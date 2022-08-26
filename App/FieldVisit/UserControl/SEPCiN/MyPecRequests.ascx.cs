using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_MyPecRequests : aspnetUserControl
{
    public void InitPage()
    {
        loadMyPendingPECRequests();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
            int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

            if (ButtonClicked == "editThis")
            {
                LinkButton lbAction = (LinkButton)grdView.Rows[index].FindControl("editLinkButton");
                string iActivityId = lbAction.Attributes["ID_ACTIVITYINFO"].ToString();

                Response.Redirect("~/App/FieldVisit/Forms/PEC/edt/PECForm.aspx?ActivityId=" + iActivityId);
            }
            else if (ButtonClicked == "viwFieldDetails")
            {
                LinkButton lbFieldDetails = (LinkButton)grdView.Rows[index].FindControl("fieldDetailsLinkButton");
                long iActivity = long.Parse(lbFieldDetails.Attributes["ID_ACTIVITYINFO"].ToString());

            }
            else if (ButtonClicked == "viwStatus")
            {
                LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
                long iActivity = long.Parse(lbViewStatus.Attributes["ID_ACTIVITYINFO"].ToString());

                Response.Redirect("~/App/FieldVisit/Forms/PEC/Approval/approvalStatus.aspx?ActivityId=" + iActivity);
            }
            else if (ButtonClicked == "report")
            {
                LinkButton lbReport = (LinkButton)grdView.Rows[index].FindControl("reportLinkButton");
                string sActivity = lbReport.Attributes["ID_ACTIVITYINFO"].ToString();

                Response.Redirect("~/App/FieldVisit/Report/PECReport.aspx?ActivityId=" + sActivity);
            }
            else if (ButtonClicked == "thisDelete")
            {
                LinkButton lbDelete = (LinkButton)grdView.Rows[index].FindControl("lnkDelete");
                long iActivityInfo = long.Parse(lbDelete.Attributes["ID_ACTIVITYINFO"].ToString());

                ActivityInfo ThisActivity = ActivityInfo.objGetActivityInfoByActivityId(iActivityInfo);

                bool success = ActivityInfo.deleteActivityInfo(iActivityInfo, ThisActivity.m_iStatus);
                loadMyPendingPECRequests();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void loadMyPendingPECRequests()
    {
        try
        {
            grdView.DataSource = ActivityInfo.dtGetActivityInfoByOriginator(oSessnx.getOnlineUser.m_iUserId);
            grdView.DataBind();

            foreach (GridViewRow grdRow in grdView.Rows)
            {

                LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
                long iActivityId = long.Parse(status.Attributes["ID_ACTIVITYINFO"].ToString());
                TextBox txtStatusVST = (TextBox)grdRow.FindControl("txtStatusVST");
                TextBox txtStatusST = (TextBox)grdRow.FindControl("txtStatusST");
                TextBox txtStatusMT = (TextBox)grdRow.FindControl("txtStatusMT");

                statusReporter.reportPECStatus(status, iActivityId, txtStatusVST, txtStatusST, txtStatusMT);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
