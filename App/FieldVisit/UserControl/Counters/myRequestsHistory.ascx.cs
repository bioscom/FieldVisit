using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Counters_myRequestsHistory : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page()
    {
        approvedRequestLinkButton.Text = fieldVisitDetails.dtApprovedFieldVisitDetailsByInitiator(oSessnx.getOnlineUser.m_iUserId).Rows.Count.ToString();
        pendingRequestsLnk.Text = fieldVisitDetails.dtPendingFieldVisitDetailsByInitiator(oSessnx.getOnlineUser.m_iUserId).Rows.Count.ToString();
    }
}
