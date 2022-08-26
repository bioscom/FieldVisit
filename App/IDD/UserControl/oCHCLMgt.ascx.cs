using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using System.Data;

public partial class App_IDD_UserControl_oCHCLMgt : System.Web.UI.UserControl
{
    EIdd.ContractHoldersMgt o = new EIdd.ContractHoldersMgt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataForgrdView();
            LoadControls();
        }
    }

    private void LoadDataForgrdView()
    {
        grdView.DataSource = o.GetContractHolders();
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = o.GetContractHolders();
        }

        if (ddlLocationFilter.Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(ddlLocationFilter.SelectedValue))
                grdView.DataSource = o.GetContractHoldersByLocation(int.Parse(ddlLocationFilter.SelectedValue));
        }
    }

    protected void ddlLocationFilter_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        grdView.DataSource = o.GetContractHoldersByLocation(int.Parse(ddlLocationFilter.SelectedValue));
        grdView.Rebind();
    }

    private void LoadControls()
    {
        var ot = new EIdd.Locations();
        List<EIdd.Location> olstLocations = ot.LstGetLocations();

        foreach (var o in olstLocations)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sLocation;
            item.Value = o.m_iLocationId.ToString();

            ddlLocation.Items.Add(item);
            item.DataBind();
        }

        foreach (var o in olstLocations)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sLocation;
            item.Value = o.m_iLocationId.ToString();

            ddlLocationFilter.Items.Add(item);
            item.DataBind();
        }

        var od = new EIdd.DepartmentsMgt();
        List<EIdd.Deparment> olstDepts = od.LstGetDepartments();

        foreach (var o in olstDepts)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sDeparment;
            item.Value = o.m_iDepartmentId.ToString();

            ddlDepartment.Items.Add(item);
            item.DataBind();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //Load all the Request initiators
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Insert User into Request initiator's table
        EIdd.ContractHoldersMgt o = new EIdd.ContractHoldersMgt();
        bool bRet = o.CreateContractHolder(int.Parse(ddlContractHolder.SelectedValue), int.Parse(ddlCategory.SelectedValue));
        if (bRet) { ajaxWebExtension.showJscriptAlertCx(Page, this, "Request initiator successfully added!!!"); }
        grdView.Rebind();
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem) ((LinkButton) sender).Parent.Parent)
        {
            int lId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["USERID"].ToString());
            var o = new EIdd.ContractHoldersMgt();

            ///TODO: Please update the list of Approval Decision into Enumeration list.
            o.RemoveContractHolder(lId);
            grdView.Rebind();
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Delete Successful!!!");
        }
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var oC = new EIdd.CategoryMgt();
        List<EIdd.Category> olstCats = oC.LstGetServicesByLocationDepartment(int.Parse(ddlLocation.SelectedValue), int.Parse(ddlDepartment.SelectedValue));

        ddlCategory.Items.Clear();

        foreach (var o in olstCats)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sCategory;
            item.Value = o.m_iCategoryId.ToString();

            ddlCategory.Items.Add(item);
            item.DataBind();
        }
    }
    protected void ddlContractHolder_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        EIdd.Utilities.Search(e.Text, ddlContractHolder);
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
            var lbl = e.Item.FindControl("numberLabel") as Label;
            if (lbl != null)
                lbl.Text = (e.Item.ItemIndex + 1).ToString();
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