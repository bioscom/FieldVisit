using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class SEPCiN_edt_PECForm : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //bool bRet = false;
        //try
        //{
        //string[] sPageAccess = { appUsersRoles.userRole.admin.ToString(), appUsersRoles.userRole.initiator.ToString() };
        //appUsersRoles oAccess = new appUsersRoles();
        //bRet = oAccess.grantPageAccessAdminInit(sPageAccess, this.oSessnx.getOnlineUser.m_eUserRole);
        //}
        //catch (Exception ex)
        //{
        //    appMonitor.logAppExceptions(ex);
        //}
        //if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            if (Request.QueryString["ActivityId"] != null)
            {
                long lActivityId = long.Parse(Request.QueryString["ActivityId"].ToString());
                //Initialise Controls
                activityHeader1.init_Controls();
                vendorCallOutInfo1.init_Controls();
                personnelInformationList1.Init_Page();
                activityTimeLineSummary1.Init_Page();
                locFieldLocations1.Page_Init();

                enableDisableButtons(sender, e);

                //Load values
                activityHeader1.Retrieve_Data(lActivityId);
                activityTimeLineSummary1.Retrieve_Data(lActivityId);
                locFieldLocations1.Retrieve_Data(lActivityId);
                personnelInformationList1.Retrieve_Data(lActivityId);
                vendorCallOutInfo1.Retrieve_Data(lActivityId);
                Approvers1.Retrieve_Data(lActivityId);
            }
        }
        activityHeader1.FacilitySelected += new EventHandler(activityHeader1_FacilitySelected);
    }

    protected void activityHeader1_FacilitySelected(object sender, EventArgs e)
    {
        Approvers1.Page_Init(int.Parse(activityHeader1.Facility.SelectedValue));
    }

    protected void closeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/FieldVisit/Forms/PEC/MyPecRequests.aspx");
    }

    protected void drpPlanWindow_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void enableDisableButtons(object sender, EventArgs e)
    {
        long iActivityId = long.Parse(Request.QueryString["ActivityId"].ToString());

        activityHeader1.MySaveButton.Visible = false;

        VendorCallOut MyVendorCallOut = VendorCallOut.objGetPersonnelInfoByActivityId(iActivityId);
        if (MyVendorCallOut.m_iID_VENDOR == 0)
        {
            vendorCallOutInfo1.MySaveButton.Visible = true;
            vendorCallOutInfo1.MyUpdateButton.Visible = false;
        }
        else
        {
            vendorCallOutInfo1.MySaveButton.Visible = false;
            vendorCallOutInfo1.MyUpdateButton.Visible = true;
        }
        
        //personnelInformationList1.MySaveButton.Visible = false;
        //Note: you need to check that the 
        List<LocationFieldActivityInfo> MyLocationFieldActivities = LocationFieldActivityInfo.lstGetLocationFieldByActivityId(iActivityId);
        if (MyLocationFieldActivities.Count > 0)
        {
            locFieldLocations1.MySaveButton.Visible = false;
        }
        else
        {
            locFieldLocations1.MyUpdateButton.Visible = false;
        }

        //LocationFieldActivityInfo MyLocationFieldActivities = LocationFieldActivityInfo.objGetLocationFieldByActivityId(iActivityId);
        
        //activityTimeLineSummary1.Retrieve_Data(int.Parse(Request.QueryString["ActivityId"].ToString()));
        //Approvers1.MySaveButton.Visible = false;
    }

    override protected void OnInit(EventArgs e)
    {
        InitialiseComponent();
        base.OnInit(e);
    }

    private void InitialiseComponent()
    {
        activityHeader1.BubbleClick += new EventHandler(enableDisableButtons);
    }
}
