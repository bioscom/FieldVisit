using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_supportContactExt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        appUsersHelper oappUsersHelper = new appUsersHelper();

        supportBlst.Items.Add("For Concept design & CI workflows call +2348070321919");

        List<appUsers> oAdmins = oappUsersHelper.lstGetSupportContact((int)appUsersRoles.userRole.admin);
        foreach (appUsers oAdmin in oAdmins)
        {
            supportBlst.Items.Add("For Technical Support contact: " + oAdmin.m_sFullName + " (" + AppConfiguration.adminExt + ")");
        }
    }

}