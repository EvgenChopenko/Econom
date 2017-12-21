using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EconomLibrary;

namespace Econom
{
    public partial class Form1 : Form

    {
        private int Column = 0;
        private int Row = 0;
        private string Atr = "";
        private string pattern = @"\b(\w+)-(\w+)\b";
        private string patDecimal = @"\b(\d+),(\d{2}\b)";
        bool no_save = false;
        public Form1()
        {
            InitializeComponent();         
          
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ScherchBills_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.ColumnIndex.ToString());
        }

        private void ScherchBills_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
           // MessageBox.Show(e.Column.ToString());
        }

        private void ScherchBills_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // MessageBox.Show(e.RowIndex.ToString());
        }

        private void ScherchBills_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //MessageBox.Show(e.Row.Index.ToString());
        }

        private void ScherchBills_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.RowIndex.ToString());
        }

        private void parsePatern(ref string  input,string patern)
        {

            
            if (!(input is null)){
                input = Regex.Matches(input, patern, RegexOptions.IgnoreCase)[0].ToString();
            }else if (patern == "")
            {
                throw new Exception("Шаблон не задан");
            }
            else
            {
                throw new Exception("Параметр для проверки не переданы");
            }
           
        }

        private string parseBuhCode(string s)
        {
            if (s.Length > 0)
            {
                s = s.ToUpper();
                s = s.Trim(' ');
                string lastS = s.Last().ToString();
                s = s.TrimEnd(s.Last());
                parsePatern(ref s, pattern);
                s = s + lastS.ToLower();
                return (s);
            }
            else
            {
                throw new ArgumentException("Строка имела длину нул");
            }
         
        }

        private string parseAmount(string s)
        {
            if (s.Length > 0)
            {
                s = s.ToUpper();
               // string lastS = s.Last().ToString();
                //s = s.TrimEnd(s.Last());
                parsePatern(ref s, patDecimal);
                return (s);
            }
            else if(s.Length <= 0)
            {
                throw new ArgumentException("Строка имела длину нул");
            }
            else
            {
                throw new Exception("Ошибка пердачи параметра в маске");
            }


        }
        private bool inputStringWatchs(int ColumIndex,int RowIndex,DataGridView dataGrid,string name)
        {
            string s = "";
            try
            {
                if (Column == dataGrid.Columns[name].Index)
                {

                    s = ScherchBills.Rows[RowIndex].Cells[ColumIndex].Value.ToString();
                    s = parseBuhCode(s);
                    ScherchBills.Rows[RowIndex].Cells[ColumIndex].Value = (s);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException reg)
            {
                MessageBox.Show("Не правильный ввод параметра");
                return false;
            }
            catch (Exception reg)
            {
                MessageBox.Show("Не введен парметр");
                return false;
            }
            
        }
        private bool inputDecimalgWatchs(int ColumIndex, int RowIndex, DataGridView dataGrid, string name)
        {
            string s = "";
            decimal amount = 0;
            try
            {
                if (Column == dataGrid.Columns[name].Index)
                {

                    s = ScherchBills.Rows[RowIndex].Cells[ColumIndex].Value.ToString();
                    s = parseAmount(s);
                    amount = decimal.Parse(s);
                    ScherchBills.Rows[RowIndex].Cells[ColumIndex].Value = (amount);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException reg)
            {
                MessageBox.Show("Не правильный ввод параметра");
                return false;
            }
            catch (Exception reg)
            {
                MessageBox.Show("Не введен парметр");
                return false;
            }
        }

        private void ScanSerchBuhCode(object s,DataGridView dataGrid,int Row,int Column)
        {
            OracleCommand comd = new OracleCommand(EconomLibrary.SelectOracle.SelectFastSerchBuhCode_GET, EconomLibrary.BD.Connection_GET);
            comd.CommandType = CommandType.Text;
           
            try
            {
                EconomLibrary.BD.Connection_GET.Open();
                comd.Parameters.Add(":BUHCODE", OracleType.NVarChar, 64).Value =s;
              
              OracleDataReader read = comd.ExecuteReader();
                while (read.Read()) {
                  dataGrid.Rows[Row].Cells["SUMDOH"].Value =read.GetDecimal(1);
                    dataGrid.Rows[Row].Cells["id"].Value = read.GetDecimal(0);
                    dataGrid.Rows[Row].Cells["BUHCODE"].Value = read.GetString(2).ToString();
                    Row++;
                }               


            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка" + ex.Message);
            }
            finally
            {
                EconomLibrary.BD.Connection_GET.Close();
            }
        }

        private void ScanSerchAmount(object s, DataGridView dataGrid, int Row, int Column)
        {
            OracleCommand comd = new OracleCommand(EconomLibrary.SelectOracle.SelectFastSerchAmount_GET, EconomLibrary.BD.Connection_GET);
            comd.CommandType = CommandType.Text;
            int row = Row;
            try
            {
                EconomLibrary.BD.Connection_GET.Open();
                comd.Parameters.Add(":Amount", OracleType.Number, 12).Value = s;

                OracleDataReader read = comd.ExecuteReader();
                while (read.Read())
                {
                    

                    
                        dataGrid.Rows[row].Cells["SUMDOH"].Value = read.GetDecimal(1);
                        dataGrid.Rows[row].Cells["id"].Value = read.GetDecimal(0);
                        dataGrid.Rows[row].Cells["BUHCODE"].Value = read.GetString(2).ToString();

                        dataGrid.Rows.Add();
                        row++;
                  
                   
                }
               


            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка" + ex.Message);
            }
            finally
            {
                EconomLibrary.BD.Connection_GET.Close();
            }
        }



        private void ScherchBills_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
          
           
            Column = e.ColumnIndex;
            Row = e.RowIndex;

         
           if( inputStringWatchs(Column, Row, ScherchBills, "BUHCODE"))

            {
               
                ScanSerchBuhCode(ScherchBills.Rows[Row].Cells[Column].Value, ScherchBills, Row, Column);
            }
           else if (inputDecimalgWatchs(Column, Row, ScherchBills, "SUMDOH"))
            {
                ScanSerchAmount(ScherchBills.Rows[Row].Cells[Column].Value, ScherchBills, Row, Column);
            }
           else
            {
                
            }






        }

        private void clearDataGrid()
        {
            for (int i = 0; i < this.ScherchBills.RowCount - 1; i++)
            {
                // BUHCODE.DataGridView.Rows.
                if (this.ScherchBills.Rows[i].Cells["ID"].Value == null)
                {
                   
                    //  MessageBox.Show(this.ScherchBills.Rows[i].Cells["BUHCODE"].Value.ToString());
                    ScherchBills.Rows.RemoveAt(i);
                }
            }
            }

        private void ScanGrid()
        {
            Atr = "";
            no_save = true;
            decimal value = 0;
            string s = "";
            Dictionary<string, decimal> a = new Dictionary<string, decimal>();

            try
            {


                for (int i = 0; i < this.ScherchBills.RowCount - 1; i++)
                {

                    a.TryGetValue(this.ScherchBills.Rows[i].Cells["BUHCODE"].Value.ToString(), out value);

                    if (value == (decimal)this.ScherchBills.Rows[i].Cells["ID"].Value)
                    {
                        no_save = false;
                        this.ScherchBills.Rows[i].Cells["BUHCODE"].Style.BackColor = System.Drawing.Color.Red;


                    }
                    else
                    {
                        a.Add(this.ScherchBills.Rows[i].Cells["BUHCODE"].Value.ToString(), (decimal)this.ScherchBills.Rows[i].Cells["ID"].Value);
                        a.TryGetValue(this.ScherchBills.Rows[i].Cells["BUHCODE"].Value.ToString(), out value);
                        Atr += value.ToString() + ",";
                    }
                }
                a.Clear();
                Atr = Atr.TrimEnd(',');
            }catch(Exception e)
            {
                MessageBox.Show("Не коректный список");
            }
        }

        private void SelectFastSerchListTotal()
        {
     
            /*SelectFastSerchListTotal_NOMAS*/
            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastSerchListTotal_NOMAS(Atr,Atr,Atr,Atr));
            TotalItog.adapterinstal();
            this.TotlaSchet.DataSource = TotalItog.GetDataView();
        }

        /*SelectFastScetSerchList_NOMAS*/
        private void SelectFastScetSerchList()
        { 
            /*SelectFastSerchListTotal_NOMAS*/
            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastScetSerchList_NOMAS(Atr));
            TotalItog.adapterinstal();
            TotalListSchet.DataSource = TotalItog.GetDataView();
        }

        private void SelectFastScetSerchList_inCITY()
        {
            
            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastScetSerchList_NOMAS_inCITY(Atr));
            TotalItog.adapterinstal();
           inCYTI.DataSource = TotalItog.GetDataView();
        }
        private void SelectFastScetSerchList_VTB()
        {

            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastScetSerchList_NOMAS_VTB(Atr));
            TotalItog.adapterinstal();
            VTB.DataSource = TotalItog.GetDataView();
        }

        private void SelectFastScetSerchList_SOGAZ()
        {

            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastScetSerchList_NOMAS_SOGAZ(Atr));
            TotalItog.adapterinstal();
            SOGAZ.DataSource = TotalItog.GetDataView();
        }

        private void SelectFastScetSerchList_RGS()
        {

            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastScetSerchList_NOMAS_RGS(Atr));
            TotalItog.adapterinstal();
            RGS.DataSource = TotalItog.GetDataView();
        }

        private void SelectFastScetSerchList_RESO()
        {

            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastScetSerchList_NOMAS_RESO(Atr));
            TotalItog.adapterinstal();
            RESO.DataSource = TotalItog.GetDataView();
        }

        private void SelectFastScetSerchList_GSMK()
        {

            Vozvratset TotalItog = new Vozvratset(EconomLibrary.BD.ConnectionStrings, "MED", "DOHSPB");

            TotalItog.setselectcomand(EconomLibrary.Select.SelectFastScetSerchList_NOMAS_GSMK(Atr));
            TotalItog.adapterinstal();
            GSMK.DataSource = TotalItog.GetDataView();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearDataGrid();
            ScanGrid();
            SelectFastSerchListTotal();
            SelectFastScetSerchList();
            SelectFastScetSerchList_inCITY();
            SelectFastScetSerchList_VTB();
            SelectFastScetSerchList_RESO();
            SelectFastScetSerchList_RGS();
            SelectFastScetSerchList_GSMK();
            SelectFastScetSerchList_SOGAZ();
        }

    
        /*string atr*/
    }
    }
    

