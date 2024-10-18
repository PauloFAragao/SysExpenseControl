using System.Drawing;
using System.Windows.Forms;

namespace SysExpenseControl.Controller
{
    internal class ButtonsController
    {
        private static Button _currentButton;// botão senecionado

        private static Button _btnHome;// botão de iniciar
        private static Button _btnAccountsPayable;// botão das contas a pagar
        private static Button _btnDetailedExpenses;// botão para visualizar os gastos
        private static Button _btnSettings;// botão das configurações

        //cores
        private static Color _unselectedButton = Color.FromArgb(102, 102, 102);
        private static Color _selectedButton = Color.FromArgb(159, 159, 159);

        // Método para passar as referencias dos botões
        public static void SetButtonsData(
            Button btnHome, Button btnAccountsPayable, Button btnDetailedExpenses, Button btnSettings)
        {
            _btnHome = btnHome;
            _btnAccountsPayable = btnAccountsPayable;
            _btnDetailedExpenses = btnDetailedExpenses;
            _btnSettings = btnSettings;
        }

        // Método para desselecionar o botão que está selecionado atualmente
        public static void UnselectCurrentButton()
        {
            if (_currentButton != null)
            {
                _currentButton.BackColor = _unselectedButton;
                _currentButton = null;
            }
        }

        // Método para marcar que o botão home foi selecionado
        public static void SetBtnHomeSelected()
        {
            if (_currentButton != _btnHome)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnHome;
                _currentButton.BackColor = _selectedButton;
            }
        }

        // Método para marcar que o botão de contas a pagar
        public static void SetBtnAccountsPayableSelected()
        {
            if (_currentButton != _btnAccountsPayable)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnAccountsPayable;
                _currentButton.BackColor = _selectedButton;
            }
        }

        // Método para marcar que o botão de Despesas detalhadas
        public static void SetBtnDetailedExpensesSelected()
        {
            if (_currentButton != _btnDetailedExpenses)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnDetailedExpenses;
                _currentButton.BackColor = _selectedButton;
            }
        }

        // Método para marcar que o botão das configurações
        public static void SetBtnSettingsSelected()
        {
            if (_currentButton != _btnSettings)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnSettings;
                _currentButton.BackColor = _selectedButton;
            }
        }

    }
}
