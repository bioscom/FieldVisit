using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_SEPCiN_AllPECRequestsApproved : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void InitPage()
    {
        LoadApprovedRequests();
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        LoadApprovedRequests();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
            int iActivityInfo = int.Parse(lbViewStatus.Attributes["ID_ACTIVITYINFO"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/PEC/Approval/approvalStatus.aspx?ActivityInfoId=" + iActivityInfo);
        }
        else if (ButtonClicked == "report")
        {
            LinkButton lbReport = (LinkButton)grdView.Rows[index].FindControl("reportLinkButton");
            int iActivityId = int.Parse(lbReport.Attributes["ID_ACTIVITYINFO"].ToString());

            Response.Redirect("~/App/FieldVisit/Report/PECReport.aspx?ActivityId=" + iActivityId);
        }
    }

    private void LoadApprovedRequests()
    {
        DataTable dt = new DataTable();
        dt = PECApprover.dtPECRequestApproved();

        grdView.DataSource = dt;
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");

            TextBox txtStatusVST = (TextBox)grdRow.FindControl("txtStatusVST");
            TextBox txtStatusST = (TextBox)grdRow.FindControl("txtStatusST");
            TextBox txtStatusMT = (TextBox)grdRow.FindControl("txtStatusMT");

            int iActivityId = int.Parse(status.Attributes["ID_ACTIVITYINFO"].ToString());

            statusReporter.reportPECStatus(status, iActivityId, txtStatusVST, txtStatusST, txtStatusMT);
        }
    }
}