using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setup_functionalAcctUsers : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

        if (!IsPostBack)
        {
            List<Superintendent> superintendents = Superintendent.lstGetSuperintendent();
            foreach (Superintendent _superintendents in superintendents)
            {
                drpSuperintendents.Items.Add(new ListItem(_superintendents.m_sSuperintendent, _superintendents.m_iSuperintendentId.ToString()));
            }

            Search4User1.initUserInfo("Search user", 250);
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        bool bRet = SuperintendentFunctionalAcctUser.insertSuperintendentFunctionalAcctUser(int.Parse(drpSuperintendents.SelectedValue), int.Parse(drpSuperintendents.SelectedValue));
        if (bRet == true)
        {
            viwFunctionalAcctMembers1.LoadSuperintendentAcctUserBySuperintendent(int.Parse(drpSuperintendents.SelectedValue), drpSuperintendents.SelectedItem.Text);

            string message = Search4User1.selectedUserDetails.m_sFullName + " now member of " + drpSuperintendents.SelectedItem.Text + " functional account.";
            ajaxWebExtension.showJscriptAlert(Page, this, message);
        }
    }
    protected void drpSuperintendents_SelectedIndexChanged(object sender, EventArgs e)
    {
        viwFunctionalAcctMembers1.LoadSuperintendentAcctUserBySuperintendent(int.Parse(drpSuperintendents.SelectedValue), drpSuperintendents.SelectedItem.Text);
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Setup/Superintendent.aspx");
    }
}
