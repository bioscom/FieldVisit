using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_Report_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnWeekly_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 0;
    }
    protected void btnMonthly_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 1;
    }
    protected void btnYearly_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 2;
    }
}