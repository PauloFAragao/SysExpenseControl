using System;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using SysExpenseControl.Data;
using SysExpenseControl.Entities;

namespace SysExpenseControl.Forms
{
    public partial class FrmAccountsPayable : Form
    {
        readonly DataTable _data;

        public FrmAccountsPayable()
        {
            InitializeComponent();

            _data = new DataTable();

            this.CbxFilter.SelectedIndex = 0;// para iniciar sem filtros

            this.LblDisplayMonth.Text = DateTime.Now.ToString("MM/yyyy");// para exibir o mês atual

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

        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadData())
            {
                HideColumns();
                ChangeColumns();

                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);
                ThreadHelper.SetPropertyValue(CbxFilter, "Enabled", true);
            }
        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewAccountsPayable();

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
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 1, DataGridViewAutoSizeColumnMode.Fill);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 2, "Valor R$");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 3, "Data de vencimento");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 4, "Quantidade de parcelas restante");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 4, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 6, "Nome da categoria");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 6, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 7, "Pagamento realizado em");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 7, DataGridViewAutoSizeColumnMode.DisplayedCells);
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
    }
}
