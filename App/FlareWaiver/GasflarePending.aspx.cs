using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_GasflarePending : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Pending Requests
            if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator)
            {
                lblTitle.Text = " Pending Flare waiver Requests";
            }
            else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
            {
                lblTitle.Text = "My Pending Flare waiver requests";
            }
            else
            {
                lblTitle.Text = "Flare waiver requests pending my approval";
                Panel oPanel = oRequestsPending.setPanelRequestStatus;
                oPanel.Visible = false;
            }
            oRequestsPending.LoadPendingFlareWaiverRequests2(oSessnx.getOnlineUser);
        }
    }
}