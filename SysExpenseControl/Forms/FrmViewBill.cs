using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmViewBill : Form
    {
        private string _name;
        private string _value;
        private string _dueDay;
        private int _idFixedExpenses;
        private string _numberOfInstallments;
        private bool _paid;
        private DateTime? _date;
        private string _description;

        public FrmViewBill(string name, string value, string dueDay, int idFixedExpenses, 
            string numberOfInstallments, bool paid, DateTime? date, string description)
        {
            InitializeComponent();

            _name = name;
            _value = value;
            _dueDay = dueDay;
            _idFixedExpenses = idFixedExpenses;
            _numberOfInstallments = numberOfInstallments;
            _paid = paid;
            _date = date;
            _description = description;

            FillFields();
        }

        private void FillFields()
        {
            this.LblBillName.Text = _name;
            this.LblValue.Text = _value;

            this.LblBillTipe.Text = _idFixedExpenses == 0 ? "Paga apenas uma vez" : "Conta fixa";

            this.LblDueDay.Text = _dueDay;
            this.LblNumberOfInstallments.Text = _numberOfInstallments;

            this.LblPaid.Text = _paid ? "Está paga" : "Não está paga";

            this.LblPaidDate.Text = _date != null ?
                //_date.ToString("d 'de' MMMM 'de' yyyy") 
                _date.Value.ToString("d 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("pt-BR"))
                : "";

            this.LblDescription.Text = _description;
        }
    }
}
