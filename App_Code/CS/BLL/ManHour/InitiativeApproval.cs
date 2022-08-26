using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for InitiativeApproval
/// </summary>

public class InitiativeApproval
{
    public int m_iApprovalID { get; set; }
    public int m_iUserId { get; set; }
    public string m_sDateReceived { get; set; }
    public string m_sDateReviwed { get; set; }
    public string m_sComment { get; set; }
    public int m_iStand { get; set; }
    public int m_iRole { get; set; }
    public int m_iInitiativeId { get; set; }

    public InitiativeApproval()
    {
        //
        //
    }

    public InitiativeApproval(DataRow dr)
    {
        m_iApprovalID = int.Parse(dr["ID_APPROVAL"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_sDateReceived = dr["DATE_RECEIVED"].ToString();
        m_sDateReviwed = dr["DATE_REVIEWED"].ToString();
        m_iStand = int.Parse(dr["STAND"].ToString());
        m_sComment = dr["COMMENTS"].ToString();
        m_iRole = int.Parse(dr["ROLEID"].ToString());
        m_iInitiativeId = int.Parse(dr["IDINITIATIVE"].ToString()); 
    }

    public bool AssignInitiativeToApprover(long iInitiativeId, int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.assignInitiativeToApprover();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = iInitiativeId;
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

    public bool UpdateAssignedPECRequestToApprover(int iActivityInfoId, int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateAssignedInitiativeToApprover();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int32;
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

    public bool ActionInitiativeRequest(long lApprovalId, string sComment, int iStand)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.actionInitiativeRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = lApprovalId;
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

    public DataTable dtApproverByInitiative(long iInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = iInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtApproverByUserRoleInitiativeId(long lInitiativeId, int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByRoleInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtApproverByInitiativeUserId(long iInitiativeId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByInitiativeIdUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = iInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtBIApproverByApprovalId(long lApprovalId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getBIApprovalByApprovalId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_APPROVAL";
        param.Value = lApprovalId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public InitiativeApproval objGetBIApproverByApprovalId(long lApprovalId)
    {
        DataTable dt = dtBIApproverByApprovalId(lApprovalId);

        InitiativeApproval xRows = new InitiativeApproval();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new InitiativeApproval(dr);
        }
        return xRows;
    }

    public InitiativeApproval objGetApproverByApprovalIdUserId(long lApprovalId, int iUserId)
    {
        DataTable dt = dtApproverByInitiativeUserId(lApprovalId, iUserId);

        InitiativeApproval xRows = new InitiativeApproval();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new InitiativeApproval(dr);
        }
        return xRows;
    }

    public bool bApproverReviewerFound(long lApprovalId, int iUserId)
    {
        bool bFound = false;
        if (dtApproverByInitiativeUserId(lApprovalId, iUserId).Rows.Count > 0)
        {
            bFound = true;
        }

        return bFound;
    }

    public List<InitiativeApproval> lstGetApproversByInitiativeId(long iInitiativeId)
    {
        DataTable dt = dtApproverByInitiative(iInitiativeId);

        List<InitiativeApproval> approvers = new List<InitiativeApproval>(dt.Rows.Count);
        approvers.AddRange(from DataRow dr in dt.Rows select new InitiativeApproval(dr));
        return approvers;
    }
    public List<InitiativeApproval> lstGetApproversByRoleInitiativeId(long iInitiativeId, int iRoleId)
    {
        DataTable dt = dtApproverByUserRoleInitiativeId(iInitiativeId, iRoleId);

        List<InitiativeApproval> approvers = new List<InitiativeApproval>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            approvers.Add(new InitiativeApproval(dr));
        }
        return approvers;
    }
    public bool UpdateInitiativeStatus(long iActivityID, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.updateInitiativeStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
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

    //public static DataTable dtInitiativePendingApproval()
    //{
        //OracleCommand comm = GenericDataAccess.CreateCommand();
        //comm.CommandText = StoredProcedure.PECRequestPendingApproval();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":STATUS";
        //param.Value = (int)Approval.apprStatusRpt.Approved;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtPECRequestPendingApproval(int iStand, int iActivityStatus, int iUserId)
    //{
        //OracleCommand comm = GenericDataAccess.CreateCommand();
        //comm.CommandText = StoredProcedure.PECPendingApproval();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":STAND";
        //param.Value = iStand;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":STATUS";
        //param.Value = iActivityStatus;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":USERID";
        //param.Value = iUserId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtInitiativeApproved()
    //{
        //OracleCommand comm = GenericDataAccess.CreateCommand();
        //comm.CommandText = StoredProcedure.ApprovedPECRequests();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":STATUS";
        //param.Value = (int)Approval.apprStatusRpt.Approved;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtPECRequestApproved(int iStand, int iUserId, int iRoleid)
    //{
    //    //OracleCommand comm = GenericDataAccess.CreateCommand();
        //comm.CommandText = StoredProcedure.PECApproved();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":STAND";
        //param.Value = iStand;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":ROLEID";
        //param.Value = iRoleid;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":USERID";
        //param.Value = iUserId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetPECApprovalByApprover(int iApprovalId, long iActivityId, int iUserId)
    //{
        //OracleCommand comm = GenericDataAccess.CreateCommand();
        //comm.CommandText = StoredProcedure.getPECApprovalByApprover();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":IDINITIATIVE";
        //param.Value = iActivityId;
        //param.DbType = DbType.Int64;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":ID_APPROVAL";
        //param.Value = iApprovalId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":USERID";
        //param.Value = iUserId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static InitiativeApproval objGetPECApprovalByApprover(int iApprovalId, long iActivityId, int iUserId)
    //{
    //    DataTable dt = dtGetPECApprovalByApprover(iApprovalId, iActivityId, iUserId);

    //    InitiativeApproval approvalDetails = new InitiativeApproval();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        approvalDetails = new InitiativeApproval(dr);
    //    }
    //    return approvalDetails;
    //}
}