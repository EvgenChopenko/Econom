namespace Econom
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выгрузкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доходыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.возвратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.планToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.планToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toExelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exeltoLOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sPBtoexelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sPBLOtoexelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabLO = new System.Windows.Forms.TabPage();
            this.datageidlo = new System.Windows.Forms.DataGridView();
            this.tabspbrf = new System.Windows.Forms.TabPage();
            this.datagridspbrf = new System.Windows.Forms.DataGridView();
            this.tabLOspbrf = new System.Windows.Forms.TabPage();
            this.datagridspbrflo = new System.Windows.Forms.DataGridView();
            this.Bills = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataSet1 = new Econom.DataSet1();
            this.lUTAG9BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lUTAG9TableAdapter = new Econom.DataSet1TableAdapters.LUTAG9TableAdapter();
            this.menuStrip1.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabLO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datageidlo)).BeginInit();
            this.tabspbrf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrf)).BeginInit();
            this.tabLOspbrf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrflo)).BeginInit();
            this.Bills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выгрузкиToolStripMenuItem,
            this.планToolStripMenuItem,
            this.сформироватьОтчетToolStripMenuItem,
            this.toExelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выгрузкиToolStripMenuItem
            // 
            this.выгрузкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.доходыToolStripMenuItem,
            this.возвратыToolStripMenuItem,
            this.отказыToolStripMenuItem});
            this.выгрузкиToolStripMenuItem.Name = "выгрузкиToolStripMenuItem";
            this.выгрузкиToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.выгрузкиToolStripMenuItem.Text = "Выгрузки";
            // 
            // доходыToolStripMenuItem
            // 
            this.доходыToolStripMenuItem.Name = "доходыToolStripMenuItem";
            this.доходыToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.доходыToolStripMenuItem.Text = "Доходы";
            this.доходыToolStripMenuItem.Click += new System.EventHandler(this.доходыToolStripMenuItem_Click);
            // 
            // возвратыToolStripMenuItem
            // 
            this.возвратыToolStripMenuItem.Name = "возвратыToolStripMenuItem";
            this.возвратыToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.возвратыToolStripMenuItem.Text = "Возвраты";
            this.возвратыToolStripMenuItem.Click += new System.EventHandler(this.возвратыToolStripMenuItem_Click);
            // 
            // отказыToolStripMenuItem
            // 
            this.отказыToolStripMenuItem.Name = "отказыToolStripMenuItem";
            this.отказыToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.отказыToolStripMenuItem.Text = "Отказы";
            this.отказыToolStripMenuItem.Click += new System.EventHandler(this.отказыToolStripMenuItem_Click);
            // 
            // планToolStripMenuItem
            // 
            this.планToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.планToolStripMenuItem1});
            this.планToolStripMenuItem.Name = "планToolStripMenuItem";
            this.планToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.планToolStripMenuItem.Text = "План";
            // 
            // планToolStripMenuItem1
            // 
            this.планToolStripMenuItem1.Name = "планToolStripMenuItem1";
            this.планToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.планToolStripMenuItem1.Text = "План";
            this.планToolStripMenuItem1.Click += new System.EventHandler(this.планToolStripMenuItem1_Click);
            // 
            // сформироватьОтчетToolStripMenuItem
            // 
            this.сформироватьОтчетToolStripMenuItem.Name = "сформироватьОтчетToolStripMenuItem";
            this.сформироватьОтчетToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.сформироватьОтчетToolStripMenuItem.Text = "Сформировать  отчет";
            this.сформироватьОтчетToolStripMenuItem.Click += new System.EventHandler(this.СформироватьОтчетToolStripMenuItem_Click);
            // 
            // toExelToolStripMenuItem
            // 
            this.toExelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exeltoLOToolStripMenuItem,
            this.sPBtoexelToolStripMenuItem,
            this.sPBLOtoexelToolStripMenuItem,
            this.таблицаToolStripMenuItem,
            this.выгрузитьВсёToolStripMenuItem});
            this.toExelToolStripMenuItem.Name = "toExelToolStripMenuItem";
            this.toExelToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.toExelToolStripMenuItem.Text = "to_Exel";
            this.toExelToolStripMenuItem.Click += new System.EventHandler(this.toExelToolStripMenuItem_Click);
            // 
            // exeltoLOToolStripMenuItem
            // 
            this.exeltoLOToolStripMenuItem.Name = "exeltoLOToolStripMenuItem";
            this.exeltoLOToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exeltoLOToolStripMenuItem.Text = "LO_to_exel";
            this.exeltoLOToolStripMenuItem.Click += new System.EventHandler(this.exeltoLOToolStripMenuItem_Click);
            // 
            // sPBtoexelToolStripMenuItem
            // 
            this.sPBtoexelToolStripMenuItem.Name = "sPBtoexelToolStripMenuItem";
            this.sPBtoexelToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.sPBtoexelToolStripMenuItem.Text = "SPB_to_exel";
            // 
            // sPBLOtoexelToolStripMenuItem
            // 
            this.sPBLOtoexelToolStripMenuItem.Name = "sPBLOtoexelToolStripMenuItem";
            this.sPBLOtoexelToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.sPBLOtoexelToolStripMenuItem.Text = "SPB+LO_to_exel";
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.таблицаToolStripMenuItem.Text = "Таблица";
            // 
            // выгрузитьВсёToolStripMenuItem
            // 
            this.выгрузитьВсёToolStripMenuItem.Name = "выгрузитьВсёToolStripMenuItem";
            this.выгрузитьВсёToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.выгрузитьВсёToolStripMenuItem.Text = "Выгрузить всё";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabLO);
            this.tab.Controls.Add(this.tabspbrf);
            this.tab.Controls.Add(this.tabLOspbrf);
            this.tab.Controls.Add(this.Bills);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 24);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(875, 389);
            this.tab.TabIndex = 2;
            // 
            // tabLO
            // 
            this.tabLO.Controls.Add(this.datageidlo);
            this.tabLO.Location = new System.Drawing.Point(4, 22);
            this.tabLO.Name = "tabLO";
            this.tabLO.Padding = new System.Windows.Forms.Padding(3);
            this.tabLO.Size = new System.Drawing.Size(867, 363);
            this.tabLO.TabIndex = 0;
            this.tabLO.Text = "ЛО";
            this.tabLO.UseVisualStyleBackColor = true;
            // 
            // datageidlo
            // 
            this.datageidlo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datageidlo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datageidlo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datageidlo.Location = new System.Drawing.Point(3, 3);
            this.datageidlo.Name = "datageidlo";
            this.datageidlo.Size = new System.Drawing.Size(861, 357);
            this.datageidlo.TabIndex = 0;
            // 
            // tabspbrf
            // 
            this.tabspbrf.Controls.Add(this.datagridspbrf);
            this.tabspbrf.Location = new System.Drawing.Point(4, 22);
            this.tabspbrf.Name = "tabspbrf";
            this.tabspbrf.Padding = new System.Windows.Forms.Padding(3);
            this.tabspbrf.Size = new System.Drawing.Size(867, 363);
            this.tabspbrf.TabIndex = 1;
            this.tabspbrf.Text = "СПБ+РФ";
            this.tabspbrf.UseVisualStyleBackColor = true;
            // 
            // datagridspbrf
            // 
            this.datagridspbrf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridspbrf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridspbrf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridspbrf.Location = new System.Drawing.Point(3, 3);
            this.datagridspbrf.Name = "datagridspbrf";
            this.datagridspbrf.Size = new System.Drawing.Size(861, 357);
            this.datagridspbrf.TabIndex = 1;
            // 
            // tabLOspbrf
            // 
            this.tabLOspbrf.Controls.Add(this.datagridspbrflo);
            this.tabLOspbrf.Location = new System.Drawing.Point(4, 22);
            this.tabLOspbrf.Name = "tabLOspbrf";
            this.tabLOspbrf.Size = new System.Drawing.Size(867, 363);
            this.tabLOspbrf.TabIndex = 2;
            this.tabLOspbrf.Text = "СПБ+РФ+ЛО";
            this.tabLOspbrf.UseVisualStyleBackColor = true;
            // 
            // datagridspbrflo
            // 
            this.datagridspbrflo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridspbrflo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridspbrflo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridspbrflo.Location = new System.Drawing.Point(0, 0);
            this.datagridspbrflo.Name = "datagridspbrflo";
            this.datagridspbrflo.Size = new System.Drawing.Size(867, 363);
            this.datagridspbrflo.TabIndex = 1;
            // 
            // Bills
            // 
            this.Bills.Controls.Add(this.listBox1);
            this.Bills.Location = new System.Drawing.Point(4, 22);
            this.Bills.Name = "Bills";
            this.Bills.Padding = new System.Windows.Forms.Padding(3);
            this.Bills.Size = new System.Drawing.Size(867, 363);
            this.Bills.TabIndex = 3;
            this.Bills.Text = "Счета";
            this.Bills.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(861, 357);
            this.listBox1.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lUTAG9BindingSource
            // 
            this.lUTAG9BindingSource.DataMember = "LUTAG9";
            this.lUTAG9BindingSource.DataSource = this.dataSet1;
            // 
            // lUTAG9TableAdapter
            // 
            this.lUTAG9TableAdapter.ClearBeforeFill = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 413);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabLO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datageidlo)).EndInit();
            this.tabspbrf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrf)).EndInit();
            this.tabLOspbrf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrflo)).EndInit();
            this.Bills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выгрузкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доходыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem возвратыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem планToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem планToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сформироватьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toExelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exeltoLOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sPBtoexelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sPBLOtoexelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВсёToolStripMenuItem;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabLO;
        private System.Windows.Forms.DataGridView datageidlo;
        private System.Windows.Forms.TabPage tabspbrf;
        private System.Windows.Forms.DataGridView datagridspbrf;
        private System.Windows.Forms.TabPage tabLOspbrf;
        private System.Windows.Forms.DataGridView datagridspbrflo;
        private System.Windows.Forms.TabPage Bills;
        private System.Windows.Forms.ListBox listBox1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource lUTAG9BindingSource;
        private DataSet1TableAdapters.LUTAG9TableAdapter lUTAG9TableAdapter;
    }
}