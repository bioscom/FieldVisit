using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;

/// <summary>
/// Summary description for StoredProcedurePDCC
/// </summary>
public class StoredProcedurePDCC
{
    public StoredProcedurePDCC()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Calculator

    private static string CalulationMast()
    {
        string sql = "SELECT SUM(OPEX)AS OPEX, SUM(FECTO)AS FECTO, SUM(IMPROVEMENT)AS IMPROVEMENT, SUM(POTSAVINGS)AS POTSAVINGS, SUM(ACTSAVINGS)AS ACTSAVINGS FROM PDCC_OPPORTUNITYCOST ";
        return sql;
    }

    public static string getPDPerformanceByYear()
    {
        string sql = CalulationMast();
        sql += "WHERE YYEAR = :iYear";
        return sql;
    }

    public static string getAssetPerformanceByYear()
    {
        string sql = CalulationMast();
        sql += "WHERE ASSETID = :iAsset AND YYEAR = :iYear";
        return sql;
    }
    public static string getOnshoreOffshorePerformanceByYear()
    {
        string sql = CalulationMast();
        sql += "WHERE ASSERV = :iAsset AND YYEAR = :iYear";
        return sql;
    }
    public static string getOpExFectoImprovementByYearDepartmentAsset()
    {
        string sql = CalulationMast();
        sql += "WHERE ASSERV = :iAsset AND YYEAR = :iYear AND IDDEPARTMENT = :iDept";
        return sql;
    }
    public static string getOpExFectoImprovementByYearDepartment()
    {
        string sql = CalulationMast();
        sql += "WHERE YYEAR = :iYear AND IDDEPARTMENT = :iDept";
        return sql;
    }
    public static string getOpExFectoImprovementByYearOpCost()
    {
        string sql = CalulationMast();
        sql += "WHERE YYEAR = :iYear AND IDOPCOST = :lOpCost";
        return sql;
    }

    //This query collects activities that fall under a particular asset, whether the activity is classified as onshore or offshore
    public static string GetDataSummaryByAsset()
    {
        string sql = "SELECT SUM(PDCC_OPPORTUNITYCOST.OPEX)OPEX, SUM(PDCC_OPPORTUNITYCOST.FECTO)FECTO, SUM(PDCC_OPPORTUNITYCOST.IMPROVEMENT)IMPROVEMENT, ";
        sql += "SUM(PDCC_OPPORTUNITYCOST.POTSAVINGS)POTSAVINGS, SUM(PDCC_OPPORTUNITYCOST.ACTSAVINGS)ACTSAVINGS ";
        sql += "FROM PDCC_DEPT ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_DEPT.IDDEPARTMENT = PDCC_ASSET.IDDEPARTMENT ";
        sql += "INNER JOIN PDCC_OPPORTUNITYCOST ON PDCC_OPPORTUNITYCOST.ASSETID = PDCC_ASSET.ASSETID ";
        sql += "WHERE PDCC_ASSET.ASSETID = :iAssetId AND PDCC_OPPORTUNITYCOST.YYEAR = :iYear";

        return sql;
    }

    #endregion

    public static string InsertAssetToPdccUser()
    {
        string sql = "INSERT INTO PDCC_USER_DEPT (USERID, ASSETID) VALUES (:iUserId, :iAssetId)";
        return sql;
    }

    public static string getPdccDepartments()
    {
        string sql = "SELECT IDDEPARTMENT, DEPARTMENT FROM PDCC_DEPT";
        return sql;
    }
    public static string getPdccDepartmentsThatHaveData()
    {
        //string sql = "SELECT IDDEPARTMENT, DEPARTMENT FROM PDCC_DEPT";

        string sql = "SELECT DISTINCT PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT FROM PDCC_DEPT ";
        sql += " INNER JOIN PDCC_ASSET ON PDCC_ASSET.IDDEPARTMENT = PDCC_DEPT.IDDEPARTMENT ";
        sql += " INNER JOIN PDCC_OPPORTUNITYCOST ON PDCC_ASSET.ASSETID = PDCC_OPPORTUNITYCOST.ASSETID ORDER BY DEPARTMENT DESC";
        return sql;
    }

    public static string GetUserPdccAssets(int iRoleId)
    {
        string sql = "";
        if (iRoleId == (int)AppUsersPdccRoles.UserRole.ActionParty)
        {
            sql = "SELECT DISTINCT PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_ASSET.IDDEPARTMENT, PDCC_ASSET.IDSERVICE, PDCC_ASSET.IDOU, PDCC_OPPORTUNITYCOST.ACTIONPARTY FROM PDCC_OPPORTUNITYCOST ";
            sql += "INNER JOIN PDCC_ASSET ON PDCC_OPPORTUNITYCOST.ASSETID = PDCC_ASSET.ASSETID WHERE PDCC_OPPORTUNITYCOST.ACTIONPARTY = :iUserId";
        }
        else if (iRoleId == (int)AppUsersPdccRoles.UserRole.Sponsor)
        {
            sql = "SELECT DISTINCT PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_ASSET.IDDEPARTMENT, PDCC_ASSET.IDSERVICE, PDCC_ASSET.IDOU, PDCC_OPPORTUNITYCOST.SPONSOR FROM PDCC_OPPORTUNITYCOST ";
            sql += "INNER JOIN PDCC_ASSET ON PDCC_OPPORTUNITYCOST.ASSETID = PDCC_ASSET.ASSETID WHERE PDCC_OPPORTUNITYCOST.SPONSOR = :iUserId";
        }
        else if (iRoleId == (int)AppUsersPdccRoles.UserRole.User)
        {
            sql = "SELECT DISTINCT PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_ASSET.IDDEPARTMENT, PDCC_ASSET.IDSERVICE, PDCC_ASSET.IDOU, PDCC_ASSET.IDSERVICE, PDCC_ASSET.IDOU FROM PDCC_OPPORTUNITYCOST ";
            sql += "INNER JOIN PDCC_ASSET ON PDCC_OPPORTUNITYCOST.ASSETID = PDCC_ASSET.ASSETID ";
            sql += "INNER JOIN PDCC_USER_DEPT ON PDCC_USER_DEPT.ASSETID = PDCC_ASSET.ASSETID WHERE PDCC_USER_DEPT.USERID = :iUserId";
        }

        return sql;
    }

