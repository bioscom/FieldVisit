using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Reporting.WebForms;
using Microsoft.Security.Application;

public partial class App_ManHour_UserControl_StatusMilestoneReport : System.Web.UI.UserControl
{
    ProjectCurrentStatusHelper oProjectCurrentStatusHelper = new ProjectCurrentStatusHelper();
    ProjectMilestoneHelper oProjectMilestoneHelper = new ProjectMilestoneHelper();

    long lIntiativeId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    public void Init_Page(long IntiativeId)
    {
        lIntiativeId = IntiativeId;
        DataTable dt = oProjectCurrentStatusHelper.dtGetProjectCurrentStatusReportByInitiativeId(lIntiativeId);
        ReportGenerator("ProjectStatusMilestoneReport.rdlc", "Report_ProjectStatus", dt);
        
        //SubreportProcessingEvent Event
        rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ProjectMilestoneSubReportProcessingEvent);
        this.rptViewer.LocalReport.Refresh();
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable dt)
    {
        rptViewer.Reset();
        rptViewer.LocalReport.DataSources.Clear();
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/ManHour/Report/rptDocument/" + ReportFileName);
        rptViewer.LocalReport.EnableExternalImages = true;

        rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);
        rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, dt));

        rptViewer.LocalReport.Refresh();
    }

    //SubReportProcessingEvent Events
    void ProjectMilestoneSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dt = oProjectMilestoneHelper.dtGetProjectMilestoneByInitiativeId(lIntiativeId);
            ReportDataSource rptDataSource = new ReportDataSource("Report_ProjectMilestone", dt);
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void showReportLinkButton_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["IntiativeId"] != null)
        {
            long lIntiativeId = long.Parse(Encoder.HtmlEncode(Request.QueryString["IntiativeId"].ToString()));
            Init_Page(lIntiativeId);
        }
    }
}