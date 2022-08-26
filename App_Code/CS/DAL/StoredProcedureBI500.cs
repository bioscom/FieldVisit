using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedureBI500
/// </summary>
public class StoredProcedureBI500
{
	public StoredProcedureBI500()
	{
		//
		// 
		//
	}
    public static string getDistinctYear()
    {
        string sql = "SELECT DISTINCT TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') YYEAR FROM BI500_REQUEST WHERE BI500_REQUEST.DATE_SUBMITTED IS NOT NULL";
        return sql;
    }

    #region ===== Bright Idea Queries ========

    public static string CreateBIRequest()
    {
        string sql = "INSERT INTO BI500_REQUEST (IDREQUEST, REQUESTNO, USERID, FUNCTIONID, TITLE, CHAMPIONUSERID, SPONSORUSERID, BUS_CASE, ";
        sql += "IDBENEFIT, DATE_COMPLETION, DATE_SUBMITTED, OPPORTUNITYSTMT, STATUS, DEPTID, TEAMID, REQUESTTYPE) ";
        sql += "VALUES (:lRequestId, :sRequestNumber, :iUserId, :iFunctionId, :sTitle, :iChampion, :iSponsor, :sBuzCase, :iImpactedArea, ";
        sql += ":DATE_COMPLETION, :DATE_SUBMITTED, :sOpportunityStmt, :iStatus, :iDeptId, :iTeamId, :iRequestType)";

        return sql;
    }
    public static string UpdateBIRequest()
    {
        string sql = "UPDATE BI500_REQUEST SET CHAMPIONUSERID = :iChampion, SPONSORUSERID = :iSponsor, USERID = :iUserId, ";
        sql += "TITLE = :sTitle, BUS_CASE = :sBuzCase, IDBENEFIT = :iImpactedArea, DATE_COMPLETION = :DATE_COMPLETION, ";
        sql += "OPPORTUNITYSTMT = :sOpportunityStmt WHERE IDREQUEST = :lRequestId";
        
        return sql;
    }
    public static string getRequestMaster()
    {
        string sql = "SELECT BI500_REQUEST.IDREQUEST, BI500_REQUEST.REQUESTNO, BI500_REQUEST.TITLE, BI500_REQUEST.BUS_CASE, BI500_TEAMS.TEAMID, BI500_TEAMS.TEAM, ";
        sql += "TO_CHAR(BI500_REQUEST.DATE_COMPLETION, 'DD/MM/YYYY') AS DATE_COMPLETION, TO_CHAR(BI500_REQUEST.DATE_SUBMITTED, 'DD/MM/YYYY') AS DATE_SUBMITTED, BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, BI500_REQUEST.STATUS, ";
        sql += "REQINITIATOR.USERID, REQINITIATOR.FULLNAME, REQINITIATOR.EMAIL, REQCHAMPION.USERID AS CHAMPIONUSERID, REQCHAMPION.FULLNAME AS CHAMPIONFULLNAME, ";
        sql += "REQFOCALPOINT.USERID AS FOCALPOINTUSERID, REQFOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, REQFOCALPOINT.EMAIL AS FOCALPOINTEMAIL, ";
        sql += "REQCHAMPION.EMAIL AS CHAMPIONEMAIL, REQSPONSOR.USERID AS SPONSORUSERID, REQSPONSOR.FULLNAME AS SPONSORFULLNAME, REQSPONSOR.EMAIL AS SPONSOREMAIL, ";
        sql += "BI500_BENEFIT.IDBENEFIT, BI500_BENEFIT.BENEFIT, CPDMS_FUNCTIONS.FUNCTIONID, CPDMS_FUNCTIONS.FUNCTION, BI500_REQUEST.PHASE, BI500_REQUEST_APPROVAL.IDAPPROVAL, ";
        sql += "BI500_IMPROVEMENT.IMPROVEMENT, BI500_POTENTIAL.REP_POTENTIAL, BI500_DEPT.DEPTID, BI500_DEPT.DEPARTMENT, BI500_REQUEST.QTYBENEFIT, TO_CHAR(BI500_REQUEST.ACTUAL_DATE, 'DD/MM/YYYY') AS ACTUAL_DATE, ";
        sql += "BI500_REQUEST.AMOUNTSAVED, BI500_REQUEST.REQUESTTYPE, BI500_REQUEST.RETAINED FROM BI500_REQUEST ";
        sql += "INNER JOIN PROD_USERMGT REQINITIATOR ON BI500_REQUEST.USERID = REQINITIATOR.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQFOCALPOINT ON BI500_REQUEST.FOCALPOINTUSERID = REQFOCALPOINT.USERID ";
        sql += "INNER JOIN PROD_USERMGT REQCHAMPION ON BI500_REQUEST.CHAMPIONUSERID = REQCHAMPION.USERID ";
        sql += "INNER JOIN PROD_USERMGT REQSPONSOR ON BI500_REQUEST.SPONSORUSERID = REQSPONSOR.USERID ";
        sql += "INNER JOIN BI500_BENEFIT ON BI500_REQUEST.IDBENEFIT = BI500_BENEFIT.IDBENEFIT ";
        sql += "INNER JOIN CPDMS_FUNCTIONS ON BI500_REQUEST.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        sql += "INNER JOIN BI500_DEPT ON BI500_REQUEST.DEPTID = BI500_DEPT.DEPTID ";
        sql += "INNER JOIN BI500_TEAMS ON BI500_REQUEST.TEAMID = BI500_TEAMS.TEAMID ";
        sql += "left outer JOIN BI500_IMPROVEMENT ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";

        return sql;
    }
    public static string getRequestMaster2()
    {
        string sql = "SELECT DISTINCT BI500_REQUEST.IDREQUEST, BI500_REQUEST.REQUESTNO, BI500_REQUEST.TITLE, BI500_REQUEST.BUS_CASE, BI500_TEAMS.TEAMID, BI500_TEAMS.TEAM, ";
        sql += "TO_CHAR(BI500_REQUEST.DATE_COMPLETION, 'DD/MM/YYYY') AS DATE_COMPLETION, TO_CHAR(BI500_REQUEST.DATE_SUBMITTED, 'DD/MM/YYYY') AS DATE_SUBMITTED, ";
        sql += "BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, BI500_REQUEST.STATUS, REQINITIATOR.USERID, REQINITIATOR.FULLNAME, ";
        sql += "REQFOCALPOINT.USERID AS FOCALPOINTUSERID, REQFOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, REQFOCALPOINT.EMAIL AS FOCALPOINTEMAIL, ";
        sql += "REQINITIATOR.EMAIL, REQCHAMPION.USERID AS CHAMPIONUSERID, REQCHAMPION.FULLNAME AS CHAMPIONFULLNAME, ";
        sql += "REQCHAMPION.EMAIL AS CHAMPIONEMAIL, REQSPONSOR.USERID AS SPONSORUSERID, REQSPONSOR.FULLNAME AS SPONSORFULLNAME, REQSPONSOR.EMAIL AS SPONSOREMAIL, ";
        sql += "BI500_BENEFIT.IDBENEFIT, BI500_BENEFIT.BENEFIT, CPDMS_FUNCTIONS.FUNCTIONID, CPDMS_FUNCTIONS.FUNCTION, BI500_REQUEST.PHASE, ";
        sql += "BI500_IMPROVEMENT.IMPROVEMENT, BI500_POTENTIAL.REP_POTENTIAL, BI500_DEPT.DEPTID, BI500_DEPT.DEPARTMENT, BI500_REQUEST.QTYBENEFIT, TO_CHAR(BI500_REQUEST.ACTUAL_DATE, 'DD/MM/YYYY') AS ACTUAL_DATE, ";
        sql += "BI500_REQUEST.AMOUNTSAVED, BI500_REQUEST.REQUESTTYPE, BI500_REQUEST.RETAINED FROM BI500_REQUEST ";
        sql += "INNER JOIN PROD_USERMGT REQINITIATOR ON BI500_REQUEST.USERID = REQINITIATOR.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQFOCALPOINT ON BI500_REQUEST.FOCALPOINTUSERID = REQFOCALPOINT.USERID ";
        sql += "INNER JOIN PROD_USERMGT REQCHAMPION ON BI500_REQUEST.CHAMPIONUSERID = REQCHAMPION.USERID ";
        sql += "INNER JOIN PROD_USERMGT REQSPONSOR ON BI500_REQUEST.SPONSORUSERID = REQSPONSOR.USERID ";
        sql += "INNER JOIN BI500_BENEFIT ON BI500_REQUEST.IDBENEFIT = BI500_BENEFIT.IDBENEFIT ";
        sql += "INNER JOIN CPDMS_FUNCTIONS ON BI500_REQUEST.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        sql += "INNER JOIN BI500_DEPT ON BI500_REQUEST.DEPTID = BI500_DEPT.DEPTID ";
        sql += "INNER JOIN BI500_TEAMS ON BI500_REQUEST.TEAMID = BI500_TEAMS.TEAMID ";
        sql += "left outer JOIN BI500_IMPROVEMENT ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";

        return sql;
    }
    
