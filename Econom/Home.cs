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
        //------------------------------------LOUS
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
        //-------------------------------------------SPBUS
        private string sqlspbselectUS = @"select lu.text as SpecId,
doc.SPBPLANTOTAL as One ,
NVL(doc.SPBPLANTOTALOBR,0) as OneObr,
doc.SPBPOSPLANTOTAL as PlanPos,
doc.SPBOBRPLANTOTAL as PlanObr ,
doc.SPBUETPLANOBR as PlanUet,
(NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0)) +(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0)) as PlanDoh,
RFINCOME.POS as PosDoh,
RFINCOME.OBR as ObrDoh,
RFINCOME.UET as UetDoh,
RFINCOME.QTY as QtyDoh,
RFINCOME.SUMDOH as SumDoh,
RFREF.POS as PosVoz,
RFREF.OBR as ObrVoz,
RFREF.UET as UetVoz ,
RFREF.QTY as QtyVoz,
RFREF.SUMVOZ as SumVoz,
RF.POS as PosOtk,
RF.OBR as ObrOtk,
RF.UET as UetOtk,
RF.QTY as QtyOtk,
RF.SUMOTK as SumOtk,
ROUND((NVL(RFINCOME.SUMDOH,0)+NVL(RFREF.SUMVOZ,0)-NVL(RF.SUMOTK,0))*100/decode((doc.SPBPLANTOTAL*doc.SPBPOSPLANTOTAL),0,null,doc.SPBPLANTOTAL*doc.SPBPOSPLANTOTAL),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311)) and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";

        //-------------------------------------------ALLUS
        private string sqlallselectUS = @"select lu.text as SpecId,
doc.PLANTOTAL as One ,
NVL(doc.PLANTOTALOBR,0) as OneObr,
doc.POSPLANTOTAL as PlanPos,
doc.OBRPLANTOTAL as PlanObr ,
doc.UETPLANOBR as PlanUet,
(NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0)) as PlanDoh,
ALLINCOME.POS as PosDoh,
ALLINCOME.OBR as ObrDoh,
ALLINCOME.UET as UetDoh,
ALLINCOME.QTY as QtyDoh,
ALLINCOME.SUMDOH as SumDoh,
ALLREF.POS as PosVoz,
ALLREF.OBR as ObrVoz,
ALLREF.UET as UetVoz ,
ALLREF.QTY as QtyVoz,
ALLREF.SUMVOZ as SumVoz,
ALLT.POS as PosOtk,
ALLT.OBR as ObrOtk,
ALLT.UET as UetOtk,
ALLT.QTY as QtyOtk,
ALLT.SUMOTK as SumOtk,
ROUND((NVL(ALLINCOME.SUMDOH,0)+NVL(ALLREF.SUMVOZ,0)-NVL(ALLT.SUMOTK,0))*100/decode((doc.PLANTOTAL*doc.POSPLANTOTAL),0,null,doc.PLANTOTAL*doc.POSPLANTOTAL),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311)) and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";
        ///------------------------------------------------------------------LODC
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
        //--------------------------------spbDC
        private string sqlspbselectDC = @"
