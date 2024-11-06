using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmMonthlyExpensesAndProfits : Form
    {
        DateTime _date;

        public FrmMonthlyExpensesAndProfits()
        {
            InitializeComponent();

            //Mês corrente
            _date = DateTime.Now;
            this.LblProftsMonth.Text = _date.ToString("MMMM");
            this.LblExepencesMonth.Text = _date.ToString("MMMM");
            this.LblMonth.Text = _date.ToString("MM/yyyy");
            //this.LblDisplayMonth.Text = DateTime.Now.ToString("MM/yyyy");// para exibir o mês atual

            //carregando os dados
            Task.Run(() => Initialize());
        }

        private void AddProfit()
        {
            FrmAddEditMonthProfits frmAddEditMonthProfits = new FrmAddEditMonthProfits(0,
                CallLoadProfitsData, DateTime.Now, "profits_" + _date.Year + "_" + _date.Month);
            frmAddEditMonthProfits.ShowDialog();
        }

        private void DelProfit()
        {
            if (DgvProfits.Rows.Count > 0)
            {
                if (MessageBox.Show(
                    "Confirme para deletar: " + this.DgvProfits.CurrentRow.Cells["name"].Value,
                    "Deletar Receita?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataConsultant.DeleteMonthProfits(
                        Convert.ToInt32(this.DgvProfits.CurrentRow.Cells["id"].Value),
                        _date.Year, _date.Month);

                    //carregando os dados
                    Task.Run(() => LoadProfitsData());
                }
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void ViewEditProfit(int tipe)
        {
            if (DgvProfits.Rows.Count > 0)
            {
                DateTime date;

                // Verificando se o campo data está vazio e capturando o valor
                if (DateTime.TryParse(this.DgvProfits.CurrentRow.Cells["date"].Value.ToString(),
                    out DateTime dateValue))
                    date = dateValue;

                else
                    date = DateTime.Now;

                FrmAddEditMonthProfits frmAddEditMonthProfits = new FrmAddEditMonthProfits(tipe,
                    CallLoadProfitsData,
                    date,
                    "profits_" + _date.Year + "_" + _date.Month,// nome da tabela
                    Convert.ToInt32(this.DgvProfits.CurrentRow.Cells["id"].Value),
                    Convert.ToString(this.DgvProfits.CurrentRow.Cells["name"].Value),
                    Convert.ToDouble(this.DgvProfits.CurrentRow.Cells["value"].Value),
                    Convert.ToString(this.DgvProfits.CurrentRow.Cells["description"].Value));

                frmAddEditMonthProfits.ShowDialog();
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void AddExpense()
        {
            FrmAddEditMonthExpenses frmAddEditMonthExpenses = new FrmAddEditMonthExpenses(0,
                CallLoadExpensesData, DateTime.Now, "expenses_" + _date.Year + "_" + _date.Month);
            frmAddEditMonthExpenses.ShowDialog();
        }

        private void DelExpense()
        {
            if (DgvExpenses.Rows.Count > 0)
            {
                if (MessageBox.Show(
                    "Confirme para deletar: " + this.DgvExpenses.CurrentRow.Cells["name"].Value,
                    "Deletar Receita?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataConsultant.DeleteMonthExpense(
                        Convert.ToInt32(this.DgvExpenses.CurrentRow.Cells["id"].Value),
                        _date.Year, _date.Month);

                    //carregando os dados
                    Task.Run(() => LoadExpensesData());
                }
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void ViewEditExepense(int tipe)
        {
            if (DgvExpenses.Rows.Count > 0)
            {
                DateTime date;

                // Verificando se o campo data está vazio e capturando o valor
                if (DateTime.TryParse(this.DgvExpenses.CurrentRow.Cells["date"].Value.ToString(),
                    out DateTime dateValue))
                    date = dateValue;

                else
                    date = DateTime.Now;

                FrmAddEditMonthExpenses frmAddEditMonthExpenses = new FrmAddEditMonthExpenses(tipe,
                CallLoadExpensesData, date, "expenses_" + _date.Year + "_" + _date.Month,
                Convert.ToInt32(this.DgvExpenses.CurrentRow.Cells["id"].Value),
                Convert.ToString(this.DgvExpenses.CurrentRow.Cells["name"].Value),
                Convert.ToDouble(this.DgvExpenses.CurrentRow.Cells["value"].Value),
                Convert.ToString(this.DgvExpenses.CurrentRow.Cells["categorieName"].Value),
                Convert.ToString(this.DgvExpenses.CurrentRow.Cells["description"].Value),
                Convert.ToInt32(this.DgvExpenses.CurrentRow.Cells["idFixedExpenses"].Value),
                Convert.ToBoolean(this.DgvExpenses.CurrentRow.Cells["paid"].Value));

                frmAddEditMonthExpenses.ShowDialog();
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
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
            ThreadHelper.SetColumnVisibility(this.DgvExpenses, 0, false);// mudando a visibilidade da coluna id
            ThreadHelper.SetColumnVisibility(this.DgvExpenses, 6, false);// coluna com os ids a tabela de gastos fixos
            ThreadHelper.SetColumnVisibility(this.DgvExpenses, 7, false);// coluna que indica que já foi pago
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
            decimal value = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["date"].ToString() != "")
                {
                    value += Convert.ToDecimal(row["value"]);// capturando o valor
                }
            }

            ThreadHelper.SetPropertyValue(label, "Text", "R$: " + value.ToString("F2"));
        }

        // ------------------------- Eventos
        private void CallLoadProfitsData()
        {
            Task.Run(() => LoadProfitsData());
        }

        private void CallLoadExpensesData()
        {
            Task.Run(() => LoadExpensesData());
        }

        // ------------------------- Métodos criados pelo visual studo
        private void BtnAddProfits_Click(object sender, EventArgs e)
        {
            AddProfit();
        }

        private void BtnDelProfits_Click(object sender, EventArgs e)
        {
            DelProfit();
        }

        private void BtnEditProfits_Click(object sender, EventArgs e)
        {
            ViewEditProfit(1);
        }

        private void BtnViewProfits_Click(object sender, EventArgs e)
        {
            ViewEditProfit(2);
        }

        private void BtnAddExpenses_Click(object sender, EventArgs e)
        {
            AddExpense();
        }

        private void BtnDelExpenses_Click(object sender, EventArgs e)
        {
            DelExpense();
        }

        private void BtnEditExpenses_Click(object sender, EventArgs e)
        {
            ViewEditExepense(1);
        }

        private void BtnViewExpenses_Click(object sender, EventArgs e)
        {
            ViewEditExepense(2);
        }
    }
}
