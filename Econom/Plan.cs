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
        private const string sqlselect= @"
       select * from solution_med.DOCPLAN_ECO dd
        where dd.DATATEXT =:MONTHS
        and dd.YEAR = :YEAR";

        private const string sqlinsert = "p_insert";

        private string connectionString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;


       
        public Plan()
        {
            InitializeComponent();
            PlabCalc = new PlabCalc(this);
        }


        public Plan(Home father)
        {
            InitializeComponent();
            this.father = father;

        }

        private void Plan_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.LUTAG9". При необходимости она может быть перемещена или удалена.
            this.lUTAG9TableAdapter.Fill(this.dataSet1.LUTAG9);

             comboxyear.DataSource = Program.GETYERS();
            comboxmonth.DataSource = Program.GETMonths();

            p = new Planset(connectionString, "MED", "DOCPLAN_ECO");
            p.setselectcomand(sqlselect, CommandType.Text);
            p.AddSelectParametr(":MONTHS", OracleType.NVarChar, 14, comboxmonth.Text);
            p.AddSelectParametr(":YEAR", OracleType.Number, 12, int.Parse(comboxyear.Text));

            p.setinsertcomand(sqlinsert, CommandType.StoredProcedure);
            
                p.AddInsertParametrGrid("specid", OracleType.Number, 12, "specid");
            p.AddInsertParametrGrid("PlanTotal", OracleType.Number, 12, "PlanTotal");
            p.AddInsertParametrGrid("PosPlanTotal", OracleType.Number, 12, "PosPlanTotal");
            p.AddInsertParametrGrid("ObrPlanTotal", OracleType.Number, 12, "ObrPlanTotal");
            p.AddInsertParametrGrid("UetPlanObr", OracleType.Number, 12, "UetPlanObr");

            p.AddInsertParametrGrid("LOPlanTotal", OracleType.Number, 12, "LOPlanTotal");
            p.AddInsertParametrGrid("LOPosPlanTotal", OracleType.Number, 12, "LOPosPlanTotal");
            p.AddInsertParametrGrid("LOObrPlanTotal", OracleType.Number, 12, "LOObrPlanTotal");
            p.AddInsertParametrGrid("LOUetPlanObr", OracleType.Number, 12, "LOUetPlanObr");

            p.AddInsertParametrGrid("SPBPlanTotal", OracleType.Number, 12, "SPBPlanTotal");
            p.AddInsertParametrGrid("SPBPosPlanTotal", OracleType.Number, 12, "SPBPosPlanTotal");
            p.AddInsertParametrGrid("SPBObrPlanTotal", OracleType.Number, 12, "SPBObrPlanTotal");
            p.AddInsertParametrGrid("SPBUetPlanObr", OracleType.Number, 12, "SPBUetPlanObr");

            p.AddInsertParametrGrid("DataStart", OracleType.DateTime, 0, "DataStart");
            p.AddInsertParametrGrid("DataFinish", OracleType.DateTime, 10, "DataFinish");
            p.AddInsertParametrGrid("DATATEXT", OracleType.NVarChar, 255, "DATATEXT");
            p.AddInsertParametrGrid("YEAR", OracleType.Number, 0, "YEAR");






            p.adapterinstal();


            view = p.GetDataView();
            this.dataGridView1.DataSource = view;
           
            dataGridView1.Width =  this.groupBox1.Width;
            dataGridView1.Height = (Height-this.groupBox1.Height)-40;
            comboxdoc.DataSource = dataSet1.LUTAG9;
            comboxdoc.ValueMember = "ID";
            comboxdoc.DisplayMember = "DOC_SPEC";

           
            p.Dt.Columns["YEAR"].DefaultValue = int.Parse(comboxyear.Text.ToString());
        







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
    }
    }
    

