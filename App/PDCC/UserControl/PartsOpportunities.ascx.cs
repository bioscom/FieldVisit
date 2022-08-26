using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_UserControl_PartsOpportunities : System.Web.UI.UserControl
{
    PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Page_Init()
    {
        PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
        var oYears = oPDCostReductionSummaryHelper.lstYears();
        ddlYear.Items.Clear();
        ddlYear.Items.Add(new ListItem("--Select Year--", "1"));
        foreach(var i in oYears)
        {
            ddlYear.Items.Add(i.ToString());
        }

        LoadReport(oTrans.tYear().iYear);

        lblPercSavings.Text = oPDCostReductionSummaryHelper.OverrallPercentageSavings().ToString() + " %";
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadReport(int.Parse(ddlYear.SelectedValue));
    }


    private void LoadReport(int iYear)
    {
        List<PDCostReductionSummary> lstPDCostReduction = oPDCostReductionSummaryHelper.lstGetCostReductionByYear(iYear);
        RenderToPage(lstPDCostReduction, iYear);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        //List<cVerificationHeatMap> lstVerification = cVerificationHeatMapHelper.lstGetVerificationByMonthYear(int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue));
        ExporttoExcel();

        //List<NTR> oNTR = oNtrHelper.lstReportNtrByMonthYear(ddlMonth.SelectedItem.Text, int.Parse(ddlYear.SelectedValue));
        //List<NTR> oNTRWithAction = oNtrHelper.lstGetNtrByMonthYearWithActions(ddlMonth.SelectedItem.Text, int.Parse(ddlYear.SelectedValue));
        //ExporttoExcel(oNTR, oNTRWithAction);
    }

    private void RenderToPage(List<PDCostReductionSummary> lstPDCostReduction, int iYear)
    {
        //Set Colours
        string styleYellow = "style='background-color:Yellow; padding: 5px;text-align: right;vertical-align: middle; font:bold;'";
        string styleFushia = "style='background-color:#f7d6a5; padding: 5px;text-align: right;vertical-align: middle; font:bold;'";
        string styleDeepFushia = "style='background-color:#fbc3b0; padding: 5px;text-align: right;vertical-align: middle;'";
        string styleSkyBlue = "style='background-color:#87CEEB; padding: 5px;text-align: right;vertical-align: middle;'";
        string textAlignment = "style='padding: 5px;text-align: left;vertical-align: middle;font:bold'";
        string textRtAlignment = "style='padding: 5px;text-align: right;vertical-align: middle;font:bold'";

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        //sets font
        sb.Append("<font style='font-size:12.0pt; font-family:Calibri;'>");
        //sb.Append("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        sb.Append("<Table border='1' " +
          "borderColor='#eee' cellSpacing='0' cellPadding='0' " +
          "style='font-size:10.0pt; font-family:Calibri; background:white;'> ");

        sb.Append("<tr>");

        sb.Append("<td rowspan='2'>");
        sb.Append("<div style='font:bold; '>");
        sb.Append("Asset/Team");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td rowspan='2'>");
        sb.Append("<div " + styleYellow + ">");
        sb.Append("OP" + (iYear - 1));
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td rowspan='2'>");
        sb.Append("<div>");
        sb.Append("Target Saving 25% of Opex");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td colspan='3'>");
        sb.Append("<div " + styleFushia + ">");
        sb.Append("Deep Dive");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td colspan='3'>");
        sb.Append("<div " + styleDeepFushia + ">");
        sb.Append("Deep Dive Opportunities");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("<div " + styleSkyBlue + ">");
        sb.Append("Efficiency Improvement Opportunities");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td colspan='8'>");
        sb.Append("<div>");
        sb.Append("");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("</tr>");

        //==============================

        sb.Append("<tr>");

        //sb.Append("<td>");
        //sb.Append("<div>");
        //sb.Append("");
        //sb.Append("</div>");
        //sb.Append("</td>");

        //sb.Append("<td>");
        //sb.Append("<div " + styleYellow + ">");
        //sb.Append("  ");
        //sb.Append("</div>");
        //sb.Append("</td>");

        //sb.Append("<td>");
        //sb.Append("<div>");
        //sb.Append("");
        //sb.Append("</div>");
        //sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleFushia + ">");
        sb.Append("Bankable");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleFushia + ">");
        sb.Append("Banked as at");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleFushia + ">");
        sb.Append("Expected");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleDeepFushia + ">");
        sb.Append("Estimated Savings");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleDeepFushia + ">");
        sb.Append("Banked as at");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleDeepFushia + ">");
        sb.Append("Expected");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleSkyBlue + ">");
        sb.Append("Estimated Savings");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleSkyBlue + ">");
        sb.Append("Actual Savings");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleSkyBlue + ">");
        sb.Append("Banked");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleSkyBlue + ">");
        sb.Append("Cost Avoidance");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td colspan='8'>");
        sb.Append("<div>");
        sb.Append("");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("</tr>");

        decimal dSum25per = 0;
        decimal dSumOpex = 0; decimal dSumDeepDiveBanked = 0; decimal dSumDeepDiveBankable = 0; decimal dSumDeepDiveExpected = 0;
        decimal dSumDeepDiveOppor = 0; decimal dSumDeepDiveOpporBanked = 0; decimal dSumDeepDiveOpporExpected = 0;
        decimal dSumEIO = 0; decimal dSumEIOBanked = 0; decimal dSumEIOActual = 0; decimal dSumEIOCostAvoidance = 0;

        foreach (PDCostReductionSummary oCostReduction in lstPDCostReduction)
        {
            //write in new row
            sb.Append("<tr>");

            sb.Append("<Td>");
            sb.Append("<div " + textAlignment + ">");
            sb.Append(AssetPdcc.objGetAssetById(oCostReduction.iAssetId).sAsset);
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleYellow + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dOpex));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + textRtAlignment + ">");
            sb.Append(stringRoutine.formatAsBankMoney(Math.Round((oCostReduction.dOpex * 0.25M), 2)));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleFushia + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dDeepDiveBanked));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleFushia + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dDeepDiveBankable));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleFushia + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dDeepDiveExpected));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleDeepFushia + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dDeepDiveOppor));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleDeepFushia + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dDeepDiveOpporBanked));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleDeepFushia + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dDeepDiveOpporExpected));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleSkyBlue + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dEIO));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleSkyBlue + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dEIOActual));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleSkyBlue + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dEIOBanked));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td>");
            sb.Append("<div " + styleSkyBlue + ">");
            sb.Append(stringRoutine.formatAsBankMoney(oCostReduction.dEIOCostAvoidance));
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("<Td colspan='8'>");
            sb.Append("<div>");
            sb.Append(oCostReduction.sPerformanceDescription);
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("</tr>");

            dSum25per += Math.Round((oCostReduction.dOpex * 0.25M), 2);
            dSumOpex += oCostReduction.dOpex; 

            dSumDeepDiveBanked += oCostReduction.dDeepDiveBanked;

            dSumDeepDiveBankable += oCostReduction.dDeepDiveBankable;
            dSumDeepDiveExpected += oCostReduction.dDeepDiveExpected;

            dSumDeepDiveOppor += oCostReduction.dDeepDiveOppor;
            dSumDeepDiveOpporBanked += oCostReduction.dDeepDiveOpporBanked;

            dSumDeepDiveOpporExpected += oCostReduction.dDeepDiveOpporExpected;

            dSumEIO += oCostReduction.dEIO; 
            dSumEIOBanked += oCostReduction.dEIOBanked;

            dSumEIOActual += oCostReduction.dEIOActual;
            dSumEIOCostAvoidance += oCostReduction.dEIOCostAvoidance;

        }

        sb.Append("<tr>");

        sb.Append("<Td>");
        sb.Append("<div style='font-size:14.0pt; font-family:Calibri; background:white; color:RED'>");
        sb.Append("PD");
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumOpex));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSum25per));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumDeepDiveBanked));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumDeepDiveBankable));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumDeepDiveExpected));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumDeepDiveOppor));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumDeepDiveOpporBanked));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumDeepDiveOpporExpected));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumEIO));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumEIOActual));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumEIOBanked));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td>");
        sb.Append("<div " + textRtAlignment + ">");
        sb.Append(stringRoutine.formatAsBankMoney(dSumEIOCostAvoidance));
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<Td colspan='8'>");
        sb.Append("<div>");
        sb.Append("");
        sb.Append("</div>");
        sb.Append("</Td>");

        sb.Append("<tr>");

        sb.Append("</Table>");

        sb.Append("</font>");

        ViewLiteral.Text = sb.ToString();
    }

    private void ExporttoExcel()
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        
        //Get the actions
        //HttpContext.Current.Response.Write("<br>");
        HttpContext.Current.Response.Write(ViewLiteral.Text);

        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
}