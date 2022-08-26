using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_SEPCiN_AllPECRequestsPendingApproval : aspnetUserControl
{
    public void Page_Init()
    {
        LoadRequestsPendingApproval();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        LoadRequestsPendingApproval();
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
            string sActivity = lbReport.Attributes["ID_ACTIVITYINFO"].ToString();

            Response.Redirect("~/App/FieldVisit/Report/PECReport.aspx?ActivityId=" + sActivity);
        }

    }

    private void LoadRequestsPendingApproval()
    {
        DataTable dt = new DataTable();

        dt = PECApprover.dtPECRequestPendingApproval();

        grdView.DataSource = dt;
        grdView.DataBind();

        if (dt.Rows.Count == 0)
        {
            //lblMssg.Text = "No record found.";
        }

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            //LinkButton Action = (LinkButton)grdRow.FindControl("actionLinkButton");

            //int iActivityId = int.Parse(Action.Attributes["ID_ACTIVITYINFO"].ToString());
            //int iApprovalId = int.Parse(Action.Attributes["ID_APPROVAL"].ToString());

            TextBox txtStatusVST = (TextBox)grdRow.FindControl("txtStatusVST");
            TextBox txtStatusST = (TextBox)grdRow.FindControl("txtStatusST");
            TextBox txtStatusMT = (TextBox)grdRow.FindControl("txtStatusMT");

            statusReporter.reportPECStatus(status, oSessnx.getOnlineUser.m_iUserId, txtStatusVST, txtStatusST, txtStatusMT); //Action, iActivityId, iApprovalId, 
        }
    }
}