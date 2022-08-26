using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class MasterPages_ActionTracker : aspnetMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

        dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        lblWebSiteTitle.Text = @"Action Tracker"; //AppConfiguration.siteNamePdcc;

        //adminMenu1.Init_Page(oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int) appUsersRoles.userRole.admin
        //    ? AppConfiguration.adminMenuPdcc
        //    : AppConfiguration.userMenuPdcc);

        ////lblInfo.Text = AppConfiguration.footerInfo;
        ////lblCopyRight.Text = AppConfiguration.copyRight;

        //if ((oSessnx.getOnlineUser.m_iRolePdcc == null) || (oSessnx.getOnlineUser.m_iRolePdcc == 0))
        //{
        //    adminMenu1.Visible = false; //.InitMenu();
        //    //Response.Redirect("~/Support/pageDenied.aspx?Msg=");
        //    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have any sufficient account. Please contact the Administrator.");
        //}
        //else
        //{
        //    loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

        //    dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        //    lblWebSiteTitle.Text = AppConfiguration.siteNamePdcc;

        //    if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Administrator)
        //    {
        //        adminMenu1.Init_Page(AppConfiguration.adminMenuPdcc);
        //    }
        //    else
        //    {
        //        adminMenu1.Init_Page(AppConfiguration.userMenuPdcc);
        //    }
        //}
    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
        
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/PPMS/Search.aspx?IdNo=" + txtIdNo.Text);
    }
}
