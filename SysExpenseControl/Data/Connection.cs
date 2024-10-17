namespace SysExpenseControl.Data
{
    static class Connection
    {
        public static string TableName = "database.db";

        public static string Cn = $"Data Source={TableName};Version=3;";
    }
}
