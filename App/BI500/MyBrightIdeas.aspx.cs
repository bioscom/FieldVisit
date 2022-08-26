using System;

public partial class App_BI500_MyBrightIdeas : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //oPndgRqst1.LoadMyPendingBrightIdeas(oSessnx.getOnlineUser);
            //oPndgRqst1.HideShowColumns(0);
            //oAprdgRqst1.LoadMyBrightIdeasApproved(oSessnx.getOnlineUser);
        }
    }
}