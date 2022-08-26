using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_ManHour_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //MyBusinessInitiatives();
            //Note: when a user logs in by clicking a link, the system should get the lInitiativeID and load the content for preview and approval.


            long lInitiativeId = 0;
            if (Request.QueryString["IntiativeId"] != null)
            {
                lInitiativeId = long.Parse(Request.QueryString["IntiativeId"].ToString());
                ApproveThisInitiative(lInitiativeId);
            }
            else
            {
                MyBusinessInitiatives();
                //if ((oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.initiator) || (oSessnx.getOnlineUser.m_iRoleIdManHr == null) || (oSessnx.getOnlineUser.m_iRoleIdManHr == 0)) MyBusinessInitiatives();
                //else if (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.admin) MyBusinessInitiatives();
                //else
                //{

                //}
            }
        }
    }
    private void MyBusinessInitiatives()
    {
        Initiative oInitiative = new Initiative();
        List<Initiative> Initiatives = oInitiative.lstGetInitiativesByUserId(oSessnx.getOnlineUser.m_iUserId);
        if (Initiatives.Count > 0)
        {
            foreach (Initiative initiative in Initiatives)
            {
                Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Edt&IntiativeId=" + initiative.m_lInitiativeId);
                break;
            }
        }
        else
        {
            Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Nor");
        }
    }

    private void ApproveThisInitiative(long lInitiativeId)
    {
        //Before allowing user to action a request, check if he had already actioned it
        InitiativeApproval oInitiativeApproval = new InitiativeApproval();
        List<InitiativeApproval> oApprovers = oInitiativeApproval.lstGetApproversByInitiativeId(lInitiativeId);
        foreach (InitiativeApproval oApprover in oApprovers)
        {
            if (oApprover.m_iUserId == oSessnx.getOnlineUser.m_iUserId)
            {
                if (oApprover.m_iStand == (int)Approval.apprStatusRpt.NoComment)
                {
                    Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Viw&IntiativeId=" + lInitiativeId);
                }
                else
                {
                    MyBusinessInitiatives();
                }
                break;
            }
        }
    }
}