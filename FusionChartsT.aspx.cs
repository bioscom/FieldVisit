using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using InfoSoftGlobal;
using System.Data.SqlClient;

public partial class FusionChartsT : System.Web.UI.Page 
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    DataTable dtOnshore = new DataTable("ChartOnshore");
    DataTable dtOffshore = new DataTable("ChartOffshore");
    string X, Y;
    string GraphWidth = "450";
    string GraphHeight = "420";
    string[] color = new string[12]; 


    protected void Page_Load(object sender, EventArgs e)
    {
        ConfigureColors();
        PlotGraphs(2015);
        //LoadGraphData();
        CreateBarGraph(dtOnshore);
        CreateLineGraph(dtOnshore);
        CreatePieGraph(dtOnshore);
        CreateDoughnutGraph(dtOnshore);
    }

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

    private void CreateLineGraph(DataTable dt)
    {
        string strCaption = "Month wise Product Distribution";
        string strSubCaption = "For the year 2010";
        string xAxis = "Month";
        string yAxis = "Qnty";

        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"                
            <graph caption='" + strCaption + @"' 
            subcaption='" + strSubCaption + @"'
            hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='2' 
            showvalues='0' numdivlines='3' numVdivlines='0' yaxisminvalue='80.00' yaxismaxvalue='80.00'  
            rotateNames='1'
            showAlternateHGridColor='1' AlternateHGridColor='ff5904' divLineColor='ff5904' 
            divLineAlpha='20' alternateHGridAlpha='5' 
            xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' 
            >        
            ";

        string tmp = null;

        tmp = @"<categories font='Arial' fontSize='11' fontColor='000000'>";
        //foreach (DataRow dr in dt.Rows)
        //{
        //    tmp += @"<category name='" + dr["OPEX"].ToString().Trim() + @"' />";
        //}

        foreach (DataColumn dc in dt.Columns)
        {
            tmp += @"<category name='" + dc.ColumnName.ToString().Trim() + @"' />";
        }
        tmp += @"</categories>";

        strXML += tmp;

        tmp = @"<dataset seriesName='2010' color='1D8BD1' anchorBorderColor='1D8BD1' anchorBgColor='1D8BD1'>";
        foreach (DataRow dr in dt.Rows)
        {
            tmp += @"<set value='" + dr["OPEX"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dr["OPEX"].ToString() + ", " + dr["OPEX"].ToString() + "'); &quot; />";
            tmp += @"<set value='" + dr["FECTO"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dr["FECTO"].ToString() + ", " + dr["FECTO"].ToString() + "'); &quot; />";
            tmp += @"<set value='" + dr["IMPROVEMENT"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dr["IMPROVEMENT"].ToString() + ", " + dr["IMPROVEMENT"].ToString() + "'); &quot; />";
            tmp += @"<set value='" + dr["POTSAVINGS"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dr["POTSAVINGS"].ToString() + ", " + dr["POTSAVINGS"].ToString() + "'); &quot; />";
            tmp += @"<set value='" + dr["ACTSAVINGS"].ToString().Trim() + @"'  link=&quot;JavaScript:myJS('" + dr["ACTSAVINGS"].ToString() + ", " + dr["ACTSAVINGS"].ToString() + "'); &quot; />";
        }

        tmp += @"</dataset>";

        strXML += tmp;


        strXML += "</graph>";

        //FCLiteral1.Text = FusionCharts.RenderChartHTML(
        //    "FusionCharts/FCF_MSLine.swf",   // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph4",                      // Unique chart ID
        //    GraphWidth, GraphHeight,         // Width & Height of chart
        //    false
        //    );
    }

    private void CreateBarGraph(DataTable dt)
    {
        string strCaption = "Month wise Product Distribution";
        string strSubCaption = "For the year 2010";
        string xAxis = "Month";
        string yAxis = "Qnty";

        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;

        foreach (DataRow dr in dt.Rows)
        {
            strXML += "<set name='" + dt.Columns[0].ToString() + "' value='" + dr[0].ToString() + "' color='" + color[0] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["OPEX"].ToString() + ", " + dr["OPEX"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns[1].ToString() + "' value='" + dr[1].ToString() + "' color='" + color[1] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["FECTO"].ToString() + ", " + dr["FECTO"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns[2].ToString() + "' value='" + dr[2].ToString() + "' color='" + color[2] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["IMPROVEMENT"].ToString() + ", " + dr["IMPROVEMENT"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns[3].ToString() + "' value='" + dr[3].ToString() + "' color='" + color[3] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["POTSAVINGS"].ToString() + ", " + dr["POTSAVINGS"].ToString() + "'); &quot;/>";
            strXML += "<set name='" + dt.Columns[4].ToString() + "' value='" + dr[4].ToString() + "' color='" + color[4] + @"'  link=&quot;JavaScript:myJS('" + dt.Columns["ACTSAVINGS"].ToString() + ", " + dr["ACTSAVINGS"].ToString() + "'); &quot;/>";
            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        //FCLiteral2.Text = FusionCharts.RenderChartHTML(
        //    "FusionCharts/FCF_Column3D.swf", // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph1",                      // Unique chart ID
        //    GraphWidth, GraphHeight,                   // Width & Height of chart
        //    false
        //    );
    }

    private void CreatePieGraph(DataTable dt)
    {
        string strCaption = "Month wise Product Distribution";
        string strSubCaption = "For the year 2010";
        string xAxis = "Month";
        string yAxis = "Qnty";

        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;

        foreach (DataRow dr2 in dt.Rows)
        {
            strXML += "<set name='" + dr2[0].ToString() + "' value='" + dr2[1].ToString() + "' color='" + color[i] + @"'  link=&quot;JavaScript:myJS('" + dr2["Month"].ToString() + ", " + dr2["Qnty"].ToString() + "'); &quot;/>";
            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        //FCLiteral3.Text = FusionCharts.RenderChartHTML(
        //    "FusionCharts/FCF_Pie3D.swf", // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph1",                      // Unique chart ID
        //    GraphWidth, GraphHeight,                   // Width & Height of chart
        //    false
        //    );
    }

    private void CreateDoughnutGraph(DataTable dt)
    {
        string strCaption = "Month wise Product Distribution";
        string strSubCaption = "For the year 2010";
        string xAxis = "Month";
        string yAxis = "Qnty";

        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;

        foreach (DataRow dr2 in dt.Rows)
        {
            strXML += "<set name='" + dr2[0].ToString() + "' value='" + dr2[1].ToString() + "' color='" + color[i] + @"'  link=&quot;JavaScript:myJS('" + dr2["Month"].ToString() + ", " + dr2["Qnty"].ToString() + "'); &quot;/>";
            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        //FCLiteral4.Text = FusionCharts.RenderChartHTML(
        //    "FusionCharts/FCF_Doughnut2D.swf", // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph1",                      // Unique chart ID
        //    GraphWidth, GraphHeight,                   // Width & Height of chart
        //    false
        //    );
    }

    private void PlotGraphs(int iYear)
    {
        DataColumn dc = new DataColumn("Month", typeof(string));
        DataColumn dc1 = new DataColumn("Qnty", typeof(int));
        dtOnshore.Columns.Add(dc);
        dtOnshore.Columns.Add(dc1);

        dtOnshore = _opportunityCostHelper.DtGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Onshore);

        dtOffshore = _opportunityCostHelper.DtGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Offshore);


        //OpexFectoImprovementActualPotential objOnShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Onshore);
        ////Charter(cSPDCReport, objOnShore, "SPDC PD", 400, 500);

        //OpexFectoImprovementActualPotential objOffShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Offshore);
        ////Charter(cSNEPCOReport, objOffShore, "SNEPCo PD", 400, 500);

        //OpexFectoImprovementActualPotential objOffShoreOnShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByYear(iYear);
        //Charter(cCombinedReporter, objOffShoreOnShore, "SPDC + SNEPCo PD", 600, 900);
    }
    
    
    
    
    //private void LoadGraphData()
    //{
    //    // Preparing Data Source For Chart Control

    //    DataColumn dc = new DataColumn("Month", typeof(string));
    //    DataColumn dc1 = new DataColumn("Qnty", typeof(int));
    //    dt.Columns.Add(dc);
    //    dt.Columns.Add(dc1);

    //    DataRow dr1 = dt.NewRow();
    //    dr1[0] = "January";
    //    dr1[1] = 8465;
    //    dt.Rows.Add(dr1);

    //    DataRow dr2 = dt.NewRow();
    //    dr2[0] = "February";
    //    dr2[1] = 9113;
    //    dt.Rows.Add(dr2);

    //    DataRow dr3 = dt.NewRow();
    //    dr3[0] = "March";
    //    dr3[1] = 18305;
    //    dt.Rows.Add(dr3);

    //    DataRow dr4 = dt.NewRow();
    //    dr4[0] = "April";
    //    dr4[1] = 23839;
    //    dt.Rows.Add(dr4);

    //    DataRow dr5 = dt.NewRow();
    //    dr5[0] = "May";
    //    dr5[1] = 11167;
    //    dt.Rows.Add(dr5);

    //    DataRow dr6 = dt.NewRow();
    //    dr6[0] = "June";
    //    dr6[1] = 8838;
    //    dt.Rows.Add(dr6);

    //    DataRow dr7 = dt.NewRow();
    //    dr7[0] = "July";
    //    dr7[1] = 10800;
    //    dt.Rows.Add(dr7);

    //    DataRow dr8 = dt.NewRow();
    //    dr8[0] = "August";
    //    dr8[1] = 12115;
    //    dt.Rows.Add(dr8);

    //    DataRow dr9 = dt.NewRow();
    //    dr9[0] = "September";
    //    dr9[1] = 7298;
    //    dt.Rows.Add(dr9);

    //    DataRow dr10 = dt.NewRow();
    //    dr10[0] = "October";
    //    dr10[1] = 13186;
    //    dt.Rows.Add(dr10);

    //    DataRow dr11 = dt.NewRow();
    //    dr11[0] = "November";
    //    dr11[1] = 10460;
    //    dt.Rows.Add(dr11);

    //    DataRow dr12 = dt.NewRow();
    //    dr12[0] = "December";
    //    dr12[1] = 9964;
    //    dt.Rows.Add(dr12);
    //}
}
