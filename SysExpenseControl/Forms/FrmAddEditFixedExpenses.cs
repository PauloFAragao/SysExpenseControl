﻿using SysExpenseControl.Data;
using SysExpenseControl.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Forms
{
    public partial class FrmAddEditFixedExpenses : Form
    {
        private int _tipe;
        private int _id;
        private string _name;
        private double _amount;
        private int _dueDay;
        private int _numberOfInstallments;
        //private string _category;

        private Action _onCloseCallback;

        public FrmAddEditFixedExpenses(int tipe, Action onCloseCallback, int id = 0, string name = "",
            double amount = 0, int dueDay = 0, int numberOfInstallments = 0, string category = "", 
            string desciption = "")
        {
            InitializeComponent();

            _tipe = tipe;
            _id = id;
            _name = name;
            _amount = amount;
            _dueDay = dueDay;
            _numberOfInstallments = numberOfInstallments;
            _onCloseCallback = onCloseCallback;
            //_category = category;

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
                this.TxtDueDay.Text = _dueDay.ToString();
                this.TxtNumberOfInstallments.Text = _numberOfInstallments.ToString();
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

        private void SelectedIndexChanged()
        {
            if(this.CbxCategories.SelectedIndex == 1)//categoria contas
                this.TxtNumberOfInstallments.Enabled = true;
            
            else
            {
                this.TxtNumberOfInstallments.Enabled = false;
                this.TxtNumberOfInstallments.Text = string.Empty;
            }
        }

        private void Save()
        {
            if (CaptureAndVerifyData())
            {
                if (_tipe == 0)// Adicionar
                {
                    // Adicionando na tabela de gastos fixos
                    int id = DataConsultant.InsertFixedExpense(_name, _amount, _dueDay, _numberOfInstallments,
                        this.CbxCategories.Text, this.RtbDescription.Text);

                    if (id == -1) return; //erro

                    // Adicionando na tabela de gastos do Mês corrente
                    DataConsultant.InsertMonthExpense(_name, _amount, null, id,
                        this.CbxCategories.Text, this.RtbDescription.Text, DateTime.Now.Year,
                        DateTime.Now.Month);

                }
                else// Editar
                    DataConsultant.EditFixedExpense(_id, _name, _amount, _dueDay, _numberOfInstallments,
                        this.CbxCategories.Text, this.RtbDescription.Text);

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
            if (!String.IsNullOrWhiteSpace(this.TxtValue.Text))
            {
                if (Double.TryParse(this.TxtValue.Text, out double value))
                    _amount = value;
                else
                {
                    allFieldsAreCorrect = false;
                    msg += "\nValor";
                }
            }

            // Data de vencimento
            if (!String.IsNullOrWhiteSpace(this.TxtDueDay.Text))
            {
                if (int.TryParse(this.TxtDueDay.Text, out int dueDay))
                    _dueDay = dueDay;
                else
                {
                    allFieldsAreCorrect = false;
                    msg += "\nData de vencimento";
                }
            }

            // Parcelas restantes
            if (!String.IsNullOrWhiteSpace(this.TxtNumberOfInstallments.Text))
            {
                if (int.TryParse(this.TxtNumberOfInstallments.Text, out int numberOfInstallments))
                    _numberOfInstallments = numberOfInstallments;
                else
                {
                    allFieldsAreCorrect = false;
                    msg += "\nParcelas restantes";
                }
            }

            if (!allFieldsAreCorrect)// se algum campo não foi preencido dá um erro
            {
                MessageBox.Show(msg, "Preenchimento incorreto ou não preencimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allFieldsAreCorrect;
        }

        private void Edit()
        {
            this.LblTitle.Text = "Editar Gasto Fixo";

            this.BtnEdit.Visible = false;
            this.BtnSave.Visible = true;
            this.BtnCancel.Visible = true;
        }

        // ------------------------- Thread
        private void Initialize(string category)
        {
            List <string> data= DataConsultant.GetCategorys();

            // Carregando os dados no comboBox
            ThreadHelper.SetComboBoxData(CbxCategories, data);

            if (category != "")
                ThreadHelper.SetPropertyValue(CbxCategories, "Text", category);

            else
                ThreadHelper.SetPropertyValue(CbxCategories, "SelectedIndex", 0);
        }

        // ------------------------- Métodos criados pelo visual studio
        private void CbxCategories_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SelectedIndexChanged();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            Edit();
        }

        private void FrmAddEditFixedExpenses_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }
    }
}
