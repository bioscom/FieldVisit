using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Services.Protocols;
using Microsoft.Security.Application;

public partial class Initiator_edtActivityForm : aspnetPage
{
    //protected override void OnLoad(EventArgs e)
    //{
    //    //set the validator min and max values
    //    this.valDateMustBeWithinMinMaxRange.MinimumValue = DateTime.Today.Date.ToShortDateString();
    //    this.valDateMustBeWithinMinMaxRange.MaximumValue = DateTime.MaxValue.Date.ToShortDateString();
    //    base.OnLoad(e);
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Load Fields/Facilities
            List<facility> facilities = facility.lstGetFacility();
            foreach (facility _facility in facilities)
            {
                drpFacilities.Items.Add(new ListItem(_facility.m_sFacility, _facility.m_iFacilityId.ToString()));
            }

            ////Load Accounts to charge
            //List<accountToCharge> accounts = accountToCharge.lstGetAccountsToCharge();
            //foreach (accountToCharge account in accounts)
            //{
            //   drpAccountToCharge.Items.Add(new ListItem(account.m_sAccount, account.m_sAccountDescription));
            //}

            ////4. Load Activity Sponsors
            //List<appUsers> ActivitySponsors = appUsers.lstGetOnlineUserByRole((int)appUsersRoles.userRole.sponsor);
            //foreach (appUsers ActivitySponsor in ActivitySponsors)
            //{
            //    drpSponsor.Items.Add(new ListItem(ActivitySponsor.m_sFullName, ActivitySponsor.m_iUserId.ToString()));
            //}

            ////Load Asset Managers
            //drpSponsor.Items.Add(new ListItem("****** Asset Managers ******"));
            //List<appUsers> AssetManagers = appUsers.lstGetOnlineUserByRole((int)appUsersRoles.userRole.AssetOperationsManager);
            //foreach (appUsers AssetManager in AssetManagers)
            //{
            //    drpSponsor.Items.Add(new ListItem(AssetManager.m_sFullName, AssetManager.m_iUserId.ToString()));
            //}

            ////Load Functional Leads
            //drpSponsor.Items.Add(new ListItem("****** Functional Lead ******"));
            //List<appUsers> FunctionalLeads = appUsers.lstGetOnlineUserByRole((int)appUsersRoles.userRole.FunctionalLead);
            //foreach (appUsers FunctionalLead in FunctionalLeads)
            //{
            //    drpSponsor.Items.Add(new ListItem(FunctionalLead.m_sFullName, FunctionalLead.m_iUserId.ToString()));
            //}

            //Superintendent.initUserInfo("Select Superintendent", 250);
            //List<Superintendent> superintendents = Superintendent.lstGetSuperintendent();
            //foreach (Superintendent superintendent in superintendents)
            //{
            //    drpSuperintendent.Items.Add(new ListItem(superintendent.m_sSuperintendentEmail, superintendent.m_iSuperintendentId.ToString()));
            //}

            //load Questionaires
            FieldVisitQuestionaire1.loadQuestionaires();

