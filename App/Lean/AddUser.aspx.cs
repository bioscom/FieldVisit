using System;
using System.Web.UI.WebControls;

public partial class App_Lean_AddUser : aspnetPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddUser1.Init_Page((int)AppTokens.appTokens.lean);
        }
    }
}