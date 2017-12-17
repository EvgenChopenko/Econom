namespace Econom
{
    partial class ListDohodSchet
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DataGridListSpb = new System.Windows.Forms.DataGridView();
            this.DataGridListLo = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.LOADOBJECT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.AddSchet = new System.Windows.Forms.ToolStripMenuItem();
            this.SPBBILLSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILLSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridListSpb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridListLo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DataGridListLo);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGridListSpb);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(960, 430);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 0;
            // 
            // DataGridListSpb
            // 
            this.DataGridListSpb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridListSpb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SPBBILLSID});
            this.DataGridListSpb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridListSpb.Location = new System.Drawing.Point(0, 24);
            this.DataGridListSpb.Name = "DataGridListSpb";
            this.DataGridListSpb.Size = new System.Drawing.Size(475, 406);
            this.DataGridListSpb.TabIndex = 0;
            // 
            // DataGridListLo
            // 
            this.DataGridListLo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridListLo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BILLSID});
            this.DataGridListLo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridListLo.Location = new System.Drawing.Point(0, 24);
            this.DataGridListLo.Name = "DataGridListLo";
            this.DataGridListLo.Size = new System.Drawing.Size(481, 406);
            this.DataGridListLo.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LOADOBJECT});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LOADOBJECT
            // 
            this.LOADOBJECT.Name = "LOADOBJECT";
            this.LOADOBJECT.Size = new System.Drawing.Size(108, 20);
            this.LOADOBJECT.Text = "ВыгрузитьСчета";
            this.LOADOBJECT.Click += new System.EventHandler(this.LOADOBJECT_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSchet});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(475, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // AddSchet
            // 
            this.AddSchet.Name = "AddSchet";
            this.AddSchet.Size = new System.Drawing.Size(98, 20);
            this.AddSchet.Text = "Добавить счет";
            this.AddSchet.Click += new System.EventHandler(this.AddSchet_Click);
            // 
            // SPBBILLSID
            // 
            this.SPBBILLSID.DataPropertyName = "BILLSID";
            this.SPBBILLSID.HeaderText = "KEyid";
            this.SPBBILLSID.Name = "SPBBILLSID";
            this.SPBBILLSID.Visible = false;
            // 
            // BILLSID
            // 
            this.BILLSID.DataPropertyName = "BILLSID";
            this.BILLSID.HeaderText = "Keyid";
            this.BILLSID.Name = "BILLSID";
            this.BILLSID.Visible = false;
            // 
            // ListDohodSchet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 430);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ListDohodSchet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListDohodSchet";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridListSpb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridListLo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DataGridListLo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView DataGridListSpb;
        private System.Windows.Forms.ToolStripMenuItem LOADOBJECT;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem AddSchet;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILLSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPBBILLSID;
    }
}