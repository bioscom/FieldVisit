using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Support_pageDenied : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //'Master.pageTasks = "Restricted Resource Access"
                msgTypeResponse(getQueryStringIdx());
                ajaxWebExtension.showJscriptAlert(Page, this, "Please, if you continue to experience this, call support on +234 807 022 4772. Thank you.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
        }
    }

    private string getQueryStringIdx()
    {
        string sRet = "";
        try
        {
            if (Request.QueryString["Msg"] != null)
            {
                sRet = Request.QueryString["Msg"];
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
        }
        return sRet;
    }

    private void msgTypeResponse(string sRetCode)
    {
        try
        {
            lblMsg.Text = "User Sign-In was Denied, Contact your Administrator";
            lblHeader.Text = "Requested Access Denied";

            switch (sRetCode)
            {
                //case "eId", "":

                case "":
                    lblMsg.Text = "You do NOT have the Required Access to this Application or you session has expired. Close and try login again.";
                    lblHeader.Text = "Invalid Account Status";
                    break;

                case "eId":
                    lblMsg.Text = "You do NOT have the Required Access to this Application";
                    lblHeader.Text = "Requested Access Denied";
                    break;

                case "nId":
                    lblMsg.Text = "You do NOT have the Required Access to this Application";
                    //lblMsg.Text = "User Account Has been Removed from this Application. Please, Contact your Administrator";
                    lblHeader.Text = "Invalid Account Status";
                    break;

                case "lId":
                    lblMsg.Text = "User Account is Currently Locked from Accessing this Application. Please, Contact your Administrator";
                    lblHeader.Text = "Locked Account Status";
                    break;

                case "Err":
                    lblMsg.Text = "User Account Sign-In Failed. Please, Try Again Later";
                    lblHeader.Text = "Account Login Error";
                    break;

                case "nLg":
                    lblMsg.Text = "Click the Login Link to Access this Application";
                    lblHeader.Text = "User Login Required";
                    break;

                case "noRL":
                    lblMsg.Text = "Please, you are not defined into any role in this application. Contact your Administrator.";
                    lblHeader.Text = "User Login Required";
                    break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
        }
    }
}