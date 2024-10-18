using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

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
                        + "name Varchar (50),"
                        + "description Text)";

                    // Lucros fixos
                    string createTableFixedProfits =
                        "Create Table If Not Exists fixed_profits("
                        + "id Integer Primary Key,"
                        + "name Varchar (50),"
                        + "value Decimal,"
                        + "description Text)";

                    // Gastos fixos
                    string createTableFixedExpenses =
                        "Create Table If Not Exists fixed_expenses("
                        + "id Integer Primary Key,"
                        + "name Varchar (50),"
                        + "value Decimal Not Null,"
                        + "dueDay Integer,"// data para o vencimento 
                                           //References categories (id) - indica foreign key //On Delete Set Default - quando a categoria for deletada muda para o default que é 0
                        + "category Integer References categories (id) On Delete Set Default Default '0',"// 0 Para sem categoria
                        + "description Text)";

                    // Tabela para as referencias das tabelas das reservas de dinheiro
                    string createReferencesToTablesReserve =
                        "Create Table If Not Exists references_to_reserves("
                        + "id Integer Primary Key, "
                        + "tableName Varchar (50) Not Null, "
                        + "reservationAmount Decimal Not Null, "
                        + "description Text)";

                    // Referencias as tabelas
                    string createTableReferencesToTables =
                        "Create Table If Not Exists references_to_tables("
                        + "year Integer Not Null,"
                        + "month Integer Not Null,"
                        + "nameOfTheTableProfits Varchar(10),"
                        + "nameOfTheTableExpenses Varchar(10))";

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

                    // Criando a tabela que vai conter as referencias as tabelas que forem criadas dinamicamente para as reservas de dinheiro
                    using (SQLiteCommand command = new SQLiteCommand(createReferencesToTablesReserve, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Criando a tabela que vai conter as referencias as tabelas que forem criadas dinamicamente
                    using (SQLiteCommand command = new SQLiteCommand(createTableReferencesToTables, connection))
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

        // Verifica se já existem as tabelas para esse mês e cria se não
        public static void CheckIfThereAreAlreadyTablesForThisMonth()
        {
            // Verifica se já existem as tabelas desse mês
            if (!DataConsultant.QueryInReferencesToTables())
                CreateDynamicTables();// cria a tabela desse mês
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
                        + "(name, description)"
                        + "Values"
                        + "('Alimentação', 'Gastos com comida, lanches, petiscos e afins'),"
                        + "('Transpote', 'Gastos com combustivel, passagens e afins'),"
                        + "('Vestuario', 'Gastos com peças de vestuario, sapatos e afins'),"
                        + "('Contas', 'Contas de luz, água, internet, cartão e afins'),"
                        + "('remédios', 'Gastos com remédios ded uso contidiano ou por necessidades potuais')";

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

        // Criador de tabelas dinamico
        private static void CreateDynamicTables()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    //pegando o ano e o mês
                    int year = DateTime.Now.Date.Year;
                    int month = DateTime.Now.Date.Month;

                    //------------------------------------ string das querys para criar as tabelas
                    // Lucros do mês
                    string profitsTableName = "profits_" + year + "_" + month;// gerando o nome da tabela
                    string createTableProfits =
                        $"Create Table If Not Exists \"{profitsTableName}\"("
                        + "id Integer Primary Key,"
                        + "name Varchar (50),"
                        + "value Decimal Not Null,"
                        + "description Text)";

                    // Gastos do mês
                    string expensesTableName = "expenses_" + year + "_" + month;// gerando o nome da tabela
                    string createTableExpenses =
                        $"Create Table If Not Exists \"{expensesTableName}\"("
                        + "id Integer Primary Key,"
                        + "name Varchar (50),"
                        + "value Decimal Not Null,"
                        + "dateOfExpenditure Date,"
                        //References categories (id) - indica foreign key //On Delete Set Default - quando a categoria for deletada muda para o default que é 0
                        + "category Integer References categories (id) On Delete Set Default Default '0',"// 0 Para sem categoria
                        + "description Text)";

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
                        + "(year, month, nameOfTheTableProfits, nameOfTheTableExpenses) "
                        + "Values "
                        + "(@year, @month, @nameOfTheTableProfits, @nameOfTheTableExpenses)";

                    // Guardando os nomes das tabelas
                    using (var command = new SQLiteCommand(insertInReferences_to_tables, connection))
                    {
                        command.Parameters.AddWithValue("@year", year);
                        command.Parameters.AddWithValue("@month", month);
                        command.Parameters.AddWithValue("@nameOfTheTableProfits", profitsTableName);
                        command.Parameters.AddWithValue("@nameOfTheTableExpenses", expensesTableName);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.CreateDynamicTables: " + e.Message);
            }

            CreateProfitsAndExpenses();
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

                    string profitsTableName = "profits_" + DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month;// nome da tabela
                    string insertProfits = // Query para copiar os lucros
                        $"Insert Into {profitsTableName} "
                        + "(name, value, description)"
                        + "Select name, value, description "
                        + "From fixed_profits";

                    // Query para copiar os gastos
                    string expensesTableName = "expenses_" + DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month;// nome da tabela
                    string insertExpense =
                        $"Insert Into {expensesTableName} "
                        + "(name, value, dateOfExpenditure, category, description) "
                        + "Select name, value, "
                        + "date(strftime('%Y-%m', 'now') || '-' || printf('%02d', dueDay))"// transformando int em date
                        + ", category, description "
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

        // Método que vai criar uma tabela de serva de dinheiro dinamicamente 
        public static void CreateDynamicTable_Reserve(string name, string description)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Gerando nome
                    string TableName = GenerateRandonTableName(name, "references_to_reserves");

                    // Query para criar a tabela
                    string createTableProfits =
                        $"Create Table If Not Exists \"{TableName}\"("
                        + "id Integer Primary Key, "
                        + "operation Bit Not Null, "// 0 para subtração, 1 para adição
                        + "value Decimal Not Null, "
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
                        + "(tableName, reservationAmount, description)"
                        + "Values "
                        + $"('{TableName}', 0, '{description}')";

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

            return result;
        }
    }
}
