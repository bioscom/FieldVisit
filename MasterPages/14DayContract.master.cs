using System;
using System.Web;
using System.Web.UI;

public partial class MasterPages_14DayContract : aspnetMaster
{
    protected void Page_Init(object sender, EventArgs e)
    {
        dateLabel.Text = dateRoutine.dateLong(DateTime.Now.Date);
        lblSiteName.Text = AppConfiguration.siteName14DayContract;

        //hpkLogout.Attributes.Add("onclick", "return clientMsgboxOnBlurEffect('Are You Sure You Want to Logout?')");
        loggedinUserLabel.Text = ((string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName))) ? HttpContext.Current.User.Identity.Name : oSessnx.getOnlineUser.m_sFullName;

        lblRole.Text = AppUsers14DaysContract.UserRoleDesc((AppUsers14DaysContract.UserRole)oSessnx.getOnlineUser.m_iRoleIdContract); 
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (oSessnx.getOnlineUser.m_iRoleIdContract == (int)AppUsers14DaysContract.UserRole.Administrator)
                {
                    adminMenu.Init_Page(AppConfiguration.adminMenu14DayContract);
                }
                else
                {
                    //adminMenu.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {

    }
}
