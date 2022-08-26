using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

/// <summary>
/// Summary description for sendMail
/// </summary>

public class sendMailBI500
{
    private const string c_sMailSubjet = " - Bright Ideas";
    private string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/ShellLogo.png");
    private structUserMailIdx m_eSender;
    FunctionMgt oFunctionMgt = new FunctionMgt();

    bool bRet = false;
    appUsersHelper oappUsersHelper = new appUsersHelper();

    public sendMailBI500(structUserMailIdx _eSender)
    {
        m_eSender = _eSender;
    }

    public static structUserMailIdx eManager()
    {
        return new structUserMailIdx(AppConfiguration.adminName, AppConfiguration.adminEmail, "");
    }

    #region ============================  Bright Ideas Emails =========================================

    public bool ForwardRequestForSupportApproval(CostReductionRequest oBI500Request, List<structUserMailIdx> oReceivers, List<structUserMailIdx> cCopy)
    {
        string mSubject = oBI500Request.sRequestNumber + " - Bright Idea pending your action.";
        string mBody = Resources.ResourceBI500.eMailTemplateBI500;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ForSupportApproval);

        mBody = mBody.Replace("@=TITLE", oBI500Request.sTitle);
        mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        mBody = mBody.Replace("@=BUZCASE", oBI500Request.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);

        AlternateView altView = CommonContent(mBody, oBI500Request);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceivers, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool ForwardRequestForSupportApproval(CostReductionRequest oBI500Request, List<structUserMailIdx> oReceivers, structUserMailIdx cCopy)
    {
        string mSubject = oBI500Request.sRequestNumber + " - Bright Idea Request pending your action.";
        string mBody = Resources.ResourceBI500.eMailTemplateBI500;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ForSupportApproval);

        mBody = mBody.Replace("@=TITLE", oBI500Request.sTitle);
        mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        mBody = mBody.Replace("@=BUZCASE", oBI500Request.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);

        AlternateView altView = CommonContent(mBody, oBI500Request);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceivers, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool RequestNotSupportedApproved(CostReductionRequest oBI500Request, appUsers oOnlineUser, string sReason, List<structUserMailIdx> cCopy)
    {
        string mSubject = oBI500Request.sRequestNumber + " - Bright Idea Approved.";
        string mBody = Resources.ResourceBI500.eMailTemplateBI500;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ForNotSupportedApproved);
        mBody = mBody.Replace("@=APPROVER", oOnlineUser.m_sFullName);
        mBody = mBody.Replace("@=TITLE", oBI500Request.sTitle);
        mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        mBody = mBody.Replace("@=BUZCASE", oBI500Request.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);

        mBody = mBody.Replace("@=XREASON", sReason);

