using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_ECFlareAnalyser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int iMonth = int.Parse(Request.QueryString["iM"].ToString());
            int iYear = int.Parse(Request.QueryString["iY"].ToString());
            string sCode = Request.QueryString["sCd"].ToString();
            decimal dFlareTarget = decimal.Parse(Request.QueryString["Tgt"].ToString());

            //oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, dFlareTarget);
        }
    }
}