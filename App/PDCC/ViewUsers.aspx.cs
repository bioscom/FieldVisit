using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_ViewUsers : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sToken = "";
        bool bRet = false;
        try
        {
            string[] sPageAccess = { AppUsersPdccRoles.UserRole.Administrator.ToString() };
            AppUsersPdccRoles oAccess = new AppUsersPdccRoles();
            bRet = oAccess.GrantPageAccess(sPageAccess, (AppUsersPdccRoles.UserRole)this.oSessnx.getOnlineUser.m_iRolePdcc);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }

        //if (oSessnx.getOnlineUser.m_iRoleIdFlr != (int)appUserRolesFlrWaiver.userRole.Initiator) sToken = "tAdmin";
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx?Msg=" + sToken);

        if (!IsPostBack)
        {
            ViewUsers1.InitPage((int)AppTokens.appTokens.pdcc);
        }
    }
}