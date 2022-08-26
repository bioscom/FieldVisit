using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedureIDD
/// </summary>


public class StoredProcedureIDD
{
    public StoredProcedureIDD()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //public static string CreateIDD()
    //{
    //    string sql = "INSERT INTO IDD_REQUEST (REQUESTID, IDDNO, USERID, CATEGORYID, VENDOURCODE, REGISTEREDNAME, ";
    //    sql += "ADDRESS, REPRESENTATIVE, EMAILADDRESS, TELEPHONENO, STAGE, DATE_SUBMITTED, NOR, AMOUNT, GOE, GI) ";
    //    sql += "VALUES (:lRequestId, :sIDDNo, :iUserId, :iCategoryId, :sVendourCode, :sRegisteredName, ";
    //    sql += ":sAddress, :sRepresentative, :sEmailAddress, :sTelephoneNo, :iStage, :dDateSubmitted, :iNor, :dAmount, :iGo, :iGi)";

    //    return sql;
    //}

    public static string getIDDAutoNumber()
    {
        string sql = "SELECT AUTO FROM IDD_AUTO";
        return sql;
    }

    public static string UpdateIDDAuto()
    {
        string sql = "UPDATE IDD_AUTO SET AUTO = :lVendorId";
        return sql;
    }

    public static string getRequestIdAutoNumber()
    {
        string sql = "SELECT AUTO FROM IDD_REQUEST_AUTO";
        return sql;
    }

    public static string UpdateReqNumAuto()
    {
        string sql = "UPDATE IDD_REQUEST_AUTO SET AUTO = :lRequestId";
        return sql;
    }

    

    //public static string UpdateIDD()
    //{
    //    string sql = "UPDATE IDD_REQUEST SET USERID = :iUserId, CATEGORYID = :iCategoryId, ";
    //    sql += "VENDOURCODE = :sVendourCode, REGISTEREDNAME = :sRegisteredName, ADDRESS = :sAddress, ";
    //    sql += "REPRESENTATIVE = :sRepresentative, EMAILADDRESS = :sEmailAddress, TELEPHONENO = :sTelephoneNo, ";
    //    sql += "NOR = :iNor, AMOUNT = :dAmount, GOE = :iGo, GI = :iGi WHERE REQUESTID = :lRequestId";

    //    return sql;
    //}



