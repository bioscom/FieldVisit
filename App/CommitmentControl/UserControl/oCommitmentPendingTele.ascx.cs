using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Drawing;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;

public partial class App_BONGACCP_UserControl_oCommitmentPendingTele : aspnetUserControl
{
    CommitmentsMgt o = new CommitmentsMgt();
    FinanceDirecor fd = new FinanceDirecor();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataForgrdView();
        }
    }

    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        string alternateText = (sender as ImageButton).AlternateText;

        grdView.ExportSettings.IgnorePaging = true;
        grdView.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
        grdView.ExportSettings.ExportOnlyData = true;
        grdView.ExportSettings.OpenInNewWindow = true;
        grdView.ExportSettings.FileName = "Pending";
        grdView.MasterTableView.ExportToExcel();
    }

    private void LoadDataForgrdView()
    {
        GridColumn ViewColumn = grdView.MasterTableView.Columns.FindByUniqueName("TemplateViewColumn");
        ViewColumn.Visible = false;


        var fd1 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SPDC);
        var fd2 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SNEPCO);
        if (fd1.Count() > 0)
        {
            ViewColumn.Visible = true;
            grdView.DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SPDC && t.eDecision.m_sDecision.Contains("TBD")));
        }
        else if (fd2.Count() > 0)
        {
            ViewColumn.Visible = true;
            grdView.DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SNEPCO && t.eDecision.m_sDecision.Contains("TBD")));
        }
        else
        {
            var result = o.lstCommitments().Where(t => t.SPONSORID == oSessnx.getOnlineUser.m_iUserId
            || t.CHECKEDBYID == oSessnx.getOnlineUser.m_iUserId
            || t.APPROVERID == oSessnx.getOnlineUser.m_iUserId
            || t.INITIATORID == oSessnx.getOnlineUser.m_iUserId
            && t.eDecision.m_sDecision.Contains("TBD"));

            if (result.Count() > 0)
                grdView.DataSource = o.ToDataTable(result);
        }
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var fd1 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SPDC);
        var fd2 = fd.GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == oSessnx.getOnlineUser.m_iUserId && t.Field<decimal>("IDOU") == (int)commonEnums.OU.SNEPCO);
        if (fd1.Count() > 0)
        {
            (sender as RadGrid).DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SPDC && t.eDecision.m_sDecision.Contains("TBD")));
        }
        else if (fd2.Count() > 0)
        {
            (sender as RadGrid).DataSource = o.ToDataTable(o.lstCommitments().Where(t => t.IDOU == (int)commonEnums.OU.SNEPCO && t.eDecision.m_sDecision.Contains("TBD")));
        }
        else
        {
            var result = o.lstCommitments().Where(t => t.SPONSORID == oSessnx.getOnlineUser.m_iUserId
            || t.CHECKEDBYID == oSessnx.getOnlineUser.m_iUserId
            || t.APPROVERID == oSessnx.getOnlineUser.m_iUserId
            || t.INITIATORID == oSessnx.getOnlineUser.m_iUserId
            && t.eDecision.m_sDecision.Contains("TBD"));

            //var result = o.dtGetCommitments().AsEnumerable().Where(t => t.Field<decimal>("SPONSORID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("CHECKEDBYID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("APPROVERID") == oSessnx.getOnlineUser.m_iUserId
            //|| t.Field<decimal>("INITIATORID") == oSessnx.getOnlineUser.m_iUserId
            //&& t.Field<string>("DECISION").Contains("TBD"));

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

    protected void grdView_ItemUpdated(object source, GridUpdatedEventArgs e)
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

    protected void grdView_ItemInserted(object source, GridInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
            DisplayMessage(true, "Commitment cannot be inserted due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "Commitment inserted");
        }
    }

    protected void grdView_ItemDeleted(object source, GridDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            DisplayMessage(true, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " cannot be deleted");
        }
        else
        {
            DisplayMessage(false, "Commitment " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"] + " deleted");
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

    private void DisplayMessage(bool isError, string text)
    {
        Label label = (isError) ? this.Label1 : this.Label2;
        label.Text = text;
    }



    protected void ddlCommitment_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlCommitment.SelectedValue))
        {
            var result = o.lstCommitments().Where(t => t.COMMITMENTID == long.Parse(ddlCommitment.SelectedValue));
            if (result.Count() > 0)
            {
                grdView.DataSource = o.ToDataTable(result);
                grdView.Rebind();
            }
        }
        else
        {
            LoadDataForgrdView();
        }
    }

    protected void ddlCommitment_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        var result = o.lstCommitments().Where(t => t.TITLE.Contains(e.Text)).ToList();
        RadComboControlLoader(result, ddlCommitment);
    }

    private static void RadComboControlLoader(List<Commitments> lst, RadComboBox RadDdl)
    {
        foreach (Commitments o in lst)
        {
            var item = new RadComboBoxItem();
            item.Text = o.TITLE;
            item.Value = o.COMMITMENTID.ToString();

            string commitmntNo = o.COMITMNTNO;
            string dateSubmitted = string.Format("{0:dd-MMM-yyy}", o.DATE_SUBMITTED);

            item.Attributes.Add("COMITMNTNO", commitmntNo);
            item.Attributes.Add("DATE_SUBMITTED", dateSubmitted);

            RadDdl.Items.Add(item);
            item.DataBind();
        }
    }



    protected void grdView_ItemCommand(object source, GridCommandEventArgs e)
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

    protected void grdView_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdView.EditIndexes.Add(0);
            grdView.Rebind();
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            HyperLink viewLink = (HyperLink) e.Item.FindControl("ViewLink");
            viewLink.Attributes["href"] = "javascript:void(0);";
            viewLink.Attributes["onclick"] = string.Format("return ShowDetailsForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"], e.Item.ItemIndex);

            HyperLink editLink = (HyperLink) e.Item.FindControl("editLink");
            editLink.Attributes["href"] = "javascript:void(0);";
            editLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["COMMITMENTID"], e.Item.ItemIndex);

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