    public static string GetUserAssets()
    {
        string sql = "SELECT PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_ASSET.IDDEPARTMENT, PDCC_ASSET.IDSERVICE, PDCC_ASSET.IDOU, PDCC_USER_DEPT.USERID FROM PDCC_USER_DEPT ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_ASSET.ASSETID = PDCC_USER_DEPT.ASSETID WHERE PDCC_USER_DEPT.USERID = :iUserId";

        return sql;
    }

    public static string GetUserDepartments2()
    {
        string sql = "SELECT ASSETID, USERID FROM PDCC_USER_DEPT WHERE USERID = :iUserId AND ASSETID = :iAssetId";

        return sql;
    }

    public static string getPdccDepartmentById()
    {
        string sql = "SELECT IDDEPARTMENT, DEPARTMENT FROM PDCC_DEPT WHERE IDDEPARTMENT = :iDeptId";
        return sql;
    }

    public static string getYears()
    {
        string sql = "SELECT DISTINCT YYEAR FROM PDCC_OPPORTUNITYCOST ORDER BY YYEAR";
        return sql;
    }

    public static string getYears2()
    {
        string sql = "SELECT DISTINCT YYEAR FROM PDCC_SUMMARY_COST ORDER BY YYEAR";
        return sql;
    }

    public static string getTransactionYear()
    {
        string sql = "SELECT IYEAR FROM PDCC_TRANS_YEAR";
        return sql;
    }

    public static string UpdateTransactionYear()
    {
        string sql = "UPDATE PDCC_TRANS_YEAR SET IYEAR = :iYear";
        return sql;
    }


    #region Create, Update and Delete from Opportunity Cost table

    public static string CreatePdcc()
    {
        string sql = "INSERT INTO PDCC_OPPORTUNITYCOST (IDOPCOST, ASSETID, STARTEDBY, COMPLETEDBY, SPONSOR, ACTIONPARTY, ACCEPTPARK, PRIORITY, OPEX, FECTO, IMPROVEMENT, ASSERV, ";
        sql += "COSTCENTRE, OPPORTUNITY, DATEUPDATED, YYEAR, WORKSCOPE, USERID, POTSAVINGS, ACTSAVINGS, COMMENTS) VALUES (:lOpCost, :iAssetId, :iStartedBy, :iCompletedBy, :iSponsor, :iActionParty, :iAcceptPark, :iPriority,  ";
        sql += ":dOpexYear, :dFecto, :dImprovement, :iAsService, :sCostCentre, :sOpportunity, :DtDateUpdated, :iYear, :sWorkScope, :iUserId, :dPotSavings, :dActSavings, :sComments)";

        return sql;
    }
    public static string UpdatePdcc()
    {
        string sql = "UPDATE PDCC_OPPORTUNITYCOST SET ASSETID = :iAssetId, STARTEDBY = :iStartedBy, COMPLETEDBY = :iCompletedBy, SPONSOR = :iSponsor, ";
        sql += "ACTIONPARTY = :iActionParty, ACCEPTPARK = :iAcceptPark, PRIORITY = :iPriority, OPEX = :dOpexYear, FECTO = :dFecto, IMPROVEMENT = :dImprovement, ";
        sql += "ASSERV = :iAsService, COSTCENTRE = :sCostCentre, OPPORTUNITY = :sOpportunity, DATEUPDATED = :DtDateUpdated, WORKSCOPE = :sWorkScope, USERID = :iUserId, ";
        sql += "POTSAVINGS = :dPotSavings, ACTSAVINGS = :dActSavings, COMMENTS = :sComments WHERE IDOPCOST = :lOpCost";

        return sql;
    }
    public static string UpdatePdcc2()
    {
        string sql = "UPDATE PDCC_OPPORTUNITYCOST SET POTSAVINGS = :dPotSavings, ACTSAVINGS = :dActSavings, COMMENTS = :sComments, ";
        sql += "DATEUPDATED = :DtDateUpdated, USERID = :iUserId WHERE IDOPCOST = :lOpCost";

        return sql;
    }

    public static string CreatePdccLog()
    {
        string sql = "INSERT INTO PDCC_OPPORTUNITYCOST_LOG (IDOPCOST, FECTO, IMPROVEMENT, POTSAVINGS, ACTSAVINGS, COMMENTS, DATEUPDATED, WORKSCOPE, USERID) ";
        sql += "VALUES (:lOpCost, :dFecto, :dImprovement, :dPotSavings, :dActSavings, :sComments, :DtDateUpdated, :sWorkScope, :iUserId)";
        return sql;
    }

    public static string UpdatePdccLog()
    {
        string sql = "UPDATE PDCC_OPPORTUNITYCOST_LOG SET FECTO = :dFecto, IMPROVEMENT = :dImprovement, POTSAVINGS = :dPotSavings, ACTSAVINGS = :dActSavings, ";
        sql += "COMMENTS = :sComments, DATEUPDATED = :DtDateUpdated, WORKSCOPE = :sWorkScope WHERE IDOPCOST = :lOpCost";
        return sql;
    }

    public static string getPdccLog()
    {
        string sql = "SELECT PDCC_OPPORTUNITYCOST_LOG.IDOPCOST, PDCC_OPPORTUNITYCOST_LOG.FECTO, PDCC_OPPORTUNITYCOST_LOG.IMPROVEMENT, ";
        sql += "PDCC_OPPORTUNITYCOST_LOG.POTSAVINGS, PDCC_OPPORTUNITYCOST_LOG.ACTSAVINGS, PDCC_OPPORTUNITYCOST_LOG.COMMENTS, ";
        sql += "PDCC_OPPORTUNITYCOST_LOG.DATEUPDATED, PDCC_OPPORTUNITYCOST_LOG.WORKSCOPE, PROD_USERMGT.FULLNAME ";
        sql += "FROM PDCC_OPPORTUNITYCOST_LOG INNER JOIN PROD_USERMGT ON PDCC_OPPORTUNITYCOST_LOG.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE TO_CHAR(TO_DATE(PDCC_OPPORTUNITYCOST_LOG.DATEUPDATED, 'DD-MON-YY') ,'YYYY') = :iYear ";
        
        //AND TO_CHAR(TO_DATE(DATEUPDATED, 'DD-MON-YY') ,'YYYY') = :iYYear
        return sql;
    }

