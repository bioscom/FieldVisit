using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

public partial class App_FLBM_UserControl_AssessmentCriteriaControl : System.Web.UI.UserControl
{
    Proficiency tProficiency = new Proficiency();
    Group tGroup = new Group();
    Competencies tCompetencies = new Competencies();
    KnowledgeSkillManager tKnowledgeSkillManager = new KnowledgeSkillManager();
    RequiredEvidence tRequiredEvidence = new RequiredEvidence();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        Utilities.LoadGroups(ddlGroup);
        pnlCriteriah.Visible = false;
    }

    private void LoadData()
    {
        grdView.DataSource = DtGetAssessmentSheet();
        grdView.DataBind();

        LoadAssessmentEvidence(grdView);
    }

    private void LoadAssessmentEvidence(GridView oGrd)
    {
        foreach (GridViewRow grdRows in oGrd.Rows)
        {
            LinkButton lnkEvidence = (LinkButton)grdRows.FindControl("AddLinkButton");
            int iAssessmentId = int.Parse(lnkEvidence.Attributes["ASSESSMENTID"]);
            BulletedList blst = (BulletedList)grdRows.FindControl("lstRequiredEvidences");

            List<RequiredEvidence> o = tRequiredEvidence.LstRequiredEvidenceByAssessment(iAssessmentId);
            foreach(RequiredEvidence evidence in o)
            {
                blst.Items.Add(new ListItem(evidence.sEvidence, evidence.iEvidenceId.ToString()));
            }
        }
    }
    

    protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public DataTable DtGetAssessmentSheet()
    {
        string sql = "SELECT ASSESSMENT_KS.ASSESSMENTID, ASSESSMENT_KS.LOGID, ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ASSESMENT_SHEET.SHEETID, ";
        sql += "ASSESMENT_SHEET.ASSESSID, ASSESMENT_SHEET.SCORE, ASSESMENT_SHEET.COMMENTS, ASSESMENT_SHEET.ACHIEVED, ASSESMENT_SHEET.DATE_ACHIEVED ";
        sql += "FROM ASSESMENT_SHEET ";
        sql += "LEFT OUTER JOIN ASSESSMENT_HEADER ON ASSESSMENT_HEADER.ASSESSID = ASSESMENT_SHEET.ASSESSID ";
        sql += "RIGHT OUTER JOIN ASSESSMENT_KS ON ASSESSMENT_KS.ASSESSMENTID = ASSESMENT_SHEET.ASSESSMENTID WHERE ASSESSMENT_KS.LOGID = '1'";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Load Competencies
       Utilities.LoadCompetenciesByGroup(int.Parse(ddlGroup.SelectedValue), ddlCompetency);

       grdView.DataSource = null;
       grdView.DataBind();
    }
    protected void ddlProficiency_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Load assessment criteria by Competency and Proficiency
        pnlCriteriah.Visible = true;

        AssessmentKSEntryControl1.setCompetence(ddlCompetency.SelectedValue);
        AssessmentKSEntryControl1.setProficiency(ddlProficiency.SelectedValue);

        var DtAssessment = tKnowledgeSkillManager.DtGetKnowledgeSkillByCompetenceProficiency(int.Parse(ddlCompetency.SelectedValue), int.Parse(ddlProficiency.SelectedValue));
        grdView.DataSource = DtAssessment;
        grdView.DataBind();

        LoadAssessmentEvidence(grdView);
    }
    protected void ddlCompetency_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Load Proficiencies. Though not dependent, but for user's clarity
        Utilities.LoadProficiencies(ddlProficiency);

        grdView.DataSource = null;
        grdView.DataBind();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void AddLinkButton_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton lnkEdit = (LinkButton)row.FindControl("AddLinkButton");
                //long lRecommendationId = long.Parse(lnkEdit.Attributes["RECOMMENDATIONID"]);

                //lRecommendationIdHF.Value = lRecommendationId.ToString();

                //Recommendations xRecommendation = new Recommendations();
                //RecommendationsHelper oRecommendationsHelper = new RecommendationsHelper();

                //long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                //Recommendations oRecommendations = oRecommendationsHelper.objGetLeanProjectRecommendationById(lRecommendationId);

                //ddlFunction.SelectedValue = oRecommendations.iFunctionId.ToString();
                //Status._SelectedValue(oRecommendations.iStatus);
                //txtChampionComment.Text = oRecommendations.sChampionComment;
                //txtRecommendation.Text = oRecommendations.sRecommendations;
                //txtSponsorComment.Text = oRecommendations.sSponsorComment;
                //targetDate.setDate(oRecommendations.dtTargetDate.ToString("dd/MMM/yyyy"));

                //txtBenefit.Text = oRecommendations.sOtherBenefits;
                //txtComments.Text = oRecommendations.sComments;
                //txtCostReduction.Text = oRecommendations.dCostReduction.ToString();
                //txtCTR.Text = oRecommendations.dCTReduction.ToString();
                //txtProdEnhancmt.Text = oRecommendations.dProductionBarrel.ToString();
                //txtNumber.Text = oRecommendations.dNumber.ToString();
                //ddlActionParty.SelectedValue = oRecommendations.iActionParty.ToString();
                //ddlActionFunction.SelectedValue = oRecommendations.iActionFunction.ToString();

                //oRecommendationsHelper.UpdateRecommendation(xRecommendation);

                //LoadRecommendations(lProjectId);

                //Show ModalPopUpExtender
                MPE2.Show();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

}







