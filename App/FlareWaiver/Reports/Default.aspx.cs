using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class Reports_Default : System.Web.UI.Page
{
    long lRequestId = 0;
    RequestFacilityHelper oRequestFacilityHelper = new RequestFacilityHelper();
    Facility oFacility = new Facility();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["RequestId"] != null)
            {
                FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();
                lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                DataTable dtFlareWaiverRequest = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestById(lRequestId);

                ReportGenerator("rptFlareWaiver.rdlc", "Report_FlareWaiverRequest", dtFlareWaiverRequest, lRequestId);

                //SubreportProcessingEvent Event
                rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ApproversSubReportProcessingEvent);
                this.rptViewer.LocalReport.Refresh();
            }
        }
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable dtInitiative, long lIntiativeId)
    {
        rptViewer.Reset();
        rptViewer.LocalReport.DataSources.Clear();
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/FlareWaiver/Reports/rptRDLC/" + ReportFileName);
        rptViewer.LocalReport.EnableExternalImages = true;

        rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);
        rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, dtInitiative));

        ReportParameter[] oReportParams = new ReportParameter[1];

        
        string sFacilities = "";
        List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(lRequestId);
        foreach (RequestFacility oRequestFacility in lstRequestFacilities)
        {
            sFacilities += Facility.objGetFacilityById(oRequestFacility.m_iFacilityId).m_sFacility +", ";
        }

        oReportParams[0] = new ReportParameter("paramFacilities", sFacilities);
        //oReportParams[1] = new ReportParameter("sFacilities", sFacilities);
        rptViewer.LocalReport.SetParameters(oReportParams);

        rptViewer.LocalReport.Refresh();
    }

    void ApproversSubReportProcessingEvent(Object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            DataTable dtApprovers = FlareApprovalHelper.dtGetFlareApprovalbyRequestId(lRequestId);
            ReportDataSource rptDataSource = new ReportDataSource("Report_Approvers", dtApprovers);
            e.DataSources.Add(rptDataSource);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}