        AlternateView altView = CommonContent(mBody, oBI500Request);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).structUserIdx, cCopy, mSubject, mBody, altView);

        return bRet;




        //appUsers oInitiator = oappUsersHelper.objGetUserByUserID(oFlareWaiver.m_iUserId);
        //string sActionRequired = "supported";
        //if (oOnlineUser.m_iRoleId == (int)UserRoles.userRole.GMProduction) sActionRequired = "approved";

        //string mSubject = oFlareWaiver.m_sRequestNumber + " - Flare Waiver Request Not " + sActionRequired + ".";
        //string mBody = Resources.FlareWaiver.eMailTemplate;
        //mBody = mBody.Replace("@=EMAIL", Resources.FlareWaiver.ForNotSupportedApproved);

        //mBody = mBody.Replace("@=CATEGORY", Category.objGetCategoryByCatId(oFlareWaiver.m_iCategoryId).m_sCategory);
        //mBody = mBody.Replace("@=FACILITY", facility.objGetFacilityById(oFlareWaiver.m_iFacilityId).m_sFacility);

        //mBody = mBody.Replace("@=ACTION", sActionRequired);
        //mBody = mBody.Replace("@=INITIATOR", oInitiator.m_sFullName);
        //mBody = mBody.Replace("@=SUPPORTAPPROVAL", oOnlineUser.m_sFullName);
        //mBody = mBody.Replace("@=ACTIONED", sActionRequired);

        


        //mBody = mBody.Replace("@=VOLUME", oFlareWaiver.m_sFlareVol.ToString());
        //mBody = mBody.Replace("@=OIL", oFlareWaiver.m_sOilProduced.ToString());

        //mBody = mBody.Replace("@=SDATE", oFlareWaiver.m_sStartDate);
        //mBody = mBody.Replace("@=STIME", oFlareWaiver.m_sStartTime);
        //mBody = mBody.Replace("@=EDATE", oFlareWaiver.m_sEndDate);
        //mBody = mBody.Replace("@=ETIME", oFlareWaiver.m_sEndTime);
        //mBody = mBody.Replace("@=REASON", oFlareWaiver.m_sReason);
        //mBody = mBody.Replace("@=JUSTIFICATION", oFlareWaiver.m_sJustification);

        //mBody = mBody.Replace("@=POSTEVENT", oFlareWaiver.m_sPostEvent);

        //AlternateView altView = CommonContent(mBody);
        //emailClientExPic oMail = new emailClientExPic(m_eSender);
        //bRet = oMail.sendShellMail(oInitiator.structUserIdx, cCopy, mSubject, mBody, altView);

        //return bRet;
    }

    public bool RequestApproved(CostReductionRequest oBI500Request, appUsers oOnlineUser, List<structUserMailIdx> cCopy)
    {
        string mSubject = oBI500Request.sRequestNumber + " - Bright Idea Approved.";
        string mBody = Resources.ResourceBI500.eMailTemplateBI500;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ForApproved);
        mBody = mBody.Replace("@=APPROVER", oOnlineUser.m_sFullName);
        mBody = mBody.Replace("@=TITLE", oBI500Request.sTitle);
        mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        mBody = mBody.Replace("@=BUZCASE", oBI500Request.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);

        AlternateView altView = CommonContent(mBody, oBI500Request);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).structUserIdx, cCopy, mSubject, mBody, altView);

        return bRet;
    }
    public bool RequestSupported(CostReductionRequest oBI500Request, appUsers oOnlineUser, List<structUserMailIdx> cCopy)
    {
        string mSubject = oBI500Request.sRequestNumber + " - Bright Idea Supported.";
        string mBody = Resources.ResourceBI500.eMailTemplateBI500;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ForSupported);
        mBody = mBody.Replace("@=APPROVER", oOnlineUser.m_sFullName);
        mBody = mBody.Replace("@=TITLE", oBI500Request.sTitle);
        mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        mBody = mBody.Replace("@=BUZCASE", oBI500Request.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);

        AlternateView altView = CommonContent(mBody, oBI500Request);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).structUserIdx, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool BIPhaseUpdated(CostReductionRequest oBI500Request, appUsers oOnlineUser, List<structUserMailIdx> cCopy)
    {
        string mSubject = oBI500Request.sRequestNumber + " - Bright Idea Phase Updated.";
        string mBody = Resources.ResourceBI500.eMailTemplateBI500;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.BIPhaseUpdate);
        
        System.Web.UI.WebControls.LinkButton lnkPhase = new System.Web.UI.WebControls.LinkButton();
        lnkPhase.Text = oBI500Request.iPhase.ToString();
        BIRequestStatus.reportBrightIdeaPhase(lnkPhase);

        mBody = mBody.Replace("@=PHASE", lnkPhase.Text);
        mBody = mBody.Replace("@=TITLE", oBI500Request.sTitle);
        mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        mBody = mBody.Replace("@=BUZCASE", oBI500Request.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);

        AlternateView altView = CommonContent(mBody, oBI500Request);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).structUserIdx, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool PendingRequestReminder(CostReductionRequest oBI500Request, appUsers oNextSupportApprover, structUserMailIdx cCopy)
    {
        string mSubject = oBI500Request.sRequestNumber + " - Pending Bright Idea Review Reminder.";
        string mBody = Resources.ResourceBI500.eMailTemplateBI500;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ForSupportApproval);

        mBody = mBody.Replace("@=TITLE", oBI500Request.sTitle);
        mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        mBody = mBody.Replace("@=BUZCASE", oBI500Request.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);

        AlternateView altView = CommonContent(mBody, oBI500Request);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oNextSupportApprover.structUserIdx, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool ApplicationErrorMessage(List<structUserMailIdx> toEmail, string errorMessage)
    {
        string mBody;
        string mSubject = AppConfiguration.siteName + " Error Message:";
        mBody = "Dear System Administrator, <br/> <br/>";
        mBody += errorMessage;
        mBody += "<br/>";

        emailClient oMail = new emailClient(m_eSender);
        bRet = oMail.sendShellMail(toEmail, mSubject, mBody);

        return bRet;
    }

    private AlternateView CommonContent(string mBody, CostReductionRequest oBI500Request)
    {
        mBody = mBody.Replace("@=PROJCHAMPION", oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectChampionUserId).m_sFullName);
        mBody = mBody.Replace("@=PROJMGRS", oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);
        mBody = mBody.Replace("@=SPONSOR", oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectSponsorUserId).m_sFullName);
        mBody = mBody.Replace("@=FOCALPOINT", oappUsersHelper.objGetUserByUserID(oBI500Request.iFocalPointUserId).m_sFullName);

        //TODO: This should take the user to the application directly, instead of expecting the user to click the icon
        mBody = mBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/Default.aspx?BI=" + (int)AppTokens.appTokens.BI500 + "&RequestId=" + oBI500Request.lRequestId);  //AppConfiguration.siteHostName
        mBody = mBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

        mBody = mBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
        mBody = mBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

        AlternateView altView = AlternateView.CreateAlternateViewFromString(mBody, null, MediaTypeNames.Text.Html);
        LinkedResource pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
        pic.ContentId = "Logo";
        altView.LinkedResources.Add(pic);

        return altView;
    }

    #endregion




    #region Improvement Ideas Mails

    public bool ForwardImprovementIdeaForSupportApproval(CostReductionRequest o, List<structUserMailIdx> oReceivers, structUserMailIdx cCopy)
    {
        string mSubject = o.sRequestNumber + " - Improvement Idea pending your action.";
        string mBody = Resources.ResourceBI500.eMailTemplateImprovementIdeas;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ImprovementIdeaSupportApproval);

        mBody = mBody.Replace("@=TITLE", o.sTitle);
        BITeams oT = new BITeams();

        mBody = mBody.Replace("@=BIZUNIT", oT.objGetTeamById(o.iTeamId).m_sTeam);
        mBody = mBody.Replace("@=BUZCASE", o.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);

        AlternateView altView = CommonContentCostReduction(mBody, o);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceivers, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool ForwardImprovementIdeaForSupportApproval(CostReductionRequest o, List<structUserMailIdx> oReceivers, List<structUserMailIdx> cCopy)
    {
        string mSubject = o.sRequestNumber + " - Improvement Idea pending your action.";
        string mBody = Resources.ResourceBI500.eMailTemplateImprovementIdeas;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ImprovementIdeaSupportApproval);

        mBody = mBody.Replace("@=TITLE", o.sTitle);
        BITeams oT = new BITeams();

        mBody = mBody.Replace("@=BIZUNIT", oT.objGetTeamById(o.iTeamId).m_sTeam);
        mBody = mBody.Replace("@=BUZCASE", o.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);

        AlternateView altView = CommonContentCostReduction(mBody, o);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceivers, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool MaintainedInDatabase(CostReductionRequest o, List<structUserMailIdx> oReceivers, List<structUserMailIdx> cCopy)
    {
        string mSubject = o.sRequestNumber + " - Improvement Idea maintained in database.";
        string mBody = Resources.ResourceBI500.eMailTemplateImprovementIdeas;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.MaintainedInDatabase);

        mBody = mBody.Replace("@=TITLE", o.sTitle);
        BITeams oT = new BITeams();

        mBody = mBody.Replace("@=BIZUNIT", oT.objGetTeamById(o.iTeamId).m_sTeam);
        mBody = mBody.Replace("@=BUZCASE", o.sBusinessCase);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);
        mBody = mBody.Replace("@=REASON", o.sRetained);

        AlternateView altView = CommonContentCostReduction(mBody, o);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceivers, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool SlippageReminder(CostReductionRequest o, structUserMailIdx oReceiver, List<structUserMailIdx> cCopy, DateTime dDateSubmittedReceived, string Status)
    {
        string mSubject = "Reminder!!! " + o.sRequestNumber + " - Improvement Idea pending your action.";
        string mBody = Resources.ResourceBI500.eMailTemplateImprovementIdeas;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.SlippageReminder);

        mBody = mBody.Replace("@=TITLE", o.sTitle);
        BITeams oT = new BITeams();

        int total_days = (DateTime.Now.Date - dDateSubmittedReceived).Days;

        int iNoOfDays = DateTime.Compare(DateTime.Now.Date, dDateSubmittedReceived);

        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);

        mBody = mBody.Replace("@=DATERECEIVED", dDateSubmittedReceived.ToString("dd/MMM/yyyy"));
        mBody = mBody.Replace("@=NOOFDAYS", total_days.ToString());

        mBody = mBody.Replace("@=STATUS", Status);

        mBody = mBody.Replace("@=BIZUNIT", oT.objGetTeamById(o.iTeamId).m_sTeam);
        mBody = mBody.Replace("@=BUZCASE", o.sBusinessCase);
        //mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);

        AlternateView altView = CommonContentCostReduction(mBody, o);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceiver, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool SlippageReminder(CostReductionRequest o, structUserMailIdx oReceiver, DateTime dDateSubmittedReceived, string Status)
    {
        string mSubject = "Reminder!!! " + o.sRequestNumber + " - Improvement Idea pending your action.";
        string mBody = Resources.ResourceBI500.eMailTemplateImprovementIdeas;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.SlippageReminder);

        mBody = mBody.Replace("@=TITLE", o.sTitle);
        BITeams oT = new BITeams();

        int total_days = (DateTime.Now.Date - dDateSubmittedReceived).Days;

        int iNoOfDays = DateTime.Compare(DateTime.Now.Date, dDateSubmittedReceived);

        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);

        mBody = mBody.Replace("@=DATERECEIVED", dDateSubmittedReceived.ToString("dd/MMM/yyyy"));
        mBody = mBody.Replace("@=NOOFDAYS", total_days.ToString());

        mBody = mBody.Replace("@=STATUS", Status);

        mBody = mBody.Replace("@=BIZUNIT", oT.objGetTeamById(o.iTeamId).m_sTeam);
        mBody = mBody.Replace("@=BUZCASE", o.sBusinessCase);
        //mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);

        AlternateView altView = CommonContentCostReduction(mBody, o);
        emailClientExPic oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceiver, mSubject, mBody, altView);

        return bRet;
    }


    private AlternateView CommonContentCostReduction(string mBody, CostReductionRequest o)
    {
        BI500RequestHelper oBIReq = new BI500RequestHelper();

        mBody = mBody.Replace("@=BIREVIEWER", oBIReq.BIReviewers());
        mBody = mBody.Replace("@=PROJMGRS", oappUsersHelper.objGetUserByUserID(o.iUserId).m_sFullName);
        mBody = mBody.Replace("@=FOCALPOINT", oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId).m_sFullName);
        mBody = mBody.Replace("@=PROJCHAMPION", oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId).m_sFullName);
        mBody = mBody.Replace("@=SPONSOR", oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId).m_sFullName);

        //TODO: This should take the user to the application directly, instead of expecting the user to click the icon
        mBody = mBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/Default.aspx?CR=" + (int)AppTokens.appTokens.BI500 + "&RequestId=" + o.lRequestId);  //AppConfiguration.siteHostName
        mBody = mBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

        mBody = mBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
        mBody = mBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

        AlternateView altView = AlternateView.CreateAlternateViewFromString(mBody, null, MediaTypeNames.Text.Html);
        LinkedResource pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
        pic.ContentId = "Logo";
        altView.LinkedResources.Add(pic);

        return altView;
    }

    #endregion


}