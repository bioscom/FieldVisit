using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using CS.DAL;

/// <summary>
/// Summary description for FunctionAsset
/// </summary>

namespace CS.BLL.PPMS
{
    public class FunctionAsset
    {
        public int AssetId { get; set; }
        public string SAsset { get; set; }

        public FunctionAsset()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public FunctionAsset(DataRow dr)
        {
            AssetId = int.Parse(dr["ASSETID"].ToString());
            SAsset = dr["ASSET"].ToString();
        }
    }

    public class FunctionAssetHelper
    {
        public static bool InsertAsset(string sAsset, ref int iAssetId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.InsertAsset();

            iAssetId = GetAssetId();

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

            var result = -1;

            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

            return (result != -1);
        }

        private static int GetAssetId()
        {
            string sql = "SELECT PPMS_ASSET_SEQ.NEXTVAL FROM DUAL";
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sql;

            int iAssetId = 0;
            try
            {
                DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
                iAssetId = Convert.ToInt32(dt.Rows[0]["NEXTVAL"].ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

            return iAssetId;
        }



        public static DataTable DtGetAssets()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetAssets();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static DataTable DtGetAssetById(int iAssetId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetAssetById();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iAssetId";
            param.Value = iAssetId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static FunctionAsset ObjGetAssetById(int iAssetId)
        {
            DataTable dt = DtGetAssetById(iAssetId);

            FunctionAsset oFunctionAsset = new FunctionAsset();
            foreach (DataRow dr in dt.Rows)
            {
                oFunctionAsset = new FunctionAsset(dr);
            }
            return oFunctionAsset;
        }

        public static List<FunctionAsset> LstGetAssets()
        {
            DataTable dt = DtGetAssets();

            List<FunctionAsset> lstAssets = new List<FunctionAsset>(dt.Rows.Count);
            lstAssets.AddRange(from DataRow dr in dt.Rows select new FunctionAsset(dr));
            return lstAssets;
        }
    }

}