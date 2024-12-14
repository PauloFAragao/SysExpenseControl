using SysExpenseControl.Controller;
using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmReserves : Form
    {
        public FrmReserves()
        {
            InitializeComponent();

            //carregando os dados
            Task.Run(() => Initialize());
        }

        private void ViewReserve()
        {
            if (this.DgvData.Rows.Count > 0 &&
                this.DgvData.CurrentCell != null)
            {
                FormLoader.OpenChildForm(new FrmViewReserve(
                    Convert.ToString(this.DgvData.CurrentRow.Cells["tableName"].Value),
                    Convert.ToString(this.DgvData.CurrentRow.Cells["name"].Value),
                    Convert.ToInt32(this.DgvData.CurrentRow.Cells["id"].Value),
                    Convert.ToInt32(this.DgvData.CurrentRow.Cells["operationsQuantity"].Value) ));
            }
        }

        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadData())
            {
                HideColumns();
                ChangeColumns();

                // panel com mensagem
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);

                // botões da interface
                ThreadHelper.SetPropertyValue(BtnAdd, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnDelete, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnEdit, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnView, "Enabled", true);

                ThreadHelper.SetDefaultCellStyle(DgvData, "reservationAmount");// para a coluna dos valores ter ,00

            }
        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewReserves();

            if (dataTable != null)
            {
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
            ThreadHelper.SetColumnVisibility(this.DgvData, 2, false);//coluna tableName
        }

        private void ChangeColumns()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvData, 1, "Nome");

            ThreadHelper.SetColumnHeaderText(this.DgvData, 3, "Valor na reserva");

            ThreadHelper.SetColumnHeaderText(this.DgvData, 4, "Quantidade de operações");

            ThreadHelper.SetColumnHeaderText(this.DgvData, 5, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 5, DataGridViewAutoSizeColumnMode.DisplayedCells);
        }

        private void TakeDataFromDataTable(DataTable dataTable)
        {
            double totalValue = 0;
            int qtd = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                double amaunt = Convert.ToDouble(row["reservationAmount"]);// capturando o valor

                totalValue += amaunt;
                qtd++;
            }

            ThreadHelper.SetPropertyValue(this.LblValue, "Text", "R$: " + totalValue.ToString("F2"));
            ThreadHelper.SetPropertyValue(this.LblQtd, "Text", qtd.ToString());

        }

        // ------------------------- Métodos criados pelo visual studio
        private void BtnView_Click(object sender, System.EventArgs e)
        {
            ViewReserve();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
