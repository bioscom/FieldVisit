using System;
using Microsoft.Security.Application;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class UserControl_MainReport : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

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

    public void Init_Page(long lIntiativeId)
    {
        Initiative oInitiative = new Initiative();
        Initiative rptInitiative = oInitiative.objGetBusinessInitiativeReportByInitiativeId(lIntiativeId);

        DataTable dt = oInitiative.dtGetBusinessInitiativeReportByInitiativeId(lIntiativeId);

        ReportGenerator("ProjectCharter.rdlc", "Report_BusinessInitiative", dt);
        this.rptViewer.LocalReport.Refresh();
    }

    void myDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
    {
        LocalReport localReport = (LocalReport)e.Report;
    }

    private void ReportGenerator(string ReportFileName, string sInitiative, DataTable dt)
    {
        rptViewer.Reset();
        rptViewer.LocalReport.DataSources.Clear();
        rptViewer.LocalReport.ReportPath = Server.MapPath("~/App/ManHour/Report/rptDocument/" + ReportFileName);
        //rptViewer.LocalReport.EnableExternalImages = true;

        rptViewer.Drillthrough += new DrillthroughEventHandler(myDrillthroughEventHandler);

        rptViewer.LocalReport.DataSources.Add(new ReportDataSource(sInitiative, dt));
        rptViewer.LocalReport.Refresh();
    }
}

#region  Reuseable codes

//public void Init_Page(long lIntiativeId)
//{
//    lblDistricts.Text = "";
//    lblFacilities.Text = "";

//    Initiative oInitiative = new Initiative();
//    Initiative rptInitiative = oInitiative.objGetBusinessInitiativeReportByInitiativeId(lIntiativeId);

//    FunctionMgt oFunctionMgt = new FunctionMgt();
//    List<facility> oFacilities = facility.lstGetFacilityByInitiative(lIntiativeId);

//    lblBenefits.Text = rptInitiative.m_sBenefits;
//    lblBusinessCase.Text = rptInitiative.m_sBusinessCase;
//    lblCriticalSuccessFactors.Text = rptInitiative.m_sSuccessFactor;
//    lblDeliverables.Text = rptInitiative.m_sDeliverables;

//    foreach (facility oFacility in oFacilities)
//    {
//        lblDistricts.Text += District.objGetDistrictById(oFacility.m_iDistrictId).m_sDistrict + "; ";
//        lblFacilities.Text += oFacility.m_sFacility + "; ";
//    }

//    lblFunctions.Text = oFunctionMgt.objGetFunctionById(rptInitiative.m_iFunctionId).m_sFunction;
//    lblKeyActivities.Text = rptInitiative.m_sKeyActivities;
//    lblMeasures.Text = rptInitiative.m_sMeasures;
//    lblObjectives.Text = rptInitiative.m_sObjectives;
//    lblScope.Text = rptInitiative.m_sScope;
//    lblTeamMembers.Text = rptInitiative.m_sTeamMembers;
//    lblTitle.Text = rptInitiative.m_sTitle;
//}

//public System.Text.StringBuilder ConvertToHtml(long lIntiativeId)
//{
//    System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();

//    try
//    {
//        string sDictricts = ""; string sFacilities = "";

//        Initiative oInitiative = new Initiative();
//        Initiative rptInitiative = oInitiative.objGetBusinessInitiativeReportByInitiativeId(lIntiativeId);

//        FunctionMgt oFunctionMgt = new FunctionMgt();
//        List<facility> oFacilities = facility.lstGetFacilityByInitiative(lIntiativeId);

//        // set a path to where you want to write the PDF to.
//        //string sPathToWritePdfTo = @"\Report\NewInitiative.pdf";

//        // build some HTML text to write as a PDF.  You could also 
//        // read this HTML from a file or other means.
//        // NOTE: This component doesn't understand CSS or other 
//        // newer style HTML so you will need to use depricated 
//        // HTML formatting such as the <font> tag to make it look correct.

