using System;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class App_Contract_LeadershipActivityReport : System.Web.UI.Page
{
    //ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    //ContractLessonsLearnt oContractLessonsLearnt = new ContractLessonsLearnt();
    ContractLessonsLearntHelper oContractLessonsLearntHelper = new ContractLessonsLearntHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtTripStart.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
            dtTripStart.ImageBtn.Enabled = false;
            dtTripStart.txtDateTextBox.Enabled = false;
            LoadData();

            //oContractActivitiesHelper.LoadDistrict(ddlDistrict);
        }
    }

    private void LoadData()
    {
        DataTable dt = oContractLessonsLearntHelper.dtGetLeadershipActivityByDistrictTripStartDate(int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStart.dtSelectedDate);

        ReportGenerator("Report.rdlc", "Contract14Day_LeadershipReport", dt);
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
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/Contract/Report/rptDocument/" + ReportFileName);

        // Add the handler for drillthrough.
        rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);

        // Supply a DataTable corresponding to each report data source.
        rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, dt));

        //ReportParameter[] oReportParams = new ReportParameter[3];
        //oReportParams[0] = new ReportParameter("sYear", ddlYear.SelectedValue);
        //oReportParams[1] = new ReportParameter("sMonth", ddlMonth.SelectedItem.Text);
        //oReportParams[2] = new ReportParameter("sDate", DateTime.Now.Date.ToLongDateString());
        //rptViewer.LocalReport.SetParameters(oReportParams);

        rptViewer.LocalReport.Refresh();
    }
}