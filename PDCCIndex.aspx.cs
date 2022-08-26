using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDCCIndex : System.Web.UI.Page
{

    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    readonly Department _Department = new Department();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //OpexFectoImprovementActualPotential objOffShoreOnShore = _opportunityCostHelper.ObjGetPDPerformanceSummaryByYear(OpportunityCostHelper.iYear);

            //lblFecto.Text = stringRoutine.formatAsBankMoney("$", objOffShoreOnShore.dFecto);
            //lblImpOpp.Text = stringRoutine.formatAsBankMoney("$", objOffShoreOnShore.dImprovement);
            //lblPDSavings.Text = stringRoutine.formatAsBankMoney("$", (objOffShoreOnShore.dActSavings + objOffShoreOnShore.dImprovement));
        }
    }
}