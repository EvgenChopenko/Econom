using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    public partial class BILLS : Form
    {
        private Bilssset bill;
        private renouncement renouncements;
        public BILLS()
        {
            InitializeComponent();
        }
        private string sqlcomand = @"SELECT DAT,b.BUHCODE||' '||ag.TEXT as TEXT, 
b.AMOUNT,b.code,b.AGRID,b.keyid , 
TO_CHAR( b.BGNDAT ||' - '|| b.ENDDAT) as datfull 
from bill b, AGR ag where b.AGRID= ag.keyid(+) 
and ag.FINANCE=5";
        private string connectionString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;
        private void BILLS_Load(object sender, EventArgs e)
        {
             bill = new Bilssset(connectionString,sqlcomand,"MED", "bill");
            dataGridView1.DataSource = bill.GetDataView();
            this.dataGridView1.Width = this.groupBox1.Width-10;
            this.dataGridView1.Height = (Height - this.groupBox1.Height) - 50;
        }

        private void BILLS_SizeChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.groupBox1.Width - 10;
            this.dataGridView1.Height = (Height - this.groupBox1.Height) - 50;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bill = new Bilssset(connectionString, sqlcomand, "MED", "bill");
            dataGridView1.DataSource = bill.GetDataView();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void father(renouncement a)
        {
            renouncements = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            renouncements.call(bill.TOKEYID(this.dataGridView1, "ADD", "keyid"));
            this.Close();
        }
    }
}
