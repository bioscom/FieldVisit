using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for HSSEGoalZero
/// </summary>
/// 
namespace PDR
{
    public class HSSEGoalZero
    {
        public long lHsseId { get; set; }
        public long lReportId { get; set; }
        public int iFacilityId { get; set; }
        public string sLTI { get; set; }
        public string sGoalZeroDays { get; set; }
        public string sZeroPlantDays { get; set; }
        public string sFountainAssurance { get; set; }
        public string sSOL { get; set; }
        public string sLTIRemarks { get; set; }
        public string sGoalZeroDaysRemarks { get; set; }
        public string sZeroPlantDaysRemarks { get; set; }
        public string sFountainAssuranceRemarks { get; set; }
        public string sSOLRemarks { get; set; }

        public HSSEGoalZero()
        {

        }
        public HSSEGoalZero(DataRow dr)
        {
            lHsseId = long.Parse(dr["IDHSSE"].ToString());
            lReportId = long.Parse(dr["IDREPORT"].ToString());
            iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
            sLTI = dr["LTI"].ToString();
            sGoalZeroDays = dr["GOALZERODAYS"].ToString();
            sZeroPlantDays = dr["ZEROPLANTDAYS"].ToString();
            sFountainAssurance = dr["FOUNTASSURANCE"].ToString();
            sSOL = dr["SOL"].ToString();
            sLTIRemarks = dr["LTIREMARKS"].ToString();
            sGoalZeroDaysRemarks = dr["GOALZEROREMARKS"].ToString();
            sZeroPlantDaysRemarks = dr["ZEROPLANTREMARKS"].ToString();
            sFountainAssuranceRemarks = dr["FOUNTREMARKS"].ToString();
            sSOLRemarks = dr["SOLREMARKS"].ToString();
        }
    }

    public class HSSEGoalZeroHelper
    {
        public HSSEGoalZeroHelper()
        {

        }

        public static bool Insert(HSSEGoalZero oHSSEGoalZero)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertGoalZero();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oHSSEGoalZero.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oHSSEGoalZero.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLti";
            param.Value = oHSSEGoalZero.sLTI;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGoalZeroDays";
            param.Value = oHSSEGoalZero.sGoalZeroDays;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sZeroPlantDays";
            param.Value = oHSSEGoalZero.sZeroPlantDays;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFountainAssurance";
            param.Value = oHSSEGoalZero.sFountainAssurance;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSol";
            param.Value = oHSSEGoalZero.sSOL;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLtiRemarks";
            param.Value = oHSSEGoalZero.sLTIRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGoalZeroRemarks";
            param.Value = oHSSEGoalZero.sGoalZeroDaysRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sZeroPlantRemarks";
            param.Value = oHSSEGoalZero.sZeroPlantDaysRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFountainRemarks";
            param.Value = oHSSEGoalZero.sFountainAssuranceRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSolRemarks";
            param.Value = oHSSEGoalZero.sSOLRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
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

        public static bool Update(HSSEGoalZero oHSSEGoalZero)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdateGoalZero();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oHSSEGoalZero.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oHSSEGoalZero.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLti";
            param.Value = oHSSEGoalZero.sLTI;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGoalZeroDays";
            param.Value = oHSSEGoalZero.sGoalZeroDays;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sZeroPlantDays";
            param.Value = oHSSEGoalZero.sZeroPlantDays;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFountainAssurance";
            param.Value = oHSSEGoalZero.sFountainAssurance;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSol";
            param.Value = oHSSEGoalZero.sSOL;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLtiRemarks";
            param.Value = oHSSEGoalZero.sLTIRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sGoalZeroRemarks";
            param.Value = oHSSEGoalZero.sGoalZeroDaysRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sZeroPlantRemarks";
            param.Value = oHSSEGoalZero.sZeroPlantDaysRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFountainRemarks";
            param.Value = oHSSEGoalZero.sFountainAssuranceRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSolRemarks";
            param.Value = oHSSEGoalZero.sSOLRemarks;
            param.DbType = DbType.String;
            param.Size = 2000;
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

        public static bool Delete(HSSEGoalZero oHSSEGoalZero)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oHSSEGoalZero.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oHSSEGoalZero.iFacilityId;
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

        public static DataTable dtGetHSSEFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getHSSEFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}