using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;

/// <summary>
/// Summary description for sendMail
/// </summary>

public class sendMailManHour
{
    private const string c_sMailSubjet = "Production Field Visit Activity Mail System: ";
    private const string c_sPECMailSubjet = "Business Initiative Mail System: ";
    private string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/p_ShellLogo.gif");

    private structUserMailIdx m_eSender;

    public sendMailManHour(structUserMailIdx _eSender)
    {
        m_eSender = _eSender;
    }

    public static structUserMailIdx eManager()
    {
        return new structUserMailIdx(AppConfiguration.adminName, AppConfiguration.adminEmail, "");
    }

    public bool UserDefinition(appUsers oAppUser)
    {
        bool bRet = false;
        string sSubject = "Defined to use Field Business Initiative";
        try
        {
            string sBody = Resources.Resource.newAppUserAcct;
            sBody = sBody.Replace("@=AAAA", oAppUser.m_sUserName);
            sBody = sBody.Replace("@=BBBB", oAppUser.m_sFullName);
            sBody = sBody.Replace("@=CCCC", oAppUser.m_sUserMail);
            sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());


            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");
            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(oAppUser.structUserIdx, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool ProfileNotFound(List<structUserMailIdx> receivers)
    {
        bool bRet = false;
        string sSubject = "Profile Not Found.";
        try
        {
            string sBody = Resources.Resource.UserAcctProfileNotFound;

            sBody = sBody.Replace("@=AAAA", Apps.LoginIDNoDomain(HttpContext.Current.User.Identity.Name));
            sBody = sBody.Replace("@=CCCC", HttpContext.Current.User.Identity.Name);
            sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");
            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(receivers, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool ApplicationErrorMessage(structUserMailIdx eTo, string errorMessage)
    {
        bool bRet = false;
        try
        {
            string sSubject, sBody;

            sSubject = "Man Hour Application Error:";
            sBody = "Dear System Admnistrator, <br/> <br/>";
            sBody += errorMessage;
            sBody += "<br/>";

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eTo, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool InitiatorRequestsForApproval(appUsers ActivitySponsor, List<structUserMailIdx> eReviewers, List<appUsers> allReviewers, long lInitiativeId)
    {
        string sBody = Resources.ResourceManHour.eMailTemplateInitiativeMgtFramWork;
        sBody = sBody.Replace("@=EMAIL", Resources.ResourceManHour.ForApproval);
        Initiative InitiativeDetails = Initiative.objGetInitiativeById(lInitiativeId);
        bool bRet = false;
        try
        {
            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString();
            //string BusInitiative = "http://" + httpHost + "/App/ManHour/Forms/Default.aspx?xMod=Viw&IntiativeId=" + lInitiativeId;
            string sSubject = InitiativeDetails.m_sTitle + " - " + c_sPECMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", appUsersHelper.objGetOnlineUserByUserId(InitiativeDetails.m_iUserId).m_sFullName);
            sBody = sBody.Replace("@=TITLE", InitiativeDetails.m_sTitle);
            sBody = sBody.Replace("@=BUSINESSCASE", InitiativeDetails.m_sBusinessCase);
            //sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            //sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

            AlternateView altView = CommonContent(sBody, ActivitySponsor.m_sFullName, allReviewers, lInitiativeId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(ActivitySponsor.structUserIdx, eReviewers, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;

    }

    public bool ActivitySponsorSendsMailToAssetManagers(appUsers ActivitySponsor, List<structUserMailIdx> eAssetManagers, List<appUsers> allAssetManagers, long lInitiativeId)
    {
        string sBody = Resources.ResourceManHour.eMailTemplateInitiativeMgtFramWork;
        sBody = sBody.Replace("@=EMAIL", Resources.ResourceManHour.ForApproval);
        Initiative InitiativeDetails = Initiative.objGetInitiativeById(lInitiativeId);

        appUsers oInitiator = appUsersHelper.objGetOnlineUserByUserId(InitiativeDetails.m_iUserId);
        bool bRet = false;

        try
        {
            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString();
            //string BusInitiative = "http://" + httpHost + "/App/ManHour/Forms/Default.aspx?xMod=Viw&IntiativeId=" + lInitiativeId;
            string sSubject = InitiativeDetails.m_sTitle + " - " + c_sPECMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", oInitiator.m_sFullName);
            sBody = sBody.Replace("@=TITLE", InitiativeDetails.m_sTitle);
            sBody = sBody.Replace("@=BUSINESSCASE", InitiativeDetails.m_sBusinessCase);

            AlternateView altView = CommonContent(sBody, ActivitySponsor.m_sFullName, allAssetManagers, lInitiativeId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eAssetManagers, oInitiator.structUserIdx, sSubject, sBody, altView);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    //Asset Manager sends mail to Initiator and copy Activity sponsor
    public bool requestApproved(structUserMailIdx eInitiator, structUserMailIdx eUsers, long lInitiativeId, long lApprovalId, int iUserId)
    {
        Initiative InitiativeDetails = Initiative.objGetInitiativeById(lInitiativeId);

        InitiativeApproval oApproval = new InitiativeApproval();
        InitiativeApproval myApprovalDetails = oApproval.objGetBIApproverByApprovalId(lApprovalId);

        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestApproved;
            string sSubject = InitiativeDetails.m_sTitle + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=APPROVER", appUsersHelper.objGetOnlineUserByUserId(InitiativeDetails.m_iUserId).m_sFullName);
            //sBody = sBody.Replace("@=FIELD", District.objGetDistrictById(InitiativeDetails.m_iFacilityId).m_sDistrict);
            sBody = sBody.Replace("@=TASK", InitiativeDetails.m_sBusinessCase);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eInitiator, eUsers, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }


    //Activity sponsor sends mail to Initiator with the detailed comment why not approved.
    public bool requestNotApproved(structUserMailIdx eInitiator, long lInitiativeId, long lApprovalId, string Comment, appUsers Approver)
    {
        Initiative InitiativeDetails = Initiative.objGetInitiativeById(lInitiativeId);

        string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString();
        string BusInitiative = "http://" + httpHost + "/App/ManHour/Forms/Default.aspx?xMod=Viw&IntiativeId=" + lInitiativeId;

        InitiativeApproval oApproval = new InitiativeApproval();
        InitiativeApproval myApprovalDetails = oApproval.objGetBIApproverByApprovalId(lApprovalId);

        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestNotApproved;
            string sSubject = InitiativeDetails.m_sTitle + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdManHr));
            sBody = sBody.Replace("@=STAND", getMyStand(myApprovalDetails));
            sBody = sBody.Replace("@=REASON", oApproval.objGetBIApproverByApprovalId(lApprovalId).m_sComment);
            //sBody = sBody.Replace("@=FIELD", District.objGetDistrictById(InitiativeDetails.m_iFacilityId).m_sDistrict);
            sBody = sBody.Replace("@=TASK", InitiativeDetails.m_sBusinessCase);
            sBody = sBody.Replace("@=EEEE", BusInitiative);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eInitiator, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    //Asset Manager sends mail to Initiator and copy Activity Sponsor with the detailed comment why not approved.
    public bool requestNotApproved(structUserMailIdx eInitiator, structUserMailIdx eSponsor, long lInitiativeId, long lApprovalId, string Comment, appUsers Approver)
    {
        Initiative InitiativeDetails = Initiative.objGetInitiativeById(lInitiativeId);

        string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString();
        string BusInitiative = "http://" + httpHost + "/App/ManHour/Forms/Default.aspx?xMod=Viw&IntiativeId=" + lInitiativeId;

        InitiativeApproval oApproval = new InitiativeApproval();
        InitiativeApproval myApprovalDetails = oApproval.objGetBIApproverByApprovalId(lApprovalId);

        bool bRet = false;
        try
        {
             string sBody = Resources.Resource.requestNotApproved;
            string sSubject = InitiativeDetails.m_sTitle + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdManHr));
            sBody = sBody.Replace("@=STAND", getMyStand(myApprovalDetails));
            sBody = sBody.Replace("@=REASON", oApproval.objGetBIApproverByApprovalId(lApprovalId).m_sComment);
            //sBody = sBody.Replace("@=FIELD", District.objGetDistrictById(InitiativeDetails.m_iFacilityId).m_sDistrict);
            sBody = sBody.Replace("@=TASK", InitiativeDetails.m_sBusinessCase);
            sBody = sBody.Replace("@=EEEE", BusInitiative);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eInitiator, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    private string getMyStand(InitiativeApproval myApprovalDetails)
    {
        string myStand = "";
        if (myApprovalDetails.m_iStand == (int)Approval.apprStatusRpt.Callme)
        {
            myStand = Approval.StatusRptDesc(Approval.apprStatusRpt.Callme);
        }
        else if (myApprovalDetails.m_iStand == (int)Approval.apprStatusRpt.NotApproved)
        {
            myStand = Approval.StatusRptDesc(Approval.apprStatusRpt.NotApproved);
        }
        else if (myApprovalDetails.m_iStand == (int)Approval.apprStatusRpt.Reschedule)
        {
            myStand = Approval.StatusRptDesc(Approval.apprStatusRpt.Reschedule);
        }

        return myStand;
    }


    private AlternateView CommonContent(string mBody, string sActivitySponsor, List<appUsers> allReviewers, long lInitiativeId)
    {
        string assetOpsMgrs = ""; string sFunctionalLeads = "";
        foreach (appUsers reviewers in allReviewers)
        {
            if (reviewers.m_iRoleIdManHr == (int)appUsersRoles.userRole.AssetOperationsManager)
            {
                assetOpsMgrs += reviewers.m_sFullName + "; ";
            }
            else if (reviewers.m_iRoleIdManHr == (int)appUsersRoles.userRole.FunctionalLead)
            {
                sFunctionalLeads += reviewers.m_sFullName + "; ";
            }
        }

        mBody = mBody.Replace("@=ACTIVITYSPONSOR", sActivitySponsor);
        mBody = mBody.Replace("@=ASSETOPMGRS", assetOpsMgrs);
        mBody = mBody.Replace("@=FUNCLEADS", sFunctionalLeads);
        mBody = mBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/Default.aspx?xMod=Viw&IntiativeId=" + lInitiativeId);
        mBody = mBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

        mBody = mBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
        mBody = mBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

        AlternateView altView = AlternateView.CreateAlternateViewFromString(mBody, null, MediaTypeNames.Text.Html);
        LinkedResource pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
        pic.ContentId = "Logo";
        altView.LinkedResources.Add(pic);

        return altView;
    }
}