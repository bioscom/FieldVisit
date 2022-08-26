using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Prices_MyServiceMaterialCost : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MyOngoingSubmission.LoadMySubmittedPendingPrices(oSessnx.getOnlineUser.m_iUserId);
        MyApprovedSubmission.LoadMyApprovedPrices(oSessnx.getOnlineUser.m_iUserId);
    }
}