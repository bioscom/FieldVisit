using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Prices_UserControl_oCostSaving : aspnetUserControl
{
    long lPriceId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Page_Init()
    {
        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            //Response.Redirect("~/Default.aspx?pr=9");
        }
    }

    public void LoadMySubmittedPendingPrices(int iUserId)
    {
        grdView.DataSource = PriceHelper.dtGetMyPendingPrices(iUserId);
        grdView.DataBind();

        GetStatus(grdView);

        PriceReviewerHelper.FormatReport(grdView);
    }

    public void LoadMyApprovedPrices(int iUserId)
    {
        grdView.DataSource = PriceHelper.dtGetMyApprovedPrices(iUserId);
        grdView.DataBind();
        grdView.Columns[1].Visible = false;

        GetStatus(grdView);

        PriceReviewerHelper.FormatReport(grdView);
    }

    private void GetStatus(GridView oGrdView)
    {
        foreach (GridViewRow grdRow in oGrdView.Rows)
        {
            PriceReviewerHelper.Reporter(grdRow);
        }
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
            int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

            if (ButtonClicked == "ViewStatus")
            {
                //Label labelOU = (Label)requestsGridView.Rows[index].FindControl("labelOU");
                //LinkButton lbViewStatus = (LinkButton)requestsGridView.Rows[index].FindControl("ViewStatusLinkButton");
                //lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

                //aRequest oRequest = RequestHelper.objGetRequestByRequestId(lRequestId);

                //Response.Redirect("~/Common/ViewComments2.aspx?RequestId=" + lRequestId + "&iOu=" + oRequest.m_iOuId, false);
            }

            if (ButtonClicked == "EditThis")
            {
                LinkButton lbEditThis = (LinkButton)grdView.Rows[index].FindControl("EditLinkButton");
                lPriceId = long.Parse(lbEditThis.Attributes["PRICEID"].ToString());

                Response.Redirect("~/App/Prices/Default.aspx?lPriceId=" + lPriceId, false);
            }

            if (ButtonClicked == "ViewStatus")
            {
                //
                LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("ViewStatusLinkButton");
                lPriceId = long.Parse(lbViewStatus.Attributes["PRICEID"].ToString());
                //App_Prices_ReviewerReport
                Response.Redirect("~/App/Prices/ReviewStatus.aspx?lPriceId=" + lPriceId, false);
            }

            if (ButtonClicked == "Action")
            {
                LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("ActionLinkButton");
                lPriceId = long.Parse(lbViewStatus.Attributes["PRICEID"].ToString());
                //App_Prices_ReviewerReport
                Response.Redirect("~/App/Prices/ReviewerReport.aspx?lPriceId=" + lPriceId, false);

                //if (oSessnx.getOnlineUser.m_iUserRole == (int)appUsersRoles.userRole.IAPPlanner)
                //{
                //    LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("ActionLinkButton");
                //    lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

                //    if (RequestHelper.objGetRequestByRequestId(lRequestId).m_iStatus == RequestStatus.m_iFunctionalRepresentatives)
                //    {
                //        var message = "Sorry, this change request is still pending Functional Authorisers approval.";
                //        ajaxWebExtension.showJscriptAlert(Page, this, message);
                //    }
                //    else
                //    {
                //        LinkButton lbAddComment = (LinkButton)requestsGridView.Rows[index].FindControl("ActionLinkButton");
                //        lRequestId = long.Parse(lbAddComment.Attributes["IDREQUEST"].ToString());

                //        aRequest oRequest = RequestHelper.objGetRequestByRequestId(lRequestId);

                //        if (oRequest.m_iOuId == (int)appOUs.ous.SNEPCO)
                //        {
                //            Response.Redirect("~/IAPPlanner/RequestApproval2.aspx" + "?RequestId=" + lRequestId, false);
                //        }
                //        else
                //        {
                //            Response.Redirect("~/IAPPlanner/RequestApproval.aspx" + "?RequestId=" + lRequestId, false);
                //        }
                //    }
            }
            else
            {
                //LinkButton lbAddComment = (LinkButton)requestsGridView.Rows[index].FindControl("ActionLinkButton");
                //lRequestId = long.Parse(lbAddComment.Attributes["IDREQUEST"].ToString());

                //if (oSessnx.getOnlineUser.m_iUserRole == (int)appUsersRoles.userRole.ChangeReviewBoardChairman)
                //{
                //    if (RequestHelper.objGetRequestByRequestId(lRequestId).m_iStatus == RequestStatus.m_iProductionAssetRepresentative)
                //    {
                //        var message = "Sorry, this change request is still pending Production Asset Authorisers approval.";
                //        ajaxWebExtension.showJscriptAlert(Page, this, message);
                //    }
                //    else
                //    {
                //        Response.Redirect("~/Common/RequestApproval.aspx" + "?RequestId=" + lRequestId, false);
                //    }
                //}
                //else
                //{
                //    Response.Redirect("~/Common/RequestApproval.aspx" + "?RequestId=" + lRequestId, false);
                //}
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        //LoadRecords();
    }
}