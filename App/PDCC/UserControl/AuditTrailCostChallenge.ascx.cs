using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_PDCC_UserControl_AuditTrailCostChallenge : aspnetUserControl
{
    readonly AssetPdcc _gAsset = new AssetPdcc();
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    TransactionYear oTrans = new TransactionYear();

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                List<AssetPdcc> lstAssets = AssetPdcc.lstGetAssets(); ;
                foreach (AssetPdcc oAsset in lstAssets)
                {
                    ddlAsset.Items.Add(new ListItem(oAsset.sAsset, oAsset.iAssetId.ToString()));
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDataBySelection();
    }

    private void LoadDataBySelection()
    {
        DataTable dt = new DataTable();
        dt = _opportunityCostHelper.DtGetOpportunityCostLogsByAsset(int.Parse(ddlAsset.SelectedValue), oTrans.tYear().iYear);

        grdGridView.DataSource = null;
        grdGridView.DataSource = dt;
        grdGridView.DataBind();

        GetItemsStringValues();
    }


    private void GetItemsStringValues()
    {
        try
        {
            foreach (GridViewRow grdRow in grdGridView.Rows)
            {
                Label lblAcceptPark = (Label)grdRow.FindControl("lblAcceptPark");
                Label lblAssetSupport = (Label)grdRow.FindControl("lblAssetSupport");

                Label lblOpex = (Label)grdRow.FindControl("lblOpex");
                Label lblPotSavings = (Label)grdRow.FindControl("lblPotSavings");
                Label lblActualSaving = (Label)grdRow.FindControl("lblActualSaving");
                Label lblFecto = (Label)grdRow.FindControl("lblFecto");
                Label lblImprovement = (Label)grdRow.FindControl("lblImprovement");
                Label lblStartedBy = (Label)grdRow.FindControl("lblStartedBy");
                Label lblCompletedBy = (Label)grdRow.FindControl("lblCompletedBy");

                lblStartedBy.Text = !string.IsNullOrEmpty(lblStartedBy.Text) ? dateRoutine.dateStandard(DateTime.Parse(lblStartedBy.Text)) : "";
                lblCompletedBy.Text = !string.IsNullOrEmpty(lblCompletedBy.Text) ? dateRoutine.dateStandard(DateTime.Parse(lblCompletedBy.Text)) : "";

                lblFecto.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblFecto.Text));
                lblImprovement.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblImprovement.Text));
                lblOpex.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblOpex.Text));
                lblPotSavings.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblPotSavings.Text));
                lblActualSaving.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblActualSaving.Text));

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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        LoadDataBySelection();
    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string buttonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        DataSorter sortMe = new DataSorter();

        if ((buttonClicked == "Sort") || (buttonClicked == "Page"))
        {
            
        }
        else
        {
            int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

            if (buttonClicked == "ViewDetails")
            {
                LinkButton lbViewLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("ViewLinkButton");
                long lOpCost = long.Parse(lbViewLinkButton.Attributes["IDOPCOST"].ToString());
                Response.Redirect("~/App/PDCC/ViewDetails.aspx" + "?lOpCost=" + lOpCost + "&iAst=" + ddlAsset.SelectedValue, false);
                //Response.Redirect("~/App/PDCC/ViewDetails.aspx" + "?lOpCost=" + lOpCost + "&iMonth=" + int.Parse(ddlMonth.SelectedValue).ToString(), false);
            }
        }
    }

    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}