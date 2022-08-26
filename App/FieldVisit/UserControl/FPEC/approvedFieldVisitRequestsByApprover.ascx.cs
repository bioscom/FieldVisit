using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_approvedFieldVisitRequestsByApprover : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitPage()
    {
        //loadApprovedSiteVisitRequests();
        loadApprovedSiteVisitRequestsByPlannerSponsor();
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
        //GridView gv = (GridView)(e.CommandSource);

        //int iActivity = int.Parse(gv.DataKeys[row.RowIndex]["ID_ACTIVITIES"].ToString());

        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "viwFieldDetails")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("fieldDetailsLinkButton");
            int iActivity = int.Parse(lbViewStatus.Attributes["ID_ACTIVITIES"].ToString());

            //loadFieldVisitDetailsByActivity(iActivity);
        }
        else if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
            int iActivity = int.Parse(lbViewStatus.Attributes["ID_ACTIVITIES"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/fieldVisitApprovalStatus.aspx?ActivityId=" + iActivity);
        }
        else if (ButtonClicked == "report")
        {
            LinkButton lbReport = (LinkButton)grdView.Rows[index].FindControl("reportLinkButton");
            int iActivity = int.Parse(lbReport.Attributes["ID_ACTIVITIES"].ToString());

            Response.Redirect("~/App/FieldVisit/Report/FieldEntryRpt.aspx?ActivityId=" + iActivity);
        }
    }

    private void loadApprovedSiteVisitRequestsByPlannerSponsor()
    {
        grdView.DataSource = fieldVisitDetails.dtApprovedFieldVisitByApprover(oSessnx.getOnlineUser.m_iUserId, oSessnx.getOnlineUser.m_iRoleIdFieldVisit);
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }

    private void loadApprovedSiteVisitRequestsBySuperintendent()
    {
        //TODO: Please come back here
        //SuperintendentFunctionalAcctUser manOnTheField = SuperintendentFunctionalAcctUserAccess.objGetSuperintendentFunctionalAcctByUserName(oSessnx.getOnlineUser.m_sUserName);
        //grdView.DataSource = fieldVisitDetails.dtApprovedFieldVisitDetailsBySuperintendent(manOnTheField.superintendentEmail, oSessnx.getOnlineUser.m_sUserName);
        //grdView.DataBind();

        //foreach (GridViewRow grdRow in grdView.Rows)
        //{
        //    Label status = (Label)grdRow.FindControl("labelStatus");

        //    statusReporter.reportMyStatus(status);
        //}
    }
}
