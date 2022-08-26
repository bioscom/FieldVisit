using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator)
        {
            pnlUserMgt.Visible = true;
        }
        else
        {
            pnlUserMgt.Visible = false;
        }
    }
    protected void lnkUserMgt_Click(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator)
        {
            Response.Redirect("~/App/Lean/UserMgt.aspx");
        }
    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator)
        {
            Response.Redirect("~/App/Lean/AddUser.aspx"); //~/App/Lean/AddUser.aspx
        }
    }
    protected void lbAddC4CUsers_Click(object sender, EventArgs e)
    {

    }
    protected void lnkDeleteProject_Click(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iRoleIdLean == (int)appUsersLeanRoles.userRole.Administrator)
        {
            Response.Redirect("~/App/Lean/DeleteProject.aspx");
        }
    }
}