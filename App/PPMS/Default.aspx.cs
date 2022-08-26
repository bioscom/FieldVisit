using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using CS.BLL.PPMS;

public partial class App_PPMS_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var dtProjects = oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int) appUsersRoles.userRole.admin ? ActionTrackerRegisterHelper.DtGetActions() : ActionTrackerRegisterHelper.DtGetMyProjects(oSessnx.getOnlineUser.m_iUserId);

            grdGridView.DataSource = dtProjects;
            grdGridView.DataBind();

            //Encoder.HtmlEncode(

            ActionTrackerRegisterHelper.ManageReport(grdGridView);
        }
    }

    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }

    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;

        var dtProjects = oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin ? ActionTrackerRegisterHelper.DtGetActions() : ActionTrackerRegisterHelper.DtGetMyProjects(oSessnx.getOnlineUser.m_iUserId);

        grdGridView.DataSource = dtProjects;
        grdGridView.DataBind();

        ActionTrackerRegisterHelper.ManageReport(grdGridView);
    }

    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName;
        int index = Convert.ToInt32(e.CommandArgument);
        bool bRet = false;

        if (ButtonClicked == "EditThisRequest")
        {
            LinkButton lbEdit = (LinkButton)grdGridView.Rows[index].FindControl("EditLinkButton");
            var lActionId = long.Parse(lbEdit.Attributes["ACTIONID"]);

            Response.Redirect("~/App/PPMS/EditActionTrackerForm.aspx?ActionId=" + lActionId);
        }
    }

    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/PPMS/ActionTrackerForm.aspx");
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExporttoExcel();
    }

    private static void ExporttoExcel()
    {
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
        HttpContext.Current.Response.Write(@"<font style='font-size:12.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write(@"<BR><BR><BR>");

        HttpContext.Current.Response.Write(@"<Table border='1' borderColor='#eee' cellSpacing='0' cellPadding='0' style='font-size:12.0pt; font-family:Calibri; background:white;'> " +
                                            "<tr style='font-size:18.0pt'><td colspan='13'><b>Project Actions Tracker</b></td></tr>");
        HttpContext.Current.Response.Write(@"<tr" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Category</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Theme</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Asset/Function</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Action</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Importance</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Urgency</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Status</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Action Party</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Focal Point</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Date Closed Out</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Underlining Activities</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Comments</td>" +
                                           "<td style='background-color:Silver; padding: 5px;text-align: left; vertical-align: middle;font:bold'>Next Steps</td>" +
                                           "</tr>");
        var lstActions = ActionTrackerRegisterHelper.LstGetActions();
        foreach (var oAction in lstActions)
        {
            var styleImportance = "";
            var styleUrgency = "";
            var styleStatus = "";

            switch (oAction.Importance)
            {
                case (int) appEnumList.mImportance.H:
                    styleImportance =
                        "style='background-color:Red; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
                case (int) appEnumList.mImportance.M:
                    styleImportance =
                        "style='background-color:DarkOrange; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
                case (int) appEnumList.mImportance.L:
                    styleImportance =
                        "style='background-color:Cyan; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
            }


            switch (oAction.Urgency)
            {
                case (int) appEnumList.mUrgency.Ok:
                    styleUrgency =
                        "style='background-color:Green; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
                case (int) appEnumList.mUrgency.OverDue:
                    styleUrgency = "style='background-color:Red; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
                case (int) appEnumList.mUrgency.Na:
                    styleUrgency =
                        "style='background-color:White; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
            }


            switch (oAction.ProjectStatus)
            {
                case (int) appEnumList.mProjectStatus.InProgress:
                    styleStatus =
                        "style='background-color:DarkOrange; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
                case (int) appEnumList.mProjectStatus.Completed:
                    styleStatus =
                        "style='background-color:Green; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
                case (int) appEnumList.mProjectStatus.NotStated:
                    styleStatus = "style='background-color:Red; padding: 5px;text-align: left; vertical-align: middle'";
                    break;
            }

            //write in new row
            HttpContext.Current.Response.Write(@"<tr>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.Tcategory.SCategory + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.Theme.STheme + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.TfunctionAsset.SAsset + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.sAction + "</td>");
            HttpContext.Current.Response.Write(@"<td " + styleImportance + ">" + appEnumList.ImportanceDesc((appEnumList.mImportance) oAction.Importance) + "</td>");
            HttpContext.Current.Response.Write(@"<td " + styleUrgency + ">" + appEnumList.UrgencyDesc((appEnumList.mUrgency) oAction.Urgency) + "</td>");
            HttpContext.Current.Response.Write(@"<td " + styleStatus + ">" + appEnumList.ProjectStatusDesc((appEnumList.mProjectStatus) oAction.ProjectStatus) + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.ActionParty + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.FocalPoint + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.DateClosedOut + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.Activities + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.Comments + "</td>");
            HttpContext.Current.Response.Write(@"<td>" + oAction.NextSteps + "</td>");
            HttpContext.Current.Response.Write(@"</tr>");
        }

        HttpContext.Current.Response.Write(@"</table>");

        HttpContext.Current.Response.Write(@"</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
}