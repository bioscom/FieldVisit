using System;
using System.Collections.Generic;
using Microsoft.Security.Application;

public partial class App_BI500_ViewComments : aspnetPage
{
    //BI500Request oBI500Request = new BI500Request();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    //BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    //BI500Approval oBI500Approval = new BI500Approval();
    //appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["RequestId"] != null)
            {
                long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["RequestId"].ToString()));
                oRequestDetails1.Init_Control(oBI500RequestHelper.objGetBrightIdeaById(lRequestId));

                oApprovalCommentBITeam.InitControl(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam);
                oApprovalCommentProjectChampion.InitControl(lRequestId, (int)appUsersRolesBI500.userRole.champion);
                oApprovalCommentProjectSponsor.InitControl(lRequestId, (int)appUsersRolesBI500.userRole.sponsor);

                //LoadComments(lRequestId);
            }
        }
    }

    //private void LoadComments(long lRequestId)
    //{
    //    //List<BI500Approval> oBI500Approvals = oBI500ApprovalHelper.lstGetBIApprovalbyRequestId(lRequestId);
    //    //oBI500Approval = oBI500ApprovalHelper.objGetBIApprovalbyRequestId(lRequestId);

    //    //lblChampion.Text = oappUsersHelper.objGetUserByUserID(oBI500Approval.m_iUserId).m_sFullName;
    //    //lblChampionStand.Text = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)(int)(BIRequestStatus.RequestStatusRpt)oBI500Approval.m_iStand);
    //    //lblChampionCmnt.Text = oBI500Approval.m_sComments;
    //    //lblChampionDateRecvd.Text = oBI500Approval.m_sDateReceived;
    //    //lblChampionDateRvwd.Text = oBI500Approval.m_sDateReviewed;

    //    //foreach (BI500Approval oBI500Approval in oBI500Approvals)
    //    //{
    //    //    if (oBI500Approval.m_iRoleIdBI == (int)appUsersRoles.userRole.champion)
    //    //    {
    //    //        lblChampion.Text = oappUsersHelper.objGetUserByUserID(oBI500Approval.m_iUserId).m_sFullName;
    //    //        lblChampionStand.Text = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)(int)(BIRequestStatus.RequestStatusRpt)oBI500Approval.m_iStand);
    //    //        lblChampionComments.Text = oBI500Approval.m_sComments;
    //    //        lblChampionDateReceived.Text = oBI500Approval.m_sDateReceived;
    //    //        lblChampionDateReviewed.Text = oBI500Approval.m_sDateReviewed;

                
    //    //    }
    //    //    //else if (oBI500Approval.m_iRoleIdBI == (int)appUsersRoles.userRole.sponsor)
    //    //    //{
    //    //    //    lblSponsor.Text = oappUsersHelper.objGetUserByUserID(oBI500Approval.m_iUserId).m_sFullName;
    //    //    //    lblSponsorStand.Text = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)oBI500Approval.m_iStand);
    //    //    //    lblSponsorComment.Text = oBI500Approval.m_sComments;
    //    //    //    lblSponsorDateReceived.Text = oBI500Approval.m_sDateReceived;
    //    //    //    lblSponsorDateReviewed.Text = oBI500Approval.m_sDateReviewed;
    //    //    //}
    //    //}
    //}

    //protected void forwardReminderButton_Click(object sender, EventArgs e)
    //{
    //    oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(long.Parse(Request.QueryString["RequestId"].ToString()));
    //    SendReminder(oBI500Request.m_lRequestId, (int)appUsersRoles.userRole.champion, oBI500Request.m_sBusinessCase, oBI500Request.m_sRequestNumber);

    //    //if (ProjChampionCkb.Checked)
    //    //{
    //    //    SendReminder(oBI500Request.m_lRequestId, (int)appUsersRoles.userRole.champion, oBI500Request.m_sBusinessCase, oBI500Request.m_sRequestNumber);
    //    //}

    //    //if (ProjSponsorCkb.Checked)
    //    //{
    //    //    SendReminder(oBI500Request.m_lRequestId, (int)appUsersRoles.userRole.sponsor, oBI500Request.m_sBusinessCase, oBI500Request.m_sRequestNumber);
    //    //}

    //    //if (!ProjChampionCkb.Checked || !ProjSponsorCkb.Checked)
    //    //{
    //    //    ajaxWebExtension.showJscriptAlert(Page, this, "At least a check box must be selected before you can send pending Bright Idea review reminder. Check any desired box.");
    //    //}
    //}

    //private bool SendReminder(long lRequestId, int iRoleId, string sReason, string sRequestNumber)
    //{
    //    bool success = false;
    //    oBI500Approval = oBI500ApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, iRoleId);
    //    appUsers oAppUser = oappUsersHelper.objGetUserByUserID(oBI500Approval.m_iUserId);

    //    if (!string.IsNullOrEmpty(oBI500Approval.m_sDateReceived))
    //    {
    //        sendMailBI500 eMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
    //        success = eMail.PendingRequestReminder(oBI500RequestHelper.objGetBrightIdeaById(lRequestId), oAppUser, oSessnx.getOnlineUser.structUserIdx);
    //        if (success)
    //        {
    //            ajaxWebExtension.showJscriptAlert(Page, this, "Mail Successfully sent to " + oAppUser.m_sFullName);
    //        }
    //    }
    //    else
    //    {
    //        ajaxWebExtension.showJscriptAlert(Page, this, "Reminder mail cannot be sent to " + oAppUser.m_sFullName + ", Request yet to get to his or her intray.");
    //    }

    //    return success;
    //}
}