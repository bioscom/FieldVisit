using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_userHelpGuide : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void hlpGuideLinkButton_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "Application/pdf";
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", "UserManual.pdf"));
        Response.Flush();
        Response.WriteFile(Server.MapPath("~/Help/UserManual.pdf"));
    }
}
