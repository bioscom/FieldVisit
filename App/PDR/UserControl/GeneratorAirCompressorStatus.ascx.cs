using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_GeneratorAirCompressorStatus : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {

    }
    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.GeneratorAirCompressorStatusHelper.dtGetGenAirCompressorFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        //long result = 0;
        bool bRet = false;
        PDR.GeneratorAirCompressorStatus oGeneratorAirCompressorStatus = new PDR.GeneratorAirCompressorStatus();
        oGeneratorAirCompressorStatus.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oGeneratorAirCompressorStatus.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oGeneratorAirCompressorStatus.lGenId = long.TryParse(lbFacility.Attributes["IDGEN"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDGEN"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDGEN"]))
            {
                oGeneratorAirCompressorStatus.lGenId = long.Parse(lbFacility.Attributes["IDGEN"].ToString());
            }
            TextBox txtGenA = (TextBox)grdRow.FindControl("txtGenA");
            TextBox txtGenB = (TextBox)grdRow.FindControl("txtGenB");
            TextBox txtGenC = (TextBox)grdRow.FindControl("txtGenC");
            TextBox txtDieselGenA = (TextBox)grdRow.FindControl("txtDieselGenA");
            TextBox txtDieselGenB = (TextBox)grdRow.FindControl("txtDieselGenB");
            TextBox txtAirCompA = (TextBox)grdRow.FindControl("txtAirCompA");
            TextBox txtAirCompB = (TextBox)grdRow.FindControl("txtAirCompB");
            TextBox txtAirCompC = (TextBox)grdRow.FindControl("txtAirCompC");
            TextBox txtAirCompD = (TextBox)grdRow.FindControl("txtAirCompD");

            oGeneratorAirCompressorStatus.sGen1 = txtGenA.Text;
            oGeneratorAirCompressorStatus.sGen2 = txtGenB.Text;

            oGeneratorAirCompressorStatus.sGen3 = txtGenC.Text;
            oGeneratorAirCompressorStatus.sDieselGen1 = txtDieselGenA.Text;
            oGeneratorAirCompressorStatus.sDieselGen2 = txtDieselGenB.Text;
            oGeneratorAirCompressorStatus.sAirCompressor1 = txtAirCompA.Text;
            oGeneratorAirCompressorStatus.sAirCompressor2 = txtAirCompB.Text;
            oGeneratorAirCompressorStatus.sAirCompressor3 = txtAirCompC.Text;
            oGeneratorAirCompressorStatus.sAirCompressor4 = txtAirCompD.Text;

            //if (string.IsNullOrEmpty(txtGenA.Text)) oGeneratorAirCompressorStatus.sGen1 = null; else oGeneratorAirCompressorStatus.sGen1 = txtGenA.Text;
            //if (string.IsNullOrEmpty(txtGenB.Text)) oGeneratorAirCompressorStatus.sGen2 = null; else oGeneratorAirCompressorStatus.sGen2 = txtGenB.Text;
            //if (string.IsNullOrEmpty(txtGenC.Text)) oGeneratorAirCompressorStatus.sGen3 = null; else oGeneratorAirCompressorStatus.sGen3 = txtGenC.Text;
            //if (string.IsNullOrEmpty(txtDieselGenA.Text)) oGeneratorAirCompressorStatus.sDieselGen1 = null; else oGeneratorAirCompressorStatus.sDieselGen1 = txtDieselGenA.Text;
            //if (string.IsNullOrEmpty(txtDieselGenB.Text)) oGeneratorAirCompressorStatus.sDieselGen2 = null; else oGeneratorAirCompressorStatus.sDieselGen2 = txtDieselGenB.Text;
            //if (string.IsNullOrEmpty(txtAirCompA.Text)) oGeneratorAirCompressorStatus.sAirCompressor1 = null; else oGeneratorAirCompressorStatus.sAirCompressor1 = txtAirCompA.Text;
            //if (string.IsNullOrEmpty(txtAirCompB.Text)) oGeneratorAirCompressorStatus.sAirCompressor2 = null; else oGeneratorAirCompressorStatus.sAirCompressor2 = txtAirCompB.Text;
            //if (string.IsNullOrEmpty(txtAirCompC.Text)) oGeneratorAirCompressorStatus.sAirCompressor3 = null; else oGeneratorAirCompressorStatus.sAirCompressor3 = txtAirCompC.Text;
            //if (string.IsNullOrEmpty(txtAirCompD.Text)) oGeneratorAirCompressorStatus.sAirCompressor4 = null; else oGeneratorAirCompressorStatus.sAirCompressor4 = txtAirCompD.Text;

            if (oGeneratorAirCompressorStatus.lGenId == 0)
                bRet = PDR.GeneratorAirCompressorStatusHelper.Insert(oGeneratorAirCompressorStatus);
            else 
                bRet = PDR.GeneratorAirCompressorStatusHelper.Update(oGeneratorAirCompressorStatus);
        }
    }
}