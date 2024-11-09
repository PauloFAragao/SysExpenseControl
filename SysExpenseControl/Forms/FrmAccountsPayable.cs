using System;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System.Diagnostics;

namespace SysExpenseControl.Forms
{
    public partial class FrmAccountsPayable : Form
    {
        private DataTable _data;// gambiarra para alterar o que está sendo exibido no DataGridView
        private DateTime _date;// para guardar o Mês e o ano que está sendo exibido

        public FrmAccountsPayable()
        {
            InitializeComponent();

            _data = new DataTable();

            this.CbxFilter.SelectedIndex = 0;// para iniciar sem filtros

            _date = DateTime.Now;
            this.LblDisplayMonth.Text = _date.ToString("MM/yyyy");// para exibir o mês atual

            //carregando os dados
            Task.Run(() => Initialize());
        }

        private void SelectedFilterChanged()
        {
            if(DgvData.Rows.Count > 0)
            {
                if (this.CbxFilter.SelectedIndex == 0)// sem filtros
                {
                    DgvData.DataSource = _data;
                }
                else if (this.CbxFilter.SelectedIndex == 1)// contas pagas
                {
                    DataTable dt = _data.Copy();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var paymentDate = dt.Rows[i][6];

                        if (paymentDate.ToString() == string.Empty)
                            dt.Rows[i].Delete();// marcando para deletar
                    }
                    dt.AcceptChanges();// confirmando a deleção

                    DgvData.DataSource = dt;
                }
                else if (this.CbxFilter.SelectedIndex == 2)// contas a pagar
                {
                    DataTable dt = _data.Copy();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var paymentDate = dt.Rows[i][6];

                        if (paymentDate.ToString() != string.Empty)
                            dt.Rows[i].Delete();// marcando para deletar
                    }
                    dt.AcceptChanges();// confirmando a deleção

                    DgvData.DataSource = dt;
                }
                else// contas vencidas
                {
                    DataTable dt = _data.Copy();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var paymentDate = dt.Rows[i][6];

                        if (paymentDate.ToString() != string.Empty ||
                                !(Convert.ToInt32(dt.Rows[i][3]) < DateTime.Now.Day))
                            dt.Rows[i].Delete();// marcando para deletar
                    }
                    dt.AcceptChanges();// confirmando a deleção

                    DgvData.DataSource = dt;
                }
            }
        }

        private void Add()
        {
            FrmAddEditBill frmAddEditBill = new FrmAddEditBill(0, CallLoadData, DateTime.Now);
            frmAddEditBill.ShowDialog();
        }

        private void ViewEditBill(int tipe)
        {
            if(DgvData.Rows.Count > 0)
            {
                // capturando a data que foi pago, se for null pega a data corrente
                DateTime date;
                if(DateTime.TryParse(this.DgvData.CurrentRow.Cells["date"].Value.ToString(), out DateTime dt))
                {
                    date = dt;
                }
                else date = DateTime.Now;

                // capturando o id referencia a tabela de gastos fixos, se não tiver manda 0 
                int idFixedExpenses;
                if(int.TryParse(this.DgvData.CurrentRow.Cells["idFixedExpenses"].Value.ToString(), out int ife))
                {
                    idFixedExpenses = ife;
                }
                else idFixedExpenses = 0;

                // capturando o valor
                double value;
                if (double.TryParse(this.DgvData.CurrentRow.Cells["value"].Value.ToString(), out double amount))
                {
                    value = amount;
                }
                else value = 0;

                // capturando a data de pagamento
                int dueDay;
                if (int.TryParse(this.DgvData.CurrentRow.Cells["dueDay"].Value.ToString(), out int dueD))
                {
                    dueDay = dueD;
                }
                else dueDay = 0;

                // capturando a data de pagamento
                int numberOfInstallments;
                if (int.TryParse(this.DgvData.CurrentRow.Cells["numberOfInstallments"].Value.ToString(), out int nInstallments))
                {
                    numberOfInstallments = nInstallments;
                }
                else numberOfInstallments = 0;

                FrmAddEditBill frmAddEditBill = new FrmAddEditBill(tipe, CallLoadData, date,
                    Convert.ToInt32(this.DgvData.CurrentRow.Cells["id"].Value),
                    idFixedExpenses,
                    Convert.ToString(this.DgvData.CurrentRow.Cells["name"].Value),
                    value,
                    Convert.ToString(this.DgvData.CurrentRow.Cells["description"].Value),
                    dueDay, numberOfInstallments,
                    Convert.ToBoolean(this.DgvData.CurrentRow.Cells["paid"].Value),
                    $"expenses_{_date.Year}_{_date.Month}" );

                frmAddEditBill.ShowDialog();
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        // ------------------------- Eventos
        private void CallLoadData()
        {
            Task.Run(() => LoadData());
        }

        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadData())
            {
                //HideColumns();
                //ChangeColumns();

                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);
                ThreadHelper.SetPropertyValue(CbxFilter, "Enabled", true);
            }
        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewBills(_date); //DataConsultant.ViewAccountsPayable();

            if (dataTable != null)
            {
                ThreadHelper.SetFieldValue(this, "_data", dataTable);

                TakeDataFromDataTable(dataTable);

                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(this.DgvData, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumns()
        {
            ThreadHelper.SetColumnVisibility(this.DgvData, 0, false);//mudando a visibilidade da coluna id
            ThreadHelper.SetColumnVisibility(this.DgvData, 5, false);//mudando a visibilidade da coluna category
        }

        private void ChangeColumns()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvData, 1, "Nome");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 1, DataGridViewAutoSizeColumnMode.Fill);
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 1, DataGridViewAutoSizeColumnMode.AllCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 2, "Valor R$");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 3, "Data de vencimento");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 4, "Quantidade de parcelas restantes");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 4, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 6, "Nome da categoria");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 6, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 7, "Pagamento realizado em");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 7, DataGridViewAutoSizeColumnMode.DisplayedCells);
        }

        private void TakeDataFromDataTable(DataTable dataTable)
        {
            decimal amountpaid = 0;
            decimal amountPayable = 0;
            decimal overdueAccounts = 0;
            decimal total = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                decimal amaunt = Convert.ToDecimal(row["value"]);// capturando o valor

                // ainda não foi pago
                if (row.IsNull("date") || string.IsNullOrEmpty(row["date"].ToString()))
                {
                    //está vencida
                    if(int.TryParse(row["dueDay"].ToString(), out int dueDay) && dueDay < DateTime.Now.Day)
                    {
                        overdueAccounts += amaunt;//somando valor atrasado
                    }

                    amountPayable += amaunt;//total a pagar
                }
                else// já foi pago
                {
                    amountpaid += amaunt;
                }

                total += amaunt;
            }

            ThreadHelper.SetPropertyValue(this.LblAmountPaid, "Text", "R$: " + amountpaid.ToString("F2"));
            ThreadHelper.SetPropertyValue(this.LblAmountPayable, "Text", "R$: " + amountPayable.ToString("F2"));
            ThreadHelper.SetPropertyValue(this.LblOverdueAccounts, "Text", "R$: " + overdueAccounts.ToString("F2"));
            ThreadHelper.SetPropertyValue(this.LblTotal, "Text", "R$: " + total.ToString("F2"));

            //this.LblAmount.Text = dataTable.Rows.Count.ToString();
            ThreadHelper.SetPropertyValue(this.LblAmount, "Text", dataTable.Rows.Count.ToString());
        }

        // ------------------------- Métodos criados pelo visual studio
        private void CbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFilterChanged();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ViewEditBill(1);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            ViewEditBill(2);
        }
    }
}