    public static string AssignIDDAnalyst()
    {
        string sql = "UPDATE IDD_REQUEST SET FOCALPOINTID = :iFocalPointId, ANALYSTID = :iAnalystId, STAGE = :iStage, DATE_ASSIGNED = :dDateAssigned WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string AnalystActionRequest()
    {
        string sql = "UPDATE IDD_REQUEST SET STATUS = :iStatus, STAGE = :iStage, COMMENTS = :sComments, DATESCREENED = :dValidityPeriod  WHERE REQUESTID = :lRequestId";
        return sql;
    }

    public static string VMIDDLeadApproveRequest()
    {
        string sql = "UPDATE IDD_REQUEST SET STATUS = :iStatus, STAGE = :iStage, APPROVERCOMMENT = :sComments  WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string VMIDDLeadApproveRequestWtDate()
    {
        string sql = "UPDATE IDD_REQUEST SET STATUS = :iStatus, STAGE = :iStage, DATESCREENED = :dtScreened, APPROVERCOMMENT = :sComments  WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string VMIDDActionRequest()
    {
        string sql = "UPDATE IDD_REQUEST SET STATUS = :iStatus, STAGE = :iStage, APPROVERCOMMENT = :sComments, VSR = :iVsr WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string IddExpired()
    {
        string sql = "UPDATE IDD_REQUEST SET STATUS = :iStatus, STAGE = :iStage WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string AnalystActionRequest2()
    {
        string sql = "UPDATE IDD_REQUEST SET STATUS = :iStatus, COMMENTS = :sComments  WHERE REQUESTID = :lRequestId";
        return sql;
    }

    #region   //  Due Diligence Audit Trail review

    public static string RequestActionAuditTrail()
    {
        string sql = "INSERT INTO IDD_REQUEST_AUDIT (REQUESTID, USERID, STAGE, STATUS, COMMENTS, DATECOMMENT) VALUES (:lRequestId, :iUserId, :iStage, :iStatus, :sComments, :dDateComment)";
        //Note Validity Period here has been changed to date_update made by the IDD Analyst.
        //validity period is now assigned to the 
        return sql;
    }

    public static string UpdateActionAuditTrail()
    {
        string sql = "UPDATE IDD_REQUEST_AUDIT SET APPROVEDBY = :iUserId, STAGE = :iStage, STATUS = :iStatus, COMMENTS = :sComments, APPROVERCOMMENT = :sApproverComments, APPROVALSTATUS = :iYesNo, DATEAPPROVED = :dDateComment WHERE AUDITID = :lAuditId";
        return sql;
    }

    public static string getAuditTraiByRequestId()
    {
        string sql = "SELECT AUDITID, REQUESTID, USERID, STAGE, STATUS, COMMENTS, DATECOMMENT, DATEAPPROVED, APPROVERCOMMENT, APPROVALSTATUS, APPROVEDBY FROM IDD_REQUEST_AUDIT WHERE AUDITID = :lAuditId";
        return sql;
    }

    #endregion

    public static string RequestRejected()
    {
        string sql = "UPDATE IDD_REQUEST SET FOCALPOINTID = :iFocalPointId, COMMENTS = :sComments, STAGE = :iStage WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string getRequests()
    {
        string sql = "SELECT IDD_REQUEST.REQUESTID, IDD_VENDOURS.VENDORID, IDD_REQUEST.USERID, IDD_REQUEST.FOCALPOINTID, IDD_REQUEST.ANALYSTID, IDD_VENDOURS.CODE, IDD_REQUEST.APPROVERCOMMENT, IDD_VENDOURS.REGISTEREDNAME, ";
        sql += "IDD_VENDOURS.ADDRESS, IDD_VENDOURS.REPRESENTATIVE, IDD_VENDOURS.EMAILADDRESS, IDD_VENDOURS.TELEPHONENO, IDD_REQUEST.COMMENTS, IDD_REQUEST.DATE_SUBMITTED, IDD_REQUEST.DATE_ASSIGNED, IDD_REQUEST.DATESCREENED, ";
        sql += "IDD_VENDOURS.IDDNO, IDD_REQUEST.STATUS, IDD_REQUEST.STAGE, IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_REQUEST.NOR, CONTRACTHOLDER.FULLNAME CONTRACTHOLDERFULLNAME, IDD_REQUEST.VSR, ";
        sql += "FOCALPOINT.FULLNAME FOCALPOINTFULLNAME, ANALYST.FULLNAME ANALYSTFULLNAME, ADD_MONTHS(TO_DATE(IDD_REQUEST.DATESCREENED), 36) AS VALIDTILL, IDD_VENDOURS.AMOUNT, IDD_VENDOURS.GOE, IDD_VENDOURS.GI ";
        sql += "FROM IDD_CATEGORY ";
        sql += "INNER JOIN IDD_VENDOURS ON IDD_VENDOURS.CATEGORYID = IDD_CATEGORY.CATEGORYID ";
        sql += "INNER JOIN IDD_REQUEST ON IDD_REQUEST.VENDORID = IDD_VENDOURS.VENDORID ";
        sql += "INNER JOIN PROD_USERMGT CONTRACTHOLDER ON IDD_REQUEST.USERID = CONTRACTHOLDER.USERID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT FOCALPOINT ON IDD_REQUEST.FOCALPOINTID = FOCALPOINT.USERID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT ANALYST ON IDD_REQUEST.ANALYSTID = ANALYST.USERID ";

        //string sql = "SELECT IDD_REQUEST.REQUESTID, IDD_REQUEST.USERID, IDD_REQUEST.FOCALPOINTID, IDD_REQUEST.ANALYSTID, IDD_REQUEST.APPROVERCOMMENT, ";
        //sql += "IDD_REQUEST.COMMENTS, IDD_REQUEST.DATE_SUBMITTED, IDD_REQUEST.DATESCREENED, IDD_REQUEST.STATUS, IDD_REQUEST.STAGE, IDD_CATEGORY.CATEGORYID, ";
        //sql += "IDD_CATEGORY.CATEGORY, IDD_REQUEST.NOR, IDD_REQUEST.VSR, CONTRACTHOLDER.FULLNAME CONTRACTHOLDERFULLNAME, FOCALPOINT.FULLNAME FOCALPOINTFULLNAME, ";
        //sql += "ANALYST.FULLNAME ANALYSTFULLNAME, ";
        //sql += "IDD_VENDOURS.VENDORID, IDD_VENDOURS.CODE IDD_VENDOURS.REGISTEREDNAME, IDD_VENDOURS.ADDRESS, IDD_VENDOURS.REPRESENTATIVE, IDD_VENDOURS.EMAILADDRESS, ";
        //sql += "IDD_VENDOURS.TELEPHONENO, IDD_VENDOURS.IDDNO, IDD_VENDOURS.AMOUNT, IDD_VENDOURS.GOE, IDD_VENDOURS.GI ";
        //sql += "FROM IDD_CATEGORY ";
        //sql += "INNER JOIN IDD_VENDOURS ON IDD_VENDOURS.CATEGORYID = IDD_CATEGORY.CATEGORYID ";
        //sql += "INNER JOIN IDD_REQUEST ON IDD_REQUEST.VENDORID = IDD_VENDOURS.VENDORID ";
        //sql += "INNER JOIN PROD_USERMGT CONTRACTHOLDER ON IDD_REQUEST.USERID = CONTRACTHOLDER.USERID ";
        //sql += "LEFT OUTER JOIN PROD_USERMGT FOCALPOINT ON IDD_REQUEST.FOCALPOINTID = FOCALPOINT.USERID ";
        //sql += "LEFT OUTER JOIN PROD_USERMGT ANALYST ON IDD_REQUEST.ANALYSTID = ANALYST.USERID ";

        return sql;
    }

    public static string getVSRReport()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.STATUS >= :iStatus AND IDD_REQUEST.VSR = :iVsr ORDER BY IDD_VENDOURS.REGISTEREDNAME ";

        return sql;
    }

    public static string getVSRReportByVendorId()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.STATUS >= :iStatus AND IDD_REQUEST.VSR = :iVsr AND IDD_VENDOURS.VENDORID = :lVendorId";

        return sql;
    }

    public static string getVSRReportByRequestId()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.REQUESTID = :lRequestId";

        return sql;
    }

    private static string Expired()
    {
        string sql = "SELECT IDD_REQUEST.REQUESTID, IDD_REQUEST.USERID, IDD_REQUEST.FOCALPOINTID, IDD_REQUEST.ANALYSTID, IDD_REQUEST.COMMENTS, IDD_REQUEST.DATE_SUBMITTED, ";
        sql += "IDD_REQUEST.STATUS, IDD_REQUEST.STAGE, IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_REQUEST.NOR, CONTRACTHOLDER.FULLNAME CONTRACTHOLDERFULLNAME, ";
        sql += "FOCALPOINT.FULLNAME FOCALPOINTFULLNAME, ANALYST.FULLNAME ANALYSTFULLNAME, SYSDATE, IDD_REQUEST.DATESCREENED, ROUND(TO_NUMBER(SYSDATE - IDD_REQUEST.DATESCREENED)) AS EXPIRED, ";
        sql += "ADD_MONTHS(TO_DATE(IDD_REQUEST.DATESCREENED), 36) AS VALIDTILL, ROUND(TO_NUMBER(MONTHS_BETWEEN(SysDate, IDD_REQUEST.DATESCREENED))) AS MONTHS, ";
        sql += "IDD_VENDOURS.VENDORID, IDD_VENDOURS.CODE, IDD_VENDOURS.REGISTEREDNAME, IDD_VENDOURS.ADDRESS, IDD_VENDOURS.REPRESENTATIVE, IDD_VENDOURS.EMAILADDRESS, IDD_VENDOURS.TELEPHONENO, ";
        sql += "IDD_VENDOURS.IDDNO, IDD_VENDOURS.AMOUNT, IDD_VENDOURS.GOE, IDD_VENDOURS.GI ";
        sql += "FROM IDD_CATEGORY ";
        sql += "INNER JOIN IDD_VENDOURS ON IDD_VENDOURS.CATEGORYID = IDD_CATEGORY.CATEGORYID ";
        sql += "RIGHT OUTER JOIN IDD_REQUEST ON IDD_REQUEST.VENDORID = IDD_VENDOURS.VENDORID ";
        sql += "INNER JOIN PROD_USERMGT CONTRACTHOLDER ON IDD_REQUEST.USERID = CONTRACTHOLDER.USERID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT FOCALPOINT ON IDD_REQUEST.FOCALPOINTID = FOCALPOINT.USERID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT ANALYST ON IDD_REQUEST.ANALYSTID = ANALYST.USERID ";

        return sql;
    }

    public static string getExpiredIDDs()
    {
        string sql = Expired();
        sql += "WHERE SYSDATE > IDD_REQUEST.DATESCREENED ORDER BY IDD_VENDOURS.IDDNO ";
        return sql;
    }

    public static string getExpiredIDDBtween()
    {
        string sql = Expired();
        sql += "WHERE SYSDATE > IDD_REQUEST.DATESCREENED AND (IDD_REQUEST.DATESCREENED BETWEEN TO_DATE(:dFrom) AND TO_DATE(:dTo)) ORDER BY IDD_VENDOURS.IDDNO";
        return sql;
    }

    public static string getExpiredIDDByRequestId()
    {
        string sql = Expired();
        sql += "WHERE SYSDATE > IDD_REQUEST.DATESCREENED AND IDD_REQUEST.REQUESTID = :lRequestId ORDER BY IDD_VENDOURS.IDDNO";
        return sql;
    }


    #region Initiators / Request initiators

    public static string getMyPendingRequest()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.USERID = :iUserId AND IDD_REQUEST.STAGE = :iStage ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getMyRequestAssignedToAnalyst()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.USERID = :iUserId AND IDD_REQUEST.STAGE <> :iStage AND IDD_REQUEST.ANALYSTID IS NOT NULL ORDER BY IDD_VENDOURS.IDDNO";
        
        return sql;
    }

    public static string getMyCompletedRequests()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.USERID = :iUserId ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getMyRejectedRequest()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.USERID = :iUserId AND IDD_REQUEST.STAGE = :iStage ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getRejectedRequests()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.STAGE = :iStage ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    #endregion

    public static string getCompletedRequestByStatus()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.STATUS = :iStatus AND IDD_REQUEST.VSR = :iVsr ORDER BY IDD_VENDOURS.IDDNO";
        return sql;
    }

    public static string getRequestAssignedToMeAnalyst()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.ANALYSTID = :iUserId AND VSR = :iVsr ORDER BY IDD_REQUEST.DATE_ASSIGNED";
        //sql += " WHERE IDD_REQUEST.ANALYSTID = :iUserId AND VSR = :iVsr";

        return sql;
    }

