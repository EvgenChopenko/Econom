using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    public partial class PlabCalc : Form
    {

        private Plan father = null; 
        public PlabCalc()
        {
            InitializeComponent();
            this.MonthsBox.DataSource = Program.GETMonths();
            this.MonthsYear.DataSource = Program.GETYERS();
        }

        public PlabCalc(Plan father)
        {
            InitializeComponent();
            this.father = father;
            this.MonthsBox.DataSource = Program.GETMonths();
            this.MonthsYear.DataSource = Program.GETYERS();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PlabCalc_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.LUTAG9". При необходимости она может быть перемещена или удалена.
            this.lUTAG9TableAdapter.Fill(this.dataSet1.LUTAG9);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            reckoner a = new reckoner();
            a.InTEXBOX(SPBPOSBOX, LOPOSBOX, SPBLOPOSBOX);
            a.InTEXBOX(SPBOBRBOX, LOOBRBOX, SPBLOOBRBOX);
            a.InTEXBOX(SPBUETBOX, LOUETBOX, SPBLOUETBOX);

            if (a.indispsto(DispBoxSum, DispBoxPos, ONESUMBOX, SPBLOPOSBOX, chekDisp.Checked)) {
                SPBPOSBOX.Text = "0";
                LOPOSBOX.Text = "0";

                chekDisp.Checked = false;
            };
            this.SPBTOTALMONTHS.Text = a.insumMonts(ONESUMBOX, SPBPOSBOX).ToString();
            this.LOTOTALMOTHES.Text = a.insumMonts(ONESUMBOX, LOPOSBOX).ToString();
            this.SPBLOTOTALMONTHS.Text = a.insumMonts(ONESUMBOX, SPBLOPOSBOX).ToString();





        }

        private void chekDisp_CheckedChanged(object sender, EventArgs e)
        {
            if (chekDisp.Checked){
                DispBoxSum.Enabled = true;
                DispBoxPos.Enabled = true;
                DispBoxUet.Enabled = true;
               DisbBoxObr.Enabled = true;
                ///
                DispLabelObr.Enabled = true;
                DispLabelPos.Enabled = true;
                DispLabelSum.Enabled = true;
                DispLabelUet.Enabled = true;
            }
            else
            {
                DispBoxSum.Enabled = false;
                DispBoxPos.Enabled = false;
                DispBoxUet.Enabled = false;
                DisbBoxObr.Enabled = false;
                ///
                DispLabelObr.Enabled = false;
                DispLabelPos.Enabled = false;
                DispLabelSum.Enabled = false;
                DispLabelUet.Enabled = false;
            }
        }

        private void PlabCalc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.father.Calcwindows = null;
            this.father.Row1 = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void DataMonthsYearDoc(string Months,string Year,object doc)
        {
            if (Months != null || Months != "")

                MonthsBox.Text = Months;
            if (Year != null || Year != "")

                this.MonthsYear.Text = Year;
            if (doc != null)
                this.DocBox.SelectedValue = doc;




           

            this.MonthsBox.Enabled = false;
            this.MonthsYear.Enabled = false;
            this.DocBox.Enabled = false;
        }

        public void DataLO(string obr, string pos, string uet)
        {
            if (obr is null || obr == "")
                obr = "0";
            if (pos is null || pos == "")
                pos = "0";
            if (uet is null || uet == "")
                uet = "0";

            LOOBRBOX.Text = obr;
            LOPOSBOX.Text = pos;
            LOUETBOX.Text = uet;
                

         
        }
        public void DataSPB(string obr, string pos, string uet)
        {
            if (obr is null || obr == "")
                obr = "0";
            if (pos is null || pos == "")
                pos = "0";
            if (uet is null || uet == "")
                uet = "0";

            SPBOBRBOX.Text = obr;
            SPBPOSBOX.Text = pos;
            SPBUETBOX.Text = uet;



        }
        public void DataSPBLO(string obr, string pos, string uet)
        {if (obr is null || obr == "")
                obr = "0";
            if (pos is null || pos == "")
                pos = "0";
            if (uet is null || uet == "")
                uet = "0";



            SPBLOOBRBOX.Text = obr;
            SPBLOPOSBOX.Text = pos;
            SPBLOUETBOX.Text = uet;
        }

        public void DataSum(string LO,string SPB, string SPBLO)
        {
            try
            {
                decimal lo = decimal.Parse(LO);
                decimal spb = decimal.Parse(SPB);
                decimal spblo = decimal.Parse(SPBLO);
                decimal sum = lo + spb + spblo;
                if (sum == lo || sum == spb || sum == spblo)
                    ONESUMBOX.Text = sum.ToString();
                if ((sum == lo + spb && sum != lo && sum != spb) || (sum == spblo + lo && sum != lo && sum != spblo) || (sum == spb + spblo && spblo != sum && sum != spb))
                    ONESUMBOX.Text = ((sum) / 2).ToString();
                if (lo > 0 && spb > 0 && spblo > 0)
                    ONESUMBOX.Text = (sum / 3).ToString();
            }
            catch(Exception e)
            {
                MessageBox.Show("Введите цифры в поля сумм"+e.Message);
            }
          
           


        }




        private void redact_CheckedChanged(object sender, EventArgs e)
        {
            if (this.redact.Checked)
            {
                this.MonthsBox.Enabled = true;
                this.MonthsYear.Enabled = true;
                this.DocBox.Enabled = true;
            }
            else
            {

                this.MonthsBox.Enabled = false;
                this.MonthsYear.Enabled = false;
                this.DocBox.Enabled = false;
            }

        
        }
    

    }
}
