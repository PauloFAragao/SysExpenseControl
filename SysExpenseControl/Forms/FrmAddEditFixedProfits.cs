using SysExpenseControl.Data;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditFixedProfits : Form
    {
        private int _tipe;
        private int _id;
        private string _name;
        private double _value;

        private Action _onCloseCallback;

        public FrmAddEditFixedProfits(int tipe, Action onCloseCallback, int id = 0,
                string name = "", double value = 0,string desciption = "")
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _value = value;
            _onCloseCallback = onCloseCallback;

            FillFields(desciption);
        }

        private void FillFields(string desciption)
        {
            if(_tipe != 0)
            {
                this.LblTitle.Text = "Editar Receita Fixa";
                this.TxtName.Text = _name;
                this.TxtValue.Text = _value.ToString("F2", CultureInfo.InstalledUICulture);
                this.RtbDescription.Text = desciption;

                if (_tipe == 2)
                {
                    this.LblTitle.Text = _name;

                    this.BtnEdit.Visible = true;
                    this.BtnSave.Visible = false;
                    this.BtnCancel.Visible = false;
                }
            }
        }

        private void Save()
        {
            if (CaptureAndVerifyData())
            {
                if (_tipe == 0)// Adicionar
                {
                    // Adicionando na tabela de lucros fixos
                    int? idFixedProfit = DataConsultant.InsertFixedProfit(_name, _value, this.RtbDescription.Text);

                    if (idFixedProfit == null) return; // deu erro

                    // Adicionando na tabela de lucros do mês corrente
                    int? idMonthProfits =  DataConsultant.InsertMonthProfits(_name, _value, null, this.RtbDescription.Text, 
                        DateTime.Now.Year, DateTime.Now.Month, (int)idFixedProfit);

                    if (idMonthProfits == null) return; // deu erro
                }
                else// Editar
                {
                    // Editando o lucro fixo
                    bool result = DataConsultant.EditFixedProfit(_id, _name, _value, 
                        this.RtbDescription.Text);

                    if(!result) return;// deu erro

                    // Editar o lucro do mês corrente
                    bool resultEditProfit = DataConsultant.EditProfit(_id, _name, _value, 
                        this.RtbDescription.Text,
                        "profits_" + DateTime.Now.Year + "_" + DateTime.Now.Month);

                    if (!resultEditProfit) return;// deu erro
                }
                
                this.Close();
            }
        }

        private bool CaptureAndVerifyData()
        {
            bool allFieldsAreCorrect = true;
            string msg = "Os seguintes campos não foram preenchidos corretamente:";

            // Nome
            if (!String.IsNullOrWhiteSpace(this.TxtName.Text))
                _name = this.TxtName.Text;
            else
            {
                allFieldsAreCorrect = false;
                msg += "\nNome";
            }

            // Valor
            if (!String.IsNullOrWhiteSpace(this.TxtValue.Text) &&
                Double.TryParse(this.TxtValue.Text, out double value))
                _value = value;
            else
            {
                allFieldsAreCorrect = false;
                msg += "\nValor";
            }

            if (!allFieldsAreCorrect)// se algum campo não foi preencido dá um erro
            {
                MessageBox.Show(msg, "Preenchimento incorreto ou não preencimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allFieldsAreCorrect;
        }

        private void Edit()
        {
            this.LblTitle.Text = "Editar Receita Fixa";

            this.BtnEdit.Visible = false;
            this.BtnSave.Visible = true;
            this.BtnCancel.Visible = true;
        }

        // ------------------------- Métodos criados pelo visual studio
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddEditFixedProfits_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
