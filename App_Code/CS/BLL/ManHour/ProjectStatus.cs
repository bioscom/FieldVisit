using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ProjectStatus
/// </summary>
public class ProjectCurrentStatus
{
    public long lStatusId { get; set; }
    public long lInitiativeId { get; set; }
    public string sStatus { get; set; }
    public string sLEC { get; set; }
    public string sChallenges { get; set; }
    public string sComments { get; set; }

    public ProjectCurrentStatus()
    {
        //
        // 
        //
    }

    public ProjectCurrentStatus(DataRow dr)
    {
        lStatusId = long.Parse(dr["IDSTATUS"].ToString());
        lInitiativeId = long.Parse(dr["IDINITIATIVE"].ToString());
        sStatus = dr["STATUS"].ToString();
        sLEC = dr["LEC"].ToString();
        sChallenges = dr["CHALLENGES"].ToString();
        sComments = dr["COMMENTS"].ToString();
    }
}

public class ProjectCurrentStatusHelper
{
    public ProjectCurrentStatusHelper()
    {

    }

    public bool InsertProjectCurrentStatus(ProjectCurrentStatus oProjectCurrentStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.InsertProjectCurrentStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = oProjectCurrentStatus.lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStatus";
        param.Value = oProjectCurrentStatus.sStatus;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sLEC";
        param.Value = oProjectCurrentStatus.sLEC;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sChallenges";
        param.Value = oProjectCurrentStatus.sChallenges;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oProjectCurrentStatus.sComments;
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

    public bool UpdateProjectCurrentStatus(ProjectCurrentStatus oProjectCurrentStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateProjectCurrentStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lStatusId";
        param.Value = oProjectCurrentStatus.lStatusId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":lInitiativeId";
        //param.Value = oProjectCurrentStatus.lInitiativeId;
        //param.DbType = DbType.Int64;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sChallenges";
        param.Value = oProjectCurrentStatus.sChallenges;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oProjectCurrentStatus.sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sLEC";
        param.Value = oProjectCurrentStatus.sLEC;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStatus";
        param.Value = oProjectCurrentStatus.sStatus;
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


    public DataTable dtGetProjectCurrentStatusByInitiativeId(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getProjectCurrentStatusByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetProjectCurrentStatusReportByInitiativeId(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getProjectCurrentStatusReportByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public ProjectCurrentStatus objGetProjectCurrentStatusByInitiativeId(long lInitiativeId)
    {
        DataTable dt = dtGetProjectCurrentStatusByInitiativeId(lInitiativeId);
        ProjectCurrentStatus oProjectCurrentStatus = new ProjectCurrentStatus();
        foreach (DataRow dr in dt.Rows)
        {
            oProjectCurrentStatus = new ProjectCurrentStatus(dr);
        }
        return oProjectCurrentStatus;
    }
}