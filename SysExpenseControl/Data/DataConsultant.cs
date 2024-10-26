using System;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;

namespace SysExpenseControl.Data
{
    static class DataConsultant
    {
        // Método que verifica se já tem as tabelas referentes ao ano e mes
        public static bool QueryInReferencesToTables()
        {
            bool result = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Consulta 
                    string query = 
                        "Select Exists(Select 1 From references_to_tables "
                        + "Where year = @year And month = @month)";

                    // Executando a Query
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Adiciona parâmetros para evitar SQL Injection
                        command.Parameters.AddWithValue("@year", DateTime.Now.Date.Year);
                        command.Parameters.AddWithValue("@month", DateTime.Now.Date.Month);

                        // Executa a consulta e captura o resultado
                        result = Convert.ToBoolean(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DatabaseManager.QueryInReferencesToTables: " + e.Message);
            }

            return result;
        }

        // ---------------------------------- Categoria
        // Método para visualizar todas as categorias
        public static DataTable ViewCategory()
        {
            string viewQuery = $"Select * From categories";

            return ViewQuery(viewQuery);
        }

        // Método para inserir uma categoria
        public static string InsertCategory(string name, string description)
        {
            string insertQuery = $"Insert Into categories Values ('{name}', '{description}')";

            return SimpleQuery(insertQuery);
        }

        // Método para editar uma categoria
        public static string EditCategory(int id, string name, string description)
        {
            string editQuery = $"Update categories Set name = '{name}', description = '{description}' Where id = {id} ";

            return SimpleQuery(editQuery);
        }

