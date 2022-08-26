using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedure
/// </summary>
/// 

namespace PDR
{
    public class StoredProcedure
    {
        public StoredProcedure()
        {

        }

        public static string getChartMenu()
        {
            string sql = "SELECT PROD_ASSET.IDASSET AS MENUID, SUBSTR(PROD_ASSET.ASSETS, 0,40) AS ASSETS, ";
            sql += "SUBSTR(PROD_DISTRICT.DISTRICT,0,40) AS TITLE, PROD_ASSET.IDASSET AS PARENTID ";
            sql += "FROM PROD_DISTRICT, PROD_ASSET WHERE PROD_DISTRICT.IDASSET = PROD_ASSET.IDASSET ";
            sql += "ORDER BY PROD_ASSET.IDASSET ";

            return sql;
        }

        #region Main Report Queries
        public static string InsertMainReport()
        {
            string sql = "INSERT INTO PDR_MAINREPORT (IDREPORT, USERID, ID_DISTRICT, DATERPTD) VALUES (:lReportId, :iUserId, :iDistrict, :dtDateReported)";
            return sql;
        }
        public static string InsertMainReport2()
        {
            string sql = "INSERT INTO PDR_MAINREPORT (IDREPORT, USERID, ID_DISTRICT, HIGHLIGHT, LOOKAHEAD, LOWLIGHT, SNAPSHOT1, SNAPSHOT2, SNAPSHOT3, SNAPSHOT4, SNAPSHOT5, DATERPTD) ";
            sql += "VALUES (:lReportId, :iUserId, :iDistrict, :sHighLight, :sLookAhead, :sLowLight, :sSnapShot1, :sSnapShot2, :sSnapShot3, :sSnapShot4, :sSnapShot5, :dtDateReported)";

            return sql;
        }
        public static string UpdateMainReport()
        {
            //string sql = "UPDATE PDR_MAINREPORT SET HIGHLIGHT = :sHighLight, LOOKAHEAD = :sLookAhead, LOWLIGHT = :sLowLight, SNAPSHOT1 = :sSnapShot1, ";
            //sql += "SNAPSHOT2 = :sSnapShot2, SNAPSHOT3 = :sSnapShot3, SNAPSHOT4 = :sSnapShot4, SNAPSHOT5 = :sSnapShot5 WHERE IDREPORT = :lReportId";

            string sql = "UPDATE PDR_MAINREPORT SET HIGHLIGHT = :sHighLight, LOOKAHEAD = :sLookAhead, LOWLIGHT = :sLowLight, SNAPSHOT1 = :sSnapShot1, ";
            sql += "SNAPSHOT2 = :sSnapShot2, SNAPSHOT3 = :sSnapShot3, SNAPSHOT4 = :sSnapShot4, SNAPSHOT5 = :sSnapShot5, USERID = :iUserId WHERE IDREPORT = :lReportId";

            return sql;
        }