    public static string getPdccLogByAsset()
    {
        string sql = "SELECT PDCC_OPPORTUNITYCOST_LOG.IDOPCOST, PDCC_OPPORTUNITYCOST_LOG.FECTO, PDCC_OPPORTUNITYCOST_LOG.IMPROVEMENT, ";
        sql += "PDCC_OPPORTUNITYCOST_LOG.POTSAVINGS, PDCC_OPPORTUNITYCOST_LOG.ACTSAVINGS, PDCC_OPPORTUNITYCOST_LOG.COMMENTS, PDCC_OPPORTUNITYCOST.OPPORTUNITY, ";
        sql += "PDCC_OPPORTUNITYCOST_LOG.DATEUPDATED, PDCC_OPPORTUNITYCOST_LOG.WORKSCOPE, PDCC_OPPORTUNITYCOST.STARTEDBY, "; //PROD_USERMGT.FULLNAME, 
        sql += "PDCC_OPPORTUNITYCOST.COMPLETEDBY, PDCC_OPPORTUNITYCOST.SPONSOR, PDCC_OPPORTUNITYCOST.ACTIONPARTY, PDCC_OPPORTUNITYCOST.ACCEPTPARK, ";
        sql += "PDCC_OPPORTUNITYCOST.PRIORITY, PDCC_OPPORTUNITYCOST.ASSERV, PDCC_OPPORTUNITYCOST.COSTCENTRE, PDCC_OPPORTUNITYCOST.OPEX, ";
        sql += "SPONSOR.FULLNAME AS SPONSORNAME, ACTIONPARTY.FULLNAME AS ACTIONPARTYNAME, FOCALPOINT.FULLNAME AS FOCALPOINTNAME, ";
        sql += "PDCC_OPPORTUNITYCOST.COSTBUCKET, PDCC_OPPORTUNITYCOST.SERIALNUM, PDCC_OPPORTUNITYCOST.SERIALNO FROM PDCC_OPPORTUNITYCOST_LOG ";
        //sql += "INNER JOIN PROD_USERMGT ON PDCC_OPPORTUNITYCOST_LOG.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN PDCC_OPPORTUNITYCOST ON PDCC_OPPORTUNITYCOST_LOG.IDOPCOST = PDCC_OPPORTUNITYCOST.IDOPCOST ";
        sql += "LEFT OUTER JOIN PROD_USERMGT SPONSOR ON SPONSOR.USERID = PDCC_OPPORTUNITYCOST.SPONSOR ";
        sql += "LEFT OUTER JOIN PROD_USERMGT ACTIONPARTY ON ACTIONPARTY.USERID = PDCC_OPPORTUNITYCOST.ACTIONPARTY ";
        sql += "INNER JOIN PROD_USERMGT FOCALPOINT ON FOCALPOINT.USERID = PDCC_OPPORTUNITYCOST_LOG.USERID ";
        sql += "WHERE TO_CHAR(TO_DATE(PDCC_OPPORTUNITYCOST_LOG.DATEUPDATED, 'DD-MON-YY') ,'YYYY') = :iYear AND PDCC_OPPORTUNITYCOST.ASSETID = :iAssetId ";
        sql += "ORDER BY PDCC_OPPORTUNITYCOST_LOG.IDOPCOST";

        //AND TO_CHAR(TO_DATE(DATEUPDATED, 'DD-MON-YY') ,'YYYY') = :iYYear
        return sql;
    }

    //

    public static string getPdccLogByOpportunity()
    {
        string sql = "SELECT PDCC_OPPORTUNITYCOST_LOG.IDOPCOST, PDCC_OPPORTUNITYCOST_LOG.FECTO, PDCC_OPPORTUNITYCOST_LOG.IMPROVEMENT, ";
        sql += "PDCC_OPPORTUNITYCOST_LOG.POTSAVINGS, PDCC_OPPORTUNITYCOST_LOG.ACTSAVINGS, PDCC_OPPORTUNITYCOST_LOG.COMMENTS, ";
        sql += "PDCC_OPPORTUNITYCOST_LOG.DATEUPDATED, PDCC_OPPORTUNITYCOST_LOG.WORKSCOPE, PROD_USERMGT.FULLNAME ";
        sql += "FROM PDCC_OPPORTUNITYCOST_LOG INNER JOIN PROD_USERMGT ON PDCC_OPPORTUNITYCOST_LOG.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE TO_CHAR(TO_DATE(PDCC_OPPORTUNITYCOST_LOG.DATEUPDATED, 'DD-MON-YY') ,'YYYY') = :iYear AND (IDOPCOST = :lOpCost) ";
        //AND TO_CHAR(TO_DATE(DATEUPDATED, 'DD-MON-YY') ,'YYYY') = :iYYear
        return sql;
    }

    //public static string CreatePdccLog()
    //{
    //    string sql = "INSERT INTO PDCC_OPPORTUNITYCOST_LOG (IDOPCOST, FECTO, IMPROVEMENT, POTSAVINGS, ACTSAVINGS, COMMENTS, DATEUPDATED, WORKSCOPE) ";
    //    sql += "VALUES (:lOpCost, :dFecto, :dImprovement, :dPotSavings, :dActSavings, :sComments, :DtDateUpdated, :sWorkScope)";
    //    return sql;
    //}

    #endregion

