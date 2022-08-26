using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_SEPCiN_Approvers : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init(int iFacilityId)
    {
        try
        {
            //Load Planners
            List<FacilityPlanners> facilityPlaners = facility.lstGetFacilityPlannersByFacility(iFacilityId);
            foreach (FacilityPlanners facilityPlaner in facilityPlaners)
            {
                drpPlanner.Items.Add(new ListItem(facilityPlaner.eFacilityPlanner.m_sFullName, facilityPlaner.eFacilityPlanner.m_iUserId.ToString()));
            }

            //Load Functional Leads
            drpFunctionalLead.Items.Clear();
            drpFunctionalLead.Items.Add(new ListItem("--Select Functional Lead", "-1"));

            drpFunctionalLead.Attributes.Add("style", "color:RED; Font-Bold:True");
            drpFunctionalLead.Items.Add(new ListItem("****** Functional Lead ******"));
            List<appUsers> FunctionalLeads = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.FunctionalLead);
            foreach (appUsers FunctionalLead in FunctionalLeads)
            {
                drpFunctionalLead.Items.Add(new ListItem(FunctionalLead.m_sFullName, FunctionalLead.m_iUserId.ToString()));
            }

            //Load Activity Sponsors as Functional Leads
            drpFunctionalLead.Attributes.Add("style", "color:RED; Font-Bold:True");
            drpFunctionalLead.Items.Add(new ListItem("***** Activity Sponsors ******"));
            List<appUsers> ActivitySponsors = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.sponsor);
            foreach (appUsers ActivitySponsor in ActivitySponsors)
            {
                drpFunctionalLead.Attributes.Add("style", "color:RED; Font-Bold:False");
                drpFunctionalLead.Items.Add(new ListItem(ActivitySponsor.m_sFullName, ActivitySponsor.m_iUserId.ToString()));
            }

            //Load Superintendents as Functional Leads
            drpFunctionalLead.Items.Add(new ListItem("***** Superintendents ******"));
            List<appUsers> oSuperintendents = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.superintendent);
            foreach (appUsers oSuperintendent in oSuperintendents)
            {
                drpFunctionalLead.Items.Add(new ListItem(oSuperintendent.m_sFullName, oSuperintendent.m_iUserId.ToString()));
            }

            //Load Asset Managers
            drpAssetManager.Items.Clear();
            drpAssetManager.Items.Add(new ListItem("--Select Asset Manager", "-1"));
            List<appUsers> AssetManagers = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.AssetOperationsManager);
            foreach (appUsers AssetManager in AssetManagers)
            {
                drpAssetManager.Items.Add(new ListItem(AssetManager.m_sFullName, AssetManager.m_iUserId.ToString()));
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void initiateActivityId(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();
    }
    public void Retrieve_Data(long lActivityId)
    {
        try
        {
            ActivityIDHF.Value = lActivityId.ToString();
            ActivityInfo Activity = ActivityInfo.objGetActivityInfoByActivityId(lActivityId);

            //Load Planners
            List<FacilityPlanners> facilityPlaners = facility.lstGetFacilityPlannersByFacility(Activity.m_iFacilityId);
            foreach (FacilityPlanners facilityPlaner in facilityPlaners)
            {
                drpPlanner.Items.Add(new ListItem(facilityPlaner.eFacilityPlanner.m_sFullName, facilityPlaner.eFacilityPlanner.m_iUserId.ToString()));
            }

            //Load Functional Leads
            drpFunctionalLead.Items.Clear();
            drpFunctionalLead.Items.Add(new ListItem("--Select Functional Lead", "-1"));

            drpFunctionalLead.Attributes.Add("style", "color:RED; Font-Bold:True");
            drpFunctionalLead.Items.Add(new ListItem("****** Functional Lead ******"));
            List<appUsers> FunctionalLeads = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.FunctionalLead);
            foreach (appUsers FunctionalLead in FunctionalLeads)
            {
                drpFunctionalLead.Items.Add(new ListItem(FunctionalLead.m_sFullName, FunctionalLead.m_iUserId.ToString()));
            }

            //Load Activity Sponsors as Functional Leads
            drpFunctionalLead.Attributes.Add("style", "color:RED; Font-Bold:True");
            drpFunctionalLead.Items.Add(new ListItem("***** Activity Sponsors ******"));
            List<appUsers> ActivitySponsors = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.sponsor);
            foreach (appUsers ActivitySponsor in ActivitySponsors)
            {
                drpFunctionalLead.Attributes.Add("style", "color:RED; Font-Bold:False");
                drpFunctionalLead.Items.Add(new ListItem(ActivitySponsor.m_sFullName, ActivitySponsor.m_iUserId.ToString()));
            }

            //Load Superintendents as Functional Leads
            drpFunctionalLead.Items.Add(new ListItem("***** Superintendents ******"));
            List<appUsers> oSuperintendents = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.superintendent);
            foreach (appUsers oSuperintendent in oSuperintendents)
            {
                drpFunctionalLead.Items.Add(new ListItem(oSuperintendent.m_sFullName, oSuperintendent.m_iUserId.ToString()));
            }

            //Load Asset Managers
            drpAssetManager.Items.Clear();
            drpAssetManager.Items.Add(new ListItem("--Select Asset Manager", "-1"));
            List<appUsers> AssetManagers = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.AssetOperationsManager);
            foreach (appUsers AssetManager in AssetManagers)
            {
                drpAssetManager.Items.Add(new ListItem(AssetManager.m_sFullName, AssetManager.m_iUserId.ToString()));
            }

            List<PECApprover> approvers = PECApprover.lstGetPECApproversByActivityId(lActivityId);
            foreach (PECApprover approver in approvers)
            {
                if ((int)appUsersRoles.userRole.FunctionalLead == approver.m_iRole)
                {
                    drpFunctionalLead.SelectedValue = approver.m_iUserId.ToString();
                }
                else if ((int)appUsersRoles.userRole.planner == approver.m_iRole)
                {
                    drpPlanner.SelectedValue = approver.m_iUserId.ToString();
                }
                else if ((int)appUsersRoles.userRole.AssetOperationsManager == approver.m_iRole)
                {
                    drpAssetManager.SelectedValue = approver.m_iUserId.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    //private long GetHFControl()
    //{
    //    ASP.app_fieldvisit_usercontrol_sepcin_activityheader_ascx ActivityHeaderCntrl = (ASP.app_fieldvisit_usercontrol_sepcin_activityheader_ascx)Parent.FindControl("activityHeader1"); //(ASP.app_fieldvisit_usercontrol_sepcin_activityheader_ascx).FindControl("activityHeader1");
    //    return long.Parse(ActivityHeaderCntrl.activityInfoId.Value);
    //}

    protected void forwardButton_Click(object sender, EventArgs e)
    {
        try
        {
            long iActivityInfo = long.Parse(ActivityIDHF.Value);

            List<PECApprover> oPECApprover = PECApprover.lstGetPECApproversByActivityId(iActivityInfo);
            if (oPECApprover.Count == 1)
            {
                //Initiator assigns Request to to Functional Lead for comment and approval, and sends notification email 
                PECApprover.AssignPECRequestToApprover(iActivityInfo, int.Parse(drpFunctionalLead.SelectedValue), (int)appUsersRoles.userRole.FunctionalLead);

                //Initiator assigns Request to Asset Planner and sends notification email for approval
                PECApprover.AssignPECRequestToApprover(iActivityInfo, int.Parse(drpPlanner.SelectedValue), (int)appUsersRoles.userRole.planner);

                //Initiator assigns Request to Asset/Operations Manager. It is when Asset Planner approves that an email will go to Asset/Operations Manager for approval
                PECApprover.AssignPECRequestToApprover(iActivityInfo, int.Parse(drpAssetManager.SelectedValue), (int)appUsersRoles.userRole.AssetOperationsManager);
            }
            if (oPECApprover.Count > 1)
            {
                //i.e. some approvers have been assigned, thus update
                //Initiator assigns Request to to Functional Lead for comment and approval, and sends notification email 
                PECApprover.UpdateAssignedPECRequestToApprover(iActivityInfo, int.Parse(drpFunctionalLead.SelectedValue), (int)appUsersRoles.userRole.FunctionalLead);

                //Initiator assigns Request to Asset Planner and sends notification email for approval
                PECApprover.UpdateAssignedPECRequestToApprover(iActivityInfo, int.Parse(drpPlanner.SelectedValue), (int)appUsersRoles.userRole.planner);

                //Initiator assigns Request to Asset/Operations Manager. It is when Asset Planner approves that an email will go to Asset/Operations Manager for approval
                PECApprover.UpdateAssignedPECRequestToApprover(iActivityInfo, int.Parse(drpAssetManager.SelectedValue), (int)appUsersRoles.userRole.AssetOperationsManager);
            }
            //else
            //{
            //    //Initiator assigns Request to to Functional Lead for comment and approval, and sends notification email 
            //    PECApprover.AssignPECRequestToApprover(iActivityInfo, int.Parse(drpFunctionalLead.SelectedValue), (int)appUsersRoles.userRole.FunctionalLead);

            //    //Initiator assigns Request to Asset Planner and sends notification email for approval
            //    PECApprover.AssignPECRequestToApprover(iActivityInfo, int.Parse(drpPlanner.SelectedValue), (int)appUsersRoles.userRole.planner);

            //    //Initiator assigns Request to Asset/Operations Manager. It is when Asset Planner approves that an email will go to Asset/Operations Manager for approval
            //    PECApprover.AssignPECRequestToApprover(iActivityInfo, int.Parse(drpAssetManager.SelectedValue), (int)appUsersRoles.userRole.AssetOperationsManager);
            //}

            //Update PEC request table to show status change.
            //PECApprover.UpdatePECRequestStatus(iActivityInfoId, (int)Approval.apprStatusRpt.FunctionalLead);
            PECApprover.UpdatePECRequestStatus(iActivityInfo, (int)Approval.apprStatusRpt.Sponsor);

            structUserMailIdx eSender = new structUserMailIdx(oSessnx.getOnlineUser.structUserIdx);
            sendMailFieldVisit emailSender = new sendMailFieldVisit(eSender);

            //List<PECApprover> eActivitySponsor = PECApprover.lstGetPECApproversByActivityId(iActivityInfo);
            foreach (PECApprover ActivitySponsor in oPECApprover)
            {
                if (ActivitySponsor.m_iRole == (int)appUsersRoles.userRole.sponsor)
                {
                    appUsers oappUsers = appUsersHelper.objGetOnlineUserByUserId(ActivitySponsor.m_iUserId);
                    emailSender.PecInitiatorSendsMailToActivitySponsor(oappUsers.structUserIdx, iActivityInfo);
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        Response.Redirect("~/App/FieldVisit/Forms/PEC/MyPecRequests.aspx");
    }

    public Button MyForwardButton
    {
        get
        {
            return forwardButton;
        }
    }
}