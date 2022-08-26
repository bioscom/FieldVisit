using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;

/// <summary>
/// Summary description for SendMailIDD
/// </summary>

public class SendMailIDD
{
    private const string c_sMailSubjet = "Electronic Integrity Due Diligence";
    private const string c_sPECMailSubjet = "Business Improvement: ";
    private readonly string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/p_ShellLogo.gif");

    private readonly structUserMailIdx m_eSender;
    readonly appUsersHelper oHlp = new appUsersHelper();
    //readonly EIdd.ContractHoldersMgt ch = new EIdd.ContractHoldersMgt();
    readonly EIdd.CategoryMgt catMgt = new EIdd.CategoryMgt();

    public SendMailIDD(structUserMailIdx _eSender)
    {
        m_eSender = _eSender;
    }

    public static structUserMailIdx eManager()
    {
        return new structUserMailIdx(AppConfiguration.adminName, AppConfiguration.adminEmail, "");
    }

    //public bool ContractHolderRaisedRequest(EIdd.RequestForIDD o, List<structUserMailIdx> eTo, List<structUserMailIdx> eCopy)
    //{
    //    //Send to CP IDD Focal Point 
    //    //Copy Category Lead and Request initiator 
    //    string sBody = Resources.IDDResource.ContractHolder;
    //    bool bRet = false;
    //    try
    //    {
    //        string sSubject = o.m_sIDDNo + " - " + c_sMailSubjet;

    //        sBody = sBody.Replace("@=VENDOR", o.m_sRegisteredName);
    //        sBody = sBody.Replace("@=VALUE", stringRoutine.formatAsBankMoney("$", o.m_dAmount));
    //        sBody = sBody.Replace("@=NATURE", o.m_iNoR.ToString());
    //        sBody = sBody.Replace("@=CATEGORY", catMgt.objGetServiceByServiceId(o.m_iCategoryId).m_sCategory);
    //        sBody = sBody.Replace("@=CONTRACTHOLDER", o.m_sContractHolder);
    //        sBody = sBody.Replace("@=IDDFOCALPOINT", o.m_sFocalPoint);
    //        sBody = sBody.Replace("@=ANALYST", o.m_sAnalyst);

    //        string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/pec?Id=Idd";
    //        AlternateView altView = CommonContent(sBody, httpHost);
    //        var oMail = new emailClientExPic(m_eSender);
    //        bRet = oMail.sendShellMail(eTo, eCopy, sSubject, sBody, altView);

    //        return bRet;
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //    }
    //    return bRet;
    //}

