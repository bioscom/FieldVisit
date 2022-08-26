using System;
using System.Web.UI.WebControls;

public partial class SEPCiN_PECForm : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            activityHeader1.init_Controls();
            vendorCallOutInfo1.init_Controls();
            personnelInformationList1.Init_Page();
            //activityTimeLineSummary1.Init_Page();
            locFieldLocations1.Page_Init();
            //Approvers1.Page_Init();

            enableDisableButtons(sender, e);
        }


        //Subscribe to the event of the UserControl, to receive notification of its execution
        activityHeader1.GetDataFromChild += new UserControl_activityHeader.ChildControlDelegate(activityHeader1_GetDataFromChild);
        activityHeader1.FacilitySelected += new EventHandler(activityHeader1_FacilitySelected);
    }

    /// <summary>
    /// Method will be executed when the event notification is received from the user control
    /// </summary>
    /// <param name="lActivityId"></param>
    void activityHeader1_GetDataFromChild(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();

        vendorCallOutInfo1.initiateActivityId(lActivityId);
        personnelInformationList1.initiateActivityId(lActivityId);
        activityTimeLineSummary1.initiateActivityId(lActivityId);
        locFieldLocations1.initiateActivityId(lActivityId);
        Approvers1.initiateActivityId(lActivityId);
        
    }

    protected void activityHeader1_FacilitySelected(object sender, EventArgs e)
    {
        Approvers1.Page_Init(int.Parse(activityHeader1.Facility.SelectedValue));
    }

    protected void drpPlanWindow_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void enableDisableButtons(object sender, EventArgs e)
    {
        //int iActivityInfo = int.Parse(activityHeader1.activityInfoId.Value);

        if (!string.IsNullOrEmpty(activityHeader1.activityInfoId.Value))
        {
            activityHeader1.MySaveButton.Visible = false;
            activityHeader1.MyUpdateButton.Visible = true;

            vendorCallOutInfo1.MySaveButton.Visible = true;
            vendorCallOutInfo1.MyUpdateButton.Visible = false;

            personnelInformationList1.MySaveButton.Visible = true;

            locFieldLocations1.MySaveButton.Visible = true;
            locFieldLocations1.MyUpdateButton.Visible = false;

            Approvers1.MyForwardButton.Visible = true;
        }
        else if (string.IsNullOrEmpty(activityHeader1.activityInfoId.Value))
        {
            activityHeader1.MySaveButton.Visible = true;
            activityHeader1.MyUpdateButton.Visible = false;

            vendorCallOutInfo1.MySaveButton.Visible = false;
            vendorCallOutInfo1.MyUpdateButton.Visible = false;

            personnelInformationList1.MySaveButton.Visible = false;

            locFieldLocations1.MySaveButton.Visible = false;
            locFieldLocations1.MyUpdateButton.Visible = false;

            Approvers1.MyForwardButton.Visible = false;
        }



        //if (ActivityInfo.bGetActivityInfoByActivityId(iActivityInfo) == true)
        //{
        //    activityHeader1.MySaveButton.Visible = false;
        //    activityHeader1.MyUpdateButton.Visible = true;

        //    vendorCallOutInfo1.MySaveButton.Visible = true;
        //    vendorCallOutInfo1.MyUpdateButton.Visible = false;

        //    personnelInformationList1.MySaveButton.Visible = true;

        //    locFieldLocations1.MySaveButton.Visible = true;
        //    locFieldLocations1.MyUpdateButton.Visible = false;

        //    Approvers1.MyForwardButton.Visible = true;
        //}
        //else if (ActivityInfo.bGetActivityInfoByActivityId(iActivityInfo) == false)
        //{
        //    activityHeader1.MySaveButton.Visible = true;
        //    activityHeader1.MyUpdateButton.Visible = false;

        //    vendorCallOutInfo1.MySaveButton.Visible = false;
        //    vendorCallOutInfo1.MyUpdateButton.Visible = false;

        //    personnelInformationList1.MySaveButton.Visible = false;

        //    locFieldLocations1.MySaveButton.Visible = false;
        //    locFieldLocations1.MyUpdateButton.Visible = false;

        //    Approvers1.MyForwardButton.Visible = false;
        //}
    }

    override protected void OnInit(EventArgs e)
    {
        InitialiseComponent();
        base.OnInit(e);
    }

    private void InitialiseComponent()
    {
        activityHeader1.BubbleClick += new EventHandler(enableDisableButtons);
        //AddHandler opexCostActivityDetailsForm1.BubbleClick, AddressOf LoadData 'VB.Net
        //'opexCostActivityDetailsForm1.BubbleClick += New EventHandler(BindGridYearOnePlan) //C#
    }
}