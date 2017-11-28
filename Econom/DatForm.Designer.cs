namespace Econom
{
    partial class DatForm
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
            this.MonthBox = new System.Windows.Forms.ComboBox();
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MonthBox
            // 
            this.MonthBox.FormattingEnabled = true;
            this.MonthBox.Location = new System.Drawing.Point(12, 12);
            this.MonthBox.Name = "MonthBox";
            this.MonthBox.Size = new System.Drawing.Size(121, 21);
            this.MonthBox.TabIndex = 0;
            // 
            // YearBox
            // 
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(139, 12);
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(121, 21);
            this.YearBox.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(104, 39);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCan
            // 
            this.btnCan.Location = new System.Drawing.Point(185, 39);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(75, 23);
            this.btnCan.TabIndex = 3;
            this.btnCan.Text = "Отмена";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // DatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 69);
            this.Controls.Add(this.btnCan);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.MonthBox);
            this.Name = "DatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatForm";
            this.Load += new System.EventHandler(this.DatForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox MonthBox;
        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCan;
    }
}