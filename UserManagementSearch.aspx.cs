using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagementSearch : System.Web.UI.Page
{
    string sortArgument = "FULLNAME";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("~/UserManagementSearch.aspx?fName=" + userTextBox.Text);

        if (!string.IsNullOrEmpty(Request.QueryString["fName"]))
        {
            string sCriteria = Request.QueryString["fName"].ToString();
            appUsersHelper.SearchUser(grdView, sortArgument, sCriteria);
        }
        
        changeValues();
        changeValuesBI500();
        changeValuesFlrWaiver();
        ChangeValuesPdcc();
        changeValuesLean();
        changeValuesInitiativeMgt();
    }


    //Note that these codes below need to be centralised for the UserManagement Forms

    private void changeValues()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRole")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));
            //
            //labelRoleInitiative
            //
            if (!string.IsNullOrEmpty(userRole.Text))
            {
                if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.admin)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.admin);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.initiator)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.initiator);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.planner)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.sponsor)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.superintendent)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.FunctionalLead)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.AssetOperationsManager)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.champion)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.champion);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.CorporateViewer)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.CorporateViewer);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.focalPoint)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.focalPoint);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.GMProduction)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.GMProduction);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LineManager)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LineManager);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.ProductionServicesManager)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.ProductionServicesManager);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.BusinessImprovementTeam)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.BusinessImprovementTeam);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LeanFocalPoint)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LeanFocalPoint);
            }
        }
    }

    private void changeValuesBI500()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRoleBI")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

            if (!string.IsNullOrEmpty(userRole.Text))
            {
                if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.admin)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.admin);
                else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.initiator)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.initiator);
                else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.AssetOperationsManager)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.AssetOperationsManager);
                else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.sponsor)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.sponsor);
                else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.focalPoint)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.focalPoint);
                else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.BusinessImprovementTeam)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.BusinessImprovementTeam);
                else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.champion)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.champion);
                else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.CorporateViewer)
                    userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.CorporateViewer);
            }
        }
    }

    private void changeValuesFlrWaiver()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRoleFlareWaiver")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

            if (!string.IsNullOrEmpty(userRole.Text))
            {
                if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Administrator)
                    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Administrator);
                else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Approval)
                    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Approval);
                else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Initiator)
                    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Initiator);
                else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.LineManager)
                    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.LineManager);
                else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
                    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssurancePSMgr);
                else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
                    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOffshore);
                else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
                    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOnshore);
            }
        }
    }

    private void ChangeValuesPdcc()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRoleCostTransparency")));
            if (!string.IsNullOrEmpty(userRole.Text))
            {
                if (int.Parse(userRole.Text) == (int)AppUsersPdccRoles.UserRole.Administrator)
                    userRole.Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.Administrator);
                else if (int.Parse(userRole.Text) == (int)AppUsersPdccRoles.UserRole.User)
                    userRole.Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.User);
            }
        }
    }

    private void changeValuesLean()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRoleLean")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

            if (!string.IsNullOrEmpty(userRole.Text))
            {

                if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.Administrator)
                    userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.Administrator);
                else if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.CorporateManager)
                    userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.CorporateManager);
                else if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.LeanCoach)
                    userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.LeanCoach);
                else if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.User)
                    userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.User);
            }
        }
    }

    private void changeValuesInitiativeMgt()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRoleInitiative")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));
            //
            if (!string.IsNullOrEmpty(userRole.Text))
            {
                if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.admin)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.admin);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.initiator)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.initiator);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.planner)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.sponsor)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.superintendent)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.FunctionalLead)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.AssetOperationsManager)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.champion)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.champion);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.CorporateViewer)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.CorporateViewer);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.focalPoint)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.focalPoint);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.GMProduction)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.GMProduction);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LineManager)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LineManager);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.ProductionServicesManager)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.ProductionServicesManager);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.BusinessImprovementTeam)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.BusinessImprovementTeam);
                else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LeanFocalPoint)
                    userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LeanFocalPoint);
            }
        }
    }

    protected void grdView_Sorted(object sender, EventArgs e)
    {

    }
    protected void grdView_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton edit = (LinkButton)row.FindControl("editLinkButton");
        int iUserId = int.Parse(edit.Attributes["USERID"].ToString());

        Response.Redirect("~/EditUser.aspx?UserId=" + iUserId);
        //Response.Redirect("~/EditUser.aspx?UserId=" + iUserId + "&App=" + (int)AppTokens.appTokens.pec);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton)row.FindControl("deleteLinkButton");
        int userID = int.Parse(lnkDelete.Attributes["USERID"].ToString());

        bool success = appUsersHelper.disableUserAccount(userID);
        if (success)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "User successfully disabled.");
        }
    }
}