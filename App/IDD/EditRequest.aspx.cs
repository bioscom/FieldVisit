using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Telerik.Web.UI;

public partial class App_IDD_EditRequest : aspnetPage
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.VendorReportMgt oi = new EIdd.VendorReportMgt();
    EIdd.Admins a = new EIdd.Admins();
    EIdd.CategoryMgt c = new EIdd.CategoryMgt();
    appUsersHelper h = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
                {
                    long lRequestId = long.Parse(Request.QueryString["lRequestId"]);
                    LoadByNatureOfRequest(lRequestId);
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    private void LoadByNatureOfRequest(long lRequestId)
    {
        LoadServices();
        LoadGOGI();

        EIdd.RequestForIDD oR = o.objGetRequestById(lRequestId);
        RetrieveVendorById(lRequestId);

        //ddlNature.SelectedValue = oR.m_iNoR.ToString();

        //if (ddlNature.SelectedValue == "1")
        //{
        //    pnlFileUpload.Visible = true;
        //    btnSubmit.Visible = true;
        //    btnSubmitRenewal.Visible = false;

        //    RetrieveItem(lRequestId);
        //}
        //else if (ddlNature.SelectedValue == "2")
        //{
        //    pnlFileUpload.Visible = true;
        //    btnSubmit.Visible = false;
        //    btnSubmitRenewal.Visible = true;
        //}
    }

    public void RetrieveVendorById(long lVendorId)
    {
        var o = new EIdd.IDDRequestMgt();
        EIdd.Vendours oR = oi.objGetVendorById(lVendorId); //.objGetRequestById(lRequestId);

        txtVendorName.Text = oR.m_sRegisteredName;
        ddlServices.SelectedValue = oR.m_iCategoryId.ToString();
        txtVendorAddress.Text = oR.m_sAddress;
        txtEmailAddress.Text = oR.m_sEmailAddress;
        txtRepresentative.Text = oR.m_sRepresentative;
        txtMskPhoneNo.Text = oR.m_sTelephoneNumber;
        txtVendorCode.Text = oR.m_sCodes;
        txtContractValue.Text = oR.m_dAmount.ToString();
        btnLstGI.SelectedValue = oR.m_iGI.ToString();
        btnLstGO.SelectedValue = oR.m_iGO.ToString();
    }

    private void LoadByNatureOfRequest()
    {
        //if (ddlNature.SelectedValue == "1")
        //{
        //    pnlNewRequest.Visible = true;
        //    pnlRenewal.Visible = false;
        //    pnlFileUpload.Visible = true;
        //    btnSubmit.Visible = true;
        //    btnSubmitRenewal.Visible = false;
        //}
        //else if (ddlNature.SelectedValue == "2")
        //{
        //    pnlNewRequest.Visible = false;
        //    pnlRenewal.Visible = true;
        //    pnlFileUpload.Visible = true;
        //    btnSubmit.Visible = false;
        //    btnSubmitRenewal.Visible = true;
        //}

        LoadServices();
        LoadGOGI();
    }

    //Server Side Method which will get called from Client Side
    //Ensure that you have declared the method like WebMethod
    [WebMethod]
    public static string checkVendorCode(string IDVal)
    {
        string result = string.Empty;
        var o = new EIdd.IDDRequestMgt();
        EIdd.RequestForIDD r = o.objGetRequestByVendourCode(IDVal);

        //Check if dataset is having any value
        if (!string.IsNullOrEmpty(r.m_sVendourCode))
        {
            result = "Vendor Code already in use";
        }
        else result = "Vendor Code is available, you can use it";
        return result;
    }

    //Server Side Method which will get called from Client Side
    //Ensure that you have declared the method like WebMethod
    [WebMethod]
    public static string checkVendorName(string IDVal)
    {
        string result = string.Empty;
        var o = new EIdd.IDDRequestMgt();
        EIdd.RequestForIDD r = o.objGetRequestByRegisteredName(IDVal);

        //Check if dataset is having any value
        if (!string.IsNullOrEmpty(r.m_sRegisteredName))
        {
            result = "A request for this Vendor already exists, please go to renew request.";

        }
        else result = "Vendor Code is available, you can use it";
        return result;
    }

    public void Page_Init(object sender, EventArgs e)
    {

    }

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    bool bRet = false;

    //    if (string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
    //    {
    //        bRet = SaveNewRequest();
    //        if (bRet) ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
    //        else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
    //    }
    //    else
    //    {
    //        long lRequestId = long.Parse(Request.QueryString["lRequestId"].ToString());

    //        bRet = UpdateNewRequest(lRequestId);
    //        if (bRet) ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
    //        else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successfully updated, try again later!!!");
    //    }
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;

        //if (string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
        //{
        //    bRet = Save2();
        //    if (bRet) ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        //    else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
        //}
        //else
        //{
            long lRequestId = long.Parse(Request.QueryString["lRequestId"].ToString());

            bRet = Update(lRequestId);
            if (bRet) ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
            else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successfully updated, try again later!!!");
        //}
    }

    private bool UploadDocuments(long lRequestId)
    {
        var o = new EIdd.RequestDocs();
        var oT = new EIdd.IDDRequestDocsMgt();

        try
        {
            foreach (UploadedFile file in AsyncUpload1.UploadedFiles)
            {
                var bytes = new byte[file.ContentLength];
                file.InputStream.Read(bytes, 0, bytes.Length);

                o.m_iRequestId = lRequestId;
                o.m_bDocs = bytes;
                o.m_sFileName = file.FileName;
                o.m_sFileType = file.ContentType;

                oT.CreateRequestDocs(o.m_iRequestId, o.m_bDocs, o.m_sFileName, o.m_sFileType);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return true;
    }

    private bool checkIfVendorExists(string VendorName)
    {
        bool bRet = false;
        EIdd.RequestForIDD r = o.objGetRequestByRegisteredName(VendorName);
        if (!string.IsNullOrEmpty(r.m_sRegisteredName)) bRet = true;

        return bRet;
    }

    //public bool SaveNewRequest()
    //{
    //    bool bRet = false;
    //    long lRequestId = 0;
    //    try
    //    {
    //        string sIddNumber = "";
    //        var oR = new EIdd.IddRequest();

    //        oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
    //        oR.m_iStatus = (int) EIdd.StageEnums.IddStage.AwaitingFocalPoint;
    //        oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
    //        oR.m_sAddress = txtVendorAddress.Text;
    //        oR.m_sEmailAddress = txtEmailAddress.Text;
    //        oR.m_sRegisteredName = txtVendorName.Text;
    //        oR.m_sRepresentative = txtRepresentative.Text;
    //        oR.m_sTelephoneNumber = txtMskPhoneNo.Text;
    //        oR.m_sVendourCode = "Not Yet Assigned";
    //        oR.m_dAmount = !string.IsNullOrEmpty(txtContractValue.Text) ? decimal.Parse(txtContractValue.Text) : 0;
    //        oR.m_iNoR = 1;    // int.Parse(ddlNature.SelectedValue);
    //        foreach (ButtonListItem li in btnLstGI.Items) if (li.Selected) oR.m_iGI = int.Parse(li.Value);
    //        foreach (ButtonListItem li in btnLstGO.Items) if (li.Selected) oR.m_iGO = int.Parse(li.Value);

    //        bRet = o.CreateRequest(oR, ref lRequestId, ref sIddNumber);
    //        if (bRet)
    //        {
    //            UploadDocuments(lRequestId); //Upload Documents
    //            o.UpdateIDDAutoNumberGenerator(lRequestId); //Update IDD_Auto table to the latest value
    //            List<structUserMailIdx> eTos = o.LstGetIddFocalPoints(); //To CP IDD Focal Points
    //            List<structUserMailIdx> cCopy = o.LstGetCategoryLeads(oR); //Copy Category Lead.
    //            cCopy.Add(oSessnx.getOnlineUser.structUserIdx); //Copy the Requestor

    //            //if (cCopy.Count == 0) cCopy = eTos;

    //            //Send Mail
    //            var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
    //            oSend.ContractHolderRaisedRequest(oR, eTos, cCopy);
    //            //oSend.ContractHolderRaisedRequest(oR, eTos, cCopy);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }

    //    return bRet;
    //}

    //public bool UpdateNewRequest(long lRequestId)
    //{
    //    var oR = new EIdd.IddRequest();

    //    oR.m_lRequestId = lRequestId;
    //    oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
    //    oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
    //    oR.m_sAddress = txtVendorAddress.Text;
    //    oR.m_sEmailAddress = txtEmailAddress.Text;
    //    oR.m_sRegisteredName = txtVendorName.Text;
    //    oR.m_sRepresentative = txtRepresentative.Text;
    //    oR.m_sTelephoneNumber = txtMskPhoneNo.Text;
    //    oR.m_sVendourCode = "Not Yet Assigned";
    //    oR.m_dAmount = !string.IsNullOrEmpty(txtContractValue.Text) ? decimal.Parse(txtContractValue.Text) : 0;
    //    oR.m_iNoR = 1; //int.Parse(ddlNature.SelectedValue);
    //    foreach (ButtonListItem li in btnLstGI.Items) if (li.Selected) oR.m_iGI = int.Parse(li.Value);
    //    foreach (ButtonListItem li in btnLstGO.Items) if (li.Selected) oR.m_iGO = int.Parse(li.Value);

    //    bool bRet = o.UpdateRequest(oR);
    //    if (bRet)
    //    {
    //        //Upload Documents
    //        UploadDocuments(lRequestId);
    //    }

    //    return bRet;
    //}

    //public bool Save2()
    //{
    //    bool bRet = false;
    //    long lRequestId = 0;
    //    try
    //    {
    //        string sIddNumber = "";
    //        var oR = new EIdd.RequestForIDD();

    //        oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
    //        oR.m_iStatus = (int)EIdd.StageEnums.IddStage.AwaitingFocalPoint;
    //        oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
    //        oR.m_sAddress = txtVendorAddress.Text;
    //        oR.m_sEmailAddress = txtEmailAddress.Text;
    //        oR.m_sRegisteredName = txtVendorName.Text;
    //        oR.m_sRepresentative = txtRepresentative.Text;
    //        oR.m_sTelephoneNumber = txtMskPhoneNo.Text;
    //        oR.m_sVendourCode = txtVendorCode.Text;
    //        oR.m_dAmount = !string.IsNullOrEmpty(txtContractValue.Text) ? decimal.Parse(txtContractValue.Text) : 0;
    //        oR.m_iNoR = 2;
    //        foreach (ButtonListItem li in btnLstGI.Items) if (li.Selected) oR.m_iGI = int.Parse(li.Value);
    //        foreach (ButtonListItem li in btnLstGO.Items) if (li.Selected) oR.m_iGO = int.Parse(li.Value);

    //        bRet = o.CreateRequest(oR, ref lRequestId, ref sIddNumber);
    //        if (bRet)
    //        {
    //            UploadDocuments(lRequestId); //Upload Documents
    //            o.UpdateIDDAutoNumberGenerator(lRequestId); //Update IDD_Auto table to the latest value
    //            List<structUserMailIdx> eTos = o.LstGetIddFocalPoints(); //To CP IDD Focal Points
    //            List<structUserMailIdx> cCopy = o.LstGetCategoryLeads(oR); //Copy Category Lead.

    //            if (cCopy.Count == 0) cCopy = eTos;
    //            //Send Mail
    //            var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
    //            oSend.ContractHolderRaisedRequest(oR, eTos, cCopy);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }

    //    return bRet;
    //}

    public bool Update(long lRequestId)
    {
        var kk = o.objGetNewRequestById(lRequestId);

        var oT = new EIdd.Vendours();
        var oR = new EIdd.RequestForIDD();

        oR.m_lRequestId = lRequestId;
        oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
        oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
        oR.m_iNoR = kk.m_iNoR;

        oT.m_sAddress = txtVendorAddress.Text;
        oT.m_sEmailAddress = txtEmailAddress.Text;
        oT.m_sRegisteredName = txtVendorName.Text;
        oT.m_sRepresentative = txtRepresentative.Text;
        oT.m_sTelephoneNumber = txtMskPhoneNo.Text;
        oT.m_sCodes = txtVendorCode.Text;
        oT.m_dAmount = !string.IsNullOrEmpty(txtContractValue.Text) ? decimal.Parse(txtContractValue.Text) : 0;
        foreach (ButtonListItem li in btnLstGI.Items) if (li.Selected) oT.m_iGI = int.Parse(li.Value);
        foreach (ButtonListItem li in btnLstGO.Items) if (li.Selected) oT.m_iGO = int.Parse(li.Value);

        bool bRet = o.UpdateVendor(oT);
        if (bRet)
        {
            bRet = o.UpdateNewRequest(oR);
            if (bRet)
            {
                //Upload Documents
                UploadDocuments(lRequestId);
            }
        }

        return bRet;
    }

    //protected void ddlVendor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    //{
    //    //EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    //    System.Data.DataTable dt = !string.IsNullOrEmpty(e.Text) ? o.dtGetRequestBySearch(e.Text) : null;

    //    EIdd.Utilities.RadComboControlLoader2(dt, ddlVendor);
    //}

    //protected void ddlVendor2_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    //{
    //    //EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    //    System.Data.DataTable dt = !string.IsNullOrEmpty(e.Text) ? o.dtGetRequestBySearch(e.Text) : null;

    //    EIdd.Utilities.RadComboControlLoader2(dt, ddlVendor2);
    //}

    protected void ddlNature_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        LoadByNatureOfRequest();
    }

    private void LoadServices()
    {
        ddlServices.Items.Clear();
        //ddlServices2.Items.Clear();
        var l = new EIdd.CategoryMgt();

        foreach (var o in l.LstGetServices())
        {
            var item = new RadComboBoxItem();
            //var item2 = new RadComboBoxItem();
            item.Text = o.m_sCategory;
            item.Value = o.m_iCategoryId.ToString();

            //item2.Text = o.m_sCategory;
            //item2.Value = o.m_iCategoryId.ToString();

            ddlServices.Items.Add(item);
            item.DataBind();

            //ddlServices2.Items.Add(item2);
            //item2.DataBind();            
        }
    }

    private void LoadGOGI()
    {
        btnLstGI.Items.Clear();
        btnLstGO.Items.Clear();
        //btnLstGI2.Items.Clear();
        //btnLstGO2.Items.Clear();

        var item = new ButtonListItem();
        item.Text = "Yes";
        item.Value = "1";
        btnLstGI.Items.Add(item);
        btnLstGO.Items.Add(item);
        //btnLstGI2.Items.Add(item);
        //btnLstGO2.Items.Add(item);

        item = new ButtonListItem();
        item.Text = "No";
        item.Value = "2";
        btnLstGI.Items.Add(item);
        btnLstGO.Items.Add(item);
        //btnLstGI2.Items.Add(item);
        //btnLstGO2.Items.Add(item);
    }

    //protected void ddlVendor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    pnlRenewalView.Visible = true;
    //    RetrieveVendorById(long.Parse(ddlVendor2.SelectedValue));
    //}

    //public void RetrieveItem(long lRequestId)
    //{
    //    var o = new EIdd.IDDRequestMgt();
    //    EIdd.IddRequest oR = o.objGetRequestById(lRequestId);

    //    txtVendorName.Text = oR.m_sRegisteredName;
    //    ddlServices.SelectedValue = oR.m_iCategoryId.ToString();
    //    txtVendorAddress.Text = oR.m_sAddress;
    //    txtEmailAddress.Text = oR.m_sEmailAddress;
    //    txtRepresentative.Text = oR.m_sRepresentative;
    //    txtMskPhoneNo.Text = oR.m_sTelephoneNumber;
    //    txtVendorCode.Text = oR.m_sVendourCode;
    //    txtContractValue.Text = oR.m_dAmount.ToString();
    //    btnLstGI.SelectedValue = oR.m_iGI.ToString();
    //    btnLstGO.SelectedValue = oR.m_iGO.ToString();
    //}


}