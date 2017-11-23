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
        private string ConectString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;
        private string sqlscan = @"select doceco.specid , doceco.keyid , doceco.keyid 
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

           
            if (count > 0)
            {
               ///
            }
            else if (count ==0)
            {
                ex_oracle.Visible = true;
                datatextfinish.Visible = true;
                datatextstart.Visible = true;
                fordat.Visible = true;
                indat.Visible = true;
                yearBox.Enabled = false;
                MonthBox.Enabled = false;
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
            VozTablLO.AddInsertParametr("tcountry", OracleType.VarChar, 5, "LO");
            VozTablLO.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "SPECID");
            VozTablLO.AddInsertParametrGrid("tSUMVOZ", OracleType.Number, 12, "SUMVOZ");
            VozTablLO.AddInsertParametrGrid("tPOS", OracleType.Number, 12, "POS");
            VozTablLO.AddInsertParametrGrid("tOBR", OracleType.Number, 12, "OBR");
            VozTablLO.AddInsertParametrGrid("tQTY", OracleType.Number, 12, "QTY");
            VozTablLO.AddInsertParametrGrid("tUET", OracleType.Number, 12, "UET");
            VozTablLO.AddInsertParametr("tdatas", OracleType.DateTime, 6, DateTime.Today);
            VozTablLO.AddInsertParametr("tdatef", OracleType.DateTime, 6, DateTime.Today);
            VozTablLO.AddInsertParametr("tYEAR", OracleType.Number, 5, (int.Parse(yearBox.Text)));
            VozTablLO.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.Text.ToString());
            VozTablLO.AddInsertParametr("v_cunt", OracleType.Number, 5, 0);




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
        }
    }
}
