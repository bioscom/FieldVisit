using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class UserControl_oRequestsPendingMyApproval : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    BI500Approval oBI500Approval = new BI500Approval();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    CostReductionRequest oBI500Request = new CostReductionRequest();
    BusinessLeanFocalPoints oBusinessLeanFocalPoints = new BusinessLeanFocalPoints();
    BuzLeanFocalPointHelper o = new BuzLeanFocalPointHelper();

    public void Page_Init()
    {
        if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.admin)
        {
            LoadPendingBrightIdeasRegister();
        }
        else if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.CorporateViewer)
        {
            LoadCorporatePendingBrightIdeasRegister(o.objGetBusinessUnitAssignedByUserId(oSessnx.getOnlineUser.m_iUserId).m_iFunctionId);
        }
        else
        {
            LoadBIPendingMyApprovalSupport(oSessnx.getOnlineUser);
        }

        oBI500RequestHelper.LoadYear(ddlYear);
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.CorporateViewer)
        {
            dt = oBI500RequestHelper.dtGetCorporatePendingBrightIdeasByYear(int.Parse(ddlYear.SelectedValue), o.objGetBusinessUnitAssignedByUserId(oSessnx.getOnlineUser.m_iUserId).m_iFunctionId);
        }
        else
        {
            dt = oBI500RequestHelper.dtGetRequestsPendingMyApprovalSupportByYear(oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlYear.SelectedValue));
        }
        grdGridView.DataSource = dt;
        grdGridView.DataBind();

        GridManager();
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

        if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.CorporateViewer)
            LoadCorporatePendingBrightIdeasRegister(o.objGetBusinessUnitAssignedByUserId(oSessnx.getOnlineUser.m_iUserId).m_iFunctionId);
        else
            LoadBIPendingMyApprovalSupport(oSessnx.getOnlineUser);
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

                Response.Redirect("~/App/BI500/ViewComments.aspx?RequestId=" + lRequestId);
            }
            //else if (ButtonClicked == "EditThisRequest")
            //{
            //    LinkButton lbEdit = (LinkButton)grdGridView.Rows[index].FindControl("EditLinkButton");
            //    long lRequestId = long.Parse(lbEdit.Attributes["IDREQUEST"].ToString());

            //    Response.Redirect("~/App/BI500/EdtBizIntel.aspx?RequestId=" + lRequestId);
            //}
            else if (ButtonClicked == "Report")
            {
                LinkButton lbReport = (LinkButton)grdGridView.Rows[index].FindControl("ReportLinkButton");
                long lRequestId = long.Parse(lbReport.Attributes["IDREQUEST"].ToString());

                Response.Redirect("~/App/BI500/Report/MainReport.aspx?lRequestId=" + lRequestId);
            }
            //else if (ButtonClicked == "Reroute")
            //{
            //    LinkButton lbReroute = (LinkButton)grdGridView.Rows[index].FindControl("RerouteLinkButton");
            //    long lRequestId = long.Parse(lbReroute.Attributes["IDREQUEST"].ToString());

            //    Response.Redirect("~/FlareRequestRouter.aspx?RequestId=" + lRequestId);
            //    //TODO: Complete the FlareRequestRouter.aspx page
            //}
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

    ////Loads Initiators Pending Requests
    //public void LoadMyPendingBrightIdeas(appUsers oAppUser)
    //{
    //    grdGridView.DataSource = oBI500RequestHelper.dtGetMyPendingRequests(oAppUser.m_iUserId);
    //    grdGridView.DataBind();        

    //    GridManager();
    //}

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

    public void LoadCorporatePendingBrightIdeasRegister(int iFunction)
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetCorporatePendingBrightIdeas(iFunction);
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

            LinkButton ActionLinkButton = (LinkButton)grdRow.FindControl("ActionLinkButton");
            Label labelStatus = (Label)grdRow.FindControl("labelStatus");
            ActionLinkButton.Enabled = false;
            lRequestId = long.Parse(ActionLinkButton.Attributes["IDREQUEST"].ToString());

            List<BI500Approval> lstApproval = oBI500ApprovalHelper.lstGetBIApprovalbyRequestId(lRequestId);
            foreach (BI500Approval oApproval in lstApproval)
            {
                if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport)
                {
                    if (oApproval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.champion)
                    {
                        ActionLinkButton.Enabled = true;
                    }
                }
                else if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval)
                {
                    if (oApproval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.sponsor)
                    {
                        ActionLinkButton.Enabled = true;
                    }
                }
                else if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport)
                {
                    //if (oApproval.m_iRoleIdBI == (int)appUsersRoles.userRole.sponsor)
                    //{
                    ActionLinkButton.Enabled = true;
                    //}
                }
                else if (int.Parse(labelStatus.Text) == (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval)
                {
                    //if (oApproval.m_iRoleIdBI == (int)appUsersRoles.userRole.sponsor)
                    //{
                    ActionLinkButton.Enabled = true;
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