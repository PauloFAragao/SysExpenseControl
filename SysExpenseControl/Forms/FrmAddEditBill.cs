using System;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditBill : Form
    {
        private int _tipe;// 0 - adicionar/ 1 - editar / 2 - visualizar
        private bool _fixedbill;// indica no caso de edição se é uma conta fixa

        public FrmAddEditBill()
        {
            InitializeComponent();

            RbBill.Select();// para inicar checado como uma conta não fixa
        }

        private void Save()
        {
            if(_tipe == 0)// para adicionar
            {
                if(this.RbFixedBill.Checked)// verifica se é uma conta fixa
                {
                    // adionar nas contas fixas

                }
                // adiconar nas contas desse mês

            }
            else// para editar
            {
                if(_fixedbill)// verifica se é uma conta fixa
                {
                    if (this.RbFixedBill.Checked)// não mudou, ainda é uma conta fixa
                    {
                        // fazer edições
                    }
                    else// mudou de conta fixa para conta não fixa
                    {
                        // deletar conta fixa

                        // fazer outras edições
                    }
                }
                else// não é uma conta fixa
                {
                    if (this.RbFixedBill.Checked)// Mudou para conta fixa
                    {
                        // adicionar conta fixa

                        // fazer edições
                    }
                    else// não mudou para conta fixa
                    {
                        // fazer edições
                    }
                }
            }
        }

        private void Paid()
        {
            this.DateTimePicker.Enabled = this.CbPaid.Checked;
        }

        private void BillTipe() 
        {
            if (this.RbBill.Checked)
            {
                this.TxtDueDay.Enabled = false;
                this.TxtNumberOfInstallments.Enabled = false;
            }
            else
            {
                this.TxtDueDay.Enabled = true;
                this.TxtNumberOfInstallments.Enabled = true;
            }
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

        }

        private void BtnNotPaid_Click(object sender, EventArgs e)
        {

        }

        private void CbPaid_CheckedChanged(object sender, EventArgs e)
        {
            Paid();
        }

        private void RbFixedBill_CheckedChanged(object sender, EventArgs e)
        {
            BillTipe();
        }

    }
}
