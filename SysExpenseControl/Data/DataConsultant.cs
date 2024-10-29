﻿using System;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;
using System.Globalization;

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
                + $"Values ('{name}', '{value.ToString(CultureInfo.InvariantCulture)}', '{description}')";

            SimpleQuery(insertQuery);
        }

        // Método para editar uma fonte de lucro fixa
        public static void EditFixedProfit(int id, string name, double value, string description)
        {
            string editQuery =
                "Update fixed_profits "
                + $"Set name = '{name}', "
                + $"value = '{value.ToString(CultureInfo.InvariantCulture)}', "
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
        public static void InsertFixedExpense(string name, decimal value, int dueDay, int category, string description)
        {
            string insertQuery =
                $"Insert Into fixed_expenses "
                + "(name, value, dueDay, category, description)"
                + $"Values ('{name}', '{value}', '{dueDay}', '{category}', '{description}')";

            SimpleQuery(insertQuery);
        }

        // Método para Editar um gasto fixo
        public static void EditFixedExpense(int id, string name, decimal value, int dueDay, int category, string description)
        {
            string editQuery =
                "Update fixed_expenses "
                + $"Set name = '{name}', "
                + $"value = '{value}', "
                + $"dueDay = '{dueDay}', "
                + $"category = '{category}'"
                + $"description = '{description}' "
                + $"Where id = {id}";

            SimpleQuery(editQuery);
        }

        // Método para deletar um gasto fixo
        public static void DeleteFixedExpense(int id)
        {
            string deleteQuery = $"Delete From fixed_expenses where id = {id} ";

            SimpleQuery(deleteQuery);
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
        public static void InsertMonthProfits(string name, decimal value, string description, int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string insertQuery = $"Insert Into {profitsTableName} Values ('{name}', '{value}', '{description}')";

            SimpleQuery(insertQuery);
        }

        // Método para Editar um gasto fixo
        public static void EditMonthProfits(int id, string name, decimal value, string description, int year, int month)
        {
            string profitsTableName = "profits_" + year + "_" + month;
            string editQuery =
                $"Update {profitsTableName} "
                + $"Set name = '{name}', "
                + $"value = '{value}', "
                + $"description = '{description}' "
                + $"Where id = '{id}'";

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
        public static void InsertMonthExpense(string name, decimal value, DateTime dateOfExpenditure, int category, string description, int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;
            string insertQuery = $"Insert Into {expensesTableName} Values ('{name}', '{value}', '{dateOfExpenditure}', '{category}', '{description}')";

            SimpleQuery(insertQuery);
        }

        // Método para Editar um gasto fixo
        public static void EditMonthProfits(int id, string name, decimal value, DateTime dateOfExpenditure, int category, string description, int year, int month)
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

            SimpleQuery(editQuery);
        }

        // Método para Deletar um gasto no mês
        public static void DeleteMonthExpense(int id, int year, int month)
        {
            string expensesTableName = "expenses_" + year + "_" + month;
            string deleteQuery = $"Delete From {expensesTableName} where id = {id} ";

            SimpleQuery(deleteQuery);
        }

        // ---------------------------------- 
        public static DataTable ViewReserves()//references_to_reserves
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
                        command.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in DataConsultant.SimpleQuery: " + e.Message);
            }
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
