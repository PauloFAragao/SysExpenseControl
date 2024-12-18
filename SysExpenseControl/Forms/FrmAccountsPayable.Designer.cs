﻿namespace SysExpenseControl.Forms
{
    partial class FrmAccountsPayable
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblTotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblOverdueAccounts = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblAmountPayable = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblAmountPaid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LblWait = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnMark = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnView = new System.Windows.Forms.Button();
            this.BtnChangeMonth = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CbxFilter = new System.Windows.Forms.ComboBox();
            this.LblAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblDisplayMonth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.LblWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(13, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 327);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totais a Pagar";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.LblTotal);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(16, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(243, 58);
            this.panel4.TabIndex = 3;
            // 
            // LblTotal
            // 
            this.LblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(143, 26);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblTotal.Size = new System.Drawing.Size(96, 20);
            this.LblTotal.TabIndex = 4;
            this.LblTotal.Text = "R$: 0000,00";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Total Geral:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.LblOverdueAccounts);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(16, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(243, 58);
            this.panel3.TabIndex = 2;
            // 
            // LblOverdueAccounts
            // 
            this.LblOverdueAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblOverdueAccounts.AutoSize = true;
            this.LblOverdueAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOverdueAccounts.ForeColor = System.Drawing.Color.White;
            this.LblOverdueAccounts.Location = new System.Drawing.Point(143, 26);
            this.LblOverdueAccounts.Name = "LblOverdueAccounts";
            this.LblOverdueAccounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblOverdueAccounts.Size = new System.Drawing.Size(96, 20);
            this.LblOverdueAccounts.TabIndex = 6;
            this.LblOverdueAccounts.Text = "R$: 0000,00";
            this.LblOverdueAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(11, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Vencidas:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LblAmountPayable);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(16, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 58);
            this.panel2.TabIndex = 1;
            // 
            // LblAmountPayable
            // 
            this.LblAmountPayable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAmountPayable.AutoSize = true;
            this.LblAmountPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmountPayable.ForeColor = System.Drawing.Color.White;
            this.LblAmountPayable.Location = new System.Drawing.Point(143, 26);
            this.LblAmountPayable.Name = "LblAmountPayable";
            this.LblAmountPayable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblAmountPayable.Size = new System.Drawing.Size(96, 20);
            this.LblAmountPayable.TabIndex = 4;
            this.LblAmountPayable.Text = "R$: 0000,00";
            this.LblAmountPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "A Pagar:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblAmountPaid);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(16, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 58);
            this.panel1.TabIndex = 0;
            // 
            // LblAmountPaid
            // 
            this.LblAmountPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAmountPaid.AutoSize = true;
            this.LblAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmountPaid.Location = new System.Drawing.Point(144, 25);
            this.LblAmountPaid.Name = "LblAmountPaid";
            this.LblAmountPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblAmountPaid.Size = new System.Drawing.Size(96, 20);
            this.LblAmountPaid.TabIndex = 2;
            this.LblAmountPaid.Text = "R$: 0000,00";
            this.LblAmountPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Pagas:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.groupBox3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(618, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(308, 572);
            this.panel7.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(14, 0, 0, 8);
            this.panel6.Size = new System.Drawing.Size(618, 572);
            this.panel6.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.LblWait);
            this.panel8.Controls.Add(this.DgvData);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(14, 75);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 30);
            this.panel8.Size = new System.Drawing.Size(604, 489);
            this.panel8.TabIndex = 9;
            // 
            // LblWait
            // 
            this.LblWait.Controls.Add(this.label4);
            this.LblWait.Location = new System.Drawing.Point(182, 204);
            this.LblWait.Name = "LblWait";
            this.LblWait.Size = new System.Drawing.Size(205, 52);
            this.LblWait.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Wait...";
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.AllowUserToDeleteRows = false;
            this.DgvData.AllowUserToOrderColumns = true;
            this.DgvData.AllowUserToResizeColumns = false;
            this.DgvData.AllowUserToResizeRows = false;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvData.Enabled = false;
            this.DgvData.Location = new System.Drawing.Point(0, 5);
            this.DgvData.MultiSelect = false;
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.Size = new System.Drawing.Size(604, 454);
            this.DgvData.TabIndex = 8;
            this.DgvData.SelectionChanged += new System.EventHandler(this.DgvData_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.BtnMark);
            this.panel5.Controls.Add(this.BtnAdd);
            this.panel5.Controls.Add(this.BtnView);
            this.panel5.Controls.Add(this.BtnChangeMonth);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.CbxFilter);
            this.panel5.Controls.Add(this.LblAmount);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.LblDisplayMonth);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(14, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(604, 75);
            this.panel5.TabIndex = 7;
            // 
            // BtnMark
            // 
            this.BtnMark.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMark.Location = new System.Drawing.Point(303, 42);
            this.BtnMark.Name = "BtnMark";
            this.BtnMark.Size = new System.Drawing.Size(129, 23);
            this.BtnMark.TabIndex = 10;
            this.BtnMark.Text = "Marcar como não pago";
            this.BtnMark.UseVisualStyleBackColor = false;
            this.BtnMark.Click += new System.EventHandler(this.BtnMark_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAdd.Enabled = false;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Location = new System.Drawing.Point(438, 42);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 9;
            this.BtnAdd.Text = "Adicionar";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnView
            // 
            this.BtnView.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnView.Enabled = false;
            this.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnView.Location = new System.Drawing.Point(519, 42);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(75, 23);
            this.BtnView.TabIndex = 7;
            this.BtnView.Text = "Visualizar";
            this.BtnView.UseVisualStyleBackColor = false;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // BtnChangeMonth
            // 
            this.BtnChangeMonth.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnChangeMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangeMonth.Location = new System.Drawing.Point(303, 10);
            this.BtnChangeMonth.Name = "BtnChangeMonth";
            this.BtnChangeMonth.Size = new System.Drawing.Size(75, 23);
            this.BtnChangeMonth.TabIndex = 6;
            this.BtnChangeMonth.Text = "Trocar Mês";
            this.BtnChangeMonth.UseVisualStyleBackColor = false;
            this.BtnChangeMonth.Click += new System.EventHandler(this.BtnChangeMonth_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Filtro:";
            // 
            // CbxFilter
            // 
            this.CbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFilter.Enabled = false;
            this.CbxFilter.FormattingEnabled = true;
            this.CbxFilter.Items.AddRange(new object[] {
            "Todas",
            "Pagas",
            "A pagar",
            "Vencidas"});
            this.CbxFilter.Location = new System.Drawing.Point(50, 44);
            this.CbxFilter.Name = "CbxFilter";
            this.CbxFilter.Size = new System.Drawing.Size(152, 21);
            this.CbxFilter.TabIndex = 4;
            this.CbxFilter.SelectedIndexChanged += new System.EventHandler(this.CbxFilter_SelectedIndexChanged);
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblAmount.Location = new System.Drawing.Point(132, 15);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(19, 13);
            this.LblAmount.TabIndex = 3;
            this.LblAmount.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantidade de contas:";
            // 
            // LblDisplayMonth
            // 
            this.LblDisplayMonth.AutoSize = true;
            this.LblDisplayMonth.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblDisplayMonth.Location = new System.Drawing.Point(249, 15);
            this.LblDisplayMonth.Name = "LblDisplayMonth";
            this.LblDisplayMonth.Size = new System.Drawing.Size(48, 13);
            this.LblDisplayMonth.TabIndex = 1;
            this.LblDisplayMonth.Text = "01/2000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mês referente: ";
            // 
            // FrmAccountsPayable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 572);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Name = "FrmAccountsPayable";
            this.Text = "FrmAccountsPayable";
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.LblWait.ResumeLayout(false);
            this.LblWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblOverdueAccounts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblAmountPayable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblAmountPaid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BtnChangeMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbxFilter;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblDisplayMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnView;
        private System.Windows.Forms.Panel LblWait;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnMark;
    }
}