using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            DatabaseManager.CheckIfCatabaseExists();

            // Verifica se já existem as tabelas desse mês
            if (!DataConsultant.QueryInReferencesToTables())
            {
                DatabaseManager.CreateDynamicTables();// cria a tabela desse mês
                DatabaseManager.InsertDemoCategories();// cria as categorias de demonstração
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
