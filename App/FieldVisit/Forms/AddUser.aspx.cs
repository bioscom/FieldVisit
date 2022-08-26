﻿using System;
using System.Web.UI.WebControls;

public partial class Forms_AddUser : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddUser1.Init_Page((int)AppTokens.appTokens.pec);
        }

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
}