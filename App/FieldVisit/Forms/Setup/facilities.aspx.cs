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

public partial class Setup_facilities : aspnetPage
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
            idFacilityHF.Value = lbEdit.Attributes["ID_FACILITIES"].ToString();

            if ((idFacilityHF.Value != null) || (idFacilityHF.Value != ""))
            {
                facility myFacility = facility.objGetFacilityById(int.Parse(idFacilityHF.Value));

                drpSuperintendents.SelectedValue = myFacility.eSuperintendent.m_iSuperintendentId.ToString();

                //Load District
                loadDistrict();

                drpDistrict.SelectedValue = myFacility.m_iDistrictId.ToString();
                facilitiesTextBox.Text = myFacility.m_sFacility;
            }
        }
    }

    protected void drpSuperintendents_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Load District
        loadDistrict();
    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idFacilityHF.Value == null) || (idFacilityHF.Value == ""))
        {
            bool bRet = facility.createFacility(int.Parse(drpDistrict.SelectedValue), facilitiesTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string message = facilitiesTextBox.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = facility.updateFacility(int.Parse(drpDistrict.SelectedValue), int.Parse(idFacilityHF.Value), facilitiesTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = facilitiesTextBox.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = facility.dtGetFacilityDetails();
        grdView.DataBind();
    }

    private void loadDistrict()
    {
        drpDistrict.Items.Clear();
        drpDistrict.Items.Add(new ListItem("Select District...", "-1"));
        List<District> districts = District.lstGetDistrictBySuperintendent(int.Parse(drpSuperintendents.SelectedValue));
        foreach (District district in districts)
        {
            drpDistrict.Items.Add(new ListItem(district.m_sDistrict, district.m_iDistrictId.ToString()));
        }
    }

    private void Clear()
    {
        //drpSuperintendents.ClearSelection();
        //drpDistrict.Items.Clear();
        facilitiesTextBox.Text = "";
        idFacilityHF.Value = "";
    }

    protected void drpDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDistrict.SelectedValue == "-1")
        {
            loadData();
        }
        else
        {
            grdView.DataSource = facility.dtGetFacilityByDistrict(int.Parse(drpDistrict.SelectedValue));
            grdView.DataBind();
        }
    }
}
