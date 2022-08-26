using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for siteVisit
/// </summary>

public class fieldVisit
{
    public fieldVisit()
    {
        
    }

    public static bool newFieldVisit(long iActivity, int iFacility, string sTaskDescription, int iInitiatorUserId, string sActivityId, DateTime dDateFrom,
        DateTime dDateTo, string sAccountToCharge, string sGeneralComment, int iNoOfPersonnel, int iNoOfNights)      
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.CreateNewSiteVisit();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivity;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacility;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TASK_DESCRIPTION";
        param.Value = sTaskDescription;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iInitiatorUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.PlannerApprover;
        //param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITYID";
        param.Value = sActivityId;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_FROM";
        param.Value = dDateFrom;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_TO";
        param.Value = dDateTo;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":GENERAL_COMMENT";
        param.Value = sGeneralComment;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NO_OF_PERSONNEL";
        param.Value = iNoOfPersonnel;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NO_OF_NIGHTS";
        param.Value = iNoOfNights;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACCOUNT";
        param.Value = sAccountToCharge;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);
        
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return (result != -1);
    }

    public static bool newFieldVisitCheckList(long iActivity, int iQuestionId, int iCheckList)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.CreateNewSiteVisitCheckList();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivity;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_QUESTION";
        param.Value = iQuestionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":CHECKLIST";
        param.Value = iCheckList;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return (result != -1);
    }

    public static bool updateFieldVisitCheckList(long iActivity, int iQuestionId, int iCheckList)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.UpdateSiteVisitCheckList();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivity;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_QUESTION";
        param.Value = iQuestionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":CHECKLIST";
        param.Value = iCheckList;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return (result != -1);
    }

    public static bool updateFieldVisit(long iActivity, int iFacility, string sTaskDescription, int iInitiatorUserId, DateTime dDateFrom,  
        DateTime dDateTo, string sAccountToCharge, string sGeneralComment, int iNoOfPersonnel, int iNoOfNights)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.UpdateSiteVisit();

     
        //string sql = "UPDATE PROD_ACTIVITIES SET ID_FACILITIES = :ID_FACILITIES, TASK_DESCRIPTION = :TASK_DESCRIPTION, USERID = :USERID, ";
        //sql += "DATE_FROM = :DATE_FROM, DATE_TO = :DATE_TO, ACCOUNT = :ACCOUNT, GENERAL_COMMENT = :GENERAL_COMMENT, NO_OF_PERSONNEL = :NO_OF_PERSONNEL, ";
        //sql += "NO_OF_NIGHTS = :NO_OF_NIGHTS WHERE ID_ACTIVITIES = :ID_ACTIVITIES";

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivity;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacility;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iInitiatorUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TASK_DESCRIPTION";
        param.Value = sTaskDescription;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_FROM";
        param.Value = dDateFrom;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_TO";
        param.Value = dDateTo;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACCOUNT";
        param.Value = sAccountToCharge;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":GENERAL_COMMENT";
        param.Value = sGeneralComment;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NO_OF_NIGHTS";
        param.Value = iNoOfNights;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NO_OF_PERSONNEL";
        param.Value = iNoOfPersonnel;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return (result != -1);
    }

    public static long getActivityID()
    {
        string sql = "SELECT PROD_ACTIVITIES_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        long activityID = 0;
        try
        {
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
            activityID = Convert.ToInt32(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return activityID;
    }

    public static DataTable dtMyPendingFieldVisitRequests(string UserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.PendingFieldVisitDetailsByInitiator();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static string GenerateActivityID()
    {
        string YY = DateTime.Now.Year.ToString().Remove(0, 2);  // xx = year of origin
        string xxxx; //Activity ID sequencial numbering

        string sql = "SELECT PROD_AUTONUMBER_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
        string xy = dt.Rows[0]["NEXTVAL"].ToString();

        if (xy.Length == 1) { xxxx = "000" + xy; }
        else if (xy.Length == 2) { xxxx = "00" + xy; }
        else if (xy.Length == 3) { xxxx = "0" + xy; }
        else { xxxx = xy; }

        return "SEPCIN" + YY + xxxx;
    }

    public static bool UpdateFieldVisitRequestPreStatus(long lActivityId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.UpdateFieldVisitRequestPreStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lActivityId";
        param.Value = lActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return (result != -1);
    }

    public static bool DeleteFieldVisitRequest(long lActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.DeleteFieldVisitRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lActivityId";
        param.Value = lActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return (result != -1);
    }
}

public class fieldVisitDetails
{
    public long m_iActivityID { get; set; }
    public int m_iFacilityId { get; set; }
    public string m_sTaskDescription { get; set; }
    public int m_iInitiatorUserId { get; set; }
    public int m_iStatus { get; set; }
    public string m_sActivityId { get; set; }
    public string m_sDateFrom { get; set; }
    public string m_sDateTo { get; set; }
    public string m_sGeneralComment { get; set; }
    public string m_sNoOfPersonnels { get; set; }
    public string m_sNoOfNights { get; set; }
    public string m_sAccountToCharge { get; set; }

    public facility eFacility
    {
        get
        {
            return facility.objGetFacilityById(m_iFacilityId);
        }
    }
    public appUsers eInitiator
    {
        get
        {
            return appUsersHelper.objGetUserByUserId(m_iInitiatorUserId);
        }
    }

    public List<siteVisitApproval> lstApprovalDetails
    {
        get
        {
            return siteVisitApproval.lstGetSiteVisitApprovalByActivityId(m_iActivityID);
        }
    }

    public fieldVisitDetails()
    {
        
    }

    public fieldVisitDetails(DataRow dr)
    {        
        m_iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
        m_sAccountToCharge = dr["ACCOUNT"].ToString();
        m_iActivityID = int.Parse(dr["ID_ACTIVITIES"].ToString());
        m_sTaskDescription = dr["TASK_DESCRIPTION"].ToString();
        m_iInitiatorUserId = int.Parse(dr["USERID"].ToString());
        m_iStatus = int.Parse(dr["STATUS"].ToString());
        m_sActivityId = dr["ACTIVITYID"].ToString();
        m_sDateFrom = dr["DATE_FROM"].ToString();
        m_sDateTo = dr["DATE_TO"].ToString();
        m_sGeneralComment = dr["GENERAL_COMMENT"].ToString();
        m_sNoOfPersonnels = dr["NO_OF_PERSONNEL"].ToString();
        m_sNoOfNights = dr["NO_OF_NIGHTS"].ToString();        
    }

    public static DataTable dtFieldVisitDetails()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitDetails();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitDetailsByActivity(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitDetailsByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitDetailsReportByActivity(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitDetailsReportByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitDetailsQuestionaireByActivity(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitDetailsQuestionaireByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // 1. Initiator Pending/Approved
    public static DataTable dtPendingFieldVisitDetailsByInitiator(int iInitiatorUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.PendingFieldVisitDetailsByInitiator();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iInitiatorUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtApprovedFieldVisitDetailsByInitiator(int iInitiatorUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.ApprovedFieldVisitDetailsByInitiator();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iInitiatorUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitDetailsByRequestNumber(string sRequestNumber)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.FieldVisitDetailsByRequestNumber();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sRequestNumber";
        param.Value = sRequestNumber.ToUpper();
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // 2. Sponsor, Facilities Planner Pending/ Approved
    public static DataTable dtPendingFieldVisitByApprover(int iUserId, int? iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.PendingFieldVisitDetailsByApprover();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.NoComment; //When no comment is made, the request lies in the intray
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtRejectedFieldVisiRequestsByApprover(int iUserId, Nullable<int> iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.RejectedFieldVisiRequestsByApprover();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":noCmtSTAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.NoComment; //When no comment is made, the request lies in the intray
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":apprdSTAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtApprovedFieldVisitByApprover(int iUserId, Nullable<int> iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.ApprovedFieldVisitDetailsByApprover();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // 3. Superintendent Pending/Approved
    public static DataTable dtPendingFieldVisitBySuperintendent(int iSuperintendentId, Nullable<int> iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.PendingFieldVisitDetailsBySuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLES";
        param.Value = iRoleId;  
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtApprovedFieldVisitBySuperintendent(int iSuperintendentId, Nullable<int> iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.ApprovedFieldVisitDetailsBySuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLES";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static fieldVisitDetails objGetFieldVisitDetailsByActivityId(long activityId)
    {
        DataTable dt = dtFieldVisitDetailsByActivity(activityId);

        fieldVisitDetails details = new fieldVisitDetails();
        foreach (DataRow dr in dt.Rows)
        {
            details = new fieldVisitDetails(dr);
        }
        return details;
    }

    public static fieldVisitDetailsQuestinaire objGetFieldVisitQuestionaireDetailsByActivityId(int activityId)
    {
        DataTable dt = dtFieldVisitDetailsQuestionaireByActivity(activityId);

        fieldVisitDetailsQuestinaire details = new fieldVisitDetailsQuestinaire();
        foreach (DataRow dr in dt.Rows)
        {
            details = new fieldVisitDetailsQuestinaire(dr);
        }
        return details;
    }

    public static List<fieldVisitDetailsQuestinaire> lstGetFieldVisitQuestionaireDetailsByActivityId(long activityId)
    {
        DataTable dt = dtFieldVisitDetailsQuestionaireByActivity(activityId);

        List<fieldVisitDetailsQuestinaire> details = new List<fieldVisitDetailsQuestinaire>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            details.Add(new fieldVisitDetailsQuestinaire(dr));
        }
        return details;
    }

    public static DataTable dtFieldVisitRequestsPendingApproval()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitRequestsPendingApproval();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitRequestsApproved()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitRequestsApproved();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable dtFieldVisitRequestsNotApproved()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitRequestRejected();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.NotApproved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitRequestsRescheduled()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitRequestRejected();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Reschedule;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public static DataTable dtFieldVisitRequestsRescheduled()
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.fieldVisitRequestsApproved();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":STATUS";
    //    param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Reschedule;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    public static DataTable dtFieldVisitRequestsApprovedByFacility(int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitRequestsApprovedByFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitRequestsNotApprovedByFacility(int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitRequestRejectedByFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.NotApproved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static DataTable dtFieldVisitRequestsRescheduledByFacility(int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitRequestRejectedByFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Reschedule;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":delSTATUS";
        param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}


public class fieldVisitDetailsQuestinaire
{
    public int m_iID { get; set; }
    public int m_iID_ACTIVITIES { get; set; }
    public int m_iID_QUESTION { get; set; }
    public int m_iCHECKLIST { get; set; }

    public fieldVisitDetailsQuestinaire()
    {

    }

    public fieldVisitDetailsQuestinaire(DataRow dr)
    {
        m_iID = int.Parse(dr["ID"].ToString());
        m_iID_ACTIVITIES = int.Parse(dr["ID_ACTIVITIES"].ToString());
        m_iID_QUESTION = int.Parse(dr["ID_QUESTION"].ToString());
        m_iCHECKLIST = int.Parse(dr["CHECKLIST"].ToString());
    }
}