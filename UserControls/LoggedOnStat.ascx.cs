using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_LoggedOnStat : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Page_Init()
    {
        lblVisitedToday.Text = stringRoutine.formatAsNumber(appUsersHelper.iGetNoOfUsersLastLoggedOn(DateTime.Now.Date));
        lblOnline.Text = stringRoutine.formatAsNumber(appUsersHelper.iGetNoOfUsersCurrentlyLoggedOn(DateTime.Now.Date, DateTime.Now.Minute));
        lblVisited.Text = stringRoutine.formatAsNumber(appUsersHelper.iGetNoVisitedSite());
    }
}