using System;
using System.Collections.Generic;
using Microsoft.Security.Application;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_ManHour_Forms_DefaultApproval : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if ((oSessnx.getOnlineUser.m_iRoleIdManHr == null) || (oSessnx.getOnlineUser.m_iRoleIdManHr == 0))
                    MyInitiatives.Init_Control();
                else if (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)AppUsersRolesInitMgt.UserRole.Admin)
                    MyInitiatives.Init_Control_Admin();
                else
                    MyInitiatives.Init_Control_Approvers();

                if (Request.QueryString["xMod"].ToString() == "Nor")
                {
                    //This will be the mode when you want to create a new Initiative
                    //ApproveSupportTabPanel.Visible = false;
                    LoadMyManHrInitiative(-1);

                    //Approvers.InitValues();
                }
                else if (Request.QueryString["xMod"].ToString() == "Edt")
                {
                    //This will be the mode when you want to edit an Initiative.
                    //Note: when you have initiatives already created, the list of the Initiatives will show on the left side of your screen.
                    //And the first one will be in the edit mode by default

                    //ApproveSupportTabPanel.Visible = false;

                    long lInitiativeId = long.Parse(Encoder.HtmlEncode(Request.QueryString["IntiativeId"].ToString()));

                    LoadMyManHrInitiative(lInitiativeId);
                    Report1.Init_Page(lInitiativeId);
                    MainReport1.Init_Page(lInitiativeId);
                    StatusMilestoneReport.Init_Page(lInitiativeId);
                    ViewComments1.Init_Page(lInitiativeId);
                }
                else if (Request.QueryString["xMod"].ToString() == "Viw")
                {
                    //This will be the mode for viewers
                    //approvalTabPanel.Visible = false;
                    //pnlDistrict.Visible = false;
                    //pnlResourceUtilisation.Visible = false;
                    //pnlBusinessInitiative.Visible = false;
                    //progressTabPanel.Visible = false;

                    long lInitiativeId = long.Parse(Encoder.HtmlEncode(Request.QueryString["IntiativeId"].ToString()));

                    LoadMyManHrInitiative(lInitiativeId);
                    Report1.Init_Page(lInitiativeId);
                    MainReport1.Init_Page(lInitiativeId);
                    StatusMilestoneReport.Init_Page(lInitiativeId);
                    ViewComments1.Init_Page(lInitiativeId);

                    InitiativeApproval oInitiativeApproval = new InitiativeApproval();
                    List<InitiativeApproval> lstApprovals = oInitiativeApproval.lstGetApproversByInitiativeId(lInitiativeId);
                    foreach (InitiativeApproval MyApproval in lstApprovals)
                    {
                        if (MyApproval.m_iUserId == oSessnx.getOnlineUser.m_iUserId)
                        {
                            ApproveSupport1.Init_Control(lInitiativeId, MyApproval.m_iApprovalID);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void LoadMyManHrInitiative(long lInitiativeId)
    {
        Initiative ThisInitiative = Initiative.objGetInitiativeById(lInitiativeId);

        //Load Initiative
        lblInitiativeTitle.Text = ThisInitiative.m_sTitle;
        RequestStatus(ThisInitiative);
    }

    private void RequestStatus(Initiative ThisInitiative)
    {
        if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.Sponsor)
        {
            lblStatus.ForeColor = System.Drawing.Color.Navy;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Sponsor);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.FunctionalLead)
        {
            lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.FunctionalLead);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.AssetPlanner)
        {
            lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetPlanner);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.AssetOperationsManager)
        {
            lblStatus.ForeColor = System.Drawing.Color.Brown;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetOperationsManager);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.Approved)
        {
            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Approved);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.Callme)
        {
            lblStatus.ForeColor = System.Drawing.Color.Purple;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Callme);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.NotApproved)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NotApproved);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.Reschedule)
        {
            lblStatus.ForeColor = System.Drawing.Color.PaleGreen;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Reschedule);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.NoComment)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NoComment);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.Deleted)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Deleted);
        }
        else if (ThisInitiative.m_iStatus == (int)Approval.apprStatusRpt.NewInitiative)
        {
            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NewInitiative);
        }
    }
}