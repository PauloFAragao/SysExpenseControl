namespace SysExpenseControl.Forms
{
    partial class FrmAddEditBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnNotPaid = new System.Windows.Forms.Button();
            this.LblDate = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.RtbDescription = new System.Windows.Forms.RichTextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RbFixedBill = new System.Windows.Forms.RadioButton();
            this.RbBill = new System.Windows.Forms.RadioButton();
            this.TxtDueDay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNumberOfInstallments = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbPaid = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnNotPaid
            // 
            this.BtnNotPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnNotPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNotPaid.Location = new System.Drawing.Point(201, 6);
            this.BtnNotPaid.Name = "BtnNotPaid";
            this.BtnNotPaid.Size = new System.Drawing.Size(75, 23);
            this.BtnNotPaid.TabIndex = 13;
            this.BtnNotPaid.Text = "Paga";
            this.BtnNotPaid.UseVisualStyleBackColor = false;
            this.BtnNotPaid.Visible = false;
            this.BtnNotPaid.Click += new System.EventHandler(this.BtnNotPaid_Click);
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(19, 205);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(30, 13);
            this.LblDate.TabIndex = 95;
            this.LblDate.Text = "Data";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Enabled = false;
            this.DateTimePicker.Location = new System.Drawing.Point(55, 201);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(221, 20);
            this.DateTimePicker.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Os campos marcados com asterisco (*) são obrigatórios.";
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Location = new System.Drawing.Point(18, 392);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 12;
            this.BtnEdit.Text = "Editar";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Visible = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Location = new System.Drawing.Point(202, 392);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(121, 392);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "Descrição:";
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(82, 70);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(194, 20);
            this.TxtValue.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Valor (R$):";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(14, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(122, 20);
            this.LblTitle.TabIndex = 100;
            this.LblTitle.Text = "Adicionar Conta";
            // 
            // RtbDescription
            // 
            this.RtbDescription.Location = new System.Drawing.Point(18, 255);
            this.RtbDescription.Name = "RtbDescription";
            this.RtbDescription.Size = new System.Drawing.Size(254, 96);
            this.RtbDescription.TabIndex = 9;
            this.RtbDescription.Text = "";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(63, 44);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(213, 20);
            this.TxtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Nome*:";
            // 
            // RbFixedBill
            // 
            this.RbFixedBill.AutoSize = true;
            this.RbFixedBill.Location = new System.Drawing.Point(200, 99);
            this.RbFixedBill.Name = "RbFixedBill";
            this.RbFixedBill.Size = new System.Drawing.Size(72, 17);
            this.RbFixedBill.TabIndex = 4;
            this.RbFixedBill.TabStop = true;
            this.RbFixedBill.Text = "Conta fixa";
            this.RbFixedBill.UseVisualStyleBackColor = true;
            this.RbFixedBill.CheckedChanged += new System.EventHandler(this.RbFixedBill_CheckedChanged);
            // 
            // RbBill
            // 
            this.RbBill.AutoSize = true;
            this.RbBill.Location = new System.Drawing.Point(21, 99);
            this.RbBill.Name = "RbBill";
            this.RbBill.Size = new System.Drawing.Size(161, 17);
            this.RbBill.TabIndex = 3;
            this.RbBill.TabStop = true;
            this.RbBill.Text = "Conta paga apenas uma vez";
            this.RbBill.UseVisualStyleBackColor = true;
            // 
            // TxtDueDay
            // 
            this.TxtDueDay.Enabled = false;
            this.TxtDueDay.Location = new System.Drawing.Point(125, 127);
            this.TxtDueDay.Name = "TxtDueDay";
            this.TxtDueDay.Size = new System.Drawing.Size(151, 20);
            this.TxtDueDay.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "Data de Vencimento*:";
            // 
            // TxtNumberOfInstallments
            // 
            this.TxtNumberOfInstallments.Enabled = false;
            this.TxtNumberOfInstallments.Location = new System.Drawing.Point(125, 153);
            this.TxtNumberOfInstallments.Name = "TxtNumberOfInstallments";
            this.TxtNumberOfInstallments.Size = new System.Drawing.Size(151, 20);
            this.TxtNumberOfInstallments.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Parcelas Restantes:";
            // 
            // CbPaid
            // 
            this.CbPaid.AutoSize = true;
            this.CbPaid.Location = new System.Drawing.Point(22, 180);
            this.CbPaid.Name = "CbPaid";
            this.CbPaid.Size = new System.Drawing.Size(74, 17);
            this.CbPaid.TabIndex = 7;
            this.CbPaid.Text = "Está paga";
            this.CbPaid.UseVisualStyleBackColor = true;
            this.CbPaid.CheckedChanged += new System.EventHandler(this.CbPaid_CheckedChanged);
            // 
            // FrmAddEditBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 428);
            this.Controls.Add(this.CbPaid);
            this.Controls.Add(this.TxtNumberOfInstallments);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtDueDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RbBill);
            this.Controls.Add(this.RbFixedBill);
            this.Controls.Add(this.BtnNotPaid);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.RtbDescription);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddEditBill_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNotPaid;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.RichTextBox RtbDescription;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RbFixedBill;
        private System.Windows.Forms.RadioButton RbBill;
        private System.Windows.Forms.TextBox TxtDueDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNumberOfInstallments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox CbPaid;
    }
}