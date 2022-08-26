using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedureBongaCC
/// </summary>


public class StoredProcedureBongaCC
{
    public StoredProcedureBongaCC()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region //Approval Decision
    public static string getApprovalDecisions()
    {
        string sql = "SELECT BONGA_APPROVALDECISION.APPROVALID, BONGA_APPROVALDECISION.DECISION, BONGA_APPROVALDECISION.COLORCODE FROM BONGA_APPROVALDECISION";
        return sql;
    }

    public static string getApprovalDecisionById()
    {
        string sql = "SELECT BONGA_APPROVALDECISION.APPROVALID, BONGA_APPROVALDECISION.DECISION, BONGA_APPROVALDECISION.COLORCODE FROM BONGA_APPROVALDECISION WHERE BONGA_APPROVALDECISION.APPROVALID = :iApprovalId";
        return sql;
    }

    #endregion

    #region//Team
    public static string getTeams()
    {
        string sql = "SELECT BONGA_TEAM.TEAMID, BONGA_TEAM.NAME FROM BONGA_TEAM";

        return sql;

    }

    public static string getTeamById()
    {
        string sql = "SELECT BONGA_TEAM.TEAMID, BONGA_TEAM.NAME FROM BONGA_TEAM WHERE BONGA_TEAM.TEAMID = :iTeamId";

        return sql;

    }

    #endregion

    #region//Planning and Emmergency
    public static string getPlanningEmmergency()
    {
        string sql = "SELECT BONGA_PLNEMMERG.TYPEID, BONGA_PLNEMMERG.TYPE FROM BONGA_PLNEMMERG";
        return sql;
    }

    public static string getPlanningEmmergencyById()
    {
        string sql = "SELECT BONGA_PLNEMMERG.TYPEID, BONGA_PLNEMMERG.TYPE FROM BONGA_PLNEMMERG WHERE BONGA_PLNEMMERG.TYPEID = :iTypeId";
        return sql;
    }

    #endregion

    #region//Purchasing Groups
    public static string getPurchasingGroups()
    {
        string sql = "SELECT BONGA_PURCHASINGRP.GROUPID, BONGA_PURCHASINGRP.NAME FROM BONGA_PURCHASINGRP";
        return sql;
    }

    public static string getPurchasingGroupById()
    {
        string sql = "SELECT BONGA_PURCHASINGRP.GROUPID, BONGA_PURCHASINGRP.NAME FROM BONGA_PURCHASINGRP WHERE BONGA_PURCHASINGRP.GROUPID = :iGroupId";
        return sql;
    }

    #endregion

    #region//Request Staus (New or Re presented)
    public static string getRequestStatus()
    {
        string sql = "SELECT BONGA_REQUESTSTATUS.STATUSID, BONGA_REQUESTSTATUS.STATUS FROM BONGA_REQUESTSTATUS";
        return sql;
    }

    public static string getRequestStatusById()
    {
        string sql = "SELECT BONGA_REQUESTSTATUS.STATUSID, BONGA_REQUESTSTATUS.STATUS FROM BONGA_REQUESTSTATUS WHERE BONGA_REQUESTSTATUS.STATUSID = :iStatusId";
        return sql;
    }
    #endregion

    #region//Vehicle

    public static string getVehicles()
    {
        string sql = "SELECT BONGA_VEHICLE.VEHICLEID, BONGA_VEHICLE.NAME FROM BONGA_VEHICLE";
        return sql;
    }

    public static string getVehicleById()
    {
        string sql = "SELECT BONGA_VEHICLE.VEHICLEID, BONGA_VEHICLE.NAME FROM BONGA_VEHICLE WHERE BONGA_VEHICLE.VEHICLEID = :iVehicleId";
        return sql;
    }

    #endregion

    #region ====================== Bonga Commitment Control Master Data ============================