    #region Loading Data from Opportunity Cost table by parameters
    public static string GetOpportunitiesMaster()
    {
        string sql = "SELECT PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT, PDCC_OPPORTUNITYCOST.IDOPCOST, PDCC_OPPORTUNITYCOST.STARTEDBY, PDCC_OPPORTUNITYCOST.COMPLETEDBY, PDCC_OPPORTUNITYCOST.USERID, ";
        sql += "PDCC_OPPORTUNITYCOST.SPONSOR, PDCC_OPPORTUNITYCOST.ACTIONPARTY, PDCC_OPPORTUNITYCOST.OPEX, PDCC_OPPORTUNITYCOST.ACCEPTPARK, PDCC_OPPORTUNITYCOST.PRIORITY, PDCC_OPPORTUNITYCOST.FECTO, ";
        sql += "PDCC_OPPORTUNITYCOST.IMPROVEMENT, PDCC_OPPORTUNITYCOST.ASSERV, PDCC_OPPORTUNITYCOST.POTSAVINGS, PDCC_OPPORTUNITYCOST.ACTSAVINGS, PDCC_OPPORTUNITYCOST.COSTCENTRE, ";
        sql += "PDCC_OPPORTUNITYCOST.COMMENTS, PDCC_OPPORTUNITYCOST.OPPORTUNITY, PDCC_OPPORTUNITYCOST.DATEUPDATED, PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_OPPORTUNITYCOST.YYEAR, ";
        sql += "PDCC_OPPORTUNITYCOST.SERIALNO, PDCC_OPPORTUNITYCOST.WORKSCOPE, SPONSOR.FULLNAME AS SPONSORNAME, ACTIONPARTY.FULLNAME AS ACTIONPARTYNAME, FOCALPOINT.FULLNAME AS FOCALPOINTNAME ";
        sql += "FROM PDCC_OPPORTUNITYCOST ";
        sql += "LEFT OUTER JOIN PROD_USERMGT SPONSOR ON SPONSOR.USERID = PDCC_OPPORTUNITYCOST.SPONSOR ";
        sql += "LEFT OUTER JOIN PROD_USERMGT ACTIONPARTY ON ACTIONPARTY.USERID = PDCC_OPPORTUNITYCOST.ACTIONPARTY ";
        sql += "LEFT OUTER JOIN PROD_USERMGT FOCALPOINT ON FOCALPOINT.USERID = PDCC_OPPORTUNITYCOST.USERID ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_ASSET.ASSETID = PDCC_OPPORTUNITYCOST.ASSETID ";
        sql += "INNER JOIN PDCC_DEPT ON PDCC_ASSET.IDDEPARTMENT = PDCC_DEPT.IDDEPARTMENT ";

        return sql;
    }
    public static string GetOpportunities()
    {
        string sql = GetOpportunitiesMaster();
        sql += "ORDER BY PDCC_OPPORTUNITYCOST.SERIALNO  ";

        return sql;
    }

    public static string GetProjects()
    {
        //projects are opportunities that has no Serial Number.
        string sql = GetOpportunitiesMaster();
        sql += " WHERE PDCC_OPPORTUNITYCOST.YYEAR = :iYear AND PDCC_OPPORTUNITYCOST.SERIALNO IS NULL";

        return sql;
    }
    public static string GetOpportunityBySponsor()
    {
        string sql = GetOpportunitiesMaster();
        sql += "WHERE PDCC_OPPORTUNITYCOST.SPONSOR = :iUserId ORDER BY PDCC_OPPORTUNITYCOST.SERIALNO";

        return sql;
    }
    public static string GetOpportunityByActionParty()
    {
        string sql = GetOpportunitiesMaster();
        sql += "WHERE PDCC_OPPORTUNITYCOST.ACTIONPARTY = :iUserId AND PDCC_OPPORTUNITYCOST.YYEAR = :iYear ORDER BY PDCC_OPPORTUNITYCOST.SERIALNO";

        return sql;
    }
    public static string GetOpportunityBySerialNo()
    {
        string sql = GetOpportunitiesMaster();
        sql += "WHERE PDCC_OPPORTUNITYCOST.SERIALNO = :sSerialNo ";

        return sql;
    }
    //public static string GetOpportunitiesByAsset()
    //{
    //    string sql = GetOpportunitiesMaster();
    //    sql += "WHERE PDCC_OPPORTUNITYCOST.ASSETID = :iAssetId ";

    //    return sql;
    //}

    public static string GetOpportunitiesByAsset()
    {
        string sql = GetOpportunitiesMaster();
        sql += "WHERE PDCC_OPPORTUNITYCOST.ASSETID = :iAssetId AND PDCC_OPPORTUNITYCOST.YYEAR = :iYear ORDER BY PDCC_OPPORTUNITYCOST.SERIALNO";

        return sql;
    }
    public static string GetOpportunitiesByAssetOwner()
    {
        string sql = GetOpportunitiesMaster();
        sql += "WHERE PDCC_OPPORTUNITYCOST.ASSETID = :iAssetId AND PDCC_OPPORTUNITYCOST.YYEAR = :iYear AND PDCC_OPPORTUNITYCOST.ACTIONPARTY = :iUserId ORDER BY PDCC_OPPORTUNITYCOST.SERIALNO";

        return sql;
    }    
    public static string GetOpportunitiesById()
    {
        string sql = GetOpportunitiesMaster();
        sql += "WHERE PDCC_OPPORTUNITYCOST.IDOPCOST = :lOpCost ";

        return sql;
    }
    public static string GetOpportunityByOpportunity()
    {
        string sql = GetOpportunitiesMaster();
        sql += "WHERE UPPER(PDCC_OPPORTUNITYCOST.OPPORTUNITY) LIKE UPPER(:Opportunity) ";

        return sql;
    }
    public static string GetOpportunitiesByAssetRpt()
    {
        //PDCC_OPPORTUNITYCOST.ASSETID
        string sql = GetOpportunitiesRpt();
        sql += "WHERE PDCC_OPPORTUNITYCOST.ASSETID = :iAsset ORDER BY PDCC_OPPORTUNITYCOST.SERIALNO";

        return sql;
    }
    #endregion

    public static string GetFunctionsOrDepartments()
    {
        string sql = "SELECT PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT, PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_ASSET.IDOU, PDCC_ASSET.IDSERVICE FROM PDCC_DEPT ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_DEPT.IDDEPARTMENT = PDCC_ASSET.IDDEPARTMENT ORDER BY PDCC_DEPT.DEPARTMENT DESC";
        return sql;
    }

    public static string GetAssetByOnshoreOffshore()
    {
        string sql = "SELECT DISTINCT PDCC_ASSET.ASSETID, PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT, PDCC_ASSET.ASSET, PDCC_ASSET.IDOU, PDCC_ASSET.IDSERVICE FROM PDCC_DEPT ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_DEPT.IDDEPARTMENT = PDCC_ASSET.IDDEPARTMENT ";
        sql += "INNER JOIN PDCC_OPPORTUNITYCOST ON PDCC_ASSET.ASSETID = PDCC_OPPORTUNITYCOST.ASSETID ";
        sql += "WHERE PDCC_OPPORTUNITYCOST.ASSERV = :iAssetId AND PDCC_OPPORTUNITYCOST.YYEAR = :iYear ORDER BY PDCC_ASSET.ASSET";

        //string sql = "SELECT PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT, PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET FROM PDCC_DEPT ";
        //sql += "INNER JOIN PDCC_ASSET ON PDCC_DEPT.IDDEPARTMENT = PDCC_ASSET.IDDEPARTMENT ";
        //sql += "WHERE PDCC_DEPT.IDDEPARTMENT = :iDeptId";
        return sql;
    }

