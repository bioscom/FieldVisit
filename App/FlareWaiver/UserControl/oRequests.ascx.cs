using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Linq;
using System.Collections.Generic;

public partial class UserControl_oRequests : aspnetUserControl
{
    FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page()
    {

    }

    public Panel setPanelRequestStatus
    {
        get
        {
            return pnlRequestStatus;
        }
    }

    public void SearchResult(DataTable dt)
    {
        grdView.DataSource = dt;
        grdView.DataBind();

        //GridManager();
    }

    public void SearchResult(long lRequestId)
    {
        DataTable dt = FlareApprovalHelper.dtGetFlareRequests().AsEnumerable().Where(t => t.Field<decimal>("IDREQUEST") == lRequestId).CopyToDataTable();
        grdView.DataSource = dt;
        grdView.DataBind();

        //GridManager();
    }

    protected void allCkb_CheckedChanged(object sender, EventArgs e)
    {
        //if (allCkb.Checked)
        //{
        //    foreach (GridViewRow grdRow in grdGridView.Rows)
        //    {
        //        CheckBox ckb = (CheckBox)grdRow.FindControl("HandOverCkB");
        //        ckb.Checked = true;
        //    }
        //}
        //else if (!allCkb.Checked)
        //{
        //    foreach (GridViewRow grdRow in grdGridView.Rows)
        //    {
        //        CheckBox ckb = (CheckBox)grdRow.FindControl("HandOverCkB");
        //        ckb.Checked = false;
        //    }
        //}
    }

    protected void handOverButton_Click(object sender, EventArgs e)
    {
        //int i = 0;
        //foreach (GridViewRow grdRow in grdGridView.Rows)
        //{
        //    CheckBox ckb = (CheckBox)grdRow.FindControl("HandOverCkB");
        //    if (ckb.Checked)
        //    {
        //        i++;
        //    }
        //}

        //if (i == 0)
        //{
        //    ajaxWebExtension.showJscriptAlertCx(Page, this, "You must select a request to be handed over to an Initiator. You can use Select All checkbox if all requests are to be handed over or select individual request for handing over.");
        //}
        //else
        //{
        //    foreach (GridViewRow grdRow2 in grdGridView.Rows)
        //    {
        //        CheckBox ckb2 = (CheckBox)grdRow2.FindControl("HandOverCkB");
        //        if (ckb2.Checked)
        //        {
        //            //TODO: Write the code to hand over CTRs to selected person.
        //            //Note, before someone can be allowed to be changed to a new role, he/she must not have any CTR pending.
        //        }
        //    }
        //}
    }

