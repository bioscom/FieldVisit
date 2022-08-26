using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_BI500_UserControl_WeeklyReport : System.Web.UI.UserControl
{
    Reporting oRpt = new Reporting();
    BI500RequestHelper o = new BI500RequestHelper();
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Page_Init()
    {
        o.LoadYear(ddlYear);

        List<Functions> Functions = oFunctionMgt.lstGetFunctions();
        foreach (Functions Function in Functions)
        {
            ddlFunction.Items.Add(new ListItem(Function.m_sFunction, Function.m_iFunctionId.ToString()));
        }

        DataRow row;
        DataTable dt = new DataTable();
        dt.Columns.Add("NOID");

        for(int i = 1; i < 53; i++)
        {
            row = dt.NewRow();
            row["NOID"] = i.ToString();
            dt.Rows.Add(row);
        }

        WeeklyRepeater.DataSource = dt;
        WeeklyRepeater.DataBind();
    }

    protected void WeeklyRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            RepeaterItem oItem = e.Item;
            LinkButton lnkWeeklyReport = (LinkButton)oItem.FindControl("lnkWeek");

            int iWeek = int.Parse(lnkWeeklyReport.Attributes["NOID"]);

            DataTable dt = new DataTable();


            if (int.Parse(ddlDepartment.SelectedValue) != -1)
            {
                dt = oRpt.dtGetRequestsByDepartmentWeek(iWeek, int.Parse(ddlYear.SelectedValue), int.Parse(ddlDepartment.SelectedValue));
                //Graph Plotting
                GraphicalReports1.GraphicalReportByWeekDepartment(iWeek, int.Parse(ddlYear.SelectedValue), int.Parse(ddlDepartment.SelectedValue), int.Parse(ddlFunction.SelectedValue));

            }
            else if ((int.Parse(ddlDepartment.SelectedValue) != -1) && (int.Parse(ddlTeam.SelectedValue) != -1))
            {
                dt = oRpt.dtGetRequestsByTeamWeek(iWeek, int.Parse(ddlYear.SelectedValue), int.Parse(ddlTeam.SelectedValue));
            }
            else if ((int.Parse(ddlFunction.SelectedValue) != -1) && (int.Parse(ddlDepartment.SelectedValue) == -1) && (int.Parse(ddlTeam.SelectedValue) == -1))
            {
                dt = oRpt.dtGetRequestsByBusinessUnitWeek(iWeek, int.Parse(ddlYear.SelectedValue), int.Parse(ddlFunction.SelectedValue));
                //Graph Plotting
                GraphicalReports1.GraphicalReportByWeekFunction(iWeek, int.Parse(ddlYear.SelectedValue), int.Parse(ddlFunction.SelectedValue));
            }

            grdView.DataSource = dt;
            grdView.DataBind();

            GridManager();

            int iTotalYearBI = oRpt.dtGetRequestsByYear(int.Parse(ddlYear.SelectedValue)).Rows.Count;

            lblMessage.Text = ddlFunction.SelectedItem.Text + " number of Bright Ideas during week " + iWeek + " = " + dt.Rows.Count + " of (" + iTotalYearBI.ToString() + " Total number of BI)";

        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Command Button           Command Name

        //ActionLinkButton          Action
        //CancelLinkButton          CancelRequest
        //deleteLinkButton          deleteRequest
        //ViewStatusLinkButton      ViewStatus
        //EditLinkButton            EditThisRequest
        //ReportLinkButton          Report
        //RerouteLinkButton         Reroute
        //AuditTrailLinkButton      AuditTrail

        //try
        //{
        string ButtonClicked = e.CommandName;
        int index = Convert.ToInt32(e.CommandArgument);

        if (ButtonClicked == "Action")
        {
            LinkButton lbAction = (LinkButton)grdView.Rows[index].FindControl("ActionLinkButton");
            long lRequestId = long.Parse(lbAction.Attributes["IDREQUEST"].ToString());
            //long lApprovalId = long.Parse(lbAction.Attributes["IDAPPROVAL"].ToString());

            //oBI500Approval = oBI500ApprovalHelper.objBIApprovalbyApprovalId(lApprovalId);
            //oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

            Response.Redirect("~/App/BI500/BIApprovalProc.aspx?RequestId=" + lRequestId);
        }
        else if (ButtonClicked == "CancelRequest")
        {
            LinkButton lbCancel = (LinkButton)grdView.Rows[index].FindControl("CancelLinkButton");
            long lRequestId = long.Parse(lbCancel.Attributes["IDREQUEST"].ToString());

            //TODO: When a request is cancelled, move it to the cancelled folder, by updating the status to iCancel
        }
        else if (ButtonClicked == "deleteRequest")
        {
            LinkButton lbDelete = (LinkButton)grdView.Rows[index].FindControl("deleteLinkButton");
            long lRequestId = long.Parse(lbDelete.Attributes["IDREQUEST"].ToString());

            //TODO: When a request is delete, what should be done????
        }
        else if (ButtonClicked == "ViewStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("ViewStatusLinkButton");
            long lRequestId = long.Parse(lbViewStatus.Attributes["IDREQUEST"].ToString());

            Response.Redirect("~/App/BI500/ViewComments.aspx?RequestId=" + lRequestId);
        }
        else if (ButtonClicked == "Report")
        {
            LinkButton lbReport = (LinkButton)grdView.Rows[index].FindControl("ReportLinkButton");
            long lRequestId = long.Parse(lbReport.Attributes["IDREQUEST"].ToString());

            Response.Redirect("~/App/BI500/Report/MainReport.aspx?lRequestId=" + lRequestId);
        }
        else if (ButtonClicked == "Reroute")
        {
            LinkButton lbReroute = (LinkButton)grdView.Rows[index].FindControl("RerouteLinkButton");
            long lRequestId = long.Parse(lbReroute.Attributes["IDREQUEST"].ToString());

            Response.Redirect("~/FlareRequestRouter.aspx?RequestId=" + lRequestId);
            //TODO: Complete the FlareRequestRouter.aspx page
        }
    }

    protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void GridManager()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label labelStatus = (Label)grdRow.FindControl("labelStatus");
            BIRequestStatus.reportMyStatus(labelStatus);
        }
    }

    protected void ddlFunction_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDepartment.Items.Clear();
        ddlDepartment.Items.Add(new ListItem("Select Department", "-1"));
        List<BIDepartments> oDepts = BIDepartments.lstGetDeparmentsByFunction(int.Parse(ddlFunction.SelectedValue));
        foreach (BIDepartments o in oDepts)
        {
            ddlDepartment.Items.Add(new ListItem(o.m_sDepartment, o.m_iDepartmentId.ToString()));
        }
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTeam.Items.Clear();
        ddlTeam.Items.Add(new ListItem("Select Team", "-1"));
        List<BITeams> oTeams = BITeams.lstGetTeamsByDepartment(int.Parse(ddlDepartment.SelectedValue));
        foreach (BITeams o in oTeams)
        {
            ddlTeam.Items.Add(new ListItem(o.m_sTeam, o.m_iTeamId.ToString()));
        }
    }
}