using System;

public partial class App_Lean_UserMgt : aspnetPage
{
    string sortArgument = "FULLNAME";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewUsers1.InitPage((int)AppTokens.appTokens.lean);
        }
    }
}