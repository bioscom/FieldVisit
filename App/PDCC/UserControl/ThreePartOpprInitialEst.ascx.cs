using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_UserControl_ThreePartOpprInitialEst : aspnetUserControl
{
    PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
    TransactionYear oTrans = new TransactionYear();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_ControlInitialEstimatedSavings(int iYear)
    {

        grdView.DataSource = AssetPdcc.dtGetAssets();
        grdView.DataBind();

        try
        {
            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lbJanDD = (Label)grdRow.FindControl("lbJanDD");
                Label lbFebDD = (Label)grdRow.FindControl("lbFebDD");
                Label lbMarDD = (Label)grdRow.FindControl("lbMarDD");
                Label lbAprDD = (Label)grdRow.FindControl("lbAprDD");
                Label lbMayDD = (Label)grdRow.FindControl("lbMayDD");
                Label lbJunDD = (Label)grdRow.FindControl("lbJunDD");
                Label lbJulDD = (Label)grdRow.FindControl("lbJulDD");
                Label lbAugDD = (Label)grdRow.FindControl("lbAugDD");
                Label lbSepDD = (Label)grdRow.FindControl("lbSepDD");
                Label lbOctDD = (Label)grdRow.FindControl("lbOctDD");
                Label lbNovDD = (Label)grdRow.FindControl("lbNovDD");
                Label lbDecDD = (Label)grdRow.FindControl("lbDecDD");

                TextBox txtJanDD = (TextBox)grdRow.FindControl("txtJanDD");
                TextBox txtFebDD = (TextBox)grdRow.FindControl("txtFebDD");
                TextBox txtMarDD = (TextBox)grdRow.FindControl("txtMarDD");
                TextBox txtAprDD = (TextBox)grdRow.FindControl("txtAprDD");
                TextBox txtMayDD = (TextBox)grdRow.FindControl("txtMayDD");
                TextBox txtJunDD = (TextBox)grdRow.FindControl("txtJunDD");
                TextBox txtJulDD = (TextBox)grdRow.FindControl("txtJulDD");
                TextBox txtAugDD = (TextBox)grdRow.FindControl("txtAugDD");
                TextBox txtSepDD = (TextBox)grdRow.FindControl("txtSepDD");
                TextBox txtOctDD = (TextBox)grdRow.FindControl("txtOctDD");
                TextBox txtNovDD = (TextBox)grdRow.FindControl("txtNovDD");
                TextBox txtDecDD = (TextBox)grdRow.FindControl("txtDecDD");

                Label lbJanDDO = (Label)grdRow.FindControl("lbJanDDO");
                Label lbFebDDO = (Label)grdRow.FindControl("lbFebDDO");
                Label lbMarDDO = (Label)grdRow.FindControl("lbMarDDO");
                Label lbAprDDO = (Label)grdRow.FindControl("lbAprDDO");
                Label lbMayDDO = (Label)grdRow.FindControl("lbMayDDO");
                Label lbJunDDO = (Label)grdRow.FindControl("lbJunDDO");
                Label lbJulDDO = (Label)grdRow.FindControl("lbJulDDO");
                Label lbAugDDO = (Label)grdRow.FindControl("lbAugDDO");
                Label lbSepDDO = (Label)grdRow.FindControl("lbSepDDO");
                Label lbOctDDO = (Label)grdRow.FindControl("lbOctDDO");
                Label lbNovDDO = (Label)grdRow.FindControl("lbNovDDO");
                Label lbDecDDO = (Label)grdRow.FindControl("lbDecDDO");

                TextBox txtJanDDO = (TextBox)grdRow.FindControl("txtJanDDO");
                TextBox txtFebDDO = (TextBox)grdRow.FindControl("txtFebDDO");
                TextBox txtMarDDO = (TextBox)grdRow.FindControl("txtMarDDO");
                TextBox txtAprDDO = (TextBox)grdRow.FindControl("txtAprDDO");
                TextBox txtMayDDO = (TextBox)grdRow.FindControl("txtMayDDO");
                TextBox txtJunDDO = (TextBox)grdRow.FindControl("txtJunDDO");
                TextBox txtJulDDO = (TextBox)grdRow.FindControl("txtJulDDO");
                TextBox txtAugDDO = (TextBox)grdRow.FindControl("txtAugDDO");
                TextBox txtSepDDO = (TextBox)grdRow.FindControl("txtSepDDO");
                TextBox txtOctDDO = (TextBox)grdRow.FindControl("txtOctDDO");
                TextBox txtNovDDO = (TextBox)grdRow.FindControl("txtNovDDO");
                TextBox txtDecDDO = (TextBox)grdRow.FindControl("txtDecDDO");

                Label lbJanEIO = (Label)grdRow.FindControl("lbJanEIO");
                Label lbFebEIO = (Label)grdRow.FindControl("lbFebEIO");
                Label lbMarEIO = (Label)grdRow.FindControl("lbMarEIO");
                Label lbAprEIO = (Label)grdRow.FindControl("lbAprEIO");
                Label lbMayEIO = (Label)grdRow.FindControl("lbMayEIO");
                Label lbJunEIO = (Label)grdRow.FindControl("lbJunEIO");
                Label lbJulEIO = (Label)grdRow.FindControl("lbJulEIO");
                Label lbAugEIO = (Label)grdRow.FindControl("lbAugEIO");
                Label lbSepEIO = (Label)grdRow.FindControl("lbSepEIO");
                Label lbOctEIO = (Label)grdRow.FindControl("lbOctEIO");
                Label lbNovEIO = (Label)grdRow.FindControl("lbNovEIO");
                Label lbDecEIO = (Label)grdRow.FindControl("lbDecEIO");

                TextBox txtJanEIO = (TextBox)grdRow.FindControl("txtJanEIO");
                TextBox txtFebEIO = (TextBox)grdRow.FindControl("txtFebEIO");
                TextBox txtMarEIO = (TextBox)grdRow.FindControl("txtMarEIO");
                TextBox txtAprEIO = (TextBox)grdRow.FindControl("txtAprEIO");
                TextBox txtMayEIO = (TextBox)grdRow.FindControl("txtMayEIO");
                TextBox txtJunEIO = (TextBox)grdRow.FindControl("txtJunEIO");
                TextBox txtJulEIO = (TextBox)grdRow.FindControl("txtJulEIO");
                TextBox txtAugEIO = (TextBox)grdRow.FindControl("txtAugEIO");
                TextBox txtSepEIO = (TextBox)grdRow.FindControl("txtSepEIO");
                TextBox txtOctEIO = (TextBox)grdRow.FindControl("txtOctEIO");
                TextBox txtNovEIO = (TextBox)grdRow.FindControl("txtNovEIO");
                TextBox txtDecEIO = (TextBox)grdRow.FindControl("txtDecEIO");

                Label lbAsset = (Label)grdRow.FindControl("lbAsset");
                int iAssetId = int.Parse(lbAsset.Attributes["ASSETID"].ToString());

                PDInitialEstimatedSavings oJan = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jan, iYear);
                PDInitialEstimatedSavings oFeb = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.feb, iYear);
                PDInitialEstimatedSavings oMar = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.mar, iYear);
                PDInitialEstimatedSavings oApr = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.apr, iYear);
                PDInitialEstimatedSavings oMay = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.may, iYear);
                PDInitialEstimatedSavings oJun = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jun, iYear);
                PDInitialEstimatedSavings oJul = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.jul, iYear);
                PDInitialEstimatedSavings oAug = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.aug, iYear);
                PDInitialEstimatedSavings oSep = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.sep, iYear);
                PDInitialEstimatedSavings oOct = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.oct, iYear);
                PDInitialEstimatedSavings oNov = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.nov, iYear);
                PDInitialEstimatedSavings oDec = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAssetId, (int)mMonthEnuem.mMonth.dec, iYear);

                if (lbJanDD == null)
                {
                    txtJanDD.Text = (oJan.dDD == 0) ? "" : oJan.dDD.ToString();
                    txtJanDDO.Text = (oJan.dDDO == 0) ? "" : oJan.dDDO.ToString();
                    txtJanEIO.Text = (oJan.dEIO == 0) ? "" : oJan.dEIO.ToString();

                    txtFebDD.Text = (oFeb.dDD == 0) ? "" : oFeb.dDD.ToString();
                    txtFebDDO.Text = (oFeb.dDDO == 0) ? "" : oFeb.dDDO.ToString();
                    txtFebEIO.Text = (oFeb.dEIO == 0) ? "" : oFeb.dEIO.ToString();

                    txtMarDD.Text = (oMar.dDD == 0) ? "" : oMar.dDD.ToString();
                    txtMarDDO.Text = (oMar.dDDO == 0) ? "" : oMar.dDDO.ToString();
                    txtMarEIO.Text = (oMar.dEIO == 0) ? "" : oMar.dEIO.ToString();

                    txtAprDD.Text = (oApr.dDD == 0) ? "" : oApr.dDD.ToString();
                    txtAprDDO.Text = (oApr.dDDO == 0) ? "" : oApr.dDDO.ToString();
                    txtAprEIO.Text = (oApr.dEIO == 0) ? "" : oApr.dEIO.ToString();

                    txtMayDD.Text = (oMay.dDD == 0) ? "" : oMay.dDD.ToString();
                    txtMayDDO.Text = (oMay.dDDO == 0) ? "" : oMay.dDDO.ToString();
                    txtMayEIO.Text = (oMay.dEIO == 0) ? "" : oMay.dEIO.ToString();

                    txtJunDD.Text = (oJun.dDD == 0) ? "" : oJun.dDD.ToString();
                    txtJunDDO.Text = (oJun.dDDO == 0) ? "" : oJun.dDDO.ToString();
                    txtJunEIO.Text = (oJun.dEIO == 0) ? "" : oJun.dEIO.ToString();

                    txtJulDD.Text = (oJul.dDD == 0) ? "" : oJul.dDD.ToString();
                    txtJulDDO.Text = (oJul.dDDO == 0) ? "" : oJul.dDDO.ToString();
                    txtJulEIO.Text = (oJul.dEIO == 0) ? "" : oJul.dEIO.ToString();

                    txtAugDD.Text = (oAug.dDD == 0) ? "" : oAug.dDD.ToString();
                    txtAugDDO.Text = (oAug.dDDO == 0) ? "" : oAug.dDDO.ToString();
                    txtAugEIO.Text = (oAug.dEIO == 0) ? "" : oAug.dEIO.ToString();

                    txtSepDD.Text = (oSep.dDD == 0) ? "" : oSep.dDD.ToString();
                    txtSepDDO.Text = (oSep.dDDO == 0) ? "" : oSep.dDDO.ToString();
                    txtSepEIO.Text = (oSep.dEIO == 0) ? "" : oSep.dEIO.ToString();

                    txtOctDD.Text = (oOct.dDD == 0) ? "" : oOct.dDD.ToString();
                    txtOctDDO.Text = (oOct.dDDO == 0) ? "" : oOct.dDDO.ToString();
                    txtOctEIO.Text = (oOct.dEIO == 0) ? "" : oOct.dEIO.ToString();

                    txtNovDD.Text = (oNov.dDD == 0) ? "" : oNov.dDD.ToString();
                    txtNovDDO.Text = (oNov.dDDO == 0) ? "" : oNov.dDDO.ToString();
                    txtNovEIO.Text = (oNov.dEIO == 0) ? "" : oNov.dEIO.ToString();

                    txtDecDD.Text = (oDec.dDD == 0) ? "" : oDec.dDD.ToString();
                    txtDecDDO.Text = (oDec.dDDO == 0) ? "" : oDec.dDDO.ToString();
                    txtDecEIO.Text = (oDec.dEIO == 0) ? "" : oDec.dEIO.ToString();
                }
                else
                {
                    lbJanDD.Text = (oJan.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oJan.dDD);
                    lbJanDDO.Text = (oJan.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oJan.dDDO);
                    lbJanEIO.Text = (oJan.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oJan.dEIO);

                    lbFebDD.Text = (oFeb.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oFeb.dDD);
                    lbFebDDO.Text = (oFeb.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oFeb.dDDO);
                    lbFebEIO.Text = (oFeb.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oFeb.dEIO);

                    lbMarDD.Text = (oMar.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oMar.dDD);
                    lbMarDDO.Text = (oMar.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oMar.dDDO);
                    lbMarEIO.Text = (oMar.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oMar.dEIO);

                    lbAprDD.Text = (oApr.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oApr.dDD);
                    lbAprDDO.Text = (oApr.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oApr.dDDO);
                    lbAprEIO.Text = (oApr.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oApr.dEIO);

                    lbMayDD.Text = (oMay.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oMay.dDD);
                    lbMayDDO.Text = (oMay.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oMay.dDDO);
                    lbMayEIO.Text = (oMay.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oMay.dEIO);

                    lbJunDD.Text = (oJun.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oJun.dDD);
                    lbJunDDO.Text = (oJun.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oJun.dDDO);
                    lbJunEIO.Text = (oJun.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oJun.dEIO);

                    lbJulDD.Text = (oJul.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oJul.dDD);
                    lbJulDDO.Text = (oJul.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oJul.dDDO);
                    lbJulEIO.Text = (oJul.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oJul.dEIO);

                    lbAugDD.Text = (oAug.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oAug.dDD);
                    lbAugDDO.Text = (oAug.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oAug.dDDO);
                    lbAugEIO.Text = (oAug.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oAug.dEIO);

                    lbSepDD.Text = (oSep.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oSep.dDD);
                    lbSepDDO.Text = (oSep.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oSep.dDDO);
                    lbSepEIO.Text = (oSep.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oSep.dEIO);

                    lbOctDD.Text = (oOct.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oOct.dDD);
                    lbOctDDO.Text = (oOct.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oOct.dDDO);
                    lbOctEIO.Text = (oOct.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oOct.dEIO);

                    lbNovDD.Text = (oNov.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oNov.dDD);
                    lbNovDDO.Text = (oNov.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oNov.dDDO);
                    lbNovEIO.Text = (oNov.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oNov.dEIO);

                    lbDecDD.Text = (oDec.dDD == 0) ? "" : stringRoutine.formatAsBankMoney(oDec.dDD);
                    lbDecDDO.Text = (oDec.dDDO == 0) ? "" : stringRoutine.formatAsBankMoney(oDec.dDDO);
                    lbDecEIO.Text = (oDec.dEIO == 0) ? "" : stringRoutine.formatAsBankMoney(oDec.dEIO);
                }
            }

            //TODO: the lines belo need change
            PDEstimatedActualSavings oJanEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jan, iYear);
            PDEstimatedActualSavings oFebEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.feb, iYear);
            PDEstimatedActualSavings oMarEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.mar, iYear);
            PDEstimatedActualSavings oAprEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.apr, iYear);
            PDEstimatedActualSavings oMayEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.may, iYear);
            PDEstimatedActualSavings oJunEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jun, iYear);
            PDEstimatedActualSavings oJulEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.jul, iYear);
            PDEstimatedActualSavings oAugEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.aug, iYear);
            PDEstimatedActualSavings oSepEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.sep, iYear);
            PDEstimatedActualSavings oOctEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.oct, iYear);
            PDEstimatedActualSavings oNovEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.nov, iYear);
            PDEstimatedActualSavings oDecEst = oPDCostReductionSummaryHelper.ObjGetInitialEstimatedSavingByMonthYear((int)mMonthEnuem.mMonth.dec, iYear);

            Label lbJan = (Label)grdView.FooterRow.FindControl("lbJan"); lbJan.Text = stringRoutine.formatAsBankMoney(oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO);
            Label lbFeb = (Label)grdView.FooterRow.FindControl("lbFeb"); lbFeb.Text = stringRoutine.formatAsBankMoney(oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO);
            Label lbMar = (Label)grdView.FooterRow.FindControl("lbMar"); lbMar.Text = stringRoutine.formatAsBankMoney(oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO);
            Label lbApr = (Label)grdView.FooterRow.FindControl("lbApr"); lbApr.Text = stringRoutine.formatAsBankMoney(oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO);
            Label lbMay = (Label)grdView.FooterRow.FindControl("lbMay"); lbMay.Text = stringRoutine.formatAsBankMoney(oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO);
            Label lbJun = (Label)grdView.FooterRow.FindControl("lbJun"); lbJun.Text = stringRoutine.formatAsBankMoney(oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO);
            Label lbJul = (Label)grdView.FooterRow.FindControl("lbJul"); lbJul.Text = stringRoutine.formatAsBankMoney(oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO);
            Label lbAug = (Label)grdView.FooterRow.FindControl("lbAug"); lbAug.Text = stringRoutine.formatAsBankMoney(oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO);
            Label lbSep = (Label)grdView.FooterRow.FindControl("lbSep"); lbSep.Text = stringRoutine.formatAsBankMoney(oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO);
            Label lbOct = (Label)grdView.FooterRow.FindControl("lbOct"); lbOct.Text = stringRoutine.formatAsBankMoney(oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO);
            Label lbNov = (Label)grdView.FooterRow.FindControl("lbNov"); lbNov.Text = stringRoutine.formatAsBankMoney(oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO);
            Label lbDec = (Label)grdView.FooterRow.FindControl("lbDec"); lbDec.Text = stringRoutine.formatAsBankMoney(oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO);


            //grdView.FooterRow.Cells[0].Text = "PD Est. Savings"; grdView.FooterRow.Cells[0].Font.Bold = true;
            //grdView.FooterStyle.BackColor = System.Drawing.Color.SkyBlue;

            //grdView.FooterStyle.Font.Size = FontUnit.Point(9);

            //grdView.FooterRow.Cells[1].Text = stringRoutine.formatAsBankMoney(oJanEst.dDD + oJanEst.dDDO + oJanEst.dEIO); //grdView.FooterRow.Cells[1].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[2].Text = stringRoutine.formatAsBankMoney(oFebEst.dDD + oFebEst.dDDO + oFebEst.dEIO); //grdView.FooterRow.Cells[2].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[3].Text = stringRoutine.formatAsBankMoney(oMarEst.dDD + oMarEst.dDDO + oMarEst.dEIO); //grdView.FooterRow.Cells[3].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[4].Text = stringRoutine.formatAsBankMoney(oAprEst.dDD + oAprEst.dDDO + oAprEst.dEIO); //grdView.FooterRow.Cells[4].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[5].Text = stringRoutine.formatAsBankMoney(oMayEst.dDD + oMayEst.dDDO + oMayEst.dEIO); //grdView.FooterRow.Cells[5].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[6].Text = stringRoutine.formatAsBankMoney(oJunEst.dDD + oJunEst.dDDO + oJunEst.dEIO); //grdView.FooterRow.Cells[6].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[7].Text = stringRoutine.formatAsBankMoney(oJulEst.dDD + oJulEst.dDDO + oJulEst.dEIO); //grdView.FooterRow.Cells[7].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[8].Text = stringRoutine.formatAsBankMoney(oAugEst.dDD + oAugEst.dDDO + oAugEst.dEIO); //grdView.FooterRow.Cells[8].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[9].Text = stringRoutine.formatAsBankMoney(oSepEst.dDD + oSepEst.dDDO + oSepEst.dEIO); //grdView.FooterRow.Cells[9].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[10].Text = stringRoutine.formatAsBankMoney(oOctEst.dDD + oOctEst.dDDO + oOctEst.dEIO); //grdView.FooterRow.Cells[10].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[11].Text = stringRoutine.formatAsBankMoney(oNovEst.dDD + oNovEst.dDDO + oNovEst.dEIO); //grdView.FooterRow.Cells[11].BackColor = System.Drawing.Color.SkyBlue;
            //grdView.FooterRow.Cells[12].Text = stringRoutine.formatAsBankMoney(oDecEst.dDD + oDecEst.dDDO + oDecEst.dEIO); //grdView.FooterRow.Cells[12].BackColor = System.Drawing.Color.SkyBlue;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }


    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //long lInitiativeId = long.Parse(lInitiativeHF.Value);
        grdView.EditIndex = -1;
        //Init_Control(lInitiativeId);
    }

    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdView.EditIndex = e.NewEditIndex;

        Init_ControlInitialEstimatedSavings(oTrans.tYear().iYear);
        //Init_Control(lInitiativeId);

        //long lResourceId = Convert.ToInt64(grdView.DataKeys[e.NewEditIndex].Values[0].ToString());
        //ResourceUtilisation oResourceUtil = new ResourceUtilisation();
        //ResourceUtilisation ThisResourceUtil = oResourceUtil.objGetResourceUtilisationByResourceId(lResourceId);
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lbAsset = (Label)grdView.Rows[e.RowIndex].FindControl("lbAsset");
        int iAssetId = int.Parse(lbAsset.Attributes["ASSETID"].ToString());
        int iYear = oTrans.tYear().iYear;

        decimal dJanDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJanDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJanDD")).Text) : 0;
        decimal dJanDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJanDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJanDDO")).Text) : 0;
        decimal dJanEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJanEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJanEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.jan, iYear, dJanDD, dJanDDO, dJanEIO);

        decimal dFebDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtFebDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtFebDD")).Text) : 0;
        decimal dFebDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtFebDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtFebDDO")).Text) : 0;
        decimal dFebEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtFebEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtFebEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.feb, iYear, dFebDD, dFebDDO, dFebEIO);

        decimal dMarDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMarDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMarDD")).Text) : 0;
        decimal dMarDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMarDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMarDDO")).Text) : 0;
        decimal dMarEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMarEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMarEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.mar, iYear, dMarDD, dMarDDO, dMarEIO);

        decimal dAprDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAprDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAprDD")).Text) : 0;
        decimal dAprDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAprDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAprDDO")).Text) : 0;
        decimal dAprEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAprEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAprEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.apr, iYear, dAprDD, dAprDDO, dAprEIO);

        decimal dMayDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMayDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMayDD")).Text) : 0;
        decimal dMayDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMayDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMayDDO")).Text) : 0;
        decimal dMayEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMayEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMayEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.may, iYear, dMayDD, dMayDDO, dMayEIO);

        decimal dJunDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJunDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJunDD")).Text) : 0;
        decimal dJunDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJunDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJunDDO")).Text) : 0;
        decimal dJunEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJunEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJunEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.jun, iYear, dJunDD, dJunDDO, dJunEIO);

        decimal dJulDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJulDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJulDD")).Text) : 0;
        decimal dJulDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJulDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJulDDO")).Text) : 0;
        decimal dJulEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJulEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJulEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.jul, iYear, dJulDD, dJulDDO, dJulEIO);

        decimal dAugDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAugDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAugDD")).Text) : 0;
        decimal dAugDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAugDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAugDDO")).Text) : 0;
        decimal dAugEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAugEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAugEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.aug, iYear, dAugDD, dAugDDO, dAugEIO);

        decimal dSepDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtSepDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtSepDD")).Text) : 0;
        decimal dSepDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtSepDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtSepDDO")).Text) : 0;
        decimal dSepEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtSepEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtSepEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.sep, iYear, dSepDD, dSepDDO, dSepEIO);

        decimal dOctDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtOctDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtOctDD")).Text) : 0;
        decimal dOctDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtOctDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtOctDDO")).Text) : 0;
        decimal dOctEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtOctEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtOctEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.oct, iYear, dOctDD, dOctDDO, dOctEIO);

        decimal dNovDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNovDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNovDD")).Text) : 0;
        decimal dNovDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNovDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNovDDO")).Text) : 0;
        decimal dNovEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNovEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNovEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.nov, iYear, dNovDD, dNovDDO, dNovEIO);

        decimal dDecDD = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtDecDD")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtDecDD")).Text) : 0;
        decimal dDecDDO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtDecDDO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtDecDDO")).Text) : 0;
        decimal dDecEIO = !string.IsNullOrEmpty(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtDecEIO")).Text) ? Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtDecEIO")).Text) : 0;
        InitiatEstimatedSavingsReduction(iAssetId, (int)mMonthEnuem.mMonth.dec, iYear, dDecDD, dDecDDO, dDecEIO);

        grdView.EditIndex = -1;

        Init_ControlInitialEstimatedSavings(oTrans.tYear().iYear);
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    private void InitiatEstimatedSavingsReduction(int iAsset, int iMonth, int iYear, decimal DD, decimal DDO, decimal EIO)
    {
        bool bRet = false;
        PDInitialEstimatedSavings oPDInitialEstimatedSavings = new PDInitialEstimatedSavings();
        oPDInitialEstimatedSavings.iAssetId = iAsset;
        oPDInitialEstimatedSavings.iMonth = iMonth;
        oPDInitialEstimatedSavings.iYear = iYear;
        oPDInitialEstimatedSavings.iUserId = oSessnx.getOnlineUser.m_iUserId;

        oPDInitialEstimatedSavings.dDD = DD;
        oPDInitialEstimatedSavings.dDDO = DDO;
        oPDInitialEstimatedSavings.dEIO = EIO;

        var o = oPDCostReductionSummaryHelper.ObjGetAssetInitialEstimatedSavingByMonthYear(iAsset, iMonth, iYear);
        if (o.iAssetId == 0)
        {
            bRet = oPDCostReductionSummaryHelper.InsertInitialEstimatedSavings(oPDInitialEstimatedSavings);
            //if (bRet)
            //{
            //    ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDInitialEstimatedSavings.iAssetId).sAsset + ", Estimated Saving successfully submitted.");
            //}
        }
        else
        {
            bRet = oPDCostReductionSummaryHelper.UpdateInitialEstimatedSavings(oPDInitialEstimatedSavings);
            //if (bRet)
            //{
            //    ajaxWebExtension.showJscriptAlertCx(Page, this, AssetPdcc.objGetAssetById(oPDInitialEstimatedSavings.iAssetId).sAsset + ", Estimated Saving successfully updated.");
            //}
        }
    }
}