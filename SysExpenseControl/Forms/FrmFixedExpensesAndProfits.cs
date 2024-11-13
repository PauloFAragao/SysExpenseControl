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
            FrmAddEditFixedProfits frmAddEditFixedProfits = new FrmAddEditFixedProfits(0, CallLoadFixedProfitsData);
            frmAddEditFixedProfits.ShowDialog();
        }

        private void DelFixedProfits()
        {
            if (DgvFixedProfits.Rows.Count > 0)
            {
                if (MessageBox.Show(
                    "Confirme para deletar: " + this.DgvFixedProfits.CurrentRow.Cells["name"].Value,
                    "Deletar Receita Fixa?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataConsultant.DeleteFixedProfit(
                        Convert.ToInt32(this.DgvFixedProfits.CurrentRow.Cells["id"].Value));

                    //carregando os dados
                    Task.Run(() => LoadFixedProfitsData());
                }
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void ViewEditFixedProfits(int tipe)
        {
            if (DgvFixedProfits.Rows.Count > 0)
            {
                FrmAddEditFixedProfits frmAddEditFixedProfits = new FrmAddEditFixedProfits(tipe, CallLoadFixedProfitsData,
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

        private void AddFixedExpenses()
        {
            FrmAddEditFixedExpenses frmAddEditFixedExpenses = new FrmAddEditFixedExpenses(0, CallLoadFixedExpensesData);
            frmAddEditFixedExpenses.ShowDialog();
        }

        private void DelFixedExpenses()
        {
            if (DgvFixedExpenses.Rows.Count > 0)
            {
                if (MessageBox.Show(
                    "Confirme para deletar: " + this.DgvFixedExpenses.CurrentRow.Cells["name"].Value,
                    "Deletar Gasto Fixo?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataConsultant.DeleteFixedExpense(
                        Convert.ToInt32(this.DgvFixedExpenses.CurrentRow.Cells["id"].Value));



                    //carregando os dados
                    Task.Run(() => LoadFixedExpensesData());
                }
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void ViewEditFixedExpenses(int tipe)
        {
            if (DgvFixedExpenses.Rows.Count > 0)
            {
                FrmAddEditFixedExpenses frmAddEditFixedExpenses = new FrmAddEditFixedExpenses(tipe, CallLoadFixedExpensesData,
                    Convert.ToInt32(this.DgvFixedExpenses.CurrentRow.Cells["id"].Value),
                    Convert.ToString(this.DgvFixedExpenses.CurrentRow.Cells["name"].Value),
                    Convert.ToDouble(this.DgvFixedExpenses.CurrentRow.Cells["value"].Value),
                    Convert.ToInt32(this.DgvFixedExpenses.CurrentRow.Cells["dueDay"].Value),
                    Convert.ToInt32(this.DgvFixedExpenses.CurrentRow.Cells["numberOfInstallments"].Value),
                    Convert.ToString(this.DgvFixedExpenses.CurrentRow.Cells["categorieName"].Value),
                    Convert.ToString(this.DgvFixedExpenses.CurrentRow.Cells["description"].Value));

                frmAddEditFixedExpenses.ShowDialog();
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        // ------------------------- Eventos
        private void CallLoadFixedProfitsData()
        {
            Task.Run(() => LoadFixedProfitsData());
        }

        private void CallLoadFixedExpensesData()
        {
            Task.Run(() => LoadFixedExpensesData());
        }

        // ------------------------- Thread
        private void Initialize()
        {
            bool allDone = true;

            if (LoadFixedProfitsData())
            {
                HideColumnsFixedProfits();
                ChangeColumnsFixedProfits();

                ThreadHelper.SetDefaultCellStyle(DgvFixedProfits, "value");// para a coluna dos valores ter ,00
            }
            else allDone = false;

            if (LoadFixedExpensesData())
            {
                HideColumnsFixedExpenses();
                ChangeColumnsFixedExpenses();

                ThreadHelper.SetDefaultCellStyle(DgvFixedExpenses, "value");// para a coluna dos valores ter ,00
            }
            else allDone = false;

            if(allDone)
            {
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);// retirando o label wait da tela

                ThreadHelper.SetPropertyValue(TabControl, "Enabled", true);// habilitando tudo
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

            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 4, "Quantidade de parcelas restante");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 4, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 5, "Categoria");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 5, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvFixedExpenses, 6, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvFixedExpenses, 6, DataGridViewAutoSizeColumnMode.Fill);
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
            ViewEditFixedProfits(1);
        }

        private void BtnViewFixedProfits_Click(object sender, EventArgs e)
        {
            ViewEditFixedProfits(2);
        }

        private void BtnAddFixedExpenses_Click(object sender, EventArgs e)
        {
            AddFixedExpenses();
        }

        private void BtnDelFixedExpenses_Click(object sender, EventArgs e)
        {
            DelFixedExpenses();
        }

        private void BtnEditFixedExpenses_Click(object sender, EventArgs e)
        {
            ViewEditFixedExpenses(1);
        }

        private void BtnViewFixedExpenses_Click(object sender, EventArgs e)
        {
            ViewEditFixedExpenses(2);
        }
    }

}
