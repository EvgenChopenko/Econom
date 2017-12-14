using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econom
{
    abstract class  SQLDBABSTRACT:BoneFishDB
    {
        private SqlDataAdapter adapter;
        private DataSet ds;
        private DataTable dt;
        private string sqlcommand;
        private string nameTabel;
        private string nameDB;
        private string connectionString;
        private SqlConnection conect;
       private SqlCommandBuilder commmmm;

        public SqlConnection Conect { get => conect; set => conect = value; }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public string NameDB { get => nameDB; set => nameDB = value; }
        public string NameTabel { get => nameTabel; set => nameTabel = value; }
        public string Sqlcommand { get => sqlcommand; set => sqlcommand = value; }
        public DataTable Dt { get => dt; set => dt = value; }
        public DataSet Ds { get => ds; set => ds = value; }
        public SqlDataAdapter Adapter { get => adapter; set => adapter = value; }

        public SQLDBABSTRACT(string connectionString, string sqlcommand, string nameDB, string nameTabel)
        {
            this.nameTabel = nameTabel;
            this.nameDB = nameDB;
            this.sqlcommand = sqlcommand;
            this.ds = new DataSet(nameDB);
            this.dt = new DataTable(nameTabel);
            this.ds.Tables.Add(this.dt);
            this.connectionString = connectionString;

           
            this.conect = new SqlConnection(this.connectionString);
            

            this.adapter = new SqlDataAdapter(this.sqlcommand, this.conect);

            this.adapter.Fill(this.ds.Tables[nameTabel]);
            commmmm = new SqlCommandBuilder(this.adapter);

            
        }

     

        public SqlDataAdapter adapterGet()
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


        public void adapterSet(SqlConnection conect)
        {
            this.adapter = new SqlDataAdapter(this.sqlcommand, conect);

        }
        public void adapterSet(SqlDataAdapter ada)
        {
            this.adapter =  ada;

        }
        public DataView GetDataView()
            {
                DataView view = new DataView();
                view = this.ds.Tables[nameTabel].AsDataView();
                return view;
            }
        public virtual void UpdateDB(){

           
               
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
        /* public object[] GetYear()
         {
             //MessageBox.Show( this.ds.Tables[nameTabel].Rows[0].ToString());

             var view = (from c in this.getTabel().AsEnumerable()


                         select c.Field<object>("year_four")).Distinct<object>().ToArray<object>();


             return view;
         }
 */
    }
}
