using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_IDD_UserControl_oDetails : System.Web.UI.UserControl
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.VendorReportMgt oi = new EIdd.VendorReportMgt();
    EIdd.CategoryMgt oCat = new EIdd.CategoryMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void ViewDetails(long lRequestId)
    {
        //RequestIdHF.Value = lRequestId.ToString();
        EIdd.RequestForIDD oReq = o.objGetRequestById(lRequestId);

        lblAddress.Text = oReq.m_sAddress;
        lblAmount.Text = stringRoutine.formatAsBankMoney("$", oReq.m_dAmount);
        lblAnalyst.Text = oReq.m_sAnalyst;
        lblCategory.Text = oCat.objGetServiceByServiceId(oReq.m_iCategoryId).m_sCategory;
        lblContractHolder.Text = oReq.m_sContractHolder;
        lblEmailAddress.Text = oReq.m_sEmailAddress;
        lblFocalPoint.Text = oReq.m_sFocalPoint;
        lblGI.Text = (oReq.m_iGI == 1) ? "Yes" : "No";
        lblGO.Text = (oReq.m_iGO == 1) ? "Yes" : "No";
        lblIDDNo.Text = oReq.m_sIDDNo;
        //lblNatureOfContract.Text = oReq.m_iNoR.ToString();
        lblNatureOfRequest.Text = EIdd.NatureOfRequest.NatureOfRequestStatusDesc((EIdd.NatureOfRequest.NatureOfRequestStatus)oReq.m_iNoR);
        lblRegisteredName.Text = oReq.m_sRegisteredName;
        lblRepresentative.Text = oReq.m_sRepresentative;
        lbltelephoneNumber.Text = oReq.m_sTelephoneNumber;
        lblVendorCode.Text = oReq.m_sVendourCode;
    }

    public void ViewDetailsByVendor(long lVendorId, long lRequestId)
    {
        EIdd.Vendours oReq = oi.objGetVendorById(lVendorId);

        lblAddress.Text = oReq.m_sAddress;
        lblAmount.Text = stringRoutine.formatAsBankMoney("$", oReq.m_dAmount);
        lblCategory.Text = oCat.objGetServiceByServiceId(oReq.m_iCategoryId).m_sCategory;
        lblEmailAddress.Text = oReq.m_sEmailAddress;
        lblGI.Text = (oReq.m_iGI == 1) ? "Yes" : "No";
        lblGO.Text = (oReq.m_iGO == 1) ? "Yes" : "No";
        lblIDDNo.Text = oReq.m_sIDDNo;
        lblRegisteredName.Text = oReq.m_sRegisteredName;
        lblRepresentative.Text = oReq.m_sRepresentative;
        lbltelephoneNumber.Text = oReq.m_sTelephoneNumber;
        lblVendorCode.Text = oReq.m_sCodes;

        EIdd.RequestForIDD t = o.objGetRequestById(lRequestId);

        lblAnalyst.Text = t.m_sAnalyst;
        lblContractHolder.Text = t.m_sContractHolder;
        lblFocalPoint.Text = t.m_sFocalPoint;
        lblNatureOfRequest.Text = EIdd.NatureOfRequest.NatureOfRequestStatusDesc((EIdd.NatureOfRequest.NatureOfRequestStatus)t.m_iNoR);
    }

    public void ViewDetail(long lVendorId)
    {
        EIdd.Vendours oReq = oi.objGetVendorById(lVendorId);

        lblAddress.Text = oReq.m_sAddress;
        lblAmount.Text = stringRoutine.formatAsBankMoney("$", oReq.m_dAmount);
        //lblAnalyst.Text = oReq.m_sAnalyst;
        lblCategory.Text = oCat.objGetServiceByServiceId(oReq.m_iCategoryId).m_sCategory;
        //lblContractHolder.Text = oReq.m_sContractHolder;
        lblEmailAddress.Text = oReq.m_sEmailAddress;
        //lblFocalPoint.Text = oReq.m_sFocalPoint;
        lblGI.Text = (oReq.m_iGI == 1) ? "Yes" : "No";
        lblGO.Text = (oReq.m_iGO == 1) ? "Yes" : "No";
        lblIDDNo.Text = oReq.m_sIDDNo;
        //lblNatureOfRequest.Text = (oReq.m_iNoR == 1) ? "New" : "Renewal";
        lblRegisteredName.Text = oReq.m_sRegisteredName;
        lblRepresentative.Text = oReq.m_sRepresentative;
        lbltelephoneNumber.Text = oReq.m_sTelephoneNumber;
        lblVendorCode.Text = oReq.m_sCodes;
    }
}