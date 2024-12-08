namespace SysExpenseControl.Forms
{
    partial class FrmHome
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.DgvSpent = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CbxCategories = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DgvReserves = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ChartSpent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ChartComparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.LblMonth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnChangeMonth = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DgvData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSpent)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReserves)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSpent)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartComparison)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvSpent
            // 
            this.DgvSpent.AllowUserToAddRows = false;
            this.DgvSpent.AllowUserToDeleteRows = false;
            this.DgvSpent.AllowUserToOrderColumns = true;
            this.DgvSpent.AllowUserToResizeColumns = false;
            this.DgvSpent.AllowUserToResizeRows = false;
            this.DgvSpent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSpent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSpent.Location = new System.Drawing.Point(3, 3);
            this.DgvSpent.MultiSelect = false;
            this.DgvSpent.Name = "DgvSpent";
            this.DgvSpent.ReadOnly = true;
            this.DgvSpent.Size = new System.Drawing.Size(437, 427);
            this.DgvSpent.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CbxCategories);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 38);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categoria:";
            // 
            // CbxCategories
            // 
            this.CbxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxCategories.FormattingEnabled = true;
            this.CbxCategories.Location = new System.Drawing.Point(60, 8);
            this.CbxCategories.Name = "CbxCategories";
            this.CbxCategories.Size = new System.Drawing.Size(121, 21);
            this.CbxCategories.TabIndex = 0;
            this.CbxCategories.SelectedIndexChanged += new System.EventHandler(this.CbxCategories_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Controls.Add(this.DgvReserves);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(461, 266);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reservas";
            // 
            // DgvReserves
            // 
            this.DgvReserves.AllowUserToAddRows = false;
            this.DgvReserves.AllowUserToDeleteRows = false;
            this.DgvReserves.AllowUserToOrderColumns = true;
            this.DgvReserves.AllowUserToResizeColumns = false;
            this.DgvReserves.AllowUserToResizeRows = false;
            this.DgvReserves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReserves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvReserves.Location = new System.Drawing.Point(10, 23);
            this.DgvReserves.MultiSelect = false;
            this.DgvReserves.Name = "DgvReserves";
            this.DgvReserves.ReadOnly = true;
            this.DgvReserves.Size = new System.Drawing.Size(441, 233);
            this.DgvReserves.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 273);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ChartSpent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(439, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gastos do mês";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ChartSpent
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartSpent.ChartAreas.Add(chartArea1);
            this.ChartSpent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartSpent.Location = new System.Drawing.Point(10, 10);
            this.ChartSpent.Name = "ChartSpent";
            this.ChartSpent.Size = new System.Drawing.Size(419, 227);
            this.ChartSpent.TabIndex = 1;
            this.ChartSpent.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(422, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comparação";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ChartComparison);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(416, 210);
            this.panel5.TabIndex = 9;
            // 
            // ChartComparison
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartComparison.ChartAreas.Add(chartArea2);
            this.ChartComparison.Location = new System.Drawing.Point(-3, 0);
            this.ChartComparison.Name = "ChartComparison";
            this.ChartComparison.Size = new System.Drawing.Size(422, 204);
            this.ChartComparison.TabIndex = 6;
            this.ChartComparison.Text = "chart2";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.comboBox2);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(416, 32);
            this.panel6.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Último mês",
            "Últimos 3 mêses",
            "Últimos 6 mêses",
            "Últimos 12 mêses"});
            this.comboBox2.Location = new System.Drawing.Point(55, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Período:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(459, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(467, 293);
            this.panel2.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.groupBox3);
            this.panel8.Location = new System.Drawing.Point(459, 299);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3);
            this.panel8.Size = new System.Drawing.Size(467, 272);
            this.panel8.TabIndex = 10;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(60, 3);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(10);
            this.panel9.Size = new System.Drawing.Size(326, 100);
            this.panel9.TabIndex = 11;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.LblMonth);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.BtnChangeMonth);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(10, 10);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(306, 80);
            this.panel10.TabIndex = 15;
            // 
            // LblMonth
            // 
            this.LblMonth.AutoSize = true;
            this.LblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMonth.Location = new System.Drawing.Point(39, 36);
            this.LblMonth.Name = "LblMonth";
            this.LblMonth.Size = new System.Drawing.Size(75, 24);
            this.LblMonth.TabIndex = 13;
            this.LblMonth.Text = "01/2000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Referente ao Mês:";
            // 
            // BtnChangeMonth
            // 
            this.BtnChangeMonth.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnChangeMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangeMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChangeMonth.Location = new System.Drawing.Point(181, 28);
            this.BtnChangeMonth.Name = "BtnChangeMonth";
            this.BtnChangeMonth.Size = new System.Drawing.Size(100, 27);
            this.BtnChangeMonth.TabIndex = 11;
            this.BtnChangeMonth.Text = "Mudar Mês";
            this.BtnChangeMonth.UseVisualStyleBackColor = false;
            this.BtnChangeMonth.Click += new System.EventHandler(this.BtnChangeMonth_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(2, 109);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(451, 459);
            this.tabControl2.TabIndex = 12;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DgvSpent);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(443, 433);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Resumo dos Gastos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(443, 433);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Gastos por categoria";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DgvData);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(443, 395);
            this.panel4.TabIndex = 7;
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
            this.DgvData.Location = new System.Drawing.Point(0, 0);
            this.DgvData.MultiSelect = false;
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.Size = new System.Drawing.Size(443, 395);
            this.DgvData.TabIndex = 4;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 572);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel8);
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            ((System.ComponentModel.ISupportInitialize)(this.DgvSpent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReserves)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartSpent)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartComparison)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DgvSpent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbxCategories;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DgvReserves;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartSpent;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartComparison;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label LblMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnChangeMonth;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView DgvData;
    }
}