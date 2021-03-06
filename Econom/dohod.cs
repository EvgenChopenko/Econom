﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EconomLibrary;

namespace Econom
{
    
    public partial class dohod : Form
    {
        private string atr="";
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

        private string SqlDohLO = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count( distinct v.num) as Obr,
count(distinct v.keyid) as Pos,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and (b.NOTE is null or b.NOTE NOT LIKE '%отказы%')
 and b.dat between :DATES and :DATEF and
 b.AGRID in (select g.keyid from agr g where g.keyid != 435 and  g.finance = 5 and g.STATUS =1)
group by get_specdocid(v.num)";
        private string SqlDohSPB = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count( distinct v.num) as Obr,
count(distinct v.keyid) as Pos,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and (b.NOTE is null or b.NOTE NOT LIKE '%отказы%') 
 and b.dat between :DATES and :DATEF
and b.AGRID = 435
group by get_specdocid(v.num)";
        private string SqlDohALL = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count( distinct v.num) as Obr,
count(distinct v.keyid) as Pos,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and (b.NOTE is null or b.NOTE NOT LIKE '%отказы%')
  and b.dat between :DATES and :DATEF and
 b.AGRID in (select g.keyid from agr g where g.finance = 5 and g.STATUS =1)
group by get_specdocid(v.num)";

        // and i.STATUS in (0) нужно будет добавить когда будет стационар ! 

        private string sqlinsert = @"Int_income_Inv_TABL";
        private string sqlupdate = @"UPT_income_INV_TABL";
        private string sqldelet= @"Delincome_TABL";

