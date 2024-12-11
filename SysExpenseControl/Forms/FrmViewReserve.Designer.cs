namespace SysExpenseControl.Forms
{
    partial class FrmViewReserve
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
            this.BtnView = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblValue = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.Btn = new System.Windows.Forms.Button();
            this.BtnBackToFirst = new System.Windows.Forms.Button();
            this.BtnBackOne = new System.Windows.Forms.Button();
            this.BtnForwardOne = new System.Windows.Forms.Button();
            this.BtnForwardToLast = new System.Windows.Forms.Button();
            this.Btn01 = new System.Windows.Forms.Button();
            this.PnButtons = new System.Windows.Forms.Panel();
            this.Btn05 = new System.Windows.Forms.Button();
            this.Btn04 = new System.Windows.Forms.Button();
            this.Btn03 = new System.Windows.Forms.Button();
            this.Btn02 = new System.Windows.Forms.Button();
            this.LblWait = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.PnButtons.SuspendLayout();
            this.LblWait.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnView
            // 
            this.BtnView.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnView.Enabled = false;
            this.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnView.Location = new System.Drawing.Point(361, 96);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(109, 23);
            this.BtnView.TabIndex = 21;
            this.BtnView.Text = "Visualizar";
            this.BtnView.UseVisualStyleBackColor = false;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEdit.Enabled = false;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Location = new System.Drawing.Point(246, 96);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(109, 23);
            this.BtnEdit.TabIndex = 20;
            this.BtnEdit.Text = "Editar";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Cyan;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.LblValue);
            this.panel5.Controls.Add(this.LblName);
            this.panel5.Location = new System.Drawing.Point(19, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(241, 72);
            this.panel5.TabIndex = 17;
            // 
            // LblValue
            // 
            this.LblValue.AutoSize = true;
            this.LblValue.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValue.Location = new System.Drawing.Point(146, 41);
            this.LblValue.Name = "LblValue";
            this.LblValue.Size = new System.Drawing.Size(88, 24);
            this.LblValue.TabIndex = 3;
            this.LblValue.Text = "R$: 00,00";
            this.LblValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(4, 4);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(126, 20);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "Total da reserva:";
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Location = new System.Drawing.Point(131, 96);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(109, 23);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "Remover";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAdd.Enabled = false;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Location = new System.Drawing.Point(16, 96);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(109, 23);
            this.BtnAdd.TabIndex = 18;
            this.BtnAdd.Text = "Adicionar";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.AllowUserToDeleteRows = false;
            this.DgvData.AllowUserToOrderColumns = true;
            this.DgvData.AllowUserToResizeColumns = false;
            this.DgvData.AllowUserToResizeRows = false;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Location = new System.Drawing.Point(12, 130);
            this.DgvData.MultiSelect = false;
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.Size = new System.Drawing.Size(910, 400);
            this.DgvData.TabIndex = 16;
            // 
            // Btn
            // 
            this.Btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn.Location = new System.Drawing.Point(813, 96);
            this.Btn.Name = "Btn";
            this.Btn.Size = new System.Drawing.Size(109, 23);
            this.Btn.TabIndex = 22;
            this.Btn.Text = "< Voltar";
            this.Btn.UseVisualStyleBackColor = false;
            this.Btn.Click += new System.EventHandler(this.Btn_Click);
            // 
            // BtnBackToFirst
            // 
            this.BtnBackToFirst.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBackToFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBackToFirst.Location = new System.Drawing.Point(28, 3);
            this.BtnBackToFirst.Name = "BtnBackToFirst";
            this.BtnBackToFirst.Size = new System.Drawing.Size(30, 23);
            this.BtnBackToFirst.TabIndex = 23;
            this.BtnBackToFirst.Text = "<<";
            this.BtnBackToFirst.UseVisualStyleBackColor = false;
            this.BtnBackToFirst.Click += new System.EventHandler(this.BtnBackToFirst_Click);
            // 
            // BtnBackOne
            // 
            this.BtnBackOne.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBackOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBackOne.Location = new System.Drawing.Point(64, 3);
            this.BtnBackOne.Name = "BtnBackOne";
            this.BtnBackOne.Size = new System.Drawing.Size(30, 23);
            this.BtnBackOne.TabIndex = 24;
            this.BtnBackOne.Text = "<";
            this.BtnBackOne.UseVisualStyleBackColor = false;
            this.BtnBackOne.Click += new System.EventHandler(this.BtnBackOne_Click);
            // 
            // BtnForwardOne
            // 
            this.BtnForwardOne.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnForwardOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForwardOne.Location = new System.Drawing.Point(298, 3);
            this.BtnForwardOne.Name = "BtnForwardOne";
            this.BtnForwardOne.Size = new System.Drawing.Size(30, 23);
            this.BtnForwardOne.TabIndex = 25;
            this.BtnForwardOne.Text = ">";
            this.BtnForwardOne.UseVisualStyleBackColor = false;
            this.BtnForwardOne.Click += new System.EventHandler(this.BtnForwardOne_Click);
            // 
            // BtnForwardToLast
            // 
            this.BtnForwardToLast.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnForwardToLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForwardToLast.Location = new System.Drawing.Point(334, 3);
            this.BtnForwardToLast.Name = "BtnForwardToLast";
            this.BtnForwardToLast.Size = new System.Drawing.Size(30, 23);
            this.BtnForwardToLast.TabIndex = 26;
            this.BtnForwardToLast.Text = ">>";
            this.BtnForwardToLast.UseVisualStyleBackColor = false;
            this.BtnForwardToLast.Click += new System.EventHandler(this.BtnForwardToLast_Click);
            // 
            // Btn01
            // 
            this.Btn01.BackColor = System.Drawing.Color.Gray;
            this.Btn01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn01.Location = new System.Drawing.Point(109, 3);
            this.Btn01.Name = "Btn01";
            this.Btn01.Size = new System.Drawing.Size(30, 23);
            this.Btn01.TabIndex = 27;
            this.Btn01.Text = "1";
            this.Btn01.UseVisualStyleBackColor = false;
            this.Btn01.Click += new System.EventHandler(this.Btn01_Click);
            // 
            // PnButtons
            // 
            this.PnButtons.Controls.Add(this.Btn01);
            this.PnButtons.Controls.Add(this.Btn05);
            this.PnButtons.Controls.Add(this.BtnBackToFirst);
            this.PnButtons.Controls.Add(this.Btn04);
            this.PnButtons.Controls.Add(this.BtnForwardToLast);
            this.PnButtons.Controls.Add(this.Btn03);
            this.PnButtons.Controls.Add(this.BtnBackOne);
            this.PnButtons.Controls.Add(this.Btn02);
            this.PnButtons.Controls.Add(this.BtnForwardOne);
            this.PnButtons.Enabled = false;
            this.PnButtons.Location = new System.Drawing.Point(268, 546);
            this.PnButtons.Name = "PnButtons";
            this.PnButtons.Size = new System.Drawing.Size(409, 31);
            this.PnButtons.TabIndex = 28;
            // 
            // Btn05
            // 
            this.Btn05.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn05.Location = new System.Drawing.Point(253, 3);
            this.Btn05.Name = "Btn05";
            this.Btn05.Size = new System.Drawing.Size(30, 23);
            this.Btn05.TabIndex = 31;
            this.Btn05.Text = "5";
            this.Btn05.UseVisualStyleBackColor = false;
            this.Btn05.Click += new System.EventHandler(this.Btn05_Click);
            // 
            // Btn04
            // 
            this.Btn04.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn04.Location = new System.Drawing.Point(217, 3);
            this.Btn04.Name = "Btn04";
            this.Btn04.Size = new System.Drawing.Size(30, 23);
            this.Btn04.TabIndex = 30;
            this.Btn04.Text = "4";
            this.Btn04.UseVisualStyleBackColor = false;
            this.Btn04.Click += new System.EventHandler(this.Btn04_Click);
            // 
            // Btn03
            // 
            this.Btn03.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn03.Location = new System.Drawing.Point(181, 3);
            this.Btn03.Name = "Btn03";
            this.Btn03.Size = new System.Drawing.Size(30, 23);
            this.Btn03.TabIndex = 29;
            this.Btn03.Text = "3";
            this.Btn03.UseVisualStyleBackColor = false;
            this.Btn03.Click += new System.EventHandler(this.Btn03_Click);
            // 
            // Btn02
            // 
            this.Btn02.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn02.Location = new System.Drawing.Point(145, 3);
            this.Btn02.Name = "Btn02";
            this.Btn02.Size = new System.Drawing.Size(30, 23);
            this.Btn02.TabIndex = 28;
            this.Btn02.Text = "2";
            this.Btn02.UseVisualStyleBackColor = false;
            this.Btn02.Click += new System.EventHandler(this.Btn02_Click);
            // 
            // LblWait
            // 
            this.LblWait.Controls.Add(this.label4);
            this.LblWait.Location = new System.Drawing.Point(361, 278);
            this.LblWait.Name = "LblWait";
            this.LblWait.Size = new System.Drawing.Size(205, 52);
            this.LblWait.TabIndex = 32;
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
            // FrmViewReserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 572);
            this.Controls.Add(this.LblWait);
            this.Controls.Add(this.PnButtons);
            this.Controls.Add(this.Btn);
            this.Controls.Add(this.BtnView);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.DgvData);
            this.Name = "FrmViewReserve";
            this.Text = "FrmViewReserve";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.PnButtons.ResumeLayout(false);
            this.LblWait.ResumeLayout(false);
            this.LblWait.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnView;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LblValue;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.Button Btn;
        private System.Windows.Forms.Button BtnBackToFirst;
        private System.Windows.Forms.Button BtnBackOne;
        private System.Windows.Forms.Button BtnForwardOne;
        private System.Windows.Forms.Button BtnForwardToLast;
        private System.Windows.Forms.Button Btn01;
        private System.Windows.Forms.Panel PnButtons;
        private System.Windows.Forms.Button Btn02;
        private System.Windows.Forms.Button Btn03;
        private System.Windows.Forms.Button Btn05;
        private System.Windows.Forms.Button Btn04;
        private System.Windows.Forms.Panel LblWait;
        private System.Windows.Forms.Label label4;
    }
}