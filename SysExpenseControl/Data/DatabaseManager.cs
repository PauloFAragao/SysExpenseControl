using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace SysExpenseControl.Data
{
    static class DatabaseManager
    {
        // Verifica se existe o arquivo do banco de dados do Sqlite
        public static void CheckIfCatabaseExists()
        {
            string caminhoDoArquivo = @"./{" + Connection.TableName + "}";

            if (!File.Exists(caminhoDoArquivo))
            {
                CreateTables();
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

        // Insere as categorias de demonstração
        public static void InsertDemoCategories()
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
        public static void CreateDynamicTables()
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
    
    }
}
