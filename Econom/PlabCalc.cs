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
        private bool flagRed = true;
        private int RowIndex = 0;
        private DataGridView DataGrid = null; 
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
            this.flagRed = true;
            this.MonthsYear.DataSource = Program.GETYERS();
            this.DataGrid = father.getdataview();
         


        }

        public PlabCalc(Plan father,bool flagREd)
        {
            InitializeComponent();
            this.father = father;
            this.MonthsBox.DataSource = Program.GETMonths();
            this.flagRed = flagREd;
            this.MonthsYear.DataSource = Program.GETYERS();
            this.redact.Checked = true;

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PlabCalc_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.LUTAG9". При необходимости она может быть перемещена или удалена.
            this.lUTAG9TableAdapter.Fill(this.dataSet1.LUTAG9);
            this.redact.Checked = false;
            groupBox1.Enabled = false;



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
            try
            {
                this.father.Calcwindows = null;
                this.father.Row1 = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:"+ ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            returndata(this.father.Ds,DataGrid,RowIndex);
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void DataMonthsYearDoc(object Months,object Year,object doc)
        {
            try
            {
                if (Months != null)
                    //MessageBox.Show(MonthsBox.SelectedValue.ToString()+Months.ToString());

                   MonthsBox.Text = Months.ToString();
                if (Year != null )

                     this.MonthsYear.Text = Year.ToString();
                   // MessageBox.Show(MonthsYear.SelectedValue.ToString());
                if (doc != null)
                    this.DocBox.SelectedValue = doc;
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка:" + e.Message);
            }




           

           
        }

        public void DataLO(string obr, string pos, string uet)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show("Ошибка:" + e.Message);
            }
        
                

         
        }
        public void DataSPB(string obr, string pos, string uet)
        {
            try
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
            catch (Exception e){
                MessageBox.Show("Ошибка:" + e.Message);

            }
          



        }
        public void DataSPBLO(string obr, string pos, string uet)
        {
            try
            {
                if (obr is null || obr == "")
                    obr = "0";
                if (pos is null || pos == "")
                    pos = "0";
                if (uet is null || uet == "")
                    uet = "0";



                SPBLOOBRBOX.Text = obr;
                SPBLOPOSBOX.Text = pos;
                SPBLOUETBOX.Text = uet;
            }
            catch (Exception e)
                { 
                MessageBox.Show("Ошибка:"+e.Message);
            }
           
        }

        public void DataSum(string LO,string SPB, string SPBLO)
        {
            /*
             * входные данные суммы доходов едеиниц lo spb spblo и сохранает в textbox 
             */
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
        public void SysDatein(object datas ,object dataf)
        {
            DateStart.Value = (DateTime)datas;
            DateFinish.Value = (DateTime)dataf;
        }
        public void SetRowindex(int RowIndex)
        {
            this.RowIndex = RowIndex;
        }




        private void redact_CheckedChanged(object sender, EventArgs e)
        {
            if (this.redact.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {

                groupBox1.Enabled = false;
            }

        
        }

        public void returndata(DataSet DS,DataGridView dataGrid,int Rowindex)
        {
            
            // DS.Tables["DOCPLAN_ECO"].Rows.Add(DR);



            if (flagRed)
               {
                //DS.Tables[].Rows[21].a
                dataGrid["specid", Rowindex].Value = DocBox.SelectedValue;
                dataGrid["PLANTOTAL", Rowindex].Value = decimal.Parse(ONESUMBOX.Text);
                dataGrid["POSPLANTOTAL", Rowindex].Value = decimal.Parse(SPBLOPOSBOX.Text);
                          dataGrid["OBRPLANTOTAL", Rowindex].Value =decimal.Parse(SPBLOOBRBOX.Text);
                            dataGrid["UETPLANOBR", Rowindex].Value = decimal.Parse(SPBLOUETBOX.Text);
                              dataGrid["LOPLANTOTAL", Rowindex].Value =decimal.Parse(ONESUMBOX.Text);
                                dataGrid["LOPOSPLANTOTAL", Rowindex].Value =decimal.Parse(LOPOSBOX.Text);
                                  dataGrid["LOOBRPLANTOTAL", Rowindex].Value =decimal.Parse(LOOBRBOX.Text);
                                  dataGrid["LOUETPLANOBR", Rowindex].Value =decimal.Parse(LOUETBOX.Text);
                                  dataGrid["SPBPLANTOTAL", Rowindex].Value =decimal.Parse(ONESUMBOX.Text);
                                  dataGrid["SPBPOSPLANTOTAL", Rowindex].Value = decimal.Parse(SPBPOSBOX.Text);
                                 dataGrid["SPBOBRPLANTOTAL", Rowindex].Value =decimal.Parse(SPBOBRBOX.Text);
                                  dataGrid["SPBUETPLANOBR", Rowindex].Value =decimal.Parse(SPBUETBOX.Text);
                dataGrid["YEAR", Rowindex].Value = int.Parse(MonthsYear.Text);
                dataGrid["DATATEXT", Rowindex].Value = MonthsBox.Text;
                ////
                dataGrid["DATASTART", Rowindex].Value = DateStart.Value;
                dataGrid["DATAFINISH", Rowindex].Value = DateFinish.Value;


            } else
               {
                DataRow DR = DS.Tables["DOCPLAN_ECO"].NewRow();
                DR["specid"] = DocBox.SelectedValue;
                ///
                DR["PLANTOTAL"] = decimal.Parse(ONESUMBOX.Text);
                DR["POSPLANTOTAL"] = decimal.Parse(SPBLOPOSBOX.Text);
                DR["OBRPLANTOTAL"] = decimal.Parse(SPBLOOBRBOX.Text);
                DR["UETPLANOBR"] = decimal.Parse(SPBLOUETBOX.Text);
                ///
                DR["LOPLANTOTAL"] = decimal.Parse(ONESUMBOX.Text);
                DR["LOPOSPLANTOTAL"] = decimal.Parse(LOPOSBOX.Text);
                DR["LOOBRPLANTOTAL"] = decimal.Parse(LOOBRBOX.Text);
                DR["LOUETPLANOBR"] = decimal.Parse(LOUETBOX.Text);
                ///
                DR["SPBPLANTOTAL"] = decimal.Parse(ONESUMBOX.Text);
                DR["SPBPOSPLANTOTAL"] = decimal.Parse(SPBPOSBOX.Text);
                DR["SPBOBRPLANTOTAL"] = decimal.Parse(SPBOBRBOX.Text);
                DR["SPBUETPLANOBR"] = decimal.Parse(SPBUETBOX.Text);
                ///
                DR["YEAR"] = int.Parse(MonthsYear.Text);
                DR["DATATEXT"] = MonthsBox.Text;
                ////
                DR["DATASTART"] = DateStart.Value;
                DR["DATAFINISH"] = DateFinish.Value;

                DS.Tables["DOCPLAN_ECO"].Rows.Add(DR);
               }


         
        }
        }
    }
