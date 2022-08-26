using System;
using Microsoft.Security.Application;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class Report_MainReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["lRequestId"] != null)
            {
                long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["lRequestId"].ToString()));

                BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
                DataTable dt = oBI500RequestHelper.dtGetRequestById(lRequestId);

                ReportGenerator("Report.rdlc", "BI500Report_BI500Report", dt);
                this.rptViewer.LocalReport.Refresh();
            }
        }
    }


    //public void Init_Page(long lIntiativeId)
    //{
    //    Initiative oInitiative = new Initiative();
    //    DataTable dt = oInitiative.dtGetBusinessInitiativeReportByInitiativeId(lIntiativeId);
    //    ReportGenerator("MainReport.rdlc", "Report_BusinessInitiative", dt);

    //    this.rptViewer.LocalReport.Refresh();
    //}

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable rptDataTable)
    {
        rptViewer.Reset();
        rptViewer.LocalReport.DataSources.Clear();
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/BI500/Report/rptDocument/" + ReportFileName);

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
}