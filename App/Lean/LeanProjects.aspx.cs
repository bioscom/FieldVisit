using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_Projects : aspnetPage
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    appUsersHelper oAppUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersLeanRoles.userRole.Administrator.ToString(), appUsersLeanRoles.userRole.LeanCoach.ToString(), appUsersLeanRoles.userRole.User.ToString() };
            appUsersLeanRoles oAccess = new appUsersLeanRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersLeanRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdLean);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            List<int> iYears = oMainProjectHelper.lstYears();
            foreach (int iYear in iYears)
            {
                ddlYear.Items.Add(iYear.ToString());
            }

            List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in oFunctions)
            {
                ddlFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
            }

            if (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator)
            {
                foreach (GridViewRow grdRow in grdGridView.Rows)
                {
                    LinkButton deleteLinkButton = (LinkButton)grdRow.FindControl("deleteLinkButton");
                    if (deleteLinkButton != null)
                    {
                        deleteLinkButton.Visible = true;
                        deleteLinkButton.Attributes.Add("onclick", "return DeleteProject()");
                    }
                    else
                    {
                        deleteLinkButton.Visible = false;
                    }
                }
            }

            LoadProjects();
        }
    }
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        LoadProjectByCriteria();
    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        DataSorter sortMe = new DataSorter();

        //try
        //{
            if ((ButtonClicked == "Sort") || (ButtonClicked == "Page"))
            {
                //CurrentSortExpression = sortMe.MySortExpression(e);

                //int result;
                //if (Int32.TryParse(e.CommandArgument.ToString(), out result) == false)
                //{
                //    Session["SortExpression"] = e.CommandArgument.ToString();
                //}
                //CurrentSortExpression = Session["SortExpression"].ToString();
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

                if (ButtonClicked == "Project")
                {
                    LinkButton lbProjectLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("ProjectLinkButton");
                    long ProjectId = long.Parse(lbProjectLinkButton.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/IES.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "ViewProject")
                {
                    LinkButton lbProjectLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("ViewLinkButton");
                    long ProjectId = long.Parse(lbProjectLinkButton.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/Report/MainReport.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "EditProject")
                {
                    LinkButton lbEditLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("EditLinkButton");
                    long ProjectId = long.Parse(lbEditLinkButton.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/EditLeanProject.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "IES")
                {
                    LinkButton lbIES = (LinkButton)grdGridView.Rows[index].FindControl("IESLinkButton");
                    long ProjectId = long.Parse(lbIES.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/IES.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "VSM")
                {
                    LinkButton lbVSM = (LinkButton)grdGridView.Rows[index].FindControl("VsmLinkButton");
                    long ProjectId = long.Parse(lbVSM.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/AsIsVsm.aspx" + "?ProjectId=" + ProjectId, false);
                }

                //if (ButtonClicked == "KaizenAction")
                //{
                //    LinkButton lbKaizenAction = (LinkButton)grdGridView.Rows[index].FindControl("KaizenLinkButton");
                //    long ProjectId = long.Parse(lbKaizenAction.Attributes["IDPROJECT"].ToString());
                //    Response.Redirect("~/App/Lean/KaizenAction.aspx" + "?ProjectId=" + ProjectId, false);
                //}

                if (ButtonClicked == "Benefit")
                {
                    LinkButton lbBenefit = (LinkButton)grdGridView.Rows[index].FindControl("BenefitLinkButton");
                    long ProjectId = long.Parse(lbBenefit.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/Benefit.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "Recommendations")
                {
                    LinkButton lbRecommendations = (LinkButton)grdGridView.Rows[index].FindControl("RecommendationsLinkButton");
                    long ProjectId = long.Parse(lbRecommendations.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/ProjectRecommendation.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "LoadDocs")
                {
                    LinkButton lbLoadDocs = (LinkButton)grdGridView.Rows[index].FindControl("DocsLinkButton");
                    long ProjectId = long.Parse(lbLoadDocs.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/LoadDocs.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "Assessment")
                {
                    LinkButton lbAssessment = (LinkButton)grdGridView.Rows[index].FindControl("AssessmentLinkButton");
                    long ProjectId = long.Parse(lbAssessment.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/AssessmentQuiz.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "DeleteThis")
                {
                    bool bRet = false;

                    LinkButton lbDelete = (LinkButton)grdGridView.Rows[index].FindControl("deleteLinkButton");
                    long ProjectId = long.Parse(lbDelete.Attributes["IDPROJECT"].ToString());

                    LinkButton ProjectLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("ProjectLinkButton");

                    bool bRet2 = ajaxWebExtension.showJscriptAlert(Page, this, "Are you sure you want to delete project, " + ProjectLinkButton.Text + "? \nNote that deleted project can no longer be recovered!!!");

                    if (bRet2)
                    {
                        string sql0 = "DELETE FROM LEAN_ASSESSMENT WHERE IDPROJECT = :lProjectId";
                        string sql1 = "DELETE FROM LEAN_ASSESSMENT_CUSTOMERS WHERE IDPROJECT = :lProjectId";
                        string sql2 = "DELETE FROM LEAN_BENEFIT_ACTUAL WHERE IDPROJECT = :lProjectId";
                        string sql3 = "DELETE FROM LEAN_PROJECT_DRB WHERE IDPROJECT = :lProjectId";
                        string sql4 = "DELETE FROM LEAN_ELIMINATE WHERE IDPROJECT = :lProjectId";
                        string sql5 = "DELETE FROM LEAN_IDENTIFY WHERE IDPROJECT = :lProjectId";
                        string sql6 = "DELETE FROM LEAN_PROJECT_IMPR_REC WHERE IDPROJECT = :lProjectId";
                        string sql7 = "DELETE FROM LEAN_PROJECT_TEAM WHERE IDPROJECT = :lProjectId";
                        string sql8 = "DELETE FROM LEAN_SUSTAIN WHERE IDPROJECT = :lProjectId";
                        string sql9 = "DELETE FROM LEAN_VSMASIS WHERE IDPROJECT = :lProjectId";
                        string sql10 = "DELETE FROM LEAN_PROJECTS WHERE IDPROJECT = :lProjectId";

                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql0);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql1);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql2);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql3);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql4);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql5);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql6);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql7);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql8);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql9);
                        bRet = oMainProjectHelper.DeleteProject(ProjectId, sql10);

                        if (bRet)
                        {
                            ajaxWebExtension.showJscriptAlert(Page, this, ProjectLinkButton.Text + ", project successfully deleted.");
                        }
                        else
                        {
                            ajaxWebExtension.showJscriptAlert(Page, this, ProjectLinkButton.Text + ", project can not be deleted, try again later.");
                        }
                        LoadProjectByCriteria();
                    }
                }
            }
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }
    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void LoadProjects()
    {
        MainProjectHelper oMainProjectHelper = new MainProjectHelper();
        if ((oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator) || (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetLeanProjects();
        }
        else
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetMyProjects(oSessnx.getOnlineUser.m_iUserId);
        }
        grdGridView.DataBind();
        getProjectCoach();
    }

    private void getProjectCoach()
    {
        foreach(GridViewRow grdRow in grdGridView.Rows)
        {
            Label labelCoach = (Label)grdRow.FindControl("labelCoach");
            LinkButton lnkEdit = (LinkButton)grdRow.FindControl("EditLinkButton");
            long ProjectId = long.Parse(lnkEdit.Attributes["IDPROJECT"].ToString());
            List<ProjectCoaches> lstProjectCoached = oMainProjectHelper.lstProjectCoaches(ProjectId);
            foreach (ProjectCoaches oProjectCoach in lstProjectCoached)
            {
                labelCoach.Text += oAppUsersHelper.objGetUserByUserID(oProjectCoach.iUserId).m_sFullName + "; ";
            }
        }
    }
    private void LoadProjectsByYear()
    {
        if ((oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator) || (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetLeanProjectsByYear(int.Parse(ddlYear.SelectedValue));
        }
        else
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetMyProjectsByYear(oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlYear.SelectedValue));
        }
        grdGridView.DataBind(); 
        getProjectCoach();
    }
    private void LoadProjectsByFunctionYear()
    {
        if ((oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator) || (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetLeanProjectsByFunctionYear(int.Parse(ddlFunction.SelectedValue), int.Parse(ddlYear.SelectedValue));
        }
        else
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetMyProjectsByYearFunction(oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlFunction.SelectedValue), int.Parse(ddlYear.SelectedValue));
        }
        grdGridView.DataBind();
        getProjectCoach();
    }
    private void LoadProjectsByFunction()
    {
        if ((oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator) || (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetLeanProjectsByFunction(int.Parse(ddlFunction.SelectedValue));
        }
        else
        {
            grdGridView.DataSource = oMainProjectHelper.dtGetMyProjectsByFunction(oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlFunction.SelectedValue));
        }
        grdGridView.DataBind();
        getProjectCoach();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProjectByCriteria();
    }
    protected void ddlFunction_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProjectByCriteria();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/Default.aspx");
    }
    private void LoadProjectByCriteria()
    {
        if ((ddlYear.SelectedValue == "-1") && (ddlFunction.SelectedValue == "-1"))
        {
            LoadProjects();
        }
        else if ((ddlYear.SelectedValue != "-1") && (ddlFunction.SelectedValue == "-1"))
        {
            LoadProjectsByYear();
        }
        else if ((ddlYear.SelectedValue == "-1") && (ddlFunction.SelectedValue != "-1"))
        {
            LoadProjectsByFunction();
        }
        else if ((ddlYear.SelectedValue != "-1") && (ddlFunction.SelectedValue != "-1"))
        {
            LoadProjectsByFunctionYear();
        }
    }
}