using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class App_Contract_UserControls_KPIReport : System.Web.UI.UserControl
{
    PriorityHelper oPriorityHelper = new PriorityHelper();
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadData()
    {
        grdView.DataSource = oPriorityHelper.dtGetPriorities();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblPriority = (Label)grdRow.FindControl("lblPriority");
            int iPriorityId = int.Parse(lblPriority.Attributes["IDPRIORITY"].ToString());

            GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");

            DataTable dt = oContractActivitiesHelper.dtGetActivitiesByPriorityTripStartDate(iPriorityId, int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStartDate.dtSelectedDate);
            if (dt.Rows.Count > 0)
            {
                oSubGrdView.DataSource = dt;
                oSubGrdView.DataBind();
            }
        }

        appUsersHelper oAppUser = new appUsersHelper();

        lblSuperintendent.Text = "OPS SUPT Name: " + oAppUser.objGetUserByUserID(oContractActivitiesHelper.objGetOpsSuperintendentByTripStartDated(dtTripStartDate.dtSelectedDate)).m_sFullName;
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    public UserControl_dateControl TripStartDate
    {
        get { return dtTripStartDate; }
    }
}