using System;
using System.Collections.Generic;
using System.Linq;
using FusionCharts.Charts;

public partial class App_Prices_UserControl_oPerformanceByHub : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public void HubsPerformance()
    {
        string strXML = null;
        List<AssetHubs> o = AssetHubs.lstGetHubs();

        strXML = @"<chart caption='Savings by Hubs' baseFont='Arial' baseFontSize ='10' numberprefix='$' ";
        strXML += "plotgradientcolor='' bgcolor ='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' ";
        strXML += "showvalues='1' showcanvasborder='1' canvasborderalpha ='0' canvasbordercolor='CCCCCC' ";
        strXML += "canvasborderthickness='1' captionpadding='30' linethickness='3' yaxisvaluespadding ='15' ";
        strXML += "legendshadow ='1' legendborderalpha='1' ";
        strXML += "palettecolors ='#ff0000, #FFA500, #00ff00, #33bdda, #e44a00, #583e78' showborder='1'>";

        strXML += "<categories font='Arial' fontsize='10' fontcolor='000000'>";
        foreach (AssetHubs h in o)
        {
            strXML += "<category label='" + h.sHub + "' />";
        }
        strXML += "</categories>";


        strXML += "<dataset seriesname='Red Flag'>";
        foreach (AssetHubs h in o)
        {
            List<Price> lstPrices = PriceHelper.LstGetPricesByHub(h.iHubId);
            decimal sumRedFlagValue = lstPrices.Sum(p => p.dPrice);
            
            strXML += "<set value='" + sumRedFlagValue + "' />";
        }
        strXML += "</dataset>";


        strXML += "<dataset seriesname='Opportunity'>";
        foreach (AssetHubs h in o)
        {
            List<Price> lstPrices = PriceHelper.LstGetPricesByHub(h.iHubId);

            decimal sumRedFlagValue = lstPrices.Sum(p => p.dPrice);
            decimal sumShouldBeValue = lstPrices.Sum(p => p.dShouldBePrice);
            decimal opportunity = sumRedFlagValue - sumShouldBeValue;

            strXML += "<set value='" + opportunity + "' />";
        }
        strXML += "</dataset>";


        strXML += "<dataset seriesname='Saved'>";
        foreach (AssetHubs h in o)
        {
            List<Price> lstPrices = PriceHelper.LstGetPricesByHub(h.iHubId);

            decimal sumSaved = lstPrices.Sum(p => p.dAmountSaved);
            strXML += "<set value='" + sumSaved + "' />";
        }
        strXML += "</dataset>";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("mscolumn2d", "myHubChart", "750", "450", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }
}