using SysExpenseControl.Data;
using System;
using System.Diagnostics;
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
        private double _originalValue;
        private DateTime _date;
        private Action _onCloseCallback;

        bool _confirm;// essa variavel indica na edição se o valor está sendo marcado como "pago"

        public FrmAddEditMonthProfits(int tipe, Action onCloseCallback, DateTime date,
            int id = 0, string name = "", double value = 0,
            string desciption = "", bool confirm = false)
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _value = value;
            _originalValue = value;
            _date = date;
            _onCloseCallback = onCloseCallback;
            _confirm = confirm;

            // para o radio button iniciar marcado
            this.RbRecived.Checked = true;

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
                bool recived = this.RbRecived.Checked;

                if (_tipe == 0)// Adicionar
                {
                    int? id = DataConsultant.InsertMonthProfits(_name, _value,
                        GetDate(_date, recived),
                        this.RtbDescription.Text, _date.Year, _date.Month);

                    if (id == null) return; // deu erro

                    if (recived)// só soma caso esteja marcado como recebido
                        DataConsultant.InsertProfit(_value, _date.Year, _date.Month);
                }
                else// Editar
                {
                    bool result = DataConsultant.EditMonthProfits(_id, _name, _value,
                        GetDate(_date, recived),
                        this.RtbDescription.Text, _date.Year, _date.Month);

                    if (!result) return; // deu erro

                    if (recived)// só soma caso esteja marcado como recebido
                    {
                        Debug.WriteLine("tá marcada como recebida");
                        if (_confirm)// indica que não estava marcada como paga
                        {
                            DataConsultant.InsertProfit(_value, _date.Year, _date.Month);
                        }
                        else// indica que já estava marcada como paga
                        {
                            DataConsultant.InsertProfit(
                            -1 * (_originalValue - _value),// envia a diferença
                            _date.Year, _date.Month);
                        }
                    }
                    // foi marcado como não recebido e estava marcado como pago
                    else if (!_confirm)
                    {
                        Debug.WriteLine("tá marcada como não recebida e o confirm tá false");
                        DataConsultant.InsertProfit(-1 * _originalValue, _date.Year,
                            _date.Month);
                    }
                }

                this.Close();
            }
        }

        private DateTime? GetDate(DateTime date, bool paid)
        {
            if (paid)
                return date;
            else
                return null;
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

            DateTime date = Convert.ToDateTime(DateTimePicker.Value);
            // capturando a data
            if (date.Month != _date.Month)// verifica se a data está no mês correto
            {//se o usuario colocar a data de recebimento em outro mês vai dar problema
                MessageBox.Show("A Data selecionada não é valida, por favor selecione uma " +
                    "data referente ao mês de: " + _date.ToString("MMMM"), 
                    "Preenchimento incorreto", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            else
                _date = date;

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
