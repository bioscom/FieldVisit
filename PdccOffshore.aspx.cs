using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PdccOffshore : System.Web.UI.Page
{
    readonly Department _gDepartment = new Department();
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    TransactionYear oTrans = new TransactionYear();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Chartting1.Offshore(oTrans.tYear().iYear);
            CharttingData1.OnOffshore(oTrans.tYear().iYear, (int)ItemStatus.ItStatus.Offshore);
        }
    }
}