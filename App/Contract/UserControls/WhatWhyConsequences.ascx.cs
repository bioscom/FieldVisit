using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;

public partial class App_Contract_UserControls_WhatWhyConsequences : System.Web.UI.UserControl
{
    ContractLessonsLearntHelper oContractLessonsLearntHelper = new ContractLessonsLearntHelper();
    PriorityHelper oPriorityHelper = new PriorityHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region  =================================== Lessons Learnt ======================================================

    public void LoadDataLessonLearnt()
    {
        //DataTable dt = oContractLessonsLearntHelper.dtGetLeadershipActivityByDistrictTripStartDate(int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStart.dtSelectedDate);

        //ReportGenerator("Report.rdlc", "Contract14Day_LeadershipReport", dt);
        //this.rptViewer.LocalReport.Refresh();

        ViewLiteral.Text = HtmlReport(int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStart.dtSelectedDate).ToString();
    }


    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string rptDataSource, DataTable dt)
    {
        //rptViewer.Reset();
        //rptViewer.LocalReport.DataSources.Clear();
        //rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/Contract/Report/rptDocument/" + ReportFileName);

        //// Add the handler for drillthrough.
        //rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);

        //// Supply a DataTable corresponding to each report data source.
        //rptViewer.LocalReport.DataSources.Add(new ReportDataSource(rptDataSource, dt));

        ////ReportParameter[] oReportParams = new ReportParameter[3];
        ////oReportParams[0] = new ReportParameter("sYear", ddlYear.SelectedValue);
        ////oReportParams[1] = new ReportParameter("sMonth", ddlMonth.SelectedItem.Text);
        ////oReportParams[2] = new ReportParameter("sDate", DateTime.Now.Date.ToLongDateString());
        ////rptViewer.LocalReport.SetParameters(oReportParams);

        //rptViewer.LocalReport.Refresh();
    }

    public UserControl_dateControl TripStartDate
    {
        get { return dtTripStart; }
    }


    #endregion
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
        //ViewLiteral.Text = HtmlReport().ToString();
        //HtmlReport(oCtr, lstGetCostPhasing, lstManPower, lstMaterialServiceCost, lstApprovalComments);
        ExportToPDF(ViewLiteral.Text);

    }

    private StringBuilder HtmlReport(int iDistrict, DateTime dtSelectedDate)
    {
        StringBuilder sb = new StringBuilder();

        string tdStyle = "style='padding: 5px;text-align:left; vertical-align: middle'";

        sb.Append("<table border='0' style='font-size:12.0pt; width:800px; font-family:Calibri; background:white;'>");
        sb.Append("<tr>");
        sb.Append("<td  style='background-color: GOLD' colspan='3'><b>OPERATIONS SUPERINTENDENT 14 DAY CONTRACT</b></td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td " + tdStyle + ">WHAT</td>");
        sb.Append("<td " + tdStyle + ">WHY</td>");
        sb.Append("<td " + tdStyle + ">CONSEQUENCES</td>");
        sb.Append("</tr>");

        List<ContractLessonsLearnt> lstLessonsLearnt;// = new List<ContractLessonsLearnt>();
        List<Priority> lstPriority = oPriorityHelper.lstGetPriority();
        foreach (Priority oPriority in lstPriority)
        {
            if (oPriority.iPriorityId == 6)
            {
                sb.Append("<tr>");
                sb.Append("<td style='background-color: #999999' colspan='3'>" + oPriorityHelper.objGetPriorityById(oPriority.iPriorityId).sPriority + "</td>");
                sb.Append("</tr>");

                lstLessonsLearnt = oContractLessonsLearntHelper.lstLessonsLearnt(oPriority.iPriorityId, iDistrict, dtSelectedDate);
                foreach (ContractLessonsLearnt oLessonsLearnt in lstLessonsLearnt)
                {
                    sb.Append("<tr>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sWhat + "</td>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sWhy + "</td>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sConsequences + "</td>");
                    sb.Append("</tr>");
                }
            }
            else if (oPriority.iPriorityId == 7)
            {
                sb.Append("<tr>");
                sb.Append("<td style='background-color: #999999' colspan='3'>" + oPriorityHelper.objGetPriorityById(oPriority.iPriorityId).sPriority + "</td>");
                sb.Append("</tr>");

                lstLessonsLearnt = oContractLessonsLearntHelper.lstLessonsLearnt(oPriority.iPriorityId, iDistrict, dtSelectedDate);
                foreach (ContractLessonsLearnt oLessonsLearnt in lstLessonsLearnt)
                {
                    sb.Append("<tr>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sWhat + "</td>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sWhy + "</td>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sConsequences + "</td>");
                    sb.Append("</tr>");
                }
            }
            else if (oPriority.iPriorityId == 8)
            {
                sb.Append("<tr>");
                sb.Append("<td style='background-color: #999999' colspan='3'>" + oPriorityHelper.objGetPriorityById(oPriority.iPriorityId).sPriority + "</td>");
                sb.Append("</tr>");

                lstLessonsLearnt = oContractLessonsLearntHelper.lstLessonsLearnt(oPriority.iPriorityId, iDistrict, dtSelectedDate);
                foreach (ContractLessonsLearnt oLessonsLearnt in lstLessonsLearnt)
                {
                    sb.Append("<tr>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sWhat + "</td>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sWhy + "</td>");
                    sb.Append("<td " + tdStyle + ">" + oLessonsLearnt.sConsequences + "</td>");
                    sb.Append("</tr>");
                }
            }
        }
        sb.Append("</table>");
        return sb;
    }

    private void ExportToPDF(string sHtml)
    {
        var output = new MemoryStream();

        try
        {
            // Create a Document object
            var document = new Document(PageSize.A4, 50, 50, 75, 25);

            // Create a new PdfWriter object, specifying the output stream

            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();

            //... Step 3: Add elements to the document! ...


            // Step 4: Parse the HTML string into a collection of elements...
            var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(sHtml), null);
            // Enumerate the elements, adding each one to the Document...
            foreach (IElement htmlElement in parsedHtmlElements)
            {
                document.Add(htmlElement);
            }


            //var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(sHtml), null);
            //foreach (var htmlElement in parsedHtmlElements)
            //    document.Add(htmlElement as IElement);



            //var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logo.gif"));
            //logo.SetAbsolutePosition(40, 800);
            //document.Add(logo);

            // Close the Document - this saves the document contents to the output stream
            document.Close();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Report.pdf"));
        Response.BinaryWrite(output.ToArray());

        Response.Flush();
        Response.End();
    }

}