    public static string GetAssetsByYear()
    {
        string sql = "SELECT DISTINCT PDCC_ASSET.ASSETID, PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT, PDCC_ASSET.ASSET, PDCC_ASSET.IDOU, PDCC_ASSET.IDSERVICE FROM PDCC_DEPT ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_DEPT.IDDEPARTMENT = PDCC_ASSET.IDDEPARTMENT ";
        sql += "INNER JOIN PDCC_OPPORTUNITYCOST ON PDCC_ASSET.ASSETID = PDCC_OPPORTUNITYCOST.ASSETID ";
        sql += "WHERE PDCC_OPPORTUNITYCOST.YYEAR = :iYear ORDER BY PDCC_ASSET.ASSET";

        //string sql = "SELECT PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT, PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET FROM PDCC_DEPT ";
        //sql += "INNER JOIN PDCC_ASSET ON PDCC_DEPT.IDDEPARTMENT = PDCC_ASSET.IDDEPARTMENT ";
        //sql += "WHERE PDCC_DEPT.IDDEPARTMENT = :iDeptId";
        return sql;
    }

    public static string GetFunctionsByDepartments()
    {
        string sql = "SELECT PDCC_DEPT.IDDEPARTMENT, PDCC_DEPT.DEPARTMENT, PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_ASSET.IDOU, PDCC_ASSET.IDSERVICE FROM PDCC_DEPT ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_DEPT.IDDEPARTMENT = PDCC_ASSET.IDDEPARTMENT ";
        sql += "WHERE PDCC_DEPT.IDDEPARTMENT = :iDeptId";
        return sql;
    }
    public static string GetOpportunitiesRpt()
    {
        string sql = "SELECT PDCC_OPPORTUNITYCOST.SERIALNO, PDCC_DEPT.DEPARTMENT, PDCC_ASSET.ASSET, PDCC_OPPORTUNITYCOST.OPPORTUNITY, SPONSOR.FULLNAME AS SPONSORNAME, ";
        sql += "ACTIONPARTY.FULLNAME AS ACTIONPARTYNAME, PDCC_OPPORTUNITYCOST.ACCEPTPARK, PDCC_OPPORTUNITYCOST.PRIORITY, PDCC_OPPORTUNITYCOST.OPEX, PDCC_OPPORTUNITYCOST.FECTO, ";
        sql += "PDCC_OPPORTUNITYCOST.IMPROVEMENT, PDCC_OPPORTUNITYCOST.ASSERV, TO_CHAR(PDCC_OPPORTUNITYCOST.STARTEDBY, 'dd-MON-yyyy') STARTEDBY, ";
        sql += "TO_CHAR(PDCC_OPPORTUNITYCOST.COMPLETEDBY, 'dd-MON-yyyy') COMPLETEDBY, PDCC_OPPORTUNITYCOST.POTSAVINGS, PDCC_OPPORTUNITYCOST.ACTSAVINGS, PDCC_OPPORTUNITYCOST.COSTCENTRE, ";
        sql += "PDCC_OPPORTUNITYCOST.COMMENTS, PDCC_OPPORTUNITYCOST.WORKSCOPE FROM PDCC_OPPORTUNITYCOST ";
        sql += "LEFT OUTER JOIN PROD_USERMGT SPONSOR ON SPONSOR.USERID = PDCC_OPPORTUNITYCOST.SPONSOR ";
        sql += "LEFT OUTER JOIN PROD_USERMGT ACTIONPARTY ON ACTIONPARTY.USERID = PDCC_OPPORTUNITYCOST.ACTIONPARTY ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_ASSET.ASSETID = PDCC_OPPORTUNITYCOST.ASSETID ";
        sql += "INNER JOIN PDCC_DEPT ON PDCC_ASSET.IDDEPARTMENT = PDCC_DEPT.IDDEPARTMENT ";

        return sql;




        //string sql = "SELECT PDCC_DEPT.DEPARTMENT, PDCC_OPPORTUNITYCOST.OPPORTUNITY, SPONSOR.FULLNAME AS SPONSORNAME, ACTIONPARTY.FULLNAME AS ACTIONPARTYNAME, ";
        //sql += "PDCC_OPPORTUNITYCOST.ACCEPTPARK, PDCC_OPPORTUNITYCOST.PRIORITY, PDCC_OPPORTUNITYCOST.OPEX, PDCC_OPPORTUNITYCOST.FECTO, PDCC_OPPORTUNITYCOST.IMPROVEMENT, ";
        //sql += "PDCC_OPPORTUNITYCOST.ASSERV, TO_CHAR(PDCC_OPPORTUNITYCOST.STARTEDBY, 'dd-MON-yyyy')STARTEDBY, TO_CHAR(PDCC_OPPORTUNITYCOST.COMPLETEDBY, 'dd-MON-yyyy')COMPLETEDBY, ";
        //sql += "PDCC_OPPORTUNITYCOST.POTSAVINGS, PDCC_OPPORTUNITYCOST.ACTSAVINGS, PDCC_OPPORTUNITYCOST.COSTCENTRE, PDCC_OPPORTUNITYCOST.COMMENTS, PDCC_ASSET.ASSET, ";
        //sql += "PDCC_OPPORTUNITYCOST.SERIALNO, PDCC_OPPORTUNITYCOST.WORKSCOPE FROM PDCC_OPPORTUNITYCOST ";
        //sql += "LEFT OUTER JOIN PROD_USERMGT SPONSOR ON SPONSOR.USERID = PDCC_OPPORTUNITYCOST.SPONSOR ";
        //sql += "LEFT OUTER JOIN PROD_USERMGT ACTIONPARTY ON ACTIONPARTY.USERID = PDCC_OPPORTUNITYCOST.ACTIONPARTY ";
        ////sql += "LEFT OUTER JOIN PROD_USERMGT UPDATEDBY ON UPDATEDBY.USERID = PDCC_OPPORTUNITYCOST.USERID ";
        ////sql += "INNER JOIN PDCC_DEPT ON PDCC_DEPT.IDDEPARTMENT = PDCC_OPPORTUNITYCOST.IDDEPARTMENT ";
        //sql += "INNER JOIN PDCC_ASSET ON PDCC_ASSET.ASSETID = PDCC_OPPORTUNITYCOST.ASSETID ";

        //return sql;
    }
    public static string getChartMenu()
    {
        string sql = "SELECT PDCC_DEPT.IDDEPARTMENT AS MENUID, PDCC_DEPT.DEPARTMENT AS ASSETS, ";
        sql += "PDCC_OPPORTUNITYCOST.OPPORTUNITY AS TITLE, PDCC_DEPT.IDDEPARTMENT AS PARENTID ";
        sql += "FROM PDCC_OPPORTUNITYCOST, PDCC_DEPT WHERE PDCC_OPPORTUNITYCOST.IDDEPARTMENT = PDCC_DEPT.IDDEPARTMENT ";
        sql += "ORDER BY PDCC_DEPT.IDDEPARTMENT";

        return sql;
    }

