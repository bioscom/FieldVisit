using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_approvedFieldVisitRequestsBySuperintendentApprover : aspnetUserControl
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
        grdView.PageIndex = e.NewPageIndex;
        loadApprovedSiteVisitRequestsByPlannerSponsor();
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
        System.Data.DataTable dt = new System.Data.DataTable();

        List<SuperintendentFunctionalAcctUser> MySuperintendents = SuperintendentFunctionalAcctUser.lstGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
        foreach (SuperintendentFunctionalAcctUser MySuperintendent in MySuperintendents)
        {
            if (MySuperintendent.superintendentId != 0)
            {
                //dt.Merge(fieldVisitDetails.dtApprovedFieldVisitDetailsBySuperintendent(MySuperintendent.superintendentEmail, oSessnx.getOnlineUser.m_sUserName));
                dt.Merge(fieldVisitDetails.dtApprovedFieldVisitBySuperintendent(MySuperintendent.superintendentId, (int)appUsersRoles.userRole.superintendent));
            }
        }

        grdView.DataSource = dt;
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);            
        }
    }

    private void loadApprovedSiteVisitRequestsBySuperintendent()
    {
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
