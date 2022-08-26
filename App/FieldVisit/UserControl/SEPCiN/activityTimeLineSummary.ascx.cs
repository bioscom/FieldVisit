using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_activityTimeLineSummary : aspnetUserControl
{
    public void Init_Page()
    {
        //long iActivityInfo = long.Parse(Session["ActivityInfoID"].ToString());
        //Retrieve_Data(iActivityInfo);
    }

    public void InitPage()
    {
        //ActivityIDHF.Value = iActivityInfo.ToString();
        //Retrieve_Data(iActivityInfo);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void initiateActivityId(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();
        grdView.DataSource = ActivityTimeLine.dtGetActivityTimeLineByActivityId(lActivityId);
        grdView.DataBind();
    }

    public void Retrieve_Data(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();
        grdView.DataSource = ActivityTimeLine.dtGetActivityTimeLineByActivityId(lActivityId);
        grdView.DataBind();
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long lActivityId = long.Parse(ActivityIDHF.Value);
        if (e.CommandName.Equals("Insert"))
        {
            ActivityTimeLine eTimeLine = new ActivityTimeLine();
            eTimeLine.m_sACTIVITY_DESCRIPTION = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("activityDescTextBox")).Text);

            ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)grdView.FooterRow.FindControl("SDdateControl");
            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.FooterRow.FindControl("FDdateControl");

            eTimeLine.m_sSTART_DATE = SD.dtSelectedDate.ToString();
            eTimeLine.m_sFINISH_DATE = FD.dtSelectedDate.ToString();

            ActivityTimeLine.createActivityTimeLine(lActivityId, eTimeLine);
            Retrieve_Data(lActivityId);
        }

        if (e.CommandName.Equals("emptyInsert"))
        {
            GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

            ActivityTimeLine eTimeLine = new ActivityTimeLine();
            eTimeLine.m_sACTIVITY_DESCRIPTION = Convert.ToString(((TextBox)emptyRow.FindControl("activityDescTextBox")).Text);

            ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)emptyRow.FindControl("SDdateControl");
            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)emptyRow.FindControl("FDdateControl");

            eTimeLine.m_sSTART_DATE = SD.dtSelectedDate.ToString();
            eTimeLine.m_sFINISH_DATE = FD.dtSelectedDate.ToString();
            if (Convert.ToString(((TextBox)emptyRow.FindControl("activityDescTextBox")).Text) != "")
            {
                ActivityTimeLine.createActivityTimeLine(lActivityId, eTimeLine);
            }
            else
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Activity Description is required.");
            }

            Retrieve_Data(lActivityId);
        }
    }
    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        long lActivityId = long.Parse(ActivityIDHF.Value);
        grdView.EditIndex = -1;
        Retrieve_Data(lActivityId);
    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        long lActivityId = long.Parse(ActivityIDHF.Value);
        grdView.EditIndex = e.NewEditIndex;
        Retrieve_Data(lActivityId);

        Int64 lTimeLine = Convert.ToInt64(grdView.DataKeys[e.NewEditIndex].Values[0].ToString());
        ActivityTimeLine ThisTimeLine = ActivityTimeLine.objGetActivityTimeLineById(lTimeLine);

        ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("SDdateControl");
        ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("FDdateControl");

        SD.setDate(ThisTimeLine.m_sSTART_DATE.ToString());
        FD.setDate(ThisTimeLine.m_sFINISH_DATE.ToString());
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            long lActivityId = long.Parse(ActivityIDHF.Value);

            ActivityTimeLine eTimeLine = new ActivityTimeLine();
            eTimeLine.m_iID_TIMELINE = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            eTimeLine.m_sACTIVITY_DESCRIPTION = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("activityDescTextBox")).Text);

            ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.RowIndex].FindControl("SDdateControl");
            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.RowIndex].FindControl("FDdateControl");

            eTimeLine.m_sSTART_DATE = SD.dtSelectedDate.ToString();
            eTimeLine.m_sFINISH_DATE = FD.dtSelectedDate.ToString();

            ActivityTimeLine.updateActivityTimeLine(eTimeLine);

            grdView.EditIndex = -1;
            Retrieve_Data(lActivityId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lActivityId = long.Parse(ActivityIDHF.Value);

        Int64 iTimeLineId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
        ActivityTimeLine.deleteTimeLine(iTimeLineId);
        Retrieve_Data(lActivityId);
    }
}
