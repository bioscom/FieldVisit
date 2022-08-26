using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class App_PDCC_iReport : aspnetPage
{
    readonly AssetPdcc _gAsset = new AssetPdcc();
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    TransactionYear oTrans = new TransactionYear();

    decimal dPercRed = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                List<AssetPdcc> lstAssets;
                if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Administrator)
                {
                    //An Administrator should be able to see all department opportunities
                    lstAssets = AssetPdcc.lstGetAssets();
                }
                else
                {
                    lstAssets = _gAsset.lstGetPdccAssetsByUser(oSessnx.getOnlineUser.m_iUserId, Convert.ToInt32(oSessnx.getOnlineUser.m_iRolePdcc));
                }

                foreach (AssetPdcc oAsset in lstAssets)
                {
                    lstBoxDepartments.Items.Add(new ListItem(oAsset.sAsset, oAsset.iAssetId.ToString()));
                }

                List<int> iYears = _opportunityCostHelper.lstYears();
                ddlYear.Items.Add(new ListItem("Select Year", "-1"));
                foreach (int iYear in iYears)
                {
                    ddlYear.Items.Add(iYear.ToString());
                }

                ddlYear.SelectedValue = oTrans.tYear().iYear.ToString(); //DateTime.Today.Year.ToString();
                dPercRed = decimal.Parse(txtPercRed.Text) / 100;

                //PlotGraphs(int.Parse(ddlYear.SelectedValue));
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }
    protected void brnPreview_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        foreach (ListItem li in lstBoxDepartments.Items)
        {
            if (li.Selected)
            {
                //dt.Merge(_opportunityCostHelper.DtGetOpportunityCostByDept(int.Parse(li.Value)));
            }
        }

        grdGridView.DataSource = dt;
        grdGridView.DataBind();
        if (dt.Rows.Count > 0)
        {
            GetItemsStringValues();
        }
    }

    private void GetItemsStringValues()
    {
        try
        {
            foreach (GridViewRow grdRow in grdGridView.Rows)
            {
                Label lblAcceptPark = (Label)grdRow.FindControl("lblAcceptPark");
                Label lblAssetSupport = (Label)grdRow.FindControl("lblAssetSupport");

                if (!string.IsNullOrEmpty(lblAcceptPark.Text))
                {
                    if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Accept) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Accept);
                    else if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Park) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Park);
                    else if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Done) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Done);
                }

                if (!string.IsNullOrEmpty(lblAssetSupport.Text))
                {
                    if (int.Parse(lblAssetSupport.Text) == (int)ItemStatus.ItStatus.All) lblAssetSupport.Text = ItemStatus.status(ItemStatus.ItStatus.All);
                    else if (int.Parse(lblAssetSupport.Text) == (int)ItemStatus.ItStatus.Offshore) lblAssetSupport.Text = ItemStatus.status(ItemStatus.ItStatus.Offshore);
                    else if (int.Parse(lblAssetSupport.Text) == (int)ItemStatus.ItStatus.Onshore) lblAssetSupport.Text = ItemStatus.status(ItemStatus.ItStatus.Onshore);
                    else if (int.Parse(lblAssetSupport.Text) == (int)ItemStatus.ItStatus.OnShoreOffShore) lblAssetSupport.Text = ItemStatus.status(ItemStatus.ItStatus.OnShoreOffShore);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        foreach (ListItem li in lstBoxDepartments.Items)
        {
            if (li.Selected)
            {
                dt.Merge(_opportunityCostHelper.DtGetOpportunityCostByDeptRpt(int.Parse(li.Value)));
            }
        }

        ExporttoExcel(dt);
    }

    
    private void ExporttoExcel(DataTable dt)
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
        //am getting my grid's column headers
        //int columnscount = grdGridView.Columns.Count;

        int columnscount = dt.Columns.Count;

        for (int j = 0; j < columnscount; j++)
        {      //write in new column
            HttpContext.Current.Response.Write("<Td>");
            //Get column headers  and make it as bold in excel columns
            HttpContext.Current.Response.Write("<B>");
            //HttpContext.Current.Response.Write(grdGridView.Columns[j].HeaderText.ToString());
            HttpContext.Current.Response.Write(RenameColumns(dt.Columns[j].ColumnName.ToString()));
            HttpContext.Current.Response.Write("</B>");
            HttpContext.Current.Response.Write("</Td>");
        }

        HttpContext.Current.Response.Write("</TR>");
        foreach (DataRow row in dt.Rows)
        {//write in new row
            HttpContext.Current.Response.Write("<TR>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                HttpContext.Current.Response.Write("<Td>");
                
                if ((i == 6) && (row[i].ToString() != "")) { HttpContext.Current.Response.Write(GetStringValAcceptPark(int.Parse(row[i].ToString()))); }
                //if ((i == 6) && (row[i].ToString() != "")) { HttpContext.Current.Response.Write(GetStringValFecto(int.Parse(row[i].ToString()))); }
                //if ((i == 7) && (row[i].ToString() != "")) { HttpContext.Current.Response.Write(GetStringValImprovement(int.Parse(row[i].ToString()))); }
                if ((i == 11) && (row[i].ToString() != "")) { HttpContext.Current.Response.Write(GetStringValAssetSupport(int.Parse(row[i].ToString()))); }
                else { HttpContext.Current.Response.Write(row[i].ToString()); }
                
                HttpContext.Current.Response.Write("</Td>");
            }

            HttpContext.Current.Response.Write("</TR>");
        }
        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    private string RenameColumns(string sColumnName)
    {
        string sName = "";

        if (sColumnName == "SERIALNO") sName = "S/No";
        else if (sColumnName == "ASSET") sName = "Asset";
        else if (sColumnName == "DEPARTMENT") sName = "Department";
        else if (sColumnName == "OPPORTUNITY") sName = "Opportunity";
        else if (sColumnName == "SPONSORNAME") sName = "Sponsor";
        else if (sColumnName == "ACTIONPARTYNAME") sName = "Action Party";
        else if (sColumnName == "ACCEPTPARK") sName = "Accept/Park";
        else if (sColumnName == "PRIORITY") sName = "Priority";
        else if (sColumnName == "FECTO") sName = "Front End Cost Take Out (F$ Mln)";
        else if (sColumnName == "IMPROVEMENT") sName = "Improvement";
        else if (sColumnName == "ASSERV") sName = "Asset/Support Services";
        else if (sColumnName == "STARTEDBY") sName = "Started By";
        else if (sColumnName == "COMPLETEDBY") sName = "Complete By";
        else if (sColumnName == "POTSAVINGS") sName = "Potential Savings (F$ Mln)";
        else if (sColumnName == "ACTSAVINGS") sName = "Actual Savings (F$ Mln)";
        else if (sColumnName == "COSTCENTRE") sName = "Cost Centre";
        else if (sColumnName == "COMMENTS") sName = "Comments";
        else if (sColumnName == "OPEX") sName = OpportunityCostHelper.getSOpexYear(sName);
        else if (sColumnName == "WORKSCOPE") sName = "Work Scope";

        return sName;
    }

    private string GetStringValAcceptPark(int iVal)
    {
        string sAcceptPark = "";
        try
        {
            if (iVal == (int)ItemStatus.ItStatus.Accept) sAcceptPark = ItemStatus.status(ItemStatus.ItStatus.Accept);
            else if (iVal == (int)ItemStatus.ItStatus.Park) sAcceptPark = ItemStatus.status(ItemStatus.ItStatus.Park);
            else if (iVal == (int)ItemStatus.ItStatus.Done) sAcceptPark = ItemStatus.status(ItemStatus.ItStatus.Done);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return sAcceptPark;
    }

    private string GetStringValAssetSupport(int iVal)
    {
        string sAssetSupport = "";
        try
        {
            if (iVal == (int)ItemStatus.ItStatus.All) sAssetSupport = ItemStatus.status(ItemStatus.ItStatus.All);
            else if (iVal == (int)ItemStatus.ItStatus.Offshore) sAssetSupport = ItemStatus.status(ItemStatus.ItStatus.Offshore);
            else if (iVal == (int)ItemStatus.ItStatus.Onshore) sAssetSupport = ItemStatus.status(ItemStatus.ItStatus.Onshore);
            else if (iVal == (int)ItemStatus.ItStatus.OnShoreOffShore) sAssetSupport = ItemStatus.status(ItemStatus.ItStatus.OnShoreOffShore);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return sAssetSupport;
    }

    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        //LoadPendingFlareWaiverRequests(oSessnx.getOnlineUser);
    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string buttonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        DataSorter sortMe = new DataSorter();

        if ((buttonClicked == "Sort") || (buttonClicked == "Page"))
        {
            //CurrentSortExpression = sortMe.MySortExpression(e);

            //int result;
            //if (Int32.TryParse(e.CommandArgument.ToString(), out result) == false)
            //{
            //    Session["SortExpression"] = e.CommandArgument.ToString();
            //}
            //CurrentSortExpression = Session["SortExpression"].ToString();
        }
        else
        {
            int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

            if (buttonClicked == "ViewDetails")
            {
                LinkButton lbViewLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("ViewLinkButton");
                long lOpCost = long.Parse(lbViewLinkButton.Attributes["IDOPCOST"].ToString());
                Response.Redirect("~/App/PDCC/ViewDetails.aspx" + "?lOpCost=" + lOpCost, false);
            }
        }
    }
    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    protected void btnChart_Click(object sender, EventArgs e)
    {
        EventChanger();

        //PlotGraphs(int.Parse(ddlYear.SelectedValue));
    }

    private void PlotGraphs(int iYear)
    {
        OpexFectoImprovementActualPotential objOnShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Onshore);
        Charter(cSPDCReport, objOnShore, "SPDC PD", 400, 500);

        OpexFectoImprovementActualPotential objOffShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByAssetYear(iYear, (int)ItemStatus.ItStatus.Offshore);
        Charter(cSNEPCOReport, objOffShore, "SNEPCo PD", 400, 500);

        OpexFectoImprovementActualPotential objOffShoreOnShore = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(iYear);
        Charter(cCombinedReporter, objOffShoreOnShore, "SPDC + SNEPCo PD", 600, 900);
    }

    private void Charter(PlaceHolder oPlaceHolder, OpexFectoImprovementActualPotential objData, string sChartTitle, int iHeight, int iWidth)
    {
        try
        {
            decimal CummVal = objData.dFecto + objData.dImprovement;

            //create the chart ---------------------------- '
            Chart myChart = new Chart();
            oPlaceHolder.Controls.Add(myChart);

            myChart.Height = Unit.Pixel(iHeight);
            myChart.Width = Unit.Pixel(iWidth);

            //myChart.Series[0]["PointWidth"] = "0.8";
            myChart.Titles.Add(sChartTitle);

            //create the ChartArea - needed to plot data onto '
            ChartArea ca = new ChartArea();
            ca.Name = "ChartArea1";
            ca.AxisY.Title = "F($)mln";
            ca.AxisX.Interval = 1;
            myChart.ChartAreas.Add(ca);


            //Plot "OPEX" data column from our datatable '
            Series OpexSeries = new Series();
            OpexSeries.Name = "OP" + (oTrans.tYear().iYear - 1).ToString().Remove(0, 2);
            OpexSeries.ChartType = SeriesChartType.Column;
            OpexSeries.Color = System.Drawing.Color.Brown;
            OpexSeries.BorderWidth = 3;
            OpexSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(OpexSeries);

            DataPoint opex = new DataPoint();
            opex.SetValueY(objData.dOpex); opex.AxisLabel = OpexSeries.Name;
            OpexSeries.Points.Add(opex);


            //Plot "FECTO" data column from our datatable '
            Series FectoSeries = new Series();
            FectoSeries.Name = "FEC T/O";
            FectoSeries.ChartType = SeriesChartType.Column;
            FectoSeries.Color = System.Drawing.Color.Navy;
            FectoSeries.BorderWidth = 3;
            FectoSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(FectoSeries);

            DataPoint fecto = new DataPoint();
            fecto.SetValueY(objData.dFecto); fecto.AxisLabel = FectoSeries.Name;
            FectoSeries.Points.Add(fecto);


            //Plot "IMPROVEMENT" data column from our datatable '
            Series ImprovementSeries = new Series();
            ImprovementSeries.Name = "Impr. Opp";
            ImprovementSeries.ChartType = SeriesChartType.Column;
            ImprovementSeries.Color = System.Drawing.Color.OrangeRed;
            ImprovementSeries.BorderWidth = 3;
            ImprovementSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(ImprovementSeries);

            DataPoint improve = new DataPoint();
            improve.SetValueY(objData.dImprovement); improve.AxisLabel = ImprovementSeries.Name;
            ImprovementSeries.Points.Add(improve);

            //Plot "CUMMULATIVE" data column from our datatable '
            Series CummSeries = new Series();
            CummSeries.Name = "Cumm";
            CummSeries.ChartType = SeriesChartType.Column;
            CummSeries.Color = System.Drawing.Color.Pink;
            CummSeries.BorderWidth = 3;
            CummSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(CummSeries);

            DataPoint Cumm = new DataPoint();
            Cumm.SetValueY(objData.dFecto + objData.dImprovement); Cumm.AxisLabel = CummSeries.Name;
            CummSeries.Points.Add(Cumm);

            //Plot "ACTSAVINGS" data column from our datatable '
            Series ActualSeries = new Series();
            ActualSeries.Name = "Actual";
            ActualSeries.ChartType = SeriesChartType.Column;
            ActualSeries.Color = System.Drawing.Color.Gray;
            ActualSeries.BorderWidth = 3;
            ActualSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(ActualSeries);

            DataPoint Actual = new DataPoint();
            Actual.SetValueY(objData.dActSavings); Actual.AxisLabel = ActualSeries.Name;
            ActualSeries.Points.Add(Actual);

            //Plot "POTSAVINGS" data column from our datatable '
            Series PotentialSeries = new Series();
            PotentialSeries.Name = "Red. Target";
            PotentialSeries.ChartType = SeriesChartType.Column;
            PotentialSeries.Color = System.Drawing.Color.Orange;
            PotentialSeries.BorderWidth = 3;
            PotentialSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(PotentialSeries);

            DataPoint Potential = new DataPoint();
            Potential.SetValueY(objData.dOpex * dPercRed); Potential.AxisLabel = PotentialSeries.Name;
            PotentialSeries.Points.Add(Potential);


            //Add a Legend
            myChart.Legends.Add(new Legend("Legend1"));
            OpexSeries.LegendText = OpexSeries.Name;
            FectoSeries.LegendText = FectoSeries.Name;
            ImprovementSeries.LegendText = ImprovementSeries.Name;
            CummSeries.LegendText = CummSeries.Name;
            ActualSeries.LegendText = ActualSeries.Name;
            PotentialSeries.LegendText = PotentialSeries.Name;

            //chart background colour
            myChart.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee");

            //chart background shadow
            ca.ShadowOffset = 5;
            ca.ShadowColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");

            //' chart background gradient
            ca.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            ca.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#ddddee");
            ca.BackGradientStyle = System.Web.UI.DataVisualization.Charting.GradientStyle.TopBottom;

            //' format the chart gridlines
            ca.AxisX.LabelStyle.Angle = -45;
            ca.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            ca.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ////apply gradient colours to OpexSeries column '
            //OpexSeries.BackGradientStyle = GradientStyle.TopBottom;
            //OpexSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //OpexSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            ////apply gradient colours to FectoSeries column '
            //FectoSeries.BackGradientStyle = GradientStyle.TopBottom;
            //FectoSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //FectoSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            ////apply gradient colours to ImprovementSeries column '
            //ImprovementSeries.BackGradientStyle = GradientStyle.TopBottom;
            //ImprovementSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //ImprovementSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            ////apply gradient colours to CummSeries column '
            //CummSeries.BackGradientStyle = GradientStyle.TopBottom;
            //CummSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //CummSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            myChart.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void ChartDrill(int iDept, PlaceHolder oPlaceHolder, OpexFectoImprovementActualPotential objData, string sChartTitle, int iHeight, int iWidth, string sDept)
    {
        try
        {
            decimal CummVal = objData.dFecto + objData.dImprovement;

            //create the chart ---------------------------- '
            Chart myChart = new Chart();
            oPlaceHolder.Controls.Add(myChart);
            myChart.Height = Unit.Pixel(iHeight);
            myChart.Width = Unit.Pixel(iWidth);
            //myChart.Series[0]["PointWidth"] = "0.8";
            myChart.Titles.Add(sChartTitle + " (" + sDept + ")");

            //create the ChartArea - needed to plot data onto '
            ChartArea ca = new ChartArea();
            ca.Name = "ChartArea1";
            ca.AxisY.Title = "F($)mln";
            //ca.AxisY2.Title = sDept;
            ca.AxisX.Interval = 1;

            ////Remove X-Axis Grid lines
            //ca.AxisX.MajorGrid.LineWidth = 0;

            ////Remove Y-Axis Grid lines
            //ca.AxisY.MajorGrid.LineWidth = 0;

            myChart.ChartAreas.Add(ca);


            //Plot "OPEX" data column from our datatable '
            Series OpexSeries = new Series();
            OpexSeries.Name = "OP" + (oTrans.tYear().iYear - 1).ToString().Remove(0, 2);
            OpexSeries.ChartType = SeriesChartType.Column;
            OpexSeries.Color = System.Drawing.Color.Brown;
            OpexSeries.BorderWidth = 3;
            OpexSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(OpexSeries);

            DataPoint opex = new DataPoint();
            opex.SetValueY(objData.dOpex); opex.AxisLabel = OpexSeries.Name;
            OpexSeries.Points.Add(opex);


            //Plot "FECTO" data column from our datatable '
            Series FectoSeries = new Series();
            FectoSeries.Name = "FEC T/O";
            FectoSeries.ChartType = SeriesChartType.Column;
            FectoSeries.Color = System.Drawing.Color.Navy;
            FectoSeries.BorderWidth = 3;
            FectoSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(FectoSeries);

            DataPoint fecto = new DataPoint();
            fecto.SetValueY(objData.dFecto); fecto.AxisLabel = FectoSeries.Name;
            FectoSeries.Points.Add(fecto);


            //Plot "IMPROVEMENT" data column from our datatable '
            Series ImprovementSeries = new Series();
            ImprovementSeries.Name = "Impr. Opp";
            ImprovementSeries.ChartType = SeriesChartType.Column;
            ImprovementSeries.Color = System.Drawing.Color.OrangeRed;
            ImprovementSeries.BorderWidth = 3;
            ImprovementSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(ImprovementSeries);

            DataPoint improve = new DataPoint();
            improve.SetValueY(objData.dImprovement); improve.AxisLabel = ImprovementSeries.Name;
            ImprovementSeries.Points.Add(improve);

            //Plot "CUMMULATIVE" data column from our datatable '
            Series CummSeries = new Series();
            CummSeries.Name = "Cumm";
            CummSeries.ChartType = SeriesChartType.Column;
            CummSeries.Color = System.Drawing.Color.Pink;
            CummSeries.BorderWidth = 3;
            CummSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(CummSeries);

            DataPoint Cumm = new DataPoint();
            Cumm.SetValueY(objData.dFecto + objData.dImprovement); Cumm.AxisLabel = CummSeries.Name;
            CummSeries.Points.Add(Cumm);

            //Plot "ACTSAVINGS" data column from our datatable '
            Series ActualSeries = new Series();
            ActualSeries.Name = "Actual";
            ActualSeries.ChartType = SeriesChartType.Column;
            ActualSeries.Color = System.Drawing.Color.Gray;
            ActualSeries.BorderWidth = 3;
            ActualSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(ActualSeries);

            DataPoint Actual = new DataPoint();
            Actual.SetValueY(objData.dActSavings); Actual.AxisLabel = ActualSeries.Name;
            ActualSeries.Points.Add(Actual);

            //Plot "POTSAVINGS" data column from our datatable '
            Series PotentialSeries = new Series();
            PotentialSeries.Name = "Red. Target";
            PotentialSeries.ChartType = SeriesChartType.Column;
            PotentialSeries.Color = System.Drawing.Color.Orange;
            PotentialSeries.BorderWidth = 3;
            PotentialSeries.IsValueShownAsLabel = true;
            myChart.Series.Add(PotentialSeries);

            DataPoint Potential = new DataPoint();
            Potential.SetValueY(objData.dOpex * dPercRed); Potential.AxisLabel = PotentialSeries.Name;
            PotentialSeries.Points.Add(Potential);


            //Add a Legend
            myChart.Legends.Add(new Legend("Legend1"));
            OpexSeries.LegendText = OpexSeries.Name;
            FectoSeries.LegendText = FectoSeries.Name;
            ImprovementSeries.LegendText = ImprovementSeries.Name;
            CummSeries.LegendText = CummSeries.Name;
            ActualSeries.LegendText = ActualSeries.Name;
            PotentialSeries.LegendText = PotentialSeries.Name;

            //chart background colour
            myChart.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee");

            //chart background shadow
            ca.ShadowOffset = 5;
            ca.ShadowColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");

            //' chart background gradient
            ca.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            ca.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#ddddee");
            ca.BackGradientStyle = System.Web.UI.DataVisualization.Charting.GradientStyle.TopBottom;

            //' format the chart gridlines
            ca.AxisX.LabelStyle.Angle = -45;
            ca.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            ca.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ////apply gradient colours to OpexSeries column '
            //OpexSeries.BackGradientStyle = GradientStyle.TopBottom;
            //OpexSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //OpexSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            ////apply gradient colours to FectoSeries column '
            //FectoSeries.BackGradientStyle = GradientStyle.TopBottom;
            //FectoSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //FectoSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            ////apply gradient colours to ImprovementSeries column '
            //ImprovementSeries.BackGradientStyle = GradientStyle.TopBottom;
            //ImprovementSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //ImprovementSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            ////apply gradient colours to CummSeries column '
            //CummSeries.BackGradientStyle = GradientStyle.TopBottom;
            //CummSeries.Color = System.Drawing.ColorTranslator.FromHtml("#0066cc");
            //CummSeries.BackSecondaryColor = System.Drawing.ColorTranslator.FromHtml("#00aadd");

            myChart.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void EventChanger()
    {
        try
        {
            string sDepartment = "";
            //lblNodeClicked.Text = sDepartment;

            //mnuTreeView.CheckedNodes.
            int iDept = 0;
            foreach (ListItem li in lstBoxDepartments.Items)
            {
                if (li.Selected)
                {
                    iDept = int.Parse(li.Value);
                    sDepartment = li.Text;
                    
                    OpexFectoImprovementActualPotential objOffShoreOnShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByYearDepartment(int.Parse(ddlYear.SelectedValue), iDept);
                    ChartDrill(iDept, cCombinedReporter, objOffShoreOnShore, "SPDC+SNEPCo PD", 600, 900, sDepartment);

                    OpexFectoImprovementActualPotential objOnShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByYearDepartmentAsset(int.Parse(ddlYear.SelectedValue), iDept, (int)ItemStatus.ItStatus.Onshore);
                    ChartDrill(iDept, cSPDCReport, objOnShore, "SPDC PD", 400, 500, sDepartment);

                    OpexFectoImprovementActualPotential objOffShore = _opportunityCostHelper.ObjGetOpExFectoImprovementByYearDepartmentAsset(int.Parse(ddlYear.SelectedValue), iDept, (int)ItemStatus.ItStatus.Offshore);
                    ChartDrill(iDept, cSNEPCOReport, objOffShore, "SNEPCo PD", 400, 500, sDepartment);
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dPercRed = decimal.Parse(txtPercRed.Text) / 100;
        PlotGraphs(int.Parse(ddlYear.SelectedValue));
    }
}