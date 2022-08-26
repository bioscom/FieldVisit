using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_UserControl_PDSavingsViewer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Init_ControlEstimatedSavings(int iYear)
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();

        grdView.DataSource = AssetPdcc.dtGetAssets();
        grdView.DataBind();
        
        foreach(GridViewRow grdRow in grdView.Rows)
        {
            Label lbJan = (Label)grdRow.FindControl("lbJan");
            Label lbFeb = (Label)grdRow.FindControl("lbFeb");
            Label lbMar = (Label)grdRow.FindControl("lbMar");
            Label lbApr = (Label)grdRow.FindControl("lbApr");
            Label lbMay = (Label)grdRow.FindControl("lbMay");
            Label lbJun = (Label)grdRow.FindControl("lbJun");
            Label lbJul = (Label)grdRow.FindControl("lbJul");
            Label lbAug = (Label)grdRow.FindControl("lbAug");
            Label lbSep = (Label)grdRow.FindControl("lbSep");
            Label lbOct = (Label)grdRow.FindControl("lbOct");
            Label lbNov = (Label)grdRow.FindControl("lbNov");
            Label lbDec = (Label)grdRow.FindControl("lbDec");

            Label lbAsset = (Label)grdRow.FindControl("lbAsset");
            int iAssetId = int.Parse(lbAsset.Attributes["ASSETID"].ToString());

            PDEstimatedSavings oJan = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jan, iYear);
            lbJan.Text = ((oJan.dDD + oJan.dDDO + oJan.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJan.dDD + oJan.dDDO + oJan.dEIO);

            PDEstimatedSavings oFeb = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.feb, iYear);
            lbFeb.Text = ((oFeb.dDD + oFeb.dDDO + oFeb.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oFeb.dDD + oFeb.dDDO + oFeb.dEIO);

            PDEstimatedSavings oMar = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.mar, iYear);
            lbMar.Text = ((oMar.dDD + oMar.dDDO + oMar.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oMar.dDD + oMar.dDDO + oMar.dEIO);

            PDEstimatedSavings oApr = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.apr, iYear);
            lbApr.Text = ((oApr.dDD + oApr.dDDO + oApr.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oApr.dDD + oApr.dDDO + oApr.dEIO);

            PDEstimatedSavings oMay = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.may, iYear);
            lbMay.Text = ((oMay.dDD + oMay.dDDO + oMay.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oMay.dDD + oMay.dDDO + oMay.dEIO);

            PDEstimatedSavings oJun = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jun, iYear);
            lbJun.Text = ((oJun.dDD + oJun.dDDO + oJun.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJun.dDD + oJun.dDDO + oJun.dEIO);

            PDEstimatedSavings oJul = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jul, iYear);
            lbJul.Text = ((oJul.dDD + oJul.dDDO + oJul.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJul.dDD + oJul.dDDO + oJul.dEIO);

            PDEstimatedSavings oAug = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.aug, iYear);
            lbAug.Text = ((oAug.dDD + oAug.dDDO + oAug.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oAug.dDD + oAug.dDDO + oAug.dEIO);

            PDEstimatedSavings oSep = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.sep, iYear);
            lbSep.Text = ((oSep.dDD + oSep.dDDO + oSep.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oSep.dDD + oSep.dDDO + oSep.dEIO);

            PDEstimatedSavings oOct = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.oct, iYear);
            lbOct.Text = ((oOct.dDD + oOct.dDDO + oOct.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oOct.dDD + oOct.dDDO + oOct.dEIO);

            PDEstimatedSavings oNov = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.nov, iYear);
            lbNov.Text = ((oNov.dDD + oNov.dDDO + oNov.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oNov.dDD + oNov.dDDO + oNov.dEIO);

            PDEstimatedSavings oDec = oPDCostReductionSummaryHelper.ObjGetAssetEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.dec, iYear);
            lbDec.Text = ((oDec.dDD + oDec.dDDO + oDec.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oDec.dDD + oDec.dDDO + oDec.dEIO);


        }

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


        grdView.FooterRow.Cells[0].Text = "PD Est. Savings(Mln$)"; grdView.FooterRow.Cells[0].Font.Bold = true;
        grdView.FooterStyle.BackColor = System.Drawing.Color.SkyBlue;

        grdView.FooterStyle.Font.Size = FontUnit.Point(9);

        grdView.FooterRow.Cells[1].Text = stringRoutine.formatAsNumber(oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO); //grdView.FooterRow.Cells[1].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[2].Text = stringRoutine.formatAsNumber(oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO); //grdView.FooterRow.Cells[2].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[3].Text = stringRoutine.formatAsNumber(oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO); //grdView.FooterRow.Cells[3].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[4].Text = stringRoutine.formatAsNumber(oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO); //grdView.FooterRow.Cells[4].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[5].Text = stringRoutine.formatAsNumber(oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO); //grdView.FooterRow.Cells[5].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[6].Text = stringRoutine.formatAsNumber(oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO); //grdView.FooterRow.Cells[6].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[7].Text = stringRoutine.formatAsNumber(oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO); //grdView.FooterRow.Cells[7].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[8].Text = stringRoutine.formatAsNumber(oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO); //grdView.FooterRow.Cells[8].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[9].Text = stringRoutine.formatAsNumber(oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO); //grdView.FooterRow.Cells[9].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[10].Text = stringRoutine.formatAsNumber(oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO); //grdView.FooterRow.Cells[10].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[11].Text = stringRoutine.formatAsNumber(oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO); //grdView.FooterRow.Cells[11].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[12].Text = stringRoutine.formatAsNumber(oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO); //grdView.FooterRow.Cells[12].BackColor = System.Drawing.Color.SkyBlue;
    }

    public void Init_ControlActualSavings(int iYear)
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();

        grdView.DataSource = AssetPdcc.dtGetAssets();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbJan = (Label)grdRow.FindControl("lbJan");
            Label lbFeb = (Label)grdRow.FindControl("lbFeb");
            Label lbMar = (Label)grdRow.FindControl("lbMar");
            Label lbApr = (Label)grdRow.FindControl("lbApr");
            Label lbMay = (Label)grdRow.FindControl("lbMay");
            Label lbJun = (Label)grdRow.FindControl("lbJun");
            Label lbJul = (Label)grdRow.FindControl("lbJul");
            Label lbAug = (Label)grdRow.FindControl("lbAug");
            Label lbSep = (Label)grdRow.FindControl("lbSep");
            Label lbOct = (Label)grdRow.FindControl("lbOct");
            Label lbNov = (Label)grdRow.FindControl("lbNov");
            Label lbDec = (Label)grdRow.FindControl("lbDec");

            Label lbAsset = (Label)grdRow.FindControl("lbAsset");
            int iAssetId = int.Parse(lbAsset.Attributes["ASSETID"].ToString());

            PDActualSavings oJan = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jan, iYear);
            lbJan.Text = ((oJan.dDD + oJan.dDDO + oJan.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJan.dDD + oJan.dDDO + oJan.dEIO);

            PDActualSavings oFeb = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.feb, iYear);
            lbFeb.Text = ((oFeb.dDD + oFeb.dDDO + oFeb.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oFeb.dDD + oFeb.dDDO + oFeb.dEIO);

            PDActualSavings oMar = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.mar, iYear);
            lbMar.Text = ((oMar.dDD + oMar.dDDO + oMar.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oMar.dDD + oMar.dDDO + oMar.dEIO);

            PDActualSavings oApr = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.apr, iYear);
            lbApr.Text = ((oApr.dDD + oApr.dDDO + oApr.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oApr.dDD + oApr.dDDO + oApr.dEIO);

            PDActualSavings oMay = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.may, iYear);
            lbMay.Text = ((oMay.dDD + oMay.dDDO + oMay.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oMay.dDD + oMay.dDDO + oMay.dEIO);

            PDActualSavings oJun = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jun, iYear);
            lbJun.Text = ((oJun.dDD + oJun.dDDO + oJun.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJun.dDD + oJun.dDDO + oJun.dEIO);

            PDActualSavings oJul = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jul, iYear);
            lbJul.Text = ((oJul.dDD + oJul.dDDO + oJul.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJul.dDD + oJul.dDDO + oJul.dEIO);

            PDActualSavings oAug = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.aug, iYear);
            lbAug.Text = ((oAug.dDD + oAug.dDDO + oAug.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oAug.dDD + oAug.dDDO + oAug.dEIO);

            PDActualSavings oSep = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.sep, iYear);
            lbSep.Text = ((oSep.dDD + oSep.dDDO + oSep.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oSep.dDD + oSep.dDDO + oSep.dEIO);

            PDActualSavings oOct = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.oct, iYear);
            lbOct.Text = ((oOct.dDD + oOct.dDDO + oOct.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oOct.dDD + oOct.dDDO + oOct.dEIO);

            PDActualSavings oNov = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.nov, iYear);
            lbNov.Text = ((oNov.dDD + oNov.dDDO + oNov.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oNov.dDD + oNov.dDDO + oNov.dEIO);

            PDActualSavings oDec = oPDCostReductionSummaryHelper.ObjGetAssetActualSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.dec, iYear);
            lbDec.Text = ((oDec.dDD + oDec.dDDO + oDec.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oDec.dDD + oDec.dDDO + oDec.dEIO);
        }

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


        grdView.FooterRow.Cells[0].Text = "PD Actual Savings(Mln$)"; grdView.FooterRow.Cells[0].Font.Bold = true;
        grdView.FooterStyle.BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterStyle.Font.Size = FontUnit.Point(9);

        grdView.FooterRow.Cells[1].Text = stringRoutine.formatAsNumber(oJanAct.dDD + oJanAct.dDDO + oJanAct.dEIO); //grdView.FooterRow.Cells[1].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[2].Text = stringRoutine.formatAsNumber(oFebAct.dDD + oFebAct.dDDO + oFebAct.dEIO); //grdView.FooterRow.Cells[2].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[3].Text = stringRoutine.formatAsNumber(oMarAct.dDD + oMarAct.dDDO + oMarAct.dEIO); //grdView.FooterRow.Cells[3].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[4].Text = stringRoutine.formatAsNumber(oAprAct.dDD + oAprAct.dDDO + oAprAct.dEIO); //grdView.FooterRow.Cells[4].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[5].Text = stringRoutine.formatAsNumber(oMayAct.dDD + oMayAct.dDDO + oMayAct.dEIO); //grdView.FooterRow.Cells[5].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[6].Text = stringRoutine.formatAsNumber(oJunAct.dDD + oJunAct.dDDO + oJunAct.dEIO); //grdView.FooterRow.Cells[6].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[7].Text = stringRoutine.formatAsNumber(oJulAct.dDD + oJulAct.dDDO + oJulAct.dEIO); //grdView.FooterRow.Cells[7].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[8].Text = stringRoutine.formatAsNumber(oAugAct.dDD + oAugAct.dDDO + oAugAct.dEIO); //grdView.FooterRow.Cells[8].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[9].Text = stringRoutine.formatAsNumber(oSepAct.dDD + oSepAct.dDDO + oSepAct.dEIO); //grdView.FooterRow.Cells[9].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[10].Text = stringRoutine.formatAsNumber(oOctAct.dDD + oOctAct.dDDO + oOctAct.dEIO); //grdView.FooterRow.Cells[10].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[11].Text = stringRoutine.formatAsNumber(oNovAct.dDD + oNovAct.dDDO + oNovAct.dEIO); //grdView.FooterRow.Cells[11].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[12].Text = stringRoutine.formatAsNumber(oDecAct.dDD + oDecAct.dDDO + oDecAct.dEIO); //grdView.FooterRow.Cells[12].BackColor = System.Drawing.Color.SkyBlue;

    }

    public void Init_ControlLESavings(int iYear)
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();

        grdView.DataSource = AssetPdcc.dtGetAssets();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbJan = (Label)grdRow.FindControl("lbJan");
            Label lbFeb = (Label)grdRow.FindControl("lbFeb");
            Label lbMar = (Label)grdRow.FindControl("lbMar");
            Label lbApr = (Label)grdRow.FindControl("lbApr");
            Label lbMay = (Label)grdRow.FindControl("lbMay");
            Label lbJun = (Label)grdRow.FindControl("lbJun");
            Label lbJul = (Label)grdRow.FindControl("lbJul");
            Label lbAug = (Label)grdRow.FindControl("lbAug");
            Label lbSep = (Label)grdRow.FindControl("lbSep");
            Label lbOct = (Label)grdRow.FindControl("lbOct");
            Label lbNov = (Label)grdRow.FindControl("lbNov");
            Label lbDec = (Label)grdRow.FindControl("lbDec");

            Label lbAsset = (Label)grdRow.FindControl("lbAsset");
            int iAssetId = int.Parse(lbAsset.Attributes["ASSETID"].ToString());

            PDLESavings oJan = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jan, iYear);
            lbJan.Text = ((oJan.dDD + oJan.dDDO + oJan.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJan.dDD + oJan.dDDO + oJan.dEIO);

            PDLESavings oFeb = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.feb, iYear);
            lbFeb.Text = ((oFeb.dDD + oFeb.dDDO + oFeb.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oFeb.dDD + oFeb.dDDO + oFeb.dEIO);

            PDLESavings oMar = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.mar, iYear);
            lbMar.Text = ((oMar.dDD + oMar.dDDO + oMar.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oMar.dDD + oMar.dDDO + oMar.dEIO);

            PDLESavings oApr = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.apr, iYear);
            lbApr.Text = ((oApr.dDD + oApr.dDDO + oApr.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oApr.dDD + oApr.dDDO + oApr.dEIO);

            PDLESavings oMay = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.may, iYear);
            lbMay.Text = ((oMay.dDD + oMay.dDDO + oMay.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oMay.dDD + oMay.dDDO + oMay.dEIO);

            PDLESavings oJun = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jun, iYear);
            lbJun.Text = ((oJun.dDD + oJun.dDDO + oJun.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJun.dDD + oJun.dDDO + oJun.dEIO);

            PDLESavings oJul = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jul, iYear);
            lbJul.Text = ((oJul.dDD + oJul.dDDO + oJul.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oJul.dDD + oJul.dDDO + oJul.dEIO);

            PDLESavings oAug = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.aug, iYear);
            lbAug.Text = ((oAug.dDD + oAug.dDDO + oAug.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oAug.dDD + oAug.dDDO + oAug.dEIO);

            PDLESavings oSep = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.sep, iYear);
            lbSep.Text = ((oSep.dDD + oSep.dDDO + oSep.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oSep.dDD + oSep.dDDO + oSep.dEIO);

            PDLESavings oOct = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.oct, iYear);
            lbOct.Text = ((oOct.dDD + oOct.dDDO + oOct.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oOct.dDD + oOct.dDDO + oOct.dEIO);

            PDLESavings oNov = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.nov, iYear);
            lbNov.Text = ((oNov.dDD + oNov.dDDO + oNov.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oNov.dDD + oNov.dDDO + oNov.dEIO);

            PDLESavings oDec = oPDCostReductionSummaryHelper.ObjGetAssetLESavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.dec, iYear);
            lbDec.Text = ((oDec.dDD + oDec.dDDO + oDec.dEIO) == 0) ? "" : stringRoutine.formatAsNumber(oDec.dDD + oDec.dDDO + oDec.dEIO);
        }

        //PD LE Savings
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


        grdView.FooterRow.Cells[0].Text = "PD Latest Estimate(Mln$)"; grdView.FooterRow.Cells[0].Font.Bold = true;
        grdView.FooterStyle.BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterStyle.Font.Size = FontUnit.Point(9);

        grdView.FooterRow.Cells[1].Text = stringRoutine.formatAsNumber(oJanLE.dDD + oJanLE.dDDO + oJanLE.dEIO); //grdView.FooterRow.Cells[1].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[2].Text = stringRoutine.formatAsNumber(oFebLE.dDD + oFebLE.dDDO + oFebLE.dEIO); //grdView.FooterRow.Cells[2].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[3].Text = stringRoutine.formatAsNumber(oMarLE.dDD + oMarLE.dDDO + oMarLE.dEIO); //grdView.FooterRow.Cells[3].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[4].Text = stringRoutine.formatAsNumber(oAprLE.dDD + oAprLE.dDDO + oAprLE.dEIO); //grdView.FooterRow.Cells[4].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[5].Text = stringRoutine.formatAsNumber(oMayLE.dDD + oMayLE.dDDO + oMayLE.dEIO); //grdView.FooterRow.Cells[5].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[6].Text = stringRoutine.formatAsNumber(oJunLE.dDD + oJunLE.dDDO + oJunLE.dEIO); //grdView.FooterRow.Cells[6].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[7].Text = stringRoutine.formatAsNumber(oJulLE.dDD + oJulLE.dDDO + oJulLE.dEIO); //grdView.FooterRow.Cells[7].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[8].Text = stringRoutine.formatAsNumber(oAugLE.dDD + oAugLE.dDDO + oAugLE.dEIO); //grdView.FooterRow.Cells[8].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[9].Text = stringRoutine.formatAsNumber(oSepLE.dDD + oSepLE.dDDO + oSepLE.dEIO); //grdView.FooterRow.Cells[9].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[10].Text = stringRoutine.formatAsNumber(oOctLE.dDD + oOctLE.dDDO + oOctLE.dEIO); //grdView.FooterRow.Cells[10].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[11].Text = stringRoutine.formatAsNumber(oNovLE.dDD + oNovLE.dDDO + oNovLE.dEIO); //grdView.FooterRow.Cells[11].BackColor = System.Drawing.Color.SkyBlue;
        grdView.FooterRow.Cells[12].Text = stringRoutine.formatAsNumber(oDecLE.dDD + oDecLE.dDDO + oDecLE.dEIO); //grdView.FooterRow.Cells[12].BackColor = System.Drawing.Color.SkyBlue;

    }


}