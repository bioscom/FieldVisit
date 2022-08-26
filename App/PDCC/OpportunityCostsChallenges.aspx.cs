using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

public partial class App_PDCC_OpportunityCostsChallenges : aspnetPage
{
    readonly AssetPdcc _gAsset = new AssetPdcc();
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["IdNo"]))
                {
                    string sSerialNoOrOpportunity = Request.QueryString["IdNo"].ToString();
                    DataTable dt = _opportunityCostHelper.DtGetOpportunityCostBySerialNo(sSerialNoOrOpportunity);
                    OpportunityCost oOpportunityCost = _opportunityCostHelper.ObjGetOpportunityCostBySerialNo(sSerialNoOrOpportunity);

                    if (dt.Rows.Count == 0)
                    {
                        dt = _opportunityCostHelper.DtGetOpportunityCostByOpportunity(sSerialNoOrOpportunity);
                        oOpportunityCost = _opportunityCostHelper.ObjGetOpportunityCostByOpportunity(sSerialNoOrOpportunity);
                    }

                    grdGridView.DataSource = dt;
                    grdGridView.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        GetItemsStringValues();
                        ItemSearchSecurity(oOpportunityCost);
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    List<AssetPdcc> lstAssets;
                    if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Administrator)
                    {
                        //An Administrator should be able to see all department opportunities
                        lstAssets = AssetPdcc.lstGetAssets();
                        //getDataByAdmin(DateTime.Today.Year);
                    }
                    else
                    {
                        //Others should only be able to see Assets assigned to them.
                        lstAssets = _gAsset.lstGetPdccAssetsByUser(oSessnx.getOnlineUser.m_iUserId, Convert.ToInt32(oSessnx.getOnlineUser.m_iRolePdcc));
                        //getDataByUser();
                    }

                    foreach (AssetPdcc oAsset in lstAssets)
                    {
                        ddlAsset.Items.Add(new ListItem(oAsset.sAsset, oAsset.iAssetId.ToString()));
                    }
                }

                if(!string.IsNullOrEmpty(Request.QueryString["iAst"]))
                {
                    ddlAsset.SelectedValue = Request.QueryString["iAst"].ToString();
                    LoadDataBySelection();
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

        }
    }
    private void getDataByAdmin(int iYear)
    {
        DataTable dt = _opportunityCostHelper.DtGetOpportunityCosts(iYear);
        grdGridView.DataSource = dt;
        grdGridView.DataBind();
        if (dt.Rows.Count > 0)
        {
            GetItemsStringValues();
        }
    }

    private void getDataByUser()
    {
        DataTable dt = new DataTable();

        //dt = _gDepartment.dtGetUserPdccDeparments(oSessnx.getOnlineUser.m_iUserId, Convert.ToInt32(oSessnx.getOnlineUser.m_iRolePdcc));

        dt = _opportunityCostHelper.DtGetOpportunityCostByUser(oSessnx.getOnlineUser.m_iUserId, Convert.ToInt32(oSessnx.getOnlineUser.m_iRolePdcc), oTrans.tYear().iYear);

        //List<Department> lstMyDepartments = _gDepartment.lstGetPdccDeparmentsByUser(oSessnx.getOnlineUser.m_iUserId, Convert.ToInt32(oSessnx.getOnlineUser.m_iRolePdcc));
        //foreach (Department oDept in lstMyDepartments)
        //{
        //    dt.Merge(_opportunityCostHelper.DtGetOpportunityCostBySponsor(oDept.m_iDepartmentId));
        //}

        grdGridView.DataSource = dt;
        grdGridView.DataBind();
        if (dt.Rows.Count > 0)
        {
            GetItemsStringValues();
        }
    }

    protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDataBySelection();
    }

    private void LoadDataBySelection()
    {
        DataTable dt = new DataTable();
        if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Administrator)
        {
            dt = _opportunityCostHelper.DtGetOpportunityCostByAsset(int.Parse(ddlAsset.SelectedValue), oTrans.tYear().iYear);
        }
        else if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.User)
        {
            dt = _opportunityCostHelper.DtGetOpportunityCostByAsset(int.Parse(ddlAsset.SelectedValue), oTrans.tYear().iYear);
        }
        else
        {
            dt = _opportunityCostHelper.DtGetOpportunityCostByAssetOwner(int.Parse(ddlAsset.SelectedValue), oTrans.tYear().iYear, oSessnx.getOnlineUser.m_iUserId);
        }

        grdGridView.DataSource = null;
        //grdGridView.Columns.Clear();
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

    private void ItemSearchSecurity(OpportunityCost oOpportunityCost)
    {
        try
        {
            foreach (GridViewRow grdRow in grdGridView.Rows)
            {
                LinkButton lnkEdit = (LinkButton)grdRow.FindControl("EditLinkButton");
                LinkButton lnkUpdate = (LinkButton)grdRow.FindControl("UpdateLinkButton");

                lnkEdit.Enabled = false;
                lnkUpdate.Enabled = false;

                if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Sponsor)
                {
                    if (oOpportunityCost.iSponsor == oSessnx.getOnlineUser.m_iUserId)
                    {
                        lnkEdit.Enabled = true;
                        lnkUpdate.Enabled = true;
                    }
                }
                else if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.ActionParty)
                {
                    if (oOpportunityCost.iActionParty == oSessnx.getOnlineUser.m_iUserId)
                    {
                        lnkEdit.Enabled = true;
                        lnkUpdate.Enabled = true;
                    }
                }
                else if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Administrator)
                {
                    lnkEdit.Enabled = true;
                    lnkUpdate.Enabled = true;
                }
                else if (oSessnx.getOnlineUser.m_iUserId == oOpportunityCost.iUserId)
                {
                    lnkEdit.Enabled = true;
                    lnkUpdate.Enabled = true;
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



        //if (oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.Administrator)
        //{
        //    getDataByAdmin(OpportunityCostHelper.getCurrentMonth());
        //}
        //else
        //{
        //    getDataByUser();
        //}
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

            if (buttonClicked == "UpdateOpportunity")
            {
                LinkButton lbEditLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("EditLinkButton");
                long lOpCost = long.Parse(lbEditLinkButton.Attributes["IDOPCOST"].ToString());
                Response.Redirect("~/App/PDCC/EditPdcc.aspx" + "?lOpCost=" + lOpCost + "&iAst=" + ddlAsset.SelectedValue, false);
            }

            if (buttonClicked == "UpdatePerformance")
            {
                LinkButton lbEditLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("UpdateLinkButton");
                long lOpCost = long.Parse(lbEditLinkButton.Attributes["IDOPCOST"].ToString());
                Response.Redirect("~/App/PDCC/UpdateMonthyPerformance.aspx" + "?lOpCost=" + lOpCost, false);
                //Response.Redirect("~/App/PDCC/UpdateMonthyPerformance.aspx" + "?lOpCost=" + lOpCost + "&iMonth=" + int.Parse(ddlMonth.SelectedValue).ToString(), false);
            }

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
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    protected void btnList_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/PDCC/Create.aspx");
    }
    
}