    public static string getCommitmentMaster()
    {
        string sql = "SELECT BONGA_COMMITMENTS.IDOU, BONGA_COMMITMENTS.COMMITMENTID, BONGA_COMMITMENTS.TITLE, BONGA_COMMITMENTS.COSTOBJECT, BONGA_COMMITMENTS.JUSTIFICATION, BONGA_COMMITMENTS.THREAT, ";
        sql += "BONGA_COMMITMENTS.CONTRACTNOVENDOR,BONGA_COMMITMENTS.PRNUMBER, BONGA_COMMITMENTS.PRVALUE, BONGA_COMMITMENTS.PONUMBER, BONGA_COMMITMENTS.POVALUE, BONGA_COMMITMENTS.COMMITMENT, ";
        sql += "BONGA_COMMITMENTS.APPROVALCOMMENT, BONGA_COMMITMENTS.SAVINGS, BONGA_COMMITMENTS.COMITMNTNO, ";
        sql += "BONGA_COMMITMENTS.PERIODFROM, BONGA_COMMITMENTS.PERIODTO, BONGA_COMMITMENTS.PREVIOUS, BONGA_COMMITMENTS.DATE_SUBMITTED, ";
        sql += "BONGA_APPROVALDECISION.APPROVALID, BONGA_APPROVALDECISION.DECISION AS DECISION, BONGA_APPROVALDECISION.COLORCODE, BONGA_REQUESTSTATUS.STATUSID, BONGA_REQUESTSTATUS.STATUS, ";
        sql += "BONGA_PLNEMMERG.TYPEID, BONGA_PLNEMMERG.TYPE, BONGA_PURCHASINGRP.GROUPID, BONGA_PURCHASINGRP.NAME AS GROUPNAME, COMMON_DEPARTMENT.IDDEPARTMENT, COMMON_DEPARTMENT.DEPARTMENT AS TEAMNAME, ";
        sql += "BONGA_VEHICLE.VEHICLEID, BONGA_VEHICLE.NAME AS VEHICLENAME, ";

        sql += "INITIATOR.USERID AS INITIATORID, INITIATOR.FULLNAME AS INITIATORFULLNAME, ";
        sql += "SPONSOR.USERID AS SPONSORID, SPONSOR.FULLNAME AS SPONSORFULLNAME, ";
        sql += "CHECKEDBY.USERID AS CHECKEDBYID, CHECKEDBY.FULLNAME AS CHECKEDBYFULLNAME, ";
        sql += "APPROVER.USERID AS APPROVERID, APPROVER.FULLNAME AS APPROVERFULLNAME, ";
        sql += "FOCALPOINT.USERID AS FOCALPOINTID, FOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, ";

        sql += "BONGA_COMMITMENTS.FACILITYID, PROD_FACILITIES.FACILITIES, BONGA_COMMITMENTS.ASSETID, PROD_ASSET.ASSETS, BONGA_COMMITMENTS.COSTOBJECTDESC, BONGA_COMMITMENTS.CAPEXOPEX, ";
        sql += "BONGA_COMMITMENTS.TEAMINDICATOR, BONGA_COMMITMENTS.NAPPIMSNAIRA, BONGA_COMMITMENTS.NAPPIMSDOLLAR, BONGA_COMMITMENTS.NAPPIMSFUNCDOLLAR, ";
        sql += "BONGA_COMMITMENTS.REQUESTNAIRA, BONGA_COMMITMENTS.REQUESTDOLLAR, BONGA_COMMITMENTS.REQUESTFUNCDOLLAR ";
        sql += "FROM BONGA_COMMITMENTS ";

        sql += "INNER JOIN BONGA_APPROVALDECISION ON BONGA_APPROVALDECISION.APPROVALID = BONGA_COMMITMENTS.APPROVALID ";
        sql += "INNER JOIN BONGA_PLNEMMERG ON BONGA_PLNEMMERG.TYPEID = BONGA_COMMITMENTS.TYPEID ";
        sql += "INNER JOIN BONGA_PURCHASINGRP ON BONGA_PURCHASINGRP.GROUPID = BONGA_COMMITMENTS.GROUPID ";
        sql += "INNER JOIN BONGA_REQUESTSTATUS ON BONGA_REQUESTSTATUS.STATUSID = BONGA_COMMITMENTS.STATUSID ";
        sql += "INNER JOIN COMMON_DEPARTMENT ON COMMON_DEPARTMENT.IDDEPARTMENT = BONGA_COMMITMENTS.IDDEPARTMENT ";
        sql += "INNER JOIN BONGA_VEHICLE ON BONGA_VEHICLE.VEHICLEID = BONGA_COMMITMENTS.VEHICLEID ";
        sql += "LEFT OUTER JOIN PROD_ASSET ON BONGA_COMMITMENTS.ASSETID = PROD_ASSET.IDASSET ";
        sql += "LEFT OUTER JOIN PROD_FACILITIES ON BONGA_COMMITMENTS.FACILITYID = PROD_FACILITIES.ID_FACILITIES ";

        sql += "LEFT OUTER JOIN PROD_USERMGT FOCALPOINT ON FOCALPOINT.USERID = BONGA_COMMITMENTS.FOCALPOINTID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT SPONSOR ON SPONSOR.USERID = BONGA_COMMITMENTS.SPONSORID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT CHECKEDBY ON CHECKEDBY.USERID = BONGA_COMMITMENTS.CHECKEDBYID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT APPROVER ON APPROVER.USERID = BONGA_COMMITMENTS.APPROVERID ";
        sql += "LEFT OUTER JOIN PROD_USERMGT INITIATOR ON INITIATOR.USERID = BONGA_COMMITMENTS.USERID ";
        sql += "ORDER BY BONGA_COMMITMENTS.COMMITMENTID DESC ";

        return sql;
    }

