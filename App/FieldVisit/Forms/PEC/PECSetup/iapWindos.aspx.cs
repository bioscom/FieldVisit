using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_SetupSepcin_iapWindos : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFieldVisit);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            loadData();
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        loadData();
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "editThis")
        {
            LinkButton lbEdit = (LinkButton)grdView.Rows[index].FindControl("editLinkButton");
            idIAPWindowHF.Value = lbEdit.Attributes["ID_WINDOW"].ToString();

            if ((idIAPWindowHF.Value != null) || (idIAPWindowHF.Value != ""))
            {
                iapWindows oWindow = iapWindows.objGetIAPWindowById(int.Parse(idIAPWindowHF.Value));
                txtIAPWindow.Text = oWindow.m_sWindow;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        iapWindows me = new iapWindows();
        me.m_sWindow = txtIAPWindow.Text;

        if ((idIAPWindowHF.Value == null) || (idIAPWindowHF.Value == ""))
        {
            bool bRet = iapWindows.createWindow(me);
            if (bRet == true)
            {
                loadData();

                string message = txtIAPWindow.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            me.m_iIDWindow = int.Parse(idIAPWindowHF.Value);
            bool bRet = iapWindows.UpdateIAPWindow(me);
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtIAPWindow.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = iapWindows.dtGetIAPWindows();
        grdView.DataBind();
    }

    private void Clear()
    {
        txtIAPWindow.Text = "";
        idIAPWindowHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}