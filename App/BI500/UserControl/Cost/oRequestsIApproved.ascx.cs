using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_BI500_UserControl_Cost_oRequestsIApproved : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            MPE.Show();
    }

    public void Page_Init()
    {
        LoadImprovementIdeasIApprovedOrSupported(oSessnx.getOnlineUser);
    }

    protected void lnkReroute_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton RerouteLinkButton = (LinkButton)row.FindControl("RerouteLinkButton");
                long lRequestId = long.Parse(RerouteLinkButton.Attributes["IDREQUEST"].ToString());

                _Reroute1.Init_Page(lRequestId);

                MPE.Show();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void SearchResult(DataTable dt)
    {
        grdGridView.DataSource = dt;
        grdGridView.DataBind();
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

        LoadImprovementIdeasIApprovedOrSupported(oSessnx.getOnlineUser);

        //grdGridView.DataSource = oBI500RequestHelper.dtGetApprovedRequests();
        //grdGridView.DataBind();

        //GridManager();
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

        if (ButtonClicked == "ViewStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("ViewStatusLinkButton");
            long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

            WizardStep oWzrdStp = (WizardStep)this.Parent.FindControl("RequestDetails");
            UserControl_Cost_oRequestDetails oReq = (UserControl_Cost_oRequestDetails)oWzrdStp.FindControl("oRequestDetails1");
            oReq.Init_Control(lRequestId);

            MultiView o = (MultiView)this.Parent.Parent;
            o.ActiveViewIndex = 3;
        }       
        else if (ButtonClicked == "Report")
        {
            LinkButton lbReport = (LinkButton)grdGridView.Rows[index].FindControl("ReportLinkButton");
            long lRequestId = long.Parse(lbReport.Attributes["IDREQUEST"].ToString());

            //Response.Redirect("~/App/BI500/Report/MainReport.aspx?lRequestId=" + lRequestId);
        }
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

    public void LoadImprovementIdeasIApprovedOrSupported(appUsers oAppUser)
    {
        DataTable dt = oBI500RequestHelper.dtGetImprovementIdeasIApprovedSupportedOrRejected(oAppUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Approved);
        dt.Merge(oBI500RequestHelper.dtGetImprovementIdeasIApprovedSupportedOrRejected(oAppUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Supported));

        bool bRet = BuzBILeanReviewers.dtGetBILeanReviewerByUserId(oAppUser.m_iUserId).Rows.Count > 0;
        if (bRet)
        {
            dt = oBI500RequestHelper.dtGetImprovementIdeasSupportedByBI();
        }

        grdGridView.DataSource = dt;
        grdGridView.DataBind();

        GridManager();
    }

    private void GridManager()
    {
        foreach (GridViewRow grdRow in grdGridView.Rows)
        {
            Label labelStatus = (Label)grdRow.FindControl("labelStatus");
            Label labelInitiator = (Label)grdRow.FindControl("labelInitiator");

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