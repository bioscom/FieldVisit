using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_FlareTargetFrm : System.Web.UI.Page
{
    FlareTargetHelper oHlp = new FlareTargetHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Facility> lstFac = Facility.lstGetFacilities();
            foreach (Facility lFac in lstFac)
            {
                ddlFacility.Items.Add(new ListItem(lFac.m_sFacility, lFac.m_iFacilityId.ToString()));
            }
        }
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        try
        {
            FlareTarget oT = new FlareTarget();

            //oT.lTargetId = long.Parse(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            oT.iFacilityId = int.Parse(ddlFacility.SelectedValue);
            oT.iYear = DateTime.Now.Year;
            oT.iJan = Convert.ToDecimal(txtJan.Text);
            oT.iFeb = Convert.ToDecimal(txtFeb.Text);
            oT.iMar = Convert.ToDecimal(txtMar.Text);
            oT.iApr = Convert.ToDecimal(txtApr.Text);
            oT.iMay = Convert.ToDecimal(txtMay.Text);
            oT.iJun = Convert.ToDecimal(txtJun.Text);
            oT.iJul = Convert.ToDecimal(txtJul.Text);
            oT.iAug = Convert.ToDecimal(txtAug.Text);
            oT.iSep = Convert.ToDecimal(txtSep.Text);
            oT.iOct = Convert.ToDecimal(txtOct.Text);
            oT.iNov = Convert.ToDecimal(txtNov.Text);
            oT.iDec = Convert.ToDecimal(txtDec.Text);
            oT.iYTD = Convert.ToDecimal(txtYTD.Text);

            oHlp.Insert(oT);

            //InitPage();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}