namespace SysExpenseControl.Forms
{
    partial class FrmViewBill
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
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblBillName = new System.Windows.Forms.Label();
            this.LblValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblBillTipe = new System.Windows.Forms.Label();
            this.LblDueDay = new System.Windows.Forms.Label();
            this.LblNumberOfInstallments = new System.Windows.Forms.Label();
            this.LblPaid = new System.Windows.Forms.Label();
            this.LblPaidDate = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 117;
            this.label7.Text = "Parcelas Restantes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "Data de Vencimento:";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(17, 108);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(104, 13);
            this.LblDate.TabIndex = 116;
            this.LblDate.Text = "Data do pagamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "Descrição:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 119;
            this.label3.Text = "Valor (R$):";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(12, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(124, 20);
            this.LblTitle.TabIndex = 121;
            this.LblTitle.Text = "Visualizar Conta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Nome:";
            // 
            // LblBillName
            // 
            this.LblBillName.AutoSize = true;
            this.LblBillName.Location = new System.Drawing.Point(52, 47);
            this.LblBillName.Name = "LblBillName";
            this.LblBillName.Size = new System.Drawing.Size(80, 13);
            this.LblBillName.TabIndex = 122;
            this.LblBillName.Text = "Nome da conta";
            // 
            // LblValue
            // 
            this.LblValue.AutoSize = true;
            this.LblValue.Location = new System.Drawing.Point(272, 47);
            this.LblValue.Name = "LblValue";
            this.LblValue.Size = new System.Drawing.Size(76, 13);
            this.LblValue.TabIndex = 123;
            this.LblValue.Text = "Valor da conta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 124;
            this.label6.Text = "Tipo de conta:";
            // 
            // LblBillTipe
            // 
            this.LblBillTipe.AutoSize = true;
            this.LblBillTipe.Location = new System.Drawing.Point(90, 67);
            this.LblBillTipe.Name = "LblBillTipe";
            this.LblBillTipe.Size = new System.Drawing.Size(54, 13);
            this.LblBillTipe.TabIndex = 125;
            this.LblBillTipe.Text = "Conta fixa";
            // 
            // LblDueDay
            // 
            this.LblDueDay.AutoSize = true;
            this.LblDueDay.Location = new System.Drawing.Point(322, 67);
            this.LblDueDay.Name = "LblDueDay";
            this.LblDueDay.Size = new System.Drawing.Size(23, 13);
            this.LblDueDay.TabIndex = 126;
            this.LblDueDay.Text = "Dia";
            // 
            // LblNumberOfInstallments
            // 
            this.LblNumberOfInstallments.AutoSize = true;
            this.LblNumberOfInstallments.Location = new System.Drawing.Point(117, 87);
            this.LblNumberOfInstallments.Name = "LblNumberOfInstallments";
            this.LblNumberOfInstallments.Size = new System.Drawing.Size(62, 13);
            this.LblNumberOfInstallments.TabIndex = 127;
            this.LblNumberOfInstallments.Text = "Quantidade";
            // 
            // LblPaid
            // 
            this.LblPaid.AutoSize = true;
            this.LblPaid.Location = new System.Drawing.Point(218, 87);
            this.LblPaid.Name = "LblPaid";
            this.LblPaid.Size = new System.Drawing.Size(77, 13);
            this.LblPaid.TabIndex = 128;
            this.LblPaid.Text = "Não está paga";
            // 
            // LblPaidDate
            // 
            this.LblPaidDate.AutoSize = true;
            this.LblPaidDate.Location = new System.Drawing.Point(119, 108);
            this.LblPaidDate.Name = "LblPaidDate";
            this.LblPaidDate.Size = new System.Drawing.Size(72, 13);
            this.LblPaidDate.TabIndex = 129;
            this.LblPaidDate.Text = "Dia/Mês/Ano";
            // 
            // LblDescription
            // 
            this.LblDescription.Location = new System.Drawing.Point(17, 147);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(328, 145);
            this.LblDescription.TabIndex = 130;
            this.LblDescription.Text = "Descrição";
            // 
            // FrmViewBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 302);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.LblPaidDate);
            this.Controls.Add(this.LblPaid);
            this.Controls.Add(this.LblNumberOfInstallments);
            this.Controls.Add(this.LblDueDay);
            this.Controls.Add(this.LblBillTipe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblValue);
            this.Controls.Add(this.LblBillName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.label1);
            this.Name = "FrmViewBill";
            this.Text = "FrmViewBill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblBillName;
        private System.Windows.Forms.Label LblValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblBillTipe;
        private System.Windows.Forms.Label LblDueDay;
        private System.Windows.Forms.Label LblNumberOfInstallments;
        private System.Windows.Forms.Label LblPaid;
        private System.Windows.Forms.Label LblPaidDate;
        private System.Windows.Forms.Label LblDescription;
    }
}