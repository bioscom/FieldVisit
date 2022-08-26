using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerificationHeatMap : aspnetPage
{
    //PDR.MainReport oMainReport = new PDR.MainReport();
    //PDR.MainReportHelper oMainReportHelper = new PDR.MainReportHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //lblAssetDistrictFacility.Text = "RPI Verification Heat Map";
            PopulateTreeViewControl();

            cVerificationHeatMapHelper.getMonths(ddlMonth);
            //ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            LoadYear();
            pnlForm.Visible = false;
        }
    }

    private void LoadYear()
    {
        ddlYear.Items.Add(DateTime.Now.Year.ToString());
        List<int> iYears = cVerificationHeatMapHelper.lstYears();
        foreach (int iYear in iYears)
        {
            ddlYear.Items.Add(iYear.ToString());
        }
        //ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }

    private void PopulateTreeViewControl()
    {
        try
        {
            TreeNode parentNode = null;
            List<Assets> lstAssets = Assets.lstGetAssets();

            foreach (Assets asset in lstAssets)
            {
                parentNode = new TreeNode(asset.sAsset, asset.iAssetId.ToString());

                List<District> lstDistricts = District.lstGetDistrictByAsset(asset.iAssetId);

                foreach (District district in lstDistricts)
                {
                    TreeNode childNode = new TreeNode(district.m_sDistrict, district.m_iDistrictId.ToString());
                    parentNode.ChildNodes.Add(childNode);

                    List<facility> ofacilities = facility.lstGetFacilityByDistrict(district.m_iDistrictId);
                    foreach(facility tFacility in ofacilities)
                    {
                        TreeNode tChildNode = new TreeNode(tFacility.m_sFacility, tFacility.m_iFacilityId.ToString());
                        childNode.ChildNodes.Add(tChildNode);
                    }
                }

                parentNode.ExpandAll();

                // Show all checkboxes
                mnuTreeView.ShowCheckBoxes = TreeNodeTypes.All;
                mnuTreeView.Nodes.Add(parentNode);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void mnuTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            pnlForm.Visible = true;
            lblAssetDistrictFacility.Text = mnuTreeView.SelectedNode.Parent.Text + "(" + mnuTreeView.SelectedNode.Text + ") RPI Verification Heat Map";
            iFacilityId.Value = mnuTreeView.SelectedNode.Value;
            lblDate.Text = mnuTreeView.SelectedNode.Value;

            LoadData();

            //cVerificationHeatMap tVerification = cVerificationHeatMapHelper.objGetVerificationByMonthYear(int.Parse(iFacilityId.Value), int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue));
            //if (tVerification.lIdVerification != 0)
            //{
            //    ddlStandardised._SelectedValue(tVerification.iStandardisedWork);
            //    ddlGoSee._SelectedValue(tVerification.iGoSee);
            //    ddlStructuredDay._SelectedValue(tVerification.iStructuredDay);
            //    ddlMtceConsumables._SelectedValue(tVerification.iMtceConsumables);
            //}
            //else
            //{
            //    ddlStandardised.Page_Init();
            //    ddlGoSee.Page_Init();
            //    ddlStructuredDay.Page_Init();
            //    ddlMtceConsumables.Page_Init();
            //}

            ////int iDistrictId = District.objGetDistrictByName(mnuTreeView.SelectedNode.Text).m_iDistrictId;
            ////oMainReport.iDistrict = iDistrictId;
            ////oMainReport.iUserId = oSessnx.getOnlineUser.m_iUserId;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void LoadData()
    {
        cVerificationHeatMap tVerification = cVerificationHeatMapHelper.objGetVerificationByMonthYear(int.Parse(iFacilityId.Value), int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue));
        if (tVerification.lIdVerification != 0)
        {
            ddlStandardised._SelectedValue(tVerification.iStandardisedWork);
            ddlGoSee._SelectedValue(tVerification.iGoSee);
            ddlStructuredDay._SelectedValue(tVerification.iStructuredDay);
            ddlMtceConsumables._SelectedValue(tVerification.iMtceConsumables);
        }
        else
        {
            ddlStandardised.Page_Init();
            ddlGoSee.Page_Init();
            ddlStructuredDay.Page_Init();
            ddlMtceConsumables.Page_Init();
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/VerificationHeatMapReport.aspx?iMnt=" + ddlMonth.SelectedValue + "&iYr=" + ddlYear.SelectedValue);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        cVerificationHeatMap oVerification = new cVerificationHeatMap();

        oVerification.iFacilityId = int.Parse(iFacilityId.Value);
        oVerification.iStandardisedWork = int.Parse( ddlStandardised.ddlSelector.SelectedValue);
        oVerification.iGoSee = int.Parse(ddlGoSee.ddlSelector.SelectedValue);
        oVerification.iStructuredDay  = int.Parse(ddlStructuredDay.ddlSelector.SelectedValue);
        oVerification.iMtceConsumables = int.Parse(ddlMtceConsumables.ddlSelector.SelectedValue);
        oVerification.iMonth = int.Parse(ddlMonth.SelectedValue);
        oVerification.iYear = int.Parse(ddlYear.SelectedValue);
        oVerification.iUserId = oSessnx.getOnlineUser.m_iUserId;

        //Check to see if the selected Facility exists in the database for the selected Month and Year

        cVerificationHeatMap tVerification = cVerificationHeatMapHelper.objGetVerificationByMonthYear(int.Parse(iFacilityId.Value), int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue));
        if (tVerification.lIdVerification == 0)
        {
            bool bRet = cVerificationHeatMapHelper.Insert(oVerification);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Submitted sucessful.");
            }
        }
        else
        {
            oVerification.lIdVerification = tVerification.lIdVerification;
            bool bRet = cVerificationHeatMapHelper.Update(oVerification);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Update submitted sucessfully.");
            }
        }        
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
}