    public static string getAssets()
    {
        string sql = "SELECT ASSETID, ASSET, IDDEPARTMENT, IDOU, IDSERVICE FROM PDCC_ASSET ORDER BY ASSET";
        return sql;
    }

    public static string getAssetById()
    {
        string sql = "SELECT ASSETID, ASSET, IDDEPARTMENT, IDOU, IDSERVICE FROM PDCC_ASSET WHERE ASSETID = :iAssetId";
        return sql;
    }

    #region Tell Your Stories

    public static string InsertStory()
    {
        string sql = "INSERT INTO PDCC_STORY (STORY, USERNAME, DATETOLD, TITLE, STIME, AMTSAVED, FILE1, FILE2, FILE3, FILE4) VALUES (:sStory, :sUserName, :dtDateTold, :sTitle, :sTime, :dAmtSaved, :sFile1, :sFile2, :sFile3, :sFile4)";
        return sql;
    }

    public static string UpdateStory()
    {
        string sql = "UPDATE PDCC_STORY SET STORY = :sStory, TITLE = :sTitle, AMTSAVED = :dAmtSaved, FILE1 = :sFile1, FILE2 = :sFile2, FILE3 = :sFile3, FILE4 = :sFile4 WHERE IDSTORY = :lStoryId";
        return sql;
    }

    public static string UpdateStoryWtFileUpload()
    {
        string sql = "UPDATE PDCC_STORY SET STORY = :sStory, TITLE = :sTitle, AMTSAVED = :dAmtSaved WHERE IDSTORY = :lStoryId";
        return sql;
    }
    public static string getStories()
    {
        string sql = "SELECT IDSTORY, STORY, USERNAME, TO_CHAR(DATETOLD, 'DD-MON-YY')DATETOLD, TITLE, STIME, AMTSAVED, FILE1, FILE2, FILE3, FILE4, TO_NUMBER(trunc(sysdate) - to_date(to_char(DATETOLD, 'yyyy-mm-dd'),'yyyy-mm-dd')) NOOFDAYS  FROM PDCC_STORY ";
        //DEV_TDAT_PERF_SUMM.PERF_DATE_ADD
        return sql;
    }

    public static string getStoryById()
    {
        string sql = getStories(); //"SELECT IDSTORY, STORY, USERNAME, DATETOLD, TITLE, STIME FROM PDCC_STORY ";
        sql += "WHERE IDSTORY = :lStoryId";
        return sql;
    }

    public static string getStoryByUserName()
    {
        string sql = getStories(); //"SELECT IDSTORY, STORY, USERNAME, DATETOLD, TITLE, STIME FROM PDCC_STORY ";
        sql += "WHERE USERNAME = :sUserName";
        return sql;
    }

    public static string getStoryBySearch()
    {
        string sql = getStories();
        sql += "WHERE UPPER(TITLE) LIKE UPPER(:sSearch)";
        return sql;
    }

    public static string getNoOfMembers()
    {
        string sql = "select distinct username from PDCC_STORY ";
        return sql;
    }
    public static string getNoOfTopics()
    {
        string sql = "select STORY from PDCC_STORY ";
        return sql;
    }

    public static string getNoOfMyTopics()
    {
        //string sql = "select count(distinct STORY) STORY from PDCC_STORY WHERE USERNAME = :sUserName ";
        string sql = "select STORY from PDCC_STORY WHERE upper(USERNAME) = upper(:sUserName)";
        return sql;
    }

    #endregion


    #region Managing Loggedon users

    public static string insertLogonUser()
    {
        string sql = "INSERT INTO PROD_LOGONMGT (DATELOGON, TIMELOGON, USERSNAMES) VALUES (:sDateLogon, :sTimeLogon, :sUsersNames)";
        return sql;
    }

    public static string UpdateLogonUser()
    {
        string sql = "UPDATE PROD_LOGONMGT SET USERSNAMES = :sUsersNames WHERE IDLOGON = :lIdLogon";
        return sql;
    }

    public static string GetTodayLogonUsers()
    {
        string sql = "SELECT IDLOGON, DATELOGON, TIMELOGON, USERSNAMES FROM PROD_LOGONMGT WHERE DATELOGON = :iDateLogon";
        return sql;
    }


    #endregion

    #region =============================================   PD Cost Reduction Summary =================================================

