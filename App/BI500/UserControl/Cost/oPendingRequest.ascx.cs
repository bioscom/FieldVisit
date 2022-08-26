using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Microsoft.Security.Application;
using System.Linq;

public partial class App_BI500_UserControl_Cost_oPendingRequest : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    BI500Approval oBI500Approval = new BI500Approval();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    CostReductionRequest oBI500Request = new CostReductionRequest();
    BenefitsMgt oBnft = new BenefitsMgt();

    public void Page_Init()
    {
        if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRoles.userRole.admin)
        {
            btnReminderMail.Enabled = true;
        }
        else
        {
            btnReminderMail.Enabled = false;
        }

        ViewState["TeamFilter"] = "ALL";
        ViewState["InitiatorFilter"] = "ALL";
        ViewState["InitiativeLeadFilter"] = "ALL";
        ViewState["FocalPointFilter"] = "ALL";
        ViewState["ChampionFilter"] = "ALL";
        ViewState["SponsorFilter"] = "ALL";
        ViewState["BenefitFilter"] = "ALL";
        ViewState["StatusFilter"] = "ALL";
        ViewState["StageGateFilter"] = "ALL";

        LoadPendingImprovementIdeas();
    }

    public void LoadPendingImprovementIdeas()
    {
        string sTeamFilter = ViewState["TeamFilter"].ToString();
        string sInitiatorFilter = ViewState["InitiatorFilter"].ToString();
        string sInitiativeLeadFilter = ViewState["InitiativeLeadFilter"].ToString();
        string sFocalPointFilter = ViewState["FocalPointFilter"].ToString();
        string sChampionFilter = ViewState["ChampionFilter"].ToString();
        string sSponsorFilter = ViewState["SponsorFilter"].ToString();
        string sBenefitFilter = ViewState["BenefitFilter"].ToString();
        string sStatusFilter = ViewState["StatusFilter"].ToString();
        string sStageGateFilter = ViewState["StageGateFilter"].ToString();

        DataTable dt = oBI500RequestHelper.dtGetPendingImprovementIdeas(sInitiativeLeadFilter, sTeamFilter, sInitiatorFilter, sFocalPointFilter, sChampionFilter, sSponsorFilter, sBenefitFilter, sStatusFilter, sStageGateFilter);

        grdGridView.DataSource = dt;
        grdGridView.DataBind();

        List<CostReductionRequest> oLst = oBI500RequestHelper.lstCostReductionRequest(dt);

        GridManager();

        var ddlTeam = (DropDownList)grdGridView.HeaderRow.FindControl("ddlTeam");
        var ddlInitiator = (DropDownList)grdGridView.HeaderRow.FindControl("ddlInitiator");
        var ddlInitiativeLead = (DropDownList)grdGridView.HeaderRow.FindControl("ddlInitiativeLead");
        var ddlFocalPoint = (DropDownList)grdGridView.HeaderRow.FindControl("ddlFocalPoint");
        var ddlProjectChampion = (DropDownList)grdGridView.HeaderRow.FindControl("ddlProjectChampion");
        var ddlProjectSponsor = (DropDownList)grdGridView.HeaderRow.FindControl("ddlProjectSponsor");
        var ddlStageGate = (DropDownList)grdGridView.HeaderRow.FindControl("ddlStageGate");
        var ddlExpectedBenefit = (DropDownList)grdGridView.HeaderRow.FindControl("ddlExpectedBenefit");
        var ddlStatus = (DropDownList)grdGridView.HeaderRow.FindControl("ddlStatus");


        this.BindInitiatorList(ddlInitiator, oLst);
        this.BindFocalPointList(ddlFocalPoint, oLst);
        this.BindProjectChampionList(ddlProjectChampion, oLst);
        this.BindProjectSponsorList(ddlProjectSponsor, oLst);
        this.BindWorkInitiativeLeadList(ddlInitiativeLead, oLst);

        this.BindTeamList(ddlTeam);
        this.BindStageGateList(ddlStageGate);
        this.BindExpectedBenefitList(ddlExpectedBenefit);
        this.BindStatusList(ddlStatus);
    }

    public void SearchResult(DataTable dt)
    {
        grdGridView.DataSource = dt;
        grdGridView.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }

    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        LoadPendingImprovementIdeas();
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton UpdateLinkButton = (LinkButton)row.FindControl("UpdateLinkButton");
                long lRequestId = long.Parse(UpdateLinkButton.Attributes["IDREQUEST"].ToString());

                BrightIdeasFormEdt1.Init_Page(lRequestId);

                MPE.Show();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Command Button           Command Name

        //ActionLinkButton          Action
        //CancelLinkButton          CancelRequest
        //deleteLinkButton          deleteRequest
        //ViewStatusLinkButton      ViewStatus
        //EditLinkButton            EditThisRequest
        //ReportLinkButton          Report
        //RerouteLinkButton         Reroute
        //AuditTrailLinkButton      AuditTrail

        //try
        //{
        string ButtonClicked = e.CommandName;
        int index = Convert.ToInt32(e.CommandArgument);

        if (ButtonClicked == "Action")
        {
            LinkButton lbAction = (LinkButton)grdGridView.Rows[index].FindControl("ActionLinkButton");
            long lRequestId = long.Parse(lbAction.Attributes["IDREQUEST"].ToString());
            //long lApprovalId = long.Parse(lbAction.Attributes["IDAPPROVAL"].ToString());

            //oBI500Approval = oBI500ApprovalHelper.objBIApprovalbyApprovalId(lApprovalId);
            //oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

            Response.Redirect("~/App/BI500/BIApprovalProc.aspx?RequestId=" + lRequestId);

            //if (oSessnx.getOnlineUser.m_iUserId == oBI500Approval.m_iUserId)
            //{
            //    Response.Redirect("~/App/BI500/BIApprovalProc.aspx?RequestId=" + lRequestId);

            //    if (oBI500Approval.m_iRoleIdBI == (int)appUsersRoles.userRole.champion)
            //    {
            //        Response.Redirect("~/App/BI500/BIApprovalProc.aspx?RequestId=" + lRequestId);
            //    }
            //    else if (oBI500Approval.m_iRoleIdBI == (int)appUsersRoles.userRole.sponsor)
            //    {
            //        if (oBI500Request.m_iStatus != (int)BIRequestStatus.RequestStatusRpt.AwaitProjectSponsorApproval)
            //        {
            //            ajaxWebExtension.showJscriptAlertCx(Page, this, "You cannot action this request now, the status is " + BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)(int)BIRequestStatus.RequestStatusRpt.AwaitProjectChampionSupport));
            //        }
            //        else
            //        {
            //            Response.Redirect("~/App/BI500/BIApprovalProc.aspx?RequestId=" + lRequestId);
            //        }
            //    }
            //}
        }
        else if (ButtonClicked == "CancelRequest")
        {
            LinkButton lbCancel = (LinkButton)grdGridView.Rows[index].FindControl("CancelLinkButton");
            long lRequestId = long.Parse(lbCancel.Attributes["IDREQUEST"].ToString());

            //TODO: When a request is cancelled, move it to the cancelled folder, by updating the status to iCancel
        }
        else if (ButtonClicked == "deleteRequest")
        {
            LinkButton lbDelete = (LinkButton)grdGridView.Rows[index].FindControl("deleteLinkButton");
            long lRequestId = long.Parse(lbDelete.Attributes["IDREQUEST"].ToString());

            //TODO: When a request is delete, what should be done????
        }
        else if (ButtonClicked == "ViewStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("ViewStatusLinkButton");
            long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

            WizardStep oWzrdStp = (WizardStep)this.Parent.FindControl("RequestDetails");
            UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)oWzrdStp.FindControl("oRequestDetails1");
            oReq.Init_Control(lRequestId);

            MultiView o = (MultiView)this.Parent.Parent;
            o.ActiveViewIndex = 3;
        }
        else if (ButtonClicked == "AssignFocalPoint")
        {
            LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("AssignFocalPointLinkButton");
            long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

            WizardStep AssignFocalPoint = (WizardStep)this.Parent.FindControl("WizFocalPoint");
            UserControl_userFinder_Search4LocalUser FocalPoint = (UserControl_userFinder_Search4LocalUser)AssignFocalPoint.FindControl("FocalPoint");

            HiddenField HFRequestIdFP = (HiddenField)AssignFocalPoint.FindControl("HFRequestIdFP");
            HFRequestIdFP.Value = lRequestId.ToString();

            UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)AssignFocalPoint.FindControl("oRequestDetails3");
            oReq.Init_Control(lRequestId);

            FocalPoint.ErrorMssg("Focal Point is required. Please, select N/A if Focal Point not found, can be updated later.");

            FocalPoint.resetUserInfo();

            MultiView o = (MultiView)this.Parent.Parent;
            o.ActiveViewIndex = 4;
        }
        else if (ButtonClicked == "AssignApprovers")
        {
            LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("ViewStatusLinkButton");
            long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

            WizardStep AssignApprovers = (WizardStep)this.Parent.FindControl("AssignApprovers");
            UserControl_userFinder_Search4LocalUser Sponsor = (UserControl_userFinder_Search4LocalUser)AssignApprovers.FindControl("Sponsor");
            UserControl_userFinder_Search4LocalUser champion = (UserControl_userFinder_Search4LocalUser)AssignApprovers.FindControl("champion");

            HiddenField HFRequestId2 = (HiddenField)AssignApprovers.FindControl("HFRequestId2");
            HFRequestId2.Value = lRequestId.ToString();

            UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)AssignApprovers.FindControl("oRequestDetails2");
            oReq.Init_Control(lRequestId);

            Sponsor.ErrorMssg("Project Sponsor is required. Please, select N/A if Sponsor not found, can be updated later.");
            champion.ErrorMssg("Project Champion is required. Please, select N/A if Champion not found, can be updated later.");

            Sponsor.resetUserInfo();
            champion.resetUserInfo();

            MultiView o = (MultiView)this.Parent.Parent;
            o.ActiveViewIndex = 5;
        }
        else if (ButtonClicked == "StageGate")
        {
            Panel pnlStageGate = (Panel)grdGridView.Rows[index].FindControl("pnlStageGate");
            pnlStageGate.Visible = true;
        }


    //else if (ButtonClicked == "EditThisRequest")
        //{
        //    LinkButton lbEdit = (LinkButton)grdGridView.Rows[index].FindControl("EditLinkButton");
        //    long lRequestId = long.Parse(lbEdit.Attributes["IDREQUEST"].ToString());

    //    //Check if the RequestId is found on BI500_REQUEST_ONBEHALF

    //    BI500RequestOnBehalfHelper o = new BI500RequestOnBehalfHelper();
        //    if (o.dtGetRequestOnBehalByRequestId(lRequestId).Rows.Count > 0)
        //    {
        //        //Response.Redirect("~/App/BI500/OnBehalfEdt.aspx?RequestId=" + lRequestId);
        //    }
        //    else
        //    {
        //        //Response.Redirect("~/App/BI500/EdtBizIntel.aspx?RequestId=" + lRequestId);
        //    }
        //}
        else if (ButtonClicked == "Report")
        {
            LinkButton lbReport = (LinkButton)grdGridView.Rows[index].FindControl("ReportLinkButton");
            long lRequestId = long.Parse(lbReport.Attributes["IDREQUEST"].ToString());

            //Response.Redirect("~/App/BI500/Report/MainReport.aspx?lRequestId=" + lRequestId);
        }
        else if (ButtonClicked == "Reroute")
        {
            LinkButton lbReroute = (LinkButton)grdGridView.Rows[index].FindControl("RerouteLinkButton");
            long lRequestId = long.Parse(lbReroute.Attributes["IDREQUEST"].ToString());

            //Response.Redirect("~/FlareRequestRouter.aspx?RequestId=" + lRequestId);
            //TODO: Complete the FlareRequestRouter.aspx page
        }
        //else if (ButtonClicked == "AuditTrail")
        //{
        //    LinkButton lbAuditTrail = (LinkButton)grdGridView.Rows[index].FindControl("AuditTrailLinkButton");
        //    long lRequestId = long.Parse(lbAuditTrail.Attributes["IDREQUEST"].ToString());

        //    Response.Redirect("~/FlareRequestApprovalAudit.aspx?RequestId=" + lRequestId);
        //    //TODO: Complete the FlareRequestApprovalAudit.aspx page
        //}
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }

    protected void ddlStageGate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            bool bRet = false;

            List<BIReviewers> lstStageGaters = BuzBILeanReviewers.lstGetCRStageGaters();
            foreach (BIReviewers o in lstStageGaters)
            {
                if (oSessnx.getOnlineUser.m_iUserId == o.m_iUserId)
                {
                    bRet = true;
                    break;
                }
            }


            if (bRet)
            {
                DropDownList ddlStageGate = (DropDownList)sender;
                GridViewRow row = ((GridViewRow)ddlStageGate.Parent.Parent);

                long lRequestId = long.Parse(ddlStageGate.Attributes["IDREQUEST"].ToString());

                //Update the column for the stage gate.
                oBI500RequestHelper.UpdateStageGate(lRequestId, int.Parse(ddlStageGate.SelectedValue));
                LoadPendingImprovementIdeas();
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Stage Gate update successful!!!");
            }
            else
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Please, you do not have the right to change the Stage Gate. Refer to System Administrator!!!");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //Loads Bright Ideas Pending anybody's approval approval
    public void LoadBIPendingMyApprovalSupport(appUsers oAppUser)
    {
        DataTable dt = new DataTable();
        //if this user is found in the list of the BI/Lean Approvers 
        //To determine if the login user has right to perform BI/Lean approval role
        //BuzBILeanReviewers.objGetBILeanReviewerByUserId(oAppUser.m_iUserId);
        bool bRet = BuzBILeanReviewers.dtGetBILeanReviewerByUserId(oAppUser.m_iUserId).Rows.Count > 0;
        if (bRet)
        {
            dt = oBI500RequestHelper.dtGetRequestsPendingBITeamSupport();
            dt.Merge(oBI500RequestHelper.dtGetRequestsPendingMyApprovalSupport(oAppUser.m_iUserId));
        }
        else
        {
            dt = oBI500RequestHelper.dtGetRequestsPendingMyApprovalSupport(oAppUser.m_iUserId);
        }

        grdGridView.DataSource = dt;
        grdGridView.DataBind();

        GridManager();
    }

    //Loads Bright Ideas Pending BI Team Support
    public void LoadBIPendingBITeamSupport()
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetRequestsPendingBITeamSupport();
        grdGridView.DataBind();

        GridManager();
    }

    //Loads Bright Ideas Pending Lean Team Focal Point support
    public void LoadBIPendingLeanTeamFocalPointSupport(int iUserId)
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetBrightIdeaPendingLeanFocalPointSupport(iUserId);
        grdGridView.DataBind();

        GridManager();
    }

    //Load Pending Bright Ideas Register
    public void LoadPendingBrightIdeasRegister()
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetPendingBrightIdeas();
        grdGridView.DataBind();

        GridManager();
    }

    private void GridManager()
    {
        long lRequestId = 0;
        foreach (GridViewRow grdRow in grdGridView.Rows)
        {
            //LinkButton CancelLinkButton = (LinkButton)grdRow.FindControl("CancelLinkButton");
            //LinkButton DeleteLinkButton = (LinkButton)grdRow.FindControl("deleteLinkButton");
            //LinkButton ViewStatusLinkButton = (LinkButton)grdRow.FindControl("ViewStatusLinkButton");
            //LinkButton EditLinkButton = (LinkButton)grdRow.FindControl("EditLinkButton");
            //LinkButton ReportLinkButton = (LinkButton)grdRow.FindControl("ReportLinkButton");
            //LinkButton RerouteLinkButton = (LinkButton)grdRow.FindControl("RerouteLinkButton");
            //LinkButton AuditTrailLinkButton = (LinkButton)grdRow.FindControl("AuditTrailLinkButton");

            //LinkButton ActionLinkButton = (LinkButton)grdRow.FindControl("ActionLinkButton");
            Label labelStatus = (Label)grdRow.FindControl("labelStatus");

            DropDownList ddlStageGate = (DropDownList)grdRow.FindControl("ddlStageGate");
            ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate1), ((int)BIRequestStatus.StageGates.StageGate1).ToString()));
            ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate2), ((int)BIRequestStatus.StageGates.StageGate2).ToString()));
            ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate3), ((int)BIRequestStatus.StageGates.StageGate3).ToString()));
            ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate4), ((int)BIRequestStatus.StageGates.StageGate4).ToString()));
            ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate5), ((int)BIRequestStatus.StageGates.StageGate5).ToString()));

            int iGate = int.Parse(ddlStageGate.Attributes["GATE"].ToString());
            ddlStageGate.SelectedValue = iGate.ToString();

            List<BI500Approval> lstApproval = oBI500ApprovalHelper.lstGetBIApprovalbyRequestId(lRequestId);
            foreach (BI500Approval oApproval in lstApproval)
            {
                if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport)
                {
                    if (oApproval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.champion)
                    {
                        //ActionLinkButton.Visible = true;
                    }
                }
                else if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval)
                {
                    if (oApproval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.sponsor)
                    {
                        //ActionLinkButton.Visible = true;
                    }
                }
                else if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport)
                {
                    //if (oApproval.m_iRoleIdBI == (int)appUsersRoles.userRole.sponsor)
                    //{
                    //ActionLinkButton.Visible = true;
                    //}
                }
                else if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval)
                {
                    //if (oApproval.m_iRoleIdBI == (int)appUsersRoles.userRole.sponsor)
                    //{
                    //ActionLinkButton.Visible = true;
                    //}
                }
            }

            BIRequestStatus.reportMyStatus(labelStatus);
        }
    }

    public GridView oGrdGridView
    {
        get
        {
            GridView grdView = (GridView)grdGridView;
            return grdView;
        }
    }



    #region ================================== Filtering the gridview ====================================

    #region ================================== Binding to the drop down list ==================================
    private void BindTeamList(DropDownList ddlTeam)
    {
        List<BITeams> oTs = BITeams.lstGetTeams();
        foreach (BITeams oT in oTs)
        {
            ddlTeam.Items.Add(new ListItem(oT.m_sTeam, oT.m_iTeamId.ToString()));
        }
        ddlTeam.Items.FindByValue(ViewState["TeamFilter"].ToString()).Selected = true;
    }

    private void BindInitiatorList(DropDownList ddlInitiator, List<CostReductionRequest> oLst)
    {
        //Sort the list and remove duplicates
        List<int> iHolder = new List<int>();
        iHolder.Add(0);
        List<appUsers> Initiators = new List<appUsers>();
        foreach (CostReductionRequest o in oLst)
        {
            if (!iHolder.Contains(o.iUserId))
            {
                Initiators.Add(oappUsersHelper.objGetUserByUserID(o.iUserId));
            }
            iHolder.Add(o.iUserId);
        }

        foreach (appUsers o in Initiators)
        {
            ddlInitiator.Items.Add(new ListItem(o.m_sFullName, o.m_iUserId.ToString()));
        }
        ddlInitiator.Items.FindByValue(ViewState["InitiatorFilter"].ToString()).Selected = true;
    }

    private void BindWorkInitiativeLeadList(DropDownList ddlInitiativeLead, List<CostReductionRequest> oLst)
    {
        //Sort the list and remove duplicates
        List<int> iHolder = new List<int>();
        iHolder.Add(0);
        List<appUsers> InitiativeLeads = new List<appUsers>();
        foreach (CostReductionRequest o in oLst)
        {
            if (!iHolder.Contains(o.iInitiativeLeadUserId))
            {
                InitiativeLeads.Add(oappUsersHelper.objGetUserByUserID(o.iInitiativeLeadUserId));
            }
            iHolder.Add(o.iInitiativeLeadUserId);
        }

        foreach (appUsers o in InitiativeLeads)
        {
            ddlInitiativeLead.Items.Add(new ListItem(o.m_sFullName, o.m_iUserId.ToString()));
        }
        ddlInitiativeLead.Items.FindByValue(ViewState["InitiativeLeadFilter"].ToString()).Selected = true;
    }

    private void BindFocalPointList(DropDownList ddlFocalPoint, List<CostReductionRequest> oLst)
    {
        //Sort the list and remove duplicates
        List<int> iHolder = new List<int>();
        iHolder.Add(0);
        List<appUsers> FocalPoints = new List<appUsers>();
        foreach (CostReductionRequest o in oLst)
        {
            if (!iHolder.Contains(o.iFocalPointUserId))
            {
                FocalPoints.Add(oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId));
            }
            iHolder.Add(o.iFocalPointUserId);
        }

        foreach (appUsers o in FocalPoints)
        {
            ddlFocalPoint.Items.Add(new ListItem(o.m_sFullName, o.m_iUserId.ToString()));
        }
        ddlFocalPoint.Items.FindByValue(ViewState["FocalPointFilter"].ToString()).Selected = true;
    }
    private void BindProjectChampionList(DropDownList ddlProjectChampion, List<CostReductionRequest> oLst)
    {
        //Sort the list and remove duplicates
        List<int> iHolder = new List<int>();
        iHolder.Add(0);
        List<appUsers> ProjectChampions = new List<appUsers>();
        foreach (CostReductionRequest o in oLst)
        {
            if (!iHolder.Contains(o.iProjectChampionUserId))
            {
                ProjectChampions.Add(oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId));
            }
            iHolder.Add(o.iProjectChampionUserId);
        }

        foreach (appUsers o in ProjectChampions)
        {
            ddlProjectChampion.Items.Add(new ListItem(o.m_sFullName, o.m_iUserId.ToString()));
        }

        ddlProjectChampion.Items.FindByValue(ViewState["ChampionFilter"].ToString()).Selected = true;
    }
    private void BindProjectSponsorList(DropDownList ddlProjectSponsor, List<CostReductionRequest> oLst)
    {
        //Sort the list and remove duplicates
        List<int> iHolder = new List<int>();
        iHolder.Add(0);
        List<appUsers> ProjectSponsors = new List<appUsers>();
        foreach (CostReductionRequest o in oLst)
        {
            if (!iHolder.Contains(o.iProjectSponsorUserId))
            {
                ProjectSponsors.Add(oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId));
            }
            iHolder.Add(o.iProjectSponsorUserId);
        }

        foreach (appUsers o in ProjectSponsors)
        {
            ddlProjectSponsor.Items.Add(new ListItem(o.m_sFullName, o.m_iUserId.ToString()));
        }

        ddlProjectSponsor.Items.FindByValue(ViewState["SponsorFilter"].ToString()).Selected = true;
    }
    private void BindExpectedBenefitList(DropDownList ddlExpectedBenefit)
    {
        List<Benefits> oBenefits = oBnft.lstBenefits();
        foreach (Benefits oBenefit in oBenefits)
        {
            ddlExpectedBenefit.Items.Add(new ListItem(oBenefit.m_sBenefit, oBenefit.m_iBenefitId.ToString()));
        }
        ddlExpectedBenefit.Items.FindByValue(ViewState["BenefitFilter"].ToString()).Selected = true;
    }
    private void BindStatusList(DropDownList ddlStatus)
    {
        ddlStatus.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.iDefault), BIRequestStatus.RequestStatusRpt.iDefault.ToString()));

        ddlStatus.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport), ((int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport).ToString()));
        ddlStatus.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval), ((int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval).ToString()));
        ddlStatus.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport), ((int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport).ToString()));
        ddlStatus.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.MaintainInDatabase), ((int)BIRequestStatus.RequestStatusRpt.MaintainInDatabase).ToString()));
        ddlStatus.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction), ((int)BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction).ToString()));

        ddlStatus.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.InitiativeLead), ((int)BIRequestStatus.RequestStatusRpt.InitiativeLead).ToString()));


        ddlStatus.Items.FindByValue(ViewState["StatusFilter"].ToString()).Selected = true;
    }
    private void BindStageGateList(DropDownList ddlStageGate)
    {
        //DropDownList ddlStageGate = (DropDownList)grdRow.FindControl("ddlStageGate");
        ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate1), ((int)BIRequestStatus.StageGates.StageGate1).ToString()));
        ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate2), ((int)BIRequestStatus.StageGates.StageGate2).ToString()));
        ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate3), ((int)BIRequestStatus.StageGates.StageGate3).ToString()));
        ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate4), ((int)BIRequestStatus.StageGates.StageGate4).ToString()));
        ddlStageGate.Items.Add(new ListItem(BIRequestStatus.StageGateDesc(BIRequestStatus.StageGates.StageGate5), ((int)BIRequestStatus.StageGates.StageGate5).ToString()));

        ddlStageGate.Items.FindByValue(ViewState["StageGateFilter"].ToString()).Selected = true;
    }

    #endregion

    #region ================================== Onselected Change Events ==================================
    protected void TeamChanged(object sender, EventArgs e)
    {
        DropDownList ddlTeam = (DropDownList)sender;
        ViewState["TeamFilter"] = ddlTeam.SelectedValue;
        this.LoadPendingImprovementIdeas();

    }

    protected void InitiatorChanged(object sender, EventArgs e)
    {
        DropDownList ddlInitiator = (DropDownList)sender;
        ViewState["InitiatorFilter"] = ddlInitiator.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    protected void InitiativeLeadChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ViewState["InitiativeLeadFilter"] = ddl.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    protected void FocalPointChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ViewState["FocalPointFilter"] = ddl.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    protected void ProjectChampionChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ViewState["ChampionFilter"] = ddl.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    protected void ProjectSponsorChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ViewState["SponsorFilter"] = ddl.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    protected void ExpectedBenefitChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ViewState["BenefitFilter"] = ddl.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    protected void StatusChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ViewState["StatusFilter"] = ddl.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    protected void StageGateChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ViewState["StageGateFilter"] = ddl.SelectedValue;
        this.LoadPendingImprovementIdeas();
    }

    #endregion


    #endregion

    protected void btnReminderMail_Click(object sender, EventArgs e)
    {
        //This mail will be sent three times a day.
        //Morning, Afternoon and Evening B4 COB
        ReminderMailMgt oReminder = ReminderMailMgt.objGetReminderMailMgt();
        CostImprovementSlippageReminder o = new CostImprovementSlippageReminder();

        //TimeSpan tTimeOfDay = DateTime.Now.TimeOfDay;
        //TimeSpan MorningScheduledTime = new TimeSpan(07, 40, 0);
        //TimeSpan AfternoonScheduledTime = new TimeSpan(13, 00, 0);
        //TimeSpan EveningScheduledTime = new TimeSpan(15, 00, 0);

        //Reset the reminder for the new day
        if (oReminder.dTodayDate != DateTime.Now.Date) ReminderMailMgt.UpdateDailyMailReminder(DateTime.Now.Date, 0, 0, 0);
        if (oReminder.dTodayDate == DateTime.Now.Date) o.SendReminderMail();

        //if (oReminder.dTodayDate == DateTime.Now.Date)
        //{
        //    if ((tTimeOfDay >= MorningScheduledTime) && (oReminder.iMorning == 0))
        //    {
        //        o.SendReminderMail();
        //        ReminderMailMgt.UpdateDailyMailReminder(DateTime.Now.Date, 1, 0, 0);
        //    }
        //    if ((tTimeOfDay >= AfternoonScheduledTime) && (oReminder.iAfternoon == 0))
        //    {
        //        o.SendReminderMail();
        //        ReminderMailMgt.UpdateDailyMailReminder(DateTime.Now.Date, 1, 1, 0);
        //    }
        //    if ((tTimeOfDay >= EveningScheduledTime) && (oReminder.iEvening == 0))
        //    {
        //        o.SendReminderMail();
        //        ReminderMailMgt.UpdateDailyMailReminder(DateTime.Now.Date, 1, 1, 1);
        //    }
        //}
    }

    protected void Export_Click(object sender, EventArgs e)
    {
        try
        {
            List<CostReductionRequest> o = oBI500RequestHelper.lstCostReductionRequest(oBI500RequestHelper.dtGetPendingImprovementIdeas());
            ExporttoExcel(o);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }


    private void ExporttoExcel(List<CostReductionRequest> o)
    {
        appUsersHelper oUsers = new appUsersHelper();

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
          "style='font-size:12.0pt; font-family:Calibri; background:white;'> <TR>");

        //Get column headers  and make it as bold in excel columns

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("S/No");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Request No");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Stage Gate");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Title");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Target Savings($)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Actual Savings($)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Team");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Initiator");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Focal Point");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Initiative Lead");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Workstream Owner");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Workstream Sponsor");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Benefit");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Status");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Date Request");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("</TR>");

        int i = 1;

        foreach (CostReductionRequest oT in o)
        {
            HttpContext.Current.Response.Write("<TR>");
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(i++);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.sRequestNumber);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.iGate);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.sTitle);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oT.dTargetSavings));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oT.dActualSavings));
            HttpContext.Current.Response.Write("</Td>");

            BITeams ok = new BITeams();
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(ok.objGetTeamById(oT.iTeamId).m_sTeam);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(oT.iUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(oT.iFocalPointUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(oT.iInitiativeLeadUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(oT.iProjectChampionUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(oT.iProjectSponsorUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");            

            BenefitsMgt oBen = new BenefitsMgt();
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oBen.objGetBenefitById(oT.iBenefitId).m_sBenefit);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");

            Label status = new Label();
            status.Text = oT.iStatus.ToString();
            BIRequestStatus.reportMyStatus(status);

            HttpContext.Current.Response.Write(status.Text);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(dateRoutine.dateShort(oT.dDateSubmitted, "-"));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("</TR>");
        }        

        HttpContext.Current.Response.Write("<TR>");

        HttpContext.Current.Response.Write("<Td colspan='4'>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(o.Sum(c => c.dTargetSavings)));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(o.Sum(c => c.dActualSavings)));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td colspan='9'>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("</TR>");

        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

}