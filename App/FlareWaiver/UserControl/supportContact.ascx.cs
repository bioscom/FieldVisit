using System;
using System.Collections.Generic;

public partial class UserControl_supportContact : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        appUsersHelper oappUsersHelper = new appUsersHelper();

        List<appUsers> oAdmins = oappUsersHelper.lstGetUserByRole((int)appUserRolesFlrWaiver.userRole.Administrator);
        foreach (appUsers oAdmin in oAdmins)
        {
            supportBlst.Items.Add(oAdmin.m_sFullName + " (Ext.: +2348070224772)");
        }
    }
}
