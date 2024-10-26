using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmMonthlyExpensesAndProfits : Form
    {
        public FrmMonthlyExpensesAndProfits()
        {
            InitializeComponent();

            //carregando os dados
            Task.Run(() => Initialize());
        }
        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadProfitsData())
            {
                HideColumnsProfits();
                ChangeColumnsProfits();
            }

            if (LoadExpensesData())
            {
                HideColumnsExpenses();
                ChangeColumnsExpenses();
            }
        }

        // ------ Lucros do mês
        private bool LoadProfitsData()
        {
            DataTable dataTable = DataConsultant.ViewMonthProfits(DateTime.Now.Year, DateTime.Now.Month);

            if (dataTable != null)
            {
                TakeDataFromDataTable(dataTable, this.LblProfits);

                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(DgvProfits, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumnsProfits()
        {
            ThreadHelper.SetColumnVisibility(this.DgvProfits, 0, false);//mudando a visibilidade da coluna id
        }

        private void ChangeColumnsProfits()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvProfits, 1, "Nome");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvProfits, 1, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvProfits, 2, "Valor R$");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvProfits, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvProfits, 3, "Data");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvProfits, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvProfits, 4, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvProfits, 4, DataGridViewAutoSizeColumnMode.Fill);
        }

        // ------ Gastos do mês
        private bool LoadExpensesData()
        {
            DataTable dataTable = DataConsultant.ViewMonthExpenses(DateTime.Now.Year, DateTime.Now.Month);

            if (dataTable != null)
            {
                TakeDataFromDataTable(dataTable, this.LblExpenses);

                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(DgvExpenses, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumnsExpenses()
        {
            ThreadHelper.SetColumnVisibility(this.DgvExpenses, 0, false);//mudando a visibilidade da coluna id
        }

        private void ChangeColumnsExpenses()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvExpenses, 1, "Nome");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvExpenses, 1, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvExpenses, 2, "Valor R$");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvExpenses, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvExpenses, 3, "Data do pagamento");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvExpenses, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvExpenses, 4, "Categoria");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvExpenses, 4, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvExpenses, 5, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvExpenses, 5, DataGridViewAutoSizeColumnMode.Fill);
        }

        // Método que soma os valores dos gastos e lucros e imprime os valores
        private void TakeDataFromDataTable(DataTable dataTable, Label label)
        {
            decimal FixedProfits = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                FixedProfits += Convert.ToDecimal(row["value"]);// capturando o valor
            }

            ThreadHelper.SetPropertyValue(label, "Text", "R$: " + FixedProfits.ToString("F2"));
        }
    }
}
