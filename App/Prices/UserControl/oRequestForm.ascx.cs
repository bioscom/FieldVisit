using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Telerik.Web.UI;

public partial class App_Prices_UserControl_oRequestForm : aspnetUserControl
{
    ViewFile oViewFile = new ViewFile();
    string DestinationPath = "../Prices/RedFlag/";
    //string PreviewPath = "\\app\\FieldVisit\\App\\Prices\\";
    //string PreviewPath = "/App/Prices/RedFlag/";
    string PreviewPath = "RedFlag\\";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["lPriceId"]))
            {
                HFPriceId.Value = Request.QueryString["lPriceId"];
                RetrieveRecord(long.Parse(Request.QueryString["lPriceId"]));
            }

            //Load Asset Hubs
            List<AssetHubs> oLst = AssetHubs.lstGetHubs();
            foreach (var listItem in oLst.Select(r => new ListItem(r.sHub, r.iHubId.ToString())))
                ddlAssetHub.Items.Add(listItem);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Your session has expired and cannot continue. Please, logout and login again!!!");
        }
        else
        {
            if (string.IsNullOrEmpty(Request.QueryString["lPriceId"])) Save(); else Update();
        }
    }

    private void Save()
    {
        try
        {
            var oPrice = new Price();

            oPrice.dPrice = decimal.Parse(txtPrice.Text);
            oPrice.dShouldBePrice = decimal.Parse(txtShouldBePrice.Text);
            oPrice.dtDateSubmitted = DateTime.Today.Date;
            oPrice.iUserId = oSessnx.getOnlineUser.m_iUserId;
            oPrice.sMaterialCode = txtCode.Text;
            oPrice.sMaterialDescription = txtMaterialDesc.Text;
            oPrice.sOtherInformation = txtOtherInformation.Text;
            oPrice.sPONumber = txtPO.Text;
            oPrice.sPriceSource = txtPriceSource.Text;
            oPrice.bBlob = UploadFile(oPrice);
            oPrice.iHubId = int.Parse(ddlAssetHub.SelectedValue);

            bool bRet =  (oPrice.bBlob == null) ? PriceHelper.InsertWtOutFile(oPrice) :  PriceHelper.Insert(oPrice);
            SendNotificationMail();
            if (bRet)
            {
                PreviewLoadedFile(oPrice);
                btnSubmit.Enabled = false;
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true); // Call client method in radwindow page

                //ajaxWebExtension.showJscriptAlert(Page, this, "Successfully submited!!! Click close button.");
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void Update()
    {
        try
        {
            var oPrice = new Price();

            oPrice.lPriceId = long.Parse(Request.QueryString["lPriceId"]);

            oPrice.dPrice = decimal.Parse(txtPrice.Text);
            oPrice.dShouldBePrice = decimal.Parse(txtShouldBePrice.Text);
            //oPrice.dtDateSubmitted = DateTime.Today.Date;
            oPrice.iUserId = oSessnx.getOnlineUser.m_iUserId;
            oPrice.sMaterialCode = txtCode.Text;
            oPrice.sMaterialDescription = txtMaterialDesc.Text;
            oPrice.sOtherInformation = txtOtherInformation.Text;
            oPrice.sPONumber = txtPO.Text;
            oPrice.sPriceSource = txtPriceSource.Text;
            oPrice.bBlob = UploadFile(oPrice);
            oPrice.iHubId = int.Parse(ddlAssetHub.SelectedValue);

            bool bRet = true;

            if (bRet)
            {
                bRet = PriceHelper.Update(oPrice);
                PreviewLoadedFile(oPrice);
                btnSubmit.Enabled = false;
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true); // Call client method in radwindow page
                //ajaxWebExtension.showJscriptAlert(Page, this, "Update successful!!! Click close button.");
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());

        }
    }

    private byte[] UploadFile(Price oPrice)
    {
        MediaTypesMgt o = new MediaTypesMgt();
        try
        {
            string ext = o.objGetMediaType(xyFileUpload.PostedFile.ContentType).m_sMediaExt;
            oPrice.sFileName = Guid.NewGuid() + ext;

                string saveLocation = HttpContext.Current.Server.MapPath(DestinationPath + oPrice.sFileName);
                xyFileUpload.PostedFile.SaveAs(saveLocation);
                oPrice.bBlob = (xyFileUpload.HasFile) ? File.ReadAllBytes(saveLocation) : null;

                File.Delete(saveLocation);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return oPrice.bBlob;
    }

    private void RetrieveRecord(long lPriceId)
    {
        Price oPrice = PriceHelper.objGetPriceById(lPriceId);

        txtPrice.Text = oPrice.dPrice.ToString();
        txtShouldBePrice.Text = oPrice.dShouldBePrice.ToString();
        txtCode.Text = oPrice.sMaterialCode;
        txtMaterialDesc.Text = oPrice.sMaterialDescription;
        txtOtherInformation.Text = oPrice.sOtherInformation;
        txtPO.Text = oPrice.sPONumber;
        txtPriceSource.Text = oPrice.sPriceSource;
        ddlAssetHub.SelectedValue = oPrice.iHubId.ToString();

        string saveLocation = HttpContext.Current.Server.MapPath(DestinationPath + oPrice.sFileName);
        PreviewLoadedFile(oPrice);
    }

    private void PreviewLoadedFile(Price o)
    {
        if (o.bBlob != null)
        {
            string sFinalPath = HttpContext.Current.Server.MapPath(DestinationPath + o.sFileName);
            File.WriteAllBytes(sFinalPath, o.bBlob);
            fileLoader.Attributes["src"] = PreviewPath + o.sFileName;

            //OpenPDFHyperLink.NavigateUrl = PreviewPath + o.sFileName;
        }
        else
        {
            fileLoader.Attributes["src"] = "";
        }
    }

    private void SendNotificationMail()
    {
        List<structUserMailIdx> Reviewers = PriceReviewerHelper.Reviewers();

        SendMailFairPrice oMail = new SendMailFairPrice(oSessnx.getOnlineUser.structUserIdx);
        oMail.SendNotificationForReview(oSessnx.getOnlineUser, txtPO.Text, txtMaterialDesc.Text, txtCode.Text, decimal.Parse(txtPrice.Text), decimal.Parse(txtShouldBePrice.Text), txtPriceSource.Text, Reviewers);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtPrice.Text = "";
        txtShouldBePrice.Text = "";
        txtCode.Text = "";
        txtMaterialDesc.Text = "";
        txtOtherInformation.Text = "";
        txtPO.Text = "";
        txtPriceSource.Text = "";
    }

    public HiddenField WorkOrderFileName
    {
        get
        {
            return sFileNameHF;
        }
    }
}