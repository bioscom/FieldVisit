using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for TechnicalIntegrity
/// </summary>
/// 
namespace PDR
{
    public class TechnicalIntegrity
    {
        public long lTiId { get; set; }
        public long lReportId { get; set; }
        public int iFacilityId { get; set; }
        public string sPMDue { get; set; }
        public string sPMCompleted { get; set; }
        public string sPMComplaint { get; set; }
        public string sSCEDue { get; set; }
        public string sSCECompleted { get; set; }
        public string sSCEComplaint { get; set; }
        public string sCMDue { get; set; }
        public string sCMCompleted { get; set; }
        public string sCMComplaint { get; set; }
        
        public TechnicalIntegrity()
        {

        }

        public TechnicalIntegrity(DataRow dr)
        {
            lTiId = long.Parse(dr["IDTI"].ToString()); 
            lReportId = long.Parse(dr["IDREPORT"].ToString()); 
            iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
            sPMDue = dr["PMDUE"].ToString();
            sPMCompleted = dr["PMCOMPLETED"].ToString(); 
            sPMComplaint = dr["PMCOMPLAINT"].ToString(); 
            sSCEDue = dr["SCEPMDUE"].ToString(); 
            sSCECompleted = dr["SCEPMCOMPLETED"].ToString(); 
            sSCEComplaint = dr["SCEPMCOMPLAINT"].ToString(); 
            sCMDue = dr["CMDUE"].ToString(); 
            sCMCompleted = dr["CMCOMPLETED"].ToString();
            sCMComplaint = dr["CMCOMPLAINT"].ToString(); 
        }
    }

    public class TechnicalIntegrityHelper
    {
        public TechnicalIntegrityHelper()
        {

        }

        public static bool Insert(TechnicalIntegrity oTechnicalIntegrity)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertTechnicalIntegrity();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oTechnicalIntegrity.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oTechnicalIntegrity.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCMComplaint";
            param.Value = oTechnicalIntegrity.sCMComplaint;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCMCompleted";
            param.Value = oTechnicalIntegrity.sCMCompleted;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCMDue";
            param.Value = oTechnicalIntegrity.sCMDue;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sPMComplaint";
            param.Value = oTechnicalIntegrity.sPMComplaint;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sPMCompleted";
            param.Value = oTechnicalIntegrity.sPMCompleted;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":PMDue";
            param.Value = oTechnicalIntegrity.sPMDue;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sScepmComplaint";
            param.Value = oTechnicalIntegrity.sSCEComplaint;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sScepmCompleted";
            param.Value = oTechnicalIntegrity.sSCECompleted;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sScepmDue";
            param.Value = oTechnicalIntegrity.sSCEDue;
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

        public static bool Update(TechnicalIntegrity oTechnicalIntegrity)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdateTechnicalIntegrity();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oTechnicalIntegrity.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oTechnicalIntegrity.iFacilityId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCMComplaint";
            param.Value = oTechnicalIntegrity.sCMComplaint;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCMCompleted";
            param.Value = oTechnicalIntegrity.sCMCompleted;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCMDue";
            param.Value = oTechnicalIntegrity.sCMDue;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sPMComplaint";
            param.Value = oTechnicalIntegrity.sPMComplaint;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sPMCompleted";
            param.Value = oTechnicalIntegrity.sPMCompleted;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":PMDue";
            param.Value = oTechnicalIntegrity.sPMDue;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sScepmComplaint";
            param.Value = oTechnicalIntegrity.sSCEComplaint;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sScepmCompleted";
            param.Value = oTechnicalIntegrity.sSCECompleted;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sScepmDue";
            param.Value = oTechnicalIntegrity.sSCEDue;
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

        public static bool Delete(TechnicalIntegrity oTechnicalIntegrity)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oTechnicalIntegrity.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFacilityId";
            param.Value = oTechnicalIntegrity.iFacilityId;
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

        public static DataTable dtGetTechIntegrityFacilitiesByDisctrict(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getTechIntegrityFacilitiesByDistrict();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}