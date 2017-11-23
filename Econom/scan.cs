using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econom
{
    class Scan : ORACLEABSRTACT
    {
        private int coun =0; 
        public Scan(string connectionString, string nameDB, string nameTabel) : base(connectionString, nameDB, nameTabel)
        {
        }

        public Scan(string connectionString, string sqlcommand, string nameDB, string nameTabel) : base(connectionString, sqlcommand, nameDB, nameTabel)
        {

        }

        
    }
}
