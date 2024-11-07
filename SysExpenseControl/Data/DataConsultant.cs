using System;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Collections.Generic;

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
            string viewQuery = "Select * From categories";

            return ViewQuery(viewQuery);
        }

        // Método que vai pegar os nomes das categorias
        public static List<string> GetCategorys()
        {
            string query = "Select name From categories Order by id";

            List<string> result = new List<string>();

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
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Adiciona o nome da categoria à lista
                                result.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.GetCategorys: " + e.Message);
            }

            return result;
        }

        // Método para inserir uma categoria
        public static void InsertCategory(string name, string description)
        {
            string insertQuery = $"Insert Into categories Values ('{name}', '{description}')";

            SimpleQuery(insertQuery);
        }

        // Método para editar uma categoria
        public static void EditCategory(int id, string name, string description)
        {
            string editQuery = $"Update categories Set name = '{name}', description = '{description}' Where id = {id} ";

            SimpleQuery(editQuery);
        }

        // Deleta uma categoria
        public static void DeleteCategory(int id)
        {
            string deleteQuery = $"Delete From categories where id = {id} ";

            SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Lucros fixos
        // Método para visualizar todas os lucros fixos
        public static DataTable ViewFixedProfits()
        {
            string viewQuery = $"Select * From fixed_profits";

            return ViewQuery(viewQuery);
        }

        // Método para Inserir uma fonte de lucro fixa
        public static void InsertFixedProfit(string name, double value, string description)
        {
            string insertQuery = $"Insert Into fixed_profits (name, value, description) "
                + $"Values ('{name}', {value.ToString(CultureInfo.InvariantCulture)}, '{description}')";

            SimpleQuery(insertQuery);
        }

        // Método para editar uma fonte de lucro fixa
        public static void EditFixedProfit(int id, string name, double value, string description)
        {
            string editQuery =
                "Update fixed_profits "
                + $"Set name = '{name}', "
                + $"value = {value.ToString(CultureInfo.InvariantCulture)}, "
                + $"description = '{description}' "
                + $"Where id = {id}";

            SimpleQuery(editQuery);
        }

        // Método que vai deletar um lucro fixo
        public static void DeleteFixedProfit(int id)
        {
            string deleteQuery = $"Delete From fixed_profits where id = {id} ";

            SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Gastos fixos
        // Método para visualizar os gastos fixos
        public static DataTable ViewFixedExpenses()
        {
            //string viewQuery = "Select * From fixed_expenses";

            string viewQuery =
            "Select "
            + "f.id, f.name, "
            + "f.value, f.dueDay, f.numberOfInstallments, "
            + "c.name As categorieName, "
            + "f.description "
            + "From fixed_expenses f "
            + "Join categories c On f.category = c.id ";

            return ViewQuery(viewQuery);
        }

        // Método para visualizar as contas
        public static DataTable ViewAccountsPayable()
        {
            string expensesTableName = "expenses_" + DateTime.Now.Year + "_" + DateTime.Now.Month;
            string viewQuery = "Select f.id, f.name, e.value, f.dueDay, f.numberOfInstallments, f.category, "
            + "c.name As categorieName, e.date As dayItWasPaid "
            + "From fixed_expenses f "
            + "Join categories c On f.category = c.id "
            + $"Join {expensesTableName} e On f.id = e.idFixedExpenses "
            + $"Where f.category = 1 Order by dueDay Desc";

            return ViewQuery(viewQuery);
        }

        // Novo método para visualizar as contas <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public static DataTable ViewBills(DateTime date)
        {
            string expensesTableName = "expenses_" + date.Year + "_" + date.Month;
            string viewQuery = "Select  ";

            return ViewQuery(viewQuery);
        }

        // Método para Inserir um gasto fixo
        public static int InsertFixedExpense(string name, double value, int dueDay, int numberOfInstallments,
            string category, string description, bool definedNumberOfInstallments)
        {
            string insertQuery =
                $"Insert Into fixed_expenses "
                + "(name, value, dueDay, numberOfInstallments, definedNumberOfInstallments, category, description)"
                + $"Values ('{name}', {value.ToString(CultureInfo.InvariantCulture)}, "
                + $"{dueDay}, {numberOfInstallments}, {definedNumberOfInstallments}, "
                + $"(Select id From categories where name = '{category}'), "
                + $"'{description}')";

            //SimpleQuery(insertQuery);
            return InsertQuery(insertQuery);
        }

        // Método para Editar um gasto fixo
        public static void EditFixedExpense(int id, string name, double value, int dueDay, int numberOfInstallments,
            string category, string description, bool definedNumberOfInstallments)
        {
            string editQuery =
                "Update fixed_expenses "
                + $"Set name = '{name}', "
                + $"value = {value.ToString(CultureInfo.InvariantCulture)}, "
                + $"dueDay = {dueDay}, "
                + $"numberOfInstallments = {numberOfInstallments}, "
                + $"definedNumberOfInstallments = {definedNumberOfInstallments}, "
                + $"category = (Select id From categories where name = '{category}'), "
                + $"description = '{description}' "
                + $"Where id = {id}";

            SimpleQuery(editQuery);
        }

        // Método para subtrair ou somar 1 na quantidade de parcelas de uma conta
        public static void EditInstallment(int id, bool subtract)
        {
            string editQuery = "Update fixed_Expenses "
                + "Set numberOfInstallments = ";

            if (subtract)// para subtrair uma prestação
            {
                editQuery += "Case When numberOfInstallments > 0 Then numberOfInstallments - 1 Else 0 End ";
            }
            else// para somar uma prestação
            {
                editQuery += "numberOfInstallments + 1 ";
            }

            editQuery += $"Where id = {id}";

            SimpleQuery(editQuery);
        }

        // Método para deletar um gasto fixo
        public static void DeleteFixedExpense(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.Cn))
                {
                    // Abre a conexão
                    connection.Open();

                    // Ativa as restrições de chaves estrangeiras
                    using (SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON", connection))
                    {
                        // Executa a consulta e captura o resultado
                        command.ExecuteNonQuery();
                    }

                    // Deleta o registro da tabela fixed_expenses com id = {id}
                    using (SQLiteCommand command = new SQLiteCommand($"Delete From fixed_expenses where id = {id}", connection))
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

        // ---------------------------------- Lucros do mês
        // Método para visualizar todos os lucros de um mês
        public static DataTable ViewMonthProfits(int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string viewQuery = $"Select * From {profitsTableName}";

            return ViewQuery(viewQuery);
        }

        // Método para inserir um lucro no mês
        public static void InsertMonthProfits(string name, double value, DateTime? date, string description,
            int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;

            string insertQuery = $"Insert Into {profitsTableName} (name, value, ";
            string values = $"Values ('{name}', {value.ToString(CultureInfo.InvariantCulture)}, ";

            if (date != null)
            {
                insertQuery += "date, ";
                values += $"'{date:yyyy-MM-dd}', ";
            }

            insertQuery += "description) ";
            values += $"'{description}')";

            SimpleQuery(insertQuery + values);
        }

        // Método para Editar um lucro do mês
        public static void EditMonthProfits(int id, string name, double value, DateTime date,
            string description, string tableName)
        {
            string editQuery =
                $"Update {tableName} "
                + $"Set name = '{name}', "
                + $"value = {value.ToString(CultureInfo.InvariantCulture)}, "
                + $"date = '{date:yyyy-MM-dd}', "
                + $"description = '{description}' "
                + $"Where id = {id}";

            SimpleQuery(editQuery);
        }

        // Método para deletar lucro no mês
        public static void DeleteMonthProfits(int id, int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string deleteQuery = $"Delete From {profitsTableName} where id = {id} ";

            SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Gastos do mês
        // Método para visualizar todos os lucros de um mês
        public static DataTable ViewMonthExpenses(int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;

            string viewQuery =
                "Select "
                + "f.id, f.name, f.value, f.date, c.name As categorieName, e.numberOfInstallments, "
                + "f.description, f.idFixedExpenses, f.paid, e.definedNumberOfInstallments "
                + $"From {expensesTableName} f "
                + "Join categories c On f.category = c.id "
                + "Left Join fixed_expenses e On f.idFixedExpenses = e.id "
                + $"Order by f.date Asc";

            return ViewQuery(viewQuery);
        }

        // Método para inserir um gasto no mês
        public static void InsertMonthExpense(string name, double value, DateTime? dateOfExpenditure,
            int idFixedExpenses, string category, string description, int year, int month, bool paid,
            string fixedExpense = "")
        {
            string expensesTableName = "expenses_" + year + "_" + month;

            string insertQuery = $"Insert Into {expensesTableName} (name, value, category, paid, ";
            string values = $"Values ('{name}', {value.ToString(CultureInfo.InvariantCulture)}, "
                + $"(Select id From categories where name = '{category}'), {paid}, ";

            // Se já vai inserir com uma data
            if (dateOfExpenditure != null)
            {
                insertQuery += "date, ";
                values += $"'{dateOfExpenditure:yyyy-MM-dd}', ";
            }

            // se tem referencia a tabela de gastos fixos
            if (idFixedExpenses != -1)
            {
                insertQuery += "idFixedExpenses, ";
                values += $"{idFixedExpenses}, ";
            }

            // Referencia a tabela de gastos fixos pelo nome do gasto
            if (fixedExpense != "")
            {
                insertQuery += "idFixedExpenses, ";
                values += $"(Select id From fixed_expenses Where name = {fixedExpense}), ";
            }

            insertQuery += "description) ";
            values += $"'{description}')";

            SimpleQuery(insertQuery + values);
        }

        // Método para Editar um gasto do mês
        public static void EditMonthExpense(int id, string name, double value, DateTime dateOfExpenditure,
            string category, string description, string tableName, bool paid)
        {
            string editQuery =
                $"Update {tableName} "
                + $"Set name = '{name}', "
                + $"value = {value.ToString(CultureInfo.InvariantCulture)}, "
                + $"category = (Select id From categories Where name = '{category}'), "
                + $"paid = {paid}, ";

            if (paid) editQuery += $"date = '{dateOfExpenditure:yyyy-MM-dd}', ";
            else editQuery += "date = NULL, ";

            editQuery +=
                $"description = '{description}' "
                + $"Where id = {id}";

            SimpleQuery(editQuery);
        }

        // Método para Deletar um gasto no mês
        public static void DeleteMonthExpense(int id, int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;
            string deleteQuery = $"Delete From {expensesTableName} where id = {id} ";

            SimpleQuery(deleteQuery);
        }

        // ---------------------------------- Tabela de referencias

        // Método que vai retornar a quantidade de referencias na tabela references_to_tables
        public static int GetReferences_to_tablesQuantity()
        {
            int quantity = 0;

            string query = "Select Count(*) From references_to_tables;";

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
                        quantity = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.SimpleQuery: " + e.Message);

                quantity = 0;
            }

            return quantity;
        }

        // ---------------------------------- 
        public static DataTable ViewReserves()
        {
            string viewQuery = "Select * From references_to_reserves";

            return ViewQuery(viewQuery);
        }

        // ---------------------------------- 
        private static void SimpleQuery(string query)
        {
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
                        //command.ExecuteScalar();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.SimpleQuery: " + e.Message);
            }
        }

        private static int InsertQuery(string query)
        {
            int id = -1;

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
                        command.ExecuteNonQuery();
                    }

                    // capturar o id 
                    using (SQLiteCommand command = new SQLiteCommand("SELECT last_insert_rowid();", connection))
                    {
                        id = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.SimpleQuery: " + e.Message);

                id = -1;
            }

            return id;
        }

        private static DataTable ViewQuery(string query)
        {
            DataTable dtResult = new DataTable("data");
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
