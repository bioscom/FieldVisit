using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Prices_PriceCheckList : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = PriceReviewerHelper.GetReviewer(oSessnx.getOnlineUser.m_iUserId);
        if (bRet)
        {
            oCostSavingForReviewer.LoadPendingRecords();
            oClosedOut.LoadClosedOutRecords();
        }
        else if (bRet == false)
        {
            Response.Redirect("~/App/Prices/taskPage.aspx?lpq=0");
        } 
    }
}