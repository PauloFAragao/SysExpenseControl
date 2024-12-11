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
            }

            // pesquisando as quantidades no banco de dados

        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewReserves();

            if (dataTable != null)
            {
                
                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(this.DgvData, "DataSource", dataTable);
                return true;
            }
            else
                return false;
        }

        private void HideColumns()
        {

        }

        private void ChangeColumns()
        {

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
