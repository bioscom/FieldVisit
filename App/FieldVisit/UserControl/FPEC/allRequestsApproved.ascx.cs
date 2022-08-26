using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_allRequestsApproved : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitPage()
    {
        LoadAssets();
        loadFieldVisitRequestsApproved();
    }

    private void LoadAssets()
    {
        List<Assets> oAssets = Assets.lstGetAssets();
        foreach (Assets oAsset in oAssets)
        {
            ddlAsset.Items.Add(new ListItem(oAsset.sAsset, oAsset.iAssetId.ToString()));
        }
    }

    public void LoadFacilitiesInMyLocations(int iUserId)
    {
        List<facility> oFacilities = facility.lstGetFacilitiesByPlanner(iUserId);
        foreach (facility oFacility in oFacilities)
        {
            ddlFieldsApproved.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
        }

        //loadFieldVisitRequestsApprovedInMyLocation(iUserId);
    }

    public void LoadRequestsNotApproved()
    {
        LoadAssets();
        loadFieldVisitRequestsNotApproved();
        
    }
    public void LoadRequestsToBeRescheduled()
    {
        loadRequestsToBeRescheduled();
        LoadAssets();
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        loadFieldVisitRequestsApproved();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
        //GridView gv = (GridView)(e.CommandSource);

        //int iActivity = int.Parse(gv.DataKeys[row.RowIndex]["ID_ACTIVITIES"].ToString());

        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "viwStatus")
        {
            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("statusLinkButton");
            int iActivity = int.Parse(lbViewStatus.Attributes["ID_ACTIVITIES"].ToString());

            Response.Redirect("~/App/FieldVisit/Forms/FieldVisit/fieldVisitApprovalStatus.aspx?ActivityId=" + iActivity);
        }
        else if (ButtonClicked == "report")
        {
            LinkButton lbReport = (LinkButton)grdView.Rows[index].FindControl("reportLinkButton");
            int iActivity = int.Parse(lbReport.Attributes["ID_ACTIVITIES"].ToString());

            Response.Redirect("~/App/FieldVisit/Report/FieldEntryRpt.aspx?ActivityId=" + iActivity);
        }
    }

    private void loadFieldVisitRequestsApprovedInMyLocation(int iUserId)
    {
        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsApproved();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }

    private void loadFieldVisitRequestsApproved()
    {
        ddlFieldRescheduled.Visible = false;
        ddlFieldApproved.Visible = true;
        ddlFieldNotApproved.Visible = false;

        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsApproved();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }
    private void loadFieldVisitRequestsNotApproved()
    {
        ddlFieldRescheduled.Visible = false;
        ddlFieldApproved.Visible = false;
        ddlFieldNotApproved.Visible = true;

        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsNotApproved();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }
    private void loadRequestsToBeRescheduled()
    {
        ddlFieldRescheduled.Visible = true;
        ddlFieldApproved.Visible = false;
        ddlFieldNotApproved.Visible = false;

        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsRescheduled();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }




    protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDistrict.Items.Clear();
        ddlDistrict.Items.Add(new ListItem("Select District", "-1"));
        List<DistrictExt> oDistricts = District.lstGetDistrictExtByAsset(int.Parse(ddlAsset.SelectedValue));
        foreach (DistrictExt oDistrict in oDistricts)
        {
            ddlDistrict.Items.Add(new ListItem(oDistrict.m_sDistrict, oDistrict.m_iDistrictId.ToString()));
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFieldsApproved.Items.Clear(); ddlFieldsNotApproved.Items.Clear(); ddlFieldsRescheduled.Items.Clear();
        ddlFieldsApproved.Items.Add(new ListItem("Select Facility", "-1")); ddlFieldsNotApproved.Items.Add(new ListItem("Select Facility", "-1")); ddlFieldsRescheduled.Items.Add(new ListItem("Select Facility", "-1"));
        List<facility> oFacilities = facility.lstGetFacilityByDistrict(int.Parse(ddlDistrict.SelectedValue));
        foreach (facility oFacility in oFacilities)
        {
            ddlFieldsApproved.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
            ddlFieldsNotApproved.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
            ddlFieldsRescheduled.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
        }

    }
    protected void btnList_Click(object sender, EventArgs e)
    {

    }
    protected void ddlFieldsApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsApprovedByFacility(int.Parse(ddlFieldsApproved.SelectedValue));
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }
    protected void ddlFieldsNotApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsNotApprovedByFacility(int.Parse(ddlFieldsNotApproved.SelectedValue));
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }
    protected void ddlFieldsRescheduled_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdView.DataSource = fieldVisitDetails.dtFieldVisitRequestsRescheduledByFacility(int.Parse(ddlFieldsRescheduled.SelectedValue));
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
            statusReporter.reportMyStatus(status);
        }
    }

    public DropDownList ddlFieldApproved
    {
        get
        {
            return ddlFieldsApproved;
        }
    }

    public DropDownList ddlFieldNotApproved
    {
        get
        {
            return ddlFieldsNotApproved;
        }
    }

    public DropDownList ddlFieldRescheduled
    {
        get
        {
            return ddlFieldsRescheduled;
        }
    }
}
