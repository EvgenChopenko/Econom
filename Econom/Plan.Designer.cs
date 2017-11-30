namespace Econom
{
    partial class Plan
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lUTAG9BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Econom.DataSet1();
            this.dOCIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboxyear = new System.Windows.Forms.ComboBox();
            this.yearIdBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comboxmonth = new System.Windows.Forms.ComboBox();
            this.mothsIdBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comboxdoc = new System.Windows.Forms.ComboBox();
            this.dOCIDBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dOCMONTHYEARBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.yearIdBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.docbox = new System.Windows.Forms.CheckBox();
            this.MonthsYear = new System.Windows.Forms.CheckBox();
            this.yearbox = new System.Windows.Forms.CheckBox();
            this.lUTAG9TableAdapter = new Econom.DataSet1TableAdapters.LUTAG9TableAdapter();
            this.keyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATATEXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YEAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SPBPosPlanTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPBOBRPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPBUETPLANOBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPBPlanTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOPOSPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOOBRPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOUETPLANOBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBRPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UetPlanObr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATASTART = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFinish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxRadio = new System.Windows.Forms.GroupBox();
            this.SPBRadioButton = new System.Windows.Forms.RadioButton();
            this.SPBLORadioButton = new System.Windows.Forms.RadioButton();
            this.LORadioButton = new System.Windows.Forms.RadioButton();
            this.ALLRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearIdBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mothsIdBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCIDBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCMONTHYEARBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearIdBindingSource2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.BoxRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyid,
            this.DATATEXT,
            this.YEAR,
            this.specid,
            this.SPBPosPlanTotal,
            this.SPBOBRPLANTOTAL,
            this.SPBUETPLANOBR,
            this.SPBPlanTotal,
            this.LOPOSPLANTOTAL,
            this.LOOBRPLANTOTAL,
            this.LOUETPLANOBR,
            this.LOPLANTOTAL,
            this.POSPLANTOTAL,
            this.OBRPLANTOTAL,
            this.UetPlanObr,
            this.PLANTOTAL,
            this.DATASTART,
            this.DataFinish});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(996, 293);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Location = new System.Drawing.Point(875, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save DB";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(909, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboxyear
            // 
            this.comboxyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxyear.FormattingEnabled = true;
            this.comboxyear.Items.AddRange(new object[] {
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.comboxyear.Location = new System.Drawing.Point(6, 30);
            this.comboxyear.Name = "comboxyear";
            this.comboxyear.Size = new System.Drawing.Size(121, 21);
            this.comboxyear.TabIndex = 4;
            this.comboxyear.SelectedIndexChanged += new System.EventHandler(this.comboxyear_SelectedIndexChanged);
            // 
            // yearIdBindingSource1
            // 
            this.yearIdBindingSource1.DataMember = "yearId";
            // 
            // comboxmonth
            // 
            this.comboxmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxmonth.FormattingEnabled = true;
            this.comboxmonth.Location = new System.Drawing.Point(133, 30);
            this.comboxmonth.Name = "comboxmonth";
            this.comboxmonth.Size = new System.Drawing.Size(121, 21);
            this.comboxmonth.TabIndex = 5;
            // 
            // mothsIdBindingSource1
            // 
            this.mothsIdBindingSource1.DataMember = "MothsId";
            // 
            // comboxdoc
            // 
            this.comboxdoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxdoc.FormattingEnabled = true;
            this.comboxdoc.Location = new System.Drawing.Point(270, 30);
            this.comboxdoc.Name = "comboxdoc";
            this.comboxdoc.Size = new System.Drawing.Size(139, 21);
            this.comboxdoc.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Год";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Месяц";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Доктор";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BoxRadio);
            this.groupBox1.Controls.Add(this.docbox);
            this.groupBox1.Controls.Add(this.MonthsYear);
            this.groupBox1.Controls.Add(this.yearbox);
            this.groupBox1.Controls.Add(this.comboxdoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboxyear);
            this.groupBox1.Controls.Add(this.comboxmonth);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 105);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Меню ";
            // 
            // docbox
            // 
            this.docbox.AutoSize = true;
            this.docbox.Location = new System.Drawing.Point(290, 61);
            this.docbox.Name = "docbox";
            this.docbox.Size = new System.Drawing.Size(125, 17);
            this.docbox.TabIndex = 12;
            this.docbox.Text = "Скрыть Спец.Врача";
            this.docbox.UseVisualStyleBackColor = true;
            // 
            // MonthsYear
            // 
            this.MonthsYear.AutoSize = true;
            this.MonthsYear.Location = new System.Drawing.Point(138, 63);
            this.MonthsYear.Name = "MonthsYear";
            this.MonthsYear.Size = new System.Drawing.Size(100, 17);
            this.MonthsYear.TabIndex = 11;
            this.MonthsYear.Text = "Скрыть Месяц";
            this.MonthsYear.UseVisualStyleBackColor = true;
            this.MonthsYear.CheckedChanged += new System.EventHandler(this.MonthsYear_CheckedChanged);
            // 
            // yearbox
            // 
            this.yearbox.AutoSize = true;
            this.yearbox.Location = new System.Drawing.Point(6, 65);
            this.yearbox.Name = "yearbox";
            this.yearbox.Size = new System.Drawing.Size(126, 17);
            this.yearbox.TabIndex = 10;
            this.yearbox.Text = "Зафиксировать год";
            this.yearbox.UseVisualStyleBackColor = true;
            this.yearbox.CheckedChanged += new System.EventHandler(this.yearbox_CheckedChanged);
            // 
            // lUTAG9TableAdapter
            // 
            this.lUTAG9TableAdapter.ClearBeforeFill = true;
            // 
            // keyid
            // 
            this.keyid.DataPropertyName = "keyid";
            this.keyid.HeaderText = "keyid ";
            this.keyid.Name = "keyid";
            this.keyid.Visible = false;
            this.keyid.Width = 60;
            // 
            // DATATEXT
            // 
            this.DATATEXT.DataPropertyName = "DATATEXT";
            this.DATATEXT.HeaderText = "Месяц";
            this.DATATEXT.Name = "DATATEXT";
            this.DATATEXT.ReadOnly = true;
            this.DATATEXT.Width = 65;
            // 
            // YEAR
            // 
            this.YEAR.DataPropertyName = "YEAR";
            this.YEAR.HeaderText = "ГОД";
            this.YEAR.Name = "YEAR";
            this.YEAR.ReadOnly = true;
            this.YEAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.YEAR.Width = 55;
            // 
            // specid
            // 
            this.specid.DataPropertyName = "SPECID";
            this.specid.DataSource = this.lUTAG9BindingSource;
            this.specid.DisplayMember = "DOC_SPEC";
            this.specid.HeaderText = "Специальность";
            this.specid.Name = "specid";
            this.specid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.specid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.specid.ValueMember = "ID";
            this.specid.Width = 110;
            // 
            // SPBPosPlanTotal
            // 
            this.SPBPosPlanTotal.DataPropertyName = "SPBPosPlanTotal";
            this.SPBPosPlanTotal.HeaderText = "СПБ+РФ кол-посещений";
            this.SPBPosPlanTotal.Name = "SPBPosPlanTotal";
            this.SPBPosPlanTotal.Visible = false;
            this.SPBPosPlanTotal.Width = 159;
            // 
            // SPBOBRPLANTOTAL
            // 
            this.SPBOBRPLANTOTAL.DataPropertyName = "SPBOBRPLANTOTAL";
            this.SPBOBRPLANTOTAL.HeaderText = "СПБ+РФ кол-во обращений";
            this.SPBOBRPLANTOTAL.Name = "SPBOBRPLANTOTAL";
            this.SPBOBRPLANTOTAL.Visible = false;
            this.SPBOBRPLANTOTAL.Width = 174;
            // 
            // SPBUETPLANOBR
            // 
            this.SPBUETPLANOBR.DataPropertyName = "SPBUETPLANOBR";
            this.SPBUETPLANOBR.HeaderText = "СПБ+РФ кол-во ует";
            this.SPBUETPLANOBR.Name = "SPBUETPLANOBR";
            this.SPBUETPLANOBR.Visible = false;
            this.SPBUETPLANOBR.Width = 133;
            // 
            // SPBPlanTotal
            // 
            this.SPBPlanTotal.DataPropertyName = "SPBPlanTotal";
            this.SPBPlanTotal.HeaderText = "СПБ +РФ Плановая стоимость";
            this.SPBPlanTotal.Name = "SPBPlanTotal";
            this.SPBPlanTotal.Visible = false;
            this.SPBPlanTotal.Width = 191;
            // 
            // LOPOSPLANTOTAL
            // 
            this.LOPOSPLANTOTAL.DataPropertyName = "LOPOSPLANTOTAL";
            this.LOPOSPLANTOTAL.HeaderText = "ЛО кол-во Посещений ";
            this.LOPOSPLANTOTAL.Name = "LOPOSPLANTOTAL";
            this.LOPOSPLANTOTAL.Visible = false;
            this.LOPOSPLANTOTAL.Width = 149;
            // 
            // LOOBRPLANTOTAL
            // 
            this.LOOBRPLANTOTAL.DataPropertyName = "LOOBRPLANTOTAL";
            this.LOOBRPLANTOTAL.HeaderText = "ЛО кол-во Оброщений";
            this.LOOBRPLANTOTAL.Name = "LOOBRPLANTOTAL";
            this.LOOBRPLANTOTAL.Visible = false;
            this.LOOBRPLANTOTAL.Width = 146;
            // 
            // LOUETPLANOBR
            // 
            this.LOUETPLANOBR.DataPropertyName = "LOUETPLANOBR";
            this.LOUETPLANOBR.HeaderText = "ЛО кол-во УЕТ";
            this.LOUETPLANOBR.Name = "LOUETPLANOBR";
            this.LOUETPLANOBR.Visible = false;
            this.LOUETPLANOBR.Width = 109;
            // 
            // LOPLANTOTAL
            // 
            this.LOPLANTOTAL.DataPropertyName = "LOPLANTOTAL";
            this.LOPLANTOTAL.HeaderText = "ЛО Плановая Стоимость ";
            this.LOPLANTOTAL.Name = "LOPLANTOTAL";
            this.LOPLANTOTAL.Visible = false;
            this.LOPLANTOTAL.Width = 162;
            // 
            // POSPLANTOTAL
            // 
            this.POSPLANTOTAL.DataPropertyName = "PosPlanTotal";
            this.POSPLANTOTAL.HeaderText = "СПБ+РФ +ЛО кол-во Посещений ";
            this.POSPLANTOTAL.Name = "POSPLANTOTAL";
            this.POSPLANTOTAL.Width = 204;
            // 
            // OBRPLANTOTAL
            // 
            this.OBRPLANTOTAL.DataPropertyName = "OBRPLANTOTAL";
            this.OBRPLANTOTAL.HeaderText = "СПБ +РФ+ЛО кол-во Обращений";
            this.OBRPLANTOTAL.Name = "OBRPLANTOTAL";
            this.OBRPLANTOTAL.Width = 201;
            // 
            // UetPlanObr
            // 
            this.UetPlanObr.DataPropertyName = "UetPlanObr";
            this.UetPlanObr.HeaderText = "СПБ + РФ+ЛО кол-во УЕТ";
            this.UetPlanObr.Name = "UetPlanObr";
            this.UetPlanObr.Width = 167;
            // 
            // PLANTOTAL
            // 
            this.PLANTOTAL.DataPropertyName = "PLANTOTAL";
            this.PLANTOTAL.HeaderText = "СПБ+РФ +ЛО Плановая стоимость";
            this.PLANTOTAL.Name = "PLANTOTAL";
            this.PLANTOTAL.Width = 213;
            // 
            // DATASTART
            // 
            this.DATASTART.DataPropertyName = "DATASTART";
            this.DATASTART.HeaderText = "Дата начала месяца ";
            this.DATASTART.Name = "DATASTART";
            this.DATASTART.Width = 140;
            // 
            // DataFinish
            // 
            this.DataFinish.DataPropertyName = "DataFinish";
            this.DataFinish.HeaderText = "Дата Окончания Месяца";
            this.DataFinish.Name = "DataFinish";
            this.DataFinish.Width = 158;
            // 
            // BoxRadio
            // 
            this.BoxRadio.Controls.Add(this.ALLRadioButton);
            this.BoxRadio.Controls.Add(this.LORadioButton);
            this.BoxRadio.Controls.Add(this.SPBLORadioButton);
            this.BoxRadio.Controls.Add(this.SPBRadioButton);
            this.BoxRadio.Location = new System.Drawing.Point(633, 14);
            this.BoxRadio.Name = "BoxRadio";
            this.BoxRadio.Size = new System.Drawing.Size(236, 79);
            this.BoxRadio.TabIndex = 13;
            this.BoxRadio.TabStop = false;
            this.BoxRadio.Text = "Фильтр";
            // 
            // SPBRadioButton
            // 
            this.SPBRadioButton.AutoSize = true;
            this.SPBRadioButton.Location = new System.Drawing.Point(18, 16);
            this.SPBRadioButton.Name = "SPBRadioButton";
            this.SPBRadioButton.Size = new System.Drawing.Size(71, 17);
            this.SPBRadioButton.TabIndex = 0;
            this.SPBRadioButton.TabStop = true;
            this.SPBRadioButton.Text = "СПБ+РФ";
            this.SPBRadioButton.UseVisualStyleBackColor = true;
            this.SPBRadioButton.CheckedChanged += new System.EventHandler(this.SPBRadioButton_CheckedChanged);
            // 
            // SPBLORadioButton
            // 
            this.SPBLORadioButton.AutoSize = true;
            this.SPBLORadioButton.Location = new System.Drawing.Point(109, 16);
            this.SPBLORadioButton.Name = "SPBLORadioButton";
            this.SPBLORadioButton.Size = new System.Drawing.Size(93, 17);
            this.SPBLORadioButton.TabIndex = 1;
            this.SPBLORadioButton.TabStop = true;
            this.SPBLORadioButton.Text = "СПБ+РФ+ЛО";
            this.SPBLORadioButton.UseVisualStyleBackColor = true;
            this.SPBLORadioButton.CheckedChanged += new System.EventHandler(this.SPBLORadioButton_CheckedChanged);
            // 
            // LORadioButton
            // 
            this.LORadioButton.AutoSize = true;
            this.LORadioButton.Location = new System.Drawing.Point(18, 46);
            this.LORadioButton.Name = "LORadioButton";
            this.LORadioButton.Size = new System.Drawing.Size(41, 17);
            this.LORadioButton.TabIndex = 2;
            this.LORadioButton.TabStop = true;
            this.LORadioButton.Text = "ЛО";
            this.LORadioButton.UseVisualStyleBackColor = true;
            this.LORadioButton.CheckedChanged += new System.EventHandler(this.LORadioButton_CheckedChanged);
            // 
            // ALLRadioButton
            // 
            this.ALLRadioButton.AutoSize = true;
            this.ALLRadioButton.Location = new System.Drawing.Point(109, 46);
            this.ALLRadioButton.Name = "ALLRadioButton";
            this.ALLRadioButton.Size = new System.Drawing.Size(44, 17);
            this.ALLRadioButton.TabIndex = 3;
            this.ALLRadioButton.TabStop = true;
            this.ALLRadioButton.Text = "ALL";
            this.ALLRadioButton.UseVisualStyleBackColor = true;
            this.ALLRadioButton.CheckedChanged += new System.EventHandler(this.ALLRadioButton_CheckedChanged);
            // 
            // Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 314);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Plan";
            this.Text = "План";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Plan_FormClosed);
            this.Load += new System.EventHandler(this.Plan_Load);
            this.SizeChanged += new System.EventHandler(this.Plan_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearIdBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mothsIdBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCIDBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCMONTHYEARBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearIdBindingSource2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.BoxRadio.ResumeLayout(false);
            this.BoxRadio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboxyear;
        private System.Windows.Forms.ComboBox comboxmonth;
        private System.Windows.Forms.ComboBox comboxdoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
      //  private DOC_MONTH_YEARTableAdapters.MothsIdTableAdapter mothsIdTableAdapter;
        private System.Windows.Forms.BindingSource dOCIDBindingSource;
      //  private DOC_MONTH_YEARTableAdapters.DOCIDTableAdapter dOCIDTableAdapter;
        private System.Windows.Forms.BindingSource yearIdBindingSource1;
        private System.Windows.Forms.BindingSource mothsIdBindingSource1;
        private System.Windows.Forms.BindingSource yearIdBindingSource2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox docbox;
        private System.Windows.Forms.CheckBox MonthsYear;
        private System.Windows.Forms.CheckBox yearbox;
        private System.Windows.Forms.BindingSource dOCIDBindingSource1;
        private System.Windows.Forms.BindingSource dOCMONTHYEARBindingSource1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource lUTAG9BindingSource;
        private DataSet1TableAdapters.LUTAG9TableAdapter lUTAG9TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATATEXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn YEAR;
        private System.Windows.Forms.DataGridViewComboBoxColumn specid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPBPosPlanTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPBOBRPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPBUETPLANOBR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPBPlanTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOPOSPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOOBRPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOUETPLANOBR;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBRPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn UetPlanObr;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATASTART;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFinish;
        private System.Windows.Forms.GroupBox BoxRadio;
        private System.Windows.Forms.RadioButton ALLRadioButton;
        private System.Windows.Forms.RadioButton LORadioButton;
        private System.Windows.Forms.RadioButton SPBLORadioButton;
        private System.Windows.Forms.RadioButton SPBRadioButton;
    }
}