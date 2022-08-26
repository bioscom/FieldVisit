using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

public partial class App_Prices_Reviewers : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = PriceReviewerHelper.GetReviewer(oSessnx.getOnlineUser.m_iUserId);

        if (bRet == false)
        {
            Response.Redirect("~/App/Prices/taskPage.aspx?lpq=0");
        }

        LoadReviewers();
    }

    protected void ddlContractHolder_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        EIdd.Utilities.Search(e.Text, ddlContractHolder);
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton) row.FindControl("deleteLinkButton");
        int iUserID = int.Parse(lnkDelete.Attributes["USERID"].ToString());

        bool bRet = PriceReviewerHelper.RemoveFromReviewers(iUserID);
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Reviewer successfully Removed.");
            LoadReviewers();
        }
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = PriceReviewerHelper.Insert(int.Parse(ddlContractHolder.SelectedValue));//int.Parse(ddlReviewer._SelectedValue)
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, ddlContractHolder.SelectedItem.Text + " successfully added to the list of reviewers.");
        }
        LoadReviewers();
    }

    private void LoadReviewers()
    {
        grdView.DataSource = PriceReviewerHelper.dtGetPriceReviewers();
        grdView.DataBind();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Prices/Default.aspx");
    }

    protected void btnReminder_Click(object sender, EventArgs e)
    {
        List<structUserMailIdx> reviewers = PriceReviewerHelper.Reviewers();

        var oMail = new SendMailFairPrice(oSessnx.getOnlineUser.structUserIdx);
        oMail.ItemsPendingReview(reviewers);
        ajaxWebExtension.showJscriptAlert(Page, this, "Reminder mail has been sent to all reviewers!!!");
    }
}