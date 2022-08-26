using System;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class eSearch : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["lRequestId"] != null)
        {
            Panel o = oRequests1.setPanelRequestStatus;
            o.Visible = false;
            long lRequestId = long.Parse(Request.QueryString["lRequestId"]);
            oRequests1.SearchResult(lRequestId);
        }
    }
}
