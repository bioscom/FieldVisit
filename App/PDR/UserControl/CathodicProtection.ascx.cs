using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_CathodicProtection : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.CathodicProtectionHelper.dtGetcathodicprotectionFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        PDR.CathodicProtection oCathodicProtection = new PDR.CathodicProtection();
        oCathodicProtection.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oCathodicProtection.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oCathodicProtection.lCathodicId = long.TryParse(lbFacility.Attributes["IDCATHODIC"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDCATHODIC"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDCATHODIC"]))
            {
                oCathodicProtection.lCathodicId = long.Parse(lbFacility.Attributes["IDCATHODIC"].ToString());
            }
            TextBox txtCurrent = (TextBox)grdRow.FindControl("txtCurrent");
            TextBox txtVoltage = (TextBox)grdRow.FindControl("txtVoltage");
            TextBox txtSilicaGelStandard = (TextBox)grdRow.FindControl("txtSilicaGelStandard");
            TextBox txtSilicaGelActual = (TextBox)grdRow.FindControl("txtSilicaGelActual");

            oCathodicProtection.sCurrent = txtCurrent.Text;
            oCathodicProtection.sVoltage = txtVoltage.Text;
            oCathodicProtection.sSilcaGelStandard = txtSilicaGelStandard.Text;
            oCathodicProtection.sSilcaGelActual = txtSilicaGelActual.Text;

            //if (string.IsNullOrEmpty(txtCurrent.Text)) oCathodicProtection.sCurrent = null; else oCathodicProtection.sCurrent = decimal.Parse(txtCurrent.Text).ToString();
            //if (string.IsNullOrEmpty(txtVoltage.Text)) oCathodicProtection.sVoltage = null; else oCathodicProtection.sVoltage = decimal.Parse(txtVoltage.Text).ToString();
            //if (string.IsNullOrEmpty(txtSilicaGelStandard.Text)) oCathodicProtection.sSilcaGelStandard = null; else oCathodicProtection.sSilcaGelStandard = decimal.Parse(txtSilicaGelStandard.Text).ToString();
            //if (string.IsNullOrEmpty(txtSilicaGelActual.Text)) oCathodicProtection.sSilcaGelActual = null; else oCathodicProtection.sSilcaGelActual = decimal.Parse(txtSilicaGelActual.Text).ToString();

            if (oCathodicProtection.lCathodicId == 0)
                bRet = PDR.CathodicProtectionHelper.Insert(oCathodicProtection);
            else bRet = PDR.CathodicProtectionHelper.Update(oCathodicProtection);
        }
    }
}