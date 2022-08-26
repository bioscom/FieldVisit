using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;

public partial class App_IDD_UserControl_oDueDiligenceAuditTrailApproval : System.Web.UI.UserControl
{

    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ViewAuditTrail(long lRequestId)
    {
        RequestIdHF.Value = lRequestId.ToString();
        LoadDataForgrdView(lRequestId);
    }

    private void LoadDataForgrdView(long lRequestId)
    {
        System.Data.DataTable dt = o.GetAuditTrailByRequestId(lRequestId);
        grdView.DataSource = dt;
        grdView.Rebind();
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            if (!string.IsNullOrEmpty(RequestIdHF.Value))
            {
                long lRequestId = long.Parse(RequestIdHF.Value);
                (sender as RadGrid).DataSource = o.GetAuditTrailByRequestId(lRequestId);
            }
        }
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var lbl = e.Item.FindControl("numberLabel") as Label;
            if (lbl != null)
                lbl.Text = (e.Item.ItemIndex + 1).ToString();

            var item = e.Item as GridDataItem;

            if (item.Cells[10].Text == ((int) EIdd.CompletedEnums.CompletedStatus.Yes).ToString())
            {
                item.Cells[10].Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.Yes);
                item.Cells[10].ForeColor = Color.Green;
            }
            else if (item.Cells[10].Text == ((int) EIdd.CompletedEnums.CompletedStatus.No).ToString())
            {
                item.Cells[10].Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.No);
                item.Cells[10].ForeColor = Color.Red;
            }

            o.DueDiligenceAuditTrailStatusManager(item, "Remarks", 4);
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var approveLink = (HyperLink) e.Item.FindControl("approveLink");

            if (approveLink != null)
            {
                approveLink.Attributes["href"] = "javascript:void(0);";
                approveLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AUDITID"], e.Item.ItemIndex);
            }
        }
    }
}