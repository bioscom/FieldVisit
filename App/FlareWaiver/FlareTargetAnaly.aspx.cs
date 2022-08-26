using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_FlareWaiver_FlareTargetAnaly : System.Web.UI.Page
{
    FlareTargetHelper o = new FlareTargetHelper();
    FlareWaiverRequestHelper oHlp = new FlareWaiverRequestHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<int> o = FlareTargetHelper.lstYears();
            foreach (int i in o)
            {
                ddlYear.Items.Add(new ListItem(i.ToString()));
            }

            cVerificationHeatMapHelper.getMonths2(ddlMonth);
        }
    }
    
    protected void DailyRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            RepeaterItem oItem = e.Item;
            LinkButton lnkDailyReport = (LinkButton)oItem.FindControl("lnkDaily");

            int iDay = int.Parse(lnkDailyReport.Attributes["NOID"]);

            lblMessage.Text = iDay + ", " + ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedValue + " Flared Gas Analysis";

            grdView.DataSource = o.dtGetFlareTargetByMonthYear(ddlMonth.SelectedItem.Text, int.Parse(ddlYear.SelectedValue));
            grdView.DataBind();

            GridManager();

            grdViewEC.DataSource = oHlp.dtGetDailyFlareWaiverRequestFromEC2(iDay, int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue));
            grdViewEC.DataBind();

            //GraphicalReports1.GraphicalReporter(int.Parse(ddlYear.SelectedValue), ddlMonth.SelectedItem.Text, int.Parse(ddlMonth.SelectedValue), iDay);
            //GraphicalReports2.GraphicalReporterSeries(int.Parse(ddlYear.SelectedValue), ddlMonth.SelectedItem.Text, int.Parse(ddlMonth.SelectedValue), iDay);
            
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataRow row;
        DataTable dt = new DataTable();
        dt.Columns.Add("NOID");

        int iDaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(ddlMonth.SelectedValue));

        for (int i = 1; i <= iDaysInMonth; i++)
        {
            row = dt.NewRow();
            row["NOID"] = i.ToString();
            dt.Rows.Add(row);
        }

        DailyRepeater.DataSource = dt;
        DailyRepeater.DataBind();
    }

    private void GridManager()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label labelStatus = (Label)grdRow.FindControl("labelStatus");
            RequestStatusReporter.reportMyStatus(labelStatus);
        }
    }

}