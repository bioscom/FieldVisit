using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for PTWSummary
/// </summary>
/// 
namespace PDR
{
    public class PTWSummary
    {
        public long lPtwId { get; set; }
        public long lReportId { get; set; }
        public string sActive { get; set; }
        public string sSuspended { get; set; }
        public string sClosed { get; set; }
        public string sEPI { get; set; }
        public string sAuthorised { get; set; }
        public string sExpired { get; set; }
        public string sCancelled { get; set; }

        public PTWSummary()
        {

        }

        public PTWSummary(DataRow dr)
        {
            lPtwId = long.Parse(dr["IDPTW"].ToString());
            lReportId = long.Parse(dr["IDREPORT"].ToString());
            sActive = dr["ACTIVE"].ToString();
            sSuspended = dr["SUSPENDED"].ToString();
            sClosed = dr["CLOSED"].ToString();
            sEPI = dr["EPI"].ToString();
            sAuthorised = dr["AUTHORIZED"].ToString();
            sExpired = dr["EXPIRED"].ToString();
            sCancelled = dr["CANCELLED"].ToString();
        }
    }

    public class PTWSummaryHelper
    {
        public PTWSummaryHelper()
        {

        }

        public static bool Insert(PTWSummary oPTWSummary)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oPTWSummary.lReportId;
            param.DbType = DbType.Int64;
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

        public static bool Update(PTWSummary oPTWSummary)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdatePTWSummary();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oPTWSummary.lReportId;
            param.DbType = DbType.Int64;
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

        public static bool Delete(PTWSummary oPTWSummary)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oPTWSummary.lReportId;
            param.DbType = DbType.Int64;
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

        public static DataTable dtGetPTWSummaryFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getPTWSummaryFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}