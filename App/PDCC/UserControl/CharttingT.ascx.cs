using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using InfoSoftGlobal;
using System.Data;
using System.Data.SqlClient;

public partial class App_PDCC_UserControl_CharttingT : System.Web.UI.UserControl
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    readonly Department _gDepartment = new Department();

    DataTable dtOnshore = new DataTable("ChartOnshore");
    DataTable dtOffshore = new DataTable("ChartOffshore");
    DataTable dtOnOffshore = new DataTable("ChartOnOffshore");
    string X, Y;
    string GraphWidth = "440";
    string GraphHeight = "420";
    string[] color = new string[12];

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iYear)
    {
        ConfigureColors();
        LoadGraphsData(iYear);

        CreateBarGraph(dtOnshore, "SPDC", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral1);
        CreatePieGraph(dtOnshore, "SPDC", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral2);
    }

    public void Init_PageSnepco(int iYear)
    {
        ConfigureColors();
        LoadGraphsData(iYear);
        //LoadGraphData();
        CreateBarGraph(dtOffshore, "SNEPCo", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral1);
        CreatePieGraph(dtOnshore, "SNEPCo", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral2);
    }

    public void Init_PagePD(int iYear)
    {
        ConfigureColors();
        LoadGraphsData(iYear);
        //LoadGraphData();
        CreateBarGraph(dtOnOffshore, "SPDC + SNEPCo", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral1);
        CreatePieGraph(dtOnOffshore, "SPDC + SNEPCo", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral2);
    }

    public void Onshore(int iYear)
    {
        ConfigureColors();
        LoadGraphsData(iYear);
        //LoadGraphData();
        //CreateLineGraph(dtOnshore);
        CreateBarGraph(dtOnshore, "Onshore PD", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral1);
        //CreateBarGraph(dtOffshore, "SNEPCo PD", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral2);
        //CreateBarGraph(dtOnOffshore, "SPDC+SNEPCo PD", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral3);
        //CreatePieGraph(dtOnshore);
        //CreateDoughnutGraph(dtOnshore);
    }

    public void Offshore(int iYear)
    {
        ConfigureColors();
        LoadGraphsData(iYear);
        //LoadGraphData();
        CreateBarGraph(dtOffshore, "OffShore PD", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral2);
    }

    public void ByDepartment(int iYear, int iDeptId)
    {
        Department oDepartment = _gDepartment.objGetDeparmentById(iDeptId);

        ConfigureColors();
        LoadGraphsData(iYear);
        //LoadGraphData();
        CreateBarGraph(dtOffshore, oDepartment.m_sDepartment + " PD", "Cost Reduction Performance for the year " + iYear, "Cost Reduction Performance", "F($)mln", FCLiteral2);
    }
    private void LoadGraphsData(int iYear)
    {
        dtOnshore = _opportunityCostHelper.DtGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Onshore);
        dtOffshore = _opportunityCostHelper.DtGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Offshore);
        dtOnOffshore = _opportunityCostHelper.DtGetOpExFectoImprovementByYear(iYear);
    }

    private void CreateBarGraph(DataTable dt, string strCaption, string strSubCaption, string xAxis, string yAxis, Literal FCLiteral)
    {
        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0' showValues='0'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;

        foreach (DataRow dr in dt.Rows)
        {
            string sRedTarget = "Red. Target";
            decimal dRedTargetVal = decimal.Parse(dr["OPEX"].ToString()) * 0.25M;
            string sCummulative = "Cumm.";
            decimal dCummulative = decimal.Parse(dr["FECTO"].ToString()) + decimal.Parse(dr["IMPROVEMENT"].ToString());


            strXML += "<set name='" + dt.Columns["OPEX"].ToString() + "' value='" + dr[0].ToString() + "' color='" + color[0] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["OPEX"].ToString() + ", " + dr["OPEX"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns["FECTO"].ToString() + "' value='" + dr[1].ToString() + "' color='" + color[1] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["FECTO"].ToString() + ", " + dr["FECTO"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns["IMPROVEMENT"].ToString() + "' value='" + dr[2].ToString() + "' color='" + color[2] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["IMPROVEMENT"].ToString() + ", " + dr["IMPROVEMENT"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + sCummulative + "' value='" + dCummulative + "' color='" + color[3] + @"'  link=&quot;JavaScript:myJS('" + sCummulative + ", " + dCummulative + "'); &quot;/>";
            //strXML += "<set name='" + dt.Columns[3].ToString() + "' value='" + dr[3].ToString() + "' color='" + color[3] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["POTSAVINGS"].ToString() + ", " + dr["POTSAVINGS"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns["ACTSAVINGS"].ToString() + "' value='" + dr["ACTSAVINGS"].ToString() + "' color='" + color[4] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["ACTSAVINGS"].ToString() + ", " + dr["ACTSAVINGS"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + sRedTarget + "' value='" + dRedTargetVal + "' color='" + color[5] + @"'  link=&quot;JavaScript:myJS('" + sRedTarget + ", " + dRedTargetVal + "'); &quot;/>";
            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        //FCLiteral.Text = FusionCharts.RenderChartHTML(
        //    "FusionCharts/FCF_Column2D.swf", // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph1",                      // Unique chart ID
        //    GraphWidth, GraphHeight,                   // Width & Height of chart
        //    false
        //    );
    }

//    private void CreateLineGraph(DataTable dt, string strCaption, string strSubCaption, string xAxis, string yAxis, Literal FCLiteral)
//    {
//        //strXML will be used to store the entire XML document generated
//        string strXML = null;

//        //Generate the graph element
//        strXML = @"                
//            <graph caption='" + strCaption + @"' 
//            subcaption='" + strSubCaption + @"'
//            hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='2' 
//            showvalues='0' numdivlines='3' numVdivlines='0' yaxisminvalue='80.00' yaxismaxvalue='80.00'  
//            rotateNames='1'
//            showAlternateHGridColor='1' AlternateHGridColor='ff5904' divLineColor='ff5904' 
//            divLineAlpha='20' alternateHGridAlpha='5' 
//            xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' 
//            >        
//            ";

//        string tmp = null;

//        tmp = @"<categories font='Arial' fontSize='11' fontColor='000000'>";
//        //foreach (DataRow dr in dt.Rows)
//        //{
//        //    tmp += @"<category name='" + dr["OPEX"].ToString().Trim() + @"' />";
//        //}

//        foreach (DataColumn dc in dt.Columns)
//        {
//            tmp += @"<category name='" + dc.ColumnName.ToString().Trim() + @"' />";
//        }
//        tmp += @"</categories>";

//        strXML += tmp;

//        tmp = @"<dataset seriesName='...' color='1D8BD1' anchorBorderColor='1D8BD1' anchorBgColor='1D8BD1'>";
//        foreach (DataRow dr in dt.Rows)
//        {
//            string sRedTarget = "Red. Target";
//            decimal dRedTargetVal = decimal.Parse(dr["OPEX"].ToString()) * 0.25M;
//            string sCummulative = "Cumm.";
//            decimal dCummulative = decimal.Parse(dr["FECTO"].ToString()) + decimal.Parse(dr["IMPROVEMENT"].ToString());

//            tmp += @"<set value='" + dr["OPEX"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["OPEX"].ToString() + ", " + dr["OPEX"].ToString() + "'); &quot; />";
//            tmp += @"<set value='" + dr["FECTO"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["FECTO"].ToString() + ", " + dr["FECTO"].ToString() + "'); &quot; />";
//            tmp += @"<set value='" + dr["IMPROVEMENT"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["IMPROVEMENT"].ToString() + ", " + dr["IMPROVEMENT"].ToString() + "'); &quot; />";
//            tmp += @"<set value='" + sCummulative + @"'  link=&quot;JavaScript:myJS('" + sCummulative + ", " + dCummulative + "'); &quot;/>";
//            tmp += @"<set value='" + dr["ACTSAVINGS"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["ACTSAVINGS"].ToString() + ", " + dr["ACTSAVINGS"].ToString() + "'); &quot; />";
//            tmp += @"<set value='" + sRedTarget + @"'  link=&quot;JavaScript:myJS('" + sRedTarget + ", " + dRedTargetVal + "'); &quot;/>";

//        }

//        tmp += @"</dataset>";

//        strXML += tmp;


//        strXML += "</graph>";

//        FCLiteral1.Text = FusionCharts.RenderChartHTML(
//            "FusionCharts/FCF_MSLine.swf",   // Path to chart's SWF
//            "",                              // Leave blank when using Data String method
//            strXML,                          // xmlStr contains the chart data
//            "mygraph4",                      // Unique chart ID
//            GraphWidth, GraphHeight,         // Width & Height of chart
//            false
//            );
//    }

    private void CreatePieGraph(DataTable dt, string strCaption, string strSubCaption, string xAxis, string yAxis, Literal FCLiteral)
    {
        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0' showValues='0' showNames='0' skipOverlapLabels='0' showLegends='1'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;

        foreach (DataRow dr in dt.Rows)
        {
            string sRedTarget = "Red. Target";
            decimal dRedTargetVal = decimal.Parse(dr["OPEX"].ToString()) * 0.25M;
            string sCummulative = "Cumm.";
            decimal dCummulative = decimal.Parse(dr["FECTO"].ToString()) + decimal.Parse(dr["IMPROVEMENT"].ToString());

            strXML += "<set name='" + dt.Columns["OPEX"].ToString() + "' value='" + dr["OPEX"].ToString() + "' color='" + color[0] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["OPEX"].ToString() + ", " + dr["OPEX"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns["FECTO"].ToString() + "' value='" + dr["FECTO"].ToString() + "' color='" + color[1] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["FECTO"].ToString() + ", " + dr["FECTO"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns["IMPROVEMENT"].ToString() + "' value='" + dr["IMPROVEMENT"].ToString() + "' color='" + color[2] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["IMPROVEMENT"].ToString() + ", " + dr["IMPROVEMENT"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + sCummulative + "' value='" + dCummulative + "' color='" + color[3] + @"'  link=&quot;JavaScript:myJS('" + sCummulative + ", " + dCummulative + "'); &quot;/>";
            //strXML += "<set name='" + dr["POTSAVINGS"].ToString() + "' value='" + dr["POTSAVINGS"].ToString() + "' color='" + color[5] + @"'  link=&quot;JavaScript:myJS('" + dr["POTSAVINGS"].ToString() + ", " + dr["POTSAVINGS"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns["ACTSAVINGS"].ToString() + "' value='" + dr["ACTSAVINGS"].ToString() + "' color='" + color[4] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["ACTSAVINGS"].ToString() + ", " + dr["ACTSAVINGS"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + sRedTarget + "' value='" + dRedTargetVal + "' color='" + color[5] + @"'  link=&quot;JavaScript:myJS('" + sRedTarget + ", " + dRedTargetVal + "'); &quot;/>";

            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        //FCLiteral.Text = FusionCharts.RenderChartHTML(
        //    "FusionCharts/FCF_Pie3D.swf", // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph1",                      // Unique chart ID
        //    GraphWidth, GraphHeight,                   // Width & Height of chart
        //    false
        //    );
    }

//    private void CreateDoughnutGraph(DataTable dt, string strCaption, string strSubCaption, string xAxis, string yAxis, Literal FCLiteral)
//    {
//        //strXML will be used to store the entire XML document generated
//        string strXML = null;

//        //Generate the graph element
//        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
//                          pieSliceDepth='30' formatNumberScale='0'
//                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
//                    >";

//        int i = 0;

//        foreach (DataRow dr in dt.Rows)
//        {
//            string sRedTarget = "Red. Target";
//            decimal dRedTargetVal = decimal.Parse(dr["OPEX"].ToString()) * 0.25M;
//            string sCummulative = "Cumm.";
//            decimal dCummulative = decimal.Parse(dr["FECTO"].ToString()) + decimal.Parse(dr["IMPROVEMENT"].ToString());

//            strXML += "<set name='" + dt.Columns["OPEX"].ToString() + "' value='" + dr["OPEX"].ToString() + "' color='" + color[0] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["OPEX"].ToString() + ", " + dr["OPEX"].ToString() + "'); &quot;/>";
//            strXML += "<set name='" + dt.Columns["FECTO"].ToString() + "' value='" + dr["FECTO"].ToString() + "' color='" + color[1] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["FECTO"].ToString() + ", " + dr["FECTO"].ToString() + "'); &quot;/>";
//            strXML += "<set name='" + dt.Columns["IMPROVEMENT"].ToString() + "' value='" + dr["IMPROVEMENT"].ToString() + "' color='" + color[2] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["IMPROVEMENT"].ToString() + ", " + dr["IMPROVEMENT"].ToString() + "'); &quot;/>";
//            strXML += "<set name='" + sCummulative + "' value='" + dCummulative + "' color='" + color[3] + @"'  link=&quot;JavaScript:myJS('" + sCummulative + ", " + dCummulative + "'); &quot;/>";
//            strXML += "<set name='" + dt.Columns["ACTSAVINGS"].ToString() + "' value='" + dr["ACTSAVINGS"].ToString() + "' color='" + color[4] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["ACTSAVINGS"].ToString() + ", " + dr["ACTSAVINGS"].ToString() + "'); &quot;/>";
//            strXML += "<set name='" + sRedTarget + "' value='" + dRedTargetVal + "' color='" + color[5] + @"'  link=&quot;JavaScript:myJS('" + sRedTarget + ", " + dRedTargetVal + "'); &quot;/>";

            
//            i++;
//        }

//        //Finally, close <graph> element
//        strXML += "</graph>";

//        FCLiteral.Text = FusionCharts.RenderChartHTML(
//            "FusionCharts/FCF_Doughnut2D.swf", // Path to chart's SWF
//            "",                              // Leave blank when using Data String method
//            strXML,                          // xmlStr contains the chart data
//            "mygraph1",                      // Unique chart ID
//            GraphWidth, GraphHeight,                   // Width & Height of chart
//            false
//            );
//    }

    private void ConfigureColors()
    {
        color[0] = "AFD8F8";
        color[1] = "F6BD0F";
        color[2] = "8BBA00";
        color[3] = "FF8E46";
        color[4] = "008E8E";
        color[5] = "D64646";
        color[6] = "8E468E";
        color[7] = "588526";
        color[8] = "B3AA00";
        color[9] = "008ED6";
        color[10] = "9D080D";
        color[11] = "A186BE";
    }

}