using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for CostImprovementSlippageReminder
/// </summary>
/// 

public class ReminderMailMgt
{
    public int ID { get; set; }
    public DateTime dTodayDate { get; set; }
    public int iMorning { get; set; }
    public int iAfternoon { get; set; }
    public int iEvening { get; set; }

    public ReminderMailMgt()
    {

    }

    public ReminderMailMgt(DataRow dr)
    {
        ID = int.Parse(dr["ID"].ToString());
        dTodayDate = (!string.IsNullOrEmpty(dr["TODAYDATE"].ToString()) ? DateTime.Parse(dr["TODAYDATE"].ToString()) : DateTime.Now.Date.AddDays(-1));
        iMorning = int.Parse(dr["MORNING"].ToString());
        iAfternoon = int.Parse(dr["AFTERNOON"].ToString());
        iEvening = int.Parse(dr["EVENING"].ToString());
    }

    public static bool UpdateDailyMailReminder(DateTime dTodayDate, int iMorning, int iAfternoon, int iEvening)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateMailManagement();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMorning";
        param.Value = iMorning;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAfternoon";
        param.Value = iAfternoon;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iEvening";
        param.Value = iEvening;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dTodayDate";
        param.Value = dTodayDate;
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


    public static DataTable dtGetReminderMailMgt()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.GetMailManagement();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static ReminderMailMgt objGetReminderMailMgt()
    {
        DataTable dt = dtGetReminderMailMgt();
        ReminderMailMgt o = new ReminderMailMgt();
        foreach (DataRow dr in dt.Rows)
        {
            o = new ReminderMailMgt(dr);
        }

        return o;
    }
}


public class receiver
{
    public appUsers tUser { get; set; }
    public CostReductionRequest oCostReduction { get; set; }
}

public class CostImprovementSlippageReminder
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();

	public CostImprovementSlippageReminder()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void SendReminderMail()
    {
        BI500ApprovalHelper ok = new BI500ApprovalHelper();

        System.Data.DataTable dt = oBI500RequestHelper.dtGetPendingImprovementIdeas();
        List<CostReductionRequest> oLst = oBI500RequestHelper.lstCostReductionRequest(dt);

        //Get Focal Points
        List<receiver> focalPoints = new List<receiver>();
        foreach (CostReductionRequest o in oLst)
        {
            if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction)
            {
                receiver oRFocalPoint = new receiver();
                oRFocalPoint.oCostReduction = o;
                oRFocalPoint.tUser = oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId);
                focalPoints.Add(oRFocalPoint);
            }
        }

        //Get Workstream Owner
        List<receiver> ProjectChampion = new List<receiver>();
        foreach (CostReductionRequest o in oLst)
        {
            if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport)
            {
                receiver oRChampion = new receiver();
                oRChampion.oCostReduction = o;
                oRChampion.tUser = oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId);
                ProjectChampion.Add(oRChampion);
            }
        }

        //Get Workstream Sponsor
        List<receiver> ProjectSponsor = new List<receiver>();
        foreach (CostReductionRequest o in oLst)
        {
            if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval)
            {
                receiver oRSponsor = new receiver();
                oRSponsor.oCostReduction = o;
                oRSponsor.tUser = oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId);
                ProjectSponsor.Add(oRSponsor);
            }
        }

        //Get Initiators
        List<receiver> Initiator = new List<receiver>();
        foreach (CostReductionRequest o in oLst)
        {
            //When status is pending Initiator to submit his entry.
            if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.iDefault)
            {
                receiver oRInitiator = new receiver();
                oRInitiator.oCostReduction = o;
                oRInitiator.tUser = oappUsersHelper.objGetUserByUserID(o.iUserId);
                Initiator.Add(oRInitiator);
            }
        }

        //Sender should be the administrator.
        structUserMailIdx Sender = new structUserMailIdx(AppConfiguration.adminUserName, AppConfiguration.adminEmail, "");
        sendMailBI500 oSendMail = new sendMailBI500(Sender);
        string Status = "";

        //Send mail(s) to Initiators
        foreach (receiver o in Initiator)
        {
            Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.oCostReduction.iStatus);
            oSendMail.SlippageReminder(o.oCostReduction, o.tUser.structUserIdx, oBI500RequestHelper.BIReviewersEmail(), o.oCostReduction.dDateSubmitted, Status);
        }

        //Send mail(s) to Sponsors
        foreach (receiver o in ProjectSponsor)
        {
            Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.oCostReduction.iStatus);
            DateTime dtDateReceived = ok.objGetBIApprovalbyRequestRoleId(o.oCostReduction.lRequestId, (int)appUsersRolesBI500.userRole.sponsor).m_dDateReceived;
            oSendMail.SlippageReminder(o.oCostReduction, o.tUser.structUserIdx, oBI500RequestHelper.BIReviewersEmail(), dtDateReceived, Status);
        }

        //Send mail(s) to Project Champion (Work stream owners)
        foreach (receiver o in ProjectChampion)
        {
            Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.oCostReduction.iStatus);
            DateTime dtDateReceived = ok.objGetBIApprovalbyRequestRoleId(o.oCostReduction.lRequestId, (int)appUsersRolesBI500.userRole.champion).m_dDateReceived;
            oSendMail.SlippageReminder(o.oCostReduction, o.tUser.structUserIdx, oBI500RequestHelper.BIReviewersEmail(), dtDateReceived, Status);
        }

        //Send mail(s) to Focal Points
        foreach (receiver o in focalPoints)
        {
            Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.oCostReduction.iStatus);
            DateTime dtDateReceived = ok.objGetBIApprovalbyRequestRoleId(o.oCostReduction.lRequestId, (int)appUsersRolesBI500.userRole.focalPoint).m_dDateReceived;
            oSendMail.SlippageReminder(o.oCostReduction, o.tUser.structUserIdx, oBI500RequestHelper.BIReviewersEmail(), dtDateReceived, Status);
        }
    }
}