        public static string getMaiReportByDistrictDate()
        {
            string sql = "SELECT PDR_MAINREPORT.IDREPORT, PDR_MAINREPORT.SNAPSHOT1, PDR_MAINREPORT.SNAPSHOT2, PDR_MAINREPORT.SNAPSHOT3, PDR_MAINREPORT.SNAPSHOT4, ";
            sql += "PDR_MAINREPORT.SNAPSHOT5, PDR_MAINREPORT.HIGHLIGHT, PDR_MAINREPORT.LOWLIGHT, PDR_MAINREPORT.LOOKAHEAD, PDR_MAINREPORT.ID_DISTRICT, PDR_MAINREPORT.USERID, ";
            sql += "PDR_MAINREPORT.DATERPTD FROM PDR_MAINREPORT WHERE (PDR_MAINREPORT.ID_DISTRICT = :iDistrictId) AND (PDR_MAINREPORT.DATERPTD = :dTodaysDate)";
            return sql;
        }
        public static string getMaiReportByDistrictNameDate()
        {
            string sql = "SELECT PDR_MAINREPORT.IDREPORT, PDR_MAINREPORT.SNAPSHOT1, PDR_MAINREPORT.SNAPSHOT2, PDR_MAINREPORT.SNAPSHOT3, PDR_MAINREPORT.SNAPSHOT4, PDR_MAINREPORT.SNAPSHOT5, ";
            sql += "PDR_MAINREPORT.HIGHLIGHT, PDR_MAINREPORT.LOWLIGHT, PDR_MAINREPORT.LOOKAHEAD, PDR_MAINREPORT.USERID, PDR_MAINREPORT.DATERPTD, PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT ";
            sql += "FROM PDR_MAINREPORT INNER JOIN PROD_DISTRICT ON PDR_MAINREPORT.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
            sql += "WHERE (PROD_DISTRICT.DISTRICT = :sDistrict) AND (PDR_MAINREPORT.DATERPTD = :dTodaysDate)";

            return sql;
        }
        public static string getMaiReportByReportId()
        {
            string sql = "SELECT PDR_MAINREPORT.IDREPORT, PDR_MAINREPORT.SNAPSHOT1, PDR_MAINREPORT.SNAPSHOT2, PDR_MAINREPORT.SNAPSHOT3, PDR_MAINREPORT.SNAPSHOT4, ";
            sql += "PDR_MAINREPORT.SNAPSHOT5, PDR_MAINREPORT.HIGHLIGHT, PDR_MAINREPORT.LOWLIGHT, PDR_MAINREPORT.LOOKAHEAD, PDR_MAINREPORT.ID_DISTRICT, PDR_MAINREPORT.USERID, ";
            sql += "PDR_MAINREPORT.DATERPTD FROM PDR_MAINREPORT WHERE (PDR_MAINREPORT.IDREPORT = :lReportId)";
            return sql;
        }

        #endregion

        #region AGO Status / Logistics
        public static string InsertAGOStatus()
        {
            string sql = "INSERT INTO PDR_AGO (IDREPORT, ID_FACILITIES, ACTUALSTOCK, ISSUEDCONSUMED, ENDURANCE, BOATAVAILABILITY) VALUES (:lReportId, :iFacilityId, :sActualStock, :sIssuedConsumed, :sEndurance, :sBoatAvailability)";
            return sql;//    "IDAGO 
        }

        public static string UpdateAGOStatus()
        {
            string sql = "UPDATE PDR_AGO SET ACTUALSTOCK = :sActualStock, ISSUEDCONSUMED = :sIssuedConsumed, ENDURANCE = :sEndurance, BOATAVAILABILITY = :sBoatAvailability WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";
            return sql;//    "IDAGO 
        }

        public static string getAGOStatusFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_AGO.IDAGO, ";
            sql += "PDR_AGO.IDREPORT, ";
            sql += "PDR_AGO.ACTUALSTOCK, ";
            sql += "PDR_AGO.ISSUEDCONSUMED, ";
            sql += "PDR_AGO.ENDURANCE, ";
            sql += "PDR_AGO.BOATAVAILABILITY ";
            sql += "FROM PDR_AGO ";
            sql += "RIGHT OUTER JOIN PROD_FACILITIES ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_AGO.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }

        #endregion

        #region Alarm Rate
        public static string InsertAlarmRate()
        {
            string sql = "INSERT INTO PDR_ALARMRATE (IDREPORT, ID_FACILITIES, ALARMHR, OVERIDESSTATUS, GDSOP, GDSPG) VALUES (:lReportId, :iFacilityId, :sAlarmHr, :sOverrideStatus, :sGDSOpenPath, :sGDSPointGas)";
            return sql;//    "IDALARM 
        }

        public static string UpdateAlarmRate()
        {
            string sql = "UPDATE PDR_ALARMRATE SET ALARMHR = :sAlarmHR, OVERIDESSTATUS = :sOverrideStatus, GDSOP = :sGDSOpenPath, GDSPG = :sGDSPointGas WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";
            return sql;//    "IDALARM 
        }

