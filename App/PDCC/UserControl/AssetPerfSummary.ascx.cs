using System;
using System.Collections.Generic;
using System.Data;
// Use the `FusionCharts.Charts` namespace to be able to use classes and methods required to // create charts.
using FusionCharts.Charts;

public partial class App_PDCC_UserControl_AssetPerfSummary : System.Web.UI.UserControl
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    readonly Department _gDepartment = new Department();
    TransactionYear oTrans = new TransactionYear();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        createNewGraph();
    }

    private void createNewGraph()
    {
        OpexFectoImprovementActualPotential pAsset = new OpexFectoImprovementActualPotential();
        List<AssetPdcc> lstAssets = AssetPdcc.lstGetAssets();

        string strXML = null;

        strXML = @"<chart palette='3' caption='Cost Ambition' subcaption='In Million $' xaxisname='Department' yaxisname='Deep Dive (In USD)' numdivlines='3' numberprefix='$' showsum='0' useroundedges='1' showborder='0'>";
        strXML += "<categories font='Arial' fontsize='12' fontcolor='000000'>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            strXML += "<category label='" + oAsset.sAsset + "' />";
        }
        strXML += "<category label='PD' />";
        strXML += "</categories>";

        strXML += "<dataset>";
        strXML += "<dataset seriesname='Improvement' color='8BBA00'>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            pAsset = _opportunityCostHelper.ObjGetAssetPerformanceByYear(oTrans.tYear().iYear, oAsset.iAssetId);
            strXML += "<set value='" + pAsset.dImprovement + "' />";
        }
        pAsset = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(oTrans.tYear().iYear);
        strXML += "<set value='" + pAsset.dImprovement + "' />";
        strXML += "</dataset>";

        strXML += "<dataset seriesname='Deep Dive' color='A66EDD'>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            pAsset = _opportunityCostHelper.ObjGetAssetPerformanceByYear(oTrans.tYear().iYear, oAsset.iAssetId);
            strXML += "<set value='" + pAsset.dActSavings + "' />";
        }
        pAsset = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(oTrans.tYear().iYear);
        strXML += "<set value='" + pAsset.dActSavings + "' />";
        strXML += "</dataset>";

        strXML += "<dataset seriesname='Front End Take Out' color='F984A1'>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            pAsset = _opportunityCostHelper.ObjGetAssetPerformanceByYear(oTrans.tYear().iYear, oAsset.iAssetId);
            strXML += "<set value='" + pAsset.dFecto + "' />";
        }
        pAsset = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(oTrans.tYear().iYear);
        strXML += "<set value='" + pAsset.dFecto + "' />";
        strXML += "</dataset>";
        strXML += "</dataset>";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("msstackedcolumn2d", "myChart", "900", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }
}