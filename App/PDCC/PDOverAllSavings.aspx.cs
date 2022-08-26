using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_PDOverAllSavings : System.Web.UI.Page
{
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cVerificationHeatMapHelper.getMonths(ddlMonth);
            lblYear.Text = oTrans.tYear().iYear.ToString(); //DateTime.Today.Year.ToString();

            grdView.DataSource = AssetPdcc.dtGetAssets();
            grdView.DataBind();

            LoadControls();
        }
    }

    private void LoadControls()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbAsset = (Label)grdRow.FindControl("lbAsset");
            int iAssetId = int.Parse(lbAsset.Attributes["ASSETID"].ToString());
            ASP.app_pdcc_usercontrol_pdsavings_ascx oPdEstimatedSavings = (ASP.app_pdcc_usercontrol_pdsavings_ascx)grdRow.FindControl("PDSavingsEstimated");
            ASP.app_pdcc_usercontrol_pdsavings_ascx oPdActualSavings = (ASP.app_pdcc_usercontrol_pdsavings_ascx)grdRow.FindControl("PDSavingsActual");
            ASP.app_pdcc_usercontrol_pdsavings_ascx oPdLESavings = (ASP.app_pdcc_usercontrol_pdsavings_ascx)grdRow.FindControl("PDLatestEstimate");
            //
            oPdEstimatedSavings.Init_ControlEstimatedSavings(iAssetId, int.Parse(ddlMonth.SelectedValue), oTrans.tYear().iYear); oPdEstimatedSavings.buttonSaveActual.Visible = false; oPdEstimatedSavings.buttonSaveLE.Visible = false;
            oPdActualSavings.Init_ControlActualSavings(iAssetId, int.Parse(ddlMonth.SelectedValue), oTrans.tYear().iYear); oPdActualSavings.buttonSaveEstimate.Visible = false; oPdActualSavings.buttonSaveLE.Visible = false;
            oPdLESavings.Init_ControlLESavings(iAssetId, int.Parse(ddlMonth.SelectedValue), oTrans.tYear().iYear); oPdLESavings.buttonSaveActual.Visible = false; oPdLESavings.buttonSaveEstimate.Visible = false;
        }

        PDEstimatedSavings.Init_ControlEstimatedSavings(oTrans.tYear().iYear);
        PDActualSavings.Init_ControlActualSavings(oTrans.tYear().iYear);
        PDLESavingsViewer.Init_ControlLESavings(oTrans.tYear().iYear);

        PDValue.Init_Control(oTrans.tYear().iYear);
        PDCummulative.Init_ControlCummulative(oTrans.tYear().iYear);
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadControls();
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;

        grdView.DataSource = AssetPdcc.dtGetAssets();
        grdView.DataBind();
        LoadControls();
    }
}