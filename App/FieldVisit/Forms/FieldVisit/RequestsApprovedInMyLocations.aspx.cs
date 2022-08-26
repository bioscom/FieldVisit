using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FieldVisit_Forms_FieldVisit_RequestsApprovedInMyLocations : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            allRequestsApproved1.LoadFacilitiesInMyLocations(oSessnx.getOnlineUser.m_iUserId);
        }
    }
}