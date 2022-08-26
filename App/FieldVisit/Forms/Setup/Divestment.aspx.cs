using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FieldVisit_Forms_Setup_Divestment : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole) this.oSessnx.getOnlineUser.m_iRoleIdFieldVisit);
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

    protected void drpDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDataByDistrict();
    }
   
    protected void drpSuperintendents_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Load District
        loadDistrict();
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

    protected void submitButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            CheckBox ckbDivestment = (CheckBox) grdRow.FindControl("ckbDivestment");
            int iD = int.Parse(ckbDivestment.Attributes["DIVESTED"]);
            int iFacilityId = int.Parse(ckbDivestment.Attributes["FACILITYID"]);
            if (ckbDivestment.Checked)
            {
                //Update the rows by setting the divested column to Divested
                bool bRet = facility.Divested(iFacilityId, (int) DivestmentEnum.Divestment.Divested);
            }
            else
            {
                //Update the rows by setting the divested column to Divested
                bool bRet = facility.Divested(iFacilityId, (int) DivestmentEnum.Divestment.Active);
            }
        }
        LoadDataByDistrict();
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

        //if (ButtonClicked == "editThis")
        //{
        //    LinkButton lbEdit = (LinkButton) grdView.Rows[index].FindControl("editLinkButton");
        //    idFacilityHF.Value = lbEdit.Attributes["ID_FACILITIES"].ToString();

        //    if ((idFacilityHF.Value != null) || (idFacilityHF.Value != ""))
        //    {
        //        facility myFacility = facility.objGetFacilityById(int.Parse(idFacilityHF.Value));

        //        drpSuperintendents.SelectedValue = myFacility.eSuperintendent.m_iSuperintendentId.ToString();

        //        //Load District
        //        loadDistrict();

        //        drpDistrict.SelectedValue = myFacility.m_iDistrictId.ToString();
        //        facilitiesTextBox.Text = myFacility.m_sFacility;
        //    }
        //}
    }

    private void loadDatas()
    {
        grdView.DataSource = facility.dtGetFacilityDetails();
        grdView.DataBind();
        ManageGrid();
    }

    private void loadData()
    {
        if (drpDistrict.SelectedValue == "-1")
        {
            loadDatas();
        }
        else
        {
            LoadDataByDistrict();
        }
    }

    private void LoadDataByDistrict()
    {
        grdView.DataSource = facility.dtGetFacilityByDistrict(int.Parse(drpDistrict.SelectedValue));
        grdView.DataBind();
        ManageGrid();
    }

    public void ManageGrid()
    {
        foreach(GridViewRow grdRow in grdView.Rows)
        {
            CheckBox ckbDivestment = (CheckBox) grdRow.FindControl("ckbDivestment");
            int iD = int.Parse(ckbDivestment.Attributes["DIVESTED"]);
            if ((int) DivestmentEnum.Divestment.Divested == iD) ckbDivestment.Checked = true;
                
            Label lblDivestment = (Label) grdRow.FindControl("lblDivestment");
            int iDiv = int.Parse(lblDivestment.Text);

            lblDivestment.Text = DivestmentEnum.DivestmentDesc((DivestmentEnum.Divestment) iDiv);
            if ((int) DivestmentEnum.Divestment.Active == iDiv) lblDivestment.ForeColor = System.Drawing.Color.Green;
            else if ((int) DivestmentEnum.Divestment.Divested == iDiv) lblDivestment.ForeColor = System.Drawing.Color.Red;
        }
    }
}