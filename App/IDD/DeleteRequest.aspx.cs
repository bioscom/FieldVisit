using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_IDD_DeleteRequest : System.Web.UI.Page
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
        {
            long lVendorId = long.Parse(Request.QueryString["lVendorId"]);
            long lRequestId = long.Parse(Request.QueryString["lRequestId"]);

            oDetails.ViewDetailsByVendor(lVendorId, lRequestId);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(Request.QueryString["lRequestId"]);
        bool bRet = o.DeleteDuplicateRequest(lRequestId);

        if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
    }
}