using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public class RequestStatusReporter
{
    public RequestStatusReporter()
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
        if (iStatus == (int)RequestStatusRpt.AwaitLineManagerSupport) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitLineManagerSupport);
        else if (iStatus == (int)RequestStatusRpt.AssuranceReviewSupport) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AssuranceReviewSupport);
        else if (iStatus == (int)RequestStatusRpt.AwaitsGMProductionApproval) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMProductionApproval);
        else if (iStatus == (int)RequestStatusRpt.AwaitsGMDeepWaterApproval) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMDeepWaterApproval);
        else if (iStatus == (int)RequestStatusRpt.AwaitsGMOffshoreSupport) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMOffshoreSupport);
        else if (iStatus == (int)RequestStatusRpt.AwaitsGMOnshoreSupport) Status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMOnshoreSupport);
        else if (iStatus == (int)RequestStatusRpt.Approved) Status.Text = RequestStatusRptDesc(RequestStatusRpt.Approved);
        else if (iStatus == (int)RequestStatusRpt.NotApproved) Status.Text = RequestStatusRptDesc(RequestStatusRpt.NotApproved);
        else if (iStatus == (int)RequestStatusRpt.Supported) Status.Text = RequestStatusRptDesc(RequestStatusRpt.Supported);
        else if (iStatus == (int)RequestStatusRpt.NotSupported) Status.Text = RequestStatusRptDesc(RequestStatusRpt.NotSupported);
    }

    public enum RequestStatusRpt
    {
        iDefault = 0,
        AwaitLineManagerSupport = 1,
        AssuranceReviewSupport = 2,
        AwaitsGMProductionApproval = 3,
        Approved = 4,
        NotApproved = 5,
        Supported = 6,
        NotSupported = 7,
        Cancelled = 8,
        AwaitsGMOffshoreSupport = 9,
        AwaitsGMOnshoreSupport = 10,
        NotSupportedByLineManager = 11,
        NotSupportedByGMOffShore = 12,
        NotSupportedByGMOnShore = 13,
        NotSupportedByProductionServiceManager = 14,
        NotApprovedByGMProduction = 15,
        AwaitsGMDeepWaterApproval = 16,
        NotApprovedByGMDeepWater = 17,
        AwaitsFinalApproval = 18,
    };

    public static string RequestStatusRptDesc(RequestStatusRpt rqstStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (rqstStatus)
            {
                case RequestStatusRpt.iDefault: sRet = "Awaiting Review"; break;
                case RequestStatusRpt.AwaitLineManagerSupport: sRet = "Pending Line Manager's Support"; break;
                case RequestStatusRpt.AssuranceReviewSupport: sRet = "Assurance Review/Support ongoing..."; break;
                case RequestStatusRpt.AwaitsGMOffshoreSupport: sRet = "Pending GM Offshore's Support"; break;
                case RequestStatusRpt.AwaitsGMOnshoreSupport: sRet = "Pending GM Onshore's Support"; break;
                case RequestStatusRpt.AwaitsGMProductionApproval: sRet = "To be approved by GM Production"; break;
                case RequestStatusRpt.AwaitsGMDeepWaterApproval: sRet = "To be approved by GM Deep Water"; break;
                case RequestStatusRpt.AwaitsFinalApproval: sRet = "Awaits Final Approval"; break;
                case RequestStatusRpt.Approved: sRet = "Approved"; break;
                case RequestStatusRpt.NotApproved: sRet = "Not Approved"; break;
                case RequestStatusRpt.Supported: sRet = "Supported"; break;
                case RequestStatusRpt.NotSupported: sRet = "Not Supported"; break;
                case RequestStatusRpt.Cancelled: sRet = "Cancelled"; break;

                case RequestStatusRpt.NotSupportedByLineManager: sRet = "Not Supported By Line Manager"; break;
                case RequestStatusRpt.NotSupportedByProductionServiceManager: sRet = "Not Supported By Production Service Manager"; break;
                case RequestStatusRpt.NotSupportedByGMOffShore: sRet = "Not Supported By GM Offshore"; break;
                case RequestStatusRpt.NotSupportedByGMOnShore: sRet = "Not Supported By GM Onshore"; break;
                case RequestStatusRpt.NotApprovedByGMProduction: sRet = "Not Approved By GM Production"; break;
                case RequestStatusRpt.NotApprovedByGMDeepWater: sRet = "Not Approved By GM DeepWater"; break;
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
        if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitLineManagerSupport)
        {
            status.ForeColor = System.Drawing.Color.Navy;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitLineManagerSupport);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsGMOffshoreSupport)
        {
            status.ForeColor = System.Drawing.Color.Beige;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMOffshoreSupport);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsGMOnshoreSupport)
        {
            status.ForeColor = System.Drawing.Color.Chocolate;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMOnshoreSupport);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.AssuranceReviewSupport)
        {
            status.ForeColor = System.Drawing.Color.Brown;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.AssuranceReviewSupport);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsGMProductionApproval)
        {
            status.ForeColor = System.Drawing.Color.Purple;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMProductionApproval);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.AwaitsGMDeepWaterApproval)
        {
            status.ForeColor = System.Drawing.Color.Chocolate;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMDeepWaterApproval);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotApprovedByGMDeepWater)
        {
            status.ForeColor = System.Drawing.Color.Chocolate;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotApprovedByGMDeepWater);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.Approved)
        {
            status.ForeColor = System.Drawing.Color.Green;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.Approved);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotApproved)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotApproved);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.Supported)
        {
            status.ForeColor = System.Drawing.Color.Green;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.Supported);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotSupported)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotSupported);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.iDefault)
        {
            status.ForeColor = System.Drawing.Color.Blue;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.iDefault);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.Cancelled)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.Cancelled);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotSupportedByGMOffShore)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByGMOffShore);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotSupportedByGMOnShore)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByGMOnShore);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotApprovedByGMProduction)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotApprovedByGMProduction);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotApprovedByGMDeepWater)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotApprovedByGMDeepWater);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotSupportedByLineManager)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByLineManager);
        }
        else if (int.Parse(status.Text) == (int)RequestStatusRpt.NotSupportedByProductionServiceManager)
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByProductionServiceManager);
        }
    }

    public static void reportMyStatus(GridDataItem item, int iColumn)
    {
        if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.AwaitLineManagerSupport).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Navy;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.AwaitLineManagerSupport);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.AwaitsGMOffshoreSupport).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Beige;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMOffshoreSupport);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.AwaitsGMOnshoreSupport).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Chocolate;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMOnshoreSupport);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.AssuranceReviewSupport).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Brown;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.AssuranceReviewSupport);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.AwaitsGMProductionApproval).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Purple;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMProductionApproval);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.AwaitsFinalApproval).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Green;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsFinalApproval);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.AwaitsGMDeepWaterApproval).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Chocolate;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.AwaitsGMDeepWaterApproval);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotApprovedByGMDeepWater).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Chocolate;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotApprovedByGMDeepWater);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.Approved).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Green;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.Approved);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotApproved).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotApproved);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.Supported).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Green;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.Supported);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotSupported).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotSupported);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.iDefault).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Blue;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.iDefault);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.Cancelled).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.Cancelled);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotSupportedByGMOffShore).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByGMOffShore);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotSupportedByGMOnShore).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByGMOnShore);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotApprovedByGMProduction).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotApprovedByGMProduction);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotApprovedByGMDeepWater).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotApprovedByGMDeepWater);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotSupportedByLineManager).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByLineManager);
        }
        else if (item.Cells[iColumn].Text == ((int)RequestStatusRpt.NotSupportedByProductionServiceManager).ToString())
        {
            item.Cells[iColumn].ForeColor = System.Drawing.Color.Red;
            item.Cells[iColumn].Text = RequestStatusRptDesc(RequestStatusRpt.NotSupportedByProductionServiceManager);
        }
    }
}