using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_PDCC_UserControl_PDSummaryCostRedn : System.Web.UI.UserControl
{
    PDCostReductionSummaryHelper oPDCostReductionSummaryHelper = new PDCostReductionSummaryHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Init_Page(int iServiceId, int iYear)
    {
        try
        {
            grdView.DataSource = oPDCostReductionSummaryHelper.DtGetCostReductionByAssetService(iServiceId, iYear);
            grdView.DataBind();

            decimal dSumOpex = 0; decimal dSumDDBanked = 0; decimal dSumDDOppor = 0; decimal dSumDDOpporBanked = 0; decimal dSumEIO = 0; decimal dSumEIOBanked = 0;
            //decimal dSumAllSavingsBanked = 0; decimal dSumTargetReduction = 0; decimal dSumCurrentGap = 0; decimal dSumTotDDBanked = 0; 

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lblOpex = ((Label)(grdRow.FindControl("lblOpex")));
                Label lblDDBanked = ((Label)(grdRow.FindControl("lblDDBanked")));
                Label lblDDOppor = ((Label)(grdRow.FindControl("lblDDOppor")));
                Label lblDDOpporBanked = ((Label)(grdRow.FindControl("lblDDOpporBanked")));
                Label lblTotalDDBanked = ((Label)(grdRow.FindControl("lblTotalDDBanked")));
                Label lblPercDeepDiveBanked = ((Label)(grdRow.FindControl("lblPercDeepDiveBanked")));
                Label lblEIO = ((Label)(grdRow.FindControl("lblEIO")));
                Label lblEIOBanked = ((Label)(grdRow.FindControl("lblEIOBanked")));
                Label lblPercEIOBanked = ((Label)(grdRow.FindControl("lblPercEIOBanked")));
                Label lblAllSavingsBanked = ((Label)(grdRow.FindControl("lblAllSavingsBanked")));
                Label lblPercBanked = ((Label)(grdRow.FindControl("lblPercBanked")));
                Label lblSavingTarget = ((Label)(grdRow.FindControl("lblSavingTarget")));
                Label lblTargetRedctn = ((Label)(grdRow.FindControl("lblTargetRedctn")));
                Label lblCurrentGap = ((Label)(grdRow.FindControl("lblCurrentGap")));

                decimal Opex = !string.IsNullOrEmpty(lblOpex.Text) ? decimal.Parse(lblOpex.Text) : 0;
                decimal DDBanked = !string.IsNullOrEmpty(lblDDBanked.Text) ? decimal.Parse(lblDDBanked.Text) : 0;
                decimal DDOpporBanked = !string.IsNullOrEmpty(lblDDOpporBanked.Text) ? decimal.Parse(lblDDOpporBanked.Text) : 0;
                decimal dEioBanked = !string.IsNullOrEmpty(lblEIOBanked.Text) ? decimal.Parse(lblEIOBanked.Text) : 0;
                decimal dEio = !string.IsNullOrEmpty(lblEIO.Text) ? decimal.Parse(lblEIO.Text) : 0;
                decimal DDOppor = !string.IsNullOrEmpty(lblDDOppor.Text) ? decimal.Parse(lblDDOppor.Text) : 0;

                lblOpex.Text = !string.IsNullOrEmpty(lblOpex.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblOpex.Text)) : "0";
                lblDDBanked.Text = !string.IsNullOrEmpty(lblDDBanked.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblDDBanked.Text)) : "0";
                lblDDOpporBanked.Text = !string.IsNullOrEmpty(lblDDOpporBanked.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblDDOpporBanked.Text)) : "0";
                lblEIOBanked.Text = !string.IsNullOrEmpty(lblEIOBanked.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblEIOBanked.Text)) : "0";
                lblEIO.Text = !string.IsNullOrEmpty(lblEIO.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblEIO.Text)) : "0";
                lblDDOppor.Text = !string.IsNullOrEmpty(lblDDOppor.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblDDOppor.Text)) : "0";

                dSumOpex += Opex;
                dSumDDBanked += DDBanked;
                dSumDDOppor += DDOppor;
                dSumDDOpporBanked += DDOpporBanked;
                //
                dSumEIO += dEio;
                dSumEIOBanked += dEioBanked;


                CalculateValues(Opex, DDBanked, DDOpporBanked, dEioBanked, dEio, lblTotalDDBanked, lblPercDeepDiveBanked, lblPercEIOBanked, lblAllSavingsBanked, lblPercBanked, lblTargetRedctn, lblCurrentGap);
            }
            grdView.FooterRow.Cells[1].Text = "Total"; grdView.FooterRow.Cells[1].Font.Bold = true;
            grdView.FooterRow.Cells[2].Text = stringRoutine.formatAsBankMoney(dSumOpex); grdView.FooterRow.Cells[2].Font.Bold = true;
            grdView.FooterRow.Cells[3].Text = stringRoutine.formatAsBankMoney(dSumDDBanked); grdView.FooterRow.Cells[3].Font.Bold = true;
            grdView.FooterRow.Cells[4].Text = stringRoutine.formatAsBankMoney(dSumDDOppor); grdView.FooterRow.Cells[4].Font.Bold = true;
            grdView.FooterRow.Cells[5].Text = stringRoutine.formatAsBankMoney(dSumDDOpporBanked); grdView.FooterRow.Cells[5].Font.Bold = true;
            grdView.FooterRow.Cells[6].Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.TotalDDBanked(dSumDDBanked, dSumDDOpporBanked)); grdView.FooterRow.Cells[6].Font.Bold = true;
            grdView.FooterRow.Cells[7].Text = oPDCostReductionSummaryHelper.PercentageDDBanked(dSumOpex, dSumDDBanked, dSumDDOpporBanked).ToString(); grdView.FooterRow.Cells[7].Font.Bold = true;
            grdView.FooterRow.Cells[8].Text = stringRoutine.formatAsBankMoney(dSumEIO); grdView.FooterRow.Cells[8].Font.Bold = true;
            grdView.FooterRow.Cells[9].Text = stringRoutine.formatAsBankMoney(dSumEIOBanked); grdView.FooterRow.Cells[9].Font.Bold = true;
            grdView.FooterRow.Cells[10].Text = oPDCostReductionSummaryHelper.PercentageEioBanked(dSumEIOBanked, dSumEIO).ToString(); grdView.FooterRow.Cells[10].Font.Bold = true;
            grdView.FooterRow.Cells[11].Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.AllSavingsBanked(dSumEIOBanked, dSumDDBanked, dSumDDOpporBanked)); grdView.FooterRow.Cells[11].Font.Bold = true;
            grdView.FooterRow.Cells[12].Text = oPDCostReductionSummaryHelper.PercentageSavingsBanked(dSumOpex, dSumEIOBanked, dSumDDBanked, dSumDDOpporBanked).ToString(); grdView.FooterRow.Cells[12].Font.Bold = true;
            grdView.FooterRow.Cells[13].Text = "25.0%"; grdView.FooterRow.Cells[13].Font.Bold = true;
            grdView.FooterRow.Cells[14].Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.TargetReduction(dSumOpex)); grdView.FooterRow.Cells[14].Font.Bold = true;
            grdView.FooterRow.Cells[15].Text = stringRoutine.formatAsBankMoney((oPDCostReductionSummaryHelper.TargetReduction(dSumOpex) - oPDCostReductionSummaryHelper.AllSavingsBanked(dSumEIOBanked, dSumDDBanked, dSumDDOpporBanked))); grdView.FooterRow.Cells[15].Font.Bold = true;

        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }


    private DataTable dtPDPerformanceSummary(int iYear)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("ASSET");
        dt.Columns.Add("OPEX", typeof(decimal));
        dt.Columns.Add("DDBANKED", typeof(decimal));
        dt.Columns.Add("DDOPPOR", typeof(decimal));
        dt.Columns.Add("DDOPPORBANKED", typeof(decimal));
        dt.Columns.Add("EIO", typeof(decimal));
        dt.Columns.Add("EIOBANKED", typeof(decimal));

        dt.NewRow();
        dt.Rows.Add();

        foreach (DataRow dr in dt.Rows)
        {
            PDPerformanceSumm xCop = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYear(iYear);

            dr["ASSET"] = "PD Performance";
            dr["OPEX"] = xCop.dOpex;
            dr["DDBANKED"] = xCop.dDDBanked;
            dr["DDOPPOR"] = xCop.dDDOppor;
            dr["DDOPPORBANKED"] = xCop.dDDOpporBanked;
            dr["EIO"] = xCop.dEIO;
            dr["EIOBANKED"] = xCop.dEIOBanked;
        }

        return dt;
    }
    public void LoadPDSummaryPerformance(int iYearId)
    {
        grdView.DataSource = dtPDPerformanceSummary(iYearId);
        grdView.DataBind();

        Calculator();
    }

    public void PDPerformance(int iYear)
    {
        //For each Asset/Department
        DataTable dtSummary = oPDCostReductionSummaryHelper.DtGetPDCostReductionPerformance(iYear);

        DataTable dt = new DataTable();

        dt.Columns.Add("ASSET");
        dt.Columns.Add("OPEX", typeof(decimal));
        dt.Columns.Add("DDBANKED", typeof(decimal));
        dt.Columns.Add("DDOPPOR", typeof(decimal));
        dt.Columns.Add("DDOPPORBANKED", typeof(decimal));
        dt.Columns.Add("EIO", typeof(decimal));
        dt.Columns.Add("EIOBANKED", typeof(decimal));

        dt.NewRow();
        dt.Rows.Add();

        //ONSHORE
        foreach (DataRow dr in dt.Rows)
        {
            PDPerformanceSumm xCop = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 1); //TODO: This is wrong please find final solution

            dr["ASSET"] = "ONSHORE";
            dr["OPEX"] = xCop.dOpex.ToString();
            dr["DDBANKED"] = xCop.dDDBanked.ToString();
            dr["DDOPPOR"] = xCop.dDDOppor.ToString();
            dr["DDOPPORBANKED"] = xCop.dDDOpporBanked.ToString();
            dr["EIO"] = xCop.dEIO.ToString();
            dr["EIOBANKED"] = xCop.dEIOBanked.ToString();
        }

        dtSummary.Merge(dt);

        //OFFSHORE
        dt.Clear();
        dt.NewRow();
        dt.Rows.Add();

        foreach (DataRow dr in dt.Rows)
        {
            PDPerformanceSumm xCop = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearAssetService(iYear, 2); //TODO: This is wrong please find final solution

            dr["ASSET"] = "OFFSHORE";
            dr["OPEX"] = xCop.dOpex.ToString();
            dr["DDBANKED"] = xCop.dDDBanked.ToString();
            dr["DDOPPOR"] = xCop.dDDOppor.ToString();
            dr["DDOPPORBANKED"] = xCop.dDDOpporBanked.ToString();
            dr["EIO"] = xCop.dEIO.ToString();
            dr["EIOBANKED"] = xCop.dEIOBanked.ToString();
        }

        dtSummary.Merge(dt);

        //SPDC
        dt.Clear();
        dt.NewRow();
        dt.Rows.Add();
        foreach (DataRow dr in dt.Rows)
        {
            PDPerformanceSumm xCop = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 1); //TODO: This is wrong please find final solution

            dr["ASSET"] = "SPDC";
            dr["OPEX"] = xCop.dOpex.ToString();
            dr["DDBANKED"] = xCop.dDDBanked.ToString();
            dr["DDOPPOR"] = xCop.dDDOppor.ToString();
            dr["DDOPPORBANKED"] = xCop.dDDOpporBanked.ToString();
            dr["EIO"] = xCop.dEIO.ToString();
            dr["EIOBANKED"] = xCop.dEIOBanked.ToString();
        }
        dtSummary.Merge(dt);

        //SNEPCO
        dt.Clear();
        dt.NewRow();
        dt.Rows.Add();
        foreach (DataRow dr in dt.Rows)
        {
            PDPerformanceSumm xCop = oPDCostReductionSummaryHelper.ObjGetPDPerformanceSummaryByYearOU(iYear, 2); //TODO: This is wrong please find final solution

            dr["ASSET"] = "SNEPCO";
            dr["OPEX"] = xCop.dOpex.ToString();
            dr["DDBANKED"] = xCop.dDDBanked.ToString();
            dr["DDOPPOR"] = xCop.dDDOppor.ToString();
            dr["DDOPPORBANKED"] = xCop.dDDOpporBanked.ToString();
            dr["EIO"] = xCop.dEIO.ToString();
            dr["EIOBANKED"] = xCop.dEIOBanked.ToString();
        }
        dtSummary.Merge(dt);

        //PD Summary
        dtSummary.Merge(dtPDPerformanceSummary(iYear));

        grdView.DataSource = dtSummary;
        grdView.DataBind();

        Calculator();
    }

    private void Calculator()
    {
        decimal dSumOpex = 0; decimal dSumDDBanked = 0; decimal dSumDDOppor = 0; decimal dSumDDOpporBanked = 0; decimal dSumEIO = 0; decimal dSumEIOBanked = 0;
        //decimal dSumAllSavingsBanked = 0; decimal dSumTargetReduction = 0; decimal dSumCurrentGap = 0; decimal dSumTotDDBanked = 0; 

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblOpex = ((Label)(grdRow.FindControl("lblOpex")));
            Label lblDDBanked = ((Label)(grdRow.FindControl("lblDDBanked")));
            Label lblDDOppor = ((Label)(grdRow.FindControl("lblDDOppor")));
            Label lblDDOpporBanked = ((Label)(grdRow.FindControl("lblDDOpporBanked")));
            Label lblTotalDDBanked = ((Label)(grdRow.FindControl("lblTotalDDBanked")));
            Label lblPercDeepDiveBanked = ((Label)(grdRow.FindControl("lblPercDeepDiveBanked")));
            Label lblEIO = ((Label)(grdRow.FindControl("lblEIO")));
            Label lblEIOBanked = ((Label)(grdRow.FindControl("lblEIOBanked")));
            Label lblPercEIOBanked = ((Label)(grdRow.FindControl("lblPercEIOBanked")));
            Label lblAllSavingsBanked = ((Label)(grdRow.FindControl("lblAllSavingsBanked")));
            Label lblPercBanked = ((Label)(grdRow.FindControl("lblPercBanked")));
            Label lblSavingTarget = ((Label)(grdRow.FindControl("lblSavingTarget")));
            Label lblTargetRedctn = ((Label)(grdRow.FindControl("lblTargetRedctn")));
            Label lblCurrentGap = ((Label)(grdRow.FindControl("lblCurrentGap")));

            decimal Opex = !string.IsNullOrEmpty(lblOpex.Text) ? decimal.Parse(lblOpex.Text) : 0;
            decimal DDBanked = !string.IsNullOrEmpty(lblDDBanked.Text) ? decimal.Parse(lblDDBanked.Text) : 0;
            decimal DDOpporBanked = !string.IsNullOrEmpty(lblDDOpporBanked.Text) ? decimal.Parse(lblDDOpporBanked.Text) : 0;
            decimal dEioBanked = !string.IsNullOrEmpty(lblEIOBanked.Text) ? decimal.Parse(lblEIOBanked.Text) : 0;
            decimal dEio = !string.IsNullOrEmpty(lblEIO.Text) ? decimal.Parse(lblEIO.Text) : 0;
            decimal DDOppor = !string.IsNullOrEmpty(lblDDOppor.Text) ? decimal.Parse(lblDDOppor.Text) : 0;

            lblOpex.Text = !string.IsNullOrEmpty(lblOpex.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblOpex.Text)) : "0";
            lblDDBanked.Text = !string.IsNullOrEmpty(lblDDBanked.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblDDBanked.Text)) : "0";
            lblDDOpporBanked.Text = !string.IsNullOrEmpty(lblDDOpporBanked.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblDDOpporBanked.Text)) : "0";
            lblEIOBanked.Text = !string.IsNullOrEmpty(lblEIOBanked.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblEIOBanked.Text)) : "0";
            lblEIO.Text = !string.IsNullOrEmpty(lblEIO.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblEIO.Text)) : "0";
            lblDDOppor.Text = !string.IsNullOrEmpty(lblDDOppor.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblDDOppor.Text)) : "0";

            dSumOpex += Opex;
            dSumDDBanked += DDBanked;
            dSumDDOppor += DDOppor;
            dSumDDOpporBanked += DDOpporBanked;
            //
            dSumEIO += dEio;
            dSumEIOBanked += dEioBanked;

            CalculateValues(Opex, DDBanked, DDOpporBanked, dEioBanked, dEio, lblTotalDDBanked, lblPercDeepDiveBanked, lblPercEIOBanked, lblAllSavingsBanked, lblPercBanked, lblTargetRedctn, lblCurrentGap);
        }
    }

    private void CalculateValues(decimal Opex, decimal DDBanked, decimal DDOpporBanked, decimal dEioBanked, decimal dEio, Label lblTotalDDBanked, Label lblPercDeepDiveBanked, Label lblPercEIOBanked, Label lblAllSavingsBanked, Label lblPercBanked, Label lblTargetRedctn, Label lblCurrentGap)
    {
        lblTotalDDBanked.Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.TotalDDBanked(DDBanked, DDOpporBanked));
        lblPercDeepDiveBanked.Text = oPDCostReductionSummaryHelper.PercentageDDBanked(Opex, DDBanked, DDOpporBanked).ToString();
        lblPercEIOBanked.Text = oPDCostReductionSummaryHelper.PercentageEioBanked(dEioBanked, dEio).ToString();
        lblAllSavingsBanked.Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.AllSavingsBanked(dEioBanked, DDBanked, DDOpporBanked));
        lblPercBanked.Text = oPDCostReductionSummaryHelper.PercentageSavingsBanked(Opex, dEioBanked, DDBanked, DDOpporBanked).ToString();
        lblTargetRedctn.Text = stringRoutine.formatAsBankMoney(oPDCostReductionSummaryHelper.TargetReduction(Opex));
        lblCurrentGap.Text = stringRoutine.formatAsBankMoney((oPDCostReductionSummaryHelper.TargetReduction(Opex) - oPDCostReductionSummaryHelper.AllSavingsBanked(dEioBanked, DDBanked, DDOpporBanked)));
    }
}