using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SysExpenseControl.Forms
{
    public partial class FrmConfigureCategories : Form
    {
        public FrmConfigureCategories()
        {
            InitializeComponent();

            //carregando os dados
            Task.Run(() => Initialize());
        }

        private void Add()
        {
            FrmAddEditCategory frmAddEditCategory = new FrmAddEditCategory(0, CallLoadData);
            frmAddEditCategory.ShowDialog();
        }

        private void EditView(int type)
        {
            if (this.DgvData.Rows.Count > 0 &&
                this.DgvData.CurrentCell != null)
            {
                int id = Convert.ToInt32(this.DgvData.CurrentRow.Cells["id"].Value);
                string name = this.DgvData.CurrentRow.Cells["name"].Value.ToString();

                if (id != 0 && id != 1)// não pode Editar as categorias: Sem categorias e contas
                {
                    FrmAddEditCategory frmAddEditCategory = new FrmAddEditCategory(
                        type, CallLoadData, id, name,
                        this.DgvData.CurrentRow.Cells["description"].Value.ToString());

                    frmAddEditCategory.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "Não é permitido editar a categira: " + name,
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("A tabela não tem dados ou não tem nenhuma linha selecionada!",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Debug.WriteLine("não tem dados");
            }


        }

        private void Delete()
        {
            if (this.DgvData.Rows.Count > 0 &&
                this.DgvData.CurrentCell != null)
            {
                int id = Convert.ToInt32(this.DgvData.CurrentRow.Cells["id"].Value);
                string name = this.DgvData.CurrentRow.Cells["name"].Value.ToString();

                if (id != 0 && id != 1)// não pode deletar as categorias: Sem categorias e contas
                {
                    if (MessageBox.Show(
                    "Confirme para deletar: " + name,
                    "Deletar Categoria?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        bool result = DataConsultant.DeleteCategory(id);

                        if(result) CallLoadData();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Não é permitido deletar a categira: " + name,
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("A tabela não tem dados ou não tem nenhuma linha selecionada!",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                // panel com mensagem
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);

                // botões da interface
                ThreadHelper.SetPropertyValue(BtnAdd, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnDelete, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnEdit, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnView, "Enabled", true);
            }
        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewCategory();

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
            ThreadHelper.SetColumnVisibility(this.DgvData, 0, false);//coluna id
        }

        private void ChangeColumns()
        {
            ThreadHelper.SetColumnHeaderText(this.DgvData, 1, "Nome");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 1, DataGridViewAutoSizeColumnMode.DisplayedCells);

            ThreadHelper.SetColumnHeaderText(this.DgvData, 2, "Descrição");
            ThreadHelper.SetColumnAutoSizeMode(this.DgvData, 2, DataGridViewAutoSizeColumnMode.DisplayedCells);
        }

        // ------------------------- Métodos criados pelo visual studio

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditView(1);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            EditView(2);
        }
    }
}