//        sbHtml.Append("<html>");
//        sbHtml.Append("<body>");
//        //sbHtml.Append("<font size='14'>My Document Title Line</font>");
//        sbHtml.Append("<br />");
//        //sbHtml.Append("This is my document text");
//        sbHtml.Append("<table style='width: 99%;border:solid 1px gray;padding: 0px;margin :3px;font: 95%  Arial, Verdana,Helvetica, Georgia, Times, serif;'>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td colspan='3' style='text-align: center'>");
//        sbHtml.Append(rptInitiative.m_sTitle);
//        sbHtml.Append("</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366; background-color:#FFCC00'>Function</td>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366; background-color:#FFCC00'>Districts</td>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366; background-color:#FFCC00'>Facilities/Impacted areas</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(oFunctionMgt.objGetFunctionById(rptInitiative.m_iFunctionId).m_sFunction);
//        sbHtml.Append("</td>");

//        foreach (facility oFacility in oFacilities)
//        {
//            sDictricts += District.objGetDistrictById(oFacility.m_iDistrictId).m_sDistrict + "; ";
//            sFacilities += oFacility.m_sFacility + "; ";
//        }

//        sbHtml.Append("<td>");
//        sbHtml.Append(sDictricts);
//        sbHtml.Append("</td>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(sFacilities);
//        sbHtml.Append("</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td width='33%' style='vertical-align:middle;font-size:13px;font-weight: bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Business Case</td>");
//        sbHtml.Append("<td width='33%' style='vertical-align:middle;font-size:13px;font-weight: bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Scope</td>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366; background-color:#FFCC00'>Critical Success Factor</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sBusinessCase);
//        sbHtml.Append("</td>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sScope);
//        sbHtml.Append("</td>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sSuccessFactor);
//        sbHtml.Append("</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Objectives</td>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Deliverables</td>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Key Activities/Milestones/Dates</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sObjectives);
//        sbHtml.Append("</td>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sDeliverables);
//        sbHtml.Append("</td>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sKeyActivities);
//        sbHtml.Append("</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Team Member</td>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Benefits</td>");
//        sbHtml.Append("<td style='vertical-align:middle;font-size:13px;font-weight:bold;font-family:Arial;color:#003366;background-color:#FFCC00'>Measures</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("<tr>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sTeamMembers);
//        sbHtml.Append("</td>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sBenefits);
//        sbHtml.Append("</td>");
//        sbHtml.Append("<td>");
//        sbHtml.Append(rptInitiative.m_sMeasures);
//        sbHtml.Append("</td>");
//        sbHtml.Append("</tr>");
//        sbHtml.Append("</table>");
//        sbHtml.Append("</body>");
//        sbHtml.Append("</html>");
//        }
//    catch (Exception ex)
//    {
//        appMonitor.logAppExceptions(ex);
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }

//    return sbHtml;
//}

//public void ExportToPDF(System.Web.HttpResponse Response, System.Text.StringBuilder sbHtml) //(ByVal dt As System.Data.DataTable, ByVal response As System.Web.HttpResponse)
//{
//    Response.ContentType = "application/pdf";
//    Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
//    Response.Cache.SetCacheability(HttpCacheability.NoCache);
//    StringWriter sw = new StringWriter(sbHtml);
//    HtmlTextWriter hw = new HtmlTextWriter(sw);
//    //Page.RenderControl(hw);
//    StringReader sr = new StringReader(sw.ToString());
//    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
//    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
//    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
//    pdfDoc.Open();
//    htmlparser.Parse(sr);
//    pdfDoc.Close();
//    Response.Write(pdfDoc);
//    Response.End();
//}

//public void ExportReportToPDF(long lIntiativeId)
//{
//    System.Text.StringBuilder sbHtml = ConvertToHtml(lIntiativeId);
//    string sPath = Server.MapPath("~/Report/NewInitiative.pdf");
//    // create file stream to PDF file to write to
//    using (Stream stream = new FileStream(sPath, FileMode.OpenOrCreate))
//    {
//        // create new instance of Pdfizer
//        Pdfizer.HtmlToPdfConverter htmlToPdf = new Pdfizer.HtmlToPdfConverter();
//        // open stream to write Pdf to to
//        htmlToPdf.Open(stream);
//        // write the HTML to the component
//        htmlToPdf.Run(sbHtml.ToString().Replace("&", "&amp;"));
//        // close the write operation and complete the PDF file
//        htmlToPdf.Close();
//        Response.WriteFile(sPath);
//    }
//}

