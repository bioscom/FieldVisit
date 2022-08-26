using System;
using System.Collections.Generic;
using System.Text;

public class performanceMail
{
    private const string c_sMailSubjet = "CI Dashboard As Is VSM bulk upload Mail: ";
    private structUserMailIdx m_eSender;

    public performanceMail(structUserMailIdx _eSender)
    {
        m_eSender = _eSender;
    }

    public static structUserMailIdx eManager()
    {
        return new structUserMailIdx(AppConfiguration.adminName, AppConfiguration.adminEmail, "");
    }

    public bool sendBulkLoadError(structUserMailIdx eUserId, string sAttach, string sSubject, string sTitle)
    {
        bool bRet = false;
        try
        {
            string sBody = Resources.ResourceLean.bulkLoadError;
            sBody = sBody.Replace("@=AAAA", eUserId.m_sUserName);
            sBody = sBody.Replace("@=RRRR", eManager().m_sUserName);
            sBody = sBody.Replace("@=SSSS", eManager().m_sUserMail);
            sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());
            sBody = sBody.Replace("@=ZZZZ", sTitle);
            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eUserId, sSubject + " Bulk Load Error Report", sBody, sAttach);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    //public bool monthlyReminder(structUserMailIdx eCreator, structUserMailIdx eUser, List<string> defaultingKpi)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    foreach (string s in defaultingKpi)
    //    {
    //        sb.Append(s);
    //        sb.Append("; ");
    //    }

    //    bool bRet = false;
    //    try
    //    {
    //        string sBody = Resources.Resource.monthlyKpiUpdateReminder;
    //        sBody = sBody.Replace("@=KKKK", sb.ToString());
    //        sBody = sBody.Replace("@=EEEE", urlRoutines.getAppResourceUrl("~/taskPage.aspx"));
    //        sBody = sBody.Replace("@=FFFF", eCreator.m_sUserName);
    //        sBody = sBody.Replace("@=RRRR", eManager().m_sUserName);
    //        sBody = sBody.Replace("@=SSSS", eManager().m_sUserMail);
    //        //sBody = sBody.Replace("@=TTTT", globalCodes.c_sOwnerCompany);

    //        emailClient oMail = new emailClient(m_eSender);
    //        bRet = oMail.sendShellMail(eUser, eCreator, c_sMailSubjet + " Monthly KPI update reminder.", sBody);
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //    }
    //    return bRet;
    //}
}