    public static string InsertCommitment()
    {
        string sql = "INSERT INTO BONGA_COMMITMENTS (COMMITMENTID, IDOU, COMITMNTNO, TITLE, COSTOBJECT, GROUPID, IDDEPARTMENT, ASSETID, FACILITYID, SPONSORID, ";
        sql += "CHECKEDBYID, FOCALPOINTID, USERID, TYPEID, STATUSID,  PERIODFROM, PERIODTO, JUSTIFICATION, THREAT, VEHICLEID, CONTRACTNOVENDOR, ";
        sql += "PRNUMBER, PRVALUE, PONUMBER, POVALUE, COMMITMENT, TEAMINDICATOR, COSTOBJECTDESC, CAPEXOPEX, PREVIOUS, NAPPIMSNAIRA, NAPPIMSDOLLAR, ";
        sql += "NAPPIMSFUNCDOLLAR, REQUESTNAIRA, REQUESTDOLLAR, REQUESTFUNCDOLLAR, DATE_SUBMITTED) ";
        sql += "VALUES (:lCommitmentId, :iOuId, :sCommitmentNumber, :sTitle, :sCostObject, :iGroupId, :iTeamId, :iAssetId, :iFacilityId, :iSponsorId, :iCheckedById, ";
        sql += ":iFocalPointId, :iInitiatorId, :iTypeId, :iStatusId, :tPeriodFrom, :tPeriodTo, :sJustification, :sThreat, :iVehicleId, ";
        sql += ":sContractNumberVendor, :sPRNumber, :dPRValue, :sPONumber, :dPOValue, :dCommitment, :sTeamIndicator, :sCostObjectDesc, :iCapexOpex, :tPrevious, ";
        sql += ":dNappimsNaira, :dNappimsDollar, :dNappimsFuncDollar, :dRequestNaira, :dRequestDollar, :dRequestFuncDollar, :tDateSubmitted)";
        return sql;
    }

