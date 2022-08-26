using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using System.Web.UI.HtmlControls;

public partial class App_Prices_UserControl_oBCostSavingsApproved : aspnetUserControl
{
    long lPriceId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadClosedOutRecords();
    }

    public void Page_Init()
    {
        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            Response.Redirect("~/Default.aspx?pr=9");
        }
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            List<PriceReviewers> lstReviewers = PriceReviewerHelper.lstGetPriceReviewers();
            bool bRet = lstReviewers.Where(item => item.iUserId == oSessnx.getOnlineUser.m_iUserId) != null ? true : false;
            if (bRet)
            {
                (sender as RadGrid).DataSource = PriceHelper.dtGetPendingPrices();
            }
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var actionLink = (HyperLink) e.Item.FindControl("ViewStatusLink");
            if (actionLink != null)
            {
                actionLink.Attributes["href"] = "javascript:void(0);";
                actionLink.Attributes["onclick"] = string.Format("return ShowStatusForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PRICEID"], e.Item.ItemIndex);
            }
        }
    }

    protected void grdView_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (grdView.MasterTableView.Items.Count > 0)
                grdView.MasterTableView.Items[0].Expanded = true;
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
            if (item.Cells[10].Text == ((int) DiscrepancyStatus.ReviewStatus.PendingReview).ToString())
            {
                item.Cells[10].Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.PendingReview);
                item.Cells[10].Font.Bold = true;
                item.Cells[10].ForeColor = Color.Red;
            }
            else if (item.Cells[10].Text == ((int) DiscrepancyStatus.ReviewStatus.UnderGoingReview).ToString())
            {
                item.Cells[10].Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.UnderGoingReview);
                item.Cells[10].Font.Bold = true;
                item.Cells[10].ForeColor = Color.YellowGreen;
            }
            else if (item.Cells[10].Text == ((int) DiscrepancyStatus.ReviewStatus.ClosedOut).ToString())
            {
                item.Cells[10].Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.ClosedOut);
                item.Cells[10].Font.Bold = true;
                item.Cells[10].ForeColor = Color.Green;
            }
        }
    }

    protected void grdView_ItemCommand(object source, GridCommandEventArgs e)
    {

    }

    protected void lnkViewAttachments_Click(object sender, EventArgs e)
    {
        var lnk = (LinkButton) sender;
        var nesteditem = (GridNestedViewItem) lnk.NamingContainer;

        if (nesteditem != null)
        {
            long lPriceId = long.Parse(lnk.Attributes["PRICEID"].ToString());
            //iframe id = "fileLoader"
            var pp = (HtmlGenericControl) nesteditem.FindControl("fileLoader");
            Price o = PriceHelper.objGetPriceById(lPriceId);
            PriceHelper.PreviewLoadedFile(o, pp);
        }
    }

    //public void LoadPendingRecords()
    //{
    //    //If the logged on user is found on the Reviewers table, he should be able to see all reports with Action button enabled
    //    List<PriceReviewers> lstReviewers = PriceReviewerHelper.lstGetPriceReviewers();
    //    foreach (PriceReviewers o in lstReviewers)
    //    {
    //        if (o.iUserId == oSessnx.getOnlineUser.m_iUserId)
    //        {
    //            //lnkAddReviewer.Visible = true;
    //            LoadPendingSubmittedPrices();
    //            break;
    //        }
    //    }

    //    PriceReviewerHelper.FormatReport(grdView);
    //}

    public void LoadClosedOutRecords()
    {
        //If the logged on user is found on the Reviewers table, he should be able to see all reports with Action button enabled
        List<PriceReviewers> lstReviewers = PriceReviewerHelper.lstGetPriceReviewers();
        bool bRet = lstReviewers.Where(item => item.iUserId == oSessnx.getOnlineUser.m_iUserId) != null ? true : false;
        if (bRet)
        {
            grdView.DataSource = PriceHelper.dtGetClosedOutPrices();
            grdView.Rebind();
        }
        else
        {
            LoadMyApprovedPrices(oSessnx.getOnlineUser.m_iUserId);
        }
    }

    public void LoadMyApprovedPrices(int iUserId)
    {
        grdView.DataSource = PriceHelper.dtGetMyApprovedPrices(iUserId);
        grdView.DataBind();
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