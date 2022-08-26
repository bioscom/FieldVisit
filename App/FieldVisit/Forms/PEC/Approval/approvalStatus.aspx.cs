using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Forms_PEC_Approval_approvalStatus : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ActivityId"] != null)
            {
                if (Int64.Parse(Request.QueryString["ActivityId"].ToString()) != 0)
                {
                    long lActivityId = long.Parse(Request.QueryString["ActivityId"].ToString());
                    PecRequestInfo1.Init_Page(lActivityId);

                    DataTable dt = PECApprover.dtPECApproverByActivity(lActivityId);

                    grdView.DataSource = dt;
                    grdView.DataBind();

                    foreach (GridViewRow grdRow in grdView.Rows)
                    {
                        Label status = (Label)grdRow.FindControl("labelStand");
                        Label role = (Label)grdRow.FindControl("labelRole");

                        if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Approved)
                        {
                            status.ForeColor = System.Drawing.Color.Green;
                            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Approved);
                        }
                        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Callme)
                        {
                            status.ForeColor = System.Drawing.Color.Purple;
                            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Callme);
                        }
                        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.NotApproved)
                        {
                            status.ForeColor = System.Drawing.Color.Red;
                            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NotApproved);
                        }
                        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Reschedule)
                        {
                            status.ForeColor = System.Drawing.Color.PaleGreen;
                            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Reschedule);
                        }
                        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.NoComment)
                        {
                            status.ForeColor = System.Drawing.Color.Red;
                            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NoComment);
                        }

                        if (int.Parse(role.Text) == (int)appUsersRoles.userRole.sponsor)
                        {
                            role.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
                        }
                        else if (int.Parse(role.Text) == (int)appUsersRoles.userRole.FunctionalLead)
                        {
                            role.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
                        }
                        else if (int.Parse(role.Text) == (int)appUsersRoles.userRole.planner)
                        {
                            role.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.planner);
                        }
                        else if (int.Parse(role.Text) == (int)appUsersRoles.userRole.AssetOperationsManager)
                        {
                            role.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
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

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        //int superintendentId = int.Parse(viwMembers.Attributes["USERID"].ToString());
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {

    }
}