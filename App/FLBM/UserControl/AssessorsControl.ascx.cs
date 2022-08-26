using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FLBM_UserControl_AssessorsControl : System.Web.UI.UserControl
{
    Assessors oAssessors = new Assessors();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init(object sender, EventArgs e)
    {
        ddlAssessor.resetUserInfo();
        LoadAssessors();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = oAssessors.Insert(int.Parse(ddlAssessor._SelectedValue));
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Assessor successfully added.");
            LoadAssessors();
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Assessor cannot be added, already exists in the list of competency assessors.");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton)row.FindControl("deleteLinkButton");
        int iUserID = int.Parse(lnkDelete.Attributes["USERID"].ToString());

        bool success = oAssessors.RemoveFromAssessorList(iUserID);
        if (success)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "User successfully Removed from competence assessors list.");
            LoadAssessors();
        }
    }

    private void LoadAssessors()
    {
        grdView.DataSource = oAssessors.DtGetAssessors();
        grdView.DataBind();
    }
}