using System;

public partial class MasterPages_siteMaster : aspnetMaster
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.Head.Title = AppConfiguration.siteNameManHour;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if ((oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.initiator) || (oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.admin))
        //{
        //    Init_Control();
        //}
        //else
        //{
        //    Init_Control_Approvers();
        //}

        //try
        //{
            //if (!IsPostBack)
            //{
            lblWebSiteTitle.Text = AppConfiguration.siteNameManHour;
            loggedinUserLabel.Text = oSessnx.getOnlineUser.m_sFullName + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";
            dateLabel.Text = DateTime.Today.Date.ToLongDateString();

            //if ((oSessnx.getOnlineUser.m_iRoleIdManHr == null) || (oSessnx.getOnlineUser.m_iRoleIdManHr == 0))
            //{
            //    adminMenu1.Visible = false;
            //    Response.Redirect("~/Support/pageDenied.aspx?Msg=");
            //    //ajaxWebExtension.showJscriptAlert(Page, this, "Welcome " + oSessnx.getOnlineUser.m_sFullName + ". Sorry, you do not have any defined role to use Initiative Management Framework. Please contact the Administrator.");
            //}
            //else
            //{
                if (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)AppUsersRolesInitMgt.UserRole.Admin)
                {
                    adminMenu1.Init_Page(AppConfiguration.adminMenuManHour);
                }
                else
                {
                    adminMenu1.Visible = false;
                }

                lblRole.Text = ((oSessnx.getOnlineUser.m_iRoleIdManHr == null) || (oSessnx.getOnlineUser.m_iRoleIdManHr == 0)) ? AppUsersRolesInitMgt.UserRoleDesc((AppUsersRolesInitMgt.UserRole)(int)AppUsersRolesInitMgt.UserRole.Initiator) : AppUsersRolesInitMgt.UserRoleDesc((AppUsersRolesInitMgt.UserRole)oSessnx.getOnlineUser.m_iRoleIdManHr);
            //}
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }
    protected void searchButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

    }
}