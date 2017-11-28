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
    public partial class Home : Form
    {
        private string tMonths="";
        private int tYera=0;
       private DatForm Time = null;

        private dohod dohod=null;
        private vozvrat vozvrat = null;
        private renouncement renouncement = null;

        private Plan Plan = null;

        public Home()
        {
            InitializeComponent();
        }

        public string TMonths { get => tMonths; set => tMonths = value; }
        public int TYera { get => tYera; set => tYera = value; }
        public dohod Dohod { get => dohod; set => dohod = value; }
        public vozvrat Vozvrat { get => vozvrat; set => vozvrat = value; }
        public renouncement Renouncement { get => renouncement; set => renouncement = value; }
        public Plan Plan1 { get => Plan; set => Plan = value; }

        private void СформироватьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Time = new DatForm(this);
            this.Enabled = false;
            Time.Show();

        }

        public void run()
        {
            
        }

        private void доходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Dohod is null)
            {
                Dohod = new dohod(this);
                this.Enabled = false;
                Dohod.Show();
            }
            else
            {
                this.Enabled = false;
                Dohod.Show();
            }
        }

        private void возвратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Vozvrat is null)
            {
                Vozvrat = new vozvrat(this);
                this.Enabled = false;
                Vozvrat.Show();
            }
            else
            {
                this.Enabled = false;
                Vozvrat.Show();
            }
        }

        private void отказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Renouncement is null)
            {
                Renouncement = new renouncement(this);
                this.Enabled = false;
                Renouncement.Show();
            }
            else
            {
                this.Enabled = false;
                Renouncement.Show();
            }
        }

        private void планToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Plan1 is null)
            {
                Plan1 = new Plan(this);
                this.Enabled = false;
                Plan1.Show();
            }
            else
            {
                this.Enabled = false;
                Plan1.Show();
            }
        }
    }
}
