using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Counters_SuperIntendentCounter : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page()
    {
        try
        {
            int iApproved = 0;
            int iPending = 0;

            List<SuperintendentFunctionalAcctUser> MySuperintendents = SuperintendentFunctionalAcctUser.lstGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
            foreach (SuperintendentFunctionalAcctUser MySuperintendent in MySuperintendents)
            {
                iApproved += fieldVisitDetails.dtApprovedFieldVisitBySuperintendent(MySuperintendent.superintendentId, (int)appUsersRoles.userRole.superintendent).Rows.Count;
                iPending += fieldVisitDetails.dtPendingFieldVisitBySuperintendent(MySuperintendent.superintendentId, (int)appUsersRoles.userRole.superintendent).Rows.Count;
            }

            approvedRequestLinkButton.Text = iApproved.ToString();
            pendingRequestsLnk.Text = iPending.ToString();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}