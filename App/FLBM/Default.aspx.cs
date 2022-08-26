using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FLBM_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnKnowledge_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/FLBM/Assessment.aspx");
    }
    protected void btnAdminSetup_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/FLBM/Settings.aspx");
    }
}