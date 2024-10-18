namespace SysExpenseControl
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnDetailedExpenses = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnAccountsPayable = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnHome = new System.Windows.Forms.Button();
            this.PanelBody = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 15);
            this.panel1.Size = new System.Drawing.Size(242, 611);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnDetailedExpenses);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel2.Size = new System.Drawing.Size(242, 37);
            this.panel2.TabIndex = 21;
            // 
            // BtnDetailedExpenses
            // 
            this.BtnDetailedExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDetailedExpenses.FlatAppearance.BorderSize = 2;
            this.BtnDetailedExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDetailedExpenses.Location = new System.Drawing.Point(10, 5);
            this.BtnDetailedExpenses.Name = "BtnDetailedExpenses";
            this.BtnDetailedExpenses.Size = new System.Drawing.Size(222, 27);
            this.BtnDetailedExpenses.TabIndex = 0;
            this.BtnDetailedExpenses.Text = "Despesas detalhadas";
            this.BtnDetailedExpenses.UseVisualStyleBackColor = true;
            this.BtnDetailedExpenses.Click += new System.EventHandler(this.BtnDetailedExpenses_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnAccountsPayable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(242, 37);
            this.panel3.TabIndex = 20;
            // 
            // BtnAccountsPayable
            // 
            this.BtnAccountsPayable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAccountsPayable.FlatAppearance.BorderSize = 2;
            this.BtnAccountsPayable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAccountsPayable.Location = new System.Drawing.Point(10, 5);
            this.BtnAccountsPayable.Name = "BtnAccountsPayable";
            this.BtnAccountsPayable.Size = new System.Drawing.Size(222, 27);
            this.BtnAccountsPayable.TabIndex = 0;
            this.BtnAccountsPayable.Text = "Contas a pagar";
            this.BtnAccountsPayable.UseVisualStyleBackColor = true;
            this.BtnAccountsPayable.Click += new System.EventHandler(this.BtnAccountsPayable_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.BtnSettings);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 559);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel8.Size = new System.Drawing.Size(242, 37);
            this.panel8.TabIndex = 19;
            // 
            // BtnSettings
            // 
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSettings.FlatAppearance.BorderSize = 2;
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Location = new System.Drawing.Point(10, 5);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(222, 27);
            this.BtnSettings.TabIndex = 1;
            this.BtnSettings.Text = "Configurações";
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BtnHome);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel4.Size = new System.Drawing.Size(242, 37);
            this.panel4.TabIndex = 18;
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.BtnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnHome.FlatAppearance.BorderSize = 2;
            this.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnHome.Location = new System.Drawing.Point(10, 5);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(222, 27);
            this.BtnHome.TabIndex = 0;
            this.BtnHome.Text = "Inicio";
            this.BtnHome.UseVisualStyleBackColor = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // PanelBody
            // 
            this.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBody.Location = new System.Drawing.Point(242, 0);
            this.PanelBody.Name = "PanelBody";
            this.PanelBody.Size = new System.Drawing.Size(942, 611);
            this.PanelBody.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.PanelBody);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "SysExpenseControl";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelBody;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnHome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnAccountsPayable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnDetailedExpenses;
    }
}