        public string Atr { get => atr; set => atr = value; }

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
            Scan scan = new Scan(EconomLibrary.BD.Connection_GET, "MED", "DOCPLAN");
           scan.setselectcomand(EconomLibrary.Select.Select_Scan());
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
              //  SelectParametrsList();

            }
            else if (count <=0)
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
            DohTablLO.AddInsertParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
            DohTablLO.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
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
           DohTablLO.AddUpdateParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
            DohTablLO.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);





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
            DohTablSPB.AddInsertParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
            DohTablSPB.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
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
            DohTablSPB.AddUpdateParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
            DohTablSPB.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);


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
           DohTablALL.AddInsertParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
           DohTablALL.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
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
           DohTablALL.AddUpdateParametr("tYEAR", OracleType.Number, 5, yearBox.SelectedValue);
           DohTablALL.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);





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

      private void TotalLORun()
        {
            Vozvratset TotalLO = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHLO");

            TotalLO.setselectcomand(EconomLibrary.Select.SelectListScheta_LO(Atr));
            TotalLO.adapterinstal();
            SchetaLO.DataSource = TotalLO.GetDataView();
        }

        private void TotalSPBRun()
        {
            Vozvratset TotalSPB = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalSPB.setselectcomand(EconomLibrary.Select.SelectListScheta_SPB(Atr));
            TotalSPB.adapterinstal();
            SchetaSPB.DataSource = TotalSPB.GetDataView();
        }

        private void DoH_US_ALL()
        {
            Vozvratset TotalSPB = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalSPB.setselectcomand(EconomLibrary.Select.SelectCommandsDoH_US_ALL(Atr));
            TotalSPB.adapterinstal();
            dataGridDohUS.DataSource = TotalSPB.GetDataView();



        }

        private void DoH_STOMA_ALL()
        {
            Vozvratset TotalSPB = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalSPB.setselectcomand(EconomLibrary.Select.SelectCommandsDoH_STOMA_ALL(Atr));
            TotalSPB.adapterinstal();
            DataGridSromaDoh.DataSource = TotalSPB.GetDataView();
        }

        private void Save_Bills_ALL()
        {

            OracleCommand comd = new OracleCommand(EconomLibrary.UpdateOracle.UpdateDohodParametrs_GET, EconomLibrary.BD.Connection_GET);
            comd.CommandType = CommandType.StoredProcedure;
            MessageBox.Show(EconomLibrary.UpdateOracle.UpdateDohodParametrs_GET);
            try
            {
                EconomLibrary.BD.Connection_GET.Open();
                comd.Parameters.Add("tparametrs", OracleType.NVarChar, 2000).Value= atr;
                comd.Parameters.Add("tMONTHS", OracleType.NVarChar, 14).Value=MonthBox.SelectedValue;
                comd.Parameters.Add("tYEAR", OracleType.Number, 50).Value= yearBox.SelectedValue;
                comd.Parameters.Add("fun", OracleType.Number, 50).Value= 0;
                comd.Parameters.Add("p_keyid", OracleType.Number, 50).Value=0;
                MessageBox.Show(comd.Parameters[0].Value.ToString());
                comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Ошибка"+ex.Message);
            }
            finally
            {
                EconomLibrary.BD.Connection_GET.Close();
            }
        
        }

        /*SelectParametrsList*/



        private void SelectParametrsList()
        {/*Ищим созданные счета и возвращаем их*/

            Vozvratset Atribute = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHLO");
            Atribute.setselectcomand(EconomLibrary.Select.SelectParametrsList());
            Atribute.AddSelectParametr(":MONTHS", OracleType.NChar, 255, MonthBox.SelectedValue);
            Atribute.AddSelectParametr(":YEAR", OracleType.Number, 5, yearBox.SelectedValue);
            Atribute.adapterinstal();
           this.atr= Atribute.Dt.Rows[0]["PARAMETRS"].ToString();

        }


        /* SelectSqlDoh_NOMASH_LO(string atr) запрос доходов с сохронение в ds дохода ЛО+ очистка*/
        private void SelectSqlDoh_NOMASH_LO()
        {          
             DohTablLO.DeletRows();             
             Vozvratset LO = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "LO");
             LO.setselectcomand(EconomLibrary.Select.SelectSqlDoh_NOMASH_LO(atr));            
             LO.adapterinstal();
             DohTablLO.load(LO.Dt, "inv_income_tabl_LO");

        }
        private void SelectSqlDoh_NOMASH_SPB()
        {
            DohTablSPB.DeletRows();
            Vozvratset SPB = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "SPB");
            SPB.setselectcomand(EconomLibrary.Select.SelectSqlDoh_NOMASH_SPB(atr));
            SPB.adapterinstal();
            DohTablSPB.load(SPB.Dt, "inv_income_tabl_SPB");

        }
        private void SelectSqlDoh_NOMASH_ALL()
        {
            DohTablALL.DeletRows();
            Vozvratset ALL = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "ALL");
            ALL.setselectcomand(EconomLibrary.Select.SelectSqlDoh_NOMASH_ALL(atr));
            ALL.adapterinstal();
            DohTablALL.load(ALL.Dt, "inv_income_tabl_ALL");

        }

        

        private void fun()
        {
            TotalLORun();
            toolStripProgressBar1.Value=5;
            TotalSPBRun();
            toolStripProgressBar1.Value = 10;
            DoH_US_ALL();
            toolStripProgressBar1.Value = 15;
            DoH_STOMA_ALL();
            toolStripProgressBar1.Value = 25;
            Save_Bills_ALL();
            toolStripProgressBar1.Value = 35;
            // SelectParametrsList();
            SelectSqlDoh_NOMASH_LO();
            toolStripProgressBar1.Value = 55;
            SelectSqlDoh_NOMASH_SPB();
            toolStripProgressBar1.Value = 65;
            SelectSqlDoh_NOMASH_ALL();
            toolStripProgressBar1.Value = 100;
        }

        public void run()
        {
            Thread thread = new Thread(fun);
          
            thread.Start();
            //  fun();
        }


        private void ex_oracle_Click(object sender, EventArgs e)
        {
          

            /*
                        Vozvratset LO = new Vozvratset(ConectString, "MED", "LO");
                        Vozvratset SPB = new Vozvratset(ConectString, "MED", "SPB");
                        Vozvratset ALL = new Vozvratset(ConectString, "MED", "ALL");



                        Vozvratset TotalALL = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

                        TotalALL.setselectcomand(EconomLibrary.Select.SelectTotalDohod_ALL());
                        TotalALL.AddSelectParametr(":DATES", OracleType.DateTime, 6, this.dates);
                        TotalALL.AddSelectParametr(":DATEf", OracleType.DateTime, 6, this.datef);
                        TotalALL.adapterinstal();

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

                        LOBoxTotal.Text = (TotalLO.Dt.Rows[0][0].ToString()).ToString();
                        SPBBoxTotal.Text = TotalSPB.Dt.Rows[0][0].ToString();
                        ALLBoxTotal.Text = TotalALL.Dt.Rows[0][0].ToString();
                        DohTablALL.load(ALL.Dt, "inv_income_tabl_ALL");
                        DohTablSPB.load(SPB.Dt, "inv_income_tabl_SPB");
                        DohTablLO.load(LO.Dt, "inv_income_tabl_LO");
                        */

            ListDohodSchet LDS = new ListDohodSchet(dates,datef,this);
            LDS.Show();
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
            DohTablALL.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablALL.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablALL.Dt.Clear();

         
            DohTablSPB.AddSelectParametr(":Month", this.MonthBox.SelectedValue);
            DohTablSPB.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablSPB.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablSPB.Dt.Clear();

          
            DohTablLO.AddSelectParametr(":Month", this.MonthBox.SelectedValue);
            DohTablLO.AddUpdateParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablLO.AddInsertParametr("tMonth", OracleType.NVarChar, 255, MonthBox.SelectedValue);
            DohTablLO.Dt.Clear();


          

            DohTablLO.adapterinstal();
            DohTablSPB.adapterinstal();
            DohTablALL.adapterinstal();

        }

        private void yearBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            DohTablALL.AddSelectParametr(":year", this.yearBox.SelectedValue);
            DohTablALL.AddUpdateParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
            DohTablALL.AddInsertParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
            DohTablALL.Dt.Clear();

         
            DohTablSPB.AddSelectParametr(":year", this.yearBox.SelectedValue);
            DohTablSPB.AddUpdateParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
            DohTablSPB.AddInsertParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
            DohTablSPB.Dt.Clear();
          
        
            DohTablLO.AddSelectParametr(":year", this.yearBox.SelectedValue);
            DohTablLO.AddUpdateParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
            DohTablLO.AddInsertParametr("tYear", OracleType.Number, 12, yearBox.SelectedValue);
            DohTablLO.Dt.Clear();


            DohTablLO.adapterinstal();
            DohTablSPB.adapterinstal();
            DohTablALL.adapterinstal();
        }

        private void toExelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TO_EXEL a = new TO_EXEL("ЛО " + MonthBox.SelectedValue.ToString() + " " + yearBox.SelectedValue.ToString(), datageidlo);
        }

        private void lOToExelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sPBToExelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TO_EXEL a = new TO_EXEL("СПБ " + MonthBox.SelectedValue.ToString() + " " + yearBox.SelectedValue.ToString(), datagridspbrf);
        }

        private void dohod_SizeChanged(object sender, EventArgs e)
        {
            tab.Height = (this.Height - groupBox1.Height) - menuStrip1.Height;
            tab.Width = (this.Width-this.Padding.Right)-10;
            groupBox1.Width = this.Width - this.Padding.Right-10;//проверь
        }

        private void sPBLOToExelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Vozvratset ALL = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "ALL");
            ALL.setselectcomand(EconomLibrary.Select.SqlDohALL_NOMAS_TOEXEL(atr));
            ALL.adapterinstal();
           


            TO_EXEL a = new TO_EXEL("СПБ+РФ+ЛО" + MonthBox.SelectedValue.ToString() + " " + yearBox.SelectedValue.ToString(), ALL.Dt);
        }

        private void lOToExelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Vozvratset LO = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "LO");
            LO.setselectcomand(EconomLibrary.Select.SqlDohLO_NOMAS_TOEXEL(atr));
            LO.adapterinstal();
           // DohTablLO.load(LO.Dt, "inv_income_tabl_LO");

           // MessageBox.Show(LO.GetDataView().Table.Rows[0]["uet"].ToString());


            TO_EXEL a = new TO_EXEL("ЛО " + MonthBox.SelectedValue.ToString() + " " + yearBox.SelectedValue.ToString(), LO.Dt);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DohTablLO.UpdateDB();
            DohTablALL.UpdateDB();
            DohTablSPB.UpdateDB();

            father.Enabled = true;
            father.Show();
            this.Hide();
        }

        private void sPBToExelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Vozvratset SPB = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "SPB");
            SPB.setselectcomand(EconomLibrary.Select.SqlDohSPB_NOMAS_TOEXEL(atr));
            SPB.adapterinstal();
            // DohTablLO.load(LO.Dt, "inv_income_tabl_LO");

            // MessageBox.Show(LO.GetDataView().Table.Rows[0]["uet"].ToString());


            TO_EXEL a = new TO_EXEL("CПБ+РФ" + MonthBox.SelectedValue.ToString() + " " + yearBox.SelectedValue.ToString(), SPB.Dt);
        }

        private void общийДоходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SqlDohTOTAL_NOMAS_TOEXEL

            Vozvratset total = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "SPB");
            total.setselectcomand(EconomLibrary.Select.SqlDohTOTAL_NOMAS_TOEXEL(atr));
            total.adapterinstal();
            // DohTablLO.load(LO.Dt, "inv_income_tabl_LO");

            // MessageBox.Show(LO.GetDataView().Table.Rows[0]["uet"].ToString());


            TO_EXEL a = new TO_EXEL("CПБ+РФ+ЛО " + MonthBox.SelectedValue.ToString() + " " + yearBox.SelectedValue.ToString(), total.Dt);
        }
    }
}
