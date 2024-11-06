namespace SysExpenseControl.Forms
{
    partial class FrmAddEditMonthExpenses
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
            this.label6 = new System.Windows.Forms.Label();
            this.CbxCategories = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.LblDate = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BtnNotPaid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Os campos marcados com asterisco (*) são obrigatórios.";
            // 
            // CbxCategories
            // 
            this.CbxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxCategories.FormattingEnabled = true;
            this.CbxCategories.Location = new System.Drawing.Point(80, 122);
            this.CbxCategories.Name = "CbxCategories";
            this.CbxCategories.Size = new System.Drawing.Size(194, 21);
            this.CbxCategories.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Categoria*:";
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Location = new System.Drawing.Point(20, 313);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 37;
            this.BtnEdit.Text = "Editar";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Visible = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Location = new System.Drawing.Point(204, 313);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 36;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(123, 313);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 35;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Descrição:";
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(80, 70);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(194, 20);
            this.TxtValue.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Valor (R$)*:";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(12, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(156, 20);
            this.LblTitle.TabIndex = 31;
            this.LblTitle.Text = "Adicionar Gasto Fixo";
            // 
            // RtbDescription
            // 
            this.RtbDescription.Location = new System.Drawing.Point(20, 176);
            this.RtbDescription.Name = "RtbDescription";
            this.RtbDescription.Size = new System.Drawing.Size(254, 96);
            this.RtbDescription.TabIndex = 30;
            this.RtbDescription.Text = "";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(61, 44);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(213, 20);
            this.TxtName.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nome*:";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(17, 100);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(33, 13);
            this.LblDate.TabIndex = 46;
            this.LblDate.Text = "Data:";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Location = new System.Drawing.Point(56, 96);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(218, 20);
            this.DateTimePicker.TabIndex = 45;
            // 
            // BtnNotPaid
            // 
            this.BtnNotPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnNotPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNotPaid.Location = new System.Drawing.Point(199, 6);
            this.BtnNotPaid.Name = "BtnNotPaid";
            this.BtnNotPaid.Size = new System.Drawing.Size(75, 23);
            this.BtnNotPaid.TabIndex = 47;
            this.BtnNotPaid.Text = "Paga";
            this.BtnNotPaid.UseVisualStyleBackColor = false;
            this.BtnNotPaid.Visible = false;
            this.BtnNotPaid.Click += new System.EventHandler(this.BtnNotPaid_Click);
            // 
            // FrmAddEditMonthExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 351);
            this.Controls.Add(this.BtnNotPaid);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CbxCategories);
            this.Controls.Add(this.label5);
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
            this.Name = "FrmAddEditMonthExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gastos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddEditMonthExpenses_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CbxCategories;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Button BtnNotPaid;
    }
}