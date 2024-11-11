using SysExpenseControl.Data;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditMonthProfits : Form
    {
        private int _tipe;
        private int _id;
        private string _name;
        private double _value;
        private DateTime _date;
        private Action _onCloseCallback;

        private string _tableName;

        public FrmAddEditMonthProfits(int tipe, Action onCloseCallback, DateTime date, string tableName, int id = 0,
                string name = "", double value = 0, string desciption = "")
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _value = value;
            _date = date;
            _onCloseCallback = onCloseCallback;
            _tableName = tableName;

            FillFields(desciption);
        }

        private void FillFields(string desciption)
        {
            if (_tipe != 0)
            {
                this.LblTitle.Text = "Editar Receita";
                this.TxtName.Text = _name;
                this.TxtValue.Text = _value.ToString("F2", CultureInfo.InstalledUICulture);
                this.RtbDescription.Text = desciption;
                this.DateTimePicker.Text = _date.ToString();

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
                    int? id = DataConsultant.InsertMonthProfits(_name, _value, Convert.ToDateTime(DateTimePicker.Value),
                         this.RtbDescription.Text, DateTime.Now.Year, DateTime.Now.Month);

                    if (id == null) return; // deu erro
                }
                else// Editar
                {
                    bool result = DataConsultant.EditMonthProfits(_id, _name, _value, Convert.ToDateTime(DateTimePicker.Value),
                        this.RtbDescription.Text, _tableName);

                    if (!result) return;
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
            this.LblTitle.Text = "Editar Receita";

            this.BtnEdit.Visible = false;
            this.BtnSave.Visible = true;
            this.BtnCancel.Visible = true;
        }

        // ------------------------- Métodos criados pelo visual studio
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddEditMonthProfits_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }
    }
}
