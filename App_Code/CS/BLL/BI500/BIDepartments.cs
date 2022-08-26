using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for BIDepartments
/// </summary>
public class BIDepartments
{
    public int m_iDepartmentId { get; set; }
    public int m_iFunctionId { get; set; }
    public string m_sDepartment { get; set; }

	public BIDepartments()
	{
		//
		// 
		//
	}

    public BIDepartments(DataRow dr)
    {
        m_iDepartmentId = int.Parse(dr["DEPTID"].ToString());
        m_iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());
        m_sDepartment = dr["DEPARTMENT"].ToString();
    }

    public static DataTable dtGetDeparmentsById(int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getDepartmentById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDeparmentsByFunction(int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getDepartmentByFunctionId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<BIDepartments> lstGetDeparmentsByFunction(int iFunctionId)
    {
        DataTable dt = dtGetDeparmentsByFunction(iFunctionId);

        List<BIDepartments> o = new List<BIDepartments>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new BIDepartments(dr));
        }
        return o;
    }

    public BIDepartments objGetDepartmentById(int iDeptId)
    {
        DataTable dt = dtGetDeparmentsById(iDeptId);

        BIDepartments o = new BIDepartments();
        foreach (DataRow dr in dt.Rows)
        {
            o = new BIDepartments(dr);
        }
        return o;
    }

    public static bool AddNewDepartment(BIDepartments o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AddNewDepartment();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = o.m_iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDepartment";
        param.Value = o.m_sDepartment;
        param.DbType = DbType.String;
        param.Size = 2000;
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

    //public DataTable dtGetPdccDeparments()
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.getPdccDepartments();

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public DataTable dtGetPdccDeparmentsThatHaveData()
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.getPdccDepartmentsThatHaveData();

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public DataTable dtGetUserAssets(int iUserId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.GetUserAssets();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iUserId";
    //    param.Value = iUserId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable DtGetPdccUserAssets(int iUserId, int iAssetId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.GetUserDepartments2();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iUserId";
    //    param.Value = iUserId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":iAssetId";
    //    param.Value = iAssetId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetPdccDeparmentById(int iDeptId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.getPdccDepartmentById();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iDeptId";
    //    param.Value = iDeptId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public DataTable dtGetDeparmentById(int iDeptId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureCommon.getDepartmentById();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iDeptId";
    //    param.Value = iDeptId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public Department objGetDeparmentById(int iDeptId)
    //{
    //    DataTable dt = dtGetDeparmentById(iDeptId);

    //    Department discipln = new Department();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        discipln = new Department(dr);
    //    }
    //    return discipln;
    //}

    //public static Department objGetPdccDeparmentById(int iDeptId)
    //{
    //    DataTable dt = dtGetPdccDeparmentById(iDeptId);

    //    Department discipln = new Department();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        discipln = new Department(dr);
    //    }
    //    return discipln;
    //}

    //public List<Department> lstGetPdccDeparments()
    //{
    //    DataTable dt = dtGetPdccDeparments();

    //    List<Department> xRows = new List<Department>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        xRows.Add(new Department(dr));
    //    }
    //    return xRows;
    //}

    //public List<AssetPdcc> lstGetAssetsByUser(int iUserId)
    //{
    //    DataTable dt = dtGetUserAssets(iUserId);

    //    List<AssetPdcc> xRows = new List<AssetPdcc>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        xRows.Add(new AssetPdcc(dr));
    //    }
    //    return xRows;
    //}

    //public static bool BGetIfAssetHasBeenAssignedToUser(int iUserId, int iAssetId)
    //{
    //    bool Found = false;

    //    DataTable dt = DtGetPdccUserAssets(iUserId, iAssetId);

    //    if (dt.Rows.Count > 0)
    //    {
    //        Found = true;
    //    }

    //    return Found;
    //}

    //public static bool AssignAssetToPdccUser(int iUserId, int iAssetId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.InsertAssetToPdccUser();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iUserId";
    //    param.Value = iUserId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":iAssetId";
    //    param.Value = iAssetId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    int result = -1;

    //    try
    //    {
    //        // execute the stored procedure
    //        result = GenericDataAccess.ExecuteNonQuery(comm);
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show(ex.Message.ToString());
    //        // any errors are logged in GenericDataAccess, we ignore them here
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //    // result will be 1 in case of success
    //    return (result != -1);
    //}

}

public class BITeams
{
    public int m_iDepartmentId { get; set; }
    public int m_iTeamId { get; set; }
    public string m_sTeam { get; set; }

    public BITeams()
    {
        //
        // 
        //
    }

    public BITeams(DataRow dr)
    {
        m_iTeamId = int.Parse(dr["TEAMID"].ToString());
        m_iDepartmentId = int.Parse(dr["DEPTID"].ToString());
        m_sTeam = dr["TEAM"].ToString();
    }

    public BITeams objGetTeamById(int iTeamId)
    {
        DataTable dt = dtGetTeamById(iTeamId);

        BITeams o = new BITeams();
        foreach (DataRow dr in dt.Rows)
        {
            o = new BITeams(dr);
        }
        return o;
    }

    public static DataTable dtGetTeams()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getTeams();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetTeamById(int iTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getTeamById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetTeamsByDepartment(int iDepartmentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getTeamsByDepartmentId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDepartmentId";
        param.Value = iDepartmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<BITeams> lstGetTeamsByDepartment(int iDepartmentId)
    {
        DataTable dt = dtGetTeamsByDepartment(iDepartmentId);

        List<BITeams> o = new List<BITeams>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new BITeams(dr));
        }
        return o;
    }

    public static List<BITeams> lstGetTeams()
    {
        DataTable dt = dtGetTeams();

        List<BITeams> o = new List<BITeams>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new BITeams(dr));
        }
        return o;
    }

    public static bool AddNewTeam(BITeams o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AddNewTeam();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDepartmentId";
        param.Value = o.m_iDepartmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTeam";
        param.Value = o.m_sTeam;
        param.DbType = DbType.String;
        param.Size = 2000;
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

public class BIUserTeam
{
    public int m_iId { get; set; }
    public int m_iUserId { get; set; }
    public int m_iTeamId { get; set; }

    public BIUserTeam()
    {
        //
        // 
        //
    }

    public BIUserTeam(DataRow dr)
    {
        m_iId = int.Parse(dr["ID"].ToString());
        m_iTeamId = int.Parse(dr["TEAMID"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
    }

    public static List<BIUserTeam> lstGetTeamMembersById(int iTeamId)
    {
        DataTable dt = dtGetTeamMembersById(iTeamId);

        List<BIUserTeam> o = new List<BIUserTeam>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new BIUserTeam(dr));
        }
        return o;
    }

    public static DataTable dtGetTeamMembersById(int iTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getTeamMembersById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetTeamByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getTeamByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public BIUserTeam objGetTeamByUserId(int iUserId)
    {
        DataTable dt = dtGetTeamByUserId(iUserId);

        BIUserTeam o = new BIUserTeam();
        foreach (DataRow dr in dt.Rows)
        {
            o = new BIUserTeam(dr);
        }
        return o;
    }

    public bool AddNewTeamMember(BIUserTeam o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.AddTeamMember();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.m_iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = o.m_iUserId;
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

    public bool UpdateTeamMember(BIUserTeam o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateTeamMember();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.m_iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = o.m_iUserId;
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
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }


}