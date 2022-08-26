using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contract_Setup_viewPriorities : aspnetPage
{
    PriorityHelper oPriorityHelper = new PriorityHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdContract);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        string sRet = "";
        if (!IsPostBack)
        {
            if (Request.QueryString["Msg"] != null)
            {
                sRet = Request.QueryString["Msg"].ToString();
                if (sRet == "xTrue")
                {
                    LblTaskRetMsg.Text = "New Corporate Priority was successfully added.";
                }
                else if (sRet == "xFalse")
                {
                    LblTaskRetMsg.Text = "Corporate Priority was not added, please try again later.";
                }
                else if (sRet == "xMsgExt")
                {
                    LblTaskRetMsg.Text = "Corporate Priority already exists.";
                }
            }

            //Master.pageTasks = "View Asset Type Listing"
            try
            {
                GdVRepot.DataSource = getDynamicGridDataset();
                GdVRepot.DataBind();
            }
            catch (Exception ex)
            {
                sRet = "SerErr";
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
        if (sRet != "")
        {
            Server.Transfer("~/taskPage.aspx?Msg=" + sRet);
        }
    }

    private DataView getDynamicGridDataset()
    {
        DataView oView = new DataView();

        try
        {
            LblRecCount.Text = "No Corporate Priority is Listed";
            DataTable oTable = oPriorityHelper.dtGetPriorities();
            oView = new DataView(oTable);
            LblRecCount.Text = oView.Count + " Corporate Priority(ies) are Listed";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return oView;
    }

    protected void GdVRepot_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GdVRepot_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdVRepot.PageIndex = e.NewPageIndex;
            GdVRepot.DataSource = oPriorityHelper.dtGetPriorities();
            GdVRepot.DataBind();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void GdVRepot_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        // Cancel edit mode
        GdVRepot.EditIndex = -1;
        // Set status message
        //statusLabel.Text = "Editing canceled";
        // Reload the grid
        GdVRepot.DataSource = getDynamicGridDataset();
        GdVRepot.DataBind();
    }
    protected void GdVRepot_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GdVRepot.EditIndex = e.NewEditIndex;

        // Set status message
        //statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GdVRepot.DataSource = getDynamicGridDataset();
        GdVRepot.DataBind();
    }
    protected void GdVRepot_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        int iCorpPriorityId = int.Parse(GdVRepot.DataKeys[e.RowIndex].Value.ToString());
        string corpPriority = ((TextBox)GdVRepot.Rows[e.RowIndex].FindControl("corpPriorityTextBox")).Text;
        int iOrder = int.Parse(((TextBox)GdVRepot.Rows[e.RowIndex].FindControl("txtOrder")).Text);

        // Execute the update command
        bool success = oPriorityHelper.updatePriority(corpPriority, iOrder, iCorpPriorityId);
        // Cancel edit mode
        GdVRepot.EditIndex = -1;
        // Display status message
        //statusLabel.Text = success ? "Update successful" : "Update failed";
        // Reload the grid

        GdVRepot.DataSource = getDynamicGridDataset();
        GdVRepot.DataBind();
    }
    protected void closeBtn_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Default.aspx");
    }
}