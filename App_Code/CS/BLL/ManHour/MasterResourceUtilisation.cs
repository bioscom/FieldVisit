using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for MasterResourceUtilisation
/// </summary>

public class MasterResourceUtilisation
{
    public long m_lIdMaster { get; set; }
    public long m_lInitiativeId { get; set; }
    public string m_sInitiative { get; set; }

    public MasterResourceUtilisation()
    {
        //
        // 
        //
    }

    public MasterResourceUtilisation(DataRow dr)
    {
        m_lIdMaster = long.Parse(dr["IDMASTER"].ToString());
        m_lInitiativeId = long.Parse(dr["IDINITIATIVE"].ToString());
        m_sInitiative = dr["INITIATIVE"].ToString();
    }

    public bool CreateMasterResourceUtilisation(long lInitiativeId, string sInitiative)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.CreateMasterResourceUtilisation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":INITIATIVE";
        param.Value = sInitiative;
        param.DbType = DbType.String;
        param.Size = 4000;
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

    public bool UpdateMasterResourceUtilisation(long lMasterId, string sInitiative)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateMasterResourceUtilisation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDMASTER";
        param.Value = lMasterId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":INITIATIVE";
        param.Value = sInitiative;
        param.DbType = DbType.String;
        param.Size = 4000;
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

    public DataTable dtGetMasterResourceUtilisationByInitiative(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getMasterResourceUtilisationByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public MasterResourceUtilisation objGetResourceUtilisationByInitiative(long lMasterId)
    {
        DataTable dt = dtGetMasterResourceUtilisationByInitiative(lMasterId);

        MasterResourceUtilisation xRows = new MasterResourceUtilisation();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new MasterResourceUtilisation(dr);
        }
        return xRows;
    }

    public bool deleteInitiativeId(long lMasterId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.DeleteInitiativeByMasterId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDMASTER";
        param.Value = lMasterId;
        param.DbType = DbType.Int64;
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
