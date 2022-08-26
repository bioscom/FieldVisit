using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Approvers : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitValues()
    {
        //lInitiativeHF.Value = lInitiativeId.ToString();
        try
        {
            ////Load Activity Sponsors
            //drpSponsor.Items.Clear();
            //drpSponsor.Items.Add(new ListItem("--Select Activity Sponsor", "-1"));
            ////List<appUsers> ActivitySponsors = appUsersHelper.lstGetApproversByRole((int)appUsersRoles.userRole.sponsor);
            //List<appUsers> ActivitySponsors = appUsersHelper.lstGetUsers();
            //foreach (appUsers ActivitySponsor in ActivitySponsors)
            //{
            //    drpSponsor.Items.Add(new ListItem(ActivitySponsor.m_sFullName, ActivitySponsor.m_iUserId.ToString()));
            //}

            //ddlSponsor.initUserInfo("To locate user quickly, click on search botton.", 250);

            List<appUsers> AssetManagers = appUsersHelper.LstGetInitMgtApproversByRole((int)AppUsersRolesInitMgt.UserRole.AssetOperationsManager);
            foreach (appUsers AssetManager in AssetManagers)
            {
                assetMgrCkbLst.Items.Add(new ListItem(AssetManager.m_sFullName, AssetManager.m_iUserId.ToString()));
            }

            List<appUsers> FunctionalLeads = appUsersHelper.LstGetInitMgtApproversByRole((int)AppUsersRolesInitMgt.UserRole.FunctionalLead);
            foreach (appUsers FunctionalLead in FunctionalLeads)
            {
                funcMgrCkbLst.Items.Add(new ListItem(FunctionalLead.m_sFullName, FunctionalLead.m_iUserId.ToString()));
            }

            //Retrieve_Data(lInitiativeId);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void Init_Page(long lInitiativeId)
    {
        lInitiativeHF.Value = lInitiativeId.ToString();
        InitValues();
        Retrieve_Data(lInitiativeId);
    }

    private void Retrieve_Data(long lInitiativeId)
    {
        try
        {
            InitiativeApproval approver = new InitiativeApproval();
            List<InitiativeApproval> InitiativeApprovals = approver.lstGetApproversByInitiativeId(lInitiativeId);
            
            foreach (InitiativeApproval InitApprover in InitiativeApprovals)
            {
                if (InitApprover.m_iRole == (int)AppUsersRolesInitMgt.UserRole.Sponsor)
                {
                    //drpSponsor.SelectedValue = InitApprover.m_iUserId.ToString();
                }
            }

            foreach (InitiativeApproval InitApprover in InitiativeApprovals)
            {
                foreach (ListItem li in assetMgrCkbLst.Items)
                {
                    if (InitApprover.m_iRole == (int)AppUsersRolesInitMgt.UserRole.AssetOperationsManager)
                    {
                        if (li.Value == InitApprover.m_iUserId.ToString())
                        {
                            li.Selected = true;
                        }
                    }
                }
            }

            foreach (InitiativeApproval InitApprover in InitiativeApprovals)
            {
                foreach (ListItem li in funcMgrCkbLst.Items)
                {
                    if (InitApprover.m_iRole == (int)AppUsersRolesInitMgt.UserRole.FunctionalLead)
                    {
                        if (li.Value == InitApprover.m_iUserId.ToString())
                        {
                            li.Selected = true;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void forwardButton_Click(object sender, EventArgs e)
    {
        structUserMailIdx eSender = new structUserMailIdx(oSessnx.getOnlineUser.m_sUserName, oSessnx.getOnlineUser.m_sUserMail, oSessnx.getOnlineUser.m_iUserId.ToString());
        sendMailManHour emailSender = new sendMailManHour(eSender);

        InitiativeApproval oInitiativeApproval = new InitiativeApproval();
        
        //Initiator sends Initiative to Activity Sponsor for comment and approval, and sends notification email to all selected reviewers
        if (oInitiativeApproval.bApproverReviewerFound(long.Parse(lInitiativeHF.Value), int.Parse(ddlSponsor._SelectedValue)) == false)
        {
            oInitiativeApproval.AssignInitiativeToApprover(long.Parse(lInitiativeHF.Value), int.Parse(ddlSponsor._SelectedValue), (int)AppUsersRolesInitMgt.UserRole.Sponsor);
        }
        
        //Get email address of Activity Sponsor.
        appUsers ActivitySponsor = appUsersHelper.objGetOnlineUserByUserId(int.Parse(ddlSponsor._SelectedValue));
        structUserMailIdx eActivitySponsor = new structUserMailIdx(ActivitySponsor.structUserIdx);

        List<structUserMailIdx> eReviewers = new List<structUserMailIdx>();
        List<appUsers> allReviewers = new List<appUsers>();
        appUsers oReviewers = new appUsers();

        foreach (ListItem li in funcMgrCkbLst.Items)
        {
            if (li.Selected == true)
            {
                //Check if the user has been assigned the Initiative, if true do not reinsert.
                if (oInitiativeApproval.bApproverReviewerFound(long.Parse(lInitiativeHF.Value), int.Parse(li.Value)) == false)
                {
                    oInitiativeApproval.AssignInitiativeToApprover(long.Parse(lInitiativeHF.Value), int.Parse(li.Value), (int)AppUsersRolesInitMgt.UserRole.FunctionalLead);
                }
                //Get email address of all selected
                oReviewers = appUsersHelper.objGetOnlineUserByUserId(int.Parse(li.Value));
                eReviewers.Add(oReviewers.structUserIdx);
                allReviewers.Add(oReviewers);
            }
        }

        foreach (ListItem li in assetMgrCkbLst.Items)
        {
            if (li.Selected == true)
            {
                //Check if the user has been assigned the Initiative, if true do not reinsert.
                if (oInitiativeApproval.bApproverReviewerFound(long.Parse(lInitiativeHF.Value), int.Parse(li.Value)) == false)
                {
                    oInitiativeApproval.AssignInitiativeToApprover(long.Parse(lInitiativeHF.Value), int.Parse(li.Value), (int)AppUsersRolesInitMgt.UserRole.AssetOperationsManager);
                }
                //Get email address of all selected
                oReviewers = appUsersHelper.objGetOnlineUserByUserId(int.Parse(li.Value));
                eReviewers.Add(oReviewers.structUserIdx);
                allReviewers.Add(oReviewers);
            }
        }

        //Update Initiative status.
        oInitiativeApproval.UpdateInitiativeStatus(long.Parse(lInitiativeHF.Value), (int)Approval.apprStatusRpt.Sponsor);

        //Send email to Activity Sponsor and copy all reviewers
        bool bRet = emailSender.InitiatorRequestsForApproval(ActivitySponsor, eReviewers, allReviewers, long.Parse(lInitiativeHF.Value));
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Your Initiative has been sucessfully sent for approval.");
        }
    }
}