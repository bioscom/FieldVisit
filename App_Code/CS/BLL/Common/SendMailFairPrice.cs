using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;

/// <summary>
/// Summary description for SendMail14DaysContract
/// </summary>
public class SendMailFairPrice
{
    private const string c_sMailSubjet = "Operations Goods and Services Fair Price Assurance";
    private const string c_sPECMailSubjet = "Business Improvement and Production Excellence: ";
    private string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/p_ShellLogo.gif");

    private structUserMailIdx m_eSender;

    public SendMailFairPrice(structUserMailIdx _eSender)
    {
        m_eSender = _eSender;
    }

    public static structUserMailIdx eManager()
    {
        return new structUserMailIdx(AppConfiguration.adminName, AppConfiguration.adminEmail, "");
    }

    public bool SendNotificationForReview(appUsers Poster, string sPONumber, string sItem, string sCode, decimal dPrice, decimal dShouldBePrice, string sSource, List<structUserMailIdx> eReviewers)
    {
        string sBody = Resources.FairPrice.GoodServiceFairPrice;
        bool bRet = false;
        try
        {
            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/PEC?pr=9";
            string sSubject = sPONumber + " - " + c_sMailSubjet;

            sBody = sBody.Replace("@=SENDER", Poster.m_sFullName);
            sBody = sBody.Replace("@=PONUMBER", sPONumber);
            sBody = sBody.Replace("@=ITEM", sItem);
            sBody = sBody.Replace("@=CODE", sCode);
            sBody = sBody.Replace("@=PRICE", stringRoutine.formatAsBankMoney(dPrice));
            sBody = sBody.Replace("@=SHOULDBEPRICE", stringRoutine.formatAsBankMoney(dShouldBePrice));

            decimal dVariance = (dShouldBePrice - dPrice);

            sBody = sBody.Replace("@=VARIANCE", stringRoutine.formatAsBankMoney(dVariance));
            sBody = sBody.Replace("@=SOURCE", sSource);
                                        
            sBody = sBody.Replace("@=EEEE", httpHost);
            sBody = sBody.Replace("@=TTTT", DateTime.Today.ToLongDateString());

            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eReviewers, Poster.structUserIdx, sSubject, sBody, altView);


            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool ReviewNotification(appUsers Poster, Price oPrice, List<structUserMailIdx> eReviewers)
    {
        string sBody = Resources.FairPrice.GoodServiceFairPriceReview;
        bool bRet = false;
        try
        {
            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/PEC?pr=9";
            string sSubject = oPrice.sPONumber + " - " + c_sMailSubjet;

            sBody = sBody.Replace("@=SENDER", Poster.m_sFullName);
            sBody = sBody.Replace("@=PONUMBER", oPrice.sPONumber);
            sBody = sBody.Replace("@=ITEM", oPrice.sMaterialDescription);
            sBody = sBody.Replace("@=CODE", oPrice.sMaterialCode);
            sBody = sBody.Replace("@=PRICE", stringRoutine.formatAsBankMoney(oPrice.dPrice));
            sBody = sBody.Replace("@=SHOULDBEPRICE", stringRoutine.formatAsBankMoney(oPrice.dShouldBePrice));

            sBody = sBody.Replace("@=COMMENTS", oPrice.sComments);

            decimal dPrice = oPrice.dPrice;
            decimal dShouldBePrice = oPrice.dShouldBePrice;
            decimal dVariance = (dShouldBePrice - dPrice);

            sBody = sBody.Replace("@=VARIANCE", stringRoutine.formatAsBankMoney(dVariance));
            sBody = sBody.Replace("@=AMTSAVED", stringRoutine.formatAsBankMoney(oPrice.dAmountSaved));
            sBody = sBody.Replace("@=SOURCE", oPrice.sPriceSource);

            sBody = sBody.Replace("@=EEEE", httpHost);
            sBody = sBody.Replace("@=TTTT", DateTime.Today.ToLongDateString());

            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(Poster.structUserIdx, eReviewers, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool ItemsPendingReview(List<structUserMailIdx> eReviewers)
    {
        string sBody = Resources.FairPrice.GoodServiceReminder;
        bool bRet = false;
        try
        {
            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString() + "/PEC?pr=9";
            string sSubject = c_sMailSubjet + "- items pending your attention.";

            int i = 1;
            List<Price> lstPendingReview = PriceHelper.LstGetPricesPendingReview();

            string tbl = "<br/><table style='border-spacing: 10px; border:solid 1px silver'>";
            tbl += "<tr style='padding:5px; border:solid 1px silver; font:bold'>";
            tbl += "<td style='border:solid 1px silver'>S/No</td>";
            tbl += "<td style='border:solid 1px silver'>Material Description</td>";
            tbl += "<td style='border:solid 1px silver'>PO Number</td>";
            tbl += "<td style='border:solid 1px silver'>Material Code</td>";
            tbl += "<td style='border:solid 1px silver'>Price($)</td>";
            tbl += "<td style='border:solid 1px silver'>Should be Price($)</td>";
            tbl += "<td style='border:solid 1px silver'>Price Variance($)</td>";
            tbl += "<td style='border:solid 1px silver'>Date Submitted</td></tr>";

            foreach (Price oPrice in lstPendingReview)
            {
                tbl += "<tr style='padding:5px; border:solid 1px silver'>";
                tbl += "<td style='border:solid 1px silver'>" + i + "</td>";
                tbl += "<td style='border:solid 1px silver'>" + oPrice.sMaterialDescription + "</td>";
                tbl += "<td style='border:solid 1px silver'>" + oPrice.sPONumber + "</td>";
                tbl += "<td style='border:solid 1px silver'>" + oPrice.sMaterialCode + "</td>";
                tbl += "<td style='border:solid 1px silver; text-align:right'>" + stringRoutine.formatAsBankMoney(oPrice.dPrice) + "</td>";
                tbl += "<td style='border:solid 1px silver; text-align:right'>" + stringRoutine.formatAsBankMoney(oPrice.dShouldBePrice) + "</td>";
                tbl += "<td style='border:solid 1px silver; text-align:right; color: red; font:bold'>" + stringRoutine.formatAsBankMoney((oPrice.dPrice - oPrice.dShouldBePrice)) + "</td>";
                tbl += "<td style='border:solid 1px silver'>" + oPrice.dtDateSubmitted.ToString("dd MMM, yyyy") + "</td>";
                tbl += "</tr>";
                i++;
            }
            
            tbl += "</table><br/>";

            sBody = sBody.Replace("@=DETAILS", tbl);
            
            AlternateView altView = CommonContent(sBody, httpHost);
            var oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eReviewers, sSubject, sBody, altView);
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