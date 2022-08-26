using System;

public partial class UserControl_adminMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(string _siteMapProvider)
    {
        SMapDS.SiteMapProvider = _siteMapProvider;
    }

    public void InitMenu()
    {
        SMapDS.SiteMapProvider = null;
    }
}
