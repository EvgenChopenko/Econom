﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    public partial class Plan : Form
    {

        private Planset p = null;
        private Home father = null;
        private DataView view = null;
        private const string sqlcomm= @"
select * from solution_med.DOCPLAN_ECO
";
        
        private string connectionString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;


       
        public Plan()
        {
            InitializeComponent();

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

            

            p = new Planset(connectionString, sqlcomm, "MED", "solution_med.DOCPLAN_ECO");
            view = p.GetDataView();
            this.dataGridView1.DataSource = view;
           
            dataGridView1.Width =  this.groupBox1.Width;
            dataGridView1.Height = (Height-this.groupBox1.Height)-40;
            comboxdoc.DataSource = dataSet1.LUTAG9;
            comboxdoc.ValueMember = "ID";
            comboxdoc.DisplayMember = "DOC_SPEC";

            comboxyear.DataSource = Program.GETYERS();
            comboxmonth.DataSource = Program.GETMonths();
            p.Dt.Columns["YEAR"].DefaultValue = int.Parse(comboxyear.Text.ToString());
           // p.Dt.Columns["specid"].DefaultValue = comboxdoc.Text;







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
    

