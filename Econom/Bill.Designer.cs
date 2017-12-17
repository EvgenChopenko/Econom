namespace Econom
{
    partial class Bill
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
            this.DataGridBill = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AddSchet = new System.Windows.Forms.ToolStripMenuItem();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BILLSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUMDOHCHETLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPESCHETADOHLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUHCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBill)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridBill
            // 
            this.DataGridBill.AllowUserToAddRows = false;
            this.DataGridBill.AllowUserToDeleteRows = false;
            this.DataGridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.BILLSID,
            this.COMPANYNAME,
            this.SUMDOHCHETLO,
            this.SCHET,
            this.TYPESCHETADOHLO,
            this.BUHCODE});
            this.DataGridBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridBill.Location = new System.Drawing.Point(0, 24);
            this.DataGridBill.Name = "DataGridBill";
            this.DataGridBill.Size = new System.Drawing.Size(545, 419);
            this.DataGridBill.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSchet});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AddSchet
            // 
            this.AddSchet.Name = "AddSchet";
            this.AddSchet.Size = new System.Drawing.Size(106, 20);
            this.AddSchet.Text = "Добавить Счета";
            this.AddSchet.Click += new System.EventHandler(this.AddSchet_Click);
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.HeaderText = "Добавить";
            this.Check.Name = "Check";
            this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BILLSID
            // 
            this.BILLSID.DataPropertyName = "BILLSID";
            this.BILLSID.HeaderText = "BILLSID";
            this.BILLSID.Name = "BILLSID";
            this.BILLSID.ReadOnly = true;
            // 
            // COMPANYNAME
            // 
            this.COMPANYNAME.DataPropertyName = "COMPANYNAME";
            this.COMPANYNAME.HeaderText = "Компания";
            this.COMPANYNAME.Name = "COMPANYNAME";
            this.COMPANYNAME.ReadOnly = true;
            // 
            // SUMDOHCHETLO
            // 
            this.SUMDOHCHETLO.DataPropertyName = "SUMDOHCHETLO";
            this.SUMDOHCHETLO.HeaderText = "Сумма";
            this.SUMDOHCHETLO.Name = "SUMDOHCHETLO";
            this.SUMDOHCHETLO.ReadOnly = true;
            // 
            // SCHET
            // 
            this.SCHET.DataPropertyName = "SCHET";
            this.SCHET.HeaderText = "Счет";
            this.SCHET.Name = "SCHET";
            this.SCHET.ReadOnly = true;
            // 
            // TYPESCHETADOHLO
            // 
            this.TYPESCHETADOHLO.DataPropertyName = "TYPESCHETADOHLO";
            this.TYPESCHETADOHLO.HeaderText = "ТипСчета";
            this.TYPESCHETADOHLO.Name = "TYPESCHETADOHLO";
            this.TYPESCHETADOHLO.ReadOnly = true;
            // 
            // BUHCODE
            // 
            this.BUHCODE.DataPropertyName = "BUHCODE";
            this.BUHCODE.HeaderText = "Буг.Код";
            this.BUHCODE.Name = "BUHCODE";
            this.BUHCODE.ReadOnly = true;
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 443);
            this.Controls.Add(this.DataGridBill);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Bill";
            this.Text = "Bill";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bill_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBill)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridBill;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddSchet;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILLSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUMDOHCHETLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHET;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPESCHETADOHLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUHCODE;
    }
}