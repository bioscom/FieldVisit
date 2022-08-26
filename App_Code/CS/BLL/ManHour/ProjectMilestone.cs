using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ProjectMilestone
/// </summary>


public class ProjectMilestone
{
    public long lMilestoneId { get; set; }
    public long lInitiativeId { get; set; }
    public string sMilestones { get; set; }
    public string sStatus { get; set; }
    public string sTargetDate { get; set; }
    public string sRemarks { get; set; }

    public ProjectMilestone()
    {
        //
        // 
        //
    }

    public ProjectMilestone(DataRow dr)
    {
        lMilestoneId = long.Parse(dr["IDMILESTONE"].ToString());
        lInitiativeId = long.Parse(dr["IDINITIATIVE"].ToString());
        sMilestones = dr["MILESTONES"].ToString();
        sStatus = dr["STATUS"].ToString();
        sTargetDate = dr["TARGET_DATE"].ToString();
        sRemarks = dr["REMARKS"].ToString();
    }
}

public class ProjectMilestoneHelper
{
    public ProjectMilestoneHelper()
    {

    }

    public bool InsertProjectMilestone(ProjectMilestone oProjectMilestone)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.InsertProjectMilestone();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = oProjectMilestone.lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStatus";
        param.Value = oProjectMilestone.sStatus;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMilestones";
        param.Value = oProjectMilestone.sMilestones;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTargetDate";
        param.Value = oProjectMilestone.sTargetDate;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRemarks";
        param.Value = oProjectMilestone.sRemarks;
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

    public bool UpdateProjectMilestone(ProjectMilestone oProjectMilestone)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateProjectMilestone();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lMilestoneId";
        param.Value = oProjectMilestone.lMilestoneId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":lInitiativeId";
        //param.Value = oProjectMilestone.lInitiativeId;
        //param.DbType = DbType.Int64;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStatus";
        param.Value = oProjectMilestone.sStatus;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMilestones";
        param.Value = oProjectMilestone.sMilestones;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTargetDate";
        param.Value = oProjectMilestone.sTargetDate;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRemarks";
        param.Value = oProjectMilestone.sRemarks;
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

    public bool DeleteProjectMilestone(ProjectMilestone oProjectMilestone)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.DeleteProjectMilestone();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lMilestoneId";
        param.Value = oProjectMilestone.lMilestoneId;
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


    public DataTable dtGetProjectMilestoneByInitiativeId(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getProjectMilestoneByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public ProjectMilestone objGetProjectMilestoneByInitiativeId(long lInitiativeId)
    {
        DataTable dt = dtGetProjectMilestoneByInitiativeId(lInitiativeId);
        ProjectMilestone oProjectMilestone = new ProjectMilestone();
        foreach (DataRow dr in dt.Rows)
        {
            oProjectMilestone = new ProjectMilestone(dr);
        }
        return oProjectMilestone;
    }
}


