using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;

public partial class App_IDD_MakeRequestNew : aspnetPage
{
    EIdd.IDDRequestMgt oo = new EIdd.IDDRequestMgt();
    EIdd.VendorReportMgt o = new EIdd.VendorReportMgt();
    //EIdd.Admins a = new EIdd.Admins();
    //EIdd.CategoryMgt c = new EIdd.CategoryMgt();
    //appUsersHelper h = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlHider.Visible = false;
            pnlLoadDocs.Visible = false;
        }

        oAddVendor.sendResult += OAddVendor1_sendResult;

        oEditVendor1.sendResult += OEditVendor1_sendResult;
    }

    private void OAddVendor1_sendResult(bool bRet, long lRequestId)
    {
        oDocumentLoader1.UploadDocuments(lRequestId);
    }

    private void OEditVendor1_sendResult(bool bRet, long lRequestId)
    {
        oDocumentLoader1.UploadDocuments(lRequestId);
    }

    protected void ddlNature_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        LoadByNatureOfRequest();
    }

    private void LoadByNatureOfRequest()
    {
        if (ddlNature.SelectedValue == ((int)EIdd.NatureOfRequest.NatureOfRequestStatus.New).ToString())
        {
            pnlNewRequest.Visible = true;
            pnlLoadDocs.Visible = true;
            pnlSearchVendor.Visible = false;
            pnlHider.Visible = false;
        }
        else if (ddlNature.SelectedValue == ((int)EIdd.NatureOfRequest.NatureOfRequestStatus.Renewal).ToString())
        {
            pnlNewRequest.Visible = false;
            pnlSearchVendor.Visible = true;
        }
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlVendor.SelectedValue))
            {
                pnlHider.Visible = true;
                pnlLoadDocs.Visible = true;
                long lVendorId = long.Parse(ddlVendor.SelectedValue);
                oEditVendor1.InitPage(lVendorId);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void ddlVendor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        System.Data.DataTable dt = !string.IsNullOrEmpty(e.Text) ? o.dtGetVendorBySearch(e.Text) : null;
        EIdd.Utilities.RadComboControlLoader2(dt, ddlVendor);
    }

    //private bool checkIfVendorExists(string VendorName)
    //{
    //    bool bRet = false;
    //    EIdd.RequestForIDD r = o.objGetRequestByRegisteredName(VendorName);
    //    if (!string.IsNullOrEmpty(r.m_sRegisteredName)) bRet = true;

    //    return bRet;
    //}    

    //protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    //{
    //    try
    //    {
    //        if (!e.IsFromDetailTable)
    //        {
    //            if (!string.IsNullOrEmpty(ddlVendor.SelectedValue))
    //            {
    //                long lVendorId = long.Parse(ddlVendor.SelectedValue);
    //                System.Data.DataTable dt = o.GetNewRequestByVendorId(lVendorId);

    //                if (dt.Rows.Count > 0)
    //                {
    //                    pnlHider.Visible = true;
    //                    //pnlRenewal.Visible = false;
    //                    //(sender as RadGrid).DataSource = dt;
    //                }
    //                else
    //                {
    //                    pnlHider.Visible = false;
    //                    //pnlRenewal.Visible = true;
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}


    //public bool SaveNewRequest()
    //{
    //    bool bRet = false;
    //    long lRequestId = 0;

    //    try
    //    {
    //        string sIddNumber = "";
    //        var oR = new EIdd.RequestForIDD();

    //        //oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
    //        oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
    //        oR.m_iNoR = 2;    // int.Parse(ddlNature.SelectedValue);
    //        oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
    //        oR.m_lVendorId = int.Parse(ddlVendor.SelectedValue);
    //        oR.m_iStatus = (int)EIdd.StageEnums.IddStage.AwaitingFocalPoint;
    //        oR.m_iStage = (int)EIdd.StageEnums.IddStage.AwaitingFocalPoint;

    //        bRet = oo.MakeNewRequest(oR, ref lRequestId, ref sIddNumber);
    //        if (bRet)
    //        {
    //            UploadDocuments(lRequestId); //Upload Documents
    //            oo.UpdateIDDAutoNumberGenerator(lRequestId); //Update IDD_Auto table to the latest value
    //            List<structUserMailIdx> eTos = oo.LstGetIddFocalPoints(); //To CP IDD Focal Points
    //            List<structUserMailIdx> cCopy = new List<structUserMailIdx>();
    //            cCopy.Add(oSessnx.getOnlineUser.structUserIdx); //Copy the Requestor

    //            //cCopy = o.LstGetCategoryLeads(oR).ForEach(structUserMailEx);

    //            foreach (var k in oo.LstGetCategoryLeads(oR)) cCopy.Add(k);

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

    //public bool UpdateNewRequest(long lRequestId)
    //{
    //    var oR = new EIdd.RequestForIDD();

    //    //oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
    //    oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
    //    oR.m_iNoR = 1;    // int.Parse(ddlNature.SelectedValue);
    //    oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
    //    oR.m_lVendorId = int.Parse(ddlVendor.SelectedValue);
    //    oR.m_iStatus = (int)EIdd.StageEnums.IddStage.AwaitingFocalPoint;
    //    oR.m_iStage = (int)EIdd.StageEnums.IddStage.AwaitingFocalPoint;

    //    oR.m_lRequestId = lRequestId;
    //    oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;       
    //    oR.m_iNoR = 1; //int.Parse(ddlNature.SelectedValue);

    //    bool bRet = o.UpdateNewRequest(oR);
    //    if (bRet)
    //    {
    //        //Upload Documents
    //        //UploadDocuments(lRequestId);
    //    }

    //    return bRet;
    //}

    //protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    //{
    //    if (e.Item is GridDataItem)
    //    {
    //        var lbl = e.Item.FindControl("numberLabel") as Label;
    //        if (lbl != null)
    //            lbl.Text = (e.Item.ItemIndex + 1).ToString();

    //        var item = e.Item as GridDataItem;

    //        if (item.Cells[5].Text == "1")
    //        {
    //            item.Cells[5].Text = "New";
    //            item.Cells[5].Font.Bold = true;
    //            item.Cells[5].ForeColor = Color.Navy;
    //        }
    //        else if (item.Cells[5].Text == "2")
    //        {
    //            item.Cells[5].Text = "Renewal";
    //            item.Cells[5].Font.Bold = true;
    //            item.Cells[5].ForeColor = Color.Red;
    //        }

    //        o.DueDiligenceAuditTrailStatusManager(item, "Remarks", 0);
    //    }
    //}


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


}