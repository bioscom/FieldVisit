using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_PDCC_UserControl_PDPerformance : aspnetUserControl
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadPDSummaryPerformance(int iYearId)
    {
        DataTable dt = new DataTable();
        
        dt.Columns.Add("OPEX");
        dt.Columns.Add("ACTSAVINGS");
        dt.Columns.Add("IMPROVEMENT");
        dt.NewRow();
        dt.Rows.Add();
        //dt.Columns.Add("TOTALPROJINHOPPER");

        foreach (DataRow dr in dt.Rows)
        {
            OpexFectoImprovementActualPotential xCop = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(iYearId);

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