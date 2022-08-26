using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Linq;

/// <summary>
/// Summary description for FlareApprovalHelper
/// </summary>

public class FlareApprovalHelper
{
	public FlareApprovalHelper()
	{
		
	}
    public bool ActionFlareWaiverRequest(long lRequestId, int iUserId, int iStand, string sComments)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.ActionFlareWaiverRequest();

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

    public bool ActionFlareWaiverRequestAuditTrail(long lRequestId, int iStandId, string sComments)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.ActionFlareWaiverRequestAuditTrail();
        //string sql = "INSERT INTO FLARE_APPROVAL_AUDIT (STAND, COMMENTS, DATE_REVIEWED, IDREQUEST) VALUES (:iStandId, :sComments, :sDateReviewed, :lRequestId)";

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStandId";
        param.Value = iStandId;
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

    public static DataTable dtGetAuditTrails()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getAuditTrails();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFlareApprovalbyRequestId(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareApprovalFlareRequestId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFlareRequests()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverByRequest();

        return GenericDataAccess.ExecuteSelectCommand(comm);
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

    public FlareApproval objGetFlareApprovalbyRequestRoleId(long lRequestId, int iRoleId)
    {
        DataTable dt = dtGetFlareApprovalbyRequestRoleId(lRequestId, iRoleId);
        FlareApproval oRequest = new FlareApproval();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new FlareApproval(dr);
        }                   
        
        return oRequest;
    }

    public FlareApproval objGetFlareApprovalbyRequestId(long lRequestId)
    {
        DataTable dt = dtGetFlareApprovalbyRequestId(lRequestId);
        FlareApproval oRequest = new FlareApproval();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new FlareApproval(dr);
        }

        return oRequest;
    }

    public DataTable dtGetFlareWaiverByRequestNumber(string flareWaiverRequestNumber)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverByRequestNumber();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sRequestNo";
        param.Value = flareWaiverRequestNumber.ToUpper().Trim();
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<FlareApproval> lstGetFlareApprovalbyRequestId(long lRequestId)
    {
        DataTable dt = dtGetFlareApprovalbyRequestId(lRequestId);

        List<FlareApproval> oFlareApproval = new List<FlareApproval>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oFlareApproval.Add(new FlareApproval(dr));
        }
        return oFlareApproval;
    }

    public bool ReRouteRequest(long lRequestId, int iUserId, int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.ReRouteRequest();

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
}