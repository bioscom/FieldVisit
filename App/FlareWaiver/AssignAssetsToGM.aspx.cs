using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class App_FlareWaiver_AssignAssetsToGM : aspnetPage
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

            List<Facility> oFacilities = Facility.lstGetFacilities(); //Load Facilities
            foreach (Facility oFacility in oFacilities)
            {
                //ddlFacilities.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
                //facilitiesCkbLst.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
                facilitiesCheckBoxList.Items.Add(new ListItem(x + ". " + Encoder.HtmlEncode(oFacility.m_sFacility) , Encoder.HtmlEncode(oFacility.m_iFacilityId.ToString())));
                x++;
            }


            //List<facility> fieldFacilities = facility.lstGetFacility();
            //foreach (facility fieldFacility in fieldFacilities)
            //{
            //    facilitiesCheckBoxList.Items.Add(new ListItem(x + ". " + "  <b><font color='Navy'>[" + Encoder.HtmlEncode(fieldFacility.eDistrict.m_sDistrict) + "]</font></b>" + Encoder.HtmlEncode(fieldFacility.m_sFacility) + "  <b><font color='Green'>[" + Encoder.HtmlEncode(fieldFacility.eSuperintendent.m_sSuperintendent) + "]</font></b>", Encoder.HtmlEncode(fieldFacility.m_iFacilityId.ToString())));
            //    x++;
            //}

            int y = 1;
            List<appUsers> lstGMOffShore = oAppUsersHelper.lstGetFlareWaiverUserByRole((int)appUserRolesFlrWaiver.userRole.AssuranceOffshore);
            List<appUsers> lstGMOnShore = oAppUsersHelper.lstGetFlareWaiverUserByRole((int)appUserRolesFlrWaiver.userRole.AssuranceOnshore);

            foreach (appUsers oGMOffShore in lstGMOffShore)
            {
                drpGMOnOffShore.Items.Add(new ListItem(y + ". " + oGMOffShore.m_sFullName + "{" + appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOffshore) + "}", oGMOffShore.m_iUserId.ToString()));
                y++;
            }
            foreach (appUsers oGMOnShore in lstGMOnShore)
            {
                drpGMOnOffShore.Items.Add(new ListItem(y + ". " + oGMOnShore.m_sFullName + "{" + appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOnshore) + "}", oGMOnShore.m_iUserId.ToString()));
                y++;
            }
        }
    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        int i = 0;
        foreach (ListItem li in facilitiesCheckBoxList.Items)
        {
            if (li.Selected == false)
            {
                i++;
            }
        }

        if (i == facilitiesCheckBoxList.Items.Count)
        {
            string sRet2 = "Atleast, a facility must be assigned to a GM Offshore or Onshore.";
            ajaxWebExtension.showJscriptAlert(Page, this, sRet2);
        }
        else
        {
            //Get PlannerId
            //int iPlannerId = facility.GetPlannerID();

            //onlineUser Planner = OnlineUserAccess.objGetOnlineUserByUserId(int.Parse(drpPlanners.SelectedValue));
            //bool success = facility.AssignPlanner(Planner.m_iUserId, Planner.m_sUserName, Planner.m_sFullName, Planner.m_sUserMail);

            string sFacilities = "";
            foreach (ListItem li in facilitiesCheckBoxList.Items)
            {
                if (li.Selected == true)
                {
                    //Check if selected Facility is found for the user
                    if (!FacilityAssetGMHelper.bGetIfFacilityHasBeenAssignedToGM(int.Parse(drpGMOnOffShore.SelectedValue), int.Parse(li.Value)))
                    {
                        oFacilityAssetGMHelper.AssignFacilityToAssetGM(int.Parse(drpGMOnOffShore.SelectedValue), int.Parse(li.Value));
                        sFacilities += facilitiesCheckBoxList.Text + ", ";
                    }
                    //TODO: if previously selected facility has been deselected, what should be done?
                }
            }
            facilitiesCheckBoxList.ClearSelection();

            string mssg = "The following facilities " + sFacilities + " were successully assigned to " + drpGMOnOffShore.SelectedItem.Text;
            ajaxWebExtension.showJscriptAlert(Page, this, mssg);
        }
    }
    protected void drpGMOnOffShore_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TODO: If a user is selected, check to see if the user already has Facilities assigned

        facilitiesCheckBoxList.ClearSelection();

        List<FacilityAssetGM> MyAssignedFacilities = FacilityAssetGMHelper.lstGetFacilitiesAssignedToGM(int.Parse(drpGMOnOffShore.SelectedValue));
        foreach (FacilityAssetGM MyAssignedFacility in MyAssignedFacilities)
        {
            foreach (ListItem li in facilitiesCheckBoxList.Items)
            {
                if (li.Value == MyAssignedFacility.m_iFacilityId.ToString())
                {
                    li.Selected = true;
                }
            }
        }
    }
}