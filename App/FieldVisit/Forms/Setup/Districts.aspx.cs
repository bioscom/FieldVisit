using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Setup_Districts : aspnetPage
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
            //Load Superintendents

            List<Superintendent> superintendents = Superintendent.lstGetSuperintendent();
            foreach (Superintendent _superintendents in superintendents)
            {
                drpSuperintendents.Items.Add(new ListItem(_superintendents.m_sSuperintendent, _superintendents.m_iSuperintendentId.ToString()));
            }

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
            idDistrictHF.Value = lbEdit.Attributes["ID_DISTRICT"].ToString();

            if ((idDistrictHF.Value != null) || (idDistrictHF.Value != ""))
            {
                District myDistrict = District.objGetDistrictById(int.Parse(idDistrictHF.Value));
                districtTextBox.Text = myDistrict.m_sDistrict;
                drpSuperintendents.SelectedValue = myDistrict.m_iSuperintendentId.ToString();
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idDistrictHF.Value == null) || (idDistrictHF.Value == ""))
        {
            bool bRet = District.createDistrict(int.Parse(drpSuperintendents.SelectedValue), districtTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string message = districtTextBox.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = District.updateDistrict(int.Parse(drpSuperintendents.SelectedValue), int.Parse(idDistrictHF.Value), districtTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = districtTextBox.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = District.dtGetDistrictDetails();
        grdView.DataBind();
    }
    private void Clear()
    {
        drpSuperintendents.ClearSelection();
        districtTextBox.Text = "";
        idDistrictHF.Value = "";
    }
    protected void drpSuperintendents_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpSuperintendents.SelectedValue == "0")
        {
            loadData();
        }
        else if (drpSuperintendents.SelectedValue != "-1")
        {
            grdView.DataSource = District.dtGetDistrictDetailsById(int.Parse(drpSuperintendents.SelectedValue));
            grdView.DataBind();
        }
    }
}
