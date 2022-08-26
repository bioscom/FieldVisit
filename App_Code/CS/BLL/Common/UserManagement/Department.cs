using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Department
/// </summary>
public class Department
{
    public int m_iDepartmentId { get; set; }
    public string m_sDepartment { get; set; }

	public Department()
	{
		//
		// 
		//
	}

    public Department(DataRow dr)
    {
        m_iDepartmentId = int.Parse(dr["IDDEPARTMENT"].ToString());
        m_sDepartment = dr["DEPARTMENT"].ToString();
    }

    public DataTable dtGetDeparments()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureCommon.getDepartments();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPdccDeparments()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPdccDepartments();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetPdccDeparmentsThatHaveData()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPdccDepartmentsThatHaveData();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetUserAssets(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetUserAssets();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }



    public static DataTable DtGetPdccUserAssets(int iUserId, int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetUserDepartments2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetPdccDeparmentById(int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPdccDepartmentById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDeparmentById(int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureCommon.getDepartmentById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Department objGetDeparmentById(int iDeptId)
    {
        DataTable dt = dtGetDeparmentById(iDeptId);

        Department discipln = new Department();
        foreach (DataRow dr in dt.Rows)
        {
            discipln = new Department(dr);
        }
        return discipln;
    }

    public static Department objGetPdccDeparmentById(int iDeptId)
    {
        DataTable dt = dtGetPdccDeparmentById(iDeptId);

        Department discipln = new Department();
        foreach (DataRow dr in dt.Rows)
        {
            discipln = new Department(dr);
        }
        return discipln;
    }

    public List<Department> lstGetDeparments()
    {
        DataTable dt = dtGetDeparments();

        List<Department> xRows = new List<Department>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new Department(dr));
        }
        return xRows;
    }

    public List<Department> lstGetPdccDeparments()
    {
        DataTable dt = dtGetPdccDeparments();

        List<Department> xRows = new List<Department>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new Department(dr));
        }
        return xRows;
    }
    public List<AssetPdcc> lstGetAssetsByUser(int iUserId)
    {
        DataTable dt = dtGetUserAssets(iUserId);

        List<AssetPdcc> xRows = new List<AssetPdcc>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new AssetPdcc(dr));
        }
        return xRows;
    }

    public static bool BGetIfAssetHasBeenAssignedToUser(int iUserId, int iAssetId)
    {
        bool Found = false;

        DataTable dt = DtGetPdccUserAssets(iUserId, iAssetId);

        if (dt.Rows.Count > 0)
        {
            Found = true;
        }

        return Found;
    }

    public static bool AssignAssetToPdccUser(int iUserId, int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.InsertAssetToPdccUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

}