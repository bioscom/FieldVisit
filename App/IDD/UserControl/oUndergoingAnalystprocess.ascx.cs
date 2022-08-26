using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using System.Data;
using EIdd;

public partial class App_IDD_UserControl_oUndergoingAnalystprocess : aspnetUserControl
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.IDDRequestDocsMgt oM = new EIdd.IDDRequestDocsMgt();
    EIdd.LeadFocalPoint cppFP = new EIdd.LeadFocalPoint();
    appUsersHelper hlp = new appUsersHelper();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataForgrdView();
        }
    }

    //private EIdd.eIddUsers CheckIfLogInUserIsCpFocalPoint()
    //{
    //    EIdd.eIddUsers o = cppFP.objGetLeadFocalPointByUserId(oSessnx.getOnlineUser.m_iUserId);
    //    return o;
    //}

    private void LoadDataForgrdView()
    {
        grdView.DataSource = o.GetRequestsAssignedToMeAnalyst(oSessnx.getOnlineUser.m_iUserId);
        //grdView.DataSource = o.lstRequests().Where(t => t.m_iAnalystId == oSessnx.getOnlineUser.m_iUserId && t.m_iVSR == (int)CompletedEnums.CompletedStatus.No);
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = o.GetRequestsAssignedToMeAnalyst(oSessnx.getOnlineUser.m_iUserId);
            //(sender as RadGrid).DataSource =  o.lstRequests().Where(t => t.m_iAnalystId == oSessnx.getOnlineUser.m_iUserId && t.m_iVSR == (int)CompletedEnums.CompletedStatus.No);
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var editLink = (HyperLink) e.Item.FindControl("editLink");
            var actionLink = (HyperLink) e.Item.FindControl("actionLink");

            if (editLink != null)
            {
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"], e.Item.ItemIndex);
            }

            if (actionLink != null)
            {
                actionLink.Attributes["href"] = "javascript:void(0);";
                actionLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"], e.Item.ItemIndex);
            }
        }
    }

    protected void DocumentsGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        try
        {
            int index = !(Session["RowIndex"] == null) ? int.Parse(Session["RowIndex"].ToString()) : 0;

            GridDataItem item = grdView.MasterTableView.Items[index];

            long lRequestId = long.Parse(item.GetDataKeyValue("REQUESTID").ToString());
            (sender as RadGrid).DataSource = oM.dtGetDocsByRequestId(lRequestId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
    {
        GridDataItem dataItem = e.DetailTableView.ParentItem;

        long lRequestId = long.Parse(dataItem.GetDataKeyValue("REQUESTID").ToString());
        e.DetailTableView.DataSource = oM.dtGetDocsByRequestId(lRequestId);

        //switch (e.DetailTableView.Name)
        //{
        //    case "Docs":
        //        {
        //            long lRequestId = long.Parse(dataItem.GetDataKeyValue("REQUESTID").ToString());
        //            e.DetailTableView.DataSource = o.dtGetDocsByRequestId(lRequestId);

        //            break;
        //        }

        //    case "OrderDetails":
        //        {
        //            string OrderID = dataItem.GetDataKeyValue("OrderID").ToString();
        //            e.DetailTableView.DataSource = null;
        //            break;
        //        }
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
            var lbl = e.Item.FindControl("numberLabel") as Label;
            if (lbl != null)
                lbl.Text = (e.Item.ItemIndex + 1).ToString();

            var item = e.Item as GridDataItem;
            if (item.Cells[6].Text == "1")
            {
                item.Cells[6].Text = "New";
                item.Cells[6].Font.Bold = true;
                item.Cells[6].ForeColor = Color.Navy;
            }
            else if (item.Cells[6].Text == "2")
            {
                item.Cells[6].Text = "Renewal";
                item.Cells[6].Font.Bold = true;
                item.Cells[6].ForeColor = Color.Red;
            }
        }
    }

    private void DisplayMessage(bool isError, string text)
    {
        Label label = (isError) ? this.Label1 : this.Label2;
        label.Text = text;
    }

    protected void grdView_ItemCommand(object source, GridCommandEventArgs e)
    {
        Session["RowIndex"] = e.Item.ItemIndex.ToString();

        if (e.CommandName == RadGrid.ExpandCollapseCommandName)
        {
            var details = (ASP.app_idd_usercontrol_odetails_ascx) ((GridDataItem) e.Item).ChildItem.FindControl("oDetails");
            var grid = (ASP.app_idd_usercontrol_oduediligenceaudittrail_ascx) ((GridDataItem) e.Item).ChildItem.FindControl("oDueDiligenceAuditTrail");
            if (!e.Item.Expanded)
            {
                long lRequestId = long.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"].ToString());
                grid.ViewAuditTrail(lRequestId);
                long lVendorId = long.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["VENDORID"].ToString());
                details.ViewDetailsByVendor(lVendorId, lRequestId);
            }
        }

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
        //if (!IsPostBack)
        //{
        //    if (grdView.MasterTableView.Items.Count > 0)
        //        grdView.MasterTableView.Items[0].Expanded = true;
        //}
    }

    protected void btnDocument_Click(object sender, EventArgs e)
    {
        var lb = (LinkButton) sender;
        var item = (GridDataItem) lb.NamingContainer;
        if (item != null)
        {
            long lDocId = long.Parse(lb.Attributes["IDDOCS"].ToString());
            DownloadFile(lDocId);
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem) ((LinkButton) sender).Parent.Parent)
        {
            long lId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["DOCSID"].ToString());
            oM.deleteDocById(lId);
            //grdView.Rebind();
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Document deleted successfully!!!");
        }
    }

    protected void lnkRejectRequest_Click(object sender, EventArgs e)
    {
        var button = (LinkButton) sender;
        var nesteditem = (GridNestedViewItem) button.NamingContainer;
        var panel = (Panel) nesteditem.FindControl("pnlRejection");
        if (panel != null)
        {
            panel.Visible = true;
        }
    }

    protected void ddlAnalyst_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        var o = (RadComboBox) sender;
        EIdd.Utilities.Search(e.Text, o);
    }

    private void DownloadFile(long lDocId)
    {
        try
        {
            EIdd.RequestDocs ok = oM.objGetRequestDocByDocId(lDocId);

            //string strfn = Convert.ToString(DateTime.Now.ToFileTime()) + ok.m_sFileName;
            string strfn = ok.m_sFileName;

            //retrieving binary data of pdf from datatable to byte array
            byte[] blob = ok.m_bDocs;

            var o = new RadAjaxPanel();

            //o.ResponseScripts.Add()

            HttpContext.Current.Response.ContentType = ok.m_sFileType;
            HttpContext.Current.Response.AddHeader("content-disposition", "Attachment; filename=" + strfn);
            HttpContext.Current.Response.AddHeader("content-length", blob.Length.ToString());
            HttpContext.Current.Response.BinaryWrite(blob);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest(); //instead of Response.End()
            HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
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

    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        string alternateText = (sender as ImageButton).AlternateText;
        #region [ XSLX FORMAT ]
        if (alternateText == "Xlsx")
        {
            grdView.MasterTableView.GetColumn("EmployeeID").HeaderStyle.BackColor = Color.LightGray;
            grdView.MasterTableView.GetColumn("EmployeeID").ItemStyle.BackColor = Color.LightGray;
        }
        #endregion
        grdView.ExportSettings.Excel.Format = (GridExcelExportFormat) Enum.Parse(typeof(GridExcelExportFormat), alternateText);
        //grdView.ExportSettings.IgnorePaging = CheckBox1.Checked;
        grdView.ExportSettings.ExportOnlyData = true;
        grdView.ExportSettings.OpenInNewWindow = true;
        grdView.MasterTableView.ExportToExcel();
    }
}