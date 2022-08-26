using System;
using Microsoft.Security.Application;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class Report_MainReport : System.Web.UI.Page
{
    MainProjects oMainProjects = new MainProjects();
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    appUsersHelper oAppUsersHelper = new appUsersHelper();
    IdentifyHelper oIdentifyHelper = new IdentifyHelper();
    EliminateHelper oEliminateHelper = new EliminateHelper();
    SustainHelper oSustainHelper = new SustainHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ProjectId"] != null)
            {
                long lProjectId = long.Parse(Encoder.HtmlEncode(Request.QueryString["ProjectId"].ToString()));

                MainProjectHelper oMainProjectHelper = new MainProjectHelper();
                DataTable dt = oMainProjectHelper.dtGetLeanProjectByProjectId(lProjectId);

                List<ProjectTeamMembers> lstProjectTeamMembers = oMainProjectHelper.lstProjectTeamMembers(lProjectId);
                List<ProjectDrbMembers> lstProjectDrbMembers = oMainProjectHelper.lstProjectDrbMembers(lProjectId);
                List<ProjectCoaches> lstProjectCoaches = oMainProjectHelper.lstProjectCoaches(lProjectId);

                oMainProjects = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);

                ReportGenerator("Report.rdlc", "dsLeanProject_ProjectCharter", dt, lstProjectTeamMembers, lstProjectDrbMembers, lstProjectCoaches, oMainProjects);
                this.rptViewer.LocalReport.Refresh();
            }
        }
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable dt, List<ProjectTeamMembers> lstProjectTeamMembers, List<ProjectDrbMembers> lstProjectDrbMembers, List<ProjectCoaches> lstProjectCoaches, MainProjects oMainProjects)
    {
        try
        {
            rptViewer.Reset();
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/Lean/Report/rptDocument/" + ReportFileName);

            // Add the handler for drillthrough.
            rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);

            // Supply a DataTable corresponding to each report data source.
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, dt));

            string sTeamMembers = ""; string sDRBMembers = ""; string sCoaches = "";

            foreach (ProjectTeamMembers oTeamMembers in lstProjectTeamMembers)
            {
                sTeamMembers += oAppUsersHelper.objGetUserByUserID(oTeamMembers.iUserId).m_sFullName + "; ";
            }

            foreach (ProjectDrbMembers oDrbMembers in lstProjectDrbMembers)
            {
                sDRBMembers += oAppUsersHelper.objGetUserByUserID(oDrbMembers.iUserId).m_sFullName + "; ";
            }

            foreach (ProjectCoaches oCoaches in lstProjectCoaches)
            {
                sCoaches += oAppUsersHelper.objGetUserByUserID(oCoaches.iUserId).m_sFullName + "; ";
            }

            ReportParameter[] oReportParams = new ReportParameter[7];
            oReportParams[0] = new ReportParameter("sDRBMembers", sDRBMembers);
            oReportParams[1] = new ReportParameter("sCoaches", sCoaches);
            oReportParams[2] = new ReportParameter("sTeamMembers", sTeamMembers);
            oReportParams[3] = new ReportParameter("sIdentify", oIdentifyHelper.IdentifyWorkDoneByProject(oMainProjects.lProjectId).ToString());
            oReportParams[4] = new ReportParameter("sEliminate", oEliminateHelper.EliminateWorkDoneByProject(oMainProjects.lProjectId).ToString());
            oReportParams[5] = new ReportParameter("sSustain", oSustainHelper.SustainWorkDoneByProject(oMainProjects.lProjectId).ToString());
            oReportParams[6] = new ReportParameter("sProjectTitle", oMainProjects.sTitle);

            rptViewer.LocalReport.SetParameters(oReportParams);

            rptViewer.LocalReport.Refresh();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}