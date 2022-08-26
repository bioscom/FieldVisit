using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Signoff_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.Approved);
            addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.NotApproved);
            addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.Callme);
            addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.Reschedule);

            if (Request.QueryString["ActivityId"] != null)
            {
                fieldVisitInformation1.InitPage(long.Parse(Request.QueryString["ActivityId"].ToString()));

                siteVisitApproval mySiteVisit = siteVisitApproval.objGetFieldVisitApprovalByApprovalId(long.Parse(Request.QueryString["ApprovalId"].ToString()));

                //1. retrieve the field visit item from the activity_approval table
                //drpStand.SelectedValue = mySiteVisit.m_iStand.ToString();
                CommentTextBox.Text = mySiteVisit.m_sComment;

                if ((int)appUsersRoles.userRole.sponsor == mySiteVisit.m_iRole)
                {
                    SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
                }
                else if ((int)appUsersRoles.userRole.planner == mySiteVisit.m_iRole)
                {
                    SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
                }
                else if ((int)appUsersRoles.userRole.superintendent == mySiteVisit.m_iRole)
                {
                    SupportLabel.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
                }
            }
        }
    }

    private void addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt eStatus)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = siteVisitApprovalStatus.StatusRptDesc(eStatus);
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
        try
        {
            if (Request.QueryString["ActivityId"] != null)
            {
                long iActivityId = long.Parse(Request.QueryString["ActivityId"].ToString());
                long iApprovalId = long.Parse(Request.QueryString["ApprovalId"].ToString());

                structUserMailIdx ePlanner = new structUserMailIdx();
                //structUserMailIdx eSponsor = new structUserMailIdx();

                List<structUserMailIdx> eSuperintendents = new List<structUserMailIdx>();
                List<SuperintendentFunctionalAcctUserDetails> functionalAccountUsers = new List<SuperintendentFunctionalAcctUserDetails>();

                fieldVisitDetails fieldRequestDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivityId);

                //Get Initiator Information
                appUsers sInitiator = appUsersHelper.objGetOnlineUserByUserId(fieldRequestDetails.eInitiator.m_iUserId);
                structUserMailIdx eInitiator = sInitiator.structUserIdx;

                List<siteVisitApproval> myFieldVisitRequestApprovalDetails = fieldRequestDetails.lstApprovalDetails;
                foreach (siteVisitApproval myFieldVisitRequestApprovalDetail in myFieldVisitRequestApprovalDetails)
                {
                    if (myFieldVisitRequestApprovalDetail.m_iRole == (int)appUsersRoles.userRole.planner)
                    {
                        //Get Planners Information. This is used to send mail to planner selected for the facility to be visited
                        appUsers sPlanner = appUsersHelper.objGetOnlineUserByUserId(myFieldVisitRequestApprovalDetail.m_iUserId);
                        ePlanner = sPlanner.structUserIdx;
                    }
                    //else if (myFieldVisitRequestApprovalDetail.m_iRole == (int)appUsersRoles.userRole.sponsor)
                    //{
                    //    //Get activity sponsor Information. This is used to send mail to activity sponsor selected for the facility to be visited
                    //    appUsers sSponsor = appUsersHelper.objGetOnlineUserByUserId(myFieldVisitRequestApprovalDetail.m_iUserId);
                    //    eSponsor = sSponsor.structUserIdx;
                    //}
                    else if (myFieldVisitRequestApprovalDetail.m_iRole == (int)appUsersRoles.userRole.superintendent)
                    {
                        //get the list of superintendents functional account users for the facility Superintendent
                        functionalAccountUsers = SuperintendentFunctionalAcctUser.lstGetSuperintendentFunctionalAcctUsersBySuperintendent(fieldRequestDetails.eFacility.eSuperintendent.m_iSuperintendentId);
                        foreach (SuperintendentFunctionalAcctUserDetails accountUser in functionalAccountUsers)
                        {
                            eSuperintendents.Add(new structUserMailIdx(accountUser.userName, accountUser.email, accountUser.fullName));
                        }
                    }
                }


                //Merge Planner and Initiator information in same list
                List<structUserMailIdx> eInitiatorPlanner = new List<structUserMailIdx>();
                eInitiatorPlanner.Add(eInitiator);
                eInitiatorPlanner.Add(ePlanner);

                //Merge Planner and Activity Sponsor information in same list
                //List<structUserMailIdx> ePlannerSponsor = new List<structUserMailIdx>();
                //ePlannerSponsor.Add(eSponsor);
                //ePlannerSponsor.Add(ePlanner);

                if (functionalAccountUsers.Count == 0)
                {
                    string mssg = "Sorry, there is no staff assigned to " + fieldRequestDetails.eFacility.eSuperintendent.m_sSuperintendent + " functional account. Please contact the Administrator to assign superintendents to this functional account.";
                    ajaxWebExtension.showJscriptAlert(Page, this, mssg);
                }
                else
                {
                    //appUsers approver = appUsers.objGetOnlineUserByUserId(oSessnx.getOnlineUser.m_iUserId);
                    sendMailFieldVisit ApproverSendMail = new sendMailFieldVisit(oSessnx.getOnlineUser.structUserIdx); //new structUserMailIdx(oSessnx.getOnlineUser.m_sUserName, oSessnx.getOnlineUser.m_sUserMail, oSessnx.getOnlineUser.m_iUserId.ToString()));
                    //if (oSessnx.getOnlineUser.m_iRoleId == (int)appUsersRoles.userRole.sponsor)
                    //{
                    //    bool success = siteVisitApproval.actionFieldVisitRequest(iApprovalId, CommentTextBox.Text, int.Parse(drpStand.SelectedValue), oSessnx.getOnlineUser.m_iUserId, (int)appUsersRoles.userRole.sponsor);
                    //    if (success == true)
                    //    {
                    //        if (int.Parse(drpStand.SelectedValue) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
                    //        {
                    //            //Update Field Visit request table to change status to awaiting Planner's approval.
                    //            siteVisitApproval.updateFieldVisitRequestStatus(iActivityId, (int)siteVisitApprovalStatus.apprStatusRpt.PlannerApprover);
                    //            //send mail to Activity Planner found for the selected Facility, that there is a request for approval and copy Initiator.
                    //            ApproverSendMail.SendsMailToNextApprover(ePlanner, eInitiator, iActivityId, false);
                    //        }
                    //        else
                    //        {
                    //            //Send mail to Initiator with the detailed comment why not approved.
                    //            ApproverSendMail.requestNotApproved(eInitiator, iActivityId, iApprovalId, CommentTextBox.Text, oSessnx.getOnlineUser);
                    //        }
                    //    }
                    //}
                    if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.planner)
                    {
                        bool success = siteVisitApproval.actionFieldVisitRequest(iApprovalId, CommentTextBox.Text, int.Parse(drpStand.SelectedValue), oSessnx.getOnlineUser.m_iUserId, (int)appUsersRoles.userRole.planner);
                        if (success == true)
                        {
                            if (int.Parse(drpStand.SelectedValue) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
                            {
                                //Update Field Visit request table to change to awaiting Superintendent's approval.
                                siteVisitApproval.updateFieldVisitRequestStatus(iActivityId, (int)siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval);
                                //send mail to superintendents that there is a request for approval copy Initiator.
                                ApproverSendMail.SendsMailToNextApprover(eSuperintendents, eInitiator, iActivityId, false);
                            }
                            else
                            {
                                //Send mail to Initiator with the detailed comment why not approved.
                                ApproverSendMail.requestNotApproved(eInitiator, iActivityId, iApprovalId, CommentTextBox.Text, oSessnx.getOnlineUser);
                            }
                            Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/Approvers/oPendingFieldVisitRequest.aspx");
                        }
                    }
                    else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.superintendent)
                    {
                        //In the case below, the USerId is the email address of the superintendent that owns the request to be actioned
                        //we may need to get th email address of the superintendent in question by ApprovalID and ActivityID
                        //siteVisitApproval superintendentEmail = siteVisitApproval.objGetFieldVisitApprovalByActivityApproval(iApprovalId, iActivityId);
                        bool success = siteVisitApproval.actionFieldVisitRequest(iApprovalId, CommentTextBox.Text, int.Parse(drpStand.SelectedValue), oSessnx.getOnlineUser.m_iUserId, (int)appUsersRoles.userRole.superintendent);
                        if (success == true)
                        {
                            List<structUserMailIdx> allPlanners = getAllFacilityPlanners();
                            
                            if (int.Parse(drpStand.SelectedValue) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
                            {
                                //Update Field Visit request table to change to request approved.
                                siteVisitApproval.updateFieldVisitRequestStatus(iActivityId, (int)siteVisitApprovalStatus.apprStatusRpt.Approved);
                                //Send mail to Initiator, and copy all Planners in the facility and Activity Sponsor
                                ApproverSendMail.requestApproved(eInitiator, allPlanners, iActivityId, oSessnx.getOnlineUser.m_iUserId);
                            }
                            else
                            {
                                //Send mail to Initiator, and copy Planner, Sponsor and other Superintendents account users with the detailed comment why not approved.
                                ApproverSendMail.requestNotApproved(eInitiator, allPlanners, iActivityId, iApprovalId, CommentTextBox.Text, oSessnx.getOnlineUser);
                            }
                        }
                        Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/Approvers/SuperintendentPendingRequests.aspx");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    /// <summary>
    /// This is a new request that requires all the facility leaders to be aware of the approval of field visit by the Superintendent. Code Review October 15, 2014.
    /// </summary>
    /// <returns></returns>
    private List<structUserMailIdx> getAllFacilityPlanners()
    {
        fieldVisitDetails visitDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(long.Parse(Request.QueryString["ActivityId"].ToString()));
        List<structUserMailIdx> allPlanners = new List<structUserMailIdx>();
        List<FacilityPlanners> facilityPlaners = facility.lstGetFacilityPlannersByFacility(visitDetails.m_iFacilityId);
        foreach (FacilityPlanners facilityPlaner in facilityPlaners)
        {
            allPlanners.Add(facilityPlaner.eFacilityPlanner.structUserIdx);
        }

        return allPlanners;
    }
}