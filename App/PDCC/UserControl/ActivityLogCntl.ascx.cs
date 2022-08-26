using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
//using System.Web.UI.DataVisualization.Charting;
using FusionCharts.Charts;

public partial class App_PDCC_UserControl_ActivityLogCntl : System.Web.UI.UserControl
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public void InitPage()
    {
        if (Request.QueryString["lOpCost"] != null)
        {
            long lOpCost = long.Parse(Request.QueryString["lOpCost"]);

            OpportunityCostHelper.getOpexYear(lblOpex);
            RetrieveData(lOpCost);

            //if (Request.QueryString["iMonth"] != null)
            //{
            //    int iMonth = int.Parse(Request.QueryString["iMonth"]);
            //    RetrieveData(lOpCost);
            //}
            //else
            //{
            //    RetrieveData(lOpCost);
            //}
        }
    }

    //public void InitPage()
    //{
    //    if (Request.QueryString["lOpCost"] != null)
    //    {
    //        OpportunityCostHelper.getOpexYear(lblOpex);
    //        long lOpCost = long.Parse(Request.QueryString["lOpCost"]);
    //        RetrieveData(lOpCost);
    //    }
    //}

    private void RetrieveData(long lOpCost)
    {
        OpportunityCost oOpportunityCost = _opportunityCostHelper.ObjGetOpportunityCostById(lOpCost);

        lblAssett.Text = AssetPdcc.objGetAssetById(oOpportunityCost.iAssetId).sAsset;

        lblOpexValue.Text = stringRoutine.formatAsBankMoney(oOpportunityCost.dOpexYear);
        lblActSavings.Text = stringRoutine.formatAsBankMoney(oOpportunityCost.dActSavings);
        lblPotSavings.Text = stringRoutine.formatAsBankMoney(oOpportunityCost.dPotSavings);
        lblFecto.Text = stringRoutine.formatAsBankMoney(oOpportunityCost.dFecto);
        lblImprovement.Text = stringRoutine.formatAsBankMoney(oOpportunityCost.dImprovement);

        lblAsset.Text = oOpportunityCost.sAsset;
        lblWorkScope.Text = oOpportunityCost.sWorkScope;

        lblAcceptPark.Text = oOpportunityCost.iAcceptPark.ToString();
        lblActionParty.Text = oOpportunityCost.iActionParty.ToString();
        lblAserv.Text = oOpportunityCost.iAsService.ToString();
        lblPriority.Text = oOpportunityCost.iPriority.ToString();
        lblSponsor.Text = oOpportunityCost.iSponsor.ToString();
        lblComments.Text = oOpportunityCost.sComments;
        lblCostCentre.Text = oOpportunityCost.sCostCentre;
        lblOpportunity.Text = oOpportunityCost.sOpportunity;
        lblOpportunityTitle.Text = oOpportunityCost.sOpportunity;

        GetItemsStringValues();

        PlotGraphs(oOpportunityCost);

        if (!string.IsNullOrEmpty(oOpportunityCost.dtCompletedBy.ToString())) lblCompleteBy.Text = dateRoutine.dateShort(DateTime.Parse(oOpportunityCost.dtCompletedBy.ToString()));
        if (!string.IsNullOrEmpty(oOpportunityCost.dtStartedBy.ToString())) lblStartBy.Text = dateRoutine.dateShort(DateTime.Parse(oOpportunityCost.dtStartedBy.ToString()));

        //DateTime.Parse(oOpportunityCost.dtCompletedBy.ToString()).ToString("dd/MM/yyyy");  oOpportunityCost.dtCompletedBy.ToString();
        //DateTime.Parse(oOpportunityCost.dtStartedBy.ToString()).ToString("dd/MM/yyyy"); //oOpportunityCost.dtStartedBy.ToString();
    }

    private void GetItemsStringValues()
    {
        appUsersHelper oAppUserHelper = new appUsersHelper();
        Department oDepartment = new Department();
        //lblDepartment.Text = oDepartment.objGetDeparmentById(int.Parse(lblDepartment.Text)).m_sDepartment;

        if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Accept) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Accept);
        else if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Park) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Park);
        else if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Done) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Done);

        if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.All) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.All);
        else if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.Offshore) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.Offshore);
        else if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.Onshore) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.Onshore);
        else if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.OnShoreOffShore) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.OnShoreOffShore);

        lblSponsor.Text = oAppUserHelper.objGetUserByUserID(int.Parse(lblSponsor.Text)).m_sFullName;
        lblActionParty.Text = oAppUserHelper.objGetUserByUserID(int.Parse(lblActionParty.Text)).m_sFullName;
    }

    private void PlotGraphs(OpportunityCost oOpportunityCost)
    {
        createGraph(oOpportunityCost, oOpportunityCost.sOpportunity);
        //OpportunityCost oOpportunityCost = _opportunityCostHelper.ObjGetOpportunityCostBySerialNo(sSerialNo);

        //Charter(cReport, oOpportunityCost, oOpportunityCost.sOpportunity, 300, 500);

        //OpexFectoImprovementActualPotential objOffShore = _OpportunityCostHelper.ObjGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Offshore);
        //Charter(cSNEPCOReport, objOffShore, "SNEPCo PD", 400, 500);

        //OpexFectoImprovementActualPotential objOffShoreOnShore = _OpportunityCostHelper.ObjGetOpExFectoImprovementByYear(iYear);
        //Charter(cCombinedReporter, objOffShoreOnShore, "SPDC + SNEPCo PD", 600, 900);
    }

    private void createGraph(OpportunityCost objData, string sChartTitle)
    {
        decimal CummVal = objData.dFecto + objData.dImprovement;

        string strXML = null;

        strXML = @"<chart caption='" + sChartTitle + "' subcaption='$mln' yaxisname='(F$mln)' palette='1' animation='1' formatnumberscale='0' numberprefix='$' showvalues='0' seriesnameintooltip='0' showborder='0'>";
        strXML += "<categories>";
        strXML += "<category label='OP" + (oTrans.tYear().iYear - 1).ToString().Remove(0, 2) + "' />";
        strXML += "<category label='FEC T/O' />";
        strXML += "<category label='Impr. Opp' />";
        strXML += "<category label='Cumm' />";
        strXML += "<category label='Actual' />";
        strXML += "<category label='Red. Target' />";
        strXML += "</categories>";

        decimal OpexYear = objData.dOpexYear;
        decimal Fecto = objData.dFecto;
        decimal Improvement = objData.dImprovement;
        decimal Cummulative = objData.dFecto + objData.dImprovement;
        decimal Actual = objData.dActSavings;

        decimal dPercRed = decimal.Parse("25") / 100;
        decimal ReducedTarget = objData.dOpexYear * dPercRed;

        strXML += "<dataset seriesname='Bar'>";
        strXML += "<set value='" + OpexYear + "' />";
        strXML += "<set value='" + Fecto + "' />";
        strXML += "<set value='" + Improvement + "' />";
        strXML += "<set value='" + Cummulative + "' />";
        strXML += "<set value='" + Actual + "' />";
        strXML += "<set value='" + ReducedTarget + "' />";
        strXML += "</dataset>";

        strXML += "<dataset seriesname='Line' parentyaxis='S' renderas='Line'>";
        strXML += "<set value='" + OpexYear + "' />";
        strXML += "<set value='" + Fecto + "' />";
        strXML += "<set value='" + Improvement + "' />";
        strXML += "<set value='" + Cummulative + "' />";
        strXML += "<set value='" + Actual + "' />";
        strXML += "<set value='" + ReducedTarget + "' />";
        strXML += "</dataset>";
        strXML += "</chart>";

        // Initialize the chart.
        Chart factoryOutput = new Chart("MSColumnLine3D", "myChart", "500", "350", "xml", strXML);
        //msline
        //stackedcolumn2d
        //column2d
        //msstackedcolumn2d

        // Render the chart.

        FCLiteral.Text = factoryOutput.Render();
    }

    //private void Charter(PlaceHolder oPlaceHolder, OpportunityCost objData, string sChartTitle, int iHeight, int iWidth)
    //{
    //    try
    //    {
    //        decimal CummVal = objData.dFecto + objData.dImprovement;

    //        //create the chart ---------------------------- '
    //        Chart myChart = new Chart();
    //        oPlaceHolder.Controls.Add(myChart);

    //        myChart.Height = Unit.Pixel(iHeight);
    //        myChart.Width = Unit.Pixel(iWidth);

    //        //myChart.Series[0]["PointWidth"] = "0.8";
    //        myChart.Titles.Add(sChartTitle);

    //        //create the ChartArea - needed to plot data onto '
    //        ChartArea ca = new ChartArea();
    //        ca.Name = "ChartArea1";
    //        ca.AxisY.Title = "F($)mln";
    //        ca.AxisX.Interval = 1;
    //        myChart.ChartAreas.Add(ca);


    //        //Plot "OPEX" data column from our datatable '
    //        Series OpexSeries = new Series();
    //        OpexSeries.Name = "OP" + (DateTime.Now.Year - 1).ToString().Remove(0, 2);
    //        OpexSeries.ChartType = SeriesChartType.Column;
    //        OpexSeries.Color = System.Drawing.Color.Brown;
    //        OpexSeries.BorderWidth = 3;
    //        OpexSeries.IsValueShownAsLabel = true;
    //        myChart.Series.Add(OpexSeries);

    //        DataPoint opex = new DataPoint();
    //        opex.SetValueY(Math.Round((objData.dOpexYear / 1000), 0)); opex.AxisLabel = OpexSeries.Name;
    //        OpexSeries.Points.Add(opex);


    //        //Plot "FECTO" data column from our datatable '
    //        Series FectoSeries = new Series();
    //        FectoSeries.Name = "FEC T/O";
    //        FectoSeries.ChartType = SeriesChartType.Column;
    //        FectoSeries.Color = System.Drawing.Color.Navy;
    //        FectoSeries.BorderWidth = 3;
    //        FectoSeries.IsValueShownAsLabel = true;
    //        myChart.Series.Add(FectoSeries);

    //        DataPoint fecto = new DataPoint();
    //        fecto.SetValueY(Math.Round((objData.dFecto / 1000), 0)); fecto.AxisLabel = FectoSeries.Name;
    //        FectoSeries.Points.Add(fecto);

    //        //Plot "IMPROVEMENT" data column from our datatable '
    //        Series ImprovementSeries = new Series();
    //        ImprovementSeries.Name = "Impr. Opp";
    //        ImprovementSeries.ChartType = SeriesChartType.Column;
    //        ImprovementSeries.Color = System.Drawing.Color.OrangeRed;
    //        ImprovementSeries.BorderWidth = 3;
    //        ImprovementSeries.IsValueShownAsLabel = true;
    //        myChart.Series.Add(ImprovementSeries);

    //        DataPoint improve = new DataPoint();
    //        improve.SetValueY(Math.Round((objData.dImprovement / 1000), 0)); improve.AxisLabel = ImprovementSeries.Name;
    //        ImprovementSeries.Points.Add(improve);

    //        //Plot "CUMMULATIVE" data column from our datatable '
    //        Series CummSeries = new Series();
    //        CummSeries.Name = "Cumm";
    //        CummSeries.ChartType = SeriesChartType.Column;
    //        CummSeries.Color = System.Drawing.Color.Pink;
    //        CummSeries.BorderWidth = 3;
    //        CummSeries.IsValueShownAsLabel = true;
    //        myChart.Series.Add(CummSeries);

    //        DataPoint Cumm = new DataPoint();
    //        Cumm.SetValueY(Math.Round(((objData.dFecto + objData.dImprovement) / 1000), 0)); Cumm.AxisLabel = CummSeries.Name;
    //        CummSeries.Points.Add(Cumm);

    //        //Plot "ACTSAVINGS" data column from our datatable '
    //        Series ActualSeries = new Series();
    //        ActualSeries.Name = "Actual";
    //        ActualSeries.ChartType = SeriesChartType.Column;
    //        ActualSeries.Color = System.Drawing.Color.Gray;
    //        ActualSeries.BorderWidth = 3;
    //        ActualSeries.IsValueShownAsLabel = true;
    //        myChart.Series.Add(ActualSeries);

    //        DataPoint Actual = new DataPoint();
    //        Actual.SetValueY(Math.Round((objData.dActSavings / 1000), 0)); Actual.AxisLabel = ActualSeries.Name;
    //        ActualSeries.Points.Add(Actual);

    //        //Plot "POTSAVINGS" data column from our datatable '
    //        Series PotentialSeries = new Series();
    //        PotentialSeries.Name = "Red. Target";
    //        PotentialSeries.ChartType = SeriesChartType.Column;
    //        PotentialSeries.Color = System.Drawing.Color.Orange;
    //        PotentialSeries.BorderWidth = 3;
    //        PotentialSeries.IsValueShownAsLabel = true;
    //        myChart.Series.Add(PotentialSeries);

    //        decimal dPercRed = decimal.Parse("25") / 100;

    //        DataPoint Potential = new DataPoint();
    //        decimal oResult = (objData.dOpexYear * dPercRed) / 1000;
    //        //Potential.SetValueY(oResult); Potential.AxisLabel = PotentialSeries.Name;
    //        Potential.SetValueY(Math.Round(oResult, 0)); Potential.AxisLabel = PotentialSeries.Name;
    //        PotentialSeries.Points.Add(Potential);


    //        //Add a Legend
    //        myChart.Legends.Add(new Legend("Legend1"));
    //        OpexSeries.LegendText = OpexSeries.Name;
    //        FectoSeries.LegendText = FectoSeries.Name;
    //        ImprovementSeries.LegendText = ImprovementSeries.Name;
    //        CummSeries.LegendText = CummSeries.Name;
    //        ActualSeries.LegendText = ActualSeries.Name;
    //        PotentialSeries.LegendText = PotentialSeries.Name;

    //        //chart background colour
    //        myChart.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee");

    //        //chart background shadow
    //        ca.ShadowOffset = 5;
    //        ca.ShadowColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");

    //        //' chart background gradient
    //        ca.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
    //        ca.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#ddddee");
    //        ca.BackGradientStyle = System.Web.UI.DataVisualization.Charting.GradientStyle.TopBottom;

    //        //' format the chart gridlines
    //        ca.AxisX.LabelStyle.Angle = -45;
    //        ca.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
    //        ca.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

    //        ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
    //        ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

    //        ////apply gradient colours to OpexSeries column '
    //        //OpexSeries.BackGradientStyle = GradientStyle.TopBottom;
    //        //OpexSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
    //        //OpexSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

    //        ////apply gradient colours to FectoSeries column '
    //        //FectoSeries.BackGradientStyle = GradientStyle.TopBottom;
    //        //FectoSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
    //        //FectoSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

    //        ////apply gradient colours to ImprovementSeries column '
    //        //ImprovementSeries.BackGradientStyle = GradientStyle.TopBottom;
    //        //ImprovementSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
    //        //ImprovementSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

    //        ////apply gradient colours to CummSeries column '
    //        //CummSeries.BackGradientStyle = GradientStyle.TopBottom;
    //        //CummSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
    //        //CummSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

    //        myChart.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        long lOpCost = long.Parse(Request.QueryString["lOpCost"]);
        Response.Redirect("~/App/PDCC/EditPdcc.aspx" + "?lOpCost=" + lOpCost, false);
        //Response.Redirect("~/App/PDCC/EditPdcc.aspx" + "?lOpCost=" + lOpCost + "&iAst=" + ddlAsset.SelectedValue, false);
    }

    public Button oUpdateButton
    {
        get
        {
            Button Update = (Button)btnUpdate;
            return Update;
        }
    }

}