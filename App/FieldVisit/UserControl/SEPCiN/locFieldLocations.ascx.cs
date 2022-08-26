using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_fieldLocations : aspnetUserControl
{
    public void Page_Init()
    {
        grdView.DataSource = LocationField.dtGetLocationFieldByWindowId((int)LocationField.PEC.MT); grdView.DataBind();
        grdViewOffShoreLocations.DataSource = LocationField.dtGetLocationFieldByWindowId((int)LocationField.PEC.ST); grdViewOffShoreLocations.DataBind();
        grdViewSwampLocations.DataSource = LocationField.dtGetLocationFieldByWindowId((int)LocationField.PEC.VST); grdViewSwampLocations.DataBind();

        lbMT.Text = LocationField.PECDesc(LocationField.PEC.MT);
        lbST.Text = LocationField.PECDesc(LocationField.PEC.ST);
        lbVST.Text = LocationField.PECDesc(LocationField.PEC.VST);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void initiateActivityId(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();
    }

    public void Retrieve_Data(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();
        List<LocationFieldActivityInfo> MyLocationFieldActivities = LocationFieldActivityInfo.lstGetLocationFieldByActivityId(lActivityId);

        foreach (LocationFieldActivityInfo MyLocationFieldActivity in MyLocationFieldActivities)
        {
            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");

                if (iFieldLoc == MyLocationFieldActivity.m_iID_FIELD_LOC)
                {
                    MyStatus._SelectedValue(MyLocationFieldActivity.m_iSTATUS);
                }
            }

            foreach (GridViewRow grdRow in grdViewOffShoreLocations.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");

                if (iFieldLoc == MyLocationFieldActivity.m_iID_FIELD_LOC)
                {
                    MyStatus._SelectedValue(MyLocationFieldActivity.m_iSTATUS);
                }
            }

            foreach (GridViewRow grdRow in grdViewSwampLocations.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");

                if (iFieldLoc == MyLocationFieldActivity.m_iID_FIELD_LOC)
                {
                    MyStatus._SelectedValue(MyLocationFieldActivity.m_iSTATUS);
                }
            }
        }
    }


    //Expose control to the outside world
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool success = false;
        try
        {                
            long lActivityId = long.Parse(ActivityIDHF.Value);
            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");
                success = LocationFieldActivityInfo.createLocationFieldActivityInfo(iFieldLoc, lActivityId, int.Parse(MyStatus.SelectedStatus));
            }

            foreach (GridViewRow grdRow in grdViewOffShoreLocations.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");
                success = LocationFieldActivityInfo.createLocationFieldActivityInfo(iFieldLoc, lActivityId, int.Parse(MyStatus.SelectedStatus));
            }

            foreach (GridViewRow grdRow in grdViewSwampLocations.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");
                success = LocationFieldActivityInfo.createLocationFieldActivityInfo(iFieldLoc, lActivityId, int.Parse(MyStatus.SelectedStatus));
            }

            if (success == true)
            {
                btnSave.Visible = false;
                updateButton.Visible = true;

                string Message = "Plan Execution Criteria successfully saved.";
                ajaxWebExtension.showJscriptAlert(Page, this, Message);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        
        bool success = false;
        try
        {
            long lActivityId = long.Parse(ActivityIDHF.Value);

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");
                success = LocationFieldActivityInfo.updateLocationFieldActivityInfo(iFieldLoc, lActivityId, int.Parse(MyStatus.SelectedStatus));
            }

            foreach (GridViewRow grdRow in grdViewOffShoreLocations.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                //long iActivityInfo = long.Parse(GetHFControl().Value);
                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");
                success = LocationFieldActivityInfo.updateLocationFieldActivityInfo(iFieldLoc, lActivityId, int.Parse(MyStatus.SelectedStatus));
            }

            foreach (GridViewRow grdRow in grdViewSwampLocations.Rows)
            {
                Label lbFieldLocation = (Label)grdRow.FindControl("lblFieldLocation");
                int iFieldLoc = int.Parse(lbFieldLocation.Attributes["FIELD_LOC"].ToString());

                //long iActivityInfo = long.Parse(GetHFControl().Value);
                ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx MyStatus = (ASP.app_fieldvisit_usercontrol_sepcin_statusselectorcontrol_ascx)grdRow.FindControl("statusSelectorControl1");
                success = LocationFieldActivityInfo.updateLocationFieldActivityInfo(iFieldLoc, lActivityId, int.Parse(MyStatus.SelectedStatus));
            }

            if (success == true)
            {
                btnSave.Visible = false;
                updateButton.Visible = true;

                string Message = "Plan Execution Criteria successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, Message);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}
