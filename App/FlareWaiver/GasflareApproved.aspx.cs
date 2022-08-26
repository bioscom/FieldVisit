using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_GasflareApproved : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Approved Requests
            if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator)
            {
                lblTitleApproved.Text = "My approved flare waiver requests";
            }
            else
            {
                lblTitleApproved.Text = "Approved flare waiver requests";
            }

            oRequestsApproved.LoadApprovedFlareWaiverRequests2(oSessnx.getOnlineUser);
            //oRequestsApproved.HideSomeColumns(1);
            oRequestsApproved.setPanelRequestStatus.Visible = false;
        }
    }
}