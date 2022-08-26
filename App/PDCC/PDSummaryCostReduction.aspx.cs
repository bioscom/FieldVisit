using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_PDSummaryCostReduction : aspnetPage
{
    readonly AssetPdcc _gAsset = new AssetPdcc();

    PDCostReductionSummary oPDCostReductionSummary = new PDCostReductionSummary();
    PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
    TransactionYear oTrans = new TransactionYear();
    
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

        }
    }

    private void ValidateNumeric()
    {
        txtOpexYear.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtDDBanked.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtDDOpportunity.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtDDOpporBanked.Attributes.Add("onkeypress", "return numericOnly(this);");
        
        txtEffImprovement.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtEffImprovementBanked.Attributes.Add("onkeypress", "return numericOnly(this);");

        txtDDBankableAsAt.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtDDExpected.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtDDOpporExpected.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtEffImprovementActual.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtEIOAvoidance.Attributes.Add("onkeypress", "return numericOnly(this);");

        //txtFecto.Attributes.Add("onkeypress", "return numericOnly(this);");
        //txtImprovement.Attributes.Add("onkeypress", "return numericOnly(this);");
        //txtActSavings.Attributes.Add("onkeypress", "return numericOnly(this);");
        //txtPotSavings.Attributes.Add("onkeypress", "return numericOnly(this);");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            oPDCostReductionSummary.iAssetId = int.Parse(ddlAsset.SelectedValue);
            oPDCostReductionSummary.dDeepDiveBanked = !string.IsNullOrEmpty(txtDDBanked.Text) ? decimal.Parse(txtDDBanked.Text) : 0;
            oPDCostReductionSummary.dDeepDiveBankable = !string.IsNullOrEmpty(txtDDBankableAsAt.Text) ? decimal.Parse(txtDDBankableAsAt.Text) : 0;
            oPDCostReductionSummary.dDeepDiveExpected = !string.IsNullOrEmpty(txtDDExpected.Text) ? decimal.Parse(txtDDExpected.Text) : 0;
            
            oPDCostReductionSummary.dDeepDiveOppor = !string.IsNullOrEmpty(txtDDOpportunity.Text) ? decimal.Parse(txtDDOpportunity.Text) : 0;
            oPDCostReductionSummary.dDeepDiveOpporBanked = !string.IsNullOrEmpty(txtDDOpporBanked.Text) ? decimal.Parse(txtDDOpporBanked.Text) : 0;
            oPDCostReductionSummary.dDeepDiveOpporExpected = !string.IsNullOrEmpty(txtDDOpporExpected.Text) ? decimal.Parse(txtDDOpporExpected.Text) : 0;

            oPDCostReductionSummary.dEIO = !string.IsNullOrEmpty(txtEffImprovement.Text) ? decimal.Parse(txtEffImprovement.Text) : 0;
            oPDCostReductionSummary.dEIOBanked = !string.IsNullOrEmpty(txtEffImprovementBanked.Text) ? decimal.Parse(txtEffImprovementBanked.Text) : 0;
            oPDCostReductionSummary.dEIOActual = !string.IsNullOrEmpty(txtEffImprovementActual.Text) ? decimal.Parse(txtEffImprovementActual.Text) : 0;
            oPDCostReductionSummary.dEIOCostAvoidance = !string.IsNullOrEmpty(txtEIOAvoidance.Text) ? decimal.Parse(txtEIOAvoidance.Text) : 0;

            oPDCostReductionSummary.dOpex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
            oPDCostReductionSummary.sPerformanceDescription = txtPerfDescription.Text;
            oPDCostReductionSummary.iUserId = oSessnx.getOnlineUser.m_iUserId;

            bool bRet = false;
            if (string.IsNullOrEmpty(lCostIdHF.Value))
            {
                bRet = oPDCostReductionSummaryHelper.CreatePDCostReductionSummary(oPDCostReductionSummary);
                if (bRet)
                    ajaxWebExtension.showJscriptAlert(Page, this, "Successfully submitted!!!");
                else
                    ajaxWebExtension.showJscriptAlert(Page, this, "Not Successfully submitted, try again later!!!");
            }
            else
            {
                oPDCostReductionSummary.lCost = long.Parse(lCostIdHF.Value);
                bRet = oPDCostReductionSummaryHelper.UpdatePDCostReductionSummary(oPDCostReductionSummary);
                if (bRet)
                    ajaxWebExtension.showJscriptAlert(Page, this, "Successfully Updated!!!");
                else
                    ajaxWebExtension.showJscriptAlert(Page, this, "Not Successfully updated, try again later!!!");
            }

            LoadData();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void CalculateValues()
    {
        decimal Opex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
        decimal DDBanked = !string.IsNullOrEmpty(txtDDBanked.Text) ? decimal.Parse(txtDDBanked.Text) : 0;
        decimal DDOpporBanked = !string.IsNullOrEmpty(txtDDOpporBanked.Text) ? decimal.Parse(txtDDOpporBanked.Text) : 0;
        
        decimal dEioBanked = !string.IsNullOrEmpty(txtEffImprovementBanked.Text) ? decimal.Parse(txtEffImprovementBanked.Text) : 0;
        decimal dEio = !string.IsNullOrEmpty(txtEffImprovement.Text) ? decimal.Parse(txtEffImprovement.Text) : 0;


        lblTotalDDBanked.Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.TotalDDBanked(DDBanked, DDOpporBanked));

        lblPerDDBanked.Text = oPDCostReductionSummaryHelper.PercentageDDBanked(Opex, DDBanked, DDOpporBanked).ToString();
        lblPerEIOBanked.Text = oPDCostReductionSummaryHelper.PercentageEioBanked(dEioBanked, dEio).ToString();

        lblAllSavingsBanked.Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.AllSavingsBanked(dEioBanked, DDBanked, DDOpporBanked));
        lblPerSavingsBanked.Text = oPDCostReductionSummaryHelper.PercentageSavingsBanked(Opex, dEioBanked, DDBanked, DDOpporBanked).ToString();

        lblPercTargetReduction.Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.TargetReduction(Opex));

        lblCurrentGap.Text = stringRoutine.formatAsBankMoney((oPDCostReductionSummaryHelper.TargetReduction(Opex) - oPDCostReductionSummaryHelper.AllSavingsBanked(dEioBanked, DDBanked, DDOpporBanked)));
    }

    //private decimal TotalDDBanked()
    //{
    //    decimal DDBanked = !string.IsNullOrEmpty(txtDDBanked.Text) ? decimal.Parse(txtDDBanked.Text) : 0;
    //    decimal DDOpporBanked = !string.IsNullOrEmpty(txtDDOpporBanked.Text) ? decimal.Parse(txtDDOpporBanked.Text) : 0;
    //    decimal totDDBanked = DDBanked + DDOpporBanked;

    //    return totDDBanked;
    //}

    //private decimal PercentageDDBanked()
    //{
    //    decimal Opex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
    //    decimal PerDDBanked = (TotalDDBanked() / Opex) * 100;

    //    return Math.Round(PerDDBanked, 1);
    //}    

    //private decimal PercentageEioBanked()
    //{
    //    decimal dEioBanked = !string.IsNullOrEmpty(txtEffImprovementBanked.Text) ? decimal.Parse(txtEffImprovementBanked.Text) : 0;
    //    decimal dEio = !string.IsNullOrEmpty(txtEffImprovement.Text) ? decimal.Parse(txtEffImprovement.Text) : 0;
    //    decimal PerEioBanked = (dEioBanked / dEio) * 100;

    //    return Math.Round(PerEioBanked, 1);
    //}

    //private decimal AllSavingsBanked()
    //{
    //    decimal dEioBanked = !string.IsNullOrEmpty(txtEffImprovementBanked.Text) ? decimal.Parse(txtEffImprovementBanked.Text) : 0;
    //    decimal dAllSavingsbanked = TotalDDBanked() + dEioBanked;

    //    return dAllSavingsbanked;
    //}

    //private decimal PercentageSavingsBanked()
    //{
    //    decimal Opex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
    //    decimal PercBanked = (AllSavingsBanked() / Opex) * 100;

    //    return Math.Round(PercBanked, 1);
    //}

    //private decimal TargetReduction()
    //{
    //    decimal Opex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
    //    decimal PercTargetRedtn = Opex * 0.25M;

    //    return PercTargetRedtn;
    //}


    protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }


    private void LoadData()
    {
        Clear();

        PDCostReductionSummary oPDCostReductionSummary = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(int.Parse(ddlAsset.SelectedValue), oTrans.tYear().iYear);
        // DateTime.Today.Year
        if (oPDCostReductionSummary.lCost != 0)
        {
            txtDDBanked.Text = oPDCostReductionSummary.dDeepDiveBanked.ToString();
            txtDDOpportunity.Text = oPDCostReductionSummary.dDeepDiveOppor.ToString();
            txtDDOpporBanked.Text = oPDCostReductionSummary.dDeepDiveOpporBanked.ToString();
            txtEffImprovement.Text = oPDCostReductionSummary.dEIO.ToString();
            txtEffImprovementBanked.Text = oPDCostReductionSummary.dEIOBanked.ToString();
            txtOpexYear.Text = oPDCostReductionSummary.dOpex.ToString();
            txtPerfDescription.Text = oPDCostReductionSummary.sPerformanceDescription;

            txtDDBankableAsAt.Text = oPDCostReductionSummary.dDeepDiveBankable.ToString();
            txtDDExpected.Text = oPDCostReductionSummary.dDeepDiveExpected.ToString();
            txtDDOpporExpected.Text = oPDCostReductionSummary.dDeepDiveOpporExpected.ToString();
            txtEffImprovementActual.Text = oPDCostReductionSummary.dEIOActual.ToString();
            txtEIOAvoidance.Text = oPDCostReductionSummary.dEIOCostAvoidance.ToString();

            lCostIdHF.Value = oPDCostReductionSummary.lCost.ToString();
            CalculateValues();
        }
    }
    

    private void Clear()
    {
        txtDDBanked.Text = "";
        txtDDOpportunity.Text = "";
        txtDDOpporBanked.Text = "";
        txtEffImprovement.Text = "";
        txtEffImprovementBanked.Text = "";
        txtOpexYear.Text = "";
        txtPerfDescription.Text = "";
        lblTotalDDBanked.Text = "";
        lblPerDDBanked.Text = "";
        lblPerEIOBanked.Text = "";
        lblAllSavingsBanked.Text = "";
        lblPerSavingsBanked.Text = "";
        lblPercTargetReduction.Text = "";
        lblCurrentGap.Text = "";
        lCostIdHF.Value = "";

        txtDDBankableAsAt.Text = "";
        txtDDExpected.Text = "";
        txtDDOpporExpected.Text = "";
        txtEffImprovementActual.Text = "";
        txtEIOAvoidance.Text = "";
    }
}