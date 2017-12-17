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
    public partial class Bill : Form
    {
        private ListDohodSchet Father = null;
        private string check_atr="";
        public Bill()
        {
            InitializeComponent();
        }

        public Bill(DataTable DT,ListDohodSchet Father)
        {
            InitializeComponent();
           this.DataGridBill.DataSource = DT;
            this.Father = Father;
          
        }

        private void AddSchet_Click(object sender, EventArgs e)
            
        {
           
            int i = 0;
            while (i < DataGridBill.RowCount)
            {

                if (DataGridBill["Check", i].Value is true)
                {
                    check_atr += (DataGridBill["BILLSID", i].Value.ToString() + ",");
                }
                i++;

            }
            check_atr = check_atr.TrimEnd(',');
          this.Father.CallBack(check_atr);
            Father.Enabled = true;
        }

        private void Bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            Father.Enabled = true;
        }
    }
}
