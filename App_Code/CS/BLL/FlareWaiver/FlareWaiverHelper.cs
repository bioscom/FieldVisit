using System;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for eCTRMgt
/// </summary>
public class FlareWaiverRequestHelper
{
    public FlareWaiverRequestHelper()
	{
       
	}

    public bool RaiseFlareWaiverRequest(FlareWaiver oFlareWaiver, FileUpload UploadProposal, ref long lRequestId, ref string oMessage)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.RaiseFlareWaiverRequest();

        lRequestId = GetRequestID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCategoryId";
        param.Value = oFlareWaiver.m_iCategoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iFacilityId";
        //param.Value = oFlareWaiver.m_iFacilityId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oFlareWaiver.m_iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRequestNumber";
        param.Value = oFlareWaiver.m_sRequestNumber;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDateCreated";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.AwaitLineManagerSupport;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStartDate";
        param.Value = oFlareWaiver.m_sStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStartTime";
        param.Value = oFlareWaiver.m_sStartTime;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEndDate";
        param.Value = oFlareWaiver.m_sEndDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEndTime";
        param.Value = oFlareWaiver.m_sEndTime;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFlareVol";
        param.Value = oFlareWaiver.m_sFlareVol;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOilProduced";
        param.Value = oFlareWaiver.m_sOilProduced;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sReason";
        param.Value = oFlareWaiver.m_sReason;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sJustification";
        param.Value = oFlareWaiver.m_sJustification;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPostEvent";
        param.Value = oFlareWaiver.m_sPostEvent;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWorkOrder";
        param.Value = oFlareWaiver.m_sWorkOrder;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iInOutBP";
        param.Value = oFlareWaiver.m_iInOutBusinessPlan;
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

