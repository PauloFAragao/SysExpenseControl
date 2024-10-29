namespace SysExpenseControl.Forms
{
    partial class FrmFixedExpensesAndProfits
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnViewFixedProfits = new System.Windows.Forms.Button();
            this.BtnEditFixedProfits = new System.Windows.Forms.Button();
            this.BtnDelFixedProfits = new System.Windows.Forms.Button();
            this.BtnAddFixedProfits = new System.Windows.Forms.Button();
            this.DgvFixedProfits = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnViewFixedExpenses = new System.Windows.Forms.Button();
            this.BtnEditFixedExpenses = new System.Windows.Forms.Button();
            this.BtnDelFixedExpenses = new System.Windows.Forms.Button();
            this.BtnAddFixedExpenses = new System.Windows.Forms.Button();
            this.DgvFixedExpenses = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblFixedProfits = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblFixedExpenses = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFixedProfits)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFixedExpenses)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 467);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnViewFixedProfits);
            this.tabPage1.Controls.Add(this.BtnEditFixedProfits);
            this.tabPage1.Controls.Add(this.BtnDelFixedProfits);
            this.tabPage1.Controls.Add(this.BtnAddFixedProfits);
            this.tabPage1.Controls.Add(this.DgvFixedProfits);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(894, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recetias Fixas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnViewFixedProfits
            // 
            this.BtnViewFixedProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnViewFixedProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewFixedProfits.Location = new System.Drawing.Point(358, 20);
            this.BtnViewFixedProfits.Name = "BtnViewFixedProfits";
            this.BtnViewFixedProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnViewFixedProfits.TabIndex = 10;
            this.BtnViewFixedProfits.Text = "Visualizar";
            this.BtnViewFixedProfits.UseVisualStyleBackColor = false;
            this.BtnViewFixedProfits.Click += new System.EventHandler(this.BtnViewFixedProfits_Click);
            // 
            // BtnEditFixedProfits
            // 
            this.BtnEditFixedProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEditFixedProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditFixedProfits.Location = new System.Drawing.Point(243, 20);
            this.BtnEditFixedProfits.Name = "BtnEditFixedProfits";
            this.BtnEditFixedProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnEditFixedProfits.TabIndex = 9;
            this.BtnEditFixedProfits.Text = "Editar Receita";
            this.BtnEditFixedProfits.UseVisualStyleBackColor = false;
            this.BtnEditFixedProfits.Click += new System.EventHandler(this.BtnEditFixedProfits_Click);
            // 
            // BtnDelFixedProfits
            // 
            this.BtnDelFixedProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDelFixedProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelFixedProfits.Location = new System.Drawing.Point(128, 20);
            this.BtnDelFixedProfits.Name = "BtnDelFixedProfits";
            this.BtnDelFixedProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnDelFixedProfits.TabIndex = 8;
            this.BtnDelFixedProfits.Text = "Remover Receita";
            this.BtnDelFixedProfits.UseVisualStyleBackColor = false;
            this.BtnDelFixedProfits.Click += new System.EventHandler(this.BtnDelFixedProfits_Click);
            // 
            // BtnAddFixedProfits
            // 
            this.BtnAddFixedProfits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAddFixedProfits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddFixedProfits.Location = new System.Drawing.Point(13, 20);
            this.BtnAddFixedProfits.Name = "BtnAddFixedProfits";
            this.BtnAddFixedProfits.Size = new System.Drawing.Size(109, 23);
            this.BtnAddFixedProfits.TabIndex = 7;
            this.BtnAddFixedProfits.Text = "Adicionar Receita";
            this.BtnAddFixedProfits.UseVisualStyleBackColor = false;
            this.BtnAddFixedProfits.Click += new System.EventHandler(this.BtnAddFixedProfits_Click);
            // 
            // DgvFixedProfits
            // 
            this.DgvFixedProfits.AllowUserToAddRows = false;
            this.DgvFixedProfits.AllowUserToDeleteRows = false;
            this.DgvFixedProfits.AllowUserToOrderColumns = true;
            this.DgvFixedProfits.AllowUserToResizeColumns = false;
            this.DgvFixedProfits.AllowUserToResizeRows = false;
            this.DgvFixedProfits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFixedProfits.Location = new System.Drawing.Point(13, 62);
            this.DgvFixedProfits.MultiSelect = false;
            this.DgvFixedProfits.Name = "DgvFixedProfits";
            this.DgvFixedProfits.ReadOnly = true;
            this.DgvFixedProfits.Size = new System.Drawing.Size(868, 358);
            this.DgvFixedProfits.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnViewFixedExpenses);
            this.tabPage2.Controls.Add(this.BtnEditFixedExpenses);
            this.tabPage2.Controls.Add(this.BtnDelFixedExpenses);
            this.tabPage2.Controls.Add(this.BtnAddFixedExpenses);
            this.tabPage2.Controls.Add(this.DgvFixedExpenses);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Despesas Fixas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnViewFixedExpenses
            // 
            this.BtnViewFixedExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnViewFixedExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewFixedExpenses.Location = new System.Drawing.Point(358, 20);
            this.BtnViewFixedExpenses.Name = "BtnViewFixedExpenses";
            this.BtnViewFixedExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnViewFixedExpenses.TabIndex = 15;
            this.BtnViewFixedExpenses.Text = "Visualizar";
            this.BtnViewFixedExpenses.UseVisualStyleBackColor = false;
            // 
            // BtnEditFixedExpenses
            // 
            this.BtnEditFixedExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEditFixedExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditFixedExpenses.Location = new System.Drawing.Point(243, 20);
            this.BtnEditFixedExpenses.Name = "BtnEditFixedExpenses";
            this.BtnEditFixedExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnEditFixedExpenses.TabIndex = 14;
            this.BtnEditFixedExpenses.Text = "Editar Despesa";
            this.BtnEditFixedExpenses.UseVisualStyleBackColor = false;
            // 
            // BtnDelFixedExpenses
            // 
            this.BtnDelFixedExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDelFixedExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelFixedExpenses.Location = new System.Drawing.Point(128, 20);
            this.BtnDelFixedExpenses.Name = "BtnDelFixedExpenses";
            this.BtnDelFixedExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnDelFixedExpenses.TabIndex = 13;
            this.BtnDelFixedExpenses.Text = "Remover Despesa";
            this.BtnDelFixedExpenses.UseVisualStyleBackColor = false;
            // 
            // BtnAddFixedExpenses
            // 
            this.BtnAddFixedExpenses.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAddFixedExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddFixedExpenses.Location = new System.Drawing.Point(13, 20);
            this.BtnAddFixedExpenses.Name = "BtnAddFixedExpenses";
            this.BtnAddFixedExpenses.Size = new System.Drawing.Size(109, 23);
            this.BtnAddFixedExpenses.TabIndex = 12;
            this.BtnAddFixedExpenses.Text = "Adicionar Despesa";
            this.BtnAddFixedExpenses.UseVisualStyleBackColor = false;
            // 
            // DgvFixedExpenses
            // 
            this.DgvFixedExpenses.AllowUserToAddRows = false;
            this.DgvFixedExpenses.AllowUserToDeleteRows = false;
            this.DgvFixedExpenses.AllowUserToOrderColumns = true;
            this.DgvFixedExpenses.AllowUserToResizeColumns = false;
            this.DgvFixedExpenses.AllowUserToResizeRows = false;
            this.DgvFixedExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFixedExpenses.Location = new System.Drawing.Point(13, 62);
            this.DgvFixedExpenses.MultiSelect = false;
            this.DgvFixedExpenses.Name = "DgvFixedExpenses";
            this.DgvFixedExpenses.ReadOnly = true;
            this.DgvFixedExpenses.Size = new System.Drawing.Size(868, 358);
            this.DgvFixedExpenses.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Lime;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.LblFixedProfits);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(19, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(241, 72);
            this.panel5.TabIndex = 6;
            // 
            // LblFixedProfits
            // 
            this.LblFixedProfits.AutoSize = true;
            this.LblFixedProfits.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFixedProfits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFixedProfits.Location = new System.Drawing.Point(134, 41);
            this.LblFixedProfits.Name = "LblFixedProfits";
            this.LblFixedProfits.Size = new System.Drawing.Size(103, 24);
            this.LblFixedProfits.TabIndex = 3;
            this.LblFixedProfits.Text = "R$ 0000,00";
            this.LblFixedProfits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Receitas Fixas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Despesas Fixas:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblFixedExpenses);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(296, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 72);
            this.panel1.TabIndex = 7;
            // 
            // LblFixedExpenses
            // 
            this.LblFixedExpenses.AutoSize = true;
            this.LblFixedExpenses.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFixedExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFixedExpenses.ForeColor = System.Drawing.Color.White;
            this.LblFixedExpenses.Location = new System.Drawing.Point(134, 41);
            this.LblFixedExpenses.Name = "LblFixedExpenses";
            this.LblFixedExpenses.Size = new System.Drawing.Size(103, 24);
            this.LblFixedExpenses.TabIndex = 3;
            this.LblFixedExpenses.Text = "R$ 0000,00";
            this.LblFixedExpenses.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmFixedExpensesAndProfits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmFixedExpensesAndProfits";
            this.Text = "FrmFixedExpensesAndProfits";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFixedProfits)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFixedExpenses)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LblFixedProfits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblFixedExpenses;
        private System.Windows.Forms.DataGridView DgvFixedProfits;
        private System.Windows.Forms.Button BtnViewFixedProfits;
        private System.Windows.Forms.Button BtnEditFixedProfits;
        private System.Windows.Forms.Button BtnDelFixedProfits;
        private System.Windows.Forms.Button BtnAddFixedProfits;
        private System.Windows.Forms.Button BtnViewFixedExpenses;
        private System.Windows.Forms.Button BtnEditFixedExpenses;
        private System.Windows.Forms.Button BtnDelFixedExpenses;
        private System.Windows.Forms.Button BtnAddFixedExpenses;
        private System.Windows.Forms.DataGridView DgvFixedExpenses;
    }
}