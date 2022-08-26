using System;
using Microsoft.Security.Application;

public partial class MasterPages_siteMasterFieldVisit : aspnetMaster
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.Head.Title = AppConfiguration.siteNameFieldVisit;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        logoutHyperLink.Attributes.Add("onclick", "return LogoutMessage()");
        dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        lblWebSiteTitle.Text = AppConfiguration.siteNameFieldVisit;
        lblRole.Text = Encoder.HtmlEncode(appUsersRoles.userRoleDesc((appUsersRoles.userRole)oSessnx.getOnlineUser.m_iRoleIdFieldVisit));
        loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

        lblInfo.Text = AppConfiguration.footerInfo;
        lblCopyRight.Text = AppConfiguration.copyRight;

        if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit == null) || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == 0))
        {
            adminMenu1.Visible = false; //.InitMenu();
            //Response.Redirect("~/Support/pageDenied.aspx?Msg=");
            ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have any sufficient account to use Field Visit/PEC. Please contact the Administrator.");
        }
        else
        {
            //if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit == null) || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == 0))
            //{
            if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin)
            {
                adminMenu1.Init_Page(AppConfiguration.adminMenuFieldVisit);
            }
            else
            {
                adminMenu1.Init_Page(AppConfiguration.userMenuFieldVisit);
            }
            //}

            KounterView();
        }
    }

    private void KounterView()
    {
        //TODO: Find out if the logged on user is a member of a superintendent
        //then enable the superintendent activity counter
        //else disable the activity counter

        myRequestsHistory1.Visible = false;
        myApprovedRequestsHistory1.Visible = false;
        SuperIntendentCounter1.Visible = false;
        MyRequests1.Visible = false;
        OthersRequest1.Visible = false;

        if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin)
        {
            myRequestsHistory1.Visible = true;
            myRequestsHistory1.Init_Page();

            MyRequests1.Visible = true;
            MyRequests1.Init_Page();

            myApprovedRequestsHistory1.Visible = true;
            myApprovedRequestsHistory1.Init_Page();

            OthersRequest1.Visible = true;
            OthersRequest1.Init_Page();

            SuperIntendentCounter1.Visible = true;
            SuperIntendentCounter1.Init_Page();
        }
        else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.initiator)
        {
            myRequestsHistory1.Visible = true;
            myRequestsHistory1.Init_Page();

            MyRequests1.Visible = true;
            MyRequests1.Init_Page();

            myApprovedRequestsHistory1.Visible = true;
            myApprovedRequestsHistory1.Init_Page();

            OthersRequest1.Visible = true;
            OthersRequest1.Init_Page();
        }
        else if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.sponsor)
            || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.FunctionalLead)
            || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.planner)
            || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.AssetOperationsManager)
            || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin))
        {
            myRequestsHistory1.Visible = true;
            myRequestsHistory1.Init_Page();

            MyRequests1.Visible = true;
            MyRequests1.Init_Page();

            myApprovedRequestsHistory1.Visible = true;
            myApprovedRequestsHistory1.Init_Page();

            OthersRequest1.Visible = true;
            OthersRequest1.Init_Page();
        }
        else if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.superintendent) || (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin))
        {
            SuperIntendentCounter1.Visible = true;
            SuperIntendentCounter1.Init_Page();

            OthersRequest1.Visible = true;
            OthersRequest1.Init_Page();
        }
    }
}