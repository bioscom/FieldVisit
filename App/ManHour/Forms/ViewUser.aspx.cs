using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Setup_ViewUser : aspnetPage
{
    string sortArgument = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdManHr);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");


        if (!IsPostBack)
        {
            //UserControl_MyInitiatives oInitiative = (UserControl_MyInitiatives)Master.FindControl("MyInitiatives1");
            //if ((oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.initiator) || (oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.admin))
            //{
            //    oInitiative.Init_Control();
            //}
            //else
            //{
            //    oInitiative.Init_Control_Approvers();
            //}

            addRoleToDropDown(appUsersRoles.userRole.admin);
            addRoleToDropDown(appUsersRoles.userRole.initiator);
        }

        BindUserData("FULLNAME");
    }
    protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindUserDataByRole(sortArgument);

    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
        BindUserDataByName(sortArgument);
    }
    protected void grdView_PageIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        BindUserData(sortArgument);
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
        DataView dv = appUsersHelper.dtGetUser().DefaultView;
        dv.Sort = sortArgument;
        grdView.DataSource = dv;
        grdView.DataBind();

        changeValues();
    }

    private void changeValues()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRole")));
            //Label status = ((Label)(grdRow.FindControl("lblStatus")));

            if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.admin)
            {
                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.admin);
            }
            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.AssetOperationsManager)
            {
                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
            }
            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.CorporateViewer)
            {
                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.CorporateViewer);
            }
            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.FunctionalLead)
            {
                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
            }
            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.initiator)
            {
                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.initiator);
            }
            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.sponsor)
            {
                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
            }
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton edit = (LinkButton)row.FindControl("editLinkButton");
        int iUserId = int.Parse(edit.Attributes["USERID"].ToString());
        Response.Redirect("~/App/ManHour/Forms/EditUser.aspx?UserId=" + iUserId);
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