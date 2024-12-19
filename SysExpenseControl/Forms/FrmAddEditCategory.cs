using SysExpenseControl.Data;
using System;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditCategory : Form
    {
        private int _type;
        private int _id;
        private string _name;
        private string _description;

        private Action _onCloseCallback;

        public FrmAddEditCategory(int type, Action onCloseCallback, int id = 0, string name = "", 
            string description = "")
        {
            InitializeComponent();

            _type = type;
            _id = id;
            _onCloseCallback = onCloseCallback;
            _name = name;
            _description = description;

            FillFields(description);
        }

        private void FillFields(string desciption)
        {
            if(_type != 0)
            {
                this.TxtName.Text = _name;
                this.RtbDescription.Text = desciption;

                if (_type == 2)
                {
                    this.LblTitle.Text = "Visualizar " + _name;

                    this.BtnEdit.Visible = true;
                    this.BtnSave.Visible = false;
                    this.BtnCancel.Visible = false;
                }
                else
                    this.LblTitle.Text = "Editar " + _name;
            }
        }

        private void Save()
        {
            if (CaptureAndVerifyData())
            {
                if(_type == 0)// adicionar categoria
                {
                    int? result = DataConsultant.InsertCategory(_name, this.RtbDescription.Text);

                    //erro
                    if(result == null) return;
                }
                else// editar categoria
                {
                    bool result = DataConsultant.EditCategory(_id, _name, this.RtbDescription.Text);

                    //erro
                    if (!result) return;
                }

                this.Close();
            }
        }

        private bool CaptureAndVerifyData()
        {
            // capturando o Nome
            if (!String.IsNullOrWhiteSpace(this.TxtName.Text))
            {
                _name = this.TxtName.Text;

                return true;
            }
            else
            {
                MessageBox.Show("Preenchimento incorreto ou não preencimento do campo Nome", 
                    "Preenchimento incorreto ou não preencimento", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        private void Edit()
        {
            this.LblTitle.Text = "Editar " + _name;

            this.BtnEdit.Visible = false;
            this.BtnSave.Visible = true;
            this.BtnCancel.Visible = true;
        }

        // ---------------------------- métodos criados pelo visual studio
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void FrmAddEditCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }
    }
}
