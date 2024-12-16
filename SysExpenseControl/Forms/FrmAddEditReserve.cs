using SysExpenseControl.Data;
using System;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditReserve : Form
    {
        int _id;
        int _type;
        string _name;
        string _tableName;// quando a reserva é criada o método retorna o nome da tabela

        Action _onCloseCallback;

        public FrmAddEditReserve(int type, Action onCloseCallback, int id = 0, string name = "",
            string description = "")
        {
            InitializeComponent();

            _id = id;
            _type = type;
            _name = name;
            _onCloseCallback = onCloseCallback;

            FillFilds(description);
        }

        private void FillFilds(string description)
        {
            if (_type == 1)// editar
            {
                this.LblTitle.Text = "Editar Reserva";
                this.CbInicialOperation.Enabled = false;

                this.TxtName.Text = _name;
                this.RtbDescription.Text = description;
            }
        }

        private void Save()
        {
            if (CaptureAndVerifyData())
            {
                if(_type == 0)// adicionar
                {
                    _tableName = DatabaseManager.CreateDynamicTable_Reserve(_name,
                    this.RtbDescription.Text);

                    // Erro
                    if (_tableName == "fail" || _tableName == null) return;

                    // inserindo valor inicial
                    if (this.CbInicialOperation.Checked)
                    {
                        FrmAddEditReserveOperation frmAddEditReserveOperation =
                            new FrmAddEditReserveOperation(_tableName, 0, _name, DateTime.Now,
                                _onCloseCallback);

                        frmAddEditReserveOperation.ShowDialog();
                    }
                }
                else// editar
                {
                    bool result = DataConsultant.EditReserve(_id, _name, this.RtbDescription.Text);

                    // Erro
                    if (!result) return;
                }

                // chamando evento pra recarregar a outra pagina
                _onCloseCallback?.Invoke();

                this.Close();
            }
        }

        private bool CaptureAndVerifyData()
        {
            bool allFieldsAreCorrect = true;
            string msg = "Os seguintes campos não foram preenchidos corretamente:";

            // Nome
            if (!String.IsNullOrWhiteSpace(this.TxtName.Text))
            {
                _name = this.TxtName.Text;
            }
            else
            {
                allFieldsAreCorrect = false;
                msg += "\nNome";
            }

            if (!allFieldsAreCorrect)// se algum campo não foi preencido dá um erro
            {
                MessageBox.Show(msg, "Preenchimento incorreto ou não preencimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allFieldsAreCorrect;
        }

        // ------------------------ Métodos criados pelo Visual Studio
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
