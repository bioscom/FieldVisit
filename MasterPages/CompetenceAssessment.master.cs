using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class MasterPages_CompetenceAssessment : aspnetMaster
{
    protected void Page_Init(object sender, EventArgs e)
    {
        //Head.Title = AppConfiguration.siteNameFieldVisit;
        Head.Title = "FLBM: Monitor and Control Hydrocarbon Process Activities";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        logoutHyperLink.Attributes.Add("onclick", "return LogoutMessage()");

        dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        lblWebSiteTitle.Text = "FLBM: Monitor and Control Hydrocarbon Process Activities"; //AppConfiguration.siteNameFieldVisit;
        lblRole.Text = Encoder.HtmlEncode(appUsersRoles.userRoleDesc((appUsersRoles.userRole)oSessnx.getOnlineUser.m_iRoleIdFieldVisit));
        loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + HttpContext.Current.User.Identity.Name + "]";

        lblInfo.Text = AppConfiguration.footerInfo;
        lblCopyRight.Text = AppConfiguration.copyRight;

        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            adminMenu1.Visible = false; //.InitMenu();
            Response.Redirect("~/Support/pageDenied.aspx?Msg=");
        }
        else
        {
            if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit == null) || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == 0))
            {
                Response.Redirect("~/Support/pageDenied.aspx?Msg=noRL");
            }
            else
            {
                if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin)
                {
                    adminMenu1.Init_Page(AppConfiguration.adminMenuFLBM);
                }
                else
                {
                    adminMenu1.Init_Page(AppConfiguration.userMenuFLBM);
                }

                // KounterView();
            }
        }
    }
}
