namespace Econom
{
    partial class PlabCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlabCalc));
            this.DocBox = new System.Windows.Forms.ComboBox();
            this.MonthsBox = new System.Windows.Forms.ComboBox();
            this.MonthsYear = new System.Windows.Forms.ComboBox();
            this.chekDisp = new System.Windows.Forms.CheckBox();
            this.DispBoxUet = new System.Windows.Forms.TextBox();
            this.DispBoxPos = new System.Windows.Forms.TextBox();
            this.DisbBoxObr = new System.Windows.Forms.TextBox();
            this.DispBoxSum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SPBOBRBOX = new System.Windows.Forms.TextBox();
            this.LOOBRBOX = new System.Windows.Forms.TextBox();
            this.SPBLOOBRBOX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SPBLOPOSBOX = new System.Windows.Forms.TextBox();
            this.LOPOSBOX = new System.Windows.Forms.TextBox();
            this.SPBPOSBOX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SPBLOUETBOX = new System.Windows.Forms.TextBox();
            this.LOUETBOX = new System.Windows.Forms.TextBox();
            this.SPBUETBOX = new System.Windows.Forms.TextBox();
            this.ONESUMBOX = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SPBLOTOTALMONTHS = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.LOTOTALMOTHES = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.SPBTOTALMONTHS = new System.Windows.Forms.TextBox();
            this.DispLabelObr = new System.Windows.Forms.Label();
            this.DispLabelPos = new System.Windows.Forms.Label();
            this.DispLabelUet = new System.Windows.Forms.Label();
            this.DispLabelSum = new System.Windows.Forms.Label();
            this.dataSet1 = new Econom.DataSet1();
            this.lUTAG9BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lUTAG9TableAdapter = new Econom.DataSet1TableAdapters.LUTAG9TableAdapter();
            this.redact = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DocBox
            // 
            this.DocBox.DataSource = this.lUTAG9BindingSource;
            this.DocBox.DisplayMember = "DOC_SPEC";
            this.DocBox.FormattingEnabled = true;
            resources.ApplyResources(this.DocBox, "DocBox");
            this.DocBox.Name = "DocBox";
            this.DocBox.ValueMember = "ID";
            // 
            // MonthsBox
            // 
            this.MonthsBox.FormattingEnabled = true;
            resources.ApplyResources(this.MonthsBox, "MonthsBox");
            this.MonthsBox.Name = "MonthsBox";
            // 
            // MonthsYear
            // 
            this.MonthsYear.FormattingEnabled = true;
            resources.ApplyResources(this.MonthsYear, "MonthsYear");
            this.MonthsYear.Name = "MonthsYear";
            // 
            // chekDisp
            // 
            resources.ApplyResources(this.chekDisp, "chekDisp");
            this.chekDisp.Name = "chekDisp";
            this.chekDisp.UseVisualStyleBackColor = true;
            this.chekDisp.CheckedChanged += new System.EventHandler(this.chekDisp_CheckedChanged);
            // 
            // DispBoxUet
            // 
            resources.ApplyResources(this.DispBoxUet, "DispBoxUet");
            this.DispBoxUet.Name = "DispBoxUet";
            // 
            // DispBoxPos
            // 
            resources.ApplyResources(this.DispBoxPos, "DispBoxPos");
            this.DispBoxPos.Name = "DispBoxPos";
            // 
            // DisbBoxObr
            // 
            resources.ApplyResources(this.DisbBoxObr, "DisbBoxObr");
            this.DisbBoxObr.Name = "DisbBoxObr";
            // 
            // DispBoxSum
            // 
            resources.ApplyResources(this.DispBoxSum, "DispBoxSum");
            this.DispBoxSum.Name = "DispBoxSum";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // SPBOBRBOX
            // 
            resources.ApplyResources(this.SPBOBRBOX, "SPBOBRBOX");
            this.SPBOBRBOX.Name = "SPBOBRBOX";
            // 
            // LOOBRBOX
            // 
            resources.ApplyResources(this.LOOBRBOX, "LOOBRBOX");
            this.LOOBRBOX.Name = "LOOBRBOX";
            // 
            // SPBLOOBRBOX
            // 
            resources.ApplyResources(this.SPBLOOBRBOX, "SPBLOOBRBOX");
            this.SPBLOOBRBOX.Name = "SPBLOOBRBOX";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // SPBLOPOSBOX
            // 
            resources.ApplyResources(this.SPBLOPOSBOX, "SPBLOPOSBOX");
            this.SPBLOPOSBOX.Name = "SPBLOPOSBOX";
            // 
            // LOPOSBOX
            // 
            resources.ApplyResources(this.LOPOSBOX, "LOPOSBOX");
            this.LOPOSBOX.Name = "LOPOSBOX";
            // 
            // SPBPOSBOX
            // 
            resources.ApplyResources(this.SPBPOSBOX, "SPBPOSBOX");
            this.SPBPOSBOX.Name = "SPBPOSBOX";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // SPBLOUETBOX
            // 
            resources.ApplyResources(this.SPBLOUETBOX, "SPBLOUETBOX");
            this.SPBLOUETBOX.Name = "SPBLOUETBOX";
            // 
            // LOUETBOX
            // 
            resources.ApplyResources(this.LOUETBOX, "LOUETBOX");
            this.LOUETBOX.Name = "LOUETBOX";
            // 
            // SPBUETBOX
            // 
            resources.ApplyResources(this.SPBUETBOX, "SPBUETBOX");
            this.SPBUETBOX.Name = "SPBUETBOX";
            // 
            // ONESUMBOX
            // 
            resources.ApplyResources(this.ONESUMBOX, "ONESUMBOX");
            this.ONESUMBOX.Name = "ONESUMBOX";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // SPBLOTOTALMONTHS
            // 
            resources.ApplyResources(this.SPBLOTOTALMONTHS, "SPBLOTOTALMONTHS");
            this.SPBLOTOTALMONTHS.Name = "SPBLOTOTALMONTHS";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // LOTOTALMOTHES
            // 
            resources.ApplyResources(this.LOTOTALMOTHES, "LOTOTALMOTHES");
            this.LOTOTALMOTHES.Name = "LOTOTALMOTHES";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // SPBTOTALMONTHS
            // 
            resources.ApplyResources(this.SPBTOTALMONTHS, "SPBTOTALMONTHS");
            this.SPBTOTALMONTHS.Name = "SPBTOTALMONTHS";
            // 
            // DispLabelObr
            // 
            resources.ApplyResources(this.DispLabelObr, "DispLabelObr");
            this.DispLabelObr.Name = "DispLabelObr";
            // 
            // DispLabelPos
            // 
            resources.ApplyResources(this.DispLabelPos, "DispLabelPos");
            this.DispLabelPos.Name = "DispLabelPos";
            // 
            // DispLabelUet
            // 
            resources.ApplyResources(this.DispLabelUet, "DispLabelUet");
            this.DispLabelUet.Name = "DispLabelUet";
            // 
            // DispLabelSum
            // 
            resources.ApplyResources(this.DispLabelSum, "DispLabelSum");
            this.DispLabelSum.Name = "DispLabelSum";
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
            // redact
            // 
            resources.ApplyResources(this.redact, "redact");
            this.redact.Name = "redact";
            this.redact.UseVisualStyleBackColor = true;
            this.redact.CheckedChanged += new System.EventHandler(this.redact_CheckedChanged);
            // 
            // PlabCalc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.redact);
            this.Controls.Add(this.DispLabelSum);
            this.Controls.Add(this.DispLabelUet);
            this.Controls.Add(this.DispLabelPos);
            this.Controls.Add(this.DispLabelObr);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.SPBTOTALMONTHS);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.LOTOTALMOTHES);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.SPBLOTOTALMONTHS);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ONESUMBOX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SPBLOUETBOX);
            this.Controls.Add(this.LOUETBOX);
            this.Controls.Add(this.SPBUETBOX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SPBLOPOSBOX);
            this.Controls.Add(this.LOPOSBOX);
            this.Controls.Add(this.SPBPOSBOX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SPBLOOBRBOX);
            this.Controls.Add(this.LOOBRBOX);
            this.Controls.Add(this.SPBOBRBOX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DispBoxSum);
            this.Controls.Add(this.DisbBoxObr);
            this.Controls.Add(this.DispBoxPos);
            this.Controls.Add(this.DispBoxUet);
            this.Controls.Add(this.chekDisp);
            this.Controls.Add(this.MonthsYear);
            this.Controls.Add(this.MonthsBox);
            this.Controls.Add(this.DocBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "PlabCalc";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlabCalc_FormClosed);
            this.Load += new System.EventHandler(this.PlabCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUTAG9BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DocBox;
        private System.Windows.Forms.ComboBox MonthsBox;
        private System.Windows.Forms.ComboBox MonthsYear;
        private System.Windows.Forms.CheckBox chekDisp;
        private System.Windows.Forms.TextBox DispBoxUet;
        private System.Windows.Forms.TextBox DispBoxPos;
        private System.Windows.Forms.TextBox DisbBoxObr;
        private System.Windows.Forms.TextBox DispBoxSum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SPBOBRBOX;
        private System.Windows.Forms.TextBox LOOBRBOX;
        private System.Windows.Forms.TextBox SPBLOOBRBOX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SPBLOPOSBOX;
        private System.Windows.Forms.TextBox LOPOSBOX;
        private System.Windows.Forms.TextBox SPBPOSBOX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SPBLOUETBOX;
        private System.Windows.Forms.TextBox LOUETBOX;
        private System.Windows.Forms.TextBox SPBUETBOX;
        private System.Windows.Forms.TextBox ONESUMBOX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox SPBLOTOTALMONTHS;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox LOTOTALMOTHES;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox SPBTOTALMONTHS;
        private System.Windows.Forms.Label DispLabelObr;
        private System.Windows.Forms.Label DispLabelPos;
        private System.Windows.Forms.Label DispLabelUet;
        private System.Windows.Forms.Label DispLabelSum;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource lUTAG9BindingSource;
        private DataSet1TableAdapters.LUTAG9TableAdapter lUTAG9TableAdapter;
        private System.Windows.Forms.CheckBox redact;
    }
}