    public bool ContractHolderRaisedRequest(EIdd.RequestForIDD o, List<structUserMailIdx> eTo, List<structUserMailIdx> eCopy)
    {
        //EIdd.IDDRequestMgt ott = new EIdd.IDDRequestMgt();
        EIdd.VendorReportMgt ott = new EIdd.VendorReportMgt();


        //Send to CP IDD Focal Point 
        //Copy Category Lead and Request initiator 
        string sBody = Resources.IDDResource.ContractHolder;
        bool bRet = false;
        try
        {
            EIdd.Vendours vendr = ott.objGetVendorById(o.m_lVendorId);
            
            string sSubject = vendr.m_sIDDNo + " - " + c_sMailSubjet;

            sBody = sBody.Replace("@=VENDOR", vendr.m_sRegisteredName);
            sBody = sBody.Replace("@=VALUE", stringRoutine.formatAsBankMoney("$", vendr.m_dAmount));
            sBody = sBody.Replace("@=NATURE", EIdd.NatureOfRequest.NatureOfRequestStatusDesc((EIdd.NatureOfRequest.NatureOfRequestStatus)o.m_iNoR));
            sBody = sBody.Replace("@=CATEGORY", catMgt.objGetServiceByServiceId(o.m_iCategoryId).m_sCategory);
            sBody = sBody.Replace("@=CONTRACTHOLDER", o.m_sContractHolder);
            sBody = sBody.Replace("@=IDDFOCALPOINT", o.m_sFocalPoint);
            sBody = sBody.Replace("@=ANALYST", o.m_sAnalyst);

            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/pec?Id=Idd";
            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eTo, eCopy, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool AssignAnalystToRequest(EIdd.RequestForIDD o, structUserMailIdx eTo, List<structUserMailIdx> eCopy)
    {
        //Send to IDD Analyst
        //Copy CP IDD Focal Point, Category Lead and Request initiator 
        string sBody = Resources.IDDResource.IDDFocalPoint;
        bool bRet = false;
        try
        {
            string sSubject = o.m_sIDDNo + " - " + c_sMailSubjet;

            sBody = sBody.Replace("@=VENDOR", o.m_sRegisteredName);
            sBody = sBody.Replace("@=VALUE", stringRoutine.formatAsBankMoney("$", o.m_dAmount));
            sBody = sBody.Replace("@=NATURE", EIdd.NatureOfRequest.NatureOfRequestStatusDesc((EIdd.NatureOfRequest.NatureOfRequestStatus)o.m_iNoR));
            sBody = sBody.Replace("@=CATEGORY", catMgt.objGetServiceByServiceId(o.m_iCategoryId).m_sCategory);
            sBody = sBody.Replace("@=CONTRACTHOLDER", o.m_sContractHolder);
            sBody = sBody.Replace("@=IDDFOCALPOINT", o.m_sFocalPoint);
            sBody = sBody.Replace("@=ANALYST", o.m_sAnalyst);

            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() +"/pec?Id=Analyst";
            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eTo, eCopy, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool RequestRejected(EIdd.RequestForIDD o, structUserMailIdx eTo, List<structUserMailIdx> eCopy, string sReasonRejected)
    {
        //Send to IDD Analyst
        //Copy CP IDD Focal Point, Category Lead and Request initiator 
        string sBody = Resources.IDDResource.Rejected;
        bool bRet = false;
        try
        {
            string sSubject = o.m_sIDDNo + " - " + c_sMailSubjet;

            sBody = sBody.Replace("@=VENDOR", o.m_sRegisteredName);
            sBody = sBody.Replace("@=VALUE", stringRoutine.formatAsBankMoney("$", o.m_dAmount));
            sBody = sBody.Replace("@=NATURE", EIdd.NatureOfRequest.NatureOfRequestStatusDesc((EIdd.NatureOfRequest.NatureOfRequestStatus)o.m_iNoR));
            sBody = sBody.Replace("@=CATEGORY", catMgt.objGetServiceByServiceId(o.m_iCategoryId).m_sCategory);
            sBody = sBody.Replace("@=CONTRACTHOLDER", o.m_sContractHolder);
            sBody = sBody.Replace("@=IDDFOCALPOINT", o.m_sFocalPoint);
            sBody = sBody.Replace("@=REASON", sReasonRejected);

            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/pec?Id=Idd";
            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eTo, eCopy, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool AnalystActionsRequest(EIdd.RequestForIDD o, structUserMailIdx eTo, List<structUserMailIdx> eCopy)
    {
        //Send to IDD CP IDD Focal Point
        //Copy Category Leads and Request initiator 
        string sBody = Resources.IDDResource.AnalystAction;
        bool bRet = false;
        try
        {
            string sSubject = o.m_sIDDNo + " - " + c_sMailSubjet;

            sBody = sBody.Replace("@=VENDOR", o.m_sRegisteredName);
            sBody = sBody.Replace("@=VALUE", stringRoutine.formatAsBankMoney("$", o.m_dAmount));
            sBody = sBody.Replace("@=NATURE", EIdd.NatureOfRequest.NatureOfRequestStatusDesc((EIdd.NatureOfRequest.NatureOfRequestStatus)o.m_iNoR));
            sBody = sBody.Replace("@=CATEGORY", catMgt.objGetServiceByServiceId(o.m_iCategoryId).m_sCategory);
            sBody = sBody.Replace("@=CONTRACTHOLDER", o.m_sContractHolder);
            sBody = sBody.Replace("@=IDDFOCALPOINT", o.m_sFocalPoint);
            sBody = sBody.Replace("@=ANALYST", o.m_sAnalyst);

            sBody = sBody.Replace("@=STAGE", EIdd.StageEnums.IddStageDesc((EIdd.StageEnums.IddStage) o.m_iStage));
            sBody = sBody.Replace("@=COMMENT", o.m_sComments);

            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/pec?Id=Idd";
            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eTo, eCopy, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool AnalystActionsCompleted(EIdd.RequestForIDD o, List<structUserMailIdx> eTo)
    {
        //Send to IDD CP IDD Focal Point
        //Copy Category Leads and Request initiator 
        string sBody = Resources.IDDResource.Completed;
        bool bRet = false;
        try
        {
            string sSubject = o.m_sIDDNo + " - " + c_sMailSubjet;

            sBody = sBody.Replace("@=VENDOR", o.m_sRegisteredName);
            sBody = sBody.Replace("@=VALUE", stringRoutine.formatAsBankMoney("$", o.m_dAmount));
            sBody = sBody.Replace("@=NATURE", EIdd.NatureOfRequest.NatureOfRequestStatusDesc((EIdd.NatureOfRequest.NatureOfRequestStatus)o.m_iNoR));
            sBody = sBody.Replace("@=CATEGORY", catMgt.objGetServiceByServiceId(o.m_iCategoryId).m_sCategory);
            sBody = sBody.Replace("@=CONTRACTHOLDER", o.m_sContractHolder);
            sBody = sBody.Replace("@=IDDFOCALPOINT", o.m_sFocalPoint);
            sBody = sBody.Replace("@=ANALYST", o.m_sAnalyst);

            sBody = sBody.Replace("@=STAGE", EIdd.StageEnums.IddStageDesc((EIdd.StageEnums.IddStage) o.m_iStage));
            sBody = sBody.Replace("@=COMMENT", o.m_sComments);

            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/pec?Id=Idd";
            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eTo, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    private AlternateView CommonContent(string sBody, string httpHost)
    {
        sBody = sBody.Replace("@=EEEE", httpHost);
        sBody = sBody.Replace("@=TTTT", DateTime.Today.ToLongDateString());

        sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
        sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

        AlternateView altView = AlternateView.CreateAlternateViewFromString(sBody, null, MediaTypeNames.Text.Html);
        var pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
        pic.ContentId = "Logo";
        altView.LinkedResources.Add(pic);

        return altView;
    }
}