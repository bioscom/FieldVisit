using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_FlareWaiver_UserControl_oFlareECAnalyser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //public void Page_Init(int iMonth, int iYear, string sFacilityCode, string sFacility, decimal dFlareTarget, int iFacilityId)
    public void Page_Init()
    {
        if (Request.QueryString["iFacId"] != null)
        {
            int iFacilityId = int.Parse(Request.QueryString["iFacId"]);
            int iYear = int.Parse(Request.QueryString["iYear"]);
            string sCode = Request.QueryString["sCode"];
            string sFacility = Request.QueryString["sFac"];
            decimal dFlareTarget = decimal.Parse(Request.QueryString["dTar"]);
            int iMonth = int.Parse(Request.QueryString["iMonth"]);

            try
            {
                PnlFlareWaiverApproval.Visible = false;
                PnlNoApproval.Visible = false;

                lblCode.Text = sCode;
                lblFacility.Text = sFacility;
                lblFlareTarget.Text = stringRoutine.formatAsNumber(dFlareTarget);
                lblMonth.Text = mMonthEnuem.monthDesc((mMonthEnuem.mMonth)iMonth);

                FlareWaiverRequestHelper o = new FlareWaiverRequestHelper();

                DataTable dt = o.dtGetFlareWaiverRequestEC(iMonth, iYear, sCode);

                if (dt.Rows.Count > DateTime.DaysInMonth(iYear, iMonth)) grdViewEC.DataSource = dtResult(iMonth, iYear, dt);
                else if ((iMonth == DateTime.Now.Month) && (dt.Rows.Count > DateTime.Now.Day)) grdViewEC.DataSource = dtResult2(iMonth, iYear, dt);
                else grdViewEC.DataSource = dt;

                grdViewEC.DataBind();

                ManageGrid(dFlareTarget);
                Summary(dFlareTarget, iMonth, iYear, sCode, iFacilityId);
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    private DataTable dtResult(int iMonth, int iYear, DataTable dt)
    {
        DataRow row;
        DataTable oDt = new DataTable();
        oDt.Columns.Add("AREA"); oDt.Columns.Add("FACILITYKEY"); oDt.Columns.Add("PRODUCTION_DAY"); oDt.Columns.Add("CODE"); oDt.Columns.Add("API");

        int iNextRow = 1;
        int iRows = dt.Rows.Count;
        for (int iDay = 1; iDay <= DateTime.DaysInMonth(iYear, iMonth); ++iDay)
        {
            string filter = "PRODUCTION_DAY = '" + new DateTime(iYear, iMonth, iDay) + "'"; //Define the filter                   
            DataRow[] FilteredRows = dt.Select(filter); //Filter the rows using Select() method of DataTable
            decimal API = 0; string sCode = "";

            row = oDt.NewRow();

            row["AREA"] = dt.Rows[iNextRow]["AREA"];
            row["FACILITYKEY"] = dt.Rows[iNextRow]["FACILITYKEY"];
            row["PRODUCTION_DAY"] = dt.Rows[iNextRow]["PRODUCTION_DAY"];

            foreach (DataRow xrow in FilteredRows)
            {
                API += (!string.IsNullOrEmpty(xrow["API"].ToString())) ? decimal.Parse(xrow["API"].ToString()) : 0;
                sCode += xrow["CODE"] + ", ";
            }
            row["CODE"] = sCode;
            row["API"] = API;
            oDt.Rows.Add(row);

            iNextRow += (FilteredRows.Length);

            if (iNextRow > iRows) break;            
        }

        return oDt;
    }

    private DataTable dtResult2(int iMonth, int iYear, DataTable dt)
    {
        DataRow row;
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("AREA"); dtNew.Columns.Add("FACILITYKEY"); dtNew.Columns.Add("PRODUCTION_DAY"); dtNew.Columns.Add("CODE"); dtNew.Columns.Add("API");

        int iNextRow = 1;
        int iRows = dt.Rows.Count;
        for (int iDay = 1; iDay < DateTime.Now.Day; ++iDay)
        {
            string filter = "PRODUCTION_DAY = '" + new DateTime(iYear, iMonth, iDay) + "'"; //Define the filter                   
            DataRow[] FilteredRows = dt.Select(filter); //Filter the rows using Select() method of DataTable
            decimal API = 0; string sCode = "";

            row = dtNew.NewRow();

            row["AREA"] = dt.Rows[iNextRow]["AREA"];
            row["FACILITYKEY"] = dt.Rows[iNextRow]["FACILITYKEY"];
            row["PRODUCTION_DAY"] = dt.Rows[iNextRow]["PRODUCTION_DAY"];

            foreach (DataRow xrow in FilteredRows)
            {
                API += (!string.IsNullOrEmpty(xrow["API"].ToString())) ? decimal.Parse(xrow["API"].ToString()) : 0;
                sCode += xrow["CODE"] + ", ";
            }
            row["CODE"] = sCode;
            row["API"] = API;
            dtNew.Rows.Add(row);

            iNextRow += (FilteredRows.Length);
            if (iNextRow > iRows) break;
        }

        return dtNew;
    }

    private void Summary(decimal dFlareTarget, int iMonth, int iYear, string sFacilityCode, int iFacilityId)
    {
        FlareWaiverRequestHelper o = new FlareWaiverRequestHelper();
        lbTarget.Text = stringRoutine.formatAsNumber(dFlareTarget);

        decimal AverageMonthlyActual = 0;
        List<EnergyComponent> lstEC = o.lstGetDailyFlaredGasFromEC(iMonth, iYear, sFacilityCode);

        var totActual = lstEC.Sum(S => S.API);
        int iRows = DateTime.DaysInMonth(iYear, iMonth);
        if ((iMonth == DateTime.Now.Month) && (lstEC.Count == DateTime.Now.Day)) iRows = lstEC.Count - 1; //Remove 1 because the production day for yesterday is considered for today, this is required if in current month
        else if ((iMonth == DateTime.Now.Month) && (lstEC.Count > DateTime.Now.Day)) iRows = DateTime.Now.Day - 1; //Remove 1 because the production day for yesterday is considered for today, this is required if in current month

        AverageMonthlyActual = (iRows > 0) ? Math.Round((totActual / iRows), 2, MidpointRounding.AwayFromZero) : 0;

        if (AverageMonthlyActual > dFlareTarget) lbActual.ForeColor = System.Drawing.Color.Red;
        else if (AverageMonthlyActual < dFlareTarget) lbActual.ForeColor = System.Drawing.Color.Green;
        else if (AverageMonthlyActual == dFlareTarget) lbActual.ForeColor = System.Drawing.Color.Orange;

        lbActual.Text = stringRoutine.formatAsNumber(AverageMonthlyActual);

        FlareWaiverProof(iMonth, iYear, iFacilityId);
    }

    private void FlareWaiverProof(int iMonth, int iYear, int iFacilityId)
    {
        FlareWaiverRequestHelper o = new FlareWaiverRequestHelper();
        FlareWaiver oFlareWaiverRequest = o.objGetFlareWaiverRequestByFacilityYearMonth(iFacilityId, iYear, iMonth);

	PnlFlareWaiverApproval.Visible = false;
        PnlNoApproval.Visible = false;

        //if (o.dtGetFlareWaiverRequestByFacilityYearMonth(iFacilityId, iYear, iMonth).Rows.Count > 0)
        if(oFlareWaiverRequest.m_lRequestId != 0)
        {
            PnlFlareWaiverApproval.Visible = true;
            PnlNoApproval.Visible = false;
            //FlareWaiver oFlareWaiverRequest = o.objGetFlareWaiverRequestByFacilityYearMonth(iFacilityId, iYear, iMonth);
            Init_Control(oFlareWaiverRequest);
        }
        else
        {
            PnlFlareWaiverApproval.Visible = false;
            PnlNoApproval.Visible = true;
            lblNoApproval.Text = "No Flare Waiver request found!!!";
        }
    }

    public void Init_Control(FlareWaiver oFlareWaiverRequest)
    {
        appUsersHelper oappUsersHelper = new appUsersHelper();
        RequestFacilityHelper oRequestFacilityHelper = new RequestFacilityHelper();

        oRequestDetails1.Init_Control(oFlareWaiverRequest);

        //lblRequestNumber.Text = oFlareWaiverRequest.m_sRequestNumber;
        //lblFlareAgVolume.Text = oFlareWaiverRequest.m_sFlareVol.ToString() + " (mmscfd)";
        //lblAssOilProd.Text = oFlareWaiverRequest.m_sOilProduced.ToString() + " (mbopd)";

        //lblDateInit.Text = oFlareWaiverRequest.m_sDateCreated;
        //lblCategory.Text = Category.objGetCategoryByCatId(oFlareWaiverRequest.m_iCategoryId).m_sCategory;
        ////lblFacility.Text = Facility.objGetFacilityById(oFlareWaiverRequest.m_iFacilityId).m_sFacility);

        //List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(oFlareWaiverRequest.m_lRequestId);
        //foreach (RequestFacility oRequestFacility in lstRequestFacilities)
        //{
        //    lblFacility1.Text += Facility.objGetFacilityById(oRequestFacility.m_iFacilityId).m_sFacility + ", ";
        //}

        //lblStartDate.Text = oFlareWaiverRequest.m_sStartDate;
        //lblStartTime.Text = oFlareWaiverRequest.m_sStartTime;
        //lblEndDate.Text = oFlareWaiverRequest.m_sEndDate;
        //lblEndTime.Text = oFlareWaiverRequest.m_sEndTime;

        //lblReason.Text = oFlareWaiverRequest.m_sReason;
        //lblJustification.Text = oFlareWaiverRequest.m_sJustification;
        //lblPostEvent.Text = oFlareWaiverRequest.m_sPostEvent;

        //lblInitiator.Text = oappUsersHelper.objGetUserByUserID(oFlareWaiverRequest.m_iUserId).m_sFullName;
        //lblStatus.Text = oFlareWaiverRequest.m_iStatus.ToString();

        //RequestStatusReporter.reportMyStatus(lblStatus);
    }

    private void ManageGrid(decimal dFlareTarget)
    {
        foreach (GridViewRow grdRow in grdViewEC.Rows)
        {
            Label lblAPI = (Label)grdRow.FindControl("lblAPI");
            if (!string.IsNullOrEmpty(lblAPI.Text))
            {
                decimal dAPI = decimal.Parse(lblAPI.Text.Replace(",",""));
                if (dAPI > dFlareTarget) grdRow.Cells[5].BackColor = System.Drawing.Color.Red;
                else if (dAPI < dFlareTarget) grdRow.Cells[5].BackColor = System.Drawing.Color.Green;
                else if (dAPI == dFlareTarget) grdRow.Cells[5].BackColor = System.Drawing.Color.Orange;
            }
        }
    }
}