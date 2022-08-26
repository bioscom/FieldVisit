using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Telerik.Web.UI;

public partial class IDD : aspnetMaster
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Note: The immediate line below is very important for all pages that references jQuery, JavaScripts and CSS to function.
        Page.Header.DataBind();

        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            //RadWindowManager1.RadAlert("Your session has expired, please logout and login again.", 350, 230, "Session Expired", "alertCallBackFn");
            Response.Redirect("~/Support/pageDenied.aspx");  
        }
        else
        {
            loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

            dateLabel.Text = DateTime.Today.Date.ToLongDateString();
            lblWebSiteTitle.Text = @"Electronic Integrity Due Diligence"; //AppConfiguration.siteNamePdcc;
        }       
    }
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void searchButton_Click(object sender, EventArgs e)
    {

    }

    //protected void ddlVendor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        long lRequestId = long.Parse(ddlVendor.SelectedValue);
    //        Response.Redirect("~/App/IDD/RenewRequest.aspx?lRequestId=" + lRequestId);
    //    }
    //    catch(Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    //protected void ddlVendor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    //{
    //    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    //    System.Data.DataTable dt = !string.IsNullOrEmpty(e.Text) ? o.dtGetRequestBySearch(e.Text) : null;

    //    EIdd.Utilities.RadComboControlLoader2(dt, ddlVendor);
    //}
}