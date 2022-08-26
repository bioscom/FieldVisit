using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Approval
/// </summary>

public class PECApprover
{
    public int m_iApprovalID { get; set; }
    //public string m_sActivityID { get; set; }
    public int m_iUserId { get; set; }
    public string m_sDateReceived { get; set; }
    public string m_sDateReviwed { get; set; }
    public string m_sComment { get; set; }
    public int m_iStand { get; set; }
    public int m_iRole { get; set; }
    public int m_iID_ACTIVITYINFO { get; set; }

    public PECApprover()
    {
        //
        //
    }

    public PECApprover(DataRow dr)
    {
        m_iApprovalID = int.Parse(dr["ID_APPROVAL"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_sDateReceived = dr["DATE_RECEIVED"].ToString();
        m_sDateReviwed = dr["DATE_REVIEWED"].ToString();
        m_iStand = int.Parse(dr["STAND"].ToString());
        m_sComment = dr["COMMENTS"].ToString();
        m_iRole = int.Parse(dr["ROLEID"].ToString());
        m_iID_ACTIVITYINFO = int.Parse(dr["ID_ACTIVITYINFO"].ToString()); 
    }

    public static bool AssignPECRequestToApprover(long iActivityInfoId, int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.assignPECRequestToApprover();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_RECEIVED";
        param.Value = DateTime.Now;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
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

    public static bool UpdateAssignedPECRequestToApprover(long iActivityInfoId, int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.UpdateAssignedPECRequestToApprover();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
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

    public static bool ActionPECRequest(long lApproval, string sComment, int iStand)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.actionPECRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = lApproval;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":COMMENTS";
        param.Value = sComment;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_REVIEWED";
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

    public static bool UpdatePECRequestStatus(long iActivityID, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updatePECRequestStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityID;
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

    public static DataTable dtPECApproverByActivity(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.pecApprovalByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtPECApproverByApprovalId(long iApprovalId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getPecApprovalByApprovalId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = iApprovalId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static PECApprover objGetPECApproverByApprovalId(long iApprovalId)
    {
        DataTable dt = dtPECApproverByApprovalId(iApprovalId);

        PECApprover xRows = new PECApprover();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new PECApprover(dr);
        }
        return xRows;
    }

    public static List<PECApprover> lstGetPECApproversByActivityId(long iActivityId)
    {
        DataTable dt = dtPECApproverByActivity(iActivityId);

        List<PECApprover> approvers = new List<PECApprover>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            approvers.Add(new PECApprover(dr));
        }
        return approvers;
    }




    //public static DataTable dtFieldVisitApproval(int iApprovalId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.fieldVisitApprovalByApprovalId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_APPROVAL";
    //    param.Value = iApprovalId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static siteVisitApproval objGetFieldVisitApprovalByApprovalId(int iApprovalId)
    //{
    //    DataTable dt = dtFieldVisitApproval(iApprovalId);

    //    siteVisitApproval approvalDetails = new siteVisitApproval();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        approvalDetails = new siteVisitApproval(dr);
    //    }
    //    return approvalDetails;
    //}

    //public static List<siteVisitApproval> lstGetSiteVisitApprovalByApprovalId(int iApprovalId)
    //{
    //    DataTable dt = dtFieldVisitApproval(iApprovalId);

    //    List<siteVisitApproval> asset = new List<siteVisitApproval>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset.Add(new siteVisitApproval(dr));
    //    }
    //    return asset;
    //}



    //public static DataTable dtFieldVisitApprovalByActivityApproval(int iApprovalId, int iActivityId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.fieldVisitApprovalByActivityIdApprovalId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_ACTIVITIES";
    //    param.Value = iActivityId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":ID_APPROVAL";
    //    param.Value = iApprovalId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static siteVisitApproval objGetFieldVisitApprovalByActivityApproval(int iApprovalId, int iActivityId)
    //{
    //    DataTable dt = dtFieldVisitApprovalByActivityApproval(iApprovalId, iActivityId);

    //    siteVisitApproval approvalDetails = new siteVisitApproval();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        approvalDetails = new siteVisitApproval(dr);
    //    }
    //    return approvalDetails;
    //}

    public static DataTable dtPECRequestPendingApproval()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.PECRequestPendingApproval();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtPECRequestPendingMyApproval(int iStatus, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.PECPendingApproval();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)Approval.apprStatusRpt.NoComment;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtPECRequestApproved()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.ApprovedPECRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtPECRequestByRequestNumber(string sRequestNumber)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.ApprovedPECRequestByRequestNumber();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sRequestNumber";
        param.Value = sRequestNumber;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtPECRequestApproved(int iStand, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.PECApproved();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = iStand;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable dtGetPECApprovalByApprover(int iApprovalId, long iActivityId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getPECApprovalByApprover();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
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

    public static PECApprover objGetPECApprovalByApprover(int iApprovalId, long iActivityId, int iUserId)
    {
        DataTable dt = dtGetPECApprovalByApprover(iApprovalId, iActivityId, iUserId);

        PECApprover approvalDetails = new PECApprover();
        foreach (DataRow dr in dt.Rows)
        {
            approvalDetails = new PECApprover(dr);
        }
        return approvalDetails;
    }
}
