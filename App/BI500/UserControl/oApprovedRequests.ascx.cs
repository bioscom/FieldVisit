using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class App_BI500_UserControl_oApprovedRequests : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    public void Init_Page()
    {
        
    }

    public void SearchResult(DataTable dt)
    {
        grdGridView.DataSource = dt;
        grdGridView.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void handOverButton_Click(object sender, EventArgs e)
    {

    }

    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }

    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.admin)
            LoadApprovedBrightIdeasRegister();
        else
            LoadBIApprovedRequests(oSessnx.getOnlineUser);
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

            Response.Redirect("~/App/BI500/ViewComments.aspx?RequestId=" + lRequestId);
        }
        else if (ButtonClicked == "Phasing")
        {
            LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("PhaseLinkButton");
            long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

            Response.Redirect("~/App/BI500/Phasing.aspx?RequestId=" + lRequestId);
        }
        else if (ButtonClicked == "Report")
        {
            LinkButton lbReport = (LinkButton)grdGridView.Rows[index].FindControl("ReportLinkButton");
            long lRequestId = long.Parse(lbReport.Attributes["IDREQUEST"].ToString());

            Response.Redirect("~/App/BI500/Report/MainReport.aspx?lRequestId=" + lRequestId);
        }
        else if (ButtonClicked == "Reroute")
        {
            //LinkButton lbReroute = (LinkButton)grdGridView.Rows[index].FindControl("RerouteLinkButton");
            //long lRequestId = long.Parse(lbReroute.Attributes["IDREQUEST"].ToString());

            //Response.Redirect("~/FlareRequestRouter.aspx?RequestId=" + lRequestId);
        }
        else if (ButtonClicked == "AuditTrail")
        {
            //LinkButton lbAuditTrail = (LinkButton)grdGridView.Rows[index].FindControl("AuditTrailLinkButton");
            //long lRequestId = long.Parse(lbAuditTrail.Attributes["IDREQUEST"].ToString());

            //Response.Redirect("~/FlareRequestApprovalAudit.aspx?RequestId=" + lRequestId);
        }
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }

    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void LoadMyBrightIdeasApproved(appUsers oAppUser)
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetMyApprovedRequests(oAppUser.m_iUserId);
        grdGridView.DataBind();

        GridManager();
    }

    public void LoadBIRequestsIApprovedOrSupported(appUsers oAppUser)
    {
        DataTable dt = oBI500RequestHelper.dtGetRequestsIApprovedSupportedOrRejected(oAppUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Approved);
        dt.Merge(oBI500RequestHelper.dtGetRequestsIApprovedSupportedOrRejected(oAppUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Supported));
        grdGridView.DataSource = dt;
        grdGridView.DataBind();

        GridManager();
    }

    //public void LoadBIRequestsISupported(appUsers oAppUser)
    //{
    //    grdGridView.DataSource = oBI500RequestHelper.dtGetRequestsIApprovedSupportedOrRejected(oAppUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Supported);
    //    grdGridView.DataBind();

    //    GridManager();
    //}

    public void LoadBIApprovedRequests(appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.focalPoint)
        {
            DataTable dt = oBI500RequestHelper.dtGetBrightIdeaApprovedForLeanFocalPoint(oAppUser.m_iUserId);
            grdGridView.DataSource = dt;
            grdGridView.DataBind();
        }
        else if (oAppUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.BusinessImprovementTeam)
        {
            DataTable dt = oBI500RequestHelper.dtGetBITeamSupportedBrightIdeas();
            grdGridView.DataSource = dt;
            grdGridView.DataBind();
        }
        else
        {
            grdGridView.DataSource = oBI500RequestHelper.dtGetMyApprovedRequests(oAppUser.m_iUserId);
            grdGridView.DataBind();
        }

        GridManager();
    }

    public void LoadApprovedBrightIdeasRegister()
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetApprovedBrightIdeas();
        grdGridView.DataBind();

        GridManager();
    }

    private void GridManager()
    {
        foreach (GridViewRow grdRow in grdGridView.Rows)
        {
            Label labelStatus = (Label)grdRow.FindControl("labelStatus");
            Label labelInitiator = (Label)grdRow.FindControl("labelInitiator");
            LinkButton PhaseLinkButton = (LinkButton)grdRow.FindControl("PhaseLinkButton");

            BIRequestStatus.reportMyStatus(labelStatus);
            BIRequestStatus.reportBrightIdeaPhase(PhaseLinkButton);

            if (int.Parse(labelInitiator.Attributes["USERID"].ToString()) != oSessnx.getOnlineUser.m_iUserId)
            {
                PhaseLinkButton.Enabled = false;
            }
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