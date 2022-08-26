using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for siteVisitApprovalStatus
/// </summary>
public class siteVisitApprovalStatus
{
	public siteVisitApprovalStatus()
	{
		
	}

    public enum apprStatusRpt
    {
        NoComment = -1,
        Approved = 1,
        NotApproved = 2,
        Callme = 3,
        Reschedule = 4,
        ActivitySponsorApproval = 5,
        PlannerApprover = 6,
        SuperintendentApproval = 7,
        deleted = 0
    };

    public static string StatusRptDesc(apprStatusRpt apprStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (apprStatus)
            {
                case apprStatusRpt.Approved: sRet = "Approved"; break;
                case apprStatusRpt.NotApproved: sRet = "Not Approved"; break;
                case apprStatusRpt.Callme: sRet = "Call me"; break;
                case apprStatusRpt.Reschedule: sRet = "Reschedule"; break;
                case apprStatusRpt.ActivitySponsorApproval: sRet = "Awaiting Activity Sponsor's approval."; break;
                case apprStatusRpt.PlannerApprover: sRet = "Awaiting Activity Planner's approval."; break;
                case apprStatusRpt.SuperintendentApproval: sRet = "Awaiting Superintendent's approval."; break;
                case apprStatusRpt.NoComment: sRet = "Awaiting Comment/Approval"; break;
                case apprStatusRpt.deleted: sRet = "Request Deleted"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}

public class siteVisitApproval
{
    public int m_iApprovalID { get; set; }
    public int m_iActivityID { get; set; }
    public int m_iUserId { get; set; }
    public string m_sDateReceived { get; set; }
    public string m_sDateComment { get; set; }
    public string m_sComment { get; set; }
    public int m_iStand { get; set; }
    public int m_iRole { get; set; } 

    public siteVisitApproval()
	{
		
	}

    public siteVisitApproval(DataRow dr)
    {
        m_iApprovalID = int.Parse(dr["ID_APPROVAL"].ToString());
        m_iActivityID = int.Parse(dr["ID_ACTIVITIES"].ToString());

        if (string.IsNullOrEmpty(dr["USERID"].ToString())) { m_iUserId = 0; }
        else m_iUserId = int.Parse(dr["USERID"].ToString());
        
        m_sDateReceived = dr["DATE_RECEIVED"].ToString();
        m_sDateComment = dr["DATE_COMMENT"].ToString();
        m_sComment = dr["COMMENTS"].ToString();
        m_iStand = int.Parse(dr["STAND"].ToString());
        m_iRole = int.Parse(dr["ROLES"].ToString());
    }

    public static bool actionFieldVisitRequest(long iApproval, string sComment, int iStand, int UserId, int iRoleId)
    {
        string sql = StoredProcedure.actionFieldVisitRequest();
        
        if ((int)appUsersRoles.userRole.superintendent == iRoleId)
        {
            sql = StoredProcedure.superintendentActionFieldVisitRequest();
        }
       
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = iApproval;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = UserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":COMMENTS";
        param.Value = sComment;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_COMMENT";
        param.Value = DateTime.Now;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = iStand;
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

    public static bool updateFieldVisitRequestStatus(long iActivity, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateFieldVisitRequestStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivity;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
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

    //public static bool fieldVisitRequestApprovedBy(int iActivity, string superintendentId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.updateFieldVisitRequestApproval();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_ACTIVITIES";
    //    param.Value = iActivity;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":SUPERINTENDENT_USERID";
    //    param.Value = superintendentId;
    //    param.DbType = DbType.String;
    //    param.Size = 200;
    //    comm.Parameters.Add(param);

    //    int result = -1;
    //    try
    //    {
    //        result = GenericDataAccess.ExecuteNonQuery(comm);
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }

    //    return (result != -1);
    //}

    public static DataTable dtFieldVisitStatusByActivityId(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitApprovalStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":ROLES";
        //param.Value = (int) appUsersRoles.userRole.planner;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public static DataTable dtFieldVisitStatusActivityPlannerByActivityId(int iActivityId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.fieldVisitApprovalStatusActivityPlanner();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_ACTIVITIES";
    //    param.Value = iActivityId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    public static DataTable dtFieldVisitApproval(long iApprovalId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitApprovalByApprovalId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = iApprovalId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitApprovalByActivity(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitApprovalByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitApprovalByActivityApproval(int iApprovalId, int iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitApprovalByActivityIdApprovalId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = iApprovalId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtFieldVisitApprovalByActivityApprovalPlanner(int iApprovalId, long iActivityId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.fieldVisitApprovalByActivityIdApprovalIdPlanner();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = iApprovalId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtApprovedFieldVisitDetailsBySuperintendentApprover(long iActivityId, int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getApprovalDetailsBySuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITIES";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLES";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":STAND";
        //param.Value = (int)siteVisitApprovalStatus.apprStatusRpt.Approved;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static siteVisitApproval objGetApprovedFieldVisitDetailsBySuperintendentApprover(long iActivityId, int iRoleId)
    {
        DataTable dt = dtApprovedFieldVisitDetailsBySuperintendentApprover(iActivityId, iRoleId);

        siteVisitApproval details = new siteVisitApproval();
        foreach (DataRow dr in dt.Rows)
        {
            details = new siteVisitApproval(dr);
        }
        return details;
    }

    public static siteVisitApproval objGetFieldVisitApprovalByActivityApprovalPlanner(int iApprovalId, long iActivityId, int iUserId)
    {
        DataTable dt = dtFieldVisitApprovalByActivityApprovalPlanner(iApprovalId, iActivityId, iUserId);

        siteVisitApproval approvalDetails = new siteVisitApproval();
        foreach (DataRow dr in dt.Rows)
        {
            approvalDetails = new siteVisitApproval(dr);
        }
        return approvalDetails;
    }

    public static siteVisitApproval objGetFieldVisitApprovalByActivityApproval(int iApprovalId, int iActivityId)
    {
        DataTable dt = dtFieldVisitApprovalByActivityApproval(iApprovalId, iActivityId);

        siteVisitApproval approvalDetails = new siteVisitApproval();
        foreach (DataRow dr in dt.Rows)
        {
            approvalDetails = new siteVisitApproval(dr);
        }
        return approvalDetails;
    }

    public static siteVisitApproval objGetFieldVisitApprovalByApprovalId(long iApprovalId)
    {
        DataTable dt = dtFieldVisitApproval(iApprovalId);

        siteVisitApproval approvalDetails = new siteVisitApproval();
        foreach (DataRow dr in dt.Rows)
        {
            approvalDetails = new siteVisitApproval(dr);
        }
        return approvalDetails;
    }

    public static List<siteVisitApproval> lstGetSiteVisitApprovalByApprovalId(int iApprovalId)
    {
        DataTable dt = dtFieldVisitApproval(iApprovalId);

        List<siteVisitApproval> asset = new List<siteVisitApproval>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new siteVisitApproval(dr));
        }
        return asset;
    }

    public static List<siteVisitApproval> lstGetSiteVisitApprovalByActivityId(long iActivityId)
    {
        DataTable dt = dtFieldVisitApprovalByActivity(iActivityId);

        List<siteVisitApproval> asset = new List<siteVisitApproval>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new siteVisitApproval(dr));
        }
        return asset;
    }
}