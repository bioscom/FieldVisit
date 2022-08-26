using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_SEPCiN_OthersRequest : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page()
    {
        DataTable dt = new DataTable();
        //DataTable dtActivitySponsor = new DataTable();
        //DataTable dtFuntionalLead = new DataTable();
        //DataTable dtAssetPlanner = new DataTable();
        //DataTable dtAssetManager = new DataTable();

        int KounterPending = 0;
        int KounterApproved = 0;

        //dt = PECApprover.dtPECRequestPendingMyApproval(oSessnx.getOnlineUser.m_iUserId);


        if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.sponsor)
            dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.Sponsor, oSessnx.getOnlineUser.m_iUserId);
        else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.FunctionalLead)
            dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.FunctionalLead, oSessnx.getOnlineUser.m_iUserId);
        else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.planner)
            dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.AssetPlanner, oSessnx.getOnlineUser.m_iUserId);
        else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.AssetOperationsManager)
            dt = PECApprover.dtPECRequestPendingMyApproval((int)Approval.apprStatusRpt.AssetOperationsManager, oSessnx.getOnlineUser.m_iUserId);


        KounterPending = dt.Rows.Count;

        KounterApproved = PECApprover.dtPECRequestApproved((int)Approval.apprStatusRpt.Approved, oSessnx.getOnlineUser.m_iUserId).Rows.Count;

        pendingApprovalLinkButton.Text = KounterPending.ToString();
        approvedRequestLinkButton.Text = KounterApproved.ToString();
    }
}
