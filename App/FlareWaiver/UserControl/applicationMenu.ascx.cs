using System;

public partial class UserControl_applicationMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(string _siteMapProvider)
    {
        SiteMapDataSource1.SiteMapProvider = _siteMapProvider;
    }
}
