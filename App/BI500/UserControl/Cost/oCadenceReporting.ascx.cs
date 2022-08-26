using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_UserControl_Cost_oCadenceReporting : aspnetUserControl
{
    CadenceHelper oMS = new CadenceHelper();
    CostReductionCadence o = new CostReductionCadence();
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

    public void LoadCadenceByRequestId(long lRequestId)
    {
        oT = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

        lblRequestNumber.Text = oT.sRequestNumber;
        lblTitle.Text = oT.sTitle;
        lblDateInit.Text = oT.dDateSubmitted.ToLongDateString();

        RequestIdHF.Value = lRequestId.ToString();
        grdView.DataSource = oMS.dtGetCadenceByRequestId(lRequestId);
        grdView.DataBind();

        CadenceStatus.CadenceStatusReporter(grdView);

        //foreach (GridViewRow grdRow in grdView.Rows)
        //{
        //    Label lb = (Label) grdRow.FindControl("labelStatus");

        //    if (lb != null)
        //    {
        //        int iStatus = int.Parse(lb.Text);

        //        if (iStatus == (int) CadenceStatus.ProjStatus.New) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.New); }

        //        if (iStatus == (int) CadenceStatus.ProjStatus.AtRisk) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.AtRisk); }
        //        if (iStatus == (int) CadenceStatus.ProjStatus.OnTrack) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.OnTrack); }
        //        if (iStatus == (int) CadenceStatus.ProjStatus.Delayed) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.Delayed); }
        //        if (iStatus == (int) CadenceStatus.ProjStatus.Completed) { lb.Text = CadenceStatus.status(CadenceStatus.ProjStatus.Completed); }
        //    }
        //}
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
            o.sAction = Convert.ToString(((TextBox) grdView.FooterRow.FindControl("txtAction")).Text);
            o.sActionParty = Convert.ToString(((TextBox) grdView.FooterRow.FindControl("txtActionParty")).Text);
            o.sThreat = Convert.ToString(((TextBox) grdView.FooterRow.FindControl("txtThreat")).Text);

            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx) grdView.FooterRow.FindControl("FDdateControl");
            o.dFinishDate = FD.dtSelectedDate;

            ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx) grdView.FooterRow.FindControl("oStatusControl");
            o.iStatus = Convert.ToInt16(ddlStatus.thisDropDown.SelectedValue);


            //o.iStatus = Convert.ToInt16(((DropDownList)grdView.FooterRow.FindControl("oStatusControl")).SelectedValue);

            if (Convert.ToString(((TextBox) grdView.FooterRow.FindControl("txtAction")).Text) != "") oMS.InsertCadence(o);
            else ajaxWebExtension.showJscriptAlertCx(Page, this, "Action is required.");

            LoadCadenceByRequestId(lRequestId);
        }

        if (e.CommandName.Equals("emptyInsert"))
        {
            GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

            o.sAction = Convert.ToString(((TextBox) emptyRow.FindControl("txtAction")).Text);
            o.sActionParty = Convert.ToString(((TextBox) emptyRow.FindControl("txtActionParty")).Text);
            o.sThreat = Convert.ToString(((TextBox) emptyRow.FindControl("txtThreat")).Text);

            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx) emptyRow.FindControl("FDdateControl");
            o.dFinishDate = FD.dtSelectedDate;

            ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx) emptyRow.FindControl("oStatusControl");
            o.iStatus = Convert.ToInt16(ddlStatus.thisDropDown.SelectedValue);

            if (Convert.ToString(((TextBox) emptyRow.FindControl("txtAction")).Text) != "") oMS.InsertCadence(o);
            else ajaxWebExtension.showJscriptAlertCx(Page, this, "Action is required.");

            LoadCadenceByRequestId(lRequestId);
        }
    }
    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        long lActivityId = long.Parse(RequestIdHF.Value);
        grdView.EditIndex = -1;
        LoadCadenceByRequestId(lActivityId);
    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);
        grdView.EditIndex = e.NewEditIndex;
        LoadCadenceByRequestId(lRequestId);

        Int64 lCadenceId = Convert.ToInt64(grdView.DataKeys[e.NewEditIndex].Values[0].ToString());
        CostReductionCadence oC = oMS.objGetCadenceByCadenceId(lCadenceId);

        ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("FDdateControl");
        FD.setDate(oC.dFinishDate.ToString());

        ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx) grdView.Rows[e.NewEditIndex].FindControl("oStatusControl");
        ddlStatus.thisDropDown.SelectedValue = oC.iStatus.ToString();
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(RequestIdHF.Value);
            o.lRequestId = lRequestId;
            ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx) grdView.Rows[e.RowIndex].FindControl("FDdateControl");

            o.lCadenceId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            o.sAction = Convert.ToString(((TextBox) grdView.Rows[e.RowIndex].FindControl("txtAction")).Text);
            o.sActionParty = Convert.ToString(((TextBox) grdView.Rows[e.RowIndex].FindControl("txtActionParty")).Text);
            o.sThreat = Convert.ToString(((TextBox) grdView.Rows[e.RowIndex].FindControl("txtThreat")).Text);
            o.dFinishDate = FD.dtSelectedDate;

            ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx) grdView.Rows[e.RowIndex].FindControl("oStatusControl");
            o.iStatus = Convert.ToInt16(ddlStatus.thisDropDown.SelectedValue);

            oMS.UpdateCadence(o);

            grdView.EditIndex = -1;
            LoadCadenceByRequestId(lRequestId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lRequestId = long.Parse(RequestIdHF.Value);

        Int64 lCadenceId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
        oMS.DeleteCadence(lCadenceId);
        LoadCadenceByRequestId(lRequestId);
    }

    protected void exportExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(RequestIdHF.Value);
            List<CostReductionCadence> o = oMS.lstGetCadenceByRequestId(lRequestId);
            oMS.ExporttoExcel(o);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
        }
    }
}
