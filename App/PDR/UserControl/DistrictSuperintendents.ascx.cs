using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class App_PDR_UserControl_DistrictSuperintendents : System.Web.UI.UserControl
{
    appUsersHelper oAppUsersHelper = new appUsersHelper();
    FacilityAssetGMHelper oFacilityAssetGMHelper = new FacilityAssetGMHelper();
    DistrictExt oDistrictExt = new DistrictExt();
    District oDistrict = new District();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<appUsers> oSuperintendents = oAppUsersHelper.lstGetUserByRole((int)appUsersRoles.userRole.superintendent);
            foreach(appUsers oAppUser in oSuperintendents)
            {
                ddlSuperintendents.Items.Add(new ListItem(Encoder.HtmlEncode(oAppUser.m_sFullName), Encoder.HtmlEncode(oAppUser.m_iUserId.ToString())));
            }

            List<Assets> oAssets = Assets.lstGetAssets();
            foreach (Assets oAsset in oAssets)
            {
                ddlAssets.Items.Add(new ListItem(Encoder.HtmlEncode(oAsset.sAsset), Encoder.HtmlEncode(oAsset.iAssetId.ToString())));
            }
        }
    }
    protected void ddlAssets_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<District> oDistricts = District.lstGetDistrictByAsset(int.Parse(ddlAssets.SelectedValue));
        foreach (District oDistrict in oDistricts)
        {
            ckbDistrict.Items.Add(new ListItem(Encoder.HtmlEncode(oDistrict.m_sDistrict), Encoder.HtmlEncode(oDistrict.m_iDistrictId.ToString())));
        }
    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        int i = 0;
        foreach (ListItem li in ckbDistrict.Items)
        {
            if (li.Selected == false)
            {
                i++;
            }
        }

        if (i == ckbDistrict.Items.Count)
        {
            string sRet2 = "Atleast, a district must be assigned to a District Superintendent.";
            ajaxWebExtension.showJscriptAlert(Page, this, sRet2);
        }
        else
        {
            string sDistricts = "";
            foreach (ListItem li in ckbDistrict.Items)
            {
                if (li.Selected == true)
                {
                    //Check if selected Facility is found for the user
                    if (!District.bGetIfDistrictHasBeenAssignedToSuperintendent(int.Parse(ddlSuperintendents.SelectedValue), int.Parse(li.Value)))
                    {
                        District.AssignDistrictToSuperintendent(int.Parse(ddlSuperintendents.SelectedValue), int.Parse(li.Value));
                        sDistricts += ckbDistrict.Text + ", ";
                    }
                    //TODO: if previously selected facility has been deselected, what should be done?
                }
            }
            ckbDistrict.ClearSelection();

            string mssg = "The following Districts " + sDistricts + " were successully assigned to " + ddlSuperintendents.SelectedItem.Text;
            ajaxWebExtension.showJscriptAlert(Page, this, mssg);
        }
    }
    //protected void drpGMOnOffShore_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //TODO: If a user is selected, check to see if the user already has Facilities assigned

    //    ckbDistrict.ClearSelection();

    //    List<FacilityAssetGM> MyAssignedFacilities = FacilityAssetGMHelper.lstGetFacilitiesAssignedToGM(int.Parse(ddlSuperintendents.SelectedValue));
    //    foreach (FacilityAssetGM MyAssignedFacility in MyAssignedFacilities)
    //    {
    //        foreach (ListItem li in ckbDistrict.Items)
    //        {
    //            if (li.Value == MyAssignedFacility.m_iFacilityId.ToString())
    //            {
    //                li.Selected = true;
    //            }
    //        }
    //    }
    //}
}