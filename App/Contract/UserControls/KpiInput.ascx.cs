using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;

public partial class App_Contract_UserControls_KpiInput : aspnetUserControl
{
    PriorityHelper oPriorityHelper = new PriorityHelper();
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractActivitiesRecordedHelper oContractActivitiesRecordedHelper = new ContractActivitiesRecordedHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        oContractActivitiesHelper.LoadDistrict(ddlDistrict);
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
    }

    public void Init_Page()
    {
        HFDistrictId.Value = Request.QueryString["dstrt"].ToString();
        ddlDistrict.SelectedValue = Request.QueryString["dstrt"].ToString();
        DtDateTripStarts.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
        ddlDistrict.Enabled = false;
        lblAssetArea.Text = District.objGetDistrictById(int.Parse(Request.QueryString["dstrt"].ToString())).m_sDistrict;

        btnSubmit.Visible = false;
        btnUpdate.Visible = true;
        //dtTripStart.dtSetDate(DateTime.Parse(Request.QueryString["dt"]));

        LoadData2();
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    public UserControl_dateControl TripStartDate
    {
        get { return dtTripStart; }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(dtTripStart.SelectedDate))
        {
            lblAssetArea.Text = ddlDistrict.SelectedItem.Text;

            if (oSessnx.getOnlineUser.m_iRoleIdContract == (int)appUsersRoles.userRole.admin)
            {
                LoadData();
            }
            else
            {
                SuperintendentFunctionalAcctUser MySuperintendents = SuperintendentFunctionalAcctUser.objGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
                if (MySuperintendents.superintendentId == 0)
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, You do not have right to enter data for " + ddlDistrict.SelectedItem.Text + " District. Contact the System Administrator.");
                }
                else
                {
                    LoadData();
                }
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Please select trip start date!!!");
            ddlDistrict.ClearSelection();
        }
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

            DataTable dt = oContractActivitiesHelper.dtGetActivitiesByPriority2(iPriorityId);
            dt.Columns.Add("TARGET");
            dt.Columns.Add("ACTUAL");

            if (dt.Rows.Count > 0)
            {
                oSubGrdView.DataSource = dt;
                oSubGrdView.DataBind();
            }
        }

        appUsersHelper oAppUser = new appUsersHelper();

        lblSuperintendent.Text = "OPS SUPT Name: " + oAppUser.objGetUserByUserID(oContractActivitiesHelper.objGetOpsSuperintendentByTripStartDated(dtTripStart.dtSelectedDate)).m_sFullName;
    }

    public void LoadData2()
    {
        grdView.DataSource = oPriorityHelper.dtGetPriorities();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblPriority = (Label)grdRow.FindControl("lblPriority");
            int iPriorityId = int.Parse(lblPriority.Attributes["IDPRIORITY"].ToString());

            GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");

            DataTable dt = oContractActivitiesHelper.dtGetActivitiesByPriority2TripStartDate(iPriorityId, int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStart.dtSelectedDate);

            oSubGrdView.DataSource = dt;
            oSubGrdView.DataBind();
        }

        appUsersHelper oAppUser = new appUsersHelper();

        lblSuperintendent.Text = "OPS SUPT Name: " + oAppUser.objGetUserByUserID(oContractActivitiesHelper.objGetOpsSuperintendentByTripStartDated(dtTripStart.dtSelectedDate)).m_sFullName;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        ContractActivitiesRecorded oContractActivitiesRecorded = new ContractActivitiesRecorded();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblPriority = (Label)grdRow.FindControl("lblPriority");
            int iPriorityId = int.Parse(lblPriority.Attributes["IDPRIORITY"].ToString());

            GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");
            foreach (GridViewRow subGrdRow in oSubGrdView.Rows)
            {
                oContractActivitiesRecorded.iDistrictId = int.Parse(ddlDistrict.SelectedValue);
                oContractActivitiesRecorded.iUserId = oSessnx.getOnlineUser.m_iUserId;
                oContractActivitiesRecorded.dtTripStartDate = dtTripStart.dtSelectedDate;

                Label lblActivity = (Label)subGrdRow.FindControl("lblActivity");
                oContractActivitiesRecorded.iActivityId = int.Parse(lblActivity.Attributes["IDACTIVITIES"].ToString());

                TextBox txtTarget = (TextBox)subGrdRow.FindControl("txtTarget");
                TextBox txtActual = (TextBox)subGrdRow.FindControl("txtActual");

                if (string.IsNullOrEmpty(txtTarget.Text)) oContractActivitiesRecorded.dTarget = null; else oContractActivitiesRecorded.dTarget = decimal.Parse(txtTarget.Text);
                if (string.IsNullOrEmpty(txtActual.Text)) oContractActivitiesRecorded.dActual = null; else oContractActivitiesRecorded.dActual = decimal.Parse(txtActual.Text);

                bRet = oContractActivitiesRecordedHelper.Insert14DayContract2(oContractActivitiesRecorded);         
            }
        }

        if(bRet)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Update Successful!!!");
            Response.Redirect("~/App/Contract/Start14DayContract.aspx?dt=" + dtTripStart.dtSelectedDate + "&dstrt=" + ddlDistrict.SelectedValue + "&bRet=t");
        }
    }

    public UserControl_dateControl DtDateTripStarts
    {
        get { return dtTripStart; }
    }

    //public Button ForwardForApproval
    //{
    //    //get { return btnForwardForApproval; }
    //}
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Contract/Default.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        ContractActivitiesRecorded oContractActivitiesRecorded = new ContractActivitiesRecorded();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblPriority = (Label)grdRow.FindControl("lblPriority");
            int iPriorityId = int.Parse(lblPriority.Attributes["IDPRIORITY"].ToString());

            GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");
            foreach (GridViewRow subGrdRow in oSubGrdView.Rows)
            {
                oContractActivitiesRecorded.iDistrictId = int.Parse(ddlDistrict.SelectedValue);
                oContractActivitiesRecorded.iUserId = oSessnx.getOnlineUser.m_iUserId;
                oContractActivitiesRecorded.dtTripStartDate = dtTripStart.dtSelectedDate;

                Label lblActivity = (Label)subGrdRow.FindControl("lblActivity");
                oContractActivitiesRecorded.iActivityId = int.Parse(lblActivity.Attributes["IDACTIVITIES"].ToString());

                TextBox txtTarget = (TextBox)subGrdRow.FindControl("txtTarget");
                TextBox txtActual = (TextBox)subGrdRow.FindControl("txtActual");

                if (string.IsNullOrEmpty(txtTarget.Text)) oContractActivitiesRecorded.dTarget = null; else oContractActivitiesRecorded.dTarget = decimal.Parse(txtTarget.Text);
                if (string.IsNullOrEmpty(txtActual.Text)) oContractActivitiesRecorded.dActual = null; else oContractActivitiesRecorded.dActual = decimal.Parse(txtActual.Text);

                bRet = oContractActivitiesRecordedHelper.Update14DayContract2(oContractActivitiesRecorded);
            }
        }

        if (bRet)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Update Successful!!!");
        }
        else
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Update Not Successful. Try again!!!");
        }
    }
    protected void btnForwardForApproval_Click(object sender, EventArgs e)
    {
        appUsers oAppUser = new appUsers();
        if (!string.IsNullOrEmpty(Request.QueryString["dstrt"]))
        {
            //Forward an email to the Operations Manager, copy the Admins of the tool and the Superintendent account.
            List<structUserMailIdx> eOpsMgr = new List<structUserMailIdx>();

            structUserMailIdx eSender = new structUserMailIdx(oSessnx.getOnlineUser.m_sUserName, oSessnx.getOnlineUser.m_sUserMail, oSessnx.getOnlineUser.m_iUserId.ToString());
            SendMail14DaysContract emailSender = new SendMail14DaysContract(eSender);

            int iDistrict = int.Parse(Request.QueryString["dstrt"].ToString());

            DataTable dt = OpsMgrFunctionalAcctUser.dtGetOpsMgrFunctionalAcctUsersByDistrict(iDistrict);
            if (dt.Rows.Count == 0)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, no Operations Manager found assigned to your District. Please Contact the administrator. Thanks.");
            }
            else
            {
                //Update the 14 Days contract status, to be sent for Operations Superintendent approval

                //string sql = "SELECT DISTINCT PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT, CONTRACT_APPROVAL.IDAPPROVAL, CONTRACT_APPROVAL.START_DATE, ";
                //sql += "CONTRACT_APPROVAL.USERID, CONTRACT_APPROVAL.DATE_RECEIVED, CONTRACT_APPROVAL.DATE_REVIEWED, CONTRACT_APPROVAL.STATUS, ";
                //sql += "CONTRACT_APPROVAL.COMMENTS FROM PROD_DISTRICT ";
                //sql += "INNER JOIN CONTRACT_APPROVAL ON PROD_DISTRICT.ID_DISTRICT = CONTRACT_APPROVAL.ID_DISTRICT ";

                //Get all the Operations Managers attached to the District/Asset
                List<OpsMgrFunctionalAcctUserDetails> lstOpsMgrFunctionalAcctUser = OpsMgrFunctionalAcctUser.lstGetOpsMgrAcctDetailsByDistrict(iDistrict);
                eOpsMgr.AddRange(lstOpsMgrFunctionalAcctUser.Select(opsMgr => appUsersHelper.objGetUserByUserId(opsMgr.iUserId).structUserIdx));

                DateTime dStartDate = DateTime.Parse(Request.QueryString["dt"]);
                DateTime dEndDate = dStartDate.AddDays(14);

                string sStartDate = dStartDate.ToString("dd/MM/yyyy");
                string sEndDate = dEndDate.ToString("dd/MM/yyyy");

                ContractApproval oContractApproval = new ContractApproval
                {
                    iDistrictId = iDistrict,
                    dtTripStartDate = dStartDate,
                    dtDateReceived = DateTime.Now
                };

                //Before you send an email, enter the approval into the APPROVAL TABLE
                bool bRet = ContractApprovalHelper.SendForApproval(oContractApproval);
                if (bRet)
                {
                    bRet = emailSender.SuperintendentRequestsForApproval(oSessnx.getOnlineUser, District.objGetDistrictById(iDistrict).m_sDistrict, sStartDate, sEndDate, eOpsMgr);
                    if (bRet)
                    {
                        ajaxWebExtension.showJscriptAlert(Page, this, "Your 14 days contract has been sucessfully sent for approval.");
                    }
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Your 14 days contract has not been sucessfully sent for approval, please try again later!!!");
                }
            }
        }
    }
}