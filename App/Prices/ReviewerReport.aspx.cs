using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class App_Prices_ReviewerReport : aspnetPage
{
    string PreviewPath = "/App/Prices/RedFlag/";
    string DestinationPath = "../Prices/RedFlag/";
    public void Page_Init()
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool bRet = PriceReviewerHelper.GetReviewer(oSessnx.getOnlineUser.m_iUserId);
            if(bRet)
            {
                ddlSavingsAchieved.Items.Add(new ListItem(ReviewStatus.status(ReviewStatus.RevStatus.No), ((int) ReviewStatus.RevStatus.No).ToString()));
                ddlSavingsAchieved.Items.Add(new ListItem(ReviewStatus.status(ReviewStatus.RevStatus.Yes), ((int)ReviewStatus.RevStatus.Yes).ToString()));

                ddlClosedOut.Items.Add(new ListItem(ReviewStatus.status(ReviewStatus.RevStatus.No), ((int)ReviewStatus.RevStatus.No).ToString()));
                ddlClosedOut.Items.Add(new ListItem(ReviewStatus.status(ReviewStatus.RevStatus.Yes), ((int)ReviewStatus.RevStatus.Yes).ToString()));

                LoadRecord();
            }
            else if (bRet == false)
            {
                Response.Redirect("~/App/Prices/taskPage.aspx?lpq=0");
            }             
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long lPriceId = long.Parse(Request.QueryString["lPriceId"]);

        Price oPrice = new Price();

        oPrice.dAmountSaved = decimal.Parse(txtAmount.Text);
        oPrice.iStatus = int.Parse(ddlSavingsAchieved.SelectedValue);
        oPrice.iCloseOutStatus = int.Parse(ddlClosedOut.SelectedValue);
        oPrice.iReviewerUserId = oSessnx.getOnlineUser.m_iUserId;
        oPrice.lPriceId = lPriceId;
        oPrice.dtDateReviewed = DateTime.Today.Date;
        oPrice.sComments = txtComment.Text;

        bool bRet = PriceHelper.UpdateReviewComment(oPrice);
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Successfully Submitted.");

            LoadRecord();

            List<structUserMailIdx> Reviewers = PriceReviewerHelper.Reviewers();
            oPrice = PriceHelper.objGetPriceById(lPriceId);

            appUsers Poster = appUsersHelper.objGetUserByUserId(oPrice.iUserId);

            SendMailFairPrice oMail = new SendMailFairPrice(oSessnx.getOnlineUser.structUserIdx);
            oMail.ReviewNotification(Poster, oPrice, Reviewers);
        }
    }

    private void LoadRecord()
    {
        long lPriceId = long.Parse(Request.QueryString["lPriceId"]);

        dtlView.DataSource = PriceHelper.dtGetPriceById(lPriceId);
        dtlView.DataBind();

        Price o = PriceHelper.objGetPriceById(lPriceId);

        txtAmount.Text = o.dAmountSaved.ToString();
        txtComment.Text = o.sComments;
        ddlSavingsAchieved.SelectedValue = o.iStatus.ToString();
        ddlClosedOut.SelectedValue = o.iCloseOutStatus.ToString();

        PreviewLoadedFile(o);

        PriceReviewerHelper.FormatReport(dtlView);
    }

    private void PreviewLoadedFile(Price o)
    {
        if (o != null)
        {
            string sFinalPath = HttpContext.Current.Server.MapPath(DestinationPath + o.sFileName);

            if (o.bBlob != null)
            {
                File.WriteAllBytes(sFinalPath, o.bBlob);
                fileLoader.Attributes["src"] = PreviewPath + o.sFileName;

                OpenPDFHyperLink.NavigateUrl = PreviewPath + o.sFileName;
            }
        }
        else
        {
            fileLoader.Attributes["src"] = "";
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Prices/PriceCheckList.aspx");
    }
}