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
    public partial class renouncement : Form
    {
        private Home father=null;
        private Calcultion calcultionLO;
        private Calcultion calcultionSPB;
        public renouncement()
        {
            InitializeComponent();
            this.MonthBox.DataSource = Program.GETMonths();
            this.yearBox.DataSource = Program.GETYERS();
        }

        public renouncement(Home father)
        {
            InitializeComponent();
            this.MonthBox.DataSource = Program.GETMonths();
            this.yearBox.DataSource = Program.GETYERS();
            this.father = father;
        }
        private string sqlComandlointobill = @" select sum(get_invoisesumaomunt(i.BILLID, v.num, i.keyid)) as SumOtk,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num, i.keyid))as qty ,
sum(get_UETINNUM(v.num, i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v
where v.KEYID = i.VISITID 
 and i.BILLID in ({0})
 and i.AGRID !=435
and i.REFUSE_STATUS in (1,2)
group by get_specdocid(v.num)";
        private string sqlComandspbintibill = @"select sum(get_invoisesumaomunt(i.BILLID, v.num, i.keyid)) as SumOtk,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num, i.keyid))as qty ,
sum(get_UETINNUM(v.num, i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v
where v.KEYID = i.VISITID 
 and i.BILLID in ({0})
 and i.AGRID = 435
and i.REFUSE_STATUS in (1,2)
group by get_specdocid(v.num)";
        private string sqlComandlospbrfintobill = @"select sum(get_invoisesumaomunt(i.BILLID, v.num, i.keyid)) as SumOtk,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num, i.keyid))as qty ,
sum(get_UETINNUM(v.num, i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v
where v.KEYID = i.VISITID 
 and i.BILLID in ({0})
and i.REFUSE_STATUS in (1,2)
group by get_specdocid(v.num)";

        private string sqlselectLO = @"select  pl.keyid, pl.SUMOTK,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_TABL_LO pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private string sqlselectspb = @"select  pl.*,DP.SPECID from INV_TABL_RF pl, DOCPLAN_ECO DP 
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month
                                        and DP.YEAR = :year";
        private string sqlselectall = @"select  pl.*,DP.SPECID from INV_TABL_ALL pl, DOCPLAN_ECO DP 
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month
                                        and DP.YEAR = :year";

        private string sqlUPDATELO = @"UPTINV_TABL";
        private string sqlUPDATEspb = @"UPTINV_TABL";
        private string sqlUPDATEall = @"UPTINV_TABL";

        private string sqlinsertLO = @"IntInv_Tabl";
        private string sqlinsertspb = @"IntInv_Tabl";
        private string sqlinsertall = @"IntInv_Tabl";

        private string sqldeletLO = @"DelInv_Tabl";
        private string sqldeletspb = @"DelInv_Tabl";
        private string sqldeletall = @"DelInv_Tabl";

        private string ConectString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;
        private string filter;
        private renouncementset selectLO;
        private renouncementset selectspb;
        private renouncementset selectALL;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ex_oracle_Click(object sender, EventArgs e)
        {

            if (this.datageidlo.Rows[0].Cells[0].Value is null)
            {
                this.Hide();
                BILLS form = new BILLS();
                form.Visible = true;
                form.father(this);
            }

        }
        public void call(string keyid)
        {
            sqlComandlointobill = String.Format(sqlComandlointobill, keyid.TrimEnd(','));
            sqlComandspbintibill = String.Format(sqlComandspbintibill, keyid.TrimEnd(','));
            sqlComandlospbrfintobill = String.Format(sqlComandlospbrfintobill, keyid.TrimEnd(','));
            MessageBox.Show(sqlComandspbintibill);
            
            renouncementset LO = new renouncementset(ConectString, "MED", "LO");
            renouncementset SPB = new renouncementset(ConectString, "MED", "SPB");
            renouncementset ALL= new renouncementset(ConectString, "MED", "ALL");
            LO.setselectcomand(sqlComandlointobill, CommandType.Text);
            SPB.setselectcomand(sqlComandspbintibill, CommandType.Text);
            ALL.setselectcomand(sqlComandlospbrfintobill, CommandType.Text);
            long iMaxLO = selectLO.maxkeid(selectLO.Ds.Tables["INV_TABL_LO"], "keyid");
            //"System.Int32"
           

            long iMaxSPB = selectspb.maxkeid(selectspb.Ds.Tables["INV_TABL_SPB"], "keyid");
            long iMaxALL = selectALL.maxkeid(selectALL.Ds.Tables["INV_TABL_ALL"], "keyid");
            MessageBox.Show(""+iMaxALL+iMaxLO+iMaxSPB);
            LO.dataColumn("keyid", "System.Int32", iMaxLO, 1);
           SPB.dataColumn("keyid", "System.Int32", iMaxSPB, 1);
            ALL.dataColumn("keyid", "System.Int32", iMaxALL, 1);



            SPB.adapterinstal();
            LO.adapterinstal();
            ALL.adapterinstal();
          

           selectALL.load(ALL.Dt, "INV_TABL_ALL");
           selectspb.load(SPB.Dt, "INV_TABL_spb");
            selectLO.load(LO.Dt, "INV_TABL_LO");


            this.Visible = true;
        }

        private void renouncement_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.LUTAG9". При необходимости она может быть перемещена или удалена.
            this.lUTAG9TableAdapter.Fill(this.dataSet1.LUTAG9);
            //  this.ex_oracle.Visible = false;
            calcultionLO = new Calcultion(datageidlo);
            calcultionSPB = new Calcultion(datagridspbrf);
            selectLO = new renouncementset(ConectString, "MED", "INV_TABL_LO");
            selectspb = new renouncementset(ConectString, "MED", "INV_TABL_spb");
            selectALL = new renouncementset(ConectString, "MED", "INV_TABL_ALL");
//--------------------------------------------------------------------------------------------------------------
            selectLO.setselectcomand(sqlselectLO, CommandType.Text);
            selectLO.AddSelectParametr(":Month", this.MonthBox.Text);
            selectLO.AddSelectParametr(":year", OracleType.Number, 5, this.yearBox.Text);


            //--------------------------------------------------------------------------------------------------------------------
            selectLO.setinsertcomand(sqlinsertLO, CommandType.StoredProcedure);
            selectLO.Adapter.InsertCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "LO";
            selectLO.Adapter.InsertCommand.Parameters.Add("tspecid", OracleType.Number, 10, "SpecId");
            selectLO.Adapter.InsertCommand.Parameters.Add("tSUMOTK", OracleType.Number, 12, "SUMOTK");
            selectLO.Adapter.InsertCommand.Parameters.Add("tPOS", OracleType.Number, 12, "POS");
            selectLO.Adapter.InsertCommand.Parameters.Add("tOBR", OracleType.Number, 12, "OBR");
            selectLO.Adapter.InsertCommand.Parameters.Add("tQTY", OracleType.Number, 12, "QTY");
            selectLO.Adapter.InsertCommand.Parameters.Add("tUET", OracleType.Number, 12, "UET");
            selectLO.Adapter.InsertCommand.Parameters.Add("tYEAR", OracleType.Number, 12).Value = int.Parse(yearBox.Text);
            selectLO.Adapter.InsertCommand.Parameters.Add("tMonth", OracleType.VarChar, 12).Value = MonthBox.Text;
            selectLO.Adapter.InsertCommand.Parameters.Add("v_cunt", OracleType.Number, 12).Value = 0;
            ///-----------------------------------------------------------------------------------------------------------------
            selectLO.setupdatecomand(sqlUPDATELO, CommandType.StoredProcedure);
            selectLO.Adapter.UpdateCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "LO";
            selectLO.Adapter.UpdateCommand.Parameters.Add("tkeyid", OracleType.Number, 10, "keyid");
            selectLO.Adapter.UpdateCommand.Parameters.Add("tspecid", OracleType.Number, 10, "SpecId");
            selectLO.Adapter.UpdateCommand.Parameters.Add("tSUMOTK", OracleType.Number, 12, "SUMOTK");
            selectLO.Adapter.UpdateCommand.Parameters.Add("tPOS", OracleType.Number, 12, "POS");
            selectLO.Adapter.UpdateCommand.Parameters.Add("tOBR", OracleType.Number, 12, "OBR");
            selectLO.Adapter.UpdateCommand.Parameters.Add("tQTY", OracleType.Number, 12, "QTY");
            selectLO.Adapter.UpdateCommand.Parameters.Add("tUET", OracleType.Number, 12, "UET");
            selectLO.Adapter.UpdateCommand.Parameters.Add("tYEAR", OracleType.Number, 12).Value = int.Parse(yearBox.Text);
            selectLO.Adapter.UpdateCommand.Parameters.Add("tMonth", OracleType.VarChar, 12).Value = MonthBox.Text;

            selectLO.setdeletcomand(sqldeletLO, CommandType.StoredProcedure);
            selectLO.Adapter.DeleteCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "LO";
            selectLO.Adapter.DeleteCommand.Parameters.Add("tkeyid", OracleType.Number, 10, "keyid");

            selectLO.adapterinstal();
 ///----------------------------------------------------------------------------------------------------------------
            selectspb.setselectcomand(sqlselectspb, CommandType.Text);
            selectspb.Adapter.SelectCommand.Parameters.AddWithValue(":Month", this.MonthBox.Text);
            selectspb.Adapter.SelectCommand.Parameters.Add(":year", OracleType.Number, 5).Value = this.yearBox.Text;

            //-----------------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------
            selectspb.setinsertcomand(sqlinsertspb, CommandType.StoredProcedure);
            selectspb.Adapter.InsertCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "RF";
            selectspb.Adapter.InsertCommand.Parameters.Add("tspecid", OracleType.Number, 10, "SpecId");
            selectspb.Adapter.InsertCommand.Parameters.Add("tSUMOTK", OracleType.Number, 12, "SUMOTK");
            selectspb.Adapter.InsertCommand.Parameters.Add("tPOS", OracleType.Number, 12, "POS");
            selectspb.Adapter.InsertCommand.Parameters.Add("tOBR", OracleType.Number, 12, "OBR");
            selectspb.Adapter.InsertCommand.Parameters.Add("tQTY", OracleType.Number, 12, "QTY");
            selectspb.Adapter.InsertCommand.Parameters.Add("tUET", OracleType.Number, 12, "UET");
            selectspb.Adapter.InsertCommand.Parameters.Add("tYEAR", OracleType.Number, 12).Value = int.Parse(yearBox.Text);
            selectspb.Adapter.InsertCommand.Parameters.Add("tMonth", OracleType.VarChar, 12).Value = MonthBox.Text;
            selectspb.Adapter.InsertCommand.Parameters.Add("v_cunt", OracleType.Number, 12).Value = 0;
            ///-----------------------------------------------------------------------------------------------------------------
            selectspb.setupdatecomand(sqlUPDATEspb, CommandType.StoredProcedure);
            selectspb.Adapter.UpdateCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "RF";
            selectspb.Adapter.UpdateCommand.Parameters.Add("tkeyid", OracleType.Number, 10, "keyid");
            selectspb.Adapter.UpdateCommand.Parameters.Add("tspecid", OracleType.Number, 10, "SpecId");
            selectspb.Adapter.UpdateCommand.Parameters.Add("tSUMOTK", OracleType.Number, 12, "SUMOTK");
            selectspb.Adapter.UpdateCommand.Parameters.Add("tPOS", OracleType.Number, 12, "POS");
            selectspb.Adapter.UpdateCommand.Parameters.Add("tOBR", OracleType.Number, 12, "OBR");
            selectspb.Adapter.UpdateCommand.Parameters.Add("tQTY", OracleType.Number, 12, "QTY");
            selectspb.Adapter.UpdateCommand.Parameters.Add("tUET", OracleType.Number, 12, "UET");
            selectspb.Adapter.UpdateCommand.Parameters.Add("tYEAR", OracleType.Number, 12).Value = int.Parse(yearBox.Text);
            selectspb.Adapter.UpdateCommand.Parameters.Add("tMonth", OracleType.VarChar, 12).Value = MonthBox.Text;

            selectspb.setdeletcomand(sqldeletLO, CommandType.StoredProcedure);
            selectspb.Adapter.DeleteCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "RF";
            selectspb.Adapter.DeleteCommand.Parameters.Add("tkeyid", OracleType.Number, 10, "keyid");

            selectspb.adapterinstal();
///--------------------------------------------------------------------------------------------------------------------------------

            selectALL.setselectcomand(sqlselectall, CommandType.Text);
            selectALL.Adapter.SelectCommand.Parameters.AddWithValue(":Month", this.MonthBox.Text);
            selectALL.Adapter.SelectCommand.Parameters.Add(":year", OracleType.Number, 5).Value = this.yearBox.Text;

            //-----------------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------
            selectALL.setinsertcomand(sqlinsertall, CommandType.StoredProcedure);
            selectALL.Adapter.InsertCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "ALL";
            selectALL.Adapter.InsertCommand.Parameters.Add("tspecid", OracleType.Number, 10, "SpecId");
            selectALL.Adapter.InsertCommand.Parameters.Add("tSUMOTK", OracleType.Number, 12, "SUMOTK");
            selectALL.Adapter.InsertCommand.Parameters.Add("tPOS", OracleType.Number, 12, "POS");
            selectALL.Adapter.InsertCommand.Parameters.Add("tOBR", OracleType.Number, 12, "OBR");
            selectALL.Adapter.InsertCommand.Parameters.Add("tQTY", OracleType.Number, 12, "QTY");
            selectALL.Adapter.InsertCommand.Parameters.Add("tUET", OracleType.Number, 12, "UET");
            selectALL.Adapter.InsertCommand.Parameters.Add("tYEAR", OracleType.Number, 12).Value = int.Parse(yearBox.Text);
            selectALL.Adapter.InsertCommand.Parameters.Add("tMonth", OracleType.VarChar, 12).Value = MonthBox.Text;
            selectALL.Adapter.InsertCommand.Parameters.Add("v_cunt", OracleType.Number, 12).Value = 0;
            ///-----------------------------------------------------------------------------------------------------------------
            selectALL.setupdatecomand(sqlUPDATEall, CommandType.StoredProcedure);
            selectALL.Adapter.UpdateCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "ALL";
            selectALL.Adapter.UpdateCommand.Parameters.Add("tkeyid", OracleType.Number, 10, "keyid");
            selectALL.Adapter.UpdateCommand.Parameters.Add("tspecid", OracleType.Number, 10, "SpecId");
            selectALL.Adapter.UpdateCommand.Parameters.Add("tSUMOTK", OracleType.Number, 12, "SUMOTK");
            selectALL.Adapter.UpdateCommand.Parameters.Add("tPOS", OracleType.Number, 12, "POS");
            selectALL.Adapter.UpdateCommand.Parameters.Add("tOBR", OracleType.Number, 12, "OBR");
            selectALL.Adapter.UpdateCommand.Parameters.Add("tQTY", OracleType.Number, 12, "QTY");
            selectALL.Adapter.UpdateCommand.Parameters.Add("tUET", OracleType.Number, 12, "UET");
            selectALL.Adapter.UpdateCommand.Parameters.Add("tYEAR", OracleType.Number, 12).Value = int.Parse(yearBox.Text);
            selectALL.Adapter.UpdateCommand.Parameters.Add("tMonth", OracleType.VarChar, 12).Value = MonthBox.Text;

            selectALL.setdeletcomand(sqldeletall, CommandType.StoredProcedure);
            selectALL.Adapter.DeleteCommand.Parameters.Add("tcountry", OracleType.VarChar, 10).Value = "ALL";
            selectALL.Adapter.DeleteCommand.Parameters.Add("tkeyid", OracleType.Number, 10, "keyid");

            selectALL.adapterinstal();

///------------------------------------------------------------------------------------------------------------------------------
            this.datageidlo.DataSource = selectLO.GetDataView();
            this.datagridspbrf.DataSource = selectspb.GetDataView();
            this.datagridspbrflo.DataSource = selectALL.GetDataView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //datagridspbrf
        //datagridspbrflo

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            selectLO.Adapter.SelectCommand.Parameters[":year"].Value = this.yearBox.Text;
            selectLO.Adapter.SelectCommand.Parameters[":Month"].Value = this.MonthBox.Text;
            selectLO.Dt.Clear();
            selectLO.adapterinstal();

            selectspb.Adapter.SelectCommand.Parameters[":year"].Value = this.yearBox.Text;
            selectspb.Adapter.SelectCommand.Parameters[":Month"].Value = this.MonthBox.Text;
            selectspb.Dt.Clear();
            selectspb.adapterinstal();

            selectALL.Adapter.SelectCommand.Parameters[":year"].Value = this.yearBox.Text;
            selectALL.Adapter.SelectCommand.Parameters[":Month"].Value = this.MonthBox.Text;
            selectALL.Dt.Clear();
            selectALL.adapterinstal();

        }

        private void datageidlo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mathcheck_AppearanceChanged(object sender, EventArgs e)
        {

        }

        private void mathcheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.mathcheck.Checked == true)
            {
                this.dopobr.Visible = true;
                this.dopotk.Visible = true;
                this.doppos.Visible = true;
                this.dopqty.Visible = true;
                this.dopuet.Visible = true;

                this.dopOBRSPB.Visible = true;
                this.dopotkspb.Visible = true;
                this.dopPOSSPB.Visible = true;
                this.DOPQTYSPB.Visible = true;
                this.dopUETspb.Visible = true;

                this.dopobrspblo.Visible = true;
                this.dopotkspblo.Visible = true;
                this.dopposspblo.Visible = true;
                this.dopobrspblo.Visible = true;
                this.dopuetspblo.Visible = true;


            }
            else
            {
                this.dopobr.Visible = false;
                this.dopotk.Visible = false;
                this.doppos.Visible = false;
                this.dopqty.Visible = false;
                this.dopuet.Visible = false;

                this.dopOBRSPB.Visible = false;
                this.dopotkspb.Visible = false;
                this.dopPOSSPB.Visible = false;
                this.DOPQTYSPB.Visible = false;
                this.dopUETspb.Visible = false;

                this.dopobrspblo.Visible = false;
                this.dopotkspblo.Visible = false;
                this.dopposspblo.Visible = false;
                this.dopobrspblo.Visible = false;
                this.dopuetspblo.Visible = false;
            }


        }

        private void datageidlo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.mathcheck.Checked == true)
            {
                if (e.ColumnIndex == dopobr.Index)
                {
                    calcultionLO.sum("obr", e.RowIndex, e.ColumnIndex);

                }
                if (e.ColumnIndex == doppos.Index)
                {

                    calcultionLO.sum("pos", e.RowIndex, e.ColumnIndex);

                }
                if (e.ColumnIndex == dopuet.Index)
                {

                    calcultionLO.sum("uet", e.RowIndex, e.ColumnIndex);


                }
                if (e.ColumnIndex == dopqty.Index)
                {
                    calcultionLO.sum("qty", e.RowIndex, e.ColumnIndex);
                }
                if (e.ColumnIndex == dopotk.Index)//
                {
                    calcultionLO.sum("SumOtk", e.RowIndex, e.ColumnIndex);
                }


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectLO.UpdateDB();
            selectALL.UpdateDB();
            selectspb.UpdateDB();
            if (this.father is null){
                this.Close();
            }
            this.father.Enabled = true;
            this.Hide();
        }

        private void datagridspbrf_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.mathcheck.Checked == true)
            {
                if (e.ColumnIndex == dopobr.Index)
                {
                    calcultionSPB.sum("obr", e.RowIndex, e.ColumnIndex);
                }
                if (e.ColumnIndex == doppos.Index)
                {
                    calcultionSPB.sum("pos", e.RowIndex, e.ColumnIndex);
                }
                if (e.ColumnIndex == dopuet.Index)
                {
                    calcultionSPB.sum("uet", e.RowIndex, e.ColumnIndex);

                }
                if (e.ColumnIndex == dopqty.Index)
                {
                    calcultionSPB.sum("qty", e.RowIndex, e.ColumnIndex);
                }
                if (e.ColumnIndex == dopotk.Index)
                {

                    calcultionSPB.sum("SumOtk", e.RowIndex, e.ColumnIndex);
                }

            }


        }

        private void renouncement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.father != null)
            {
                this.father.Enabled = true;
                this.father.Renouncement = null;
            }
        }
    }
}
    

