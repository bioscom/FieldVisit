using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

/// <summary>
/// Summary description for sendMail
/// </summary>

namespace FlareWaiverSendMail
{
    public class sendMail
    {
        private const string c_sMailSubjet = " - Flare Waiver";
        private string c_sLogoPath = HttpContext.Current.Server.MapPath(@"~/Images/ShellLogo.png");
        private structUserMailIdx m_eSender;

        bool bRet = false;
        appUsersHelper oappUsersHelper = new appUsersHelper();
        RequestFacilityHelper oRequestFacilityHelper = new RequestFacilityHelper();

        public sendMail(structUserMailIdx _eSender)
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
            string sSubject = AppConfiguration.siteNameFlareWaiver;
            try
            {
                string sBody = Resources.FlareWaiver.eMailUsers;
                sBody = sBody.Replace("@=ROLE", appUserRolesFlrWaiver.userRoleDesc((appUserRolesFlrWaiver.userRole)oAppUser.m_iRoleIdFlr));
                sBody = sBody.Replace("@=AAAA", oAppUser.m_sUserName);
                sBody = sBody.Replace("@=BBBB", oAppUser.m_sFullName);
                sBody = sBody.Replace("@=CCCC", oAppUser.m_sUserMail);
                sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

                AlternateView altView = CommonContent(sBody);
                emailClientExPic oMail = new emailClientExPic(m_eSender);

                bRet = oMail.sendShellMail(oAppUser.structUserIdx, sSubject, sBody, altView);
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
            }
            return bRet;
        }

        public bool FlareLimitViolation(int iMonth, decimal dFlareLimit, int iFacilityId, decimal API, List<structUserMailIdx> mailTo, List<structUserMailIdx> cCopy)
        {
            string mSubject = "Flare Limit Violation.";

            Facility ofac = Facility.objGetFacilityById(iFacilityId);

            string mBody = "There is a flare limit violation from " + ofac.m_sFacility;
            mBody += " <br/> <br/>Flare limit for the month of " + mMonthEnuem.monthDesc((mMonthEnuem.mMonth)iMonth) + " is " + dFlareLimit + "mscfd";
            mBody += " <br/> <br/>Amount flared " + API + " mscfd";

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(mailTo, cCopy, mSubject, mBody);

            return bRet;
        }

