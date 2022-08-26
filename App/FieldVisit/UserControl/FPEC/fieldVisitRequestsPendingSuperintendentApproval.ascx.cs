using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class UserControl_fieldVisitRequestsPendingSuperintendentApproval : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitPage()
    {
        loadSiteVisitRequestsPendingMyApproval();
        detailsPanel.Visible = false;
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

        if (ButtonClicked == "Action")
        {
            LinkButton lbAction = (LinkButton)grdView.Rows[index].FindControl("actionLinkButton");
            int iActivity = int.Parse(lbAction.Attributes["ID_ACTIVITIES"].ToString());
            int iApproval = int.Parse(lbAction.Attributes["ID_APPROVAL"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/Signoff/Default.aspx?ActivityId=" + iActivity + "&ApprovalId=" + iApproval);
        }
        else if (ButtonClicked == "viwFieldDetails")
        {
            LinkButton lbFieldDetails = (LinkButton)grdView.Rows[index].FindControl("fieldDetailsLinkButton");
            int iActivity = int.Parse(lbFieldDetails.Attributes["ID_ACTIVITIES"].ToString());

            loadFieldVisitDetailsByActivity(iActivity);
            //loadQuestionaires();
            FieldVisitQuestionaire1.loadQuestionaires();
            FieldVisitQuestionaire1.loadFieldVisitDetailsByActivity(iActivity);
           
        }
        else if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
            int iActivity = int.Parse(lbViewStatus.Attributes["ID_ACTIVITIES"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/fieldVisitApprovalStatus.aspx?ActivityId=" + iActivity);
        }
    }

    private void loadSiteVisitRequestsPendingMyApproval()
    {
        System.Data.DataTable dt = new System.Data.DataTable();

        List<SuperintendentFunctionalAcctUser> MySuperintendents = SuperintendentFunctionalAcctUser.lstGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
        foreach (SuperintendentFunctionalAcctUser MySuperintendent in MySuperintendents)
        {
            if (MySuperintendent.superintendentId != 0)
            {
                dt.Merge(fieldVisitDetails.dtPendingFieldVisitBySuperintendent(MySuperintendent.superintendentId, (int)appUsersRoles.userRole.superintendent));
            }
        }

        grdView.DataSource = dt;
        grdView.DataBind();

        if (dt.Rows.Count == 0)
        {
            lblMssg.Text = "No record found.";
        }

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            LinkButton Action = (LinkButton)grdRow.FindControl("actionLinkButton");

            int iActivityId = int.Parse(Action.Attributes["ID_ACTIVITIES"].ToString());
            int iApprovalId = int.Parse(Action.Attributes["ID_APPROVAL"].ToString());

            statusReporter.reportMyStatus(status, Action, iActivityId, iApprovalId, oSessnx.getOnlineUser.m_iUserId);   
        }
    }

    private void loadFieldVisitDetailsByActivity(int iActivity)
    {
        detailsPanel.Visible = true;
        fieldVisitDetails visitDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivity);
        facility xFacility = facility.objGetFacilityById(visitDetails.m_iFacilityId);
        District xDistrict = District.objGetDistrictById(xFacility.m_iDistrictId);
        Superintendent xSuperintendent = Superintendent.objGetSuperintendentById(xDistrict.m_iSuperintendentId);

        activityIDLabel.Text = Encoder.HtmlEncode(visitDetails.m_sActivityId);
        taskDescriptionLabel.Text = Encoder.HtmlEncode(visitDetails.m_sTaskDescription);
        fromDateLabel.Text = Encoder.HtmlEncode(visitDetails.m_sDateFrom);
        toDateLabel.Text = Encoder.HtmlEncode(visitDetails.m_sDateTo);
        fieldLabel.Text = Encoder.HtmlEncode(xFacility.m_sFacility);
        acctToChargeLabel.Text = Encoder.HtmlEncode(visitDetails.m_sAccountToCharge);
        districtLabel.Text = Encoder.HtmlEncode(xDistrict.m_sDistrict);
        superintendentLabel.Text = Encoder.HtmlEncode(xSuperintendent.m_sSuperintendent);
    }
}