    public static string getCostReductionMaster()
    {
        string sql = "SELECT PDCC_SUMMARY_COST.IDCOST, PDCC_ASSET.ASSETID, PDCC_ASSET.ASSET, PDCC_ASSET_SERVICE.IDSERVICE, PDCC_ASSET_SERVICE.SERVICE, ";
        sql += "PDCC_SUMMARY_COST.OPEX, PDCC_SUMMARY_COST.DDBANKED, PDCC_SUMMARY_COST.DDOPPOR, PDCC_SUMMARY_COST.DDOPPORBANKED, PDCC_SUMMARY_COST.EIO, ";
        sql += "PDCC_SUMMARY_COST.EIOBANKED, PDCC_SUMMARY_COST.YYEAR, PDCC_SUMMARY_COST.DATEUPDATED, PDCC_SUMMARY_COST.PERFDESCRIPTION, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, ";
        sql += "PDCC_SUMMARY_COST.DDBANKABLE, PDCC_SUMMARY_COST.DDEXPECTED, PDCC_SUMMARY_COST.DDOPPOREXPECTED, PDCC_SUMMARY_COST.EIOACTUAL, PDCC_SUMMARY_COST.EIOCOSTAVOID ";
        sql += "FROM PDCC_ASSET ";
        sql += "INNER JOIN PDCC_ASSET_SERVICE ON PDCC_ASSET_SERVICE.IDSERVICE = PDCC_ASSET.IDSERVICE ";
        sql += "INNER JOIN PDCC_SUMMARY_COST ON PDCC_ASSET.ASSETID = PDCC_SUMMARY_COST.ASSETID ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = PDCC_SUMMARY_COST.USERID  ";

        return sql;
    }

    public static string getCostReductionMaster2()
    {
        string sql = "SELECT PDCC_ASSET.ASSET, PDCC_SUMMARY_COST.OPEX, PDCC_SUMMARY_COST.DDBANKED, PDCC_SUMMARY_COST.DDOPPOR, ";
        sql += "PDCC_SUMMARY_COST.DDOPPORBANKED, PDCC_SUMMARY_COST.EIO, PDCC_SUMMARY_COST.EIOBANKED FROM PDCC_ASSET ";
        sql += "INNER JOIN PDCC_ASSET_SERVICE ON PDCC_ASSET_SERVICE.IDSERVICE = PDCC_ASSET.IDSERVICE ";
        sql += "INNER JOIN PDCC_SUMMARY_COST ON PDCC_ASSET.ASSETID = PDCC_SUMMARY_COST.ASSETID ";

        return sql;

    }

    public static string GetCostReductionByAssetService()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE PDCC_ASSET_SERVICE.IDSERVICE = :iServiceId AND PDCC_SUMMARY_COST.YYEAR = :iYear ORDER BY PDCC_ASSET.ASSET";

