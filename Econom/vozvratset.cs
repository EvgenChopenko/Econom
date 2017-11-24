using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Econom
{
    class Vozvratset : ORACLEABSRTACT
    {
        public Vozvratset(string connectionString, string nameDB, string nameTabel) : base(connectionString, nameDB, nameTabel)
        {
        }

        public Vozvratset(string connectionString, string sqlcommand, string nameDB, string nameTabel) : base(connectionString, sqlcommand, nameDB, nameTabel)
        {
        }

      
    }
}
