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
        private double _amount;

        private Action _onCloseCallback;

        public FrmAddEditFixedProfits(int tipe, Action onCloseCallback, int id = 0,
                string name = "", double amount = 0,string desciption = "")
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _amount = amount;
            _onCloseCallback = onCloseCallback;

            FillFields(desciption);
        }

        private void FillFields(string desciption)
        {
            if(_tipe == 1)
            {
                this.LblTitle.Text = "Editar Receita Fixa";
                this.TxtName.Text = _name;
                this.TxtValue.Text = _amount.ToString("F2", CultureInfo.InstalledUICulture);
                this.RtbDescription.Text = desciption;
            }
        }

        private void Save()
        {
            
            if (CaptureAndVerifyData())
            {
                if (_tipe == 0)// Adicionar
                    DataConsultant.InsertFixedProfit(_name, _amount, this.RtbDescription.Text);

                else// Editar
                    DataConsultant.EditFixedProfit(_id, _name, _amount, this.RtbDescription.Text);
                
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
                _amount = value;
            else
            {
                allFieldsAreCorrect = false;
                msg += "\nValor";
            }

            if (!allFieldsAreCorrect)// se algum campo não foi preencido dá um erro
            {
                MessageBox.Show(msg, "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allFieldsAreCorrect;
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
    }
}
