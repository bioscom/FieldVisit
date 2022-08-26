using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_vendorCallOutInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void init_Controls()
    {
        //drpTradeTypes.Items.Add(new ListItem("Select Trade Type", "-1"));
        List<TradeType> tradeTypes = TradeType.lstGetTradeType();
        foreach (TradeType tradeType in tradeTypes)
        {
            drpTradeTypes.Items.Add(new ListItem(tradeType.m_sTRADE_TYPE, tradeType.m_iID_TRADE_TYPE.ToString()));
        }
    }

    public void initiateActivityId(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();
    }

    public void Retrieve_Data(long lActivityId)
    {
        ActivityIDHF.Value = lActivityId.ToString();
        VendorCallOut MyVendorCallOut = VendorCallOut.objGetPersonnelInfoByActivityId(lActivityId);

        txtVendorName.Text = MyVendorCallOut.m_sVENDOR_NAME;
        txtContactPerson.Text = MyVendorCallOut.m_sCONTACT_PERSON;
        txtTelephone.Text = MyVendorCallOut.m_sTELEPHONE;
        txtEmailAddress.Text = MyVendorCallOut.m_sEMAIL_ADDRESS;
        drpTradeTypes.SelectedValue = MyVendorCallOut.m_iID_TRADE_TYPE.ToString();
        txtVendorAddress.Text = MyVendorCallOut.m_sVENDOR_ADDRESS;
        txtToolsMaterials.Text = MyVendorCallOut.m_sTOOLS_MATERIALS;

        VendorIDHF.Value = MyVendorCallOut.m_iID_VENDOR.ToString();
    }


    public void enableSaveButton()
    {
        btnSave.Visible = false;
        updateButton.Visible = true;
    }

    //private HiddenField GetHFControl()
    //{
    //    ASP.app_fieldvisit_usercontrol_sepcin_activityheader_ascx ActivityHeaderCntrl = new ASP.app_fieldvisit_usercontrol_sepcin_activityheader_ascx();
    //    HiddenField HFActivityInfo = (HiddenField)ActivityHeaderCntrl.FindControl("activityInfoIdHF");
    //    return HFActivityInfo;
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            long iActivityInfo = long.Parse(ActivityIDHF.Value);

            VendorCallOut eVendor = new VendorCallOut();
            eVendor.m_iID_ACTIVITYINFO = iActivityInfo;
            eVendor.m_sVENDOR_NAME = txtVendorName.Text;
            eVendor.m_sCONTACT_PERSON = txtContactPerson.Text;
            eVendor.m_sTELEPHONE = txtTelephone.Text;
            eVendor.m_sEMAIL_ADDRESS = txtEmailAddress.Text;
            eVendor.m_iID_TRADE_TYPE = int.Parse(drpTradeTypes.SelectedValue);
            eVendor.m_sVENDOR_ADDRESS = txtVendorAddress.Text;
            eVendor.m_sTOOLS_MATERIALS = txtToolsMaterials.Text;

            bool bRet = VendorCallOut.createVendorCallOut(eVendor);

            if (bRet == true)
            {
                enableSaveButton();

                string Message = "Vendor Call Out Information successfully saved.";
                ajaxWebExtension.showJscriptAlert(Page, this, Message);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    //Expose control to the outside world
    public Button MySaveButton
    {
        get
        {
            return btnSave;
        }
    }

    public Button MyUpdateButton
    {
        get
        {
            return updateButton;
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        long iActivityInfo = long.Parse(ActivityIDHF.Value);
        //long iActivityInfo = long.Parse(GetHFControl().Value);
        bool bRet = VendorCallOut.updateVendorCallOut(int.Parse(VendorIDHF.Value), iActivityInfo, txtVendorName.Text, txtContactPerson.Text, txtTelephone.Text,
            txtEmailAddress.Text, int.Parse(drpTradeTypes.SelectedValue), txtVendorAddress.Text, txtToolsMaterials.Text);

        if (bRet == true)
        {
            string sMessage = "Update was successful.";
            lblMssg.Text = sMessage;
            ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
        }
    }
}
