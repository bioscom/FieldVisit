using System;
using System.Collections.Generic;
// Use the `FusionCharts.Charts` namespace to be able to use classes and methods required to // create charts.
using FusionCharts.Charts;

public partial class App_BI500_UserControl_GraphicalReports : System.Web.UI.UserControl
{
    Reporting oRpt = new Reporting();
    FunctionMgt oFunc = new FunctionMgt();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {

    }


    //Yearly Reporting
    public void GraphicalReportByYearFunction(int iYear, int iFunction)
    {
        List<BIDepartments> lstBIDeps = BIDepartments.lstGetDeparmentsByFunction(iFunction);

        string strXML = null;
        string sFunction = oFunc.objGetFunctionById(iFunction).m_sFunction;

        string strCaption = iYear + ", Business Unit: " + sFunction + " Bright Ideas by Departments.";
        string yAxis = iYear + " Year to date Bright Ideas";
        string xAxis = "Business Unit: " + sFunction;

        strXML = @"<chart caption='" + strCaption + "' yaxisname='" + yAxis + "' xAxisName='" + xAxis + @"' bgcolor='#FFFFFF' showalternatehgridcolor='0' ";
        strXML += "showvalues='1' labeldisplay='WRAP' baseFontSize ='12' divlinecolor='#CCCCCC' divlinealpha='70' useroundedges='0' canvasbgcolor='#FFFFFF' ";
        strXML += "xAxisNameFont='Arial' xAxisNameFontSize='12' xAxisNameFontColor='#993300' xAxisNameFontBold='1' xAxisNameFontItalic='1' xAxisNameAlpha='80' ";
        strXML += "yAxisNameFont='Arial' yAxisNameFontSize='12' yAxisNameFontColor='#993300' yAxisNameFontBold='1' yAxisNameFontItalic='1' yAxisNameAlpha='80' ";
        strXML += "canvasbasecolor='#CCCCCC' showcanvasbg='1' animation='0' palettecolors='#008ee4,#6baa01,#f8bd19,#e44a00,#33bdda' showborder='0'>";

        //strXML = @"<chart caption='" + strCaption + "' showvalues='1' plotgradientcolor='' formatnumberscale='0' showplotborder='0' 
        //palettecolors='#EED17F,#97CBE7,#074868,#B0D67A,#2C560A,#DD9D82' canvaspadding='0' bgcolor='FFFFFF' showalternatehgridcolor='0' 
        //divlinecolor='CCCCCC' showcanvasborder='1' legendborderalpha='1' legendshadow='0' interactivelegend='0' showpercentvalues='0' 
        //showsum='1' canvasborderalpha='0' showborder='1'>";
        int i = 0; int iCummulative = 0;
        foreach (BIDepartments o in lstBIDeps)
        {
            i = oRpt.dtGetRequestsByDepartmentYear(iYear, o.m_iDepartmentId).Rows.Count;
            strXML += "<set label='" + o.m_sDepartment + "' value='" + i + "' />";
            iCummulative = iCummulative + i;
        }

        strXML += "<set label='Cummulative' value='" + iCummulative + "' />";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "ByFunction", "800", "500", "xml", strXML);

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    public void GraphicalReportByYearDepartment(int iYear, int iDepartmentId, int iFunction)
    {
        BIDepartments oD = new BIDepartments();
        List<BITeams> lstBITeams = BITeams.lstGetTeamsByDepartment(iDepartmentId);

        string sFunction = oFunc.objGetFunctionById(iFunction).m_sFunction;
        string sDepartment = oD.objGetDepartmentById(iDepartmentId).m_sDepartment;

        string strCaption = iYear + " - " + sFunction + ", " + sDepartment + "  Bright Ideas by Teams.";
        string yAxis = iYear + " Year to date Bright Ideas";
        string xAxis = "Department: " + sDepartment;

        string strXML = null;
        strXML = @"<chart caption='" + strCaption + "' yaxisname='" + yAxis + "' xAxisName='" + xAxis + @"' bgcolor='#FFFFFF' showalternatehgridcolor='0' ";
        strXML += "showvalues='1' labeldisplay='WRAP' divlinecolor='#CCCCCC' divlinealpha='70' useroundedges='0' canvasbgcolor='#FFFFFF' ";
        strXML += "canvasbasecolor='#CCCCCC' showcanvasbg='1' animation='0' palettecolors='#008ee4,#6baa01,#f8bd19,#e44a00,#33bdda' showborder='0'>";

        int i = 0; int iCummulative = 0;
        foreach (BITeams o in lstBITeams)
        {
            i = oRpt.dtGetRequestsByTeamYear(iYear, o.m_iTeamId).Rows.Count;
            strXML += "<set label='" + o.m_sTeam + "' value='" + i + "' />";
            iCummulative = iCummulative + i;
        }

        strXML += "<set label='Cummulative' value='" + iCummulative + "' />";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "ByDepartment", "800", "500", "xml", strXML);
        //msline //stackedcolumn2d  //column2d //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }


