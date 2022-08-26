using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Drawing;

public partial class Report_PECReport : System.Web.UI.Page
{
    long iActivityID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ActivityId"] != null)
            {
                iActivityID = long.Parse(Request.QueryString["ActivityId"].ToString());

                DataTable dt = new DataTable();
                dt = Report.dtGetActivityInformationReportByActivityID(iActivityID);

                ReportGenerator("PEC_Report2.rdlc", "report_SepcinActivityInformation", dt);

                //SubreportProcessingEvent Event
                rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(VendorCallOutSubReportProcessingEvent);
                rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(PersonnelInformationSubReportProcessingEvent);
                rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ActivityTimelineSubReportProcessingEvent);
                rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(PlanExecutionCriteriaSubReportProcessingEvent);
                rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ApprovalSubReportProcessingEvent);

                this.rptViewer.LocalReport.Refresh();
            }
        }
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable dt)
    {
        rptViewer.Reset();
        rptViewer.LocalReport.DataSources.Clear();
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/FieldVisit/Report/rptDocument/" + ReportFileName);

        // Add the handler for drillthrough.
        rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);

        // Supply a DataTable corresponding to each report data source.
        rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, dt));

        rptViewer.LocalReport.Refresh();
    }

    //SubReportProcessingEvent Events
    void VendorCallOutSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dt = Report.dtGetVendorCallOutReportByActivityID(iActivityID);
            ReportDataSource rptDataSource = new ReportDataSource("report_SepcinVendorCallOut", dt);
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    void PersonnelInformationSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dt = Report.dtGetPersonnelInformationReportByActivityID(iActivityID);
            ReportDataSource rptDataSource = new ReportDataSource("report_SepcinPersonnel", dt); //SepcinPersonnel
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    void ActivityTimelineSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dt = Report.dtGetActivityTimeLineReportByActivityID(iActivityID);
            ReportDataSource rptDataSource = new ReportDataSource("report_SepcinActivityTimeLine", dt); //SepcinActivityTimeLine
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    void PlanExecutionCriteriaSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dt = Report.dtGetPECReportByActivityID(iActivityID);
            ReportDataSource rptDataSource = new ReportDataSource("report_SepcinPlanExecutionCriteria", dt);
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    void ApprovalSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dt = Report.dtGetApprovalReportByActivityID(iActivityID);
            ReportDataSource rptDataSource = new ReportDataSource("report_SepcinApproval", dt);
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}
