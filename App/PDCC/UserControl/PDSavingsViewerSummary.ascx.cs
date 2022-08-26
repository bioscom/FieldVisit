using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_UserControl_PDSavingsViewerSummary : System.Web.UI.UserControl
{
    PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control(int iYear)
    {
        PDEstimatedActualSavings oJanEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(1, iYear); 
        PDEstimatedActualSavings oFebEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(2, iYear);
        PDEstimatedActualSavings oMarEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(3, iYear);
        PDEstimatedActualSavings oAprEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(4, iYear);
        PDEstimatedActualSavings oMayEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(5, iYear);
        PDEstimatedActualSavings oJunEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(6, iYear);
        PDEstimatedActualSavings oJulEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(7, iYear);
        PDEstimatedActualSavings oAugEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(8, iYear);
        PDEstimatedActualSavings oSepEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(9, iYear);
        PDEstimatedActualSavings oOctEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(10, iYear);
        PDEstimatedActualSavings oNovEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(11, iYear);
        PDEstimatedActualSavings oDecEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(12, iYear);

        JanE.Text = stringRoutine.formatAsNumber(oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO);
        FebE.Text = stringRoutine.formatAsNumber(oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO);
        MarE.Text = stringRoutine.formatAsNumber(oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO);
        AprE.Text = stringRoutine.formatAsNumber(oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO);
        MayE.Text = stringRoutine.formatAsNumber(oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO);
        JunE.Text = stringRoutine.formatAsNumber(oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO);
        JulE.Text = stringRoutine.formatAsNumber(oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO);
        AugE.Text = stringRoutine.formatAsNumber(oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO);
        SepE.Text = stringRoutine.formatAsNumber(oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO);
        OctE.Text = stringRoutine.formatAsNumber(oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO);
        NovE.Text = stringRoutine.formatAsNumber(oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO);
        DecE.Text = stringRoutine.formatAsNumber(oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO); 


        PDEstimatedActualSavings oJanAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(1, iYear);
        PDEstimatedActualSavings oFebAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(2, iYear);
        PDEstimatedActualSavings oMarAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(3, iYear);
        PDEstimatedActualSavings oAprAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(4, iYear);
        PDEstimatedActualSavings oMayAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(5, iYear);
        PDEstimatedActualSavings oJunAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(6, iYear);
        PDEstimatedActualSavings oJulAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(7, iYear);
        PDEstimatedActualSavings oAugAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(8, iYear);
        PDEstimatedActualSavings oSepAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(9, iYear);
        PDEstimatedActualSavings oOctAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(10, iYear);
        PDEstimatedActualSavings oNovAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(11, iYear);
        PDEstimatedActualSavings oDecAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(12, iYear);

        JanA.Text = stringRoutine.formatAsNumber(oJanAct.dDD + oJanAct.dDDO + oJanEst.dEIO);
        FebA.Text = stringRoutine.formatAsNumber(oFebAct.dDD + oFebAct.dDDO + oFebAct.dEIO);
        MarA.Text = stringRoutine.formatAsNumber(oMarAct.dDD + oMarAct.dDDO + oMarAct.dEIO);
        AprA.Text = stringRoutine.formatAsNumber(oAprAct.dDD + oAprAct.dDDO + oAprAct.dEIO);
        MayA.Text = stringRoutine.formatAsNumber(oMayAct.dDD + oMayAct.dDDO + oMayAct.dEIO);
        JunA.Text = stringRoutine.formatAsNumber(oJunAct.dDD + oJunAct.dDDO + oJunAct.dEIO);
        JulA.Text = stringRoutine.formatAsNumber(oJulAct.dDD + oJulAct.dDDO + oJulAct.dEIO);
        AugA.Text = stringRoutine.formatAsNumber(oAugAct.dDD + oAugAct.dDDO + oAugAct.dEIO);
        SepA.Text = stringRoutine.formatAsNumber(oSepAct.dDD + oSepAct.dDDO + oSepAct.dEIO);
        OctA.Text = stringRoutine.formatAsNumber(oOctAct.dDD + oOctAct.dDDO + oOctAct.dEIO);
        NovA.Text = stringRoutine.formatAsNumber(oNovAct.dDD + oNovAct.dDDO + oNovAct.dEIO);
        DecA.Text = stringRoutine.formatAsNumber(oDecAct.dDD + oDecAct.dDDO + oDecAct.dEIO);

        PDEstimatedActualSavings oJanLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(1, iYear);
        PDEstimatedActualSavings oFebLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(2, iYear);
        PDEstimatedActualSavings oMarLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(3, iYear);
        PDEstimatedActualSavings oAprLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(4, iYear);
        PDEstimatedActualSavings oMayLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(5, iYear);
        PDEstimatedActualSavings oJunLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(6, iYear);
        PDEstimatedActualSavings oJulLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(7, iYear);
        PDEstimatedActualSavings oAugLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(8, iYear);
        PDEstimatedActualSavings oSepLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(9, iYear);
        PDEstimatedActualSavings oOctLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(10, iYear);
        PDEstimatedActualSavings oNovLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(11, iYear);
        PDEstimatedActualSavings oDecLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(12, iYear);

        JanLE.Text = stringRoutine.formatAsNumber(oJanLE.dDD + oJanLE.dDDO + oJanEst.dEIO);
        FebLE.Text = stringRoutine.formatAsNumber(oFebLE.dDD + oFebLE.dDDO + oFebLE.dEIO);
        MarLE.Text = stringRoutine.formatAsNumber(oMarLE.dDD + oMarLE.dDDO + oMarLE.dEIO);
        AprLE.Text = stringRoutine.formatAsNumber(oAprLE.dDD + oAprLE.dDDO + oAprLE.dEIO);
        MayLE.Text = stringRoutine.formatAsNumber(oMayLE.dDD + oMayLE.dDDO + oMayLE.dEIO);
        JunLE.Text = stringRoutine.formatAsNumber(oJunLE.dDD + oJunLE.dDDO + oJunLE.dEIO);
        JulLE.Text = stringRoutine.formatAsNumber(oJulLE.dDD + oJulLE.dDDO + oJulLE.dEIO);
        AugLE.Text = stringRoutine.formatAsNumber(oAugLE.dDD + oAugLE.dDDO + oAugLE.dEIO);
        SepLE.Text = stringRoutine.formatAsNumber(oSepLE.dDD + oSepLE.dDDO + oSepLE.dEIO);
        OctLE.Text = stringRoutine.formatAsNumber(oOctLE.dDD + oOctLE.dDDO + oOctLE.dEIO);
        NovLE.Text = stringRoutine.formatAsNumber(oNovLE.dDD + oNovLE.dDDO + oNovLE.dEIO);
        DecLE.Text = stringRoutine.formatAsNumber(oDecLE.dDD + oDecLE.dDDO + oDecLE.dEIO);
    }


    public void Init_ControlCummulative(int iYear)
    {
        //PD Estimated Savings
        PDEstimatedActualSavings oJanEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(1, iYear);
        PDEstimatedActualSavings oFebEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(2, iYear);
        PDEstimatedActualSavings oMarEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(3, iYear);
        PDEstimatedActualSavings oAprEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(4, iYear);
        PDEstimatedActualSavings oMayEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(5, iYear);
        PDEstimatedActualSavings oJunEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(6, iYear);
        PDEstimatedActualSavings oJulEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(7, iYear);
        PDEstimatedActualSavings oAugEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(8, iYear);
        PDEstimatedActualSavings oSepEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(9, iYear);
        PDEstimatedActualSavings oOctEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(10, iYear);
        PDEstimatedActualSavings oNovEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(11, iYear);
        PDEstimatedActualSavings oDecEst = oPDCostReductionSummaryHelper.ObjGetEstimatedSavingByMonthYear(12, iYear);

        decimal dSumJan = oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO;
        decimal dSumFeb = oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO;
        decimal dSumMar = oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO;
        decimal dSumApr = oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO;
        decimal dSumMay = oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO;
        decimal dSumJun = oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO ;
        decimal dSumJul = oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO;
        decimal dSumAug = oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO;
        decimal dSumSep = oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO;
        decimal dSumOct = oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO;
        decimal dSumNov = oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO;
        decimal dSumDec = oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO;

        JanE.Text = stringRoutine.formatAsNumber(dSumJan);
        FebE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb);
        MarE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar);
        AprE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr);
        MayE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay);
        JunE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun);
        JulE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul);
        AugE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug);
        SepE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep);
        OctE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct);
        NovE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov);
        DecE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov + dSumDec);

        //PD Actual Savings
        PDEstimatedActualSavings oJanAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(1, iYear);
        PDEstimatedActualSavings oFebAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(2, iYear);
        PDEstimatedActualSavings oMarAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(3, iYear);
        PDEstimatedActualSavings oAprAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(4, iYear);
        PDEstimatedActualSavings oMayAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(5, iYear);
        PDEstimatedActualSavings oJunAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(6, iYear);
        PDEstimatedActualSavings oJulAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(7, iYear);
        PDEstimatedActualSavings oAugAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(8, iYear);
        PDEstimatedActualSavings oSepAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(9, iYear);
        PDEstimatedActualSavings oOctAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(10, iYear);
        PDEstimatedActualSavings oNovAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(11, iYear);
        PDEstimatedActualSavings oDecAct = oPDCostReductionSummaryHelper.ObjGetActualSavingByMonthYear(12, iYear);

        //Re Initialise Variables
        dSumJan = 0; dSumFeb = 0; dSumMar = 0; dSumApr = 0; dSumMay = 0; dSumJun = 0; dSumJul = 0; dSumAug = 0; dSumSep = 0; dSumOct = 0; dSumNov = 0; dSumDec = 0;
        
        dSumJan = oJanAct.dDD + oJanAct.dDDO + oJanAct.dEIO;
        dSumFeb = oFebAct.dDD + oFebAct.dDDO + oFebAct.dEIO;
        dSumMar = oMarAct.dDD + oMarAct.dDDO + oMarAct.dEIO;
        dSumApr = oAprAct.dDD + oAprAct.dDDO + oAprAct.dEIO;
        dSumMay = oMayAct.dDD + oMayAct.dDDO + oMayAct.dEIO;
        dSumJun = oJunAct.dDD + oJunAct.dDDO + oJunAct.dEIO;
        dSumJul = oJulAct.dDD + oJulAct.dDDO + oJulAct.dEIO;
        dSumAug = oAugAct.dDD + oAugAct.dDDO + oAugAct.dEIO;
        dSumSep = oSepAct.dDD + oSepAct.dDDO + oSepAct.dEIO;
        dSumOct = oOctAct.dDD + oOctAct.dDDO + oOctAct.dEIO;
        dSumNov = oNovAct.dDD + oNovAct.dDDO + oNovAct.dEIO;
        dSumDec = oDecAct.dDD + oDecAct.dDDO + oDecAct.dEIO;

        JanA.Text = stringRoutine.formatAsNumber(dSumJan);
        FebA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb);
        MarA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar);
        AprA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr);
        MayA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay);
        JunA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun);
        JulA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul);
        AugA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug);
        SepA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep);
        OctA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct);
        NovA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov);
        DecA.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov + dSumDec);



        //PD Latest Estimate
        PDEstimatedActualSavings oJanLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(1, iYear);
        PDEstimatedActualSavings oFebLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(2, iYear);
        PDEstimatedActualSavings oMarLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(3, iYear);
        PDEstimatedActualSavings oAprLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(4, iYear);
        PDEstimatedActualSavings oMayLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(5, iYear);
        PDEstimatedActualSavings oJunLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(6, iYear);
        PDEstimatedActualSavings oJulLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(7, iYear);
        PDEstimatedActualSavings oAugLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(8, iYear);
        PDEstimatedActualSavings oSepLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(9, iYear);
        PDEstimatedActualSavings oOctLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(10, iYear);
        PDEstimatedActualSavings oNovLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(11, iYear);
        PDEstimatedActualSavings oDecLE = oPDCostReductionSummaryHelper.ObjGetLESavingByMonthYear(12, iYear);

        //Re Initialise Variables
        dSumJan = 0; dSumFeb = 0; dSumMar = 0; dSumApr = 0; dSumMay = 0; dSumJun = 0; dSumJul = 0; dSumAug = 0; dSumSep = 0; dSumOct = 0; dSumNov = 0; dSumDec = 0;

        dSumJan = oJanLE.dDD + oJanLE.dDDO + oJanLE.dEIO;
        dSumFeb = oFebLE.dDD + oFebLE.dDDO + oFebLE.dEIO;
        dSumMar = oMarLE.dDD + oMarLE.dDDO + oMarLE.dEIO;
        dSumApr = oAprLE.dDD + oAprLE.dDDO + oAprLE.dEIO;
        dSumMay = oMayLE.dDD + oMayLE.dDDO + oMayLE.dEIO;
        dSumJun = oJunLE.dDD + oJunLE.dDDO + oJunLE.dEIO;
        dSumJul = oJulLE.dDD + oJulLE.dDDO + oJulLE.dEIO;
        dSumAug = oAugLE.dDD + oAugLE.dDDO + oAugLE.dEIO;
        dSumSep = oSepLE.dDD + oSepLE.dDDO + oSepLE.dEIO;
        dSumOct = oOctLE.dDD + oOctLE.dDDO + oOctLE.dEIO;
        dSumNov = oNovLE.dDD + oNovLE.dDDO + oNovLE.dEIO;
        dSumDec = oDecLE.dDD + oDecLE.dDDO + oDecLE.dEIO;

        JanLE.Text = stringRoutine.formatAsNumber(dSumJan);
        FebLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb);
        MarLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar);
        AprLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr);
        MayLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay);
        JunLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun);
        JulLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul);
        AugLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug);
        SepLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep);
        OctLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct);
        NovLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov);
        DecLE.Text = stringRoutine.formatAsNumber(dSumJan + dSumFeb + dSumMar + dSumApr + dSumMay + dSumJun + dSumJul + dSumAug + dSumSep + dSumOct + dSumNov + dSumDec);

    }
}