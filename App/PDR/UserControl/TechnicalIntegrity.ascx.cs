using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_TechnicalIntegrity : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.TechnicalIntegrityHelper.dtGetTechIntegrityFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        PDR.TechnicalIntegrity oTechnicalIntegrity = new PDR.TechnicalIntegrity();
        oTechnicalIntegrity.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oTechnicalIntegrity.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oTechnicalIntegrity.lTiId = long.TryParse(lbFacility.Attributes["IDTI"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDTI"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDTI"]))
            {
                oTechnicalIntegrity.lTiId = long.Parse(lbFacility.Attributes["IDTI"].ToString());
            }

            TextBox txtPMDue = (TextBox)grdRow.FindControl("txtPMDue");
            TextBox txtPMCompleted = (TextBox)grdRow.FindControl("txtPMCompleted");
            TextBox txtPMComplaint = (TextBox)grdRow.FindControl("txtPMComplaint");

            TextBox txtSCEDue = (TextBox)grdRow.FindControl("txtSCEDue");
            TextBox txtSCECompleted = (TextBox)grdRow.FindControl("txtSCECompleted");
            TextBox txtSCEComplaint = (TextBox)grdRow.FindControl("txtSCEComplaint");

            TextBox txtCMDUE = (TextBox)grdRow.FindControl("txtCMDUE");
            TextBox txtCMCompleted = (TextBox)grdRow.FindControl("txtCMCompleted");
            TextBox txtCMComplaint = (TextBox)grdRow.FindControl("txtCMComplaint");

            oTechnicalIntegrity.sPMDue = txtPMDue.Text;
            oTechnicalIntegrity.sPMCompleted = txtPMCompleted.Text;
            oTechnicalIntegrity.sPMComplaint = txtPMComplaint.Text;
            
            oTechnicalIntegrity.sSCEDue = txtSCEDue.Text;
            oTechnicalIntegrity.sSCECompleted = txtSCECompleted.Text;
            oTechnicalIntegrity.sSCEComplaint = txtSCEComplaint.Text;

            oTechnicalIntegrity.sCMDue = txtCMDUE.Text;
            oTechnicalIntegrity.sCMCompleted = txtCMCompleted.Text;
            oTechnicalIntegrity.sCMComplaint = txtCMComplaint.Text;

            //if (string.IsNullOrEmpty(txtPMDue.Text)) oTechnicalIntegrity.sPMDue = null; else oTechnicalIntegrity.sPMDue = txtPMDue.Text;
            //if (string.IsNullOrEmpty(txtPMCompleted.Text)) oTechnicalIntegrity.sPMCompleted = null; else oTechnicalIntegrity.sPMCompleted = txtPMCompleted.Text;
            //if (string.IsNullOrEmpty(txtPMComplaint.Text)) oTechnicalIntegrity.sPMComplaint = null; else oTechnicalIntegrity.sPMComplaint = txtPMComplaint.Text;

            //if (string.IsNullOrEmpty(txtSCEDue.Text)) oTechnicalIntegrity.sCMDue = null; else oTechnicalIntegrity.sCMDue = txtSCEDue.Text;
            //if (string.IsNullOrEmpty(txtSCECompleted.Text)) oTechnicalIntegrity.sCMCompleted = null; else oTechnicalIntegrity.sCMCompleted = txtSCECompleted.Text;
            //if (string.IsNullOrEmpty(txtSCEComplaint.Text)) oTechnicalIntegrity.sCMComplaint = null; else oTechnicalIntegrity.sCMComplaint = txtSCEComplaint.Text;

            //if (string.IsNullOrEmpty(txtCMDUE.Text)) oTechnicalIntegrity.sCMDue = null; else oTechnicalIntegrity.sCMDue = txtCMDUE.Text;
            //if (string.IsNullOrEmpty(txtCMCompleted.Text)) oTechnicalIntegrity.sCMCompleted = null; else oTechnicalIntegrity.sCMCompleted = txtCMCompleted.Text;
            //if (string.IsNullOrEmpty(txtCMComplaint.Text)) oTechnicalIntegrity.sCMComplaint = null; else oTechnicalIntegrity.sCMComplaint = txtCMComplaint.Text;

            if (oTechnicalIntegrity.lTiId == 0)
            {
                bRet = PDR.TechnicalIntegrityHelper.Insert(oTechnicalIntegrity);
            }
            else
            {
                bRet = PDR.TechnicalIntegrityHelper.Update(oTechnicalIntegrity);
            }
        }
    }
}