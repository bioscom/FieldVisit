using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_GasflareCancelled : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Cancelled Requests
            oRequestsCancelled.LoadCancelledFlareWaiverRequests2(oSessnx.getOnlineUser);
            oRequestsCancelled.setPanelRequestStatus.Visible = false;            
        }
    }
}