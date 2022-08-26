using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;

/// <summary>
/// Summary description for sendMail
/// </summary>

public class sendMailFieldVisit
{
    private const string c_sMailSubjet = "Production Field Visit Activity Mail System: ";
    private const string c_sPECMailSubjet = "Planned Execution Criteria Mail System: ";
    private string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/p_ShellLogo.gif");

    private structUserMailIdx m_eSender;
    public sendMailFieldVisit(structUserMailIdx _eSender)
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
        string sSubject = "Production Business Improvement Portal";
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
    public bool UserPasswordReset(structUserMailIdx eUserDefined, appUsers me)
    {
        bool bRet = false;
        string sSubject = "Account Password reset.";
        try
        {
            string sBody = Resources.Resource.PasswordReset;
            sBody = sBody.Replace("@=AAAA", eUserDefined.m_sUserName);
            sBody = sBody.Replace("@=BBBB", me.m_sFullName);
            sBody = sBody.Replace("@=CCCC", eUserDefined.m_sUserMail);
            sBody = sBody.Replace("@PPPP", me.m_sPassword);
            sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/LPswReset.aspx");
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");
            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eUserDefined, sSubject, sBody);
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

    public bool cleanUpReport(structUserMailIdx eSender)
    {
        bool bRet = false;
        try
        {
            string mBody = Resources.Resource.UserTableCleaUp;
            string mSubject = "User database cleanup Report.";

            //mBody = mBody.Replace("@@URL", ApplicationURL.MyAppURL());
            mBody = mBody.Replace("@@=BODY", mBody);
            //mBody = SystemAdmin(mBody);

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eSender, mSubject, mBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    #region Field Visit Emails
    public bool initiatorSendsMailToActivitySponsor(structUserMailIdx eSponsor, long iActivityId)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(myDetails.m_iFacilityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility + " => " + field.eDistrict.m_sDistrict + " => " + field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eSponsor, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool initiatorSendsMailToFacilityPlanner(structUserMailIdx ePlanner, long iActivityId, bool bReminder)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(myDetails.m_iFacilityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility);
            sBody = sBody.Replace("@=DISTRICT", field.eDistrict.m_sDistrict);
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            if (bReminder) sBody = sBody.Replace("@=REMINDER", "Field Visit Approval Reminder!");
            else sBody = sBody.Replace("@=REMINDER", "");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(ePlanner, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool ReminderMail(structUserMailIdx ePlanner, long iActivityId, bool bReminder)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(myDetails.m_iFacilityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet + " Field Visit Approval Reminder!";
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility);
            sBody = sBody.Replace("@=DISTRICT", field.eDistrict.m_sDistrict);
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            if (bReminder) sBody = sBody.Replace("@=REMINDER", "Field Visit Approval Reminder!");
            else sBody = sBody.Replace("@=REMINDER", "");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(ePlanner, myDetails.eInitiator.structUserIdx, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    //Activity sponsor sends mail to superintendent that he has a request to approve
    public bool SendsMailToNextApprover(List<structUserMailIdx> eNextApprover, structUserMailIdx eIntiator, long iActivityId, bool bReminder)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(myDetails.m_iFacilityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility);
            sBody = sBody.Replace("@=DISTRICT", field.eDistrict.m_sDistrict);
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent); 
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            if (bReminder) sBody = sBody.Replace("@=REMINDER", "Field Visit Approval Reminder!");
            else sBody = sBody.Replace("@=REMINDER", "");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eNextApprover, eIntiator, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool SendsMailToNextApprover(structUserMailIdx eNextApprover, structUserMailIdx eIntiator, long iActivityId, bool bReminder)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(myDetails.m_iFacilityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility);
            sBody = sBody.Replace("@=DISTRICT", field.eDistrict.m_sDistrict);
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent); 
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            if (bReminder) sBody = sBody.Replace("@=REMINDER", "Field Visit Approval Reminder!");
            else sBody = sBody.Replace("@=REMINDER", "");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eNextApprover, eIntiator, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool SendsMailToNextApprover(structUserMailIdx eNextApprover, List<structUserMailIdx> eCopy, long iActivityId, bool bReminder)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(myDetails.m_iFacilityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility);
            sBody = sBody.Replace("@=DISTRICT", field.eDistrict.m_sDistrict);
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent); 
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            if (bReminder) sBody = sBody.Replace("@=REMINDER", "Field Visit Approval Reminder!");
            else sBody = sBody.Replace("@=REMINDER", "");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eNextApprover, eCopy, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    //Activity sponsor sends mail to Initiator with the detailed comment why not approved.
    public bool requestNotApproved(structUserMailIdx eInitiator, long iActivityId, long iApprovalId, string Comment, appUsers Approver)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        siteVisitApproval myApprovalDetails = siteVisitApproval.objGetFieldVisitApprovalByApprovalId(iApprovalId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestNotApproved;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdFieldVisit));
            sBody = sBody.Replace("@=STAND", getMyStand(myApprovalDetails));
            sBody = sBody.Replace("@=REASON", myApprovalDetails.m_sComment);
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
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
    //Facility Planner sends mail to Initiator and copy Activity Sponsor with the detailed comment why not approved.
    public bool requestNotApproved(structUserMailIdx eInitiator, structUserMailIdx eSponsor, long iActivityId, long iApprovalId, string Comment, appUsers Approver)
    {
        siteVisitApproval myApprovalDetails = siteVisitApproval.objGetFieldVisitApprovalByApprovalId(iApprovalId);
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestNotApproved;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdFieldVisit));
            sBody = sBody.Replace("@=STAND", getMyStand(myApprovalDetails));
            sBody = sBody.Replace("@=REASON", myApprovalDetails.m_sComment);
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
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
    //Superintendent sends mail to Initiator and copy Planner, Sponsor and other superintendents with the detailed comment why not approved.
    public bool requestNotApproved(structUserMailIdx eInitiator, List<structUserMailIdx> eUsers, long iActivityId, long iApprovalId, string Comment, appUsers Approver)
    {
        fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        siteVisitApproval myApprovalDetails = siteVisitApproval.objGetFieldVisitApprovalByApprovalId(iApprovalId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestNotApproved;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdFieldVisit));
            sBody = sBody.Replace("@=STAND", getMyStand(myApprovalDetails));
            sBody = sBody.Replace("@=REASON", myApprovalDetails.m_sComment);
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sTaskDescription);
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
    //Activity sponsor/Superintendent sends mail to Initiator and copy Planner 
    //Superintendent sends mail to Initiator, copy Planner and Activity sponsor
    public bool requestApproved(structUserMailIdx eInitiator, List<structUserMailIdx> eUsers, long iActivityId, int iUserId)
    {
        siteVisitApproval myDetails = siteVisitApproval.objGetApprovedFieldVisitDetailsBySuperintendentApprover(iActivityId, (int)appUsersRoles.userRole.superintendent);
        appUsers ApproverSuperIntendent = appUsersHelper.objGetUserByUserId(iUserId);

        fieldVisitDetails activity = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(myDetails.m_iActivityID);
        //fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(activity.m_iFacilityId);
        bool bRet = false;
        try
        {

            string sBody = Resources.Resource.requestApproved;
            string sSubject = activity.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=APPROVER", ApproverSuperIntendent.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility + " => " + field.eDistrict.m_sDistrict + " => " + field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", activity.m_sTaskDescription);
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
    public bool requestApproved(structUserMailIdx eInitiator, structUserMailIdx eUsers, long iActivityId, int iUserId)
    {
        siteVisitApproval myDetails = siteVisitApproval.objGetApprovedFieldVisitDetailsBySuperintendentApprover(iActivityId, (int)appUsersRoles.userRole.superintendent);
        appUsers ApproverSuperIntendent = appUsersHelper.objGetUserByUserId(iUserId);

        fieldVisitDetails activity = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(myDetails.m_iActivityID);
        //fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);
        facility field = facility.objGetFacilityById(activity.m_iFacilityId);
        bool bRet = false;
        try
        {

            string sBody = Resources.Resource.requestApproved;
            string sSubject = activity.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=APPROVER", ApproverSuperIntendent.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility + " => " + field.eDistrict.m_sDistrict + " => " + field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", activity.m_sTaskDescription);
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
    private string getMyStand(siteVisitApproval myApprovalDetails)
    {
        string myStand = "";
        if (myApprovalDetails.m_iStand == (int)siteVisitApprovalStatus.apprStatusRpt.Callme)
        {
            myStand = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.Callme);
        }
        else if (myApprovalDetails.m_iStand == (int)siteVisitApprovalStatus.apprStatusRpt.NotApproved)
        {
            myStand = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.NotApproved);
        }
        else if (myApprovalDetails.m_iStand == (int)siteVisitApprovalStatus.apprStatusRpt.Reschedule)
        {
            myStand = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.Reschedule);
        }

