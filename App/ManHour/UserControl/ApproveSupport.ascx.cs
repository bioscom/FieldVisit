using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_ApproveSupport : aspnetUserControl
{
    InitiativeApproval oInitiativeApprovers = new InitiativeApproval();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control(long lInitiativeId, long lApprovalId)
    {
        lInitiativeHF.Value = lInitiativeId.ToString();
        lApprovalHF.Value = lApprovalId.ToString();

        addRoleToDropDown(Approval.apprStatusRpt.Approved);
        addRoleToDropDown(Approval.apprStatusRpt.NotApproved);
        //addRoleToDropDown(Approval.apprStatusRpt.Callme);
        //addRoleToDropDown(Approval.apprStatusRpt.Reschedule);

        InitiativeApproval oInitiativeApproval = new InitiativeApproval();
        InitiativeApproval myPendingBI = oInitiativeApproval.objGetBIApproverByApprovalId(lApprovalId);

        drpStand.SelectedValue = myPendingBI.m_iStand.ToString();
        CommentTextBox.Text = myPendingBI.m_sComment;

        if (myPendingBI.m_iStand == (int)Approval.apprStatusRpt.Approved)
        {
            submitButton.Enabled = false;
            drpStand.Enabled = false;
            CommentTextBox.Enabled = false;
        }

        if ((int)appUsersRoles.userRole.sponsor == myPendingBI.m_iRole)
        {
            SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
        }
        else if ((int)appUsersRoles.userRole.AssetOperationsManager == myPendingBI.m_iRole)
        {
            SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
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
        appUsers oSponsor = new appUsers(); appUsers oInitiator = new appUsers();
        List<appUsers> oAssetManagers = new List<appUsers>();
        List<structUserMailIdx> eAssetManagers = new List<structUserMailIdx>();
        List<appUsers> oFunctionalLeads = new List<appUsers>(); 

        try
        {
            Initiative thisInitiative = Initiative.objGetInitiativeById(long.Parse(lInitiativeHF.Value));

            oInitiator = appUsersHelper.objGetOnlineUserByUserId(thisInitiative.m_iUserId);

            List<InitiativeApproval> oApprovalDetails = oInitiativeApprovers.lstGetApproversByInitiativeId(long.Parse(lInitiativeHF.Value));
            foreach (InitiativeApproval oApprovalDetail in oApprovalDetails)
            {
                if (oApprovalDetail.m_iRole == (int)appUsersRoles.userRole.sponsor)
                { oSponsor = appUsersHelper.objGetOnlineUserByUserId(oApprovalDetail.m_iUserId); }

                else if (oApprovalDetail.m_iRole == (int)appUsersRoles.userRole.FunctionalLead)
                { oFunctionalLeads.Add(appUsersHelper.objGetOnlineUserByUserId(oApprovalDetail.m_iUserId)); }

                else if (oApprovalDetail.m_iRole == (int)appUsersRoles.userRole.AssetOperationsManager)
                { oAssetManagers.Add(appUsersHelper.objGetOnlineUserByUserId(oApprovalDetail.m_iUserId)); }
            }

            foreach(appUsers oAssetManager in oAssetManagers)
            {
                eAssetManagers.Add(oAssetManager.structUserIdx);
            }

            //Get the current approver's details
            appUsers oThisApprover = appUsersHelper.objGetOnlineUserByUserId(oSessnx.getOnlineUser.m_iUserId);
            sendMailManHour oThisApproverSendMail = new sendMailManHour(oThisApprover.structUserIdx);

            foreach (InitiativeApproval oApprovalDetail in oApprovalDetails)
            {
                if (oApprovalDetail.m_iUserId == oSessnx.getOnlineUser.m_iUserId)
                {
                    if (oApprovalDetail.m_iRole == (int)appUsersRoles.userRole.sponsor)
                    {
                        bool success = oInitiativeApprovers.ActionInitiativeRequest(long.Parse(lApprovalHF.Value), CommentTextBox.Text, int.Parse(drpStand.SelectedValue));
                        if (success == true)
                        {
                            if (int.Parse(drpStand.SelectedValue) == (int)Approval.apprStatusRpt.Approved)
                            {
                                //Update Business Initiative table to change status to awaiting Asset Manager's approval.
                                oInitiativeApprovers.UpdateInitiativeStatus(long.Parse(lInitiativeHF.Value), (int)Approval.apprStatusRpt.AssetOperationsManager);
                                //send mail to Asset Managers and copy Initiator.
                                oThisApproverSendMail.ActivitySponsorSendsMailToAssetManagers(oSessnx.getOnlineUser, eAssetManagers, oAssetManagers, long.Parse(lInitiativeHF.Value));
                                ajaxWebExtension.showJscriptAlert(Page, this, "Initiative approved successfully, notification sent to all Asset Managers and Initiative Initiator copied.");
                            }
                            else
                            {
                                //Send mail to Initiator with the detailed comment why not approved.
                                oThisApproverSendMail.requestNotApproved(oInitiator.structUserIdx, long.Parse(lInitiativeHF.Value), long.Parse(lApprovalHF.Value), CommentTextBox.Text, oSessnx.getOnlineUser);
                            }
                        }
                    }
                    else if (oApprovalDetail.m_iRole == (int)appUsersRoles.userRole.FunctionalLead)
                    {
                        bool success = oInitiativeApprovers.ActionInitiativeRequest(long.Parse(lApprovalHF.Value), CommentTextBox.Text, int.Parse(drpStand.SelectedValue));
                        if (success == true)
                        {
                            if (int.Parse(drpStand.SelectedValue) == (int)Approval.apprStatusRpt.Approved)
                            {
                                //Update Business Initiative table to change status to awaiting Asset Manager's approval.
                                //oInitiativeApprovers.UpdateInitiativeStatus(long.Parse(lInitiativeHF.Value), (int)Approval.apprStatusRpt.AssetOperationsManager);
                                //send mail to Asset Managers and copy Initiator.
                                oThisApproverSendMail.ActivitySponsorSendsMailToAssetManagers(oSessnx.getOnlineUser, eAssetManagers, oAssetManagers, long.Parse(lInitiativeHF.Value));
                                ajaxWebExtension.showJscriptAlert(Page, this, "Initiative approved successfully, notification sent to all Asset Managers and Initiative Initiator copied.");
                            }
                            else
                            {
                                //Send mail to Initiator with the detailed comment why not approved.
                                oThisApproverSendMail.requestNotApproved(oInitiator.structUserIdx, long.Parse(lInitiativeHF.Value), long.Parse(lApprovalHF.Value), CommentTextBox.Text, oSessnx.getOnlineUser);
                            }
                        }
                    }
                    else if (oApprovalDetail.m_iRole == (int)appUsersRoles.userRole.AssetOperationsManager)
                    {
                        bool success = oInitiativeApprovers.ActionInitiativeRequest(long.Parse(lApprovalHF.Value), CommentTextBox.Text, int.Parse(drpStand.SelectedValue));
                        if (success == true)
                        {
                            if (int.Parse(drpStand.SelectedValue) == (int)Approval.apprStatusRpt.Approved)
                            {
                                //Check if all Asset Managers have approved, then
                                //Update Business Initiative table to change status to approved.
                                if (bAllAssetManagersHaveApproved())
                                {
                                    oInitiativeApprovers.UpdateInitiativeStatus(long.Parse(lInitiativeHF.Value), (int)Approval.apprStatusRpt.Approved);
                                }
                                //Send mail to Initiator, and copy Activity Sponsor.
                                oThisApproverSendMail.requestApproved(oInitiator.structUserIdx, oSponsor.structUserIdx, long.Parse(lInitiativeHF.Value), long.Parse(lApprovalHF.Value), oSessnx.getOnlineUser.m_iUserId);
                                ajaxWebExtension.showJscriptAlert(Page, this, "Initiative approved successfully!!! Notification sent to Initiative Initiator, all reviewers and approvers copied.");
                            }
                            else
                            {
                                //Send mail to Initiator, and copy Activity Sponsor with the detailed comment why not approved.
                                oThisApproverSendMail.requestNotApproved(oInitiator.structUserIdx, oSponsor.structUserIdx, long.Parse(lInitiativeHF.Value), long.Parse(lApprovalHF.Value), CommentTextBox.Text, oSessnx.getOnlineUser);
                            }
                        }
                    }
                    //Disable the button to disallow multiple emails sent.
                    submitButton.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private bool bAllAssetManagersHaveApproved()
    {
        List<InitiativeApproval> oApprovalDetails = oInitiativeApprovers.lstGetApproversByRoleInitiativeId(long.Parse(lInitiativeHF.Value), (int) appUsersRoles.userRole.AssetOperationsManager);
        bool bRet = false;
        foreach (InitiativeApproval oApprovalDetail in oApprovalDetails)
        {
            if (oApprovalDetail.m_iStand == (int)Approval.apprStatusRpt.Approved)
            {
                bRet = true;
            }
            else
            {
                bRet = false;
                break;
            }
        }

        return bRet;
    }
}


 //else if (oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.planner)
 //           {
 //               bool success = siteVisitApproval.actionFieldVisitRequest(iApprovalId, CommentTextBox.Text, int.Parse(drpStand.SelectedValue), oSessnx.getOnlineUser.m_iUserId, (int)appUsersRoles.userRole.planner);
 //               if (success == true)
 //               {
 //                   if (int.Parse(drpStand.SelectedValue) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
 //                   {
 //                       //Update Field Visit request table to change to awaiting Superintendent's approval.
 //                       siteVisitApproval.updateFieldVisitRequestStatus(iActivityId, (int)siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval);
 //                       //send mail to superintendents that there is a request for approval copy Initiator.
 //                       ApproverSendMail.SendsMailToNextApprover(eSuperintendents, eInitiator, iActivityId);
 //                   }
 //                   else
 //                   {
 //                       //Send mail to Initiator and copy Activity Sponsor with the detailed comment why not approved.
 //                       ApproverSendMail.requestNotApproved(eInitiator, eSponsor, iActivityId, iApprovalId, CommentTextBox.Text, approver);
 //                   }
 //               }
 //           }