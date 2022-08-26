using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for AssetPdcc
/// </summary>

public class AssetPdcc
{
    public int iDeptId { get; set; }
    public int iAssetId { get; set; }
    public string sAsset { get; set; }
    public int iServiceId { get; set; }
    public int iOuId { get; set; }

	public AssetPdcc()
	{
		//
		// 
		//
	}

    public AssetPdcc(DataRow dr)
    {
        iDeptId = int.Parse(dr["IDDEPARTMENT"].ToString());
        iAssetId = int.Parse(dr["ASSETID"].ToString());
        sAsset = dr["ASSET"].ToString();
        iServiceId = int.Parse(dr["IDSERVICE"].ToString());
        iOuId = int.Parse(dr["IDOU"].ToString());
    }
    public static DataTable dtGetAssets()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getAssets();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static DataTable dtGetAssetById(int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getAssetById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static AssetPdcc objGetAssetById(int iAssetId)
    {
        DataTable dt = dtGetAssetById(iAssetId);

        AssetPdcc asset = new AssetPdcc();
        foreach (DataRow dr in dt.Rows)
        {
            asset = new AssetPdcc(dr);
        }
        return asset;
    }
    public static List<AssetPdcc> lstGetAssets()
    {
        DataTable dt = dtGetAssets();

        List<AssetPdcc> asset = new List<AssetPdcc>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new AssetPdcc(dr));
        }
        return asset;
    }

    public DataTable dtGetUserPdccAssets(int iUserId, int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetUserPdccAssets(iRoleId);

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<AssetPdcc> lstGetPdccAssetsByUser(int iUserId, int iRoleId)
    {
        DataTable dt = dtGetUserPdccAssets(iUserId, iRoleId);

        List<AssetPdcc> xRows = new List<AssetPdcc>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new AssetPdcc(dr));
        }
        return xRows;
    }

    //public static DataTable dtGetAssetByOUId(int iOuId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getAssetByOuId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iOuId";
    //    param.Value = iOuId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}
    public static bool createAsset(string sAsset, string sLocation)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertAsset();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sAsset";
        param.Value = sAsset;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sLocation";
        param.Value = sLocation;
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
    public static bool updateAsset(int iAssetId, string sAsset, string sLocation)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateDistrict();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sAsset";
        param.Value = sAsset;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sLocation";
        param.Value = sLocation;
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
}