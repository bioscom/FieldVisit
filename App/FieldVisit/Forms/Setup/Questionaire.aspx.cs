using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setup_Questionaire : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFieldVisit);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            loadData();
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        loadData();
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "editThis")
        {
            LinkButton lbEdit = (LinkButton)grdView.Rows[index].FindControl("editLinkButton");
            idQuestionHF.Value = lbEdit.Attributes["ID_QUESTION"].ToString();

            if ((idQuestionHF.Value != null) || (idQuestionHF.Value != ""))
            {
                Questionaire myQuestion = Questionaire.objGetQuestionaireById(int.Parse(idQuestionHF.Value));
                questionaireTextBox.Text = myQuestion.question;
                descriptionTextBox.Text = myQuestion.description;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        int lastSequence = sequenceGenerator.readLastSequence();
        if ((idQuestionHF.Value == null) || (idQuestionHF.Value == ""))
        {
            bool bRet = Questionaire.insertQuestion(lastSequence, questionaireTextBox.Text, descriptionTextBox.Text);
            if (bRet == true)
            {
                sequenceGenerator.writeNextSequence(lastSequence);
                loadData();

                string message = questionaireTextBox.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = Questionaire.updateQuestion(int.Parse(idQuestionHF.Value), questionaireTextBox.Text, descriptionTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = questionaireTextBox.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = Questionaire.dtGetQuestionaire();
        grdView.DataBind();
    }

    private void Clear()
    {
        questionaireTextBox.Text = "";
        descriptionTextBox.Text = "";
        idQuestionHF.Value = "";
    }
}
