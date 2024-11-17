using SysExpenseControl.Data;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditBill : Form
    {
        private int _tipe;// 0 - adicionar/ 1 - editar / 2 - visualizar
        private int _id;
        private int _idFixedExpenses;
        private DateTime _date;
        private string _name;
        private double _value;
        private double _originalValue;
        private string _description;
        private int _dueDay;
        private int _numberOfInstallments;
        private bool _paid;
        private bool _statusPaid = false;

        private Action _onCloseCallback;// evento para atualizar a outra janela

        public FrmAddEditBill(int tipe, Action onCloseCallback, DateTime date, int id = 0, 
            int idFixedExpenses = 0, string name = "", double value = 0, string description = "", 
            int dueDay = 0, int numberOfInstallments = 0, bool paid = false)
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _idFixedExpenses = idFixedExpenses;
            _name = name;
            _value = value;
            _originalValue = _value;
            _description = description;
            _dueDay = dueDay;
            _date = date;
            _numberOfInstallments = numberOfInstallments;
            _paid = paid;

            _statusPaid = _paid;// ao editar deve marcar como pago

            _onCloseCallback = onCloseCallback;

            FillFields();
        }

        private void FillFields()
        {
            this.TxtName.Text = _name;
            this.TxtValue.Text = _value.ToString();
            this.TxtDueDay.Text = _dueDay.ToString();
            this.TxtNumberOfInstallments.Text = _numberOfInstallments.ToString();
            this.DateTimePicker.Text = _date.ToString();
            this.RtbDescription.Text = _description;

            if (_idFixedExpenses == 0)// não é uma conta fixa
                this.RbBill.Select();
            else// é uma conta fixa
                this.RbFixedBill.Select();

            this.CbPaid.Checked = _paid;

            if (_tipe == 1)// Editar
            {
                this.LblTitle.Text = "Editar Conta";

                this.BtnNotPaid.Visible = _paid;
            }
            else if (_tipe == 2)// Visualizar
            {
                this.LblTitle.Text = "Visualizar Conta";

                //desabilitando todos os campos
                this.TxtName.Enabled = false;
                this.TxtValue.Enabled = false;
                this.TxtDueDay.Enabled = false;
                this.TxtNumberOfInstallments.Enabled = false;
                this.DateTimePicker.Enabled = false;
                this.RtbDescription.Enabled = false;
                this.RbBill.Enabled = false;
                this.RbFixedBill.Enabled = false;
                this.CbPaid.Enabled = false;

                // botões visiveis e não visiveis
                this.BtnEdit.Visible = true;
                this.BtnSave.Visible = false;
                this.BtnCancel.Visible = false;

                this.BtnNotPaid.Visible = _paid;
            }

        }

        private void Edit()
        {
            this.LblTitle.Text = "Editar Conta";

            //desabilitando todos os campos
            this.TxtName.Enabled = true;
            this.TxtValue.Enabled = true;
            this.RtbDescription.Enabled = true;
            this.RbBill.Enabled = true;
            this.RbFixedBill.Enabled = true;
            this.CbPaid.Enabled = true;

            if (_idFixedExpenses == 0)// não é uma conta fixa
                this.RbBill.Select();

            else// é uma conta fixa
            {
                this.RbFixedBill.Select();

                this.TxtDueDay.Enabled = true;
                this.TxtNumberOfInstallments.Enabled = true;
            }

            this.CbPaid.Checked = _paid;
            if (_paid) this.DateTimePicker.Enabled = true;

            // botões visiveis e não visiveis
            this.BtnEdit.Visible = false;
            this.BtnSave.Visible = true;
            this.BtnCancel.Visible = true;
        }

        private void Save()
        {
            if (CaptureAndVerifyData())
            {
                if (_tipe == 0)// para adicionar
                {
                    int? idFixedExpenses = -1;

                    if (this.RbFixedBill.Checked)// verifica se é uma conta fixa
                    {
                        // adionar nas contas fixas 
                        idFixedExpenses = DataConsultant.InsertFixedExpense( _name, _value, 
                            Convert.ToInt32(_dueDay), _numberOfInstallments,"Contas", 
                            this.RtbDescription.Text, _numberOfInstallments != 0 );
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
                else// para editar
                {
                    if (_idFixedExpenses != 0)// verifica se é uma conta fixa
                    {
                        if (this.RbFixedBill.Checked)// não mudou, ainda é uma conta fixa
                        {
                            // editar o gasto fixo
                            bool result = DataConsultant.EditFixedExpense(_idFixedExpenses, _name, _value, _dueDay, 
                                _numberOfInstallments, "Contas", this.RtbDescription.Text, 
                                _numberOfInstallments != 0 );

                            if (!result) return; // deu erro

                            // editar todas as tabelas de gastos de mês com referencia a aquele gasto fixo
                            bool resultEditAllMonthExpense = DataConsultant.EditAllMonthExpense(_id, 
                                _name, /*_value,*/"Contas", this.RtbDescription.Text);

                            if(!resultEditAllMonthExpense) return;// deu erro

                            // editar a conta na tabela do mês
                            bool resultEditMonthExpense = DataConsultant.EditMonthExpense(_id, _name, 
                                _value, _date, "Contas", this.RtbDescription.Text, _date.Year, 
                                _date.Month, _paid);

                            if (!resultEditMonthExpense) return;
                        }
                        else// mudou de conta fixa para conta não fixa
                        {
                            // deletar conta fixa
                            DataConsultant.DeleteFixedExpense(_idFixedExpenses);

                            // Editar as contas não fixas
                            bool result = DataConsultant.EditAllMonthExpense(_id, _name, 
                                /*_value,*/ "Contas", this.RtbDescription.Text, true);

                            if (!result) return; // deu erro

                            // editar a conta na tabela do mês
                            bool resultEditMonthExpense = DataConsultant.EditMonthExpense(_id, _name,
                                _value, _date, "Contas", this.RtbDescription.Text, _date.Year,
                                _date.Month, _paid);

                            if (!resultEditMonthExpense) return;
                        }
                    }
                    else// não é uma conta fixa
                    {
                        if (this.RbFixedBill.Checked)// Mudou para conta fixa
                        {
                            // adicionar conta fixa
                            int? idFixedExpenses = DataConsultant.InsertFixedExpense(_name, _value,
                            Convert.ToInt32(_dueDay), _numberOfInstallments, "Contas",
                            this.RtbDescription.Text, _numberOfInstallments != 0);

                            // fazer edições
                            bool result = DataConsultant.EditMonthExpense(_id, _name, _value, _date, 
                                "Contas",  this.RtbDescription.Text, _date.Year,
                                _date.Month, _paid, idFixedExpenses);

                            if (!result) return;// deu erro
                        }
                        else// não mudou para conta fixa
                        {
                            // fazer edições
                            bool result = DataConsultant.EditMonthExpense(_id, _name, _value, _date, 
                                "Contas", this.RtbDescription.Text, _date.Year, _date.Month, _paid);

                            if (!result) return;// deu erro
                        }
                    }

                    // inserido o gasto na tabela references_to_tables 
                    DataConsultant.InsertExpense(
                        -1 * (_originalValue - _value),// envia a diferença
                        Convert.ToDateTime(DateTimePicker.Value).Year,
                        Convert.ToDateTime(DateTimePicker.Value).Month);
                }
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

                Debug.WriteLine("Valor-1: "+value);
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

        private void SetNotPaid()
        {
            _statusPaid = !_statusPaid;

            if (!_statusPaid)
            {
                BtnNotPaid.BackColor = Color.FromArgb(255, 128, 128);
                BtnNotPaid.Text = "Não paga";
            }
            else
            {
                BtnNotPaid.BackColor = Color.FromArgb(128, 255, 128);
                BtnNotPaid.Text = "Paga";
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BtnNotPaid_Click(object sender, EventArgs e)
        {
            SetNotPaid();
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
