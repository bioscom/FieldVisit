using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for RequestStatusReporter
/// </summary>

public class BIRequestStatus
{
    public BIRequestStatus()
    {

    }

    public static void RequestStatus(appUsers OnlineUser, GridView oGridView, DataTable dtRequest, string sortExpression)
    {
        appUsersHelper oAppUserMgt = new appUsersHelper();

        DataTable dt = dtRequest;
        DataView dv = dt.DefaultView;
        dv.Sort = sortExpression;

        try
        {
            oGridView.DataSource = dv;
            oGridView.DataBind();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public static void supportProcess(int iStatus, Label Status)
    {
        if (iStatus == (int)RequestStatusRpt.AwaitsProjectChampionSupport) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsProjectChampionSupport);
        else if (iStatus == (int)RequestStatusRpt.AwaitsProjectSponsorApproval) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsProjectSponsorApproval);
        else if (iStatus == (int)RequestStatusRpt.Approved) Status.Text = RequestStatusRptDesc(RequestStatusRpt.Approved);
        else if (iStatus == (int)RequestStatusRpt.NotApproved) Status.Text = RequestStatusRptDesc(RequestStatusRpt.NotApproved);
        else if (iStatus == (int)RequestStatusRpt.Supported) Status.Text = RequestStatusRptDesc(RequestStatusRpt.Supported);
        else if (iStatus == (int)RequestStatusRpt.NotSupported) Status.Text = RequestStatusRptDesc(RequestStatusRpt.NotSupported);
        else if (iStatus == (int)RequestStatusRpt.AwaitsBusinessImprovementSupport) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsBusinessImprovementSupport);
        else if (iStatus == (int)RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval);
        else if (iStatus == (int)RequestStatusRpt.AwaitsFocalPointAction) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsFocalPointAction);
        else if (iStatus == (int)RequestStatusRpt.InitiativeLead) Status.Text = RequestStatusRptDesc(RequestStatusRpt.InitiativeLead);
    }

    public enum RequestStatusRpt
    {
        iDefault = 0,
        AwaitsBusinessImprovementOrProjectChampionApproval = 1,
        AwaitsBusinessImprovementSupport = 2,
        AwaitsProjectChampionSupport = 3,
        AwaitsProjectSponsorApproval = 4,
        AwaitsFocalPointAction = 5,
        Approved = 6,
        NotApproved = 7,
        Supported = 8,
        NotSupported = 9,
        Cancelled = 10,
        MaintainInDatabase = 11,
        InitiativeLead = 12,
    };

    public enum RequestType
    {
        BI = 1,
        CR = 2,
    };

    public enum StageGates
    {
        StageGate1 = 1,
        StageGate2 = 2,
        StageGate3 = 3,
        StageGate4 = 4,
        StageGate5 = 5,
    };

    public static string StageGateDesc(StageGates o)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (o)
            {
                case StageGates.StageGate1: sRet = "L1"; break;
                case StageGates.StageGate2: sRet = "L2"; break;
                case StageGates.StageGate3: sRet = "L3"; break;
                case StageGates.StageGate4: sRet = "L4"; break;
                case StageGates.StageGate5: sRet = "L5"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public static string RequestStatusRptDesc(RequestStatusRpt rqstStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (rqstStatus)
            {
                case RequestStatusRpt.iDefault: sRet = "Saved as Draft/or Review Ongoing..."; break;
                case RequestStatusRpt.AwaitsProjectChampionSupport: sRet = "Pending Work Stream Owner"; break;
                case RequestStatusRpt.AwaitsProjectSponsorApproval: sRet = "Pending Work Stream Sponsor"; break;
                case RequestStatusRpt.AwaitsFocalPointAction: sRet = "Pending Focal Point's Action"; break;
                case RequestStatusRpt.Approved: sRet = "Approved"; break;
                case RequestStatusRpt.NotApproved: sRet = "Not Approved"; break;
                case RequestStatusRpt.Supported: sRet = "Supported"; break;
                case RequestStatusRpt.NotSupported: sRet = "Not Supported"; break;
                case RequestStatusRpt.Cancelled: sRet = "Cancelled"; break;
                case RequestStatusRpt.AwaitsBusinessImprovementSupport: sRet = "Awaits Business Improvement Team Support"; break;
                case RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval: sRet = "Awaits BI/Lean Team and/Or Project Champion Support"; break;
                case RequestStatusRpt.MaintainInDatabase: sRet = "Maintain In Database"; break;
                case RequestStatusRpt.InitiativeLead: sRet = "Initiative Lead actions ongoing..."; break;                    
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public enum RequestPhasing
    {
        iDefault = 0,
        Identify = 1,
        Eliminate = 2,
        Sustain = 3,
        HandOver = 4,
    };

    public static string RequestPhasingDesc(RequestPhasing rqstPhasing)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (rqstPhasing)
            {
                case RequestPhasing.iDefault: sRet = "Pending Phasing"; break;
                case RequestPhasing.Identify: sRet = "Identify"; break;
                case RequestPhasing.Eliminate: sRet = "Eliminate"; break;
                case RequestPhasing.Sustain: sRet = "Sustain"; break;
                case RequestPhasing.HandOver: sRet = "Hand Over"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public static void reportMyStatus(Label status)
    {
        try
        {
            if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsProjectChampionSupport)
            {
                status.ForeColor = System.Drawing.Color.Navy;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.AwaitsProjectChampionSupport);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsProjectSponsorApproval)
            {
                status.ForeColor = System.Drawing.Color.Brown;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.AwaitsProjectSponsorApproval);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsFocalPointAction)
            {
                status.ForeColor = System.Drawing.Color.Purple;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.AwaitsFocalPointAction);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.Approved)
            {
                status.ForeColor = System.Drawing.Color.Green;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.Approved);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotApproved)
            {
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.NotApproved);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.Supported)
            {
                status.ForeColor = System.Drawing.Color.Green;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.Supported);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotSupported)
            {
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.NotSupported);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.iDefault)
            {
                status.ForeColor = System.Drawing.Color.Blue;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.iDefault);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.Cancelled)
            {
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.Cancelled);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsBusinessImprovementSupport)
            {
                status.ForeColor = System.Drawing.Color.Purple;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.AwaitsBusinessImprovementSupport);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval)
            {
                status.ForeColor = System.Drawing.Color.Purple;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.MaintainInDatabase)
            {
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.MaintainInDatabase);
            }
            else if (int.Parse(status.Text) == (int)RequestStatusRpt.InitiativeLead)
            {
                status.ForeColor = System.Drawing.Color.Brown;
                status.Text = RequestStatusRptDesc((RequestStatusRpt)(int)RequestStatusRpt.InitiativeLead);
            }
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public static void reportBrightIdeaPhase(LinkButton lnkPhase)
    {
        try
        {
            if (int.Parse(lnkPhase.Text) == (int)RequestPhasing.Eliminate)
            {
                lnkPhase.ForeColor = System.Drawing.Color.Navy;
                lnkPhase.Text = RequestPhasingDesc(RequestPhasing.Eliminate);
            }
            else if (int.Parse(lnkPhase.Text) == (int)RequestPhasing.Identify)
            {
                lnkPhase.ForeColor = System.Drawing.Color.Brown;
                lnkPhase.Text = RequestPhasingDesc(RequestPhasing.Identify);
            }
            else if (int.Parse(lnkPhase.Text) == (int)RequestPhasing.Sustain)
            {
                lnkPhase.ForeColor = System.Drawing.Color.Purple;
                lnkPhase.Text = RequestPhasingDesc(RequestPhasing.Sustain);
            }
            else if (int.Parse(lnkPhase.Text) == (int)RequestPhasing.HandOver)
            {
                lnkPhase.ForeColor = System.Drawing.Color.Green;
                lnkPhase.Text = RequestPhasingDesc(RequestPhasing.HandOver);
            }
            else if (int.Parse(lnkPhase.Text) == (int)RequestPhasing.iDefault)
            {
                lnkPhase.ForeColor = System.Drawing.Color.Red;
                lnkPhase.Text = RequestPhasingDesc(RequestPhasing.iDefault);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}