            retrieveDetails();
            hookScriptValidator();
        }
    }

    private void hookScriptValidator()
    {
        txtPersonnel.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtPersonnel.ClientID + "');");
        txtNight.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtNight.ClientID + "');");
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        //Get Detail Information of the LoginUser from IWH databse
        //Initiator aInitiator = new Initiator();

        try
        {
            if (Request.QueryString["ActivityId"] != null)
            {
                int iActivity = int.Parse(Request.QueryString["ActivityId"].ToString());

                //FacilityPlanners selectedPlanner = facility.objGetFacilityPlannerByPlanneryId(int.Parse(drpPlanner.SelectedValue));
                appUsers FacilityPlanner = appUsersHelper.objGetUserByUserId(int.Parse(drpPlanner.SelectedValue));
                
                bool success = fieldVisit.updateFieldVisit(iActivity, int.Parse(drpFacilities.SelectedValue), taxDesTextBox.Text, oSessnx.getOnlineUser.m_iUserId, 
                          dtFrom.dtSelectedDate, dtTo.dtSelectedDate, txtCostCentre.Text, commentTextBox.Text, int.Parse(txtPersonnel.Text), int.Parse(txtNight.Text)); 

                if (success == true)
                {
                    FieldVisitQuestionaire1.UpdateCheckList(iActivity);

                    //TODO: the mail here should be notification of change made to the request
                    Initiator.updateActivityToApproverAssignment(iActivity, FacilityPlanner.m_iUserId, (int)appUsersRoles.userRole.planner); //Planner

                    var emailSystem = new sendMailFieldVisit(oSessnx.getOnlineUser.structUserIdx);
                    emailSystem.initiatorSendsMailToFacilityPlanner(FacilityPlanner.structUserIdx, iActivity, false);
                    //emailSystem.initiatorSendsMailToActivitySponsor(new structUserMailIdx(mailSponsor.m_sUserName, mailSponsor.m_sUserMail, mailSponsor.m_sFullName), iActivity);

                    //Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/RequestOwners/myPendingFieldVisitRequest.aspx?Msg=xActUpd");
                    Response.Redirect("~/App/FieldVisit/Forms/MyRequets.aspx");
                }
                else
                {
                    string updateMessage = "Update was not successful, please try again later.";
                    ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void drpFacilities_SelectedIndexChanged(object sender, EventArgs e)
    {
        getFacilityRelation(int.Parse(drpFacilities.SelectedValue));
        LoadPlannersByFacilityId(int.Parse(drpFacilities.SelectedValue));
    }

    private void retrieveDetails()
    {
        if (Request.QueryString["ActivityId"] != null)
        {
            fieldVisitDetails myDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(int.Parse(Request.QueryString["ActivityId"].ToString()));
            drpFacilities.SelectedValue = myDetails.m_iFacilityId.ToString();

            //Load Planners for the selected Facility
            drpPlanner.Items.Clear();
            drpPlanner.Items.Add(new ListItem("--Select Planner--", "-1"));

            List<FacilityPlanners> facilityPlaners = facility.lstGetFacilityPlannersByFacility(int.Parse(myDetails.m_iFacilityId.ToString()));
            foreach (FacilityPlanners facilityPlaner in facilityPlaners)
            {
                drpPlanner.Items.Add(new ListItem(facilityPlaner.eFacilityPlanner.m_sFullName, facilityPlaner.m_iPlannerId.ToString()));
            }

            List<siteVisitApproval> oApprovals = myDetails.lstApprovalDetails;
            foreach (siteVisitApproval oApproval in oApprovals)
            {
                if (oApproval.m_iRole == (int)appUsersRoles.userRole.planner)
                {
                    drpPlanner.SelectedValue = oApproval.m_iUserId.ToString();
                }
                //else
                //{
                //    drpSponsor.SelectedValue = oApproval.m_iUserId.ToString();
                //}
                //else if (oApproval.m_iRole == (int)appUsersRoles.userRole.sponsor)
                //{
                //    drpSponsor.SelectedValue = oApproval.m_iUserId.ToString();
                //}
            }

            taxDesTextBox.Text = Encoder.HtmlEncode(myDetails.m_sTaskDescription);
            lblActivityId.Text = Encoder.HtmlEncode(myDetails.m_sActivityId);

            dtFrom.setDate(Encoder.HtmlEncode(myDetails.m_sDateFrom));
            dtTo.setDate(Encoder.HtmlEncode(myDetails.m_sDateFrom));

            txtNight.Text = Encoder.HtmlEncode(myDetails.m_sNoOfNights);
            txtPersonnel.Text = Encoder.HtmlEncode(myDetails.m_sNoOfPersonnels);
            commentTextBox.Text = Encoder.HtmlEncode(myDetails.m_sGeneralComment);

            FieldVisitQuestionaire1.loadFieldVisitDetailsByActivity(int.Parse(Request.QueryString["ActivityId"].ToString()));

            txtCostCentre.Text = Encoder.HtmlEncode(myDetails.m_sAccountToCharge);
            //drpAccountToCharge.SelectedValue = Encoder.HtmlEncode(myDetails.m_sAccountToCharge);
            //lblAccounttoChargeDesc.Text = Encoder.HtmlEncode(drpAccountToCharge.SelectedItem.Text);
            getFacilityRelation(int.Parse(Encoder.HtmlEncode(myDetails.m_iFacilityId.ToString())));

            //retrieveApprovers();
        }
    }

    private void retrieveApprovers()
    {
        if (Request.QueryString["ActivityId"] != null)
        {
            LoadPlannersByFacilityId(int.Parse(Request.QueryString["ActivityId"].ToString()));

            List<siteVisitApproval> approvers = siteVisitApproval.lstGetSiteVisitApprovalByActivityId(int.Parse(Request.QueryString["ActivityId"].ToString()));
            foreach (siteVisitApproval approver in approvers)
            {
                //if (approver.m_iRole == (int)appUsersRoles.userRole.planner)
                //{
                //    //plannerLabel.Text = ;
                //    plannerLabel.Text = activityPlanner.m_sFullName;
                //    plannerHF.Value = activityPlanner.m_sUserName;
                //}
                if (approver.m_iRole == (int)appUsersRoles.userRole.sponsor)
                {
                    //sponsorLabel.Text = approver.m_sUserId;
                    //sponsorLabel.Text = activitySponsor.m_sFullName;
                    //sponsorHF.Value = activitySponsor.m_sUserName;
                }
                else if (approver.m_iRole == (int)appUsersRoles.userRole.superintendent)
                {
                    //drpSuperintendent.SelectedValue = approver.m_sUserId;
                }
            }
        }
    }

    private void LoadPlannersByFacilityId(int iFacilityId)
    {
        //Load Facility Planners by selected facility
        List<FacilityPlanners> planners = facility.lstGetFacilityPlannersByFacility(iFacilityId);
        foreach (FacilityPlanners planner in planners)
        {
            drpPlanner.Items.Add(new ListItem(planner.eFacilityPlanner.m_sFullName, planner.m_iPlannerId.ToString()));
        }

        //TODO: this is not yet fully correct please revisit this code
        //FacilityPlanners selectedPlanner = facility.objGetFacilityPlannerByFacilityId(iFacilityId);
        //drpPlanner.SelectedValue = selectedPlanner.m_iPlannerId.ToString();
    }

    private void getFacilityRelation(int iFacilityId)
    {
        facility myFacility = facility.objGetFacilityById(iFacilityId);

        districtLabel.Text = Encoder.HtmlEncode(myFacility.eDistrict.m_sDistrict);
        superintendentLabel.Text = Encoder.HtmlEncode(myFacility.eSuperintendent.m_sSuperintendent);
    }
    
    protected void closeButton_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/RequestOwners/myPendingFieldVisitRequest.aspx");
        Response.Redirect("~/App/FieldVisit/Forms/MyRequets.aspx");
    }

    //protected void drpAccountToCharge_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lblAccounttoChargeDesc.Text = Encoder.HtmlEncode(drpAccountToCharge.SelectedValue);
    //}

    protected void drpPlanner_SelectedIndexChanged(object sender, EventArgs e)
    {
        FacilityPlanners facilityPlaner = facility.objGetFacilityPlannerByPlanneryId(int.Parse(drpPlanner.SelectedValue));

        //plannerUserMailHF.Value = facilityPlaner.eFacilityPlanner.m_sUserMail;
        //plannerUserNameHF.Value = facilityPlaner.eFacilityPlanner.m_sUserName;
    }

    [WebMethodAttribute(), ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        List<string> MyItems = new List<string>();

        List<accountToCharge> accounts = accountToCharge.lstGetAccountsToChargeByPrefixText(prefixText);
        foreach (accountToCharge account in accounts)
        {
            MyItems.Add(account.m_sAccount + "(" + account.m_sAccountDescription + ")");
        }

        return MyItems.ToArray();
    }
}
