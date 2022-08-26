using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for BI500ApprovalHelper
/// </summary>

public class BI500ApprovalHelper
{
    public BI500ApprovalHelper()
    {

    }

    public bool ActionBIRequest(long lRequestId, int iRoleId, int iUserId, int iStand, string sComments)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.ActionBIRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStand";
        param.Value = iStand;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDateReviewed";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }


    public static DataTable dtGetBIApprovalbyRequestId(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBIApprovalRequestId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetBIApprovalbyRequestRoleId(long lRequestId, int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBIApprovalRequestRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetBIApprovalbyApprovalId(long lApprovalId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBIApprovalByApprovalId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lApprovalId";
        param.Value = lApprovalId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public BI500Approval objGetBIApprovalbyRequestId(long lRequestId)
    {
        DataTable dt = dtGetBIApprovalbyRequestId(lRequestId);
        BI500Approval oRequest = new BI500Approval();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new BI500Approval(dr);
        }

        return oRequest;
    }

    public BI500Approval objGetBIApprovalbyRequestRoleId(long lRequestId, int iRoleId)
    {
        DataTable dt = dtGetBIApprovalbyRequestRoleId(lRequestId, iRoleId);
        BI500Approval oRequest = new BI500Approval();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new BI500Approval(dr);
        }

        return oRequest;
    }

    public BI500Approval objBIApprovalbyApprovalId(long lApprovalId)
    {
        DataTable dt = dtGetBIApprovalbyApprovalId(lApprovalId);
        BI500Approval oRequest = new BI500Approval();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new BI500Approval(dr);
        }

        return oRequest;
    }
    public List<BI500Approval> lstGetBIApprovalbyRequestId(long lRequestId)
    {
        DataTable dt = dtGetBIApprovalbyRequestId(lRequestId);

        List<BI500Approval> oFlareApproval = new List<BI500Approval>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oFlareApproval.Add(new BI500Approval(dr));
        }
        return oFlareApproval;
    }

    private static DataTable dtGetFlareApprovalbyRequestRoleId(long lRequestId, int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareApprovalFlareRequestRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public BI500Approval objGetFlareApprovalbyRequestRoleId(long lRequestId, int iRoleId)
    {
        DataTable dt = dtGetFlareApprovalbyRequestRoleId(lRequestId, iRoleId);
        BI500Approval oRequest = new BI500Approval();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new BI500Approval(dr);
        }

        return oRequest;
    }

    //public DataTable dtGetFlareWaiverByRequestNumber(string flareWaiverRequestNumber)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverByRequestNumber();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":sRequestNo";
    //    param.Value = flareWaiverRequestNumber.ToUpper().Trim();
    //    param.DbType = DbType.String;
    //    param.Size = 200;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public bool ReRouteRequest(long lRequestId, int iUserID, int iRoleId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureFlareWaiver.ReRouteRequest();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":lRequestId";
    //    param.Value = lRequestId;
    //    param.DbType = DbType.Int64;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":iUserId";
    //    param.Value = lRequestId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":iRoleId";
    //    param.Value = lRequestId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    int result = -1;

    //    try
    //    {
    //        // execute the stored procedure
    //        result = GenericDataAccess.ExecuteNonQuery(comm);
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show(ex.Message.ToString());
    //        // any errors are logged in GenericDataAccess, we ignore them here
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //    // result will be 1 in case of success
    //    return (result != -1);
    //}

    //public bool ActionFlareWaiverRequestAuditTrail(long lRequestId, int iStandId, string sComments)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureFlareWaiver.ActionFlareWaiverRequestAuditTrail();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":lRequestId";
    //    param.Value = lRequestId;
    //    param.DbType = DbType.Int64;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":iStandId";
    //    param.Value = iStandId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":sComments";
    //    param.Value = sComments;
    //    param.DbType = DbType.String;
    //    param.Size = 4000;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":sDateReviewed";
    //    param.Value = DateTime.Today.Date;
    //    param.DbType = DbType.Date;
    //    comm.Parameters.Add(param);

    //    int result = -1;

    //    try
    //    {
    //        // execute the stored procedure
    //        result = GenericDataAccess.ExecuteNonQuery(comm);
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show(ex.Message.ToString());
    //        // any errors are logged in GenericDataAccess, we ignore them here
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //    // result will be 1 in case of success
    //    return (result != -1);
    //}

}