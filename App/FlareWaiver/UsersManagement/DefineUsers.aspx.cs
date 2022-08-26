using System;

public partial class UsersManagement_DefineUsers : aspnetPage
{
    //protected void Page_PreRender(object sender, EventArgs e)
    //{
    //    //TODO: solve this session problem issues
    //    //if ((oSessnx.getOnlineUser.m_iRoleIdFlr == (int)UserRoles.userRole.Administrator) || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)UserRoles.userRole.Business_Process_Owner))
    //    //{
            
    //    //}
    //    //else
    //    //{
    //    //    //MessageBox.Show("Please you are not allowed to view this page");
    //    //    Response.Redirect("~/Default.aspx");
    //    //}
    //}

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        UserRoles roles = new UserRoles();
    //        roles.getUserRoles(ddlUserRole);

    //        AffliateMgt oAffliateMgt = new AffliateMgt();
    //        oAffliateMgt.getAffiliates(ddlAffiliates);

    //        Search4User1.initUserInfo("Select Planner", 250);
    //    }
    //}

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    appUsersMgt oappUsersMgt = new appUsersMgt();
    //    if (Search4User1.userIsValid)
    //    {
    //        bool success = oappUsersMgt.AddNewUser(Search4User1.selectedUserDetails.m_sUserName, Search4User1.selectedUserDetails.m_sUserMail, Search4User1.selectedUserDetails.m_sFullName, txtPhoneExt.Text, ddlUserRole.SelectedValue, int.Parse(ddlAffiliates.SelectedValue));
    //        if (success == true)
    //        {
    //            appUsers oAppUser = oappUsersMgt.objGetUserByGIDUserName(Apps.LoginIDNoDomain(Search4User1.selectedUserDetails.m_sUserMail));
    //            sendMail oMail = new sendMail(oSessnx.getOnlineUser.structUserIdx);
    //            oMail.UserDefinition(oAppUser.structUserIdx, oAppUser);

    //            ajaxWebExtension.showJscriptAlert(Page, this, "User Successfully defined.");
    //        }
    //        else
    //        {
    //            appUsers oUser = oappUsersMgt.objGetOnlineUserByUserName(Search4User1.selectedUserDetails.m_sUserName);
    //            ajaxWebExtension.showJscriptAlert(Page, this, oUser.m_sFullName + " has been defined as " + UserRoles.userRoleDesc(oUser.m_eUserRole) + ", but may have been deactivated. Contact the Administrator.");
    //        }
    //    }
    //    else
    //    {
    //        ajaxWebExtension.showJscriptAlert(Page, this, "User not successfully defined, please try again later.");
    //    }
    //}

    //private void Clear()
    //{
    //    //txtUserName.Text = "";
    //    ddlUserRole.ClearSelection();
    //    txtPhoneExt.Text = "";
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        string sToken = "";
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUserRolesFlrWaiver.userRole.Administrator.ToString() };
            appUserRolesFlrWaiver oAccess = new appUserRolesFlrWaiver();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUserRolesFlrWaiver.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFlr);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }

        if (oSessnx.getOnlineUser.m_iRoleIdFlr != (int)appUserRolesFlrWaiver.userRole.Initiator) sToken = "tAdminAddUser";
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx?Msg=" + sToken);

        if (!IsPostBack)
        {
            AddUser1.Init_Page((int)AppTokens.appTokens.FlareWaiver);
        }
    }
}