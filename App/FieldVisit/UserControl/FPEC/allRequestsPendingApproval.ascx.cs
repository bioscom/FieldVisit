using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_allRequestsPendingApproval : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitPage()
    {
        loadFieldVisitRequestsPendingApproval();
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

        //if (ButtonClicked == "editThis")
        //{
        //    LinkButton lbEdit = (LinkButton)grdView.Rows[index].FindControl("editLinkButton");
        //    int iActivity = int.Parse(lbEdit.Attributes["ID_ACTIVITIES"].ToString());

        //    Response.Redirect("~/edtActivityForm.aspx?ActivityId=" + iActivity);
        //}

        //else if (ButtonClicked == "viwFieldDetails")
        //{
        //    LinkButton lbFieldDetails = (LinkButton)grdView.Rows[index].FindControl("fieldDetailsLinkButton");
        //    int iActivity = int.Parse(lbFieldDetails.Attributes["ID_ACTIVITIES"].ToString());

        //    loadFieldVisitDetailsByActivity(iActivity);
        //    loadQuestionaires();
        //}
        if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
            int iActivity = int.Parse(lbViewStatus.Attributes["ID_ACTIVITIES"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/fieldVisitApprovalStatus.aspx?ActivityId=" + iActivity);
        }
    }

    private void loadFieldVisitRequestsPendingApproval()
    {
        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsPendingApproval();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");

            statusReporter.reportMyStatus(status);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton)row.FindControl("deleteLinkButton");
        long lActivityId = long.Parse(lnkDelete.Attributes["ID_ACTIVITIES"].ToString());
        int iStatus = int.Parse(lnkDelete.Attributes["STATUS"].ToString());

        fieldVisitDetails oFieldVisitDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(lActivityId);

        fieldVisit.UpdateFieldVisitRequestPreStatus(lActivityId, oFieldVisitDetails.m_iStatus);
        bool success = fieldVisit.DeleteFieldVisitRequest(lActivityId); //appUsersHelper.disableUserAccount(userID);
        if (success)
        {
            loadFieldVisitRequestsPendingApproval();
            ajaxWebExtension.showJscriptAlert(Page, this, oFieldVisitDetails.m_sActivityId + " successfully deleted.");
        }
    }
}
