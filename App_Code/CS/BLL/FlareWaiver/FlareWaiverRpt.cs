using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for FlareWaiverRpt
/// </summary>
public class FlareWaiverRpt
{
    public FlareWaiverRpt()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataTable DtGetApprovedNotApprovedByGmp(int iStatus, int iYear, int iRole)
    {
        //Approved by GM
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.GetProposalsApprovedByGmp();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRole";
        param.Value = iRole;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable DtGetPendingLineSupport(int iStatus, int iYear)
    {
        //Pending Line Support
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.GetProposalsPendingLineSupport();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<FlareWaiver> LstGetApprovedNotApprovedByGmp(int iStatus, int iYear, int iRole)
    {
        DataTable dt = DtGetApprovedNotApprovedByGmp(iStatus, iYear, iRole);

        var oFlareWaiver = new List<FlareWaiver>(dt.Rows.Count);
        oFlareWaiver.AddRange(from DataRow dr in dt.Rows select new FlareWaiver(dr));
        return oFlareWaiver;
    }

    public static List<FlareWaiver> LstGetPendingLineSupport(int iStatus, int iYear)
    {
        DataTable dt = DtGetPendingLineSupport(iStatus, iYear);

        var oFlareWaiver = new List<FlareWaiver>(dt.Rows.Count);
        oFlareWaiver.AddRange(from DataRow dr in dt.Rows select new FlareWaiver(dr));
        return oFlareWaiver;
    }

    public static List<int> LstYearsExt()
    {
        int iYear = 0;
        DataTable dt = DtGetYear();
        List<int> oYears = new List<int>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            iYear = int.Parse(dr["YYEAR"].ToString());
            oYears.Add(iYear);
        }

        oYears.Add(iYear += 1);
        oYears.Add(iYear += 1);
        oYears.Add(iYear += 1);
        oYears.Add(iYear += 1);

        return oYears;
    }

    public static DataTable DtGetYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getYear();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static void LoadYear(DropDownList ddlYear)
    {
        var oYears = FlareWaiverRpt.LstYearsExt();
        ddlYear.Items.Clear();
        ddlYear.Items.Add(new ListItem("--Select Year--", "1"));
        foreach (var i in oYears)
        {
            ddlYear.Items.Add(i.ToString());
        }
        int iYear = DateTime.Now.Year;
        ddlYear.SelectedValue = iYear.ToString();
    }
}