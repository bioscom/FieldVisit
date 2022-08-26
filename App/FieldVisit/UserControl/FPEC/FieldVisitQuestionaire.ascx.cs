using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class UserControl_FieldVisitQuestionaire : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool InsertCheckList(long iActivity)
    {
        bool bRet = false;
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s1HF.Value), int.Parse(s10Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s2HF.Value), int.Parse(s20Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s3HF.Value), int.Parse(s30Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s4HF.Value), int.Parse(s40Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s5HF.Value), int.Parse(s50Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s6HF.Value), int.Parse(s60Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s7HF.Value), int.Parse(s70Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s8HF.Value), int.Parse(s80Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s9HF.Value), int.Parse(s90Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s10HF.Value), int.Parse(s100Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s11HF.Value), int.Parse(s110Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s12HF.Value), int.Parse(s120Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s13HF.Value), int.Parse(s130Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s14HF.Value), int.Parse(s140Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s15HF.Value), int.Parse(s150Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s16HF.Value), int.Parse(s160Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s17HF.Value), int.Parse(s170Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s18HF.Value), int.Parse(s180Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s19HF.Value), int.Parse(s190Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s20HF.Value), int.Parse(s200Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s21HF.Value), int.Parse(s210Chklst.SelectedValue));
        fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s22HF.Value), int.Parse(s220Chklst.SelectedValue));
        bRet = fieldVisit.newFieldVisitCheckList(iActivity, int.Parse(s23HF.Value), int.Parse(s230Chklst.SelectedValue));

        return bRet;
    }

    public void UpdateCheckList(long iActivity)
    {
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s1HF.Value), int.Parse(s10Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s2HF.Value), int.Parse(s20Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s3HF.Value), int.Parse(s30Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s4HF.Value), int.Parse(s40Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s5HF.Value), int.Parse(s50Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s6HF.Value), int.Parse(s60Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s7HF.Value), int.Parse(s70Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s8HF.Value), int.Parse(s80Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s9HF.Value), int.Parse(s90Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s10HF.Value), int.Parse(s100Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s11HF.Value), int.Parse(s110Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s12HF.Value), int.Parse(s120Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s13HF.Value), int.Parse(s130Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s14HF.Value), int.Parse(s140Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s15HF.Value), int.Parse(s150Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s16HF.Value), int.Parse(s160Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s17HF.Value), int.Parse(s170Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s18HF.Value), int.Parse(s180Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s19HF.Value), int.Parse(s190Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s20HF.Value), int.Parse(s200Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s21HF.Value), int.Parse(s210Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s22HF.Value), int.Parse(s220Chklst.SelectedValue));
        fieldVisit.updateFieldVisitCheckList(iActivity, int.Parse(s23HF.Value), int.Parse(s230Chklst.SelectedValue));

        //updateFieldVisitCheckList
    }

    public void loadQuestionaires()
    {
        List<Questionaire> questionaires = Questionaire.lstGetQuestionaire();
        foreach (Questionaire questionaire in questionaires)
        {
            if (s1Label.Text == "") { s1Label.Text = Encoder.HtmlEncode(questionaire.question); img1.ToolTip = questionaire.description; s1HF.Value = questionaire.questionId.ToString(); }
            else if (s2Label.Text == "") { s2Label.Text = Encoder.HtmlEncode(questionaire.question); img2.ToolTip = questionaire.description; s2HF.Value = questionaire.questionId.ToString(); }
            else if (s3Label.Text == "") { s3Label.Text = Encoder.HtmlEncode(questionaire.question); img3.ToolTip = questionaire.description; s3HF.Value = questionaire.questionId.ToString(); }
            else if (s4Label.Text == "") { s4Label.Text = Encoder.HtmlEncode(questionaire.question); img4.ToolTip = questionaire.description; s4HF.Value = questionaire.questionId.ToString(); }
            else if (s5Label.Text == "") { s5Label.Text = Encoder.HtmlEncode(questionaire.question); img5.ToolTip = questionaire.description; s5HF.Value = questionaire.questionId.ToString(); }
            else if (s6Label.Text == "") { s6Label.Text = Encoder.HtmlEncode(questionaire.question); img6.ToolTip = questionaire.description; s6HF.Value = questionaire.questionId.ToString(); }
            else if (s7Label.Text == "") { s7Label.Text = Encoder.HtmlEncode(questionaire.question); img7.ToolTip = questionaire.description; s7HF.Value = questionaire.questionId.ToString(); }
            else if (s8Label.Text == "") { s8Label.Text = Encoder.HtmlEncode(questionaire.question); img8.ToolTip = questionaire.description; s8HF.Value = questionaire.questionId.ToString(); }
            else if (s9Label.Text == "") { s9Label.Text = Encoder.HtmlEncode(questionaire.question); img9.ToolTip = questionaire.description; s9HF.Value = questionaire.questionId.ToString(); }
            else if (s10Label.Text == "") { s10Label.Text = Encoder.HtmlEncode(questionaire.question); img10.ToolTip = questionaire.description; s10HF.Value = questionaire.questionId.ToString(); }
            else if (s11Label.Text == "") { s11Label.Text = Encoder.HtmlEncode(questionaire.question); img11.ToolTip = questionaire.description; s11HF.Value = questionaire.questionId.ToString(); }
            else if (s12Label.Text == "") { s12Label.Text = Encoder.HtmlEncode(questionaire.question); img12.ToolTip = questionaire.description; s12HF.Value = questionaire.questionId.ToString(); }
            else if (s13Label.Text == "") { s13Label.Text = Encoder.HtmlEncode(questionaire.question); img13.ToolTip = questionaire.description; s13HF.Value = questionaire.questionId.ToString(); }
            else if (s14Label.Text == "") { s14Label.Text = Encoder.HtmlEncode(questionaire.question); img14.ToolTip = questionaire.description; s14HF.Value = questionaire.questionId.ToString(); }
            else if (s15Label.Text == "") { s15Label.Text = Encoder.HtmlEncode(questionaire.question); img15.ToolTip = questionaire.description; s15HF.Value = questionaire.questionId.ToString(); }
            else if (s16Label.Text == "") { s16Label.Text = Encoder.HtmlEncode(questionaire.question); img16.ToolTip = questionaire.description; s16HF.Value = questionaire.questionId.ToString(); }
            else if (s17Label.Text == "") { s17Label.Text = Encoder.HtmlEncode(questionaire.question); img17.ToolTip = questionaire.description; s17HF.Value = questionaire.questionId.ToString(); }
            else if (s18Label.Text == "") { s18Label.Text = Encoder.HtmlEncode(questionaire.question); img18.ToolTip = questionaire.description; s18HF.Value = questionaire.questionId.ToString(); }
            else if (s19Label.Text == "") { s19Label.Text = Encoder.HtmlEncode(questionaire.question); img19.ToolTip = questionaire.description; s19HF.Value = questionaire.questionId.ToString(); }
            else if (s20Label.Text == "") { s20Label.Text = Encoder.HtmlEncode(questionaire.question); img20.ToolTip = questionaire.description; s20HF.Value = questionaire.questionId.ToString(); }
            else if (s21Label.Text == "") { s21Label.Text = Encoder.HtmlEncode(questionaire.question); img21.ToolTip = questionaire.description; s21HF.Value = questionaire.questionId.ToString(); }
            else if (s22Label.Text == "") { s22Label.Text = Encoder.HtmlEncode(questionaire.question); img22.ToolTip = questionaire.description; s22HF.Value = questionaire.questionId.ToString(); }
            else if (s23Label.Text == "") { s23Label.Text = Encoder.HtmlEncode(questionaire.question); img23.ToolTip = questionaire.description; s23HF.Value = questionaire.questionId.ToString(); }
        }
    }

    public void loadFieldVisitDetailsByActivity(long iActivity)
    {
       List<fieldVisitDetailsQuestinaire> questionaireDetails = fieldVisitDetails.lstGetFieldVisitQuestionaireDetailsByActivityId(iActivity);

        foreach (fieldVisitDetailsQuestinaire questionaireDetail in questionaireDetails)
        {
            if (s1HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s10Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s2HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s20Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s3HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s30Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s4HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s40Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s5HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s50Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s6HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s60Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s7HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s70Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s8HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s80Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s9HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s90Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s10HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s100Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s11HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s110Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s12HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s120Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s13HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s130Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s14HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s140Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s15HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s150Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s16HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s160Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s17HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s170Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s18HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s180Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s19HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s190Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s20HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s200Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s21HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s210Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s22HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s220Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
            if (s23HF.Value == questionaireDetail.m_iID_QUESTION.ToString()) { s230Chklst.SelectedValue = questionaireDetail.m_iCHECKLIST.ToString(); }
        }
    }
}
