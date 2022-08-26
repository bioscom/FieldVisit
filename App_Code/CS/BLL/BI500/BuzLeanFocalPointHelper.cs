using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for BuzLeanFocalPointHelper
/// 
/// Note: This class is also used to managed List of Corporate Users and their areas of operation.
/// The same database table is shared for both Lean Focal Points and Corporate Overviewers.
/// </summary>
public class BuzLeanFocalPointHelper
{
	public BuzLeanFocalPointHelper()
	{
		//
		// 
		//
	}
    public bool AssignFocalPointToBizUnit(int iUserId, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.assignFocalPointToBusiness();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateFocalPointToBizUnit(int iFocalPointId, int iUserId, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.updateFocalPointToBusiness();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFocalPointId";
        param.Value = iFocalPointId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public DataTable dtGetBusinessUnitFocalPoints(int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBusinessUnitFocalPoints();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iRole";
        param.Value = iRole;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<BusinessLeanFocalPoints> lstGetBusinessUnitFocalPoints(int iRole)
    {
        DataTable dt = dtGetBusinessUnitFocalPoints(iRole);

        List<BusinessLeanFocalPoints> BusinessUnitFocalPoints = new List<BusinessLeanFocalPoints>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            BusinessUnitFocalPoints.Add(new BusinessLeanFocalPoints(dr));
        }
        return BusinessUnitFocalPoints;
    }

    public DataTable dtGetBusinessUnitAssignedByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBusinessUnitFocalPoint();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public BusinessLeanFocalPoints objGetBusinessUnitAssignedByUserId(int iUserId)
    {
        DataTable dt = dtGetBusinessUnitAssignedByUserId(iUserId);
        BusinessLeanFocalPoints oBusinessLeanFocalPoints = new BusinessLeanFocalPoints();
        foreach (DataRow dr in dt.Rows)
        {
            oBusinessLeanFocalPoints = new BusinessLeanFocalPoints(dr);
        }
        return oBusinessLeanFocalPoints;
    }

    public DataTable dtGetBusinessUnitFocalPointsByFunction(int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBusinessUnitFocalPointsByFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<BusinessLeanFocalPoints> lstGetBusinessUnitFocalPointsByFunction(int iFunctionId)
    {
        DataTable dt = dtGetBusinessUnitFocalPointsByFunction(iFunctionId);

        List<BusinessLeanFocalPoints> BusinessUnitFocalPoints = new List<BusinessLeanFocalPoints>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            BusinessUnitFocalPoints.Add(new BusinessLeanFocalPoints(dr));
        }
        return BusinessUnitFocalPoints;
    }
}