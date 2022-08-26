using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_UserControl_oApprovalComment : aspnetUserControl
{
    CostReductionRequest oBI500Request = new CostReductionRequest();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    BI500Approval oBI500Approval = new BI500Approval();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitControl()
    {

    }

    public void InitControl(long lRequestId, int iRoleId)
    {
        oBI500Approval = oBI500ApprovalHelper.objGetBIApprovalbyRequestRoleId(lRequestId, iRoleId);

        if (iRoleId == (int)appUsersRolesBI500.userRole.sponsor)
        {
            lblSupportApprover.Text = "Approver";
            lblApproverRole.Text = "Leadership Governing Board";
        }
        else if (iRoleId == (int)appUsersRolesBI500.userRole.champion)
        {
            lblSupportApprover.Text = "Reviewer/Support";
            lblApproverRole.Text = "Supervisor";
        }
        else
        {
            lblSupportApprover.Text = "Reviewer/Support";
            lblApproverRole.Text = "Lean Team and Business Improvement Rep.";
        }

        lblApprover.Text = oappUsersHelper.objGetUserByUserID(oBI500Approval.m_iUserId).m_sFullName;
        //lblApproverRole.Text = appUsersRoles.userRoleDesc((appUsersRoles.userRole)iRoleId);
        lblComment.Text = oBI500Approval.m_sComments;
        lblDateReceived.Text = oBI500Approval.m_dDateReceived.ToString();
        lblDateReviewed.Text = oBI500Approval.m_dDateReviewed.ToString();

        if (oBI500Approval.m_iStand == (int)BIRequestStatus.RequestStatusRpt.iDefault)
        {
            lblStand.Text = "Pending Review...";
            lblStand.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblStand.Text = oBI500Approval.m_iStand.ToString();
            BIRequestStatus.reportMyStatus(lblStand);
            lblStand.Text = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)oBI500Approval.m_iStand);
        }

        HFRole.Value = iRoleId.ToString();
    }

    protected void forwardReminderButton_Click(object sender, EventArgs e)
    {
        oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(long.Parse(Request.QueryString["RequestId"].ToString()));
        SendReminder(oBI500Request.lRequestId, int.Parse(HFRole.Value), oBI500Request.sBusinessCase, oBI500Request.sRequestNumber);
    }

    private bool SendReminder(long lRequestId, int iRoleId, string sReason, string sRequestNumber)
    {
        bool success = false;
        oBI500Approval = oBI500ApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, iRoleId);
        appUsers oAppUser = oappUsersHelper.objGetUserByUserID(oBI500Approval.m_iUserId);

        if (!string.IsNullOrEmpty(oBI500Approval.m_dDateReceived.ToString()))
        {
            sendMailBI500 eMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
            success = eMail.PendingRequestReminder(oBI500RequestHelper.objGetBrightIdeaById(lRequestId), oAppUser, oSessnx.getOnlineUser.structUserIdx);
            if (success)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Mail Successfully sent to " + oAppUser.m_sFullName);
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Reminder mail cannot be sent to " + oAppUser.m_sFullName + ", Request yet to get to his or her intray.");
        }

        return success;
    }
}