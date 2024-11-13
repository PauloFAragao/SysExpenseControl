using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditMonthExpenses : Form
    {
        private int _tipe;// 0 - adicionar/1 - editar/2 - visualizar
        private int _id;// id no banco de dados - só no caso de editar/visualizar
        private string _name;// nome da despesa
        private double _value;// valor da despesa
        private double _originalValue;// valor da despesa antes da alteração
        private DateTime _date;// data da despesa
        private string _tableName;// nome da tabela 
        private string _category;// categoria do gasto
        private bool _paid;// se já está pago ou não
        private bool _definedNumberOfInstallments;// se tem uma quantidade de parcelas para terminar

        private bool _statusPaid = true;// para mudar para não pago 

        private int _idFixedExpenses;// chave estrangeira para a tabela de gastos fixos

        private Action _onCloseCallback;// evento para atualizar a outra janela

        public FrmAddEditMonthExpenses(int tipe, Action onCloseCallback, DateTime date, string tableName,
            int id = 0, string name = "", double value = 0, string category = "",
            string desciption = "", int idFixedExpenses = 0, bool paid = false, 
            bool definedNumberOfInstallments = false)
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _value = value;
            _originalValue = _value;
            _date = date;
            _tableName = tableName;
            _onCloseCallback = onCloseCallback;
            _category = category;
            _paid = paid;
            _definedNumberOfInstallments = definedNumberOfInstallments;

            _idFixedExpenses = idFixedExpenses;

            FillFields(desciption);

            // Carregando os dados
            Task.Run(() => Initialize(category));
        }

        private void FillFields(string desciption)
        {
            if (_tipe != 0)
            {
                ShowBtnNotPaid();

                this.LblTitle.Text = "Editar Gasto Fixo";
                this.TxtName.Text = _name;
                this.TxtValue.Text = _value.ToString("F2", CultureInfo.InstalledUICulture);
                this.DateTimePicker.Text = _date.ToString();
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
                DateTime date = Convert.ToDateTime(DateTimePicker.Value);

                if (_tipe == 0)// Adicionar
                {
                    int? id = DataConsultant.InsertMonthExpense(_name, _value,
                        date, -1, this.CbxCategories.Text, 
                        this.RtbDescription.Text, date.Year, date.Month, true);

                    if (id == null) return; // deu erro

                    // inserido o gasto na tabela references_to_tables 
                    DataConsultant.InsertExpense(_value, date.Year, date.Month);
                }
                else// Editar
                {
                    bool resultEditMonthExpense = DataConsultant.EditMonthExpense(_id, _name, _value,
                        date, this.CbxCategories.Text, this.RtbDescription.Text, 
                        _tableName, _statusPaid);

                    if (!resultEditMonthExpense) return;

                    if(!_paid && _statusPaid)
                    {
                        // inserido o gasto na tabela references_to_tables 
                        DataConsultant.InsertExpense(_value, date.Year, date.Month);
                    }
                    else if(_paid && !_statusPaid)
                    {
                        // inserido o gasto na tabela references_to_tables 
                        DataConsultant.InsertExpense(
                            -1 * _originalValue,// envia o valor 
                            date.Year, date.Month);
                    }
                    else
                    {
                        // inserido o gasto na tabela references_to_tables 
                        DataConsultant.InsertExpense(
                            -1 * (_originalValue - _value),// envia a diferença
                            date.Year, date.Month);
                    }

                    // para cuidar das contas que tem uma quantidade de parcelas para acabar
                    if (_category == "Contas" && _definedNumberOfInstallments && 
                        !_paid && // se não está marcada como paga
                        _statusPaid)// se está marcada para ser paga
                    {
                        bool result = DataConsultant.EditInstallment(_idFixedExpenses, true);// subitrair uma parcela

                        if (!result) return;
                    }
                    else if(_category == "Contas" && _definedNumberOfInstallments && 
                        _paid &&// se está marcada como paga
                        !_statusPaid)// se está marcada para não paga
                    {
                        bool result = DataConsultant.EditInstallment(_idFixedExpenses, false);// somar uma parcela

                        if (!result) return;
                    }
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
            ShowBtnNotPaid();
        }

        private void ShowBtnNotPaid()
        {
            if(_paid && _category == "Contas")
            {
                this.BtnNotPaid.Visible = true;
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

            Debug.WriteLine("Status: " + _statusPaid);
        }

        // ------------------------- Thread
        private void Initialize(string category)
        {
            List<string> data = DataConsultant.GetCategorys();

            // Carregando os dados no comboBox
            ThreadHelper.SetComboBoxData(CbxCategories, data);

            if (category != "")
                ThreadHelper.SetPropertyValue(CbxCategories, "Text", category);

            else
                ThreadHelper.SetPropertyValue(CbxCategories, "SelectedIndex", 0);
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

        private void FrmAddEditMonthExpenses_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }

        private void BtnNotPaid_Click(object sender, EventArgs e)
        {
            SetNotPaid();
        }
    }
}
