using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_AllBrightIdeas : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRolesBI500.userRole.admin.ToString(), appUsersRolesBI500.userRole.CorporateViewer.ToString() };
            appUsersRolesBI500 oAccess = new appUsersRolesBI500();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRolesBI500.userRole)this.oSessnx.getOnlineUser.m_iRoleIdBI);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        //oPndgRqst1.LoadPendingBrightIdeasRegister();
        oAprdgRqst1.LoadApprovedBrightIdeasRegister();

        foreach (GridViewRow grdRow in oAprdgRqst1.oGrdGridView.Rows)
        {
            LinkButton lnkPhasing = (LinkButton)grdRow.FindControl("PhaseLinkButton");
            lnkPhasing.Enabled = false;
            //LinkButton PhaseLinkButton = (LinkButton)grdGridView.FindControl("PhaseLinkButton");
        }
        //oPndgRqst1.HideActionLinkColumn();
        //oPndgRqst1.HideEditLinkColumn();
        //oPndgRqst1.HideShowColumns(1);

        //oAprdgRqst1.lnkPhasing.Enabled = false;
    }
}