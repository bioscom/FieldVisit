using System;
using System.Web.UI.WebControls;
using CS.BLL.PPMS;

public partial class App_PPMS_Search : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["IdNo"]))
            {
                grdGridView.DataSource = ActionTrackerRegisterHelper.DtGetProjectByActionTitle(Request.QueryString["IdNo"]);
                grdGridView.DataBind();

                ActionTrackerRegisterHelper.ManageReport(grdGridView);
            }
        }
    }

    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }

    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;

        grdGridView.DataSource = ActionTrackerRegisterHelper.DtGetProjectByActionTitle(Request.QueryString["IdNo"]);
        grdGridView.DataBind();

        ActionTrackerRegisterHelper.ManageReport(grdGridView);
    }

    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName;
        int index = Convert.ToInt32(e.CommandArgument);
        bool bRet = false;

        if (ButtonClicked == "EditThisRequest")
        {
            LinkButton lbEdit = (LinkButton)grdGridView.Rows[index].FindControl("EditLinkButton");
            var lActionId = long.Parse(lbEdit.Attributes["ACTIONID"]);

            Response.Redirect("~/App/PPMS/EditActionTrackerForm.aspx?ActionId=" + lActionId);
        }
    }

    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}