        public static string getAlarmRateFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_ALARMRATE.IDALARM, ";
            sql += "PDR_ALARMRATE.IDREPORT, ";
            sql += "PDR_ALARMRATE.ALARMHR, ";
            sql += "PDR_ALARMRATE.OVERIDESSTATUS, ";
            sql += "PDR_ALARMRATE.GDSOP, ";
            sql += "PDR_ALARMRATE.GDSPG ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_ALARMRATE ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_ALARMRATE.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }


        #endregion

        #region cathodic protection
        public static string InsertCathodicProtection()
        {
            string sql = "INSERT INTO PDR_CATHODICPROTECTION (IDREPORT, ID_FACILITIES, CURRENTS, VOLTAGE, SILCALGELSTANDARD, SILCAGELACTUAL) VALUES (:lReportId, :iFacilityId, :sCurrents, :sVoltage, :sSilcaGel, :sSilcagelActual)";
            return sql;//    "IDCATHODIC 
        }

        public static string UpdateCathodicProtection()
        {
            string sql = "UPDATE PDR_CATHODICPROTECTION SET CURRENTS = :sCurrents, VOLTAGE = :sVoltage, SILCALGELSTANDARD = :sSilcaGel, SILCAGELACTUAL = :sSilcagelActual WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";
            return sql;//    "IDCATHODIC 
        }

        public static string getCathodicProtectionFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_CATHODICPROTECTION.IDCATHODIC, ";
            sql += "PDR_CATHODICPROTECTION.IDREPORT, ";
            sql += "PDR_CATHODICPROTECTION.CURRENTS, ";
            sql += "PDR_CATHODICPROTECTION.VOLTAGE, ";
            sql += "PDR_CATHODICPROTECTION.SILCALGELSTANDARD, ";
            sql += "PDR_CATHODICPROTECTION.SILCAGELACTUAL ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_CATHODICPROTECTION ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_CATHODICPROTECTION.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion

        #region Generator/Air Compressor Status
        public static string InsertGenAirCompressor()
        {
            string sql = "INSERT INTO PDR_GENAIRCOMPRESSORS (IDREPORT, ID_FACILITIES, GEN1, GEN2, GEN3, DIESELGEN1, DIESELGEN2, AIRCOMP1, AIRCOMP2, AIRCOMP3, AIRCOMP4) ";
            sql += "VALUES (:lReportId, :iFacilityId, :sGen1, :sGen2, :sGen3, :sDieselGen1, :sDieselGen2, :sAirCompressor1, :sAirCompressor2, :sAirCompressor3, :sAirCompressor4)";
            return sql;
        }
        public static string UpdateGenAirCompressor()
        {
            string sql = "UPDATE PDR_GENAIRCOMPRESSORS GEN1 = :sGen1, GEN2 = :sGen2, GEN3 = :sGen3, DIESELGEN1 = :sDieselGen1, DIESELGEN2 = :sDieselGen2, ";
            sql += "AIRCOMP1 = :sAirCompressor1, AIRCOMP2 = :sAirCompressor2, AIRCOMP3 = :ssAirCompressor3, AIRCOMP4 = :sAirCompressor4 WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";
            return sql;
        }

        public static string getGenAirCompressorFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_GENAIRCOMPRESSORS.IDGEN, ";
            sql += "PDR_GENAIRCOMPRESSORS.IDREPORT, ";
            sql += "PDR_GENAIRCOMPRESSORS.GEN1, ";
            sql += "PDR_GENAIRCOMPRESSORS.GEN2, ";
            sql += "PDR_GENAIRCOMPRESSORS.GEN3, ";
            sql += "PDR_GENAIRCOMPRESSORS.DIESELGEN1, ";
            sql += "PDR_GENAIRCOMPRESSORS.DIESELGEN2, ";
            sql += "PDR_GENAIRCOMPRESSORS.AIRCOMP1, ";
            sql += "PDR_GENAIRCOMPRESSORS.AIRCOMP2, ";
            sql += "PDR_GENAIRCOMPRESSORS.AIRCOMP3, ";
            sql += "PDR_GENAIRCOMPRESSORS.AIRCOMP4 ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_GENAIRCOMPRESSORS ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_GENAIRCOMPRESSORS.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion

