using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Telerik.Web.UI;

public partial class App_IDD_AddVendor : Page
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.Admins a = new EIdd.Admins();
    EIdd.CategoryMgt c = new EIdd.CategoryMgt();
    appUsersHelper h = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadServices();
            LoadGOGI();
        }
    }

    public void Page_Init(object sender, EventArgs e)
    {

    }

    private void LoadByNatureOfRequest()
    {
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
        EIdd.VendorReportMgt t = new EIdd.VendorReportMgt();
        EIdd.Vendours r = t.objGetVendorByVendourCode(IDVal);

        //Check if dataset is having any value
        if (!string.IsNullOrEmpty(r.m_sCodes))
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
        EIdd.VendorReportMgt t = new EIdd.VendorReportMgt();
        EIdd.Vendours r = t.objGetVendorByRegisteredName(IDVal);
        //EIdd.RequestForIDD r = o.objGetRequestByRegisteredName(IDVal);

        //Check if dataset is having any value
        if (!string.IsNullOrEmpty(r.m_sRegisteredName))
        {
            result = "Vendor Name already exists.";
            
        }
        else result = "Vendor Name available!!!";
        return result;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;

        bRet = Save();
        if (bRet) ajaxWebExtension.showJscriptAlertCx(Page, this, "Submit Successful!!!");
        else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");

        //if (string.IsNullOrEmpty(Request.QueryString["lVendorId"]))
        //{
        //bRet = Save();
        //    if (bRet) ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        //    else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
        //}
        //else
        //{
        //    long lRequestId = long.Parse(Request.QueryString["lVendorId"].ToString());

        //    bRet = UpdateNewRequest(lRequestId);
        //    if (bRet) ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        //    else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successfully updated, try again later!!!");
        //}
    }

    public bool Save()
    {
        bool bRet = false;
        long lVendorId = 0;
        try
        {
            string sIddNumber = "";
            var oR = new EIdd.Vendours();

            oR.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
            oR.m_sAddress = txtVendorAddress.Text;
            oR.m_sEmailAddress = txtEmailAddress.Text;
            oR.m_sRegisteredName = txtVendorName.Text;
            oR.m_sRepresentative = txtRepresentative.Text;
            oR.m_sTelephoneNumber = txtMskPhoneNo.Text;
            oR.m_sCodes = "Not Yet Assigned";
            oR.m_dAmount = !string.IsNullOrEmpty(txtContractValue.Text) ? decimal.Parse(txtContractValue.Text) : 0;
            foreach (ButtonListItem li in btnLstGI.Items) if (li.Selected) oR.m_iGI = int.Parse(li.Value);
            foreach (ButtonListItem li in btnLstGO.Items) if (li.Selected) oR.m_iGO = int.Parse(li.Value);

            bRet = o.AddVendor(oR, ref lVendorId, ref sIddNumber);
            if (bRet)
            {
                //UploadDocuments(lRequestId); //Upload Documents
                o.UpdateIDDAutoNumberGenerator(lVendorId); //Update IDD_Auto table to the latest value
                
                //List<structUserMailIdx> eTos = o.LstGetIddFocalPoints(); //To CP IDD Focal Points
                //List<structUserMailIdx> cCopy = new List<structUserMailIdx>();
                //cCopy.Add(oSessnx.getOnlineUser.structUserIdx); //Copy the Requestor
                //foreach(var k in o.LstGetCategoryLeads(oR))
                //{
                //    cCopy.Add(k);
                //}                
                ////if (cCopy.Count == 0) cCopy = eTos;

                ////Send Mail
                //var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
                //oSend.ContractHolderRaisedRequest(oR, eTos, cCopy);
                ////oSend.ContractHolderRaisedRequest(oR, eTos, cCopy);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return bRet;
    }

    protected void ddlNature_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        LoadByNatureOfRequest();
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
}