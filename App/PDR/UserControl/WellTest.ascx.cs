using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_WellTest : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {

    }
    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.WellTestSampleStatusHelper.dtGetWelltestSampleStatusFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        PDR.WellTestSampleStatus oWellTestSampleStatus = new PDR.WellTestSampleStatus();
        oWellTestSampleStatus.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oWellTestSampleStatus.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oWellTestSampleStatus.lWellId = long.TryParse(lbFacility.Attributes["IDWELL"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDWELL"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDWELL"]))
            {
                oWellTestSampleStatus.lWellId = long.Parse(lbFacility.Attributes["IDWELL"].ToString());
            }

            TextBox txtWellsOnProgramm = (TextBox)grdRow.FindControl("txtWellsOnProgramm");
            TextBox txtNoOfWellsFlowing = (TextBox)grdRow.FindControl("txtNoOfWells");
            TextBox txtCurrNoOfWells = (TextBox)grdRow.FindControl("txtCurrNoOfWells");
            TextBox txtCummulativeWells = (TextBox)grdRow.FindControl("txtCummulativeWells");
            TextBox txtWellsSampled = (TextBox)grdRow.FindControl("txtWellsSampled");
            TextBox txtMERPlan = (TextBox)grdRow.FindControl("txtMERPlan");
            TextBox txtMERActual = (TextBox)grdRow.FindControl("txtMERActual");


            oWellTestSampleStatus.sWellOnProgram = txtWellsOnProgramm.Text;
            oWellTestSampleStatus.sWellsFlowingStart = txtNoOfWellsFlowing.Text;
            oWellTestSampleStatus.sWellsFlowingCurrent = txtCurrNoOfWells.Text;
            oWellTestSampleStatus.sCummulatedWellTested = txtCummulativeWells.Text;
            oWellTestSampleStatus.sWellSampled = txtWellsSampled.Text;
            oWellTestSampleStatus.sMerPlan = txtMERPlan.Text;
            oWellTestSampleStatus.sMerActual = txtMERActual.Text;


            //if (string.IsNullOrEmpty(txtWellsOnProgramm.Text)) oWellTestSampleStatus.sWellOnProgram = null; else oWellTestSampleStatus.sWellOnProgram = txtWellsOnProgramm.Text;
            //if (string.IsNullOrEmpty(txtNoOfWellsFlowing.Text)) oWellTestSampleStatus.sWellsFlowingStart = null; else oWellTestSampleStatus.sWellsFlowingStart = txtNoOfWellsFlowing.Text;
            //if (string.IsNullOrEmpty(txtCurrNoOfWells.Text)) oWellTestSampleStatus.sWellsFlowingCurrent = null; else oWellTestSampleStatus.sWellsFlowingCurrent = txtCurrNoOfWells.Text;
            //if (string.IsNullOrEmpty(txtCummulativeWells.Text)) oWellTestSampleStatus.sCummulatedWellTested = null; else oWellTestSampleStatus.sCummulatedWellTested = txtCummulativeWells.Text;
            //if (string.IsNullOrEmpty(txtWellsSampled.Text)) oWellTestSampleStatus.sWellSampled = null; else oWellTestSampleStatus.sWellSampled = txtWellsSampled.Text;
            //if (string.IsNullOrEmpty(txtMERPlan.Text)) oWellTestSampleStatus.sMerPlan = null; else oWellTestSampleStatus.sMerPlan = txtMERPlan.Text;
            //if (string.IsNullOrEmpty(txtMERActual.Text)) oWellTestSampleStatus.sMerActual = null; else oWellTestSampleStatus.sMerActual = txtMERActual.Text;

            if (oWellTestSampleStatus.lWellId == 0)
            {
                bRet = PDR.WellTestSampleStatusHelper.Insert(oWellTestSampleStatus);
            }
            else
            {
                bRet = PDR.WellTestSampleStatusHelper.Update(oWellTestSampleStatus);
            }
        }
    }
}