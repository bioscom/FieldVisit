using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class App_Contract_AssignAssetsToSuperintendent : aspnetPage
{
    appUsersHelper oAppUsersHelper = new appUsersHelper();
    FacilityAssetGMHelper oFacilityAssetGMHelper = new FacilityAssetGMHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        //bool bRet = false;
        //try
        //{
        //    string[] sPageAccess = { appUserRolesFlrWaiver.userRole.Administrator.ToString() };
        //    appUserRolesFlrWaiver oAccess = new appUserRolesFlrWaiver();
        //    bRet = oAccess.grantPageAccess(sPageAccess, (appUserRolesFlrWaiver.userRole)this.oSessnx.getOnlineUser.m_eUserRole);
        //}
        //catch (Exception ex)
        //{
        //    appMonitor.logAppExceptions(ex);
        //}
        //if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            int x = 1;

            List<Assets> lstAssets = Assets.lstGetAssets(); //Load Assets
            foreach (Assets oAssets in lstAssets)
            {
                AssetCheckBoxList.Items.Add(new ListItem(x + ". " + Encoder.HtmlEncode(oAssets.sAsset) , Encoder.HtmlEncode(oAssets.iAssetId.ToString())));
                x++;
            }


            //List<facility> fieldFacilities = facility.lstGetFacility();
            //foreach (facility fieldFacility in fieldFacilities)
            //{
            //    facilitiesCheckBoxList.Items.Add(new ListItem(x + ". " + "  <b><font color='Navy'>[" + Encoder.HtmlEncode(fieldFacility.eDistrict.m_sDistrict) + "]</font></b>" + Encoder.HtmlEncode(fieldFacility.m_sFacility) + "  <b><font color='Green'>[" + Encoder.HtmlEncode(fieldFacility.eSuperintendent.m_sSuperintendent) + "]</font></b>", Encoder.HtmlEncode(fieldFacility.m_iFacilityId.ToString())));
            //    x++;
            //}

            int y = 1;
            List<appUsers> lstSuperintendent = oAppUsersHelper.lstGet14DaysContractUserByRole((int)AppUsers14DaysContract.UserRole.Superintendent);
            List<appUsers> lstOperationsManager = oAppUsersHelper.lstGet14DaysContractUserByRole((int)AppUsers14DaysContract.UserRole.OperationsManager);

            foreach (appUsers oSuperintendent in lstSuperintendent)
            {
              ddlSuperintendent.Items.Add(new ListItem(y + ". " + oSuperintendent.m_sFullName + "{" + AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.Superintendent) + "}", oSuperintendent.m_iUserId.ToString()));
                y++;
            }
            foreach (appUsers oOperationsManager in lstOperationsManager)
            {
                ddlSuperintendent.Items.Add(new ListItem(y + ". " + oOperationsManager.m_sFullName + "{" + AppUsers14DaysContract.UserRoleDesc(AppUsers14DaysContract.UserRole.OperationsManager) + "}", oOperationsManager.m_iUserId.ToString()));
                y++;
            }
        }
    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        int i = 0;
        foreach (ListItem li in AssetCheckBoxList.Items)
        {
            if (li.Selected == false)
            {
                i++;
            }
        }

        if (i == AssetCheckBoxList.Items.Count)
        {
            string sRet2 = "Atleast, an Asset Area must be assigned to a Superintendent or Operations Manager.";
            ajaxWebExtension.showJscriptAlert(Page, this, sRet2);
        }
        else
        {
            //Get PlannerId
            //int iPlannerId = facility.GetPlannerID();

            //onlineUser Planner = OnlineUserAccess.objGetOnlineUserByUserId(int.Parse(drpPlanners.SelectedValue));
            //bool success = facility.AssignPlanner(Planner.m_iUserId, Planner.m_sUserName, Planner.m_sFullName, Planner.m_sUserMail);

            string sAssets = "";
            foreach (ListItem li in AssetCheckBoxList.Items)
            {
                if (li.Selected == true)
                {
                    //Check if selected Facility is found for the user
                    if (!FacilityAssetGMHelper.bGetIfFacilityHasBeenAssignedToGM(int.Parse(ddlSuperintendent.SelectedValue), int.Parse(li.Value)))
                    {
                        oFacilityAssetGMHelper.AssignFacilityToAssetGM(int.Parse(ddlSuperintendent.SelectedValue), int.Parse(li.Value));
                        sAssets += AssetCheckBoxList.Text + ", ";
                    }
                    //TODO: if previously selected facility has been deselected, what should be done?
                }
            }
            AssetCheckBoxList.ClearSelection();

            string mssg = "The following assets " + sAssets + " were successully assigned to " + ddlSuperintendent.SelectedItem.Text;
            ajaxWebExtension.showJscriptAlert(Page, this, mssg);
        }
    }
    protected void ddlSuperintendent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TODO: If a user is selected, check to see if the user already has Facilities assigned

        AssetCheckBoxList.ClearSelection();

        List<FacilityAssetGM> MyAssignedFacilities = FacilityAssetGMHelper.lstGetFacilitiesAssignedToGM(int.Parse(ddlSuperintendent.SelectedValue));
        foreach (FacilityAssetGM MyAssignedFacility in MyAssignedFacilities)
        {
            foreach (ListItem li in AssetCheckBoxList.Items)
            {
                if (li.Value == MyAssignedFacility.m_iFacilityId.ToString())
                {
                    li.Selected = true;
                }
            }
        }
    }
}