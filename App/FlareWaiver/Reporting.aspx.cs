using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_Reporting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Area> MyAreas = Area.lstGetAreas();
            foreach (Area MyArea in MyAreas)
            {
                ddlArea.Items.Add(new ListItem(MyArea.m_sAREA, MyArea.m_iIDAREA.ToString()));
            }
        }

        //oRequests1.HideColumn(1);
        //oRequests1.HideColumn(2);
        oRequests1.setPanelRequestStatus.Visible = false;
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        facilitiesCkbLst.Items.Clear();

        List<Facility> oFacilities = Facility.lstGetFacilitiesByArea(int.Parse(ddlArea.SelectedValue));
        foreach (Facility oFacility in oFacilities)
        {
            facilitiesCkbLst.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
        }

        //Report all facilities under area selected
        //oRequests1.LoadFlareWaiverRequestsByArea(int.Parse(ddlArea.SelectedValue));
        oRequests1.LoadFlareWaiverRequestsByArea2(int.Parse(ddlArea.SelectedValue));
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        //Report based on  the number of facilities selected

    }
}