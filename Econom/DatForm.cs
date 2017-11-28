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


    public partial class DatForm : Form
    {   private  Home father =null;
        public DatForm()
        {
            InitializeComponent();
        }
        public DatForm(Home father)
        {
            InitializeComponent();
            this.father = father;
        }

        private void DatForm_Load(object sender, EventArgs e)
        {
            YearBox.DataSource = Program.GETYERS();
            MonthBox.DataSource = Program.GETMonths();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.father is null)
            {
                this.Close();
            }
            try
            {
                father.Enabled = true;
                father.TMonths = MonthBox.Text;
                father.TYera = int.Parse(YearBox.Text);
                father.run();
            }
            catch
            {
                MessageBox.Show("не все поля заполнены");
            }
            
            
            this.Close();
        }
    }
}