    public void LoadPendingFlareWaiverRequests2(appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.Initiator);
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetPendingFlareWaiverRequests((int)RequestStatusReporter.RequestStatusRpt.Approved);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.Initiator);
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverPendingRequests(oAppUser.m_iUserId);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.LineManager);
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.AssurancePSMgr);
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.AssuranceOnshore);
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.AssuranceOffshore);
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.Approval);
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
    }

    public void LoadApprovedFlareWaiverRequests2(appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsByStatus((int)RequestStatusReporter.RequestStatusRpt.Approved);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverApprovedRequests(oAppUser.m_iUserId);
        }
        else
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverIApproved(oAppUser);
        }
    }

    public void LoadCancelledFlareWaiverRequests2(appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsByStatus((int)RequestStatusReporter.RequestStatusRpt.Cancelled);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverCancelledRequests(oAppUser.m_iUserId);
        }
    }

    public void LoadFlareWaiverRequestsByArea2(int iAreaId)
    {
        grdView.DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsByArea(iAreaId);
    }

    public void LoadRejectedFlareWaiverRequests2(appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsNotSupportedOrApproved();
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverRequestsNotSupportedOrApproved(oAppUser.m_iUserId);
        }
        else
        {
            grdView.DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverIDidNotApprove(oAppUser);
        }
    }

    public void LoadPendingFlareWaiverRequestsNeedData(object sender, appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.Initiator);
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetPendingFlareWaiverRequests((int)RequestStatusReporter.RequestStatusRpt.Approved);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.Initiator);
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverPendingRequests(oAppUser.m_iUserId);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.LineManager);
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.AssurancePSMgr);
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.AssuranceOnshore);
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.AssuranceOffshore);
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval)
        {
            oappUsersHelper.GetUsersByRoleId(ddlDeligate, appUserRolesFlrWaiver.userRole.Approval);
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverPendingMyApproval(oAppUser);
        }
    }

    public void LoadApprovedFlareWaiverRequestsNeedData(object sender, appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsByStatus((int)RequestStatusReporter.RequestStatusRpt.Approved);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverApprovedRequests(oAppUser.m_iUserId);
        }
        else
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverIApproved(oAppUser);
        }
    }

    public void LoadCancelledFlareWaiverRequestsNeedData(object sender, appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsByStatus((int)RequestStatusReporter.RequestStatusRpt.Cancelled);
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverCancelledRequests(oAppUser.m_iUserId);
        }
    }

    public void LoadFlareWaiverRequestsByAreaNeedData(object sender, int iAreaId)
    {
        (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsByArea(iAreaId);
    }

    public void LoadRejectedFlareWaiverRequestsNeedData(object sender, appUsers oAppUser)
    {
        if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetFlareWaiverRequestsNotSupportedOrApproved();
        }
        else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetMyFlareWaiverRequestsNotSupportedOrApproved(oAppUser.m_iUserId);
        }
        else
        {
            (sender as RadGrid).DataSource = oFlareWaiverRequestHelper.dtGetRequestsFlareWaiverIDidNotApprove(oAppUser);
        }
    }

    protected void CancelLink_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
        {
            long lRequestId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDREQUEST"].ToString());
            //TODO: When a request is cancelled, move it to the cancelled folder, by updating the status to iCancel
            //ApprovalWorkFlow.UpdateRequestFlowStatus(lRequestId, RequestStatus.m_iCancelled);

            grdView.Rebind();
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Request successfully cancelled!!!");
        }
    }

    protected void ActionLink_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
        {
            long lRequestId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDREQUEST"].ToString());
            string url = "~/App/FlareWaiver/FlareApprovalProc.aspx?RequestId=" + lRequestId;
            Response.Redirect(url);
            //TODO: When a request is cancelled, move it to the cancelled folder, by updating the status to iCancel
            //ApprovalWorkFlow.UpdateRequestFlowStatus(lRequestId, RequestStatus.m_iCancelled);

            //grdView.Rebind();
            //ajaxWebExtension.showJscriptAlertCx(Page, this, "Request successfully cancelled!!!");
        }
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            if (Request.QueryString["Mdx"] == "Aprd")
            {
                LoadApprovedFlareWaiverRequestsNeedData(sender, oSessnx.getOnlineUser);
            }
            else if (Request.QueryString["Mdx"] == "Rjct")
            {
                LoadRejectedFlareWaiverRequestsNeedData(sender, oSessnx.getOnlineUser);
            }
            else if (Request.QueryString["Mdx"] == "Cncl")
            {
                LoadCancelledFlareWaiverRequestsNeedData(sender, oSessnx.getOnlineUser);
            }
            else
            {
                LoadPendingFlareWaiverRequestsNeedData(sender, oSessnx.getOnlineUser);
            }
        }
    }

    protected void grdView_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "Redirect")
        {
            GridDataItem item = (GridDataItem)e.Item;
            string value = item.GetDataKeyValue("IDREQUEST").ToString(); // Get the value in clicked row    

            // Save the required  value in session    
            string url = "~/App/FlareWaiver/FlareApprovalProc.aspx?RequestId=" + value;
            Response.Redirect(url);
        }
    }

    protected void grdView_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            //var actionLink = (HyperLink)e.Item.FindControl("ActionLink");
            var viewCommentLink = (HyperLink)e.Item.FindControl("ViewCommentLink");
            var CancelLink = (HyperLink)e.Item.FindControl("CancelLink");
            var deleteLink = (HyperLink)e.Item.FindControl("deleteLink");
            var editLink = (HyperLink)e.Item.FindControl("editLink");
            var reportLink = (HyperLink)e.Item.FindControl("reportLink");
            var ReRouteLink = (HyperLink)e.Item.FindControl("ReRouteLink");
            var AuditTrailLink = (HyperLink)e.Item.FindControl("AuditTrailLink");

            //if (actionLink != null)
            //{
            //    actionLink.Attributes["href"] = "javascript:void(0);";
            //    actionLink.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            //}

            if (viewCommentLink != null)
            {
                viewCommentLink.Attributes["href"] = "javascript:void(0);";
                viewCommentLink.Attributes["onclick"] = string.Format("return ShowComment('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            }

            if (editLink != null)
            {
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = string.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            }

            if (CancelLink != null)
            {
                CancelLink.Attributes["href"] = "javascript:void(0);";
                //CancelLink.Attributes["onclick"] = string.Format("return ShowCancelForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            }

            if (deleteLink != null)
            {
                deleteLink.Attributes["href"] = "javascript:void(0);";
                //deleteLink.Attributes["onclick"] = string.Format("return ShowDeleteForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            }

            if (reportLink != null)
            {
                reportLink.Attributes["href"] = "javascript:void(0);";
                reportLink.Attributes["onclick"] = string.Format("return ShowReport('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            }

            if (ReRouteLink != null)
            {
                ReRouteLink.Attributes["href"] = "javascript:void(0);";
                ReRouteLink.Attributes["onclick"] = string.Format("return ShowRerouteForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            }

            if (AuditTrailLink != null)
            {
                AuditTrailLink.Attributes["href"] = "javascript:void(0);";
                AuditTrailLink.Attributes["onclick"] = string.Format("return ShowAuditTrailForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"], e.Item.ItemIndex);
            }
        }
    }

    protected void grdView_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        GridColumn status = grdView.MasterTableView.Columns.FindByUniqueName("status");

        GridColumn ActionColumn = grdView.MasterTableView.Columns.FindByUniqueName("ActionColumn");
        GridColumn CancelColumn = grdView.MasterTableView.Columns.FindByUniqueName("CancelColumn");
        GridColumn deleteColumn = grdView.MasterTableView.Columns.FindByUniqueName("deleteColumn");
        GridColumn ViewCommentColumn = grdView.MasterTableView.Columns.FindByUniqueName("ViewCommentColumn");
        GridColumn EditColumn = grdView.MasterTableView.Columns.FindByUniqueName("EditColumn");
        GridColumn ViewReportColumn = grdView.MasterTableView.Columns.FindByUniqueName("ViewReportColumn");
        GridColumn ReRouteColumn = grdView.MasterTableView.Columns.FindByUniqueName("ReRouteColumn");
        GridColumn AuditTrailColumn = grdView.MasterTableView.Columns.FindByUniqueName("AuditTrailColumn");


        if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
        {
            ActionColumn.Visible = false;
            CancelColumn.Visible = true;
            deleteColumn.Visible = true;
            ViewCommentColumn.Visible = true;
            EditColumn.Visible = true;
            ViewReportColumn.Visible = true;
            ReRouteColumn.Visible = true;
            AuditTrailColumn.Visible = true;
        }
        else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
        {
            ActionColumn.Visible = true;
            CancelColumn.Visible = false;
            deleteColumn.Visible = false;
            ViewCommentColumn.Visible = true;
            EditColumn.Visible = false;
            ViewReportColumn.Visible = true;
            ReRouteColumn.Visible = false;
            AuditTrailColumn.Visible = true;
        }
        else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
        {
            ActionColumn.Visible = true;
            CancelColumn.Visible = false;
            deleteColumn.Visible = false;
            ViewCommentColumn.Visible = true;
            EditColumn.Visible = false;
            ViewReportColumn.Visible = true;
            ReRouteColumn.Visible = false;
            AuditTrailColumn.Visible = true;
        }
        else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
        {
            ActionColumn.Visible = true;
            CancelColumn.Visible = false;
            deleteColumn.Visible = false;
            ViewCommentColumn.Visible = true;
            EditColumn.Visible = false;
            ViewReportColumn.Visible = true;
            ReRouteColumn.Visible = false;
            AuditTrailColumn.Visible = true;
        }
        else
        {
            ActionColumn.Visible = true;
            CancelColumn.Visible = false;
            deleteColumn.Visible = false;
            ViewCommentColumn.Visible = true;
            EditColumn.Visible = false;
            ViewReportColumn.Visible = true;
            ReRouteColumn.Visible = false;
            AuditTrailColumn.Visible = true;
        }

        if (e.Item is GridDataItem)
        {
            int rowCounter = new int();
            Label lbl = e.Item.FindControl("numberLabel") as Label;
            rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
            lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();

            var item = e.Item as GridDataItem;
            RequestStatusReporter.reportMyStatus(item, status.OrderIndex);

            Label lblFacilities = e.Item.FindControl("lblFacilities") as Label;
            long lRequestId = long.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDREQUEST"].ToString());
            List<Facility> lstFacilities = oFlareWaiverRequestHelper.lstGetFacilitiesByRequestId(lRequestId);

            foreach (Facility o in lstFacilities)
            {
                lblFacilities.Text += o.m_sFacility + "  ";
            }
        }

        if (e.Item is GridDataItem)
        {
            bool found = (from d in grdView.MasterTableView.RenderColumns select d).Any(d => d.UniqueName == "ActionColumn");
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

    protected void grdView_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
    {

    }
}