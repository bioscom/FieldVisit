using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_FieldVisit_UserControl_frmDistricts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void GetDisctrictBySuperintendent(int SuperintendentId)
    {
        grdView.DataSource = District.dtGetDistrictBySuperintendent(SuperintendentId);
        grdView.Rebind();

        superintendentIdHF.Value = SuperintendentId.ToString();
    }

    protected void grdView_ItemCommand(object source, GridCommandEventArgs e)
    {
        //Session["RowIndex"] = e.Item.ItemIndex.ToString();

        if (e.CommandName == RadGrid.ExpandCollapseCommandName)
        {
            var details = (ASP.app_fieldvisit_usercontrol_frmfacilities_ascx) ((GridDataItem) e.Item).ChildItem.FindControl("frmFacilities");
            if (!e.Item.Expanded)
            {
                int iDistrictId = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID_DISTRICT"].ToString());
                details.GetFacilitiesByDisctrict(iDistrictId);
            }
        }
    }

    protected void grdView_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
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

    protected void grdView_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = District.dtGetDistrictBySuperintendent(int.Parse(superintendentIdHF.Value));
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
}