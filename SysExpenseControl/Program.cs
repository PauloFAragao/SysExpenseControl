using System;
using System.Windows.Forms;
using SysExpenseControl.Data;

//https://www.youtube.com/shorts/aCQ-WGKCJWg

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
            // Verifica se já tem o arquivo do banco de dados
            DatabaseManager.CheckIfDatabaseExists();
            // Verifica se já tem as tabelas do mês
            DatabaseManager.CheckIfThereAreAlreadyTablesForThisMonth();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
