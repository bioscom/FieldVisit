using System;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Forms_Analysis : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //UserControl_MyInitiatives oInitiative = (UserControl_MyInitiatives)Master.FindControl("MyInits1");
            //if ((oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.initiator) || (oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.admin))
            //{
            //    oInitiative.Init_Control();
            //}
            //else
            //{
            //    oInitiative.Init_Control_Approvers();
            //}
            report(DateTime.Today.Year);
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
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/ManHour/Report/rptDocument/" + ReportFileName);

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
        report(dtYearOne.dtSelectedDate.Year);
    }

    private void report(int iYear)
    {
        Initiative oInitiative = new Initiative();
        ResourceUtilisation oResourceUtilisation = new ResourceUtilisation();
        DataTable dt = oResourceUtilisation.dtGetResourceRequirementsByYear(iYear);
        ReportGenerator("rptReport.rdlc", "Report_ResourceUtilisation", dt);

        //SubreportProcessingEvent Event
        rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(BaseDataSubReportProcessingEvent);
        this.rptViewer.LocalReport.Refresh();

        if (dt.Rows.Count == 0)
        {
            string sMessage = "No Business Improvement Initiative found for the current year. Select year from the Date Picker box and click View for previous years.";
            lblMessage.Text = sMessage;
            ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
        }
    }


    void BaseDataSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dtBaseData = BasedataHelper.dtGetBaseData(); //FlareApprovalHelper.dtGetFlareApprovalbyRequestId(lRequestId);
            ReportDataSource rptDataSource = new ReportDataSource("Report_BaseData", dtBaseData);
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}