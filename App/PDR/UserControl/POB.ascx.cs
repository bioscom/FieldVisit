using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_POB : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.POBHelper.dtGetPOBFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        //long result = 0;
        bool bRet = false;
        PDR.POB oPOB = new PDR.POB();
        oPOB.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oPOB.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oPOB.lPobId = long.TryParse(lbFacility.Attributes["IDPOB"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDPOB"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDPOB"]))
            {
                oPOB.lPobId = long.Parse(lbFacility.Attributes["IDPOB"].ToString());
            }

            TextBox txtCurrentPOB = (TextBox)grdRow.FindControl("txtCurrentPOB");
            TextBox txtCritical = (TextBox)grdRow.FindControl("txtCritical");
            TextBox txtNonCritical = (TextBox)grdRow.FindControl("txtNonCritical");
            TextBox txtRemarks = (TextBox)grdRow.FindControl("txtRemarks");

            oPOB.sCurrentPOB = txtCurrentPOB.Text;
            oPOB.sCritical = txtCritical.Text;
            oPOB.sNonCritical = txtNonCritical.Text;
            oPOB.sRemarks = txtRemarks.Text;

            //if (string.IsNullOrEmpty(txtCurrentPOB.Text)) oPOB.sCurrentPOB = null; else oPOB.sCurrentPOB = txtCurrentPOB.Text;
            //if (string.IsNullOrEmpty(txtCritical.Text)) oPOB.sCritical = null; else oPOB.sCritical = txtCritical.Text;
            //if (string.IsNullOrEmpty(txtNonCritical.Text)) oPOB.sNonCritical = null; else oPOB.sNonCritical = txtNonCritical.Text;
            //if (string.IsNullOrEmpty(txtRemarks.Text)) oPOB.sRemarks = null; else oPOB.sRemarks = txtRemarks.Text;

            if (oPOB.lPobId == 0)
                bRet = PDR.POBHelper.Insert(oPOB);
            else 
                bRet = PDR.POBHelper.Update(oPOB);
        }
    }
}