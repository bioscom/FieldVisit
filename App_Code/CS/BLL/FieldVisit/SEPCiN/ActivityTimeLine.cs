using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Globalization;

/// <summary>
/// Summary description for ActivityTimeLine
/// </summary>

public class ActivityTimeLine
{
    public Int64 m_iID_TIMELINE { get; set; }
    public string m_sACTIVITYID { get; set; }
    public string m_sACTIVITY_DESCRIPTION { get; set; }
    public string m_sSTART_DATE { get; set; }
    public string m_sFINISH_DATE { get; set; }

	public ActivityTimeLine()
	{

    }

    public ActivityTimeLine(DataRow dr)
    {
        m_iID_TIMELINE = int.Parse(dr["ID_TIMELINE"].ToString());
        m_sACTIVITYID = dr["ID_ACTIVITYINFO"].ToString();
        m_sACTIVITY_DESCRIPTION = dr["ACTIVITY_DESCRIPTION"].ToString();
        m_sSTART_DATE = dr["START_DATE"].ToString();
        m_sFINISH_DATE = dr["FINISH_DATE"].ToString();
        //m_sFINISH_DATE = DateTime.Parse(dr["FINISH_DATE"].ToString(), "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
    }

    public static DataTable dtGetActivityTimeLine()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityTimeLine();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetActivityTimeLineById(Int64 ActivityTimeLineId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityTimeLineById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_TIMELINE";
        param.Value = ActivityTimeLineId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetActivityTimeLineByActivityId(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityTimeLineByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static ActivityTimeLine objGetActivityTimeLineByActivityId(int iActivityId)
    {
        DataTable dt = dtGetActivityTimeLineByActivityId(iActivityId);

        ActivityTimeLine xRows = new ActivityTimeLine();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new ActivityTimeLine(dr);
        }
        return xRows;
    }

    public static List<ActivityTimeLine> lstGetActivityTimeLineByActivityId(long lActivityId)
    {
        DataTable dt = dtGetActivityTimeLineByActivityId(lActivityId);

        List<ActivityTimeLine> xRows = new List<ActivityTimeLine>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new ActivityTimeLine(dr));
        }
        return xRows;
    }

    public static ActivityTimeLine objGetActivityTimeLineById(Int64 ActivityTimeLineId)
    {
        DataTable dt = dtGetActivityTimeLineById(ActivityTimeLineId);

        ActivityTimeLine xRows = new ActivityTimeLine();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new ActivityTimeLine(dr);
        }
        return xRows;
    }

    public static List<ActivityTimeLine> lstGetActivityTimeLine()
    {
        DataTable dt = dtGetActivityTimeLine();

        List<ActivityTimeLine> xRows = new List<ActivityTimeLine>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new ActivityTimeLine(dr));
        }
        return xRows;
    }

    public static bool createActivityTimeLine(long iActivityId, ActivityTimeLine eTimeLine)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.createActivityTimeLine();
         
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITY_DESCRIPTION";
        param.Value = eTimeLine.m_sACTIVITY_DESCRIPTION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":START_DATE";
        param.Value = eTimeLine.m_sSTART_DATE;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FINISH_DATE";
        param.Value = eTimeLine.m_sFINISH_DATE;
        param.DbType = DbType.Date;
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

    public static bool updateActivityTimeLine(ActivityTimeLine eTimeLine)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateActivityTimeLine();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_TIMELINE";
        param.Value = eTimeLine.m_iID_TIMELINE;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITY_DESCRIPTION";
        param.Value = eTimeLine.m_sACTIVITY_DESCRIPTION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":START_DATE";
        param.Value = eTimeLine.m_sSTART_DATE;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FINISH_DATE";
        param.Value = eTimeLine.m_sFINISH_DATE;
        param.DbType = DbType.Date;
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

    public static bool deleteTimeLine(Int64 iTimeLineId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.deleteActivityTimeLine();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_TIMELINE";
        param.Value = iTimeLineId;
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