using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_Prices_Findings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdView.DataSource = FindingsRecomendationsHelper.dtGetRecommendation();
            //grdView.Rebind();
        }
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = FindingsRecomendationsHelper.dtGetRecommendation();

            //List<PriceReviewers> lstReviewers = PriceReviewerHelper.lstGetPriceReviewers();
            //bool bRet = lstReviewers.Where(item => item.iUserId == oSessnx.getOnlineUser.m_iUserId) != null ? true : false;
            //if (bRet)
            //{
            //    (sender as RadGrid).DataSource = PriceHelper.dtGetPendingPrices();
            //}
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var actionLink = (HyperLink) e.Item.FindControl("editLink");
            if (actionLink != null)
            {
                actionLink.Attributes["href"] = "javascript:void(0);";
                actionLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RECOMENDID"], e.Item.ItemIndex);
            }

            //var editLink = (HyperLink) e.Item.FindControl("editLink");
            //if (editLink != null)
            //{
            //    editLink.Attributes["href"] = "javascript:void(0);";
            //    editLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PRICEID"], e.Item.ItemIndex);
            //}
        }
    }

    protected void grdView_PreRender(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (grdView.MasterTableView.Items.Count > 0)
        //        grdView.MasterTableView.Items[0].Expanded = true;
        //}
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var lbl = e.Item.FindControl("numberLabel") as Label;
            if (lbl != null)
                lbl.Text = (e.Item.ItemIndex + 1).ToString();

            //var item = e.Item as GridDataItem;
            //if (item.Cells[12].Text == ((int) DiscrepancyStatus.ReviewStatus.PendingReview).ToString())
            //{
            //    item.Cells[12].Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.PendingReview);
            //    item.Cells[12].Font.Bold = true;
            //    item.Cells[12].ForeColor = Color.Red;
            //}
            //else if (item.Cells[12].Text == ((int) DiscrepancyStatus.ReviewStatus.UnderGoingReview).ToString())
            //{
            //    item.Cells[12].Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.UnderGoingReview);
            //    item.Cells[12].Font.Bold = true;
            //    item.Cells[12].ForeColor = Color.YellowGreen;
            //}
            //else if (item.Cells[12].Text == ((int) DiscrepancyStatus.ReviewStatus.ClosedOut).ToString())
            //{
            //    item.Cells[12].Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.ClosedOut);
            //    item.Cells[12].Font.Bold = true;
            //    item.Cells[12].ForeColor = Color.Green;
            //}
        }
    }

    protected void grdView_ItemCommand(object source, GridCommandEventArgs e)
    {
        //if (e.CommandName == RadGrid.ExpandCollapseCommandName)
        //{
        //    if (e.Item.Expanded)
        //    {
        //        long lPriceId = long.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PRICEID"].ToString());
        //        var ht = (RadPageView) ((GridDataItem) e.Item).ChildItem.FindControl("DocumentsPageView");
        //        var pp = (HtmlGenericControl) ht.FindControl("fileLoader");
        //        //var pp = (HtmlGenericControl) e.Item.FindControl("fileLoader");
        //        Price o = PriceHelper.objGetPriceById(lPriceId);
        //        PriceHelper.PreviewLoadedFile(o, pp);
        //    }
        //}

        //var lnk = (LinkButton) sender;
        //var nesteditem = (GridNestedViewItem) lnk.NamingContainer;

        //if (nesteditem != null)
        //{
        //    long lPriceId = long.Parse(lnk.Attributes["PRICEID"].ToString());
        //    //iframe id = "fileLoader"
        //    var pp = (HtmlGenericControl) nesteditem.FindControl("fileLoader");
        //    Price o = PriceHelper.objGetPriceById(lPriceId);
        //    PriceHelper.PreviewLoadedFile(o, pp);
        //}
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