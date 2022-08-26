using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Approval
/// </summary>

public class Approval
{
    public Approval()
    {

    }

    public enum apprStatusRpt
    {
        Deleted = 0,
        NewInitiative = -2,
        //Deleted = 20,
        NoComment = -1,
        Approved = 1,
        NotApproved = 2,
        Callme = 3,
        Reschedule = 4,

        Sponsor = 5,
        FunctionalLead = 6,
        AssetOperationsManager = 7,
        AssetPlanner = 8,

    };

    public static string StatusRptDesc(apprStatusRpt apprStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (apprStatus)
            {
                case apprStatusRpt.Approved: sRet = "Approved"; break;
                case apprStatusRpt.NotApproved: sRet = "Not Approved"; break;
                case apprStatusRpt.Callme: sRet = "Call me"; break;
                case apprStatusRpt.Reschedule: sRet = "Reschedule"; break;
                case apprStatusRpt.Deleted: sRet = ""; break;
                case apprStatusRpt.NewInitiative: sRet = "Create New Initiative"; break;

                case apprStatusRpt.Sponsor: sRet = "Awaiting Activity Sponsor's approval."; break;
                case apprStatusRpt.FunctionalLead: sRet = "Awaiting Functional Lead's approval."; break;
                case apprStatusRpt.AssetOperationsManager: sRet = "Awaiting Asset/Operations Manager's approval."; break;
                case apprStatusRpt.AssetPlanner: sRet = "Awaiting Asset Planner's approval."; break;

                case apprStatusRpt.NoComment: sRet = "Pending action"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}
