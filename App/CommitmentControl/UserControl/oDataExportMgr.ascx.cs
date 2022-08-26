using System;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Linq;

public partial class App_BONGACCP_UserControl_oDataExportMgr : System.Web.UI.UserControl
{
    OUMgt oU = new OUMgt();
    TeamMgt oTeam = new TeamMgt();
    CommitmentsMgt o = new CommitmentsMgt();
    Department oD = new Department();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        LoadControls();
    }

    private void LoadControls()
    {
        List<OU> olstOU = oU.lstGetOUS();
        foreach (var listItem in olstOU.Select(r => new RadComboBoxItem(r.m_sOUS, r.m_iOUId.ToString())))
        {
            ddlOU.Items.Add(listItem);
            ddlOU.DataBind();
        }

        List<Assets> olstAssets = Assets.lstGetAssets();
        foreach (var listItem in olstAssets.Select(r => new RadComboBoxItem(r.sAsset, r.iAssetId.ToString())))
        {
            ddlAsset.Items.Add(listItem);
            ddlAsset.DataBind();
        }

        List<facility> olstFacility = facility.lstGetFacility();
        foreach (var listItem in olstFacility.Select(r => new RadComboBoxItem(r.m_sFacility, r.m_iFacilityId.ToString())))
        {
            ddlFacility.Items.Add(listItem);
            ddlFacility.DataBind();
        }

        List<Department> olstTeam = oD.lstGetDeparments();
        foreach (var listItem in olstTeam.Select(r => new RadComboBoxItem(r.m_sDepartment, r.m_iDepartmentId.ToString())))
        {
            ddlteam.Items.Add(listItem);
            ddlteam.DataBind();
        }

        //Capex Opex.
        ddlCapexOpex.Items.Add(new RadComboBoxItem(CapexOpex.CapexOpexDesc(CapexOpex.CapexOpexx.Capex), ((int)CapexOpex.CapexOpexx.Capex).ToString()));
        ddlCapexOpex.Items.Add(new RadComboBoxItem(CapexOpex.CapexOpexDesc(CapexOpex.CapexOpexx.Opex), ((int)CapexOpex.CapexOpexx.Opex).ToString()));

    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        List<Commitments> lstComm = new List<Commitments>();
        lstComm = o.lstCommitments(ddlOU.SelectedValue, dtFrom.SelectedDate, dtTo.SelectedDate, ddlAsset.SelectedValue, ddlFacility.SelectedValue, ddlteam.SelectedValue, ddlCapexOpex.SelectedValue);

        o.ExporttoExcel(lstComm);
    }
}