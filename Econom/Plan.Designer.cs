﻿namespace Econom
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.yearbox = new System.Windows.Forms.CheckBox();
            this.lUTAG9TableAdapter = new Econom.DataSet1TableAdapters.LUTAG9TableAdapter();
            this.keyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATATEXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YEAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SPBPlanTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPBPosPlanTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBRPLANTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UetPlanObr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATASTART = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFinish = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyid,
            this.DATATEXT,
            this.YEAR,
            this.specid,
            this.SPBPlanTotal,
            this.SPBPosPlanTotal,
            this.PLANTOTAL,
            this.POSPLANTOTAL,
            this.OBRPLANTOTAL,
            this.UetPlanObr,
            this.DATASTART,
            this.DataFinish});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(846, 293);
            this.dataGridView1.TabIndex = 0;
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
            this.button1.Location = new System.Drawing.Point(731, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save DB";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(753, 59);
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
            this.comboxyear.Location = new System.Drawing.Point(48, 32);
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
            this.comboxmonth.Location = new System.Drawing.Point(210, 32);
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
            this.comboxdoc.Location = new System.Drawing.Point(364, 32);
            this.comboxdoc.Name = "comboxdoc";
            this.comboxdoc.Size = new System.Drawing.Size(170, 21);
            this.comboxdoc.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Год";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Месяц";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Доктор";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.docbox);
            this.groupBox1.Controls.Add(this.checkBox2);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 105);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Меню ";
            // 
            // docbox
            // 
            this.docbox.AutoSize = true;
            this.docbox.Location = new System.Drawing.Point(397, 63);
            this.docbox.Name = "docbox";
            this.docbox.Size = new System.Drawing.Size(125, 17);
            this.docbox.TabIndex = 12;
            this.docbox.Text = "Скрыть Спец.Врача";
            this.docbox.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(229, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(100, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Скрыть Месяц";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // yearbox
            // 
            this.yearbox.AutoSize = true;
            this.yearbox.Location = new System.Drawing.Point(65, 65);
            this.yearbox.Name = "yearbox";
            this.yearbox.Size = new System.Drawing.Size(85, 17);
            this.yearbox.TabIndex = 10;
            this.yearbox.Text = "Скрыть Год";
            this.yearbox.UseVisualStyleBackColor = true;
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
            // 
            // DATATEXT
            // 
            this.DATATEXT.DataPropertyName = "DATATEXT";
            this.DATATEXT.HeaderText = "Месяц";
            this.DATATEXT.Name = "DATATEXT";
            // 
            // YEAR
            // 
            this.YEAR.DataPropertyName = "YEAR";
            this.YEAR.HeaderText = "ГОД";
            this.YEAR.Name = "YEAR";
            this.YEAR.ReadOnly = true;
            this.YEAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // 
            // SPBPlanTotal
            // 
            this.SPBPlanTotal.DataPropertyName = "SPBPlanTotal";
            this.SPBPlanTotal.HeaderText = "СПБ +РФ Плановая стоимость";
            this.SPBPlanTotal.Name = "SPBPlanTotal";
            // 
            // SPBPosPlanTotal
            // 
            this.SPBPosPlanTotal.DataPropertyName = "SPBPosPlanTotal";
            this.SPBPosPlanTotal.HeaderText = "СПБ+РФ кол-посещений";
            this.SPBPosPlanTotal.Name = "SPBPosPlanTotal";
            // 
            // PLANTOTAL
            // 
            this.PLANTOTAL.DataPropertyName = "PLANTOTAL";
            this.PLANTOTAL.HeaderText = "СПБ+РФ +ЛО Плановая стоимость";
            this.PLANTOTAL.Name = "PLANTOTAL";
            // 
            // POSPLANTOTAL
            // 
            this.POSPLANTOTAL.DataPropertyName = "PosPlanTotal";
            this.POSPLANTOTAL.HeaderText = "СПБ+РФ +ЛО кол-во Посещений ";
            this.POSPLANTOTAL.Name = "POSPLANTOTAL";
            // 
            // OBRPLANTOTAL
            // 
            this.OBRPLANTOTAL.DataPropertyName = "OBRPLANTOTAL";
            this.OBRPLANTOTAL.HeaderText = "СПБ +РФ+ЛО кол-во Обращений";
            this.OBRPLANTOTAL.Name = "OBRPLANTOTAL";
            // 
            // UetPlanObr
            // 
            this.UetPlanObr.DataPropertyName = "UetPlanObr";
            this.UetPlanObr.HeaderText = "СПБ + РФ+ЛО кол-во УЕТ";
            this.UetPlanObr.Name = "UetPlanObr";
            // 
            // DATASTART
            // 
            this.DATASTART.DataPropertyName = "DATASTART";
            this.DATASTART.HeaderText = "Дата начала месяца ";
            this.DATASTART.Name = "DATASTART";
            // 
            // DataFinish
            // 
            this.DataFinish.DataPropertyName = "DataFinish";
            this.DataFinish.HeaderText = "Дата Окончания Месяца";
            this.DataFinish.Name = "DataFinish";
            // 
            // Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 318);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Plan";
            this.Text = "План";
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
        private System.Windows.Forms.CheckBox checkBox2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn SPBPlanTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPBPosPlanTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBRPLANTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn UetPlanObr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATASTART;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFinish;
    }
}