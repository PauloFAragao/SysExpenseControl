using SysExpenseControl.Data;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SysExpenseControl.Forms
{
    public partial class FrmMarkBillPaid : Form
    {
        int _id, _year, _month, _idFixedExpenses;
        double _value;
        bool _definedNumberOfInstallments;

        private Action _onCloseCallback;// evento para atualizar a outra janela

        public FrmMarkBillPaid(string name, int id, int idFixedExpenses, double value,
            int year, int month, bool definedNumberOfInstallments, Action onCloseCallback)
        {
            InitializeComponent();

            this.LblName.Text = name;
            this.TxtValue.Text = value.ToString("N2");

            _id = id;
            _year = year;
            _month = month;
            _idFixedExpenses = idFixedExpenses;
            _definedNumberOfInstallments = definedNumberOfInstallments;
            _onCloseCallback = onCloseCallback;
            _value = value;
        }

        private void Save()
        {
            if(CaptureAndVerifyData())
            {
                DateTime date = Convert.ToDateTime(this.DateTimePicker.Value);

                // marcando como paga
                bool result = DataConsultant.EditBillPaid(_id, true, _value, date, _year,
                    _month);

                if (result)
                {
                    // para subtrair uma parcela se for aplicavel
                    if (_definedNumberOfInstallments)
                        DataConsultant.EditInstallment(_idFixedExpenses, true);

                    // para somar na contagem de gastos
                    DataConsultant.InsertExpense(_value, date.Year, date.Month);

                    this.Close();
                }
            }
        }

        private bool CaptureAndVerifyData()
        {
            bool allFieldsAreCorrect = true;
            string msg = "Os seguintes campos não foram preenchidos corretamente:";

            // Valor
            if (!String.IsNullOrWhiteSpace(this.TxtValue.Text) &&
                Double.TryParse(this.TxtValue.Text, out double value))
                _value = value;
            else
            {
                allFieldsAreCorrect = false;
                msg += "\n-Valor (R$):";
            }

            if (!allFieldsAreCorrect)// se algum campo não foi preencido dá um erro
            {
                MessageBox.Show(msg, "Preenchimento incorreto ou não preencimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allFieldsAreCorrect;
        }

        // -------------------- Métodos criados pelo Visual Studio
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMarkBillPaid_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }
    }
}