        return myStand;
    }

    

    #endregion

    #region The region for the PEC Requests email

    private string getMyStand(PECApprover oPECApprover)
    {
        string myStand = "";
        if (oPECApprover.m_iStand == (int)siteVisitApprovalStatus.apprStatusRpt.Callme)
        {
            myStand = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.Callme);
        }
        else if (oPECApprover.m_iStand == (int)siteVisitApprovalStatus.apprStatusRpt.NotApproved)
        {
            myStand = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.NotApproved);
        }
        else if (oPECApprover.m_iStand == (int)siteVisitApprovalStatus.apprStatusRpt.Reschedule)
        {
            myStand = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.Reschedule);
        }

        return myStand;
    }
    public bool PecInitiatorSendsMailToActivitySponsor(structUserMailIdx eActivitySponsor, long lActivityId)
    {
        ActivityInfo myDetails = ActivityInfo.objGetActivityInfoByActivityId(lActivityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.PECRequestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sPECMailSubjet;
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName + " [" + myDetails.eInitiator.m_sRefInd + "]");
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());
            sBody = sBody.Replace("@=TASK", myDetails.m_sActivityDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/Default.aspx?pec=" + (int)AppTokens.appTokens.pec + "&lActivityId=" + lActivityId);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.prodSupportName + "[" + AppConfiguration.prodSupportEmail + "]");

            AlternateView altView = AlternateView.CreateAlternateViewFromString(sBody, null, MediaTypeNames.Text.Html);
            LinkedResource pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
            pic.ContentId = "Logo";
            altView.LinkedResources.Add(pic);

            emailClientExPic oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(eActivitySponsor, sSubject, sBody, altView);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool SendsMailToNextPECApprover(structUserMailIdx eNextApprover, structUserMailIdx eIntiator, long iActivityId)
    {
        ActivityInfo myDetails = ActivityInfo.objGetActivityInfoByActivityId(iActivityId);

        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.PECRequestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=TASK", myDetails.m_sActivityDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eNextApprover, eIntiator, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool SendsMailToNextPECApprover(structUserMailIdx eNextApprover, List<structUserMailIdx> eTo, long iActivityId)
    {
        ActivityInfo myDetails = ActivityInfo.objGetActivityInfoByActivityId(iActivityId);

        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.PECRequestForApproval;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=INITIATOR", myDetails.eInitiator.m_sFullName);
            sBody = sBody.Replace("@=TASK", myDetails.m_sActivityDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eNextApprover, eTo, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool PECRequestNotApproved(structUserMailIdx eInitiator, long iActivityId, long iApprovalId, string Comment, appUsers Approver)
    {
        ActivityInfo myDetails = ActivityInfo.objGetActivityInfoByActivityId(iActivityId);
        PECApprover oPECApprover = PECApprover.objGetPECApproverByApprovalId(iApprovalId);

        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestNotApproved;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdFieldVisit));
            sBody = sBody.Replace("@=STAND", getMyStand(oPECApprover));
            sBody = sBody.Replace("@=REASON", oPECApprover.m_sComment);
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sActivityDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
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
    public bool PECRequestNotApproved(structUserMailIdx eInitiator, structUserMailIdx eCopy, long iActivityId, long iApprovalId, string Comment, appUsers Approver)
    {
        ActivityInfo myDetails = ActivityInfo.objGetActivityInfoByActivityId(iActivityId);
        PECApprover oPECApprover = PECApprover.objGetPECApproverByApprovalId(iApprovalId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestNotApproved;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdFieldVisit));
            sBody = sBody.Replace("@=STAND", getMyStand(oPECApprover));
            sBody = sBody.Replace("@=REASON", oPECApprover.m_sComment);
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sActivityDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eInitiator, eCopy, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool PECRequestNotApproved(structUserMailIdx eInitiator, List<structUserMailIdx> eCopy, long iActivityId, long iApprovalId, string Comment, appUsers Approver)
    {
        ActivityInfo myDetails = ActivityInfo.objGetActivityInfoByActivityId(iActivityId);
        PECApprover oPECApprover = PECApprover.objGetPECApproverByApprovalId(iApprovalId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.requestNotApproved;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=FULLNAME", Approver.m_sFullName);
            sBody = sBody.Replace("@ROLE", appUsersRoles.userRoleDesc((appUsersRoles.userRole)Approver.m_iRoleIdFieldVisit));
            sBody = sBody.Replace("@=STAND", getMyStand(oPECApprover));
            sBody = sBody.Replace("@=REASON", oPECApprover.m_sComment);
            sBody = sBody.Replace("@=FIELD", myDetails.eFacility.m_sFacility + " => " + myDetails.eFacility.eDistrict.m_sDistrict + " => " + myDetails.eFacility.eDistrict.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sActivityDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eInitiator, eCopy, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
    public bool PECRequestApproved(structUserMailIdx eInitiator, List<structUserMailIdx> eTo, long iActivityId, int iUserId)
    {
        appUsers ApproverSuperIntendent = appUsersHelper.objGetUserByUserId(iUserId);
        ActivityInfo myDetails = ActivityInfo.objGetActivityInfoByActivityId(iActivityId);

        facility field = facility.objGetFacilityById(myDetails.m_iFacilityId);
        bool bRet = false;
        try
        {
            string sBody = Resources.Resource.PECRequestApproved;
            string sSubject = myDetails.m_sActivityId + " - " + c_sMailSubjet;
            sBody = sBody.Replace("@=SUPERINTENDENT", field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=APPROVER", ApproverSuperIntendent.m_sFullName);
            sBody = sBody.Replace("@=FIELD", field.m_sFacility + " => " + field.eDistrict.m_sDistrict + " => " + field.eSuperintendent.m_sSuperintendent);
            sBody = sBody.Replace("@=TASK", myDetails.m_sActivityDescription);
            sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.prodAdminName + "[" + AppConfiguration.prodAdminEmail + "]");
            sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eInitiator, eTo, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    #endregion

    public bool ApplicationErrorMessage(structUserMailIdx eFrom, structUserMailIdx eTo, string errorMessage)
    {
        bool bRet = false;
        try
        {
            string sSubject, sBody;

            sSubject = "Field Visit Application Error:";
            sBody = "Dear System Admnistrator, <br/> <br/>";
            sBody += errorMessage;
            sBody += "<br/>";

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(eFrom, eTo, sSubject, sBody);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }
}