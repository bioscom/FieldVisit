using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;
using Telerik.Web.UI;
using System.Drawing;

public partial class UserManagement : aspnetPage
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


        RadGrdView.DataSource = appUsersHelper.dtGetUsers4AllApps();

        //if (!IsPostBack)
        //{
        //    addRoleToDropDown(appUsersRoles.userRole.admin);
        //    addRoleToDropDown(appUsersRoles.userRole.AssetOperationsManager);
        //    //addRoleToDropDown(appUsersRoles.userRole.champion);
        //    //addRoleToDropDown(appUsersRoles.userRole.CorporateViewer);
        //    //addRoleToDropDown(appUsersRoles.userRole.focalPoint);          
        //    addRoleToDropDown(appUsersRoles.userRole.FunctionalLead);
        //    addRoleToDropDown(appUsersRoles.userRole.initiator);
        //    addRoleToDropDown(appUsersRoles.userRole.planner);
        //    addRoleToDropDown(appUsersRoles.userRole.sponsor);
        //    addRoleToDropDown(appUsersRoles.userRole.superintendent);

        //    //addRoleToDropDown(appUsersRoles.userRole.LineManager);
        //    //addRoleToDropDown(appUsersRoles.userRole.ProductionServicesManager);
        //    //addRoleToDropDown(appUsersRoles.userRole.GMProduction);
        //    //addRoleToDropDown(appUsersRoles.userRole.BusinessImprovementTeam);
        //    //addRoleToDropDown(appUsersRoles.userRole.LeanFocalPoint);
        //}

        //BindUserData(sortArgument);
    }

    //protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (int.Parse(ddlUserRole.SelectedValue) == -1)
    //    {
    //        BindUserData(sortArgument);
    //    }
    //    else
    //    {
    //        BindUserDataByRole(sortArgument);
    //    }

    //}

    //protected void searchButton_Click(object sender, ImageClickEventArgs e)
    //{
    //    Response.Redirect("~/UserManagementSearch.aspx?fName=" + userTextBox.Text);
    //    //appUsersHelper.SearchUser(grdView, sortArgument, userTextBox.Text);
    //    //changeValues();
    //    //changeValuesBI500();
    //    //changeValuesFlrWaiver();
    //    //ChangeValuesPdcc();
    //    //changeValuesLean();
    //}

    //protected void searchButton_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/UserManagementSearch.aspx?fName=" + userTextBox.Text);
    //}

    //protected void grdView_PageIndexChanged(object sender, EventArgs e)
    //{

    //}

    //protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdView.PageIndex = e.NewPageIndex;

    //    if (int.Parse(ddlUserRole.SelectedValue) == -1)
    //    {
    //        BindUserData(sortArgument);
    //    }
    //    else
    //    {
    //        BindUserDataByRole(sortArgument);
    //    }
    //}

    //protected void grdView_Sorted(object sender, EventArgs e)
    //{

    //}

    //protected void grdView_Sorting(object sender, GridViewSortEventArgs e)
    //{

    //}

    //private void addRoleToDropDown(appUsersRoles.userRole eRole)
    //{
    //    try
    //    {
    //        ListItem oItem = new ListItem();
    //        oItem.Text = appUsersRoles.userRoleDesc(eRole);
    //        oItem.Value = ((int)eRole).ToString();
    //        ddlUserRole.Items.Add(oItem);
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    //private void BindUserData(string sortArgument)
    //{
    //    DataView dv = appUsersHelper.dtGetUsers4AllApps().DefaultView;
    //    dv.Sort = sortArgument;
    //    grdView.DataSource = dv;
    //    grdView.DataBind();

    //    changeValues();
    //    changeValuesBI500();
    //    changeValuesFlrWaiver();
    //    ChangeValuesPdcc();
    //    changeValuesLean();
    //    changeValuesInitiativeMgt();
    //    changeValuesContracts();
    //}

    //private void BindUserDataByRole(string sortArgument)
    //{
    //    DataView dv = appUsersHelper.dtGetUsersByRole(int.Parse(ddlUserRole.SelectedValue)).DefaultView;
    //    dv.Sort = sortArgument;
    //    grdView.DataSource = dv;
    //    grdView.DataBind();

    //    changeValues();
    //    changeValuesBI500();
    //    changeValuesFlrWaiver();
    //    ChangeValuesPdcc();
    //    changeValuesLean();
    //    changeValuesInitiativeMgt();
    //    changeValuesContracts();
    //}

    //private void BindUserDataByName(string sortArgument)
    //{
    //    //DataView dv = appUsersHelper.dtGetUserBySearch(userTextBox.Text).DefaultView;
    //    //dv.Sort = sortArgument;
    //    //grdView.DataSource = dv;
    //    //grdView.DataBind();

    //    grdView.DataSource = null;

    //    DataTable dt = appUsersHelper.dtGetUserBySearch(userTextBox.Text);

    //    if (dt.Rows.Count > 0)
    //    {
    //        DataView dv = dt.DefaultView;
    //        //dv.Sort = SortExpression;
    //        grdView.DataSource = dv;
    //        grdView.DataBind();
    //    }

    //    //grdView.DataSource = dt;
    //    //grdView.DataBind();

    //    changeValues();
    //    changeValuesBI500();
    //    changeValuesFlrWaiver();
    //    ChangeValuesPdcc();
    //    changeValuesLean();
    //    changeValuesInitiativeMgt();
    //    changeValuesContracts();
    //}


    //private void changeValues()
    //{
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label userRole = ((Label)(grdRow.FindControl("labelRole")));
    //        //Label status = ((Label)(grdRow.FindControl("lblStatus")));
    //        //
    //        //labelRoleInitiative
    //        //
    //        if (!string.IsNullOrEmpty(userRole.Text))
    //        {
    //            if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.admin)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.admin);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.initiator)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.initiator);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.planner)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.sponsor)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.superintendent)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.FunctionalLead)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.AssetOperationsManager)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.champion)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.champion);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.CorporateViewer)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.CorporateViewer);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.focalPoint)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.focalPoint);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.GMProduction)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.GMProduction);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LineManager)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LineManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.ProductionServicesManager)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.ProductionServicesManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.BusinessImprovementTeam)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.BusinessImprovementTeam);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LeanFocalPoint)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LeanFocalPoint);
    //        }
    //    }
    //}

    //private void changeValuesBI500()
    //{
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label userRole = ((Label)(grdRow.FindControl("labelRoleBI")));
    //        //Label status = ((Label)(grdRow.FindControl("lblStatus")));

    //        if (!string.IsNullOrEmpty(userRole.Text))
    //        {
    //            if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.admin)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.admin);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.initiator)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.initiator);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.AssetOperationsManager)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.AssetOperationsManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.sponsor)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.sponsor);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.focalPoint)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.focalPoint);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.BusinessImprovementTeam)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.BusinessImprovementTeam);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.champion)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.champion);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRolesBI500.userRole.CorporateViewer)
    //                userRole.Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.CorporateViewer);
    //        }
    //    }
    //}

    //private void changeValuesFlrWaiver()
    //{
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label userRole = ((Label)(grdRow.FindControl("labelRoleFlareWaiver")));
    //        //Label status = ((Label)(grdRow.FindControl("lblStatus")));

    //        if (!string.IsNullOrEmpty(userRole.Text))
    //        {
    //            if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Administrator)
    //                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Administrator);
    //            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.GMProduction)
    //                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.GMProduction);
    //            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Initiator)
    //                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Initiator);
    //            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.LineManager)
    //                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.LineManager);
    //            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.ProductionServicesManager)
    //                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.ProductionServicesManager);
    //            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.GMOffshore)
    //                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.GMOffshore);
    //            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.GMOnshore)
    //                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.GMOnshore);
    //        }
    //    }
    //}

    //private void ChangeValuesPdcc()
    //{
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label userRole = ((Label)(grdRow.FindControl("labelRoleCostTransparency")));
    //        if (!string.IsNullOrEmpty(userRole.Text))
    //        {
    //            if (int.Parse(userRole.Text) == (int)AppUsersPdccRoles.UserRole.Administrator)
    //                userRole.Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.Administrator);
    //            else if (int.Parse(userRole.Text) == (int)AppUsersPdccRoles.UserRole.User)
    //                userRole.Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.User);
    //        }
    //    }
    //}

    //private void changeValuesLean()
    //{
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label userRole = ((Label)(grdRow.FindControl("labelRoleLean")));
    //        //Label status = ((Label)(grdRow.FindControl("lblStatus")));

    //        if (!string.IsNullOrEmpty(userRole.Text))
    //        {

    //            if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.Administrator)
    //                userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.Administrator);
    //            else if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.CorporateManager)
    //                userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.CorporateManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.LeanCoach)
    //                userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.LeanCoach);
    //            else if (int.Parse(userRole.Text) == (int)appUsersLeanRoles.userRole.User)
    //                userRole.Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.User);
    //        }
    //    }
    //}

    //private void changeValuesInitiativeMgt()
    //{
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label userRole = ((Label)(grdRow.FindControl("labelRoleInitiative")));
    //        //Label status = ((Label)(grdRow.FindControl("lblStatus")));
    //        //
    //        if (!string.IsNullOrEmpty(userRole.Text))
    //        {
    //            if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.admin)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.admin);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.initiator)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.initiator);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.planner)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.sponsor)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.superintendent)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.FunctionalLead)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.AssetOperationsManager)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.champion)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.champion);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.CorporateViewer)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.CorporateViewer);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.focalPoint)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.focalPoint);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.GMProduction)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.GMProduction);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LineManager)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LineManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.ProductionServicesManager)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.ProductionServicesManager);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.BusinessImprovementTeam)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.BusinessImprovementTeam);
    //            else if (int.Parse(userRole.Text) == (int)appUsersRoles.userRole.LeanFocalPoint)
    //                userRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LeanFocalPoint);
    //        }
    //    }
    //}

    //private void changeValuesContracts()
    //{
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label userRole = ((Label)(grdRow.FindControl("labelRoleContract")));
    //       if (!string.IsNullOrEmpty(userRole.Text))
    //        {
    //            if (int.Parse(userRole.Text) == (int)AppUsers14DaysContract.UserRole.Administrator)
    //                userRole.Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.Administrator);
    //            else if (int.Parse(userRole.Text) == (int)AppUsers14DaysContract.UserRole.CorporateViewer)
    //                userRole.Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.CorporateViewer);
    //            else if (int.Parse(userRole.Text) == (int)AppUsers14DaysContract.UserRole.OperationsManager)
    //                userRole.Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.OperationsManager);
    //            else if (int.Parse(userRole.Text) == (int)AppUsers14DaysContract.UserRole.Superintendent)
    //                userRole.Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.Superintendent);
    //        }
    //    }
    //}

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton edit = (LinkButton)row.FindControl("editLinkButton");
        int iUserId = int.Parse(edit.Attributes["USERID"].ToString());

        Response.Redirect("~/EditUser.aspx?UserId=" + iUserId + "&App=" + (int)AppTokens.appTokens.pec);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        //LinkButton lnkDelete = (LinkButton)row.FindControl("deleteLinkButton");
        //int userID = int.Parse(lnkDelete.Attributes["USERID"].ToString());

        //bool success = appUsersHelper.disableUserAccount(userID);
        //if (success)
        //{
        //    ajaxWebExtension.showJscriptAlert(Page, this, "User successfully disabled.");
        //}

        using (GridDataItem dataItem = (GridDataItem) ((LinkButton) sender).Parent.Parent)
        {
            int UserID = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["USERID"].ToString());
            bool success = appUsersHelper.disableUserAccount(UserID);
            if (success)
            {
                RadGrdView.Rebind();
                ajaxWebExtension.showJscriptAlert(Page, this, "User successfully disabled.");
            }
        }
    }

    protected void btnCleanUp_Click(object sender, EventArgs e)
    {
        UserTableCleanUp oUserTableCleanUp = new UserTableCleanUp();
        UserTableCleanUp.procRet eRet = oUserTableCleanUp.CleanUpTable();

        if (eRet.eStatus)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "User database successfully cleaned up. An email has been sent to you with details of operation done in the Clean Up.");
            sendMailFieldVisit oMail = new sendMailFieldVisit(sendMailFieldVisit.eManager());
            oMail.cleanUpReport(oSessnx.getOnlineUser.structUserIdx);
        }
    }

    protected void ddlUsers_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        EIdd.Utilities.Search(e.Text, ddlUsers);
    }

    private void RadComboControlLoader(DataTable dt, RadComboBox RadDdl)
    {
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var item = new RadComboBoxItem();
                item.Text = (string) dr["FULLNAME"];
                item.Value = dr["USERID"].ToString();

                string email = dr["EMAIL"].ToString();
                string refInd = dr["REFIND"].ToString();

                item.Attributes.Add("EMAIL", email);
                item.Attributes.Add("REFIND", refInd);
                //item.Value += ":" + refInd;

                RadDdl.Items.Add(item);
                item.DataBind();
            }
        }
    }

    protected void ddlUsers_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            int Userid = 0;
            Userid = !string.IsNullOrEmpty(ddlUsers.SelectedValue) ? int.Parse(ddlUsers.SelectedValue) : Userid;

            RadGrdView.DataSource = appUsersHelper.dtGetUserByUserId(Userid);
            RadGrdView.Rebind();
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = appUsersHelper.dtGetUsers4AllApps();
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var editLink = (HyperLink) e.Item.FindControl("editLink");
            var actionLink = (HyperLink) e.Item.FindControl("actionLink");

            if (editLink != null)
            {
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["USERID"], e.Item.ItemIndex);
            }

            if (actionLink != null)
            {
                actionLink.Attributes["href"] = "javascript:void(0);";
                actionLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["USERID"], e.Item.ItemIndex);
            }
        }

        //if (e.Item is GridNestedViewItem)
        //{
        //    EIdd.eIddUsers oCP = o.CheckIfLogInUserIsCpFocalPoint(oSessnx.getOnlineUser.m_iUserId);
        //    if (oCP.m_iUserId != 0)
        //    {
        //        var panel = (Panel) e.Item.FindControl("pnlAssignAnalyst");
        //        if (panel != null)
        //        {
        //            panel.Visible = true;
        //        }

        //        var lnkRejectRequest = (LinkButton) e.Item.FindControl("lnkRejectRequest");
        //        lnkRejectRequest.Visible = true;
        //    }
        //}

        //if (e.Item is GridNestedViewItem) /**/
        //{
        //    (e.Item.FindControl("DocumentsGrid") as RadGrid).NeedDataSource += new GridNeedDataSourceEventHandler(DocumentsGrid_NeedDataSource);
        //    //(e.Item.FindControl("DocumentsGrid") as RadGrid).DataSource; 

        //}
    }

    protected void grdView_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
    {
        GridDataItem dataItem = e.DetailTableView.ParentItem;

        long lRequestId = long.Parse(dataItem.GetDataKeyValue("USERID").ToString());
        //e.DetailTableView.DataSource = oM.dtGetDocsByRequestId(lRequestId);

        //switch (e.DetailTableView.Name)
        //{
        //    case "Docs":
        //        {
        //            long lRequestId = long.Parse(dataItem.GetDataKeyValue("REQUESTID").ToString());
        //            e.DetailTableView.DataSource = o.dtGetDocsByRequestId(lRequestId);

        //            break;
        //        }

        //    case "OrderDetails":
        //        {
        //            string OrderID = dataItem.GetDataKeyValue("OrderID").ToString();
        //            e.DetailTableView.DataSource = null;
        //            break;
        //        }
        //}
    }

    protected void grdView_ItemUpdated(object source, GridUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.KeepInEditMode = true;
            e.ExceptionHandled = true;
            DisplayMessage(true, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " cannot be updated due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " updated");
        }
    }

    protected void grdView_ItemInserted(object source, GridInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
            DisplayMessage(true, "Commitment cannot be inserted due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "Commitment inserted");
        }
    }

    protected void grdView_ItemDeleted(object source, GridDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            DisplayMessage(true, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " cannot be deleted");
        }
        else
        {
            DisplayMessage(false, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " deleted");
        }
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var lbl = e.Item.FindControl("numberLabel") as Label;
            if (lbl != null)
                lbl.Text = (e.Item.ItemIndex + 1).ToString();

            //Field Visit
            var item = e.Item as GridDataItem;
            if (item.Cells[5].Text == ((int) appUsersRoles.userRole.admin).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.admin);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.initiator).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.initiator);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.planner).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.sponsor).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.superintendent).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.FunctionalLead).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.AssetOperationsManager).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.champion).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.champion);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.CorporateViewer).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.CorporateViewer);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.focalPoint).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.focalPoint);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.GMProduction).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.GMProduction);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.LineManager).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LineManager);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.ProductionServicesManager).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.ProductionServicesManager);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.BusinessImprovementTeam).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.BusinessImprovementTeam);
            else if (item.Cells[5].Text == ((int) appUsersRoles.userRole.LeanFocalPoint).ToString()) item.Cells[5].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LeanFocalPoint);


            //Cost Transparency
            if (item.Cells[6].Text ==  ((int) AppUsersPdccRoles.UserRole.Administrator).ToString()) item.Cells[6].Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.Administrator);
            else if (item.Cells[6].Text == ((int) AppUsersPdccRoles.UserRole.User).ToString()) item.Cells[6].Text = AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.User);
               
            //Bright Ideas
            if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.admin).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.admin);
            else if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.initiator).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.initiator);
            else if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.AssetOperationsManager).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.AssetOperationsManager);
            else if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.sponsor).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.sponsor);
            else if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.focalPoint).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.focalPoint);
            else if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.BusinessImprovementTeam).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.BusinessImprovementTeam);
            else if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.champion).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.champion);
            else if (item.Cells[7].Text == ((int) appUsersRolesBI500.userRole.CorporateViewer).ToString()) item.Cells[7].Text = appUsersRolesBI500.userRoleDesc(appUsersRolesBI500.userRole.CorporateViewer);

            //Flare Waiver
            if (item.Cells[8].Text == ((int) appUserRolesFlrWaiver.userRole.Administrator).ToString()) item.Cells[8].Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Administrator);
            else if (item.Cells[8].Text == ((int) appUserRolesFlrWaiver.userRole.Approval).ToString()) item.Cells[8].Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Approval);
            else if (item.Cells[8].Text == ((int) appUserRolesFlrWaiver.userRole.Initiator).ToString()) item.Cells[8].Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Initiator);
            else if (item.Cells[8].Text == ((int) appUserRolesFlrWaiver.userRole.LineManager).ToString()) item.Cells[8].Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.LineManager);
            else if (item.Cells[8].Text == ((int) appUserRolesFlrWaiver.userRole.AssurancePSMgr).ToString()) item.Cells[8].Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssurancePSMgr);
            else if (item.Cells[8].Text == ((int) appUserRolesFlrWaiver.userRole.AssuranceOffshore).ToString()) item.Cells[8].Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOffshore);
            else if (item.Cells[8].Text == ((int) appUserRolesFlrWaiver.userRole.AssuranceOnshore).ToString()) item.Cells[8].Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOnshore);

            //Initiatives Management
            if (item.Cells[9].Text == ((int) appUsersRoles.userRole.admin).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.admin);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.initiator).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.initiator);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.planner).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.sponsor).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.superintendent).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.FunctionalLead).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.AssetOperationsManager).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.champion).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.champion);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.CorporateViewer).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.CorporateViewer);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.focalPoint).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.focalPoint);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.GMProduction).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.GMProduction);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.LineManager).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LineManager);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.ProductionServicesManager).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.ProductionServicesManager);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.BusinessImprovementTeam).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.BusinessImprovementTeam);
            else if (item.Cells[9].Text == ((int) appUsersRoles.userRole.LeanFocalPoint).ToString()) item.Cells[9].Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.LeanFocalPoint);

            //14 Days Contract
            if (item.Cells[10].Text == ((int) AppUsers14DaysContract.UserRole.Administrator).ToString()) item.Cells[10].Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.Administrator);
            else if (item.Cells[10].Text == ((int) AppUsers14DaysContract.UserRole.CorporateViewer).ToString()) item.Cells[10].Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.CorporateViewer);
            else if (item.Cells[10].Text == ((int) AppUsers14DaysContract.UserRole.OperationsManager).ToString()) item.Cells[10].Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.OperationsManager);
            else if (item.Cells[10].Text == ((int) AppUsers14DaysContract.UserRole.Superintendent).ToString()) item.Cells[10].Text = AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.Superintendent);

            //Lean Management
            if (item.Cells[11].Text == ((int) appUsersLeanRoles.userRole.Administrator).ToString()) item.Cells[11].Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.Administrator);
            else if (item.Cells[11].Text == ((int) appUsersLeanRoles.userRole.CorporateManager).ToString()) item.Cells[11].Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.CorporateManager);
            else if (item.Cells[11].Text == ((int) appUsersLeanRoles.userRole.LeanCoach).ToString()) item.Cells[11].Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.LeanCoach);
            else if (item.Cells[11].Text == ((int) appUsersLeanRoles.userRole.User).ToString()) item.Cells[11].Text = appUsersLeanRoles.userRoleDesc(appUsersLeanRoles.userRole.User);
        }
    }

    private void DisplayMessage(bool isError, string text)
    {
        Label label = (isError) ? this.Label1 : this.Label2;
        label.Text = text;
    }

    protected void grdView_ItemCommand(object source, GridCommandEventArgs e)
    {
        //Session["RowIndex"] = e.Item.ItemIndex.ToString();

        //if (e.CommandName == RadGrid.ExpandCollapseCommandName)
        //{
        //    var details = (ASP.app_idd_usercontrol_odetails_ascx) ((GridDataItem) e.Item).ChildItem.FindControl("oDetails");
        //    if (!e.Item.Expanded)
        //    {
        //        long lRequestId = long.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"].ToString());
        //        details.ViewDetails(lRequestId);
        //    }
        //}

        //if (e.CommandName == RadGrid.InitInsertCommandName) //"Add new" button clicked
        //{
        //    GridEditCommandColumn editColumn = (GridEditCommandColumn) grdView.MasterTableView.GetColumn("EditCommandColumn");
        //    editColumn.Visible = false;
        //}
        //else if (e.CommandName == RadGrid.RebindGridCommandName && e.Item.OwnerTableView.IsItemInserted)
        //{
        //    e.Canceled = true;
        //}
        //else
        //{
        //    GridEditCommandColumn editColumn = (GridEditCommandColumn) grdView.MasterTableView.GetColumn("EditCommandColumn");
        //    if (!editColumn.Visible)
        //        editColumn.Visible = true;
        //}
    }

    protected void grdView_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (grdView.MasterTableView.Items.Count > 0)
            //    grdView.MasterTableView.Items[0].Expanded = true;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem) ((LinkButton) sender).Parent.Parent)
        {
            //long lId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["DOCSID"].ToString());
            //oM.deleteDocById(lId);
            ////grdView.Rebind();
            //ajaxWebExtension.showJscriptAlertCx(Page, this, "Document deleted successfully!!!");
        }
    }


    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            //grdView.MasterTableView.SortExpressions.Clear();
            //grdView.MasterTableView.GroupByExpressions.Clear();
            //grdView.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            //grdView.MasterTableView.SortExpressions.Clear();
            //grdView.MasterTableView.GroupByExpressions.Clear();
            //grdView.MasterTableView.CurrentPageIndex = grdView.MasterTableView.PageCount - 1;
            //grdView.Rebind();
        }
    }
}