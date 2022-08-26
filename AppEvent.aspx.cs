using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AppEvent : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //Code that runs when an unhandled error occurs
    //        Exception objErr = Server.GetLastError().GetBaseException();
    //        string err = "<b>Error Caught in Application_Error event<b/> <br/> <br/>";
    //        err += "Error in: " + Request.Url.ToString() + "<br/>";
    //        err += "<br/>Error Message: " + objErr.Message.ToString() + "";
    //        err += "<br/> <br/>Stack Trace: " + objErr.StackTrace.ToString();
    //        //EventLog.WriteEntry("EIP_WebApp_Errors", err, EventLogEntryType.Error);
    //        Server.ClearError();

    //        sendMail MyMail = new sendMail(sendMail.eManager());
    //        MyMail.ApplicationErrorMessage(sendMail.eManager(), sendMail.eManager(), err);
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    catch (Exception ex)
    //    {
    //        //appMonitor.logAppExceptions(ex);
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        //sendMailFlareWaiver MyMail = new sendMailFlareWaiver(oSessnx.getOnlineUser.structUserIdx);
        FlareWaiverSendMail.sendMail MyMail = new FlareWaiverSendMail.sendMail(FlareWaiverSendMail.sendMail.eManager());
        try
        {
            //Code that runs when an unhandled error occurs
            Exception objErr = Server.GetLastError().GetBaseException();
            string err = "<b>Error Caught in Application_Error event<b/> <br/> <br/>";
            err += "Error in: " + Request.Url.ToString() + "<br/>";
            err += "<br/>Error Message: " + objErr.Message.ToString() + "";
            err += "<br/> <br/>Stack Trace: " + objErr.StackTrace.ToString();
            //EventLog.WriteEntry("EIP_WebApp_Errors", err, EventLogEntryType.Error);
            Server.ClearError();

            appUsersHelper oappUsersHelper = new appUsersHelper();

            List<structUserMailIdx> Admins = new List<structUserMailIdx>();
            List<appUsers> Administrators = oappUsersHelper.lstGetUserByRole((int)appUsersRoles.userRole.admin);
            foreach (appUsers Administrator in Administrators)
            {
                //todo: arrange the code here properly, no hard code
                if (Administrator.m_iDeligate == 1)
                {
                    Admins.Add(Administrator.structUserIdx);
                }
            }

            MyMail.ApplicationErrorMessage(Admins, err);
            Server.Transfer("~/Default.aspx");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

}