//public void ExportToPDF2(System.Web.HttpResponse response, System.Text.StringBuilder sbHTML)
//{
//    //'Create a dummy GridView 
//    System.Web.UI.WebControls.GridView grdView = new System.Web.UI.WebControls.GridView();
//    grdView.AllowPaging = false;
//    grdView.DataSource = sbHTML;
//    grdView.DataBind();

//    response.ContentType = "application/pdf";
//    response.AddHeader("content-disposition", "attachment;filename=Reports.pdf");
//    response.Cache.SetCacheability(HttpCacheability.NoCache);
//    System.IO.StringWriter sw = new System.IO.StringWriter();
//    System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
//    grdView.RenderControl(hw);
//    System.IO.StringReader sr = new System.IO.StringReader(sw.ToString());

//    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 30f);
//    //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);

//    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
//    Font times = new Font(bfTimes, 22, Font.BOLD, BaseColor.BLACK);

//    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
//    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, response.OutputStream);


//    //'create an instance of your PDFpage class. This is the class we generated above.
//    PdfPage page;

//    //set the PageEvent of the pdfWriter instance to the instance of our PDFPage class
//    ////pdfWriter.PageEvent = page;


//    pdfDoc.Open();

//    //'Add Image
//    String imagePath = HttpContext.Current.Server.MapPath("Images");
//    try
//    {
//        //Dim gif As Image = Image.GetInstance(imagePath & "/logo.gif")
//        //Dim Para As Paragraph = New Paragraph("Business Plan Data Management System Report: PPS Codes", times)

//        //Dim table As PdfPTable = New PdfPTable(2)
//        //Dim widths As Single() = New Single() {1.0F, 6.0F}
//        //table.SetWidths(widths)
//        //table.HorizontalAlignment = 0
//        //table.SpacingBefore = 20.0F
//        //table.SpacingAfter = 20.0F

//        //Dim cell1 As PdfPCell = New PdfPCell()
//        //Dim cell2 As PdfPCell = New PdfPCell()

//        //cell1.Border = 0
//        //cell2.Border = 0

//        //cell2.VerticalAlignment = Element.ALIGN_CENTER

//        //cell1.AddElement(gif)
//        //cell2.AddElement(Para)

//        //table.AddCell(cell1) 'col 1 row 1
//        //table.AddCell(cell2) 'col 2 row 1
//        //pdfDoc.Add(table)
//    }
//    catch (Exception ex)
//    {
//        //'MessageBox.Show("")
//    }

//    htmlparser.Parse(sr);
//    pdfDoc.Close();

//    response.Write(pdfDoc);
//    response.End();
//}

//protected void process(object sender, CommandEventArgs e)
//{
//    Response.ContentType = "application/pdf";
//    Response.AppendHeader("Content-Disposition", "attachment; filename=table.pdf");
//    var doc = new Document();
//    PdfWriter.GetInstance(doc, Response.OutputStream);
//    doc.Open();
//    var html = new System.Text.StringBuilder();
//    var stringWriter = new StringWriter(html);
//    var htmlWriter = new HtmlTextWriter(stringWriter);
//    RenderControl(htmlWriter);
//    var interfaceProps = new Dictionary<string, Object>();
//    /*
//     * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//     * HTMLWorker does **NOT** understand relative URLs, make it absolute
//     * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//     */
//    var ih = new ImageHander() { BaseUri = Request.Url.ToString() };
//    /*
//     * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//     * dictionary key 'img_provider' is **HARD-CODED** (iTextSharp 5.0.0 - 5.0.5)
//     * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//     */
//    // interfaceProps.Add("img_provider", ih);
//    /*
//     * constant added in 5.0.6
//     */
//    interfaceProps.Add(HTMLWorker.IMG_PROVIDER, ih);
//    foreach (IElement element in HTMLWorker.ParseToList(
//        new StringReader(html.ToString()), null, interfaceProps))
//    {
//        doc.Add(element);
//    }
//    doc.Close();
//    Response.End();
//}
///* #######################################################################################
// * nested class that implements IImageProvider to handler <img> tags in the             ##
// * HtmlControl with relative URLs:                                                      ##
// * http://api.itextpdf.com/itext/com/itextpdf/text/html/simpleparser/ImageProvider.html ##
// * #######################################################################################
// */