        // Deleta uma categoria
        public static string DeleteCategory(int id)
        {
            string deleteQuery = $"Delete From categories where id = {id} ";

            return SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Lucros fixos
        // Método para visualizar todas os lucros fixos
        public static DataTable ViewFixedProfits()
        {
            string viewQuery = $"Select * From fixed_profits";

            return ViewQuery(viewQuery);
        }

        // Método para Inserir uma fonte de lucro fixa
        public static string InsertFixedProfit(string name, decimal value, string description)
        {
            string insertQuery = $"Insert Into fixed_profits Values ('{name}', '{value}', '{description}')";

            return SimpleQuery(insertQuery);
        }

        // Método para editar uma fonte de lucro fixa
        public static string EditFixedProfit(int id, string name, decimal value, string description)
        {
            string editQuery =
                "Update fixed_profits "
                + $"Set name = '{name}', "
                + $"value = '{value}', "
                + $"description = '{description}' "
                + $"Where id = {id})";

            return SimpleQuery(editQuery);
        }

        // Método que vai deletar um lucro fixo
        public static string DeleteFixedProfit(int id)
        {
            string deleteQuery = $"Delete From fixed_profits where id = {id} ";

            return SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Gastos fixos
        // Método para visualizar os gastos fixos
        public static DataTable ViewFixedExpenses()
        {
            //string viewQuery = "Select * From fixed_expenses";

            string viewQuery =
            "Select "
            + "f.id, f.name, "
            + "f.value, f.dueDay, "
            + "c.name As categorieName, "
            + "f.description "
            + "From fixed_expenses f "
            + "Join categories c On f.category = c.id ";

            return ViewQuery(viewQuery);
        }

        public static DataTable ViewAccountsPayable()
        {
            string expensesTableName = "expenses_" + DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month;
            string viewQuery =
            "Select "
            + "f.id, f.name, "
            + "f.value, f.dueDay, "
            + "f.category, c.name As categorieName, "
            + "e.date As dayItWasPaid "
            + "From fixed_expenses f "
            + "Join categories c On f.category = c.id "
            + $"Join {expensesTableName} e On f.id = e.idFixedExpenses "
            + $"Where f.category = 4 Order by dueDay Desc";

            return ViewQuery(viewQuery);
        }

        // Método para Inserir um gasto fixo
        public static string InsertFixedExpense(string name, decimal value, int dueDay, int category, string description)
        {
            string insertQuery =
                $"Insert Into fixed_expenses "
                + "(name, value, dueDay, category, description)"
                + $"Values ('{name}', '{value}', '{dueDay}', '{category}', '{description}')";

            return SimpleQuery(insertQuery);
        }

        // Método para Editar um gasto fixo
        public static string EditFixedExpense(int id, string name, decimal value, int dueDay, int category, string description)
        {
            string editQuery =
                "Update fixed_expenses "
                + $"Set name = '{name}', "
                + $"value = '{value}', "
                + $"dueDay = '{dueDay}', "
                + $"category = '{category}'"
                + $"description = '{description}' "
                + $"Where id = {id})";

            return SimpleQuery(editQuery);
        }

        // Método para deletar um gasto fixo
        public static string DeleteFixedExpense(int id)
        {
            string deleteQuery = $"Delete From fixed_expenses where id = {id} ";

            return SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Lucros do mês
        // Método para visualizar todos os lucros de um mês
        public static DataTable ViewMonthProfits(int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string viewQuery = $"Select * From {profitsTableName}";

            return ViewQuery(viewQuery);
        }

        // Método para inserir um lucro no mês
        public static string InsertMonthProfits(string name, decimal value, string description, int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string insertQuery = $"Insert Into {profitsTableName} Values ('{name}', '{value}', '{description}')";

            return SimpleQuery(insertQuery);
        }

        // Método para Editar um gasto fixo
        public static string EditMonthProfits(int id, string name, decimal value, string description, int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string editQuery =
                $"Update {profitsTableName} "
                + $"Set name = '{name}', "
                + $"value = '{value}', "
                + $"description = '{description}' "
                + $"Where id = '{id}')";

            return SimpleQuery(editQuery);
        }

        // Método para deletar lucro no mês
        public static string DeleteMonthProfits(int id, int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string deleteQuery = $"Delete From {profitsTableName} where id = {id} ";

            return SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Gastos do mês
        // Método para visualizar todos os lucros de um mês
        public static DataTable ViewMonthExpenses(int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;
            //string viewQuery = $"Select * From {expensesTableName}";

            string viewQuery =
                "Select "
                + "f.id, f.name, f.value, f.date, c.name As categorieName, "
                + "f.description "
                + $"From {expensesTableName} f "
                + "Join categories c On f.category = c.id "
                + $"Order by date Asc";

            return ViewQuery(viewQuery);
        }

        // Método para inserir um gasto no mês
        public static string InsertMonthExpense(string name, decimal value, DateTime dateOfExpenditure, int category, string description, int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;
            string insertQuery = $"Insert Into {expensesTableName} Values ('{name}', '{value}', '{dateOfExpenditure}', '{category}', '{description}')";

            return SimpleQuery(insertQuery);
        }

        // Método para Editar um gasto fixo
        public static string EditMonthProfits(int id, string name, decimal value, DateTime dateOfExpenditure, int category, string description, int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;
            string editQuery =
                $"Update {expensesTableName} "
                + $"Set name = '{name}', "
                + $"value = '{value}', "
                + $"dateOfExpenditure = '{dateOfExpenditure}', "
                + $"category = '{category}', "
                + $"description = '{description}' "
                + $"Where id = '{id}')";

            return SimpleQuery(editQuery);
        }

        // Método para Deletar um gasto no mês
        public static string DeleteMonthExpense(int id, int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;
            string deleteQuery = $"Delete From {expensesTableName} where id = {id} ";

            return SimpleQuery(deleteQuery);
        }

        // ---------------------------------- 
        public static DataTable ViewReserves()//references_to_reserves
        {
            string viewQuery = "Select * From references_to_reserves";

            return ViewQuery(viewQuery);
        }

        // ---------------------------------- 
        private static string SimpleQuery(string query)
        {
            string result = "";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Executando a Query
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Executa a consulta e captura o resultado
                        command.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.SimpleQuery: " + e.Message);
            }

            return result;
        }

        private static DataTable ViewQuery(string query)
        {
            DataTable dtResult = new DataTable("dados");
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Executando a consulta e capturando a resposta
                    using (SQLiteDataAdapter sqlDat = new SQLiteDataAdapter(query, connection))
                    {
                        sqlDat.Fill(dtResult);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.ViewQuery: " + e.Message);
                dtResult = null;
            }
            return dtResult;
        }

    }
}
