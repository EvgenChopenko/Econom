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
using System.Data.OracleClient;

namespace Econom
{
    public partial class Plan : Form
    {
        private PlabCalc PlabCalc = null;
        private Planset p = null;
        private Home father = null;
        private DataView view = null;
        private PlabCalc calcwindows = null;
        private DataSet ds = null;
        private int Row = -1;
        private const string sqlselect= @"
       select * from solution_med.DOCPLAN_ECO dd
        where dd.DATATEXT =:MONTHS
        and dd.YEAR = :YEAR";

        private const string sqlinsert = "p_insert";
        private const string sqlupdate = "p_updateDOCECO";
        private const string sqldelet = "p_deletDOCECO";

        private string connectionString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;

        public PlabCalc Calcwindows { get => calcwindows; set => calcwindows = value; }
        public int Row1 { get => Row; set => Row = value; }
        public DataSet Ds { get => ds; set => ds = value; }

        public Plan()
        {
            InitializeComponent();
            PlabCalc = new PlabCalc(this);
            comboxyear.DataSource = Program.GETYERS();
            comboxmonth.DataSource = Program.GETMonths();
        }


        public Plan(Home father)
        {
            InitializeComponent();
            this.father = father;
            PlabCalc = new PlabCalc(this);
            comboxyear.DataSource = Program.GETYERS();
            comboxmonth.DataSource = Program.GETMonths();


        }

        private void Plan_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.LUTAG9". При необходимости она может быть перемещена или удалена.
            this.lUTAG9TableAdapter.Fill(this.dataSet1.LUTAG9);

          

            p = new Planset(connectionString, "MED", "DOCPLAN_ECO");
            p.setselectcomand(sqlselect, CommandType.Text);
            p.AddSelectParametr(":MONTHS", OracleType.NVarChar, 14, comboxmonth.Text);
            p.AddSelectParametr(":YEAR", OracleType.Number, 12, int.Parse(comboxyear.Text));

            p.setinsertcomand(sqlinsert, CommandType.StoredProcedure);
            
                p.AddInsertParametrGrid("tspecid", OracleType.Number, 12, "specid");
            p.AddInsertParametrGrid("tPlanTotal", OracleType.Number, 12, "PlanTotal");
            p.AddInsertParametrGrid("tPosPlanTotal", OracleType.Number, 12, "PosPlanTotal");
            p.AddInsertParametrGrid("tObrPlanTotal", OracleType.Number, 12, "ObrPlanTotal");
            p.AddInsertParametrGrid("tUetPlanObr", OracleType.Number, 12, "UetPlanObr");
            p.AddInsertParametrGrid("tLOPlanTotal", OracleType.Number, 12, "LOPlanTotal");
            p.AddInsertParametrGrid("tLOPosPlanTotal", OracleType.Number, 12, "LOPosPlanTotal");
            p.AddInsertParametrGrid("tLOObrPlanTotal", OracleType.Number, 12, "LOObrPlanTotal");
            p.AddInsertParametrGrid("tLOUetPlanObr", OracleType.Number, 12, "LOUetPlanObr");
            p.AddInsertParametrGrid("tSPBPlanTotal", OracleType.Number, 12, "SPBPlanTotal");
            p.AddInsertParametrGrid("tSPBPosPlanTotal", OracleType.Number, 12, "SPBPosPlanTotal");
            p.AddInsertParametrGrid("tSPBObrPlanTotal", OracleType.Number, 12, "SPBObrPlanTotal");
            p.AddInsertParametrGrid("tSPBUetPlanObr", OracleType.Number, 12, "SPBUetPlanObr");
            p.AddInsertParametrGrid("tDataStart", OracleType.DateTime, 0, "DataStart");
            p.AddInsertParametrGrid("tDataFinish", OracleType.DateTime, 10, "DataFinish");
            p.AddInsertParametrGrid("tDATATEXT", OracleType.NVarChar, 255, "DATATEXT");
            p.AddInsertParametrGrid("tYEAR", OracleType.Number, 0, "YEAR");
            //////////////////////////
            p.setupdatecomand(sqlupdate,CommandType.StoredProcedure);
            
