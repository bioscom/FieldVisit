using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Reporting
/// </summary>
public class Reporting
{
	public Reporting()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region  ======================= Bright Ideas Reporting =======================================

    #region Weekly Reporting queries
    public DataTable dtGetRequestsByWeek(int iWeek, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByWeek();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iWeek";
        param.Value = iWeek;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByBusinessUnitWeek(int iWeek, int iYear, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByFunctionWeek();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iWeek";
        param.Value = iWeek;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByDepartmentWeek(int iWeek, int iYear, int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByDepartmentWeek();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iWeek";
        param.Value = iWeek;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByTeamWeek(int iWeek, int iYear, int iTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByTeamWeek();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iWeek";
        param.Value = iWeek;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    #endregion


    #region Monthly Reporting queries

    public DataTable dtGetRequestsByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByBusinessUnitMonth(int iMonth, int iYear, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByFunctionMonth();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByBusinessUnitYear(int iYear, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByFunctionYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public DataTable dtGetRequestsByDepartmentMonth(int iMonth, int iYear, int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByDepartmentMonth();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByDepartmentYear(int iYear, int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByDepartmentYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByTeamMonth(int iMonth, int iYear, int iTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByTeamMonth();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestsByTeamYear(int iYear, int iTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBrightIdeaByTeamYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRequestType";
        param.Value = (int)BIRequestStatus.RequestType.BI;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public List<CostReductionRequest> lstGetRequestsByBusinessUnitMonth(int iMonth, int iYear, int iFunctionId)
    {
        DataTable dt = dtGetRequestsByBusinessUnitMonth(iMonth, iYear, iFunctionId);

        List<CostReductionRequest> o = new List<CostReductionRequest>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionRequest(dr));
        }
        return o;
    }

    public List<CostReductionRequest> lstGetRequestsByBusinessUnitYear(int iYear, int iFunctionId)
    {
        DataTable dt = dtGetRequestsByBusinessUnitYear(iYear, iFunctionId);

        List<CostReductionRequest> o = new List<CostReductionRequest>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionRequest(dr));
        }
        return o;
    }

    public List<CostReductionRequest> lstGetRequestsByDepartmentMonth(int iMonth, int iYear, int iDepartmentId)
    {
        DataTable dt = dtGetRequestsByDepartmentMonth(iMonth, iYear, iDepartmentId);

        List<CostReductionRequest> o = new List<CostReductionRequest>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionRequest(dr));
        }
        return o;
    }

    public List<CostReductionRequest> lstGetRequestsByDepartmentYear(int iYear, int iDepartmentId)
    {
        DataTable dt = dtGetRequestsByDepartmentYear(iYear, iDepartmentId);

        List<CostReductionRequest> o = new List<CostReductionRequest>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionRequest(dr));
        }
        return o;
    }

    public List<CostReductionRequest> lstGetRequestsByTeamMonth(int iMonth, int iYear, int iTeamId)
    {
        DataTable dt = dtGetRequestsByTeamMonth(iMonth, iYear, iTeamId);

        List<CostReductionRequest> o = new List<CostReductionRequest>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionRequest(dr));
        }
        return o;
    }

    public List<CostReductionRequest> lstGetRequestsByTeamYear(int iYear, int iTeamId)
    {
        DataTable dt = dtGetRequestsByTeamYear(iYear, iTeamId);

        List<CostReductionRequest> o = new List<CostReductionRequest>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new CostReductionRequest(dr));
        }
        return o;
    }

    #endregion

    #endregion

}