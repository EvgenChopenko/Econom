using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    
    public partial class dohod : Form
    {
        private Home father;
        private dohodset DohTablLO;
        private dohodset DohTablSPB;
        private dohodset DohTablALL;
        private int count;
        private DateTime dates=DateTime.Today;
        private DateTime datef= DateTime.Today;
        private string ConectString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;
        private string sqlscan = @"select doceco.specid , doceco.keyid , doceco.DATASTART,doceco.DATAFINISH
                                    from docplan_eco doceco 
                                    where doceco.DATATEXT = :Moths 
                                    and doceco.YEAR = :year";

        private string sqlselectLO = @"select pl.keyid, pl.SUMDOH,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_income_TABL_LO pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private string sqlselectSPB = @"select pl.keyid, pl.SUMDOH,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_income_TABL_RF pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private string sqlselectALL = @"select pl.keyid, pl.SUMDOH,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_income_TABL_ALL pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";

        private string SqlDohLO = @"
select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE NOT LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
and i.AGRID != 435
group by get_specdocid(v.num)";
        private string SqlDohSPB = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE NOT LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
and i.AGRID = 435
group by get_specdocid(v.num)";
        private string SqlDohALL = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE NOT LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
group by get_specdocid(v.num)";

        private string sqlinsert = @"Int_income_Inv_TABL";
        private string sqlupdate = @"UPT_income_INV_TABL";
        private string sqldelet= @"Delincome_TABL";

        public dohod()
        {
            InitializeComponent();
            this.MonthBox.DataSource = Program.GETMonths();
            this.yearBox.DataSource = Program.GETYERS();
        }
        public dohod(Home father)
        {
            InitializeComponent();
            this.father = father;
            this.MonthBox.DataSource = Program.GETMonths();
            this.yearBox.DataSource = Program.GETYERS();
        }

        private void scan_Click(object sender, EventArgs e)
        {
            Scan scan = new Scan(ConectString, "MED", "DOCPLAN");
           scan.setselectcomand(sqlscan, CommandType.Text);
            scan.AddSelectParametr(":Moths", this.MonthBox.Text);
            scan.AddSelectParametr(":year", OracleType.Number, 5, this.yearBox.Text);
            scan.adapterinstal();

           count= (int)scan.count(scan.Ds.Tables["DOCPLAN"], "KEYID");
            this.scan.Enabled = false;
            this.MonthBox.Enabled = false;
            this.yearBox.Enabled = false;
            
            if (count > 0)
            {
                ///
                fordat.Visible = true;
                indat.Visible = true;
                dates = scan.datastart(scan.Ds.Tables["DOCPLAN"]);
                datef = scan.datafinish(scan.Ds.Tables["DOCPLAN"]);
                this.indat.Text = dates.ToString();
                this.fordat.Text = datef.ToString();
                datatextfinish.Visible = true;
                datatextstart.Visible = true;
                button2.Visible = true;

            }
            else if (count ==0)
            {
               // ex_oracle.Visible = true;
                datatextfinish.Visible = true;
                datatextstart.Visible = true;
                fordat.Visible = true;
                indat.Visible = true;
                yearBox.Enabled = false;
                MonthBox.Enabled = false;
                button2.Visible = true;

                this.indat.Text = dates.ToString();
                this.fordat.Text = datef.ToString();
            }
        }

        private void vozvrat_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.LUTAG9". При необходимости она может быть перемещена или удалена.
            this.lUTAG9TableAdapter.Fill(this.dataSet1.LUTAG9);

            DohTablLO = new dohodset(ConectString,"MED","inv_income_tabl_LO" );
         DohTablSPB= new dohodset(ConectString, "MED", "inv_income_tabl_SPB");
        DohTablALL= new dohodset(ConectString, "MED", "inv_income_tabl_ALL");

            DohTablLO.setselectcomand(sqlselectLO, CommandType.Text);
            DohTablLO.AddSelectParametr(":Month", this.MonthBox.Text);
            DohTablLO.AddSelectParametr(":year", OracleType.Number, 5, yearBox.SelectedValue);

            //---------------------------------------------------------------------------------

            DohTablLO.setinsertcomand(sqlinsert, CommandType.StoredProcedure);
            DohTablLO.AddInsertParametr("tcountry", OracleType.VarChar, 5, "LO");
            DohTablLO.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            DohTablLO.AddInsertParametrGrid("tSUMDOH", OracleType.Number, 12, "SUMDOH");
            DohTablLO.AddInsertParametrGrid("tPOS", OracleType.Number, 12, "POS");
            DohTablLO.AddInsertParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            DohTablLO.AddInsertParametrGrid("tQTY",OracleType.Number,12,"QTY");
            DohTablLO.AddInsertParametrGrid("tUET", OracleType.Number, 12, "UET");
            DohTablLO.AddInsertParametr("tdatas", OracleType.DateTime, 6,DateTime.Today);
            DohTablLO.AddInsertParametr("tdatef", OracleType.DateTime, 6, DateTime.Today);
           // DohTablLO.AddInsertParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
            //DohTablLO.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablLO.AddInsertParametr("v_cunt", OracleType.Number, 5, 0);

            DohTablLO.setdeletcomand(sqldelet, CommandType.StoredProcedure);
            DohTablLO.AddDeletParametr("tcountry", OracleType.VarChar, 5, "LO");
            DohTablLO.AddDeletParametrGrid("tkeyid", OracleType.Number, 12, "keyid");

            DohTablLO.setupdatecomand(sqlupdate, CommandType.StoredProcedure);
            DohTablLO.AddUpdateParametr("tcountry", OracleType.VarChar, 5, "LO");
            DohTablLO.AddUpdateParametrGrid("tkeyid", OracleType.Number, 12, "keyid");
            DohTablLO.AddUpdateParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            DohTablLO.AddUpdateParametrGrid("tSUMDOH", OracleType.Number, 12, "SUMDOH");
            DohTablLO.AddUpdateParametrGrid("tPOS", OracleType.Number, 12, "POS");
            DohTablLO.AddUpdateParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            DohTablLO.AddUpdateParametrGrid("tQTY", OracleType.Number, 12, "QTY");
            DohTablLO.AddUpdateParametrGrid("tUET", OracleType.Number, 12, "UET");
          //  DohTablLO.AddUpdateParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
           // DohTablLO.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);





            DohTablLO.adapterinstal();
            ///----------------------------------------------------------------------------------------------------------------------------------------
            ///

            DohTablSPB.setselectcomand(sqlselectSPB, CommandType.Text);
            DohTablSPB.AddSelectParametr(":Month", this.MonthBox.Text);
            DohTablSPB.AddSelectParametr(":year", OracleType.Number, 5, yearBox.SelectedValue);
            //------------------------------------------------------------------------------------------------------------------
            DohTablSPB.setinsertcomand(sqlinsert, CommandType.StoredProcedure);
            DohTablSPB.AddInsertParametr("tcountry", OracleType.VarChar, 5, "RF");
            DohTablSPB.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            DohTablSPB.AddInsertParametrGrid("tSUMDOH", OracleType.Number, 12, "SUMDOH");
            DohTablSPB.AddInsertParametrGrid("tPOS", OracleType.Number, 12, "POS");
            DohTablSPB.AddInsertParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            DohTablSPB.AddInsertParametrGrid("tUET", OracleType.Number, 12, "UET");
            DohTablSPB.AddInsertParametr("tdatas", OracleType.DateTime, 6, DateTime.Today);
            DohTablSPB.AddInsertParametr("tdatef", OracleType.DateTime, 6, DateTime.Today);
           // DohTablSPB.AddInsertParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
           // DohTablSPB.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablSPB.AddInsertParametr("v_cunt", OracleType.Number, 5, 0);

            DohTablSPB.setdeletcomand(sqldelet, CommandType.StoredProcedure);
            DohTablSPB.AddDeletParametr("tcountry", OracleType.VarChar, 5, "RF");
            DohTablSPB.AddDeletParametrGrid("tkeyid", OracleType.Number, 12, "keyid");

            DohTablSPB.setupdatecomand(sqlupdate, CommandType.StoredProcedure);
            DohTablSPB.AddUpdateParametr("tcountry", OracleType.VarChar, 5, "RF");
            DohTablSPB.AddUpdateParametrGrid("tkeyid", OracleType.Number, 12, "keyid");
            DohTablSPB.AddUpdateParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            DohTablSPB.AddUpdateParametrGrid("tSUMDOH", OracleType.Number, 12, "SUMDOH");
            DohTablSPB.AddUpdateParametrGrid("tPOS", OracleType.Number, 12, "POS");
            DohTablSPB.AddUpdateParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            DohTablSPB.AddUpdateParametrGrid("tQTY", OracleType.Number, 12, "QTY");
            DohTablSPB.AddUpdateParametrGrid("tUET", OracleType.Number, 12, "UET");
          ///  DohTablSPB.AddUpdateParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
           // DohTablSPB.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);


            DohTablSPB.adapterinstal();


            ///-----------------------------------------------------------------------------------------------------------------------------------------
            ///
            DohTablALL.setselectcomand(sqlselectALL, CommandType.Text);
            DohTablALL.AddSelectParametr(":Month", this.MonthBox.Text);
            DohTablALL.AddSelectParametr(":year", OracleType.Number, 5, yearBox.SelectedValue);

            //--------------------------------------------------------------------------------------------------------------------------------------------------------
            DohTablALL.setinsertcomand(sqlinsert, CommandType.StoredProcedure);
            DohTablALL.AddInsertParametr("tcountry", OracleType.VarChar, 5, "ALL");
            DohTablALL.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            DohTablALL.AddInsertParametrGrid("tSUMDOH", OracleType.Number, 12, "SUMDOH");
            DohTablALL.AddInsertParametrGrid("tPOS", OracleType.Number, 12, "POS");
            DohTablALL.AddInsertParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            DohTablALL.AddInsertParametrGrid("tUET", OracleType.Number, 12, "UET");
            DohTablALL.AddInsertParametr("tdatas", OracleType.DateTime, 6, DateTime.Today);
            DohTablALL.AddInsertParametr("tdatef", OracleType.DateTime, 6, DateTime.Today);
          //  DohTablALL.AddInsertParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
          //  DohTablALL.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablALL.AddInsertParametr("v_cunt", OracleType.Number, 5, 0);

            DohTablALL.setdeletcomand(sqldelet, CommandType.StoredProcedure);
            DohTablALL.AddDeletParametr("tcountry", OracleType.VarChar, 5, "ALL");
            DohTablALL.AddDeletParametrGrid("tkeyid", OracleType.Number, 12, "keyid");

            DohTablALL.setupdatecomand(sqlupdate, CommandType.StoredProcedure);
            DohTablALL.AddUpdateParametr("tcountry", OracleType.VarChar, 5, "ALL");
            DohTablALL.AddUpdateParametrGrid("tkeyid", OracleType.Number, 12, "keyid");
            DohTablALL.AddUpdateParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            DohTablALL.AddUpdateParametrGrid("tSUMDOH", OracleType.Number, 12, "SUMDOH");
            DohTablALL.AddUpdateParametrGrid("tPOS", OracleType.Number, 12, "POS");
            DohTablALL.AddUpdateParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            DohTablALL.AddUpdateParametrGrid("tQTY", OracleType.Number, 12, "QTY");
            DohTablALL.AddUpdateParametrGrid("tUET", OracleType.Number, 12, "UET");
           // DohTablALL.AddUpdateParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
          //  DohTablALL.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);





            DohTablALL.adapterinstal();

            this.datageidlo.DataSource = DohTablLO.GetDataView();
            datagridspbrf.DataSource = DohTablSPB.GetDataView();
            datagridspbrflo.DataSource =DohTablALL.GetDataView();





        }

        

        private void datageidlo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             DohTablALL.AddUpdateParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
             DohTablALL.AddInsertParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
             DohTablSPB.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablSPB.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
              DohTablLO.AddUpdateParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
             DohTablLO.AddInsertParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
              DohTablSPB.AddUpdateParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
            DohTablSPB.AddInsertParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
             DohTablLO.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablLO.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablSPB.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
             DohTablSPB.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);



            DohTablLO.UpdateDB();
            DohTablALL.UpdateDB();
            DohTablSPB.UpdateDB();
           
            father.Enabled = true;
            father.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dates != null && datef != null)
            {
                button2.Enabled = false;
                ex_oracle.Visible = true;
                indat.Enabled = false;
                fordat.Enabled = false;
                this.dates = DateTime.Parse( indat.Text);
                this.datef = DateTime.Parse(fordat.Text);
            }
        }

        private void ex_oracle_Click(object sender, EventArgs e)
        {



            Vozvratset LO = new Vozvratset(ConectString, "MED", "LO");
            Vozvratset SPB = new Vozvratset(ConectString, "MED", "SPB");
            Vozvratset ALL = new Vozvratset(ConectString, "MED", "ALL");
            LO.setselectcomand(SqlDohLO, CommandType.Text);
            LO.AddSelectParametr(":DATES", OracleType.DateTime, 6, this.dates);
            LO.AddSelectParametr(":DATEf", OracleType.DateTime, 6, this.datef);

            SPB.setselectcomand(SqlDohSPB, CommandType.Text);
            SPB.AddSelectParametr(":DATES", OracleType.DateTime, 6, this.dates);
            SPB.AddSelectParametr(":DATEf", OracleType.DateTime, 6, this.datef);

            ALL.setselectcomand(SqlDohALL, CommandType.Text);
            ALL.AddSelectParametr(":DATES", OracleType.DateTime, 6, this.dates);
            ALL.AddSelectParametr(":DATEf", OracleType.DateTime, 6, this.datef);
            long iMaxLO = DohTablLO.maxkeid(DohTablLO.Ds.Tables["inv_income_tabl_LO"], "keyid");
            


            long iMaxSPB = DohTablSPB.maxkeid(DohTablSPB.Ds.Tables["inv_income_tabl_SPB"], "keyid");
            long iMaxALL = DohTablALL.maxkeid(DohTablALL.Ds.Tables["inv_income_tabl_ALL"], "keyid");
           
            LO.dataColumn("keyid", "System.Int32", iMaxLO, 1);
            SPB.dataColumn("keyid", "System.Int32", iMaxSPB, 1);
            ALL.dataColumn("keyid", "System.Int32", iMaxALL, 1);



            SPB.adapterinstal();
            LO.adapterinstal();
            ALL.adapterinstal();

            DohTablALL.load(ALL.Dt, "inv_income_tabl_ALL");
            DohTablSPB.load(SPB.Dt, "inv_income_tabl_SPB");
            DohTablLO.load(LO.Dt, "inv_income_tabl_LO");
        }

        private void dohod_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (father != null)
            {
                father.Enabled = true;
                father.Dohod = null;
            }
            
            
        }

        private void MonthBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

           
            DohTablALL.AddSelectParametr(":Month", this.MonthBox.SelectedValue);
            DohTablALL.Dt.Clear();

         
            DohTablSPB.AddSelectParametr(":Month", this.MonthBox.SelectedValue);
            DohTablSPB.Dt.Clear();

          
            DohTablLO.AddSelectParametr(":Month", this.MonthBox.SelectedValue);
            DohTablLO.Dt.Clear();


            DohTablLO.adapterinstal();
            DohTablSPB.adapterinstal();
            DohTablALL.adapterinstal();

        }

        private void yearBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            DohTablALL.AddSelectParametr(":year", this.yearBox.SelectedValue);
            DohTablALL.Dt.Clear();

         
            DohTablSPB.AddSelectParametr(":year", this.yearBox.SelectedValue);
            DohTablSPB.Dt.Clear();
          
        
            DohTablLO.AddSelectParametr(":year", this.yearBox.SelectedValue);
            DohTablLO.Dt.Clear();


            DohTablLO.adapterinstal();
            DohTablSPB.adapterinstal();
            DohTablALL.adapterinstal();
        }
    }
}
