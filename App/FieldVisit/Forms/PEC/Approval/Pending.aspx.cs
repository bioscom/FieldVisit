using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Forms_SEPCiN_Approval_Pending : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadMyPendingRequestsForApproval();
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "Action")
        {
            LinkButton lbAction = (LinkButton)grdView.Rows[index].FindControl("actionLinkButton");
            int iActivityInfo = int.Parse(lbAction.Attributes["ID_ACTIVITYINFO"].ToString());
            int iApproval = int.Parse(lbAction.Attributes["ID_APPROVAL"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/PEC/Approval/Default.aspx?ActivityInfoId=" + iActivityInfo + "&ApprovalId=" + iApproval);
        }
        else if (ButtonClicked == "viwStatus")
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

    private void LoadMyPendingRequestsForApproval()
    {
        DataTable dt = new DataTable();
        //if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.sponsor)
        //    dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.Sponsor, oSessnx.getOnlineUser.m_iUserId);

        //else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.FunctionalLead)
        //    dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.FunctionalLead, oSessnx.getOnlineUser.m_iUserId);

        //else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.planner)
        //    dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.AssetPlanner, oSessnx.getOnlineUser.m_iUserId);

        //else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.AssetOperationsManager)
        //    dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.AssetOperationsManager, oSessnx.getOnlineUser.m_iUserId);

        //else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.superintendent)
        //    dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.FunctionalLead, oSessnx.getOnlineUser.m_iUserId);

        //This will allow anybody to be selected for any role and can approve at any role without looking at the role into which the user was registered into

        dt.Merge(PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.Sponsor, oSessnx.getOnlineUser.m_iUserId));
        dt.Merge(PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.FunctionalLead, oSessnx.getOnlineUser.m_iUserId));
        dt.Merge(PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.AssetPlanner, oSessnx.getOnlineUser.m_iUserId));
        dt.Merge(PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.AssetOperationsManager, oSessnx.getOnlineUser.m_iUserId));
        dt.Merge(PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.FunctionalLead, oSessnx.getOnlineUser.m_iUserId));

        grdView.DataSource = dt;
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            LinkButton Action = (LinkButton)grdRow.FindControl("actionLinkButton");

            int iActivityId = int.Parse(Action.Attributes["ID_ACTIVITYINFO"].ToString());
            int iApprovalId = int.Parse(Action.Attributes["ID_APPROVAL"].ToString());

            TextBox txtStatusVST = (TextBox)grdRow.FindControl("txtStatusVST");
            TextBox txtStatusST = (TextBox)grdRow.FindControl("txtStatusST");
            TextBox txtStatusMT = (TextBox)grdRow.FindControl("txtStatusMT");

            statusReporter.reportPECStatus(status, Action, iActivityId, iApprovalId, oSessnx.getOnlineUser.m_iUserId, txtStatusVST, txtStatusST, txtStatusMT);
        }
    }
}