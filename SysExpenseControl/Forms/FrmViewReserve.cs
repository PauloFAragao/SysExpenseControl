using SysExpenseControl.Controller;
using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmViewReserve : Form
    {
        string _tableName;
        int _id;
        int _operationsQuantity;// para o controle de paginas
        int _pagesQuantity;

        int _page = 1;

        Button _selectedButton;

        public FrmViewReserve(string tableName, string name, int id,
            int operationsQuantity)
        {
            InitializeComponent();

            // pegando referencia do botão selecionado
            _selectedButton = this.Btn01;

            this.LblName.Text = name;

            _tableName = tableName;
            _id = id;
            _operationsQuantity = operationsQuantity;
            _pagesQuantity = (_operationsQuantity / 17) + 1;
            //_pagesQuantity = 8;

            // Organizar os botões na tela
            OrganizeButtons();

            //carregando os dados
            Task.Run(() => Initialize());
        }

        private void OrganizeButtons()
        {
            if (_pagesQuantity > 4) return;

            if (_pagesQuantity == 1)
            {
                // tirando os botões não necessarios
                this.Btn02.Visible = false;
                this.Btn03.Visible = false;
                this.Btn04.Visible = false;
                this.Btn05.Visible = false;

                // desabilitando os botões
                this.PnButtons.Enabled = false;

                // mudando a posição dos botões
                this.BtnBackToFirst.Location = new System.Drawing.Point(100, 3);
                this.BtnBackOne.Location = new System.Drawing.Point(136, 3);
                this.Btn01.Location = new System.Drawing.Point(181, 3);
                this.BtnForwardOne.Location = new System.Drawing.Point(226, 3);
                this.BtnForwardToLast.Location = new System.Drawing.Point(262, 3);

                return;
            }

            if (_pagesQuantity == 2)
            {
                // tirando os botões não necessarios
                this.Btn03.Visible = false;
                this.Btn04.Visible = false;
                this.Btn05.Visible = false;

                // mudando a posição dos botões
                this.BtnBackToFirst.Location = new System.Drawing.Point(81, 3);
                this.BtnBackOne.Location = new System.Drawing.Point(117, 3);
                this.Btn01.Location = new System.Drawing.Point(162, 3);
                this.Btn02.Location = new System.Drawing.Point(198, 3);
                this.BtnForwardOne.Location = new System.Drawing.Point(243, 3);
                this.BtnForwardToLast.Location = new System.Drawing.Point(279, 3);

                return;
            }

            if (_pagesQuantity == 3)
            {
                // tirando os botões não necessarios
                this.Btn04.Visible = false;
                this.Btn05.Visible = false;

                // mudando a posição dos botões
                this.BtnBackToFirst.Location = new System.Drawing.Point(64, 3);
                this.BtnBackOne.Location = new System.Drawing.Point(100, 3);
                this.Btn01.Location = new System.Drawing.Point(145, 3);
                this.Btn02.Location = new System.Drawing.Point(181, 3);
                this.Btn03.Location = new System.Drawing.Point(217, 3);
                this.BtnForwardOne.Location = new System.Drawing.Point(262, 3);
                this.BtnForwardToLast.Location = new System.Drawing.Point(298, 3);

                return;
            }

            if (_pagesQuantity == 4)
            {
                // tirando os botões não necessarios
                this.Btn05.Visible = false;

                // mudando a posição dos botões
                this.BtnBackToFirst.Location = new System.Drawing.Point(45, 3);
                this.BtnBackOne.Location = new System.Drawing.Point(81, 3);
                this.Btn01.Location = new System.Drawing.Point(126, 3);
                this.Btn02.Location = new System.Drawing.Point(162, 3);
                this.Btn03.Location = new System.Drawing.Point(198, 3);
                this.Btn04.Location = new System.Drawing.Point(234, 3);
                this.BtnForwardOne.Location = new System.Drawing.Point(279, 3);
                this.BtnForwardToLast.Location = new System.Drawing.Point(315, 3);

                return;
            }
        }

        private void Back()
        {
            FormLoader.OpenChildForm(new FrmReserves());
        }

        private void ButtonController(int button)
        {
            // controle do botão selecionado
            int buttonNumber = GetButtonNumber(button);

            _page = buttonNumber;

            // caso em que o botão clicado é o botão 5 e o valor no botão
            // é menor que a quantidade de paginas
            if (button == 5 && buttonNumber < _pagesQuantity)
            {
                ChangeButtonsName(buttonNumber - 3);
                ChangeSelectedButton(this.Btn04);
            }
            // caso em que o botão clicado é o botão 5 e o valor no botão
            // é a ultima pagina
            else if (button == 5 && buttonNumber == _pagesQuantity)
            {
                ChangeSelectedButton(this.Btn05);
            }
            // caso em que o botão clicado é o botão 1 e o valor no botão
            // é diferente de 1
            else if (button == 1 && buttonNumber != 1)
            {
                ChangeButtonsName(buttonNumber - 1);
                ChangeSelectedButton(this.Btn02);
            }
            // caso em que o botão clicado é o botão 1 e o valor no botão
            // é 1
            else if (button == 1 && buttonNumber == 1)
            {
                ChangeSelectedButton(this.Btn01);
            }
            else// caso dos botões 2, 3 e 4
            {
                switch (button)
                {
                    case 2:
                        ChangeSelectedButton(this.Btn02);
                        break;
                    case 3:
                        ChangeSelectedButton(this.Btn03);
                        break;
                    case 4:
                        ChangeSelectedButton(this.Btn04);
                        break;
                }
            }

            ReloadPage();
        }

        private void ChangeSelectedButton(Button sender)
        {
            if (_selectedButton != null)
            {
                _selectedButton.BackColor = Color.FromArgb(240, 240, 240);
                _selectedButton = null;
            }

            _selectedButton = sender;
            _selectedButton.BackColor = System.Drawing.Color.Gray;
        }

        private void ChangeButtonsName(int fristButtonValue)
        {
            this.Btn01.Text = fristButtonValue.ToString();
            this.Btn02.Text = (fristButtonValue + 1).ToString();
            this.Btn03.Text = (fristButtonValue + 2).ToString();
            this.Btn04.Text = (fristButtonValue + 3).ToString();
            this.Btn05.Text = (fristButtonValue + 4).ToString();
        }

        private int GetButtonNumber(int button)
        {
            switch (button)
            {
                case 1:
                    return Convert.ToInt32(this.Btn01.Text);
                case 2:
                    return Convert.ToInt32(this.Btn02.Text);
                case 3:
                    return Convert.ToInt32(this.Btn03.Text);
                case 4:
                    return Convert.ToInt32(this.Btn04.Text);
                case 5:
                    return Convert.ToInt32(this.Btn05.Text);
            }

            return 0;
        }

        private void SetButtonOneSelected()
        {
            // verificando se precisa reescrever os nomes dos botões
            if (GetButtonNumber(1) != 1)
            {
                ChangeButtonsName(1);
            }

            ChangeSelectedButton(this.Btn01);

            ReloadPage();
        }

        private void SetLastButtonSelected()
        {
            //se a quantidade de paginas for maior ou igual a 5
            if (_pagesQuantity >= 5)
            {
                // verificar se precisa reescrever os nomes dos botões
                if (GetButtonNumber(5) != _pagesQuantity)
                {
                    ChangeButtonsName(_pagesQuantity - 4);
                }

                ChangeSelectedButton(this.Btn05);
            }
            else// se for menor do que 5
            {
                switch (_pagesQuantity)
                {
                    case 2:
                        ChangeSelectedButton(this.Btn02);
                        break;

                    case 3:
                        ChangeSelectedButton(this.Btn03);
                        break;

                    case 4:
                        ChangeSelectedButton(this.Btn04);
                        break;
                }
            }

            ReloadPage();
        }

        private void BackOnePage()
        {
            int buttonNumber = Convert.ToInt32(_selectedButton.Text);

            // se o botão selecionado não é o botão da pagina 1
            if (buttonNumber != 1)
            {
                // se o botão selecionado é o botão da pagina 2
                if (buttonNumber == 2)
                    ChangeSelectedButton(this.Btn01);

                // se o botão selecionado é o botão 2 e o botão 1 não é a primeira pagina
                else if (_selectedButton == this.Btn02 && this.Btn01.Text != "1")
                    ChangeButtonsName(buttonNumber - 2);

                // se o botão selecionado é o botão 5, 4 ou 3
                else
                {
                    if (_selectedButton == this.Btn05)
                        ChangeSelectedButton(this.Btn04);

                    else if (_selectedButton == this.Btn04)
                        ChangeSelectedButton(this.Btn03);

                    else if (_selectedButton == this.Btn03)
                        ChangeSelectedButton(this.Btn02);
                }
            }

            ReloadPage();
        }

        private void ForwardOnePage()
        {
            int buttonNumber = Convert.ToInt32(_selectedButton.Text);

            // o botão selecionado não é a ultima pagina
            if (buttonNumber != _pagesQuantity)
            {
                if (_pagesQuantity >= 5)// caso tenha 5 ou mais paginas
                {
                    // o botão selecionado é a penultima pagina
                    if (buttonNumber == _pagesQuantity - 1)
                        ChangeSelectedButton(this.Btn05);

                    // se o botão selecionado é o botão 4 e não é a penultima pagina
                    if (_selectedButton == this.Btn04 && buttonNumber != _pagesQuantity - 1)
                        ChangeButtonsName(buttonNumber - 2);

                    // se o botão selecionado é o botão 1, 2 ou 3
                    else
                    {
                        if (_selectedButton == this.Btn01)
                            ChangeSelectedButton(this.Btn02);

                        else if (_selectedButton == this.Btn02)
                            ChangeSelectedButton(this.Btn03);

                        else if (_selectedButton == this.Btn03)
                            ChangeSelectedButton(this.Btn04);
                    }
                }
                else// tem menos do que 5 paginas
                {
                    switch (_pagesQuantity)
                    {
                        case 4:
                            if (_selectedButton != this.Btn04)
                            {
                                if (_selectedButton == this.Btn01)
                                    ChangeSelectedButton(this.Btn02);

                                else if (_selectedButton == this.Btn02)
                                    ChangeSelectedButton(this.Btn03);

                                else if (_selectedButton == this.Btn03)
                                    ChangeSelectedButton(this.Btn04);
                            }

                            break;

                        case 3:
                            if (_selectedButton != this.Btn03)
                            {
                                if (_selectedButton == this.Btn01)
                                    ChangeSelectedButton(this.Btn02);

                                else if (_selectedButton == this.Btn02)
                                    ChangeSelectedButton(this.Btn03);
                            }

                            break;

                        case 2:
                            if (_selectedButton != this.Btn02)
                                ChangeSelectedButton(this.Btn02);
                            break;
                    }
                }
            }

            ReloadPage();
        }

        private void ReloadPage()
        {
            // panel com mensagem
            this.LblWait.Visible = true;

            // botões da interface
            this.BtnAdd.Enabled = false;
            this.BtnDelete.Enabled = false;
            this.BtnEdit.Enabled = false;
            this.BtnView.Enabled = false;

            // botões das paginas
            this.PnButtons.Enabled = false;

            Task.Run(() => Reload());
        }

        // ------------------------- Thread
        private void Initialize()
        {
            if (LoadData())
            {
                //HideColumns();
                //ChangeColumns();

                string reserveAmount = "R$: " + DataConsultant.GetReserveAmount(_id).ToString("N2");

                ThreadHelper.SetPropertyValue(LblValue, "Text", reserveAmount);

                // panel com mensagem
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);

                // botões da interface
                ThreadHelper.SetPropertyValue(BtnAdd, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnDelete, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnEdit, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnView, "Enabled", true);

                // botões das paginas
                ThreadHelper.SetPropertyValue(PnButtons, "Enabled", true);
            }
        }

        private void Reload()
        {
            if (LoadData())
            {
                // panel com mensagem
                ThreadHelper.SetPropertyValue(LblWait, "Visible", false);

                // botões da interface
                ThreadHelper.SetPropertyValue(BtnAdd, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnDelete, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnEdit, "Enabled", true);
                ThreadHelper.SetPropertyValue(BtnView, "Enabled", true);

                // botões das paginas
                ThreadHelper.SetPropertyValue(PnButtons, "Enabled", true);
            }
        }

        private bool LoadData()
        {
            DataTable dataTable = DataConsultant.ViewReserve(_tableName, (_page - 1) * 17);

            if (dataTable != null)
            {
                // carregando os dados no DataGridView
                ThreadHelper.SetPropertyValue(this.DgvData, "DataSource", dataTable);

                return true;
            }
            else
                return false;
        }

        private void HideColumns()
        {

        }

        private void ChangeColumns()
        {

        }

        // ------------------------- Métodos criados pelo visual studio
        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnView_Click(object sender, EventArgs e)
        {

        }

        // ------------------------- botões do controle de paginas
        private void BtnBackToFirst_Click(object sender, EventArgs e)
        {
            SetButtonOneSelected();
        }

        private void BtnBackOne_Click(object sender, EventArgs e)
        {
            BackOnePage();
        }

        private void Btn01_Click(object sender, EventArgs e)
        {
            ButtonController(1);
        }

        private void Btn02_Click(object sender, EventArgs e)
        {
            ButtonController(2);
        }

        private void Btn03_Click(object sender, EventArgs e)
        {
            ButtonController(3);
        }

        private void Btn04_Click(object sender, EventArgs e)
        {
            ButtonController(4);
        }

        private void Btn05_Click(object sender, EventArgs e)
        {
            ButtonController(5);
        }

        private void BtnForwardOne_Click(object sender, EventArgs e)
        {
            ForwardOnePage();
        }

        private void BtnForwardToLast_Click(object sender, EventArgs e)
        {
            SetLastButtonSelected();
        }
    }
}
