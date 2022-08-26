using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Meoo = (!string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName)) ? oSessnx.getOnlineUser.m_sFullName : HttpContext.Current.User.Identity.Name;

        mssgLbl.Text = "Welcome: " + Meoo + "  " + DateTime.Today.Date.ToLongDateString() + " , " + DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss");
        //lblProdPerfDate.Text = DateTime.Today.Date.ToShortDateString();
        //lblGoalSZeroDate.Text = DateTime.Today.Date.ToShortDateString() + " Number of year of the day = " + DateTime.Now.Date.DayOfYear;

        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            if (Request.QueryString["iFnd"] == "NotFound")
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
                //ajaxWebExtension.showJscriptAlert(Page, this, "Note: It appears that you did not logon through a proper URL. You may experience some unexpected behaviour in the portal. If this occurs, kindly click on Home Page link.");
            }
        }
    }
}