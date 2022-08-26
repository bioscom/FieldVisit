using System;

public partial class CBIDashboard2 : aspnetMaster
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.Head.Title = AppConfiguration.CBISiteName;
        SiteMapData.SiteMapProvider = AppConfiguration.CBIDashBoardMenu;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        logoutHyperLink.Attributes.Add("onclick", "return LogoutMessage()");
        //try
        //{
        dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        lblWebSiteTitle.Text = AppConfiguration.CBISiteName;

        //Summary: In case session expires, please relogin the user automatically.
        if (string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sUserName))
        {
            loggedinUserLabel.Text = System.Web.HttpContext.Current.User.Identity.Name;
            //lblLoginUser2.Text = System.Web.HttpContext.Current.User.Identity.Name;
        }
        else
        {
            loggedinUserLabel.Text = oSessnx.getOnlineUser.m_sFullName;
            //lblLoginUser2.Text = oSessnx.getOnlineUser.m_sFullName;
        }

        //lblRole.Text = Encoder.HtmlEncode(appUsersRoles.userRoleDesc((appUsersRoles.userRole)oSessnx.getOnlineUser.m_iRoleIdFieldVisit));
        //loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

        //lblInfo.Text = AppConfiguration.footerInfo;
        //lblCopyRight.Text = AppConfiguration.copyRight;

        
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }
}
