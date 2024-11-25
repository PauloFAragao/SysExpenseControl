﻿using System;
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
            if (_data.Rows.Count < 0 || _data == null) return;

            if (this.CbxFilter.SelectedIndex == 0)// sem filtros
            {
                DgvData.DataSource = _data;
            }
            else if (this.CbxFilter.SelectedIndex == 1)// contas pagas
            {
                DataTable dt = _data.Copy();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool paid = Convert.ToBoolean(dt.Rows[i][8]);

                    if (!paid) dt.Rows[i].Delete();// marcando para deletar
                }
                dt.AcceptChanges();// confirmando a deleção

                DgvData.DataSource = dt;
            }
            else if (this.CbxFilter.SelectedIndex == 2)// contas a pagar
            {
                DataTable dt = _data.Copy();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool paid = Convert.ToBoolean(dt.Rows[i][8]);

                    if (paid) dt.Rows[i].Delete();// marcando para deletar
                }
                dt.AcceptChanges();// confirmando a deleção

                DgvData.DataSource = dt;
            }
            else// contas vencidas
            {
                DataTable dt = _data.Copy();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool paid = Convert.ToBoolean(dt.Rows[i][8]);

                    // Se estiver marcada como paga ou se não estiver atrasada
                    if (paid || !(Convert.ToInt32(dt.Rows[i][4]) < DateTime.Now.Day))
                        dt.Rows[i].Delete();// marcando para deletar
                }
                dt.AcceptChanges();// confirmando a deleção

                DgvData.DataSource = dt;
            }
        }

        private void Add()
        {
            FrmAddEditBill frmAddEditBill = new FrmAddEditBill(CallLoadData);
            frmAddEditBill.ShowDialog();
        }

        private void ViewBill()
        {
            //dataGridView.CurrentCell != null
            if (
                this.DgvData.Rows.Count > 0 && 
                this.DgvData.CurrentCell != null)
            {
                // capturando a data que foi pago
                var cellValue = this.DgvData.CurrentRow.Cells["date"].Value;
                DateTime? date;
                if (cellValue != null &&
                    DateTime.TryParse(cellValue.ToString(), out DateTime dt))
                {
                    date = dt;
                }
                else date = null;

                // capturando o id referencia a tabela de gastos fixos
                var idFixedExpensesRow = this.DgvData.CurrentRow.Cells["idFixedExpenses"].Value;
                if (int.TryParse(idFixedExpensesRow.ToString(), out int idFixedExpenses))
                {}

                FrmViewBill frmViewBill = new FrmViewBill(
                    Convert.ToString(this.DgvData.CurrentRow.Cells["name"].Value),
                    this.DgvData.CurrentRow.Cells["value"].Value.ToString(),
                    this.DgvData.CurrentRow.Cells["dueDay"].Value.ToString(),
                    idFixedExpenses,
                    this.DgvData.CurrentRow.Cells["numberOfInstallments"].Value.ToString(),
                    Convert.ToBoolean(this.DgvData.CurrentRow.Cells["paid"].Value),
                    date,
                    Convert.ToString(this.DgvData.CurrentRow.Cells["description"].Value));

                frmViewBill.ShowDialog();
            }
            else
            {
                MessageBox.Show("A tabela não tem dados ou não tem nenhuma linha selecionada!", 
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                HideColumns();
                ChangeColumns();

                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);// retirando o label wait da tela

                ThreadHelper.SetDefaultCellStyle(DgvData, "value");// para a coluna dos valores ter ,00

                ThreadHelper.SetPropertyValue(BtnAdd, "Enabled", true);//habilitando o botão adiconar
                ThreadHelper.SetPropertyValue(BtnView, "Enabled", true);//habilitando o botão visualizar
                ThreadHelper.SetPropertyValue(CbxFilter, "Enabled", true);//habilitando o comboBox

                //ThreadHelper.SelectFirstRow(this.DgvData);// para fazer a primeira linha ficar selecionada
            }
        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewBills(_date); //DataConsultant.ViewAccountsPayable();

            if (dataTable != null)
            {
                // Guardando a referencia
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
            ThreadHelper.SetColumnVisibility(this.DgvData, 0, false);//coluna id
            ThreadHelper.SetColumnVisibility(this.DgvData, 1, false);//coluna idFixedExpenses
            ThreadHelper.SetColumnVisibility(this.DgvData, 7, false);//descrição
            ThreadHelper.SetColumnVisibility(this.DgvData, 8, false);//pago
        }

        private void ChangeColumns()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvData, 2, "Nome");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 2, DataGridViewAutoSizeColumnMode.Fill);
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 2, DataGridViewAutoSizeColumnMode.AllCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 3, "Valor R$");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 3, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 4, "Data de vencimento");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 4, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 5, "Pagamento realizado em");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 5, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 6, "Quantidade de parcelas restantes");
            //ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 6, DataGridViewAutoSizeColumnMode.DisplayedCells);

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
                    if (int.TryParse(row["dueDay"].ToString(), out int dueDay) && dueDay < DateTime.Now.Day)
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

        private void BtnView_Click(object sender, EventArgs e)
        {
            ViewBill();
        }
    }
}
