using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Counters_myApprovedRequestsHistory : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page()
    {
        //TODO: when a superintendent approves how do you get the statistics of his approval, please find solution
        approvedRequestLinkButton.Text = fieldVisitDetails.dtApprovedFieldVisitByApprover(oSessnx.getOnlineUser.m_iUserId, oSessnx.getOnlineUser.m_iRoleIdFieldVisit).Rows.Count.ToString();
        pendingApprovalLinkButton.Text = fieldVisitDetails.dtPendingFieldVisitByApprover(oSessnx.getOnlineUser.m_iUserId, oSessnx.getOnlineUser.m_iRoleIdFieldVisit).Rows.Count.ToString();
        rejectedLinkButton.Text = fieldVisitDetails.dtRejectedFieldVisiRequestsByApprover(oSessnx.getOnlineUser.m_iUserId, oSessnx.getOnlineUser.m_iRoleIdFieldVisit).Rows.Count.ToString();
    }
}
