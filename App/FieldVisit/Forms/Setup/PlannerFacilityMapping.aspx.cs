using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class Setup_PlannerFacilityMapping : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFieldVisit);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            int x = 1;
            List<facility> fieldFacilities = facility.lstGetFacility();
            foreach (facility fieldFacility in fieldFacilities)
            {
                facilitiesCheckBoxList.Items.Add(new ListItem(x + ". " + "  <b><font color='Navy'>[" + Encoder.HtmlEncode(fieldFacility.eDistrict.m_sDistrict) + "]</font></b>" + Encoder.HtmlEncode(fieldFacility.m_sFacility) + "  <b><font color='Green'>[" + Encoder.HtmlEncode(fieldFacility.eSuperintendent.m_sSuperintendent) + "]</font></b>", Encoder.HtmlEncode(fieldFacility.m_iFacilityId.ToString())));
                x++;
            }

            int y = 1;
            List<appUsers> Planners = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.planner);
            foreach (appUsers Planner in Planners)
            {
                drpPlanners.Items.Add(new ListItem(y + ". " + Planner.m_sFullName, Planner.m_iUserId.ToString()));
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
            string sRet2 = "Atleast, a facility must be assigned to a Planner.";
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
                    if (!PlannersAssignedFacilities.bGetIfFacilityHasBeenAssignedToUser(int.Parse(drpPlanners.SelectedValue), int.Parse(li.Value)))
                    {
                        facility.AssignFacilityToPlanner(int.Parse(drpPlanners.SelectedValue), int.Parse(li.Value));
                        sFacilities = sFacilities + facilitiesCheckBoxList.Text + ", ";
                    }
                    //TODO: if previously selected facility has been deselected, what should be done?
                }
            }
            facilitiesCheckBoxList.ClearSelection();

            string mssg = "Selected facilities were successully assigned to " + drpPlanners.SelectedItem.Text;
            ajaxWebExtension.showJscriptAlert(Page, this, mssg);
        }
    }
    
    protected void viwLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Forms/Setup/PlannerFacilityMapView.aspx");
    }
    protected void drpPlanners_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TODO: If a user is selected, check to see if the user already has Facilities assigned
        List<PlannersAssignedFacilities> MyAssignedFacilities = PlannersAssignedFacilities.lstGetFacilitiesAssignedToPlanner(int.Parse(drpPlanners.SelectedValue));
        foreach (PlannersAssignedFacilities MyAssignedFacility in MyAssignedFacilities)
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
