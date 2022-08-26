using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using System.Data;

public partial class App_IDD_UserControl_oIDDLeadFocalPoint : System.Web.UI.UserControl
{
    EIdd.LeadFocalPoint o = new EIdd.LeadFocalPoint();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataForgrdView();
        }
    }

    private void LoadDataForgrdView()
    {
        grdView.DataSource = o.GetLeadFocalPoints();
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = o.GetLeadFocalPoints();
        }
    }

    protected void ddlAdmin_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        EIdd.Utilities.Search(e.Text, ddlAdmin);
    }

    private void RadComboControlLoader(DataTable dt, RadComboBox RadDdl)
    {
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var item = new RadComboBoxItem();
                item.Text = (string) dr["FULLNAME"];
                item.Value = dr["USERID"].ToString();

                string email = dr["EMAIL"].ToString();
                string refInd = dr["REFIND"].ToString();

                item.Attributes.Add("EMAIL", email);
                item.Attributes.Add("REFIND", refInd);
                //item.Value += ":" + refInd;

                RadDdl.Items.Add(item);
                item.DataBind();
            }
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //Load all the Request initiators
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Insert an Administrator into Admins table
        bool bRet = o.AddLeadFocalPoint(int.Parse(ddlAdmin.SelectedValue));
        LoadDataForgrdView();
        if (bRet) { ajaxWebExtension.showJscriptAlertCx(Page, this, "Successfully added as a CP IDD Focal Point!!!"); }
        grdView.Rebind();
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem) ((LinkButton) sender).Parent.Parent)
        {
            int lId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["USERID"].ToString());
            var o = new EIdd.LeadFocalPoint();

            ///TODO: Please update the list of Approval Decision into Enumeration list.
            o.RemoveLeadFocalPoint(lId);
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