using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;

public partial class Forms_Setup_PlannerFacilityMapView : aspnetPage
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

        loadData();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton) row.FindControl("deleteLinkButton");
        int iUserID = int.Parse(lnkDelete.Attributes["USERID"].ToString());
        int ifacilityId = int.Parse(lnkDelete.Attributes["IDFACILITY"].ToString());

        bool success = facility.RemovePlannerFromFacility(ifacilityId, iUserID);
        if (success)
        {
            loadData();
            ajaxWebExtension.showJscriptAlert(Page, this, "User successfully Removed from this facility.");
        }
    }


    private void loadData()
    {
        grdView.DataSource = Superintendent.dtGetSuperintendent();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblSuperintendent = (Label)grdRow.FindControl("lblSuperintendent");
            int SuperIntendentID = int.Parse(lblSuperintendent.Attributes["ID_SUPERINTENDENT"].ToString());

            BulletedList DistrictLst = (BulletedList)grdRow.FindControl("DistrictLst");
            BulletedList FacilityLst = (BulletedList)grdRow.FindControl("FacilityLst");
            BulletedList PlannerLst = (BulletedList)grdRow.FindControl("PlannerLst");
            GridView subGrdView = (GridView)grdRow.FindControl("subGrdView");

            List<District> districts = District.lstGetDistrictBySuperintendent(SuperIntendentID);
            foreach (District district in districts)
            {
                DistrictLst.Items.Add(new ListItem(district.m_sDistrict, district.m_iDistrictId.ToString()));
            }

            foreach (District district in districts)
            {
                DataTable dt = facility.dtGetFacilityByDistrictId(district.m_iDistrictId);
                if (dt.Rows.Count > 0)
                {
                    subGrdView.DataSource = dt;
                    subGrdView.DataBind();
                }
            }
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}