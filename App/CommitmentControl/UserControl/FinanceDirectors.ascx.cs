using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

public partial class App_CommitmentControl_UserControl_FinanceDirector : System.Web.UI.UserControl
{
    FinanceDirecor o = new FinanceDirecor();
    OUMgt oU = new OUMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataForgrdView();

            List<OU> olstOU = oU.lstGetOUS();
            foreach (var listItem in olstOU.Select(r => new RadComboBoxItem(r.m_sOUS, r.m_iOUId.ToString())))
            {
                ddlOU.Items.Add(listItem);
                ddlOU.DataBind();
            }
        }
    }

    private void LoadDataForgrdView()
    {
        grdView.DataSource = o.GetFinanceDirectors();
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = o.GetFinanceDirectors();
        }
    }

    protected void ddlAdmin_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text))
            EIdd.Utilities.Search(e.Text, ddlAdmin);
    }
   
    protected void Page_Init(object sender, EventArgs e)
    {
        //Load all the Request initiators
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlAdmin.SelectedValue))
        {
            bool bRet = o.AddFianceDirector(int.Parse(ddlAdmin.SelectedValue), int.Parse(ddlOU.SelectedValue));
            LoadDataForgrdView();
            grdView.Rebind();
            if (bRet)
            {
                ddlAdmin.Items.Clear();
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Successfully added as a Finance Director!!!");
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Please select a Finance Director!!!");
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem) ((LinkButton) sender).Parent.Parent)
        {
            int lId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["USERID"].ToString());
            var o = new FinanceDirecor();

            ///TODO: Please update the list of Approval Decision into Enumeration list.
            o.RemoveFinanceDirector(lId);
            grdView.Rebind();
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Delete Successful!!!");
        }
    }

    protected void grdView_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {

    }

    protected void grdView_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

    }

    protected void grdView_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int rowCounter = new int();
            Label lbl = e.Item.FindControl("numberLabel") as Label;
            rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
            lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();
        }
    }

    protected void grdView_ItemDeleted(object sender, Telerik.Web.UI.GridDeletedEventArgs e)
    {

    }

    protected void grdView_ItemInserted(object sender, Telerik.Web.UI.GridInsertedEventArgs e)
    {

    }

    protected void grdView_ItemUpdated(object sender, Telerik.Web.UI.GridUpdatedEventArgs e)
    {

    }

    protected void grdView_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdView.EditIndexes.Add(0);
            grdView.Rebind();

            //grdView.MasterTableView.Items[0].Expanded = true;
            //grdView.MasterTableView.Items[0].ChildItem.NestedTableViews[0].Items[0].Expanded = true;
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
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

    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        string alternateText = (sender as ImageButton).AlternateText;
        #region [ XSLX FORMAT ]
        if (alternateText == "Xlsx")
        {
            grdView.MasterTableView.GetColumn("EmployeeID").HeaderStyle.BackColor = Color.LightGray;
            grdView.MasterTableView.GetColumn("EmployeeID").ItemStyle.BackColor = Color.LightGray;
        }
        #endregion
        grdView.ExportSettings.Excel.Format = (GridExcelExportFormat) Enum.Parse(typeof(GridExcelExportFormat), alternateText);
        //grdView.ExportSettings.IgnorePaging = CheckBox1.Checked;
        grdView.ExportSettings.ExportOnlyData = true;
        grdView.ExportSettings.OpenInNewWindow = true;
        grdView.MasterTableView.ExportToExcel();
    }
}