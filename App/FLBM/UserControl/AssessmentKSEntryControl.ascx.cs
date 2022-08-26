using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FLBM_UserControl_AssessmentKSEntryControl : System.Web.UI.UserControl
{
    //AssessmentKSCriteria tAssessmentKSCriteria = new AssessmentKSCriteria();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCompetencyId = Convert.ToInt32(HFCompetence.Value);
        int iProficiencyId = Convert.ToInt32(HFProficiency.Value);

        AddAssessmentCriteria(iCompetencyId, iProficiencyId);
    }

    private void AddAssessmentCriteria(int iCompetencyId, int iProficiencyId)
    {
        AssessmentKSCriteria oAssessmentKSCriteria = new AssessmentKSCriteria();

        oAssessmentKSCriteria.iCompetencyId = iCompetencyId;
        oAssessmentKSCriteria.iProficiencyId = iProficiencyId;
        oAssessmentKSCriteria.sLevel = txtLevel.Text;
        oAssessmentKSCriteria.sCriteria = txtCriteria.Text;
        oAssessmentKSCriteria.sEvidence = txtEvidence.Text;


        bool bRet = oAssessmentKSCriteria.CreateCriteria(oAssessmentKSCriteria);
        if(bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Successful!!!");
        }
    }

    public void setCompetence(string iCompetence)
    {
        HFCompetence.Value = iCompetence;
    }

    public void setProficiency(string iProficiency)
    {
        HFProficiency.Value = iProficiency;
    }

    //public HiddenField CompetenceHiddenField
    //{
    //    get
    //    {
    //        return HFCompetence;
    //    }

    //    set
    //    {
    //        HFCompetence.Value = value;
    //    }
    //}

    //public HiddenField ProficiencyHiddenField
    //{
    //    get
    //    {
    //        return HFProficiency;
    //    }
    //}
}