        #region HSSE Goal Zero
        public static string InsertGoalZero()
        {
            string sql = "INSERT INTO PDR_HSSE (IDREPORT, ID_FACILITIES, LTI, GOALZERODAYS, ZEROPLANTDAYS, FOUNTASSURANCE, SOL, LTIREMARKS, GOALZEROREMARKS, ZEROPLANTREMARKS, FOUNTREMARKS, SOLREMARKS) ";
            sql += "VALUES (:lReportId, :iFacilityId, :sLti, :sGoalZeroDays, :sZeroPlantDays, :sFountainAssurance, :sSol, :sLtiRemarks, :sGoalZeroRemarks, :sZeroPlantRemarks, :sFountainRemarks, :sSolRemarks)";
            return sql;//    "IDHSSE 
        }
        public static string UpdateGoalZero()
        {
            string sql = "UPDATE PDR_HSSE SET LTI = :sLti, GOALZERODAYS = :sGoalZeroDays, ZEROPLANTDAYS = :sZeroPlantDays, FOUNTASSURANCE = :sFountainAssurance, SOL = :sSol, LTIREMARKS = :sLtiRemarks, ";
            sql += "GOALZEROREMARKS = :sGoalZeroRemarks, ZEROPLANTREMARKS = :sZeroPlantRemarks, FOUNTREMARKS = :sFountainRemarks, SOLREMARKS = :sSolRemarks WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";

            return sql;//    "IDHSSE 
        }

        public static string getHSSEFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_HSSE.IDHSSE, ";
            sql += "PDR_HSSE.IDREPORT, ";
            sql += "PDR_HSSE.LTI, ";
            sql += "PDR_HSSE.GOALZERODAYS, ";
            sql += "PDR_HSSE.ZEROPLANTDAYS, ";
            sql += "PDR_HSSE.FOUNTASSURANCE, ";
            sql += "PDR_HSSE.SOL, ";
            sql += "PDR_HSSE.LTIREMARKS, ";
            sql += "PDR_HSSE.GOALZEROREMARKS, ";
            sql += "PDR_HSSE.ZEROPLANTREMARKS, ";
            sql += "PDR_HSSE.FOUNTREMARKS, ";
            sql += "PDR_HSSE.SOLREMARKS ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_HSSE ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_HSSE.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion

        #region Meter Status
        public static string InsertMeterStatus()
        {
            string sql = "INSERT INTO PDR_METERSTATUS (IDREPORT, ID_FACILITIES, GROSSOIL, FLARE, GASPRODUCED, GASSOLD, CONDESSATEPROD, FUELGASMETER, REMARKS) ";
            sql += "VALUES (:lReportId, :iFacilityId, :sGrossOil, :sFlare, :sGasProduced, :sGasSold, :sCondessateProd, :sFuelGasMeter, :sRemarks)";
            return sql;
        }
        public static string UpdateMeterStatus()
        {
            string sql = "UPDATE PDR_METERSTATUS SET GROSSOIL = :sGrossOil, FLARE = :sFlare, GASPRODUCED = :sGasProduced, GASSOLD = :sGasSold, ";
            sql += "CONDESSATEPROD = :sCondessateProd, FUELGASMETER = :sFuelGasMeter, REMARKS = :sRemarks WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";
            return sql;
        }

        public static string getMeterStatusFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_METERSTATUS.IDMETER, ";
            sql += "PDR_METERSTATUS.IDREPORT, ";
            sql += "PDR_METERSTATUS.GROSSOIL, ";
            sql += "PDR_METERSTATUS.FLARE, ";
            sql += "PDR_METERSTATUS.GASPRODUCED, ";
            sql += "PDR_METERSTATUS.GASSOLD, ";
            sql += "PDR_METERSTATUS.CONDESSATEPROD, ";
            sql += "PDR_METERSTATUS.FUELGASMETER, ";
            sql += "PDR_METERSTATUS.REMARKS ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_METERSTATUS ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_METERSTATUS.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion

