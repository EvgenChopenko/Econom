using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econom
{
    interface BoneFishDB
    {
         SqlDataAdapter adapterGet();
         DataView GetDataView();
        void UpdateDB();
    }
}
