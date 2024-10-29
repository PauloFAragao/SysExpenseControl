using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Data;
using System.Diagnostics;
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

        private void AddFixedProfits()
        {
            FrmAddEditFixedProfits frmAddEditFixedProfits = new FrmAddEditFixedProfits(0, CallLoadData);

            frmAddEditFixedProfits.ShowDialog();
        }

        private void DelFixedProfits()
        {

        }

        private void EditFixedProfits()
        {
            if (DgvFixedProfits.Rows.Count > 0)
            {
                FrmAddEditFixedProfits frmAddEditFixedProfits = new FrmAddEditFixedProfits(1, CallLoadData,
                    Convert.ToInt32(this.DgvFixedProfits.CurrentRow.Cells["id"].Value),
                    Convert.ToString(this.DgvFixedProfits.CurrentRow.Cells["name"].Value),
                    Convert.ToDouble(this.DgvFixedProfits.CurrentRow.Cells["value"].Value),
                    Convert.ToString(this.DgvFixedProfits.CurrentRow.Cells["description"].Value));

                frmAddEditFixedProfits.ShowDialog();
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void ViewFixedProfits()
        {

        }

        // ------------------------- Eventos
        private void CallLoadData()
        {
            Task.Run(() => LoadFixedProfitsData());
        }

        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadFixedProfitsData())
            {
                HideColumnsFixedProfits();
                ChangeColumnsFixedProfits();

                ThreadHelper.SetDefaultCellStyle(DgvFixedProfits, "value");
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

        // ------------------------- Métodos criados pelo visual studio
        private void BtnAddFixedProfits_Click(object sender, EventArgs e)
        {
            AddFixedProfits();
        }

        private void BtnDelFixedProfits_Click(object sender, EventArgs e)
        {
            DelFixedProfits();
        }

        private void BtnEditFixedProfits_Click(object sender, EventArgs e)
        {
            EditFixedProfits();
        }

        private void BtnViewFixedProfits_Click(object sender, EventArgs e)
        {
            ViewFixedProfits();
        }
    }

}