        #region POB
        public static string InsertPOB()
        {
            string sql = "INSERT INTO PDR_POB (IDREPORT, ID_FACILITIES, CURRENTPOB, REMARKS, CRITICAL, NONCRITICAL) VALUES (:lReportId, :iFacilityId, :sCurrentPOB, :sRemarks, :sCritical, :sNonCritical)";
            return sql;//    "IDPOB 
        }
        public static string UpdatePOB()
        {
            string sql = "UPDATE PDR_POB SET CURRENTPOB = :sCurrentPOB, REMARKS = :sRemarks, CRITICAL = :sCritical, NONCRITICAL = :sNonCritical WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";
            return sql;//    "IDPOB 
        }
        public static string getPOBFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_POB.IDPOB, ";
            sql += "PDR_POB.IDREPORT, ";
            sql += "PDR_POB.CURRENTPOB, ";
            sql += "PDR_POB.REMARKS, ";
            sql += "PDR_POB.CRITICAL, ";
            sql += "PDR_POB.NONCRITICAL ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_POB ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_POB.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion

        #region PTW Summary
        public static string InsertPTWSummary()
        {
            string sql = "INSERT INTO PDR_PTWSUMMARY (IDREPORT, ACTIVE, SUSPENDED, CLOSED, EPI, AUTHORIZED, EXPIRED, CANCELLED) VALUES (:lReportId, :sActive, :sSuspended, :sClosed, :sEPI, :sAuthorised, :sExpired, :sCancelled)";
            return sql;//    "IDPTW 
        }
        public static string UpdatePTWSummary()
        {
            string sql = "UPDATE PDR_PTWSUMMARY SET ACTIVE = :sActive, SUSPENDED = :sSuspended, CLOSED = :sClosed, EPI = :sEPI, AUTHORIZED = :sAuthorised, EXPIRED = :sExpired, CANCELLED = :sCancelled WHERE IDREPORT = :lReportId";
            return sql;//    "IDPTW 
        }
        public static string getPTWSummaryFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_DISTRICT.ID_DISTRICT, ";
            sql += "PROD_DISTRICT.DISTRICT, ";
            sql += "PDR_PTWSUMMARY.IDPTW, ";
            sql += "PDR_PTWSUMMARY.IDREPORT, ";
            sql += "PDR_PTWSUMMARY.ACTIVE, ";
            sql += "PDR_PTWSUMMARY.SUSPENDED, ";
            sql += "PDR_PTWSUMMARY.CLOSED, ";
            sql += "PDR_PTWSUMMARY.EPI, ";
            sql += "PDR_PTWSUMMARY.AUTHORIZED, ";
            sql += "PDR_PTWSUMMARY.EXPIRED, ";
            sql += "PDR_PTWSUMMARY.CANCELLED ";
            sql += "FROM PROD_DISTRICT ";
            sql += "LEFT OUTER JOIN PDR_PTWSUMMARY ";
            sql += "ON PROD_DISTRICT.ID_DISTRICT = PDR_PTWSUMMARY.ID_DISTRICT ";
            sql += "WHERE PROD_DISTRICT.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion

