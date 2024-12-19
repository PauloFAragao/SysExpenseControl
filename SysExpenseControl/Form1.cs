using SysExpenseControl.Controller;
using SysExpenseControl.Forms;
using System.Windows.Forms;

namespace SysExpenseControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FormLoader.PanelBody = this.PanelBody;// Enviando a referencia do painel

            // Enviando as dos botões
            ButtonsController.SetButtonsData(this.BtnHome, this.BtnAccountsPayable, this.BtnFixedExpensesAndProfits,
                this.BtnMonthlyExpensesAndProfits, this.BtnReserves, this.BtnInvestments, this.BtnSettings);

            ButtonsController.SetBtnHomeSelected();// Para iniciar
            FormLoader.OpenChildForm(new FrmHome());
        }

        private void Home()
        {
            ButtonsController.SetBtnHomeSelected();
            FormLoader.OpenChildForm(new FrmHome());
        }

        private void AccountsPayable()
        {
            ButtonsController.SetBtnAccountsPayableSelected();
            FormLoader.OpenChildForm(new FrmAccountsPayable());
        }

        private void FixedExpensesAndProfits()
        {
            ButtonsController.SetBtnFixedExpensesAndProfitsSelected();
            FormLoader.OpenChildForm(new FrmFixedExpensesAndProfits());
        }

        private void MonthlyExpensesAndProfits()
        {
            ButtonsController.SetBtnMonthlyExpensesAndProfitsSelected();
            FormLoader.OpenChildForm(new FrmMonthlyExpensesAndProfits());
        }

        private void Reserves() 
        {
            ButtonsController.SetBtnReservesSelected();
            FormLoader.OpenChildForm(new FrmReserves());
        }

        private void Investments()
        {
            ButtonsController.SetBtnInvestmentsSelected();
            FormLoader.OpenChildForm(new FrmInvestments());
        }

        private void Settings()
        {
            ButtonsController.SetBtnSettingsSelected();
            FormLoader.OpenChildForm(new FrmConfigureCategories());
        }

        // ---------------------------- Métodos criados pelo Visual Studio
        private void BtnHome_Click(object sender, System.EventArgs e)
        {
            Home();
        }

        private void BtnAccountsPayable_Click(object sender, System.EventArgs e)
        {
            AccountsPayable();
        }

        private void BtnSettings_Click(object sender, System.EventArgs e)
        {
            Settings();
        }

        private void BtnFixedExpensesAndProfits_Click(object sender, System.EventArgs e)
        {
            FixedExpensesAndProfits();
        }

        private void BtnMonthlyExpensesAndProfits_Click(object sender, System.EventArgs e)
        {
            MonthlyExpensesAndProfits();
        }

        private void BtnReserves_Click(object sender, System.EventArgs e)
        {
            Reserves();
        }

        private void BtnInvestments_Click(object sender, System.EventArgs e)
        {
            Investments();
        }
    }
}
