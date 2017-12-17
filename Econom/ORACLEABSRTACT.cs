using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Econom
{
    class ORACLEABSRTACT
    {
        private OracleDataAdapter adapter;
        private DataSet ds;
        private DataTable dt;
        private string sqlcommand;
        private string sqlselect;
        private string sqlupdate;
        private string sqldelet;
        private string sqlinsert;
        private OracleCommand select;
        private OracleCommand update;
        private OracleCommand delet;
        private OracleCommand insert;

        private string nameTabel;
        private string nameDB;
        private string connectionString;
        private OracleConnection conect;
        private OracleCommandBuilder commmmm;

        public OracleDataAdapter Adapter { get => adapter; set => adapter = value; }
        public DataSet Ds { get => ds; set => ds = value; }
        public DataTable Dt { get => dt; set => dt = value; }
        public string Sqlcommand { get => sqlcommand; set => sqlcommand = value; }
        public string NameTabel { get => nameTabel; set => nameTabel = value; }
        public string NameDB { get => nameDB; set => nameDB = value; }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public OracleConnection Conect { get => conect; set => conect = value; }
        public OracleCommandBuilder Commmmm { get => commmmm; set => commmmm = value; }

        public ORACLEABSRTACT(string connectionString, string sqlcommand, string nameDB, string nameTabel)
        {
            try
            {
                this.nameTabel = nameTabel;
                this.nameDB = nameDB;
                this.sqlcommand = sqlcommand;
                this.ds = new DataSet(nameDB);
                this.dt = new DataTable(nameTabel);
                this.ds.Tables.Add(this.dt);
                this.connectionString = connectionString;
                this.conect = new OracleConnection(this.connectionString);
                this.adapter = new OracleDataAdapter(this.sqlcommand, this.conect);
                this.adapter.Fill(this.ds.Tables[nameTabel]);
                commmmm = new OracleCommandBuilder(this.adapter);
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Передоно значение null " + e.Message);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Передан неверный аргумент " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка " + e.Message);
            }
            


        }

        public ORACLEABSRTACT(string connectionString, string nameDB, string nameTabel)
        {
            try
            {
                this.nameTabel = nameTabel;
                this.nameDB = nameDB;
                this.ds = new DataSet(nameDB);
                this.dt = new DataTable(nameTabel);
                this.ds.Tables.Add(this.dt);
                this.connectionString = connectionString;
                this.conect = new OracleConnection(this.connectionString);
                this.adapter = new OracleDataAdapter();
            }catch (Exception e)
            {
                MessageBox.Show("Ошибка в формирование соедениния " + e.Message);
            }
           

            


        }

        public ORACLEABSRTACT(OracleConnection connect, string nameDB, string nameTabel)
        {
            try
            {
                this.nameTabel = nameTabel;
                this.nameDB = nameDB;
                this.ds = new DataSet(nameDB);
                this.dt = new DataTable(nameTabel);
                this.ds.Tables.Add(this.dt);
                this.connectionString = connect.ConnectionString;
                this.conect = connect;
                this.adapter = new OracleDataAdapter();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в формирование соедениния " + e.Message);
            }

            }



        public OracleDataAdapter adapterGet()
        {
            if (!(this.adapter is null))
            {
                return this.adapter;
            }

            else
            {
                throw new System.Exception("Adapter не обьявлен");
            }

        }


        public void adapterSet(OracleConnection conect)
        {
            try
            {
                this.adapter = new OracleDataAdapter(this.sqlcommand, conect);
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка создания адаптера "+e.Message);
            }
            

        }
        public void adapterSet(OracleDataAdapter ada)
        {
            try
            {
                this.adapter = ada;
            }
            catch (Exception e)
            {
                MessageBox.Show("Не верно переданный Адаптер " + e.Message);
            }
            

        }
        public DataView GetDataView()
        {
            try
            {
                DataView view = new DataView();
                view = this.ds.Tables[nameTabel].AsDataView();
                return view;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка " + e.Message);
                return null;
            }
           

        }
        public virtual void UpdateDB()
        {


            try
            {
                ds.EndInit();

                this.adapter.Update(ds.Tables[this.nameTabel]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            


        }

        public DataTable getTabel()
        {
            try
            {
                return ds.Tables[nameTabel];
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
          
        }
        public void endinit()
        {
            this.ds.EndInit();
        }

        public DataTable datatebeldet()
        {
            return ds.Tables[this.nameTabel];
        }
        public string constringget()
        {
            return this.connectionString;
        }

        public void setselectcomand(string sqlcommand, CommandType CommandType)
        {
            try
            {
                this.sqlselect = sqlcommand;
                select = new OracleCommand(sqlcommand, this.conect);
                select.CommandType = CommandType.Text;
                Adapter.SelectCommand = select;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        public void setselectcomand(OracleCommand command)
        {
            try
            {

                select = command;
               //select.Connection = this.conect;
              
                Adapter.SelectCommand = select;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void setselectcomand(OracleCommand command, OracleConnection connection)
        {
            try
            {

                select = command;
                select.Connection = connection;

                Adapter.SelectCommand = select;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void AddSelectParametr(string oracleparametr, OracleType datatype, int length, object value)
        {
            try
            {
                if (this.adapter.SelectCommand.Parameters.IndexOf(oracleparametr) == -1){
                    this.adapter.SelectCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
                }
                
                else{
                    this.adapter.SelectCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка типа днанных" + e.Message);
            }

        }
        public void AddSelectParametr(string oracleparametr, object value)
        {
          //  this.adapter.SelectCommand.Parameters.AddWithValue(oracleparametr, value);

            try
            {
                if (this.adapter.SelectCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.SelectCommand.Parameters.AddWithValue(oracleparametr, value);
                }

                else
                {
                    this.adapter.SelectCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка типа днанных" + e.Message);
            }
        }

        public void AddSelectParametr(string oracleparametr, OracleType datatype, int length, string value)
        {
            try
            {
                if (this.adapter.SelectCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.SelectCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
                }

                else
                {
                    this.adapter.SelectCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка типа днанных" + e.Message);
            }
        }
        public void setupdatecomand(string sqlcommand, CommandType CommandType)
        {
            try
            {
                this.sqlupdate = sqlcommand;
                update = new OracleCommand(sqlcommand, this.conect);
                update.CommandType = CommandType;
                Adapter.UpdateCommand = update;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Ошибка переданного параметра" + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: "+e.Message);
            }
           
        }

        public void setupdatecomand(OracleCommand command)
        {
            try
            {
                this.sqlupdate = command.CommandText;
                update = command;
                
                Adapter.UpdateCommand = update;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Ошибка переданного параметра" + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }

        }
        public void setinsertcomand(string sqlcommand, CommandType CommandType)
        {
            try
            {
                this.sqlinsert = sqlcommand;
            insert = new OracleCommand(sqlcommand, this.conect);
            insert.CommandType = CommandType;
            Adapter.InsertCommand = insert;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Ошибка переданного параметра" + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
        }

        public void setinsertcomand(OracleCommand command)
        {
            try
            {
                this.sqlinsert = command.CommandText;
                insert = command;
                
                Adapter.InsertCommand = insert;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Ошибка переданного параметра" + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
        }
        public void setdeletcomand(string sqlcommand, CommandType CommandType)
        {
            try
            {
                this.sqldelet = sqlcommand;
            delet = new OracleCommand(sqlcommand, this.conect);
            delet.CommandType = CommandType;
            Adapter.DeleteCommand = delet;
        }
            catch (ArgumentException e)
            {
                MessageBox.Show("Ошибка переданного параметра" + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: "+e.Message);
            }
        }



        public void adapterinstal()
        {
            try
            {
            this.adapter.Fill(this.ds.Tables[nameTabel]);
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка:" + e.Message);
            }
            
            
        }
        public long maxkeid(DataTable dt, string name)
        {

            var table = dt;
            var colum = name;
            var iMax = table.Select().Any() ? (decimal)table.Select().Max(p => p[colum]) : 0;
            return (long)iMax;
        }
        public long count(DataTable dt, string name)
        {

            // var table = dt;
            var colum = name;
            var iMax = (from c in dt.AsEnumerable()
                        select c.Field<decimal>(colum)).Count();
            return (int)iMax;
        }

        public string One()
        {

            // var table = dt;
            
            var iMax = (from c in dt.AsEnumerable()
                        select c.Field<decimal>(0)).Max().ToString();
            return iMax;
        }


        //--------------------------------------------------------------------------------------------
        public void AddInsertParametr(string oracleparametr, object value)
        {
            
            try
            {
                if (this.adapter.InsertCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.InsertCommand.Parameters.AddWithValue(oracleparametr, value);
                }
                else
                {
                    this.adapter.InsertCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void AddInsertParametr(string oracleparametr, OracleType datatype, int length, string value)
        {
            try
            {
                if (this.adapter.InsertCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
                }
                else
                {
                    this.adapter.InsertCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void AddInsertParametr(string oracleparametr, OracleType datatype, int length, int value)
        {
            try
            {
                if (this.adapter.InsertCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
                }
                else
                {
                    this.adapter.InsertCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void AddInsertParametr(string oracleparametr, OracleType datatype, int length, object value)
        {
            try
            {
                if (this.adapter.InsertCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
                }
                else
                {
                    this.adapter.InsertCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AddInsertParametr(string oracleparametr, OracleType datatype, int length, DateTime value)
        {
            try
            {
                if (this.adapter.InsertCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
                }
                else
                {
                    this.adapter.InsertCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void AddInsertParametrGrid(string oracleparametr, OracleType datatype, int length, string TabelGrid)
        {
            if (this.adapter.InsertCommand.Parameters.IndexOf(oracleparametr) == -1)
            {
                this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length, TabelGrid);
            }
            else
            {
                throw new Exception("Такой компонент уже есть среди параметров");
            }
           
        }
            //-----------------------------------------------------------------------------------------------------------
        public void AddDeletParametrGrid(string oracleparametr, OracleType datatype, int length, string TabelGrid)
        {
            try
            {
                this.adapter.DeleteCommand.Parameters.Add(oracleparametr, datatype, length, TabelGrid);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Не верный входной параметр! " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
            
        }
        public void AddDeletParametr(string oracleparametr, OracleType datatype, int length, string value)
        {
            try
            {
                this.adapter.DeleteCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Не верный входной параметр! " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
        }

        public void AddUpdateParametrGrid(string oracleparametr, OracleType datatype, int length, string TabelGrid)
        {
            try
            {
                this.adapter.UpdateCommand.Parameters.Add(oracleparametr, datatype, length, TabelGrid);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Не верный входной параметр! " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
        }
        public void AddUpdateParametr(string oracleparametr, OracleType datatype, int length, object value)
        {
            try
            {
                if (this.adapter.UpdateCommand.Parameters.IndexOf(oracleparametr) == -1)
                {
                    this.adapter.UpdateCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
                }
                else
                {
                    this.adapter.UpdateCommand.Parameters[oracleparametr].Value = value;
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Не верный входной параметр! " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
        }
       

        public void dataColumn(string Columnname, string systype, long Imax, int step)
        {
            try
            {
                DataColumn column = new DataColumn();
                column.ColumnName = Columnname;
                column.DataType = System.Type.GetType(systype);
                column.AutoIncrement = true;
                column.AutoIncrementSeed = (long)Imax + 1;
                column.AutoIncrementStep = step;
                this.Dt.Columns.Add(column);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        public void load(DataTable DT, string TabelName)
        {
            try
            {
                int counter = (int)DT.Rows.Count;

                if (counter > 0)
                {
                    for (int i = 0; i < (counter); i++)
                    {
                        this.Ds.Tables[TabelName].Rows.Add(DT.Rows[i].ItemArray);
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

        }

       public string ListKeyidTostring(string name)
        {
            try
            {
                string keyid = "";
                int colum = dt.Columns.IndexOf(name);
               
                if (colum != -1)
                {
                    for (int i = 0; i < dt.Rows.Count-1; i++)
                    {
                        keyid = keyid + dt.Rows[i][colum].ToString() + ",";
                   
                }
                    
                }
            
                return keyid.TrimEnd(',');

           }
           catch
            {
               MessageBox.Show("Ошибка передачи параметра");
           }

           return "";





        }
    }
}
