using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

public partial class App_BONGACCP_UserControl_oCommitmentsRejectedTele : aspnetUserControl
{
    CommitmentsMgt o = new CommitmentsMgt();
    FinanceDirecor fd = new FinanceDirecor();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRejectedCommitmentsForgrdView();
        }
    }

    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        string alternateText = (sender as ImageButton).AlternateText;

        grdViewRejected.ExportSettings.IgnorePaging = true;
        grdViewRejected.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
        grdViewRejected.ExportSettings.ExportOnlyData = true;
        grdViewRejected.ExportSettings.OpenInNewWindow = true;
        grdViewRejected.ExportSettings.FileName = "Rejected";
        grdViewRejected.MasterTableView.ExportToExcel();
    }

    private void LoadRejectedCommitmentsForgrdView()
    {
        var fd1 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SPDC);
        var fd2 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SNEPCO);
        if (fd1.Count() > 0)
        {
            grdViewRejected.DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SPDC && !t.eDecision.m_sDecision.Contains("APPROV")
            && !t.eDecision.m_sDecision.Contains("TBD")));
        }
        else if (fd2.Count() > 0)
        {
            grdViewRejected.DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SNEPCO && !t.eDecision.m_sDecision.Contains("APPROV")
            && !t.eDecision.m_sDecision.Contains("TBD")));
        }
        else
        {
            var result = o.lstCommitments().Where(t => t.SPONSORID == oSessnx.getOnlineUser.m_iUserId
            || t.CHECKEDBYID == oSessnx.getOnlineUser.m_iUserId
            || t.APPROVERID == oSessnx.getOnlineUser.m_iUserId
            || t.INITIATORID == oSessnx.getOnlineUser.m_iUserId
            && !t.eDecision.m_sDecision.Contains("APPROV")
            && !t.eDecision.m_sDecision.Contains("TBD"));


            //var result = o.dtGetCommitments().AsEnumerable().Where(t => t.Field<decimal>("SPONSORID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("CHECKEDBYID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("APPROVERID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("INITIATORID") == oSessnx.getOnlineUser.m_iUserId
            //&& !t.Field<string>("DECISION").Contains("APPROV")
            //&& !t.Field<string>("DECISION").Contains("TBD"));

            //"AND ((BONGA_APPROVALDECISION.DECISION NOT lIKE '%APPROV%') AND (BONGA_APPROVALDECISION.DECISION NOT lIKE '%TBD%')) ORDER BY BONGA_COMMITMENTS.COMMITMENTID DESC";
            if (result.Count() > 0)
                grdViewRejected.DataSource = o.ToDataTable(result);
        }
    }

    protected void grdViewRejected_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var fd1 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SPDC);
        var fd2 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SNEPCO);
        if (fd1.Count() > 0)
        {
            (sender as RadGrid).DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SPDC && !t.eDecision.m_sDecision.Contains("APPROV")
            && !t.eDecision.m_sDecision.Contains("TBD")));
        }
        else if (fd2.Count() > 0)
        {
            (sender as RadGrid).DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SNEPCO && !t.eDecision.m_sDecision.Contains("APPROV")
            && !t.eDecision.m_sDecision.Contains("TBD")));
        }
        else
        {
            var result = o.lstCommitments().Where(t => t.SPONSORID == oSessnx.getOnlineUser.m_iUserId
            || t.CHECKEDBYID == oSessnx.getOnlineUser.m_iUserId
            || t.APPROVERID == oSessnx.getOnlineUser.m_iUserId
            || t.INITIATORID == oSessnx.getOnlineUser.m_iUserId
            && !t.eDecision.m_sDecision.Contains("APPROV")
            && !t.eDecision.m_sDecision.Contains("TBD"));

            if (result.Count() > 0)
                (sender as RadGrid).DataSource = o.ToDataTable(result);
        }
    }

    //private void LoadRejectedCommitmentsForgrdView()
    //{
    //    grdViewRejected.DataSource = o.dtGetCommitmentsAssignedToMeRejected(oSessnx.getOnlineUser.m_iUserId);
    //}

    //protected void grdViewRejected_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    //{
    //    (sender as RadGrid).DataSource = o.dtGetCommitmentsAssignedToMeRejected(oSessnx.getOnlineUser.m_iUserId);
    //}

    protected void grdViewRejected_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var lbl = e.Item.FindControl("numberLabel") as Label;
            lbl.Text = (e.Item.ItemIndex + 1).ToString();
        }
    }

    private void DisplayMessage(bool isError, string text)
    {
        Label label = (isError) ? this.Label1 : this.Label2;
        label.Text = text;

    }

    protected void grdViewRejected_ItemCommand(object source, GridCommandEventArgs e)
    {
        //if (e.CommandName == RadGrid.InitInsertCommandName) //"Add new" button clicked
        //{
        //    GridEditCommandColumn editColumn = (GridEditCommandColumn) grdView.MasterTableView.GetColumn("EditCommandColumn");
        //    editColumn.Visible = false;
        //}
        //else if (e.CommandName == RadGrid.RebindGridCommandName && e.Item.OwnerTableView.IsItemInserted)
        //{
        //    e.Canceled = true;
        //}
        //else
        //{
        //    GridEditCommandColumn editColumn = (GridEditCommandColumn) grdView.MasterTableView.GetColumn("EditCommandColumn");
        //    if (!editColumn.Visible)
        //        editColumn.Visible = true;
        //}
    }

    protected void grdViewRejected_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdViewRejected.EditIndexes.Add(0);
            grdViewRejected.Rebind();
        }
    }

    protected void grdViewRejected_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var viewLink = (HyperLink) e.Item.FindControl("ViewLink");
            viewLink.Attributes["href"] = "javascript:void(0);";
            viewLink.Attributes["onclick"] = string.Format("return ShowRejectedDetailsForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"], e.Item.ItemIndex);
        }
    }

    protected void lnkRepresent_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem) ((LinkButton) sender).Parent.Parent)
        {
            long lId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["COMMITMENTID"].ToString());

            ///TODO: Please update the list of Approval Decision into Enumeration list.
            o.RepresentForReview(lId, 41); //Where 41 = TBD
            LoadRejectedCommitmentsForgrdView();
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Commitment successfully sent for re-presentaion!!!");
        }
        grdViewRejected.Rebind();
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            grdViewRejected.MasterTableView.SortExpressions.Clear();
            grdViewRejected.MasterTableView.GroupByExpressions.Clear();
            grdViewRejected.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            grdViewRejected.MasterTableView.SortExpressions.Clear();
            grdViewRejected.MasterTableView.GroupByExpressions.Clear();
            grdViewRejected.MasterTableView.CurrentPageIndex = grdViewRejected.MasterTableView.PageCount - 1;
            grdViewRejected.Rebind();
        }
    }
}