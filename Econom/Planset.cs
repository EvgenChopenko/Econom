using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;

namespace Econom
{
    class Planset : ORACLEABSRTACT
    {
        private OracleDataAdapter ada;
        private OracleCommandBuilder inset;
        private OracleCommand update;
        private OracleCommand delet;



        public Planset(string connectionString, string sqlcommand, string nameDB, string nameTabel) : base(connectionString, sqlcommand, nameDB, nameTabel)
        {          

                base.adapterSet(base.Conect);
            ada = base.adapterGet();
            inset  = new OracleCommandBuilder(this.ada);
            base.endinit();
            ada.InsertCommand = new OracleCommand("p_insert", base.Conect);
            ada.InsertCommand.CommandType = CommandType.StoredProcedure;
            //ada.InsertCommand.Parameters.Add(new OracleParameter("keyid", OracleType.Number, 12, "KEYID"));
            
            ada.InsertCommand.Parameters.Add(new OracleParameter("specid", OracleType.Number, 12, "specid"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("PlanTotal", OracleType.Number, 12, "PlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("PosPlanTotal", OracleType.Number, 12, "PosPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("ObrPlanTotal", OracleType.Number,12, "ObrPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("UetPlanObr", OracleType.Number, 12, "UetPlanObr"));

            ada.InsertCommand.Parameters.Add(new OracleParameter("LOPlanTotal", OracleType.Number, 12, "LOPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("LOPosPlanTotal", OracleType.Number, 12, "LOPosPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("LOObrPlanTotal", OracleType.Number, 12, "LOObrPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("LOUetPlanObr", OracleType.Number, 12, "LOUetPlanObr"));

            ada.InsertCommand.Parameters.Add(new OracleParameter("SPBPlanTotal", OracleType.Number, 12, "SPBPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("SPBPosPlanTotal", OracleType.Number, 12, "SPBPosPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("SPBObrPlanTotal", OracleType.Number, 12, "SPBObrPlanTotal"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("SPBUetPlanObr", OracleType.Number, 12, "SPBUetPlanObr"));

            ada.InsertCommand.Parameters.Add(new OracleParameter("DataStart", OracleType.DateTime, 0, "DataStart"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("DataFinish", OracleType.DateTime, 10, "DataFinish"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("DATATEXT", OracleType.NVarChar, 255, "DATATEXT"));
            ada.InsertCommand.Parameters.Add(new OracleParameter("YEAR", OracleType.Number, 0, "YEAR"));

            ada.UpdateCommand = new OracleCommand("p_updateDOCECO", base.Conect);
            ada.UpdateCommand.CommandType = CommandType.StoredProcedure;
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tkeyid", OracleType.Number, 12, "keyid"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tspecid", OracleType.Number, 12, "specid"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tPlanTotal", OracleType.Number, 12, "PlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tPosPlanTotal", OracleType.Number, 12, "PosPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tObrPlanTotal", OracleType.Number, 12, "ObrPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tUetPlanObr", OracleType.Number, 12, "UetPlanObr"));
           
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tLOPlanTotal", OracleType.Number, 12, "LOPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tLOPosPlanTotal", OracleType.Number, 12, "LOPosPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tLOObrPlanTotal", OracleType.Number, 12, "LOObrPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tLOUetPlanObr", OracleType.Number, 12, "LOUetPlanObr"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tSPBPlanTotal", OracleType.Number, 12, "SPBPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tSPBPosPlanTotal", OracleType.Number, 12, "SPBPosPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tSPBObrPlanTotal", OracleType.Number, 12, "SPBObrPlanTotal"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tSPBUetPlanObr", OracleType.Number, 12, "SPBUetPlanObr"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tDataStart", OracleType.DateTime, 0, "DataStart"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tDataFinish", OracleType.DateTime, 10, "DataFinish"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tDATATEXT", OracleType.NVarChar, 255, "DATATEXT"));
            ada.UpdateCommand.Parameters.Add(new OracleParameter("tYEAR", OracleType.Number, 0, "YEAR"));
            //ada.InsertCommand.Parameters.Add("key_id", OracleType.Number, 0, "keyid");




        }




    }





}

