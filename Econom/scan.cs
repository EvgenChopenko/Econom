using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace Econom
{
    class Scan : ORACLEABSRTACT
    {
       
        public Scan(string connectionString, string nameDB, string nameTabel) : base(connectionString, nameDB, nameTabel)
        {
        }

        public Scan(OracleConnection connect, string nameDB, string nameTabel) : base(connect, nameDB, nameTabel)
        {
        }

        public Scan(string connectionString, string sqlcommand, string nameDB, string nameTabel) : base(connectionString, sqlcommand, nameDB, nameTabel)
        {

        }

        public DateTime datastart(DataTable dt)
        {
            var iMax = (from c in dt.AsEnumerable()
                        select c.Field<DateTime>("DATASTART")).Min();

            return (DateTime)iMax;
        }
        public DateTime datafinish(DataTable dt)
        {
            var iMax = (from c in dt.AsEnumerable()
                        select c.Field<DateTime>("DATAFINISH")).Max();

            return (DateTime)iMax;
        }
    }
}
