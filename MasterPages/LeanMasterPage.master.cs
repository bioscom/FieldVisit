using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class MasterPages_LeanMasterPage : aspnetMaster
{
    protected void Page_Init(object sender, EventArgs e)
    {
       
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName))
        //{
        //    //Response.Redirect("~/Default.aspx?App=" + AppTokens.AppDesc((AppTokens.appTokens)AppTokens.appTokens.lean));
        //}
        //else
        //{
            
        //}

        //bool bRedirect = false;
        //string sRedirect = "";

        //try
        //{
        dateLabel.Text = dateRoutine.dateLong(DateTime.Now.Date);
        lblWebSiteTitle.Text = AppConfiguration.LeanSiteName;

        lblInfo.Text = AppConfiguration.LeanFooterInfo;
        lblCopyRight.Text = AppConfiguration.LeanCopyRight;

        //hpkLogout.Attributes.Add("onclick", "return clientMsgboxOnBlurEffect('Are You Sure You Want to Logout?')");
        loggedinUserLabel.Text = ((string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName))) ? HttpContext.Current.User.Identity.Name : this.oSessnx.getOnlineUser.m_sFullName;

        UserRoleLabel.Text = appUsersLeanRoles.userRoleDesc((appUsersLeanRoles.userRole)oSessnx.getOnlineUser.m_iRoleIdLean);
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}

        //if (bRedirect)
        //{
        //    Response.Redirect(sRedirect);
        //}

    }
}