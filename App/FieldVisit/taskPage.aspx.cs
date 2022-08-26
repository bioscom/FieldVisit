using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class taskPage : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit != null) && (oSessnx.getOnlineUser.m_iRoleIdFieldVisit != 0))
            {
                if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.initiator)
                {
                    Response.Redirect("~/App/FieldVisit/Forms/MyRequets.aspx");
                }
                else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.superintendent)
                {
                    Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/Approvers/SuperintendentPendingRequests.aspx");
                }
                else if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin)
                {
                    Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/fieldVisitRequestStatus.aspx");
                }
                else
                {
                    Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/Approvers/oPendingFieldVisitRequest.aspx");
                }
            }
        }
    }
}