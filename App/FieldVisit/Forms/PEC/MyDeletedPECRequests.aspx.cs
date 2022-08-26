using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_SEPCiN_MyDeletedPECRequests : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadMyDeletedPECRequests();
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //try
        //{
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "viwFieldDetails")
        {
            LinkButton lbFieldDetails = (LinkButton)grdView.Rows[index].FindControl("fieldDetailsLinkButton");
            int iActivity = int.Parse(lbFieldDetails.Attributes["ID_ACTIVITYINFO"].ToString());
            
        }
        else if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
            int iActivity = int.Parse(lbViewStatus.Attributes["ID_ACTIVITYINFO"].ToString());

            Response.Redirect("~/Forms/PEC/Approval/approvalStatus.aspx?ActivityInfoId=" + iActivity);
        }
        else if (ButtonClicked == "report")
        {
            LinkButton lbReport = (LinkButton)grdView.Rows[index].FindControl("reportLinkButton");
            string sActivity = lbReport.Attributes["ID_ACTIVITYINFO"].ToString();

            Response.Redirect("~/Report/PECReport.aspx?ActivityId=" + sActivity);
        }
        else if (ButtonClicked == "thisDelete")
        {
            LinkButton lbDelete = (LinkButton)grdView.Rows[index].FindControl("lnkDelete");
            int iActivityInfo = int.Parse(lbDelete.Attributes["ID_ACTIVITYINFO"].ToString());

            ActivityInfo ThisActivity = ActivityInfo.objGetActivityInfoByActivityId(iActivityInfo);

            bool success = ActivityInfo.PurgeActivityInfo(iActivityInfo);
            loadMyDeletedPECRequests();
        }
        else if (ButtonClicked == "UnDelete")
        {
            LinkButton lbUndelete = (LinkButton)grdView.Rows[index].FindControl("lnkUnDelete");
            int iActivityInfo = int.Parse(lbUndelete.Attributes["ID_ACTIVITYINFO"].ToString());

            ActivityInfo ThisActivity = ActivityInfo.objGetActivityInfoByActivityId(iActivityInfo);
            bool success = ActivityInfo.UnDeleteActivityInfo(iActivityInfo, ThisActivity.m_iComplete);
        }
        

        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }

    private void loadMyDeletedPECRequests()
    {
        try
        {
            grdView.DataSource = ActivityInfo.dtGetDeletedActivityInfoByOriginator(oSessnx.getOnlineUser.m_iUserId);
            grdView.DataBind();

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
                statusReporter.reportPECStatus(status);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}