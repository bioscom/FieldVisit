using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Assets
/// </summary>
public class Assets
{
    public int iAssetId { get; set; }
    public string sAsset { get; set; }
    public string sLocation { get; set; }

	public Assets()
	{
		//
		// 
		//
	}
    public Assets(DataRow dr)
    {
        iAssetId = int.Parse(dr["IDASSET"].ToString());
        sAsset = dr["ASSETS"].ToString();
        sLocation = dr["LOCATION"].ToString();
    }
    public static DataTable dtGetAssets()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getAssets();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static List<Assets> lstGetAssets()
    {
        DataTable dt = dtGetAssets();

        List<Assets> asset = new List<Assets>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new Assets(dr));
        }
        return asset;
    }

    public static Assets objGetAssetById(int iAssetId)
    {
        DataTable dt = dtGetAssetById(iAssetId);

        Assets o = new Assets();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Assets(dr);
        }
        return o;
    }

    public static DataTable dtGetAssetById(int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getAssetById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static DataTable dtGetAssetByOUId(int iOuId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getAssetByOuId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iOuId";
        param.Value = iOuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
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