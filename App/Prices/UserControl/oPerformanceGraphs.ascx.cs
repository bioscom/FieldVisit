using System;
using System.Collections.Generic;
using System.Linq;
using FusionCharts.Charts;

public partial class App_Prices_UserControl_oPerformanceGraphs : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void getValues()
    {
        List<Price> lstPrices = PriceHelper.LstGetPrices();

        decimal sumRedFlagValue = lstPrices.Sum(p => p.dPrice);
        decimal sumShouldBeValue = lstPrices.Sum(p => p.dShouldBePrice);
        decimal opportunity = sumRedFlagValue - sumShouldBeValue;
        decimal sumSaved = lstPrices.Sum(p => p.dAmountSaved);

        string strXML = null;

        strXML = @"<chart caption='Red Flag Savings' yaxisname='Amount' numberprefix='$' bgcolor='#FFFFFF' ";
        strXML += "showalternatehgridcolor ='0' showvalues='1' labeldisplay='WRAP' divlinecolor='#CCCCCC' ";
        strXML += "divlinealpha = '70' useroundedges='1' canvasbgcolor='#FFFFFF' canvasbasecolor='#CCCCCC' legendshadow ='1' ";
        strXML += "showcanvasbg = '1' animation='0' palettecolors='#ff0000, #FFA500, #00ff00, #e44a00, #33bdda' showborder='1'>";

        strXML += "<set label = 'Red Flag' value = '" + sumRedFlagValue + "' />";
        strXML += "<set label = 'Opportunity' value = '" + opportunity + "' />";
        strXML += "<set label = 'Saved' value = '" + sumSaved + "' />";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "myChart", "450", "450", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }


    //public void PDEstimateActualCummulativeBarGraph(int iYear)
    //{
    //    //PD Estimated Savings
    //    PDEstimatedActualSavings oJanEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.jan, iYear);
    //    PDEstimatedActualSavings oFebEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.feb, iYear);
    //    PDEstimatedActualSavings oMarEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.mar, iYear);
    //    PDEstimatedActualSavings oAprEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.apr, iYear);
    //    PDEstimatedActualSavings oMayEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.may, iYear);
    //    PDEstimatedActualSavings oJunEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.jun, iYear);
    //    PDEstimatedActualSavings oJulEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.jul, iYear);
    //    PDEstimatedActualSavings oAugEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.aug, iYear);
    //    PDEstimatedActualSavings oSepEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.sep, iYear);
    //    PDEstimatedActualSavings oOctEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.oct, iYear);
    //    PDEstimatedActualSavings oNovEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.nov, iYear);
    //    PDEstimatedActualSavings oDecEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int) mMonthEnuem.mMonth.dec, iYear);

    //    //PD Actual Savings
    //    PDEstimatedActualSavings oJanAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.jan, iYear);
    //    PDEstimatedActualSavings oFebAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.feb, iYear);
    //    PDEstimatedActualSavings oMarAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.mar, iYear);
    //    PDEstimatedActualSavings oAprAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.apr, iYear);
    //    PDEstimatedActualSavings oMayAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.may, iYear);
    //    PDEstimatedActualSavings oJunAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.jun, iYear);
    //    PDEstimatedActualSavings oJulAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.jul, iYear);
    //    PDEstimatedActualSavings oAugAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.aug, iYear);
    //    PDEstimatedActualSavings oSepAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.sep, iYear);
    //    PDEstimatedActualSavings oOctAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.oct, iYear);
    //    PDEstimatedActualSavings oNovAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.nov, iYear);
    //    PDEstimatedActualSavings oDecAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int) mMonthEnuem.mMonth.dec, iYear);


    //    //PD Estimated Savings
    //    decimal dSumJan = oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO; decimal dSumFeb = oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO;
    //    decimal dSumMar = oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO; decimal dSumApr = oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO;
    //    decimal dSumMay = oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO; decimal dSumJun = oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO;
    //    decimal dSumJul = oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO; decimal dSumAug = oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO;
    //    decimal dSumSep = oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO; decimal dSumOct = oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO;
    //    decimal dSumNov = oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO; decimal dSumDec = oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO;

    //    //PD Actual Savings
    //    decimal dSumJanA = oJanAct.dDD + oJanAct.dDDO + oJanAct.dEIO; decimal dSumFebA = oFebAct.dDD + oFebAct.dDDO + oFebAct.dEIO;
    //    decimal dSumMarA = oMarAct.dDD + oMarAct.dDDO + oMarAct.dEIO; decimal dSumAprA = oAprAct.dDD + oAprAct.dDDO + oAprAct.dEIO;
    //    decimal dSumMayA = oMayAct.dDD + oMayAct.dDDO + oMayAct.dEIO; decimal dSumJunA = oJunAct.dDD + oJunAct.dDDO + oJunAct.dEIO;
    //    decimal dSumJulA = oJulAct.dDD + oJulAct.dDDO + oJulAct.dEIO; decimal dSumAugA = oAugAct.dDD + oAugAct.dDDO + oAugAct.dEIO;
    //    decimal dSumSepA = oSepAct.dDD + oSepAct.dDDO + oSepAct.dEIO; decimal dSumOctA = oOctAct.dDD + oOctAct.dDDO + oOctAct.dEIO;
    //    decimal dSumNovA = oNovAct.dDD + oNovAct.dDDO + oNovAct.dEIO; decimal dSumDecA = oDecAct.dDD + oDecAct.dDDO + oDecAct.dEIO;

    //    //Do PD Estimated Savings cummulative 
    //    decimal JanE = dSumJan;
    //    decimal FebE = (dSumJan + dSumFeb);
    //    decimal MarE = (dSumJan + dSumFeb + dSumMar);
    //    decimal AprE = (dSumJan + dSumFeb + dSumMar + dSumApr);
    //    decimal MayE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay);
    //    decimal JunE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun);
    //    decimal JulE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul);
    //    decimal AugE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug);
    //    decimal SepE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep);
    //    decimal OctE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct);
    //    decimal NovE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov);
    //    decimal DecE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov + dSumDec);

    //    //Do PD Actual Savings Cummulative
    //    decimal JanA = dSumJanA;
    //    decimal FebA = (dSumJanA + dSumFebA);
    //    decimal MarA = (dSumMarA != 0) ? (dSumJanA + dSumFebA + dSumMarA) : 0;
    //    decimal AprA = (dSumAprA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA) : 0;
    //    decimal MayA = (dSumMayA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA) : 0;
    //    decimal JunA = (dSumJunA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA) : 0;
    //    decimal JulA = (dSumJulA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA) : 0;
    //    decimal AugA = (dSumAugA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA) : 0;
    //    decimal SepA = (dSumSepA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA) : 0;
    //    decimal OctA = (dSumOctA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA) : 0;
    //    decimal NovA = (dSumNovA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA + dSumNovA) : 0;
    //    decimal DecA = (dSumDecA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA + dSumNovA + dSumDecA) : 0;

    //    string strXML = null;

    //    strXML = @"<chart caption='PD - Estimated Savings Vs Actual Savings' baseFont='Arial' baseFontSize ='11' numberprefix='$' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showvalues='1' showcanvasborder='1' canvasborderalpha='0' canvasbordercolor='CCCCCC' canvasborderthickness='1' captionpadding='30' linethickness='3' yaxisvaluespadding='15' legendshadow='0' legendborderalpha='0' palettecolors='#f8bd19,#008ee4,#33bdda,#e44a00,#6baa01,#583e78' showborder='0'>";
    //    //strXML += "<categories>";
    //    strXML += "<categories font='Arial' fontsize='11' fontcolor='000000'>";
    //    strXML += "<category label='Jan' />";
    //    strXML += "<category label='Feb' />";
    //    strXML += "<category label='Mar' />";
    //    strXML += "<category label='Apr' />";
    //    strXML += "<category label='May' />";
    //    strXML += "<category label='Jun' />";
    //    strXML += "<category label='Jul' />";
    //    strXML += "<category label='Aug' />";
    //    strXML += "<category label='Sep' />";
    //    strXML += "<category label='Oct' />";
    //    strXML += "<category label='Nov' />";
    //    strXML += "<category label='Dec' />";
    //    strXML += "</categories>";

    //    strXML += "<dataset seriesname='PD Estimated Savings'>";
    //    strXML += "<set value='" + JanE + "' />";
    //    strXML += "<set value='" + FebE + "' />";
    //    strXML += "<set value='" + MarE + "' />";
    //    strXML += "<set value='" + AprE + "' />";
    //    strXML += "<set value='" + MayE + "' />";
    //    strXML += "<set value='" + JunE + "' />";
    //    strXML += "<set value='" + JulE + "' />";
    //    strXML += "<set value='" + AugE + "' />";
    //    strXML += "<set value='" + SepE + "' />";
    //    strXML += "<set value='" + OctE + "' />";
    //    strXML += "<set value='" + NovE + "' />";
    //    strXML += "<set value='" + DecE + "' />";
    //    strXML += "</dataset>";

    //    strXML += "<dataset seriesname='PD Actual Savings'>";
    //    strXML += "<set value='" + JanA + "' />";
    //    strXML += "<set value='" + FebA + "' />";
    //    strXML += "<set value='" + MarA + "' />";
    //    strXML += "<set value='" + AprA + "' />";
    //    strXML += "<set value='" + MayA + "' />";
    //    strXML += "<set value='" + JunA + "' />";
    //    strXML += "<set value='" + JulA + "' />";
    //    strXML += "<set value='" + AugA + "' />";
    //    strXML += "<set value='" + SepA + "' />";
    //    strXML += "<set value='" + OctA + "' />";
    //    strXML += "<set value='" + NovA + "' />";
    //    strXML += "<set value='" + DecA + "' />";
    //    strXML += "</dataset>";
    //    strXML += "</chart>";

    //    // Initialize the chart.
    //    Chart factoryOutput = new Chart("mscolumn2d", "myChartCummBarGraph", "880", "500", "xml", strXML);
    //    //msline
    //    //stackedcolumn2d
    //    //column2d
    //    //msstackedcolumn2d

    //    // Render the chart.
    //    FCLiteral.Text = factoryOutput.Render();
    //}

}