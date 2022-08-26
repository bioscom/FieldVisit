using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_Contract_UserControls_ApprovedContracts : aspnetUserControl
{
    readonly ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    readonly ContractActivitiesRecordedHelper oContractActivitiesRecordedHelper = new ContractActivitiesRecordedHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void Page_Init(object sender, EventArgs e)
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

            if (ButtonClicked == "Report")
            {
                LinkButton lnkReport = (LinkButton)grdView.Rows[index].FindControl("ReportLinkButton");
                int iDistrictId = int.Parse(lnkReport.Attributes["ID_DISTRICT"].ToString());

                Label lbStartDate = (Label)grdView.Rows[index].FindControl("lbStartDate");
                string dtTripStart = lbStartDate.Text;
                Response.Redirect("~/App/Contract/KPIReport.aspx?dt=" + dtTripStart + "&dstrt=" + iDistrictId);
            }
        }
    }

    private void LoadData(DataTable dt)
    {
        grdView.DataSource = dt;
        grdView.DataBind();

        //List<SuperintendentFunctionalAcctUser> mySuperintendents = SuperintendentFunctionalAcctUser.lstGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
        //foreach (SuperintendentFunctionalAcctUser mySuperintendent in mySuperintendents)
        //{
        //    if (mySuperintendent.superintendentId != 0)
        //    {
        //        grdView.Columns[0].Visible = true;
        //        //grdView.Columns[1].Visible = true;
        //    }
        //}
    }
}