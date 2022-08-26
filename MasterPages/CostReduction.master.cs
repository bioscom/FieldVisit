using System;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class MasterPages_CostReduction : aspnetMaster
{
    protected void OnMenuItemDataBound(object sender, MenuEventArgs e)
    {
        if (SiteMap.CurrentNode != null)
        {
            if (e.Item.Text == SiteMap.CurrentNode.Title)
            {
                if (e.Item.Parent != null)
                {
                    e.Item.Parent.Selected = true;
                }
                else
                {
                    e.Item.Selected = true;
                }
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            //adminMenu1.Visible = false;
            Response.Redirect("~/Support/pageDenied.aspx?Msg=");
            //ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have any sufficient account to use Production Cost Agenda. Please contact the Administrator.");
        }
        else
        {
            loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

            dateLabel.Text = DateTime.Today.Date.ToLongDateString();
            lblWebSiteTitle.Text = AppConfiguration.siteNameCRP;

            if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.admin)
            {
                adminMenu1.Init_Page(AppConfiguration.adminMenuCostReduction);
                //SMDS.SiteMapProvider = AppConfiguration.adminMenuCostReduction;
                lblRole.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oSessnx.getOnlineUser.m_iRoleIdBI);
            }
            else if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.CorporateViewer)
            {
                adminMenu1.Init_Page(AppConfiguration.corporateMenuCostReduction);
                //SMDS.SiteMapProvider = AppConfiguration.corporateMenuCostReduction;
                lblRole.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oSessnx.getOnlineUser.m_iRoleIdBI);
            }
            else
            {
                if (oSessnx.getOnlineUser.m_iUserId != 0)
                {

                    adminMenu1.Init_Page(AppConfiguration.userMenuCostReduction);
                    //SMDS.SiteMapProvider = AppConfiguration.userMenuCostReduction;
                    lblRole.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oSessnx.getOnlineUser.m_iRoleIdBI);
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Login information incomplete. Please, contact the Admin.");
                }
            }
        }
    }
}
