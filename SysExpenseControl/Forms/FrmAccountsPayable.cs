using SysExpenseControl.Data;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysExpenseControl.Entities;

namespace SysExpenseControl.Forms
{
    public partial class FrmAccountsPayable : Form
    {
        public FrmAccountsPayable()
        {
            InitializeComponent();

            this.CbxFilter.SelectedIndex = 0;

            //carregando os dados
            Task.Run(() => Initialize());
        }

        private void SelectedFilterChanged()
        {
            if (this.DgvData.Rows.Count > 0)
            {
                if (this.CbxFilter.SelectedIndex == 0)// sem filtros
                {
                    foreach (DataGridViewRow row in DgvData.Rows)
                    {
                        row.Visible = true;
                    }
                }
                else if (this.CbxFilter.SelectedIndex == 1)// contas pagas
                {
                    foreach (DataGridViewRow row in DgvData.Rows)
                    {
                        var paymentDate = row.Cells[6].Value;
                        if (!DateTime.TryParse(paymentDate.ToString(), out DateTime result))
                            row.Visible = false;
                        
                        else
                            row.Visible = true;
                    }
                }
                else if (this.CbxFilter.SelectedIndex == 2)// contas a pagar
                {
                    foreach (DataGridViewRow row in DgvData.Rows)
                    {
                        var paymentDate = row.Cells[6].Value;
                        if (DateTime.TryParse(paymentDate.ToString(), out DateTime result))
                            row.Visible = false;

                        else
                            row.Visible = true;
                    }
                }
                else// contas vencidas
                {
                    foreach (DataGridViewRow row in DgvData.Rows)
                    {
                        var paymentDate = row.Cells[6].Value;
                        if (DateTime.TryParse(paymentDate.ToString(), out DateTime result))// já está pago
                            row.Visible = false;
                        
                        else if (Convert.ToInt32(row.Cells[3].Value) < DateTime.Now.Day)// está atrasado 
                            row.Visible = true;
                        
                        else// não foi pago mais ainda não está atrasado
                            row.Visible = false;
                    }
                }
            }
        }
        
        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadData())
            {
                HideColumns();
                ChangeColumns();
            }
        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewAccountsPayable();

            if (dataTable != null)
            {
                TakeDataFromDataTable(dataTable);

                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(DgvData, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumns()
        {
            ThreadHelper.SetColumnVisibility(this.DgvData, 0, false);//mudando a visibilidade da coluna id
            ThreadHelper.SetColumnVisibility(this.DgvData, 4, false);//mudando a visibilidade da coluna category
        }

        private void ChangeColumns()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvData, 1, "Nome");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 1, DataGridViewAutoSizeColumnMode.Fill);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 2, "Valor R$");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 3, "Data de vencimento");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 5, "Nome da categoria");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 5, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 6, "Pagamento realizado em");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 6, DataGridViewAutoSizeColumnMode.DisplayedCells);
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
                if (row.IsNull("dayItWasPaid") || string.IsNullOrEmpty(row["dayItWasPaid"].ToString()))
                {
                    //está vencida
                    if (Convert.ToInt32(row["dueDay"]) < DateTime.Now.Day)
                        overdueAccounts += amaunt;//somando valor atrasado

                    amountPayable += amaunt;//total a pagar
                }
                else// já foi pago
                {
                    amountpaid += amaunt;
                }

                total += amaunt;
            }

            this.LblAmountPaid.Text = "R$: " + amountpaid.ToString("F2");
            this.LblAmountPayable.Text = "R$: " + amountPayable.ToString("F2");
            this.LblOverdueAccounts.Text = "R$: " + overdueAccounts.ToString("F2");
            this.LblTotal.Text = "R$: " + total.ToString("F2");

            //this.LblAmount.Text = dataTable.Rows.Count.ToString();
            ThreadHelper.SetPropertyValue(this.LblAmount, "Text", dataTable.Rows.Count.ToString());
        }

        // ------------------------- Métodos criados pelo visual studio
        private void CbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFilterChanged();
        }
    }
}
