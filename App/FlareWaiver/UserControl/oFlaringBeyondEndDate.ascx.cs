using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

public partial class App_FlareWaiver_UserControl_oFlaringBeyondEndDate : System.Web.UI.UserControl
{
    FlareWaiverRequestHelper oT = new FlareWaiverRequestHelper();
    FlareTargetHelper oFlrT = new FlareTargetHelper();
    //Sample ViewModel Class in MVC
    public class FlareBeyond
    {
        public long lRequestId { get; set; }
        public string sRequestNo { get; set; }
        public string sfacility { get; set; }
        public string sCode { get; set; }
        public DateTime? dStartDate { get; set; }
        public DateTime? dEndDate { get; set; }
        public DateTime? dDateApproved { get; set; }

        public DateTime dOriginalEndDate
        {
            get
            {
                TimeSpan iDiff = DateTime.Parse(dEndDate.ToString()) - DateTime.Parse(dStartDate.ToString());
                return dDateApproved.Value.AddDays(iDiff.Days);
            }
        }

        public FlareBeyond()
        {

        }

        public FlareBeyond(DataRow dr)
        {
            lRequestId = long.Parse(dr["IDREQUEST"].ToString());
            sRequestNo = dr["REQUESTNO"].ToString();
            sfacility = dr["FACILITY"].ToString();
            sCode = dr["CODE"].ToString();
            dStartDate = (dr["START_DATE"] == DBNull.Value) ? (DateTime?)null : DateTime.Parse(dr["START_DATE"].ToString());
            dEndDate = (dr["END_DATE"] == DBNull.Value) ? (DateTime?)null : DateTime.Parse(dr["END_DATE"].ToString());
            dDateApproved = (dr["DATE_APPROVED"] == DBNull.Value) ? (DateTime?)null : DateTime.Parse(dr["DATE_APPROVED"].ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FlareWaiverRpt.LoadYear(ddlYear);
            cVerificationHeatMapHelper.getMonths(ddlMonth);
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            LoadResult();
        }
    }

    public DataTable dtGetInfo(int iYear, int iMonth, int iStatus)
    {
        string sql = "SELECT T.IDREQUEST, T.REQUESTNO, K.IDFACILITY, K.FACILITY, K.CODE, SUBSTR(T.REASON, 0,300) AS REASON, T.START_DATE, T.END_DATE, T.DATE_APPROVED, T.NEW_END_DATE FROM FLARE_REQUEST T ";
        sql += "INNER JOIN FLARE_REQUEST_FACILITIES F ON T.IDREQUEST = F.IDREQUEST ";
        sql += "INNER JOIN FLARE_FACILITIES K ON K.IDFACILITY = F.IDFACILITY WHERE T.STATUS = :iStatus AND TO_CHAR(to_date(T.DATE_APPROVED, 'DD-MON-YY'), 'YYYY') = :iYear ";
        sql += "AND TO_CHAR(T.DATE_APPROVED, 'MM') = :iMonth ORDER BY T.IDREQUEST ";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<FlareBeyond> lstGetFlareBeyond(int iYear, int iMonth, int iStatus)
    {
        DataTable dt = dtGetInfo(iYear, iMonth, iStatus);

        List<FlareBeyond> o = new List<FlareBeyond>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new FlareBeyond(dr));
        }
        return o;
    }

    private void LoadResult()
    {
        grdView.DataSource = dtGetInfo(int.Parse(ddlYear.SelectedValue), int.Parse(ddlMonth.SelectedValue), (int)RequestStatusReporter.RequestStatusRpt.Approved);
        grdView.DataBind();
        int i = grdView.Columns.Count;

        int iYear = int.Parse(ddlYear.SelectedValue);

        List<FlareBeyond> ols = lstGetFlareBeyond(iYear, int.Parse(ddlMonth.SelectedValue), (int)RequestStatusReporter.RequestStatusRpt.Approved);
        //var filtered = ols.Where(p => p.sCode != ""); 

        List<EnergyComponent> oLst = oT.lstGetFromECFlareBeyond(iYear, int.Parse(ddlMonth.SelectedValue));
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            foreach (FlareBeyond o in ols)
            {
                Label lblRequestNo = (Label)grdRow.FindControl("lblRequestNo");
                Label lblOriginalED = (Label)grdRow.FindControl("lblOriginalED");
                Label labelCodes = (Label)grdRow.FindControl("labelCodes");
                Label lblLastFlaredDate = (Label)grdRow.FindControl("lblLastFlaredDate");
		Label lblFacilities = (Label)grdRow.FindControl("lblFacilities");

                Label lblTotalFlared = (Label)grdRow.FindControl("lblTotalFlared");
                Label lblAnnualFlareLimit = (Label)grdRow.FindControl("lblAnnualLimit");
                Label lblActualFlared = (Label)grdRow.FindControl("lblActualFlared");

		int iFacilityId = int.Parse(lblFacilities.Attributes["IDFACILITY"].ToString());

                if (lblRequestNo.Text.Trim() == o.sRequestNo.Trim())
                {
                    lblOriginalED.Text = o.dOriginalEndDate.ToString("dd-MMM-yyyy");
                    //Compare this Original or approved flare end date, above, with the last flare date from Energy Component.
                    //If Energy Component date is beyond the Original or approved flare end date, mark the status cell RED else GREEN.


                    //YTD actual
                    List<EnergyComponent> GasFlareYTD = oT.lstGetGasFlareYTDByFacility(o.sCode, iYear);
                    var TotalFlaredYTD = GasFlareYTD.Sum(s => s.API);
                    var FlareYTDactual = TotalFlaredYTD / DateTime.Now.Date.DayOfYear - 1;

                    lblTotalFlared.Text = stringRoutine.formatAsNumber(TotalFlaredYTD);
                    lblActualFlared.Text = stringRoutine.formatAsNumber(FlareYTDactual);

		    // Annual flare limit
                    var AnnualFlareLimit = oFlrT.objGetFlareAnnualTargetByFacilityId(iFacilityId, iYear).iYTD;
                    lblAnnualFlareLimit.Text = stringRoutine.formatAsNumber(AnnualFlareLimit);


                    var filtered = oLst.Where(p => p.FacilityKey == labelCodes.Text && p.API > 0).OrderBy(x => x.ProductionDay);
                    if (filtered.ToList().Count > 0)
                    {
                        lblLastFlaredDate.Text = filtered.Last().ProductionDay.ToString("dd-MMM-yyyy");

                        if ((filtered.Last().ProductionDay > o.dOriginalEndDate) && (FlareYTDactual > AnnualFlareLimit))
                            grdRow.Cells[i - 1].BackColor = System.Drawing.Color.Red;
                        else
                            grdRow.Cells[i - 1].BackColor = System.Drawing.Color.Green;
                    }
                }
            }
        }
    }


    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadResult();
    }
}