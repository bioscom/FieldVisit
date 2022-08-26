using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Linq;

public partial class App_BONGACCP_UserControl_InputUpdateCommitmentDetails : System.Web.UI.UserControl
{
    ActivityDetailsMgt dtlMgt = new ActivityDetailsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["lCommitmentId"]))
        {
            long lCommitmentId = long.Parse(Request.QueryString["lCommitmentId"]);
            CommitmentIdHF.Value = lCommitmentId.ToString();
        }
    }

    public void LoadDetails(long lCommitmentId)
    {
        grdView.DataSource = dtlMgt.dtGetCommitmentDetailsByCommitmentId(lCommitmentId);
        grdView.DataBind();

        CommitmentIdHF.Value = lCommitmentId.ToString();
    }

    protected void grdView_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            if (!string.IsNullOrEmpty(CommitmentIdHF.Value))
            {
                long lCommitmentId = long.Parse(CommitmentIdHF.Value);
                (sender as RadGrid).DataSource = dtlMgt.dtGetCommitmentDetailsByCommitmentId(lCommitmentId);
            }
            else
            {
                (sender as RadGrid).DataSource = dtlMgt.dtGetCommitmentDetailsByCommitmentId(-1);
            }
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
        {
            int lDetailsId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["DETAILSID"].ToString());

            bool bRet = dtlMgt.Delete(lDetailsId); // repo.Delete(repo.GetById(lId));
            if (bRet) ajaxWebExtension.showJscriptAlertCx(Page, this, "Delete Successful!!!");
            else { ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful!!!"); }
            grdView.Rebind();
        }
    }

    protected void grdView_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var editLink = (HyperLink)e.Item.FindControl("editLink");
            //var actionLink = (HyperLink)e.Item.FindControl("actionLink");

            if (editLink != null)
            {
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DETAILSID"], e.Item.ItemIndex);
            }

            //if (actionLink != null)
            //{
            //    actionLink.Attributes["href"] = "javascript:void(0);";
            //    actionLink.Attributes["onclick"] = string.Format("return ShowActionFormPending('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], e.Item.ItemIndex);
            //}
        }

        if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
        {
            GridEditableItem editableItem = (GridEditableItem)e.Item;
            SetupInputManager(editableItem);
        }
    }

    protected void grdView_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                int rowCounter = new int();
                Label lbl = e.Item.FindControl("numberLabel") as Label;
                rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
                lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();

                //(from d in grdView.MasterTableView.RenderColumns select d).First(d => d.UniqueName == "Qty").;
                //decimal Rate = (from d in grdView.MasterTableView.RenderColumns select d).Any(d => d.UniqueName == "Rate");

                var item = e.Item as GridDataItem;

                int Qty = int.Parse(item["Qty"].Text);
                decimal Rate = decimal.Parse(item["Rate"].Text);

                Label lblAmount = e.Item.FindControl("lblAmount") as Label;
                lblAmount.Text = stringRoutine.formatAsBankMoney((Qty * Rate));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            grdView.MasterTableView.SortExpressions.Clear();
            grdView.MasterTableView.GroupByExpressions.Clear();
            grdView.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            grdView.MasterTableView.SortExpressions.Clear();
            grdView.MasterTableView.GroupByExpressions.Clear();
            grdView.MasterTableView.CurrentPageIndex = grdView.MasterTableView.PageCount - 1;
            grdView.Rebind();
        }
    }


    //#region //Working with gridcontrol commands

    //protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{

    //}
    //protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (e.CommandName.Equals("Insert"))
    //        {
    //            dt = (DataTable)Session["dt"];
    //            if (dt.Columns.Count == 0)
    //            {
    //                dt.Columns.Add("DESCRIPTION");
    //                dt.Columns.Add("QUANTITY");
    //                dt.Columns.Add("RATE");
    //            }

    //            row = dt.NewRow();
    //            row["DESCRIPTION"] = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("txtActivity")).Text);
    //            row["QUANTITY"] = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("txtQty")).Text);
    //            row["RATE"] = Convert.ToString(((TextBox) grdView.FooterRow.FindControl("txtRate")).Text);

    //            dt.Rows.Add(row);

    //            grdView.DataSource = dt;
    //            grdView.DataBind();

    //            Session["dt"] = dt;
    //        }

    //        if (e.CommandName.Equals("emptyInsert"))
    //        {
    //            GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

    //            dt.Columns.Add("DESCRIPTION");
    //            dt.Columns.Add("QUANTITY");
    //            dt.Columns.Add("RATE");

    //            row = dt.NewRow();
    //            row["DESCRIPTION"] = Convert.ToString(((TextBox)emptyRow.FindControl("txtActivity")).Text);
    //            row["QUANTITY"] = Convert.ToString(((TextBox) emptyRow.FindControl("txtQty")).Text);
    //            row["RATE"] = Convert.ToString(((TextBox) emptyRow.FindControl("txtRate")).Text);

    //            dt.Rows.Add(row);

    //            grdView.DataSource = dt;
    //            grdView.DataBind();

    //            Session["dt"] = dt;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //        appMonitor.logAppExceptions(ex);
    //    }
    //}
    //protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    //long lActivityId = long.Parse(RequestIdHF.Value);
    //    grdView.EditIndex = -1;
    //    //LoadCadenceByRequestId(lActivityId);
    //}
    //protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //}
    //protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    //long lRequestId = long.Parse(RequestIdHF.Value);
    //    grdView.EditIndex = e.NewEditIndex;
    //    //LoadCadenceByRequestId(lRequestId);

    //    //Int64 lCadenceId = Convert.ToInt64(grdView.DataKeys[e.NewEditIndex].Values[0].ToString());
    //    //CostReductionCadence oC = oMS.objGetCadenceByCadenceId(lCadenceId);

    //    //ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("FDdateControl");
    //    //FD.setDate(oC.dFinishDate.ToString());

    //    //ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("oStatusControl");
    //    //ddlStatus.thisDropDown.SelectedValue = oC.iStatus.ToString();
    //}
    //protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    try
    //    {
    //        //long lRequestId = long.Parse(RequestIdHF.Value);
    //        //o.lRequestId = lRequestId;
    //        //ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.RowIndex].FindControl("FDdateControl");

    //        //o.lCadenceId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
    //        //o.sAction = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAction")).Text);
    //        //o.sActionParty = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtActionParty")).Text);
    //        //o.sThreat = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtThreat")).Text);
    //        //o.dFinishDate = FD.dtSelectedDate;

    //        //ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx)grdView.Rows[e.RowIndex].FindControl("oStatusControl");
    //        //o.iStatus = Convert.ToInt16(ddlStatus.thisDropDown.SelectedValue);

    //        //oMS.UpdateCadence(o);

    //        grdView.EditIndex = -1;
    //        //LoadCadenceByRequestId(lRequestId);
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}
    //protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    //long lRequestId = long.Parse(RequestIdHF.Value);

    //    //Int64 lCadenceId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
    //    //oMS.DeleteCadence(lCadenceId);
    //    //LoadCadenceByRequestId(lRequestId);
    //}

    //#endregion

    protected void grdView_InsertCommand(object sender, GridCommandEventArgs e)
    {
        var editableItem = ((GridEditableItem)e.Item);

        //create new entity
        ActivityDetails o = new ActivityDetails();

        //populate its properties
        Hashtable values = new Hashtable();
        editableItem.ExtractValues(values);

        bool bRet = false;
        try
        {
            if (!string.IsNullOrEmpty(CommitmentIdHF.Value))
            {
                o.m_lCommitmentId = long.Parse(CommitmentIdHF.Value);
                o.m_sDescription = (string)values["DESCRIPTION"];
                if (values["RATE"] != null) o.m_dRate = short.Parse(values["RATE"].ToString());
                if (values["QUANTITY"] != null) o.m_dQuantity = decimal.Parse(values["QUANTITY"].ToString());
                bRet = dtlMgt.Insert(o);
            }
            else
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, "A commitment must be submitted before detailed activities entries are made.");
            }
        }
        catch (Exception)
        {
            ShowErrorMessage();
            //System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
        }
    }

    protected void grdView_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        var editableItem = ((GridEditableItem)e.Item);
        var detailsId = long.Parse(editableItem.GetDataKeyValue("DETAILSID").ToString());
        bool bRet = false;

        //retrive entity form the Db
        ActivityDetails o = dtlMgt.objGetActivityDetailsById(detailsId);
        
        if (o != null)
        {
            //update entity's state
            editableItem.UpdateValues(o);
            try
            {
                //save chanages to Db
                bRet = dtlMgt.Update(o);
            }
            catch (System.Exception)
            {
                ShowErrorMessage();
            }
        }
    }

    protected void grdView_DeleteCommand(object source, GridCommandEventArgs e)
    {
        var detailsId = long.Parse(((GridDataItem)e.Item).GetDataKeyValue("DETAILSID").ToString());

        //retrive entity form the Db
        ActivityDetails o = dtlMgt.objGetActivityDetailsById(detailsId);
        if (o != null)
        {
            try
            {
                dtlMgt.Delete(detailsId);

                bool bRet = dtlMgt.Delete(detailsId);
                if (bRet) ajaxWebExtension.showJscriptAlertCx(Page, this, "Delete Successful!!!");
                else { ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful!!!"); }
                grdView.Rebind();
            }
            catch (System.Exception)
            {
                ShowErrorMessage();
            }
        }
    }

    private void SetupInputManager(GridEditableItem editableItem)
    {
        // style and set ProductName column's textbox as required
        var textBox = ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("DESCRIPTION")).TextBoxControl;
        textBox.Height = 70;
        textBox.Width = 400;
        textBox.TextMode = TextBoxMode.MultiLine;

        InputSetting inputSetting = RadInputManager1.GetSettingByBehaviorID("TextBoxSetting1");
        inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));
        inputSetting.InitializeOnClient = true;
        inputSetting.Validation.IsRequired = true;

        // style UnitPrice column's textbox 
        textBox = ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("RATE")).TextBoxControl;

        inputSetting = RadInputManager1.GetSettingByBehaviorID("NumericTextBoxRate");
        inputSetting.InitializeOnClient = true;
        inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));

        // style UnitsInStock column's textbox 
        textBox = ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("Qty")).TextBoxControl;
        inputSetting = RadInputManager1.GetSettingByBehaviorID("NumericTextBoxQuantity");
        inputSetting.InitializeOnClient = true;
        inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));
    }

    private void ShowErrorMessage()
    {
        RadAjaxManager1.ResponseScripts.Add(string.Format("window.radalert(\"Please enter valid data!\")"));
    }
}