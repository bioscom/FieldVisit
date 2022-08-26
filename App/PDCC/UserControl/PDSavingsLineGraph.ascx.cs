using System;
using System.Collections.Generic;
// Use the `FusionCharts.Charts` namespace to be able to use classes and methods required to // create charts.
using FusionCharts.Charts;

public partial class App_PDCC_UserControl_PDSavingsLineGraph : System.Web.UI.UserControl
{
    PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {

    }

    public void PDEstimateActualCummulativeLineGraph(int iYear)
    {
        //PD Initial 25% Estimated Savings
        PDEstimatedActualSavings oJanInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecInitEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);


        //PD Estimated Savings
        PDEstimatedActualSavings oJanEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);

        //PD Actual Savings
        PDEstimatedActualSavings oJanAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);

        //PD Actual Savings
        PDEstimatedActualSavings oJanLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);

        //PD Initial 25% Estimated Savings
        decimal dSumJanInit = oJanInitEst.dDD + oJanInitEst.dDDO + oJanInitEst.dEIO; decimal dSumFebInit = oFebInitEst.dDD + oFebInitEst.dDDO + oFebInitEst.dEIO;
        decimal dSumMarInit = oMarInitEst.dDD + oMarInitEst.dDDO + oMarInitEst.dEIO; decimal dSumAprInit = oAprInitEst.dDD + oAprInitEst.dDDO + oAprInitEst.dEIO;
        decimal dSumMayInit = oMayInitEst.dDD + oMayInitEst.dDDO + oMayInitEst.dEIO; decimal dSumJunInit = oJunInitEst.dDD + oJunInitEst.dDDO + oJunInitEst.dEIO;
        decimal dSumJulInit = oJulInitEst.dDD + oJulInitEst.dDDO + oJulInitEst.dEIO; decimal dSumAugInit = oAugInitEst.dDD + oAugInitEst.dDDO + oAugInitEst.dEIO;
        decimal dSumSepInit = oSepInitEst.dDD + oSepInitEst.dDDO + oSepInitEst.dEIO; decimal dSumOctInit = oOctInitEst.dDD + oOctInitEst.dDDO + oOctInitEst.dEIO;
        decimal dSumNovInit = oNovInitEst.dDD + oNovInitEst.dDDO + oNovInitEst.dEIO; decimal dSumDecInit = oDecInitEst.dDD + oDecInitEst.dDDO + oDecInitEst.dEIO;


        //PD Estimated Savings
        decimal dSumJan = oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO; decimal dSumFeb = oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO;
        decimal dSumMar = oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO; decimal dSumApr = oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO;
        decimal dSumMay = oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO; decimal dSumJun = oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO;
        decimal dSumJul = oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO; decimal dSumAug = oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO;
        decimal dSumSep = oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO; decimal dSumOct = oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO;
        decimal dSumNov = oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO; decimal dSumDec = oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO;

        //PD Actual Savings
        decimal dSumJanA = oJanAct.dDD + oJanAct.dDDO + oJanAct.dEIO; decimal dSumFebA = oFebAct.dDD + oFebAct.dDDO + oFebAct.dEIO;
        decimal dSumMarA = oMarAct.dDD + oMarAct.dDDO + oMarAct.dEIO; decimal dSumAprA = oAprAct.dDD + oAprAct.dDDO + oAprAct.dEIO;
        decimal dSumMayA = oMayAct.dDD + oMayAct.dDDO + oMayAct.dEIO; decimal dSumJunA = oJunAct.dDD + oJunAct.dDDO + oJunAct.dEIO;
        decimal dSumJulA = oJulAct.dDD + oJulAct.dDDO + oJulAct.dEIO; decimal dSumAugA = oAugAct.dDD + oAugAct.dDDO + oAugAct.dEIO;
        decimal dSumSepA = oSepAct.dDD + oSepAct.dDDO + oSepAct.dEIO; decimal dSumOctA = oOctAct.dDD + oOctAct.dDDO + oOctAct.dEIO;
        decimal dSumNovA = oNovAct.dDD + oNovAct.dDDO + oNovAct.dEIO; decimal dSumDecA = oDecAct.dDD + oDecAct.dDDO + oDecAct.dEIO;

        //PD Latest Estimate Savings
        decimal dSumJanLE = oJanLE.dDD + oJanLE.dDDO + oJanLE.dEIO; decimal dSumFebLE = oFebLE.dDD + oFebLE.dDDO + oFebLE.dEIO;
        decimal dSumMarLE = oMarLE.dDD + oMarLE.dDDO + oMarLE.dEIO; decimal dSumAprLE = oAprLE.dDD + oAprLE.dDDO + oAprLE.dEIO;
        decimal dSumMayLE = oMayLE.dDD + oMayLE.dDDO + oMayLE.dEIO; decimal dSumJunLE = oJunLE.dDD + oJunLE.dDDO + oJunLE.dEIO;
        decimal dSumJulLE = oJulLE.dDD + oJulLE.dDDO + oJulLE.dEIO; decimal dSumAugLE = oAugLE.dDD + oAugLE.dDDO + oAugLE.dEIO;
        decimal dSumSepLE = oSepLE.dDD + oSepLE.dDDO + oSepLE.dEIO; decimal dSumOctLE = oOctLE.dDD + oOctLE.dDDO + oOctLE.dEIO;
        decimal dSumNovLE = oNovLE.dDD + oNovLE.dDDO + oNovLE.dEIO; decimal dSumDecLE = oDecLE.dDD + oDecLE.dDDO + oDecLE.dEIO;

        //Do cummulative 
        decimal JanInit = dSumJanInit;
        decimal FebInit = (dSumJanInit + dSumFebInit);
        decimal MarInit = (dSumJanInit + dSumFebInit + dSumMarInit);
        decimal AprInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit);
        decimal MayInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit);
        decimal JunInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit + dSumJunInit);
        decimal JulInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit + dSumJunInit + dSumJulInit);
        decimal AugInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit + dSumJunInit + dSumJulInit + dSumAugInit);
        decimal SepInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit + dSumJunInit + dSumJulInit + dSumAugInit + dSumSepInit);
        decimal OctInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit + dSumJunInit + dSumJulInit + dSumAugInit + dSumSepInit + dSumOctInit);
        decimal NovInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit + dSumJunInit + dSumJulInit + dSumAugInit + dSumSepInit + dSumOctInit + dSumNovInit);
        decimal DecInit = (dSumJanInit + dSumFebInit + dSumMarInit + dSumAprInit + dSumMayInit + dSumJunInit + dSumJulInit + dSumAugInit + dSumSepInit + dSumOctInit + dSumNovInit + dSumDecInit);

        //Do cummulative 
        decimal JanE = dSumJan;
        decimal FebE = (dSumJan + dSumFeb);
        decimal MarE = (dSumJan + dSumFeb + dSumMar);
        decimal AprE = (dSumJan + dSumFeb + dSumMar + dSumApr);
        decimal MayE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay);
        decimal JunE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun);
        decimal JulE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul);
        decimal AugE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug);
        decimal SepE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep);
        decimal OctE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct);
        decimal NovE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov);
        decimal DecE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov + dSumDec);

        //Do Cummulative
        string JanA = dSumJanA.ToString();
        string FebA = (dSumJanA + dSumFebA).ToString();
        string MarA = (dSumMarA != 0) ? (dSumJanA + dSumFebA + dSumMarA).ToString() : "";
        string AprA = (dSumAprA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA).ToString() : "";
        string MayA = (dSumMayA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA).ToString() : "";
        string JunA = (dSumJunA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA).ToString() : "";
        string JulA = (dSumJulA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA).ToString() : "";
        string AugA = (dSumAugA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA).ToString() : "";
        string SepA = (dSumSepA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA).ToString() : "";
        string OctA = (dSumOctA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA).ToString() : "";
        string NovA = (dSumNovA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA + dSumNovA).ToString() : "";
        string DecA = (dSumDecA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA + dSumNovA + dSumDecA).ToString() : "";

        //Do Cummulative
        string JanLE = dSumJanLE.ToString();
        string FebLE = (dSumJanLE + dSumFebLE).ToString();
        string MarLE = (dSumMarLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE).ToString() : "";
        string AprLE = (dSumAprLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE).ToString() : "";
        string MayLE = (dSumMayLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE).ToString() : "";
        string JunLE = (dSumJunLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE + dSumJunLE).ToString() : "";
        string JulLE = (dSumJulLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE + dSumJunLE + dSumJulLE).ToString() : "";
        string AugLE = (dSumAugLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE + dSumJunLE + dSumJulLE + dSumAugLE).ToString() : "";
        string SepLE = (dSumSepLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE + dSumJunLE + dSumJulLE + dSumAugLE + dSumSepLE).ToString() : "";
        string OctLE = (dSumOctLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE + dSumJunLE + dSumJulLE + dSumAugLE + dSumSepLE + dSumOctLE).ToString() : "";
        string NovLE = (dSumNovLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE + dSumJunLE + dSumJulLE + dSumAugLE + dSumSepLE + dSumOctLE + dSumNovLE).ToString() : "";
        string DecLE = (dSumDecLE != 0) ? (dSumJanLE + dSumFebLE + dSumMarLE + dSumAprLE + dSumMayLE + dSumJunLE + dSumJulLE + dSumAugLE + dSumSepLE + dSumOctLE + dSumNovLE + dSumDecLE).ToString() : "";

        string strXML = null;

        strXML = @"<chart caption='" + iYear + " PD Estimate Vs Actual - Cummulative' xaxisname='Month' yaxisname='Savings F$mln' baseFont='Arial' baseFontSize ='12' outCnvBaseFont='Arial' outCnvBaseFontSize ='12' numberprefix='' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showvalues='0' showcanvasborder='1' canvasborderalpha='0' canvasbordercolor='CCCCCC' canvasborderthickness='1' captionpadding='30' linethickness='3' yaxisvaluespadding='15' legendshadow='0' legendborderalpha='0' palettecolors='#f8bd19,#008ee4,#33bdda,#e44a00,#6baa01,#583e78' showborder='1'>";
        //strXML += "<categories>";
        strXML += "<categories font='Arial' fontsize='12' fontcolor='000000'>";
        strXML += "<category label='Jan' />";
        strXML += "<category label='Feb' />";
        strXML += "<category label='Mar' />";
        strXML += "<category label='Apr' />";
        strXML += "<category label='May' />";
        strXML += "<category label='Jun' />";
        strXML += "<category label='Jul' />";
        strXML += "<category label='Aug' />";
        strXML += "<category label='Sep' />";
        strXML += "<category label='Oct' />";
        strXML += "<category label='Nov' />";
        strXML += "<category label='Dec' />";
        strXML += "</categories>";


        strXML += "<dataset seriesname='PD Initial 25% Estimated Savings'>";
        strXML += "<set value='" + JanInit + "' showvalue='1' />";
        strXML += "<set value='" + FebInit + "' />";
        strXML += "<set value='" + MarInit + "' />";
        strXML += "<set value='" + AprInit + "' />";
        strXML += "<set value='" + MayInit + "' />";
        strXML += "<set value='" + JunInit + "' />";
        strXML += "<set value='" + JulInit + "' showvalue='1' />";
        strXML += "<set value='" + AugInit + "' />";
        strXML += "<set value='" + SepInit + "' />";
        strXML += "<set value='" + OctInit + "' />";
        strXML += "<set value='" + NovInit + "' />";
        strXML += "<set value='" + DecInit + "' showvalue='1'/>";
        strXML += "</dataset>";


        strXML += "<dataset seriesname='PD Estimated Savings'>";
        strXML += "<set value='" + JanE + "' showvalue='1' />";
        strXML += "<set value='" + FebE + "' />";
        strXML += "<set value='" + MarE + "' />";
        strXML += "<set value='" + AprE + "' />";
        strXML += "<set value='" + MayE + "' />";
        strXML += "<set value='" + JunE + "' />";
        strXML += "<set value='" + JulE + "' showvalue='1'/>";
        strXML += "<set value='" + AugE + "' />";
        strXML += "<set value='" + SepE + "' />";
        strXML += "<set value='" + OctE + "' />";
        strXML += "<set value='" + NovE + "' />";
        strXML += "<set value='" + DecE + "' showvalue='1'/>";
        strXML += "</dataset>";

        strXML += "<dataset seriesname='PD Latest Estimate Savings'>";
        strXML += "<set value='" + JanLE + "' showvalue='1'/>";
        strXML += "<set value='" + FebLE + "' />";
        strXML += "<set value='" + MarLE + "' />";
        strXML += "<set value='" + AprLE + "' />";
        strXML += "<set value='" + MayLE + "' />";
        strXML += "<set value='" + JunLE + "' />";
        strXML += "<set value='" + JulLE + "' showvalue='1'/>";
        strXML += "<set value='" + AugLE + "' />";
        strXML += "<set value='" + SepLE + "' />";
        strXML += "<set value='" + OctLE + "' />";
        strXML += "<set value='" + NovLE + "' />";
        strXML += "<set value='" + DecLE + "' showvalue='1'/>";
        strXML += "</dataset>";

        strXML += "<dataset seriesname='PD Actual Savings'>";
        strXML += "<set value='" + JanA + "' showvalue='1'/>";
        strXML += "<set value='" + FebA + "' />";
        strXML += "<set value='" + MarA + "' />";
        strXML += "<set value='" + AprA + "' />";
        strXML += "<set value='" + MayA + "' />";
        strXML += "<set value='" + JunA + "' />";
        strXML += "<set value='" + JulA + "' showvalue='1'/>";
        strXML += "<set value='" + AugA + "' />";
        strXML += "<set value='" + SepA + "' />";
        strXML += "<set value='" + OctA + "' />";
        strXML += "<set value='" + NovA + "' />";
        strXML += "<set value='" + DecA + "' showvalue='1'/>";
        strXML += "</dataset>";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("msline", "myChartLine", "700", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    public void StackedBarChart(int iYear)
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
        List<AssetPdcc> lstAssets = AssetPdcc.lstGetAssets();
        string strXML = null;
        strXML = @"<chart caption='" + iYear + " Savings by Asset' baseFont='Arial' baseFontSize ='12' outCnvBaseFont='Arial' outCnvBaseFontSize ='12' numberprefix='' showvalues='0' plotgradientcolor='' formatnumberscale='0' showplotborder='0' palettecolors='#EED17F,#97CBE7,#074868,#B0D67A,#2C560A,#DD9D82' canvaspadding='0' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showcanvasborder='1' legendborderalpha='0' legendshadow='0' interactivelegend='0' showpercentvalues='1' showsum='1' canvasborderalpha='0' showborder='1'>";
        //strXML = @"<chart caption='Savings by Asset' baseFont='Arial' baseFontSize ='14' outCnvBaseFont='Arial' outCnvBaseFontSize ='12' numberprefix='$' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showvalues='1' showcanvasborder='1' canvasborderalpha='0' canvasbordercolor='CCCCCC' canvasborderthickness='1' captionpadding='30' linethickness='3' yaxisvaluespadding='15' legendshadow='0' legendborderalpha='0' palettecolors='#f8bd19,#008ee4,#33bdda,#e44a00,#6baa01,#583e78' showborder='1'>";

        strXML += "<categories>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            strXML += "<category label='" + oAsset.sAsset + "' />";
        }
        strXML += "</categories>";


        strXML += "<dataset seriesname='Deep Dive' renderas='Area'>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex == 0)
            {
                strXML += "<set value='' />";
            }
            else if (xCop.dOpex != 0)
            {
                strXML += "<set value='" + Math.Round(((xCop.dDeepDiveBankable / xCop.dOpex) * 100), 1) + "' />";
            }
        }
        strXML += "</dataset>";


        strXML += "<dataset seriesname='Deep Dive Opportunity' renderas='Area'>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex == 0)
            {
                strXML += "<set value='' />";
            }
            else if (xCop.dOpex != 0)
            {
                strXML += "<set value='" + Math.Round(((xCop.dDeepDiveOpporBanked / xCop.dOpex) * 100), 1) + "' />";
            }
        }
        strXML += "</dataset>";

        strXML += "<dataset seriesname='Efficiency Improvement Opportunity' renderas='Area'>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex == 0)
            {
                strXML += "<set value='' />";
            }
            else if (xCop.dOpex != 0)
            {
                strXML += "<set value='" + Math.Round(((xCop.dEIOBanked / xCop.dOpex) * 100), 1) + "' />";
            }
        }
        strXML += "</dataset>";

        //decimal dResult = 0;
        //foreach (AssetPdcc oAsset in lstAssets)
        //{
        //    PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
        //    if (xCop.dOpex != 0)
        //    {
        //        dResult = oPDCostReductionSummaryHelper.PercentageSavingsBanked(xCop.dOpex, xCop.dEIOBanked, xCop.dDeepDiveBanked, xCop.dDeepDiveOpporBanked);
        //        strXML += "<set label='" + oAsset.sAsset + "' value='" + dResult + "' />";
        //    }
        //}

        //PDPerformanceSumm xOnshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 1);  //ONSHORE
        //PDPerformanceSumm xOffshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 2);  //OFFSHORE
        //PDPerformanceSumm xSpdc = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 1); //SPDC
        //PDPerformanceSumm xSnepco = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 2); //SNEPCO

        //decimal Onshore = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xOnshore.dOpex, xOnshore.dEIOBanked, xOnshore.dDDBanked, xOnshore.dDDOpporBanked));
        //decimal Offshore = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xOffshore.dOpex, xOffshore.dEIOBanked, xOffshore.dDDBanked, xOffshore.dDDOpporBanked));
        //decimal Spdc = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xSpdc.dOpex, xSpdc.dEIOBanked, xSpdc.dDDBanked, xSpdc.dDDOpporBanked));
        //decimal Snepco = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xSnepco.dOpex, xSnepco.dEIOBanked, xSnepco.dDDBanked, xSnepco.dDDOpporBanked));

        //decimal PDPerformanceOpex = (xOnshore.dOpex + xOffshore.dOpex + xSpdc.dOpex + xSnepco.dOpex);
        //decimal PDPerformanceDDBanked = (xOnshore.dDDBanked + xOffshore.dDDBanked + xSpdc.dDDBanked + xSnepco.dDDBanked);
        //decimal PDPerformanceDDOpporBanked = (xOnshore.dDDOpporBanked + xOffshore.dDDOpporBanked + xSpdc.dDDOpporBanked + xSnepco.dDDOpporBanked);

        //decimal PDPerformance = oPDCostReductionSummaryHelper.PercentageDDBanked(PDPerformanceOpex, PDPerformanceDDBanked, PDPerformanceDDOpporBanked); //(Onshore + Offshore + Spdc + Snepco);

        //strXML += "<set label='ONSHORE' value='" + Onshore + "' />";
        //strXML += "<set label='OFFSHORE' value='" + Offshore + "' />";
        //strXML += "<set label='SPDC' value='" + Spdc + "' />";
        //strXML += "<set label='SNEPCO' value='" + Snepco + "' />";
        //strXML += "<set label='PD Performance' value='" + PDPerformance + "' />";

        strXML += "<trendlines>";
        strXML += "<line startValue='25' color='91C728' displayValue='25%' showOnTop='1'/>";
        strXML += "</trendlines>";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("stackedcolumn2d", "myChartStacked", "700", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }
    
    public void PercentageSavingsBanked(int iYear)
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
        List<AssetPdcc> lstAssets = AssetPdcc.lstGetAssets();
        string strXML = null;
        strXML = @"<chart caption='------' showvalues='0' plotgradientcolor='' formatnumberscale='0' showplotborder='0' palettecolors='#EED17F,#97CBE7,#074868,#B0D67A,#2C560A,#DD9D82' canvaspadding='0' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showcanvasborder='0' legendborderalpha='0' legendshadow='0' interactivelegend='0' showpercentvalues='1' showsum='1' canvasborderalpha='0' showborder='0'>";

        strXML += "<categories>";
        foreach (AssetPdcc oAsset in lstAssets)
        {
            strXML += "<category label='" + oAsset.sAsset + "' />";
        }
        strXML += "</categories>";


        strXML += "<dataset seriesname='Deep Dive' renderas='Area'>";
        //decimal dResult = 0;
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex != 0)
            {
                //dResult = oPDCostReductionSummaryHelper.PercentageSavingsBanked(xCop.dOpex, xCop.dEIOBanked, xCop.dDeepDiveBanked, xCop.dDeepDiveOpporBanked);
                strXML += "<set value='" + xCop.dDeepDiveBanked + "' />";
                //strXML += "<set label='" + oAsset.sAsset + "' value='" + dResult + "' />";
            }
        }
        strXML += "</dataset>";


        strXML += "<dataset seriesname='Deep Dive Opportunity' renderas='Area'>";
        //decimal dResult = 0;
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex != 0)
            {
                //dResult = oPDCostReductionSummaryHelper.PercentageSavingsBanked(xCop.dOpex, xCop.dEIOBanked, xCop.dDeepDiveBanked, xCop.dDeepDiveOpporBanked);
                strXML += "<set value='" + xCop.dDeepDiveOpporBanked + "' />";
                //strXML += "<set label='" + oAsset.sAsset + "' value='" + dResult + "' />";
            }
        }
        strXML += "</dataset>";

        strXML += "<dataset seriesname='Efficiency Improvement Opportunity' renderas='Area'>";
        //decimal dResult = 0;
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex != 0)
            {
                //dResult = oPDCostReductionSummaryHelper.PercentageSavingsBanked(xCop.dOpex, xCop.dEIOBanked, xCop.dDeepDiveBanked, xCop.dDeepDiveOpporBanked);
                strXML += "<set value='" + xCop.dEIOBanked + "' />";
                //strXML += "<set label='" + oAsset.sAsset + "' value='" + dResult + "' />";
            }
        }
        strXML += "</dataset>";


        decimal dResult = 0;
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex != 0)
            {
                dResult = oPDCostReductionSummaryHelper.PercentageSavingsBanked(xCop.dOpex, xCop.dEIOBanked, xCop.dDeepDiveBanked, xCop.dDeepDiveOpporBanked);
                strXML += "<set label='" + oAsset.sAsset + "' value='" + dResult + "' />";
            }
        }

        PDPerformanceSumm xOnshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 1);  //ONSHORE
        PDPerformanceSumm xOffshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 2);  //OFFSHORE
        PDPerformanceSumm xSpdc = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 1); //SPDC
        PDPerformanceSumm xSnepco = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 2); //SNEPCO

        decimal Onshore = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xOnshore.dOpex, xOnshore.dEIOBanked, xOnshore.dDDBanked, xOnshore.dDDOpporBanked));
        decimal Offshore = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xOffshore.dOpex, xOffshore.dEIOBanked, xOffshore.dDDBanked, xOffshore.dDDOpporBanked));
        decimal Spdc = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xSpdc.dOpex, xSpdc.dEIOBanked, xSpdc.dDDBanked, xSpdc.dDDOpporBanked));
        decimal Snepco = (oPDCostReductionSummaryHelper.PercentageSavingsBanked(xSnepco.dOpex, xSnepco.dEIOBanked, xSnepco.dDDBanked, xSnepco.dDDOpporBanked));

        decimal PDPerformanceOpex = (xOnshore.dOpex + xOffshore.dOpex + xSpdc.dOpex + xSnepco.dOpex);
        decimal PDPerformanceDDBanked = (xOnshore.dDDBanked + xOffshore.dDDBanked + xSpdc.dDDBanked + xSnepco.dDDBanked);
        decimal PDPerformanceDDOpporBanked = (xOnshore.dDDOpporBanked + xOffshore.dDDOpporBanked + xSpdc.dDDOpporBanked + xSnepco.dDDOpporBanked);

        decimal PDPerformance = oPDCostReductionSummaryHelper.PercentageDDBanked(PDPerformanceOpex, PDPerformanceDDBanked, PDPerformanceDDOpporBanked); //(Onshore + Offshore + Spdc + Snepco);

        strXML += "<set label='ONSHORE' value='" + Onshore + "' />";
        strXML += "<set label='OFFSHORE' value='" + Offshore + "' />";
        strXML += "<set label='SPDC' value='" + Spdc + "' />";
        strXML += "<set label='SNEPCO' value='" + Snepco + "' />";
        strXML += "<set label='PD Performance' value='" + PDPerformance + "' />";

        strXML += "<trendlines>";
        strXML += "<line startValue='25' color='91C728' displayValue='25%' showOnTop='1'/>";
        strXML += "</trendlines>";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "myChartBarPerSavingBanked", "1000", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }
    public void PercentageDDBanked(int iYear)
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
        List<AssetPdcc> lstAssets = AssetPdcc.lstGetAssets();
        string strXML = null;
        strXML = @"<chart caption='" + iYear + " %Deep Dive Banked Vs %Savings Target' baseFont='Arial' baseFontSize ='14' outCnvBaseFont='Arial' outCnvBaseFontSize ='12' xAxisName='Asset' yAxisName='Percentage Performance' showValues='1' numberPrefix='%' useroundedges='0' canvasbgalpha='0' bgalpha='0' plotborderalpha='0' showalternatehgridcolor='0' plotgradientcolor='' showplotborder='0' numdivlines='5' palettecolors='#1790E1' canvasborderthickness='1' canvasbordercolor='#074868' basefontcolor='#074868' divlinecolor='#074868' divlinealpha='10' tooltipborderalpha='0' showborder='1'>";

        decimal dResult = 0;
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex != 0)
            {
                dResult = oPDCostReductionSummaryHelper.PercentageDDBanked(xCop.dOpex, xCop.dDeepDiveBanked, xCop.dDeepDiveOpporBanked);
                strXML += "<set label='" + oAsset.sAsset + "' value='" + dResult + "' />";
            }
        }

        PDPerformanceSumm xOnshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 1);  //ONSHORE
        PDPerformanceSumm xOffshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 2);  //OFFSHORE
        PDPerformanceSumm xSpdc = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 1); //SPDC
        PDPerformanceSumm xSnepco = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 2); //SNEPCO

        decimal Onshore = (oPDCostReductionSummaryHelper.PercentageDDBanked(xOnshore.dOpex, xOnshore.dDDBanked, xOnshore.dDDOpporBanked));
        decimal Offshore = (oPDCostReductionSummaryHelper.PercentageDDBanked(xOffshore.dOpex, xOffshore.dDDBanked, xOffshore.dDDOpporBanked));
        decimal Spdc = (oPDCostReductionSummaryHelper.PercentageDDBanked(xSpdc.dOpex, xSpdc.dDDBanked, xSpdc.dDDOpporBanked));
        decimal Snepco = (oPDCostReductionSummaryHelper.PercentageDDBanked(xSnepco.dOpex, xSnepco.dDDBanked, xSnepco.dDDOpporBanked));

        decimal PDPerformanceOpex = (xOnshore.dOpex + xOffshore.dOpex + xSpdc.dOpex + xSnepco.dOpex);
        decimal PDPerformanceDDBanked = (xOnshore.dDDBanked + xOffshore.dDDBanked + xSpdc.dDDBanked + xSnepco.dDDBanked);
        decimal PDPerformanceDDOpporBanked = (xOnshore.dDDOpporBanked + xOffshore.dDDOpporBanked + xSpdc.dDDOpporBanked + xSnepco.dDDOpporBanked);
        decimal PDPerformance = oPDCostReductionSummaryHelper.PercentageDDBanked(PDPerformanceOpex, PDPerformanceDDBanked, PDPerformanceDDOpporBanked); //(Onshore + Offshore + Spdc + Snepco);

        //decimal PDPerformance = (Onshore + Offshore + Spdc + Snepco);

        strXML += "<set label='ONSHORE' value='" + Onshore + "' />";
        strXML += "<set label='OFFSHORE' value='" + Offshore + "' />";
        strXML += "<set label='SPDC' value='" + Spdc + "' />";
        strXML += "<set label='SNEPCO' value='" + Snepco + "' />";
        strXML += "<set label='PD Performance' value='" + PDPerformance + "' />";

        strXML += "<trendlines>";
        strXML += "<line startValue='25' color='91C728' displayValue='25%' showOnTop='1'/>";
        strXML += "</trendlines>";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "myChartBarPerDDBanked", "1000", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }
    public void PercentageEIOBanked(int iYear)
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
        List<AssetPdcc> lstAssets = AssetPdcc.lstGetAssets();
        string strXML = null;
        strXML = @"<chart caption='" + iYear + " %Efficiency Improvement Opportunity Banked' baseFont='Arial' baseFontSize ='14' outCnvBaseFont='Arial' outCnvBaseFontSize ='12' xAxisName='Asset' yAxisName='Percentage Performance' showValues='1' numberPrefix='%' useroundedges='0' canvasbgalpha='0' bgalpha='0' plotborderalpha='0' showalternatehgridcolor='0' plotgradientcolor='' showplotborder='0' numdivlines='5' palettecolors='#1790E1' canvasborderthickness='1' canvasbordercolor='#074868' basefontcolor='#074868' divlinecolor='#074868' divlinealpha='10' tooltipborderalpha='0' showborder='1'>";

        decimal dResult = 0;
        foreach (AssetPdcc oAsset in lstAssets)
        {
            PDCostReductionSummary xCop = oPDCostReductionSummaryHelper.ObjGetCostReductionSummaryByAssetId(oAsset.iAssetId, iYear);
            if (xCop.dOpex != 0)
            {
                dResult = oPDCostReductionSummaryHelper.PercentageEioBanked(xCop.dEIOBanked, xCop.dEIO);
                strXML += "<set label='" + oAsset.sAsset + "' value='" + dResult + "' />";
            }
        }

        PDPerformanceSumm xOnshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 1);  //ONSHORE
        PDPerformanceSumm xOffshore = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 2);  //OFFSHORE
        PDPerformanceSumm xSpdc = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 1); //SPDC
        PDPerformanceSumm xSnepco = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 2); //SNEPCO

        decimal Onshore = (oPDCostReductionSummaryHelper.PercentageEioBanked(xOnshore.dEIOBanked, xOnshore.dEIO));
        decimal Offshore = (oPDCostReductionSummaryHelper.PercentageEioBanked(xOffshore.dEIOBanked, xOffshore.dEIO));
        decimal Spdc = (oPDCostReductionSummaryHelper.PercentageEioBanked(xSpdc.dEIOBanked, xSpdc.dEIO));
        decimal Snepco = (oPDCostReductionSummaryHelper.PercentageEioBanked(xSnepco.dEIOBanked, xSnepco.dEIO));

        decimal PDPerformanceEIO = (xOnshore.dEIO + xOffshore.dEIO + xSpdc.dEIO + xSnepco.dEIO);
        decimal PDPerformanceEIOBanked = (xOnshore.dEIOBanked + xOffshore.dEIOBanked + xSpdc.dEIOBanked + xSnepco.dEIOBanked);

        decimal PDPerformance = oPDCostReductionSummaryHelper.PercentageEioBanked(PDPerformanceEIOBanked, PDPerformanceEIO); //(Onshore + Offshore + Spdc + Snepco);

        strXML += "<set label='ONSHORE' value='" + Onshore + "' />";
        strXML += "<set label='OFFSHORE' value='" + Offshore + "' />";
        strXML += "<set label='SPDC' value='" + Spdc + "' />";
        strXML += "<set label='SNEPCO' value='" + Snepco + "' />";
        strXML += "<set label='PD Performance' value='" + PDPerformance + "' />";

        strXML += "<trendlines>";
        strXML += "<line startValue='25' color='91C728' displayValue='25%' showOnTop='1'/>";
        strXML += "</trendlines>";

        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("column2d", "myChartBarPerEIOBanked", "1000", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    #region ===================  Graphs not in use =============================
    public void PDEstimateActualCummulativeBarGraph(int iYear)
    {
        //PD Estimated Savings
        PDEstimatedActualSavings oJanEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);

        //PD Actual Savings
        PDEstimatedActualSavings oJanAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);


        //PD Estimated Savings
        decimal dSumJan = oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO; decimal dSumFeb = oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO;
        decimal dSumMar = oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO; decimal dSumApr = oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO;
        decimal dSumMay = oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO; decimal dSumJun = oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO;
        decimal dSumJul = oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO; decimal dSumAug = oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO;
        decimal dSumSep = oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO; decimal dSumOct = oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO;
        decimal dSumNov = oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO; decimal dSumDec = oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO;

        //PD Actual Savings
        decimal dSumJanA = oJanAct.dDD + oJanAct.dDDO + oJanAct.dEIO; decimal dSumFebA = oFebAct.dDD + oFebAct.dDDO + oFebAct.dEIO;
        decimal dSumMarA = oMarAct.dDD + oMarAct.dDDO + oMarAct.dEIO; decimal dSumAprA = oAprAct.dDD + oAprAct.dDDO + oAprAct.dEIO;
        decimal dSumMayA = oMayAct.dDD + oMayAct.dDDO + oMayAct.dEIO; decimal dSumJunA = oJunAct.dDD + oJunAct.dDDO + oJunAct.dEIO;
        decimal dSumJulA = oJulAct.dDD + oJulAct.dDDO + oJulAct.dEIO; decimal dSumAugA = oAugAct.dDD + oAugAct.dDDO + oAugAct.dEIO;
        decimal dSumSepA = oSepAct.dDD + oSepAct.dDDO + oSepAct.dEIO; decimal dSumOctA = oOctAct.dDD + oOctAct.dDDO + oOctAct.dEIO;
        decimal dSumNovA = oNovAct.dDD + oNovAct.dDDO + oNovAct.dEIO; decimal dSumDecA = oDecAct.dDD + oDecAct.dDDO + oDecAct.dEIO;

        //Do PD Estimated Savings cummulative 
        decimal JanE = dSumJan;
        decimal FebE = (dSumJan + dSumFeb);
        decimal MarE = (dSumJan + dSumFeb + dSumMar);
        decimal AprE = (dSumJan + dSumFeb + dSumMar + dSumApr);
        decimal MayE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay);
        decimal JunE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun);
        decimal JulE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul);
        decimal AugE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug);
        decimal SepE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep);
        decimal OctE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct);
        decimal NovE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov);
        decimal DecE = (dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov + dSumDec);

        //Do PD Actual Savings Cummulative
        decimal JanA = dSumJanA;
        decimal FebA = (dSumJanA + dSumFebA);
        decimal MarA = (dSumMarA != 0) ? (dSumJanA + dSumFebA + dSumMarA) : 0;
        decimal AprA = (dSumAprA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA) : 0;
        decimal MayA = (dSumMayA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA) : 0;
        decimal JunA = (dSumJunA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA) : 0;
        decimal JulA = (dSumJulA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA) : 0;
        decimal AugA = (dSumAugA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA) : 0;
        decimal SepA = (dSumSepA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA) : 0;
        decimal OctA = (dSumOctA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA) : 0;
        decimal NovA = (dSumNovA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA + dSumNovA) : 0;
        decimal DecA = (dSumDecA != 0) ? (dSumJanA + dSumFebA + dSumMarA + dSumAprA + dSumMayA + dSumJunA + dSumJulA + dSumAugA + dSumSepA + dSumOctA + dSumNovA + dSumDecA) : 0;

        string strXML = null;

        strXML = @"<chart caption='PD - Estimated Savings Vs Actual Savings' baseFont='Arial' baseFontSize ='11' numberprefix='$' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' divlinecolor='CCCCCC' showvalues='1' showcanvasborder='1' canvasborderalpha='0' canvasbordercolor='CCCCCC' canvasborderthickness='1' captionpadding='30' linethickness='3' yaxisvaluespadding='15' legendshadow='0' legendborderalpha='0' palettecolors='#f8bd19,#008ee4,#33bdda,#e44a00,#6baa01,#583e78' showborder='0'>";
        //strXML += "<categories>";
        strXML += "<categories font='Arial' fontsize='11' fontcolor='000000'>";
        strXML += "<category label='Jan' />";
        strXML += "<category label='Feb' />";
        strXML += "<category label='Mar' />";
        strXML += "<category label='Apr' />";
        strXML += "<category label='May' />";
        strXML += "<category label='Jun' />";
        strXML += "<category label='Jul' />";
        strXML += "<category label='Aug' />";
        strXML += "<category label='Sep' />";
        strXML += "<category label='Oct' />";
        strXML += "<category label='Nov' />";
        strXML += "<category label='Dec' />";
        strXML += "</categories>";

        strXML += "<dataset seriesname='PD Estimated Savings'>";
        strXML += "<set value='" + JanE + "' />";
        strXML += "<set value='" + FebE + "' />";
        strXML += "<set value='" + MarE + "' />";
        strXML += "<set value='" + AprE + "' />";
        strXML += "<set value='" + MayE + "' />";
        strXML += "<set value='" + JunE + "' />";
        strXML += "<set value='" + JulE + "' />";
        strXML += "<set value='" + AugE + "' />";
        strXML += "<set value='" + SepE + "' />";
        strXML += "<set value='" + OctE + "' />";
        strXML += "<set value='" + NovE + "' />";
        strXML += "<set value='" + DecE + "' />";
        strXML += "</dataset>";

        strXML += "<dataset seriesname='PD Actual Savings'>";
        strXML += "<set value='" + JanA + "' />";
        strXML += "<set value='" + FebA + "' />";
        strXML += "<set value='" + MarA + "' />";
        strXML += "<set value='" + AprA + "' />";
        strXML += "<set value='" + MayA + "' />";
        strXML += "<set value='" + JunA + "' />";
        strXML += "<set value='" + JulA + "' />";
        strXML += "<set value='" + AugA + "' />";
        strXML += "<set value='" + SepA + "' />";
        strXML += "<set value='" + OctA + "' />";
        strXML += "<set value='" + NovA + "' />";
        strXML += "<set value='" + DecA + "' />";
        strXML += "</dataset>";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("mscolumn2d", "myChartCummBarGraph", "880", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    public void PDEstimateActualAbsoluteBarGraph(int iYear)
    {
        //PD Estimated Savings
        PDEstimatedActualSavings oJanEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);

        //PD Actual Savings
        PDEstimatedActualSavings oJanAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
        PDEstimatedActualSavings oFebAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
        PDEstimatedActualSavings oMarAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
        PDEstimatedActualSavings oAprAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
        PDEstimatedActualSavings oMayAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
        PDEstimatedActualSavings oJunAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
        PDEstimatedActualSavings oJulAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
        PDEstimatedActualSavings oAugAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
        PDEstimatedActualSavings oSepAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
        PDEstimatedActualSavings oOctAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
        PDEstimatedActualSavings oNovAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
        PDEstimatedActualSavings oDecAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);

        decimal dSumJan = oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO; decimal dSumFeb = oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO;
        decimal dSumMar = oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO; decimal dSumApr = oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO;
        decimal dSumMay = oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO; decimal dSumJun = oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO;
        decimal dSumJul = oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO; decimal dSumAug = oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO;
        decimal dSumSep = oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO; decimal dSumOct = oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO;
        decimal dSumNov = oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO; decimal dSumDec = oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO;

        decimal dSumJanA = oJanAct.dDD + oJanAct.dDDO + oJanAct.dEIO; decimal dSumFebA = oFebAct.dDD + oFebAct.dDDO + oFebAct.dEIO;
        decimal dSumMarA = oMarAct.dDD + oMarAct.dDDO + oMarAct.dEIO; decimal dSumAprA = oAprAct.dDD + oAprAct.dDDO + oAprAct.dEIO;
        decimal dSumMayA = oMayAct.dDD + oMayAct.dDDO + oMayAct.dEIO; decimal dSumJunA = oJunAct.dDD + oJunAct.dDDO + oJunAct.dEIO;
        decimal dSumJulA = oJulAct.dDD + oJulAct.dDDO + oJulAct.dEIO; decimal dSumAugA = oAugAct.dDD + oAugAct.dDDO + oAugAct.dEIO;
        decimal dSumSepA = oSepAct.dDD + oSepAct.dDDO + oSepAct.dEIO; decimal dSumOctA = oOctAct.dDD + oOctAct.dDDO + oOctAct.dEIO;
        decimal dSumNovA = oNovAct.dDD + oNovAct.dDDO + oNovAct.dEIO; decimal dSumDecA = oDecAct.dDD + oDecAct.dDDO + oDecAct.dEIO;

        string strXML = null;

        //strXML = @"<chart palette='3' caption='Cost Ambition' subcaption='In Million $' xaxisname='Department' yaxisname='Deep Dive (In USD)' numdivlines='3' numberprefix='$' showsum='0' useroundedges='1' showborder='0'>";
        //strXML += "<categories font='Arial' fontsize='12' fontcolor='000000'>";

        strXML = @"<chart palette='3' caption='PD - Estimated Savings Vs Actual Savings' baseFont='Arial' baseFontSize ='11' subcaption='In Million $' yaxisname='In Million $' showvalues='1' numvdivlines='3' numberprefix='$' divlinealpha='30' drawanchors='0' useroundedges='1' legendborderalpha='0' showborder='1'>";
        strXML += "<categories font='Arial' fontsize='11' fontcolor='000000'>";
        strXML += "<category label='Jan' />";
        strXML += "<category label='Feb' />";
        strXML += "<category label='Mar' />";
        strXML += "<category label='Apr' />";
        strXML += "<category label='May' />";
        strXML += "<category label='Jun' />";
        strXML += "<category label='Jul' />";
        strXML += "<category label='Aug' />";
        strXML += "<category label='Sep' />";
        strXML += "<category label='Oct' />";
        strXML += "<category label='Nov' />";
        strXML += "<category label='Dec' />";
        strXML += "</categories>";

        strXML += "<dataset seriesname='PD Estimated Savings'>";
        strXML += "<set value='" + dSumJan + "' />";
        strXML += "<set value='" + dSumFeb + "' />";
        strXML += "<set value='" + dSumMar + "' />";
        strXML += "<set value='" + dSumApr + "' />";
        strXML += "<set value='" + dSumMay + "' />";
        strXML += "<set value='" + dSumJun + "' />";
        strXML += "<set value='" + dSumJul + "' />";
        strXML += "<set value='" + dSumAug + "' />";
        strXML += "<set value='" + dSumSep + "' />";
        strXML += "<set value='" + dSumOct + "' />";
        strXML += "<set value='" + dSumNov + "' />";
        strXML += "<set value='" + dSumDec + "' />";
        strXML += "</dataset>";

        strXML += "<dataset seriesname='PD Actual Savings'>";
        strXML += "<set value='" + dSumJanA + "' />";
        strXML += "<set value='" + dSumFebA + "' />";
        strXML += "<set value='" + dSumMarA + "' />";
        strXML += "<set value='" + dSumAprA + "' />";
        strXML += "<set value='" + dSumMayA + "' />";
        strXML += "<set value='" + dSumJunA + "' />";
        strXML += "<set value='" + dSumJulA + "' />";
        strXML += "<set value='" + dSumAugA + "' />";
        strXML += "<set value='" + dSumSepA + "' />";
        strXML += "<set value='" + dSumOctA + "' />";
        strXML += "<set value='" + dSumNovA + "' />";
        strXML += "<set value='" + dSumDecA + "' />";
        strXML += "</dataset>";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("mscolumn2d", "myChartBar", "880", "500", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.
        FCLiteral.Text = factoryOutput.Render();
    }

    #endregion
}