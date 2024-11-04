using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Collections.Generic;
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

        private Action _onCloseCallback;

        public FrmAddEditMonthExpenses(int tipe, Action onCloseCallback, DateTime date, string tableName,
            int id = 0, string name = "", double amount = 0, string category = "",
            string desciption = "")
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _amount = amount;
            _date = date;
            _tableName = tableName;
            _onCloseCallback = onCloseCallback;

            FillFields(desciption);

            // Carregando os dados
            Task.Run(() => Initialize(category));
        }

        private void FillFields(string desciption)
        {
            if (_tipe != 0)
            {
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
                        DateTime.Now.Month);

                }
                else// Editar
                {
                    DataConsultant.EditMonthProfits(_id, _name, _amount, Convert.ToDateTime(DateTimePicker.Value),
                        this.CbxCategories.Text, this.RtbDescription.Text, _tableName);
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

        private void BtnView_Click(object sender, EventArgs e)
        {

        }

        private void FrmAddEditMonthExpenses_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }
    }
}
