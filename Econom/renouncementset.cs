using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    class renouncementset : ORACLEABSRTACT
    { private OracleDataAdapter adapter;
        public renouncementset(string connectionString, string sqlcommand, string nameDB, string nameTabel) : base(connectionString, sqlcommand, nameDB, nameTabel)
        {
            //
           
        }
        public renouncementset(string connectionString, string nameDB, string nameTabel) : base(connectionString,nameDB, nameTabel)
        {
            

        }

        public OracleDataAdapter ada { get => adapter; set => adapter = value; }

       

        public  long maxkeid(DataTable dt, string name)
        {

            var table = dt;
            var colum = name;
            var iMax = table.Select().Any() ? (decimal)table.Select().Max(p => p[colum]) : 0;
            return (long)iMax;
        }

        public void dataColumn(string Columnname,string systype,long Imax,int step)
        {
            DataColumn column = new DataColumn();
            column.ColumnName = Columnname;
            column.DataType = System.Type.GetType(systype);
            column.AutoIncrement = true;
            column.AutoIncrementSeed = (long)Imax + 1;
            column.AutoIncrementStep = step;


            this.Dt.Columns.Add(column);
        }

        public void load (DataTable DT,string TabelName) {
            int counter = (int)DT.Rows.Count;
           // MessageBox.Show(DT.Rows[1].ItemArray.ToString());

            if (counter > 0){
                for (int i = 0; i < (counter); i++)
                {
                    
                    this.Ds.Tables[TabelName].Rows.Add(DT.Rows[i].ItemArray);
                }
            }
        }
    }
}
