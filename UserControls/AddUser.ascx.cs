using System;

public partial class UserControl_AddUser : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iToken)
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
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int)AppTokens.appTokens.pec)
        {
            appUsersRoles.getUserRoles(ddlUserRole);
            appHF.Value = iToken.ToString();
        }
        else if (iToken == (int)AppTokens.appTokens.pdcc)
        {
            AppUsersPdccRoles.GetUserRoles(ddlUserRole);
            appHF.Value = iToken.ToString();
        }

        Search4User1.initUserInfo("Select Planner", 250);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        appUsersHelper oappUsersHelper = new appUsersHelper();
        if (Search4User1.userIsValid)
        {
            bool bRet = false;
            int iUserId = 0;
            appUsers oAppUser = new appUsers();

            oAppUser.m_iRoleIdFieldVisit = null;
            oAppUser.m_iRoleIdBI = null;
            oAppUser.m_iRoleIdContract = null;
            oAppUser.m_iRoleIdFlr = null;
            oAppUser.m_iRoleIdLean = null;
            oAppUser.m_iRoleIdManHr = null;
            oAppUser.m_iRolePdcc = null;

            if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.BI500) oAppUser.m_iRoleIdBI = int.Parse(ddlUserRole.SelectedValue);
            else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.FlareWaiver) oAppUser.m_iRoleIdFlr = int.Parse(ddlUserRole.SelectedValue);
            else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.FourteenDayContract) oAppUser.m_iRoleIdContract = int.Parse(ddlUserRole.SelectedValue);
            else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.initiativeMgt) oAppUser.m_iRoleIdManHr = int.Parse(ddlUserRole.SelectedValue); //Note ManHr and Initiative Manager are the same
            else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.lean) oAppUser.m_iRoleIdLean = int.Parse(ddlUserRole.SelectedValue);
            else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.pec) oAppUser.m_iRoleIdFieldVisit = int.Parse(ddlUserRole.SelectedValue);
            else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.pdcc) oAppUser.m_iRolePdcc = int.Parse(ddlUserRole.SelectedValue);

            oAppUser.m_sFullName = Search4User1.selectedUserDetails.m_sFullName;
            oAppUser.m_sRefInd = Search4User1.selectedUserDetails.m_sRefInd;
            oAppUser.m_sUserMail = Search4User1.selectedUserDetails.m_sUserMail;
            oAppUser.m_sUserName = Search4User1.selectedUserDetails.m_sUserName;

            bRet = appUsersHelper.CreateUserAccount(oAppUser, ref iUserId);
            if (bRet)
            {
                if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.BI500)
                {
                    //No Add User mail yet
                }
                else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.FlareWaiver)
                {
                    FlareWaiverSendMail.sendMail oMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
                    oMail.UserDefinition(oAppUser);
                }
                else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.FourteenDayContract)
                {
                    //No Mail yet
                }
                else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.initiativeMgt)
                {
                    sendMailManHour oMail = new sendMailManHour(oSessnx.getOnlineUser.structUserIdx);
                    oMail.UserDefinition(oAppUser);

                }
                else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.lean)
                {
                    //No Mail yet
                }
                else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.pec)
                {
                    //Send mail to the defined user
                    sendMailFieldVisit oMail = new sendMailFieldVisit(sendMailFieldVisit.eManager());
                    oMail.UserDefinition(oAppUser);
                }

                ajaxWebExtension.showJscriptAlert(Page, this, "User Successfully Defined.");
            }
            else
            {
                UpdateUser();
                //appUsers oUser = oappUsersHelper.objGetOnlineUserByUserName(Search4User1.selectedUserDetails.m_sUserName);
                //ajaxWebExtension.showJscriptAlert(Page, this, oAppUser.m_sFullName + " has been defined as " + appUserRolesFlrWaiver.userRoleDesc((appUserRolesFlrWaiver.userRole)oAppUser.m_iRoleIdFlr) + ", but may have been deactivated. Contact the Administrator.");
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "User not successfully defined, please try again later.");
        }
    }

    private void UpdateUser()
    {
        bool bRet = false;
        appUsers oAppUser = new appUsers();

        if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.BI500)
            bRet = appUsersHelper.editBIUserAccount(oAppUser.m_iUserId, int.Parse(ddlUserRole.SelectedValue));
        else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.FlareWaiver)
            bRet = appUsersHelper.editFlrWaierUserAccount(oAppUser.m_iUserId, int.Parse(ddlUserRole.SelectedValue));
        else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.FourteenDayContract)
            bRet = appUsersHelper.edit14DayContractUserAccount(oAppUser.m_iUserId, int.Parse(ddlUserRole.SelectedValue));
        else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.initiativeMgt)
            bRet = appUsersHelper.editManHrUserAccount(oAppUser.m_iUserId, int.Parse(ddlUserRole.SelectedValue));
        else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.lean)
            bRet = appUsersHelper.editLeanUserAccount(oAppUser.m_iUserId, int.Parse(ddlUserRole.SelectedValue));
        else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.pec)
            bRet = appUsersHelper.editUserAccount(oAppUser.m_iUserId, int.Parse(ddlUserRole.SelectedValue));
        else if (int.Parse(appHF.Value) == (int)AppTokens.appTokens.pdcc)
            bRet = appUsersHelper.editPdccUserAccount(oAppUser.m_iUserId, int.Parse(ddlUserRole.SelectedValue));
        if (bRet) ajaxWebExtension.showJscriptAlert(Page, this, "User Successfully defined.");
    }

    private void Clear()
    {
        //txtUserName.Text = "";
        ddlUserRole.ClearSelection();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
}