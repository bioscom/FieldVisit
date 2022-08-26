using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Reports_rptReport : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlReportType.Items.Add(new ListItem(RequestStatusReporter.RequestStatusRptDesc(RequestStatusReporter.RequestStatusRpt.Approved), ((int)RequestStatusReporter.RequestStatusRpt.Approved).ToString()));
            ddlReportType.Items.Add(new ListItem(RequestStatusReporter.RequestStatusRptDesc(RequestStatusReporter.RequestStatusRpt.NotApproved), ((int)RequestStatusReporter.RequestStatusRpt.NotApproved).ToString()));
            ddlReportType.Items.Add(new ListItem(RequestStatusReporter.RequestStatusRptDesc(RequestStatusReporter.RequestStatusRpt.Cancelled), ((int)RequestStatusReporter.RequestStatusRpt.Cancelled).ToString()));

            List<Category> oCategories = Category.lstGetCategories(); //Load Category
            foreach (Category oCategory in oCategories)
            {
                ddlCategory.Items.Add(new ListItem(oCategory.m_sCategory, oCategory.m_iCategoryId.ToString()));
            }

            List<Facility> oFacilities = Facility.lstGetFacilities(); //Load Facilities
            foreach (Facility oFacility in oFacilities)
            {
                ddlFacilities.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
            }
        }
    }

    protected void viewButton_Click(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable();
        //ReportGenerator("rptApprovedCTR.rdlc", "Report_ApprovedCTR", dt);
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable rptDataTable)
    {
        rptViewer.LocalReport.DataSources.Clear();
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/FlareWaiver/Reports/rptRDLC/" + ReportFileName);

        // Add the handler for drillthrough.
        rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);

        // Supply a DataTable corresponding to each report data source.
        rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, rptDataTable));

        //Generate Parameters to pass to the reposrt
        ReportParameter[] oReportParams = new ReportParameter[1];
        
        //oReportParams[0] = new ReportParameter("dateFrom", txtFrom.Text);
        //oReportParams[1] = new ReportParameter("dateTo", txtTo.Text);
        string rptTitle = "";
        if (ddlReportType.SelectedValue != "-1" && (txtFrom.SelectedDate.ToString() != "") && (txtTo.SelectedDate.ToString() != ""))
        {
            rptTitle = ddlReportType.SelectedItem.Text + " between " + txtFrom.SelectedDate.ToString() + " and " + txtTo.SelectedDate.ToString();
        }
        else if (ddlReportType.SelectedValue != "-1")
        {
            rptTitle = ddlReportType.SelectedItem.Text;
        }
        oReportParams[0] = new ReportParameter("Report_Title", rptTitle);
        rptViewer.LocalReport.SetParameters(oReportParams);
        rptViewer.LocalReport.Refresh();
    }

    //protected void clearFrom_Click(object sender, ImageClickEventArgs e)
    //{
    //    txtFrom.Text = "";
    //}
    //protected void clearTo_Click(object sender, ImageClickEventArgs e)
    //{
    //    txtTo.Text = "";
    //}
}
