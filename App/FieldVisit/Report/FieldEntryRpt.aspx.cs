using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Drawing;

public partial class Report_FieldEntryRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ActivityId"] != null)
            {
                long iActivity = long.Parse(Request.QueryString["ActivityId"].ToString());

                DataTable dt = new DataTable();
                dt = fieldVisitDetails.dtFieldVisitDetailsReportByActivity(iActivity);

                ReportGenerator("fieldVisitRpt.rdlc", "report_FieldVisitReport", dt);
            }
        }
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable rptDataTable)
    {
        try
        {
            rptViewer.Reset();
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/FieldVisit/Report/rptDocument/" + ReportFileName);

            // Add the handler for drillthrough.
            rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);

            // Supply a DataTable corresponding to each report data source.
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, rptDataTable));

            //ReportParameter[] oReportParams = new ReportParameter[3];
            //oReportParams[0] = new ReportParameter("sYear", ddlYear.SelectedValue);
            //oReportParams[1] = new ReportParameter("sMonth", ddlMonth.SelectedItem.Text);
            //oReportParams[2] = new ReportParameter("sDate", DateTime.Now.Date.ToLongDateString());
            //rptViewer.LocalReport.SetParameters(oReportParams);

            rptViewer.LocalReport.Refresh();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}