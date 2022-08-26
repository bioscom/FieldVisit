using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_IDD_UserControl_VendorsInformationMgt : aspnetUserControl
{
    EIdd.VendorReportMgt o = new EIdd.VendorReportMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        var oAdmins = new EIdd.Admins();

        System.Data.DataTable dt = oAdmins.GetAdminByUserId(oSessnx.getOnlineUser.m_iUserId);
        if (dt.Rows.Count == 0)
        {
            Response.Redirect("~/App/IDD/Default.aspx");
        }
        else
        {
            grdView.DataSource = o.GetVendors();
        }
    }

    protected void grdView_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var editLink = (HyperLink) e.Item.FindControl("editLink");

            if (editLink != null)
            {
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["VENDORID"], e.Item.ItemIndex);
            }
        }
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int rowCounter = new int();
            Label lbl = e.Item.FindControl("numberLabel") as Label;
            rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
            lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();
        }
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = o.GetVendors();
        }
    }

    protected void grdView_PreRender(object sender, EventArgs e)
    {

    }

    protected void ddlVendor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        System.Data.DataTable dt = !string.IsNullOrEmpty(e.Text) ? o.dtGetVendorBySearch(e.Text) : null;
        EIdd.Utilities.RadComboControlLoader2(dt, ddlVendor);
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        grdView.DataSource = (!string.IsNullOrEmpty(ddlVendor.SelectedValue)) ? o.GetVendorById(long.Parse(ddlVendor.SelectedValue)) : o.GetVendors();
        grdView.Rebind();
    }
}