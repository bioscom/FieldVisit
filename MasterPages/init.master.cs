using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_init : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        //this.Head.Title = AppConfiguration.siteName;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblWebSiteTitle.Text = AppConfiguration.siteName;
        loggedinUserLabel.Text = System.Web.HttpContext.Current.User.Identity.Name;
        dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        logoutHyperLink.Attributes.Add("onclick", "return LogoutMessage()");
    }
}