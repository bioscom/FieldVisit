using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Microsoft.Security.Application;

public partial class UserControl_Cost_oMyPendingRequests : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    BI500Approval oBI500Approval = new BI500Approval();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    CostReductionRequest oBI500Request = new CostReductionRequest();

    public void Page_Init()
    {
        LoadMyPendingImprovementIdeas(oSessnx.getOnlineUser);
        //LoadBIPendingRequests(oSessnx.getOnlineUser);
    }

    public void SearchResult(DataTable dt)
    {
        grdGridView.DataSource = dt;
        grdGridView.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    //protected void lnkJan_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["RequestId"].ToString()));
    //        oRequestDetails.Init_Control(oBI500RequestHelper.objGetBrightIdeaById(lRequestId));

    //        GridView test = (GridView)oMyPendingRequests1.FindControl("grdGridView");

    //        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
    //        {
    //            int iYear = DateTime.Now.Year;
    //            LinkButton lnkJan = (LinkButton)row.FindControl("lnkJan");
    //            Label labelFacilities = (Label)row.FindControl("labelFacilities");
    //            string sFacility = labelFacilities.Text;
    //            string sCode = lnkJan.Attributes["CODE"].ToString();
    //            int iMonth = 01;
    //            decimal dFlareTarget = decimal.Parse(lnkJan.Text);


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}
        
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    
    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        LoadMyPendingImprovementIdeas(oSessnx.getOnlineUser);
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

    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //Loads Initiators Pending Requests
    public void LoadMyPendingImprovementIdeas(appUsers oAppUser)
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetMyPendingImprovementIdeas(oAppUser.m_iUserId);
        grdGridView.DataBind();        

        GridManager();
    }

    //Loads Bright Ideas Pending anybody's approval approval
    public void LoadBIPendingMyApprovalSupport(appUsers oAppUser)
    {
        DataTable dt = new DataTable();
        //if this user is found in the list of the BI/Lean Approvers 
        //To determine if the login user has right to perform BI/Lean approval role
        //BuzBILeanReviewers.objGetBILeanReviewerByUserId(oAppUser.m_iUserId);
        bool bRet = BuzBILeanReviewers.dtGetBILeanReviewerByUserId(oAppUser.m_iUserId).Rows.Count > 0;
        if(bRet)
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

    //public void HideActionLinkColumn()
    //{
    //    grdGridView.Columns[1].Visible = false;
    //}

    //public void HideEditLinkColumn()
    //{
    //    grdGridView.Columns[14].Visible = false;
    //}

    //public void HideShowColumns(int iToken)
    //{
    //    if (iToken == 1)
    //    {
    //        grdGridView.Columns[1].Visible = true;
    //        grdGridView.Columns[14].Visible = false;
    //    }
    //    else 
    //    {
    //        grdGridView.Columns[1].Visible = false;
    //        //grdGridView.Columns[2].Visible = false;
    //        grdGridView.Columns[14].Visible = true;
    //    }
    //}

    public GridView oGrdGridView
    {
        get
        {
            GridView grdView = (GridView)grdGridView;
            return grdView;
        }
    }
}