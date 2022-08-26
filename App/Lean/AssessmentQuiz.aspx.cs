using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_Lean_AssessmentQuiz : System.Web.UI.Page
{
    AssessmentHelper oAssessmentQuestionsHelper = new AssessmentHelper();
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ProjectId"].ToString()))
            {
                long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                MainProjects oMainProjects = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);
                oLeanProjectDetails1.Init_Control(oMainProjects);
                LoadData(lProjectId);
            }
        }
    }

    private void LoadData(long lProjectId)
    {
        //Check if the ProjectId exists in the Questionaire or on the Customers Review tables
        grdView.DataSource = oAssessmentQuestionsHelper.dtGetCategories();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblCategory = (Label)grdRow.FindControl("lblCategory");
            int iCategoryId = int.Parse(lblCategory.Attributes["IDCATEGORY"].ToString());

            GridView oGrdView = (GridView)grdRow.FindControl("subGrdView");

            DataTable dtQuestions = oAssessmentQuestionsHelper.dtGetQuestionsByCategoryId(iCategoryId);
            if (dtQuestions.Rows.Count > 0)
            {
                oGrdView.DataSource = dtQuestions;
                oGrdView.DataBind();
            }
        }

        bool bRet = oAssessmentQuestionsHelper.ProjectExistsForAssessment(lProjectId);
        if (bRet)
        {
            assessmentHF.Value = lProjectId.ToString();
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;

            CustomerAssessment oCustomerAssessment = oAssessmentQuestionsHelper.objGetCustomerAssessment(lProjectId);

            txtKeyCustomers.Text = oCustomerAssessment.sKeyCustomers;
            txtNegative.Text = oCustomerAssessment.sNegativeFindings;
            txtPositive.Text = oCustomerAssessment.sPositiveFindings;
            txtReviwers.Text = oCustomerAssessment.sReviewers;


            List<Assessment> lstAssessment = oAssessmentQuestionsHelper.lstAssessmentAsnwers(lProjectId);

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");
                foreach (GridViewRow grdSubRow in oSubGrdView.Rows)
                {
                    Label lblSustainability = (Label)grdSubRow.FindControl("lblSustainability");
                    int iSustainId = int.Parse(lblSustainability.Attributes["IDSUSTAIN"].ToString());

                    RadioButtonList rblYesNo = (RadioButtonList)grdSubRow.FindControl("rblYesNo");
                    foreach (Assessment oAssessment in lstAssessment)
                    {
                        if (iSustainId == oAssessment.iSustainId)
                        {
                            rblYesNo.SelectedValue = oAssessment.iValue.ToString();
                        }
                    }
                }
            }
        }
        else
        {
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        string sMessage = "Assessment successfully submitted.";
        Assessment oAssessment = new Assessment();
        CustomerAssessment oCustomerAssessment = new CustomerAssessment();
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        oAssessment.lProjectId = lProjectId;

        try
        {
            oCustomerAssessment.lProjectId = lProjectId;
            oCustomerAssessment.sKeyCustomers = txtKeyCustomers.Text;
            oCustomerAssessment.sNegativeFindings = txtNegative.Text;
            oCustomerAssessment.sPositiveFindings = txtPositive.Text;
            oCustomerAssessment.sReviewers = txtReviwers.Text;
            oCustomerAssessment.dtAssessed = DateTime.Today.Date;

            bRet = oAssessmentQuestionsHelper.InsertAssessmentReviewers(oCustomerAssessment);

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");
                foreach (GridViewRow grdSubRow in oSubGrdView.Rows)
                {
                    Label lblSustainability = (Label)grdSubRow.FindControl("lblSustainability");
                    oAssessment.iSustainId = int.Parse(lblSustainability.Attributes["IDSUSTAIN"].ToString());

                    RadioButtonList rblYesNo = (RadioButtonList)grdSubRow.FindControl("rblYesNo");
                    foreach (ListItem li in rblYesNo.Items)
                    {
                        if (li.Selected)
                        {
                            oAssessment.iValue = int.Parse(li.Value);
                            bRet = oAssessmentQuestionsHelper.InsertAssessmentAnswer(oAssessment);
                            if (!bRet)
                            {
                                sMessage = "Operation failed, try again later!!!";
                                break;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        string sMessage = "Assessment successfully submitted.";
        Assessment oAssessment = new Assessment();
        CustomerAssessment oCustomerAssessment = new CustomerAssessment();
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        oAssessment.lProjectId = lProjectId;

        oCustomerAssessment.lProjectId = lProjectId;
        oCustomerAssessment.sKeyCustomers = txtKeyCustomers.Text;
        oCustomerAssessment.sNegativeFindings = txtNegative.Text;
        oCustomerAssessment.sPositiveFindings = txtPositive.Text;
        oCustomerAssessment.sReviewers = txtReviwers.Text;
        oCustomerAssessment.dtAssessed = DateTime.Today.Date;

        try
        {
            bRet = oAssessmentQuestionsHelper.UpdateAssessmentReviewers(oCustomerAssessment);

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");
                foreach (GridViewRow grdSubRow in oSubGrdView.Rows)
                {
                    Label lblSustainability = (Label)grdSubRow.FindControl("lblSustainability");
                    oAssessment.iSustainId = int.Parse(lblSustainability.Attributes["IDSUSTAIN"].ToString());

                    RadioButtonList rblYesNo = (RadioButtonList)grdSubRow.FindControl("rblYesNo");
                    foreach (ListItem li in rblYesNo.Items)
                    {
                        if (li.Selected)
                        {
                            oAssessment.iValue = int.Parse(li.Value);
                            bRet = oAssessmentQuestionsHelper.UpdateAssessmentAnswer(oAssessment);
                            if (!bRet)
                            {
                                sMessage = "Operation failed, try again later!!!";
                                break;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
    }
}