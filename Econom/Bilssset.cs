using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    class Bilssset : ORACLEABSRTACT
    {
        public Bilssset(string connectionString, string sqlcommand, string nameDB, string nameTabel) : base(connectionString, sqlcommand, nameDB, nameTabel)
        {
        }


        public string TOKEYID(DataGridView datagrid,string watchtabel,string tabelreturn)
        {
           string s ="";
            int i = 0;
            while (i < datagrid.RowCount)
            {

                if (datagrid[watchtabel, i].Value is true)
                {
                    s +=(datagrid[tabelreturn, i].Value.ToString()+",") ;
                }
                i++;

            }
           

            return s;
        } 
    }
}
