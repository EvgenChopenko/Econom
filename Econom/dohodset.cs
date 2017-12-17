using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;

namespace Econom
{
    class dohodset : ORACLEABSRTACT
    {
        public dohodset(string connectionString, string nameDB, string nameTabel) : base(connectionString, nameDB, nameTabel)
        {
        }

        public dohodset(OracleConnection connect, string nameDB, string nameTabel) : base(connect, nameDB, nameTabel)
        {
        }

        public dohodset(string connectionString, string sqlcommand, string nameDB, string nameTabel) : base(connectionString, sqlcommand, nameDB, nameTabel)
        {
        }

      
    }
}
