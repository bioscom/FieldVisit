using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Report
/// </summary>
public class Report
{
	public Report()
	{
		
	}

    public static DataTable dtGetActivityInformationReportByActivityID(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityInformationReportByActivityID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetVendorCallOutReportByActivityID(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVendorCallOutReportByActivityID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetPersonnelInformationReportByActivityID(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getPersonnelInformationReportByActivityID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetActivityTimeLineReportByActivityID(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityTimeLineReportByActivityID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetPECReportByActivityID(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getPECReportByActivityID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetApprovalReportByActivityID(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getApprovalReportByActivityID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}
