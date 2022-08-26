using System;
using System.Web.Security;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        //FormsAuthentication.RedirectToLoginPage("Msg=" & sRet);
        Session.Clear();
        Response.Redirect("http://sww.scin.shell.com/ep/epg/sepcin");
    }
}