//public class ImageHander : IImageProvider
//{
//    public string BaseUri;
//    public iTextSharp.text.Image GetImage(string src,
//        // iTextSharp 5.0.6 or higher
//        IDictionary<string, string> h,
//        // iTextSharp 5.0.0 to 5.0.5
//        // Dictionary<string, string> h,
//        ChainedProperties cprops,
//        IDocListener doc)
//    {
//        /*
//         * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//         * HTMLWorker does **NOT** understand relative URLs, make it absolute
//         * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//         */
//        return iTextSharp.text.Image.GetInstance(
//            // file-system path
//          HttpContext.Current.Server.MapPath(
//            new Uri(new Uri(BaseUri), src).AbsolutePath
//          )
//            /*
//             * next line works too; absolute URL
//             */
//            // new Uri(new Uri(BaseUri), src)
//        );
//    }
//}


//protected void ButtonCreatePdf_Click(object sender, EventArgs e)
//{
//    //Set content type in response stream
//    Response.ContentType = "application/pdf";
//    Response.AddHeader("content-disposition", "attachment;filename=FileName.pdf");
//    Response.Cache.SetCacheability(HttpCacheability.NoCache);

//    //Render PlaceHolder to temporary stream
//    System.IO.StringWriter stringWrite = new StringWriter();
//    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
//    PlaceholderPdf.RenderControl(htmlWrite);

//    StringReader reader = new StringReader(stringWrite.ToString());

//    //Create PDF document
//    Document doc = new Document(PageSize.A4);
//    .itextpdf.text.html.simpleparser parser = new HTMLWorker(doc);
//    PdfWriter.GetInstance(doc, Response.OutputStream);
//    doc.Open();

//    try
//    {
//        //Create a footer that will display page number
//        HeaderFooter footer = new HeaderFooter(new Phrase("This is page: "), true) { Border = Rectangle.NO_BORDER };
//        doc.Footer = footer;

//        //Parse Html
//        parser.Parse(reader);
//    }

//    catch (Exception ex)
//    {
//        //Display parser errors in PDF.
//        //Parser errors will also be wisible in Debug.Output window in VS
//        Paragraph paragraph = new Paragraph("Error! " + ex.Message);
//        paragraph.SetAlignment("center");
//        Chunk text = paragraph.Chunks[0] as Chunk;

//        if (text != null)
//        {
//            text.Font.Color = Color.RED;
//        }
//        doc.Add(paragraph);
//    }
//    finally
//    {
//        doc.Close();
//    }
//}


//public enum ReportFileName
//{
//    mainReport = 1
//};

//public string sReportFileName(ReportFileName eReportFileName)
//{
//    string sRet = "UnKnown File";
//    try
//    {
//        switch (eReportFileName)
//        {
//            case ReportFileName.mainReport: sRet = "MainReport.rdlc"; break;
//        }
//    }
//    catch (Exception ex)
//    {
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    return sRet;
//}

//public enum ReportSource
//{
//    BusinessInitiative = 1,
//    ImpactedArea = 2,
//    ImpactedAreaDistrict = 3
//};

//public string sReportDataSource(ReportSource eReportDataSource)
//{
//    string sRet = "UnKnown File";
//    try
//    {
//        switch (eReportDataSource)
//        {
//            case ReportSource.BusinessInitiative: sRet = "Report_BusinessInitiative"; break;
//            case ReportSource.ImpactedArea: sRet = "Report_ImpactedArea"; break;
//            case ReportSource.ImpactedAreaDistrict: sRet = "Report_ImpactedAreaDistricts"; break;
//        }
//    }
//    catch (Exception ex)
//    {
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    return sRet;
//}

//protected void exportReportLinkButton_Click(object sender, EventArgs e)
//{
//    if (Request.QueryString["IntiativeId"] != null)
//    {
//        long lIntiativeId = long.Parse(Encoder.HtmlEncode(Request.QueryString["IntiativeId"].ToString()));
//        Init_Page(lIntiativeId);
//    }
//}


#endregion