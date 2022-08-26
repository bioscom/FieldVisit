using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_GasflareRejected : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Rejected Requests
            oRequestsRejected.LoadRejectedFlareWaiverRequests2(oSessnx.getOnlineUser);
            oRequestsRejected.setPanelRequestStatus.Visible = false;
        }
    }
}