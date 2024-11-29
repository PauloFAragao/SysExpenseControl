using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmSelectDate : Form
    {
        private bool _dataLoaded = false;
        private Action _onCloseCallback;

        public FrmSelectDate(Action onCloseCallback)
        {
            InitializeComponent();

            _onCloseCallback = onCloseCallback;

            Task.Run(() => Initialize());
        }

        private void SelectDate()
        {
            SelectedDateData.SetData(this.CbxMonth.Text, this.CbxYear.Text);

            this.Close();
        }

        private void LoadData()
        {
            if (!_dataLoaded) return;

            CbxMonth.Items.Clear();// deletando os dados que tem no combo box
            BtnSelect.Enabled = false;// desabilitando o botão de seleção

            int year = Convert.ToInt32(this.CbxYear.Text);
            Task.Run(() => LoadMonths(year));

            BtnSelect.Enabled = true;// reabilitando o botão de seleção
        }

        // ------------------------- Thread
        private void Initialize()
        {
            LoadMonths(DateTime.Now.Year);
            LoadYears();

            // Ativando o botão de selecionar
            ThreadHelper.SetPropertyValue(BtnSelect, "Enabled", true);

            // Ativando o campo de ano
            ThreadHelper.SetPropertyValue(CbxYear, "Enabled", true);

            // Mudando a "Flag" para indicar que os dados já foram carregados
            ThreadHelper.SetFieldValue(this, "_dataLoaded", true);
        }

        // Método que vai pegar os mês que tem no banco de dados e carregar no combo box
        private void LoadMonths(int Year)
        {
            List<string> data = DataConsultant.GetMonths(Year);
            List<string> months = new List<string>();

            foreach (string m in data)
            {
                months.Add(GetMonthName(Convert.ToInt32(m)) + "(" + m + ")");
            }

            // Carregando os dados no comboBox
            ThreadHelper.SetComboBoxData(CbxMonth, months);

            ThreadHelper.SetPropertyValue(CbxMonth, "Text", 
                GetMonthName(DateTime.Now.Month) + "(" + DateTime.Now.Month + ")");
        }

        // Método que vai pegar os anos que tem no banco de dados e carregar no combo box
        private void LoadYears()
        {
            List<string> data = DataConsultant.GetYears();

            // Carregando os dados no comboBox
            ThreadHelper.SetComboBoxData(CbxYear, data);

            ThreadHelper.SetPropertyValue(CbxYear, "Text", DateTime.Now.Year.ToString());
        }

        // Método gambiarra para pegar o nome do mês
        private string GetMonthName(int month)
        {
            return new DateTime(1990, month, 20).ToString("MMMM");
        }

        // ------------------------- Métodos criados pelo visual studio
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SelectDate();
        }

        private void FrmSelectDate_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }

        private void CbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
