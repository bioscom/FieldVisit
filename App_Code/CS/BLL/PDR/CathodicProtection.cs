using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for CathodicProtection
/// </summary>
/// 
namespace PDR
{
    public class CathodicProtection
    {
        public long lCathodicId { get; set; }
        public long lReportId { get; set; }
        public int iFacilityId { get; set; }
        public string sCurrent { get; set; }
        public string sVoltage { get; set; }
        public string sSilcaGelStandard { get; set; }
        public string sSilcaGelActual { get; set; }

        public CathodicProtection()
        {

        }

        public CathodicProtection(DataRow dr)
        {
            lCathodicId = long.Parse(dr["IDCATHODIC"].ToString());
            lReportId =long.Parse(dr["IDREPORT"].ToString());
            iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
            sCurrent = dr["CURRENTS"].ToString();
            sVoltage = dr["VOLTAGE"].ToString();
            sSilcaGelStandard = dr["SILCALGELSTANDARD"].ToString();
            sSilcaGelActual = dr["SILCAGELACTUAL"].ToString();
        }
    }

    public class CathodicProtectionHelper
    {
        public CathodicProtectionHelper()
        {

        }

        public static bool Insert(CathodicProtection oCathodicProtection)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertCathodicProtection();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oCathodicProtection.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oCathodicProtection.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCurrents";
            param.Value = oCathodicProtection.sCurrent;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSilcagelActual";
            param.Value = oCathodicProtection.sSilcaGelActual;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSilcaGel"; 
            param.Value = oCathodicProtection.sSilcaGelStandard;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sVoltage";
            param.Value = oCathodicProtection.sVoltage;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            int result = -1;

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

        public static bool Update(CathodicProtection oCathodicProtection)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdateCathodicProtection();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oCathodicProtection.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oCathodicProtection.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCurrents";
            param.Value = oCathodicProtection.sCurrent;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSilcagelActual";
            param.Value = oCathodicProtection.sSilcaGelActual;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSilcaGel";
            param.Value = oCathodicProtection.sSilcaGelStandard;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sVoltage";
            param.Value = oCathodicProtection.sVoltage;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            int result = -1;

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

        public static bool Delete(CathodicProtection oCathodicProtection)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oCathodicProtection.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oCathodicProtection.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

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

        public static DataTable dtGetcathodicprotectionFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getCathodicProtectionFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}