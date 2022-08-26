using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Dashboard2 : System.Web.UI.Page
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    readonly Department _Department = new Department();
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Chartting1.Init_Page(oTrans.tYear().iYear);
            LoadGrid();
            PDPerformance.LoadPDSummaryPerformance(oTrans.tYear().iYear);
        }
    }

    private void LoadGrid()
    {
        DataTable dt = _Department.dtGetPdccDeparmentsThatHaveData(); //dtGetPdccDeparments

        grdView.DataSource = dt;
        grdView.DataBind();

        LoadGridData();
    }

    private void LoadGridData()
    {
        try
        {
            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lbDepartment = (Label)grdRow.FindControl("lbDepartment");
                int iDeptId = int.Parse(lbDepartment.Attributes["IDDEPARTMENT"].ToString());

                ASP.app_pdcc_usercontrol_charttingdatant_ascx oCharttingData = (ASP.app_pdcc_usercontrol_charttingdatant_ascx)grdRow.FindControl("CharttingData1");
                oCharttingData.LoadDataByDepartment(oTrans.tYear().iYear, iDeptId);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
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
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}