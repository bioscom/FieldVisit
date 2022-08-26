using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for WellTestSampleStatus
/// </summary>
/// 
namespace PDR
{
    public class WellTestSampleStatus
    {
        public long lWellId { get; set; }
        public long lReportId { get; set; }
        public int iFacilityId { get; set; }
        public string sWellOnProgram { get; set; }
        public string sWellsFlowingStart { get; set; }
        public string sWellsFlowingCurrent { get; set; }
        public string sCummulatedWellTested { get; set; }
        public string sWellSampled { get; set; }
        public string sMerPlan { get; set; }
        public string sMerActual { get; set; }

        public WellTestSampleStatus()
        {

        }

        public WellTestSampleStatus(DataRow dr)
        {
            lWellId = long.Parse(dr["IDWELL"].ToString());
            lReportId = long.Parse(dr["IDREPORT"].ToString());
            iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
            sWellOnProgram = dr["WELLONPROGRAM"].ToString();
            sWellsFlowingStart = dr["WELLSFLOWINGSTART"].ToString();
            sWellsFlowingCurrent = dr["WELLSFLOWINGCURRENT"].ToString();
            sCummulatedWellTested = dr["CUMMWELLTESTED"].ToString();
            sWellSampled = dr["WELLSAMPLED"].ToString();
            sMerPlan = dr["MERPLAN"].ToString();
            sMerActual = dr["MERACTUAL"].ToString();
        }
    }

    public class WellTestSampleStatusHelper
    {
        public WellTestSampleStatusHelper()
        {

        }

        public static bool Insert(WellTestSampleStatus oWellTestSampleStatus)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertWellTestStatus();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oWellTestSampleStatus.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oWellTestSampleStatus.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCummWellTested";
            param.Value = oWellTestSampleStatus.sCummulatedWellTested;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sMerActual";
            param.Value = oWellTestSampleStatus.sMerActual;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sMerPlan";
            param.Value = oWellTestSampleStatus.sMerPlan;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellOnprogram";
            param.Value = oWellTestSampleStatus.sWellOnProgram;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellSampled";
            param.Value = oWellTestSampleStatus.sWellSampled;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellsFlowingCurrent";
            param.Value = oWellTestSampleStatus.sWellsFlowingCurrent;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellsFlowingStart";
            param.Value = oWellTestSampleStatus.sWellsFlowingStart;
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

        public static bool Update(WellTestSampleStatus oWellTestSampleStatus)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdateWellTestStatus();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oWellTestSampleStatus.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oWellTestSampleStatus.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCummWellTested";
            param.Value = oWellTestSampleStatus.sCummulatedWellTested;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sMerActual";
            param.Value = oWellTestSampleStatus.sMerActual;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sMerPlan";
            param.Value = oWellTestSampleStatus.sMerPlan;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellOnprogram";
            param.Value = oWellTestSampleStatus.sWellOnProgram;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellSampled";
            param.Value = oWellTestSampleStatus.sWellSampled;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellsFlowingCurrent";
            param.Value = oWellTestSampleStatus.sWellsFlowingCurrent;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sWellsFlowingStart";
            param.Value = oWellTestSampleStatus.sWellsFlowingStart;
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

        public static bool Delete(WellTestSampleStatus oWellTestSampleStatus)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oWellTestSampleStatus.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oWellTestSampleStatus.iFacilityId;
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

        public static DataTable dtGetWelltestSampleStatusFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getWellTestStatusFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}