using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_BONGACCP_UserControl_oSavingsStatistics : System.Web.UI.UserControl
{
    OUMgt o = new OUMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        grdView.DataSource = o.dtGetOus();
    }

    protected void grdView_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item != null)
        {
            Session["RowIndex"] = e.Item.ItemIndex.ToString();
        }

        if (e.CommandName == RadGrid.ExpandCollapseCommandName)
        {
            var SavingsBreakDown = (ASP.app_commitmentcontrol_usercontrol_osavingsbreakdown_ascx)((GridDataItem)e.Item).ChildItem.FindControl("oSavingsBreakDown");
            //var approval = (ASP.app_idd_usercontrol_ovmiddapproval_ascx) ((GridDataItem) e.Item).ChildItem.FindControl("oVMIDDApproval");
            if (!e.Item.Expanded)
            {
                int iOuId = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDOU"].ToString());
                SavingsBreakDown.LoadDetailsByOuId(iOuId);
            }
        }
    }

    protected void grdView_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
    {
        GridDataItem parentItem = e.DetailTableView.ParentItem as GridDataItem;
        if (parentItem.Edit)
        {
            return;
        }

        var SavingsBreakDown = (ASP.app_commitmentcontrol_usercontrol_osavingsbreakdown_ascx)(parentItem).ChildItem.FindControl("oSavingsBreakDown");
        int iOuId = int.Parse(parentItem.OwnerTableView.DataKeyValues[parentItem.ItemIndex]["IDOU"].ToString());
        SavingsBreakDown.LoadDetailsByOuId(iOuId);

        //if (e.DetailTableView.DataMember == "OrderDetails")
        //{
        //    dsNWind1.OrderDetails.Clear();
        //    daOrderDetails.SelectCommand.CommandText = "Select * from [Order Details] where OrderID = " + parentItem["OrderID"].Text;
        //    daOrderDetails.Fill(dsNWind1.OrderDetails);
        //}
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = o.dtGetOus();
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridDataItem)
        //{
        //    var SavingsBreakDown = (ASP.app_commitmentcontrol_usercontrol_osavingsbreakdown_ascx)((GridDataItem)e.Item).ChildItem.FindControl("oSavingsBreakDown");
        //    int iOuId = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDOU"].ToString());
        //    SavingsBreakDown.LoadDetailsByOuId(iOuId);
        //}

        //if (e.Item is GridDataItem)
        //{
        //    var editLink = (HyperLink)e.Item.FindControl("editLink");
        //    var approveLink = (HyperLink)e.Item.FindControl("approveLink");

        //    if (editLink != null)
        //    {
        //        editLink.Attributes["href"] = "javascript:void(0);";
        //        editLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"], e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["VENDORID"], e.Item.ItemIndex);
        //    }

        //    if (approveLink != null)
        //    {
        //        approveLink.Attributes["href"] = "javascript:void(0);";
        //        approveLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"], e.Item.ItemIndex);
        //    }
        //}
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            //if (e.Item is GridDataItem)
            //{
            //    int rowCounter = new int();
            //    Label lbl = e.Item.FindControl("numberLabel") as Label;
            //    rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
            //    lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();                
            //}
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}