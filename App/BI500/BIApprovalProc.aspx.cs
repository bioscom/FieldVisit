using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class BIApprovalProc : aspnetPage
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    bool bRet = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["RequestId"] != null)
            {
                long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                oRequestDetails1.Init_Control(oBI500RequestHelper.objGetBrightIdeaById(lRequestId));

                if (!IsPostBack)
                {
                    List<BI500Approval> oBI500Approvals = oBI500ApprovalHelper.lstGetBIApprovalbyRequestId(lRequestId);
                    foreach (BI500Approval oBI500Approval in oBI500Approvals)
                    {
                        if (((oBI500Approval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.CorporateViewer) || (oBI500Approval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.BusinessImprovementTeam) || (oBI500Approval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.focalPoint)) && ((oBI500Approval.m_iStand == (int)BIRequestStatus.RequestStatusRpt.iDefault) || ((oBI500Approval.m_iStand == (int)BIRequestStatus.RequestStatusRpt.iDefault))))
                        {
                            rdbSupport.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.Supported), ((int)BIRequestStatus.RequestStatusRpt.Supported).ToString()));
                            rdbSupport.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.NotSupported), ((int)BIRequestStatus.RequestStatusRpt.NotSupported).ToString()));

                            approverLabel.Text = "Business Improvement/Lean Team Reviewer";
                            getComment(oBI500Approval);
                            break;
                        }
                        else if ((oBI500Approval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.champion) && (oBI500Approval.m_iStand == (int)BIRequestStatus.RequestStatusRpt.iDefault))
                        {
                            rdbSupport.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.Supported), ((int)BIRequestStatus.RequestStatusRpt.Supported).ToString()));
                            rdbSupport.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.NotSupported), ((int)BIRequestStatus.RequestStatusRpt.NotSupported).ToString()));

                            approverLabel.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oBI500Approval.m_iRoleIdBI);
                            getComment(oBI500Approval);
                            break;
                        }
                        else
                        {
                            if (oBI500Approval.m_iUserId == oSessnx.getOnlineUser.m_iUserId)
                            {
                                if (oBI500Approval.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.sponsor)
                                {
                                    rdbSupport.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.Approved), ((int)BIRequestStatus.RequestStatusRpt.Approved).ToString()));
                                    rdbSupport.Items.Add(new ListItem(BIRequestStatus.RequestStatusRptDesc(BIRequestStatus.RequestStatusRpt.NotApproved), ((int)BIRequestStatus.RequestStatusRpt.NotApproved).ToString()));
                                }

                                approverLabel.Text = appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)oBI500Approval.m_iRoleIdBI);
                                txtComment.Text = oBI500Approval.m_sComments;

                                getComment(oBI500Approval);

                                break;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void closeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/BI500/ApprovalReview.aspx");
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            bool ProjChampionSupported = false;
            bool BITeamSupported = false;

            long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
            int iStand = int.Parse(rdbSupport.SelectedValue);
            CostReductionRequest oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

            List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
            //Get Initiator
            oCopy.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).structUserIdx);
            oCopy.Add(oSessnx.getOnlineUser.structUserIdx);

            //Check if Project Champion has approved
            int iChampionStand = oBI500ApprovalHelper.objGetBIApprovalbyRequestRoleId(lRequestId, (int)appUsersRolesBI500.userRole.champion).m_iStand;
            if (iChampionStand == (int)BIRequestStatus.RequestStatusRpt.Supported) ProjChampionSupported = true;

            //Check if the Business Improvement/Lean Team has supported
            int iBITeamStand = oBI500ApprovalHelper.objGetBIApprovalbyRequestRoleId(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam).m_iStand;
            if (iBITeamStand == (int)BIRequestStatus.RequestStatusRpt.Supported) BITeamSupported = true;

            if (oBI500Request.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval)
            {
                //Check the Login User's approval role against the BI
                //int iMyRole = oBI500ApprovalHelper.objGetBIApprovalbyRequestRoleId(lRequestId, (int)appUsersRolesBI500.userRole.champion).m_iStand;

                if ((ProjChampionSupported == false) && (oSessnx.getOnlineUser.m_iUserId == oBI500ApprovalHelper.objGetBIApprovalbyRequestRoleId(lRequestId, (int)appUsersRolesBI500.userRole.champion).m_iUserId))
                {
                    //if the login user is the project champion, then support and handover to the Business Improvement Team
                    Support(lRequestId, (int)appUsersRolesBI500.userRole.champion, iStand, oBI500Request, oCopy, (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport);
                    oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport);
                }
                else if (BITeamSupported == false)
                {
                    Support(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam, iStand, oBI500Request, oCopy, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport);
                    oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport);
                }
            }

            else if (oBI500Request.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport)
            {
                //Project Champion has approved, handover to Project Sponsor 
                Support(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam, iStand, oBI500Request, oCopy, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval);
                oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval);
            }
            else if (oBI500Request.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport)
            {
                //BI/Lean Team rep. has approved, handover to Project Sponsor
                Support(lRequestId, (int)appUsersRolesBI500.userRole.champion, iStand, oBI500Request, oCopy, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval);
                oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval);
            }
            else if (oBI500Request.iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval)
            {
                Approved(lRequestId, (int)appUsersRolesBI500.userRole.sponsor, iStand, oBI500Request, oCopy, (int)BIRequestStatus.RequestStatusRpt.Approved);
                oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.Approved);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        Response.Redirect("~/App/BI500/ApprovalReview.aspx");
    }

    private void Approved(long lRequestId, int iRoleId, int iStand, CostReductionRequest oBI500Request, List<structUserMailIdx> oCopy, int iStatus)
    {
        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        if (int.Parse(rdbSupport.SelectedValue) == (int)BIRequestStatus.RequestStatusRpt.Approved)
        {
            bRet = oBI500ApprovalHelper.ActionBIRequest(lRequestId, iRoleId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);
            //TODO: Not sure if I am going to use Audit Trail for this application, but keep it there.
            //oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text);
            //Update Request Status

            oBI500RequestHelper.UpdateRequestStatus(lRequestId, iStatus);
            oSendMail.RequestApproved(oBI500Request, oSessnx.getOnlineUser, oCopy);
        }
        else if (int.Parse(rdbSupport.SelectedValue) == (int)BIRequestStatus.RequestStatusRpt.NotApproved)
        {
            if (String.IsNullOrEmpty(txtComment.Text))
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Please enter reason why not approved.");
            }
            else
            {
                //Action Request
                bRet = oBI500ApprovalHelper.ActionBIRequest(lRequestId, iRoleId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);
                //TODO: Not sure if I am going to use Audit Trail for this application, but keep it there.
                //oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text);
                oSendMail.RequestNotSupportedApproved(oBI500Request, oSessnx.getOnlineUser, txtComment.Text, oCopy);
            }
        }

        ////TODO: Please complete this aspect
        //bool bReviewed = true;
        //List<BI500Approval> oBI500Approvals = oBI500ApprovalHelper.lstGetBIApprovalbyRequestId(lRequestId);
        //foreach (BI500Approval oBI500Approval in oBI500Approvals)
        //{
        //    if (oBI500Approval.m_iStand == (int)BIRequestStatus.RequestStatusRpt.iDefault)
        //    {
        //        bReviewed = false;
        //        break;
        //    }
        //}

        //if (bReviewed)
        //{
        //    //Assign the request to the Project Sponsor into the RequestApproval(Workflow) Table, when it has been reviewed by both the supervisor and BI/Lean Team
        //    bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRoles.userRole.sponsor, oBI500Request.m_iProjectSponsorUserId);
            
        //    //Then send email to the Manager
        //    List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
        //    List<structUserMailIdx> oCopied = new List<structUserMailIdx>();

        //    oReceivers.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.m_iProjectSponsorUserId).structUserIdx); //Staff Manager
        //    oCopied.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.m_iUserId).structUserIdx);  //Initiator (Staff)
        //    oCopied.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.m_iProjectChampionUserId).structUserIdx); //Staff Supervisor
        //    oCopied.Add(oSessnx.getOnlineUser.structUserIdx);

        //    oSendMail.ForwardRequestForSupportApproval(oBI500Request, oReceivers, oCopied);
        //}
    }

    private void Support(long lRequestId, int iRoleId, int iStand, CostReductionRequest oBI500Request, List<structUserMailIdx> oCopy, int iStatus)
    {
        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        if (int.Parse(rdbSupport.SelectedValue) == (int)BIRequestStatus.RequestStatusRpt.Supported)
        {
            bRet = oBI500ApprovalHelper.ActionBIRequest(lRequestId, iRoleId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);

            if (bRet) ajaxWebExtension.showJscriptAlert(Page, this, "Successful");
            else ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful");

            bRet = AllSupportProcessCompleted(lRequestId, oBI500Request, iStatus);
            if (!bRet)
                oSendMail.RequestSupported(oBI500Request, oSessnx.getOnlineUser, oCopy);
        }
        else if (int.Parse(rdbSupport.SelectedValue) == (int)BIRequestStatus.RequestStatusRpt.NotSupported)
        {
            if (String.IsNullOrEmpty(txtComment.Text))
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Please enter reason why not supported.");
            }
            else
            {
                //Action Request
                bRet = oBI500ApprovalHelper.ActionBIRequest(lRequestId, iRoleId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);
                //TODO: Not sure if I am going to use Audit Trail for this application, but keep it there.
                //oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text);
                oSendMail.RequestNotSupportedApproved(oBI500Request, oSessnx.getOnlineUser, txtComment.Text, oCopy);
            }
        }       
    }

    private bool AllSupportProcessCompleted(long lRequestId, CostReductionRequest oBI500Request, int iStatus)
    {
        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        bool bRet = true;
        List<BI500Approval> oBI500Approvals = oBI500ApprovalHelper.lstGetBIApprovalbyRequestId(lRequestId);
        foreach (BI500Approval oBI500Approval in oBI500Approvals)
        {
            if (oBI500Approval.m_iStand == (int)BIRequestStatus.RequestStatusRpt.iDefault)
            {
                bRet = false;
                break;
            }
        }

        if (bRet)
        {
            //Assign the request to the Project Sponsor into the RequestApproval(Workflow) Table, when it has been reviewed by both the supervisor and BI/Lean Team
            bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.sponsor, oBI500Request.iProjectSponsorUserId);
            oBI500RequestHelper.UpdateRequestStatus(lRequestId, iStatus);

            //Then send email to the Manager
            List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
            List<structUserMailIdx> oCopied = new List<structUserMailIdx>();

            oReceivers.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectSponsorUserId).structUserIdx); //Staff Manager
            oCopied.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).structUserIdx);  //Initiator (Staff)
            oCopied.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectChampionUserId).structUserIdx); //Staff Supervisor
            oCopied.Add(oSessnx.getOnlineUser.structUserIdx);

            oSendMail.ForwardRequestForSupportApproval(oBI500Request, oReceivers, oCopied);
        }
        return bRet;
    }

    private void getComment(BI500Approval oBI500Approval)
    {
        txtComment.Text = oBI500Approval.m_sComments;
        foreach (ListItem li in rdbSupport.Items)
        {
            if (int.Parse(li.Value) == oBI500Approval.m_iStand)
            {
                li.Selected = true;
            }
        }
    }
}