using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contract_Setup_Priority : aspnetPage
{
    PriorityHelper oPriorityHelper = new PriorityHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet =false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdContract);
        }
        catch(Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");
    }

    protected void addNewBtn_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        int iRet = oPriorityHelper.dtGetPrioritiesByPriority(txtPriority.Text).Rows.Count;
        if (iRet == 0)
        {
            bRet = oPriorityHelper.createPriority(txtPriority.Text, int.Parse(txtOrder.Text));
            if (bRet == true)
            {
                Response.Redirect("~/App/Contract/Setup/viewPriorities.aspx?Msg=xTrue");
            }
            else
            {
                Response.Redirect("~/App/Contract/Setup/viewPriorities.aspx?Msg=xFalse");
            }
        }
        else
        {
            Response.Redirect("~/App/Contract/Setup/viewPriorities.aspx?Msg=xMsgExt");
        }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/taskPage.aspx?Msg=xCanc");
        Response.Redirect("~/App/Contract/Setup/viewPriorities.aspx");
    }
}