    //Monthly Reporting
    public void GraphicalReportByMonthFunction(int iMonth, int iYear, int iFunction)
    {
        List<BIDepartments> lstBIDeps = BIDepartments.lstGetDeparmentsByFunction(iFunction);

        string strXML = null;
        string sFunction = oFunc.objGetFunctionById(iFunction).m_sFunction;

        string strCaption = mMonthEnuem.monthDesc((mMonthEnuem.mMonth)iMonth) + ", " + iYear + ", Business Unit: " + sFunction + " Bright Ideas by Departments.";
        string yAxis = "No of Bright Ideas for the month " + mMonthEnuem.monthDesc((mMonthEnuem.mMonth)iMonth);
        string xAxis = "Business Unit: " + sFunction;

        strXML = @"<chart caption='" + strCaption + "' yaxisname='" + yAxis + "' xAxisName='" + xAxis + @"' bgcolor='#FFFFFF' showalternatehgridcolor='0' ";
        strXML += "showvalues='1' labeldisplay='WRAP' divlinecolor='#CCCCCC' divlinealpha='70' useroundedges='0' canvasbgcolor='#FFFFFF' ";
        strXML += "canvasbasecolor='#CCCCCC' showcanvasbg='1' animation='0' palettecolors='#008ee4,#6baa01,#f8bd19,#e44a00,#33bdda' showborder='0'>";

        //strXML = @"<chart caption='" + strCaption + "' showvalues='1' plotgradientcolor='' formatnumberscale='0' showplotborder='0' 
        //palettecolors='#EED17F,#97CBE7,#074868,#B0D67A,#2C560A,#DD9D82' canvaspadding='0' bgcolor='FFFFFF' showalternatehgridcolor='0' 
        //divlinecolor='CCCCCC' showcanvasborder='1' legendborderalpha='1' legendshadow='0' interactivelegend='0' showpercentvalues='0' 
        //showsum='1' canvasborderalpha='0' showborder='1'>";
        int i = 0; int iCummulative = 0;
        foreach (BIDepartments o in lstBIDeps)
        {
            i = oRpt.dtGetRequestsByDepartmentMonth(iMonth, iYear, o.m_iDepartmentId).Rows.Count;
            strXML += "<set label='" + o.m_sDepartment + "' value='" + i + "' />";
            iCummulative = iCummulative + i;
        }

        strXML += "<set label='Cummulative' value='" + iCummulative + "' />";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "ByFunction", "800", "500", "xml", strXML);

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    public void GraphicalReportByMonthDepartment(int iMonth, int iYear, int iDepartmentId, int iFunction)
    {
        BIDepartments oD = new BIDepartments();
        List<BITeams> lstBITeams = BITeams.lstGetTeamsByDepartment(iDepartmentId);

        string sFunction = oFunc.objGetFunctionById(iFunction).m_sFunction;
        string sDepartment = oD.objGetDepartmentById(iDepartmentId).m_sDepartment;

        string strCaption = mMonthEnuem.monthDesc((mMonthEnuem.mMonth)iMonth) + " " + iYear + " - " + sFunction + ", " + sDepartment + "  Bright Ideas by Teams.";
        string yAxis = "No of Bright Ideas for the month " + mMonthEnuem.monthDesc((mMonthEnuem.mMonth)iMonth);
        string xAxis = "Department: " + sDepartment;

        string strXML = null;
        strXML = @"<chart caption='" + strCaption + "' yaxisname='" + yAxis + "' xAxisName='" + xAxis + @"' bgcolor='#FFFFFF' showalternatehgridcolor='0' ";
        strXML += "showvalues='1' labeldisplay='WRAP' divlinecolor='#CCCCCC' divlinealpha='70' useroundedges='0' canvasbgcolor='#FFFFFF' ";
        strXML += "canvasbasecolor='#CCCCCC' showcanvasbg='1' animation='0' palettecolors='#008ee4,#6baa01,#f8bd19,#e44a00,#33bdda' showborder='0'>";

        int i = 0; int iCummulative = 0;
        foreach (BITeams o in lstBITeams)
        {
            i = oRpt.dtGetRequestsByTeamMonth(iMonth, iYear, o.m_iTeamId).Rows.Count;
            strXML += "<set label='" + o.m_sTeam + "' value='" + i + "' />";
            iCummulative = iCummulative + i;
        }

        strXML += "<set label='Cummulative' value='" + iCummulative + "' />";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "ByDepartment", "800", "500", "xml", strXML);
        //msline //stackedcolumn2d  //column2d //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }



