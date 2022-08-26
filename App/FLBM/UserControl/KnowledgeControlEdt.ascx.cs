using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class App_FLBM_UserControl_KnowledgeControlEdt : aspnetUserControl
{
    RequiredEvidence tRequiredEvidence = new RequiredEvidence();
    KnowledgeSkillManager tKnowledgeSkill = new KnowledgeSkillManager();
    KnowledgeSkillAssessorAssesseInfo tKnowledgeSkillAssessorAssesseInfo = new KnowledgeSkillAssessorAssesseInfo();
    KnowledgeSkillSheet tKnowledgeSkillSheet = new KnowledgeSkillSheet();
    KnowledgeSkillScores tKnowledgeSkillScores = new KnowledgeSkillScores();

    KnowledgeSkillAssessorAssesseInfo oKnowledgeSkillAssessorAssesseInfo = new KnowledgeSkillAssessorAssesseInfo();
    KnowledgeSkillSheet oKnowledgeSkillSheet = new KnowledgeSkillSheet();
    KnowledgeSkillScores oKnowledgeSkillScores = new KnowledgeSkillScores();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void RetrieveAssessment(long lAssessId)
    {
        Competencies oCompetency = new Competencies();
        //pnlAssementSheet.Visible = true;

        KnowledgeSkillAssessorAssesseInfo o = tKnowledgeSkillAssessorAssesseInfo.ObjGetAssessmentHeaderByAssessId(lAssessId);

        //Get the Assessee
        txtAssessee.editMode();
        appUsers oAssessee = appUsersHelper.objGetUserByUserId(o.iAssesseeId);
        txtAssessee.thisDropDownList.Items.Add(new ListItem(oAssessee.m_sFullName, oAssessee.m_iUserId.ToString()));
        txtAssessee.thisDropDownList.SelectedValue = o.iAssesseeId.ToString();

        //Get the Assessor
        txtAssessor.Text = oSessnx.getOnlineUser.m_sFullName;

        Utilities.LoadGroups(ddlGroup);
        int iGroupId = oCompetency.ObjGetCompetenceById(o.iCompetenceId).iGroupId;
        ddlGroup.SelectedValue = iGroupId.ToString();

        Utilities.LoadCompetenciesByGroup(iGroupId, ddlCompetency);
        ddlCompetency.SelectedValue = o.iCompetenceId.ToString();

        Utilities.LoadProficiencies(ddlProficiency);
        ddlProficiency.SelectedValue = o.iProficiencyId.ToString();

        lblCompetenceDescription.Text = oCompetency.ObjGetCompetenceById(o.iCompetenceId).sCompetenceDescription;
        
        RetrieveAccessmentDataSheet(o.iProficiencyId, o.iAssesseeId);

        ddlCompetency.Enabled = false;
        ddlGroup.Enabled = false;
        ddlProficiency.Enabled = false;
    }

    public void RetrieveAccessmentDataSheet(int iProficiency, int iAssesseId)
    {
        grdView.DataSource = tKnowledgeSkill.DtGetAssessmentSheetByProficiencyCompetenceEdt(iProficiency, iAssesseId);
        grdView.DataBind();

        LoadAssessmentEvidence(grdView);
        RetrieveEvidenceResult(grdView);
    }
    private void LoadAssessmentEvidence(GridView oGrd)
    {
        foreach (GridViewRow grdRows in oGrd.Rows)
        {
            RadioButtonList rblYesNo = (RadioButtonList)grdRows.FindControl("rblYesNo");
            int iAchieved = string.IsNullOrEmpty(rblYesNo.Attributes["ACHIEVED"]) ? 0 : int.Parse(rblYesNo.Attributes["ACHIEVED"]);
            rblYesNo.SelectedValue = iAchieved.ToString();

            CheckBoxList lnkEvidence = (CheckBoxList)grdRows.FindControl("ckbEvidence");
            int iAssessmentId = int.Parse(lnkEvidence.Attributes["ASSESSMENTID"]);

            List<RequiredEvidence> o = tRequiredEvidence.LstRequiredEvidenceByAssessment(iAssessmentId);
            foreach (RequiredEvidence evidence in o)
            {
                lnkEvidence.Items.Add(new ListItem(evidence.sEvidence, evidence.iEvidenceId.ToString()));
            }
        }
    }

    private void RetrieveEvidenceResult(GridView oGrd)
    {
        foreach (GridViewRow grdRows in oGrd.Rows)
        {
            Label lblLevel = (Label)grdRows.FindControl("lblLevel");
            long lSheetId = int.Parse(lblLevel.Attributes["SHEETID"]);

            CheckBoxList ckbEvidence = (CheckBoxList)grdRows.FindControl("ckbEvidence");
            List<KnowledgeSkillScores> oLst = tKnowledgeSkillScores.LstGetKnowledgeSkillScoresBySheetId(lSheetId);
            foreach (KnowledgeSkillScores o in oLst)
            {
                foreach (ListItem li in ckbEvidence.Items)
                {
                    if (o.iEvidenceId == long.Parse(li.Value))
                    {
                        if (o.iScore == 1)
                            li.Selected = true;
                    }
                }
            }
        }
    }


    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }


    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/FLBM/Default.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["lAssessId"]))
        {
            long lAssessId = long.Parse(Request.QueryString["lAssessId"]);

            // Save the Assessment Header, return the AssessId
            oKnowledgeSkillAssessorAssesseInfo.lAssessId = lAssessId;
            oKnowledgeSkillAssessorAssesseInfo.iAssesseeId = int.Parse(txtAssessee._SelectedValue);
            oKnowledgeSkillAssessorAssesseInfo.iAssessorId = oSessnx.getOnlineUser.m_iUserId;
            oKnowledgeSkillAssessorAssesseInfo.iCompetenceId = int.Parse(ddlCompetency.SelectedValue);
            oKnowledgeSkillAssessorAssesseInfo.iProficiencyId = int.Parse(ddlProficiency.SelectedValue);

            bool bRet = tKnowledgeSkillAssessorAssesseInfo.UpdateAssessorAssesseInfo(oKnowledgeSkillAssessorAssesseInfo);
            if (bRet)
            {
                foreach (GridViewRow grdRows in grdView.Rows)
                {
                    oKnowledgeSkillSheet.lAssessId = lAssessId;

                    Label lblLevel = (Label)grdRows.FindControl("lblLevel");
                    oKnowledgeSkillSheet.lSheetId = long.Parse(lblLevel.Attributes["SHEETID"]);
                    oKnowledgeSkillSheet.lAssessmentId = long.Parse(lblLevel.Attributes["ASSESSMENTID"]);
                    
                    TextBox txtComment = (TextBox)grdRows.FindControl("txtComment");
                    oKnowledgeSkillSheet.sComments = txtComment.Text;

                    RadioButtonList rblYesNo = (RadioButtonList)grdRows.FindControl("rblYesNo");
                    oKnowledgeSkillSheet.iAchieved = int.Parse(rblYesNo.SelectedValue);

                    oKnowledgeSkillSheet.dDateAchieved = DateTime.Today.Date;

                    bRet = tKnowledgeSkillSheet.UpdateAssessmentScore(oKnowledgeSkillSheet);
                    if (bRet)
                    {
                        CheckBoxList ckbEvidence = (CheckBoxList)grdRows.FindControl("ckbEvidence");
                        foreach (ListItem li in ckbEvidence.Items)
                        {
                            oKnowledgeSkillScores.iScore = (li.Selected) ? 1 : 0;
                            oKnowledgeSkillScores.iSheetId = long.Parse(lblLevel.Attributes["SHEETID"]);
                            oKnowledgeSkillScores.iEvidenceId = int.Parse(li.Value);
                            //oKnowledgeSkillScores.iScoreId = //int.Parse(li.Value);

                            //Save to the result (score) table
                            bRet = tKnowledgeSkillScores.UpdateScore(oKnowledgeSkillScores);
                        }
                    }
                }
            }
            if (bRet)
            {
                AssessIdHF.Value = lAssessId.ToString();
                ajaxWebExtension.showJscriptAlert(Page, this, "COMPETENCE ASSESSMENT PERFORMANCE Successfully Submitted!!!");
                //ajaxWebExtension.showJscriptAlert(Page, this, "COMPETENCE ASSESSMENT PERFORMANCE Successfully Submitted!!!");

                //Disable the Submit button
                //btnUpdate.Visible = true;

                //Response.Redirect("~/App/FLBM/Assessment.aspx?lAssessId=" + lAssessId);
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Assessment Record not found.");
        }
    }

    //public List<Benefits> LstBenefits(int iProficiency)
    //{
    //    DataTable dt = DtGetAssessmentSheetByProficiency(iProficiency);

    //    List<Benefits> lstBenefit = new List<Benefits>(dt.Rows.Count);
    //    lstBenefit.AddRange(from DataRow dr in dt.Rows select new Benefits(dr));
    //    return lstBenefit;
    //}


    //public void LoadNewAccessmentDataSheet(int iProficiency)
    //{
    //    grdView.DataSource = tKnowledgeSkill.DtGetNewAssessmentSheetByProficiency(iProficiency);
    //    grdView.DataBind();
    //}

    #region  Loading the empty sheet, when it has not been assigned to anyone
    //public void LoadAccessmentDataSheet(int iProficiency, int iCompetenceId)
    //{
    //    grdView.DataSource = tKnowledgeSkill.DtGetAssessmentSheetByProficiencyCompetence(iProficiency, iCompetenceId);
    //    grdView.DataBind();

    //    LoadAssessmentEvidence(grdView);
    //}


    #endregion

    //protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Utilities.LoadCompetenciesByGroup(int.Parse(ddlGroup.SelectedValue), ddlCompetency);
    //    grdView.DataSource = null;
    //    grdView.DataBind();
    //}
    //protected void ddlCompetency_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Utilities.LoadProficiencies(ddlProficiency);
    //    grdView.DataSource = null;
    //    grdView.DataBind();
    //}
    //protected void ddlProficiency_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    pnlAssementSheet.Visible = true;

    //    LoadAccessmentDataSheet(int.Parse(ddlProficiency.SelectedValue), int.Parse(ddlCompetency.SelectedValue));

    //    //if (!string.IsNullOrEmpty(Request.QueryString["lAssessId"]))
    //    //{
    //    //    LoadAccessmentDataSheet(int.Parse(ddlProficiency.SelectedValue));
    //    //}
    //    //else
    //    //{
    //    //    LoadNewAccessmentDataSheet(int.Parse(ddlProficiency.SelectedValue));
    //    //}
    //}

    //public void NoAssessmentRight()
    //{
    //    pnlAssementSheet.Visible = false;
    //    //txtAssessor.Text = oSessnx.getOnlineUser.m_sFullName;
    //    //Utilities.LoadGroups(ddlGroup);

    //    //Disable the Submit and update buttons
    //    btnUpdate.Visible = false;
    //    ajaxWebExtension.showJscriptAlert(Page, this, "Please, you do not have the right to carry out competence assessment. Contact the administrator for access right!!! Thank you.");
    //}

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utilities.LoadCompetenciesByGroup(int.Parse(ddlGroup.SelectedValue), ddlCompetency);
        grdView.DataSource = null;
        grdView.DataBind();
    }
    protected void ddlCompetency_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utilities.LoadProficiencies(ddlProficiency);
        grdView.DataSource = null;
        grdView.DataBind();
    }
    protected void ddlProficiency_SelectedIndexChanged(object sender, EventArgs e)
    {
        //pnlAssementSheet.Visible = true;

        //RetrieveAccessmentDataSheet(int.Parse(ddlProficiency.SelectedValue), int.Parse(ddlCompetency.SelectedValue));

        //if (!string.IsNullOrEmpty(Request.QueryString["lAssessId"]))
        //{
        //    LoadAccessmentDataSheet(int.Parse(ddlProficiency.SelectedValue));
        //}
        //else
        //{
        //    LoadNewAccessmentDataSheet(int.Parse(ddlProficiency.SelectedValue));
        //}
    }
}