    public static string UpdateCommitment()
    {
        string sql = "UPDATE BONGA_COMMITMENTS SET IDOU = :iOuId, TITLE = :sTitle, COSTOBJECT = :sCostObject, GROUPID = :iGroupId, IDDEPARTMENT = :iTeamId, ASSETID = :iAssetId, FACILITYID = :iFacilityId, SPONSORID = :iSponsorId, ";
        sql += "FOCALPOINTID = :iFocalPointId, CHECKEDBYID = :iCheckedById, APPROVERID = :iApproverId, USERID = :iInitiatorId, TYPEID = :iTypeId, STATUSID = :iStatusId, ";
        sql += "PERIODFROM = :tPeriodFrom, PERIODTO = :tPeriodTo, JUSTIFICATION = :sJustification, THREAT = :sThreat, VEHICLEID = :iVehicleId, CONTRACTNOVENDOR = :sContractNumberVendor, ";
        sql += "PRNUMBER = :sPRNumber, PRVALUE = :dPRValue, PONUMBER = :sPONumber, POVALUE = :dPOValue, COMMITMENT = :dCommitment, TEAMINDICATOR = :sTeamIndicator, ";
        sql += "COSTOBJECTDESC = :sCostObjectDesc, CAPEXOPEX = :iCapexOpex, PREVIOUS = :tPrevious, NAPPIMSNAIRA = :dNappimsNaira, NAPPIMSDOLLAR = :dNappimsDollar, ";
        sql += "NAPPIMSFUNCDOLLAR = :dNappimsFuncDollar, REQUESTNAIRA = :dRequestNaira, REQUESTDOLLAR = :dRequestDollar, REQUESTFUNCDOLLAR =:dRequestFuncDollar ";
        sql += "WHERE COMMITMENTID = :lCommitmentId";

        return sql;
    }

    public static string InsertCommitmentSnepco()
    {
        string sql = "INSERT INTO BONGA_COMMITMENTS (COMMITMENTID, IDOU, COMITMNTNO, TITLE, COSTOBJECT, GROUPID, IDDEPARTMENT, SPONSORID, ";
        sql += "CHECKEDBYID, FOCALPOINTID, USERID, TYPEID, STATUSID,  PERIODFROM, PERIODTO, JUSTIFICATION, THREAT, VEHICLEID, CONTRACTNOVENDOR, ";
        sql += "PRNUMBER, PRVALUE, PONUMBER, POVALUE, COMMITMENT, DATE_SUBMITTED) ";
        sql += "VALUES (:lCommitmentId, :iOuId, :sCommitmentNumber, :sTitle, :sCostObject, :iGroupId, :iTeamId, :iSponsorId, :iCheckedById, ";
        sql += ":iFocalPointId, :iInitiatorId, :iTypeId, :iStatusId, :tPeriodFrom, :tPeriodTo, :sJustification, :sThreat, :iVehicleId, ";
        sql += ":sContractNumberVendor, :sPRNumber, :dPRValue, :sPONumber, :dPOValue, :dCommitment, :tDateSubmitted)";
        return sql;
    }

    public static string UpdateCommitmentSnepco()
    {
        string sql = "UPDATE BONGA_COMMITMENTS SET IDOU = :iOuId, TITLE = :sTitle, COSTOBJECT = :sCostObject, GROUPID = :iGroupId, IDDEPARTMENT = :iTeamId, SPONSORID = :iSponsorId, ";
        sql += "FOCALPOINTID = :iFocalPointId, CHECKEDBYID = :iCheckedById, USERID = :iInitiatorId, TYPEID = :iTypeId, STATUSID = :iStatusId, ";
        sql += "PERIODFROM = :tPeriodFrom, PERIODTO = :tPeriodTo, JUSTIFICATION = :sJustification, THREAT = :sThreat, VEHICLEID = :iVehicleId, CONTRACTNOVENDOR = :sContractNumberVendor, ";
        sql += "PRNUMBER = :sPRNumber, PRVALUE = :dPRValue, PONUMBER = :sPONumber, POVALUE = :dPOValue, COMMITMENT = :dCommitment ";
        sql += "WHERE COMMITMENTID = :lCommitmentId";

        return sql;
    }

    public static string UpdateCommitment2()
    {
        string sql = "UPDATE BONGA_COMMITMENTS SET APPROVALID = :iApprovalId, APPROVERID = :iApproverId, APPROVALCOMMENT = :sApprovalComments, SAVINGS = :dSavings WHERE COMMITMENTID = :lCommitmentId";
        return sql;
    }

    public static string RepresentForReview()
    {
        string sql = "UPDATE BONGA_COMMITMENTS SET APPROVALID = :iApprovalId WHERE COMMITMENTID = :lCommitmentId";
        return sql;
    }

    #endregion

    #region ====================== Bonga Commitment Control Details Data =========================

