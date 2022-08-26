using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_UserControl_AGOStatus : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {

    }
    public void Init_Page(int iDistrictId, long lReportId)
    {
        grdView.DataSource = PDR.AGOStatusLogisticsHelper.dtGetAGOStatusFacilitiesByDisctrict(iDistrictId);
        lReportIdHF.Value = lReportId.ToString();
        grdView.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        PDR.AGOStatusLogistics oAGOStatusLogistics = new PDR.AGOStatusLogistics();

        oAGOStatusLogistics.lReportId = long.Parse(lReportIdHF.Value);

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbFacility = (Label)grdRow.FindControl("lbFacility");
            oAGOStatusLogistics.iFacilityId = int.Parse(lbFacility.Attributes["ID_FACILITIES"].ToString());
            //oAGOStatusLogistics.lAgoId = long.TryParse(lbFacility.Attributes["IDAGO"].ToString(), out result) ? 0 : long.Parse(lbFacility.Attributes["IDAGO"].ToString());
            if (!string.IsNullOrEmpty(lbFacility.Attributes["IDAGO"]))
            {
                oAGOStatusLogistics.lAgoId = long.Parse(lbFacility.Attributes["IDAGO"].ToString());
            }

            TextBox txtActualStock = (TextBox)grdRow.FindControl("txtActualStock");
            TextBox txtIssuedConsumed = (TextBox)grdRow.FindControl("txtIssuedConsumed");
            TextBox txtEndurance = (TextBox)grdRow.FindControl("txtEndurance");
            TextBox txtBoatAvailability = (TextBox)grdRow.FindControl("txtBoatAvailability");

            oAGOStatusLogistics.sActualStock = txtActualStock.Text;
            oAGOStatusLogistics.sIssuedComsumed = txtIssuedConsumed.Text;
            oAGOStatusLogistics.sEndurance = txtEndurance.Text;
            oAGOStatusLogistics.sBoatAvailability = txtBoatAvailability.Text;

            //if (string.IsNullOrEmpty(txtActualStock.Text)) oAGOStatusLogistics.sActualStock = null; else oAGOStatusLogistics.sActualStock = decimal.Parse(txtActualStock.Text).ToString();
            //if (string.IsNullOrEmpty(txtIssuedConsumed.Text)) oAGOStatusLogistics.sIssuedComsumed = null; else oAGOStatusLogistics.sIssuedComsumed = decimal.Parse(txtIssuedConsumed.Text).ToString();
            //if (string.IsNullOrEmpty(txtEndurance.Text)) oAGOStatusLogistics.sEndurance = null; else oAGOStatusLogistics.sEndurance = decimal.Parse(txtEndurance.Text).ToString();
            //if (string.IsNullOrEmpty(txtBoatAvailability.Text)) oAGOStatusLogistics.sBoatAvailability = null; else oAGOStatusLogistics.sBoatAvailability = decimal.Parse(txtBoatAvailability.Text).ToString();

            if (oAGOStatusLogistics.lAgoId == 0)
            {
                bRet = PDR.AGOStatusLogisticsHelper.Insert(oAGOStatusLogistics);
            }
            else
            {
                bRet = PDR.AGOStatusLogisticsHelper.Update(oAGOStatusLogistics);
            }
        }
    }
}