using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;
using System.Web;

/// <summary>
/// Summary description for BI500RequestHelper
/// </summary>

public class BI500RequestHelper
{
    public BI500RequestHelper()
    {
        //
        // 
        //
    }

    public void LoadYear(DropDownList ddlYear)
    {
        var oYears = lstGetDistinctYear();
        ddlYear.Items.Clear();
        ddlYear.Items.Add(new ListItem("--Select Year--", "1"));
        foreach (var i in oYears)
        {
            ddlYear.Items.Add(i.ToString());
        }
    }

    private static DataTable dtGetRequestId()
    {
        string sql = "SELECT BI500_REQUEST_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPendingRequests()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getPendingRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetApprovedRequests()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getApprovedOrRejectedRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFocalPointPendingRequests(int iFocalPoint)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getFocalPointPendingRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPoint";
        param.Value = iFocalPoint;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFocalPointApprovedOrRejectedRequests(int iFocalPoint, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getFocalPointApprovedOrRejectedRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus; //(int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPoint";
        param.Value = iFocalPoint;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetBITeamApprovedOrRejectedRequests(int iCorprateViewer, int iStand)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBITeamApprovedOrRejectedRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStand";
        param.Value = iStand;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = (int)appUsersRoles.userRole.CorporateViewer;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByStatus(int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getRequestsByStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //Initiator's pending bright ideas
    public DataTable dtGetMyPendingRequests(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getMyPendingRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMyApprovedRequests(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getMyApprovedOrRejectedRequests();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //Loads Bright Ideas Pending anybody's approval or support
    public DataTable dtGetRequestsPendingMyApprovalSupport(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getRequestsPendingMyApprovalSupport();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.iDefault;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsPendingMyApprovalSupportByYear(int iUserId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getRequestsPendingMyApprovalSupport();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.iDefault;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iYear";
        //param.Value = iYear;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //Loads Bright Ideas Pending BI Team support
    public DataTable dtGetRequestsPendingBITeamSupport()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getRequestsPendingBITeamSupport();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.iDefault;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus2";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //(int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementApproval

        //param = comm.CreateParameter();
        //param.ParameterName = ":iRoleId";
        //param.Value = (int)appUsersRoles.userRole.BusinessImprovementTeam;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetBITeamSupportedBrightIdeas()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeasSupportedByBITeam();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Supported;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = (int)appUsersRoles.userRole.BusinessImprovementTeam;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetBITeamRejectedBrightIdeas()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeasRejectedByBITeam();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.NotSupported;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = (int)appUsersRoles.userRole.BusinessImprovementTeam;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //Loads Bright Ideas Pending Lean Team Focal Point support
    public DataTable dtGetBrightIdeaPendingLeanFocalPointSupport(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getPendingBrightIdeasForLeanFocalPoint();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Supported;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetBrightIdeaApprovedForLeanFocalPoint(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getApprovedBrightIdeasForLeanFocalPoint();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPendingBrightIdeas()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getPendingBrightIdeaRegister();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetCorporatePendingBrightIdeas(int iFunction)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getCorporatePendingBrightIdeaRegister();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunction";
        param.Value = iFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPendingBrightIdeasByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getPendingBrightIdeaRegisterByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetCorporatePendingBrightIdeasByYear(int iYear, int iFunction)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getCorporatePendingBrightIdeaRegisterByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunction";
        param.Value = iFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDistinctYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getDistinctYear();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetApprovedBrightIdeas()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getApprovedBrightIdeaRegister();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsIApprovedSupportedOrRejected(int iUserId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getRequestsIApprovedSupportedOrRejected();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestById(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getRequestById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static long getInitiativeId()
    {
        string sql = "SELECT MANHR_INITIATIVE_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        long lInitiativeId = 0;
        try
        {
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
            lInitiativeId = Convert.ToInt64(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return lInitiativeId;
    }

    public bool CreateBI500Request(CostReductionRequest o, ref long lRequestId)
    {
        lRequestId = GetRequestID();

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.CreateBIRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRequestNumber";
        param.Value = o.sRequestNumber;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = o.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iChampion";
        param.Value = o.iProjectChampionUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = o.iProjectSponsorUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iFocalPoint";
        //param.Value = o.iFocalPointUserId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = o.iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = o.iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = o.sTitle;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBuzCase";
        param.Value = o.sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunityStmt";
        param.Value = o.sOpportunityStmt;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iImpactedArea";
        param.Value = o.iBenefitId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_COMPLETION";
        param.Value = o.dCompletionDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_SUBMITTED";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.iDefault;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool UpdateBI500Request(CostReductionRequest oBI500Request)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateBIRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = oBI500Request.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oBI500Request.iUserId; 
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iChampion";
        param.Value = oBI500Request.iProjectChampionUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = oBI500Request.iProjectSponsorUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iFocalPoint";
        //param.Value = oBI500Request.iFocalPointUserId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = oBI500Request.sTitle;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBuzCase";
        param.Value = oBI500Request.sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunityStmt";
        param.Value = oBI500Request.sOpportunityStmt;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iImpactedArea";
        param.Value = oBI500Request.iBenefitId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_COMPLETION";
        param.Value = oBI500Request.dCompletionDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DATE_SUBMITTED";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dAmountSaved";
        //param.Value = oBI500Request.dAmountSaved;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool AssignInitiativeLeadChampionSponsor(long lRequestId, int iSponsor, int iChampion, int iInitiativeLead)
    {
        //Focal Point assigns Initiative Lead, Work Stream Owner and Work Stream Sponsor. This moves the project to L3

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AssignInitiativeLeadChampionSponsor();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iInitiativeLead";
        param.Value = iInitiativeLead;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iChampion";
        param.Value = iChampion;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = iSponsor;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool AssignProjectSponsor(long lRequestId, int iSponsor)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AssignProjectSponsor();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = iSponsor;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool AssignFocalPoint(long lRequestId, int iFocalPoint)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AssignFocalPoint();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPoint";
        param.Value = iFocalPoint;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool AssignRequestToNextApprover(long lRequestId, int iRoleId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AssignRequestToNextApprover();

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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool AssignRequestToNextApprover(long lRequestId, int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AssignRequestToBITeam();

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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool RouteRequestWithinApprovers(long lRequestId, int iRoleId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.RouteRequestWithinApprovers();

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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public List<int> lstGetDistinctYear()
    {
        DataTable dt = dtGetDistinctYear();

        List<int> o = new List<int>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(int.Parse(dr["YYEAR"].ToString()));
        }

        return o;
    }
    
    public CostReductionRequest objGetBrightIdeaById(long lRequestId)
    {
        DataTable dt = dtGetRequestById(lRequestId);
        CostReductionRequest oBI500Request = new CostReductionRequest();
        foreach (DataRow dr in dt.Rows)
        {
            oBI500Request = new CostReductionRequest(dr);
        }
        return oBI500Request;
    }

    public bool UpdateRequestStatus(long lRequestId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateRequestStatus();

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

    public bool UpdateStageGate(long lRequestId, int iValue)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateStageGate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iValue";
        param.Value = iValue;
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

    public bool MaintainInDatabase(long lRequestId, string sReasonRetained)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.MaintainInDatabase();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.MaintainInDatabase;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sReasonRetained";
        param.Value = sReasonRetained;
        param.DbType = DbType.String;
        param.Size = 2000;
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


    public bool UpdateRequestPhase(long lRequestId, int iPhase, string sMembers)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateRequestPhase();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPhase";
        param.Value = iPhase;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMembers";
        param.Value = sMembers;
        param.DbType = DbType.String;
        param.Size = 2000;
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

    public bool UpdateRequestSustainPhase(long lRequestId, int iPhase, int iImprovement, int iRepPotential, string sQtyBenefit, DateTime ActualFinishDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateRequestSustainPhase();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPhase";
        param.Value = iPhase;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iImprovement";
        param.Value = iImprovement;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iQtyBenefit";
        param.Value = sQtyBenefit;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRepPotential";
        param.Value = iRepPotential;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ActualFinishDate";
        param.Value = ActualFinishDate;
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



    #region Cost Reduction Objects
    public bool CreateCostReductionIdea(CostReductionRequest o, ref long lRequestId)
    {
        lRequestId = GetRequestID();

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.CreateCostReductionIdea();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRequestNumber";
        param.Value = o.sRequestNumber;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = o.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = o.iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = o.iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //NOTE: This is the Impacted team. ie. the team to carry out the task. That is not the same as in bright Idea.
        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = o.sTitle;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBuzCase";
        param.Value = o.sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunityStmt";
        param.Value = o.sOpportunityStmt;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iImpactedArea";
        param.Value = o.iBenefitId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_SUBMITTED";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.iDefault;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActualSavings";
        param.Value = o.dActualSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dTargetSavings";
        param.Value = o.dTargetSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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
    public bool UpdateCostReductionIdea(CostReductionRequest o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateCostReductionIdea();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = o.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = o.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = o.iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = o.iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = o.sTitle;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBuzCase";
        param.Value = o.sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunityStmt";
        param.Value = o.sOpportunityStmt;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iImpactedArea";
        param.Value = o.iBenefitId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActualSavings";
        param.Value = o.dActualSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dTargetSavings";
        param.Value = o.dTargetSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    //Loads Improvement Ideas For anybody's action
    public DataTable dtGetImprovementIdeasPendingMyAction(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getImprovementIdeasPendingMyAction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.iDefault;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetImprovementIdeasIApprovedSupportedOrRejected(int iUserId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getImprovementIdeasIApprovedSupportedOrRejected();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //Loads Improvement Ideas raised by anybody
    public DataTable dtGetMyPendingImprovementIdeas(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getMyPendingImprovementIdeas();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetMyApprovedImprovementIdeas(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getMyApprovedImprovementIdeas();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //Load all Improvement Ideas

    public DataTable dtGetPendingImprovementIdeas()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeas();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public DataTable dtGetPendingImprovementIdeas(string InitiativeLeadFilter, string TeamFilter, string InitiatorFilter, string FocalPointFilter, string ChampionFilter, string SponsorFilter, string BenefitFilter, string StatusFilter, string StageGateFilter)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        if ((InitiativeLeadFilter == "ALL") && (TeamFilter == "ALL") && (InitiatorFilter == "ALL") && (FocalPointFilter == "ALL") && (ChampionFilter == "ALL") && (SponsorFilter == "ALL") && (BenefitFilter == "ALL") && (StatusFilter == "ALL") && (StageGateFilter == "ALL"))
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeas();
        }
        else if (InitiativeLeadFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByInitiativeLead();

            param = comm.CreateParameter();
            param.ParameterName = ":InitiativeLeadFilter";
            param.Value = InitiativeLeadFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (BenefitFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByBenefit();

            param = comm.CreateParameter();
            param.ParameterName = ":BenefitFilter";
            param.Value = BenefitFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (TeamFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByTeam();

            param = comm.CreateParameter();
            param.ParameterName = ":TeamFilter";
            param.Value = TeamFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (InitiatorFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByInitiator();

            param = comm.CreateParameter();
            param.ParameterName = ":InitiatorFilter";
            param.Value = InitiatorFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (FocalPointFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByFocalPoint();

            param = comm.CreateParameter();
            param.ParameterName = ":FocalPointFilter";
            param.Value = FocalPointFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (ChampionFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByChampion();

            param = comm.CreateParameter();
            param.ParameterName = ":ChampionFilter";
            param.Value = ChampionFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (SponsorFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasBySponsor();

            param = comm.CreateParameter();
            param.ParameterName = ":SponsorFilter";
            param.Value = SponsorFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (StatusFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByStatus();

            param = comm.CreateParameter();
            param.ParameterName = ":StatusFilter";
            param.Value = StatusFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }
        else if (StageGateFilter != "ALL")
        {
            comm.CommandText = StoredProcedureBI500.getPendingImprovementIdeasByStageGate();

            param = comm.CreateParameter();
            param.ParameterName = ":StageGateFilter";
            param.Value = StageGateFilter;
            param.DbType = DbType.String;
            param.Size = 20;
            comm.Parameters.Add(param);
        }

        //TeamFilter, InitiatorFilter FocalPointFilter ChampionFilter, InitiativeLeadFilter
        //SponsorFilter BenefitFilter StatusFilter StageGateFilter
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<CostReductionRequest> lstCostReductionRequest(DataTable dt)
    {
        List<CostReductionRequest> o = new List<CostReductionRequest>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionRequest(dr));
        }
        return o;
    }

    public DataTable dtGetApprovedImprovementIdeas()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getApprovedImprovementIdeas();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    
    //Loads Improvement Ideas Pending BI Team support
    public DataTable dtGetImprovementIdeasPendingBITeamSupport()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getImprovementIdeasPendingBITeamSupport();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStand";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.iDefault;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetImprovementIdeasSupportedByBI()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getImprovementIdeasSupportedByBI();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.CR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<structUserMailIdx> BIReviewersEmail()
    {
        // We might obtain a functional account later in the future for this process.
        //oReceivers.Add(new structUserMailIdx("", AppConfiguration.productionBIFunctionalAccount, ""));
        appUsersHelper oUser = new appUsersHelper();
        List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
        List<BIReviewers> lstBIReviewers = BuzBILeanReviewers.lstGetBILeanReviewers();
        foreach (BIReviewers oR in lstBIReviewers)
        {
            oReceivers.Add(oUser.objGetUserByUserID(oR.m_iUserId).structUserIdx);
        }

        return oReceivers;
    }

    public string BIReviewers()
    {
        // We might obtain a functional account later in the future for this process.
        //oReceivers.Add(new structUserMailIdx("", AppConfiguration.productionBIFunctionalAccount, ""));
        appUsersHelper oUser = new appUsersHelper();
        string Reviewers = "";
        List<BIReviewers> lstBIReviewers = BuzBILeanReviewers.lstGetBILeanReviewers();
        foreach (BIReviewers oR in lstBIReviewers)
        {
            Reviewers += oUser.objGetUserByUserID(oR.m_iUserId).m_sFullName + ";  ";
        }

        return Reviewers.ToString();
    }

    #endregion

}


public class MilestoneHelper
{
    public MilestoneHelper()
    {

    }

    public DataTable dtGetMilestoneByRequestId(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getMilestoneByRequestId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMilestoneByMilestoneId(long lMilestoneId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getMilestoneByMilestoneId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lMilestoneId";
        param.Value = lMilestoneId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public CostReductionMileStone objGetMilestoneByMilstoneId(long lMilestoneId)
    {
        DataTable dt = dtGetMilestoneByMilestoneId(lMilestoneId);
        CostReductionMileStone o = new CostReductionMileStone();
        foreach (DataRow dr in dt.Rows)
        {
            o = new CostReductionMileStone(dr);
        }
        return o;
    }

    public List<CostReductionMileStone> lstGetMilestoneByRequestId(long lRequestId)
    {
        DataTable dt = dtGetMilestoneByRequestId(lRequestId);
        List<CostReductionMileStone> o = new List<CostReductionMileStone>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionMileStone(dr));
        }
        return o;
    }

    public bool InsertMilestone(CostReductionMileStone o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.InsertMilestone();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = o.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dFinishDate";
        param.Value = o.dFinishDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dStartDate";
        param.Value = o.dStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sActivityDescription";
        param.Value = o.sActivityDescription;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dAmountSaved";
        param.Value = o.dAmountSaved;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool UpdateMilestone(CostReductionMileStone o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateMilestone();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = o.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dFinishDate";
        param.Value = o.dFinishDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dStartDate";
        param.Value = o.dStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sActivityDescription";
        param.Value = o.sActivityDescription;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dAmountSaved";
        param.Value = o.dAmountSaved;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lMilestoneId";
        param.Value = o.lMilestoneId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool DeleteMilestone(long lMilestoneId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.DeleteMilestone();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lMilestoneId";
        param.Value = lMilestoneId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

}

public class CadenceHelper
{
    public CadenceHelper()
    {

    }

    public DataTable dtGetCadenceByRequestId(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getCadenceByRequestId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetCadenceByCadenceId(long lCadenceId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getCadenceByCadenceId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCadenceId";
        param.Value = lCadenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public CostReductionCadence objGetCadenceByCadenceId(long lCadenceId)
    {
        DataTable dt = dtGetCadenceByCadenceId(lCadenceId);
        CostReductionCadence o = new CostReductionCadence();
        foreach (DataRow dr in dt.Rows)
        {
            o = new CostReductionCadence(dr);
        }
        return o;
    }

    public List<CostReductionCadence> lstGetCadenceByRequestId(long lRequestId)
    {
        DataTable dt = dtGetCadenceByRequestId(lRequestId);
        List<CostReductionCadence> o = new List<CostReductionCadence>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionCadence(dr));
        }
        return o;
    }

    public bool InsertCadence(CostReductionCadence o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.InsertCadence();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = o.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sAction";
        param.Value = o.sAction;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sActionParty";
        param.Value = o.sActionParty;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sThreat";
        param.Value = o.sThreat;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dFinishDate";
        param.Value = o.dFinishDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = o.iStatus;
        param.DbType = DbType.Int16;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool UpdateCadence(CostReductionCadence o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateCadence();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = o.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lCadenceId";
        param.Value = o.lCadenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sAction";
        param.Value = o.sAction;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sActionParty";
        param.Value = o.sActionParty;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sThreat";
        param.Value = o.sThreat;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dFinishDate";
        param.Value = o.dFinishDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = o.iStatus;
        param.DbType = DbType.Int16;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public bool DeleteCadence(long lCadenceId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.DeleteCadence();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCadenceId";
        param.Value = lCadenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
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

    public void ExporttoExcel(List<CostReductionCadence> o)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:12.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
          "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
          "style='font-size:12.0pt; font-family:Calibri; background:white;'>");

        //Get column headers  and make it as bold in excel columns
        HttpContext.Current.Response.Write("<TR>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("S/No");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Action");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Action Party");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Threat");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Date Due");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Status");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("</TR>");

        int i = 1;

        foreach (CostReductionCadence oT in o)
        {
            HttpContext.Current.Response.Write("<TR>");
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(i++);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.sAction);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.sActionParty);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.sThreat);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.dFinishDate);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");

            Label status = new Label();
            status.Text = oT.iStatus.ToString();
            CadenceStatus.CadenceStatusReporter(status);

            HttpContext.Current.Response.Write(status.Text);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("</TR>");
        }

        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

}

public class CadenceStatus
{
    public CadenceStatus()
    {
        //
        // 
        //
    }

    public enum ProjStatus
    {
        New = 1,
        OnTrack = 2,
        AtRisk = 3,
        Delayed = 4,
        Completed = 5,
    };

    public static string status(ProjStatus eProjectStatus)
    {
        string sRet = "";
        try
        {
            switch (eProjectStatus)
            {
                case ProjStatus.New: sRet = "New"; break;
                case ProjStatus.OnTrack: sRet = "On Track"; break;
                case ProjStatus.AtRisk: sRet = "At Risk"; break;
                case ProjStatus.Delayed: sRet = "Delayed"; break;
                case ProjStatus.Completed: sRet = "Completed"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public static void CadenceStatusReporter(GridView grdView)
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lb = (Label) grdRow.FindControl("labelStatus");

            if (lb != null)
            {
                int iStatus = int.Parse(lb.Text);

                if (iStatus == (int) CadenceStatus.ProjStatus.New) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.New); grdRow.Cells[5].BackColor = System.Drawing.Color.White; }
                if (iStatus == (int) CadenceStatus.ProjStatus.AtRisk) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.AtRisk); grdRow.Cells[5].BackColor = System.Drawing.Color.Orange; }
                if (iStatus == (int) CadenceStatus.ProjStatus.OnTrack) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.OnTrack); grdRow.Cells[5].BackColor = System.Drawing.Color.Green; }
                if (iStatus == (int) CadenceStatus.ProjStatus.Delayed) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.Delayed); grdRow.Cells[5].BackColor = System.Drawing.Color.Red; }
                if (iStatus == (int) CadenceStatus.ProjStatus.Completed) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.Completed); grdRow.Cells[5].BackColor = System.Drawing.Color.Navy; }
            }
        }
    }

    public static void CadenceStatusReporter(Label lb)
    {
        if (lb != null)
        {
            int iStatus = int.Parse(lb.Text);

            if (iStatus == (int) CadenceStatus.ProjStatus.New) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.New); lb.ForeColor = System.Drawing.Color.White; }
            if (iStatus == (int) CadenceStatus.ProjStatus.AtRisk) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.AtRisk); lb.ForeColor = System.Drawing.Color.Orange; }
            if (iStatus == (int) CadenceStatus.ProjStatus.OnTrack) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.OnTrack); lb.ForeColor = System.Drawing.Color.Green; }
            if (iStatus == (int) CadenceStatus.ProjStatus.Delayed) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.Delayed); lb.ForeColor = System.Drawing.Color.Red; }
            if (iStatus == (int) CadenceStatus.ProjStatus.Completed) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.Completed); lb.ForeColor = System.Drawing.Color.Navy; }
        }
    }





}