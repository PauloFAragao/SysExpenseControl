﻿using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SysExpenseControl.Data
{
    static class DatabaseManager
    {
        // Verifica se existe o arquivo do banco de dados do Sqlite e se não cria o arquivo e as tabelas
        public static void CheckIfDatabaseExists()
        {
            string filePath = @"./" + Connection.TableName;

            if (!File.Exists(filePath))
            {
                //Debug.WriteLine("não tem um arquivo");

                CreateTables();
                InsertDemoCategories();// cria as categorias de demonstração
                CreateDynamicTable_Reserve("Reserva Geral", "Uma reserva de dinheiro para fins gerais");// cria uma reserva de dinheiro basica

            }
            else
            {
                //Debug.WriteLine("Tem um arquivo");
            }
        }

        // Cria as tabelas basicas do banco de dados
        private static void CreateTables()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    //------------------------------------ string das querys para criar as tabelas
                    // Categorias
                    string createTableCategories =
                        "Create Table If Not Exists categories("
                        + "id Integer Primary Key,"
                        + "name Varchar (50) Unique,"
                        + "description Text)";

                    // Lucros fixos
                    string createTableFixedProfits =
                        "Create Table If Not Exists fixed_profits("
                        + "id Integer Primary Key,"
                        + "name Varchar (50) Unique,"
                        + "value Real,"
                        + "description Text)";

                    // Gastos fixos
                    string createTableFixedExpenses =
                        "Create Table If Not Exists fixed_expenses("
                        + "id Integer Primary Key,"
                        + "name Varchar (50) Unique,"
                        + "value Real Not Null,"
                        + "dueDay Integer,"// data para o vencimento
                        + "numberOfInstallments Integer, "// parcelas restantes
                        + "definedNumberOfInstallments Bit, "// se tem uma quantidade de parcelas
                                                             //References categories (id) - indica foreign key //On Delete Set Default - quando a categoria for deletada muda para o default que é 0
                        + "category Integer References categories (id) On Delete Set Default Default '0',"// 0 Para sem categoria
                        + "description Text)";

                    // Referencias as tabelas
                    string createTableReferencesToTables =
                        "Create Table If Not Exists references_to_tables("
                        + "year Integer Not Null,"
                        + "month Integer Not Null,"
                        + "nameTableProfits Varchar(15) Unique,"
                        + "nameTableExpenses Varchar(16) Unique, "
                        + "totalProfits Real Default '0', "
                        + "totalExpenses Real Default '0')";

                    // Tabela para as referencias das tabelas das reservas de dinheiro
                    string createReferencesToTablesReserve =
                        "Create Table If Not Exists references_to_reserves("
                        + "id Integer Primary Key, "
                        + "name Varchar (50) Not Null, "
                        + "tableName Varchar (20) Not Null, "
                        + "reservationAmount Real Not Null, "
                        + "operationsQuantity Integer Default '0', "
                        + "description Text)";

                    // Tabela para as referencias das tabelas dos investimentos
                    string createTableReferencesToTablesInvestiment =
                        "Create Table If Not Exists references_to_investiments("
                        + "id Integer Primary Key, "
                        + "name Varchar (50) Not Null, "
                        + "tableName Varchar (20) Not Null, "
                        + "investmentAmount Real Not Null, "
                        + "incomeDate Date, "
                        + "description Text)";

                    //------------------------------------ Executando as querys
                    // Criando a tabela das categorias
                    using (SQLiteCommand command = new SQLiteCommand(createTableCategories, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    // Criando a tabela de lucros fixos
                    using (SQLiteCommand command = new SQLiteCommand(createTableFixedProfits, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Criando a tabela de Gastos fixos
                    using (SQLiteCommand command = new SQLiteCommand(createTableFixedExpenses, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Criando a tabela que vai conter as referencias as tabelas que forem criadas dinamicamente
                    using (SQLiteCommand command = new SQLiteCommand(createTableReferencesToTables, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Criando a tabela que vai conter as referencias as tabelas que forem criadas dinamicamente para as reservas de dinheiro
                    using (SQLiteCommand command = new SQLiteCommand(createReferencesToTablesReserve, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Criando a tabela que vai conter as referencias as tabelas que forem criadas dinamicamente para os investimentos
                    using (SQLiteCommand command = new SQLiteCommand(createTableReferencesToTablesInvestiment, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.CreateTables: " + e.Message);
            }
        }

        // Insere as categorias de demonstração
        private static void InsertDemoCategories()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Consulta
                    string insertCategories =
                        $"Insert Into categories"
                        + "(id, name, description)"
                        + "Values"
                        + "('0', 'Sem categoria', 'Gastos gerais não categorizados'),"
                        + "('1', 'Contas', 'Contas de luz, água, internet, cartão e afins'),"
                        + "('2', 'Alimentação', 'Gastos com comida, lanches, petiscos e afins'),"
                        + "('3', 'Transpote', 'Gastos com combustivel, passagens e afins'),"
                        + "('4', 'Vestuario', 'Gastos com peças de vestuario, sapatos e afins'),"
                        + "('5', 'Remédios', 'Gastos com remédios de uso contidiano ou por necessidades potuais')";

                    // Executando a Query
                    using (SQLiteCommand command = new SQLiteCommand(insertCategories, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.InsertDemoCategories: " + e.Message);
            }
        }

        // Verifica se já existem as tabelas para esse mês e cria se não
        public static void CheckIfThereAreAlreadyTablesForThisMonth()
        {
            // Verifica se já existem as tabelas desse mês
            if (!DataConsultant.QueryInReferencesToTables())
                CreateDynamicTables();// cria a tabela desse mês
        }

        // Sobrecarga do método sem argumentos
        private static void CreateDynamicTables()
        {
            CreateDynamicTables(DateTime.Now.Year, DateTime.Now.Month);

            // Deletando gastos que tem uma quantidade de parcelas definidas e já foram completados
            DeleteFullyPaidAccounts();

            // Copia das tabelas de gastos e lucros fixos para a tabela do mês corrente
            CreateProfitsAndExpenses();
        }

        // Criador de tabelas dinamico
        public static void CreateDynamicTables(int year, int month)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    //------------------------------------ string das querys para criar as tabelas
                    // Lucros do mês
                    string profitsTableName = "profits_" + year + "_" + month;// gerando o nome da tabela
                    string createTableProfits =
                        $"Create Table If Not Exists \"{profitsTableName}\"("
                        + "id Integer Primary Key,"
                        + "name Varchar (50) ,"//Unique
                        + "value Real Not Null,"
                        + "date Date,"
                        + "description Text, "
                        + "idFixedProfits Integer Null References fixed_profits (id) On Delete Set Null)";

                    // Gastos do mês
                    string expensesTableName = "expenses_" + year + "_" + month;// gerando o nome da tabela
                    string createTableExpenses =
                        $"Create Table If Not Exists \"{expensesTableName}\"( "
                        + "id Integer Primary Key, "
                        + "name Varchar (50), "//Unique
                        + "value Real Not Null, "
                        + "date Date, "
                        //References categories (id) - indica foreign key //On Delete Set Default - quando a categoria for deletada muda para o default que é 0
                        + "category Integer References categories (id) On Delete Set Default Default '0', "// 0 Para sem categoria
                        + "paid Bit Default '0', "// se já foi pago ou não
                        + "description Text, "
                        + "idFixedExpenses Integer Null References fixed_expenses (id) On Delete Set Null)";

                    //------------------------------------ Executando as querys
                    // criar tabela de lucros
                    using (SQLiteCommand command = new SQLiteCommand(createTableProfits, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    // criar tabela de gastos
                    using (SQLiteCommand command = new SQLiteCommand(createTableExpenses, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Comando para guardar os nomes
                    string insertInReferences_to_tables =
                        "Insert Into References_to_tables "
                        + "(year, month, nameTableProfits, nameTableExpenses) "
                        + "Values "
                        + "(@year, @month, @nameTableProfits, @nameTableExpenses)";

                    // Guardando os nomes das tabelas
                    using (var command = new SQLiteCommand(insertInReferences_to_tables, connection))
                    {
                        command.Parameters.AddWithValue("@year", year);
                        command.Parameters.AddWithValue("@month", month);
                        command.Parameters.AddWithValue("@nameTableProfits", profitsTableName);
                        command.Parameters.AddWithValue("@nameTableExpenses", expensesTableName);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.CreateDynamicTables: " + e.Message);
            }

            
        }

        // Adiciona os gastos e os lucros fixos aos gastos e lucros mensais
        private static void CreateProfitsAndExpenses()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Query para copiar os lucros
                    string profitsTableName = "profits_" + DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month;// nome da tabela
                    string insertProfits = // Query para copiar os lucros 
                        $"Insert Into {profitsTableName} "
                        + "(name, value, description, idFixedProfits)"
                        + "Select name, value, description, id "
                        + "From fixed_profits";

                    // Query para copiar os gastos
                    string expensesTableName = "expenses_" + DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month;// nome da tabela
                    string insertExpense =
                        $"Insert Into {expensesTableName} "
                        + "(name, value, category, description, idFixedExpenses) "
                        + "Select name, value, "
                        + "category, description, id "
                        + "From fixed_expenses";

                    // Copiando os lucros
                    using (SQLiteCommand command = new SQLiteCommand(insertProfits, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Copiando os gastos
                    using (SQLiteCommand command = new SQLiteCommand(insertExpense, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.CreateProfitsAndExpenses: " + e.Message);
            }
        }

        // esse método vai deletar do banco de dados todas as contas que já tiveram todas as parcelas pagas
        private static void DeleteFullyPaidAccounts()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    string query = "Delete From fixed_Expenses "
                        + "Where definedNumberOfInstallments = 1 "
                        + "And numberOfInstallments = 0";

                    // Executando a Query
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Executa a consulta e captura o resultado
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.SimpleQuery: " + e.Message);
            }
        }

        // Método que vai criar uma tabela de reserva de dinheiro dinamicamente 
        public static string CreateDynamicTable_Reserve(string name, string description)
        {
            string TableName = "fail";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Gerando nome
                    TableName = GenerateRandonTableName(name, "references_to_reserves");

                    // Query para criar a tabela
                    string createTableReserve =
                        $"Create Table If Not Exists \"{TableName}\"("
                        + "id Integer Primary Key, "
                        + "operation Varchar (10) Not Null, "// retirada / inserção
                        + "value Real Not Null, "
                        + "date Date Not Null, "
                        + "description Text)";

                    // criar tabela
                    using (SQLiteCommand command = new SQLiteCommand(createTableReserve, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // ----------------------------------------- Guardando os valores na tabela de referencias
                    // Comando para guardar os nomes
                    string insertInReferences =
                        "Insert Into references_to_reserves "
                        + "(name, tableName, reservationAmount, description)"
                        + "Values "
                        + $"('{name}', '{TableName}', 0, '{description}')";

                    // Guardando os nomes das tabelas
                    using (var command = new SQLiteCommand(insertInReferences, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.CreateDynamicTable_Reserve: " + e.Message);
            }

            return TableName;
        }

        // Método que vai criar uma tabela para um investimento
        public static void CreateDynamicTable_Investiments(string name, string description)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Gerando nome
                    string TableName = GenerateRandonTableName(name, "references_to_investiments");

                    // Query para criar a tabela
                    string createTableProfits =
                        $"Create Table If Not Exists \"{TableName}\"("
                        + "id Integer Primary Key, "
                        + "income Real Not Null, "
                        + "incomeDate Date, "
                        + "description Text)";

                    // criar tabela
                    using (SQLiteCommand command = new SQLiteCommand(createTableProfits, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // ----------------------------------------- Guardando os valores na tabela de referencias
                    // Comando para guardar os nomes
                    string insertInReferences =
                        "Insert Into references_to_reserves "
                        + "(name, tableName, investmentAmount, description)"
                        + "Values "
                        + $"('{name}', '{TableName}', 0, '{description}')";

                    // Guardando os nomes das tabelas
                    using (var command = new SQLiteCommand(insertInReferences, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.CreateDynamicTable_Reserve: " + e.Message);
            }
        }

        // Método que vai gerar um nome aleatorio para uma tabela e verificar se ele é unico
        private static string GenerateRandonTableName(string name, string tableToConsult)
        {
            string tableName = "";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Primeiro tem q limpar a string para garantir que não tem nenhum caractere ilegal
                    string result = RemoveProhibitedCharacters(name);

                    // depois tem que gerar um nome aleatorio e verificar em loop se já tem esse nome no banco de dados
                    bool loop = true;
                    while (loop)
                    {
                        // Gerando o nome aleatorio
                        tableName = result + "_" + DateTime.Now.Millisecond;

                        // Query para verificar se o nome é unico
                        string createTableProfits =
                        $"Select Exists (Select 1 From {tableToConsult} "
                        + "Where tableName = @tableName)";

                        // Executando a query
                        using (SQLiteCommand command = new SQLiteCommand(createTableProfits, connection))
                        {
                            command.Parameters.AddWithValue("@tableName", tableName);

                            loop = Convert.ToBoolean(command.ExecuteScalar());// se retornar true o loop continua
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.GenerateRandonTableName: " + e.Message);
            }

            return tableName;
        }

        // Método que retira da string caracteres que não podem ser usados para o nome de uma tabela
        private static string RemoveProhibitedCharacters(string name)
        {
            string result = "";

            for (int i = 0; i < name.Length; i++)
            {
                if ((name[i] >= 48 && name[i] <= 57) || // números
                    (name[i] >= 65 && name[i] <= 90) || // letras maiusculas
                    (name[i] >= 97 && name[i] <= 122)) // letras minusculas
                    result += name[i];

                else
                    result += '_';
            }
            
            result = char.ToLower(result[0]) + result.Substring(1);

            return result;
        }
    }
}
