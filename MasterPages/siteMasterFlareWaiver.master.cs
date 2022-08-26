using System;
using Microsoft.Security.Application;

public partial class MasterPages_siteMaster : aspnetMaster 
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.Head.Title = AppConfiguration.siteNameFlareWaiver;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            adminMenu1.Visible = false;
            Response.Redirect("~/Support/pageDenied.aspx?Msg=");
        }
        else
        {
            lblSiteName.Text = AppConfiguration.siteNameFlareWaiver;
            logoutHyperLink.Attributes.Add("onclick", "return LogoutMessage()");
            loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + Encoder.HtmlEncode(System.Web.HttpContext.Current.User.Identity.Name) + "]";

            if (string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName))
            {
                Response.Redirect("~/App/FlareWaiver/Default.aspx");
            }
            else
            {
                if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator) adminMenu1.Init_Page(AppConfiguration.AdminMenuFlareWaiver);
                else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator) adminMenu1.Init_Page(AppConfiguration.InitiatorMenuFlareWaiver);
                else if ((oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
                    || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
                    || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval))
                    adminMenu1.Init_Page(AppConfiguration.ApproverMenuFlareWaiver);
            }
            lblRole.Text = Encoder.HtmlEncode(appUserRolesFlrWaiver.userRoleDesc((appUserRolesFlrWaiver.userRole)oSessnx.getOnlineUser.m_iRoleIdFlr));
            dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        } 
    }

    protected void searchButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~/App/FlareWaiver/eSearch.aspx?xNo=" + txtFlarewaiverNum.Text.Trim());
    }
}
