namespace SysExpenseControl.Forms
{
    partial class FrmMonthlyExpensesAndProfits
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
            this.BtnViewExpenses = new System.Windows.Forms.Button();
            this.BtnEditExpenses = new System.Windows.Forms.Button();
            this.BtnDelExpenses = new System.Windows.Forms.Button();
            this.DgvExpenses = new System.Windows.Forms.DataGridView();
            this.BtnViewProfits = new System.Windows.Forms.Button();
            this.BtnEditProfits = new System.Windows.Forms.Button();
            this.BtnDelProfits = new System.Windows.Forms.Button();
            this.BtnAddProfits = new System.Windows.Forms.Button();
            this.BtnAddExpenses = new System.Windows.Forms.Button();
            this.DgvProfits = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblExepencesMonth = new System.Windows.Forms.Label();
            this.LblExpenses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblProfits = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblProftsMonth = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LblWait = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.BtnChangeMonth = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LblMonth = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProfits)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.LblWait.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnViewExpenses
            // 
            this.BtnViewExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnViewExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewExpenses.Location = new System.Drawing.Point(358, 20);
            this.BtnViewExpenses.Name = "BtnViewExpenses";
            this.BtnViewExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnViewExpenses.TabIndex = 15;
            this.BtnViewExpenses.Text = "Visualizar";
            this.BtnViewExpenses.UseVisualStyleBackColor = false;
            this.BtnViewExpenses.Click += new System.EventHandler(this.BtnViewExpenses_Click);
            // 
            // BtnEditExpenses
            // 
            this.BtnEditExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEditExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditExpenses.Location = new System.Drawing.Point(243, 20);
            this.BtnEditExpenses.Name = "BtnEditExpenses";
            this.BtnEditExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnEditExpenses.TabIndex = 14;
            this.BtnEditExpenses.Text = "Editar Despesa";
            this.BtnEditExpenses.UseVisualStyleBackColor = false;
            this.BtnEditExpenses.Click += new System.EventHandler(this.BtnEditExpenses_Click);
            // 
            // BtnDelExpenses
            // 
            this.BtnDelExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDelExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelExpenses.Location = new System.Drawing.Point(128, 20);
            this.BtnDelExpenses.Name = "BtnDelExpenses";
            this.BtnDelExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnDelExpenses.TabIndex = 13;
            this.BtnDelExpenses.Text = "Remover Despesa";
            this.BtnDelExpenses.UseVisualStyleBackColor = false;
            this.BtnDelExpenses.Click += new System.EventHandler(this.BtnDelExpenses_Click);
            // 
            // DgvExpenses
            // 
            this.DgvExpenses.AllowUserToAddRows = false;
            this.DgvExpenses.AllowUserToDeleteRows = false;
            this.DgvExpenses.AllowUserToOrderColumns = true;
            this.DgvExpenses.AllowUserToResizeColumns = false;
            this.DgvExpenses.AllowUserToResizeRows = false;
            this.DgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvExpenses.Location = new System.Drawing.Point(13, 62);
            this.DgvExpenses.MultiSelect = false;
            this.DgvExpenses.Name = "DgvExpenses";
            this.DgvExpenses.ReadOnly = true;
            this.DgvExpenses.Size = new System.Drawing.Size(868, 358);
            this.DgvExpenses.TabIndex = 11;
            // 
            // BtnViewProfits
            // 
            this.BtnViewProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnViewProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewProfits.Location = new System.Drawing.Point(358, 20);
            this.BtnViewProfits.Name = "BtnViewProfits";
            this.BtnViewProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnViewProfits.TabIndex = 10;
            this.BtnViewProfits.Text = "Visualizar";
            this.BtnViewProfits.UseVisualStyleBackColor = false;
            this.BtnViewProfits.Click += new System.EventHandler(this.BtnViewProfits_Click);
            // 
            // BtnEditProfits
            // 
            this.BtnEditProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEditProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditProfits.Location = new System.Drawing.Point(243, 20);
            this.BtnEditProfits.Name = "BtnEditProfits";
            this.BtnEditProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnEditProfits.TabIndex = 9;
            this.BtnEditProfits.Text = "Editar Receita";
            this.BtnEditProfits.UseVisualStyleBackColor = false;
            this.BtnEditProfits.Click += new System.EventHandler(this.BtnEditProfits_Click);
            // 
            // BtnDelProfits
            // 
            this.BtnDelProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDelProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelProfits.Location = new System.Drawing.Point(128, 20);
            this.BtnDelProfits.Name = "BtnDelProfits";
            this.BtnDelProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnDelProfits.TabIndex = 8;
            this.BtnDelProfits.Text = "Remover Receita";
            this.BtnDelProfits.UseVisualStyleBackColor = false;
            this.BtnDelProfits.Click += new System.EventHandler(this.BtnDelProfits_Click);
            // 
            // BtnAddProfits
            // 
            this.BtnAddProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAddProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddProfits.Location = new System.Drawing.Point(13, 20);
            this.BtnAddProfits.Name = "BtnAddProfits";
            this.BtnAddProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnAddProfits.TabIndex = 7;
            this.BtnAddProfits.Text = "Adicionar Receita";
            this.BtnAddProfits.UseVisualStyleBackColor = false;
            this.BtnAddProfits.Click += new System.EventHandler(this.BtnAddProfits_Click);
            // 
            // BtnAddExpenses
            // 
            this.BtnAddExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAddExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddExpenses.Location = new System.Drawing.Point(13, 20);
            this.BtnAddExpenses.Name = "BtnAddExpenses";
            this.BtnAddExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnAddExpenses.TabIndex = 12;
            this.BtnAddExpenses.Text = "Adicionar Despesa";
            this.BtnAddExpenses.UseVisualStyleBackColor = false;
            this.BtnAddExpenses.Click += new System.EventHandler(this.BtnAddExpenses_Click);
            // 
            // DgvProfits
            // 
            this.DgvProfits.AllowUserToAddRows = false;
            this.DgvProfits.AllowUserToDeleteRows = false;
            this.DgvProfits.AllowUserToOrderColumns = true;
            this.DgvProfits.AllowUserToResizeColumns = false;
            this.DgvProfits.AllowUserToResizeRows = false;
            this.DgvProfits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProfits.Location = new System.Drawing.Point(13, 62);
            this.DgvProfits.MultiSelect = false;
            this.DgvProfits.Name = "DgvProfits";
            this.DgvProfits.ReadOnly = true;
            this.DgvProfits.Size = new System.Drawing.Size(868, 358);
            this.DgvProfits.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblExepencesMonth);
            this.panel1.Controls.Add(this.LblExpenses);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(296, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 72);
            this.panel1.TabIndex = 10;
            // 
            // LblExepencesMonth
            // 
            this.LblExepencesMonth.AutoSize = true;
            this.LblExepencesMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExepencesMonth.ForeColor = System.Drawing.Color.White;
            this.LblExepencesMonth.Location = new System.Drawing.Point(158, 4);
            this.LblExepencesMonth.Name = "LblExepencesMonth";
            this.LblExepencesMonth.Size = new System.Drawing.Size(61, 20);
            this.LblExepencesMonth.TabIndex = 4;
            this.LblExepencesMonth.Text = "Janeiro";
            // 
            // LblExpenses
            // 
            this.LblExpenses.AutoSize = true;
            this.LblExpenses.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExpenses.ForeColor = System.Drawing.Color.White;
            this.LblExpenses.Location = new System.Drawing.Point(134, 41);
            this.LblExpenses.Name = "LblExpenses";
            this.LblExpenses.Size = new System.Drawing.Size(103, 24);
            this.LblExpenses.TabIndex = 3;
            this.LblExpenses.Text = "R$ 0000,00";
            this.LblExpenses.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Despesas do mês de";
            // 
            // LblProfits
            // 
            this.LblProfits.AutoSize = true;
            this.LblProfits.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblProfits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProfits.Location = new System.Drawing.Point(134, 41);
            this.LblProfits.Name = "LblProfits";
            this.LblProfits.Size = new System.Drawing.Size(103, 24);
            this.LblProfits.TabIndex = 3;
            this.LblProfits.Text = "R$ 0000,00";
            this.LblProfits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Receitas do mês de";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Lime;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.LblProftsMonth);
            this.panel5.Controls.Add(this.LblProfits);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(19, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(241, 72);
            this.panel5.TabIndex = 9;
            // 
            // LblProftsMonth
            // 
            this.LblProftsMonth.AutoSize = true;
            this.LblProftsMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProftsMonth.Location = new System.Drawing.Point(150, 4);
            this.LblProftsMonth.Name = "LblProftsMonth";
            this.LblProftsMonth.Size = new System.Drawing.Size(61, 20);
            this.LblProftsMonth.TabIndex = 4;
            this.LblProftsMonth.Text = "Janeiro";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LblWait);
            this.tabPage1.Controls.Add(this.BtnViewProfits);
            this.tabPage1.Controls.Add(this.BtnEditProfits);
            this.tabPage1.Controls.Add(this.BtnDelProfits);
            this.tabPage1.Controls.Add(this.BtnAddProfits);
            this.tabPage1.Controls.Add(this.DgvProfits);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(894, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recetias";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LblWait
            // 
            this.LblWait.Controls.Add(this.label3);
            this.LblWait.Location = new System.Drawing.Point(347, 209);
            this.LblWait.Name = "LblWait";
            this.LblWait.Size = new System.Drawing.Size(205, 52);
            this.LblWait.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Wait...";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnViewExpenses);
            this.tabPage2.Controls.Add(this.BtnEditExpenses);
            this.tabPage2.Controls.Add(this.BtnDelExpenses);
            this.tabPage2.Controls.Add(this.BtnAddExpenses);
            this.tabPage2.Controls.Add(this.DgvExpenses);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Despesas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Enabled = false;
            this.TabControl.Location = new System.Drawing.Point(12, 93);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(902, 467);
            this.TabControl.TabIndex = 8;
            // 
            // BtnChangeMonth
            // 
            this.BtnChangeMonth.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnChangeMonth.Enabled = false;
            this.BtnChangeMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangeMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChangeMonth.Location = new System.Drawing.Point(140, 23);
            this.BtnChangeMonth.Name = "BtnChangeMonth";
            this.BtnChangeMonth.Size = new System.Drawing.Size(100, 27);
            this.BtnChangeMonth.TabIndex = 11;
            this.BtnChangeMonth.Text = "Mudar Mês";
            this.BtnChangeMonth.UseVisualStyleBackColor = false;
            this.BtnChangeMonth.Click += new System.EventHandler(this.BtnChangeMonth_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Referente ao Mês:";
            // 
            // LblMonth
            // 
            this.LblMonth.AutoSize = true;
            this.LblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMonth.Location = new System.Drawing.Point(21, 27);
            this.LblMonth.Name = "LblMonth";
            this.LblMonth.Size = new System.Drawing.Size(75, 24);
            this.LblMonth.TabIndex = 13;
            this.LblMonth.Text = "01/2000";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LblMonth);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BtnChangeMonth);
            this.panel2.Location = new System.Drawing.Point(573, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 72);
            this.panel2.TabIndex = 14;
            // 
            // FrmMonthlyExpensesAndProfits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 572);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "FrmMonthlyExpensesAndProfits";
            this.Text = "FrmMonthlyExpensesAndProfits";
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProfits)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.LblWait.ResumeLayout(false);
            this.LblWait.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnViewExpenses;
        private System.Windows.Forms.Button BtnEditExpenses;
        private System.Windows.Forms.Button BtnDelExpenses;
        private System.Windows.Forms.DataGridView DgvExpenses;
        private System.Windows.Forms.Button BtnViewProfits;
        private System.Windows.Forms.Button BtnEditProfits;
        private System.Windows.Forms.Button BtnDelProfits;
        private System.Windows.Forms.Button BtnAddProfits;
        private System.Windows.Forms.Button BtnAddExpenses;
        private System.Windows.Forms.DataGridView DgvProfits;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblExepencesMonth;
        private System.Windows.Forms.Label LblExpenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblProfits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LblProftsMonth;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.Button BtnChangeMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblMonth;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel LblWait;
        private System.Windows.Forms.Label label3;
    }
}