using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmFixedExpensesAndProfits : Form
    {
        public FrmFixedExpensesAndProfits()
        {
            InitializeComponent();

            //carregando os dados
            Task.Run(() => Initialize());
        }

        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadFixedProfitsData())
            {
                HideColumnsFixedProfits();
                ChangeColumnsFixedProfits();
            }

            if (LoadFixedExpensesData())
            {
                HideColumnsFixedExpenses();
                ChangeColumnsFixedExpenses();
            }
        }

        // ------ Lucros fixos
        private bool LoadFixedProfitsData()
        {
            DataTable dataTable = DataConsultant.ViewFixedProfits();

            if (dataTable != null)
            {
                TakeDataFromDataTable(dataTable, this.LblFixedProfits);

                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(DgvFixedProfits, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumnsFixedProfits()
        {
            ThreadHelper.SetColumnVisibility(this.DgvFixedProfits, 0, false);//mudando a visibilidade da coluna id
        }

        private void ChangeColumnsFixedProfits()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvFixedProfits, 1, "Nome");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedProfits, 1, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedProfits, 2, "Valor R$");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedProfits, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedProfits, 3, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedProfits, 3, DataGridViewAutoSizeColumnMode.Fill);
        }

        // ------ Gastos fixos
        private bool LoadFixedExpensesData()
        {
            DataTable dataTable = DataConsultant.ViewFixedExpenses();

            if (dataTable != null)
            {
                TakeDataFromDataTable(dataTable, this.LblFixedExpenses);

                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(DgvFixedExpenses, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumnsFixedExpenses()
        {
            ThreadHelper.SetColumnVisibility(this.DgvFixedExpenses, 0, false);//mudando a visibilidade da coluna id
        }

        private void ChangeColumnsFixedExpenses()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 1, "Nome");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 1, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 2, "Valor R$");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 3, "Dia do vencimento");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 4, "Categoria");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 4, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 5, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 5, DataGridViewAutoSizeColumnMode.Fill);
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
