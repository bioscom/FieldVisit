using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Contract_listContractsByDistrict : aspnetPage
{
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractActivitiesRecordedHelper oContractActivitiesRecordedHelper = new ContractActivitiesRecordedHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            oContractActivitiesHelper.LoadDistrict(ddlDistrict);

            if (oSessnx.getOnlineUser.m_iRoleIdContract == (int)appUsersRoles.userRole.admin)
            {
                grdView.DataSource = oContractActivitiesRecordedHelper.dtGet14DayContracts();
                grdView.DataBind();
            }
        }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdView.DataSource = oContractActivitiesRecordedHelper.dtGet14DayContractByDistrict(int.Parse(ddlDistrict.SelectedValue));
        grdView.DataBind();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName;
        DataSorter SortMe = new DataSorter();

        //try
        //{
        if ((ButtonClicked == "Sort") || (ButtonClicked == "Page") || (ButtonClicked == "Last"))
        {

        }
        else
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (ButtonClicked == "Update")
            {
                LinkButton lnkUpdate = (LinkButton)grdView.Rows[index].FindControl("UpdateLinkButton");
                int iDistrictId = int.Parse(lnkUpdate.Attributes["ID_DISTRICT"].ToString());

                Label lbStartDate = (Label)grdView.Rows[index].FindControl("lbStartDate");
                string dtTripStart = lbStartDate.Text;
                Response.Redirect("~/App/Contract/Star14DayContract.aspx?dt=" + dtTripStart + "&dstrt=" + iDistrictId);
            }

            if (ButtonClicked == "Update2")
            {
                LinkButton lnkUpdate = (LinkButton)grdView.Rows[index].FindControl("Update2LinkButton");
                int iDistrictId = int.Parse(lnkUpdate.Attributes["ID_DISTRICT"].ToString());

                Label lbStartDate = (Label)grdView.Rows[index].FindControl("lbStartDate");
                string dtTripStart = lbStartDate.Text;
                Response.Redirect("~/App/Contract/WhatWhyConsequences.aspx?dt=" + dtTripStart + "&dstrt=" + iDistrictId);
            }
        }
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }
}