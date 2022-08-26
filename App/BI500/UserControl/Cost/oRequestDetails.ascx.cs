using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Microsoft.Security.Application;

public partial class UserControl_Cost_oRequestDetails : aspnetUserControl
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    BenefitsMgt oBenefitsMgt = new BenefitsMgt();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    BIDepartments oD = new BIDepartments();
    BITeams oT = new BITeams();
    CadenceHelper oMS = new CadenceHelper();
    //MilestoneHelper oMS = new MilestoneHelper();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control(long lRequestId)
    {
        btnFP.Enabled = false;
        btnIL.Enabled = false;
        btnWSO.Enabled = false;
        btnWSS.Enabled = false;

        RequestIdHF.Value = lRequestId.ToString();
        CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

        if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport) btnWSO.Enabled = true;
        else if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval) btnWSS.Enabled = true;
        else if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction) btnFP.Enabled = true;
        else if (o.iStatus == (int)BIRequestStatus.RequestStatusRpt.InitiativeLead) btnIL.Enabled = true;

        lblRequestNumber.Text = Encoder.HtmlEncode(o.sRequestNumber);
        lblTitle.Text = Encoder.HtmlEncode(o.sTitle);
        lblDateInit.Text = Encoder.HtmlEncode(o.dDateSubmitted.ToString("MMMM dd, yyyy"));

        lblTargetSavings.Text = stringRoutine.formatAsBankMoney(o.dTargetSavings);
        lblActualSavings.Text = stringRoutine.formatAsBankMoney(o.dActualSavings);

        lblBusinessArea.Text = Encoder.HtmlEncode(oFunctionMgt.objGetFunctionById(o.iFunctionId).m_sFunction);
        lblTeam.Text = Encoder.HtmlEncode(oT.objGetTeamById(o.iTeamId).m_sTeam);
        lblDepartment.Text = Encoder.HtmlEncode(oD.objGetDepartmentById(o.iDeptId).m_sDepartment);

        lblImpactArea.Text = Encoder.HtmlEncode(oBenefitsMgt.objGetBenefitById(o.iBenefitId).m_sBenefit);
        //lblPlanCompletionDate.Text = Encoder.HtmlEncode(o.dCompletionDate.ToString());
        lblInitiator.Text = Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);
        if (o.iProjectChampionUserId == 0) { lblProjectChampion.Font.Bold = true; lblProjectChampion.ForeColor = System.Drawing.Color.Red; }
        if (o.iProjectSponsorUserId == 0) { lblProjectSponsor.Font.Bold = true; lblProjectSponsor.ForeColor = System.Drawing.Color.Red; }
        if (o.iFocalPointUserId == 0) { lblFocalPoint.Font.Bold = true; lblFocalPoint.ForeColor = System.Drawing.Color.Red; }
        if (o.iInitiativeLeadUserId == 0) { lblInitiativeLead.Font.Bold = true; lblInitiativeLead.ForeColor = System.Drawing.Color.Red; }

        if (o.iStatus != (int)BIRequestStatus.RequestStatusRpt.iDefault)
        {
            lblProjectChampion.Text = (o.iProjectChampionUserId == 0) ? "Yet to be assigned by Focal Point" : Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId).m_sFullName);
            lblProjectSponsor.Text = (o.iProjectSponsorUserId == 0) ? "Yet to be assigned by Focal Point" : Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId).m_sFullName);
            lblFocalPoint.Text = (o.iFocalPointUserId == 0) ? "Pending Business Improvement Team's Action" : Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId).m_sFullName);
            lblInitiativeLead.Text = (o.iInitiativeLeadUserId == 0) ? "Yet to be assigned by Focal Point" : Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(o.iInitiativeLeadUserId).m_sFullName);
        }
        
        lblBuzCase.Text = Encoder.HtmlEncode(o.sBusinessCase);
        lblOpportunityStmt.Text = Encoder.HtmlEncode(o.sOpportunityStmt);
        lblTeamMembers.Text = Encoder.HtmlEncode(o.sTeamMembers);

        lblStatus.Text = Encoder.HtmlEncode(o.iStatus.ToString());
        lnkPhase.Text = Encoder.HtmlEncode(o.iPhase.ToString());
        BIRequestStatus.reportMyStatus(lblStatus);
        BIRequestStatus.reportBrightIdeaPhase(lnkPhase);

        lblImprovementBenefit.Text = (Encoder.HtmlEncode(o.sImprovement) == "None") ? "?" : Encoder.HtmlEncode(o.sImprovement);
        lblFinishedDate.Text = string.IsNullOrEmpty(Encoder.HtmlEncode(o.dActualDate.ToString("MMMM dd, yyyy"))) ? "?" : Encoder.HtmlEncode(o.dActualDate.ToString("MMMM dd, yyyy"));
        lblQtyBenefit.Text = Encoder.HtmlEncode(o.sQtyBenefit.ToString());
        lblReplicationPotential.Text = (Encoder.HtmlEncode(o.sReplication) == "None") ? "?" : Encoder.HtmlEncode(o.sReplication);

        BI500RequestOnBehalfHelper oL = new BI500RequestOnBehalfHelper();
        BI500RequestOnBehalf oBhlf = oL.objGetBrightIdeaOnbehalfById(o.lRequestId);
        lblFullName.Text = oBhlf.sFullName;
        lblEmailAddress.Text = oBhlf.sEmailAddress;

        LoadApproversComment(o.lRequestId);

        grdViewCadence.DataSource = oMS.dtGetCadenceByRequestId(lRequestId);
        grdViewCadence.DataBind();

        CadenceStatus.CadenceStatusReporter(grdViewCadence);

        //grdViewMilestone.DataSource = oMS.dtGetMilestoneByRequestId(o.lRequestId);
        //grdViewMilestone.DataBind();
    }

    private void LoadApproversComment(long lRequestId)
    {
        grdView.DataSource = BI500ApprovalHelper.dtGetBIApprovalbyRequestId(lRequestId);
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label Role = (Label)grdRow.FindControl("lblRole");
            int iRoleId = int.Parse(Role.Text);
            Role.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)iRoleId);

            Label Status = (Label)grdRow.FindControl("lblStand");
            BIRequestStatus.reportMyStatus(Status);
        }
    }

    protected void exportExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(RequestIdHF.Value);
            List<CostReductionCadence> o = oMS.lstGetCadenceByRequestId(lRequestId);
            oMS.ExporttoExcel(o);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
        }
    }

    protected void btnFP_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);
        CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        string Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.iStatus);

        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.SlippageReminder(o, oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId).structUserIdx, o.dDateSubmitted, Status);

        ajaxWebExtension.showJscriptAlertCx(Page, this, "Reminder mail sucessfully sent to " + oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId).m_sFullName);
    }

    protected void btnIL_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);
        CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        string Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.iStatus);

        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.SlippageReminder(o, oappUsersHelper.objGetUserByUserID(o.iInitiativeLeadUserId).structUserIdx, o.dDateSubmitted, Status);

        ajaxWebExtension.showJscriptAlertCx(Page, this, "Reminder mail sucessfully sent to " + oappUsersHelper.objGetUserByUserID(o.iInitiativeLeadUserId).m_sFullName);
    }

    protected void btnWSO_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);
        CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        string Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.iStatus);

        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.SlippageReminder(o, oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId).structUserIdx, o.dDateSubmitted, Status);

        ajaxWebExtension.showJscriptAlertCx(Page, this, "Reminder mail sucessfully sent to " + oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId).m_sFullName);
    }

    protected void btnWSS_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);
        CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        string Status = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.iStatus);

        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.SlippageReminder(o, oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId).structUserIdx, o.dDateSubmitted, Status);

        ajaxWebExtension.showJscriptAlertCx(Page, this, "Reminder mail sucessfully sent to " + oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId).m_sFullName);
    }
}