    //Weekly Reporting 

    public void GraphicalReportByWeekFunction(int iWeek, int iYear, int iFunction)
    {
        List<BIDepartments> lstBIDeps = BIDepartments.lstGetDeparmentsByFunction(iFunction);

        string strXML = null;
        string sFunction = oFunc.objGetFunctionById(iFunction).m_sFunction;

        string strCaption = "Week " + iWeek + ", " + iYear + ", Business Unit: " + sFunction + " Bright Ideas by Departments.";
        string yAxis = "No of Bright Ideas for the Week " + iWeek;
        string xAxis = "Business Unit: " + sFunction;

        strXML = @"<chart caption='" + strCaption + "' yaxisname='" + yAxis + "' xAxisName='" + xAxis + @"' bgcolor='#FFFFFF' showalternatehgridcolor='0' ";
        strXML += "showvalues='1' labeldisplay='WRAP' divlinecolor='#CCCCCC' divlinealpha='70' useroundedges='0' canvasbgcolor='#FFFFFF' ";
        strXML += "canvasbasecolor='#CCCCCC' showcanvasbg='1' animation='0' palettecolors='#008ee4,#6baa01,#f8bd19,#e44a00,#33bdda' showborder='0'>";

        //strXML = @"<chart caption='" + strCaption + "' showvalues='1' plotgradientcolor='' formatnumberscale='0' showplotborder='0' 
        //palettecolors='#EED17F,#97CBE7,#074868,#B0D67A,#2C560A,#DD9D82' canvaspadding='0' bgcolor='FFFFFF' showalternatehgridcolor='0' 
        //divlinecolor='CCCCCC' showcanvasborder='1' legendborderalpha='1' legendshadow='0' interactivelegend='0' showpercentvalues='0' 
        //showsum='1' canvasborderalpha='0' showborder='1'>";
        int i = 0; int iCummulative = 0;
        foreach (BIDepartments o in lstBIDeps)
        {
            i = oRpt.dtGetRequestsByDepartmentWeek(iWeek, iYear, o.m_iDepartmentId).Rows.Count;
            strXML += "<set label='" + o.m_sDepartment + "' value='" + i + "' />";
            iCummulative = iCummulative + i;
        }

        strXML += "<set label='Cummulative' value='" + iCummulative + "' />";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "ByFunctionWeek", "800", "500", "xml", strXML);

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    public void GraphicalReportByWeekDepartment(int iWeek, int iYear, int iDepartmentId, int iFunction)
    {
        BIDepartments oD = new BIDepartments();
        List<BITeams> lstBITeams = BITeams.lstGetTeamsByDepartment(iDepartmentId);

        string sFunction = oFunc.objGetFunctionById(iFunction).m_sFunction;
        string sDepartment = oD.objGetDepartmentById(iDepartmentId).m_sDepartment;

        string strCaption = "Week " + iWeek + ", " + iYear + " - " + sFunction + ", " + sDepartment + "  Bright Ideas by Teams.";
        string yAxis = "No of Bright Ideas for the week " + iWeek;
        string xAxis = "Department: " + sDepartment;

        string strXML = null;
        strXML = @"<chart caption='" + strCaption + "' yaxisname='" + yAxis + "' xAxisName='" + xAxis + @"' bgcolor='#FFFFFF' showalternatehgridcolor='0' ";
        strXML += "showvalues='1' labeldisplay='WRAP' divlinecolor='#CCCCCC' divlinealpha='70' useroundedges='0' canvasbgcolor='#FFFFFF' ";
        strXML += "canvasbasecolor='#CCCCCC' showcanvasbg='1' animation='0' palettecolors='#008ee4,#6baa01,#f8bd19,#e44a00,#33bdda' showborder='0'>";

        int i = 0; int iCummulative = 0;
        foreach (BITeams o in lstBITeams)
        {
            i = oRpt.dtGetRequestsByTeamWeek(iWeek, iYear, o.m_iTeamId).Rows.Count;
            strXML += "<set label='" + o.m_sTeam + "' value='" + i + "' />";
            iCummulative = iCummulative + i;
        }

        strXML += "<set label='Cummulative' value='" + iCummulative + "' />";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "ByDepartmentWeek", "800", "500", "xml", strXML);
        //msline //stackedcolumn2d  //column2d //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }
}