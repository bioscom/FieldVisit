using System;
using System.Data;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

public partial class FlareRequestApprovalAudit : System.Web.UI.Page
{
    FlareApprovalHelper o = new FlareApprovalHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RequestId"] != null)
        {
            long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
            DataTable dt = FlareApprovalHelper.dtGetAuditTrails();
            if (dt.Rows.Count > 0)
                grdView.DataSource = dt.AsEnumerable().Where(t => t.Field<decimal>("IDREQUEST") == lRequestId).CopyToDataTable();

            //grdView.DataSource = FlareApprovalHelper.dtGetAuditTrails().AsEnumerable().Where(t => t.Field<decimal>("IDREQUEST") == lRequestId).CopyToDataTable();
        }
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            if (Request.QueryString["RequestId"] != null)
            {
                long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                DataTable dt = FlareApprovalHelper.dtGetAuditTrails();
                if (dt.Rows.Count > 0)
                    (sender as RadGrid).DataSource = dt.AsEnumerable().Where(t => t.Field<decimal>("IDREQUEST") == lRequestId).CopyToDataTable();
            }
        }
    }

    protected void grdView_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int rowCounter = new int();
            Label lbl = e.Item.FindControl("numberLabel") as Label;
            rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
            lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();

            var item = e.Item as GridDataItem;
            //RequestStatusReporter.reportMyStatus(item, status.OrderIndex);
        }
        
    }

}