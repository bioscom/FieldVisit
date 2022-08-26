using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for statusReporter
/// </summary>
public static class statusReporter
{
    static statusReporter()
    {
        
    }


    public static void reportMyStatus(Label status)
    {
        if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval);
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
        {
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
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.PlannerApprover)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.PlannerApprover);
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval);
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.deleted)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.deleted);
        }
    }

    public static void reportMyStatus(LinkButton status, LinkButton Action, long iActivityId, int iApprovalId, int iUserId)
    {
        siteVisitApproval ThisApproval = siteVisitApproval.objGetFieldVisitApprovalByActivityApprovalPlanner(iApprovalId, iActivityId, iUserId);

        if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval);

            if (ThisApproval.m_iRole == (int)appUsersRoles.userRole.planner)
            {
                Action.Enabled = false;
                Action.ToolTip = "Please, you cannot action this request at the moment. The request is awaiting the Activity Sponsor's aproval before you can be enabled to action this item.";
            }
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.PlannerApprover)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.PlannerApprover);

            if (ThisApproval.m_iRole == (int)appUsersRoles.userRole.superintendent)
            {
                Action.Enabled = false;
                Action.ToolTip = "Please, you cannot action this request at the moment. The request is awaiting Planner's aproval before you can be enabled to action this item.";
            }
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval);

            Action.Enabled = true;
        }

        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
        {
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
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.NoComment)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.NoComment);
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.deleted)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.deleted);
        }
    }

    public static void reportMyStatus(LinkButton status)
    {

        if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.ActivitySponsorApproval);
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.PlannerApprover)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.PlannerApprover);
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.SuperintendentApproval);
        }

        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.Approved)
        {
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
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.NoComment)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.NoComment);
        }
        else if (int.Parse(status.Text) == (int)siteVisitApprovalStatus.apprStatusRpt.deleted)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = siteVisitApprovalStatus.StatusRptDesc(siteVisitApprovalStatus.apprStatusRpt.deleted);
        }

    }



    #region PEC Status Reporter

    public static void reportPECStatus(LinkButton status)
    {
        if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Sponsor)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Sponsor);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.FunctionalLead)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.FunctionalLead);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.AssetPlanner)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetPlanner);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.AssetOperationsManager)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetOperationsManager);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Approved)
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
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NoComment);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Deleted)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Deleted);
        }
    }


    public static void reportPECStatus(LinkButton status, LinkButton Action, long iActivityId, int iApprovalId, int iUserId, TextBox txtStatusVST, TextBox txtStatusST, TextBox txtStatusMT)
    {
        int iStatus = int.Parse(status.Attributes["STATUS"].ToString());

        PECApprover ThisApproval = PECApprover.objGetPECApprovalByApprover(iApprovalId, iActivityId, iUserId);

        if (iStatus == (int)Approval.apprStatusRpt.NoComment)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NoComment);

            if (ThisApproval.m_iRole == (int)appUsersRoles.userRole.sponsor)
            {
                //Action.Enabled = false;
                Action.ToolTip = "Please, you cannot action this request at the moment. The request is yet to be forwarded to for approval.";
            }
        }
        else if (iStatus == (int)Approval.apprStatusRpt.Sponsor)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Sponsor);

            if (ThisApproval.m_iRole != (int)appUsersRoles.userRole.sponsor)
            {
                //Action.Enabled = false;
                Action.ToolTip = "Please, you cannot action this request at the moment. The request is awaiting the Activity Sponsor's aproval before you can be enabled to action this item.";
            }
        }
        else if (iStatus == (int)Approval.apprStatusRpt.FunctionalLead)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.FunctionalLead);

            if (ThisApproval.m_iRole != (int)appUsersRoles.userRole.FunctionalLead)
            {
                //Action.Enabled = false;
                Action.ToolTip = "Please, you cannot action this request at the moment. The request is awaiting Functional's aproval before you can be enabled to action this item.";
            }
        }
        else if (iStatus == (int)Approval.apprStatusRpt.AssetPlanner)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetPlanner);

            if (ThisApproval.m_iRole != (int)appUsersRoles.userRole.planner)
            {
                //Action.Enabled = false;
                Action.ToolTip = "Please, you cannot action this request at the moment. The request is awaiting Asset Planner's aproval before you can be enabled to action this item.";
            }
        }
        else if (iStatus == (int)Approval.apprStatusRpt.AssetOperationsManager)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetOperationsManager);

            //Action.Enabled = true;
        }
        else if (iStatus == (int)Approval.apprStatusRpt.Approved)
        {
            status.ForeColor = System.Drawing.Color.Green;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Approved);
        }
        else if (iStatus == (int)Approval.apprStatusRpt.Callme)
        {
            status.ForeColor = System.Drawing.Color.Purple;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Callme);
        }
        else if (iStatus == (int)Approval.apprStatusRpt.NotApproved)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NotApproved);
        }
        else if (iStatus == (int)Approval.apprStatusRpt.Reschedule)
        {
            status.ForeColor = System.Drawing.Color.PaleGreen;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Reschedule);
        }
        else if (iStatus == (int)Approval.apprStatusRpt.NoComment)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NoComment);
        }
        else if (iStatus == (int)Approval.apprStatusRpt.Deleted)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Deleted);
        }

        IAPWindowStatus(iActivityId, txtStatusVST, txtStatusST, txtStatusMT);
    }

    public static void reportPECStatus(LinkButton status, long iActivityId, TextBox txtStatusVST, TextBox txtStatusST, TextBox txtStatusMT)
    {
        if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Sponsor)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Sponsor);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.FunctionalLead)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.FunctionalLead);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.AssetPlanner)
        {
            status.ForeColor = System.Drawing.Color.OrangeRed;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetPlanner);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.AssetOperationsManager)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.AssetOperationsManager);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Approved)
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
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NoComment);
        }
        else if (int.Parse(status.Text) == (int)Approval.apprStatusRpt.Deleted)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Deleted);
        }

        IAPWindowStatus(iActivityId, txtStatusVST, txtStatusST, txtStatusMT);
    }

    private static void IAPWindowStatus(long iActivityId, TextBox txtStatusVST, TextBox txtStatusST, TextBox txtStatusMT)
    {
        //This code is used to show the status of each PEC request in terms of IAP Window readiness.
        int iMT_IAP = 0; int iST_IAP = 0; int iVST_IAP = 0; int iMT = 0; int iST = 0; int iVST = 0;
        List<LocationFieldActivityInfo> PECS = LocationFieldActivityInfo.lstGetLocationFieldByActivityId(iActivityId);
        foreach (LocationFieldActivityInfo PEC in PECS)
        {
            if (PEC.eLocationField.m_iIAPWindowId == (int)LocationField.PEC.MT)
            {
                iMT++;
                if (PEC.m_iSTATUS == (int)commonEnums.YesNo.Yes)
                {
                    iMT_IAP++;
                }
            }

            if (PEC.eLocationField.m_iIAPWindowId == (int)LocationField.PEC.ST)
            {
                iST++;
                if (PEC.m_iSTATUS == (int)commonEnums.YesNo.Yes)
                {
                    iST_IAP++;
                }
            }

            if (PEC.eLocationField.m_iIAPWindowId == (int)LocationField.PEC.VST)
            {
                iVST++;
                if (PEC.m_iSTATUS == (int)commonEnums.YesNo.Yes)
                {
                    iVST_IAP++;
                }
            }
        }

        if ((iMT_IAP == iMT) && (iMT_IAP > 0) && (iMT > 0)) txtStatusMT.BackColor = System.Drawing.Color.Green;
        else if (iMT_IAP == (iMT * 0.5)) txtStatusMT.BackColor = System.Drawing.Color.Orange;
        else txtStatusMT.BackColor = System.Drawing.Color.Red;

        if ((iMT_IAP == iMT) && (iMT_IAP > 0) && (iMT > 0))
        {
            if ((iST_IAP == iST) && (iST_IAP > 0) && (iST > 0)) txtStatusST.BackColor = System.Drawing.Color.Green;
            else if (iST_IAP == (iST * 0.5)) txtStatusST.BackColor = System.Drawing.Color.Orange;
            else txtStatusST.BackColor = System.Drawing.Color.Red;

            if ((iST_IAP == iST) && (iST_IAP > 0) && (iST > 0))
            {
                if ((iVST == iVST_IAP) && (iVST_IAP > 0) && (iVST > 0)) txtStatusVST.BackColor = System.Drawing.Color.Green;
                else if ((iST_IAP == (iST * 0.5)) && (iMT_IAP == (iMT * 0.5)) && (iVST_IAP == (iVST * 0.5))) txtStatusVST.BackColor = System.Drawing.Color.Orange;
                else txtStatusVST.BackColor = System.Drawing.Color.Red;
            }
        }
    }

    #endregion
}