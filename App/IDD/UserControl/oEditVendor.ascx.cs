using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Telerik.Web.UI;

public partial class App_IDD_UserControl_oEditVendor : aspnetUserControl
{
    public delegate void ReturnEditResult(bool bRet, long lRequestId);
    public event ReturnEditResult sendResult;

    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.VendorReportMgt oi = new EIdd.VendorReportMgt();
    EIdd.Admins a = new EIdd.Admins();
    EIdd.CategoryMgt c = new EIdd.CategoryMgt();
    appUsersHelper h = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Page.Validate();
    }

    public void InitPage(long lVendorId)
    {
        try
        {
            VendorIdHF.Value = lVendorId.ToString();
            RetrieveVendorById(lVendorId);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void RetrieveVendorById(long lVendorId)
    {
        LoadServices();
        LoadGOGI();

        var o = new EIdd.IDDRequestMgt();
        EIdd.Vendours oR = oi.objGetVendorById(lVendorId);

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

    private void LoadServices()
    {
        ddlServices.Items.Clear();
        var l = new EIdd.CategoryMgt();

        foreach (var o in l.LstGetServices())
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sCategory;
            item.Value = o.m_iCategoryId.ToString();

            ddlServices.Items.Add(item);
            item.DataBind();
        }
    }

    private void LoadGOGI()
    {
        btnLstGI.Items.Clear();
        btnLstGO.Items.Clear();

        var item = new ButtonListItem();
        item.Text = "Yes";
        item.Value = "1";
        btnLstGI.Items.Add(item);
        btnLstGO.Items.Add(item);

        item = new ButtonListItem();
        item.Text = "No";
        item.Value = "2";
        btnLstGI.Items.Add(item);
        btnLstGO.Items.Add(item);
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iUserId == 0)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Sorry, you can not submit this form. It is either your session has expired or you are not using the right URL. Contact the administrator to properly set up your profile.");
        }
        else
        {
            var oR = new EIdd.Vendours();
            long lRequestId = 0;
            long lVendorId = long.Parse(VendorIdHF.Value);

            try
            {
                oR.m_lVendorId = lVendorId;
                oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
                oR.m_sAddress = txtVendorAddress.Text;
                oR.m_sEmailAddress = txtEmailAddress.Text;
                oR.m_sRegisteredName = txtVendorName.Text;
                oR.m_sRepresentative = txtRepresentative.Text;
                oR.m_sTelephoneNumber = txtMskPhoneNo.Text;
                oR.m_sCodes = txtVendorCode.Text;
                oR.m_dAmount = !string.IsNullOrEmpty(txtContractValue.Text) ? decimal.Parse(txtContractValue.Text) : 0;

                foreach (ButtonListItem li in btnLstGI.Items) if (li.Selected) oR.m_iGI = int.Parse(li.Value);
                foreach (ButtonListItem li in btnLstGO.Items) if (li.Selected) oR.m_iGO = int.Parse(li.Value);

                bool bRet = o.UpdateVendor(oR);
                if (bRet)
                {
                    //Then make the request into the request pool
                    var oT = new EIdd.RequestForIDD();
                    oT.m_iNoR = (int)EIdd.NatureOfRequest.NatureOfRequestStatus.Renewal;
                    oT.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
                    oT.m_lVendorId = lVendorId;
                    oT.m_iStatus = (int)EIdd.ReportStatusEnums.VendorStatus.Red;
                    oT.m_iStage = (int)EIdd.StageEnums.IddStage.AwaitingFocalPoint;

                    bRet = o.MakeNewRequest(oT, ref lRequestId);
                    if (bRet)
                    {
                        o.UpdateRequestNumberAutoGenerated(lRequestId); //Update IDD_REQUEST_AUTO table to the latest value
                                                                        //Upload Documents
                        if (sendResult != null)
                        {
                            sendResult(bRet, lRequestId);
                        }

                        List<structUserMailIdx> eTos = o.LstGetIddFocalPoints(); //To CP IDD Focal Points
                        List<structUserMailIdx> cCopy = new List<structUserMailIdx>();
                        cCopy.Add(oSessnx.getOnlineUser.structUserIdx); //Copy the Requestor
                        foreach (var k in o.LstGetCategoryLeads(oR))
                        {
                            cCopy.Add(k);
                        }
                        //if (cCopy.Count == 0) cCopy = eTos;

                        //Send Mail
                        var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
                        oSend.ContractHolderRaisedRequest(oT, eTos, cCopy);
                    }

                    //if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                    if (bRet)
                    {
                        ajaxWebExtension.showJscriptAlertCx(Page, this, "Successfully updated!!!");
                        btnSubmit.Enabled = false;
                    }
                    else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successfully updated, try again later!!!");
                }
            }
            catch (Exception ex)
            {
                //appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    private bool checkIfVendorExists(string VendorName)
    {
        bool bRet = false;
        EIdd.RequestForIDD r = o.objGetRequestByRegisteredName(VendorName);
        if (!string.IsNullOrEmpty(r.m_sRegisteredName)) bRet = true;

        return bRet;
    }
}