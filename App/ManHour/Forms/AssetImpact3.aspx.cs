using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Microsoft.Security.Application;

public partial class Forms_AssetImpact3 : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //UserControl_MyInitiatives oInitiative = (UserControl_MyInitiatives)Master.FindControl("MyInitiatives1");
            //if ((oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.initiator) || (oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.admin))
            //{
            //    oInitiative.Init_Control();
            //}
            //else
            //{
            //    oInitiative.Init_Control_Approvers();
            //}
            Report(DateTime.Today.Year - 1, DateTime.Today.Year + 1);
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
        Initiative oInitiative = new Initiative();
        DataTable dt = oInitiative.dtGetImpactOnAssetThree(dtYearOne.dtSelectedDate.Year, dtYearTwo.dtSelectedDate.Year);
        ReportGenerator("ImpactOnAssetThree.rdlc", "Report_ImpactOnAssetTwo", dt);

        this.rptViewer.LocalReport.Refresh();
    }

    private void Report(int iYearOne, int iYearThree)
    {
        Initiative oInitiative = new Initiative();
        DataTable dt = oInitiative.dtGetImpactOnAssetThree(iYearOne, iYearThree);
        ReportGenerator("ImpactOnAssetThree.rdlc", "Report_ImpactOnAssetTwo", dt);

        this.rptViewer.LocalReport.Refresh();
    }
}