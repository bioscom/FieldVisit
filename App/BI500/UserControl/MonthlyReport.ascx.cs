using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_BI500_UserControl_MonthlyReport : System.Web.UI.UserControl
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
        dt.Columns.Add("ID");
        dt.Columns.Add("MMONTH");

        for (int i = 1; i <= 12; i++)
        {
            row = dt.NewRow();
            row["ID"] = i.ToString();
            if (i == 1) row["MMONTH"] = "January";
            else if (i == 2) row["MMONTH"] = "February";
            else if (i == 3) row["MMONTH"] = "March";
            else if (i == 4) row["MMONTH"] = "April";
            else if (i == 5) row["MMONTH"] = "May";
            else if (i == 6) row["MMONTH"] = "June";
            else if (i == 7) row["MMONTH"] = "July";
            else if (i == 8) row["MMONTH"] = "August";
            else if (i == 9) row["MMONTH"] = "September";
            else if (i == 10) row["MMONTH"] = "October";
            else if (i == 11) row["MMONTH"] = "November";
            else if (i == 12) row["MMONTH"] = "December";
            dt.Rows.Add(row);
        }

        MonthlyRepeater.DataSource = dt;
        MonthlyRepeater.DataBind();
    }

    protected void MonthlyRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            RepeaterItem oItem = e.Item;
            LinkButton lnkMonthlyReport = (LinkButton)oItem.FindControl("lnkMonth");

            int iMonth = int.Parse(lnkMonthlyReport.Attributes["IMONTH"]);
            HF.Value = iMonth.ToString();
            string sMonth = lnkMonthlyReport.Attributes["MMONTH"];

            DataTable dt = new DataTable();

            if (int.Parse(ddlDepartment.SelectedValue) != -1)
            {
                dt = oRpt.dtGetRequestsByDepartmentMonth(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlDepartment.SelectedValue));
                //Graph Plotting
                GraphicalReports1.GraphicalReportByMonthDepartment(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlDepartment.SelectedValue), int.Parse(ddlFunction.SelectedValue));
            }
            else if ((int.Parse(ddlDepartment.SelectedValue) != -1) && (int.Parse(ddlTeam.SelectedValue) != -1))
            {
                dt = oRpt.dtGetRequestsByTeamMonth(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlTeam.SelectedValue));
            }
            else if ((int.Parse(ddlFunction.SelectedValue) != -1) && (int.Parse(ddlDepartment.SelectedValue) == -1) && (int.Parse(ddlTeam.SelectedValue) == -1))
            {
                dt = oRpt.dtGetRequestsByBusinessUnitMonth(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlFunction.SelectedValue));
                //Graph Plotting
                GraphicalReports1.GraphicalReportByMonthFunction(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlFunction.SelectedValue));
            }

            grdView.DataSource = dt;
            grdView.DataBind();

            GridManager();

            int iTotalYearBI = oRpt.dtGetRequestsByYear(int.Parse(ddlYear.SelectedValue)).Rows.Count;

            lblMessage.Text = ddlFunction.SelectedItem.Text + " number of Bright Ideas in " + sMonth + " = " + dt.Rows.Count + " of (" + iTotalYearBI.ToString() + " Total number of BI)";

        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;

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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(HF.Value))
            {
                int iMonth = int.Parse(HF.Value);
                List<CostReductionRequest> lstBI500Request = new List<CostReductionRequest>();

                if (int.Parse(ddlDepartment.SelectedValue) != -1)
                {
                    lstBI500Request = oRpt.lstGetRequestsByDepartmentMonth(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlDepartment.SelectedValue));
                }
                if (int.Parse(ddlTeam.SelectedValue) != -1)
                {
                    lstBI500Request = oRpt.lstGetRequestsByTeamMonth(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlTeam.SelectedValue));
                }
                else
                {
                    lstBI500Request = oRpt.lstGetRequestsByBusinessUnitMonth(iMonth, int.Parse(ddlYear.SelectedValue), int.Parse(ddlFunction.SelectedValue));
                }

                ExporttoExcel(lstBI500Request);
            }
            else
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Please select the month report you desire to export.");
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }

    private void ExporttoExcel(List<CostReductionRequest> lstOpportunityCosts)
    {
        appUsersHelper oUsers = new appUsersHelper();

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:12.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
          "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
          "style='font-size:12.0pt; font-family:Calibri; background:white;'> <TR>");

        //Get column headers  and make it as bold in excel columns

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("S/No");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Request No");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Date Request");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Title");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Business Unit");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Department");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Team");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Initiator");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Project Champion");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Project Sponsor");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Team Focal Point");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Impacted Area");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Plan Completion Date");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("<Td>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Status");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");

        HttpContext.Current.Response.Write("</TR>");

        int i = 1;

        foreach (CostReductionRequest o in lstOpportunityCosts)
        {
            HttpContext.Current.Response.Write("<TR>");
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(i++);
            HttpContext.Current.Response.Write("</Td>");

            //HttpContext.Current.Response.Write("<TR>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(o.sRequestNumber);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(o.dDateSubmitted);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(o.sTitle);
            HttpContext.Current.Response.Write("</Td>");

            FunctionMgt oFun = new FunctionMgt();

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oFun.objGetFunctionById(o.iFunctionId).m_sFunction);
            HttpContext.Current.Response.Write("</Td>");

            BIDepartments oD = new BIDepartments();
            
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oD.objGetDepartmentById(o.iDeptId).m_sDepartment);
            HttpContext.Current.Response.Write("</Td>");

            BITeams oT = new BITeams();

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oT.objGetTeamById(o.iTeamId).m_sTeam);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(o.iUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(o.iProjectChampionUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(o.iProjectSponsorUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oUsers.objGetUserByUserID(o.iFocalPointUserId).m_sFullName);
            HttpContext.Current.Response.Write("</Td>");

            BenefitsMgt oBen = new BenefitsMgt();
            

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(oBen.objGetBenefitById(o.iBenefitId).m_sBenefit);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(o.dCompletionDate);
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("<Td>");

            Label status = new Label();
            status.Text = o.iStatus.ToString();
            BIRequestStatus.reportMyStatus(status);

            HttpContext.Current.Response.Write(status.Text);
            HttpContext.Current.Response.Write("</Td>");
            
            HttpContext.Current.Response.Write("</TR>");
        }

        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
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