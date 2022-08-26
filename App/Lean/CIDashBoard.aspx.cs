using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.DataVisualization.Charting;
using Microsoft.VisualBasic;

public partial class App_Lean_CIDashBoard : System.Web.UI.Page
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    BenefitActualsHelper oBenefitActualsHelper = new BenefitActualsHelper();
    IdentifyHelper oIdentifyHelper = new IdentifyHelper();
    EliminateHelper oEliminateHelper = new EliminateHelper();
    SustainHelper oSustainHelper = new SustainHelper();
    AssessmentHelper oAssessmentHelper = new AssessmentHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                List<int> iYears = oMainProjectHelper.lstYears();
                foreach (int iYear in iYears)
                {
                    ddlYear.Items.Add(iYear.ToString());
                }

                ddlYear.SelectedValue = DateTime.Today.Year.ToString();

                NoOfProjectsByYear();
                LoadProjectsWorkDoneByFunction();
                LoadProjectMaturationPhase();
                LoadProjectBenefitsByYear();
                LoadOngoingAndCompletedProjects();
                LoadProjectAssessment();
                //Load Training and Certification

            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(AppConfiguration.LeanSiteName, ex.ToString());
            }
        }

        hpkFunctionWorkDone.NavigateUrl = "~/Handlers/pckStreamer.ashx?Msg=WrkDn&iYr=" + ddlYear.SelectedValue;
        HpkProjectStatus.NavigateUrl = "~/Handlers/pckStreamer.ashx?Msg=prjmatrphs&iYr=" + ddlYear.SelectedValue;
        HPKBenefit.NavigateUrl = "~/Handlers/pckStreamer.ashx?Msg=bnft&iYr=" + ddlYear.SelectedValue;
        HPKCompletedOngoing.NavigateUrl = "~/Handlers/pckStreamer.ashx?Msg=prjComOng&iYr=" + ddlYear.SelectedValue;
        HPKProjectBenefit.NavigateUrl = "~/Handlers/pckStreamer.ashx?Msg=prjBnft&iYr=" + ddlYear.SelectedValue;

        LoadBenefits();
        LoadTrainingCertification();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Load Labels
        NoOfProjectsByYear();

        //Load Function's Identify Eliminate and Sustain
        LoadProjectsWorkDoneByFunction();

        //Load Project's-Function Identify Eliminate and Sustain
        LoadProjectMaturationPhase();

        //Ongoing and Completed Projects
        LoadOngoingAndCompletedProjects();

        //Load Project and Benefits
        LoadProjectBenefitsByYear();

        //Load Project Assessment
        LoadProjectAssessment();

        //Load Training and Certification
        LoadTrainingCertification();

        hpkFunctionWorkDone.NavigateUrl = "~/Handlers/pckStreamer.ashx?Msg=WrkDn&iYr=" + ddlYear.SelectedValue;
        HpkProjectStatus.NavigateUrl = "~/Handlers/pckStreamer.ashx?Msg=prjmatrphs&iYr=" + ddlYear.SelectedValue;
    }

    private void LoadOngoingAndCompletedProjects()
    {
        //Note: a Project is completed when the Eliminate Implement Status is Yes

        //grdViewCompletedOngoingProjects.DataSource = oMainProjectHelper.dtGetCompletedAndOngoingProjects(int.Parse(ddlYear.SelectedValue));
        //grdViewCompletedOngoingProjects.DataBind();

        int iTotalProjects = 0;
        int iTotalCompletedProjects = 0;
        int iTotalOngoingStalledProjects = 0;

        decimal iTotalActualCostReduction = 0;
        decimal iTotalActualCycleTime = 0;
        decimal iTotalActualBarrel = 0;

        decimal iTotalPotentialCostReduction = 0;
        decimal iTotalPotentialCycleTime = 0;
        decimal iTotalPotentialBarrel = 0;


        lblYearCompletedOngoing.Text = ddlYear.SelectedValue;
        DataTable dt = oMainProjectHelper.dtGetProjectFunctions(int.Parse(ddlYear.SelectedValue));

        //Completed and Ongoing/Stalled projects.
        dt.Columns.Add("COMPLETED");
        dt.Columns.Add("ONGOING");
        dt.Columns.Add("TOTALPROJECTS");

        dt.Columns.Add("ACTUALBENEFITCR");
        dt.Columns.Add("ACTUALBENEFITCT");
        dt.Columns.Add("ACTUALBENEFITBARREL");

        dt.Columns.Add("POTENTIALBENEFITCR");
        dt.Columns.Add("POTENTIALBENEFITCT");
        dt.Columns.Add("POTENTIALBENEFITBARREL");

        foreach (DataRow dr in dt.Rows)
        {
            int iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());

            MainProjectHelper.CompletedOngoingProjects oCompletedOngoingProjects = oMainProjectHelper.objGetCompletedAndOngoingProjects(int.Parse(ddlYear.SelectedValue), iFunctionId);

            dr["COMPLETED"] = oCompletedOngoingProjects.iCompleted;
            dr["ONGOING"] = oCompletedOngoingProjects.iOngoingStalled;
            dr["TOTALPROJECTS"] = oCompletedOngoingProjects.iTotalProjects;

            dr["ACTUALBENEFITCR"] = Math.Round((oCompletedOngoingProjects.dActualBenefitCR/1000000), 2);
            dr["ACTUALBENEFITCT"] = oCompletedOngoingProjects.dActualBenefitCT;
            dr["ACTUALBENEFITBARREL"] = oCompletedOngoingProjects.dActualBenefitBRRL;
            dr["POTENTIALBENEFITCR"] = Math.Round((oCompletedOngoingProjects.dPotentialBenefitCR/1000000), 2);
            dr["POTENTIALBENEFITCT"] = oCompletedOngoingProjects.dPotentialBenefitCT;
            dr["POTENTIALBENEFITBARREL"] = oCompletedOngoingProjects.dPotentialBenefitBRRL;

            iTotalCompletedProjects += oCompletedOngoingProjects.iCompleted;
            iTotalOngoingStalledProjects += oCompletedOngoingProjects.iOngoingStalled;
            iTotalProjects += oCompletedOngoingProjects.iTotalProjects;

            iTotalActualCostReduction += oCompletedOngoingProjects.dActualBenefitCR;
            iTotalActualCycleTime += oCompletedOngoingProjects.dActualBenefitCT;
            iTotalActualBarrel += oCompletedOngoingProjects.dActualBenefitBRRL;

            iTotalPotentialCostReduction += oCompletedOngoingProjects.dPotentialBenefitCR;
            iTotalPotentialCycleTime += oCompletedOngoingProjects.dPotentialBenefitCT;
            iTotalPotentialBarrel += oCompletedOngoingProjects.dPotentialBenefitBRRL;
        }

        //grdViewCompletedOngoingProjects.HeaderRow.Cells[0].Text = ddlYear.SelectedValue;

        grdViewCompletedOngoingProjects.DataSource = dt;
        grdViewCompletedOngoingProjects.DataBind();

        grdViewCompletedOngoingProjects.FooterRow.Cells[0].Text = "Total";
        grdViewCompletedOngoingProjects.FooterRow.Cells[1].Text = iTotalCompletedProjects.ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[2].Text = (Math.Round((iTotalActualCostReduction/1000000), 2)).ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[3].Text = iTotalActualCycleTime.ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[4].Text = iTotalActualBarrel.ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[5].Text = iTotalOngoingStalledProjects.ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[6].Text = (Math.Round((iTotalPotentialCostReduction/1000000), 2)).ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[7].Text = iTotalPotentialCycleTime.ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[8].Text = iTotalPotentialBarrel.ToString();
        grdViewCompletedOngoingProjects.FooterRow.Cells[9].Text = iTotalProjects.ToString();

        grdViewCompletedOngoingProjects.FooterRow.Font.Bold = true;
        grdViewCompletedOngoingProjects.FooterRow.HorizontalAlign = HorizontalAlign.Right;

        grdViewCompletedOngoingProjects.FooterStyle.BackColor = System.Drawing.Color.DarkOrange;

        ChartCompletedOngoingStallProjects(dt);
    }

    private void LoadBenefits()
    {
        DataTable dt = oMainProjectHelper.dtGetYear();

        //Chart Benefits.       
        try
        {
            dt.Columns.Add("COSTREDUCTION");
            dt.Columns.Add("CYCLETIME");
            dt.Columns.Add("NUMBER");
            dt.Columns.Add("TOTALPROJECTS");

            foreach (DataRow dr in dt.Rows)
            {
                int iYear = int.Parse(dr["YYEAR"].ToString());

                dr["COSTREDUCTION"] = oMainProjectHelper.iTotalCostReductionPerYear(iYear).ToString();
                dr["CYCLETIME"] = oMainProjectHelper.iTotalCycleTimeReductionPerYear(iYear).ToString();
                dr["NUMBER"] = oMainProjectHelper.iNumberofProductionBarrelPerYear(iYear).ToString();
                dr["TOTALPROJECTS"] = oMainProjectHelper.iTotalProjectsByYear(iYear).ToString();
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        grdViewBenefit.DataSource = dt;
        grdViewBenefit.DataBind();
        ChartBenefits(dt);
    }

    private void ChartWorkDone(DataTable dt)
    {
        FunctionMgt oFunctionMgt = new FunctionMgt();

        // Initializes a new instance of the DataSet class
        try
        {
            chartWorkDone.BackGradientStyle = GradientStyle.None;
            chartWorkDone.BackHatchStyle = ChartHatchStyle.None;
            chartWorkDone.Titles.Add("Number of Projects 80-100% Completed By Function - " + ddlYear.SelectedValue);

            //System.Web.UI.DataVisualization.Charting.AxisType.Primary = AxisType.Primary;

            //WorkDone.Palette = ChartColorPalette.SemiTransparent;

            //AddScaleBreaks(chartWorkDone, "WorkDoneChartArea");

            chartWorkDone.ChartAreas["WorkDoneChartArea"].AxisY.Title = "Projects 80-100% Completed";
            chartWorkDone.ChartAreas["WorkDoneChartArea"].AxisY2.Title = "Total Number of Projects";

            //Remove X-Axis Grid lines
            chartWorkDone.ChartAreas["WorkDoneChartArea"].AxisX.MajorGrid.LineWidth = 0;

            //Remove Y-Axis Grid lines
            chartWorkDone.ChartAreas["WorkDoneChartArea"].AxisY.MajorGrid.LineWidth = 0;

            chartWorkDone.ChartAreas["WorkDoneChartArea"].AxisY.Interval = 0;

            string sFunction = "";
            string IdentifySeries = "Identify";
            chartWorkDone.Series.Add(IdentifySeries);
            chartWorkDone.Series[IdentifySeries].ChartType = SeriesChartType.Column;
            chartWorkDone.Series[IdentifySeries].IsVisibleInLegend = true;
            //WorkDone.Series[IdentifySeries].LabelAngle = 60;


            string EliminateSeries = "Eliminate";
            chartWorkDone.Series.Add(EliminateSeries);
            chartWorkDone.Series[EliminateSeries].ChartType = SeriesChartType.Column;
            chartWorkDone.Series[EliminateSeries].IsVisibleInLegend = true;
            //WorkDone.Series[EliminateSeries].LabelAngle = 60;

            string SustainSeries = "Sustain";
            chartWorkDone.Series.Add(SustainSeries);
            chartWorkDone.Series[SustainSeries].ChartType = SeriesChartType.Column;
            chartWorkDone.Series[SustainSeries].IsVisibleInLegend = true;
            //WorkDone.Series[SustainSeries].LabelAngle = 60;

            string ProjectsInHopperSeries = "Total No of Projects";
            chartWorkDone.Series.Add(ProjectsInHopperSeries);
            chartWorkDone.Series[ProjectsInHopperSeries].ChartType = SeriesChartType.Line;
            chartWorkDone.Series[ProjectsInHopperSeries].IsVisibleInLegend = true;
            //WorkDone.Series[ProjectsInHopperSeries].LabelAngle = 60;

            foreach (DataRow dr in dt.Rows)
            {
                sFunction = oFunctionMgt.objGetFunctionById(int.Parse(dr["FUNCTIONID"].ToString())).m_sFunction;
                //Identify
                string IdentifyColumnName = dt.Columns[2].ColumnName;
                decimal YVal1 = (dr.IsNull(2)) ? 0 : decimal.Parse(dr[IdentifyColumnName].ToString());
                chartWorkDone.Series[IdentifySeries].Points.AddXY(sFunction, YVal1);

                //Eliminate
                string EliminateColumnName = dt.Columns[3].ColumnName;
                decimal YVal2 = (dr.IsNull(3)) ? 0 : decimal.Parse(dr[EliminateColumnName].ToString());
                chartWorkDone.Series[EliminateSeries].Points.AddXY(sFunction, YVal2);

                //Sustain
                string SustainColumnName = dt.Columns[4].ColumnName;
                decimal YVal3 = (dr.IsNull(4)) ? 0 : decimal.Parse(dr[SustainColumnName].ToString());
                chartWorkDone.Series[SustainSeries].Points.AddXY(sFunction, YVal3);

                //Total Projects in the Hopper
                string HopperColumnName = dt.Columns[5].ColumnName;
                decimal YVal4 = (dr.IsNull(5)) ? 0 : decimal.Parse(dr[HopperColumnName].ToString());
                chartWorkDone.Series[ProjectsInHopperSeries].Points.AddXY(sFunction, YVal4);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void ChartCompletedOngoingStallProjects(DataTable dt)
    {
        FunctionMgt oFunctionMgt = new FunctionMgt();

        try
        {
            string sFunction = "";
            string CompletedProjects = "Completed";
            chartProjectStatus.BackGradientStyle = GradientStyle.None;
            chartProjectStatus.Titles.Add("Completed and Ongoing/Stalled Projects " + ddlYear.SelectedValue);
            chartProjectStatus.ChartAreas["ProjectStatusChartArea"].AxisY.Title = "Completed and Ongoing/Stalled Projects";
            chartProjectStatus.ChartAreas["ProjectStatusChartArea"].AxisX.Interval = 0;

            //Remove X-Axis Grid lines
            chartProjectStatus.ChartAreas["ProjectStatusChartArea"].AxisX.MajorGrid.LineWidth = 0;

            //Remove Y-Axis Grid lines
            chartProjectStatus.ChartAreas["ProjectStatusChartArea"].AxisY.MajorGrid.LineWidth = 0;

            chartProjectStatus.Series.Add(CompletedProjects);
            chartProjectStatus.Series[CompletedProjects].ChartType = SeriesChartType.Column;
            chartProjectStatus.Series[CompletedProjects].IsVisibleInLegend = true;

            string OngoingStalledProjects = "Ongoing/Stalled";
            chartProjectStatus.Series.Add(OngoingStalledProjects);
            chartProjectStatus.Series[OngoingStalledProjects].ChartType = SeriesChartType.Column;
            chartProjectStatus.Series[OngoingStalledProjects].IsVisibleInLegend = true;

            string TotalProjects = "Total Project";
            chartProjectStatus.Series.Add(TotalProjects);
            chartProjectStatus.Series[TotalProjects].ChartType = SeriesChartType.Column;
            chartProjectStatus.Series[TotalProjects].IsVisibleInLegend = true;

            foreach (DataRow dr in dt.Rows)
            {
                sFunction = oFunctionMgt.objGetFunctionById(int.Parse(dr["FUNCTIONID"].ToString())).m_sFunction;
                //Completed Projects
                string CompletedProjectsColumnName = dt.Columns[2].ColumnName;
                decimal YVal1 = (dr.IsNull(1)) ? 0 : decimal.Parse(dr[CompletedProjectsColumnName].ToString());
                chartProjectStatus.Series[CompletedProjects].Points.AddXY(sFunction, YVal1);
                chartProjectStatus.Series[CompletedProjects].LabelAngle = 60;

                //Ongoing Projects
                string OngoingProjectsColumnName = dt.Columns[3].ColumnName;
                decimal YVal2 = (dr.IsNull(2)) ? 0 : decimal.Parse(dr[OngoingProjectsColumnName].ToString());
                chartProjectStatus.Series[OngoingStalledProjects].Points.AddXY(sFunction, YVal2);

                //Total Projects
                string TotalProjectsColumnName = dt.Columns[4].ColumnName;
                decimal YVal3 = (dr.IsNull(3)) ? 0 : decimal.Parse(dr[TotalProjectsColumnName].ToString());
                chartProjectStatus.Series[TotalProjects].Points.AddXY(sFunction, YVal3);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void ChartBenefits(DataTable dt)
    {
        try
        {
            string CycleTimeSeries = "Cycle Time(Days)";
            BenefitChart.BackGradientStyle = GradientStyle.None;
            BenefitChart.Titles.Add("Benefits Delivered. Cost Reduction($10,000)");

            //Remove X-Axis Grid lines
            BenefitChart.ChartAreas["BenefitChartArea"].AxisX.MajorGrid.LineWidth = 0;

            //Remove Y-Axis Grid lines
            BenefitChart.ChartAreas["BenefitChartArea"].AxisY.MajorGrid.LineWidth = 0;

            //BenefitChart.ChartAreas["BenefitChartArea"].AxisY.LabelStyle.Format = "{0;c}"; //.LineWidth = 0;

            BenefitChart.Series.Add(CycleTimeSeries);
            BenefitChart.Series[CycleTimeSeries].ChartType = SeriesChartType.Line;
            BenefitChart.Series[CycleTimeSeries].IsVisibleInLegend = true;
            BenefitChart.Series[CycleTimeSeries].BorderWidth = 4;
            //BenefitChart.Series[CycleTimeSeries].XAxisType = AxisType.Secondary;            

            string NumberSeries = "Number*";
            BenefitChart.Series.Add(NumberSeries);
            BenefitChart.Series[NumberSeries].ChartType = SeriesChartType.Line;
            BenefitChart.Series[NumberSeries].IsVisibleInLegend = true;
            BenefitChart.Series[NumberSeries].BorderWidth = 4;
            //BenefitChart.Series[NumberSeries].XAxisType = AxisType.Secondary;

            string CostReductionSeries = "Cost Reduction($)";
            BenefitChart.Series.Add(CostReductionSeries);
            BenefitChart.Series[CostReductionSeries].ChartType = SeriesChartType.Line;
            BenefitChart.Series[CostReductionSeries].IsVisibleInLegend = true;
            BenefitChart.Series[CostReductionSeries].BorderWidth = 4;
            //BenefitChart.Series[CycleTimeSeries].YAxisType = AxisType.Primary;

            foreach (DataRow dr in dt.Rows)
            {
                //Cost Reduction
                string CostReductionColumnName = dt.Columns[1].ColumnName;
                decimal YVal1 = (dr.IsNull(1)) ? 0 : decimal.Parse(dr[CostReductionColumnName].ToString());
                BenefitChart.Series[CostReductionSeries].Points.AddXY(dr["YYEAR"].ToString(), (YVal1 / 10000));
                BenefitChart.Series[CostReductionSeries].LabelAngle = 60;


                //Cycle Time
                string CyclTimeColumnName = dt.Columns[2].ColumnName;
                decimal YVal2 = (dr.IsNull(2)) ? 0 : decimal.Parse(dr[CyclTimeColumnName].ToString());
                BenefitChart.Series[CycleTimeSeries].Points.AddXY(dr["YYEAR"].ToString(), YVal2);


                //Number*
                string NumberColumnName = dt.Columns[3].ColumnName;
                decimal YVal3 = (dr.IsNull(3)) ? 0 : decimal.Parse(dr[NumberColumnName].ToString());
                BenefitChart.Series[NumberSeries].Points.AddXY(dr["YYEAR"].ToString(), YVal3);

            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void NoOfProjectsByYear()
    {
        lblFunctionIES.Text = "Number of Projects 80-100% Completed By Function - " + ddlYear.SelectedValue;
        lblYear.Text = ddlYear.SelectedValue;
    }

    private void LoadProjectsWorkDoneByFunction()
    {
        int iTotalProjects = 0;
        int iFunctionProjects = 0;
        DataTable dt = oMainProjectHelper.dtGetProjectFunctions(int.Parse(ddlYear.SelectedValue));

        //Chart Work Done.
        dt.Columns.Add("IDENTIFY");
        dt.Columns.Add("ELIMINATE");
        dt.Columns.Add("SUSTAIN");
        dt.Columns.Add("TOTALPROJINHOPPER");

        foreach (DataRow dr in dt.Rows)
        {
            int iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());

            dr["IDENTIFY"] = oIdentifyHelper.IdentifyWorkDoneByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue)).ToString();
            dr["ELIMINATE"] = oEliminateHelper.EliminateWorkDoneByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue)).ToString();
            dr["SUSTAIN"] = oSustainHelper.SustainWorkDoneByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue)).ToString();
            iFunctionProjects = oMainProjectHelper.iTotalProjectsByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue));
            dr["TOTALPROJINHOPPER"] = iFunctionProjects;
            iTotalProjects += iFunctionProjects;
        }

        grdView.DataSource = dt;
        grdView.DataBind();
        grdView.FooterStyle.BackColor = System.Drawing.Color.DarkOrange;
        grdView.FooterStyle.HorizontalAlign = HorizontalAlign.Center;
        grdView.FooterRow.Cells[0].Text = "Total Projects";
        grdView.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        grdView.FooterRow.Cells[4].Text = iTotalProjects.ToString();

        ChartWorkDone(dt);
    }

    private void LoadProjectBenefitsByYear()
    {
        grdViewProjectBenefit.DataSource = oBenefitActualsHelper.dtProjectBenefitsByYear(int.Parse(ddlYear.SelectedValue));
        grdViewProjectBenefit.DataBind();
    }

    //Project Status - % Workdone CI Project Maturation Phase
    private void LoadProjectMaturationPhase()
    {
        DataTable dt = oMainProjectHelper.dtGetFunctionWorkDoneByYear(int.Parse(ddlYear.SelectedValue));
        grdViewProjectStatus.DataSource = dt;
        grdViewProjectStatus.DataBind();
        ColorCodeWorkDone();
    }

    private void ColorCodeWorkDone()
    {
        try
        {
            foreach (GridViewRow grdRow in grdViewProjectStatus.Rows)
            {
                Image imgIdentify = (Image)grdRow.FindControl("imgIdentify");
                Image imgEliminate = (Image)grdRow.FindControl("imgEliminate");
                Image imgSustain = (Image)grdRow.FindControl("imgSustain");

                Label labelIdentify = (Label)grdRow.FindControl("labelIdentify");
                Label labelEliminate = (Label)grdRow.FindControl("labelEliminate");
                Label labelSustain = (Label)grdRow.FindControl("labelSustain");

                LinkButton ProjectLinkButton = (LinkButton)grdRow.FindControl("ProjectLinkButton");
                int iProjectId = int.Parse(ProjectLinkButton.Attributes["IDPROJECT"].ToString());

                //Label lblProject = (Label)grdRow.FindControl("lblProject");
                //int iProjectId = int.Parse(lblProject.Attributes["IDPROJECT"].ToString());

                oIdentifyHelper.IdentifyWorkDoneByProjectYear(iProjectId, int.Parse(ddlYear.SelectedValue), imgIdentify, labelIdentify);
                oEliminateHelper.EliminateWorkDoneByProjectYear(iProjectId, int.Parse(ddlYear.SelectedValue), imgEliminate, labelEliminate);
                oSustainHelper.SustainWorkDoneByProjectYear(iProjectId, int.Parse(ddlYear.SelectedValue), imgSustain, labelSustain);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/Default.aspx");
    }

    private void CountWorkDone()
    {
        // "CountWorkDone()" No longer in use, but keep for the sake of other time.
        //Thank you code, you were so wonderful during your use before the discovery of new way of doing the same, which is reusable to other objects
        //Thanks.
        try
        {
            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lbIdentify = (Label)grdRow.FindControl("lbIdentify");
                Label lbEliminate = (Label)grdRow.FindControl("lbEliminate");
                Label lbSustain = (Label)grdRow.FindControl("lbSustain");
                Label lbTotalProjects = (Label)grdRow.FindControl("lbTotalProjects");
                Label lbFunction = (Label)grdRow.FindControl("lbFunction");
                int iFunctionId = int.Parse(lbFunction.Attributes["FUNCTIONID"].ToString());

                lbIdentify.Text = oIdentifyHelper.IdentifyWorkDoneByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue)).ToString();
                lbEliminate.Text = oEliminateHelper.EliminateWorkDoneByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue)).ToString();
                lbSustain.Text = oSustainHelper.SustainWorkDoneByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue)).ToString();

                int i = oMainProjectHelper.iTotalProjectsByFunctionYear(iFunctionId, int.Parse(ddlYear.SelectedValue));
                lbTotalProjects.Text = i.ToString();
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void AddScaleBreaks(Chart oChart, string sChartArea)
    {
        // Enable scale breaks.
        oChart.ChartAreas[sChartArea].AxisY.ScaleBreakStyle.Enabled = true;

        // Show scale break if more than 25% of the chart is empty space.
        oChart.ChartAreas[sChartArea].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 25;

        // Set the line width of the scale break.
        oChart.ChartAreas[sChartArea].AxisY.ScaleBreakStyle.LineWidth = 2;

        // Set the color of the scale break.
        oChart.ChartAreas[sChartArea].AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Red;

        // If all data points are significantly far from zero, the chart will calculate the scale minimum value.
        oChart.ChartAreas[sChartArea].AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Auto;

        // Set the spacing gap between the lines of the scale break (as a percentage of the Y-axis).
        oChart.ChartAreas[sChartArea].AxisY.ScaleBreakStyle.Spacing = 2;
    }

    protected void grdViewCompletedOngoingProjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvrow = e.Row;
        if (gvrow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell cell0 = new TableCell();
            cell0.ColumnSpan = 2;

            TableCell cell1 = new TableCell();
            cell1.Text = "Actual Benefits";
            cell1.HorizontalAlign = HorizontalAlign.Center;
            cell1.ColumnSpan = 3;
            cell1.Font.Bold = true;
            cell1.BackColor = System.Drawing.Color.Yellow;

            TableCell cell2 = new TableCell();
            cell2.ColumnSpan = 1;

            TableCell cell3 = new TableCell();
            cell3.Text = "Potential Benefits";
            cell3.HorizontalAlign = HorizontalAlign.Center;
            cell3.ColumnSpan = 3;
            cell3.Font.Bold = true;
            cell3.BackColor = System.Drawing.Color.Yellow;

            TableCell cell4 = new TableCell();
            cell4.ColumnSpan = 1;

            gvRow.Cells.Add(cell0);
            gvRow.Cells.Add(cell1);
            gvRow.Cells.Add(cell2);
            gvRow.Cells.Add(cell3);
            gvRow.Cells.Add(cell4);

            grdViewCompletedOngoingProjects.Controls[0].Controls.AddAt(0, gvRow);
        }
    }

    private void LoadProjectAssessment()
    {
        grdViewSustainability.DataSource = oAssessmentHelper.dtGetDashBoardAssessmentByYear(int.Parse(ddlYear.SelectedValue));
        grdViewSustainability.DataBind();

        int iNo = 0; int iYes = 0;
        foreach (GridViewRow grdRow in grdViewSustainability.Rows)
        {
            Label lblSusProject = (Label)grdRow.FindControl("lblSusProject");
            long lProjectId = long.Parse(lblSusProject.Attributes["IDPROJECT"].ToString());

            TextBox txtOverrallScore = (TextBox)grdRow.FindControl("txtOverrallScore");

            List<Assessment> lstCustomerAssessment = oAssessmentHelper.lstAssessmentAsnwers(lProjectId);
            int iTotalNoOfQuestions = lstCustomerAssessment.Count;
            foreach (Assessment oAssessment in lstCustomerAssessment)
            {
                if (oAssessment.iValue == 2) //Where 2 == No, 1 == Yes TODO: please take care of the hardcode here
                {
                    iNo += 1;
                }
                else if (oAssessment.iValue == 1)
                {
                    iYes += 1;
                }
            }

            if (iNo >= 3) txtOverrallScore.BackColor = System.Drawing.Color.Red;
            else if (iNo == 2) txtOverrallScore.BackColor = System.Drawing.Color.Silver;
            else if (iTotalNoOfQuestions == iYes) txtOverrallScore.BackColor = System.Drawing.Color.Green;
            else txtOverrallScore.BackColor = System.Drawing.Color.Red;
        }
    }

    private void LoadTrainingCertification()
    {
        try
        {
            TrainingHelper oTrainingHelper = new TrainingHelper();
            TrainingTypeHelper oTrainingTypeHelper = new TrainingTypeHelper();
            DataTable dt = oTrainingTypeHelper.dtGetTrainingType();

            List<int> iYears = oMainProjectHelper.lstYears();
            foreach (int iYear in iYears)
            {
                dt.Columns.Add(iYear.ToString());
            }

            foreach (DataRow dr in dt.Rows)
            {
                int iTrainingTypeId = int.Parse(dr["IDTYPE"].ToString());
                foreach (DataColumn dc in dt.Columns)
                {
                    if (Microsoft.VisualBasic.Information.IsNumeric(dc.ColumnName))
                    {
                        int iNoOfPeopleTrained = oTrainingHelper.NoOfPeopleTrainedByTrainingTypeYear(iTrainingTypeId, int.Parse(dc.ColumnName.Trim()));
                        if (iNoOfPeopleTrained == 0)
                        {
                            dr[dc.ColumnName.Trim()] = "";
                        }
                        else
                        {
                            dr[dc.ColumnName.Trim()] = iNoOfPeopleTrained;
                        }
                    }
                }                
            }

            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == "TYPE") dc.ColumnName = "Training Type";
                if (dc.ColumnName == "IDTYPE") dc.ColumnName = "...";
            }
            
            grdViewTraining.DataSource = dt;
            grdViewTraining.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void ProjectLinkButton_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnkEdit = (LinkButton)row.FindControl("ProjectLinkButton");
            long lProjectId = long.Parse(lnkEdit.Attributes["IDPROJECT"].ToString());

            Response.Redirect("~/App/Lean/Report/MainReport.aspx" + "?ProjectId=" + lProjectId, false);

            //MainProjects oMainProject = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);
            //oLeanProjectDetails1.Init_Control(oMainProject);

            //Show ModalPopUpExtender
            //MPE.Show();
        }
    }
}