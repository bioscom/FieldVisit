using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

public partial class taskPage : aspnetPage
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    readonly Department _Department = new Department();
    readonly AppsVisitorsHelper oAppsVisitorsHelper = new AppsVisitorsHelper();
    TransactionYear oTrans = new TransactionYear();

    //private bool AbsoluteVal = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PDCostReductionSummaryHelper o = new PDCostReductionSummaryHelper();
            lblPercentagePD.Text = o.OverrallPercentageSavings().ToString() + " %";

            pnlView.Visible = false;
            pnlSummary.Visible = false;
            pnlPDReportSummary.Visible = false;

            //Graphs Plotting 
            LineGraph.PDEstimateActualCummulativeLineGraph(oTrans.tYear().iYear);
            StackedChart.StackedBarChart(oTrans.tYear().iYear);

            Marquee();

            #region Unused Codes but may be useful in future
            //if (string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName))
            //{
            //    //Response.Redirect("~/Profiles/pageDenied.aspx");
            //    Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
                //CharttingT.Init_Page(System.OpportunityCostHelper.iYear);
                //CharttingTSnepco.Init_PageSnepco(System.OpportunityCostHelper.iYear);
                //CharttingTPD.Init_PagePD(System.OpportunityCostHelper.iYear);

                //OpexFectoImprovementActualPotential objOffShoreOnShore = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(OpportunityCostHelper.iYear);
                //lblPDSavings.Text = stringRoutine.formatAsBankMoney("$", (objOffShoreOnShore.dActSavings + objOffShoreOnShore.dImprovement));
                //decimal percentSaved = Math.Round(((objOffShoreOnShore.dActSavings / objOffShoreOnShore.dOpex) * 100), 0);
                //lblPercentagePD.Text = stringRoutine.formatAsNumber(percentSaved) + " %";

                //PDMonthlyActualSavings.Init_ControlActualSavings(OpportunityCostHelper.iYear);
                //PDMonthlyEstmatedSavings.Init_ControlEstimatedSavings(OpportunityCostHelper.iYear);
                //PDMonthlyLE.Init_ControlLESavings(OpportunityCostHelper.iYear);

                //PDValue.Init_Control(OpportunityCostHelper.iYear);
                //PDCummulative.Init_ControlCummulative(OpportunityCostHelper.iYear);

                //PercDDBanked.PercentageDDBanked(OpportunityCostHelper.iYear);
                //PercSavingBankedVsSavingsTarget.PercentageSavingsBanked(OpportunityCostHelper.iYear);
                //PercEIOBanked.PercentageEIOBanked(OpportunityCostHelper.iYear);

                //WeeklyHighLight.Init_Page();
            //}
            #endregion
        }
    }

    private void Marquee()
    {
        List<OpportunityCost> lstProjects = _opportunityCostHelper.lstGetProjects(oTrans.tYear().iYear);
        string s1;
        s1 = "<table style='border:none'>";
        //string sAMount = "";
        //string sStrory = "";
        int i = 1;

        foreach(OpportunityCost oProject in lstProjects)
        {
            //sAMount = !string.IsNullOrEmpty(dr["AMTSAVED"].ToString()) ? stringRoutine.formatAsBankMoney(decimal.Parse(dr["AMTSAVED"].ToString())) : "";
            //sStrory = dr["STORY"].ToString().Length > 200 ? dr["STORY"].ToString().Remove(201).Insert(201, "...") : dr["STORY"].ToString();
            s1 += "<tr>";
            s1 += "<td>";
            //s1 += "<hr/>";
            //s1 += "<strong><a href=Somepage.aspx style='font-family: fantasy; font-size: large; font-weight:bold; font-style: normal; color: Yellow'>" + dr["TITLE"].ToString() + "</a></strong>";
            s1 += "<strong><a href=Somepage.aspx style='font-family: Arial; font-style: normal; color: #ffffff'>Asset: " + oProject.sAsset + "</a></strong>";
            s1 += "<br/>";
            //s1 += "<strong><a href=Somepage.aspx style='color: Green'>" + i + ".  " + oProject.sOpportunity + "</a></strong>";
            //<a href="javascript:NewWindow('newcolour.html','colorchart','640','480','custom','front');">Click Here For Popup Color Chart</a>
            s1 += "<strong><a href=javascript:NewWindow('CostStoryDetails.aspx?lOpCost=" + oProject.lOpCost + "'" + ",'colorchart','950','550','custom','front');>" + i + ".  " + oProject.sOpportunity + "</a></strong>";
            //NewWindow('CostStoryDetails.aspx?lOpCost=91','colorchart','640','480','custom','front');
            
            s1 += "<br/>";
            s1 += "<strong><font color='Red'>Amount Saved: $ " + oProject.dActSavings + "</font></strong>";            
            s1 += "<hr/>";
            s1 += "</td>";
            s1 += "</tr>";
            i++;
        }
        s1 += "</table>";
        lt1.Text = s1.ToString();

        //OpportunityCost oProjects = _opportunityCostHelper.ObjGetProjects(OpportunityCostHelper.iYear);
        //DataTable dtProjects = _opportunityCostHelper.DtGetProjects(OpportunityCostHelper.iYear);

        //DataTable dt = _opportunityCostHelper.dtGetStories();

        //string s1;
        //s1 = "<table style='border:none'>";
        //string sAMount = "";
        //string sStrory = "";
        //int i = 1;
        //foreach (DataRow dr in dt.Rows)
        //{
        //    sAMount = !string.IsNullOrEmpty(dr["AMTSAVED"].ToString()) ? stringRoutine.formatAsBankMoney(decimal.Parse(dr["AMTSAVED"].ToString())) : "";
        //    sStrory = dr["STORY"].ToString().Length > 200 ? dr["STORY"].ToString().Remove(201).Insert(201, "...") : dr["STORY"].ToString();
        //    s1 += "<tr>";
        //    s1 += "<td>";
        //    //s1 += "<hr/>";
        //    //s1 += "<strong><a href=Somepage.aspx style='font-family: fantasy; font-size: large; font-weight:bold; font-style: normal; color: Yellow'>" + dr["TITLE"].ToString() + "</a></strong>";
        //    s1 += "<strong><a href=Somepage.aspx style='color: Gold'>" + i + ".  " + dr["TITLE"].ToString() + "</a></strong>";
        //    s1 += "<br/>";
        //    s1 += "<font color='Red'>Amount Saved: $ " + sAMount + "</font>";
        //    s1 += "<br/>";
        //    s1 += "<a href=Somepage.aspx style='font-family: Arial; font-style: normal; color: #ffffff'>" + sStrory + "</a>";
        //    s1 += "<hr/>";
        //    s1 += "</td>";
        //    s1 += "</tr>";
        //    i++;
        //}

        //s1 += "</table>";
        //lt1.Text = s1.ToString();
    }
    protected void RepeaterImages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            //ddlExport.ClearSelection();

            RepeaterItem oItem = e.Item;
            Button btnAsset = (Button)oItem.FindControl("btnAsset");
            int iAssetId = int.Parse(btnAsset.Attributes["ASSETID"]);
            iAssetIdHF.Value = iAssetId.ToString();

            lblAsset.Text = AssetPdcc.objGetAssetById(iAssetId).sAsset + " Cost Agenda";

            OpexFectoImprovementActualPotential oSummary = _opportunityCostHelper.ObjGetAssetPerformanceByYear(oTrans.tYear().iYear, iAssetId);
            //SummaryCalculation(oSummary);

            //lblOpex.Text = "OP " + (OpportunityCostHelper.iYear - 1).ToString().Remove(0, 2) + ": "; lblOpex.ForeColor = System.Drawing.Color.Red;
            //lblOpexResult.Text = stringRoutine.formatAsBankMoney("$", oAsset.dOpex); lblOpexResult.ForeColor = System.Drawing.Color.Red;
            //lblActual.Text = stringRoutine.formatAsBankMoney("$", oAsset.dActSavings); lblActual.ForeColor = System.Drawing.Color.Green;

            //decimal dPercSavings = (oAsset.dOpex != 0) ? ((oAsset.dActSavings / oAsset.dOpex) * 100) : 0; // When divisor is not equal to zero
            //lblPercentageSavings.Text = stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";

            //lblImproved.Text = stringRoutine.formatAsBankMoney("$", oAsset.dImprovement);

            //decimal dPercSavings = ((oSummary.dActSavings / oSummary.dOpex) * 100);
            decimal dPercSavings = (oSummary.dOpex != 0) ? ((oSummary.dActSavings / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
            decimal dPercImprOppr = (oSummary.dOpex != 0) ? ((oSummary.dImprovement / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
            lblPercentageSavings.Text = stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";

            lblOpex.Text = "OP " + (oTrans.tYear().iYear - 1).ToString().Remove(0, 2) + ": "; lblOpex.ForeColor = System.Drawing.Color.Red;
            lblOpexResult.Text = stringRoutine.formatAsBankMoney("$", oSummary.dOpex);
            lblOpexResult.ForeColor = (oSessnx.getOnlineUser.m_iCostSavingAbsVal == 1) ? System.Drawing.Color.Red : lblOpexResult.ForeColor = System.Drawing.Color.White;

            ///Actual Cost Saved (Deep Dive Banked)
            lblActual.Text = (oSessnx.getOnlineUser.m_iCostSavingAbsVal == 1)
                ? stringRoutine.formatAsBankMoney("$", oSummary.dActSavings)
                : stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";
            lblActual.ForeColor = System.Drawing.Color.Green;

            ///Improvement Opportunity
            lblImproved.Text = (oSessnx.getOnlineUser.m_iCostSavingAbsVal == 1)
                ? stringRoutine.formatAsBankMoney("$", oSummary.dImprovement)
                : stringRoutine.formatAsBankMoney(Math.Round(dPercImprOppr, 2)) + " %";


            pnlView.Visible = true;
            if (oSessnx.getOnlineUser.m_iCostSavingAbsVal != 1)
            {
                btnExport.Enabled = false;
                btnSummaryExport.Enabled = false;
            }
            pnlGraph.Visible = false;
            pnlPDReportSummary.Visible = false;

            //_opportunityCostHelper.lstGetOpportunityCostByAsset(iAssetId, OpportunityCostHelper.iYear);
            grdViewDetails.DataSource = _opportunityCostHelper.DtGetOpportunityCostByAsset(iAssetId, oTrans.tYear().iYear);
            grdViewDetails.DataBind();

            _opportunityCostHelper.GetItemsStringValues(grdViewDetails, oSessnx.getOnlineUser);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void lnkOnshore_Click(object sender, EventArgs e)
    {
        //List<AssetPdcc> lstAsset = _opportunityCostHelper.lstGetAssetsByOnshoreOffshoreByYear((int)ItemStatus.ItStatus.Onshore, System.OpportunityCostHelper.iYear);
        //List<string> sAssets = new List<string>();

        //foreach (AssetPdcc oAsset in lstAsset)
        //{
        //    sAssets.Add(oAsset.sAsset);
        //}
        try
        {
            //pnlView.Visible = false;
            pnlSummary.Visible = true;
            pnlGraph.Visible = false;
            pnlPDReportSummary.Visible = false;
            lblTitle.Text = "Onshore Cost Agenda: =>";

            OpexFectoImprovementActualPotential oSummary = _opportunityCostHelper.ObjGetOpExFectoImprovementByAssetYear(oTrans.tYear().iYear, (int)ItemStatus.ItStatus.Onshore);
            SummaryCalculation(oSummary);

            //lblOpex0.Text = "OP " + (OpportunityCostHelper.iYear - 1).ToString().Remove(0, 2) + ": "; lblOpex0.ForeColor = System.Drawing.Color.Red;
            //lblOpexResult0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dOpex); lblOpexResult0.ForeColor = System.Drawing.Color.Red;
            //lblActual0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dActSavings); lblActual0.ForeColor = System.Drawing.Color.Green;

            ////decimal dPercSavings = ((oSummary.dActSavings / oSummary.dOpex) * 100);
            //decimal dPercSavings = (oSummary.dOpex != 0) ? ((oSummary.dActSavings / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
            //lblPercentageSavings0.Text = stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";

            //lblImproved0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dImprovement);

            pnlView.Visible = false;

            DataTable dt = _opportunityCostHelper.dtGetAssetsByOnshoreOffshoreByYear((int)ItemStatus.ItStatus.Onshore, oTrans.tYear().iYear);

            RepeaterImages.DataSource = dt;
            RepeaterImages.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void lnkOffshore_Click(object sender, EventArgs e)
    {
        //List<AssetPdcc> lstAsset = _opportunityCostHelper.lstGetAssetsByOnshoreOffshoreByYear((int)ItemStatus.ItStatus.Offshore, System.OpportunityCostHelper.iYear);
        //List<string> sAssets = new List<string>();

        //foreach (AssetPdcc oAsset in lstAsset)
        //{
        //    sAssets.Add(oAsset.sAsset);
        //}
        try
        {
            pnlSummary.Visible = true;
            pnlGraph.Visible = false;
            pnlPDReportSummary.Visible = false;
            lblTitle.Text = "Offshore Cost Agenda: =>";

            OpexFectoImprovementActualPotential oSummary = _opportunityCostHelper.ObjGetOpExFectoImprovementByAssetYear(oTrans.tYear().iYear, (int)ItemStatus.ItStatus.Offshore);

            SummaryCalculation(oSummary);
            
            ////decimal dPercSavings = ((oSummary.dActSavings / oSummary.dOpex) * 100);
            //decimal dPercSavings = (oSummary.dOpex != 0) ? ((oSummary.dActSavings / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
            //decimal dPercImprOppr = (oSummary.dOpex != 0) ? ((oSummary.dImprovement / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
            //lblPercentageSavings0.Text = stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";
            
            //lblOpex0.Text = "OP " + (OpportunityCostHelper.iYear - 1).ToString().Remove(0, 2) + ": "; lblOpex0.ForeColor = System.Drawing.Color.Red;
            //lblOpexResult0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dOpex);
            //lblOpexResult0.ForeColor = (chkAbsVal.Checked) ? System.Drawing.Color.Red : lblOpexResult0.ForeColor = System.Drawing.Color.White;
            
            /////Actual Cost Saved (Deep Dive Banked)
            //lblActual0.Text = (chkAbsVal.Checked)
            //    ? stringRoutine.formatAsBankMoney("$", oSummary.dActSavings)
            //    : stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %"; 
            //lblActual0.ForeColor = System.Drawing.Color.Green;

            /////Improvement Opportunity
            //lblImproved0.Text = (chkAbsVal.Checked)
            //    ? stringRoutine.formatAsBankMoney("$", oSummary.dImprovement)
            //    : stringRoutine.formatAsBankMoney(Math.Round(dPercImprOppr, 2)) + " %";

            DataTable dt = _opportunityCostHelper.dtGetAssetsByOnshoreOffshoreByYear((int)ItemStatus.ItStatus.Offshore, oTrans.tYear().iYear);
            
            pnlView.Visible = false;

            RepeaterImages.DataSource = dt;
            RepeaterImages.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void lnkPD_Click(object sender, EventArgs e)
    {
        try
        {
            pnlSummary.Visible = true;
            pnlGraph.Visible = false;
            pnlPDReportSummary.Visible = false;
            lblTitle.Text = "PD Performance: =>";

            OpexFectoImprovementActualPotential oSummary = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(oTrans.tYear().iYear);

            SummaryCalculation(oSummary);

            //lblOpex0.Text = "OP " + (OpportunityCostHelper.iYear - 1).ToString().Remove(0, 2) + ": "; lblOpex0.ForeColor = System.Drawing.Color.Red;
            //lblOpexResult0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dOpex); lblOpexResult0.ForeColor = System.Drawing.Color.Red;
            //lblActual0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dActSavings); lblActual0.ForeColor = System.Drawing.Color.Green;

            ////decimal dPercSavings = ((oSummary.dActSavings / oSummary.dOpex) * 100);
            //decimal dPercSavings = (oSummary.dOpex != 0) ? ((oSummary.dActSavings / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
            //lblPercentageSavings0.Text = stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";

            //lblImproved0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dImprovement);

            DataTable dt = _opportunityCostHelper.dtGetAssetsByYear(oTrans.tYear().iYear);
            pnlView.Visible = false;

            RepeaterImages.DataSource = dt;
            RepeaterImages.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        //Response.Redirect("~/PDCCIndex.aspx");
    }

    private void SummaryCalculation(OpexFectoImprovementActualPotential oSummary)
    {
        //decimal dPercSavings = ((oSummary.dActSavings / oSummary.dOpex) * 100);
        decimal dPercSavings = (oSummary.dOpex != 0) ? ((oSummary.dActSavings / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
        decimal dPercImprOppr = (oSummary.dOpex != 0) ? ((oSummary.dImprovement / oSummary.dOpex) * 100) : 0; // When divisor is not equal to zero
        lblPercentageSavings0.Text = stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";

        lblOpex0.Text = "OP " + (oTrans.tYear().iYear - 1).ToString().Remove(0, 2) + ": "; lblOpex0.ForeColor = System.Drawing.Color.Red;
        lblOpexResult0.Text = stringRoutine.formatAsBankMoney("$", oSummary.dOpex);
        lblOpexResult0.ForeColor = (oSessnx.getOnlineUser.m_iCostSavingAbsVal == 1) ? System.Drawing.Color.Red : lblOpexResult0.ForeColor = System.Drawing.Color.White;

        ///Actual Cost Saved (Deep Dive Banked)
        lblActual0.Text = (oSessnx.getOnlineUser.m_iCostSavingAbsVal == 1)
            ? stringRoutine.formatAsBankMoney("$", oSummary.dActSavings)
            : stringRoutine.formatAsBankMoney(Math.Round(dPercSavings, 2)) + " %";
        lblActual0.ForeColor = System.Drawing.Color.Green;

        ///Improvement Opportunity
        lblImproved0.Text = (oSessnx.getOnlineUser.m_iCostSavingAbsVal == 1)
            ? stringRoutine.formatAsBankMoney("$", oSummary.dImprovement)
            : stringRoutine.formatAsBankMoney(Math.Round(dPercImprOppr, 2)) + " %";
    }

    protected void grdViewDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    private void ExporttoExcel(List<OpportunityCost> lstOpportunityCosts)
    {
        appUsersHelper oUsers = new appUsersHelper();

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:12.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
          "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
          "style='font-size:12.0pt; font-family:Calibri; background:white;'> <TR>");

        //Get column headers  and make it as bold in excel columns
        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("ID No");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Department");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Asset");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Opportunity");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Cost Centre");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Sponsor");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Action Party");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        string sOpexYear = "";
        sOpexYear = OpportunityCostHelper.getSOpexYear(sOpexYear);
        HttpContext.Current.Response.Write(sOpexYear);
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Accept/Park");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Priority");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Front End Cost Take Out (F$)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Improvement");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Asset/Support Services");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Potential Savings (F$)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Actual Savings (F$)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Started By");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Complete By");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Work Scope");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Comments");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("</TR>");

        foreach (OpportunityCost oOpportunityCost in lstOpportunityCosts)
        {
            HttpContext.Current.Response.Write("<TR>");
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sSerialNo);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sDepartment);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sAsset);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sOpportunity);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sCostCentre);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(oOpportunityCost.iSponsor).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(oOpportunityCost.iActionParty).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dOpexYear));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(AcceptPark(oOpportunityCost.iAcceptPark));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.iPriority);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dFecto));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dImprovement));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(AssetSupport(oOpportunityCost.iAsService));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dPotSavings));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dActSavings));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(dateRoutine.dateOracle(oOpportunityCost.dtStartedBy));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(dateRoutine.dateOracle(oOpportunityCost.dtCompletedBy));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sWorkScope);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sComments);
            HttpContext.Current.Response.Write("</Td>");
            HttpContext.Current.Response.Write("</TR>");
        }

        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    private void ExportSummaryReportToExcel(List<OpportunityCost> lstOpportunityCosts)
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
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:12.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
          "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
          "style='font-size:12.0pt; font-family:Calibri; background:white;'> <TR>");

        //Get column headers  and make it as bold in excel columns
        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("ID No");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Department");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Asset");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Opportunity");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        string sOpexYear = "";
        sOpexYear = OpportunityCostHelper.getSOpexYear(sOpexYear);
        HttpContext.Current.Response.Write(sOpexYear);
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Banked ($)");//Actual Savings (F$)
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("%age Banked");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Opportunities($)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("B&O ($)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("25% Target Reduction($)");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Current Gap($) excl. Oppor.");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("</TR>");

        foreach (OpportunityCost oOpportunityCost in lstOpportunityCosts)
        {
            SummaryReport oSummaryReport = _opportunityCostHelper.GetItemsStringValues2(oOpportunityCost.dOpexYear, oOpportunityCost.dActSavings, oOpportunityCost.dImprovement);

            HttpContext.Current.Response.Write("<TR>");
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sSerialNo);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sDepartment);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sAsset);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oOpportunityCost.sOpportunity);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dOpexYear));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dActSavings));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oSummaryReport.dPercentageBanked));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oOpportunityCost.dImprovement));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oSummaryReport.dBO));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oSummaryReport.dReduction));
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(oSummaryReport.dCurrentGap));
            HttpContext.Current.Response.Write("</Td>");
            HttpContext.Current.Response.Write("</TR>");
        }

        decimal dOpexYear = 0; decimal dActSavings = 0; decimal dImprovement = 0; decimal dPercentageBanked = 0; decimal dBO = 0; decimal dReduction = 0; decimal dCurrentGap = 0;
        foreach (OpportunityCost oOpportunityCost in lstOpportunityCosts)
        {
            SummaryReport oSummaryReport = _opportunityCostHelper.GetItemsStringValues2(oOpportunityCost.dOpexYear, oOpportunityCost.dActSavings, oOpportunityCost.dImprovement);
            dOpexYear += oOpportunityCost.dOpexYear;
            dActSavings += oOpportunityCost.dActSavings;
            dImprovement += oOpportunityCost.dImprovement;
            dPercentageBanked += oSummaryReport.dPercentageBanked;
            dBO += oSummaryReport.dBO;
            dReduction += oSummaryReport.dReduction;
            dCurrentGap += oSummaryReport.dCurrentGap;
        }
        HttpContext.Current.Response.Write("<TR>");
        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write("");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write("");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write("");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write("Total");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(dOpexYear));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(dActSavings));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(dPercentageBanked));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(dImprovement));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(dBO));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(dReduction));
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td style='background-color:Silver'>");
        HttpContext.Current.Response.Write(stringRoutine.formatAsBankMoney(dCurrentGap));
        HttpContext.Current.Response.Write("</Td>");
        HttpContext.Current.Response.Write("</TR>");

        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    private string AcceptPark(int iAcceptPark)
    {
        string sResult = "";

        if (iAcceptPark == (int)ItemStatus.ItStatus.Accept) sResult = ItemStatus.status(ItemStatus.ItStatus.Accept);
        else if (iAcceptPark == (int)ItemStatus.ItStatus.Park) sResult = ItemStatus.status(ItemStatus.ItStatus.Park);
        else if (iAcceptPark == (int)ItemStatus.ItStatus.Done) sResult = ItemStatus.status(ItemStatus.ItStatus.Done);

        return sResult;
    }

    private string AssetSupport(int iAssetSupport)
    {
        string sResult = "";

        if (iAssetSupport == (int)ItemStatus.ItStatus.All) sResult = ItemStatus.status(ItemStatus.ItStatus.All);
        else if (iAssetSupport == (int)ItemStatus.ItStatus.Offshore) sResult = ItemStatus.status(ItemStatus.ItStatus.Offshore);
        else if (iAssetSupport == (int)ItemStatus.ItStatus.Onshore) sResult = ItemStatus.status(ItemStatus.ItStatus.Onshore);
        else if (iAssetSupport == (int)ItemStatus.ItStatus.OnShoreOffShore) sResult = ItemStatus.status(ItemStatus.ItStatus.OnShoreOffShore);

        return sResult;
    }

    protected void lnkPDDash_Click(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iCostSavingAbsVal != 1)
        {
            ajaxWebExtension.showJscriptAlert(Page, this,
                "Sorry, you do not have right to View Performance Summary Dashboard!!! For view right, call support.");
        }
        else
        {
            //pnlGraph.Visible = true;
            pnlPDReportSummary.Visible = true;
            pnlView.Visible = false;
            pnlGraph.Visible = false;
            pnlSummary.Visible = false;
            //CharttingT.Init_Page(System.OpportunityCostHelper.iYear);
            //Chartting1.Init_Page(System.OpportunityCostHelper.iYear);
            //Load Asset Services
            grdView.DataSource = AssetServices.DtGetServices();
            grdView.DataBind();

            LoadPDSummary();
            //LoadGrid();
            //PDPerformance.LoadPDSummaryPerformance(System.OpportunityCostHelper.iYear);
        }
    }

    //private void PDSummaryCostReduction()
    //{
    //    //OpexDDBankedTabPanel
    //}

    //GraphAjaxTabContainer_ActiveTabChanged
    //protected void GraphAjaxTabContainer_ActiveTabChanged(object sender, EventArgs e)
    //{
    //    if (GraphAjaxTabContainer.ActiveTabIndex == 1) { }
    //    else if (GraphAjaxTabContainer.ActiveTabIndex == 2) { }
    //    else if (GraphAjaxTabContainer.ActiveTabIndex == 3) { }
    //    else if (GraphAjaxTabContainer.ActiveTabIndex == 4) { }
    //    else if (GraphAjaxTabContainer.ActiveTabIndex == 5) { }
    //    else if (GraphAjaxTabContainer.ActiveTabIndex == 6) { }
    //    else if (GraphAjaxTabContainer.ActiveTabIndex == 7) { }
    //}

    private void LoadPDSummary()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbService = (Label)grdRow.FindControl("lbService");
            int iServiceId = int.Parse(lbService.Attributes["IDSERVICE"].ToString());

            ASP.app_pdcc_usercontrol_pdsummarycostredn_ascx oPdSummary = (ASP.app_pdcc_usercontrol_pdsummarycostredn_ascx)grdRow.FindControl("PDSummaryCostRednT");
            oPdSummary.Init_Page(iServiceId, oTrans.tYear().iYear);
        }

        //PDPerformance.PDPerformance(System.OpportunityCostHelper.iYear);

        PDPerformance.LoadPDSummaryPerformance(oTrans.tYear().iYear);
        PDCostSummary.PDPerformance(oTrans.tYear().iYear);
    }

    //private void LoadGrid()
    //{
    //    DataTable dt = _Department.dtGetPdccDeparmentsThatHaveData(); //dtGetPdccDeparments

    //    grdView.DataSource = dt;
    //    grdView.DataBind();

    //    LoadGridData();
    //}

    //private void LoadGridData()
    //{
    //    try
    //    {
    //        foreach (GridViewRow grdRow in grdView.Rows)
    //        {
    //            Label lbDepartment = (Label)grdRow.FindControl("lbDepartment");
    //            int iDeptId = int.Parse(lbDepartment.Attributes["IDDEPARTMENT"].ToString());

    //            ASP.app_pdcc_usercontrol_charttingdatant_ascx oCharttingData = (ASP.app_pdcc_usercontrol_charttingdatant_ascx)grdRow.FindControl("CharttingData1");
    //            oCharttingData.LoadDataByDepartment(OpportunityCostHelper.iYear, iDeptId);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}
    protected void grdView_Load(object sender, EventArgs e)
    {

    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    //protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
    //    int i;
    //    //'Make the selected menu item reflect the correct imageurl
    //    //for (i = 0; (Menu1.Items.Count - 1) > i; i++)
    //    //{
    //    if (Convert.ToInt32(e.Item.Value) == 0)
    //    {
    //        LineGraph.PDEstimateActualCummulativeLineGraph(OpportunityCostHelper.iYear);
    //        //BarGraph.PDEstimateActualAbsoluteBarGraph(OpportunityCostHelper.iYear);
    //        //CummulativeBarGraph.PDEstimateActualCummulativeBarGraph(OpportunityCostHelper.iYear);

    //        //Menu1.Items[i].ImageUrl = "selectedtab.gif";

    //        //<asp:MenuItem Text="PD Cummulative" Value="0"></asp:MenuItem>
    //        //<asp:MenuItem Text="3 Part Oppor." Value="1"></asp:MenuItem>
    //        //<asp:MenuItem Text="%DD Banked" Value="2"></asp:MenuItem>
    //        //<asp:MenuItem Text="%Savings Banked" Value="3"></asp:MenuItem>
    //        //<asp:MenuItem Text="%EIO Banked" Value="4"></asp:MenuItem>
    //        //<asp:MenuItem Text="Cumm. MP Savings" Value="5"></asp:MenuItem>
    //        //<asp:MenuItem Text="Savings Summary" Value="6"></asp:MenuItem>
    //    }
    //    else if (Convert.ToInt32(e.Item.Value) == 1)
    //    {
    //        //Menu1.Items[i].ImageUrl = "unselectedtab.gif";
    //    }
    //    else if (Convert.ToInt32(e.Item.Value) == 2)
    //    {
    //        PercDDBanked.PercentageDDBankedPercSavingsTarget(OpportunityCostHelper.iYear);
    //        //Menu1.Items[i].ImageUrl = "unselectedtab.gif";
    //    }
    //    else if (Convert.ToInt32(e.Item.Value) == 3)
    //    {
    //        PercSavingBankedVsSavingsTarget.PercentageSavingsBankedPercSavingsTarget(OpportunityCostHelper.iYear);
    //        //Menu1.Items[i].ImageUrl = "unselectedtab.gif";
    //    }
    //    else if (Convert.ToInt32(e.Item.Value) == 4)
    //    {
    //        PercEIOBanked.PercentageEIOBanked(OpportunityCostHelper.iYear);
    //        //Menu1.Items[i].ImageUrl = "unselectedtab.gif";
    //    }
    //    else if (Convert.ToInt32(e.Item.Value) == 5)
    //    {
    //        //Menu1.Items[i].ImageUrl = "unselectedtab.gif";
    //    }
    //    else if (Convert.ToInt32(e.Item.Value) == 6)
    //    {
    //        //Menu1.Items[i].ImageUrl = "unselectedtab.gif";
    //    }
    //    //}
    //    //For i = 0 To Menu1.Items.Count - 1
    //    //    If i = e.Item.Value Then
    //    //        Menu1.Items(i).ImageUrl = "selectedtab.gif"
    //    //    Else
    //    //        Menu1.Items(i).ImageUrl = "unselectedtab.gif"
    //    //    End If
    //    //Next
    //}
    
    protected void lnkPDSavingsLineGraph_Click(object sender, EventArgs e)
    {
        //GraphAjaxTabContainer.ActiveTabIndex = 0;
        LineGraph.PDEstimateActualCummulativeLineGraph(oTrans.tYear().iYear);
    }

    //protected void lnkOpexDDBanked_Click(object sender, EventArgs e)
    //{
    //    GraphAjaxTabContainer.ActiveTabIndex = 1;
    //    //CummulativeBarGraph.PDEstimateActualCummulativeBarGraph(OpportunityCostHelper.iYear);
    //}
    protected void showGraphLinkButton_Click(object sender, EventArgs e)
    {
        //GraphAjaxTabContainer.ActiveTabIndex = 2;
        //BarGraph.PDEstimateActualAbsoluteBarGraph(OpportunityCostHelper.iYear);
    }
    
    //protected void lnkDDBanked_Click(object sender, EventArgs e)
    //{
    //    GraphAjaxTabContainer.ActiveTabIndex = 3;
        
    //}
    
    protected void lnkPercDDBanked_Click(object sender, EventArgs e) 
    {
        //GraphAjaxTabContainer.ActiveTabIndex = 2;
        //PercDDBanked.PercentageDDBankedPercSavingsTarget(OpportunityCostHelper.iYear);
    }
    protected void lnkPercSavingsBanked_Click(object sender, EventArgs e) 
    {
        //GraphAjaxTabContainer.ActiveTabIndex = 3;
        //PercSavingBankedVsSavingsTarget.PercentageSavingsBankedPercSavingsTarget(OpportunityCostHelper.iYear);
    }
    protected void lnkPercEIOBanked_Click(object sender, EventArgs e) 
    {
        //GraphAjaxTabContainer.ActiveTabIndex = 4;
        //PercEIOBanked.PercentageEIOBanked(OpportunityCostHelper.iYear);
    }
    protected void lnkMPSavings_Click(object sender, EventArgs e) 
    {
        //GraphAjaxTabContainer.ActiveTabIndex = 5;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        int iAssetId = int.Parse(iAssetIdHF.Value);
        List<OpportunityCost> lstOpportunityCost = _opportunityCostHelper.lstGetOpportunityCostByAsset(iAssetId, oTrans.tYear().iYear);

        ExporttoExcel(lstOpportunityCost);
    }

    protected void btnSummaryExport_Click(object sender, EventArgs e)
    {
        int iAssetId = int.Parse(iAssetIdHF.Value);
        List<OpportunityCost> lstOpportunityCost = _opportunityCostHelper.lstGetOpportunityCostByAsset(iAssetId, oTrans.tYear().iYear);

        ExportSummaryReportToExcel(lstOpportunityCost);
    }
    protected void chkAbsVal_CheckedChanged(object sender, EventArgs e)
    {
        ajaxWebExtension.showJscriptAlert(Page, this,
            !string.IsNullOrEmpty(oSessnx.getOnlineUser.m_iUserId.ToString())
                ? "Absolute value enabled."
                : "You do not have the privilege to view absolute values. Contact support.");
    }
}