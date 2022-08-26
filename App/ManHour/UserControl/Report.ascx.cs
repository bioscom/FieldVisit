using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using Microsoft.Security.Application;

public partial class UserControl_Report : System.Web.UI.UserControl
{
    public void Init_Page(long lIntiativeId)
    {
        Initiative oInitiative = new Initiative();
        ResourceUtilisation oResourceUtil = new ResourceUtilisation();

        DataTable dt = oInitiative.dtGetBusinessInitiativeReportByInitiativeId(lIntiativeId);
        ReportGenerator("UtilisationReport.rdlc", "Report_BusinessInitiative", dt);

        DataTable dtResourceUtil = oResourceUtil.dtGetResourceRequirementsByInitiative(lIntiativeId);
        ReportGenerator("UtilisationReport.rdlc", "Report_ResourceUtilisation", dtResourceUtil);

        //SubreportProcessingEvent Event
        rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(BaseDataSubReportProcessingEvent);
        this.rptViewer.LocalReport.Refresh();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
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

   
    protected void showReportLinkButton_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["IntiativeId"] != null)
        {
            long lIntiativeId = long.Parse(Encoder.HtmlEncode(Request.QueryString["IntiativeId"].ToString()));
            Init_Page(lIntiativeId);
        }
    }
}