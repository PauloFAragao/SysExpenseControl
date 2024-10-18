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
            ButtonsController.SetButtonsData(this.BtnHome, this.BtnAccountsPayable, this.BtnDetailedExpenses ,this.BtnSettings);

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
        }

        private void Settings() 
        {
            ButtonsController.SetBtnSettingsSelected();
        }

        private void DetailedExpenses()
        {
            ButtonsController.SetBtnDetailedExpensesSelected();
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

        private void BtnDetailedExpenses_Click(object sender, System.EventArgs e)
        {
            DetailedExpenses();
        }
    }
}
