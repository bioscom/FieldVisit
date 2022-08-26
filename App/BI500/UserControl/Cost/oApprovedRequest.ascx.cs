using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_BI500_UserControl_Cost_oApprovedRequest : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    public void Page_Init()
    {
        grdGridView.DataSource = oBI500RequestHelper.dtGetApprovedImprovementIdeas();
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
        //if (IsPostBack)
           // MPE.Show();
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

        grdGridView.DataSource = oBI500RequestHelper.dtGetApprovedRequests();
        grdGridView.DataBind();

        GridManager();
    }

    protected void lnkPhase_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton PhaseLinkButton = (LinkButton)row.FindControl("PhaseLinkButton");
                long lRequestId = long.Parse(PhaseLinkButton.Attributes["IDREQUEST"].ToString());

                Phasing.Init_Page(lRequestId);

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
        ////try
        ////{
        //string ButtonClicked = e.CommandName;
        //int index = Convert.ToInt32(e.CommandArgument);

        //if (ButtonClicked == "Phasing")
        //{
        //    LinkButton lbViewStatus = (LinkButton)grdGridView.Rows[index].FindControl("PhaseLinkButton");
        //    long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

        //    Response.Redirect("~/App/BI500/Phasing.aspx?RequestId=" + lRequestId);
        //}

        ////}
        ////catch (Exception ex)
        ////{
        ////    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        ////}


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
            //Label labelInitiator = (Label)grdRow.FindControl("labelInitiator");
            //LinkButton PhaseLinkButton = (LinkButton)grdRow.FindControl("PhaseLinkButton");

            BIRequestStatus.reportMyStatus(labelStatus);
            //BIRequestStatus.reportBrightIdeaPhase(PhaseLinkButton);

            //if (int.Parse(labelInitiator.Attributes["USERID"].ToString()) != oSessnx.getOnlineUser.m_iUserId)
            //{
                ///PhaseLinkButton.Enabled = false;
            //}
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