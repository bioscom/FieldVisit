using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


/// <summary>
/// Summary description for District
/// </summary>
public class District
{
    public int m_iDistrictId { get; set; }
    public int m_iSuperintendentId { get; set; }
    public string m_sDistrict { get; set; }
    public Superintendent eSuperintendent
    {
        get
        {
            return Superintendent.objGetSuperintendentById(m_iSuperintendentId);
        }
    }

    public District()
    {
        //
        //
    }

    public District(DataRow dr)
    {
        m_iDistrictId = int.Parse(dr["ID_DISTRICT"].ToString());
        m_iSuperintendentId = int.Parse(dr["ID_SUPERINTENDENT"].ToString());
        m_sDistrict = dr["DISTRICT"].ToString();
    }

    public static DataTable dtGetDistrict()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistricts();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictExt()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictsExt();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictDetails()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictDetails();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictByAssetId(int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictByAssetId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictById(int DistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = DistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictByName(string sDistrict)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictByName();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sDistrict";
        param.Value = sDistrict;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictDetailsById(int DistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictDetailsById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = DistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictBySuperintendent(int SuperintendentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictBySuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = SuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static District objGetDistrictById(int DistrictId)
    {
        DataTable dt = dtGetDistrictById(DistrictId);

        District asset = new District();
        foreach (DataRow dr in dt.Rows)
        {
            asset = new District(dr);
        }
        return asset;
    }

    public static District objGetDistrictByName(string sDistrict)
    {
        DataTable dt = dtGetDistrictByName(sDistrict);

        District oDistrict = new District();
        foreach (DataRow dr in dt.Rows)
        {
            oDistrict = new District(dr);
        }
        return oDistrict;
    }

    public static List<District> lstGetDistrict()
    {
        DataTable dt = dtGetDistrict();

        List<District> asset = new List<District>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new District(dr));
        }
        return asset;
    }

    public static List<District> lstGetDistrictByAsset(int iAssetId)
    {
        DataTable dt = dtGetDistrictByAssetId(iAssetId);

        List<District> asset = new List<District>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new District(dr));
        }
        return asset;
    }
    public static DataTable dtGetAssetByDistrictId(int iDistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getAssetByDistrictId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static DistrictExt objGetAssetByDistrictId(int iDistrictId)
    {
        DataTable dt = dtGetAssetByDistrictId(iDistrictId);

        DistrictExt asset = new DistrictExt();
        foreach (DataRow dr in dt.Rows)
        {
            asset = new DistrictExt(dr);
        }
        return asset;
    }

    public static List<DistrictExt> lstGetDistrictExt()
    {
        DataTable dt = dtGetDistrictExt();

        List<DistrictExt> xRow = new List<DistrictExt>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRow.Add(new DistrictExt(dr));
        }
        return xRow;
    }

    public static List<DistrictExt> lstGetDistrictExtByAsset(int iAssetId)
    {
        DataTable dt = dtGetDistrictByAssetId(iAssetId);

        List<DistrictExt> xRow = new List<DistrictExt>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRow.Add(new DistrictExt(dr));
        }
        return xRow;
    }

    public static List<District> lstGetDistrictBySuperintendent(int superintendentId)
    {
        DataTable dt = dtGetDistrictBySuperintendent(superintendentId);

        List<District> asset = new List<District>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new District(dr));
        }
        return asset;
    }

    public static bool bGetIfDistrictHasBeenAssignedToSuperintendent(int iUserId, int iDistrictId)
    {
        bool Found = false;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getDistrictAssignedToSuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        if (GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count > 0)
        {
            Found = true;
        }

        return Found;
    }

    public static bool AssignDistrictToSuperintendent(int iUserId, int iDistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.InsertDistrictSuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
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

    public static bool createDistrict(int iSuperintendentId, string sDistrict)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertDistrict();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DISTRICT";
        param.Value = sDistrict;
        param.DbType = DbType.String;
        param.Size = 1000;
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

    public static bool updateDistrict(int iSuperintendentId, int iDistrictId, string sDistrict)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateDistrict();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DISTRICT";
        param.Value = sDistrict;
        param.DbType = DbType.String;
        param.Size = 500;
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


    public static DataTable dtGetAssetByOU()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getDistrictsByOU();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDistrictByOU()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getDistrictsByOU();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public static DataTable dtGetDistrictDetails()
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getDistrictDetails();

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetDistrictById(int DistrictId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getDistrictById();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_DISTRICT";
    //    param.Value = DistrictId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetDistrictByInitiativeId(long lInitiativeId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getDistrictByInitiativeId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":lInitiativeId";
    //    param.Value = lInitiativeId;
    //    param.DbType = DbType.Int64;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetDistrictDetailsById(int DistrictId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getDistrictDetailsById();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_DISTRICT";
    //    param.Value = DistrictId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetDistrictBySuperintendent(int SuperintendentId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getDistrictBySuperintendent();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_SUPERINTENDENT";
    //    param.Value = SuperintendentId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static District objGetDistrictById(int DistrictId)
    //{
    //    DataTable dt = dtGetDistrictById(DistrictId);

    //    District asset = new District();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset = new District(dr);
    //    }
    //    return asset;
    //}

    //public static List<District> lstGetDistrict()
    //{
    //    DataTable dt = dtGetDistrictByOU();

    //    List<District> asset = new List<District>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset.Add(new District(dr));
    //    }
    //    return asset;
    //}

    //public static List<District> lstGetDistrictBySuperintendent(int superintendentId)
    //{
    //    DataTable dt = dtGetDistrictBySuperintendent(superintendentId);

    //    List<District> asset = new List<District>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset.Add(new District(dr));
    //    }
    //    return asset;
    //}
}


public class DistrictExt
{
    public int m_iDistrictId { get; set; }
    public string m_sDistrict { get; set; }
    public int m_iAssetId { get; set; }
    public string m_sAsset { get; set; }
    

    //string sql = "SELECT PROD_ASSET.IDASSET, PROD_ASSET.ASSETS, PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT ";
    //    sql += "FROM PROD_DISTRICT INNER JOIN PROD_ASSET ON PROD_ASSET.IDASSET = PROD_DISTRICT.IDASSET";

    public DistrictExt()
    {
        //
        //
    }

    public DistrictExt(DataRow dr)
    {
        m_iDistrictId = int.Parse(dr["ID_DISTRICT"].ToString());
        m_sDistrict = dr["DISTRICT"].ToString();
        m_iAssetId = int.Parse(dr["IDASSET"].ToString());
        m_sAsset = dr["ASSETS"].ToString();
    }
}

