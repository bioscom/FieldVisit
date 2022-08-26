using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class UserControl_activityHeader : aspnetUserControl
{
    public delegate void ChildControlDelegate(long lActivityId);

    /// <summary>
    /// Event to which the Parent page will subscribe
    /// </summary>
    public event ChildControlDelegate GetDataFromChild;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    ///		Required method for Designer support - do not modify
    ///		the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        //this.DataBinding += new System.EventHandler(this.OpexCostActivityDetails_DataBinding);
    }

    public void init_Controls()
    {
        try
        {
            originatorLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName);
            originatorDeptLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sRefInd);

            drpAssets.Items.Add(new ListItem("Select Asset", "-1"));
            List<facility> facilities = facility.lstGetFacility();
            foreach (facility _facility in facilities)
            {
                drpAssets.Items.Add(new ListItem(_facility.m_sFacility, _facility.m_iFacilityId.ToString()));
            }

            drpActivityType.Items.Add(new ListItem("Select Activity Type", "-1"));
            List<ActivityType> activities = ActivityType.lstGetActivityType();
            foreach (ActivityType activity in activities)
            {
                drpActivityType.Items.Add(new ListItem(activity.m_sACTIVITY_TYPE, activity.m_iID_ACTIVITY_TYPE.ToString()));
            }

            //unitDrp.Items.Add(new ListItem("Select Unit", "-1"));
            List<Units> _Units = Units.lstGetUnits();
            foreach (Units _unit in _Units)
            {
                unitDrp.Items.Add(new ListItem(_unit.m_sUNITS, _unit.m_iID_UNIT.ToString()));
            }

            List<appUsers> oActivitySponsors = appUsersHelper.lstGetOnlineUsers();
            //List<appUsers> ActivitySponsors = appUsers.lstGetOnlineUserByRole((int)appUsersRoles.userRole.sponsor);
            //foreach (appUsers ActivitySponsor in oActivitySponsors)
            //{
            //    drpSponsor.Items.Add(new ListItem(ActivitySponsor.m_sFullName, ActivitySponsor.m_iUserId.ToString()));
            //}
            //TODO: find solution to this javascript
            //hookScriptValidator();

            drpSponsor.initUserInfo("Select Activity Sponsor", 250);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void Retrieve_Data(long iActivityID)
    {
        ActivityIdHF.Value = iActivityID.ToString();
        ActivityInfo oActivity = ActivityInfo.objGetActivityInfoByActivityId(iActivityID);

        drpActivityType.SelectedValue = Encoder.HtmlEncode(oActivity.m_iActivityTypeId.ToString());
        drpAssets.SelectedValue = Encoder.HtmlEncode(oActivity.m_iFacilityId.ToString());
        originatorLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName);
        originatorDeptLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sRefInd);

        //txtActivityId.Text = thisActivity.m_sACTIVITYID;
        dtFirstNight.dtSetDate(oActivity.m_sFirstNight);
        //txtFirstNight.Text = Encoder.HtmlEncode(thisActivity.m_sFIRST_NIGHT);
        txtActivityDescription.Text = Encoder.HtmlEncode(oActivity.m_sActivityDescription);
        txtFunctionLocation.Text = Encoder.HtmlEncode(oActivity.m_sLocation);
        txtJustification.Text = Encoder.HtmlEncode(oActivity.m_sJustification);
        dtLastNight.dtSetDate(oActivity.m_sLastNight);
        //txtLastNight.Text = Encoder.HtmlEncode(thisActivity.m_sLAST_NIGHT);
        txtNoOfBeds.Text = Encoder.HtmlEncode(oActivity.m_iNoOfBeds.ToString());
        txtVolume.Text = Encoder.HtmlEncode(oActivity.m_sVolume);
        unitDrp.SelectedValue = Encoder.HtmlEncode(oActivity.m_iUnit.ToString());

        rdbDeferment.SelectedValue = Encoder.HtmlEncode(oActivity.m_sACTIVITY_CAUSE_OIL_DEFRMNT);
        //dateLabel.Text = thisActivity.m_sDATE_SUMBITTED;

        List<PECApprover> sponsors = oActivity.lstApprovers;
        foreach(PECApprover sponsor in sponsors)
        {
            if(sponsor.m_iRole == (int) appUsersRoles.userRole.sponsor)
            {
                drpSponsor.thisDropDownList.SelectedValue = sponsor.m_iUserId.ToString();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            long lActivityId = ActivityInfo.getActivityInfoId();
            ActivityIdHF.Value = lActivityId.ToString();

            //When the Submit button is clicked, the ActivityId generated should be assigned to the ActivityIdHF on the Parent form
            //This will be used by other UserControls to submit their contents.
            if (GetDataFromChild != null)
            {
                GetDataFromChild(lActivityId);
            }

            ActivityInfo oActivityInfo = new ActivityInfo();
            oActivityInfo.m_lActivityId = lActivityId;
            oActivityInfo.m_iActivityTypeId = int.Parse(drpActivityType.SelectedValue);
            oActivityInfo.m_iFacilityId = int.Parse(drpAssets.SelectedValue);
            oActivityInfo.m_sActivityDescription = txtActivityDescription.Text;
            oActivityInfo.m_sJustification = txtJustification.Text;
            oActivityInfo.m_sActivityId = fieldVisit.GenerateActivityID();
            oActivityInfo.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
            oActivityInfo.m_sDateSubmitted = DateTime.Today.Date;
            oActivityInfo.m_sLocation = txtFunctionLocation.Text;
            oActivityInfo.m_sFirstNight = dtFirstNight.dtSelectedDate;
            oActivityInfo.m_sLastNight = dtLastNight.dtSelectedDate;
            oActivityInfo.m_sACTIVITY_CAUSE_OIL_DEFRMNT = rdbDeferment.SelectedValue;
            oActivityInfo.m_sVolume = txtVolume.Text;
            oActivityInfo.m_iNoOfBeds = int.Parse(txtNoOfBeds.Text);
            oActivityInfo.m_iUnit = int.Parse(unitDrp.SelectedValue);

            bool bRet = ActivityInfo.createActivityInfo(oActivityInfo);

            if (bRet == true)
            {
                //Assign activity to Activity Sponsor.
                PECApprover.AssignPECRequestToApprover(lActivityId, int.Parse(drpSponsor._SelectedValue), (int)appUsersRoles.userRole.sponsor);

                OnBubbleClick(e);
                btnSave.Visible = false;
                updateButton.Visible = true;

                ajaxWebExtension.showJscriptAlert(Page, this, "Activity Information successfully saved.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        long iActivityInfoId = long.Parse(ActivityIdHF.Value);
        try
        {
            bool bRet = ActivityInfo.updateActivityInfo(iActivityInfoId, int.Parse(drpActivityType.SelectedValue),
            int.Parse(drpAssets.SelectedValue), txtActivityDescription.Text, txtJustification.Text, oSessnx.getOnlineUser.m_iUserId,
            txtFunctionLocation.Text, int.Parse(txtNoOfBeds.Text), dtFirstNight.dtSelectedDate, dtLastNight.dtSelectedDate,
            rdbDeferment.SelectedValue, txtVolume.Text, int.Parse(unitDrp.SelectedValue));

            if (bRet == true)
            {
                //Assign activity to Activity Sponsor.
                PECApprover.UpdateAssignedPECRequestToApprover(iActivityInfoId, int.Parse(drpSponsor._SelectedValue), (int)appUsersRoles.userRole.sponsor);

                ajaxWebExtension.showJscriptAlert(Page, this, "Activity Information successfully updated.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void hookScriptValidator()
    {
        txtNoOfBeds.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtNoOfBeds.ClientID + "');");
        //txtLastNight.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtLastNight.ClientID + "');");
        txtVolume.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtVolume.ClientID + "');");
        //txtFirstNight.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtFirstNight.ClientID + "');");
    }

    //Expose control to the outside world
    public HiddenField activityInfoId
    {
        get
        {
            return ActivityIdHF;
        }
    }

    public Button MySaveButton
    {
        get
        {
            return btnSave;
        }
    }

    public Button MyUpdateButton
    {
        get
        {
            return updateButton;
        }
    }

    public DropDownList Facility
    {
        get
        {
            return drpAssets;
        }
    }

    public event EventHandler BubbleClick;

    protected void OnBubbleClick(EventArgs e)
    {
        if (BubbleClick != null)
        {
            BubbleClick(this, e);
        }
    }

    public event EventHandler FacilitySelected;

    protected void OnFacilitySelected(EventArgs e)
    {
        if (FacilitySelected != null)
        {
            FacilitySelected(this, e);
        }
    }

    protected void drpAssets_SelectedIndexChanged(object sender, EventArgs e)
    {
        OnFacilitySelected(e);
    }
}
