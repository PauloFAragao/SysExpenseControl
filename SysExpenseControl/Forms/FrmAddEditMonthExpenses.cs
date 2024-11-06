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
        private int _tipe;
        private int _id;
        private string _name;
        private double _amount;
        private DateTime _date;
        private string _tableName;
        private string _category;
        private bool _paid;

        private bool _statusPaid = true;

        private int _idFixedExpenses;// chave estrangeira para a tabela de gastos fixos

        private Action _onCloseCallback;

        public FrmAddEditMonthExpenses(int tipe, Action onCloseCallback, DateTime date, string tableName,
            int id = 0, string name = "", double amount = 0, string category = "",
            string desciption = "", int idFixedExpenses = 0, bool paid = false)
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _amount = amount;
            _date = date;
            _tableName = tableName;
            _onCloseCallback = onCloseCallback;
            _category = category;
            _paid = paid;

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
                this.TxtValue.Text = _amount.ToString("F2", CultureInfo.InstalledUICulture);
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
                if (_tipe == 0)// Adicionar
                {
                    DataConsultant.InsertMonthExpense(_name, _amount, Convert.ToDateTime(DateTimePicker.Value),
                        -1, this.CbxCategories.Text, this.RtbDescription.Text, DateTime.Now.Year,
                        DateTime.Now.Month, true);

                }
                else// Editar
                {
                    DataConsultant.EditMonthExpense(_id, _name, _amount, Convert.ToDateTime(DateTimePicker.Value),
                        this.CbxCategories.Text, this.RtbDescription.Text, _tableName, _statusPaid);

                    // para subtrair uma parcela
                    if (_idFixedExpenses != 0 &&// tem referencia a um gasto fixo
                        _category == "Contas" &&// é uma conta
                        !_paid &&// não está paga
                        _statusPaid)// está editando para pagar
                    {
                        DataConsultant.SubtractInstallment(_idFixedExpenses);
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
                _amount = value;
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
