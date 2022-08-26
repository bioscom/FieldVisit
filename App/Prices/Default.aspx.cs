using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Prices_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Pending.LoadMySubmittedPendingPrices(oSessnx.getOnlineUser.m_iUserId);
            Approved.LoadMyApprovedPrices(oSessnx.getOnlineUser.m_iUserId);

            List<PriceReviewers> reviewers = PriceReviewerHelper.lstGetPriceReviewers();
            foreach (PriceReviewers o in reviewers)
            {
                if (o.iUserId == oSessnx.getOnlineUser.m_iUserId)
                {
                    //adminMenu1.Init_Page(AppConfiguration.adminMenuRedFlag);
                    Pending.LoadPendingRecords();
                    Approved.LoadClosedOutRecords();
                    break;
                }
            }

            //oPerformanceGraphs1.getValues();
            //oPerformanceByHub.HubsPerformance();
        }
    }
}