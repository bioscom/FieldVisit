using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Forms_SEPCiN_Approval_Approved : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadMyApprovedRequests();
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
            int iActivityInfo = int.Parse(lbViewStatus.Attributes["ID_ACTIVITYINFO"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/PEC/Approval/approvalStatus.aspx?ActivityId=" + iActivityInfo);
        }
        else if (ButtonClicked == "report")
        {
            LinkButton lbReport = (LinkButton)grdView.Rows[index].FindControl("reportLinkButton");
            int iActivityId = int.Parse(lbReport.Attributes["ID_ACTIVITYINFO"].ToString());

            Response.Redirect("~/App/FieldVisit/Report/PECReport.aspx?ActivityId=" + iActivityId);
        }
    }

    private void LoadMyApprovedRequests()
    {
        DataTable dt = new DataTable();
        dt = PECApprover.dtPECRequestApproved((int)Approval.apprStatusRpt.Approved, oSessnx.getOnlineUser.m_iUserId);

        grdView.DataSource = dt;
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");

            TextBox txtStatusVST = (TextBox)grdRow.FindControl("txtStatusVST");
            TextBox txtStatusST = (TextBox)grdRow.FindControl("txtStatusST");
            TextBox txtStatusMT = (TextBox)grdRow.FindControl("txtStatusMT");

            int iActivityId = int.Parse(status.Attributes["ID_ACTIVITYINFO"].ToString());
            int iApprovalId = int.Parse(status.Attributes["ID_APPROVAL"].ToString());

            statusReporter.reportPECStatus(status, iActivityId, txtStatusVST, txtStatusST, txtStatusMT);
        }
    }
}
