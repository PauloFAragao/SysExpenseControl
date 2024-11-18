using SysExpenseControl.Data;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditBill : Form
    {
        private string _name;
        private double _value;
        private int _dueDay;
        private int _numberOfInstallments;
        private bool _paid;

        private Action _onCloseCallback;// evento para atualizar a outra janela

        public FrmAddEditBill(Action onCloseCallback)
        {
            InitializeComponent();

            _onCloseCallback = onCloseCallback;
        }

        private void Save()
        {
            if (CaptureAndVerifyData())
            {
                int? idFixedExpenses = -1;

                if (this.RbFixedBill.Checked)// verifica se é uma conta fixa
                {
                    // adionar nas contas fixas 
                    idFixedExpenses = DataConsultant.InsertFixedExpense(_name, _value,
                        Convert.ToInt32(_dueDay), _numberOfInstallments, "Contas",
                        this.RtbDescription.Text, _numberOfInstallments != 0);
                }

                if (idFixedExpenses == null) return; //erro

                // Capturando a data
                DateTime? date;
                if (this.CbPaid.Checked)// se está marcado como pago
                    date = Convert.ToDateTime(DateTimePicker.Value);
                else
                    date = null;

                // adiconar nas contas desse mês
                int? id = DataConsultant.InsertMonthExpense(_name, _value, date, idFixedExpenses, "Contas",
                    this.RtbDescription.Text, DateTime.Now.Year, DateTime.Now.Month, _paid);

                if (id == null) return; // deu erro

                // inserido o gasto na tabela references_to_tables 
                DataConsultant.InsertExpense(_value,
                    Convert.ToDateTime(DateTimePicker.Value).Year,
                    Convert.ToDateTime(DateTimePicker.Value).Month);

            }

            this.Close();
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
            if (!String.IsNullOrWhiteSpace(this.TxtValue.Text))
            {
                if (Double.TryParse(this.TxtValue.Text, out double value))
                    _value = value;
                else
                {
                    allFieldsAreCorrect = false;
                    msg += "\nValor";
                }

                Debug.WriteLine("Valor-1: " + value);
            }

            // Conta fixa
            if (this.RbFixedBill.Checked)
            {
                // Dia do pagamento
                if (!String.IsNullOrWhiteSpace(this.TxtDueDay.Text) &&
                int.TryParse(this.TxtDueDay.Text, out int dueday))
                {
                    _dueDay = dueday;
                }
                else
                {
                    allFieldsAreCorrect = false;
                    msg += "\nData de Vencimento";
                }

                // Parcelas Restantes
                if (!String.IsNullOrWhiteSpace(this.TxtNumberOfInstallments.Text))
                {
                    if (int.TryParse(this.TxtNumberOfInstallments.Text, out int numberOfInstallments))
                        _numberOfInstallments = numberOfInstallments;
                    else
                    {
                        _numberOfInstallments = 0;
                        allFieldsAreCorrect = false;
                        msg += "\nParcelas Restantes";
                    }
                }
            }

            // se está paga ou não
            _paid = this.CbPaid.Checked;

            if (!allFieldsAreCorrect)// se algum campo não foi preencido dá um erro
            {
                MessageBox.Show(msg, "Preenchimento incorreto ou não preencimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allFieldsAreCorrect;
        }

        private void Paid()
        {
            this.DateTimePicker.Enabled = this.CbPaid.Checked;
        }

        private void BillTipe()
        {
            if (this.RbBill.Checked)
            {
                this.TxtDueDay.Enabled = false;
                this.TxtNumberOfInstallments.Enabled = false;
            }
            else
            {
                this.TxtDueDay.Enabled = true;
                this.TxtNumberOfInstallments.Enabled = true;
            }
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

        private void CbPaid_CheckedChanged(object sender, EventArgs e)
        {
            Paid();
        }

        private void RbFixedBill_CheckedChanged(object sender, EventArgs e)
        {
            BillTipe();
        }

        private void FrmAddEditBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }
    }
}
