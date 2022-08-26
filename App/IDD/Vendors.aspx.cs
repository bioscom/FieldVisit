using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using System.Data;
using System.Globalization;
using Telerik.Web.Spreadsheet;
using Telerik.Web.UI.GridExcelBuilder;
using xi = Telerik.Web.UI.ExportInfrastructure;

public partial class App_IDD_Vendors : aspnetPage
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.Corporate oCorp = new EIdd.Corporate();
    EIdd.Analysts oAnal = new EIdd.Analysts();
    EIdd.IDDRequestDocsMgt oM = new EIdd.IDDRequestDocsMgt();

    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        string alternateText = (sender as ImageButton).AlternateText;

        grdView.ExportSettings.IgnorePaging = true;
        grdView.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
        grdView.ExportSettings.ExportOnlyData = true;
        grdView.ExportSettings.OpenInNewWindow = true;
        grdView.MasterTableView.ExportToExcel();
    }

    protected void grdView_HtmlExporting(object sender, GridHTMLExportingEventArgs e)
    {

    }

    protected void grdView_BiffExporting(object sender, GridBiffExportingEventArgs e)
    {

    }

    protected void grdView_ExcelMLWorkBookCreated(object sender, GridExcelMLWorkBookCreatedEventArgs e)
    {
        foreach (RowElement row in e.WorkBook.Worksheets[0].Table.Rows)
        {
            row.Cells[0].StyleValue = "Style1";
        }

        StyleElement style = new StyleElement("Style1");
        style.InteriorStyle.Pattern = InteriorPatternType.Solid;
        style.InteriorStyle.Color = Color.LightGray;
        e.WorkBook.Styles.Add(style);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        VsrValidityComputation();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        EIdd.eIddUsers oCP = o.CheckIfLogInUserIsCpFocalPoint(oSessnx.getOnlineUser.m_iUserId);
        DataTable dt = oCorp.GetCorporateUserByUserId(oSessnx.getOnlineUser.m_iUserId);
        EIdd.eIddUsers oa = oAnal.objGetAnalystByUserId(oSessnx.getOnlineUser.m_iUserId);

        if (!IsPostBack)
        {
            //GridColumn remarks = grdView.MasterTableView.Columns.FindByUniqueName("Remarks");
            GridColumn Further = grdView.MasterTableView.Columns.FindByUniqueName("Further");
            GridColumn UpdateColumn = grdView.MasterTableView.Columns.FindByUniqueName("UpdateColumn");
            GridColumn DeleteColumn = grdView.MasterTableView.Columns.FindByUniqueName("DeleteColumn");

            //remarks.Visible = false;
            Further.Visible = false;
            UpdateColumn.Visible = false;
            DeleteColumn.Visible = false;

            if (oCP.m_iUserId != 0)
            {
                //remarks.Visible = true;
                Further.Visible = true;
                UpdateColumn.Visible = true;
                DeleteColumn.Visible = true;
                LoadDataForgrdView();
            }
            else if (oa.m_iUserId != 0)
            {
                //remarks.Visible = true;
                Further.Visible = true;
                LoadDataForgrdView();
            }
            else if (dt.Rows.Count != 0) LoadDataForgrdView();
            else Response.Redirect("~/App/IDD/Default.aspx");
        }


        if (!IsPostBack)
        {
            LoadDataForgrdView();
            LoadControls();

        }
        RadHtmlChart1.DataSource = GetData();
        RadHtmlChart1.DataBind();
    }

    private void VsrValidityComputation()
    {
        var expiredIdds = o.LstGetExpiredIDDs();
        foreach (EIdd.ExpiredIdds t in expiredIdds)
        {
            //Change the status to 3(Amber) and Comments to Expired.
            bool bRet = o.IDDExpired(t.m_lRequestId);
        }
    }

    private DataTable GetData()
    {
        string greens = "Vendors currently confirmed as fully compliant in terms of IDD screening and have no ABC or NCDMB related sanctions.";
        string amber = "Vendors currently under review with either IDD refresh in progress or awaiting Line/E&C mitigation of identified issues. Vendors with deadlocked amber status are to be excluded from non-NAPIMS tenders/contracts";
        string reds = "Vendors declines or de-registered due to IDD, ABC or Regulatory issues - not available for further third party use (do not engage in nany form without appropriate approval)";
        string purples = "vendors with historic red flags that are old enough to be no longer significant. Line may proceeed without additional consultation, unless they choose to discuss issue further.";
        string grays = "Vendors whose annual contract value is less than $20,000 or its Naira equivalent";

        int iGreens = o.GetCompletedRequestByStatus((int)(EIdd.ReportStatusEnums.VendorStatus.Green)).Rows.Count;
        int iAmbers = o.GetCompletedRequestByStatus((int)(EIdd.ReportStatusEnums.VendorStatus.Amber)).Rows.Count;
        int iReds = o.GetCompletedRequestByStatus((int)(EIdd.ReportStatusEnums.VendorStatus.Red)).Rows.Count;
        int iPurples = o.GetCompletedRequestByStatus((int)(EIdd.ReportStatusEnums.VendorStatus.Purple)).Rows.Count;
        int iGrays = o.GetCompletedRequestByStatus((int)(EIdd.ReportStatusEnums.VendorStatus.Gray)).Rows.Count;

        var tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Barrels"));
        tbl.Columns.Add(new DataColumn("Country"));
        tbl.Columns.Add(new DataColumn("Color"));
        tbl.Columns.Add(new DataColumn("IsExploded"));

        tbl.Rows.Add(new object[] { iGreens, greens, "Green", true });
        tbl.Rows.Add(new object[] { iAmbers, amber, "Gold", false });
        tbl.Rows.Add(new object[] { iReds, reds, "Red", false });
        tbl.Rows.Add(new object[] { iPurples, purples, "Purple", false });
        tbl.Rows.Add(new object[] { iGrays, grays, "Gray", false });

        return tbl;
    }

    private void LoadControls()
    {
        var item = new RadComboBoxItem();

        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Amber);
        item.BackColor = Color.Gold;
        item.Value = ((int)(EIdd.ReportStatusEnums.VendorStatus.Amber)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Gray);
        item.BackColor = Color.Gray;
        item.Value = ((int)(EIdd.ReportStatusEnums.VendorStatus.Gray)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Green);
        item.BackColor = Color.Green;
        item.Value = ((int)(EIdd.ReportStatusEnums.VendorStatus.Green)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Purple);
        item.BackColor = Color.Purple;
        item.Value = ((int)(EIdd.ReportStatusEnums.VendorStatus.Purple)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Red);
        item.BackColor = Color.Red;
        item.Value = ((int)(EIdd.ReportStatusEnums.VendorStatus.Red)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();
    }

    private void LoadDataForgrdView()
    {
        //grdView.DataSource = o.GetVendors();
        grdView.DataSource = o.GetVSRReport();
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            EIdd.eIddUsers oCP = o.CheckIfLogInUserIsCpFocalPoint(oSessnx.getOnlineUser.m_iUserId);
            EIdd.eIddUsers oa = oAnal.objGetAnalystByUserId(oSessnx.getOnlineUser.m_iUserId);

            GridColumn Further = grdView.MasterTableView.Columns.FindByUniqueName("Further");
            GridColumn UpdateColumn = grdView.MasterTableView.Columns.FindByUniqueName("UpdateColumn");

            Further.Visible = false;
            UpdateColumn.Visible = false;

            if (oCP.m_iUserId != 0)
            {
                Further.Visible = true;
                UpdateColumn.Visible = true;
                //GetInfo(sender);
            }
            else if (oa.m_iUserId != 0) Further.Visible = true;
            (sender as RadGrid).DataSource = (!string.IsNullOrEmpty(ddlVendor.SelectedValue)) ? o.GetVSRReportByVendorId(long.Parse(ddlVendor.SelectedValue)) : o.GetVSRReport();
        }
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        EIdd.eIddUsers oCP = o.CheckIfLogInUserIsCpFocalPoint(oSessnx.getOnlineUser.m_iUserId);
        EIdd.eIddUsers oa = oAnal.objGetAnalystByUserId(oSessnx.getOnlineUser.m_iUserId);

        GridColumn Further = grdView.MasterTableView.Columns.FindByUniqueName("Further");
        GridColumn UpdateColumn = grdView.MasterTableView.Columns.FindByUniqueName("UpdateColumn");

        Further.Visible = false;
        UpdateColumn.Visible = false;

        if (oCP.m_iUserId != 0)
        {
            Further.Visible = true;
            UpdateColumn.Visible = true;
            grdView.DataSource = (!string.IsNullOrEmpty(ddlVendor.SelectedValue)) ? o.GetVSRReportByVendorId(long.Parse(ddlVendor.SelectedValue)) : o.GetVSRReport();
            grdView.Rebind();
        }
        else if (oa.m_iUserId != 0)
        {
            //remarks.Visible = true;
            Further.Visible = true;
            grdView.DataSource = (!string.IsNullOrEmpty(ddlVendor.SelectedValue)) ? o.GetVSRReportByVendorId(long.Parse(ddlVendor.SelectedValue)) : o.GetVSRReport();
            grdView.Rebind();
        }
        else
        {
            grdView.DataSource = (!string.IsNullOrEmpty(ddlVendor.SelectedValue)) ? o.GetVSRReportByVendorId(long.Parse(ddlVendor.SelectedValue)) : o.GetVSRReport();
            grdView.Rebind();
        }
    }

    protected void ddlStatusFilter_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        grdView.DataSource = o.GetCompletedRequestByStatus(int.Parse(ddlStatusFilter.SelectedValue));
        grdView.Rebind();
    }

    protected void ddlVendor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        //EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
        DataTable dt = !string.IsNullOrEmpty(e.Text) ? o.dtGetRequestBySearch(e.Text) : null;
        EIdd.Utilities.RadComboControlLoader2(dt, ddlVendor);
    }

    protected void grdView_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item != null)
        {
            Session["RowIndex"] = e.Item.ItemIndex.ToString();
        }

        if (e.CommandName == RadGrid.ExpandCollapseCommandName)
        {
            var details = (ASP.app_idd_usercontrol_odetails_ascx)((GridDataItem)e.Item).ChildItem.FindControl("oDetails");
            var grid = (ASP.app_idd_usercontrol_oduediligenceaudittrailapproval_ascx)((GridDataItem)e.Item).ChildItem.FindControl("oDueDiligenceAuditTrailApproval");
            //var approval = (ASP.app_idd_usercontrol_ovmiddapproval_ascx) ((GridDataItem) e.Item).ChildItem.FindControl("oVMIDDApproval");
            if (!e.Item.Expanded)
            {
                long lRequestId = long.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"].ToString());
                long lVendorId = long.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["VENDORID"].ToString());
                grid.ViewAuditTrail(lRequestId);
                details.ViewDetailsByVendor(lVendorId, lRequestId);
                //approval.InitialiseControls(lRequestId);
            }
        }
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var editLink = (HyperLink)e.Item.FindControl("editLink");
            var approveLink = (HyperLink)e.Item.FindControl("approveLink");

            if (editLink != null)
            {
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"], e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["VENDORID"], e.Item.ItemIndex);
            }

            if (approveLink != null)
            {
                approveLink.Attributes["href"] = "javascript:void(0);";
                approveLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["REQUESTID"], e.Item.ItemIndex);
            }
        }
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        CultureInfo provider = new CultureInfo("en-GB"); //.InvariantCulture;
        string format = "d";
        DateTime Validity;

        try
        {
            if (e.Item is GridDataItem)
            {
                int rowCounter = new int();
                Label lbl = e.Item.FindControl("numberLabel") as Label;
                rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
                lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();

                var item = e.Item as GridDataItem;

                o.DueDiligenceAuditTrailStatusManager(item, "Remarks", 0);

                if (item["Status"].Text == ((int)EIdd.ReportStatusEnums.VendorStatus.Amber).ToString())
                {
                    item["Status"].ForeColor = Color.Gold;
                    item["Status"].BackColor = Color.Gold;
                    item["Validity"].Text = "";
                }
                else if (item["Status"].Text == ((int)EIdd.ReportStatusEnums.VendorStatus.Green).ToString())
                {
                    item["Status"].ForeColor = Color.Green;
                    item["Status"].BackColor = Color.Green;
                }
                else if (item["Status"].Text == ((int)EIdd.ReportStatusEnums.VendorStatus.Purple).ToString())
                {
                    item["Status"].ForeColor = Color.Purple;
                    item["Status"].BackColor = Color.Purple;
                }
                else if (item["Status"].Text == ((int)EIdd.ReportStatusEnums.VendorStatus.Gray).ToString())
                {
                    item["Status"].ForeColor = Color.Gray;
                    item["Status"].BackColor = Color.Gray;
                    item["Validity"].Text = "";
                }
                else if (item["Status"].Text == ((int)EIdd.ReportStatusEnums.VendorStatus.Red).ToString())
                {
                    item["Status"].ForeColor = Color.Red;
                    item["Status"].BackColor = Color.Red;
                    item["Validity"].Text = "";
                }

                string dtDated = item["Validity"].Text;
                if ((dtDated != null) && (dtDated != "") && (dtDated != "&nbsp;"))
                {
                    Validity = DateTime.ParseExact(item["Validity"].Text, format, provider);
                    item["Validity"].Text = Validity.ToString("dd-MMM-yyyy");
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_ItemDeleted(object sender, GridDeletedEventArgs e)
    {

    }

    protected void grdView_ItemInserted(object sender, GridInsertedEventArgs e)
    {

    }

    protected void grdView_ItemUpdated(object sender, GridUpdatedEventArgs e)
    {

    }

    protected void grdView_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdView.EditIndexes.Add(0);
            grdView.Rebind();

            //grdView.MasterTableView.Items[0].Expanded = true;
            //grdView.MasterTableView.Items[0].ChildItem.NestedTableViews[0].Items[0].Expanded = true;
        }
    }

    protected void DocumentsGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        try
        {
            int index = ((Session["RowIndex"] != null) && (int.Parse(Session["RowIndex"].ToString()) != -1)) ? int.Parse(Session["RowIndex"].ToString()) : 0;

            GridDataItem item = grdView.MasterTableView.Items[index];

            long lRequestId = long.Parse(item.GetDataKeyValue("REQUESTID").ToString());
            (sender as RadGrid).DataSource = oM.dtGetDocsByRequestId(lRequestId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnDocument_Click(object sender, EventArgs e)
    {
        var lb = (LinkButton)sender;
        var item = (GridDataItem)lb.NamingContainer;
        if (item != null)
        {
            long lDocId = long.Parse(lb.Attributes["IDDOCS"].ToString());
            DownloadFile(lDocId);
        }
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
            appMonitor.logAppExceptions(ex);
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
        {
            long lId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["DOCSID"].ToString());
            oM.deleteDocById(lId);
            //grdView.Rebind();
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Document deleted successfully!!!");
        }
    }

    protected void deleteLink_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
        {
            long lRequestId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["REQUESTID"].ToString());

            bRet = o.DeleteRequestAuditTrail(lRequestId);
            bRet = o.DeleteRequestDocuments(lRequestId);
            bRet = o.DeleteRequest(lRequestId);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Vendor Information successfully deleted!!!");
            }
            /////TODO: Please update the list of Approval Decision into Enumeration list.
            //o.RepresentForReview(lId, 41); //Where 41 = TBD
            //LoadRejectedCommitmentsForgrdView();
        }
        grdView.Rebind();
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