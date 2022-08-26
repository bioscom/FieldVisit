using System;
using System.Web.UI;
using Microsoft.Security.Application;

public partial class MasterPages_BI500 : aspnetMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblInfo.Text = AppConfiguration.footerInfo;
        //lblCopyRight.Text = AppConfiguration.copyRight;

        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            adminMenu1.Visible = false; //.InitMenu();
            Response.Redirect("~/Support/pageDenied.aspx?Msg=");
            //ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have any sufficient account to use Production Cost Agenda. Please contact the Administrator.");
        }
        else
        {
            //if (oSessnx.getOnlineUser.m_iUserId == 0)
            //{
            //    Response.Redirect("~/Default.aspx?BI=" + (int)AppTokens.appTokens.BI500);
            //}

            loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

            dateLabel.Text = DateTime.Today.Date.ToLongDateString();
            lblWebSiteTitle.Text = AppConfiguration.siteNameBI500;

            if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.admin)
            {
                adminMenu1.Init_Page(AppConfiguration.adminMenuBI500);
                //lblRole.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oSessnx.getOnlineUser.m_iRoleIdBI);
            }
            else if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.CorporateViewer)
            {
                adminMenu1.Init_Page(AppConfiguration.corporateMenuBI500);
                //lblRole.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oSessnx.getOnlineUser.m_iRoleIdBI);
            }
            else
            {
                if (oSessnx.getOnlineUser.m_iUserId != 0)
                {
                    adminMenu1.Init_Page(AppConfiguration.userMenuBI500);
                    //lblRole.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oSessnx.getOnlineUser.m_iRoleIdBI);
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Login information incomplete. Please, contact the Admin.");
                }
            }
        }
    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
       
    }
}
