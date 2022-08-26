using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_Create : aspnetPage
{
    readonly Department _gDepartment = new Department();
    readonly AssetPdcc _gAsset = new AssetPdcc();

    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ValidateNumeric();

            List<AssetPdcc> lstAssets;
            if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Administrator)
            {
                //An Administrator should be able to see all department opportunities
                lstAssets = AssetPdcc.lstGetAssets();
                //getDataByAdmin(DateTime.Today.Year);
            }
            else
            {
                //Others should only be able to see Assets assigned to them.
                lstAssets = _gAsset.lstGetPdccAssetsByUser(oSessnx.getOnlineUser.m_iUserId, Convert.ToInt32(oSessnx.getOnlineUser.m_iRolePdcc));
                //getDataByUser();
            }

            foreach (AssetPdcc oAsset in lstAssets)
            {
                ddlAsset.Items.Add(new ListItem(oAsset.sAsset, oAsset.iAssetId.ToString()));
            }

            OpportunityCostHelper.getOpexYear(lblOpex);

            //Accept, Park, Done
            ddlAcceptPark.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.Select), ((int)ItemStatus.ItStatus.Select).ToString()));
            ddlAcceptPark.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.Accept), ((int)ItemStatus.ItStatus.Accept).ToString()));
            ddlAcceptPark.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.Park), ((int)ItemStatus.ItStatus.Park).ToString()));
            ddlAcceptPark.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.Done), ((int)ItemStatus.ItStatus.Done).ToString()));

            //Priority: 1,2,3
            ddlPriority.Items.Add(new ListItem("Priority", "-1"));
            ddlPriority.Items.Add(new ListItem("1", "1"));
            ddlPriority.Items.Add(new ListItem("2", "2"));
            ddlPriority.Items.Add(new ListItem("3", "3"));
     
            //Asset/Support Services
            ddlAssetSupport.ddlSelector.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.Select), ((int)ItemStatus.ItStatus.Select).ToString()));
            ddlAssetSupport.ddlSelector.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.All), ((int)ItemStatus.ItStatus.All).ToString()));
            ddlAssetSupport.ddlSelector.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.Offshore), ((int)ItemStatus.ItStatus.Offshore).ToString()));
            ddlAssetSupport.ddlSelector.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.Onshore), ((int)ItemStatus.ItStatus.Onshore).ToString()));
            ddlAssetSupport.ddlSelector.Items.Add(new ListItem(ItemStatus.status(ItemStatus.ItStatus.OnShoreOffShore), ((int)ItemStatus.ItStatus.OnShoreOffShore).ToString()));

            ddlSponsor.ErrorMssg("Project Sponsor is required. Please, select N/A if Sponsor not found, can be updated later.");
            ddlActionParty.ErrorMssg("Action Party is required. Please, select N/A if Action Party not found, can be updated later.");

            ddlAssetSupport.ErrorMssg("Asset/Support Service is required.");
            //ddlAssetSupport
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long lOpCostId = 0;
        try
        {
            OpportunityCost oOpportunityCost = new OpportunityCost();

            oOpportunityCost.iAssetId = int.Parse(ddlAsset.SelectedValue);
            oOpportunityCost.dtStartedBy = dtStarted.dtSelectedDate;
            oOpportunityCost.dtCompletedBy = dtCompleted.dtSelectedDate;
            oOpportunityCost.iSponsor = int.Parse(ddlSponsor._SelectedValue);
            oOpportunityCost.iActionParty = int.Parse(ddlActionParty._SelectedValue);
            oOpportunityCost.iAcceptPark = int.Parse(ddlAcceptPark.SelectedValue);
            oOpportunityCost.iPriority = int.Parse(ddlPriority.SelectedValue);

            oOpportunityCost.dFecto = !string.IsNullOrEmpty(txtFecto.Text) ? decimal.Parse(txtFecto.Text) : 0;
            oOpportunityCost.dImprovement = !string.IsNullOrEmpty(txtImprovement.Text) ? decimal.Parse(txtImprovement.Text) : 0;
            oOpportunityCost.dOpexYear = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;

            oOpportunityCost.iAsService = int.Parse(ddlAssetSupport.SelectedStatus);
            oOpportunityCost.sCostCentre = txtCostCentre.Text;
            oOpportunityCost.sOpportunity = txtOpportunity.Text;
            oOpportunityCost.DtDateUpdated = DateTime.Today.Date;
            oOpportunityCost.sWorkScope = txtWorkScope.Text;

            oOpportunityCost.dActSavings = decimal.Parse(txtActSavings.Text);
            oOpportunityCost.dPotSavings = decimal.Parse(txtPotSavings.Text);
            oOpportunityCost.sComments = txtComment.Text;

            oOpportunityCost.iLastUpdatedBy = oSessnx.getOnlineUser.m_iUserId;

            bool bRet = _opportunityCostHelper.CreateOpportunityCost(oOpportunityCost, ref lOpCostId);
            if (bRet)
            {
                //Enter values into the Opportunity Cost log table
                _opportunityCostHelper.CreateOpportunityCostLog(oOpportunityCost, lOpCostId);
                ajaxWebExtension.showJscriptAlert(Page, this, txtOpportunity.Text + ", Submitted successfully!!!");
                Clear();
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void Clear()
    {
        txtFecto.Text = ""; 
        txtImprovement.Text = ""; 
        txtOpexYear.Text = "";
        txtCostCentre.Text = "";
        txtOpportunity.Text = "";
        txtWorkScope.Text = "";
        txtActSavings.Text = "";
        txtPotSavings.Text = "";
        txtComment.Text = "";
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/PDCC/OpportunityCostsChallenges.aspx");
    }

    private void ValidateNumeric()
    {
        txtFecto.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtImprovement.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtActSavings.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtOpexYear.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtPotSavings.Attributes.Add("onkeypress", "return numericOnly(this);");
    }
}