﻿namespace SysExpenseControl.Forms
{
    partial class FrmAddEditFixedProfits
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.RtbDescription = new System.Windows.Forms.RichTextBox();
            this.LblTitle = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(61, 56);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(213, 20);
            this.TxtName.TabIndex = 1;
            // 
            // RtbDescription
            // 
            this.RtbDescription.Location = new System.Drawing.Point(20, 134);
            this.RtbDescription.Name = "RtbDescription";
            this.RtbDescription.Size = new System.Drawing.Size(254, 96);
            this.RtbDescription.TabIndex = 2;
            this.RtbDescription.Text = "";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(12, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(167, 20);
            this.LblTitle.TabIndex = 3;
            this.LblTitle.Text = "Adicionar Receita Fixa";
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(80, 82);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(194, 20);
            this.TxtValue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor (R$):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descrição:";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(123, 242);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Location = new System.Drawing.Point(204, 242);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmAddEditFixedProfits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 281);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.RtbDescription);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 320);
            this.Name = "FrmAddEditFixedProfits";
            this.Text = "Receita Fixa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddEditFixedProfits_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.RichTextBox RtbDescription;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
    }
}