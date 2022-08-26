using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_AddC4CUser : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public void Page_Init()
    {
        appRdb.Items.Add(new ListItem(AppTokens.AppFullDesc(AppTokens.appTokens.BI500), ((int)AppTokens.appTokens.BI500).ToString()));
        appRdb.Items.Add(new ListItem(AppTokens.AppFullDesc(AppTokens.appTokens.FlareWaiver), ((int)AppTokens.appTokens.FlareWaiver).ToString()));
        appRdb.Items.Add(new ListItem(AppTokens.AppFullDesc(AppTokens.appTokens.FourteenDayContract), ((int)AppTokens.appTokens.FourteenDayContract).ToString()));
        appRdb.Items.Add(new ListItem(AppTokens.AppFullDesc(AppTokens.appTokens.initiativeMgt), ((int)AppTokens.appTokens.initiativeMgt).ToString()));
        appRdb.Items.Add(new ListItem(AppTokens.AppFullDesc(AppTokens.appTokens.lean), ((int)AppTokens.appTokens.lean).ToString()));
        appRdb.Items.Add(new ListItem(AppTokens.AppFullDesc(AppTokens.appTokens.pec), ((int)AppTokens.appTokens.pec).ToString()));

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

    protected void saveButton_Click(object sender, EventArgs e)
    {
        appUsers oAppUser = new appUsers();
        try
        {
            int iUserId = 0;

            oAppUser.m_iRoleIdFieldVisit = null;
            oAppUser.m_iRoleIdBI = null;
            oAppUser.m_iRoleIdContract = null;
            oAppUser.m_iRoleIdFlr = null;
            oAppUser.m_iRoleIdLean = null;
            oAppUser.m_iRoleIdManHr = null;

            foreach (ListItem li in appRdb.Items)
            {
                if (li.Value == ((int)AppTokens.appTokens.BI500).ToString()) oAppUser.m_iRoleIdBI = int.Parse(ddlUserRole.SelectedValue);
                else if (li.Value == ((int)AppTokens.appTokens.FlareWaiver).ToString()) oAppUser.m_iRoleIdFlr = int.Parse(ddlUserRole.SelectedValue);
                else if (li.Value == ((int)AppTokens.appTokens.FourteenDayContract).ToString()) oAppUser.m_iRoleIdContract = int.Parse(ddlUserRole.SelectedValue);
                else if (li.Value == ((int)AppTokens.appTokens.initiativeMgt).ToString()) oAppUser.m_iRoleIdManHr = int.Parse(ddlUserRole.SelectedValue);
                else if (li.Value == ((int)AppTokens.appTokens.lean).ToString()) oAppUser.m_iRoleIdLean = int.Parse(ddlUserRole.SelectedValue);
                else if (li.Value == ((int)AppTokens.appTokens.pec).ToString()) oAppUser.m_iRoleIdFieldVisit = int.Parse(ddlUserRole.SelectedValue);
            }

            oAppUser.m_sFullName = txtFullName.Text;
            oAppUser.m_sRefInd = txtRefInd.Text;
            oAppUser.m_sUserMail = txtEmailAddress.Text;
            oAppUser.m_sUserName = txtUserName.Text;

            bool success = appUsersHelper.CreateUserAccount(oAppUser, ref iUserId);
            if (success == true)
            {
                foreach (ListItem li in appRdb.Items)
                {
                    if (li.Value == ((int)AppTokens.appTokens.BI500).ToString())
                    {

                    }
                    else if (li.Value == ((int)AppTokens.appTokens.FlareWaiver).ToString())
                    {
                        FlareWaiverSendMail.sendMail oMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
                        oMail.UserDefinition(oAppUser);
                    }
                    else if (li.Value == ((int)AppTokens.appTokens.FourteenDayContract).ToString())
                    {
                        //No Add User mail yet
                    }
                    else if (li.Value == ((int)AppTokens.appTokens.initiativeMgt).ToString())
                    {
                        sendMailManHour oMail = new sendMailManHour(oSessnx.getOnlineUser.structUserIdx);
                        oMail.UserDefinition(oAppUser);
                    }
                    else if (li.Value == ((int)AppTokens.appTokens.lean).ToString())
                    {
                        //No Add User mail yet
                    }
                    else if (li.Value == ((int)AppTokens.appTokens.pec).ToString())
                    {
                        sendMailFieldVisit oMail = new sendMailFieldVisit(sendMailFieldVisit.eManager());
                        oMail.UserDefinition(oAppUser);
                    }
                }

                ajaxWebExtension.showJscriptAlert(Page, this, "User Successfully defined.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            ajaxWebExtension.showJscriptAlert(Page, this, "User not successfully defined, please try again later.");
        }
    }

    protected void closeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserManagement.aspx");
    }

    protected void appRdb_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem li in appRdb.Items)
        {
            if (li.Selected)
            {
                if (li.Value == ((int)AppTokens.appTokens.BI500).ToString()) appUsersRolesBI500.getUserRoles(ddlUserRole);
                else if (li.Value == ((int)AppTokens.appTokens.FlareWaiver).ToString()) appUserRolesFlrWaiver.getUserRoles(ddlUserRole);
                else if (li.Value == ((int)AppTokens.appTokens.FourteenDayContract).ToString()) { } //TODO: sort this out
                else if (li.Value == ((int)AppTokens.appTokens.initiativeMgt).ToString()) { } //TODO: sort this ou
                else if (li.Value == ((int)AppTokens.appTokens.lean).ToString()) appUsersLeanRoles.getUserRoles(ddlUserRole);
                else if (li.Value == ((int)AppTokens.appTokens.pec).ToString()) appUsersRoles.getUserRoles(ddlUserRole);
            }
        }
    }
}