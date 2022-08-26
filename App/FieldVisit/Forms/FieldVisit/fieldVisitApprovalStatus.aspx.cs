using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Security.Application;

public partial class fieldVisitApprovalStatus : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ActivityId"] != null)
            {
                long ActivityId = long.Parse(Request.QueryString["ActivityId"].ToString());
                fieldVisitInformation1.InitPage(ActivityId);

                DataTable dt = siteVisitApproval.dtFieldVisitStatusByActivityId(ActivityId);
                //dt.Merge(siteVisitApproval.dtFieldVisitStatusActivityPlannerByActivityId(ActivityId));

                grdView.DataSource = dt;
                grdView.DataBind();

                fieldVisitDetails me = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(ActivityId);
                Superintendent oSuperintendent = Superintendent.objGetSuperintendentById(me.eFacility.eSuperintendent.m_iSuperintendentId);
                foreach (GridViewRow grdRow in grdView.Rows)
                {
                    Label status = (Label)grdRow.FindControl("labelStand");
                    Label role = (Label)grdRow.FindControl("labelRole");
                    Label lblSuperintendent = (Label)grdRow.FindControl("labelFullName");
                    CheckBox ckb = (CheckBox)grdRow.FindControl("reminderCheckBox");

                    if (lblSuperintendent.Text == "")
                    {
                        if (lblSuperintendent.Attributes["USERID"] != "")
                        {
                            int iUSERID = Convert.ToInt32(lblSuperintendent.Attributes["USERID"]);

                            lblSuperintendent.Text = Encoder.HtmlEncode(appUsersHelper.objGetUserByUserId(iUSERID).m_sFullName);
                        }
                    }

                    if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval)
                    {
                        status.ForeColor = System.Drawing.Color.Navy;
                        status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval);
                    }
                    else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
                    {
                        ckb.Enabled = false;
                        status.ForeColor = System.Drawing.Color.Green;
                        status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.Approved);
                    }
                    else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.Callme)
                    {
                        status.ForeColor = System.Drawing.Color.Purple;
                        status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.Callme);
                    }
                    else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.NotApproved)
                    {
                        status.ForeColor = System.Drawing.Color.Red;
                        status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.NotApproved);
                    }
                    else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.Reschedule)
                    {
                        status.ForeColor = System.Drawing.Color.PaleGreen;
                        status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.Reschedule);
                    }
                    else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval)
                    {
                        status.ForeColor = System.Drawing.Color.Brown;
                        status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval);
                    }
                    else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.NoComment)
                    {
                        status.ForeColor = System.Drawing.Color.Red;
                        status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.NoComment);
                    }

                    if (int.Parse(role.Text) == (int)appUsersRoles.userRole.sponsor)
                    {
                        role.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
                    }
                    else if (int.Parse(role.Text) == (int)appUsersRoles.userRole.planner)
                    {
                        role.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
                        //status.ForeColor = System.Drawing.Color.Red;
                        //status.Text = "Comment not required.";
                    }
                    else if (int.Parse(role.Text) == (int)appUsersRoles.userRole.superintendent)
                    {
                        role.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.superintendent);
                    }
                }

                List<SuperintendentFunctionalAcctUserDetails> Superintendents = SuperintendentFunctionalAcctUser.lstGetSuperintendentFunctionalAcctUsersBySuperintendent(me.eFacility.eSuperintendent.m_iSuperintendentId);
                foreach (SuperintendentFunctionalAcctUserDetails xSuperintendent in Superintendents)
                {
                    superIntendentMembersCheckBoxList.Items.Add(xSuperintendent.fullName + " (" + xSuperintendent.email + ")");
                }
            }
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    //protected void btnSelect_Click(object sender, EventArgs e)
    //{
    //    //int superintendentId = int.Parse(viwMembers.Attributes["USERID"].ToString());

        
    //}
    
    protected void closeButton_Click(object sender, EventArgs e)
    {

    }

    protected void reminderButton_Click(object sender, EventArgs e)
    {
        appUsersHelper oappUsersHelper = new appUsersHelper();
        appUsers oappUsers = new appUsers();
        structUserMailIdx oReceiver = new structUserMailIdx();

        long lActivityId = long.Parse(Request.QueryString["ActivityId"].ToString());
        sendMailFieldVisit emailSystem = new sendMailFieldVisit(oSessnx.getOnlineUser.structUserIdx);

        foreach (GridViewRow grdRows in grdView.Rows)
        {
            CheckBox ckb = (CheckBox)grdRows.FindControl("reminderCheckBox");
            if (ckb.Checked)
            {
                oReceiver = new structUserMailIdx(oappUsersHelper.objGetUserByUserID(int.Parse(ckb.Attributes["USERID"].ToString())).structUserIdx);                
                bool sent = emailSystem.ReminderMail(oReceiver, lActivityId, true);
                if (sent)
                {
                    string mssg = "Reminder sent to selected support/approver.";
                    ajaxWebExtension.showJscriptAlert(Page, this, mssg);
                }
            }
        }        
    }
}