    public static string getCommitmentMasterDetails()
    {
        string sql = "SELECT BONGA_COMMITMENTS.COMMITMENTID, BONGA_ACTIVITY_DETAILS.DETAILSID, BONGA_ACTIVITY_DETAILS.DESCRIPTION, BONGA_ACTIVITY_DETAILS.QUANTITY, BONGA_ACTIVITY_DETAILS.RATE ";
        sql += "FROM BONGA_COMMITMENTS INNER JOIN BONGA_ACTIVITY_DETAILS ON BONGA_COMMITMENTS.COMMITMENTID = BONGA_ACTIVITY_DETAILS.COMMITMENTID ";
        sql += "WHERE BONGA_COMMITMENTS.COMMITMENTID = :lCommitmentId";
        return sql;
    }

    public static string getCommitmentDetailsById()
    {
        string sql = "SELECT COMMITMENTID, DETAILSID, DESCRIPTION, QUANTITY, RATE FROM BONGA_ACTIVITY_DETAILS WHERE DETAILSID = :lDetailId";
        return sql;
    }

    public static string InsertCommitmentDetails()
    {
        string sql = "INSERT INTO BONGA_ACTIVITY_DETAILS (COMMITMENTID, DESCRIPTION, QUANTITY, RATE) VALUES (:lCommitmentId, :sDescription, :dQuantity, :dRate)";
        return sql;
    }

    public static string UpdateCommitmentDetails()
    {
        string sql = "UPDATE BONGA_ACTIVITY_DETAILS SET DESCRIPTION = :sDescription, QUANTITY = :dQuantity, RATE = :dRate WHERE DETAILSID = :iDetailsId";
        return sql;
    }

    public static string DeleteCommitmentDetails()
    {
        string sql = "DELETE FROM BONGA_ACTIVITY_DETAILS WHERE DETAILSID = :lDetailId";
        return sql;
    }

    #endregion

    #region ====================== Request Documents =============================================

    public static string InsertRequestDocuments()
    {
        string sql = "INSERT INTO BONGA_COMMITMENTDOCS (COMMITMENTID, DOCS, SFILENAME, SFILETYPE) VALUES (:lCommitmentId, :bBlobFile, :sFileName, :sFileType)";

        return sql;
    }

    public static string DeleteRequestDocuments()
    {
        string sql = "DELETE FROM BONGA_COMMITMENTDOCS WHERE DOCSID = :lDocId";
        return sql;
    }

    public static string getRequestDocumentsByRequestId()
    {
        string sql = "SELECT DOCSID, COMMITMENTID, DOCS, SFILENAME, SFILETYPE FROM BONGA_COMMITMENTDOCS WHERE COMMITMENTID = :lCommitmentId";

        return sql;
    }

    public static string getRequestDocumentByDocId()
    {
        string sql = "SELECT DOCSID, COMMITMENTID, DOCS, SFILENAME, SFILETYPE FROM BONGA_COMMITMENTDOCS WHERE DOCSID = :lDocId";

        return sql;
    }

    #endregion

    public static string getBongaAutoNumber()
    {
        string sql = "SELECT AUTO FROM BONGA_AUTO";
        return sql;
    }

    public static string UpdateBongaAuto()
    {
        string sql = "UPDATE BONGA_AUTO SET AUTO = :lCommitmentId";
        return sql;
    }

    #region ==================================== Users management ===========================

    public static string getFinanceDirectors()
    {
        string sql = "SELECT BONGA_FINANCEDIRECTOR.ID, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, ";
        sql += "PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, PROD_USERMGT.REFIND, COMMON_OU.IDOU, COMMON_OU.OU FROM BONGA_FINANCEDIRECTOR ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = BONGA_FINANCEDIRECTOR.USERID ";
        sql += "INNER JOIN COMMON_OU ON COMMON_OU.IDOU = BONGA_FINANCEDIRECTOR.IDOU ";

        return sql;
    }

    public static string addFinanceDirector()
    {
        string sql = "INSERT INTO BONGA_FINANCEDIRECTOR (USERID, IDOU) VALUES (:iUserId, :iOuId)";
        return sql;
    }

    public static string RemoveFinanceDirector()
    {
        string sql = "DELETE FROM BONGA_FINANCEDIRECTOR WHERE USERID = :iUserId";
        return sql;
    }

    #endregion
}
