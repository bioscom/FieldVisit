using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Security.Application;

public partial class UserControl_Specific_oRequestDetails : System.Web.UI.UserControl
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    RequestFacilityHelper oRequestFacilityHelper = new RequestFacilityHelper();
    FlareWaiverRequestHelper oT = new FlareWaiverRequestHelper();
    FlareTargetHelper oFlrT = new FlareTargetHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Init_Control(FlareWaiver oFlareWaiverRequest)
    {
        try
        {
            Clear();
            if (oFlareWaiverRequest.m_lRequestId != 0)
            {
                lblRequestNumber.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sRequestNumber);
                lblFlareAgVolume.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sFlareVol.ToString() + " (mmscfd)");
                lblAssOilProd.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sOilProduced.ToString() + " (mbopd)");

                lblDateInit.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sDateCreated.ToString());
                lblCategory.Text = Encoder.HtmlEncode(Category.objGetCategoryByCatId(oFlareWaiverRequest.m_iCategoryId).m_sCategory);

                string sCode = ""; int iFacilityId = 0;
                List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(oFlareWaiverRequest.m_lRequestId);
                foreach (RequestFacility oRequestFacility in lstRequestFacilities)
                {
                    lblFacility.Text += Encoder.HtmlEncode(Facility.objGetFacilityById(oRequestFacility.m_iFacilityId).m_sFacility + ", ");
                    sCode = Facility.objGetFacilityById(oRequestFacility.m_iFacilityId).m_sCode;
                    iFacilityId = oRequestFacility.m_iFacilityId;
                }

                lblStartDate.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sStartDate.ToString());
                lblStartTime.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sStartTime.ToString());
                lblEndDate.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sEndDate.ToString());
                lblEndTime.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sEndTime.ToString());

                lblReason.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sReason);
                lblJustification.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sJustification);
                lblPostEvent.Text = Encoder.HtmlEncode(oFlareWaiverRequest.m_sPostEvent);

                lblInitiator.Text = Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(oFlareWaiverRequest.m_iUserId).m_sFullName);

                int iYear = oFlareWaiverRequest.m_sDateCreated.Value.Year;

                //New update
                //Capture YTD actual Vs Annual flare limit as input into Flare Waiver approval consideration

                //YTD actual
                List<EnergyComponent> GasFlareYTD = oT.lstGetGasFlareYTDByFacility(sCode, iYear);
                var TotalFlaredYTD = GasFlareYTD.Sum(s => s.API);
                var FlareYTDactual = TotalFlaredYTD / DateTime.Now.Date.DayOfYear - 1;

                lblTotalFlared.Text = stringRoutine.formatAsNumber(TotalFlaredYTD);
                lblYTDActual.Text = stringRoutine.formatAsNumber(FlareYTDactual);

                //Annual flare limit
                var AnnualFlareLimit = oFlrT.objGetFlareAnnualTargetByFacilityId(iFacilityId, iYear).iYTD;
                lblAnnualFlareLimit.Text = AnnualFlareLimit.ToString();

                if (AnnualFlareLimit < FlareYTDactual) lblYTDActual.ForeColor = System.Drawing.Color.Red;
                else if (AnnualFlareLimit == FlareYTDactual) lblYTDActual.ForeColor = System.Drawing.Color.Gold;
                else if (AnnualFlareLimit > FlareYTDactual) lblYTDActual.ForeColor = System.Drawing.Color.Green;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void Clear()
    {
        try
        {
            lblRequestNumber.Text = "";
            lblFlareAgVolume.Text = "";
            lblAssOilProd.Text = "";
            lblDateInit.Text = "";
            lblCategory.Text = "";
            lblFacility.Text = "";
            lblStartDate.Text = "";
            lblStartTime.Text = "";
            lblEndDate.Text = "";
            lblEndTime.Text = "";
            lblReason.Text = "";
            lblJustification.Text = "";
            lblPostEvent.Text = "";
            lblInitiator.Text = "";
            lblTotalFlared.Text = "";
            lblYTDActual.Text = "";
            lblAnnualFlareLimit.Text = "";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}