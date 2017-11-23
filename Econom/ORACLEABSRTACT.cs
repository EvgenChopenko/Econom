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

        public ORACLEABSRTACT(string connectionString, string nameDB, string nameTabel)
        {
            this.nameTabel = nameTabel;
            this.nameDB = nameDB;
            // this.sqlcommand = sqlcommand;
            this.ds = new DataSet(nameDB);
            this.dt = new DataTable(nameTabel);
            this.ds.Tables.Add(this.dt);
            this.connectionString = connectionString;


            this.conect = new OracleConnection(this.connectionString);


            this.adapter = new OracleDataAdapter();

            //  this.adapter.Fill(this.ds.Tables[nameTabel]);
            //  commmmm = new OracleCommandBuilder(this.adapter);


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
            this.adapter = new OracleDataAdapter(this.sqlcommand, conect);

        }
        public void adapterSet(OracleDataAdapter ada)
        {
            this.adapter = ada;

        }
        public DataView GetDataView()
        {
            DataView view = new DataView();
            view = this.ds.Tables[nameTabel].AsDataView();
            return view;
        }
        public virtual void UpdateDB()
        {



            ds.EndInit();

            this.adapter.Update(ds.Tables[this.nameTabel]);


        }

        public DataTable getTabel()
        {
            return ds.Tables[nameTabel];
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
            this.sqlselect = sqlcommand;
            select = new OracleCommand(sqlcommand, this.conect);
            select.CommandType = CommandType.Text;
            Adapter.SelectCommand = select;
        }

        public void AddSelectParametr(string oracleparametr, OracleType datatype, int length, object value)
        {
            try
            {
                this.adapter.SelectCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка типа днанных" + e.Message);
            }

        }
        public void AddSelectParametr(string oracleparametr, object value)
        {
            this.adapter.SelectCommand.Parameters.AddWithValue(oracleparametr, value);
        }

        public void addselecParametr(string oracleparametr, OracleType datatype, int length, string value)
        {
            this.adapter.SelectCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
        }
        public void setupdatecomand(string sqlcommand, CommandType CommandType)
        {
            this.sqlupdate = sqlcommand;
            update = new OracleCommand(sqlcommand, this.conect);
            update.CommandType = CommandType;
            Adapter.UpdateCommand = update;
        }
        public void setinsertcomand(string sqlcommand, CommandType CommandType)
        {
            this.sqlinsert = sqlcommand;
            insert = new OracleCommand(sqlcommand, this.conect);
            insert.CommandType = CommandType;
            Adapter.InsertCommand = insert;
        }
        public void setdeletcomand(string sqlcommand, CommandType CommandType)
        {
            this.sqldelet = sqlcommand;
            delet = new OracleCommand(sqlcommand, this.conect);
            delet.CommandType = CommandType;
            Adapter.DeleteCommand = delet;
        }
        public void adapterinstal()
        {
            this.adapter.Fill(this.ds.Tables[nameTabel]);
            //  commmmm = new OracleCommandBuilder(this.adapter);
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

        //--------------------------------------------------------------------------------------------
        public void AddInsertParametr(string oracleparametr, object value)
        {
            this.adapter.InsertCommand.Parameters.AddWithValue(oracleparametr, value);
        }

       
        public void AddInsertParametr(string oracleparametr, OracleType datatype, int length, string value)
        {
            this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
        }
        public void AddInsertParametr(string oracleparametr, OracleType datatype, int length, int value)
        {
            this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
        }

        public void AddInsertParametr(string oracleparametr, OracleType datatype, int length,DateTime value)
        {
            this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
        }

        public void AddInsertParametrGrid(string oracleparametr, OracleType datatype, int length, string TabelGrid)
        {
            this.adapter.InsertCommand.Parameters.Add(oracleparametr, datatype, length,TabelGrid);
        }
        //-----------------------------------------------------------------------------------------------------------
        public void AddDeletParametrGrid(string oracleparametr, OracleType datatype, int length, string TabelGrid)
        {
            this.adapter.DeleteCommand.Parameters.Add(oracleparametr, datatype, length, TabelGrid);
        }
        public void AddDeletParametr(string oracleparametr, OracleType datatype, int length, string value)
        {
            this.adapter.DeleteCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
        }

        public void AddUpdateParametrGrid(string oracleparametr, OracleType datatype, int length, string TabelGrid)
        {
            this.adapter.UpdateCommand.Parameters.Add(oracleparametr, datatype, length, TabelGrid);
        }
        public void AddUpdateParametr(string oracleparametr, OracleType datatype, int length, object value)
        {
            this.adapter.UpdateCommand.Parameters.Add(oracleparametr, datatype, length).Value = value;
        }


    }
}
