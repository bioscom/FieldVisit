using System;
using System.Collections.Generic;
using Microsoft.Security.Application;

public partial class ViewComments : aspnetPage
{
    FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();
    FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["RequestId"] != null)
            {
                long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["RequestId"].ToString()));

                oRequestDetails1.Init_Control(oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId));

                LoadComments(lRequestId);
            }
        }
    }

    private void LoadComments(long lRequestId)
    {
        List<FlareApproval> oFlareApprovals = oFlareApprovalHelper.lstGetFlareApprovalbyRequestId(lRequestId);
        foreach (FlareApproval oFlareApproval in oFlareApprovals)
        {
            if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
            {
                lblLineMgr.Text = oappUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                lblLineMgrStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)oFlareApproval.m_iStand);
                lblLineMgrStand.ForeColor = (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Supported) ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblLineMgrComments.Text = oFlareApproval.m_sComments;
                lblLineMgrDateRcd.Text = oFlareApproval.m_sDateReceived;
                lblLineMgrDateRvd.Text = oFlareApproval.m_sDateReviewed;

                if (oFlareApproval.m_iStand != (int)RequestStatusReporter.RequestStatusRpt.iDefault)
                {
                    lineMgrCkb.Enabled = false;
                }
            }
            else if ((oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore) || (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore))
            {
                lblAssuranceGM.Text = oappUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                lblAssuranceStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)oFlareApproval.m_iStand);
                lblAssuranceStand.ForeColor = (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Supported) ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblAssuranceComments.Text = oFlareApproval.m_sComments;
                lblAssuranceDateRcd.Text = oFlareApproval.m_sDateReceived;
                lblAssuranceDateRvd.Text = oFlareApproval.m_sDateReviewed;
                if (oFlareApproval.m_iStand != (int)RequestStatusReporter.RequestStatusRpt.iDefault)
                {
                    AssuranceCkb.Enabled = false;
                }
            }
            else if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
            {
                lblPSMgr.Text = oappUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                lblPSMgrStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)oFlareApproval.m_iStand);
                lblPSMgrStand.ForeColor = (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Supported) ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblPSMgrComment.Text = oFlareApproval.m_sComments;
                lblPSMgrDateRcd.Text = oFlareApproval.m_sDateReceived;
                lblPSMgrDateRvd.Text = oFlareApproval.m_sDateReviewed;
                if (oFlareApproval.m_iStand != (int)RequestStatusReporter.RequestStatusRpt.iDefault)
                {
                    PSMgrCkb.Enabled = false;
                }
            }
            else if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval)
            {
                lblApproval.Text = oappUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                lblApprovalStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)oFlareApproval.m_iStand);
                lblApprovalStand.ForeColor = (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Approved) ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblApprovalComment.Text = oFlareApproval.m_sComments;
                lblApprovalDateRcd.Text = oFlareApproval.m_sDateReceived;
                lblApprvalDateRvd.Text = oFlareApproval.m_sDateReviewed;
                if (oFlareApproval.m_iStand != (int)RequestStatusReporter.RequestStatusRpt.iDefault)
                {
                    ApprovalCkb.Enabled = false;
                }
            }
        }
    }

    protected void forwardReminderButton_Click(object sender, EventArgs e)
    {
        FlareWaiver oFlareWaiverRequest = oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(long.Parse(Request.QueryString["RequestId"].ToString()));

        if (lineMgrCkb.Checked) SendReminder(oFlareWaiverRequest.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager, oFlareWaiverRequest.m_sReason, oFlareWaiverRequest.m_sRequestNumber);
        if (PSMgrCkb.Checked) SendReminder(oFlareWaiverRequest.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr, oFlareWaiverRequest.m_sReason, oFlareWaiverRequest.m_sRequestNumber);
        if (ApprovalCkb.Checked) SendReminder(oFlareWaiverRequest.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.Approval, oFlareWaiverRequest.m_sReason, oFlareWaiverRequest.m_sRequestNumber);

        if (AssuranceCkb.Checked) SendReminder(oFlareWaiverRequest.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore, oFlareWaiverRequest.m_sReason, oFlareWaiverRequest.m_sRequestNumber);
        if (AssuranceCkb.Checked) SendReminder(oFlareWaiverRequest.m_lRequestId, (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore, oFlareWaiverRequest.m_sReason, oFlareWaiverRequest.m_sRequestNumber);

        if (!lineMgrCkb.Checked || !PSMgrCkb.Checked || !ApprovalCkb.Checked || !AssuranceCkb.Checked)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "At least a check box must be selected before you can send pending flare waiver reminder. Check any desired box.");
        }
    }

    private bool SendReminder(long lRequestId, int iRoleId, string sReason, string sRequestNumber)
    {
        bool success = false;
        try
        {
            FlareApproval oFlareApproval = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, iRoleId);
            appUsers oAppUser = oappUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId);

            if (!string.IsNullOrEmpty(oFlareApproval.m_sDateReceived))
            {
                FlareWaiverSendMail.sendMail eMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
                success = eMail.PendingRequestReminder(oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId), oAppUser, oSessnx.getOnlineUser.structUserIdx);
                if (success)
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Mail Successfully sent to " + oAppUser.m_sFullName);
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Not Successfully sent to " + oAppUser.m_sFullName);
                }
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Reminder mail cannot be sent to " + oAppUser.m_sFullName + ", Request yet to get to his/her intray.");
            }

        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return success;
    }
}