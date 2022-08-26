using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Prices_taskPage : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["lpq"] == "0")
        {
            lblHeader.Text = "Insufficient Privilege!!!";

            string sMssg = "Sorry, you do not have sufficient privilege to view page. Contact System Administrator.";
            lblMsg.Text = sMssg;
            ajaxWebExtension.showJscriptAlert(Page, this, sMssg);
        }
        else
        {
            bool bRet = PriceReviewerHelper.GetReviewer(oSessnx.getOnlineUser.m_iUserId);

            //if (bRet) Response.Redirect("~/App/Prices/PriceCheckList.aspx");
            //else Response.Redirect("~/App/Prices/MyServiceMaterialCost.aspx");

            Response.Redirect("~/App/Prices/Default.aspx");
        }
    }
}