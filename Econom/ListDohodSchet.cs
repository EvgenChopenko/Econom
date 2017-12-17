using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    public partial class ListDohodSchet : Form
    {
        private dohodset LO = null;
        private dohodset SPB = null;
        private dohodset ListSPBLO = null;
        private string atr = "";
        public string LOBILL = "";
        public string SPBBILL = "";
        private dohod Father = null;
        private string ListSchet = "";


        public ListDohodSchet()
        {
            InitializeComponent();
            DateLORun(DateTime.Now, DateTime.Now);
            DateSPBRun(DateTime.Now, DateTime.Now);
            this.DataGridListLo.DataSource = LO.GetDataView();
            this.DataGridListSpb.DataSource = LO.GetDataView();
        }

        private void DateLORun(DateTime datas, DateTime dataf)
        {
            LO = new dohodset(EconomLibrary.BD.Connection_GET, "MED", "LOLIST");
            LO.setselectcomand(EconomLibrary.Select.SelectListScheta_LO());
            LO.AddSelectParametr(":DATES", OracleType.DateTime, 6, datas);
            LO.AddSelectParametr(":DATEf", OracleType.DateTime, 6, dataf);
            LO.adapterinstal();
        }

      

        private void DateSPBRun(DateTime datas, DateTime dataf)
        {
            SPB = new dohodset(EconomLibrary.BD.Connection_GET, "MED", "SPBLIST");
            SPB.setselectcomand(EconomLibrary.Select.SelectListScheta_SPB());
            SPB.AddSelectParametr(":DATES", OracleType.DateTime, 6, datas);
            SPB.AddSelectParametr(":DATEf", OracleType.DateTime, 6, dataf);
            SPB.adapterinstal();
        }

        public ListDohodSchet(DateTime datas, DateTime dataf)
        {
            InitializeComponent();

            DateLORun(datas, dataf);
            DateSPBRun(datas, dataf);

            this.DataGridListLo.DataSource = LO.GetDataView();
            this.DataGridListSpb.DataSource = SPB.GetDataView();

        }


        public ListDohodSchet(DateTime datas, DateTime dataf , dohod Father)
        {
            InitializeComponent();
            this.Father = Father; 
            DateLORun(datas, dataf);
            DateSPBRun(datas, dataf);

            this.DataGridListLo.DataSource = LO.GetDataView();
            this.DataGridListSpb.DataSource = SPB.GetDataView();

        }

        private void AddSchet_Click(object sender, EventArgs e)
        {
            LOBILL = LO.ListKeyidTostring("BILLSID");
          SPBBILL = SPB.ListKeyidTostring("BILLSID");

           
            string commands=LOBILL+"," + SPBBILL;
            commands = commands.TrimEnd(',');
            commands = commands.TrimStart(',');
         
           ListSPBLO = new dohodset(EconomLibrary.BD.Connection_GET, "MED", "LOLIST");

            if (commands.Length != 0)
            {
                
                ListSPBLO.setselectcomand(EconomLibrary.Select.SelectListScheta_ALL_NOMAS(commands));
            }else
            {
                ListSPBLO.setselectcomand(EconomLibrary.Select.SelectListScheta_ALL_NODATE());
            }
            
          
            ListSPBLO.adapterinstal();

            Bill s = new Bill(ListSPBLO.Dt,this);
            s.Show();
            this.Enabled = false;
        }

        public void CallBack(string atr)
        {
            this.atr = atr;
       
            NewBills();

        }
        private void NewBills()
        {
            LOBILL = LOBILL+","+atr.TrimEnd(',');
            SPBBILL = SPBBILL +","+ atr.TrimEnd(',');
            LOBILL=LOBILL.TrimStart(',');
            SPBBILL=SPBBILL.TrimStart(',');
        

            dohodset lobill = new dohodset(EconomLibrary.BD.Connection_GET, "MED", "LOLIST");
            lobill.setselectcomand(EconomLibrary.Select.SelectListScheta_LO_NOMAS(LOBILL));
            lobill.adapterinstal();

            dohodset spbbill = new dohodset(EconomLibrary.BD.Connection_GET, "MED", "SPBLIST");
            spbbill.setselectcomand(EconomLibrary.Select.SelectListScheta_SPB_NOMAS(SPBBILL));
            spbbill.adapterinstal();

            DataGridListLo.DataSource = lobill.GetDataView();
            DataGridListSpb.DataSource = spbbill.GetDataView();
        }

        private void LOADOBJECT_Click(object sender, EventArgs e)
        {
            mathlistschet();
            if (!(this.Father is null)){
                Father.Atr = ListSchet;
                Father.run();
            }

            this.Hide();
        }

        private void mathlistschet()
        {
            int i = 0;
            string s = "";
            if (DataGridListLo.RowCount != 0)
            {
                while (i < DataGridListLo.RowCount - 1)
                {


                    s += (DataGridListLo["BILLSID", i].Value.ToString() + ",");
                    i++;

                }
            }

           
            i = 0;
            if (DataGridListSpb.RowCount != 0)
            {
                while (i < DataGridListSpb.RowCount - 1)
                {


                    s += (DataGridListSpb["SPBBILLSID", i].Value.ToString() + ",");

                    i++;
                }
            }
          
            s = s.TrimEnd(',');
            ListSchet = s;
        }
    }
}
