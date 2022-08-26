using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_PDSummaryCostReductionList : System.Web.UI.Page
{
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Load Asset Services
            grdView.DataSource = AssetServices.DtGetServices();
            grdView.DataBind();

            LoadPDSummary();
        }
    }

    private void LoadPDSummary()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbService = (Label)grdRow.FindControl("lbService");
            int iServiceId = int.Parse(lbService.Attributes["IDSERVICE"].ToString());

            ASP.app_pdcc_usercontrol_pdsummarycostredn_ascx oPdSummary = (ASP.app_pdcc_usercontrol_pdsummarycostredn_ascx)grdRow.FindControl("PDSummaryCostRednT");
            oPdSummary.Init_Page(iServiceId, oTrans.tYear().iYear);
        }

        //PDPerformance.PDPerformance(OpportunityCostHelper.iYear);

        PDPerformance.LoadPDSummaryPerformance(oTrans.tYear().iYear);
        PDCostSummary.PDPerformance(oTrans.tYear().iYear);
    }
}