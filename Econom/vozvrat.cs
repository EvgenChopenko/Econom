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
    
    public partial class vozvrat : Form
    {
        private Vozvratset VozTablLO;
        private Vozvratset VozTablSPB;
        private Vozvratset VozTablALL;
        private int count;
        private DateTime dates=DateTime.Today;
        private DateTime datef= DateTime.Today;
        private string ConectString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;
        private string sqlscan = @"select doceco.specid , doceco.keyid , doceco.DATASTART,doceco.DATAFINISH
                                    from docplan_eco doceco 
                                    where doceco.DATATEXT = :Moths 
                                    and doceco.YEAR = :year";

        private string sqlselectLO = @"select pl.keyid, pl.SUMVOZ,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_REF_TABL_LO pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private string sqlselectSPB = @"select pl.keyid, pl.SUMVOZ,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_REF_TABL_RF pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private string sqlselectALL = @"select pl.keyid, pl.SUMVOZ,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_REF_TABL_ALL pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";

        private string SqlVozLO = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMVOZ,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
and i.AGRID != 435
group by get_specdocid(v.num)";
        private string SqlVozSPB = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMVOZ,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
and i.AGRID = 435
group by get_specdocid(v.num)";
        private string SqlVozALL = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMVOZ,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
group by get_specdocid(v.num)";

        private string sqlinsert = @"Int_REF_Inv_TABL";
        private string sqlupdate = @"UPT_REF_INV_TABL";
        private string sqldelet= @"DelRef_TABL";

        public vozvrat()
        {
            InitializeComponent();
            this.MonthBox.Text = MonthBox.Items[0].ToString();
            this.yearBox.Text = yearBox.Items[0].ToString();
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

            VozTablLO = new Vozvratset(ConectString,"MED","inv_ref_tabl_LO" );
         VozTablSPB= new Vozvratset(ConectString, "MED", "inv_ref_tabl_SPB");
        VozTablALL= new Vozvratset(ConectString, "MED", "inv_ref_tabl_ALL");

            VozTablLO.setselectcomand(sqlselectLO, CommandType.Text);
            VozTablLO.AddSelectParametr(":Month", this.MonthBox.Text);
            VozTablLO.AddSelectParametr(":year", OracleType.Number, 5, this.yearBox.Text);

            //---------------------------------------------------------------------------------
         
            VozTablLO.setinsertcomand(sqlinsert, CommandType.StoredProcedure);         
            VozTablLO.AddInsertParametr("tcountry", OracleType.VarChar, 5, "LO");
            VozTablLO.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            VozTablLO.AddInsertParametrGrid("tSUMVOZ", OracleType.Number, 12, "SUMVOZ");
            VozTablLO.AddInsertParametrGrid("tPOS", OracleType.Number, 12, "POS");
            VozTablLO.AddInsertParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            VozTablLO.AddInsertParametrGrid("tQTY",OracleType.Number,12,"QTY");
            VozTablLO.AddInsertParametrGrid("tUET", OracleType.Number, 12, "UET");
            VozTablLO.AddInsertParametr("tdatas", OracleType.DateTime, 6,DateTime.Today);
            VozTablLO.AddInsertParametr("tdatef", OracleType.DateTime, 6, DateTime.Today);
            VozTablLO.AddInsertParametr("tYEAR", OracleType.Number, 5, (int.Parse(yearBox.Text)));
            VozTablLO.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.Text.ToString());
            VozTablLO.AddInsertParametr("v_cunt", OracleType.Number, 5, 0);

            VozTablLO.setdeletcomand(sqldelet, CommandType.StoredProcedure);
            VozTablLO.AddDeletParametr("tcountry", OracleType.VarChar, 5, "LO");
            VozTablLO.AddDeletParametrGrid("tkeyid", OracleType.Number, 12, "keyid");

            VozTablLO.setupdatecomand(sqlupdate, CommandType.StoredProcedure);
            VozTablLO.AddUpdateParametr("tcountry", OracleType.VarChar, 5, "LO");
            VozTablLO.AddUpdateParametrGrid("tkeyid", OracleType.Number, 12, "keyid");
            VozTablLO.AddUpdateParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            VozTablLO.AddUpdateParametrGrid("tSUMVOZ", OracleType.Number, 12, "SUMVOZ");
            VozTablLO.AddUpdateParametrGrid("tPOS", OracleType.Number, 12, "POS");
            VozTablLO.AddUpdateParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            VozTablLO.AddUpdateParametrGrid("tQTY", OracleType.Number, 12, "QTY");
            VozTablLO.AddUpdateParametrGrid("tUET", OracleType.Number, 12, "UET");
            VozTablLO.AddUpdateParametr("tYEAR", OracleType.Number, 5, (int.Parse(yearBox.Text)));
            VozTablLO.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.Text.ToString());
           




            VozTablLO.adapterinstal();
            ///----------------------------------------------------------------------------------------------------------------------------------------
            ///

            VozTablSPB.setselectcomand(sqlselectSPB, CommandType.Text);
            VozTablSPB.AddSelectParametr(":Month", this.MonthBox.Text);
            VozTablSPB.AddSelectParametr(":year", OracleType.Number, 5, this.yearBox.Text);
            //------------------------------------------------------------------------------------------------------------------
            VozTablSPB.setinsertcomand(sqlinsert, CommandType.StoredProcedure);           
            VozTablSPB.AddInsertParametr("tcountry", OracleType.VarChar, 5, "RF");
            VozTablSPB.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            VozTablSPB.AddInsertParametrGrid("tSUMVOZ", OracleType.Number, 12, "SUMVOZ");
            VozTablSPB.AddInsertParametrGrid("tPOS", OracleType.Number, 12, "POS");
            VozTablSPB.AddInsertParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            VozTablSPB.AddInsertParametrGrid("tUET", OracleType.Number, 12, "UET");
            VozTablSPB.AddInsertParametr("tdatas", OracleType.DateTime, 6, DateTime.Today);
            VozTablSPB.AddInsertParametr("tdatef", OracleType.DateTime, 6, DateTime.Today);
            VozTablSPB.AddInsertParametr("tYEAR", OracleType.Number, 5, (int.Parse(yearBox.Text)));
            VozTablSPB.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.Text.ToString());
            VozTablSPB.AddInsertParametr("v_cunt", OracleType.Number, 5, 0);

            VozTablSPB.setdeletcomand(sqldelet, CommandType.StoredProcedure);
            VozTablSPB.AddDeletParametr("tcountry", OracleType.VarChar, 5, "RF");
            VozTablSPB.AddDeletParametrGrid("tkeyid", OracleType.Number, 12, "keyid");

            VozTablSPB.setupdatecomand(sqlupdate, CommandType.StoredProcedure);
            VozTablSPB.AddUpdateParametr("tcountry", OracleType.VarChar, 5, "RF");
            VozTablSPB.AddUpdateParametrGrid("tkeyid", OracleType.Number, 12, "keyid");
            VozTablSPB.AddUpdateParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            VozTablSPB.AddUpdateParametrGrid("tSUMVOZ", OracleType.Number, 12, "SUMVOZ");
            VozTablSPB.AddUpdateParametrGrid("tPOS", OracleType.Number, 12, "POS");
            VozTablSPB.AddUpdateParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            VozTablSPB.AddUpdateParametrGrid("tQTY", OracleType.Number, 12, "QTY");
            VozTablSPB.AddUpdateParametrGrid("tUET", OracleType.Number, 12, "UET");
            VozTablSPB.AddUpdateParametr("tYEAR", OracleType.Number, 5, (int.Parse(yearBox.Text)));
            VozTablSPB.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.Text.ToString());


            VozTablSPB.adapterinstal();


            ///-----------------------------------------------------------------------------------------------------------------------------------------
            ///
            VozTablALL.setselectcomand(sqlselectALL, CommandType.Text);
            VozTablALL.AddSelectParametr(":Month", this.MonthBox.Text);
            VozTablALL.AddSelectParametr(":year", OracleType.Number, 5, this.yearBox.Text);

            //--------------------------------------------------------------------------------------------------------------------------------------------------------
            VozTablALL.setinsertcomand(sqlinsert, CommandType.StoredProcedure);
            VozTablALL.AddInsertParametr("tcountry", OracleType.VarChar, 5, "ALL");
            VozTablALL.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            VozTablALL.AddInsertParametrGrid("tSUMVOZ", OracleType.Number, 12, "SUMVOZ");
            VozTablALL.AddInsertParametrGrid("tPOS", OracleType.Number, 12, "POS");
            VozTablALL.AddInsertParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            VozTablALL.AddInsertParametrGrid("tUET", OracleType.Number, 12, "UET");
            VozTablALL.AddInsertParametr("tdatas", OracleType.DateTime, 6, DateTime.Today);
            VozTablALL.AddInsertParametr("tdatef", OracleType.DateTime, 6, DateTime.Today);
            VozTablALL.AddInsertParametr("tYEAR", OracleType.Number, 5, (int.Parse(yearBox.Text)));
            VozTablALL.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.Text.ToString());
            VozTablALL.AddInsertParametr("v_cunt", OracleType.Number, 5, 0);

            VozTablALL.setdeletcomand(sqldelet, CommandType.StoredProcedure);
            VozTablALL.AddDeletParametr("tcountry", OracleType.VarChar, 5, "ALL");
            VozTablALL.AddDeletParametrGrid("tkeyid", OracleType.Number, 12, "keyid");

            VozTablALL.setupdatecomand(sqlupdate, CommandType.StoredProcedure);
            VozTablALL.AddUpdateParametr("tcountry", OracleType.VarChar, 5, "ALL");
            VozTablALL.AddUpdateParametrGrid("tkeyid", OracleType.Number, 12, "keyid");
            VozTablALL.AddUpdateParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            VozTablALL.AddUpdateParametrGrid("tSUMVOZ", OracleType.Number, 12, "SUMVOZ");
            VozTablALL.AddUpdateParametrGrid("tPOS", OracleType.Number, 12, "POS");
            VozTablALL.AddUpdateParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            VozTablALL.AddUpdateParametrGrid("tQTY", OracleType.Number, 12, "QTY");
            VozTablALL.AddUpdateParametrGrid("tUET", OracleType.Number, 12, "UET");
            VozTablALL.AddUpdateParametr("tYEAR", OracleType.Number, 5, (int.Parse(yearBox.Text)));
            VozTablALL.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.Text.ToString());





            VozTablALL.adapterinstal();

            this.datageidlo.DataSource = VozTablLO.GetDataView();
            datagridspbrf.DataSource = VozTablSPB.GetDataView();
            datagridspbrflo.DataSource = VozTablALL.GetDataView();





        }

        private void datageidlo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VozTablLO.UpdateDB();
            VozTablALL.UpdateDB();
            VozTablSPB.UpdateDB();
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
            LO.setselectcomand(SqlVozLO, CommandType.Text);
            LO.AddSelectParametr(":DATES", OracleType.DateTime, 6, this.dates);
            LO.AddSelectParametr(":DATEf", OracleType.DateTime, 6, this.datef);

            SPB.setselectcomand(SqlVozSPB, CommandType.Text);
            SPB.AddSelectParametr(":DATES", OracleType.DateTime, 6, this.dates);
            SPB.AddSelectParametr(":DATEf", OracleType.DateTime, 6, this.datef);

            ALL.setselectcomand(SqlVozALL, CommandType.Text);
            ALL.AddSelectParametr(":DATES", OracleType.DateTime, 6, this.dates);
            ALL.AddSelectParametr(":DATEf", OracleType.DateTime, 6, this.datef);
            long iMaxLO = VozTablLO.maxkeid(VozTablLO.Ds.Tables["inv_ref_tabl_LO"], "keyid");
            //"System.Int32"


            long iMaxSPB = VozTablSPB.maxkeid(VozTablSPB.Ds.Tables["inv_ref_tabl_SPB"], "keyid");
            long iMaxALL = VozTablALL.maxkeid(VozTablALL.Ds.Tables["inv_ref_tabl_ALL"], "keyid");
           // MessageBox.Show("" + iMaxALL + iMaxLO + iMaxSPB);
            LO.dataColumn("keyid", "System.Int32", iMaxLO, 1);
            SPB.dataColumn("keyid", "System.Int32", iMaxSPB, 1);
            ALL.dataColumn("keyid", "System.Int32", iMaxALL, 1);



            SPB.adapterinstal();
            LO.adapterinstal();
            ALL.adapterinstal();

            VozTablALL.load(ALL.Dt, "inv_ref_tabl_ALL");
            VozTablSPB.load(SPB.Dt, "inv_ref_tabl_SPB");
            VozTablLO.load(LO.Dt, "inv_ref_tabl_LO");
        }
    }
}
