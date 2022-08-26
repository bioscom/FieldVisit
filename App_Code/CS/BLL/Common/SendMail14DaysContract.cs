using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;

/// <summary>
/// Summary description for SendMail14DaysContract
/// </summary>
public class SendMail14DaysContract
{
    private const string c_sMailSubjet = "Operations Superintendent 14 Days Contract: ";
    private const string c_sPECMailSubjet = "Competitiveness and Business Improvement: ";
    private string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/p_ShellLogo.gif");

    private structUserMailIdx m_eSender;

    public SendMail14DaysContract(structUserMailIdx _eSender)
    {
        m_eSender = _eSender;
    }

    public static structUserMailIdx eManager()
    {
        return new structUserMailIdx(AppConfiguration.adminName, AppConfiguration.adminEmail, "");
    }

    public bool SuperintendentRequestsForApproval(appUsers superintendent, string sDistrict, string sStartDate, string sEndDate, List<structUserMailIdx> eReviewers)
    {
        string sBody = Resources.Resource14DaysContract.ForteenDaysRequest4Approval;
        bool bRet = false;
        try
        {
            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString();
            string sSubject = "@=DISTRICT" + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=SUPERINTENDENT", superintendent.m_sFullName);
            sBody = sBody.Replace("@=DISTRICT", sDistrict);

            sBody = sBody.Replace("@=STARTDATE", sStartDate);
            sBody = sBody.Replace("@=ENDDATE", sEndDate);
            sBody = sBody.Replace("@=EEEE", httpHost);
            sBody = sBody.Replace("@=TTTT", DateTime.Today.ToLongDateString());

            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

            //AlternateView altView = CommonContent(sBody, Superintendent.m_sFullName, allReviewers, lInitiativeId);
            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eReviewers, superintendent.structUserIdx, sSubject, sBody);

            return bRet;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    //Asset Manager sends mail to Initiator and copy Activity sponsor
    public bool RequestApproved(appUsers superintendent, string sDistrict, string sStartDate, string sEndDate, List<structUserMailIdx> eReviewers)
    {
        string sBody = Resources.Resource14DaysContract.ForteenDaysApproved;
        bool bRet = false;
        try
        {
            string httpHost = HttpContext.Current.Request.ServerVariables["http_host"].ToString();
            string sSubject = "@=DISTRICT" + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=SUPERINTENDENT", superintendent.m_sFullName);
            sBody = sBody.Replace("@=DISTRICT", sDistrict);

            sBody = sBody.Replace("@=STARTDATE", sStartDate);
            sBody = sBody.Replace("@=ENDDATE", sEndDate);
            sBody = sBody.Replace("@=EEEE", httpHost);
            sBody = sBody.Replace("@=TTTT", DateTime.Today.ToLongDateString());

            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

            //AlternateView altView = CommonContent(sBody, Superintendent.m_sFullName, allReviewers, lInitiativeId);
            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eReviewers, superintendent.structUserIdx, sSubject, sBody);

            return bRet;
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

    //Asset Manager sends mail to Initiator and copy Activity Sponsor with the detailed comment why not approved.

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