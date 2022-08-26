using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_PDCC_UserControl_CharttingDataNT : aspnetUserControl
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadData(int iYearId)
    {
        //int iTotalProjects = 0;
        //int iFunctionProjects = 0;
        DataTable dt = _opportunityCostHelper.dtGetFunctionsOrDepartments();

        //Chart Work Done.
        dt.Columns.Add("OPEX");
        dt.Columns.Add("ACTSAVINGS");
        dt.Columns.Add("IMPROVEMENT");
        //dt.Columns.Add("TOTALPROJINHOPPER");

        foreach (DataRow dr in dt.Rows)
        {
            int iAssetId = int.Parse(dr["ASSETID"].ToString());

            OpexFectoImprovementActualPotential xCop = _opportunityCostHelper.ObjGetSummaryByAssetYear(iAssetId, iYearId);

            dr["OPEX"] = xCop.dOpex;
            dr["ACTSAVINGS"] = xCop.dActSavings;
            dr["IMPROVEMENT"] = xCop.dImprovement;
            //iFunctionProjects = oMainProjectHelper.iTotalProjectsByFunctionYear(iFunctionId, iYearId);
            //dr["TOTALPROJINHOPPER"] = iFunctionProjects;
            //iTotalProjects += iFunctionProjects;
        }

        grdView.DataSource = dt;
        grdView.DataBind();
        grdView.FooterStyle.BackColor = System.Drawing.Color.DarkOrange;
        grdView.FooterStyle.HorizontalAlign = HorizontalAlign.Center;
        //grdView.FooterRow.Cells[0].Text = "Total Projects";
        //grdView.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        //grdView.FooterRow.Cells[4].Text = iTotalProjects.ToString();

        _opportunityCostHelper.GetItemsStringValues(grdView, oSessnx.getOnlineUser);
    }
    public void LoadDataByDepartment(int iYearId, int iDeptId)
    {
        //int iTotalProjects = 0;
        //int iFunctionProjects = 0;
        DataTable dt = _opportunityCostHelper.dtGetFunctionsByDepartments(iDeptId);

        //Chart Work Done.
        dt.Columns.Add("OPEX");
        dt.Columns.Add("ACTSAVINGS");
        dt.Columns.Add("IMPROVEMENT");
        //dt.Columns.Add("TOTALPROJINHOPPER");

        foreach (DataRow dr in dt.Rows)
        {
            int iAssetId = int.Parse(dr["ASSETID"].ToString());

            OpexFectoImprovementActualPotential xCop = _opportunityCostHelper.ObjGetSummaryByAssetYear(iAssetId, iYearId);

            dr["OPEX"] = xCop.dOpex;
            dr["ACTSAVINGS"] = xCop.dActSavings;
            dr["IMPROVEMENT"] = xCop.dImprovement;
            //iFunctionProjects = oMainProjectHelper.iTotalProjectsByFunctionYear(iFunctionId, iYearId);
            //dr["TOTALPROJINHOPPER"] = iFunctionProjects;
            //iTotalProjects += iFunctionProjects;
        }

        grdView.DataSource = dt;
        grdView.DataBind();
        grdView.FooterStyle.BackColor = System.Drawing.Color.DarkOrange;
        grdView.FooterStyle.HorizontalAlign = HorizontalAlign.Center;
        //grdView.FooterRow.Cells[0].Text = "Total Projects";
        //grdView.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        //grdView.FooterRow.Cells[4].Text = iTotalProjects.ToString();

        _opportunityCostHelper.GetItemsStringValues(grdView, oSessnx.getOnlineUser);
    }
    public void OnOffshore(int iYearId, int iAssetServ)
    {
        //int iTotalProjects = 0;
        //int iFunctionProjects = 0;

        decimal dTotalOpex = 0;
        decimal dImprOppr = 0;
        DataTable dt = _opportunityCostHelper.dtGetAssetsByOnshoreOffshoreByYear(iAssetServ, iYearId);

        //Chart Work Done.
        dt.Columns.Add("OPEX");
        dt.Columns.Add("ACTSAVINGS");
        dt.Columns.Add("IMPROVEMENT");
        //dt.Columns.Add("TOTALPROJINHOPPER");
        //, iYearId
        foreach (DataRow dr in dt.Rows)
        {
            int iAssetId = int.Parse(dr["ASSETID"].ToString());

            //dtGetSummaryByOnshoreOffshoreAsset

            OpexFectoImprovementActualPotential xCop = _opportunityCostHelper.ObjGetSummaryByAssetYear(iAssetId, iYearId);

            dr["OPEX"] = xCop.dOpex;
            dr["ACTSAVINGS"] = xCop.dActSavings;
            dr["IMPROVEMENT"] = xCop.dImprovement;

            dTotalOpex += xCop.dOpex;
            dImprOppr += xCop.dImprovement;
            //iFunctionProjects = oMainProjectHelper.iTotalProjectsByFunctionYear(iFunctionId, iYearId);
            //dr["TOTALPROJINHOPPER"] = iFunctionProjects;
            //iTotalProjects += iFunctionProjects;
        }

        grdView.DataSource = dt;
        grdView.DataBind();
        grdView.FooterStyle.BackColor = System.Drawing.Color.LightPink;
        grdView.FooterStyle.HorizontalAlign = HorizontalAlign.Center;
        //grdView.FooterRow.Cells[0].Text = "Total";
        //grdView.FooterRow.Cells[1].Text = stringRoutine.formatAsBankMoney("$", dTotalOpex);
        //grdView.FooterRow.Cells[4].Text = stringRoutine.formatAsBankMoney("$", dImprOppr);
        //grdView.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        //grdView.FooterRow.Cells[4].Text = iTotalProjects.ToString();

        _opportunityCostHelper.GetItemsStringValues(grdView, oSessnx.getOnlineUser);
    }
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
}