using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_UserControl_Cost_oMilestones : aspnetUserControl
{
    MilestoneHelper oMS = new MilestoneHelper();
    CostReductionMileStone o = new CostReductionMileStone();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    CostReductionRequest oT = new CostReductionRequest();
    public void Init_Page()
    {

    }

    public void InitPage()
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void LoadMilestoneByRequestId(long lRequestId)
    {
        oT = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

        lblRequestNumber.Text = oT.sRequestNumber;
        lblTitle.Text = oT.sTitle;
        lblDateInit.Text = oT.dDateSubmitted.ToLongDateString();

        RequestIdHF.Value = lRequestId.ToString();
        grdView.DataSource = oMS.dtGetMilestoneByRequestId(lRequestId);
        grdView.DataBind();
    }

    
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);
        o.lRequestId = lRequestId;
        if (e.CommandName.Equals("Insert"))
        {
            o.sActivityDescription = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("activityDescTextBox")).Text);

            ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)grdView.FooterRow.FindControl("SDdateControl");
            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.FooterRow.FindControl("FDdateControl");
            o.dStartDate = SD.dtSelectedDate;
            o.dFinishDate = FD.dtSelectedDate;
            o.dAmountSaved = Convert.ToDecimal(((TextBox)grdView.FooterRow.FindControl("txtAmountSaved")).Text);

            if (Convert.ToString(((TextBox)grdView.FooterRow.FindControl("activityDescTextBox")).Text) != "") oMS.InsertMilestone(o);
            else ajaxWebExtension.showJscriptAlertCx(Page, this, "Activity Description is required.");

            LoadMilestoneByRequestId(lRequestId);
        }

        if (e.CommandName.Equals("emptyInsert"))
        {
            GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

            o.sActivityDescription = Convert.ToString(((TextBox)emptyRow.FindControl("activityDescTextBox")).Text);

            ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)emptyRow.FindControl("SDdateControl");
            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)emptyRow.FindControl("FDdateControl");
            o.dStartDate = SD.dtSelectedDate;
            o.dFinishDate = FD.dtSelectedDate;
            o.dAmountSaved = Convert.ToDecimal(((TextBox)emptyRow.FindControl("txtAmountSaved")).Text);

            if (Convert.ToString(((TextBox)emptyRow.FindControl("activityDescTextBox")).Text) != "") oMS.InsertMilestone(o);
            else ajaxWebExtension.showJscriptAlertCx(Page, this, "Activity Description is required.");

            LoadMilestoneByRequestId(lRequestId);
        }
    }
    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        long lActivityId = long.Parse(RequestIdHF.Value);
        grdView.EditIndex = -1;
        LoadMilestoneByRequestId(lActivityId);
    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);
        grdView.EditIndex = e.NewEditIndex;
        LoadMilestoneByRequestId(lRequestId);

        Int64 lMilestoneId = Convert.ToInt64(grdView.DataKeys[e.NewEditIndex].Values[0].ToString());
        CostReductionMileStone oC = oMS.objGetMilestoneByMilstoneId(lMilestoneId);

        ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("SDdateControl");
        ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("FDdateControl");

        SD.setDate(oC.dStartDate.ToString());
        FD.setDate(oC.dFinishDate.ToString());
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(RequestIdHF.Value);
            o.lRequestId = lRequestId;

            o.lMilestoneId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            o.sActivityDescription = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("activityDescTextBox")).Text);
            
            ASP.usercontrols_datecontrol_ascx SD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.RowIndex].FindControl("SDdateControl");
            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.RowIndex].FindControl("FDdateControl");
            o.dStartDate = SD.dtSelectedDate;
            o.dFinishDate = FD.dtSelectedDate;
            o.dAmountSaved = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAmountSaved")).Text);

            oMS.UpdateMilestone(o);

            grdView.EditIndex = -1;
            LoadMilestoneByRequestId(lRequestId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);

        Int64 lMilestoneId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
        oMS.DeleteMilestone(lMilestoneId);
        LoadMilestoneByRequestId(lRequestId);
    }
}
