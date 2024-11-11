using System.Drawing;
using System.Windows.Forms;

namespace SysExpenseControl.Controller
{
    static class ButtonsController
    {
        private static Button _currentButton;// botão selecionado

        private static Button _btnHome;// botão de inicio
        private static Button _btnAccountsPayable;// botão das contas a pagar
        private static Button _btnFixedExpensesAndProfits;// botão para a tela de gastos e lucros fixos
        private static Button _btnMonthlyExpensesAndProfits;// botão para a tela de gastos e lucros do mês
        private static Button _btnReserves;// botão para tela de reservas
        private static Button _btnInvestments;// botão para tela de investimentos
        private static Button _btnSettings;// botão das configurações

        //cores
        private static Color _unselectedButton = Color.FromArgb(102, 102, 102);
        private static Color _selectedButton = Color.FromArgb(159, 159, 159);

        // Método para passar as referencias dos botões
        public static void SetButtonsData( Button btnHome, Button btnAccountsPayable, 
            Button btnFixedExpensesAndProfits, Button btnMonthlyExpensesAndProfits, Button btnReserves, 
            Button btnInvestments, Button btnSettings)
        {
            _btnHome = btnHome;
            _btnAccountsPayable = btnAccountsPayable;
            _btnFixedExpensesAndProfits = btnFixedExpensesAndProfits;
            _btnMonthlyExpensesAndProfits = btnMonthlyExpensesAndProfits;
            _btnReserves = btnReserves;
            _btnInvestments = btnInvestments;
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

        // Método para marcar que o botão de gastos e lucros do fixos
        public static void SetBtnFixedExpensesAndProfitsSelected()
        {
            if (_currentButton != _btnFixedExpensesAndProfits)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnFixedExpensesAndProfits;
                _currentButton.BackColor = _selectedButton;
            }
        }

        // Método para marcar que o botão de gastos e lucros do mês
        public static void SetBtnMonthlyExpensesAndProfitsSelected()
        {
            if (_currentButton != _btnMonthlyExpensesAndProfits)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnMonthlyExpensesAndProfits;
                _currentButton.BackColor = _selectedButton;
            }
        }

        // Método para marcar que o botão de reservas
        public static void SetBtnReservesSelected()
        {
            if (_currentButton != _btnReserves)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnReserves;
                _currentButton.BackColor = _selectedButton;
            }
        }

        // Método para marcar que o botão de investimentos
        public static void SetBtnInvestmentsSelected()
        {
            if (_currentButton != _btnInvestments)
            {
                if (_currentButton != null)
                    UnselectCurrentButton();

                _currentButton = _btnInvestments;
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