        return sql;
    }

    public static string GetCostReductionByYear()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE PDCC_SUMMARY_COST.YYEAR = :iYear ORDER BY PDCC_ASSET.ASSET";

        return sql;
    }

    public static string GetPDCostReductionPerformance()
    {
        string sql = getCostReductionMaster2();
        sql += "WHERE PDCC_SUMMARY_COST.YYEAR = :iYear ORDER BY PDCC_ASSET.ASSET";

        return sql;
    }

    public static string GetCostReductionSummaryByAsset()
    {
        string sql = getCostReductionMaster();
        sql += "WHERE PDCC_ASSET.ASSETID = :iAssetId AND PDCC_SUMMARY_COST.YYEAR = :iYear ORDER BY PDCC_ASSET.ASSET";

        return sql;
    }

    public static string CreatePDCostReduction()
    {
        string sql = "INSERT INTO PDCC_SUMMARY_COST (ASSETID, OPEX, DDBANKED, DDOPPOR, DDOPPORBANKED, EIO, EIOBANKED, YYEAR, DATEUPDATED, USERID, PERFDESCRIPTION, DDBANKABLE, DDEXPECTED, DDOPPOREXPECTED, EIOACTUAL, EIOCOSTAVOID) ";
        sql += "VALUES (:iAssetId, :dOpex, :dDeepDiveBanked, :dDeepDiveOppor, :dDeepDiveOpporBanked, :dEIO, :dEIOBanked, :iYear, :DtDateUpdated, :iUserId, :sPerDescription, :dDeepDiveBankable, :dDeepDiveExpected, :dDeepDiveOpporExpected, :dEIOActual, :dEIOCostAvoidance)";

        return sql;
    }
    public static string UpdatePDCostReduction()
    {
        string sql = "UPDATE PDCC_SUMMARY_COST SET ASSETID = :iAssetId, OPEX = :dOpex, DDBANKED = :dDeepDiveBanked, DDOPPOR = :dDeepDiveOppor, ";
        sql += "DDOPPORBANKED = :dDeepDiveOpporBanked, EIO = :dEIO, EIOBANKED = :dEIOBanked, YYEAR = :iYear, DATEUPDATED = :DtDateUpdated, ";
        sql += "USERID = :iUserId, PERFDESCRIPTION = :sPerDescription, ";
        sql += "DDBANKABLE = :dDeepDiveBankable, DDEXPECTED = :dDeepDiveExpected, DDOPPOREXPECTED = :dDeepDiveOpporExpected, EIOACTUAL = :dEIOActual, ";
        sql += "EIOCOSTAVOID = :dEIOCostAvoidance WHERE IDCOST = :lCost";

        return sql;
    }

    public static string getAssetServices()
    {
        string sql = "SELECT PDCC_ASSET_SERVICE.IDSERVICE, PDCC_ASSET_SERVICE.SERVICE FROM PDCC_ASSET_SERVICE";
        return sql;
    }

    private static string PDCostReductionCalulationMast()
    {
        string sql = "SELECT SUM(OPEX)AS OPEX, SUM(DDBANKED)AS DDBANKED, SUM(DDOPPOR)AS DDOPPOR, SUM(DDOPPORBANKED)AS DDOPPORBANKED, SUM(EIO)AS EIO, SUM(EIOBANKED)AS EIOBANKED FROM PDCC_SUMMARY_COST ";
        return sql;
    }

    public static string getPDCostReductionPerformanceByYear()
    {
        string sql = PDCostReductionCalulationMast();
        sql += "WHERE YYEAR = :iYear";
        return sql;
    }

    public static string getPDCostReductionPerformanceByYearAssetService()
    {
        string sql = "SELECT SUM(PDCC_SUMMARY_COST.OPEX) AS OPEX, ";
        sql += "SUM(PDCC_SUMMARY_COST.DDBANKED)AS DDBANKED, ";
        sql += "SUM(PDCC_SUMMARY_COST.DDOPPOR) AS DDOPPOR, ";
        sql += "SUM(PDCC_SUMMARY_COST.DDOPPORBANKED) AS DDOPPORBANKED, ";
        sql += "SUM(PDCC_SUMMARY_COST.EIO) AS EIO, ";
        sql += "SUM(PDCC_SUMMARY_COST.EIOBANKED) AS EIOBANKED ";
        sql += "FROM PDCC_ASSET_SERVICE ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_ASSET_SERVICE.IDSERVICE = PDCC_ASSET.IDSERVICE ";
        sql += "INNER JOIN PDCC_SUMMARY_COST ON PDCC_ASSET.ASSETID = PDCC_SUMMARY_COST.ASSETID ";
        sql += "WHERE PDCC_SUMMARY_COST.YYEAR = :iYear AND PDCC_ASSET_SERVICE.IDSERVICE = :iServiceId";

        return sql;
    }

    public static string getPDCostReductionPerformanceByYearOU()
    {
        string sql = "SELECT SUM(PDCC_SUMMARY_COST.OPEX) AS OPEX, ";
        sql += "SUM(PDCC_SUMMARY_COST.DDBANKED)AS DDBANKED, ";
        sql += "SUM(PDCC_SUMMARY_COST.DDOPPOR) AS DDOPPOR, ";
        sql += "SUM(PDCC_SUMMARY_COST.DDOPPORBANKED) AS DDOPPORBANKED, ";
        sql += "SUM(PDCC_SUMMARY_COST.EIO) AS EIO, ";
        sql += "SUM(PDCC_SUMMARY_COST.EIOBANKED) AS EIOBANKED ";
        sql += "FROM PDCC_ASSET_SERVICE ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_ASSET_SERVICE.IDSERVICE = PDCC_ASSET.IDSERVICE ";
        sql += "INNER JOIN PDCC_SUMMARY_COST ON PDCC_ASSET.ASSETID = PDCC_SUMMARY_COST.ASSETID ";
        sql += "INNER JOIN COMMON_OU ON PDCC_ASSET.IDOU = COMMON_OU.IDOU ";
        sql += "WHERE PDCC_SUMMARY_COST.YYEAR = :iYear AND COMMON_OU.IDOU = :iOuId";

        return sql;
    }

    #endregion


    #region =========================== PD Savings Summary Estimated and Actual Overall Savings =====================

    public static string InsertEstimatedSavings()
    {
        string sql = "INSERT INTO PDCC_PDESTIMATE (ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID) VALUES (:iAssetId, :iMonth, :iYear, :dDD, :dDDO, :dEIO, :iUserId)";
        return sql;
    }

    public static string InsertInitialEstimatedSavings()
    {
        string sql = "INSERT INTO PDCC_PDINITESTSAVINGS (ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID) VALUES (:iAssetId, :iMonth, :iYear, :dDD, :dDDO, :dEIO, :iUserId)";
        return sql;
    }

    public static string UpdateInitialEstimatedSavings()
    {
        string sql = "UPDATE PDCC_PDINITESTSAVINGS SET DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string InsertActualSavings()
    {
        string sql = "INSERT INTO PDCC_PDACTUAL (ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID) VALUES (:iAssetId, :iMonth, :iYear, :dDD, :dDDO, :dEIO, :iUserId)";
        return sql;
    }

    public static string UpdateEstimatedSavings()
    {
        string sql = "UPDATE PDCC_PDESTIMATE SET ASSETID = :iAssetId, IMONTH = :iMonth, IYEAR = :iYear, DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE IDESTIMATE = :lEstimateId";
        return sql;
    }

    public static string UpdateEstimatedSavings2()
    {
        string sql = "UPDATE PDCC_PDESTIMATE SET DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string UpdateActualSavings()
    {
        string sql = "UPDATE PDCC_PDACTUAL SET ASSETID = :iAssetId, IMONTH = :iMonth, IYEAR = :iYear, DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE IDACTUAL = :lActualId";
        return sql;
    }

    //public static string UpdateActualSavings2()
    //{
    //    string sql = "UPDATE PDCC_PDACTUAL SET DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
    //    return sql;
    //}

    public static string UpdateActualSavings2()
    {
        string sql = "UPDATE PDCC_PDACTUAL SET DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear) ";
        return sql;
    }

    public static string InsertLESavings()
    {
        string sql = "INSERT INTO PDCC_PDLE (ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID) VALUES (:iAssetId, :iMonth, :iYear, :dDD, :dDDO, :dEIO, :iUserId)";
        return sql;
    }

    public static string UpdateLESavings()
    {
        string sql = "UPDATE PDCC_PDLE SET ASSETID = :iAssetId, IMONTH = :iMonth, IYEAR = :iYear, DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE IDLE = :lLEId";
        return sql;
    }

    public static string UpdateLESavings2()
    {
        string sql = "UPDATE PDCC_PDLE SET DD = :dDD, DDO = :dDDO, EIO = :dEIO, USERID = :iUserId WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string getEstimatedSavings()
    {
        string sql = "SELECT IDESTIMATE, ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID FROM PDCC_PDESTIMATE WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string getInitialEstimatedSavings()
    {
        string sql = "SELECT IDESTSAVINGS, ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID FROM PDCC_PDINITESTSAVINGS WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string getActualSavings()
    {
        string sql = "SELECT IDACTUAL, ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID FROM PDCC_PDACTUAL WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }
    public static string getLESavings()
    {
        string sql = "SELECT IDLE, ASSETID, IMONTH, IYEAR, DD, DDO, EIO, USERID FROM PDCC_PDLE WHERE (ASSETID = :iAssetId AND IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string getEstimatedSavingsSum()
    {
        string sql = "SELECT SUM(DD) AS DD, SUM(DDO) AS DDO, SUM(EIO) AS EIO FROM PDCC_PDESTIMATE WHERE (IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string getInitialEstimatedSavingsSum()
    {
        string sql = "SELECT SUM(DD) AS DD, SUM(DDO) AS DDO, SUM(EIO) AS EIO FROM PDCC_PDINITESTSAVINGS WHERE (IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string getActualSavingsSum()
    {
        string sql = "SELECT SUM(DD) AS DD, SUM(DDO) AS DDO, SUM(EIO) AS EIO FROM PDCC_PDACTUAL WHERE (IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    public static string getLESavingsSum()
    {
        string sql = "SELECT SUM(DD) AS DD, SUM(DDO) AS DDO, SUM(EIO) AS EIO FROM PDCC_PDLE WHERE (IMONTH = :iMonth AND IYEAR = :iYear)";
        return sql;
    }

    #endregion
}