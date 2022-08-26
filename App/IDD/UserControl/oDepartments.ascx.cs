using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;

public partial class App_IDD_UserControl_oDepartments : System.Web.UI.UserControl
{
    EIdd.DepartmentsMgt o = new EIdd.DepartmentsMgt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataForgrdView();
        }
    }

    private void LoadDataForgrdView()
    {
        grdView.DataSource = o.GetDepartments();
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = o.GetDepartments();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //Load all the Request initiators
    }

    protected void grdView_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
    {
        GridDataItem dataItem = e.DetailTableView.ParentItem;
        var o = new EIdd.CategoryMgt();

        int iDeptId = int.Parse(dataItem.GetDataKeyValue("DEPTID").ToString());
        e.DetailTableView.DataSource = o.GetServicesByDepartment(iDeptId);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

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