        #region Technical Integrity
        public static string InsertTechnicalIntegrity()
        {
            string sql = "INSERT INTO PDR_TECHNICALINTEGRITY (IDREPORT, ID_FACILITIES, PMDUE, PMCOMPLETED, PMCOMPLAINT, SCEPMDUE, SCEPMCOMPLETED, SCEPMCOMPLAINT, CMDUE, CMCOMPLETED, CMCOMPLAINT) ";
            sql += "VALUES (:lReportId, :iFacilityId, :PMDue, :sPMCompleted, :sPMComplaint, :sScepmDue, :sScepmCompleted, :sScepmComplaint, :sCMDue, :sCMCompleted, :sCMComplaint)";
            return sql;//    "IDTI 
        }
        public static string UpdateTechnicalIntegrity()
        {
            string sql = "UPDATE PDR_TECHNICALINTEGRITY SET PMDUE = :PMDue, PMCOMPLETED = :sPMCompleted, PMCOMPLAINT = :sPMComplaint, SCEPMDUE = :sScepmDue, SCEPMCOMPLETED = :sScepmCompleted, ";
            sql += "SCEPMCOMPLAINT = :sScepmComplaint, CMDUE = :sCMDue, CMCOMPLETED = :sCMCompleted, CMCOMPLAINT = :sCMComplaint WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";

            return sql;//    "IDTI 
        }
        public static string getTechIntegrityFacilitiesByDistrict()
        {

            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_TECHNICALINTEGRITY.IDTI, ";
            sql += "PDR_TECHNICALINTEGRITY.IDREPORT, ";
            sql += "PDR_TECHNICALINTEGRITY.PMDUE, ";
            sql += "PDR_TECHNICALINTEGRITY.PMCOMPLETED, ";
            sql += "PDR_TECHNICALINTEGRITY.PMCOMPLAINT, ";
            sql += "PDR_TECHNICALINTEGRITY.SCEPMDUE, ";
            sql += "PDR_TECHNICALINTEGRITY.SCEPMCOMPLETED, ";
            sql += "PDR_TECHNICALINTEGRITY.SCEPMCOMPLAINT, ";
            sql += "PDR_TECHNICALINTEGRITY.CMDUE, ";
            sql += "PDR_TECHNICALINTEGRITY.CMCOMPLETED, ";
            sql += "PDR_TECHNICALINTEGRITY.CMCOMPLAINT ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_TECHNICALINTEGRITY ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_TECHNICALINTEGRITY.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion

        #region Well Test and Sampling Status
        public static string InsertWellTestStatus()
        {
            string sql = "INSERT INTO PDR_WELLTEST (IDREPORT, ID_FACILITIES, WELLONPROGRAM, WELLSFLOWINGSTART, WELLSFLOWINGCURRENT, CUMMWELLTESTED, WELLSAMPLED, MERPLAN, MERACTUAL) ";
            sql += "VALUES (:lReportId, :iFacilityId, :sWellOnprogram, :sWellsFlowingStart, :sWellsFlowingCurrent, :sCummWellTested, :sWellSampled, :sMerPlan, :sMerActual)";
            return sql;//    "IDWELL 
        }
        public static string UpdateWellTestStatus()
        {
            string sql = "UPDATE PDR_WELLTEST SET WELLONPROGRAM = :sWellOnprogram, WELLSFLOWINGSTART = :sWellsFlowingStart, WELLSFLOWINGCURRENT = :sWellsFlowingCurrent, CUMMWELLTESTED = :sCummWellTested, ";
            sql += "WELLSAMPLED = :sWellSampled, MERPLAN = :sMerPlan, MERACTUAL = :sMerActual WHERE IDREPORT = :lReportId AND ID_FACILITIES = :iFacilityId";

            return sql;//    "IDWELL 
        }
        public static string getWellTestStatusFacilitiesByDistrict()
        {
            string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, ";
            sql += "PROD_FACILITIES.ID_DISTRICT, ";
            sql += "PROD_FACILITIES.FACILITIES, ";
            sql += "PDR_WELLTEST.IDWELL, ";
            sql += "PDR_WELLTEST.IDREPORT, ";
            sql += "PDR_WELLTEST.WELLONPROGRAM, ";
            sql += "PDR_WELLTEST.WELLSFLOWINGSTART, ";
            sql += "PDR_WELLTEST.WELLSFLOWINGCURRENT, ";
            sql += "PDR_WELLTEST.CUMMWELLTESTED, ";
            sql += "PDR_WELLTEST.WELLSAMPLED, ";
            sql += "PDR_WELLTEST.MERPLAN, ";
            sql += "PDR_WELLTEST.MERACTUAL ";
            sql += "FROM PROD_FACILITIES ";
            sql += "LEFT OUTER JOIN PDR_WELLTEST ";
            sql += "ON PROD_FACILITIES.ID_FACILITIES = PDR_WELLTEST.ID_FACILITIES ";
            sql += "WHERE PROD_FACILITIES.ID_DISTRICT = :iDistrictId";

            return sql;
        }
        #endregion
    }
}