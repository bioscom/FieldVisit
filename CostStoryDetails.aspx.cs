using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CostStoryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ActivityLogCntl1.InitPage();
        ActivityLogCntl1.oUpdateButton.Visible = false;
    }
}