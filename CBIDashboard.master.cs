using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_CBIDashboard : aspnetMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Summary: In case session expires, please relogin the user automatically.
        if (string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sUserName))
        {
            lblLoginUser.Text = System.Web.HttpContext.Current.User.Identity.Name;
            //lblLoginUser2.Text = System.Web.HttpContext.Current.User.Identity.Name;
        }
        else
        {
            lblLoginUser.Text = oSessnx.getOnlineUser.m_sFullName;
            //lblLoginUser2.Text = oSessnx.getOnlineUser.m_sFullName;
        }
    }
}
