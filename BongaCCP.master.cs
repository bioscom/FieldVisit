using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class BongaCCP : aspnetMaster
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

        loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + System.Web.HttpContext.Current.User.Identity.Name + "]";

        dateLabel.Text = DateTime.Today.Date.ToLongDateString();
        lblWebSiteTitle.Text = @"SCiN Commitment Control"; //AppConfiguration.siteNamePdcc;
    }

    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        
    }
}