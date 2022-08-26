using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Services.Protocols;
using Microsoft.Security.Application;

public partial class Initiator_activityForm : aspnetPage
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
       
        //dtFrom
        //txtOriginalFrom_CalendarExtender.StartDate = DateTime.Now.AddDays(7); //dissabling past dates
        //txtOriginalTo_CalendarExtender.StartDate = DateTime.Now.AddDays(7);

        // Calendar1.StartDate = DateTime.Now.AddMonths(1);  // Start Calneder after one month from Present Date
        //Calendar1.EndDate = DateTime.Now;                 // dissabling Future Dates 
        /* Calendar1.StartDate = DateTime.Now;
         Calendar1.EndDate = DateTime.Now;*/
        //use these two lines at a time to allow only present date  

        if (!IsPostBack)
        {
            //2. Load Fields/Facilities
            List<facility> facilities = facility.lstGetFacility();
            foreach (facility _facility in facilities)
            {
                drpFacilities.Items.Add(new ListItem(_facility.m_sFacility, _facility.m_iFacilityId.ToString()));
            }

            ////3. Load Accounts to charge
            //List<accountToCharge> accounts = accountToCharge.lstGetAccountsToCharge();
            //foreach (accountToCharge account in accounts)
            //{
            //    drpAccountToCharge.Items.Add(new ListItem(account.m_sAccount, account.m_sAccountDescription));
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

            //6. Load Questionaires
            FieldVisitQuestionaire1.loadQuestionaires();
            //hookScriptValidator();
        }
    }

    private void hookScriptValidator()
    {
        txtNight.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtNight.ClientID + "');");
        txtPersonnel.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtPersonnel.ClientID + "');");
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        try
        {
            //submitButton.Enabled = false;
            long iActivity = fieldVisit.getActivityID(); //Called from database sequence. Note: Important!!! There is no need to create trigger for the table, as the required value is derived programmatically by querying the sequence at run time.

            //1. Autogenerate ActivityID

            //appUsers ActivitySponsor = appUsers.objGetUserByUserId(int.Parse(drpSponsor.SelectedValue));
            appUsers FacilityPlanner = appUsersHelper.objGetUserByUserId(int.Parse(drpPlanner.SelectedValue));

            bool success = fieldVisit.newFieldVisit(iActivity, int.Parse(drpFacilities.SelectedValue), taxDesTextBox.Text, oSessnx.getOnlineUser.m_iUserId, fieldVisit.GenerateActivityID(),
                                                   dtFrom.dtSelectedDate, dtTo.dtSelectedDate, txtCostCentre.Text, commentTextBox.Text, int.Parse(txtPersonnel.Text), int.Parse(txtNight.Text));

            if (success == true)
            {
                bool bRet = FieldVisitQuestionaire1.InsertCheckList(iActivity);
                if (bRet)
                {
                    //Initiator assigns activity to activity sponsor and sends notification email for approval.
                    //It is when activity sponsor approves that an email will go to Activity Planner for approval
                    //Initiator.assignActivityToActivitySponsorPlanner(iActivity, ActivitySponsor.m_iUserId, (int)appUsersRoles.userRole.sponsor);

                    //Initiator assigns activity to Facility Planner.
                    Initiator.assignActivityToActivitySponsorPlanner(iActivity, int.Parse(drpPlanner.SelectedValue), (int)appUsersRoles.userRole.planner);

                    //Initiator assigns activity to Superintendent. It is when Planner approves that an email will go to Superintendent for approval
                    Superintendent superintend = facility.objGetSuperintendentByFacilityId(int.Parse(drpFacilities.SelectedValue));
                    Initiator.assignActivityToSuperintendent(iActivity, (int)appUsersRoles.userRole.superintendent);

                    sendMailFieldVisit emailSystem = new sendMailFieldVisit(oSessnx.getOnlineUser.structUserIdx);

                    //Initiator sends mail to Activity Sponsor
                    emailSystem.initiatorSendsMailToFacilityPlanner(new structUserMailIdx(FacilityPlanner.m_sUserName, FacilityPlanner.m_sUserMail, FacilityPlanner.m_sFullName), iActivity, false);

                    //Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/RequestOwners/myPendingFieldVisitRequest.aspx?Msg=xActSub");
                    Response.Redirect("~/App/FieldVisit/Forms/MyRequets.aspx");
                }
                else
                {
                    string updateMessage = "There is a problem updating your questionaire, please contact the Administrator or Edit the request in My Pending Requests and submit again. Thank you.";
                    ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
                }
            }
            else
            {
                string updateMessage = "Operation not successful. Please try again later";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void drpFacilities_SelectedIndexChanged(object sender, EventArgs e)
    {
        facility myFacility = facility.objGetFacilityById(int.Parse(drpFacilities.SelectedValue));

        districtLabel.Text = Encoder.HtmlEncode(myFacility.eDistrict.m_sDistrict);
        superintendentLabel.Text = Encoder.HtmlEncode(myFacility.eSuperintendent.m_sSuperintendent);

        drpPlanner.Items.Clear();
        drpPlanner.Items.Add(new ListItem("--Select Planner--", "-1"));

        List<FacilityPlanners> facilityPlaners = facility.lstGetFacilityPlannersByFacility(int.Parse(drpFacilities.SelectedValue));
        foreach (FacilityPlanners facilityPlaner in facilityPlaners)
        {
            drpPlanner.Items.Add(new ListItem(facilityPlaner.eFacilityPlanner.m_sFullName, facilityPlaner.m_iPlannerId.ToString()));
        }
    }

    protected void closeButton_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/RequestOwners/myPendingFieldVisitRequest.aspx");
        Response.Redirect("~/App/FieldVisit/Forms/MyRequets.aspx");
    }
    //protected void drpAccountToCharge_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lblAccounttoChargeDesc.Text = drpAccountToCharge.SelectedValue;
    //}

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