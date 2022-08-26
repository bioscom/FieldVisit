using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for GeneratorAirCompressorStatus
/// </summary>
/// 
namespace PDR
{
    public class GeneratorAirCompressorStatus
    {
        public long lGenId { get; set; }
        public long lReportId { get; set; }
        public int iFacilityId { get; set; }
        public string sGen1 { get; set; }
        public string sGen2 { get; set; }
        public string sGen3 { get; set; }
        public string sDieselGen1 { get; set; }
        public string sDieselGen2 { get; set; }
        public string sAirCompressor1 { get; set; }
        public string sAirCompressor2 { get; set; }
        public string sAirCompressor3 { get; set; }
        public string sAirCompressor4 { get; set; }
        public GeneratorAirCompressorStatus()
        {

        }

        public GeneratorAirCompressorStatus(DataRow dr)
        {
            lGenId = long.Parse(dr["IDGEN"].ToString());
            lReportId = long.Parse(dr["IDREPORT"].ToString());
            iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
            sGen1 = dr["GEN1"].ToString();
            sGen2 = dr["GEN2"].ToString();
            sGen3 = dr["GEN3"].ToString();
            sDieselGen1 = dr["DIESELGEN1"].ToString();
            sDieselGen2 = dr["DIESELGEN2"].ToString();
            sAirCompressor1 = dr["AIRCOMP1"].ToString();
            sAirCompressor2 = dr["AIRCOMP2"].ToString();
            sAirCompressor3 = dr["AIRCOMP3"].ToString();
            sAirCompressor4 = dr["AIRCOMP4"].ToString();
        }
    }

    public class GeneratorAirCompressorStatusHelper
    {
        public GeneratorAirCompressorStatusHelper()
        {

        }

        public static bool Insert(GeneratorAirCompressorStatus oGeneratorAirCompressorStatus)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertGenAirCompressor();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oGeneratorAirCompressorStatus.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oGeneratorAirCompressorStatus.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor1";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor1;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor2";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor2;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor3";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor3;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor4";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor4;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sDieselGen1";
            param.Value = oGeneratorAirCompressorStatus.sDieselGen1;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sDieselGen2";
            param.Value = oGeneratorAirCompressorStatus.sDieselGen2;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGen1";
            param.Value = oGeneratorAirCompressorStatus.sGen1;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGen2";
            param.Value = oGeneratorAirCompressorStatus.sGen2;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGen3";
            param.Value = oGeneratorAirCompressorStatus.sGen3;
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

        public static bool Update(GeneratorAirCompressorStatus oGeneratorAirCompressorStatus)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdateGenAirCompressor();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oGeneratorAirCompressorStatus.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oGeneratorAirCompressorStatus.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor1";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor1;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor2";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor2;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor3";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor3;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAirCompressor4";
            param.Value = oGeneratorAirCompressorStatus.sAirCompressor4;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sDieselGen1";
            param.Value = oGeneratorAirCompressorStatus.sDieselGen1;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sDieselGen2";
            param.Value = oGeneratorAirCompressorStatus.sDieselGen2;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGen1";
            param.Value = oGeneratorAirCompressorStatus.sGen1;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGen2";
            param.Value = oGeneratorAirCompressorStatus.sGen2;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGen3";
            param.Value = oGeneratorAirCompressorStatus.sGen3;
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

        public static bool Delete(GeneratorAirCompressorStatus oGeneratorAirCompressorStatus)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oGeneratorAirCompressorStatus.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oGeneratorAirCompressorStatus.iFacilityId;
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

        public static DataTable dtGetGenAirCompressorFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getGenAirCompressorFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}