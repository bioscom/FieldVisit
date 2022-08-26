using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_FieldVisit_Forms_FieldVisit_eSearch : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        DataTable dt = fieldVisitDetails.dtFieldVisitDetailsByRequestNumber(txtRequest.Text.ToUpper());

        if (dt.Rows.Count > 0)
        {
            grdView.DataSource = dt;
            grdView.DataBind();

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
                statusReporter.reportMyStatus(status);
            }
        }
        else if (LoadPECRequestsByRequestNumber(txtRequest.Text.ToUpper()) > 0)
        {
            
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, txtRequest.Text.ToUpper() + " Request not found!!! Type the Request Number properly or ensure you have the correct Request Number.");
        }
    }

    //public void InitPage()
    //{
    //    loadMyApprovedSiteVisitRequests();
    //}
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

    private void loadMyApprovedSiteVisitRequests()
    {
        grdView.DataSource = fieldVisitDetails.dtApprovedFieldVisitDetailsByInitiator(oSessnx.getOnlineUser.m_iUserId);
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");

            statusReporter.reportMyStatus(status);
        }
    }

    public int LoadPECRequestsByRequestNumber(string sRequestNumber)
    {
        int iRowsReturned = 0;
        DataTable dt = PECApprover.dtPECRequestByRequestNumber(sRequestNumber);
        iRowsReturned = dt.Rows.Count;

        grdPEC.DataSource = dt;
        grdPEC.DataBind();

        foreach (GridViewRow grdRow in grdPEC.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");

            TextBox txtStatusVST = (TextBox)grdRow.FindControl("txtStatusVST");
            TextBox txtStatusST = (TextBox)grdRow.FindControl("txtStatusST");
            TextBox txtStatusMT = (TextBox)grdRow.FindControl("txtStatusMT");

            int iActivityId = int.Parse(status.Attributes["ID_ACTIVITYINFO"].ToString());

            statusReporter.reportPECStatus(status, iActivityId, txtStatusVST, txtStatusST, txtStatusMT);
        }

        return iRowsReturned;
    }

    protected void grdPEC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        //LoadApprovedRequests();
    }
    protected void grdPEC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdPEC.Rows[index].FindControl("statusLinkButton");
            int iActivityInfo = int.Parse(lbViewStatus.Attributes["ID_ACTIVITYINFO"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/PEC/Approval/approvalStatus.aspx?ActivityInfoId=" + iActivityInfo);
        }
        else if (ButtonClicked == "report")
        {
            LinkButton lbReport = (LinkButton)grdPEC.Rows[index].FindControl("reportLinkButton");
            int iActivityId = int.Parse(lbReport.Attributes["ID_ACTIVITYINFO"].ToString());

            Response.Redirect("~/App/FieldVisit/Report/PECReport.aspx?ActivityId=" + iActivityId);
        }
    }
}