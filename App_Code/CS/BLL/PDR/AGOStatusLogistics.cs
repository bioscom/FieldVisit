using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for AGOStatusLogistics
/// </summary>
/// 
namespace PDR
{
    public class AGOStatusLogistics
    {
        public long lAgoId { get; set; }
        public long lReportId { get; set; }
        public int iFacilityId { get; set; }
        public string sActualStock { get; set; }
        public string sIssuedComsumed { get; set; }
        public string sEndurance { get; set; }
        public string sBoatAvailability { get; set; }

        public AGOStatusLogistics()
        {

        }

        public AGOStatusLogistics(DataRow dr)
        {
            lAgoId = long.Parse(dr["IDAGO"].ToString());
            lReportId = long.Parse(dr["IDREPORT"].ToString());
            iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
            sActualStock = dr["ACTUALSTOCK"].ToString();
            sIssuedComsumed = dr["ISSUEDCONSUMED"].ToString();
            sEndurance = dr["ENDURANCE"].ToString();
            sBoatAvailability = dr["BOATAVAILABILITY"].ToString();
        }
    }

    public class AGOStatusLogisticsHelper
    {
        public AGOStatusLogisticsHelper()
        {

        }

        public static bool Insert(AGOStatusLogistics oAGOStatusLogistics)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertAGOStatus();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oAGOStatusLogistics.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oAGOStatusLogistics.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            
            param = comm.CreateParameter();
            param.ParameterName = ":sActualStock";
            param.Value = oAGOStatusLogistics.sActualStock;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sBoatAvailability";
            param.Value = oAGOStatusLogistics.sBoatAvailability;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sEndurance";
            param.Value = oAGOStatusLogistics.sEndurance;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sIssuedConsumed";
            param.Value = oAGOStatusLogistics.sIssuedComsumed;
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

        public static bool Update(AGOStatusLogistics oAGOStatusLogistics)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdateAGOStatus();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oAGOStatusLogistics.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oAGOStatusLogistics.iFacilityId;
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

        public static bool Delete(AGOStatusLogistics oAGOStatusLogistics)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oAGOStatusLogistics.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oAGOStatusLogistics.iFacilityId;
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

        public static DataTable dtGetAGOStatusFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getAGOStatusFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}