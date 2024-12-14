using SysExpenseControl.Data;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditReserveOperation : Form
    {
        int _id;
        int _type; // 0 - Adicionar | 1 - Editar | 2 - Visualizar

        Action _onCloseCallback;

        string _name;
        DateTime _date;
        double _value;
        double _orinalValue;
        bool _operation; // true para inserir false para retirar

        string _tableName;

        public FrmAddEditReserveOperation(string tableName, int type, string name, DateTime date,
             Action onCloseCallback, int id = 0, double value = 0, bool operation = true,
             string description = "")
        {
            InitializeComponent();

            _tableName = tableName;
            _id = id;
            _name = name;
            _type = type;
            _date = date;
            _value = value;
            _orinalValue = value;
            _operation = operation;
            _onCloseCallback = onCloseCallback;

            FillFields(description);
        }

        private void FillFields(string description)
        {
            this.LblName.Text = _name;

            if (_type != 0)
            {
                this.TxtValue.Text = _value.ToString("F2", CultureInfo.InstalledUICulture);
                this.DateTimePicker.Text = _date.ToString();
                this.RtbDescription.Text = description;

                if(!_operation) this.RbWithdraw.Checked = true;

                if (_type == 2)
                {
                    this.BtnEdit.Visible = true;
                    this.BtnSave.Visible = false;
                    this.BtnCancel.Visible = false;
                }
            }
        }

        private void Save()
        {
            if(CaptureAndVerifyData())
            {
                if(_type == 0)// adicionar operação
                {
                    int? result = DataConsultant.InsertInReserve( _tableName ,
                        _operation ? "Inserção" : "Retirada", _value, _date,
                        this.RtbDescription.Text );

                    // Erro
                    if(result == null) return;

                    if(!DataConsultant.EditReservationAmount(_value, _tableName))
                    {
                        return;
                    }
                }
                else// editar operação
                {
                    bool result = DataConsultant.EditReserveOperation(
                        _id, _tableName, _operation ? "Inserção" : "Retirada", _value,
                        _date, this.RtbDescription.Text );

                    //Erro
                    if(!result) return;

                    // Alterar caso haja diferença no valor
                    if(result && _value != _orinalValue)
                    {
                        DataConsultant.MakeChangesInReservation(_tableName, 
                            (_value - _orinalValue) );
                    }
                }

                this.Close();
            }
        }

        private bool CaptureAndVerifyData()
        {
            bool allFieldsAreCorrect = true;
            string msg = "Os seguintes campos não foram preenchidos corretamente:";

            // capturando o tipo de operação
            _operation = this.RbInsert.Checked;

            // Valor
            if (!String.IsNullOrWhiteSpace(this.TxtValue.Text) &&
                Double.TryParse(this.TxtValue.Text, out double value))
            {
                if((_operation && value < 0) ||// Se está somando
                    (!_operation && value > 0))// se está subtraindo
                {
                    value = value * -1;
                }

                _value = value;
            }
            else
            {
                allFieldsAreCorrect = false;
                msg += "\nValor";
            }

            // capturando a data
            _date = Convert.ToDateTime(this.DateTimePicker.Value);

            if (!allFieldsAreCorrect)// se algum campo não foi preencido dá um erro
            {
                MessageBox.Show(msg, "Preenchimento incorreto ou não preencimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allFieldsAreCorrect;
        }

        private void EnableEdit()
        {
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableEdit();
        }

        private void FrmAddEditReserveOperation_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }
    }
}