    public bool UpdateFlareWaiverRequest(FlareWaiver oFlareWaiver, FileUpload UploadProposal, long lRequestId, ref string oMessage)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateFlareWaiverRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCategoryId";
        param.Value = oFlareWaiver.m_iCategoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iFacilityId";
        //param.Value = oFlareWaiver.m_iFacilityId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStartDate";
        param.Value = oFlareWaiver.m_sStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStartTime";
        param.Value = oFlareWaiver.m_sStartTime;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEndDate";
        param.Value = oFlareWaiver.m_sEndDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEndTime";
        param.Value = oFlareWaiver.m_sEndTime;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFlareVol";
        param.Value = oFlareWaiver.m_sFlareVol;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOilProduced";
        param.Value = oFlareWaiver.m_sOilProduced;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sReason";
        param.Value = oFlareWaiver.m_sReason;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sJustification";
        param.Value = oFlareWaiver.m_sJustification;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPostEvent";
        param.Value = oFlareWaiver.m_sPostEvent;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWorkOrder";
        param.Value = oFlareWaiver.m_sWorkOrder;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iInOutBP";
        param.Value = oFlareWaiver.m_iInOutBusinessPlan;
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
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    private long GetRequestID()
    {
        long lRequestId = 0;
        try
        {
            DataTable dt = dtGetRequestId();
            lRequestId = long.Parse(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return lRequestId;
    }

    private static DataTable dtGetRequestId()
    {
        string sql = "SELECT FLARE_REQUEST_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareWaiverRequestsByArea(int iAreaId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestsByArea();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAreaId";
        param.Value = iAreaId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareWaiverRequestsByStatus(int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestsByStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus; 
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetFlareWaiverRequestsNotSupportedOrApproved()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getGetFlareWaiverRequestsNotSupportedOrApproved();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus1";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotApprovedByGMProduction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus2";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOffShore;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus3";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOnShore;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus4";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByLineManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus5";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByProductionServiceManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPendingFlareWaiverRequests(int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getPendingFlareWaiverRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus1";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotApprovedByGMProduction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus2";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOffShore;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus3";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOnShore;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus4";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByLineManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus5";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByProductionServiceManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareWaiverRequestById(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestByRequestId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareWaiverRequestByFacilityYearMonth(int iFacilityId, int iYear, int iMonth)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestByFacilityYearMonth();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public FlareWaiver objGetFlareWaiverRequestByFacilityYearMonth(int iFacilityId, int iYear, int iMonth)
    {
        DataTable dt = dtGetFlareWaiverRequestByFacilityYearMonth(iFacilityId, iYear, iMonth);
        FlareWaiver oRequest = new FlareWaiver();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new FlareWaiver(dr);
        }

        return oRequest;
    }

    public FlareWaiver objGetFlareWaiverRequestById(long lRequestId)
    {
        DataTable dt = dtGetFlareWaiverRequestById(lRequestId);
        FlareWaiver oRequest = new FlareWaiver();
        foreach (DataRow dr in dt.Rows)
        {
            oRequest = new FlareWaiver(dr);
        }

        return oRequest;
    }

    #region ################################# Getting Request By Status #########################################

    //For Initiators/Request Owners
    public DataTable dtGetMyFlareWaiverPendingRequests(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getMyFlareWaiverPendingRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMyFlareWaiverApprovedRequests(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getMyFlareWaiverApprovedRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMyFlareWaiverCancelledRequests(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getMyFlareWaiverCancelledRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.Cancelled;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMyFlareWaiverRejectedRequests(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getMyFlareWaiverNotApprovedRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotApproved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetMyFlareWaiverRequestsNotSupportedOrApproved(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getMyFlareWaiverRequestsNotSupportedOrApproved();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":iStatus1";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotApprovedByGMProduction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus2";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOffShore;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus3";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOnShore;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus4";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByLineManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus5";
        param.Value = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByProductionServiceManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    
    //For Approvers
    public DataTable dtGetRequestsFlareWaiverPendingMyApproval(appUsers oappUsers)
    {
        int iStand = (int)RequestStatusReporter.RequestStatusRpt.Supported;
        if (oappUsers.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval) iStand = (int)RequestStatusReporter.RequestStatusRpt.Approved;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestsPendingMyApproval();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oappUsers.m_iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStand";
        param.Value = iStand;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsFlareWaiverIApproved(appUsers oappUsers)
    {
        int iStand = (int)RequestStatusReporter.RequestStatusRpt.Supported;
        if (oappUsers.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval) iStand = (int)RequestStatusReporter.RequestStatusRpt.Approved;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestsIApproved();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oappUsers.m_iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStand";
        param.Value = iStand;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsFlareWaiverIDidNotApprove(appUsers oappUsers)
    {
        int iStand = (int)RequestStatusReporter.RequestStatusRpt.NotSupported;
        if (oappUsers.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval) iStand = (int)RequestStatusReporter.RequestStatusRpt.NotApproved;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestsIDidNotApprove();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oappUsers.m_iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStand";
        param.Value = iStand;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    #endregion
   
    public bool AssignRequestToNextApprover(long lRequestId, int iRoleId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.AssignRequestToNextApprover();

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
        param.ParameterName = ":sDateReceived";
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
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateAssignRequestToNextApprover(long lRequestId, int iRoleId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateAssignRequestToNextApprover();

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
        param.ParameterName = ":sDateReceived";
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
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateRequestStatus(long lRequestId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateRequestStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
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


    //New Update

    public bool UpdateRequestApprovedByGMProduction(long lRequestId, int iUserId, FlareWaiver oFlareWaiverRequest)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateRequestApprovedByGMProduction();

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
        param.ParameterName = ":dDateApproved";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        //calculate the difference between oFlareWaiver.m_sStartDate and oFlareWaiver.m_sEndDate and add to oApproverGMProduction.m_sDateReviewed
        TimeSpan iDifference = DateTime.Parse(oFlareWaiverRequest.m_sEndDate.ToString()) - DateTime.Parse(oFlareWaiverRequest.m_sStartDate.ToString());
        DateTime finalEndDate = DateTime.Today.Date.AddDays(iDifference.Days);

        param = comm.CreateParameter();
        param.ParameterName = ":dNewEndDate";
        param.Value = finalEndDate;
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

    //Facilities View
    public DataTable dtGetFacilitiesByRequestId(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilitiesByRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<Facility> lstGetFacilitiesByRequestId(long lRequestId)
    {
        DataTable dt = dtGetFacilitiesByRequestId(lRequestId);
        var o = new List<Facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new Facility(dr));
        }

        return o;
    }


    #region Energy Component Connection

    public bool dtEnergyComponentAvailable(int iYear)
    {
        OracleCommand comm = GenericDataAccess.ECCreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getECAvailable();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return (GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count > 0);
    }

    public DataTable dtGetFlareWaiverRequestEC(int iMonth, int iYear, string sFacilityCode)
    {
        OracleCommand comm = GenericDataAccess.ECCreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getDataFromEC();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sFacilityCode";
        param.Value = "%" + sFacilityCode + "%";
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<EnergyComponent> lstGetDailyFlaredGasFromEC(int iMonth, int iYear, string sFacilityCode)
    {
        DataTable dt = dtGetFlareWaiverRequestEC(iMonth, iYear, sFacilityCode);
        List<EnergyComponent> o = new List<EnergyComponent>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new EnergyComponent(dr));
        }

        return o;
    }

    public List<EnergyComponent> SamplelstGetDailyFlaredGasFromEC(int iMonth, int iYear, string sFacilityCode)
    {
        //DataTable dt = dtGetFlareWaiverRequestEC(iMonth, iYear, sFacilityCode);
        List<EnergyComponent> o = new List<EnergyComponent>();
        o.Add(new EnergyComponent { API = 1, Code = "PQR1", FacilityKey = "TTT1", ProductionDay = DateTime.Now.Date, SI = 20 });
        o.Add(new EnergyComponent { API = 2, Code = "PQR2", FacilityKey = "TTT2", ProductionDay = DateTime.Now.AddDays(1), SI = 21 });
        o.Add(new EnergyComponent { API = 3, Code = "PQR3", FacilityKey = "TTT3", ProductionDay = DateTime.Now.AddDays(2), SI = 22 });
        o.Add(new EnergyComponent { API = 4, Code = "PQR4", FacilityKey = "TTT4", ProductionDay = DateTime.Now.AddDays(3), SI = 23 });
        o.Add(new EnergyComponent { API = 5, Code = "PQR5", FacilityKey = "TTT5", ProductionDay = DateTime.Now.AddDays(4), SI = 24 });
        o.Add(new EnergyComponent { API = 6, Code = "PQR6", FacilityKey = "TTT6", ProductionDay = DateTime.Now.AddDays(5), SI = 25 });
        o.Add(new EnergyComponent { API = 7, Code = "PQR7", FacilityKey = "TTT7", ProductionDay = DateTime.Now.AddDays(6), SI = 26 });
        o.Add(new EnergyComponent { API = 8, Code = "PQR8", FacilityKey = "TTT8", ProductionDay = DateTime.Now.AddDays(7), SI = 27 });
        o.Add(new EnergyComponent { API = 9, Code = "PQR9", FacilityKey = "TTT9", ProductionDay = DateTime.Now.AddDays(8), SI = 28 });
        o.Add(new EnergyComponent { API = 10, Code = "PQR10", FacilityKey = "TTT10", ProductionDay = DateTime.Now.AddDays(9), SI = 29 });
        o.Add(new EnergyComponent { API = 11, Code = "PQR11", FacilityKey = "TTT11", ProductionDay = DateTime.Now.AddDays(10), SI = 30 });
        o.Add(new EnergyComponent { API = 12, Code = "PQR12", FacilityKey = "TTT12", ProductionDay = DateTime.Now.AddDays(11), SI = 31 });

        return o;
    }

    public DataTable dtGetDailyFlareWaiverRequestFromEC(int iDay, int iMonth, int iYear, string sFacilityCode)
    {
        OracleCommand comm = GenericDataAccess.ECCreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getDailyDataFromEC();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sFacilityCode";
        param.Value = "%" + sFacilityCode + "%";
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDay";
        param.Value = iDay;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDailyFlareWaiverRequestFromEC2(int iDay, int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.ECCreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getDailyDataFromEC2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDay";
        param.Value = iDay;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public EnergyComponent objGetDailyFlaredGasFromEC(int iDay, int iMonth, int iYear, string sFacilityCode)
    {
        DataTable dt = dtGetDailyFlareWaiverRequestFromEC(iDay, iMonth, iYear, sFacilityCode);
        EnergyComponent o = new EnergyComponent();
        foreach (DataRow dr in dt.Rows)
        {
            o = new EnergyComponent(dr);
        }

        return o;
    }

    public DataTable dtGetFlareWaiverRequestByFacilityCode(string sFacilityCode, int iMonth, int iYear) 
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareWaiverRequestByFacilityCode();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sFacilityCode";
        param.Value = "%" + sFacilityCode + "%";
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFromECFlareBeyond(int iYear, int iMonth)
    {
        OracleCommand comm = GenericDataAccess.ECCreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFromECFlareBeyond();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<EnergyComponent> lstGetFromECFlareBeyond(int iYear, int iMonth)
    {
        DataTable dt = dtGetFromECFlareBeyond(iYear, iMonth);
        List<EnergyComponent> o = new List<EnergyComponent>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new EnergyComponent(dr));
        }

        return o;
    }

    public DataTable dtGetGasFlareYTDByFacility(string sFacilityCode, int iYear)
    {
        OracleCommand comm = GenericDataAccess.ECCreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getGasFlareYTDByFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sFacilityCode";
        param.Value = "%" + sFacilityCode + "%";
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<EnergyComponent> lstGetGasFlareYTDByFacility(string sFacilityCode, int iYear)
    {
        DataTable dt = dtGetGasFlareYTDByFacility(sFacilityCode, iYear);
        List<EnergyComponent> o = new List<EnergyComponent>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new EnergyComponent(dr));
        }

        return o;
    }

    #endregion
} 