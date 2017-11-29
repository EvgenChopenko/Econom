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
        }

        public PlabCalc(Plan father)
        {
            InitializeComponent();
            this.father = father; 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PlabCalc_Load(object sender, EventArgs e)
        {
            

            
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
    }
}
