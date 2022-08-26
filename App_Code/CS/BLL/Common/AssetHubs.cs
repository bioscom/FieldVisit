using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for AssetHubs
/// </summary>
//public class AssetHubs
//{
//    public AssetHubs()
//    {
//        //
//        // TODO: Add constructor logic here
//        //
//    }
//}



/// <summary>
/// Summary description for Assets
/// </summary>
public class AssetHubs
{
    public int iHubId { get; set; }
    public string sHub { get; set; }

    public AssetHubs()
    {
        //
        // 
        //
    }
    public AssetHubs(DataRow dr)
    {
        iHubId = int.Parse(dr["IDHUB"].ToString());
        sHub = dr["HUB"].ToString();
    }

    public static DataTable dtGetHubs()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getAssetHubs();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static List<AssetHubs> lstGetHubs()
    {
        DataTable dt = dtGetHubs();

        var o = new List<AssetHubs>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new AssetHubs(dr));
        }
        return o;
    }
    //public static DataTable dtGetAssetById(int iAssetId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getAssetById();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iAssetId";
    //    param.Value = iAssetId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}
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
    public static bool createHub(string sAsset, string sLocation)
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
    public static bool updateHub(int iAssetId, string sAsset, string sLocation)
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