    public static string getApprovedOrRejectedRequests()
    {
        string sql = getRequestMaster2();
        sql += "WHERE BI500_REQUEST.STATUS = :iStatus";

        return sql;
    }
    public static string getRequestsByStatus()
    {
        string sql = getRequestMaster();
        sql += "WHERE BI500_REQUEST.STATUS = :iStatus";

        return sql;
    }
    public static string getPendingRequests()
    {
        string sql = getRequestMaster();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus)";

        return sql;
    }
    public static string getMyPendingRequests()
    {
        string sql = getRequestMaster2();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) AND (BI500_REQUEST.USERID = :iUserId) ORDER BY DATE_SUBMITTED";

        return sql;
    }
    public static string getMyApprovedOrRejectedRequests()
    {
        string sql = getRequestMaster2();
        sql += "WHERE (BI500_REQUEST.STATUS = :iStatus) AND (BI500_REQUEST.USERID = :iUserId)";

        return sql;
    }
    public static string getRequestsPendingMyApprovalSupport()
    {
        string sql = getRequestMaster();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.STAND = :iStatus) AND (BI500_REQUEST_APPROVAL.USERID = :iUserId)";

        return sql;
    }
    public static string getBITeamApprovedOrRejectedRequests()
    {
        string sql = getRequestMaster();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.STAND = :iStand) AND (BI500_REQUEST_APPROVAL.IDROLE = :iRoleId)";

        return sql;
    }
    public static string getRequestsPendingBITeamSupport()
    {
        string sql = getRequestMaster2();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (((BI500_REQUEST_APPROVAL.STAND = :iStatus) OR (BI500_REQUEST_APPROVAL.STAND = :iStatus2)) AND (BI500_REQUEST_APPROVAL.USERID IS NULL))";

        return sql;
    }
    public static string getBrightIdeasSupportedByBITeam()
    {
        string sql = getRequestMaster2();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.STAND = :iStatus) AND (BI500_REQUEST_APPROVAL.IDROLE = :iRoleId)";

        return sql;
    }
    public static string getBrightIdeasRejectedByBITeam()
    {
        string sql = getRequestMaster2();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.STAND = :iStatus) AND (BI500_REQUEST_APPROVAL.IDROLE = :iRoleId)";

        return sql;
    }
    public static string getPendingBrightIdeasForLeanFocalPoint()
    {
        string sql = getRequestMaster2();

        sql += "INNER JOIN BI500_LEANFOCALPOINT ON BI500_LEANFOCALPOINT.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) AND (BI500_LEANFOCALPOINT.USERID = :iUserId)";

        return sql;
    }
    public static string getApprovedBrightIdeasForLeanFocalPoint()
    {
        string sql = getRequestMaster2();

        sql += "INNER JOIN BI500_LEANFOCALPOINT ON BI500_LEANFOCALPOINT.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        sql += "WHERE (BI500_REQUEST.STATUS = :iStatus) AND (BI500_LEANFOCALPOINT.USERID = :iUserId)";

        return sql;
    }
    public static string getPendingBrightIdeaRegister()
    {
        string sql = getRequestMaster2();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ORDER BY DATE_SUBMITTED";

        return sql;
    }
    public static string getCorporatePendingBrightIdeaRegister()
    {
        string sql = getRequestMaster2();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) AND (BI500_REQUEST.FUNCTIONID = :iFunction) ORDER BY DATE_SUBMITTED";

        return sql;
    }
    public static string getPendingBrightIdeaRegisterByYear()
    {
        string sql = getRequestMaster2();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }
    public static string getCorporatePendingBrightIdeaRegisterByYear()
    {
        string sql = getRequestMaster2();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) AND (BI500_REQUEST.FUNCTIONID = :iFunction) AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }
    public static string getApprovedBrightIdeaRegister()
    {
        string sql = getRequestMaster2();
        sql += "WHERE (BI500_REQUEST.STATUS = :iStatus)";

        return sql;
    }
    public static string getRequestsIApprovedSupportedOrRejected()
    {
        string sql = getRequestMaster();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.STAND = :iStatus) AND (BI500_REQUEST_APPROVAL.USERID = :iUserId)";

        return sql;
    }
    public static string getFocalPointPendingRequests()
    {
        string sql = getRequestMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) AND (BI500_REQUEST.FOCALPOINTUSERID = :iFocalPoint)";

        return sql;
    }
    public static string getFocalPointApprovedOrRejectedRequests()
    {
        string sql = getRequestMaster();
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";
        sql += "WHERE (BI500_REQUEST.STATUS = :iStatus) AND (BI500_REQUEST.FOCALPOINTUSERID = :iFocalPoint)";

        return sql;
    }

    #endregion

    #region =======Reporting Queries ======
    public static string getBrightIdeaReportHeader()
    {
        string sql = "SELECT DISTINCT BI500_REQUEST.IDREQUEST, BI500_REQUEST.REQUESTNO, CPDMS_FUNCTIONS.FUNCTIONID, CPDMS_FUNCTIONS.FUNCTION, BI500_REQUEST.TITLE, BI500_REQUEST.BUS_CASE, ";
        sql += "BI500_REQUEST.DATE_COMPLETION, BI500_REQUEST.DATE_SUBMITTED, BI500_REQUEST.TARGETSAVINGS, BI500_REQUEST.GATE, ";
        sql += "REQINITIATIVELEAD.USERID AS INITIATIVELEADUSERID, REQINITIATIVELEAD.FULLNAME AS INITIATIVELEADFULLNAME, REQINITIATIVELEAD.EMAIL AS INITIATIVELEADEMAIL, ";
        sql += "REQFOCALPOINT.USERID AS FOCALPOINTUSERID, REQFOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, REQFOCALPOINT.EMAIL AS FOCALPOINTEMAIL, ";
        sql += "BI500_REQUEST.IDBENEFIT, BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, BI500_REQUEST.STATUS, REQINITIATOR.USERID, REQINITIATOR.FULLNAME, ";
        sql += "REQINITIATOR.EMAIL, REQCHAMPION.USERID AS CHAMPIONUSERID, REQCHAMPION.FULLNAME AS CHAMPIONFULLNAME, REQCHAMPION.EMAIL AS CHAMPIONEMAIL, ";
        sql += "REQSPONSOR.USERID AS SPONSORUSERID, REQSPONSOR.FULLNAME AS SPONSORFULLNAME, REQSPONSOR.EMAIL AS SPONSOREMAIL, BI500_BENEFIT.IDBENEFIT, ";
        sql += "BI500_BENEFIT.BENEFIT, BI500_REQUEST.PHASE, BI500_REQUEST.IDIMPROVEMENT, ";
        sql += "BI500_IMPROVEMENT.IMPROVEMENT, BI500_POTENTIAL.IDREPLICATION, BI500_POTENTIAL.REP_POTENTIAL, BI500_DEPT.DEPTID, BI500_DEPT.DEPARTMENT, BI500_TEAMS.TEAMID, BI500_TEAMS.TEAM, ";
        sql += "BI500_REQUEST.QTYBENEFIT, BI500_REQUEST.ACTUAL_DATE, ";
        sql += "TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'WW')), BI500_REQUEST.AMOUNTSAVED, BI500_REQUEST.REQUESTTYPE, BI500_REQUEST.RETAINED FROM BI500_REQUEST ";
        sql += "INNER JOIN PROD_USERMGT REQINITIATOR ON BI500_REQUEST.USERID = REQINITIATOR.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQINITIATIVELEAD ON BI500_REQUEST.INITIATIVELEADUSERID = REQINITIATIVELEAD.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQFOCALPOINT ON BI500_REQUEST.FOCALPOINTUSERID = REQFOCALPOINT.USERID ";
        sql += "INNER JOIN PROD_USERMGT REQCHAMPION ON BI500_REQUEST.CHAMPIONUSERID = REQCHAMPION.USERID ";
        sql += "INNER JOIN PROD_USERMGT REQSPONSOR ON BI500_REQUEST.SPONSORUSERID = REQSPONSOR.USERID ";
        sql += "INNER JOIN BI500_BENEFIT ON BI500_REQUEST.IDBENEFIT = BI500_BENEFIT.IDBENEFIT ";
        sql += "INNER JOIN CPDMS_FUNCTIONS ON BI500_REQUEST.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        sql += "INNER JOIN BI500_DEPT ON BI500_REQUEST.DEPTID = BI500_DEPT.DEPTID ";
        sql += "INNER JOIN BI500_IMPROVEMENT ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";
        sql += "INNER JOIN BI500_TEAMS ON BI500_REQUEST.TEAMID = BI500_TEAMS.TEAMID ";

        return sql;
    }

    public static string getBrightIdeaByWeek()
    {
        //string sql = "SELECT DISTINCT BI500_REQUEST.IDREQUEST, BI500_REQUEST.REQUESTNO, BI500_REQUEST.FUNCTIONID, BI500_REQUEST.TITLE, BI500_REQUEST.BUS_CASE, ";
        //sql += "TO_CHAR(BI500_REQUEST.DATE_COMPLETION, 'DD/MM/YYYY') AS DATE_COMPLETION, TO_CHAR(BI500_REQUEST.DATE_SUBMITTED, 'DD/MM/YYYY') AS DATE_SUBMITTED, ";
        //sql += "BI500_REQUEST.IDBENEFIT, BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, BI500_REQUEST.STATUS, REQINITIATOR.USERID, REQINITIATOR.FULLNAME, ";
        //sql += "REQINITIATOR.EMAIL, REQCHAMPION.USERID AS CHAMPIONUSERID, REQCHAMPION.FULLNAME AS CHAMPIONFULLNAME, REQCHAMPION.EMAIL AS CHAMPIONEMAIL, ";
        //sql += "REQFOCALPOINT.USERID AS FOCALPOINTUSERID, REQFOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, REQFOCALPOINT.EMAIL AS FOCALPOINTEMAIL, ";
        //sql += "REQSPONSOR.USERID AS SPONSORUSERID, REQSPONSOR.FULLNAME AS SPONSORFULLNAME, REQSPONSOR.EMAIL AS SPONSOREMAIL, BI500_BENEFIT.IDBENEFIT, ";
        //sql += "BI500_BENEFIT.BENEFIT, CPDMS_FUNCTIONS.FUNCTIONID, CPDMS_FUNCTIONS.FUNCTION, BI500_REQUEST.PHASE, BI500_IMPROVEMENT.IMPROVEMENT, BI500_DEPT.DEPTID, BI500_DEPT.DEPARTMENT, ";
        //sql += "BI500_POTENTIAL.REP_POTENTIAL, BI500_REQUEST.QTYBENEFIT, TO_CHAR(BI500_REQUEST.ACTUAL_DATE, 'DD/MM/YYYY') AS ACTUAL_DATE, ";
        //sql += "TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'WW')), BI500_REQUEST.AMOUNTSAVED FROM BI500_REQUEST ";
        //sql += "INNER JOIN PROD_USERMGT REQINITIATOR ON BI500_REQUEST.USERID = REQINITIATOR.USERID ";
        //sql += "INNER JOIN PROD_USERMGT REQCHAMPION ON BI500_REQUEST.CHAMPIONUSERID = REQCHAMPION.USERID ";
        //sql += "INNER JOIN PROD_USERMGT REQSPONSOR ON BI500_REQUEST.SPONSORUSERID = REQSPONSOR.USERID ";
        //sql += "INNER JOIN PROD_USERMGT REQFOCALPOINT ON BI500_REQUEST.FOCALPOINTUSERID = REQFOCALPOINT.USERID ";
        //sql += "INNER JOIN BI500_BENEFIT ON BI500_REQUEST.IDBENEFIT = BI500_BENEFIT.IDBENEFIT ";
        //sql += "INNER JOIN CPDMS_FUNCTIONS ON BI500_REQUEST.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        //sql += "INNER JOIN BI500_DEPT ON BI500_REQUEST.DEPTID = BI500_DEPT.DEPTID ";
        //sql += "INNER JOIN BI500_IMPROVEMENT ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        //sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";

        string sql = getBrightIdeaReportHeader();
        sql += "WHERE (TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'WW')) = :iWeek ";
        sql += "AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL AND BI500_REQUEST.REQUESTTYPE = :iRequestType)";

        //sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }

    public static string getBrightIdeaByYear()
    {
        string sql = getRequestMaster2();
        sql += "WHERE TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL AND BI500_REQUEST.REQUESTTYPE = :iRequestType";
        return sql;
    }

    public static string getBrightIdeaByFunctionWeek()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE (TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'WW')) = :iWeek AND BI500_REQUEST.FUNCTIONID = :iFunctionId ";
        sql += "AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.REQUESTTYPE = :iRequestType AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL)";

        //sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }

    public static string getBrightIdeaByDepartmentWeek()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE (TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'WW')) = :iWeek AND BI500_REQUEST.DEPTID = :iDeptId AND BI500_REQUEST.REQUESTTYPE = :iRequestType ";
        sql += "AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL)";

        //sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }

    public static string getBrightIdeaByTeamWeek()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE (TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'WW')) = :iWeek AND BI500_REQUEST.TEAMID = :iTeamId AND BI500_REQUEST.REQUESTTYPE = :iRequestType ";
        sql += "AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL)";

        //sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }

    public static string getBrightIdeaByFunctionMonth()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE (TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'MM')) = :iMonth AND BI500_REQUEST.FUNCTIONID = :iFunctionId AND BI500_REQUEST.REQUESTTYPE = :iRequestType ";
        sql += "AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL)";
        return sql;
    }

    public static string getBrightIdeaByFunctionYear()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE BI500_REQUEST.FUNCTIONID = :iFunctionId AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.REQUESTTYPE = :iRequestType AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL";
        return sql;
    }

    public static string getBrightIdeaByDepartmentYear()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE BI500_REQUEST.DEPTID = :iDeptId AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.REQUESTTYPE = :iRequestType AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL";
        return sql;
    }

    public static string getBrightIdeaByTeamYear()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE BI500_REQUEST.TEAMID = :iTeamId AND BI500_REQUEST.REQUESTTYPE = :iRequestType AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL";
        return sql;
    }

    public static string getBrightIdeaByDepartmentMonth()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE (TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'MM')) = :iMonth AND BI500_REQUEST.DEPTID = :iDeptId AND BI500_REQUEST.REQUESTTYPE = :iRequestType ";
        sql += "AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL)";

        //sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }

    public static string getBrightIdeaByTeamMonth()
    {
        string sql = getBrightIdeaReportHeader();
        sql += "WHERE (TO_NUMBER(TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED,'DD/MM/YYYY'),'MM')) = :iMonth AND BI500_REQUEST.TEAMID = :iTeamId AND BI500_REQUEST.REQUESTTYPE = :iRequestType ";
        sql += "AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear AND BI500_REQUEST.DATE_SUBMITTED IS NOT NULL)";

        //sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus AND TO_CHAR(TO_DATE(BI500_REQUEST.DATE_SUBMITTED, 'DD-MON-YY') ,'YYYY') = :iYear)";
        //AND TO_CHAR(TO_DATE(EIP_PROPOSAL.DATE_LAST_ACTIONED, 'DD-MON-YY') ,'YYYY') = :iYYear 
        return sql;
    }

    #endregion

    #region Common Between BI and Cost Reduction
    public static string AssignRequestToNextApprover()
    {
        string sql = "INSERT INTO BI500_REQUEST_APPROVAL (IDREQUEST, USERID, IDROLE, DATE_RECEIVED) VALUES (:lRequestId, :iUserId, :iRoleId, :sDateReceived)";
        return sql;
    }
    public static string AssignRequestToBITeam()
    {
        string sql = "INSERT INTO BI500_REQUEST_APPROVAL (IDREQUEST, IDROLE, DATE_RECEIVED) VALUES (:lRequestId, :iRoleId, :sDateReceived)";
        return sql;
    }
    public static string RouteRequestWithinApprovers()
    {
        string sql = "UPDATE BI500_REQUEST_APPROVAL SET USERID = :iUserId, DATE_RECEIVED = :sDateReceived WHERE (IDREQUEST = :lRequestId) AND (IDROLE = :iRoleId)";
        return sql;
    }
    public static string AssignInitiativeLeadChampionSponsor()
    {
        string sql = "UPDATE BI500_REQUEST SET INITIATIVELEADUSERID = :iInitiativeLead, CHAMPIONUSERID = :iChampion, SPONSORUSERID = :iSponsor WHERE IDREQUEST = :lRequestId";
        return sql;
    }
    public static string AssignProjectSponsor()
    {
        string sql = "UPDATE BI500_REQUEST SET SPONSORUSERID = :iSponsor, STATUS = :iStatus WHERE IDREQUEST = :lRequestId";
        return sql;
    }
    public static string AssignFocalPoint()
    {
        string sql = "UPDATE BI500_REQUEST SET FOCALPOINTUSERID = :iFocalPoint, STATUS = :iStatus WHERE IDREQUEST = :lRequestId";
        return sql;
    }

    #endregion

    #region ================================  Benefit ============================

    public static string getBenefits()
    {
        string sql = "SELECT IDBENEFIT, BENEFIT FROM BI500_BENEFIT";

        return sql;
    }

    public static string getBenefitById()
    {
        string sql = "SELECT IDBENEFIT, BENEFIT FROM BI500_BENEFIT WHERE IDBENEFIT = :iBenefitId";

        return sql;
    }

    #endregion

    #region ================================ Potential  Benefit ============================

    public static string getPotentialBenefits()
    {
        string sql = "SELECT IDREPLICATION, REP_POTENTIAL FROM BI500_POTENTIAL";

        return sql;
    }

    public static string getPotentialBenefitById()
    {
        string sql = "SELECT IDREPLICATION, REP_POTENTIAL FROM BI500_POTENTIAL WHERE IDREPLICATION = :iBenefitId";

        return sql;
    }

    #endregion

    #region ================================  Approval ============================

    public static string getBIApprovalRequestId()
    {
        string sql = "SELECT PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, PROD_USERMGT.REFIND, PROD_USERMGT.STATUS, ";
        sql += "PROD_USERMGT.PASSWORD, PROD_USERMGT.DELIGATED, BI500_REQUEST_APPROVAL.IDAPPROVAL, BI500_REQUEST_APPROVAL.IDREQUEST, BI500_REQUEST_APPROVAL.IDROLE, ";
        sql += "BI500_REQUEST_APPROVAL.STAND, BI500_REQUEST_APPROVAL.DATE_RECEIVED, ";
        sql += "BI500_REQUEST_APPROVAL.DATE_REVIEWED, BI500_REQUEST_APPROVAL.COMMENTS ";
        sql += "FROM PROD_USERMGT ";
        sql += "RIGHT OUTER JOIN BI500_REQUEST_APPROVAL ON PROD_USERMGT.USERID = BI500_REQUEST_APPROVAL.USERID ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.IDREQUEST = :lRequestId) ORDER BY BI500_REQUEST_APPROVAL.IDROLE";

        return sql;
    }

    public static string getBIApprovalRequestRoleId()
    {
        string sql = "SELECT BI500_REQUEST_APPROVAL.IDAPPROVAL, BI500_REQUEST_APPROVAL.STAND, BI500_REQUEST_APPROVAL.DATE_RECEIVED, ";
        sql += "BI500_REQUEST_APPROVAL.DATE_REVIEWED, BI500_REQUEST_APPROVAL.COMMENTS, BI500_REQUEST_APPROVAL.IDREQUEST, ";
        sql += "PROD_USERMGT.USERID, PROD_USERMGT.USERNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.FULLNAME, PROD_USERMGT.STATUS, PROD_USERMGT.ROLEID, BI500_REQUEST_APPROVAL.IDROLE, ";
        sql += "PROD_USERMGT.DELIGATED, PROD_USERMGT.PASSWORD, PROD_USERMGT.REFIND ";
        sql += "FROM BI500_REQUEST_APPROVAL, PROD_USERMGT ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.USERID = PROD_USERMGT.USERID) AND (BI500_REQUEST_APPROVAL.IDREQUEST = :lRequestId) AND (BI500_REQUEST_APPROVAL.IDROLE = :iRoleId)";

        return sql;
    }
    public static string getBIApprovalByApprovalId()
    {
        string sql = "SELECT BI500_REQUEST_APPROVAL.IDAPPROVAL, BI500_REQUEST_APPROVAL.STAND, TO_CHAR(BI500_REQUEST_APPROVAL.DATE_RECEIVED, 'DD-MM-YYYY')DATE_RECEIVED, ";
        sql += "TO_CHAR(BI500_REQUEST_APPROVAL.DATE_REVIEWED, 'DD-MM-YYYY')DATE_REVIEWED, BI500_REQUEST_APPROVAL.COMMENTS, BI500_REQUEST_APPROVAL.IDREQUEST, ";
        sql += "PROD_USERMGT.USERID, PROD_USERMGT.USERNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.FULLNAME, PROD_USERMGT.STATUS, PROD_USERMGT.ROLEID, BI500_REQUEST_APPROVAL.IDROLE, ";
        sql += "PROD_USERMGT.DELIGATED, PROD_USERMGT.PASSWORD, PROD_USERMGT.REFIND ";
        sql += "FROM BI500_REQUEST_APPROVAL, PROD_USERMGT ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.USERID = PROD_USERMGT.USERID) AND (BI500_REQUEST_APPROVAL.IDAPPROVAL = :lApprovalId) ORDER BY BI500_REQUEST_APPROVAL.IDROLE";

        return sql;
    }
    public static string ActionBIRequest()
    {
        string sql = "UPDATE BI500_REQUEST_APPROVAL SET STAND = :iStand, USERID = :iUserId, COMMENTS = :sComments, DATE_REVIEWED = :sDateReviewed WHERE (IDREQUEST = :lRequestId) AND (IDROLE = :iRoleId)";
        return sql;
    }
    public static string UpdateRequestStatus()
    {
        string sql = "UPDATE BI500_REQUEST SET STATUS = :iStatus WHERE (IDREQUEST = :lRequestId)";
        return sql;
    }
    public static string UpdateStageGate()
    {
        string sql = "UPDATE BI500_REQUEST SET GATE = :iValue WHERE (IDREQUEST = :lRequestId)";
        return sql;
    }
    public static string MaintainInDatabase()
    {
        string sql = "UPDATE BI500_REQUEST SET STATUS = :iStatus, RETAINED = :sReasonRetained WHERE (IDREQUEST = :lRequestId)";
        return sql;
    }

    public static string UpdateRequestPhase()
    {
        string sql = "UPDATE BI500_REQUEST SET PHASE = :iPhase, TEAM_MEMBER = :sMembers WHERE (IDREQUEST = :lRequestId)";
        return sql;
    }
    public static string UpdateRequestSustainPhase()
    {
        string sql = "UPDATE BI500_REQUEST SET PHASE = :iPhase, IDIMPROVEMENT = :iImprovement, IDREPLICATION = :iRepPotential, ";
        sql += "QTYBENEFIT = :iQtyBenefit, ACTUAL_DATE = :ActualFinishDate WHERE (IDREQUEST = :lRequestId)";
        return sql;
    }
    #endregion

    #region ==============================  Business Lean Focal Point =======================

    public static string assignFocalPointToBusiness()
    {
        string sql = "INSERT INTO BI500_LEANFOCALPOINT (USERID, FUNCTIONID) VALUES (:iUserId, :iFunctionId)";
        return sql;
    }
    public static string updateFocalPointToBusiness()
    {
        string sql = "UPDATE BI500_LEANFOCALPOINT SET USERID = :iUserId, FUNCTIONID = :iFunctionId WHERE IDFOCALPOINT = :iFocalPointId";
        return sql;
    }
    public static string getBusinessUnitFocalPoint()
    {
        string sql = "SELECT USERID, FUNCTIONID, IDFOCALPOINT FROM BI500_LEANFOCALPOINT WHERE USERID = :iUserId";
        return sql;
    }
    public static string getBusinessUnitFocalPoints()
    {
        //string sql = "SELECT USERID, FUNCTIONID, IDFOCALPOINT FROM BI500_LEANFOCALPOINT";

        string sql = "SELECT BI500_LEANFOCALPOINT.USERID, BI500_LEANFOCALPOINT.FUNCTIONID, BI500_LEANFOCALPOINT.IDFOCALPOINT, PROD_USERMGT.ROLEIDBI ";
        sql += "FROM BI500_LEANFOCALPOINT INNER JOIN PROD_USERMGT ON BI500_LEANFOCALPOINT.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_USERMGT.ROLEIDBI = :iRole";

        return sql;
    }
    public static string getBusinessUnitFocalPointsByFunction()
    {
        string sql = "SELECT USERID, FUNCTIONID, IDFOCALPOINT FROM BI500_LEANFOCALPOINT WHERE FUNCTIONID = :iFunctionId";
        return sql;
    }
    #endregion

    #region Business Improvement Request Reviewers
    public static string InsertReviewer()
    {
        string sql = "INSERT INTO BI500_BILEANREVIEWER (USERID) VALUES (:iUserId)";
        return sql;
    }

    public static string InsertStageGater()
    {
        string sql = "INSERT INTO BI500_BILEANREVIEWER (USERID, BICR) VALUES (:iUserId, :iValue)";
        return sql;
    }
    public static string UpdateReviewer()
    {
        string sql = "UPDATE BI500_BILEANREVIEWER SET USERID = :iUserId WHERE IDREVIEWER = :iReviewId";
        return sql;
    }
    public static string getBILeanReviewers()
    {
        string sql = "SELECT BI500_BILEANREVIEWER.IDREVIEWER, BI500_BILEANREVIEWER.BICR, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME FROM PROD_USERMGT ";
        sql += "INNER JOIN BI500_BILEANREVIEWER ON PROD_USERMGT.USERID = BI500_BILEANREVIEWER.USERID";
        
        return sql;
    }

    public static string getCRStageGaters()
    {
        string sql = "SELECT BI500_BILEANREVIEWER.IDREVIEWER, BI500_BILEANREVIEWER.BICR, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME FROM PROD_USERMGT ";
        sql += "INNER JOIN BI500_BILEANREVIEWER ON PROD_USERMGT.USERID = BI500_BILEANREVIEWER.USERID WHERE BI500_BILEANREVIEWER.BICR = '2'";

        return sql;
    }

    public static string getBILeanReviewerByUserId()
    {
        string sql = "SELECT BI500_BILEANREVIEWER.IDREVIEWER, BI500_BILEANREVIEWER.BICR, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME FROM PROD_USERMGT ";
        sql += "INNER JOIN BI500_BILEANREVIEWER ON PROD_USERMGT.USERID = BI500_BILEANREVIEWER.USERID WHERE PROD_USERMGT.USERID = :iUserId";

        return sql;
    }
    public static string getCRStageGaterByUserId()
    {
        string sql = "SELECT BI500_BILEANREVIEWER.IDREVIEWER, BI500_BILEANREVIEWER.BICR, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME FROM PROD_USERMGT ";
        sql += "INNER JOIN BI500_BILEANREVIEWER ON PROD_USERMGT.USERID = BI500_BILEANREVIEWER.USERID ";
        sql += "WHERE PROD_USERMGT.USERID = :iUserId AND BI500_BILEANREVIEWER.BICR = '2'";

        return sql;
    }

    public static string RemoveFromReviewers()
    {
        string sql = "DELETE FROM BI500_BILEANREVIEWER WHERE USERID = :iUserId ";
        return sql;
    }

    public static string RemoveFromStageGaters()
    {
        string sql = "DELETE FROM BI500_BILEANREVIEWER WHERE USERID = :iUserId AND BI500_BILEANREVIEWER.BICR = '2'";
        return sql;
    }


    #endregion

    #region Team, Department and Function
    //Introducing Departments

    //public static string getDepartments()
    //{
    //    string sql = "SELECT DEPTID, FUNCTIONID, DEPARTMENT FROM BI500_DEPT";
    //    return sql;
    //}

    public static string getDepartmentByFunctionId()
    {
        string sql = "SELECT DEPTID, FUNCTIONID, DEPARTMENT FROM BI500_DEPT WHERE FUNCTIONID = :iFunctionId ORDER BY DEPARTMENT";
        return sql;
    }

    public static string getDepartmentById()
    {
        string sql = "SELECT DEPTID, FUNCTIONID, DEPARTMENT FROM BI500_DEPT WHERE DEPTID = :iDeptId ORDER BY DEPARTMENT";
        return sql;
    }

    public static string AddNewDepartment()
    {
        string sql = "INSERT INTO BI500_DEPT (FUNCTIONID, DEPARTMENT) VALUES (:iFunctionId, :sDepartment)";
        return sql;
    }
    public static string AddNewTeam()
    {
        string sql = "INSERT INTO BI500_TEAMS (DEPTID, TEAM) VALUES (:iDepartmentId, :sTeam)";
        return sql;
    }

    public static string getTeamsByDepartmentId()
    {
        string sql = "SELECT TEAMID, DEPTID, TEAM FROM BI500_TEAMS WHERE DEPTID = :iDepartmentId ORDER BY TEAM";
        return sql;
    }
    public static string getTeams()
    {
        string sql = "SELECT TEAMID, DEPTID, TEAM FROM BI500_TEAMS ORDER BY TEAM";
        return sql;
    }
    public static string getTeamById()
    {
        string sql = "SELECT TEAMID, DEPTID, TEAM FROM BI500_TEAMS WHERE TEAMID = :iTeamId ORDER BY TEAM";
        return sql;
    }

    public static string getTeamMembersById()
    {
        string sql = "SELECT ID, TEAMID, USERID FROM BI500_USER_TEAM WHERE TEAMID = :iTeamId";
        return sql;
    }

    public static string getTeamByUserId()
    {
        string sql = "SELECT ID, TEAMID, USERID FROM BI500_USER_TEAM WHERE USERID = :iUserId";
        return sql;
    }

    public static string AddTeamMember()
    {
        string sql = "INSERT INTO BI500_USER_TEAM (TEAMID, USERID) VALUES (:iTeamId, :iUserId)";
        return sql;
    }

    public static string UpdateTeamMember()
    {
        string sql = "UPDATE BI500_USER_TEAM SET TEAMID = :iTeamId WHERE USERID = :iUserId";
        return sql;
    }
    #endregion

    #region Request Onbehalf of someone

    public static string InsertOnbehalf()
    {
        string sql = "INSERT INTO BI500_REQUEST_ONBEHALF (IDREQUEST, FULLNAME, EMAILADDRESS) VALUES (:lRequestId, :sFullName, :sEmailAddress)";
        return sql;
    }

    public static string UpdateOnbehalf()
    {
        string sql = "UPDATE BI500_REQUEST_ONBEHALF SET FULLNAME = :sFullName, EMAILADDRESS = :sEmailAddress WHERE IDREQUEST = :lRequestId";
        return sql;
    }

    public static string getRequestOnbehalf()
    {
        string sql = "SELECT ONBEHALFID, IDREQUEST, FULLNAME, EMAILADDRESS FROM BI500_REQUEST_ONBEHALF WHERE IDREQUEST = :lRequestId";
        return sql;
    }


    #endregion

    #region ======================= Improvement Ideas Queries    ================================

    public static string CreateCostReductionIdea()
    {
        string sql = "INSERT INTO BI500_REQUEST (IDREQUEST, REQUESTNO, USERID, FUNCTIONID, TITLE, BUS_CASE, IDBENEFIT, DATE_SUBMITTED, OPPORTUNITYSTMT, STATUS, DEPTID, TEAMID, REQUESTTYPE, AMOUNTSAVED, TARGETSAVINGS) ";
        sql += "VALUES (:lRequestId, :sRequestNumber, :iUserId, :iFunctionId, :sTitle, :sBuzCase, :iImpactedArea, :DATE_SUBMITTED, :sOpportunityStmt, :iStatus, :iDeptId, :iTeamId, :iRequestType, :dActualSavings, :dTargetSavings)";

        return sql;
    }
    public static string UpdateCostReductionIdea()
    {
        string sql = "UPDATE BI500_REQUEST SET USERID = :iUserId, TITLE = :sTitle, BUS_CASE = :sBuzCase, IDBENEFIT = :iImpactedArea, ";
        sql += "OPPORTUNITYSTMT = :sOpportunityStmt, FUNCTIONID =:iFunctionId, DEPTID =:iDeptId, TEAMID = :iTeamId, AMOUNTSAVED = :dActualSavings, TARGETSAVINGS = :dTargetSavings WHERE IDREQUEST = :lRequestId";

        return sql;
    }
    public static string getCostReductionMaster()
    {
        string sql = "SELECT DISTINCT BI500_REQUEST.IDREQUEST, BI500_REQUEST.REQUESTNO, BI500_REQUEST.TITLE, BI500_REQUEST.BUS_CASE,  BI500_TEAMS.TEAMID,  BI500_TEAMS.TEAM, BI500_REQUEST.FUNCTIONID, BI500_REQUEST.DEPTID, BI500_REQUEST.IDIMPROVEMENT, BI500_REQUEST.IDREPLICATION, ";
        sql += "BI500_REQUEST.DATE_COMPLETION, BI500_REQUEST.DATE_SUBMITTED, BI500_REQUEST.ACTUAL_DATE, ";
        sql += "BI500_REQUEST.OPPORTUNITYSTMT,  BI500_REQUEST.TEAM_MEMBER, ";
        sql += "BI500_REQUEST.STATUS,  REQINITIATOR.USERID,  REQINITIATOR.FULLNAME,  REQINITIATOR.EMAIL, ";
        sql += "REQINITIATIVELEAD.USERID AS INITIATIVELEADUSERID, REQINITIATIVELEAD.FULLNAME AS INITIATIVELEADFULLNAME, REQINITIATIVELEAD.EMAIL AS INITIATIVELEADEMAIL, ";
        sql += "REQFOCALPOINT.USERID AS FOCALPOINTUSERID, REQFOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, REQFOCALPOINT.EMAIL AS FOCALPOINTEMAIL, ";
        sql += "REQCHAMPION.USERID AS CHAMPIONUSERID, REQCHAMPION.FULLNAME AS CHAMPIONFULLNAME, REQCHAMPION.EMAIL AS CHAMPIONEMAIL, ";
        sql += "REQSPONSOR.USERID AS SPONSORUSERID, REQSPONSOR.FULLNAME AS SPONSORFULLNAME, REQSPONSOR.EMAIL AS SPONSOREMAIL, ";
        sql += "BI500_BENEFIT.IDBENEFIT, BI500_BENEFIT.BENEFIT, BI500_REQUEST.PHASE, BI500_IMPROVEMENT.IMPROVEMENT, BI500_POTENTIAL.REP_POTENTIAL, ";
        sql += "BI500_REQUEST.QTYBENEFIT, BI500_REQUEST.AMOUNTSAVED, BI500_REQUEST.TARGETSAVINGS, BI500_REQUEST.GATE, BI500_REQUEST.REQUESTTYPE, BI500_REQUEST.RETAINED ";
        sql += "FROM BI500_REQUEST ";
        sql += "INNER JOIN PROD_USERMGT REQINITIATOR ON BI500_REQUEST.USERID = REQINITIATOR.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQINITIATIVELEAD ON BI500_REQUEST.INITIATIVELEADUSERID = REQINITIATIVELEAD.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQFOCALPOINT ON BI500_REQUEST.FOCALPOINTUSERID = REQFOCALPOINT.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQCHAMPION ON BI500_REQUEST.CHAMPIONUSERID = REQCHAMPION.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQSPONSOR ON BI500_REQUEST.SPONSORUSERID = REQSPONSOR.USERID ";
        sql += "INNER JOIN BI500_BENEFIT ON BI500_REQUEST.IDBENEFIT = BI500_BENEFIT.IDBENEFIT ";
        sql += "INNER JOIN BI500_TEAMS ON BI500_REQUEST.TEAMID = BI500_TEAMS.TEAMID ";
        sql += "INNER JOIN BI500_IMPROVEMENT ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";

        return sql;
    }

    //Used for linking to approval table
    public static string getCostReductionMaster2()
    {
        string sql = "SELECT BI500_REQUEST.IDREQUEST, BI500_REQUEST.REQUESTNO, BI500_REQUEST.TITLE, BI500_REQUEST.BUS_CASE, BI500_TEAMS.TEAMID, BI500_TEAMS.TEAM, ";
        sql += "BI500_REQUEST.DATE_COMPLETION, BI500_REQUEST.DATE_SUBMITTED, BI500_REQUEST.ACTUAL_DATE, ";
        sql += "BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, ";
        sql += "BI500_REQUEST.STATUS, REQINITIATOR.USERID, REQINITIATOR.FULLNAME, REQINITIATOR.EMAIL, ";
        sql += "REQINITIATIVELEAD.USERID AS INITIATIVELEADUSERID, REQINITIATIVELEAD.FULLNAME AS INITIATIVELEADFULLNAME, REQINITIATIVELEAD.EMAIL AS INITIATIVELEADEMAIL, ";
        sql += "REQFOCALPOINT.USERID AS FOCALPOINTUSERID, REQFOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, REQFOCALPOINT.EMAIL AS FOCALPOINTEMAIL, ";
        sql += "REQCHAMPION.USERID AS CHAMPIONUSERID, REQCHAMPION.FULLNAME AS CHAMPIONFULLNAME, REQCHAMPION.EMAIL AS CHAMPIONEMAIL, ";
        sql += "REQSPONSOR.USERID AS SPONSORUSERID, REQSPONSOR.FULLNAME AS SPONSORFULLNAME, REQSPONSOR.EMAIL AS SPONSOREMAIL, ";
        sql += "BI500_BENEFIT.IDBENEFIT, BI500_BENEFIT.BENEFIT, CPDMS_FUNCTIONS.FUNCTIONID, CPDMS_FUNCTIONS.FUNCTION, BI500_REQUEST.PHASE, BI500_REQUEST_APPROVAL.IDAPPROVAL, ";
        sql += "BI500_IMPROVEMENT.IMPROVEMENT, BI500_POTENTIAL.REP_POTENTIAL, BI500_DEPT.DEPTID, BI500_DEPT.DEPARTMENT, BI500_REQUEST.QTYBENEFIT, ";
        sql += "BI500_REQUEST.AMOUNTSAVED, BI500_REQUEST.TARGETSAVINGS, BI500_REQUEST.GATE, BI500_REQUEST.REQUESTTYPE, BI500_REQUEST.RETAINED FROM BI500_REQUEST ";
        sql += "INNER JOIN PROD_USERMGT REQINITIATOR ON BI500_REQUEST.USERID = REQINITIATOR.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQINITIATIVELEAD ON BI500_REQUEST.INITIATIVELEADUSERID = REQINITIATIVELEAD.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQFOCALPOINT ON BI500_REQUEST.FOCALPOINTUSERID = REQFOCALPOINT.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQCHAMPION ON BI500_REQUEST.CHAMPIONUSERID = REQCHAMPION.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQSPONSOR ON BI500_REQUEST.SPONSORUSERID = REQSPONSOR.USERID ";
        sql += "INNER JOIN BI500_BENEFIT ON BI500_REQUEST.IDBENEFIT = BI500_BENEFIT.IDBENEFIT ";
        sql += "INNER JOIN CPDMS_FUNCTIONS ON BI500_REQUEST.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        sql += "INNER JOIN BI500_DEPT ON BI500_REQUEST.DEPTID = BI500_DEPT.DEPTID ";
        sql += "INNER JOIN BI500_TEAMS ON BI500_REQUEST.TEAMID = BI500_TEAMS.TEAMID ";
        sql += "INNER JOIN BI500_IMPROVEMENT ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";

        return sql;
    }
    public static string getCostReductionRequestById()
    {
        string sql = "SELECT BI500_REQUEST.IDREQUEST, BI500_IMPROVEMENT.IMPROVEMENT, BI500_IMPROVEMENT.IDIMPROVEMENT, BI500_POTENTIAL.IDREPLICATION, BI500_POTENTIAL.REP_POTENTIAL, ";
        sql += "BI500_REQUEST.USERID, BI500_REQUEST.DEPTID, BI500_REQUEST.TEAMID, BI500_REQUEST.SPONSORUSERID, BI500_REQUEST.TITLE, BI500_REQUEST.INITIATIVELEADUSERID, ";
        sql += "BI500_REQUEST.CHAMPIONUSERID, BI500_REQUEST.IDBENEFIT, BI500_REQUEST.BUS_CASE, ";
        sql += "BI500_REQUEST.DATE_COMPLETION, BI500_REQUEST.DATE_SUBMITTED, BI500_REQUEST.ACTUAL_DATE, BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, ";
        sql += "BI500_REQUEST.STATUS, BI500_REQUEST.REQUESTNO, BI500_REQUEST.PHASE, BI500_REQUEST.QTYBENEFIT, BI500_REQUEST.RETAINED ";
        sql += "FROM BI500_IMPROVEMENT ";
        sql += "INNER JOIN BI500_REQUEST ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";
        sql += "WHERE (BI500_REQUEST.IDREQUEST = :lRequestId) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType)";

        return sql;
    }

    public static string getRequestById()
    {
        string sql = "SELECT BI500_REQUEST.IDREQUEST, BI500_IMPROVEMENT.IMPROVEMENT, BI500_IMPROVEMENT.IDIMPROVEMENT, BI500_POTENTIAL.IDREPLICATION, BI500_POTENTIAL.REP_POTENTIAL, ";
        sql += "BI500_REQUEST.USERID, BI500_REQUEST.FUNCTIONID, BI500_REQUEST.DEPTID, BI500_REQUEST.TEAMID, BI500_REQUEST.SPONSORUSERID, BI500_REQUEST.TITLE, ";
        sql += "BI500_REQUEST.CHAMPIONUSERID, BI500_REQUEST.IDBENEFIT, BI500_REQUEST.FOCALPOINTUSERID, BI500_REQUEST.INITIATIVELEADUSERID, BI500_REQUEST.BUS_CASE, ";
        sql += "BI500_REQUEST.DATE_COMPLETION, BI500_REQUEST.DATE_SUBMITTED, BI500_REQUEST.ACTUAL_DATE, BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, ";

        //sql += "TO_CHAR(BI500_REQUEST.DATE_COMPLETION, 'DD/MM/YYYY') AS DATE_COMPLETION, TO_CHAR(BI500_REQUEST.DATE_SUBMITTED, 'DD/MM/YYYY') AS DATE_SUBMITTED, ";
        //sql += "TO_CHAR(BI500_REQUEST.ACTUAL_DATE, 'DD/MM/YYYY') AS ACTUAL_DATE, BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, ";

        sql += "BI500_REQUEST.STATUS, BI500_REQUEST.REQUESTNO, BI500_REQUEST.PHASE, BI500_REQUEST.QTYBENEFIT, BI500_REQUEST.AMOUNTSAVED, BI500_REQUEST.TARGETSAVINGS, BI500_REQUEST.GATE, BI500_REQUEST.REQUESTTYPE, BI500_REQUEST.RETAINED ";
        sql += "FROM BI500_IMPROVEMENT ";
        //sql += "BI500_DEPT.DEPTID, BI500_DEPT.DEPARTMENT FROM BI500_IMPROVEMENT ";

        sql += "left outer JOIN BI500_REQUEST ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";
        //sql += "INNER JOIN BI500_DEPT ON BI500_REQUEST.DEPTID = BI500_DEPT.DEPTID ";
        //sql += "INNER JOIN BI500_TEAMS ON BI500_REQUEST.TEAMID = BI500_TEAMS.TEAMID ";
        sql += "WHERE BI500_REQUEST.IDREQUEST = :lRequestId";

        return sql;
    }

    public static string getMyPendingImprovementIdeas()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) AND (BI500_REQUEST.USERID = :iUserId) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }
    public static string getMyApprovedImprovementIdeas()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS = :iStatus) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) AND (BI500_REQUEST.USERID = :iUserId)";

        return sql;
    }

    public static string getApprovedImprovementIdeas()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS = :iStatus) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType)";

        return sql;
    }

    public static string getPendingImprovementIdeas()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByTeam()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (BI500_REQUEST.TEAMID = :TeamFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByInitiator()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (REQINITIATOR.USERID = :InitiatorFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByFocalPoint()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (REQFOCALPOINT.USERID = :FocalPointFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByChampion()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (REQCHAMPION.USERID = :ChampionFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasBySponsor()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (REQSPONSOR.USERID = :SponsorFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByInitiativeLead()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (REQINITIATIVELEAD.USERID = :InitiativeLeadFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByBenefit()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (BI500_BENEFIT.IDBENEFIT = :BenefitFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByStatus()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (BI500_REQUEST.STATUS = :StatusFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    public static string getPendingImprovementIdeasByStageGate()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE (BI500_REQUEST.STATUS <> :iStatus) ";
        sql += "AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        sql += "AND (BI500_REQUEST.GATE = :StageGateFilter) ";
        sql += "ORDER BY BI500_REQUEST.IDREQUEST DESC";

        return sql;
    }

    //Loads Improvement Ideas Pending anybody's action
    public static string getImprovementIdeasPendingMyAction()
    {
        string sql = getCostReductionMaster2();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.STAND = :iStatus) AND (BI500_REQUEST_APPROVAL.USERID = :iUserId) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) ";
        

        return sql;
    }

    public static string getImprovementIdeasPendingBITeamSupport()
    {
        string sql = getCostReductionMaster2();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE ((BI500_REQUEST_APPROVAL.STAND = :iStand) AND (BI500_REQUEST.STATUS = :iStatus) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) AND (BI500_REQUEST_APPROVAL.USERID IS NULL))";

        return sql;
    }

    public static string getCostReductionMaster0()
    {
        string sql = "SELECT BI500_REQUEST.IDREQUEST, BI500_REQUEST.REQUESTNO, BI500_REQUEST.TITLE, BI500_REQUEST.BUS_CASE, BI500_TEAMS.TEAMID, BI500_TEAMS.TEAM, ";
        sql += "BI500_REQUEST.DATE_COMPLETION, BI500_REQUEST.DATE_SUBMITTED, BI500_REQUEST.ACTUAL_DATE, ";
        sql += "BI500_REQUEST.OPPORTUNITYSTMT, BI500_REQUEST.TEAM_MEMBER, ";
        sql += "BI500_REQUEST.STATUS, REQINITIATOR.USERID, REQINITIATOR.FULLNAME, REQINITIATOR.EMAIL, ";
        sql += "REQINITIATIVELEAD.USERID AS INITIATIVELEADUSERID, REQINITIATIVELEAD.FULLNAME AS INITIATIVELEADFULLNAME, REQINITIATIVELEAD.EMAIL AS INITIATIVELEADEMAIL, ";
        sql += "REQFOCALPOINT.USERID AS FOCALPOINTUSERID, REQFOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, REQFOCALPOINT.EMAIL AS FOCALPOINTEMAIL, ";
        sql += "REQCHAMPION.USERID AS CHAMPIONUSERID, REQCHAMPION.FULLNAME AS CHAMPIONFULLNAME, REQCHAMPION.EMAIL AS CHAMPIONEMAIL, ";
        sql += "REQSPONSOR.USERID AS SPONSORUSERID, REQSPONSOR.FULLNAME AS SPONSORFULLNAME, REQSPONSOR.EMAIL AS SPONSOREMAIL, ";
        sql += "BI500_BENEFIT.IDBENEFIT, BI500_BENEFIT.BENEFIT, CPDMS_FUNCTIONS.FUNCTIONID, CPDMS_FUNCTIONS.FUNCTION, BI500_REQUEST.PHASE, ";
        sql += "BI500_IMPROVEMENT.IMPROVEMENT, BI500_POTENTIAL.REP_POTENTIAL, BI500_DEPT.DEPTID, BI500_DEPT.DEPARTMENT, BI500_REQUEST.QTYBENEFIT, ";
        sql += "BI500_REQUEST.AMOUNTSAVED, BI500_REQUEST.TARGETSAVINGS, BI500_REQUEST.GATE, BI500_REQUEST.REQUESTTYPE, BI500_REQUEST.RETAINED FROM BI500_REQUEST ";
        sql += "INNER JOIN PROD_USERMGT REQINITIATOR ON BI500_REQUEST.USERID = REQINITIATOR.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQINITIATIVELEAD ON BI500_REQUEST.INITIATIVELEADUSERID = REQINITIATIVELEAD.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQFOCALPOINT ON BI500_REQUEST.FOCALPOINTUSERID = REQFOCALPOINT.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQCHAMPION ON BI500_REQUEST.CHAMPIONUSERID = REQCHAMPION.USERID ";
        sql += "left outer JOIN PROD_USERMGT REQSPONSOR ON BI500_REQUEST.SPONSORUSERID = REQSPONSOR.USERID ";
        sql += "INNER JOIN BI500_BENEFIT ON BI500_REQUEST.IDBENEFIT = BI500_BENEFIT.IDBENEFIT ";
        sql += "INNER JOIN CPDMS_FUNCTIONS ON BI500_REQUEST.FUNCTIONID = CPDMS_FUNCTIONS.FUNCTIONID ";
        sql += "INNER JOIN BI500_DEPT ON BI500_REQUEST.DEPTID = BI500_DEPT.DEPTID ";
        sql += "INNER JOIN BI500_TEAMS ON BI500_REQUEST.TEAMID = BI500_TEAMS.TEAMID ";
        sql += "INNER JOIN BI500_IMPROVEMENT ON BI500_REQUEST.IDIMPROVEMENT = BI500_IMPROVEMENT.IDIMPROVEMENT ";
        sql += "INNER JOIN BI500_POTENTIAL ON BI500_REQUEST.IDREPLICATION = BI500_POTENTIAL.IDREPLICATION ";

        return sql;
    }

    public static string getImprovementIdeasSupportedByBI()
    {
        string sql = getCostReductionMaster0();
        sql += "WHERE ((BI500_REQUEST.STATUS > :iStatus) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType))";

        return sql;
    }


    public static string getImprovementIdeasIApprovedSupportedOrRejected()
    {
        string sql = getCostReductionMaster2();
        sql += "INNER JOIN BI500_REQUEST_APPROVAL ON BI500_REQUEST.IDREQUEST = BI500_REQUEST_APPROVAL.IDREQUEST ";
        sql += "WHERE (BI500_REQUEST_APPROVAL.STAND = :iStatus) AND (BI500_REQUEST.REQUESTTYPE = :iRequestType) AND (BI500_REQUEST_APPROVAL.USERID = :iUserId)";

        return sql;
    }

    //Milestone
    public static string getMilestoneByRequestId()
    {
        string sql = "SELECT MILESTONEID, ACTIVITY_DESCRIPTION, START_DATE, FINISH_DATE, AMOUNTSAVED, IDREQUEST FROM BI500_COST_MILESTONES WHERE IDREQUEST = :lRequestId";
        return sql;
    }
    public static string getMilestoneByMilestoneId()
    {
        string sql = "SELECT MILESTONEID, ACTIVITY_DESCRIPTION, START_DATE, FINISH_DATE, AMOUNTSAVED, IDREQUEST FROM BI500_COST_MILESTONES WHERE MILESTONEID = :lMilestoneId";
        return sql;
    }

    //
    public static string InsertMilestone()
    {
        string sql = "INSERT INTO BI500_COST_MILESTONES (ACTIVITY_DESCRIPTION, START_DATE, FINISH_DATE, AMOUNTSAVED, IDREQUEST) VALUES (:sActivityDescription, :dStartDate, :dFinishDate, :dAmountSaved, :lRequestId) ";
        return sql;
    }

    public static string UpdateMilestone()
    {
        string sql = "UPDATE BI500_COST_MILESTONES SET ACTIVITY_DESCRIPTION = :sActivityDescription, START_DATE = :dStartDate, FINISH_DATE = :dFinishDate, AMOUNTSAVED = :dAmountSaved, IDREQUEST = :lRequestId WHERE MILESTONEID = :lMilestoneId";
        return sql;
    }

    public static string DeleteMilestone()
    {
        string sql = "DELETE FROM BI500_COST_MILESTONES WHERE MILESTONEID = :lMilestoneId";
        return sql;
    }


    //<---  Cadence   ---->

    public static string getCadenceByRequestId()
    {
        string sql = "SELECT CADENCEID, ACTION, ACTIONPARTY, THREAT, DUEDATE, STATUS, IDREQUEST FROM BI500_COST_CADENCE WHERE IDREQUEST = :lRequestId";
        return sql;
    }
    public static string getCadenceByCadenceId()
    {
        string sql = "SELECT CADENCEID, ACTION, ACTIONPARTY, THREAT, DUEDATE, STATUS, IDREQUEST FROM BI500_COST_CADENCE WHERE CADENCEID = :lCadenceId";
        return sql;
    }

    //
    public static string InsertCadence()
    {
        string sql = "INSERT INTO BI500_COST_CADENCE (ACTION, ACTIONPARTY, THREAT, DUEDATE, STATUS, IDREQUEST) VALUES (:sAction, :sActionParty, :sThreat, :dFinishDate, :iStatus, :lRequestId) ";
        return sql;
    }

    public static string UpdateCadence()
    {
        string sql = "UPDATE BI500_COST_CADENCE SET ACTION = :sAction, ACTIONPARTY = :sActionParty, THREAT = :sThreat, DUEDATE = :dFinishDate, STATUS = :iStatus, IDREQUEST = :lRequestId WHERE CADENCEID = :lCadenceId";
        return sql;
    }

    public static string DeleteCadence()
    {
        string sql = "DELETE FROM BI500_COST_CADENCE WHERE CADENCEID = :lCadenceId";
        return sql;
    }

    //<---  End Cadence --->


    public static string GetMailManagement()
    {
        string sql = "SELECT ID, TODAYDATE, MORNING, AFTERNOON, EVENING FROM BI500_RMDRMAILMGT";
        return sql;
    }

    public static string UpdateMailManagement()
    {
        string sql = "UPDATE BI500_RMDRMAILMGT SET TODAYDATE = :dTodayDate, MORNING = :iMorning, AFTERNOON = :iAfternoon, EVENING = :iEvening";
        return sql;
    }

    #endregion
}