            ////////////////////////////////////////////////////
            p.AddUpdateParametrGrid("tkeyid", OracleType.Number, 12, "keyid");
            p.AddUpdateParametrGrid("tspecid", OracleType.Number, 12, "specid");
            p.AddUpdateParametrGrid("tPlanTotal", OracleType.Number, 12, "PlanTotal");
            p.AddUpdateParametrGrid("tPosPlanTotal", OracleType.Number, 12, "PosPlanTotal");
            p.AddUpdateParametrGrid("tObrPlanTotal", OracleType.Number, 12, "ObrPlanTotal");
            p.AddUpdateParametrGrid("tUetPlanObr", OracleType.Number, 12, "UetPlanObr");
            p.AddUpdateParametrGrid("tDataStart", OracleType.DateTime, 0, "DataStart");
            p.AddUpdateParametrGrid("tDataFinish", OracleType.DateTime, 10, "DataFinish");
            p.AddUpdateParametrGrid("tDATATEXT", OracleType.NVarChar, 255, "DATATEXT");
            p.AddUpdateParametrGrid("tYEAR", OracleType.Number, 0, "YEAR");
            p.AddUpdateParametrGrid("tLOPlanTotal", OracleType.Number, 12, "LOPlanTotal");
            p.AddUpdateParametrGrid("tLOPosPlanTotal", OracleType.Number, 12, "LOPosPlanTotal");
            p.AddUpdateParametrGrid("tLOObrPlanTotal", OracleType.Number, 12, "LOObrPlanTotal");
            p.AddUpdateParametrGrid("tLOUetPlanObr", OracleType.Number, 12, "LOUetPlanObr");
            p.AddUpdateParametrGrid("tSPBPlanTotal", OracleType.Number, 12, "SPBPlanTotal");
            p.AddUpdateParametrGrid("tSPBPosPlanTotal", OracleType.Number, 12, "SPBPosPlanTotal");
            p.AddUpdateParametrGrid("tSPBObrPlanTotal", OracleType.Number, 12, "SPBObrPlanTotal");
            p.AddUpdateParametrGrid("tSPBUetPlanObr", OracleType.Number, 12, "SPBUetPlanObr");

            ///////////////////////////////////////////
            p.setdeletcomand(sqldelet, CommandType.StoredProcedure);
            p.AddDeletParametrGrid("tkeyid", OracleType.Number, 12, "keyid");



            p.adapterinstal();
            ///
            p.Dt.Columns["PlanTotal"].DefaultValue = 0;
            p.Dt.Columns["PosPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["ObrPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["UetPlanObr"].DefaultValue = 0;
            p.Dt.Columns["LOPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["LOPosPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["LOObrPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["LOUetPlanObr"].DefaultValue = 0;
            p.Dt.Columns["SPBPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["SPBPosPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["SPBObrPlanTotal"].DefaultValue = 0;
            p.Dt.Columns["SPBUetPlanObr"].DefaultValue = 0;
           
            p.Dt.Columns["YEAR"].DefaultValue = int.Parse(comboxyear.Text.ToString());
            p.Dt.Columns["DATATEXT"].DefaultValue = comboxmonth.Text.ToString();
            p.Dt.Columns["DataStart"].DefaultValue = DateTime.Today.ToString();
            p.Dt.Columns["DataFinish"].DefaultValue = DateTime.Today;

            ///
            view = p.GetDataView();
            this.dataGridView1.DataSource = view;
           
            dataGridView1.Width =  this.groupBox1.Width;
            dataGridView1.Height = (Height-this.groupBox1.Height)-40;
            comboxdoc.DataSource = dataSet1.LUTAG9;
            comboxdoc.ValueMember = "ID";
            comboxdoc.DisplayMember = "DOC_SPEC";

           
           
            SPBLORadioButton.Checked = true;
            Ds = p.Ds;






        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.UpdateDB();
            if (this.father is null)
            {
                this.Close();
            }

            this.Hide();

            father.Enabled = true;
        }

        private void comboxyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Dt.Columns["YEAR"].DefaultValue = int.Parse(comboxyear.Text.ToString());
        }

        private void Plan_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.groupBox1.Width;
            dataGridView1.Height = (Height - this.groupBox1.Height) - 40;
        }

        private void Plan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.father != null)
            {
                this.father.Enabled = true;
                this.father.Plan1 = null;
            }
        }

