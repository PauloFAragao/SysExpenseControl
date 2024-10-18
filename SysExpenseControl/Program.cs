using System;
using System.Windows.Forms;
using SysExpenseControl.Data;


namespace SysExpenseControl
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseManager.CheckIfDatabaseExists();
            DatabaseManager.CheckIfThereAreAlreadyTablesForThisMonth();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
