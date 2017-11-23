namespace Econom
{
    partial class BILLS
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ADD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUHCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGRID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datfull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ADD,
            this.DAT,
            this.code,
            this.BUHCODE,
            this.AMOUNT,
            this.AGRID,
            this.keyid,
            this.datfull});
            this.dataGridView1.Location = new System.Drawing.Point(7, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(389, 226);
            this.dataGridView1.TabIndex = 0;
            // 
            // ADD
            // 
            this.ADD.HeaderText = "ДОБАВИТЬ СЧЕТ";
            this.ADD.Name = "ADD";
            // 
            // DAT
            // 
            this.DAT.DataPropertyName = "DAT";
            this.DAT.HeaderText = "Дата Формирование счета ";
            this.DAT.Name = "DAT";
            // 
            // code
            // 
            this.code.DataPropertyName = "CODE";
            this.code.HeaderText = "Код";
            this.code.Name = "code";
            this.code.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BUHCODE
            // 
            this.BUHCODE.DataPropertyName = "TEXT";
            this.BUHCODE.HeaderText = "БУГалтерский КОД ";
            this.BUHCODE.Name = "BUHCODE";
            this.BUHCODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BUHCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            this.AMOUNT.HeaderText = "Сумма";
            this.AMOUNT.Name = "AMOUNT";
            this.AMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AGRID
            // 
            this.AGRID.DataPropertyName = "AGRID";
            this.AGRID.HeaderText = "AGRID";
            this.AGRID.Name = "AGRID";
            this.AGRID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AGRID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AGRID.Visible = false;
            // 
            // keyid
            // 
            this.keyid.DataPropertyName = "keyid";
            this.keyid.HeaderText = "keyid";
            this.keyid.Name = "keyid";
            this.keyid.ReadOnly = true;
            this.keyid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.keyid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.keyid.Visible = false;
            // 
            // datfull
            // 
            this.datfull.DataPropertyName = "datfull";
            this.datfull.HeaderText = "временой промежуток счета ";
            this.datfull.Name = "datfull";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 102);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(179, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "обновить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BILLS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BILLS";
            this.Text = "BILLS";
            this.Load += new System.EventHandler(this.BILLS_Load);
            this.SizeChanged += new System.EventHandler(this.BILLS_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ADD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUHCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGRID;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyid;
        private System.Windows.Forms.DataGridViewTextBoxColumn datfull;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}