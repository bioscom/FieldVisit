using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_ThreePartMonthlySumm : System.Web.UI.Page
{
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ThreePartOpprInitialEst1.Init_ControlInitialEstimatedSavings(oTrans.tYear().iYear);
            ThreePartOpprEstSavings1.Init_ControlEstimatedSavings(oTrans.tYear().iYear);
            ThreePartOpprActual1.Init_ControlActualSavings(oTrans.tYear().iYear);
            ThreePartOpprLE1.Init_ControlLESavings(oTrans.tYear().iYear);
        }
    }
}