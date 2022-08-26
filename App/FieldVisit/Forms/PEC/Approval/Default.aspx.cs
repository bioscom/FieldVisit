using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_SEPCiN_Approval_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addRoleToDropDown(Approval.apprStatusRpt.Approved);
            addRoleToDropDown(Approval.apprStatusRpt.NotApproved);
            addRoleToDropDown(Approval.apprStatusRpt.Callme);
            addRoleToDropDown(Approval.apprStatusRpt.Reschedule);

            if (Request.QueryString["ActivityInfoId"] != null)
            {
                PecRequestInfo1.Init_Page(int.Parse(Request.QueryString["ActivityInfoId"].ToString()));
                PECApprover myPEC = PECApprover.objGetPECApproverByApprovalId(int.Parse(Request.QueryString["ApprovalId"].ToString()));

                drpStand.SelectedValue = myPEC.m_iStand.ToString();
                CommentTextBox.Text = myPEC.m_sComment;

                if ((int)appUsersRoles.userRole.sponsor == myPEC.m_iRole)
                {
                    SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
                }
                else if ((int)appUsersRoles.userRole.planner == myPEC.m_iRole)
                {
                    SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
                }
                else if ((int)appUsersRoles.userRole.FunctionalLead == myPEC.m_iRole)
                {
                    SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
                }
                else if ((int)appUsersRoles.userRole.AssetOperationsManager == myPEC.m_iRole)
                {
                    SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
                }
            }
        }
    }

    private void addRoleToDropDown(Approval.apprStatusRpt eStatus)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = Approval.StatusRptDesc(eStatus);
            oItem.Value = ((int)eStatus).ToString();
            drpStand.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ActivityInfoId"] != null)
        {
            long iActivityId = long.Parse(Request.QueryString["ActivityInfoId"].ToString());
            long iApprovalId = long.Parse(Request.QueryString["ApprovalId"].ToString());

            //Get the Activity Request in question
            ActivityInfo sActivityInfo = ActivityInfo.objGetActivityInfoByActivityId(iActivityId);

            //Get the List of all the approvers for this Activity Request
            List<PECApprover> myPECRequestApprovers = sActivityInfo.lstApprovers;

            structUserMailIdx eInitiator = new structUserMailIdx(sActivityInfo.eInitiator.m_sUserName, sActivityInfo.eInitiator.m_sUserMail, sActivityInfo.eInitiator.m_sFullName);
            structUserMailIdx eSponsor = new structUserMailIdx();
            structUserMailIdx ePlanner = new structUserMailIdx();
            structUserMailIdx eFunctionalLead = new structUserMailIdx();
            structUserMailIdx eAssetOperationsManager = new structUserMailIdx();

            foreach (PECApprover myPECRequestApprover in myPECRequestApprovers)
            {
                if (myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.sponsor)
                {
                    //Get activity sponsor Information.
                    appUsers sSponsor = appUsersHelper.objGetOnlineUserByUserId(myPECRequestApprover.m_iUserId);
                    eSponsor = new structUserMailIdx(sSponsor.m_sUserName, sSponsor.m_sUserMail, sSponsor.m_sFullName);
                }
                else if (myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.planner)
                {
                    //Get Planners Information.
                    appUsers sPlanner = appUsersHelper.objGetOnlineUserByUserId(myPECRequestApprover.m_iUserId);
                    ePlanner = new structUserMailIdx(sPlanner.m_sUserName, sPlanner.m_sUserMail, sPlanner.m_sFullName);
                }
                else if (myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.FunctionalLead)
                {
                    //Get Functional Lead Information
                    appUsers sFunctionalLead = appUsersHelper.objGetOnlineUserByUserId(myPECRequestApprover.m_iUserId);
                    eFunctionalLead = new structUserMailIdx(sFunctionalLead.m_sUserName, sFunctionalLead.m_sUserMail, sFunctionalLead.m_sFullName);
                }
                else if (myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.AssetOperationsManager)
                {
                    //Get Asset Manager Information
                    appUsers sAssetOperationsManager = appUsersHelper.objGetOnlineUserByUserId(myPECRequestApprover.m_iUserId);
                    eAssetOperationsManager = new structUserMailIdx(sAssetOperationsManager.m_sUserName, sAssetOperationsManager.m_sUserMail, sAssetOperationsManager.m_sFullName);
                }
            }

            List<structUserMailIdx> eInitiatorxx = new List<structUserMailIdx>();
            eInitiatorxx.Add(eInitiator);

            List<structUserMailIdx> eInitiatorSponsor = new List<structUserMailIdx>();
            eInitiatorSponsor.Add(eInitiator);
            eInitiatorSponsor.Add(eSponsor);

            List<structUserMailIdx> eInitiatorSponsorFunctionalLead = new List<structUserMailIdx>();
            eInitiatorSponsorFunctionalLead.Add(eInitiator);
            eInitiatorSponsorFunctionalLead.Add(eSponsor);
            eInitiatorSponsorFunctionalLead.Add(eFunctionalLead);

            List<structUserMailIdx> eSponsorFunctionalLead = new List<structUserMailIdx>();
            eSponsorFunctionalLead.Add(eSponsor);
            eSponsorFunctionalLead.Add(eFunctionalLead);

            List<structUserMailIdx> eSponsorFunctionalLeadPlanner = new List<structUserMailIdx>();
            eSponsorFunctionalLeadPlanner.Add(eSponsor);
            eSponsorFunctionalLeadPlanner.Add(eFunctionalLead);
            eSponsorFunctionalLeadPlanner.Add(ePlanner);

            appUsers approver = appUsersHelper.objGetOnlineUserByUserId(oSessnx.getOnlineUser.m_iUserId);
            sendMailFieldVisit ApproverSendMail = new sendMailFieldVisit(oSessnx.getOnlineUser.structUserIdx); //new structUserMailIdx(oSessnx.getOnlineUser.m_sUserName, oSessnx.getOnlineUser.m_sUserMail, oSessnx.getOnlineUser.m_iUserId.ToString()));

            bool success = PECApprover.ActionPECRequest(iApprovalId, CommentTextBox.Text, int.Parse(drpStand.SelectedValue));
            if (success == true)
            {
                foreach (PECApprover myPECRequestApprover in myPECRequestApprovers)
                {
                    if ((myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.sponsor) && (myPECRequestApprover.m_iUserId == oSessnx.getOnlineUser.m_iUserId))
                    {
                        if (int.Parse(drpStand.SelectedValue) == (int)Approval.apprStatusRpt.Approved)
                        {
                            //Update activity status to Functional Lead and send mail to functional Lead that there is a request for approval and copy Initiator.
                            PECApprover.UpdatePECRequestStatus(iActivityId, (int)Approval.apprStatusRpt.FunctionalLead);
                            ApproverSendMail.SendsMailToNextPECApprover(eFunctionalLead, eInitiator, iActivityId);
                        }
                        else
                        {
                            //Send mail to Initiator with the detailed comment why not approved.
                            ApproverSendMail.PECRequestNotApproved(eInitiator, iActivityId, iApprovalId, CommentTextBox.Text, approver);
                        }
                    }
                    else if ((myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.FunctionalLead) && (myPECRequestApprover.m_iUserId == oSessnx.getOnlineUser.m_iUserId))
                    {
                        if (int.Parse(drpStand.SelectedValue) == (int)Approval.apprStatusRpt.Approved)
                        {
                            //Update activity status to Asset Planner and send mail to Asset Planner that there is a request for approval and copy Initiator and Sponsor.
                            PECApprover.UpdatePECRequestStatus(iActivityId, (int)Approval.apprStatusRpt.AssetPlanner);
                            ApproverSendMail.SendsMailToNextPECApprover(ePlanner, eInitiatorSponsor, iActivityId);
                        }
                        else
                        {
                            //Send mail to Initiator with the detailed comment why not approved and copy Sponsor.
                            ApproverSendMail.PECRequestNotApproved(eInitiator, eSponsor, iActivityId, iApprovalId, CommentTextBox.Text, approver);
                        }
                    }
                    else if ((myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.planner) && (myPECRequestApprover.m_iUserId == oSessnx.getOnlineUser.m_iUserId))
                    {
                        if (int.Parse(drpStand.SelectedValue) == (int)Approval.apprStatusRpt.Approved)
                        {
                            //Update activity status to Asset Operation Manager and send mail to Asset Operation Manager that there is a request for approval 
                            //and copy Initiator and Sponsor and Functional Lead.
                            PECApprover.UpdatePECRequestStatus(iActivityId, (int)Approval.apprStatusRpt.AssetOperationsManager);
                            ApproverSendMail.SendsMailToNextPECApprover(eAssetOperationsManager, eInitiatorSponsorFunctionalLead, iActivityId);
                        }
                        else
                        {
                            //Send mail to Initiator with the detailed comment why not approved and copy sponsor and functional lead.
                            ApproverSendMail.PECRequestNotApproved(eInitiator, eSponsorFunctionalLead, iActivityId, iApprovalId, CommentTextBox.Text, approver);
                        }
                    }
                    else if ((myPECRequestApprover.m_iRole == (int)appUsersRoles.userRole.AssetOperationsManager) && (myPECRequestApprover.m_iUserId == oSessnx.getOnlineUser.m_iUserId))
                    {
                        if (int.Parse(drpStand.SelectedValue) == (int)Approval.apprStatusRpt.Approved)
                        {
                            //Update activity status to Approved and send mail to Initiator that the request has been approved and copy Sponsor, Functional Lead and Asset Planner.
                            PECApprover.UpdatePECRequestStatus(iActivityId, (int)Approval.apprStatusRpt.Approved);
                            ApproverSendMail.PECRequestApproved(eInitiator, eSponsorFunctionalLeadPlanner, iActivityId, oSessnx.getOnlineUser.m_iUserId);
                        }
                        else
                        {
                            //Send mail to Initiator with the detailed comment why not approved and copy Sponsor FunctionalLead Planner.
                            ApproverSendMail.PECRequestNotApproved(eInitiator, eSponsorFunctionalLeadPlanner, iActivityId, iApprovalId, CommentTextBox.Text, approver);
                        }
                    }
                }
            }
            Response.Redirect("~/App/FieldVisit/Forms/PEC/Approval/Pending.aspx");
        }
    }
}