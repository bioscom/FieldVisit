using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_SavingsTransaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OpportunityCostHelper o = new OpportunityCostHelper();

        if (!IsPostBack)
        {
            ddlYear.Items.Add(DateTime.Today.Year.ToString());
            List<int> lYear = o.lstYears();
            foreach (int i in lYear)
            {
                ddlYear.Items.Add(i.ToString());
            }

            ddlYear.SelectedValue = DateTime.Today.Year.ToString();

            //OpportunityCostHelper.iYear
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        TransactionYear o = new TransactionYear();
        bool bRet = o.UpdateTransactionYear(int.Parse(ddlYear.SelectedValue));
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Year Changed.");
        }
    }
}