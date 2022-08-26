using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_MeterStatus : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.MeterStatusHelper.dtGetMeterStatusFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        //long result = 0;
        bool bRet = false;
        PDR.MeterStatus oMeterStatus = new PDR.MeterStatus();
        oMeterStatus.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oMeterStatus.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oMeterStatus.lMeterId = long.TryParse(lbFacility.Attributes["IDMETER"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDMETER"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDMETER"]))
            {
                oMeterStatus.lMeterId = long.Parse(lbFacility.Attributes["IDMETER"].ToString());
            }

            TextBox txtGrossOil = (TextBox)grdRow.FindControl("txtGrossOil");
            TextBox txtFlare = (TextBox)grdRow.FindControl("txtFlare");
            TextBox txtGasProduced = (TextBox)grdRow.FindControl("txtGasProduced");
            TextBox txtGasSold = (TextBox)grdRow.FindControl("txtGasSold");
            TextBox txtCondessateProduced = (TextBox)grdRow.FindControl("txtCondessateProduced");
            TextBox txtFuelGasMeter = (TextBox)grdRow.FindControl("txtFuelGasMeter");
            TextBox txtRemarks = (TextBox)grdRow.FindControl("txtRemarks");

            oMeterStatus.sGrossOil = txtGrossOil.Text;
            oMeterStatus.sFlare = txtFlare.Text;
            oMeterStatus.sGasProduced = txtGasProduced.Text;
            oMeterStatus.sGasSold = txtGasSold.Text;
            oMeterStatus.sCondessate = txtCondessateProduced.Text;
            oMeterStatus.sFuelGasmeter = txtFuelGasMeter.Text;
            oMeterStatus.sRemarks = txtRemarks.Text;

            //if (string.IsNullOrEmpty(txtGrossOil.Text)) oMeterStatus.sGrossOil = null; else oMeterStatus.sGrossOil = txtGrossOil.Text;
            //if (string.IsNullOrEmpty(txtFlare.Text)) oMeterStatus.sFlare = null; else oMeterStatus.sFlare = txtFlare.Text;
            //if (string.IsNullOrEmpty(txtGasProduced.Text)) oMeterStatus.sGasProduced = null; else oMeterStatus.sGasProduced = txtGasProduced.Text;
            //if (string.IsNullOrEmpty(txtGasSold.Text)) oMeterStatus.sGasSold = null; else oMeterStatus.sGasSold = txtGasSold.Text;
            //if (string.IsNullOrEmpty(txtCondessateProduced.Text)) oMeterStatus.sCondessate = null; else oMeterStatus.sCondessate = txtCondessateProduced.Text;
            //if (string.IsNullOrEmpty(txtFuelGasMeter.Text)) oMeterStatus.sFuelGasmeter = null; else oMeterStatus.sFuelGasmeter = txtFuelGasMeter.Text;
            //if (string.IsNullOrEmpty(txtRemarks.Text)) oMeterStatus.sRemarks = null; else oMeterStatus.sRemarks = txtRemarks.Text;

            if (oMeterStatus.lMeterId == 0)
                bRet = PDR.MeterStatusHelper.Insert(oMeterStatus);
            else bRet = PDR.MeterStatusHelper.Update(oMeterStatus);
        }
    }
}