using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace Econom
{
    public partial class Home : Form
    {
        private string sqlloselectUS = @"select lu.text as SpecId,
doc.LOPLANTOTAL as One ,
NVL(doc.LOPLANTOTALOBR,0) as OneObr,
doc.LOPOSPLANTOTAL as PlanPos,
doc.LOOBRPLANTOTAL as PlanObr ,
doc.LOUETPLANOBR as PlanUet,
(NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0)) as PlanDoh,
LOINCOME.POS as PosDoh,
LOINCOME.OBR as ObrDoh,
LOINCOME.UET as UetDoh,
LOINCOME.QTY as QtyDoh,
LOINCOME.SUMDOH as SumDoh,
LOREF.POS as PosVoz,
LOREF.OBR as ObrVoz,
LOREF.UET as UetVoz ,
LOREF.QTY as QtyVoz,
LOREF.SUMVOZ as SumVoz,
lo.POS as PosOtk,
lo.OBR as ObrOtk,
lo.UET as UetOtk,
lo.QTY as QtyOtk,
lo.SUMOTK as SumOtk,
ROUND((NVL(LOINCOME.SUMDOH,0)+NVL(LOREF.SUMVOZ,0)-NVL(lo.SUMOTK,0))*100/decode((doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),0,null,doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),2) as efect

from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";

        private string sqlloselectDC = @"select lu.text as SpecId,
doc.LOPLANTOTAL as One ,
NVL(doc.LOPLANTOTALOBR,0) as OneObr,
doc.LOPOSPLANTOTAL as PlanPos,
doc.LOOBRPLANTOTAL as PlanObr ,
doc.LOUETPLANOBR as PlanUet,
(NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0)) as PlanDoh,
LOINCOME.POS as PosDoh,
LOINCOME.OBR as ObrDoh,
LOINCOME.UET as UetDoh,
LOINCOME.QTY as QtyDoh,
LOINCOME.SUMDOH as SumDoh,
LOREF.POS as PosVoz,
LOREF.OBR as ObrVoz,
LOREF.UET as UetVoz ,
LOREF.QTY as QtyVoz,
LOREF.SUMVOZ as SumVoz,
lo.POS as PosOtk,
lo.OBR as ObrOtk,
lo.UET as UetOtk,
lo.QTY as QtyOtk,
lo.SUMOTK as SumOtk,
ROUND((NVL(LOINCOME.SUMDOH,0)+NVL(LOREF.SUMVOZ,0)-NVL(lo.SUMOTK,0))*100/decode((doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),0,null,doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),2) as efect

from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";

        private string sqlloselectstoma = @"select lu.text as SpecId,
doc.LOPLANTOTAL as One ,
NVL(doc.LOPLANTOTALOBR,0) as OneObr,
doc.LOPOSPLANTOTAL as PlanPos,
doc.LOOBRPLANTOTAL as PlanObr ,
doc.LOUETPLANOBR as PlanUet,
(NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0)) as PlanDoh,
LOINCOME.POS as PosDoh,
LOINCOME.OBR as ObrDoh,
LOINCOME.UET as UetDoh,
LOINCOME.QTY as QtyDoh,
LOINCOME.SUMDOH as SumDoh,
LOREF.POS as PosVoz,
LOREF.OBR as ObrVoz,
LOREF.UET as UetVoz ,
LOREF.QTY as QtyVoz,
LOREF.SUMVOZ as SumVoz,
lo.POS as PosOtk,
lo.OBR as ObrOtk,
lo.UET as UetOtk,
lo.QTY as QtyOtk,
lo.SUMOTK as SumOtk,
ROUND((NVL(LOINCOME.SUMDOH,0)+NVL(LOREF.SUMVOZ,0)-NVL(lo.SUMOTK,0))*100/decode((doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),0,null,doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),2) as efect

from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";
        private string sqlloselectUStotal = @"
select 'Итоги:' as SpecId,
sum(doc.LOPLANTOTAL) as One ,
sum(NVL(doc.LOPLANTOTALOBR,0)) as OneObr,
sum(doc.LOPOSPLANTOTAL) as PlanPos,
sum(doc.LOOBRPLANTOTAL) as PlanObr ,
sum(doc.LOUETPLANOBR) as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))) as PlanDoh,
sum(LOINCOME.POS) as PosDoh,
sum(LOINCOME.OBR) as ObrDoh,
sum(LOINCOME.UET) as UetDoh,
sum(LOINCOME.QTY) as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
sum(LOREF.POS) as PosVoz,
sum(LOREF.OBR) as ObrVoz,
sum(LOREF.UET) as UetVoz ,
sum(LOREF.QTY) as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
sum(lo.POS) as PosOtk,
sum(lo.OBR) as ObrOtk,
sum(lo.UET) as UetOtk,
sum(lo.QTY) as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null
";
        private string sqlloselectSTOMAtotal = @"
