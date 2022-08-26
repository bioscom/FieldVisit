using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_FlareWaiver_Reports_FlareFinder : aspnetPage
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

            cVerificationHeatMapHelper.getMonths(ddlMonth);

            //List<int> iYears = FlareWaiverRpt.LstYearsExt();
            //foreach (int iYear in iYears)
            //{
            //    ddlYear.Items.Add(iYear.ToString());
            //}

            //cVerificationHeatMapHelper.getMonths(ddlMonthFrom);
            //cVerificationHeatMapHelper.getMonths(ddlMonthTo);
        }
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFacility.Items.Clear();
        ddlFacility.Items.Add(new ListItem("Select Facility", "-1"));

        //List<Facility> oFacilities = Facility.lstGetAGGFacilitiesByArea(int.Parse(ddlArea.SelectedValue));
        List<Facility> oFacilities = Facility.lstGetFacilitiesByArea(int.Parse(ddlArea.SelectedValue));
        foreach (Facility oFacility in oFacilities)
        {
            ddlFacility.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
        }
    }
    protected void btnRpt_Click(object sender, EventArgs e)
    {
        try
        {
            lblStation.Text = ddlArea.SelectedItem.Text + " " + ddlFacility.SelectedItem.Text;
            lblStation2.Text = ddlArea.SelectedItem.Text + " " + ddlFacility.SelectedItem.Text;

            FlareWaiverRequestHelper o = new FlareWaiverRequestHelper();
            Facility Fac = Facility.objGetFacilityById(int.Parse(ddlFacility.SelectedValue));

            DataTable dt = o.dtGetFlareWaiverRequestByFacilityCode(Fac.m_sCode, int.Parse(ddlMonth.SelectedValue), DateTime.Now.Year);
            grdVWFlare.DataSource = dt;
            grdVWFlare.DataBind();
            if (dt.Rows.Count == 0)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "No approved Gas Flare Waiver found.");
            }

            //Connect to EC and Execute this query
            grdVWEC.DataSource = o.dtGetFlareWaiverRequestEC(int.Parse(ddlMonth.SelectedValue), DateTime.Now.Year, Fac.m_sCode);
            grdVWEC.DataBind();            
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}