        private void yearbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.yearbox.Checked)
            {
                p.AddSelectParametr(":YEAR", OracleType.Number, 12, decimal.Parse(comboxyear.Text));
                dataGridView1.Columns["YEAR"].Visible = false;
                p.Ds.Clear();
                p.adapterinstal();
                comboxyear.Enabled = false;
                p.Dt.Columns["YEAR"].DefaultValue = int.Parse(comboxyear.Text.ToString());
            }

            else
            {
                dataGridView1.Columns["YEAR"].Visible = true;
                comboxyear.Enabled = true;

            }
        }

        private void MonthsYear_CheckedChanged(object sender, EventArgs e)
        {
            if (this.MonthsYear.Checked)
            {
                p.AddSelectParametr(":MONTHS", OracleType.NVarChar, 14, comboxmonth.Text);
               dataGridView1.Columns["DATATEXT"].Visible = false;
                p.Ds.Clear();
                p.adapterinstal();
                comboxmonth.Enabled = false;
                    p.Dt.Columns["DATATEXT"].DefaultValue = comboxmonth.Text.ToString();
                
            }
            else
            {
               dataGridView1.Columns["DATATEXT"].Visible = true;
                comboxmonth.Enabled = true;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void LORadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["LOPLANTOTAL"].Visible = true;
            dataGridView1.Columns["LOPOSPLANTOTAL"].Visible = true;
            dataGridView1.Columns["LOUETPLANOBR"].Visible = true;
            dataGridView1.Columns["LOOBRPLANTOTAL"].Visible = true;

            dataGridView1.Columns["SPBPLANTOTAL"].Visible = false;
            dataGridView1.Columns["SPbPOSPLANTOTAL"].Visible = false;
            dataGridView1.Columns["SPBUETPLANOBR"].Visible = false;
            dataGridView1.Columns["SPBOBRPLANTOTAL"].Visible = false;

            dataGridView1.Columns["PlanTotal"].Visible = false;
            dataGridView1.Columns["PosPlanTotal"].Visible = false;
            dataGridView1.Columns["ObrPlanTotal"].Visible = false;
            dataGridView1.Columns["UetPlanObr"].Visible = false;

        }

        private void ALLRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["LOPLANTOTAL"].Visible = true;
            dataGridView1.Columns["LOPOSPLANTOTAL"].Visible = true;
            dataGridView1.Columns["LOUETPLANOBR"].Visible = true;
            dataGridView1.Columns["LOOBRPLANTOTAL"].Visible = true;

            dataGridView1.Columns["SPBPLANTOTAL"].Visible = true;
            dataGridView1.Columns["SPbPOSPLANTOTAL"].Visible = true;
            dataGridView1.Columns["SPBUETPLANOBR"].Visible = true;
            dataGridView1.Columns["SPBOBRPLANTOTAL"].Visible = true;

            dataGridView1.Columns["PlanTotal"].Visible = true;
            dataGridView1.Columns["PosPlanTotal"].Visible = true;
            dataGridView1.Columns["ObrPlanTotal"].Visible = true;
            dataGridView1.Columns["UetPlanObr"].Visible = true;
        }

        private void SPBLORadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["LOPLANTOTAL"].Visible =false;
            dataGridView1.Columns["LOPOSPLANTOTAL"].Visible = false;
            dataGridView1.Columns["LOUETPLANOBR"].Visible = false;
            dataGridView1.Columns["LOOBRPLANTOTAL"].Visible = false;

            dataGridView1.Columns["SPBPLANTOTAL"].Visible = false;
            dataGridView1.Columns["SPbPOSPLANTOTAL"].Visible = false;
            dataGridView1.Columns["SPBUETPLANOBR"].Visible = false;
            dataGridView1.Columns["SPBOBRPLANTOTAL"].Visible = false;

            dataGridView1.Columns["PlanTotal"].Visible = true;
            dataGridView1.Columns["PosPlanTotal"].Visible = true;
            dataGridView1.Columns["ObrPlanTotal"].Visible = true;
            dataGridView1.Columns["UetPlanObr"].Visible = true;
        }

        private void SPBRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["LOPLANTOTAL"].Visible = false;
            dataGridView1.Columns["LOPOSPLANTOTAL"].Visible = false;
            dataGridView1.Columns["LOUETPLANOBR"].Visible = false;
            dataGridView1.Columns["LOOBRPLANTOTAL"].Visible = false;

            dataGridView1.Columns["SPBPLANTOTAL"].Visible = true;
            dataGridView1.Columns["SPbPOSPLANTOTAL"].Visible = true;
            dataGridView1.Columns["SPBUETPLANOBR"].Visible = true;
            dataGridView1.Columns["SPBOBRPLANTOTAL"].Visible = true;

            dataGridView1.Columns["PlanTotal"].Visible = false;
            dataGridView1.Columns["PosPlanTotal"].Visible = false;
            dataGridView1.Columns["ObrPlanTotal"].Visible = false;
            dataGridView1.Columns["UetPlanObr"].Visible =false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
           
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (( Row1 != e.RowIndex))
            {
                Row1 = e.RowIndex;
               
                Calcwindows = new PlabCalc(this);
                Calcwindows.Show();
                try
                {
                    Calcwindows.SetRowindex(e.RowIndex);
                    Calcwindows.DataMonthsYearDoc(p.Dt.Rows[ e.RowIndex]["DATATEXT"], p.Dt.Rows[e.RowIndex]["YEAR"],
                p.Dt.Rows[e.RowIndex]["specid"]);
                    Calcwindows.DataLO(dataGridView1["LOObrPlanTotal", e.RowIndex].Value.ToString(),
                        dataGridView1["LOPOSPLANTOTAL", e.RowIndex].Value.ToString(),
                        dataGridView1["LOUetPlanObr", e.RowIndex].Value.ToString());
                    Calcwindows.DataSPB(dataGridView1["SPBObrPlanTotal", e.RowIndex].Value.ToString(),
                        dataGridView1["SPBPOSPLANTOTAL", e.RowIndex].Value.ToString(),
                        dataGridView1["SPBUetPlanObr", e.RowIndex].Value.ToString());
                    Calcwindows.DataSPBLO(dataGridView1["ObrPlanTotal", e.RowIndex].Value.ToString(),
                      dataGridView1["PosPlanTotal", e.RowIndex].Value.ToString(),
                      dataGridView1["UetPlanObr", e.RowIndex].Value.ToString());

                    Calcwindows.DataSum(dataGridView1["SPBPlanTotal", e.RowIndex].Value.ToString(),
                          dataGridView1["LOPlanTotal", e.RowIndex].Value.ToString(),
                          dataGridView1["PlanTotal", e.RowIndex].Value.ToString());

                    Calcwindows.SysDatein(dataGridView1["DATASTART", e.RowIndex].Value, dataGridView1["DataFinish", e.RowIndex].Value);


                 // MessageBox.Show(p.Dt.Rows[e.RowIndex]["specid"].ToString());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("введены не коректные значения"+ex.Message);

                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка:" + ex.Message+" Строка еще не создана: "+e.RowIndex);
                    Calcwindows.Close();
                }
              








            }
            else if (Row1 == e.RowIndex && this.Calcwindows != null)
            {
                Calcwindows.Show();
            }
        }

        private void comboxdoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = p.selectdoc(decimal.Parse(comboxdoc.SelectedValue.ToString()));
            p.Dt.Columns["specid"].DefaultValue = comboxdoc.SelectedValue;
        }

        private void comboxyear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            p.Dt.Columns["YEAR"].DefaultValue = comboxyear.SelectedValue;
        }

        private void comboxmonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            p.Dt.Columns["DATATEXT"].DefaultValue = comboxmonth.SelectedValue;
        }

        private void docbox_CheckedChanged(object sender, EventArgs e)
        {
            if (docbox.Checked)
            {
                dataGridView1.DataSource = p.selectdoc(decimal.Parse(comboxdoc.SelectedValue.ToString()));
                dataGridView1.Columns["SPECID"].Visible = false;
                comboxdoc.Enabled = false;
            }
            else
            {
                dataGridView1.DataSource = p.GetDataView();
                dataGridView1.Columns["SPECID"].Visible = true;
                comboxdoc.Enabled = true;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calcwindows = new PlabCalc(this,false);
            Calcwindows.Show();
        }
        public DataGridView getdataview()
        {
            return dataGridView1;
        }

    }
    }
    

