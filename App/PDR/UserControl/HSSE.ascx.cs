using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_HSSE : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.HSSEGoalZeroHelper.dtGetHSSEFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //long result = 0;
            bool bRet = false;
            PDR.HSSEGoalZero oHSSEGoalZero = new PDR.HSSEGoalZero();

            oHSSEGoalZero.lReportId = long.Parse(lReportIdHF.Value);

            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lbFacility = (Label)grdRow.FindControl("lbFacility");
                oHSSEGoalZero.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
                if (!string.IsNullOrEmpty(lbFacility.Attributes["IDHSSE"]))
                {
                    oHSSEGoalZero.lHsseId = long.Parse(lbFacility.Attributes["IDHSSE"].ToString());
                }
                //oHSSEGoalZero.lHsseId = long.TryParse(lbFacility.Attributes["IDHSSE"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDHSSE"].ToString());

                TextBox txtLTI = (TextBox)grdRow.FindControl("txtLTI");
                TextBox txtOperationalSpill = (TextBox)grdRow.FindControl("txtOperationalSpill");
                TextBox txtZeroPlantDays = (TextBox)grdRow.FindControl("txtZeroPlantDays");
                TextBox txtFountainAssurance = (TextBox)grdRow.FindControl("txtFountainAssurance");
                TextBox txtSOL = (TextBox)grdRow.FindControl("txtSOL");

                oHSSEGoalZero.sLTI = txtLTI.Text;
                oHSSEGoalZero.sGoalZeroDays = txtOperationalSpill.Text;
                oHSSEGoalZero.sZeroPlantDays = txtZeroPlantDays.Text;
                oHSSEGoalZero.sFountainAssurance = txtFountainAssurance.Text;
                oHSSEGoalZero.sSOL = txtSOL.Text;

                //if (string.IsNullOrEmpty(txtLTI.Text)) oHSSEGoalZero.sLTI = null; else oHSSEGoalZero.sLTI = txtLTI.Text;
                //if (string.IsNullOrEmpty(txtOperationalSpill.Text)) oHSSEGoalZero.sGoalZeroDays = null; else oHSSEGoalZero.sGoalZeroDays = txtOperationalSpill.Text;
                //if (string.IsNullOrEmpty(txtZeroPlantDays.Text)) oHSSEGoalZero.sZeroPlantDays = null; else oHSSEGoalZero.sZeroPlantDays = txtZeroPlantDays.Text;
                //if (string.IsNullOrEmpty(txtFountainAssurance.Text)) oHSSEGoalZero.sFountainAssurance = null; else oHSSEGoalZero.sFountainAssurance = txtFountainAssurance.Text;
                //if (string.IsNullOrEmpty(txtSOL.Text)) oHSSEGoalZero.sSOL = null; else oHSSEGoalZero.sSOL = txtSOL.Text;

                oHSSEGoalZero.sFountainAssuranceRemarks = "";
                oHSSEGoalZero.sGoalZeroDaysRemarks = "";
                oHSSEGoalZero.sLTIRemarks = "";
                oHSSEGoalZero.sSOLRemarks = "";
                oHSSEGoalZero.sZeroPlantDaysRemarks = "";

                if (oHSSEGoalZero.lHsseId == 0)
                {
                    bRet = PDR.HSSEGoalZeroHelper.Insert(oHSSEGoalZero);
                }
                else
                {
                    bRet = PDR.HSSEGoalZeroHelper.Update(oHSSEGoalZero);
                }
            }
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}