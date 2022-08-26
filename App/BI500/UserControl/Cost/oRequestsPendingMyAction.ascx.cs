using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_BI500_UserControl_Cost_oRequestsPendingMyAction : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    BI500Approval oBI500Approval = new BI500Approval();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    CostReductionRequest oBI500Request = new CostReductionRequest();

    public void Page_Init()
    {
        LoadImprovementIdeaPendingMyApprovalSupport(oSessnx.getOnlineUser);
    }

    public void SearchResult(DataTable dt)
    {
        grdGridView.DataSource = dt;
        grdGridView.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) MPE.Show();
    }
        
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    
    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        LoadImprovementIdeaPendingMyApprovalSupport(oSessnx.getOnlineUser);
    }


    //This willbe used for action button
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton UpdateLinkButton = (LinkButton)row.FindControl("UpdateLinkButton");
                long lRequestId = long.Parse(UpdateLinkButton.Attributes["IDREQUEST"].ToString());

                //BrightIdeasFormEdt1.Init_Page(lRequestId);

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
        try
        {
            string ButtonClicked = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);

            if (ButtonClicked == "CancelRequest")
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

                WizardStep oWzrdStp = (WizardStep)Parent.FindControl("RequestDetails");
                UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)oWzrdStp.FindControl("oRequestDetails1");
                oReq.Init_Control(lRequestId);

                MultiView o = (MultiView)Parent.Parent;
                o.ActiveViewIndex = 3;
            }
            //Focal Point is assigned by Business Improvement Team
            else if (ButtonClicked == "AssignFocalPoint")
            {
                LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("AssignFocalPointLinkButton");
                long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

                WizardStep AssignFocalPoint = (WizardStep)Parent.FindControl("WizFocalPoint");
                UserControl_userFinder_Search4LocalUser FocalPoint = (UserControl_userFinder_Search4LocalUser)AssignFocalPoint.FindControl("FocalPoint");

                HiddenField HFRequestIdFP = (HiddenField)AssignFocalPoint.FindControl("HFRequestIdFP");
                HFRequestIdFP.Value = lRequestId.ToString();

                UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)AssignFocalPoint.FindControl("oRequestDetails3");
                oReq.Init_Control(lRequestId);

                FocalPoint.ErrorMssg("Focal Point is required. Please, select N/A if Focal Point not found, can be updated later.");

                FocalPoint.resetUserInfo();

                MultiView o = (MultiView)Parent.Parent;
                o.ActiveViewIndex = 4;
            }
            //Approvers are assigned by Focal Point after Credence review
            else if (ButtonClicked == "AssignApprovers")
            {
                LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("ViewStatusLinkButton");
                long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

                WizardStep AssignApprovers = (WizardStep)Parent.FindControl("AssignApprovers");

                UserControl_userFinder_Search4LocalUser InitiativeLead = (UserControl_userFinder_Search4LocalUser)AssignApprovers.FindControl("InitiativeLead");
                UserControl_userFinder_Search4LocalUser champion = (UserControl_userFinder_Search4LocalUser)AssignApprovers.FindControl("champion");
                UserControl_userFinder_Search4LocalUser Sponsor = (UserControl_userFinder_Search4LocalUser)AssignApprovers.FindControl("Sponsor");

                HiddenField HFRequestId2 = (HiddenField)AssignApprovers.FindControl("HFRequestId2");
                HFRequestId2.Value = lRequestId.ToString();

                UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)AssignApprovers.FindControl("oRequestDetails2");
                oReq.Init_Control(lRequestId);

                InitiativeLead.ErrorMssg("Initiative Lead is required. Please, select N/A if Initiative Lead not found, can be updated later.");
                champion.ErrorMssg("Work Stream Owner is required. Please, select N/A if Work Stream Owner not found, can be updated later.");
                Sponsor.ErrorMssg("Work Stream Sponsor is required. Please, select N/A if Sponsor not found, can be updated later.");

                InitiativeLead.resetUserInfo();
                champion.resetUserInfo();
                Sponsor.resetUserInfo();

                MultiView o = (MultiView)Parent.Parent;
                o.ActiveViewIndex = 5;
            }
            // This is the action by Work Stream Sponsor (WSS) and Work Stream Owner (WSO)
            else if (ButtonClicked == "Action")
            {
                LinkButton lbAction = (LinkButton)grdGridView.Rows[index].FindControl("ActionLinkButton");
                long lRequestId = long.Parse(lbAction.Attributes["IDREQUEST"].ToString());

                WizardStep ProjMgrsCommitment = (WizardStep)Parent.FindControl("ProjMgrsCommitment");
                HiddenField HFRequestIdToProjChamp = (HiddenField)ProjMgrsCommitment.FindControl("HFRequestIdProjCommitment");
                HFRequestIdToProjChamp.Value = lRequestId.ToString();

                UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)ProjMgrsCommitment.FindControl("oRequestDetailsprojCommit");
                oReq.Init_Control(lRequestId);

                MultiView o = (MultiView)Parent.Parent;
                o.ActiveViewIndex = 6;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkMilestone_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton MilestoneLinkButton = (LinkButton)row.FindControl("MilestoneLinkButton");
                long lRequestId = long.Parse(MilestoneLinkButton.Attributes["IDREQUEST"].ToString());

                //Phasing.Init_Page(lRequestId);
                oCadenceReporting.LoadCadenceByRequestId(lRequestId);

                //oMilestones.LoadMilestoneByRequestId(lRequestId);

                MPE.Show();
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

    //Loads Improvement Ideas Pending anybody's approval
    public void LoadImprovementIdeaPendingMyApprovalSupport(appUsers oAppUser)
    {
        DataTable dt = new DataTable();
        bool bRet = BuzBILeanReviewers.dtGetBILeanReviewerByUserId(oAppUser.m_iUserId).Rows.Count > 0;
        if (bRet)
        {
            dt = oBI500RequestHelper.dtGetImprovementIdeasPendingBITeamSupport();
            dt.Merge(oBI500RequestHelper.dtGetImprovementIdeasPendingMyAction(oAppUser.m_iUserId));
        }
        else
        {
            dt = oBI500RequestHelper.dtGetImprovementIdeasPendingMyAction(oAppUser.m_iUserId);
        }

        grdGridView.DataSource = dt;
        grdGridView.DataBind();

        RoleManager();
        GridManager();
    }

    private void RoleManager()
    {
        try
        {
            foreach (GridViewRow grdRow in grdGridView.Rows)
            {
                Label labelFocalPoint = (Label)grdRow.FindControl("labelFocalPoint");
                Label labelChampion = (Label)grdRow.FindControl("labelChampion");
                Label lblSponsor = (Label)grdRow.FindControl("lblSponsor");

                Label labelStatus = (Label)grdRow.FindControl("labelStatus");
                int iStatus = string.IsNullOrEmpty(labelStatus.Attributes["STATUS"].ToString()) ? 0 : int.Parse(labelStatus.Attributes["STATUS"].ToString());

                LinkButton AssignFocalPointLinkButton = (LinkButton)grdRow.FindControl("AssignFocalPointLinkButton");
                LinkButton AssignApproversLinkButton = (LinkButton)grdRow.FindControl("AssignApproversLinkButton");
                LinkButton ActionLinkButton = (LinkButton)grdRow.FindControl("ActionLinkButton");
                LinkButton CadenceLinkButton = (LinkButton)grdRow.FindControl("MilestoneLinkButton");

                AssignFocalPointLinkButton.Visible = false;
                AssignApproversLinkButton.Visible = false;
                ActionLinkButton.Visible = false;
                CadenceLinkButton.Visible = false;

                if (iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport)
                    AssignFocalPointLinkButton.Visible = true;
                else if (iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction)
                    AssignApproversLinkButton.Visible = true;
                else if ((iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval) || (iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport))
                    ActionLinkButton.Visible = true;
                else if (iStatus == (int)BIRequestStatus.RequestStatusRpt.InitiativeLead)
                    CadenceLinkButton.Visible = true;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
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
            //ActionLinkButton.Visible = false;
            //lRequestId = long.Parse(ActionLinkButton.Attributes["IDREQUEST"].ToString());

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
}