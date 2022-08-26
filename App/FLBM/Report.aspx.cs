using System;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;

public partial class App_FLBM_Report : System.Web.UI.Page
{
    //Proficiency oPro = new Proficiency();
    Competencies oCompetency = new Competencies();
    RequiredEvidence tRequiredEvidence = new RequiredEvidence();
    KnowledgeSkillManager tKnowledgeSkill = new KnowledgeSkillManager();
    KnowledgeSkillAssessorAssesseInfo tKnowledgeSkillAssessorAssesseInfo = new KnowledgeSkillAssessorAssesseInfo();
    //KnowledgeSkillSheet tKnowledgeSkillSheet = new KnowledgeSkillSheet();
    KnowledgeSkillScores tKnowledgeSkillScores = new KnowledgeSkillScores();

    //KnowledgeSkillAssessorAssesseInfo oKnowledgeSkillAssessorAssesseInfo = new KnowledgeSkillAssessorAssesseInfo();
    //KnowledgeSkillSheet oKnowledgeSkillSheet = new KnowledgeSkillSheet();
    //KnowledgeSkillScores oKnowledgeSkillScores = new KnowledgeSkillScores();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["lAssessId"]))
        {
            long lAssessId = long.Parse(Request.QueryString["lAssessId"]);
            //int iAssesseeId = int.Parse(Request.QueryString["iUId"]);
            RptLiteral.Text = ReportHTML(lAssessId);
        }
    }

    public string ReportHTML(long lAssessId)
    {
        KnowledgeSkillAssessorAssesseInfo o = tKnowledgeSkillAssessorAssesseInfo.ObjGetAssessmentHeaderByAssessId(lAssessId);
        StringBuilder sb = new StringBuilder();
        //string textAlignment = " style='padding: 5px;text-align: left;vertical-align: middle;font:bold'";

        Competencies xCompetency = oCompetency.ObjGetCompetenceById(o.iCompetenceId);

        sb.Append("<table border='1' borderColor='#eee' cellSpacing='0' cellPadding='0' style='font-size:9.0pt; font-family:Calibri; background:white; width:99%'>");

        sb.Append("<tr>");
        sb.Append("<td style='padding: 5px'><b>Name of Assessee:</b></div></td>");
        sb.Append("<td style='padding: 5px'>" + appUsersHelper.objGetUserByUserId(o.iAssesseeId).m_sFullName + "</div></td>");
        sb.Append("<td style='padding: 5px'><b>Name of Accessor:</b></td>");
        sb.Append("<td style='padding: 5px'>" + appUsersHelper.objGetUserByUserId(o.iAssessorId).m_sFullName + "</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td style='padding: 5px'><b>Grouping:</b></td>");
        sb.Append("<td style='padding: 5px'>" + Group.ObjGetGroupById(xCompetency.iGroupId).sGroups + "</td>");
        sb.Append("<td style='padding: 5px'><b>Date Asssessed:</b></td>");
        sb.Append("<td style='padding: 5px'>" + dateRoutine.dateLong(o.dDateAssessed) + "</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td style='padding: 5px'><b>Competence:</b></td>");
        sb.Append("<td  style='padding: 5px' colspan='3'>" + xCompetency.sCompetence + "</td>");
        sb.Append("</tr>");

        sb.Append("</table>");

        //sb.Append("<br/>");

        sb.Append("<table border='1' borderColor='#eee' cellSpacing='0' cellPadding='0' style='font-size:9.0pt; font-family:Calibri; background:white; width:99%'>");

        sb.Append("<tr>");
        sb.Append("<td style='padding: 5px' colspan='2'><b>Proficiency:</b></td>");
        sb.Append("<td style='padding: 5px' colspan='2'><b>Knowledge</b></td>");
        sb.Append("<td style='padding: 5px' colspan='3'><b>Evidence Record</b></td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td style='padding: 5px' colspan='4'>");
        sb.Append("<br/>");
        //sb.Append("Operational tasks associated with monitoring and controlling hydrocarbon processes to ensure technical integrity, whilst maximizing availability.This ensures processes stay within predefined limits as specified by regulatory statutes, internal and external guidelines and procedures.");
        sb.Append(xCompetency.sCompetenceDescription);
        sb.Append("</td>");
        sb.Append("<td style='padding: 5px'>");
        sb.Append("STRUCTURED INTERVIEW:");
        sb.Append("<br/>");
        sb.Append("(Using knowledge evidence criteria as stated in this assessor sheet)</td>");
        sb.Append("<td style='padding: 5px' colspan='2'>");
        sb.Append("TEST:");
        sb.Append("1. Written test after completing classroom training");
        sb.Append("<br/>");
        sb.Append("2. Test after completing E-Learning</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        //sb.Append("<br/>");

        sb.Append("<table border='1' borderColor='#eee' cellSpacing='0' cellPadding='0' style='font-size:9.0pt; font-family:Calibri; background:white; width:99%'>");
        sb.Append("<tr>");
        //sb.Append("<td style='width:30px'><b>Level</td>");
        //sb.Append("<td style='width:300px'><b>PERFORMANCE CRITERIA</b></td>");
        //sb.Append("<td style='width:400px'><b>Required Evidence</b></td>");
        //sb.Append("<td style='width:100px'><b>Assessment/Assessor Comments</b></td>");
        //sb.Append("<td style='width:40px'><b>Competence Achieved</b></td>");
        //sb.Append("<td style='width:30px'><b>Date Achieved</b></td>");
        sb.Append("<td style='padding: 5px; width:10px'><b>Level</td>");
        sb.Append("<td style='padding: 5px'><b>PERFORMANCE CRITERIA</b></td>");
        sb.Append("<td style='padding: 5px'><b>Required Evidence</b></td>");
        sb.Append("<td style='padding: 5px'><b>Assessment/Assessor Comments</b></td>");
        sb.Append("<td style='padding: 5px'><b>Competence Achieved</b></td>");
        sb.Append("<td style='padding: 5px'><b>Date Achieved</b></td>");
        sb.Append("</tr>");

        //Get the Assessment Sheet here...
        DateTime dtCompetenceAchieved = new DateTime();
        string CompetenceAchieved = "";
        var oTs = tKnowledgeSkill.LstGetAssessmentSheetByProficiency(o.iProficiencyId);
        foreach (var oT in oTs)
        {
            sb.Append("<tr>");
            sb.Append("<td style='padding: 5px'>" + oT.sLevel + "</td>");
            sb.Append("<td style='padding: 5px'>" + oT.sCriteria + "<br/></td>");

            sb.Append("<td style='padding: 5px'>");
            //sb.Append("<b>" + oT.sEvidence + "</b>");

            sb.Append("<table border='1' borderColor='Silver' cellSpacing='2' cellPadding='2' style='font-size:8.0pt; font-family:Calibri; margin:3px; width:100%'>");

            sb.Append("<tr>");
            sb.Append("<td colspan='2' style='padding: 5px'>");
            sb.Append("<b>" + oT.sEvidence + "</b>");
            sb.Append("</td>");
            sb.Append("</tr>");

            var oRE = tRequiredEvidence.LstRequiredEvidenceByAssessment(oT.lAssessmentId);
            foreach (var evidence in oRE)
            {
                sb.Append("<tr>");
                //sb.Append("<td style='padding: 5px; width:380px'>" + evidence.sEvidence + "</td>");
                sb.Append("<td style='padding: 5px;'>" + evidence.sEvidence + "</td>");

                var tRowColor = "Red";
                var oLst = tKnowledgeSkillScores.LstGetKnowledgeSkillScoresBySheetId(oT.lSheetId);
                foreach (var oLs in oLst)
                {
                    if (evidence.iEvidenceId == oLs.iEvidenceId)
                    {
                        tRowColor = (oLs.iScore == 1) ? "Green" : "Red";
                    }
                }
                sb.Append("<td cellPadding='5' style='background-color:" + tRowColor + "; width:20px; padding: 5px'></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            sb.Append("</td>");

            sb.Append("<td style='padding: 5px'>" + oT.sComments + "</td>");
            CompetenceAchieved = (oT.iAchieved == 1) ? "Yes" : "No";
            sb.Append("<td style='padding: 5px'>" + CompetenceAchieved + "</td>");
            sb.Append("<td style='padding: 5px'>" + dateRoutine.dateStandard(oT.dDateAchieved) + "</td>");
            sb.Append("</tr>");
            dtCompetenceAchieved = oT.dDateAchieved;
        }
        sb.Append("</table>");

        sb.Append("<br/><br/><b style='font-size:12.0pt; font-family:Calibri'>" + Proficiency.ObjGetProficiencyById(o.iProficiencyId).sProficiency + " Assessment Approval</b><br/><br/>");

        sb.Append("<table border='1' borderColor='#eee' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white; width:99%'>");

        sb.Append("<tr>");
        //sb.Append("<td style='width:300px'><b>ALL COMPETENCY ACHIEVED:</b></td>");
        //sb.Append("<td style='width:300px'><b>YES / NO</b></td>");
        sb.Append("<td><b>ALL COMPETENCY ACHIEVED:</b></td>");
        sb.Append("<td><b>YES / NO</b></td>");
        sb.Append("<td><b>Date Achieved:</b></td>");
        sb.Append("<td>" + dateRoutine.dateStandard(dtCompetenceAchieved) + "</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td><b>Assessee Signature:</b></td>");
        sb.Append("<td></td>");
        sb.Append("<td><b>Authorised Assessor Signature:</b></td>");
        //sb.Append("<td style='width:300px'></td>");
        sb.Append("<td></td>");
        sb.Append("</tr>");

        sb.Append("</table>");

        return sb.ToString();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["lAssessId"]))
        {
            long lAssessId = long.Parse(Request.QueryString["lAssessId"]);
            int iAssesseeId = int.Parse(Request.QueryString["iUId"]);
            string Reporter = ReportHTML(lAssessId);
            Exporter(Reporter);
        }
    }

    private void Exporter(string sHtml)
    {
        var output = new MemoryStream();

        try
        {
            // Create a Document object
            var document = new Document(PageSize.A4_LANDSCAPE, 25, 25, 60, 25);

            // Create a new PdfWriter object, specifying the output stream
            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();

            //... Step 3: Add elements to the document! ...
            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/iAssessor.jpg"));
            logo.SetAbsolutePosition(25, 750);
            document.Add(logo);

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

            // Close the Document - this saves the document contents to the output stream
            document.Close();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=FLBM.pdf"));
        Response.BinaryWrite(output.ToArray());

        Response.Flush();
        Response.End();
    }
}