select lu.text as SpecId,
doc.SPBPLANTOTAL as One ,
NVL(doc.SPBPLANTOTALOBR,0) as OneObr,
doc.SPBPOSPLANTOTAL as PlanPos,
doc.SPBOBRPLANTOTAL as PlanObr ,
doc.SPBUETPLANOBR as PlanUet,
(NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0)) +(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0)) as PlanDoh,
RFINCOME.POS as PosDoh,
RFINCOME.OBR as ObrDoh,
RFINCOME.UET as UetDoh,
RFINCOME.QTY as QtyDoh,
RFINCOME.SUMDOH as SumDoh,
RFREF.POS as PosVoz,
RFREF.OBR as ObrVoz,
RFREF.UET as UetVoz ,
RFREF.QTY as QtyVoz,
RFREF.SUMVOZ as SumVoz,
RF.POS as PosOtk,
RF.OBR as ObrOtk,
RF.UET as UetOtk,
RF.QTY as QtyOtk,
RF.SUMOTK as SumOtk,
ROUND((NVL(RFINCOME.SUMDOH,0)+NVL(RFREF.SUMVOZ,0)-NVL(RF.SUMOTK,0))*100/decode((doc.SPBPLANTOTAL*doc.SPBPOSPLANTOTAL),0,null,doc.SPBPLANTOTAL*doc.SPBPOSPLANTOTAL),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";
        //-----------------------------------------alldc
        private string sqlallselectDC = @"select lu.text as SpecId,
doc.PLANTOTAL as One ,
NVL(doc.PLANTOTALOBR,0) as OneObr,
doc.POSPLANTOTAL as PlanPos,
doc.OBRPLANTOTAL as PlanObr ,
doc.UETPLANOBR as PlanUet,
(NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0)) as PlanDoh,
ALLINCOME.POS as PosDoh,
ALLINCOME.OBR as ObrDoh,
ALLINCOME.UET as UetDoh,
ALLINCOME.QTY as QtyDoh,
ALLINCOME.SUMDOH as SumDoh,
ALLREF.POS as PosVoz,
ALLREF.OBR as ObrVoz,
ALLREF.UET as UetVoz ,
ALLREF.QTY as QtyVoz,
ALLREF.SUMVOZ as SumVoz,
ALLT.POS as PosOtk,
ALLT.OBR as ObrOtk,
ALLT.UET as UetOtk,
ALLT.QTY as QtyOtk,
ALLT.SUMOTK as SumOtk,
ROUND((NVL(ALLINCOME.SUMDOH,0)+NVL(ALLREF.SUMVOZ,0)-NVL(ALLT.SUMOTK,0))*100/decode((NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0)),0,null,(NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0))),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";
        ///--------------------------------------lostoma
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

        //-----------------------------SPBSTOMA
        private string sqlspbselectstoma = @"select lu.text as SpecId,
doc.SPBPLANTOTAL as One ,
NVL(doc.SPBPLANTOTALOBR,0) as OneObr,
doc.SPbPOSPLANTOTAL as PlanPos,
doc.SPBOBRPLANTOTAL as PlanObr ,
doc.SPBUETPLANOBR as PlanUet,
(NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0)) +(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0)) as PlanDoh,
RFINCOME.POS as PosDoh,
RFINCOME.OBR as ObrDoh,
RFINCOME.UET as UetDoh,
RFINCOME.QTY as QtyDoh,
RFINCOME.SUMDOH as SumDoh,
RFREF.POS as PosVoz,
RFREF.OBR as ObrVoz,
RFREF.UET as UetVoz ,
RFREF.QTY as QtyVoz,
RFREF.SUMVOZ as SumVoz,
RF.POS as PosOtk,
RF.OBR as ObrOtk,
RF.UET as UetOtk,
RF.QTY as QtyOtk,
RF.SUMOTK as SumOtk,
ROUND((NVL(RFINCOME.SUMDOH,0)+NVL(RFREF.SUMVOZ,0)-NVL(RF.SUMOTK,0))*100/decode((doc.SPBPLANTOTAL*doc.SPBPOSPLANTOTAL),0,null,doc.SPBPLANTOTAL*doc.SPBPOSPLANTOTAL),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";
        //ALLSTOMA
        private string sqlallselectstoma = @"
select lu.text as SpecId,
doc.PLANTOTAL as One ,
NVL(doc.PLANTOTALOBR,0) as OneObr,
doc.POSPLANTOTAL as PlanPos,
doc.OBRPLANTOTAL as PlanObr ,
doc.UETPLANOBR as PlanUet,
(NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0)) as PlanDoh,
ALLINCOME.POS as PosDoh,
ALLINCOME.OBR as ObrDoh,
ALLINCOME.UET as UetDoh,
ALLINCOME.QTY as QtyDoh,
ALLINCOME.SUMDOH as SumDoh,
ALLREF.POS as PosVoz,
ALLREF.OBR as ObrVoz,
ALLREF.UET as UetVoz ,
ALLREF.QTY as QtyVoz,
ALLREF.SUMVOZ as SumVoz,
ALLT.POS as PosOtk,
ALLT.OBR as ObrOtk,
ALLT.UET as UetOtk,
ALLT.QTY as QtyOtk,
ALLT.SUMOTK as SumOtk,
ROUND((NVL(ALLINCOME.SUMDOH,0)+NVL(ALLREF.SUMVOZ,0)-NVL(ALLT.SUMOTK,0))*100/decode((NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0)),0,null,(NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0)),2)) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";
        //------------------------LOUSTOTAL
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

        //-----------------------spbustotal
        private string sqlspbselectUStotal = @"
