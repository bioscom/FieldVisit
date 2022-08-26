using System;
using System.Collections.Generic;
// Use the `FusionCharts.Charts` namespace to be able to use classes and methods required to // create charts.
using FusionCharts.Charts;

public partial class App_FlareWaiver_UserControl_GraphicalReports : System.Web.UI.UserControl
{
    BI500RequestHelper oHelper = new BI500RequestHelper();
    FunctionMgt oFunc = new FunctionMgt();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {

    }


    public void GraphicalReporter(int iYear, string sMonth, int iMonth, int iDay)
    {
        List<Facility> oFac = Facility.lstGetFacilities();
        FlareTargetHelper oHlp = new FlareTargetHelper();
     
        string strXML = null;

        string strCaption = sMonth + " " + iDay + ", " + iYear + " Flare Targets/Flared Gas";
        string yAxis = iYear + " Flares";
        string xAxis = "Facilities";

        strXML = @"<chart caption='" + strCaption + "' yaxisname='" + yAxis + "' xAxisName='" + xAxis + @"' bgcolor='#FFFFFF' showalternatehgridcolor='0' ";
        strXML += "showvalues='1' labeldisplay='WRAP' divlinecolor='#CCCCCC' divlinealpha='70' useroundedges='0' canvasbgcolor='#FFFFFF' ";
        strXML += "canvasbasecolor='#CCCCCC' showcanvasbg='1' animation='0' palettecolors='#008ee4,#6baa01,#f8bd19,#e44a00,#33bdda' showborder='0'>";

        foreach(Facility o in oFac)
        {
            mFlareTarget oT = oHlp.objGetFlareTargetByFacilityId(o.m_iFacilityId, sMonth, iYear);
            strXML += "<set label='" + Facility.objGetFacilityById(oT.iFacilityId).m_sFacility + "' value='" + oT.iMonth + "' />";
        }

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "ByFunction", "2500", "600", "xml", strXML);

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    public void GraphicalReporterSeries(int iYear, string sMonth, int iMonth, int iDay)
    {
        List<Facility> oFac = Facility.lstGetFacilities();
        FlareTargetHelper oHlp = new FlareTargetHelper();

        string strXML = null;
        strXML = @"<chart caption='" + iYear + " Flared Gas' baseFont='Arial' baseFontSize ='12' outCnvBaseFont='Arial' outCnvBaseFontSize ='12' numberprefix='' showvalues='0' plotgradientcolor='' formatnumberscale='0' showplotborder='0' palettecolors='#EED17F,#97CBE7,#074868,#B0D67A,#2C560A,#DD9D82' canvaspadding='0' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showcanvasborder='1' legendborderalpha='0' legendshadow='0' interactivelegend='0' showpercentvalues='1' showsum='1' canvasborderalpha='0' showborder='1'>";
        //strXML = @"<chart caption='Savings by Asset' baseFont='Arial' baseFontSize ='14' outCnvBaseFont='Arial' outCnvBaseFontSize ='12' numberprefix='$' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showvalues='1' showcanvasborder='1' canvasborderalpha='0' canvasbordercolor='CCCCCC' canvasborderthickness='1' captionpadding='30' linethickness='3' yaxisvaluespadding='15' legendshadow='0' legendborderalpha='0' palettecolors='#f8bd19,#008ee4,#33bdda,#e44a00,#6baa01,#583e78' showborder='1'>";

        strXML += "<categories>";
        foreach (Facility o in oFac)
        {
            strXML += "<category label='" + o.m_sFacility + "' />";
        }
        strXML += "</categories>";


        strXML += "<dataset seriesname='FlareTarget' renderas='Area'>";
        foreach (Facility o in oFac)
        {
            mFlareTarget oT = oHlp.objGetFlareTargetByFacilityId(o.m_iFacilityId, sMonth, iYear);
            strXML += "<set value='" + oT.iMonth + "' />";
        }
        strXML += "</dataset>";


        strXML += "<dataset seriesname='ECFlared' renderas='Area'>";
        //Connect to EC and Execute this query
        FlareWaiverRequestHelper oEC = new FlareWaiverRequestHelper();

        foreach (Facility o in oFac)
        {
            EnergyComponent oE = oEC.objGetDailyFlaredGasFromEC(iDay, iMonth, iYear, o.m_sCode);
            strXML += "<set value='" + oE.SI + "' />";
        }

        strXML += "</dataset>";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "myChartStacked", "2500", "600", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

}