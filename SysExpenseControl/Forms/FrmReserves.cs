using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System.Data;
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
            DataTable dataTable = DataConsultant.ViewReserves();

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

        }

        private void ChangeColumns()
        {

        }

        private void TakeDataFromDataTable(DataTable dataTable)
        { 

        }
    }
}