select 'Итоги:' as SpecId,
sum(doc.SPBPLANTOTAL) as One ,
sum(NVL(doc.SPBPLANTOTALOBR,0)) as OneObr,
sum(doc.SPBPOSPLANTOTAL) as PlanPos,
sum(doc.SPBOBRPLANTOTAL) as PlanObr ,
sum(doc.SPBUETPLANOBR) as PlanUet,
sum((NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0)) +(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0))) as PlanDoh,
sum(RFINCOME.POS) as PosDoh,
sum(RFINCOME.OBR) as ObrDoh,
sum(RFINCOME.UET) as UetDoh,
sum(RFINCOME.QTY) as QtyDoh,
sum(RFINCOME.SUMDOH) as SumDoh,
sum(RFREF.POS) as PosVoz,
sum(RFREF.OBR) as ObrVoz,
sum(RFREF.UET) as UetVoz ,
sum(RFREF.QTY) as QtyVoz,
SUM(RFREF.SUMVOZ) as SumVoz,
sum(RF.POS) as PosOtk,
sum(RF.OBR) as ObrOtk,
sum(RF.UET) as UetOtk,
sum(RF.QTY) as QtyOtk,
sum(RF.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null
";
        //-----------------------allustotal
        private string sqlallselectUStotal = @"select 'Итоги:' as SpecId,
sum(NVL(doc.PLANTOTAL,0)) as One ,
sum(NVL(doc.PLANTOTALOBR,0)) as OneObr,
sum(NVL(doc.POSPLANTOTAL,0)) as PlanPos,
sum(NVL(doc.OBRPLANTOTAL,0)) as PlanObr ,
sum(NVL(doc.UETPLANOBR,0)) as PlanUet,
sum((NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0))) as PlanDoh,
sum(NVL(ALLINCOME.POS,0)) as PosDoh,
sum(NVL(ALLINCOME.OBR,0)) as ObrDoh,
sum(NVL(ALLINCOME.UET,0)) as UetDoh,
sum(NVL(ALLINCOME.QTY,0)) as QtyDoh,
sum(NVL(ALLINCOME.SUMDOH,0)) as SumDoh,
sum(NVL(ALLREF.POS,0)) as PosVoz,
sum(ALLREF.OBR) as ObrVoz,
sum(ALLREF.UET) as UetVoz ,
sum(ALLREF.QTY) as QtyVoz,
SUM(ALLREF.SUMVOZ) as SumVoz,
sum(ALLT.POS) as PosOtk,
sum(ALLT.OBR) as ObrOtk,
sum(ALLT.UET) as UetOtk,
sum(ALLT.QTY) as QtyOtk,
sum(ALLT.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null";

        //lostomatotal
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
        //spbstomatotal
        private string sqlspbselectSTOMAtotal = @"
select 'Итоги:' as SpecId,
sum(doc.SPBPLANTOTAL) as One ,
sum(NVL(doc.SPbPLANTOTALOBR,0)) as OneObr,
sum(doc.SPBPOSPLANTOTAL) as PlanPos,
sum(doc.SPBOBRPLANTOTAL) as PlanObr ,
sum(doc.SPBUETPLANOBR) as PlanUet,
sum((NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0)) +(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0))) as PlanDoh,
sum(RFINCOME.POS) as PosDoh,
sum(RFINCOME.OBR) as ObrDoh,
sum(RFINCOME.UET) as UetDoh,
sum(RFINCOME.QTY) as QtyDoh,
sum(RFINCOME.SUMDOH) as SumDoh,
sum(RFREF.POS) as PosVoz,
sum(RFREF.OBR) as ObrVoz,
sum(RFREF.UET) as UetVoz ,
sum(RFREF.QTY) as QtyVoz,
SUM(RFREF.SUMVOZ) as SumVoz,
sum(RF.POS) as PosOtk,
sum(RF.OBR) as ObrOtk,
sum(RF.UET) as UetOtk,
sum(RF.QTY) as QtyOtk,
sum(RF.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null";

        //allstomatotal
        private string sqlallselectSTOMAtotal = @"select 'Итоги:' as SpecId,
sum(NVL(doc.PLANTOTAL,0)) as One ,
sum(NVL(doc.PLANTOTALOBR,0)) as OneObr,
sum(NVL(doc.POSPLANTOTAL,0)) as PlanPos,
sum(NVL(doc.OBRPLANTOTAL,0)) as PlanObr ,
sum(NVL(doc.UETPLANOBR,0)) as PlanUet,
sum((NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0))) as PlanDoh,
sum(NVL(ALLINCOME.POS,0)) as PosDoh,
sum(NVL(ALLINCOME.OBR,0)) as ObrDoh,
sum(NVL(ALLINCOME.UET,0)) as UetDoh,
sum(NVL(ALLINCOME.QTY,0)) as QtyDoh,
sum(NVL(ALLINCOME.SUMDOH,0)) as SumDoh,
sum(NVL(ALLREF.POS,0)) as PosVoz,
sum(ALLREF.OBR) as ObrVoz,
sum(ALLREF.UET) as UetVoz ,
sum(ALLREF.QTY) as QtyVoz,
SUM(ALLREF.SUMVOZ) as SumVoz,
sum(ALLT.POS) as PosOtk,
sum(ALLT.OBR) as ObrOtk,
sum(ALLT.UET) as UetOtk,
sum(ALLT.QTY) as QtyOtk,
sum(ALLT.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null";
     
        
        //LO-totalDC
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
        //SPB-totalDC
        private string sqlspbselecttotalDC = @"select 'Итоги:' as SpecId,
sum(doc.SPBPLANTOTAL) as One ,
sum(NVL(doc.SPBPLANTOTALOBR,0)) as OneObr,
sum(doc.SPBPOSPLANTOTAL) as PlanPos,
sum(doc.SPBOBRPLANTOTAL) as PlanObr ,
sum(doc.SPBUETPLANOBR) as PlanUet,
sum((NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0)) +(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0))) as PlanDoh,
sum(RFINCOME.POS) as PosDoh,
sum(RFINCOME.OBR) as ObrDoh,
sum(RFINCOME.UET) as UetDoh,
sum(RFINCOME.QTY) as QtyDoh,
sum(RFINCOME.SUMDOH) as SumDoh,
sum(RFREF.POS) as PosVoz,
sum(RFREF.OBR) as ObrVoz,
sum(RFREF.UET) as UetVoz ,
sum(RFREF.QTY) as QtyVoz,
SUM(RFREF.SUMVOZ) as SumVoz,
sum(RF.POS) as PosOtk,
sum(RF.OBR) as ObrOtk,
sum(RF.UET) as UetOtk,
sum(RF.QTY) as QtyOtk,
sum(RF.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null";

        //ALL-totalDC
        private string sqlallselecttotalDC = @"
select 'Итоги:' as SpecId,
sum(NVL(doc.PLANTOTAL,0)) as One ,
sum(NVL(doc.PLANTOTALOBR,0)) as OneObr,
sum(NVL(doc.POSPLANTOTAL,0)) as PlanPos,
sum(NVL(doc.OBRPLANTOTAL,0)) as PlanObr ,
sum(NVL(doc.UETPLANOBR,0)) as PlanUet,
sum((NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0))) as PlanDoh,
sum(NVL(ALLINCOME.POS,0)) as PosDoh,
sum(NVL(ALLINCOME.OBR,0)) as ObrDoh,
sum(NVL(ALLINCOME.UET,0)) as UetDoh,
sum(NVL(ALLINCOME.QTY,0)) as QtyDoh,
sum(NVL(ALLINCOME.SUMDOH,0)) as SumDoh,
sum(NVL(ALLREF.POS,0)) as PosVoz,
sum(ALLREF.OBR) as ObrVoz,
sum(ALLREF.UET) as UetVoz ,
sum(ALLREF.QTY) as QtyVoz,
SUM(ALLREF.SUMVOZ) as SumVoz,
sum(ALLT.POS) as PosOtk,
sum(ALLT.OBR) as ObrOtk,
sum(ALLT.UET) as UetOtk,
sum(ALLT.QTY) as QtyOtk,
sum(ALLT.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:',null";

        //------------------LOUSREFANDVOZ
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

        //--------------------------------SPBUSREFANDVOZ
        private string sqlspbselectUSrefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(nvl(RFINCOME.POS,0))+sum(nvl(RFREF.POS,0))-sum(NVL(RF.POS,0)) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(nvl(RFINCOME.SUMDOH,0))+SUM(NVL(RFREF.SUMVOZ,0))-sum(NVL(RF.SUMOTK,0)) as SumDoh,
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
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";

        //--------------------------------ALLUSREFANDVOZ
        private string sqlallselectUSrefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(nvl(ALLINCOME.POS,0))+sum(nvl(ALLREF.POS,0))-sum(NVL(ALLT.POS,0)) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(nvl(ALLINCOME.SUMDOH,0))+SUM(NVL(ALLREF.SUMVOZ,0))-sum(NVL(ALLT.SUMOTK,0)) as SumDoh,
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
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";

        //---------------------------LOSTOMArefandvoz
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

        //---------------------------SPBSTOMArefandvoz
        private string sqlspbselectSTOMArefandvoz = @"select 'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(NVL(RFINCOME.POS,0))+sum(NVL(RFREF.POS,0))-sum(NVL(RF.POS,0)) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(NVL(RFINCOME.SUMDOH,0))+SUM(NVL(RFREF.SUMVOZ,0))-sum(NVL(RF.SUMOTK,0)) as SumDoh,
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
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";
        //---------------------------ALLSTOMArefandvoz
        private string sqlallselectSTOMArefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(nvl(ALLINCOME.POS,0))+sum(nvl(ALLREF.POS,0))-sum(NVL(ALLT.POS,0)) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(nvl(ALLINCOME.SUMDOH,0))+SUM(NVL(ALLREF.SUMVOZ,0))-sum(NVL(ALLT.SUMOTK,0)) as SumDoh,
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
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";

        //loDCrefandvoz--------------------
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

        //spbDCrefandvoz--------------------
        private string sqlspbselectDCrefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(RFINCOME.POS)+sum(RFREF.POS)-sum(RF.POS) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(RFINCOME.SUMDOH)+SUM(RFREF.SUMVOZ)-sum(RF.SUMOTK) as SumDoh,
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
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";

        //allDCrefandvoz--------------------
        private string sqlallselectDCrefandvoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(nvl(ALLINCOME.POS,0))+sum(nvl(ALLREF.POS,0))-sum(NVL(ALLT.POS,0)) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(nvl(ALLINCOME.SUMDOH,0))+SUM(NVL(ALLREF.SUMVOZ,0))-sum(NVL(ALLT.SUMOTK,0)) as SumDoh,
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
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  'С учетом отказов/возвратов', null"; 
        //lofinplan
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

        //SPBfinplan
        private string sqlspbselectfinplan = @"
SELECT 'Итоги фин.план' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
sum((NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0))) +sum(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0)) as PlanDoh,
null as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(NVL(RFINCOME.SUMDOH,0)) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
SUM(NVL(RFREF.SUMVOZ,0)) as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
sum(NVL(RF.SUMOTK,0)) as SumOtk,
ROUND((sum(NVL(RFINCOME.SUMDOH,0))+SUM(NVL(RFREF.SUMVOZ,0))-sum(NVL(RF.SUMOTK,0)))*100/sum((NVL(doc.SPBPLANTOTAL,0)*NVL(doc.SPBPOSPLANTOTAL,0)) +(NVL(doc.SPBPLANTOTALOBR,0)*NVL(doc.SPBOBRPLANTOTAL,0))),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_RF RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID
where 
 doc.YEAR=:YEAR and
 doc.DATATEXT=:MONTHS
 group by  0, 'Итоги фин.план', null";

        //ALLfinplan
        private string sqlallselectfinplan = @"SELECT 'Итоги фин.план' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
sum((NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0))) +sum(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0)) as PlanDoh,
null as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(NVL(ALLINCOME.SUMDOH,0)) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
SUM(NVL(ALLREF.SUMVOZ,0)) as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
sum(NVL(ALLT.SUMOTK,0)) as SumOtk,
ROUND((sum(NVL(ALLINCOME.SUMDOH,0))+SUM(NVL(ALLREF.SUMVOZ,0))-sum(NVL(ALLT.SUMOTK,0)))*100/sum((NVL(doc.PLANTOTAL,0)*NVL(doc.POSPLANTOTAL,0)) +(NVL(doc.PLANTOTALOBR,0)*NVL(doc.OBRPLANTOTAL,0))),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID
where 
 doc.YEAR=:YEAR and
 doc.DATATEXT=:MONTHS
 group by  0, 'Итоги фин.план', null";
// Свод Узкие специалисты 
private string sqlsvodselect_US= @"
select 
'Консультативно-диагностический центр' as SpecId,
sum(NVL(RFINCOME.SUMDOH,0)-NVL(RF.SUMOTK,0)+NVL(RFREF.SUMVOZ,0)) as SumSPb,
sum(NVL(LOINCOME.SUMDOH,0)-NVL(LO.SUMOTK,0)+NVL(LOREF.SUMVOZ,0))  as SumLO,
sum(NVL(ALLINCOME.SUMDOH,0)-NVL(ALLT.SUMOTK,0)+NVL(ALLREF.SUMVOZ,0))  as SumRefAndVoz
from
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL LO on LO.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311)) and 
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
group by 'Консультативно-диагностический центр'
            ";

        // Свод СТОМА 
        private string sqlsvodselect_STOMA = @"