        public bool ForwardRequestForSupportApproval(FlareWaiver oFlareWaiver, appUsers oNextSupportApprover, structUserMailIdx cCopy)
        {
            string mSubject = oFlareWaiver.m_sRequestNumber + " - Flare Waiver Request pending your action.";
            string mBody = Resources.FlareWaiver.eMailTemplate;
            mBody = mBody.Replace("@=EMAIL", Resources.FlareWaiver.ForSupportApproval);

            mBody = mBody.Replace("@=CATEGORY", Category.objGetCategoryByCatId(oFlareWaiver.m_iCategoryId).m_sCategory);

            mBody = mBody.Replace("@=FACILITY", getFacilities(oFlareWaiver.m_lRequestId));

            string sActionRequired = "support";
            if (oNextSupportApprover.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval) sActionRequired = "approval";

            mBody = mBody.Replace("@=ACTION", sActionRequired);
            mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oFlareWaiver.m_iUserId).m_sFullName);
            mBody = mBody.Replace("@=VOLUME", oFlareWaiver.m_sFlareVol.ToString());
            mBody = mBody.Replace("@=OIL", oFlareWaiver.m_sOilProduced.ToString());

            mBody = mBody.Replace("@=SDATE", oFlareWaiver.m_sStartDate.ToString());
            mBody = mBody.Replace("@=STIME", oFlareWaiver.m_sStartTime.ToString());
            mBody = mBody.Replace("@=EDATE", oFlareWaiver.m_sEndDate.ToString());
            mBody = mBody.Replace("@=ETIME", oFlareWaiver.m_sEndTime.ToString());
            mBody = mBody.Replace("@=REASON", oFlareWaiver.m_sReason);
            mBody = mBody.Replace("@=JUSTIFICATION", oFlareWaiver.m_sJustification);

            mBody = mBody.Replace("@=POSTEVENT", oFlareWaiver.m_sPostEvent);

            AlternateView altView = CommonContent(mBody, oFlareWaiver.m_lRequestId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(oNextSupportApprover.structUserIdx, cCopy, mSubject, mBody, altView);

            return bRet;
        }

        public bool ForwardRequestForSupportApproval(FlareWaiver oFlareWaiver, appUsers oNextSupportApprover, List<structUserMailIdx> cCopy)
        {
            string mSubject = oFlareWaiver.m_sRequestNumber + " - Flare Waiver Request pending your action.";
            string mBody = Resources.FlareWaiver.eMailTemplate;
            mBody = mBody.Replace("@=EMAIL", Resources.FlareWaiver.ForSupportApproval);

            mBody = mBody.Replace("@=CATEGORY", Category.objGetCategoryByCatId(oFlareWaiver.m_iCategoryId).m_sCategory);
            mBody = mBody.Replace("@=FACILITY", getFacilities(oFlareWaiver.m_lRequestId));

            string sActionRequired = "support";
            if (oNextSupportApprover.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval) sActionRequired = "approval";

            mBody = mBody.Replace("@=ACTION", sActionRequired);

            FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
            FlareApproval oApprover = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(oFlareWaiver.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager);
            mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oApprover.m_iUserId).m_sFullName);

            //mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oFlareWaiver.m_iUserId).m_sFullName);
            mBody = mBody.Replace("@=VOLUME", oFlareWaiver.m_sFlareVol.ToString());
            mBody = mBody.Replace("@=OIL", oFlareWaiver.m_sOilProduced.ToString());

            mBody = mBody.Replace("@=SDATE", oFlareWaiver.m_sStartDate.ToString());
            mBody = mBody.Replace("@=STIME", oFlareWaiver.m_sStartTime.ToString());
            mBody = mBody.Replace("@=EDATE", oFlareWaiver.m_sEndDate.ToString());
            mBody = mBody.Replace("@=ETIME", oFlareWaiver.m_sEndTime.ToString());
            mBody = mBody.Replace("@=REASON", oFlareWaiver.m_sReason);
            mBody = mBody.Replace("@=JUSTIFICATION", oFlareWaiver.m_sJustification);

            mBody = mBody.Replace("@=POSTEVENT", oFlareWaiver.m_sPostEvent);

            AlternateView altView = CommonContent(mBody, oFlareWaiver.m_lRequestId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(oNextSupportApprover.structUserIdx, cCopy, mSubject, mBody, altView);

            return bRet;
        }

        public bool RequestNotSupportedApproved(FlareWaiver oFlareWaiver, appUsers oOnlineUser, string sReason, List<structUserMailIdx> cCopy)
        {
            appUsers oInitiator = oappUsersHelper.objGetUserByUserID(oFlareWaiver.m_iUserId);
            string sActionRequired = "supported";
            if (oOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval) sActionRequired = "approved";

            string mSubject = oFlareWaiver.m_sRequestNumber + " - Flare Waiver Request Not " + sActionRequired + ".";
            string mBody = Resources.FlareWaiver.eMailTemplate;
            mBody = mBody.Replace("@=EMAIL", Resources.FlareWaiver.ForNotSupportedApproved);

            mBody = mBody.Replace("@=CATEGORY", Category.objGetCategoryByCatId(oFlareWaiver.m_iCategoryId).m_sCategory);
            mBody = mBody.Replace("@=FACILITY", getFacilities(oFlareWaiver.m_lRequestId));

            mBody = mBody.Replace("@=ACTION", sActionRequired);
            mBody = mBody.Replace("@=INITIATOR", oInitiator.m_sFullName);
            mBody = mBody.Replace("@=SUPPORTAPPROVAL", oOnlineUser.m_sFullName);
            mBody = mBody.Replace("@=ACTIONED", sActionRequired);

            mBody = mBody.Replace("@=XREASON", sReason);


            mBody = mBody.Replace("@=VOLUME", oFlareWaiver.m_sFlareVol.ToString());
            mBody = mBody.Replace("@=OIL", oFlareWaiver.m_sOilProduced.ToString());

            mBody = mBody.Replace("@=SDATE", oFlareWaiver.m_sStartDate.ToString());
            mBody = mBody.Replace("@=STIME", oFlareWaiver.m_sStartTime.ToString());
            mBody = mBody.Replace("@=EDATE", oFlareWaiver.m_sEndDate.ToString());
            mBody = mBody.Replace("@=ETIME", oFlareWaiver.m_sEndTime.ToString());
            mBody = mBody.Replace("@=REASON", oFlareWaiver.m_sReason);
            mBody = mBody.Replace("@=JUSTIFICATION", oFlareWaiver.m_sJustification);

            mBody = mBody.Replace("@=POSTEVENT", oFlareWaiver.m_sPostEvent);

            AlternateView altView = CommonContent(mBody, oFlareWaiver.m_lRequestId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(oInitiator.structUserIdx, cCopy, mSubject, mBody, altView);

            return bRet;
        }

        public bool RequestSupported(FlareWaiver oFlareWaiver, appUsers oOnlineUser, List<structUserMailIdx> cCopy)
        {
            appUsers oInitiator = oappUsersHelper.objGetUserByUserID(oFlareWaiver.m_iUserId);

            string mSubject = oFlareWaiver.m_sRequestNumber + " - Flare Waiver Request Supported.";
            string mBody = Resources.FlareWaiver.eMailTemplate;
            mBody = mBody.Replace("@=EMAIL", Resources.FlareWaiver.ForSupported);

            mBody = mBody.Replace("@=CATEGORY", Category.objGetCategoryByCatId(oFlareWaiver.m_iCategoryId).m_sCategory);
            mBody = mBody.Replace("@=FACILITY", getFacilities(oFlareWaiver.m_lRequestId));
            mBody = mBody.Replace("@=SUPPORTED", oOnlineUser.m_sFullName);

            //TODO: How to convert Nullable int (int?) to int
            int role = oOnlineUser.m_iRoleIdFlr ?? default(int); 

            FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
            FlareApproval o = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(oFlareWaiver.m_lRequestId, role);

            FlareApproval oApprover = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(oFlareWaiver.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager);
            mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oApprover.m_iUserId).m_sFullName);
            mBody = mBody.Replace("@=VOLUME", oFlareWaiver.m_sFlareVol.ToString());
            mBody = mBody.Replace("@=OIL", oFlareWaiver.m_sOilProduced.ToString());
            mBody = mBody.Replace("@=SDATE", o.m_sDateReviewed); //oFlareWaiver.m_sStartDate); //once approved by GM Production, the effective date should be the approval date.
            mBody = mBody.Replace("@=STIME", oFlareWaiver.m_sStartTime.ToString());

            //calculate the difference between oFlareWaiver.m_sStartDate and oFlareWaiver.m_sEndDate and add to oApproverGMProduction.m_sDateReviewed
            TimeSpan iDifference = DateTime.Parse(oFlareWaiver.m_sEndDate.ToString()) - DateTime.Parse(oFlareWaiver.m_sStartDate.ToString());
            DateTime finalEndDate = DateTime.Parse(o.m_sDateReviewed).AddDays(iDifference.Days); //DateTime.Now.AddDays(iDifference.Days);

            mBody = mBody.Replace("@=EDATE", finalEndDate.ToString());
            mBody = mBody.Replace("@=ETIME", oFlareWaiver.m_sEndTime.ToString());
            mBody = mBody.Replace("@=REASON", oFlareWaiver.m_sReason);
            mBody = mBody.Replace("@=JUSTIFICATION", oFlareWaiver.m_sJustification);

            mBody = mBody.Replace("@=POSTEVENT", oFlareWaiver.m_sPostEvent);

            AlternateView altView = CommonContent(mBody, oFlareWaiver.m_lRequestId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);

            bRet = oMail.sendShellMail(oInitiator.structUserIdx, cCopy, mSubject, mBody, altView);

            return bRet;
        }

        public bool RequestApproved(FlareWaiver oFlareWaiver, appUsers oOnlineUser, List<structUserMailIdx> cCopy)
        {
            appUsers oInitiator = oappUsersHelper.objGetUserByUserID(oFlareWaiver.m_iUserId);

            string mSubject = oFlareWaiver.m_sRequestNumber + " - Flare Waiver Request Approved.";
            string mBody = Resources.FlareWaiver.eMailTemplate;
            mBody = mBody.Replace("@=EMAIL", Resources.FlareWaiver.ForApproved);

            mBody = mBody.Replace("@=CATEGORY", Category.objGetCategoryByCatId(oFlareWaiver.m_iCategoryId).m_sCategory);
            mBody = mBody.Replace("@=FACILITY", getFacilities(oFlareWaiver.m_lRequestId));
            mBody = mBody.Replace("@=APPROVER", oOnlineUser.m_sFullName);

            FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
            FlareApproval oApproverGMProduction = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(oFlareWaiver.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.Approval);

            FlareApproval oApprover = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(oFlareWaiver.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager);
            mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oApprover.m_iUserId).m_sFullName);

            //mBody = mBody.Replace("@=INITIATOR", oInitiator.m_sFullName);
            mBody = mBody.Replace("@=SUPPORTAPPROVAL", oOnlineUser.m_sFullName);

            mBody = mBody.Replace("@=VOLUME", oFlareWaiver.m_sFlareVol.ToString());
            mBody = mBody.Replace("@=OIL", oFlareWaiver.m_sOilProduced.ToString());

            mBody = mBody.Replace("@=SDATE", oApproverGMProduction.m_sDateReviewed); //oFlareWaiver.m_sStartDate); //once approved by GM Production, the effective date should be the approval date.
            mBody = mBody.Replace("@=STIME", oFlareWaiver.m_sStartTime.ToString());

            //calculate the difference between oFlareWaiver.m_sStartDate and oFlareWaiver.m_sEndDate and add to oApproverGMProduction.m_sDateReviewed
            TimeSpan iDifference =  DateTime.Parse(oFlareWaiver.m_sEndDate.ToString()) - DateTime.Parse(oFlareWaiver.m_sStartDate.ToString());
            DateTime finalEndDate = DateTime.Parse(oApproverGMProduction.m_sDateReviewed).AddDays(iDifference.Days); //DateTime.Now.AddDays(iDifference.Days);

            mBody = mBody.Replace("@=EDATE", finalEndDate.ToString());  
            mBody = mBody.Replace("@=ETIME", oFlareWaiver.m_sEndTime.ToString());
            mBody = mBody.Replace("@=REASON", oFlareWaiver.m_sReason);
            mBody = mBody.Replace("@=JUSTIFICATION", oFlareWaiver.m_sJustification);

            mBody = mBody.Replace("@=POSTEVENT", oFlareWaiver.m_sPostEvent);

            AlternateView altView = CommonContent(mBody, oFlareWaiver.m_lRequestId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);

            bRet = oMail.sendShellMail(oInitiator.structUserIdx, cCopy, mSubject, mBody, altView);

            return bRet;
        }

        public bool PendingRequestReminder(FlareWaiver oFlareWaiver, appUsers oNextSupportApprover, structUserMailIdx cCopy)
        {
            string mSubject = oFlareWaiver.m_sRequestNumber + " - Pending Flare Waiver Request Reminder.";
            string mBody = Resources.FlareWaiver.eMailTemplate;
            mBody = mBody.Replace("@=EMAIL", Resources.FlareWaiver.ForSupportApproval);

            mBody = mBody.Replace("@=CATEGORY", Category.objGetCategoryByCatId(oFlareWaiver.m_iCategoryId).m_sCategory);
            mBody = mBody.Replace("@=FACILITY", getFacilities(oFlareWaiver.m_lRequestId));

            string sActionRequired = "support";
            if (oNextSupportApprover.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval) sActionRequired = "approval";

            mBody = mBody.Replace("@=ACTION", sActionRequired);

            FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
            FlareApproval oApprover = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(oFlareWaiver.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager);
            mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oApprover.m_iUserId).m_sFullName);

            //mBody = mBody.Replace("@=INITIATOR", oappUsersHelper.objGetUserByUserID(oFlareWaiver.m_iUserId).m_sFullName);
            mBody = mBody.Replace("@=VOLUME", oFlareWaiver.m_sFlareVol.ToString());
            mBody = mBody.Replace("@=OIL", oFlareWaiver.m_sOilProduced.ToString());

            mBody = mBody.Replace("@=SDATE", oFlareWaiver.m_sStartDate.ToString());
            mBody = mBody.Replace("@=STIME", oFlareWaiver.m_sStartTime.ToString());
            mBody = mBody.Replace("@=EDATE", oFlareWaiver.m_sEndDate.ToString());
            mBody = mBody.Replace("@=ETIME", oFlareWaiver.m_sEndTime.ToString());
            mBody = mBody.Replace("@=REASON", oFlareWaiver.m_sReason);
            mBody = mBody.Replace("@=JUSTIFICATION", oFlareWaiver.m_sJustification);

            mBody = mBody.Replace("@=POSTEVENT", oFlareWaiver.m_sPostEvent);

            AlternateView altView = CommonContent(mBody, oFlareWaiver.m_lRequestId);
            emailClientExPic oMail = new emailClientExPic(m_eSender);
            bRet = oMail.sendShellMail(oNextSupportApprover.structUserIdx, cCopy, mSubject, mBody, altView);

            return bRet;
        }

        public bool ApplicationErrorMessage(List<structUserMailIdx> toEmail, string errorMessage)
        {
            string mBody;
            string mSubject = AppConfiguration.siteNameFlareWaiver + " Error Message:";
            mBody = "Dear System Administrator, <br/> <br/>";
            mBody += errorMessage;
            mBody += "<br/>";

            emailClient oMail = new emailClient(m_eSender);
            bRet = oMail.sendShellMail(toEmail, mSubject, mBody);

            return bRet;
        }

        public bool UserPasswordReset(structUserMailIdx eUserDefined, appUsers me)
        {
            bool bRet = false;
            string sSubject = "Account Password reset.";
            try
            {
                string sBody = ""; //Resources.Resource.PasswordReset;
                sBody = sBody.Replace("@=AAAA", eUserDefined.m_sUserName);
                sBody = sBody.Replace("@=BBBB", me.m_sFullName);
                sBody = sBody.Replace("@=CCCC", eUserDefined.m_sUserMail);
                //sBody = sBody.Replace("@PPPP", me.m_sPassword);
                sBody = sBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

                sBody = sBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/LPswReset.aspx");
                //sBody = sBody.Replace("@=L1SUPPORT", AppConfiguration.ProdAdminName + "[" + AppConfiguration.ProdAdminEmail + "]");
                sBody = sBody.Replace("@=L2SUPPORT", AppConfiguration.adminName + "[" + AppConfiguration.adminEmail + "]");
                AlternateView altView = CommonContent(sBody);
                emailClientExPic oMail = new emailClientExPic(m_eSender);
                bRet = oMail.sendShellMail(eUserDefined, sSubject, sBody, altView);
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
            }
            return bRet;
        }

        private AlternateView CommonContent(string mBody, long lRequestId)
        {
            mBody = mBody.Replace("@=LIMEMGR", "");
            mBody = mBody.Replace("@=PRODSERVMGR", "");
            mBody = mBody.Replace("@=GMPROD", "");
            //mBody = mBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/App/FlareWaiver/FlareApprovalProc.aspx?RequestId=" + lRequestId);
            mBody = mBody.Replace("@=EEEE", AppConfiguration.siteHostName + "/Default.aspx?flr=" + (int)AppTokens.appTokens.FlareWaiver + "&RequestId=" + lRequestId);
            //Response.Redirect("~/FlareApprovalProc.aspx?RequestId=" + lRequestId);
            mBody = mBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

            AlternateView altView = AlternateView.CreateAlternateViewFromString(mBody, null, MediaTypeNames.Text.Html);
            LinkedResource pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
            pic.ContentId = "Logo";
            altView.LinkedResources.Add(pic);

            return altView;
        }

        private AlternateView CommonContent(string mBody)
        {
            mBody = mBody.Replace("@=LIMEMGR", "");
            mBody = mBody.Replace("@=PRODSERVMGR", "");
            mBody = mBody.Replace("@=GMPROD", "");
            mBody = mBody.Replace("@=EEEE", AppConfiguration.siteHostName);
            //Response.Redirect("~/FlareApprovalProc.aspx?RequestId=" + lRequestId);
            mBody = mBody.Replace("@=TTTT", DateTime.Now.ToLongDateString());

            AlternateView altView = AlternateView.CreateAlternateViewFromString(mBody, null, MediaTypeNames.Text.Html);
            LinkedResource pic = new LinkedResource(c_sLogoPath, MediaTypeNames.Image.Gif);
            pic.ContentId = "Logo";
            altView.LinkedResources.Add(pic);

            return altView;
        }

        private string getFacilities(long lRequestId)
        {
            string sFacilities = "";
            List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(lRequestId);
            foreach (RequestFacility oRequestFacility in lstRequestFacilities)
            {
                sFacilities += Facility.objGetFacilityById(oRequestFacility.m_iFacilityId).m_sFacility + ", ";
            }

            return sFacilities;
        }
    }
}