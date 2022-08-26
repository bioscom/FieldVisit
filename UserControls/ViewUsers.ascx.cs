using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_ViewUsers : aspnetUserControl
{
    string sortArgument = "FULLNAME";

    protected void Page_Load(object sender, EventArgs e)
    {
        //bool bRet = false; 
        //try
        //{
        //    string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
        //    appUsersRoles oAccess = new appUsersRoles();
        //    bRet = oAccess.grantPageAccess(sPageAccess, this.oSessnx.getOnlineUser.m_eUserRole);
        //}
        //catch (Exception ex)
        //{
        //    appMonitor.logAppExceptions(ex);
        //}
        //if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");
    }

    public void InitPage(int iToken)
    {
        //Note: sToken is used to know which application to add user
        if (iToken == (int)AppTokens.appTokens.BI500)
        {
            appUsersRolesBI500.getUserRoles(ddlUserRole);
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int)AppTokens.appTokens.FlareWaiver)
        {
            appUserRolesFlrWaiver.getUserRoles(ddlUserRole);
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int)AppTokens.appTokens.FourteenDayContract)
        {
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int)AppTokens.appTokens.initiativeMgt)
        {
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int)AppTokens.appTokens.lean)
        {
            appUsersLeanRoles.getUserRoles(ddlUserRole);
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int)AppTokens.appTokens.pec)
        {
            appUsersRoles.getUserRoles(ddlUserRole);
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int) AppTokens.appTokens.pdcc)
        {
            AppUsersPdccRoles.GetUserRoles(ddlUserRole);
            appHF.Value = iToken.ToString();
        }

        BindUserData(sortArgument, int.Parse(appHF.Value));
    }

    protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(ddlUserRole.SelectedValue) == -1)
        {
            BindUserData(sortArgument, int.Parse(appHF.Value));
        }
        else
        {
            BindUserDataByRole(sortArgument, int.Parse(appHF.Value));
        }

    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
        BindUserDataByName(sortArgument, int.Parse(appHF.Value));
    }
    protected void grdView_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;

        if (int.Parse(ddlUserRole.SelectedValue) == -1)
        {
            BindUserData(sortArgument, int.Parse(appHF.Value));
        }
        else
        {
            BindUserDataByRole(sortArgument, int.Parse(appHF.Value));
        }
    }

    protected void grdView_Sorted(object sender, EventArgs e)
    {

    }
    protected void grdView_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    private void BindUserData(string sortArgument, int iToken)
    {
        DataView dv = new DataView();

        if (iToken == (int)AppTokens.appTokens.BI500)
        {
            dv = appUsersHelper.dtGetBIUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesBI500();
        }
        else if (iToken == (int)AppTokens.appTokens.FlareWaiver)
        {
            dv = appUsersHelper.dtGetFlareWaiverUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesFlrWaiver();
        }
        else if (iToken == (int)AppTokens.appTokens.FourteenDayContract)
        {
            dv = appUsersHelper.dtGet14DayContractUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            //TODO:
        }
        else if (iToken == (int)AppTokens.appTokens.initiativeMgt)
        {
            dv = appUsersHelper.dtGetManHrUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            //TODO:
        }
        else if (iToken == (int)AppTokens.appTokens.lean)
        {
            dv = appUsersHelper.dtGetLeanUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesLean();
        }
        else if (iToken == (int)AppTokens.appTokens.pec)
        {
            dv = appUsersHelper.dtGetUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValues();
        }
        else if (iToken == (int)AppTokens.appTokens.pdcc)
        {
            dv = appUsersHelper.DtGetPdccUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            ChangeValuesPdcc();
        }   
    }

    private void BindUserDataByRole(string sortArgument, int iToken)
    {
        DataView dv = new DataView();

        if (iToken == (int)AppTokens.appTokens.BI500)
        {
            dv = appUsersHelper.dtGetBIUsersByRole(int.Parse(ddlUserRole.SelectedValue)).DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesBI500();
        }
        else if (iToken == (int)AppTokens.appTokens.FlareWaiver)
        {
            dv = appUsersHelper.dtGetFlrWaiverUsersByRole(int.Parse(ddlUserRole.SelectedValue)).DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesFlrWaiver();
        }
        else if (iToken == (int)AppTokens.appTokens.FourteenDayContract)
        {
            dv = appUsersHelper.dtGet14DayContractUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            //TODO:
        }
        else if (iToken == (int)AppTokens.appTokens.initiativeMgt)
        {
            dv = appUsersHelper.dtGetManHrUsers().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            //TODO:
        }
        else if (iToken == (int)AppTokens.appTokens.lean)
        {
            dv = appUsersHelper.dtGetLeanUserByRole(int.Parse(ddlUserRole.SelectedValue)).DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesLean();
        }
        else if (iToken == (int)AppTokens.appTokens.pec)
        {
            dv = appUsersHelper.dtGetUsersByRole(int.Parse(ddlUserRole.SelectedValue)).DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValues();
        }
        else if (iToken == (int)AppTokens.appTokens.pdcc)
        {
            dv = appUsersHelper.dtGetUsersByRole(int.Parse(ddlUserRole.SelectedValue)).DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            ChangeValuesPdcc();
        }
    }

    private void BindUserDataByName(string sortArgument, int iToken)
    {
        DataView dv = new DataView();
        
        if (iToken == (int)AppTokens.appTokens.BI500)
        {
            dv = appUsersHelper.dtGetUser().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesBI500();
        }
        else if (iToken == (int)AppTokens.appTokens.FlareWaiver)
        {
            dv = appUsersHelper.dtGetUser().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesFlrWaiver();
        }
        else if (iToken == (int)AppTokens.appTokens.FourteenDayContract)
        {
            dv = appUsersHelper.dtGetUser().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            //TODO:
        }
        else if (iToken == (int)AppTokens.appTokens.initiativeMgt)
        {
            dv = appUsersHelper.dtGetUser().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            //TODO:
        }
        else if (iToken == (int)AppTokens.appTokens.lean)
        {
            dv = appUsersHelper.dtGetLeanUserBySearch(txtUser.Text).DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValuesLean();
        }
        else if (iToken == (int)AppTokens.appTokens.pec)
        {
            dv = appUsersHelper.dtGetUser().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            changeValues();
        }
        else if (iToken == (int)AppTokens.appTokens.pdcc)
        {
            dv = appUsersHelper.dtGetUser().DefaultView;
            dv.Sort = sortArgument;
            grdView.DataSource = dv;
            grdView.DataBind();
            ChangeValuesPdcc();
        }
    }

    private void changeValues()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRole")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

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

    private void changeValuesBI500()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRole")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

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

    private void changeValuesFlrWaiver()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRole")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

            if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Administrator)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Administrator);
            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Approval)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Approval);
            //else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.GMDeepWater)
            //    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.GMDeepWater);
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

    private void ChangeValuesPdcc()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label) (grdRow.FindControl("labelRole")));
            if (int.Parse(userRole.Text) == (int) AppUsersPdccRoles.UserRole.Administrator)
                userRole.Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.Administrator);
            else if (int.Parse(userRole.Text) == (int) AppUsersPdccRoles.UserRole.User)
                userRole.Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.User);
        }
    }


    private void changeValuesLean()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRole")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

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



    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton edit = (LinkButton)row.FindControl("editLinkButton");
        int userID = int.Parse(edit.Attributes["USERID"].ToString());
        Response.Redirect("~/EditUser.aspx?UserId=" + userID + "&App=" + appHF.Value);
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