using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Setup_ViewUser : aspnetPage
{
    string sortArgument = "FULLNAME";

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
            addRoleToDropDown(appUsersRoles.userRole.admin);
            addRoleToDropDown(appUsersRoles.userRole.AssetOperationsManager);
            //addRoleToDropDown(appUsersRoles.userRole.champion);
            //addRoleToDropDown(appUsersRoles.userRole.CorporateViewer);
            //addRoleToDropDown(appUsersRoles.userRole.focalPoint);          
            addRoleToDropDown(appUsersRoles.userRole.FunctionalLead);
            addRoleToDropDown(appUsersRoles.userRole.initiator);
            addRoleToDropDown(appUsersRoles.userRole.planner);
            addRoleToDropDown(appUsersRoles.userRole.sponsor);
            addRoleToDropDown(appUsersRoles.userRole.superintendent);

            //addRoleToDropDown(appUsersRoles.userRole.LineManager);
            //addRoleToDropDown(appUsersRoles.userRole.ProductionServicesManager);
            //addRoleToDropDown(appUsersRoles.userRole.GMProduction);
            //addRoleToDropDown(appUsersRoles.userRole.BusinessImprovementTeam);
            //addRoleToDropDown(appUsersRoles.userRole.LeanFocalPoint);
        }

        BindUserData(sortArgument);
    }
    protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(ddlUserRole.SelectedValue) == -1)
        {
            BindUserData(sortArgument);
        }
        else
        {
            BindUserDataByRole(sortArgument);
        }

    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
        appUsersHelper.SearchUser(grdView, sortArgument, userTextBox.Text);
        changeValues();
    }
    protected void grdView_PageIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;

        if (int.Parse(ddlUserRole.SelectedValue) == -1)
        {
            BindUserData(sortArgument);
        }
        else
        {
            BindUserDataByRole(sortArgument);
        }
    }
    
    protected void grdView_Sorted(object sender, EventArgs e)
    {

    }
    protected void grdView_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    private void addRoleToDropDown(appUsersRoles.userRole eRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUsersRoles.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void BindUserData(string sortArgument)
    {
        DataView dv = appUsersHelper.dtGetUsers().DefaultView;
        dv.Sort = sortArgument;
        grdView.DataSource = dv;
        grdView.DataBind();

        changeValues();
    }

    private void BindUserDataByRole(string sortArgument)
    {
        DataView dv = appUsersHelper.dtGetUsersByRole(int.Parse(ddlUserRole.SelectedValue)).DefaultView;
        dv.Sort = sortArgument;
        grdView.DataSource = dv;
        grdView.DataBind();

        changeValues();
    }

    private void BindUserDataByName(string sortArgument)
    {
        //DataView dv = appUsersHelper.dtGetUserBySearch(userTextBox.Text).DefaultView;
        //dv.Sort = sortArgument;
        //grdView.DataSource = dv;
        //grdView.DataBind();

        grdView.DataSource = null;

        DataTable dt = appUsersHelper.dtGetUser();

        if (dt.Rows.Count > 0)
        {
            DataView dv = dt.DefaultView;
            //dv.Sort = SortExpression;
            grdView.DataSource = dv;
            grdView.DataBind();
        }
             
        //grdView.DataSource = dt;
        //grdView.DataBind();

        changeValues();
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

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton edit = (LinkButton)row.FindControl("editLinkButton");
        int iUserId = int.Parse(edit.Attributes["USERID"].ToString());

        Response.Redirect("~/EditUser.aspx?UserId=" + iUserId + "&App=" + (int)AppTokens.appTokens.pec);
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

    protected void btnCleanUp_Click(object sender, EventArgs e)
    {
        UserTableCleanUp oUserTableCleanUp = new UserTableCleanUp();
        UserTableCleanUp.procRet eRet = oUserTableCleanUp.CleanUpTable();

        if (eRet.eStatus)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "User Table Successfully cleaned up. An email has been sent to you with details of operation done in the Clean Up.");
            sendMailFieldVisit oMail = new sendMailFieldVisit(sendMailFieldVisit.eManager());
            oMail.cleanUpReport(oSessnx.getOnlineUser.structUserIdx);
        }
    }
}