select 
'Детская стоматологическая поликлиника' as SpecId,
sum(NVL(RFINCOME.SUMDOH,0)-NVL(RF.SUMOTK,0)+NVL(RFREF.SUMVOZ,0)) as SumSPb,
sum(NVL(LOINCOME.SUMDOH,0)-NVL(LO.SUMOTK,0)+NVL(LOREF.SUMVOZ,0))  as SumLO,
sum(NVL(ALLINCOME.SUMDOH,0)-NVL(ALLT.SUMOTK,0)+NVL(ALLREF.SUMVOZ,0))  as SumRefAndVoz
from
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL LO on LO.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313)) and 
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
group by 'Детская стоматологическая поликлиника'

";
        // Свод ДИагностический Центр
        private string sqlsvodselect_DC = @"
select 
'Диагностический центр(МРТ)' as SpecId,
sum(NVL(RFINCOME.SUMDOH,0)-NVL(RF.SUMOTK,0)+NVL(RFREF.SUMVOZ,0)) as SumSPb,
sum(NVL(LOINCOME.SUMDOH,0)-NVL(LO.SUMOTK,0)+NVL(LOREF.SUMVOZ,0))  as SumLO,
sum(NVL(ALLINCOME.SUMDOH,0)-NVL(ALLT.SUMOTK,0)+NVL(ALLREF.SUMVOZ,0))  as SumRefAndVoz
from
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL LO on LO.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346)) and 
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
group by 'Диагностический центр(МРТ)'
";

        // Свод ДИагностический Центр
        private string sqlsvodselect_total = @"