    public static string getRequestAssignedToMeAnalystInVsr()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.ANALYSTID = :iUserId AND VSR = :iVsr ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getRequestAssignedToAnalyst()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.ANALYSTID IS NOT NULL ORDER BY IDD_REQUEST.DATE_ASSIGNED";
        //sql += " WHERE IDD_REQUEST.ANALYSTID IS NOT NULL";

        return sql;
    }

    public static string getPendingRequests()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.STAGE = :iStage ORDER BY IDD_VENDOURS.REGISTEREDNAME";

        return sql;
    }

    public static string getRequestById()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.REQUESTID = :lRequestId";
        //getRequests();
        return sql;
    }

    public static string getRequestByVendorId()
    {
        string sql = getRequests();
        sql += " WHERE IDD_VENDOURS.VENDORID = :lVendorId";
        return sql;
    }

    public static string getRequestByPriority()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.PRIORITY = :iPriority ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getRequestByLocation()
    {
        string sql = getRequests();
        sql += " WHERE IDD_LOCATION.LOCATIONID = :iLocationId ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getRequestByLocationCategory()
    {
        string sql = getRequests();
        sql += " WHERE IDD_LOCATION.LOCATIONID = :iLocationId AND IDD_CATEGORY.CATEGORYID = :iCategoryId ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getRequestByVendourCode()
    {
        string sql = getRequests();
        sql += " WHERE IDD_REQUEST.CODES = :sVendourCode ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getVendorByVendourCode()
    {
        string sql = getRequests();
        sql += " WHERE IDD_VENDOURS.CODE = :sVendourCode ORDER BY IDD_VENDOURS.IDDNO";

        return sql;
    }

    public static string getRequestByRegisteredName()
    {
        string sql = getRequests();
        //sql += " WHERE IDD_VENDOURS.REGISTEREDNAME = :sRegisteredName ORDER BY IDD_VENDOURS.IDDNO";
        sql += " WHERE(UPPER(IDD_VENDOURS.REGISTEREDNAME) LIKE UPPER(:sRegisteredName))";

        return sql;
    }

    public static string getVendorByRegisteredName()
    {
        string sql = getRequests();
        //sql += " WHERE IDD_VENDOURS.REGISTEREDNAME = :sRegisteredName ORDER BY IDD_VENDOURS.IDDNO";
        sql += " WHERE(UPPER(IDD_VENDOURS.REGISTEREDNAME) LIKE UPPER(:sRegisteredName))";

        return sql;
    }


    #region  Request Documents

    public static string InsertRequestDocuments()
    {
        string sql = "INSERT INTO IDD_REQUESTDOCS (REQUESTID, DOCS, SFILENAME, SFILETYPE) VALUES (:lRequestId, :bBlobFile, :sFileName, :sFileType)";

        return sql;
    }

    public static string DeleteRequestDocuments()
    {
        string sql = "DELETE FROM IDD_REQUESTDOCS WHERE DOCSID = :lDocId";
        return sql;
    }

    public static string getRequestDocumentsByRequestId()
    {
        string sql = "SELECT DOCSID, REQUESTID, DOCS, SFILENAME, SFILETYPE FROM IDD_REQUESTDOCS WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string getRequestDocumentByDocId()
    {
        string sql = "SELECT DOCSID, REQUESTID, DOCS, SFILENAME, SFILETYPE FROM IDD_REQUESTDOCS WHERE DOCSID = :lDocId";

        return sql;
    }

    #endregion

    #region Delete Request

    public static string DeleteRequestDocs()
    {
        string sql = "DELETE FROM IDD_REQUESTDOCS WHERE REQUESTID = :lRequestId";
        return sql;
    }

    public static string DeleteRequestAuditTrails()
    {
        string sql = "DELETE FROM IDD_REQUEST_AUDIT WHERE REQUESTID = :lRequestId";
        return sql;
    }

    public static string DeleteRequest()
    {
        string sql = "DELETE FROM IDD_REQUEST WHERE REQUESTID = :lRequestId";
        return sql;
    }

    #endregion

    #region Loactions

    public static string getLocations()
    {
        string sql = "SELECT LOCATIONID, LOCATION FROM IDD_LOCATION";

        return sql;
    }

    #endregion

    #region  Departments

    public static string getDepartments()
    {
        string sql = "SELECT IDD_DEPT.DEPTID, IDD_DEPT.DEPARTMENT FROM IDD_DEPT ORDER BY IDD_DEPT.DEPARTMENT";

        return sql;
    }



    #endregion


    #region  Services / Or Categories

    public static string getServices()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_CATEGORY.DEPTID, PROD_USERMGT.FULLNAME, PROD_USERMGT.USERID ";
        sql += "FROM IDD_CATEGORY LEFT OUTER JOIN PROD_USERMGT ON IDD_CATEGORY.USERID = PROD_USERMGT.USERID ORDER BY IDD_CATEGORY.CATEGORY";

        return sql;
    }

    public static string getServiceByServiceId()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_CATEGORY.DEPTID, PROD_USERMGT.FULLNAME, PROD_USERMGT.USERID ";
        sql += "FROM IDD_CATEGORY INNER JOIN PROD_USERMGT ON IDD_CATEGORY.USERID = PROD_USERMGT.USERID WHERE IDD_CATEGORY.CATEGORYID = :iServiceId";

        return sql;
    }
    public static string getServicesByLocation()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_CATEGORY.DEPTID, IDD_CATEGORY.USERID, IDD_LOCATION.LOCATIONID, IDD_LOCATION.LOCATION FROM IDD_LOCATION ";
        sql += "INNER JOIN IDD_LOCATIION_SERVICES ON IDD_LOCATION.LOCATIONID = IDD_LOCATIION_SERVICES.LOCATIONID ";
        sql += "INNER JOIN IDD_CATEGORY ON IDD_CATEGORY.CATEGORYID = IDD_LOCATIION_SERVICES.CATEGORYID WHERE IDD_LOCATION.LOCATIONID = :iLocationId ORDER BY IDD_CATEGORY.CATEGORY";

        return sql;
    }

    public static string getServicesByLocationDepartment()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_CATEGORY.DEPTID, IDD_CATEGORY.USERID, IDD_LOCATION.LOCATIONID, IDD_LOCATION.LOCATION FROM IDD_LOCATION ";
        sql += "INNER JOIN IDD_LOCATIION_SERVICES ON IDD_LOCATION.LOCATIONID = IDD_LOCATIION_SERVICES.LOCATIONID ";
        sql += "INNER JOIN IDD_CATEGORY ON IDD_CATEGORY.CATEGORYID = IDD_LOCATIION_SERVICES.CATEGORYID WHERE IDD_LOCATION.LOCATIONID = :iLocationId AND IDD_CATEGORY.DEPTID = :iDept ORDER BY IDD_CATEGORY.CATEGORY";

        return sql;
    }

    public static string getServicesByDepartment()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_CATEGORY.USERID, IDD_DEPT.DEPTID, IDD_DEPT.DEPARTMENT ";
        sql += "FROM IDD_CATEGORY ";
        sql += "INNER JOIN IDD_DEPT ON IDD_DEPT.DEPTID = IDD_CATEGORY.DEPTID WHERE IDD_DEPT.DEPTID = :iDept";

        return sql;
    }

    public static string AssignCategoryLead()
    {
        string sql = "UPDATE IDD_CATEGORY SET USERID = :iUserId WHERE CATEGORYID = :iCategoryId";
        return sql;
    }

    #endregion

    #region   Request initiators

    public static string CreateContractHolder()
    {
        string sql = "INSERT INTO IDD_CONTRACTHOLDERS (USERID, CATEGORYID) VALUES (:iUserId, :iCategoryId)";
        return sql;
    }

    public static string RemoveContractHolder()
    {
        string sql = "DELETE FROM IDD_CONTRACTHOLDERS WHERE USERID = :iUserId";
        return sql;
    }
    public static string getContractHolders()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_LOCATION.LOCATIONID, IDD_LOCATION.LOCATION, ";
        sql += "IDD_CONTRACTHOLDERS.CONTRACTHOLDERID, IDD_CONTRACTHOLDERS.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, ";
        sql += "PROD_USERMGT.USERNAME, IDD_DEPT.DEPARTMENT FROM IDD_LOCATION ";
        sql += "INNER JOIN IDD_LOCATIION_SERVICES ON IDD_LOCATION.LOCATIONID = IDD_LOCATIION_SERVICES.LOCATIONID ";
        sql += "INNER JOIN IDD_CATEGORY ON IDD_CATEGORY.CATEGORYID = IDD_LOCATIION_SERVICES.CATEGORYID ";
        sql += "INNER JOIN IDD_CONTRACTHOLDERS ON IDD_CATEGORY.CATEGORYID = IDD_CONTRACTHOLDERS.CATEGORYID ";
        sql += "INNER JOIN PROD_USERMGT ON IDD_CONTRACTHOLDERS.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN IDD_DEPT ON IDD_DEPT.DEPTID = IDD_CATEGORY.DEPTID ";
        sql += "ORDER BY IDD_LOCATION.LOCATION, IDD_CONTRACTHOLDERS.USERID";

        return sql;
    }

    public static string getContractHoldersByLocationCategory()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_LOCATION.LOCATIONID, IDD_LOCATION.LOCATION, ";
        sql += "IDD_CONTRACTHOLDERS.CONTRACTHOLDERID, IDD_CONTRACTHOLDERS.USERID FROM IDD_LOCATION ";
        sql += "INNER JOIN IDD_LOCATIION_SERVICES ON IDD_LOCATION.LOCATIONID = IDD_LOCATIION_SERVICES.LOCATIONID ";
        sql += "INNER JOIN IDD_CATEGORY ON IDD_CATEGORY.CATEGORYID = IDD_LOCATIION_SERVICES.CATEGORYID ";
        sql += "INNER JOIN IDD_CONTRACTHOLDERS ON IDD_CATEGORY.CATEGORYID = IDD_CONTRACTHOLDERS.CATEGORYID ";


        sql += "WHERE IDD_LOCATION.LOCATIONID = :iLocationId AND IDD_CATEGORY.CATEGORYID = :iCategoryId ";
        sql += "ORDER BY IDD_CATEGORY.CATEGORY, IDD_CONTRACTHOLDERS.USERID ";
        return sql;
    }

    public static string getContractHoldersByLocation()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_LOCATION.LOCATIONID, IDD_LOCATION.LOCATION, ";
        sql += "IDD_CONTRACTHOLDERS.CONTRACTHOLDERID, IDD_CONTRACTHOLDERS.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, ";
        sql += "PROD_USERMGT.USERNAME, IDD_DEPT.DEPARTMENT FROM IDD_LOCATION ";
        sql += "INNER JOIN IDD_LOCATIION_SERVICES ON IDD_LOCATION.LOCATIONID = IDD_LOCATIION_SERVICES.LOCATIONID ";
        sql += "INNER JOIN IDD_CATEGORY ON IDD_CATEGORY.CATEGORYID = IDD_LOCATIION_SERVICES.CATEGORYID ";
        sql += "INNER JOIN IDD_CONTRACTHOLDERS ON IDD_CATEGORY.CATEGORYID = IDD_CONTRACTHOLDERS.CATEGORYID ";
        sql += "INNER JOIN PROD_USERMGT ON IDD_CONTRACTHOLDERS.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN IDD_DEPT ON IDD_DEPT.DEPTID = IDD_CATEGORY.DEPTID ";
        sql += "WHERE IDD_LOCATION.LOCATIONID = :iLocationId ";
        sql += "ORDER BY IDD_CATEGORY.CATEGORY, IDD_CONTRACTHOLDERS.USERID ";
        return sql;
    }

    public static string getContractHoldersByUserId()
    {
        string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_LOCATION.LOCATIONID, IDD_LOCATION.LOCATION, ";
        sql += "IDD_CONTRACTHOLDERS.CONTRACTHOLDERID, IDD_CONTRACTHOLDERS.USERID FROM IDD_LOCATION ";
        sql += "INNER JOIN IDD_LOCATIION_SERVICES ON IDD_LOCATION.LOCATIONID = IDD_LOCATIION_SERVICES.LOCATIONID ";
        sql += "INNER JOIN IDD_CATEGORY ON IDD_CATEGORY.CATEGORYID = IDD_LOCATIION_SERVICES.CATEGORYID ";
        sql += "INNER JOIN IDD_CONTRACTHOLDERS ON IDD_CATEGORY.CATEGORYID = IDD_CONTRACTHOLDERS.CATEGORYID ";


        sql += "WHERE IDD_CONTRACTHOLDERS.USERID = :iUserId";
        return sql;
    }

    #endregion

    #region Administrators

    public static string getAdministators()
    {
        string sql = "SELECT IDD_ADMIN.ID, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, PROD_USERMGT.REFIND FROM IDD_ADMIN ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = IDD_ADMIN.USERID ";

        return sql;
    }

    public static string getAdministatorByUserId()
    {
        string sql = getAdministators();
        sql += " WHERE IDD_ADMIN.USERID = :iUserId";

        return sql;
    }

    public static string addAdministrator()
    {
        string sql = "INSERT INTO IDD_ADMIN (USERID) VALUES (:iUserId)";
        return sql;
    }

    public static string RemoveAdministrator()
    {
        string sql = "DELETE FROM IDD_ADMIN WHERE USERID = :iUserId";
        return sql;
    }

    #endregion

    #region Corporate Users

    public static string getCorporateUsers()
    {
        string sql = "SELECT IDD_CORPORATE.IDCORPORATE, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, PROD_USERMGT.REFIND FROM IDD_CORPORATE ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = IDD_CORPORATE.USERID ";

        return sql;
    }

    public static string getCorporateUserByUserId()
    {
        string sql = getCorporateUsers();
        sql += " WHERE IDD_CORPORATE.USERID = :iUserId";

        return sql;
    }

    public static string addCorporateUser()
    {
        string sql = "INSERT INTO IDD_CORPORATE (USERID) VALUES (:iUserId)";
        return sql;
    }

    public static string RemoveCorporateUser()
    {
        string sql = "DELETE FROM IDD_CORPORATE WHERE USERID = :iUserId";
        return sql;
    }

    #endregion



    #region Analysts

    public static string getAnalysts()
    {
        string sql = "SELECT IDD_ANALYST.ID, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, PROD_USERMGT.REFIND FROM IDD_ANALYST ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = IDD_ANALYST.USERID ";

        return sql;
    }

    public static string getAnalystByUserId()
    {
        string sql = getAnalysts();
        sql += " WHERE IDD_ANALYST.USERID = :iUserId";

        return sql;
    }

    public static string addAnalyst()
    {
        string sql = "INSERT INTO IDD_ANALYST (USERID) VALUES (:iUserId)";
        return sql;
    }

    public static string RemoveAnalyst()
    {
        string sql = "DELETE FROM IDD_ANALYST WHERE USERID = :iUserId";
        return sql;
    }

    public static string getOrderedAnalysts()
    {
        string sql = getAnalysts();
        sql += " ORDER BY PROD_USERMGT.FULLNAME";
        return sql;
    }

    #endregion


    #region Lead Focal Point

    public static string getLeadFocalPoints()
    {
        string sql = "SELECT IDD_LEAD.ID, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, PROD_USERMGT.REFIND FROM IDD_LEAD ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = IDD_LEAD.USERID ";

        return sql;
    }

    public static string getLeadFocalPointByUserId()
    {
        string sql = getLeadFocalPoints();
        sql += " WHERE IDD_LEAD.USERID = :iUserId";

        return sql;
    }

    public static string addLeadFocalPoint()
    {
        string sql = "INSERT INTO IDD_LEAD (USERID) VALUES (:iUserId)";
        return sql;
    }

    public static string RemoveLeadFocalPoint()
    {
        string sql = "DELETE FROM IDD_LEAD WHERE USERID = :iUserId";
        return sql;
    }

    #endregion



    #region ID Analyst Progressing Request to conclusion

    public static string getProgressReportByRequestId()
    {
        string sql = "SELECT REPORTID, REQUESTID, STATUS, COMMENTS, DATE_COMMENT, ANALYSTID FROM IDD_REQUEST_REPORT WHERE REQUESTID = :lRequestId";
        return sql;
    }
    public static string addComment()
    {
        string sql = "INSERT INTO IDD_REQUEST_REPORT (REQUESTID, STATUS, COMMENTS, DATE_COMMENT, ANALYSTID) VALUES (:lRequestId, :iStatus, :sComments, :dDate, :iAnalyst)";
        return sql;
    }

    public static string updateComment()
    {
        string sql = "UPDATE IDD_REQUEST_REPORT SET REQUESTID = :lRequestId, STATUS = :iStatus, COMMENTS = :sComments, DATE_COMMENT = :dDate, ANALYSTID = :iAnalyst WHERE REPORTID = :lReportId";
        return sql;
    }

    #endregion

    #region Audit Trail

    public static string getAuditTrailByRequestId()
    {
        string sql = "SELECT IDD_REQUEST_AUDIT.AUDITID, IDD_REQUEST_AUDIT.REQUESTID, IDD_REQUEST_AUDIT.USERID, IDD_REQUEST_AUDIT.STAGE, IDD_REQUEST_AUDIT.STATUS, IDD_REQUEST_AUDIT.COMMENTS, ";
        sql += "IDD_REQUEST_AUDIT.DATECOMMENT, PROD_USERMGT.FULLNAME AS ANALYSTNAME, ";
        sql += "IDD_REQUEST_AUDIT.DATEAPPROVED, IDD_REQUEST_AUDIT.APPROVERCOMMENT, IDD_REQUEST_AUDIT.APPROVALSTATUS,  APPROVER.FULLNAME AS APPROVERNAME FROM IDD_REQUEST_AUDIT ";
        sql += "LEFT OUTER JOIN PROD_USERMGT APPROVER ON IDD_REQUEST_AUDIT.APPROVEDBY = APPROVER.USERID ";
        sql += "INNER JOIN PROD_USERMGT ON IDD_REQUEST_AUDIT.USERID = PROD_USERMGT.USERID WHERE REQUESTID = :lRequestId ORDER BY IDD_REQUEST_AUDIT.AUDITID DESC";
        

        return sql;
    }

    #endregion

    #region New IDD model

    public static string getVendorBySearch()
    {
        string sql = "SELECT VENDORID, USERID, LOCATIONID, CATEGORYID, CODE, REGISTEREDNAME, ADDRESS, REPRESENTATIVE, EMAILADDRESS, TELEPHONENO, IDDNO, AMOUNT, GOE, GI ";
        sql += "FROM IDD_VENDOURS WHERE(UPPER(REGISTEREDNAME) LIKE UPPER(:Search))";

        return sql;
    }

    public static string getRequestBySearch()
    {
        //string sql = "SELECT IDD_REQUEST.REQUESTID, IDD_REQUEST.CODES, IDD_VENDOURS.REGISTEREDNAME, IDD_REQUEST.ADDRESS, IDD_REQUEST.REPRESENTATIVE, IDD_REQUEST.EMAILADDRESS, IDD_REQUEST.TELEPHONENO ";
        //sql += "FROM IDD_REQUEST WHERE(UPPER(IDD_VENDOURS.REGISTEREDNAME) LIKE UPPER(:Search))";

        string sql = "SELECT IDD_REQUEST.REQUESTID, IDD_VENDOURS.VENDORID, IDD_REQUEST.CODES, IDD_VENDOURS.REGISTEREDNAME, IDD_VENDOURS.ADDRESS, ";
        sql += "IDD_VENDOURS.REPRESENTATIVE, IDD_VENDOURS.EMAILADDRESS, IDD_VENDOURS.TELEPHONENO FROM IDD_VENDOURS ";
        sql += "INNER JOIN IDD_REQUEST ON IDD_REQUEST.VENDORID = IDD_VENDOURS.VENDORID ";
        sql += "WHERE(UPPER(IDD_VENDOURS.REGISTEREDNAME) LIKE UPPER(:Search)) AND IDD_REQUEST.VSR = :iVsr";

        return sql;
    }

    public static string getExpiredIdds()
    {
        string sql = "SELECT IDD_REQUEST.REQUESTID, IDD_REQUEST.VENDORID, SYSDATE, ADD_MONTHS(TO_DATE(IDD_REQUEST.DATESCREENED), 36) AS VALIDTILL, IDD_VENDOURS.REGISTEREDNAME ";
        sql += "FROM IDD_VENDOURS RIGHT OUTER JOIN IDD_REQUEST ON IDD_REQUEST.VENDORID = IDD_VENDOURS.VENDORID ";
        sql += "WHERE SYSDATE > ADD_MONTHS(TO_DATE(IDD_REQUEST.DATESCREENED), 36) AND IDD_REQUEST.STATUS > :Status ORDER BY IDD_VENDOURS.REGISTEREDNAME";

        return sql;
    }

    public static string getVendorById()
    {
        string sql = "SELECT VENDORID, USERID, LOCATIONID, CATEGORYID, CODE, REGISTEREDNAME, ADDRESS, REPRESENTATIVE, EMAILADDRESS, TELEPHONENO, IDDNO, AMOUNT, GOE, GI ";
        sql += "FROM IDD_VENDOURS WHERE VENDORID = :iVendorId";

        return sql;
    }

    public static string MakeIddRequest()
    {
        string sql = "INSERT INTO IDD_REQUEST (REQUESTID, USERID, STAGE, STATUS, DATE_SUBMITTED, NOR, VENDORID) VALUES (:lRequestId, :iUserId, :iStage, :iStatus, :dDateSubmitted, :iNor, :iVendorId)";

        return sql;
    }

    public static string UpdateRequest()
    {
        string sql = "UPDATE IDD_REQUEST SET USERID = :iUserId, STAGE = :iStage, STATUS = :iStatus, NOR = :iNor, VENDORID = :iVendorId WHERE REQUESTID = :lRequestId";

        return sql;
    }

    public static string DeleteDuplicateRequest()
    {
        string sql = "DELETE FROM IDD_REQUEST WHERE REQUESTID = :lRequestId";

        return sql;
    }

    #endregion


    #region Vendor Reporting

    public static string getVendorsT()
    {
        string sql = "SELECT IDD_VENDOURS.VENDORID, IDD_VENDOURS.IDDNO, IDD_VENDOURS.CODE, IDD_VENDOURS.REGISTEREDNAME, IDD_VENDOURS.ADDRESS, IDD_VENDOURS.REPRESENTATIVE, ";
        sql += "IDD_VENDOURS.EMAILADDRESS, IDD_VENDOURS.TELEPHONENO, IDD_VENDOURS.GI, IDD_VENDOURS.GOE, IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY FROM IDD_VENDOURS ";
        sql += "INNER JOIN IDD_CATEGORY ON IDD_VENDOURS.CATEGORYID = IDD_CATEGORY.CATEGORYID ";

        return sql;
    }

    public static string getVendors()
    {
        string sql = getVendorsT();
        sql += "ORDER BY IDD_VENDOURS.REGISTEREDNAME ";
        return sql;
    }

    public static string getVendorsTById()
    {
        string sql = getVendorsT();
        sql += "WHERE IDD_VENDOURS.VENDORID = :lVendorId";
        return sql;
    }

    //public static string getVendorsByStatus()
    //{
    //    string sql = getVendors();
    //    sql += "WHERE STATUS = :iStatus";
    //    return sql;
    //}

    public static string AddVendor()
    {
        string sql = "INSERT INTO IDD_VENDOURS (VENDORID, IDDNO, CATEGORYID, CODE, REGISTEREDNAME, ADDRESS, REPRESENTATIVE, EMAILADDRESS, TELEPHONENO, AMOUNT, GOE, GI) ";
        sql += "VALUES (:lVendorId, :sIDDNo, :iCategoryId, :sCodes, :sRegisteredName, :sAddress, :sRepresentative, :sEmailAddress, :sTelephoneNo, :dAmount, :iGo, :iGi)";

        return sql;
    }

    public static string UpdateVendor()
    {
        string sql = "UPDATE IDD_VENDOURS SET CATEGORYID = :iCategoryId, CODE = :sCodes, REGISTEREDNAME = :sRegisteredName, ADDRESS = :sAddress, REPRESENTATIVE = :sRepresentative, ";
        sql += "EMAILADDRESS = :sEmailAddress, TELEPHONENO = :sTelephoneNo, AMOUNT = :dAmount, GOE = :iGo, GI = :iGi WHERE VENDORID = :lVendorId";

        return sql;
    }

    #endregion

}