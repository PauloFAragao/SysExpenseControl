using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Data;
using System.Diagnostics;
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
                    // deletando da tabela de lucros do mês
                    DataConsultant.DeleteMonthProfits(
                        Convert.ToInt32(this.DgvProfits.CurrentRow.Cells["id"].Value),
                        _date.Year, _date.Month);

                    // subtraindo o valor do lucro total (tabela references_to_tables)
                    DataConsultant.InsertProfit(
                        -1 * Convert.ToDouble(this.DgvProfits.CurrentRow.Cells["value"].Value),
                        _date.Year, _date.Month);

                    SetInLoad();// mudando para loading.

                    //carregando os dados
                    Task.Run(() => ReloadProfitsData());
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
                bool confirm;

                // Verificando se o campo data está vazio e capturando o valor
                if (DateTime.TryParse(this.DgvProfits.CurrentRow.Cells["date"].Value.ToString(),
                    out DateTime dateValue))
                {
                    date = dateValue;
                    confirm = false;
                }
                else
                {
                    date = DateTime.Now;
                    confirm = true;
                }

                FrmAddEditMonthProfits frmAddEditMonthProfits = new FrmAddEditMonthProfits(tipe,
                    CallLoadProfitsData, date,
                    "profits_" + _date.Year + "_" + _date.Month,// nome da tabela
                    Convert.ToInt32(this.DgvProfits.CurrentRow.Cells["id"].Value),
                    Convert.ToString(this.DgvProfits.CurrentRow.Cells["name"].Value),
                    Convert.ToDouble(this.DgvProfits.CurrentRow.Cells["value"].Value),
                    Convert.ToString(this.DgvProfits.CurrentRow.Cells["description"].Value), 
                    confirm);

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
                    // deletando da tabela de gastos do mês
                    DataConsultant.DeleteMonthExpense(
                        Convert.ToInt32(this.DgvExpenses.CurrentRow.Cells["id"].Value),
                        _date.Year, _date.Month);

                    // removendo o gasto na tabela references_to_tables 
                    DataConsultant.InsertExpense(
                        -1 * Convert.ToDouble(this.DgvExpenses.CurrentRow.Cells["value"].Value),
                        _date.Year, _date.Month);

                    //carregando os dados
                    Task.Run(() => ReloadExpensesData());
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
                bool confirm;

                // Verificando se o campo data está vazio e capturando o valor
                if (DateTime.TryParse(this.DgvExpenses.CurrentRow.Cells["date"].Value.ToString(),
                    out DateTime dateValue))
                    date = dateValue;
                else
                    date = DateTime.Now;
                

                // capturando se é uma conta que tem uma quantidade de parcelas para terminar
                bool definedNumberOfInstallments;
                if(bool.TryParse(this.DgvExpenses.CurrentRow.Cells["definedNumberOfInstallments"].Value.ToString(),
                     out bool value))
                {
                    definedNumberOfInstallments = value;
                }
                else definedNumberOfInstallments = false;

                // capturando a refencia a tabela de gastos fixos
                int idFixedExpenses;
                if(int.TryParse(this.DgvExpenses.CurrentRow.Cells["idFixedExpenses"].Value.ToString(), out int id))
                {
                    idFixedExpenses = id;
                }
                else idFixedExpenses = 0;

                FrmAddEditMonthExpenses frmAddEditMonthExpenses = new FrmAddEditMonthExpenses(tipe,
                    CallLoadExpensesData, date, "expenses_" + _date.Year + "_" + _date.Month,
                    Convert.ToInt32(this.DgvExpenses.CurrentRow.Cells["id"].Value),
                    Convert.ToString(this.DgvExpenses.CurrentRow.Cells["name"].Value),
                    Convert.ToDouble(this.DgvExpenses.CurrentRow.Cells["value"].Value),
                    Convert.ToString(this.DgvExpenses.CurrentRow.Cells["categorieName"].Value),
                    Convert.ToString(this.DgvExpenses.CurrentRow.Cells["description"].Value),
                    idFixedExpenses,
                    Convert.ToBoolean(this.DgvExpenses.CurrentRow.Cells["paid"].Value),
                    definedNumberOfInstallments);

                frmAddEditMonthExpenses.ShowDialog();
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void SetInLoad()
        {
            this.LblWait.Visible = true;
            this.TabControl.Enabled = false;
            this.BtnChangeMonth.Enabled = false;
        }

        // ------------------------- Thread
        private void Initialize()
        {
            bool allDone = true;

            if (LoadProfitsData())
            {
                HideColumnsProfits();
                ChangeColumnsProfits();

                ThreadHelper.SetDefaultCellStyle(DgvProfits, "value");// para a coluna dos valores ter ,00
            }
            else allDone = false;

            if (LoadExpensesData())
            {
                HideColumnsExpenses();
                ChangeColumnsExpenses();

                ThreadHelper.SetDefaultCellStyle(DgvExpenses, "value");// para a coluna dos valores ter ,00
            }
            else allDone = false;

            if (allDone)
            {
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);// retirando o label wait da tela

                ThreadHelper.SetPropertyValue(TabControl, "Enabled", true);// habilitando tudo
                ThreadHelper.SetPropertyValue(BtnChangeMonth, "Enabled", true);// habilitando o botão para mudar o mês
            }
        }

        // ------ Lucros do mês
        private bool LoadProfitsData()
        {
            DataTable dataTable = DataConsultant.ViewMonthProfits(DateTime.Now.Year, DateTime.Now.Month);

            if (dataTable != null)
            {
                // Total
                string total = "R$: ";
                total += DataConsultant.GetMonthProfit(_date.Year, _date.Month).ToString("F2");
                ThreadHelper.SetPropertyValue(LblProfits, "Text", total);

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
            ThreadHelper.SetColumnVisibility(this.DgvProfits, 5, false);//coluna idfixed profits
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

        private void ReloadProfitsData()
        {
            if(LoadProfitsData())
            {
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);// retirando o label wait da tela

                ThreadHelper.SetPropertyValue(TabControl, "Enabled", true);// habilitando tudo
                ThreadHelper.SetPropertyValue(BtnChangeMonth, "Enabled", true);// habilitando o botão para mudar o mês
            }
        }

        // ------ Gastos do mês
        private bool LoadExpensesData()
        {
            DataTable dataTable = DataConsultant.ViewMonthExpenses(DateTime.Now.Year, DateTime.Now.Month);

            if (dataTable != null)
            {
                //TakeDataFromDataTable(dataTable, this.LblExpenses);

                // Total
                string total = "R$: ";
                total += DataConsultant.GetMonthExpense(_date.Year, _date.Month).ToString("F2");
                ThreadHelper.SetPropertyValue(LblExpenses, "Text", total);

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
            ThreadHelper.SetColumnVisibility(this.DgvExpenses, 7, false);// coluna com os ids a tabela de gastos fixos
            ThreadHelper.SetColumnVisibility(this.DgvExpenses, 8, false);// coluna que indica que já foi pago
            ThreadHelper.SetColumnVisibility(this.DgvExpenses, 9, false);// coluna que indica se tem quantidade de parcelas
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

            ThreadHelper.SetColumnHeaderText(this.DgvExpenses, 5, "Quantidade de parcelas restantes");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvExpenses, 5, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvExpenses, 6, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvExpenses, 6, DataGridViewAutoSizeColumnMode.Fill);
        }

        private void ReloadExpensesData()
        {
            if(LoadExpensesData())
            {
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);// retirando o label wait da tela

                ThreadHelper.SetPropertyValue(TabControl, "Enabled", true);// habilitando tudo
                ThreadHelper.SetPropertyValue(BtnChangeMonth, "Enabled", true);// habilitando o botão para mudar o mês
            }
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
            SetInLoad();
            Task.Run(() => ReloadProfitsData());
        }

        private void CallLoadExpensesData()
        {
            SetInLoad();
            Task.Run(() => ReloadExpensesData());
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
