using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class MasterPages_PriceTracker : aspnetMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (oSessnx.getOnlineUser.m_iUserId == 0)
        //{
        //    Response.Redirect("~/Default.aspx?pr=" + (int)AppTokens.appTokens.prices);
        //}

        if (oSessnx.getOnlineUser == null)
        {
            //adminMenu1.Visible = false; //.InitMenu();
            Response.Redirect("~/Support/pageDenied.aspx?Msg=");
            //ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have any sufficient account to use Production Cost Agenda. Please contact the Administrator.");
        }
        else
        {
            loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

            dateLabel.Text = DateTime.Today.Date.ToLongDateString();
            lblWebSiteTitle.Text = @"Service/Material Cost Red Flag"; //AppConfiguration.siteNamePdcc;

            //adminMenu1.Init_Page(AppConfiguration.userMenuRedFlag);

            

            //bool bRet = reviewers.Contains(oSessnx.getOnlineUser.m_iUserId);
            //if (bRet)
            //{
            //    adminMenu1.Init_Page(AppConfiguration.adminMenuRedFlag);
            //}
            //else
            //{
            //    adminMenu1.Init_Page(AppConfiguration.userMenuRedFlag);
            //}
        }
    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}
