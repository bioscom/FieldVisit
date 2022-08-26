using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Microsoft.Security.Application;

public partial class Forms_AssetImpact2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["IntiativeId"] != null)
            {
                
            }
        }
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable rptDataTable)
    {
        rptViewer.Reset();
        rptViewer.LocalReport.DataSources.Clear();
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/Report/rptDocument/" + ReportFileName);

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
    protected void submitButton_Click(object sender, EventArgs e)
    {
        Initiative oInitiative = new Initiative();
        DataTable dt = oInitiative.dtGetImpactOnAssetTwo(dtYearOne.dtSelectedDate.Year, dtYearTwo.dtSelectedDate.Year);
        ReportGenerator("ImpactOnAssetTwo.rdlc", "Report_ImpactOnAssetTwo", dt);

        this.rptViewer.LocalReport.Refresh();
    }
}