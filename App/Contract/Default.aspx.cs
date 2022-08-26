using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_Contract_Default : aspnetPage
{
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractActivitiesRecordedHelper oContractActivitiesRecordedHelper = new ContractActivitiesRecordedHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                oContractActivitiesHelper.LoadDistrict(ddlDistrict);

                DataTable dt = oContractActivitiesRecordedHelper.dtGet14DayContracts();
                LoadData(dt);
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = oContractActivitiesRecordedHelper.dtGet14DayContractByDistrict(int.Parse(ddlDistrict.SelectedValue));
        LoadData(dt);
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName;
        DataSorter SortMe = new DataSorter();

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
                Response.Redirect("~/App/Contract/Start14DayContract.aspx?dt=" + dtTripStart + "&dstrt=" + iDistrictId);
            }

            //if (ButtonClicked == "Update2")
            //{
            //    LinkButton lnkUpdate = (LinkButton)grdView.Rows[index].FindControl("Update2LinkButton");
            //    int iDistrictId = int.Parse(lnkUpdate.Attributes["ID_DISTRICT"].ToString());

            //    Label lbStartDate = (Label)grdView.Rows[index].FindControl("lbStartDate");
            //    string dtTripStart = lbStartDate.Text;
            //    Response.Redirect("~/App/Contract/WhatWhyConsequences.aspx?dt=" + dtTripStart + "&dstrt=" + iDistrictId);
            //}

            if (ButtonClicked == "Report")
            {
                LinkButton lnkReport = (LinkButton)grdView.Rows[index].FindControl("ReportLinkButton");
                int iDistrictId = int.Parse(lnkReport.Attributes["ID_DISTRICT"].ToString());

                Label lbStartDate = (Label)grdView.Rows[index].FindControl("lbStartDate");
                string dtTripStart = lbStartDate.Text;
                Response.Redirect("~/App/Contract/KPIReport.aspx?dt=" + dtTripStart + "&dstrt=" + iDistrictId);
            }

            //if (ButtonClicked == "LeadershipActivityReport")
            //{
            //    LinkButton lnkReport = (LinkButton)grdView.Rows[index].FindControl("LeadershipActivityReportLinkButton");
            //    int iDistrictId = int.Parse(lnkReport.Attributes["ID_DISTRICT"].ToString());

            //    Label lbStartDate = (Label)grdView.Rows[index].FindControl("lbStartDate");
            //    string dtTripStart = lbStartDate.Text;
            //    Response.Redirect("~/App/Contract/LeadershipActivityReport.aspx?dt=" + dtTripStart + "&dstrt=" + iDistrictId);
            //}

            //App_Contract_LeadershipActivityReport
        }
    }


    private void LoadData(DataTable dt)
    {
        grdView.DataSource = dt;
        grdView.DataBind();

        grdView.Columns[0].Visible = false;
        //grdView.Columns[1].Visible = false;

        if (oSessnx.getOnlineUser.m_iRoleIdContract == (int)AppUsers14DaysContract.UserRole.Administrator)
        {
            grdView.Columns[0].Visible = true;
            //grdView.Columns[1].Visible = true;
        }

        List<SuperintendentFunctionalAcctUser> MySuperintendents = SuperintendentFunctionalAcctUser.lstGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
        foreach (SuperintendentFunctionalAcctUser MySuperintendent in MySuperintendents)
        {
            if (MySuperintendent.superintendentId != 0)
            {
                grdView.Columns[0].Visible = true;
                //grdView.Columns[1].Visible = true;
            }
        }
    }
}