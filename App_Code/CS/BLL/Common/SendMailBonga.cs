using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

/// <summary>
/// Summary description for SendMailBonga
/// </summary>

public class SendMailBonga
{
    private const string c_sMailSubjet = " - Bonga Commitment Control";
    private readonly string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/ShellLogo.png");
    private readonly structUserMailIdx m_eSender;
    readonly FunctionMgt oFunctionMgt = new FunctionMgt();

    bool bRet = false;
    readonly appUsersHelper oappUsersHelper = new appUsersHelper();

    public SendMailBonga(structUserMailIdx _eSender)
    {
        m_eSender = _eSender;
    }

    public static structUserMailIdx eManager()
    {
        return new structUserMailIdx(AppConfiguration.adminName, AppConfiguration.adminEmail, "");
    }

    public bool ForwardCommitmentToSponsor(Commitments o, structUserMailIdx oReceiver, List<structUserMailIdx> cCopy)
    {
        string mSubject = o.COMITMNTNO + " - Bonga Commitment.";
        string mBody = Resources.ResourceBonga.eMailTemplate;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBonga.CommitmentSubmitted);

        mBody = mBody.Replace("@=TITLE", o.TITLE);
        mBody = mBody.Replace("@=BUZCASE", o.JUSTIFICATION);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.INITIATORID).m_sFullName);

        AlternateView altView = CommonContent(mBody, o);
        var oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oReceiver, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    public bool RequestReviewed(Commitments o, appUsers oOnlineUser, List<structUserMailIdx> cCopy, string decision, string sDecisionComments)
    {
        string mSubject = o.COMITMNTNO + " - Bonga Commitment Reviewed.";
        string mBody = Resources.ResourceBonga.eMailTemplate;
        mBody = mBody.Replace("@=EMAIL", Resources.ResourceBonga.ForApproved);

        mBody = mBody.Replace("@=APPROVER", oOnlineUser.m_sFullName);
        mBody = mBody.Replace("@=TITLE", o.TITLE);
        mBody = mBody.Replace("@=BUZCASE", o.JUSTIFICATION);
        mBody = mBody.Replace("@=DECISION", decision);
        mBody = mBody.Replace("@=DECISIONCOMMENT", sDecisionComments);
        mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.INITIATORID).m_sFullName);

        AlternateView altView = CommonContent(mBody, o);
        var oMail = new emailClientExPic(m_eSender);
        bRet = oMail.sendShellMail(oappUsersHelper.objGetUserByUserID(o.INITIATORID).structUserIdx, cCopy, mSubject, mBody, altView);

        return bRet;
    }

    //public bool PendingCommitmentReminder(Commitments o, appUsers oNextSupportApprover, structUserMailIdx cCopy)
    //{
    //    string mSubject = o.m_sCommitmentNumber + " - Bonga Commitment Reminder.";
    //    string mBody = Resources.ResourceBI500.eMailTemplateBI500;
    //    mBody = mBody.Replace("@=EMAIL", Resources.ResourceBI500.ForSupportApproval);

    //    mBody = mBody.Replace("@=TITLE", o.m_sTitle);
    //    mBody = mBody.Replace("@=BIZUNIT", oFunctionMgt.objGetFunctionById(o.iFunctionId).m_sFunction);
    //    mBody = mBody.Replace("@=BUZCASE", o.sBusinessCase);
    //    mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(o.m_iInitiatorId).m_sFullName);

    //    AlternateView altView = CommonContent(mBody, o);
    //    emailClientExPic oMail = new emailClientExPic(m_eSender);
    //    bRet = oMail.sendShellMail(oNextSupportApprover.structUserIdx, cCopy, mSubject, mBody, altView);

    //    return bRet;
    //}

    public bool ApplicationErrorMessage(List<structUserMailIdx> toEmail, string errorMessage)
    {
        string mBody;
        string mSubject = AppConfiguration.siteName + " Error Message:";
        mBody = "Dear System Administrator, <br/> <br/>";
        mBody += errorMessage;
        mBody += "<br/>";

        var oMail = new emailClient(m_eSender);
        bRet = oMail.sendShellMail(toEmail, mSubject, mBody);

        return bRet;
    }

    private AlternateView CommonContent(string mBody, Commitments o)
    {
        mBody = mBody.Replace("@=APPROVER", o.eApprover.m_sFullName);
        mBody = mBody.Replace("@=CHECKEDBY", o.eCheckedBy.m_sFullName);
        mBody = mBody.Replace("@=REQUESTOR", o.eRequestor.m_sFullName);
        mBody = mBody.Replace("@=SPONSOR", o.eSponsor.m_sFullName);
        mBody = mBody.Replace("@=FOCALPOINT", o.eFocalPoint.m_sFullName);

        //TODO: This should take the user to the application directly, instead of expecting the user to click the icon
        mBody = mBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/App/BONGACCP/Commitments.aspx");
        mBody = mBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

        mBody = mBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
        mBody = mBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

        AlternateView altView = AlternateView.CreateAlternateViewFromString(mBody, contentEncoding: null, mediaType: MediaTypeNames.Text.Html);
        var pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
        pic.ContentId = "Logo";
        altView.LinkedResources.Add(pic);

        return altView;
    }
}