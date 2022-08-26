using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

public partial class App_BONGACCP_UserControl_oCommitmentsApprovedTele : aspnetUserControl
{
    CommitmentsMgt o = new CommitmentsMgt();
    FinanceDirecor fd = new FinanceDirecor();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadApprovedCommitmentsForgrdView();
        }
    }

    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        string alternateText = (sender as ImageButton).AlternateText;

        grdViewApproved.ExportSettings.IgnorePaging = true;
        grdViewApproved.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
        grdViewApproved.ExportSettings.ExportOnlyData = true;
        grdViewApproved.ExportSettings.OpenInNewWindow = true;
        grdViewApproved.ExportSettings.FileName = "Approved";
        grdViewApproved.MasterTableView.ExportToExcel();
    }

    private void LoadApprovedCommitmentsForgrdView()
    {
        var fd1 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SPDC);
        var fd2 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SNEPCO);
        if (fd1.Count() > 0)
        {
            grdViewApproved.DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SPDC && t.eDecision.m_sDecision.Contains("APPROV")));
        }
        else if (fd2.Count() > 0)
        {
            grdViewApproved.DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SNEPCO && t.eDecision.m_sDecision.Contains("APPROV")));
        }
        else
        {
            //var result = o.dtGetCommitments().AsEnumerable().Where(t => t.Field<decimal>("SPONSORID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("CHECKEDBYID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("APPROVERID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("INITIATORID") == oSessnx.getOnlineUser.m_iUserId
            //&& t.Field<string>("DECISION").Contains("APPROV"));

            var result = o.lstCommitments().Where(t => t.SPONSORID == oSessnx.getOnlineUser.m_iUserId
            || t.CHECKEDBYID == oSessnx.getOnlineUser.m_iUserId
            || t.APPROVERID == oSessnx.getOnlineUser.m_iUserId
            || t.INITIATORID == oSessnx.getOnlineUser.m_iUserId
            && t.eDecision.m_sDecision.Contains("APPROV"));

            if (result.Count() > 0)
                grdViewApproved.DataSource = o.ToDataTable(result);
        }
    }

    protected void grdViewApproved_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var fd1 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SPDC);
        var fd2 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SNEPCO);
        if (fd1.Count() > 0)
        {
            (sender as RadGrid).DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SPDC && t.eDecision.m_sDecision.Contains("APPROV")));
        }
        else if (fd2.Count() > 0)
        {
            (sender as RadGrid).DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SNEPCO && t.eDecision.m_sDecision.Contains("APPROV")));
        }
        else
        {
            var result = o.lstCommitments().Where(t => t.SPONSORID == oSessnx.getOnlineUser.m_iUserId
            || t.CHECKEDBYID == oSessnx.getOnlineUser.m_iUserId
            || t.APPROVERID == oSessnx.getOnlineUser.m_iUserId
            || t.INITIATORID == oSessnx.getOnlineUser.m_iUserId
            && t.eDecision.m_sDecision.Contains("APPROV"));

            if (result.Count() > 0)
                (sender as RadGrid).DataSource = o.ToDataTable(result);
        }

        //var kk = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId);
        //if (kk.Count() > 0)
        //{
        //    (sender as RadGrid).DataSource = o.dtGetCommitments();
        //}
        //else
        //{
        //    (sender as RadGrid).DataSource = o.dtGetCommitmentsAssignedToMeForReview(oSessnx.getOnlineUser.m_iUserId);
        //}
    }

    //private void LoadApprovedCommitmentsForgrdView()
    //{
    //    grdViewApproved.DataSource = o.dtGetCommitmentsAssignedToMeApproved(oSessnx.getOnlineUser.m_iUserId);
    //}

    //protected void grdViewApproved_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    //{
    //    (sender as RadGrid).DataSource = o.dtGetCommitmentsAssignedToMeApproved(oSessnx.getOnlineUser.m_iUserId);
    //}

    protected void grdViewApproved_ItemUpdated(object source, GridUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.KeepInEditMode = true;
            e.ExceptionHandled = true;
            DisplayMessage(true, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " cannot be updated due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " updated");
        }
    }

    protected void grdViewApproved_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("numberLabel") as Label;
            lbl.Text = (e.Item.ItemIndex + 1).ToString();
        }
    }

    private void DisplayMessage(bool isError, string text)
    {
        Label label = (isError) ? this.Label1 : this.Label2;
        label.Text = text;

    }

    protected void grdViewApproved_ItemCommand(object source, GridCommandEventArgs e)
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

    protected void grdViewApproved_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdViewApproved.EditIndexes.Add(0);
            grdViewApproved.Rebind();
        }
    }

    protected void grdViewApproved_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            HyperLink viewLink = (HyperLink) e.Item.FindControl("ViewLink");
            viewLink.Attributes["href"] = "javascript:void(0);";
            viewLink.Attributes["onclick"] = string.Format("return ShowApprovedDetailsForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"], e.Item.ItemIndex);
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            grdViewApproved.MasterTableView.SortExpressions.Clear();
            grdViewApproved.MasterTableView.GroupByExpressions.Clear();
            grdViewApproved.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            grdViewApproved.MasterTableView.SortExpressions.Clear();
            grdViewApproved.MasterTableView.GroupByExpressions.Clear();
            grdViewApproved.MasterTableView.CurrentPageIndex = grdViewApproved.MasterTableView.PageCount - 1;
            grdViewApproved.Rebind();
        }
    }
}