select 'Итоги:' as SpecId,
sum(doc.LOPLANTOTAL) as One ,
sum(NVL(doc.LOPLANTOTALOBR,0)) as OneObr,
sum(doc.LOPOSPLANTOTAL) as PlanPos,
sum(doc.LOOBRPLANTOTAL) as PlanObr ,
sum(doc.LOUETPLANOBR) as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))) as PlanDoh,
sum(LOINCOME.POS) as PosDoh,
sum(LOINCOME.OBR) as ObrDoh,
sum(LOINCOME.UET) as UetDoh,
sum(LOINCOME.QTY) as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
sum(LOREF.POS) as PosVoz,
sum(LOREF.OBR) as ObrVoz,
sum(LOREF.UET) as UetVoz ,
sum(LOREF.QTY) as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
sum(lo.POS) as PosOtk,
sum(lo.OBR) as ObrOtk,
sum(lo.UET) as UetOtk,
sum(lo.QTY) as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null
";

        private string sqlloselecttotalDC = @"
select 'Итоги:' as SpecId,
sum(doc.LOPLANTOTAL) as One ,
sum(NVL(doc.LOPLANTOTALOBR,0)) as OneObr,
sum(doc.LOPOSPLANTOTAL) as PlanPos,
sum(doc.LOOBRPLANTOTAL) as PlanObr ,
sum(doc.LOUETPLANOBR) as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))) as PlanDoh,
sum(LOINCOME.POS) as PosDoh,
sum(LOINCOME.OBR) as ObrDoh,
sum(LOINCOME.UET) as UetDoh,
sum(LOINCOME.QTY) as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
sum(LOREF.POS) as PosVoz,
sum(LOREF.OBR) as ObrVoz,
sum(LOREF.UET) as UetVoz ,
sum(LOREF.QTY) as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
sum(lo.POS) as PosOtk,
sum(lo.OBR) as ObrOtk,
sum(lo.UET) as UetOtk,
sum(lo.QTY) as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null
";
        private string sqlloselectUSrefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(LOINCOME.POS)+sum(LOREF.POS)-sum(lo.POS) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
null as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
null as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";
        private string sqlloselectSTOMArefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(LOINCOME.POS)+sum(LOREF.POS)-sum(lo.POS) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
null as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
null as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";
        private string sqlloselectDCrefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(LOINCOME.POS)+sum(LOREF.POS)-sum(lo.POS) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
null as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
null as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";

        private string sqlloselectfinplan = @"SELECT 'Итоги фин.план' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0))) +sum(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0)) as PlanDoh,
null as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
ROUND((sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK))*100/sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where 
 doc.YEAR=:YEAR and
 doc.DATATEXT=:MONTHS

 group by  0, 'Итоги фин.план', null";
        private string tMonths="";
        private int tYera=0;
       private DatForm Time = null;
        private Homeset LO = null;
        private Homeset LOselect = null;
        private dohod dohod=null;
        private vozvrat vozvrat = null;
        private renouncement renouncement = null;
        private string ConectString = ConfigurationManager.ConnectionStrings["Econom.Properties.Settings.OracleString"].ConnectionString;

        private Plan Plan = null;

        public Home()
        {
            InitializeComponent();
        }

        public string TMonths { get => tMonths; set => tMonths = value; }
        public int TYera { get => tYera; set => tYera = value; }
        public dohod Dohod { get => dohod; set => dohod = value; }
        public vozvrat Vozvrat { get => vozvrat; set => vozvrat = value; }
        public renouncement Renouncement { get => renouncement; set => renouncement = value; }
        public Plan Plan1 { get => Plan; set => Plan = value; }

        private void СформироватьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Time = new DatForm(this);
            this.Enabled = false;
            Time.Show();

        }

        public void run()
        {
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectUStotal, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();


            LO = new Homeset(ConectString, "MED", "LO");
            LO.setselectcomand(sqlloselectUS, CommandType.Text);
            LO.AddSelectParametr(":MONTHS", tMonths);
            LO.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LO.adapterinstal(); 
           
            LO.load(LOselect.Dt, "LO");
           

            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectUSrefandvoz, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");


            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectstoma, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");


            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectSTOMAtotal, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectSTOMArefandvoz, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectDC, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselecttotalDC, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectDCrefandvoz, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectfinplan, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);

            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");
           


            datageidlo.DataSource = LO.GetDataView();

            // datageidlo.Rows[two].ReadOnly = true;sqlloselectDCrefandvoz



        }

        private void доходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Dohod is null)
            {
                Dohod = new dohod(this);
                this.Enabled = false;
                Dohod.Show();
            }
            else
            {
                this.Enabled = false;
                Dohod.Show();
            }
        }

        private void возвратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Vozvrat is null)
            {
                Vozvrat = new vozvrat(this);
                this.Enabled = false;
                Vozvrat.Show();
            }
            else
            {
                this.Enabled = false;
                Vozvrat.Show();
            }
        }

        private void отказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Renouncement is null)
            {
                Renouncement = new renouncement(this);
                this.Enabled = false;
                Renouncement.Show();
            }
            else
            {
                this.Enabled = false;
                Renouncement.Show();
            }
        }

        private void планToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Plan1 is null)
            {
                Plan1 = new Plan(this);
                this.Enabled = false;
                Plan1.Show();
            }
            else
            {
                this.Enabled = false;
                Plan1.Show();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.LUTAG9". При необходимости она может быть перемещена или удалена.
            this.lUTAG9TableAdapter.Fill(this.dataSet1.LUTAG9);

        }
    }
}
