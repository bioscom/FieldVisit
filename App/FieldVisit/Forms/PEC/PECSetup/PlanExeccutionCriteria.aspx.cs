using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_SetupSepcin_PlanExeccutionCriteria : aspnetPage
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
            //Load Plan Execution Criteria
            addIapWindowToDropDown(LocationField.PEC.MT);
            addIapWindowToDropDown(LocationField.PEC.ST);
            addIapWindowToDropDown(LocationField.PEC.VST);

            //List<iapWindows> Windows = iapWindows.lstGetIAPWindows();
            //foreach (iapWindows xWindows in Windows)
            //{
            //    drpWindow.Items.Add(new ListItem(xWindows.m_sWindow, xWindows.m_iIDWindow.ToString()));
            //}

            loadData();
        }
    }

    private void addIapWindowToDropDown(LocationField.PEC eIapWindow)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = LocationField.PECDesc(eIapWindow);
            oItem.Value = ((int)eIapWindow).ToString();
            drpWindow.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
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
            idPECHF.Value = lbEdit.Attributes["ID_FIELD_LOC"].ToString();

            if ((idPECHF.Value != null) || (idPECHF.Value != ""))
            {
                LocationField pec = LocationField.objGetLocationFieldById(int.Parse(idPECHF.Value));
                txtPEC.Text = pec.sFIELD_LOCATION;
                drpWindow.SelectedValue = pec.m_iIAPWindowId.ToString();
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idPECHF.Value == null) || (idPECHF.Value == ""))
        {
            bool bRet = LocationField.createLocationField(txtPEC.Text, int.Parse(drpWindow.SelectedValue));
            if (bRet == true)
            {
                loadData();

                string message = txtPEC.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = LocationField.updateLocationField(int.Parse(idPECHF.Value), txtPEC.Text, (int.Parse(drpWindow.SelectedValue)));
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtPEC.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = LocationField.dtGetLocationField();
        grdView.DataBind();

        x();
    }

    void x()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblWindow = (Label)grdRow.FindControl("labelWindow");
            LinkButton lbEdit = (LinkButton)grdRow.FindControl("editLinkButton");

            int iWindow = ((lbEdit.Attributes["ID_WINDOW"].ToString() != "") ? int.Parse(lbEdit.Attributes["ID_WINDOW"].ToString()) : 0);

            if (iWindow == (int)LocationField.PEC.MT)
            {
                lblWindow.Text = LocationField.PECDesc(LocationField.PEC.MT);
            }
            else if (iWindow == (int)LocationField.PEC.ST)
            {
                lblWindow.Text = LocationField.PECDesc(LocationField.PEC.ST);
            }
            else if (iWindow == (int)LocationField.PEC.VST)
            {
                lblWindow.Text = LocationField.PECDesc(LocationField.PEC.VST);
            }
        }
    }

    private void Clear()
    {
        drpWindow.ClearSelection();
        txtPEC.Text = "";
        idPECHF.Value = "";
    }
    protected void drpSuperintendents_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpWindow.SelectedValue == "0")
        {
            loadData();
        }
        else if (drpWindow.SelectedValue != "-1")
        {
            grdView.DataSource = LocationField.dtGetLocationFieldByWindowId(int.Parse(drpWindow.SelectedValue));
            grdView.DataBind();
            x();
        }
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}