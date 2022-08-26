using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_UserControl_PDSavings : aspnetUserControl
{
    PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Button buttonSaveEstimate
    {
        get
        {
            return btnSaveEstimate;
        }
    }

    public Button buttonSaveActual
    {
        get
        {
            return btnSaveActual;
        }
    }

    public Button buttonSaveLE
    {
        get
        {
            return btnSaveLE;
        }
    }

    public void Init_ControlEstimatedSavings(int iAssetId, int iMonth, int iYear)
    {
        ClearControls();
        ValidateNumeric();
        //Clear Hidden Fields in the First Place
        HFAsset.Value = ""; HFMonth.Value = ""; HFYear.Value = ""; HFEstimated.Value = "";

        //Initiaise Hidden Fields
        HFAsset.Value = iAssetId.ToString();
        HFMonth.Value = iMonth.ToString();
        HFYear.Value = iYear.ToString();

        //Initialise Controls for Estimated Savings
        PDEstimatedSavings oPDEstimatedSavings = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, iMonth, iYear);
        if (oPDEstimatedSavings.lEstimateId != 0)
        {
            ClearControls();
            HFEstimated.Value = oPDEstimatedSavings.lEstimateId.ToString();
            txtDeepDive.Text = oPDEstimatedSavings.dDD.ToString();
            txtDeepDiveOppor.Text = oPDEstimatedSavings.dDDO.ToString();
            txtEIO.Text = oPDEstimatedSavings.dEIO.ToString();
        }
    }

    public void Init_ControlActualSavings(int iAssetId, int iMonth, int iYear)
    {
        ClearControls();
        ValidateNumeric();
        //Clear Hidden Fields in the First Place
        HFAsset.Value = ""; HFMonth.Value = ""; HFYear.Value = ""; HFActual.Value = "";

        //Initiaise Hidden Fields
        HFAsset.Value = iAssetId.ToString();
        HFMonth.Value = iMonth.ToString();
        HFYear.Value = iYear.ToString();

        //Initialise Controls for Actual Savings
        PDActualSavings oPDActualSavings = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, iMonth, iYear);
        if (oPDActualSavings.lActualId != 0)
        {
            ClearControls();
            HFActual.Value = oPDActualSavings.lActualId.ToString();
            txtDeepDive.Text = oPDActualSavings.dDD.ToString();
            txtDeepDiveOppor.Text = oPDActualSavings.dDDO.ToString();
            txtEIO.Text = oPDActualSavings.dEIO.ToString();
        }
    }

    public void Init_ControlLESavings(int iAssetId, int iMonth, int iYear)
    {
        ClearControls();
        ValidateNumeric();
        //Clear Hidden Fields in the First Place
        HFAsset.Value = ""; HFMonth.Value = ""; HFYear.Value = ""; HFLE.Value = "";

        //Initiaise Hidden Fields
        HFAsset.Value = iAssetId.ToString();
        HFMonth.Value = iMonth.ToString();
        HFYear.Value = iYear.ToString();

        //Initialise Controls for Actual Savings
        PDLESavings oPDLESavings = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, iMonth, iYear);
        if (oPDLESavings.lLEId != 0)
        {
            ClearControls();
            HFLE.Value = oPDLESavings.lLEId.ToString();
            txtDeepDive.Text = oPDLESavings.dDD.ToString();
            txtDeepDiveOppor.Text = oPDLESavings.dDDO.ToString();
            txtEIO.Text = oPDLESavings.dEIO.ToString();
        }
    }

    private void ClearControls()
    {
        txtDeepDive.Text = "";
        txtDeepDiveOppor.Text = "";
        txtEIO.Text = "";
    }

    private void EstimatedSavings()
    {
        bool bRet = false;
        PDEstimatedSavings oPDEstimatedSavings = new PDEstimatedSavings();
        oPDEstimatedSavings.iAssetId = int.Parse(HFAsset.Value);
        oPDEstimatedSavings.iMonth = int.Parse(HFMonth.Value);
        oPDEstimatedSavings.iYear = int.Parse(HFYear.Value);
        oPDEstimatedSavings.iUserId = oSessnx.getOnlineUser.m_iUserId;
        oPDEstimatedSavings.dDD = !string.IsNullOrEmpty(txtDeepDive.Text) ? decimal.Parse(txtDeepDive.Text) : 0;
        oPDEstimatedSavings.dDDO = !string.IsNullOrEmpty(txtDeepDiveOppor.Text) ? decimal.Parse(txtDeepDiveOppor.Text) : 0;
        oPDEstimatedSavings.dEIO = !string.IsNullOrEmpty(txtEIO.Text) ? decimal.Parse(txtEIO.Text) : 0;

        if (string.IsNullOrEmpty(HFEstimated.Value))
        {
            bRet = oPDCostReductionSummaryHelper.InsertEstimatedSavings(oPDEstimatedSavings);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDEstimatedSavings.iAssetId).sAsset + ", Estimated Saving successfully submitted.");
            }
        }
        else
        {
            oPDEstimatedSavings.lEstimateId = long.Parse(HFEstimated.Value);
            bRet = oPDCostReductionSummaryHelper.UpdateEstimatedSavings(oPDEstimatedSavings);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDEstimatedSavings.iAssetId).sAsset + ", Estimated Saving successfully updated.");
            }
        }
    }

    private void ActualSavings()
    {
        bool bRet = false;
        PDActualSavings oPDActualSavings = new PDActualSavings();
        oPDActualSavings.iAssetId = int.Parse(HFAsset.Value);
        oPDActualSavings.iMonth = int.Parse(HFMonth.Value);
        oPDActualSavings.iYear = int.Parse(HFYear.Value);
        oPDActualSavings.iUserId = oSessnx.getOnlineUser.m_iUserId;
        oPDActualSavings.dDD = !string.IsNullOrEmpty(txtDeepDive.Text) ? decimal.Parse(txtDeepDive.Text) : 0;
        oPDActualSavings.dDDO = !string.IsNullOrEmpty(txtDeepDiveOppor.Text) ? decimal.Parse(txtDeepDiveOppor.Text) : 0;
        oPDActualSavings.dEIO = !string.IsNullOrEmpty(txtEIO.Text) ? decimal.Parse(txtEIO.Text) : 0;

        if (string.IsNullOrEmpty(HFActual.Value))
        {
            bRet = oPDCostReductionSummaryHelper.InsertActualSavings(oPDActualSavings);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDActualSavings.iAssetId).sAsset + ", Actual Saving successfully submitted.");
            }
        }
        else
        {
            oPDActualSavings.lActualId = long.Parse(HFActual.Value);
            bRet = oPDCostReductionSummaryHelper.UpdateActualSavings(oPDActualSavings);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDActualSavings.iAssetId).sAsset + ", Actual Saving successfully updated.");
            }
        }
    }

    private void LatestEstimateSavings()
    {
        bool bRet = false;
        PDLESavings oPDLESavings = new PDLESavings();
        oPDLESavings.iAssetId = int.Parse(HFAsset.Value);
        oPDLESavings.iMonth = int.Parse(HFMonth.Value);
        oPDLESavings.iYear = int.Parse(HFYear.Value);
        oPDLESavings.iUserId = oSessnx.getOnlineUser.m_iUserId;
        oPDLESavings.dDD = !string.IsNullOrEmpty(txtDeepDive.Text) ? decimal.Parse(txtDeepDive.Text) : 0;
        oPDLESavings.dDDO = !string.IsNullOrEmpty(txtDeepDiveOppor.Text) ? decimal.Parse(txtDeepDiveOppor.Text) : 0;
        oPDLESavings.dEIO = !string.IsNullOrEmpty(txtEIO.Text) ? decimal.Parse(txtEIO.Text) : 0;

        if (string.IsNullOrEmpty(HFLE.Value))
        {
            bRet = oPDCostReductionSummaryHelper.InsertLESavings(oPDLESavings);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDLESavings.iAssetId).sAsset + ", LE Saving successfully submitted.");
            }
        }
        else
        {
            oPDLESavings.lLEId = long.Parse(HFLE.Value);
            bRet = oPDCostReductionSummaryHelper.UpdateLESavings(oPDLESavings);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDLESavings.iAssetId).sAsset + ", LE Saving successfully updated.");
            }
        }
    }

    protected void btnSaveEstimate_Click(object sender, EventArgs e)
    {
        EstimatedSavings();
    }
    protected void btnSaveActual_Click(object sender, EventArgs e)
    {
        ActualSavings();
    }

    private void ValidateNumeric()
    {
        txtDeepDive.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtDeepDiveOppor.Attributes.Add("onkeypress", "return numericOnly(this);");
        txtEIO.Attributes.Add("onkeypress", "return numericOnly(this);");
    }
    protected void btnSaveLE_Click(object sender, EventArgs e)
    {
        LatestEstimateSavings();
    }
}