using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_AlarmRate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.AlarmRateHelper.dtGetAlarmRateFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        PDR.AlarmRate oAlarmRate = new PDR.AlarmRate();
        oAlarmRate.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oAlarmRate.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oAlarmRate.lAlarmId = long.TryParse(lbFacility.Attributes["IDALARM"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDALARM"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDALARM"]))
            {
                oAlarmRate.lAlarmId = long.Parse(lbFacility.Attributes["IDALARM"].ToString());
            }
            TextBox txtAlarmHr = (TextBox)grdRow.FindControl("txtAlarmHr");
            TextBox txtOverrideStatus = (TextBox)grdRow.FindControl("txtOverrideStatus");
            TextBox txtOpenPath = (TextBox)grdRow.FindControl("txtOpenPath");
            TextBox txtPointGas = (TextBox)grdRow.FindControl("txtPointGas");

            oAlarmRate.sAlarmHr = txtAlarmHr.Text;
            oAlarmRate.sOverrideStatus = txtOverrideStatus.Text;
            oAlarmRate.sGDSOpenPath = txtOpenPath.Text;
            oAlarmRate.sGDSPointGas = txtPointGas.Text;

            //if (string.IsNullOrEmpty(txtAlarmHr.Text)) oAlarmRate.sAlarmHr = null; else oAlarmRate.sAlarmHr = decimal.Parse(txtAlarmHr.Text).ToString();
            //if (string.IsNullOrEmpty(txtOverrideStatus.Text)) oAlarmRate.sOverrideStatus = null; else oAlarmRate.sOverrideStatus = decimal.Parse(txtOverrideStatus.Text).ToString();
            //if (string.IsNullOrEmpty(txtOpenPath.Text)) oAlarmRate.sGDSOpenPath = null; else oAlarmRate.sGDSOpenPath = decimal.Parse(txtOpenPath.Text).ToString();
            //if (string.IsNullOrEmpty(txtPointGas.Text)) oAlarmRate.sGDSPointGas = null; else oAlarmRate.sGDSPointGas = decimal.Parse(txtPointGas.Text).ToString();

            if (oAlarmRate.lAlarmId == 0)
            {
                bRet = PDR.AlarmRateHelper.Insert(oAlarmRate);
            }
            else
            {
                bRet = PDR.AlarmRateHelper.Update(oAlarmRate);
            }
        }
    }
}