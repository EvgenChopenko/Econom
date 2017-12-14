namespace Econom
{
    partial class vozvrat
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.scan = new System.Windows.Forms.Button();
            this.datatextfinish = new System.Windows.Forms.Label();
            this.datatextstart = new System.Windows.Forms.Label();
            this.indat = new System.Windows.Forms.MaskedTextBox();
            this.fordat = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mathcheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yearBox = new System.Windows.Forms.ComboBox();
            this.MonthBox = new System.Windows.Forms.ComboBox();
            this.ex_oracle = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabLO = new System.Windows.Forms.TabPage();
            this.datageidlo = new System.Windows.Forms.DataGridView();
            this.keyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lUTAG9BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Econom.DataSet1();
            this.UET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUMVOZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabspbrf = new System.Windows.Forms.TabPage();
            this.tabLOspbrf = new System.Windows.Forms.TabPage();
            this.Bills = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lUTAG9TableAdapter = new Econom.DataSet1TableAdapters.LUTAG9TableAdapter();
            this.datagridspbrf = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagridspbrflo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabLO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datageidlo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tabspbrf.SuspendLayout();
            this.tabLOspbrf.SuspendLayout();
            this.Bills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrflo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.scan);
            this.groupBox1.Controls.Add(this.datatextfinish);
            this.groupBox1.Controls.Add(this.datatextstart);
            this.groupBox1.Controls.Add(this.indat);
            this.groupBox1.Controls.Add(this.fordat);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.mathcheck);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.yearBox);
            this.groupBox1.Controls.Add(this.MonthBox);
            this.groupBox1.Controls.Add(this.ex_oracle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Меню";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Фиксация дат";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // scan
            // 
            this.scan.Location = new System.Drawing.Point(534, 77);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(75, 23);
            this.scan.TabIndex = 19;
            this.scan.Text = "Скан";
            this.scan.UseVisualStyleBackColor = true;
            this.scan.Click += new System.EventHandler(this.scan_Click);
            // 
            // datatextfinish
            // 
            this.datatextfinish.AutoSize = true;
            this.datatextfinish.Location = new System.Drawing.Point(127, 55);
            this.datatextfinish.Name = "datatextfinish";
            this.datatextfinish.Size = new System.Drawing.Size(196, 13);
            this.datatextfinish.TabIndex = 18;
            this.datatextfinish.Text = "Дата окончания выстовления счетов";
            this.datatextfinish.Visible = false;
            // 
            // datatextstart
            // 
            this.datatextstart.AutoSize = true;
            this.datatextstart.Location = new System.Drawing.Point(145, 16);
            this.datatextstart.Name = "datatextstart";
            this.datatextstart.Size = new System.Drawing.Size(178, 13);
            this.datatextstart.TabIndex = 17;
            this.datatextstart.Text = "Дата начала выстовления счетов";
            this.datatextstart.Visible = false;
            // 
            // indat
            // 
            this.indat.Location = new System.Drawing.Point(329, 13);
            this.indat.Mask = "00/00/0000";
            this.indat.Name = "indat";
            this.indat.Size = new System.Drawing.Size(100, 20);
            this.indat.TabIndex = 16;
            this.indat.ValidatingType = typeof(System.DateTime);
            this.indat.Visible = false;
            // 
            // fordat
            // 
            this.fordat.Location = new System.Drawing.Point(329, 52);
            this.fordat.Mask = "00/00/0000";
            this.fordat.Name = "fordat";
            this.fordat.Size = new System.Drawing.Size(100, 20);
            this.fordat.TabIndex = 15;
            this.fordat.ValidatingType = typeof(System.DateTime);
            this.fordat.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mathcheck
            // 
            this.mathcheck.AutoSize = true;
            this.mathcheck.Location = new System.Drawing.Point(12, 93);
            this.mathcheck.Name = "mathcheck";
            this.mathcheck.Size = new System.Drawing.Size(91, 17);
            this.mathcheck.TabIndex = 13;
            this.mathcheck.Text = "калькуляция";
            this.mathcheck.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Месяц\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "ГОД\r\n\r\n";
            // 
            // yearBox
            // 
            this.yearBox.FormattingEnabled = true;
            this.yearBox.Items.AddRange(new object[] {
            "2017",
            "2018",
            "2019",
            "2020",
            "2021"});
            this.yearBox.Location = new System.Drawing.Point(509, 39);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(121, 21);
            this.yearBox.TabIndex = 10;
            this.yearBox.SelectedIndexChanged += new System.EventHandler(this.yearBox_SelectedIndexChanged);
            // 
            // MonthBox
            // 
            this.MonthBox.FormattingEnabled = true;
            this.MonthBox.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель ",
            "Май  ",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь ",
            "Октябрь",
            "Декабрь"});
            this.MonthBox.Location = new System.Drawing.Point(509, 12);
            this.MonthBox.Name = "MonthBox";
            this.MonthBox.Size = new System.Drawing.Size(121, 21);
            this.MonthBox.TabIndex = 9;
            this.MonthBox.SelectionChangeCommitted += new System.EventHandler(this.MonthBox_SelectionChangeCommitted);
            // 
            // ex_oracle
            // 
            this.ex_oracle.Location = new System.Drawing.Point(7, 12);
            this.ex_oracle.Name = "ex_oracle";
            this.ex_oracle.Size = new System.Drawing.Size(111, 23);
            this.ex_oracle.TabIndex = 8;
            this.ex_oracle.Text = "Экспорт из Oracle";
            this.ex_oracle.UseVisualStyleBackColor = true;
            this.ex_oracle.Visible = false;
            this.ex_oracle.Click += new System.EventHandler(this.ex_oracle_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabLO);
            this.tab.Controls.Add(this.tabspbrf);
            this.tab.Controls.Add(this.tabLOspbrf);
            this.tab.Controls.Add(this.Bills);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 116);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(736, 221);
            this.tab.TabIndex = 1;
            // 
            // tabLO
            // 
            this.tabLO.Controls.Add(this.datageidlo);
            this.tabLO.Location = new System.Drawing.Point(4, 22);
            this.tabLO.Name = "tabLO";
            this.tabLO.Padding = new System.Windows.Forms.Padding(3);
            this.tabLO.Size = new System.Drawing.Size(728, 195);
            this.tabLO.TabIndex = 0;
            this.tabLO.Text = "ЛО";
            this.tabLO.UseVisualStyleBackColor = true;
            // 
            // datageidlo
            // 
            this.datageidlo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datageidlo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datageidlo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyid,
            this.specid,
            this.UET,
            this.QTY,
            this.SUMVOZ,
            this.OBR,
            this.POS});
            this.datageidlo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datageidlo.Location = new System.Drawing.Point(3, 3);
            this.datageidlo.Name = "datageidlo";
            this.datageidlo.Size = new System.Drawing.Size(722, 189);
            this.datageidlo.TabIndex = 0;
            this.datageidlo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datageidlo_CellContentClick);
            // 
            // keyid
            // 
            this.keyid.DataPropertyName = "keyid";
            this.keyid.HeaderText = "KEYID";
            this.keyid.Name = "keyid";
            this.keyid.ReadOnly = true;
            this.keyid.Visible = false;
            // 
            // specid
            // 
            this.specid.DataPropertyName = "specid";
            this.specid.DataSource = this.lUTAG9BindingSource;
            this.specid.DisplayMember = "DOC_SPEC";
            this.specid.HeaderText = "Доктор";
            this.specid.Name = "specid";
            this.specid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.specid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.specid.ValueMember = "ID";
            // 
            // lUTAG9BindingSource
            // 
            this.lUTAG9BindingSource.DataMember = "LUTAG9";
            this.lUTAG9BindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UET
            // 
            this.UET.DataPropertyName = "UET";
            this.UET.HeaderText = "Кол-во Ует";
            this.UET.Name = "UET";
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "Кол-во Услуг";
            this.QTY.Name = "QTY";
            // 
            // SUMVOZ
            // 
            this.SUMVOZ.DataPropertyName = "SUMVOZ";
            this.SUMVOZ.HeaderText = "Сумма Возврата";
            this.SUMVOZ.Name = "SUMVOZ";
            // 
            // OBR
            // 
            this.OBR.DataPropertyName = "OBR";
            this.OBR.HeaderText = "Кол-во Обращений ";
            this.OBR.Name = "OBR";
            // 
            // POS
            // 
            this.POS.DataPropertyName = "POS";
            this.POS.HeaderText = "Кол-во Посещений";
            this.POS.Name = "POS";
            // 
            // tabspbrf
            // 
            this.tabspbrf.Controls.Add(this.datagridspbrf);
            this.tabspbrf.Location = new System.Drawing.Point(4, 22);
            this.tabspbrf.Name = "tabspbrf";
            this.tabspbrf.Padding = new System.Windows.Forms.Padding(3);
            this.tabspbrf.Size = new System.Drawing.Size(728, 195);
            this.tabspbrf.TabIndex = 1;
            this.tabspbrf.Text = "СПБ+РФ";
            this.tabspbrf.UseVisualStyleBackColor = true;
            // 
            // tabLOspbrf
            // 
            this.tabLOspbrf.Controls.Add(this.datagridspbrflo);
            this.tabLOspbrf.Location = new System.Drawing.Point(4, 22);
            this.tabLOspbrf.Name = "tabLOspbrf";
            this.tabLOspbrf.Size = new System.Drawing.Size(728, 195);
            this.tabLOspbrf.TabIndex = 2;
            this.tabLOspbrf.Text = "СПБ+РФ+ЛО";
            this.tabLOspbrf.UseVisualStyleBackColor = true;
            // 
            // Bills
            // 
            this.Bills.Controls.Add(this.listBox1);
            this.Bills.Location = new System.Drawing.Point(4, 22);
            this.Bills.Name = "Bills";
            this.Bills.Padding = new System.Windows.Forms.Padding(3);
            this.Bills.Size = new System.Drawing.Size(728, 195);
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
            this.listBox1.Size = new System.Drawing.Size(722, 189);
            this.listBox1.TabIndex = 0;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // lUTAG9TableAdapter
            // 
            this.lUTAG9TableAdapter.ClearBeforeFill = true;
            // 
            // datagridspbrf
            // 
            this.datagridspbrf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridspbrf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridspbrf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.datagridspbrf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridspbrf.Location = new System.Drawing.Point(3, 3);
            this.datagridspbrf.Name = "datagridspbrf";
            this.datagridspbrf.Size = new System.Drawing.Size(722, 189);
            this.datagridspbrf.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "keyid";
            this.dataGridViewTextBoxColumn1.HeaderText = "KEYID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "specid";
            this.dataGridViewComboBoxColumn1.DataSource = this.lUTAG9BindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "DOC_SPEC";
            this.dataGridViewComboBoxColumn1.HeaderText = "Доктор";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "ID";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UET";
            this.dataGridViewTextBoxColumn2.HeaderText = "Кол-во Ует";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "QTY";
            this.dataGridViewTextBoxColumn3.HeaderText = "Кол-во Услуг";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SUMVOZ";
            this.dataGridViewTextBoxColumn4.HeaderText = "Сумма Возврата";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "OBR";
            this.dataGridViewTextBoxColumn5.HeaderText = "Кол-во Обращений ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "POS";
            this.dataGridViewTextBoxColumn6.HeaderText = "Кол-во Посещений";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // datagridspbrflo
            // 
            this.datagridspbrflo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridspbrflo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridspbrflo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewComboBoxColumn2,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.datagridspbrflo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridspbrflo.Location = new System.Drawing.Point(0, 0);
            this.datagridspbrflo.Name = "datagridspbrflo";
            this.datagridspbrflo.Size = new System.Drawing.Size(728, 195);
            this.datagridspbrflo.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "keyid";
            this.dataGridViewTextBoxColumn7.HeaderText = "KEYID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "specid";
            this.dataGridViewComboBoxColumn2.DataSource = this.lUTAG9BindingSource;
            this.dataGridViewComboBoxColumn2.DisplayMember = "DOC_SPEC";
            this.dataGridViewComboBoxColumn2.HeaderText = "Доктор";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.ValueMember = "ID";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UET";
            this.dataGridViewTextBoxColumn8.HeaderText = "Кол-во Ует";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "QTY";
            this.dataGridViewTextBoxColumn9.HeaderText = "Кол-во Услуг";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "SUMVOZ";
            this.dataGridViewTextBoxColumn10.HeaderText = "Сумма Возврата";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "OBR";
            this.dataGridViewTextBoxColumn11.HeaderText = "Кол-во Обращений ";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "POS";
            this.dataGridViewTextBoxColumn12.HeaderText = "Кол-во Посещений";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // vozvrat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 337);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.groupBox1);
            this.Name = "vozvrat";
            this.Text = "Выгрузка возвратов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.vozvrat_FormClosed);
            this.Load += new System.EventHandler(this.vozvrat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabLO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datageidlo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tabspbrf.ResumeLayout(false);
            this.tabLOspbrf.ResumeLayout(false);
            this.Bills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridspbrflo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabLO;
        private System.Windows.Forms.DataGridView datageidlo;
        private System.Windows.Forms.TabPage tabspbrf;
        private System.Windows.Forms.TabPage tabLOspbrf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox mathcheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yearBox;
        private System.Windows.Forms.ComboBox MonthBox;
        private System.Windows.Forms.Button ex_oracle;
        private System.Windows.Forms.MaskedTextBox indat;
        private System.Windows.Forms.MaskedTextBox fordat;
        private System.Windows.Forms.Label datatextfinish;
        private System.Windows.Forms.Label datatextstart;
        private System.Windows.Forms.TabPage Bills;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button scan;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.BindingSource lUTAG9BindingSource;
        private DataSet1TableAdapters.LUTAG9TableAdapter lUTAG9TableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyid;
        private System.Windows.Forms.DataGridViewComboBoxColumn specid;
        private System.Windows.Forms.DataGridViewTextBoxColumn UET;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUMVOZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBR;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS;
        private System.Windows.Forms.DataGridView datagridspbrf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView datagridspbrflo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    }
}