select 
'Итоги:' as SpecId,
sum(NVL(RFINCOME.SUMDOH,0)-NVL(RF.SUMOTK,0)+NVL(RFREF.SUMVOZ,0)) as SumSPb,
sum(NVL(LOINCOME.SUMDOH,0)-NVL(LO.SUMOTK,0)+NVL(LOREF.SUMVOZ,0))  as SumLO,
sum(NVL(ALLINCOME.SUMDOH,0)-NVL(ALLT.SUMOTK,0)+NVL(ALLREF.SUMVOZ,0))  as SumRefAndVoz
from
DOCPLAN_ECO doc FULL JOIN INV_TABL_ALL ALLT on ALLT.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_ALL ALLREF on ALLREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_ALL ALLINCOME on ALLINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL RF on RF.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_RF RFREF on RFREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_RF RFINCOME on RFINCOME.DOCPLAN_ECOID=doc.KEYID

FULL JOIN INV_TABL_ALL LO on LO.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID 
where  
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
group by 'Итоги:'
";

        private string tMonths="";
        private int tYera=0;
       private DatForm Time = null;
        private Homeset LO = null;
        private Homeset LOselect = null;
        private Homeset SPB = null;
        private Homeset SPBselect = null;
        private Homeset ALL = null;
        private Homeset ALLselect = null;
        private Homeset SVOD = null;
        private Homeset SVODselect = null;
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
            //loselectustotal 
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectUStotal, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            //spbselectustotal
            SPBselect = new Homeset(ConectString, "MED", "SPBPOS");
            SPBselect.setselectcomand(sqlspbselectUStotal, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();

            //allselectustotal
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectUStotal, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();

            //svodselectdc
            SVODselect = new Homeset(ConectString, "MED", "SVODPOS");
            SVODselect.setselectcomand(sqlsvodselect_DC, CommandType.Text);
            SVODselect.AddSelectParametr(":MONTHS", tMonths);
            SVODselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SVODselect.adapterinstal();
            

            //lo--Start 
            LO = new Homeset(ConectString, "MED", "LO");
            LO.setselectcomand(sqlloselectUS, CommandType.Text);
            LO.AddSelectParametr(":MONTHS", tMonths);
            LO.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LO.adapterinstal(); 
           
            LO.load(LOselect.Dt, "LO");

            //SPB--strat
            SPB = new Homeset(ConectString, "MED", "SPB");
            SPB.setselectcomand(sqlspbselectUS, CommandType.Text);
            SPB.AddSelectParametr(":MONTHS", tMonths);
            SPB.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPB.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //ALL--strat
            ALL = new Homeset(ConectString, "MED", "ALL");
            ALL.setselectcomand(sqlallselectUS, CommandType.Text);
            ALL.AddSelectParametr(":MONTHS", tMonths);
            ALL.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALL.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");

            //SVOD--start
            SVOD = new Homeset(ConectString, "MED", "SVOD");
            SVOD.setselectcomand(sqlsvodselect_US, CommandType.Text);
            SVOD.AddSelectParametr(":MONTHS", tMonths);
            SVOD.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SVOD.adapterinstal();
            SVOD.load(SVODselect.Dt, "SVOD");

            //svodselectSTOMA
            SVODselect = new Homeset(ConectString, "MED", "SVODPOS");
            SVODselect.setselectcomand(sqlsvodselect_STOMA, CommandType.Text);
            SVODselect.AddSelectParametr(":MONTHS", tMonths);
            SVODselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SVODselect.adapterinstal();
            SVOD.load(SVODselect.Dt, "SVOD");

            //svodselectTOtal
            SVODselect = new Homeset(ConectString, "MED", "SVODPOS");
            SVODselect.setselectcomand(sqlsvodselect_total, CommandType.Text);
            SVODselect.AddSelectParametr(":MONTHS", tMonths);
            SVODselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SVODselect.adapterinstal();
            SVOD.load(SVODselect.Dt, "SVOD");

            //LO-usrefadzon 
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectUSrefandvoz, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");
            //SPB - usrefandvoz
            SPBselect = new Homeset(ConectString, "MED", "SPBPOS");
            SPBselect.setselectcomand(sqlspbselectUSrefandvoz, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //ALL - usrefandvoz
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectUSrefandvoz, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");

            //LO-selectstoma 
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectstoma, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");
            //SPB - selectstoma
            SPBselect = new Homeset(ConectString, "MED", "SPBPOS");
            SPBselect.setselectcomand(sqlspbselectstoma, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //ALL - selectstoma
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectstoma, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");


            //LO-sqlloselectSTOMAtotal 
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectSTOMAtotal, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            //SPB - sqlloselectSTOMAtota
            SPBselect = new Homeset(ConectString, "MED", "SPBPOS");
            SPBselect.setselectcomand(sqlspbselectSTOMAtotal, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //ALL - sqlloselectSTOMAtota
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectSTOMAtotal, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");

            //LO-selectSTOMArefandvoz
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectSTOMArefandvoz, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");
            //SPB-selectSTOMArefandvoz
            SPBselect = new Homeset(ConectString, "MED", "LOPOS");
            SPBselect.setselectcomand(sqlspbselectSTOMArefandvoz, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //ALL-selectSTOMArefandvoz
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectSTOMArefandvoz, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");

            //LO-selectDC
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectDC, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            //SPB-selectDC
            SPBselect = new Homeset(ConectString, "MED", "LOPOS");
            SPBselect.setselectcomand(sqlspbselectDC, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //ALL-selectDC
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectDC, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");


            //LO-selecttotalDC
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselecttotalDC, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");
            //SPB-selecttotalDC
            SPBselect = new Homeset(ConectString, "MED", "SPBPOS");
            SPBselect.setselectcomand(sqlspbselecttotalDC, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //ALL-selecttotalDC
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselecttotalDC, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");
            //Lo-selectselectDCrefandvoz
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectDCrefandvoz, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");

            //SPB-selectselectDCrefandvoz
            SPBselect = new Homeset(ConectString, "MED", "SPBPOS");
            SPBselect.setselectcomand(sqlspbselectDCrefandvoz, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");

            //all-selectselectDCrefandvoz
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectDCrefandvoz, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");

            //LO-selectfinplan
            LOselect = new Homeset(ConectString, "MED", "LOPOS");
            LOselect.setselectcomand(sqlloselectfinplan, CommandType.Text);
            LOselect.AddSelectParametr(":MONTHS", tMonths);
            LOselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            LOselect.adapterinstal();
            LO.load(LOselect.Dt, "LO");
            
            //SPB-selectfinplan
            SPBselect = new Homeset(ConectString, "MED", "SPBPOS");
            SPBselect.setselectcomand(sqlspbselectfinplan, CommandType.Text);
            SPBselect.AddSelectParametr(":MONTHS", tMonths);
            SPBselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            SPBselect.adapterinstal();
            SPB.load(SPBselect.Dt, "SPB");


            //ALL-selectfinplan
            ALLselect = new Homeset(ConectString, "MED", "ALLPOS");
            ALLselect.setselectcomand(sqlallselectfinplan, CommandType.Text);
            ALLselect.AddSelectParametr(":MONTHS", tMonths);
            ALLselect.AddSelectParametr(":YEAR", OracleType.Number, 5, tYera);
            ALLselect.adapterinstal();
            ALL.load(ALLselect.Dt, "ALL");



            datageidlo.DataSource = LO.GetDataView();
            datagridspbrf.DataSource = SPB.GetDataView();
            datagridspbrflo.DataSource = ALL.GetDataView();
            datagridsvod.DataSource = SVOD.GetDataView();


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

        private void toExelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exeltoLOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TO_EXEL a = new TO_EXEL("ЛО " + tMonths.ToString() + " " + tYera.ToString(), datageidlo);
        }

        private void sPBtoexelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TO_EXEL a = new TO_EXEL("СПБ " + tMonths.ToString() + " " + tYera.ToString(), datagridspbrf);
        }

        private void datageidlo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void sPBLOtoexelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TO_EXEL a = new TO_EXEL("CПБ+РФ+ЛО " + tMonths.ToString() + " " + tYera.ToString(), datagridspbrflo);
        }

        private void таблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TO_EXEL a = new TO_EXEL("Свод "+ tMonths.ToString()+" "+tYera.ToString(), datagridsvod);
        
    }

        private void выгрузитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TO_EXEL a = new TO_EXEL("ЛО " + tMonths.ToString() + " " + tYera.ToString(), datageidlo, "СПБ " + tMonths.ToString() + " " + tYera.ToString(), datagridspbrf, "CПБ+РФ+ЛО " + tMonths.ToString() + " " + tYera.ToString(), datagridspbrflo, "Свод " + tMonths.ToString() + " " + tYera.ToString(), datagridsvod);
        }
    }
}
