using System;
using Microsoft.Security.Application;

public partial class MasterPages_configuration : aspnetMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (oSessnx.getOnlineUser.m_sFullName != null)
            {
                string message = loginUser.msgQueryString(reqQueryMsg(), oSessnx);
                ajaxWebExtension.showJscriptAlert(Page, this, message);

                loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]");

                dateLabel.Text = DateTime.Today.Date.ToLongDateString();
                lblWebSiteTitle.Text = AppConfiguration.CBISiteName;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
