using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for POB
/// </summary>
/// 
namespace PDR
{
    public class POB
    {
        public long lPobId { get; set; }
        public long lReportId { get; set; }
        public int iFacilityId { get; set; }
        public string sCurrentPOB { get; set; }
        public string sCritical { get; set; }
        public string sNonCritical { get; set; }
        public string sRemarks { get; set; }

        public POB()
        {

        }

        public POB(DataRow dr)
        {
            lPobId = long.Parse(dr["IDPOB"].ToString());
            lReportId = long.Parse(dr["IDREPORT"].ToString());
            iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
            sCurrentPOB = dr["CURRENTPOB"].ToString();
            sCritical = dr["CRITICAL"].ToString();
            sNonCritical = dr["NONCRITICAL"].ToString();
            sRemarks = dr["REMARKS"].ToString();
        }
    }

    public class POBHelper
    {
        public POBHelper()
        {

        }

        public static bool Insert(POB oPOB)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertPOB();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oPOB.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oPOB.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCritical";
            param.Value = oPOB.sCritical;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCurrentPOB";
            param.Value = oPOB.sCurrentPOB;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sNonCritical";
            param.Value = oPOB.sNonCritical;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sRemarks";
            param.Value = oPOB.sRemarks;
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

        public static bool Update(POB oPOB)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdatePOB();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oPOB.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oPOB.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCritical";
            param.Value = oPOB.sCritical;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCurrentPOB";
            param.Value = oPOB.sCurrentPOB;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sNonCritical";
            param.Value = oPOB.sNonCritical;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sRemarks";
            param.Value = oPOB.sRemarks;
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

        public static bool Delete(POB oPOB)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oPOB.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oPOB.iFacilityId;
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

        public static DataTable dtGetPOBFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getPOBFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}