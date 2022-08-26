using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fieldVisitRequestStatus : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString(), appUsersRoles.userRole.initiator.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFieldVisit);

            if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

            if (!IsPostBack)
            {
                allRequestsPendingApproval1.InitPage(); //Requests Pending Approval
                allRequestsApproved1.InitPage(); //Approved Requests
                allRequestsApproved2.LoadRequestsNotApproved(); //Request Not Approved
                allRequestsApproved3.LoadRequestsToBeRescheduled(); //Requests to be rescheduled
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(AppConfiguration.appNameId, ex.ToString());
        }
    }
}
