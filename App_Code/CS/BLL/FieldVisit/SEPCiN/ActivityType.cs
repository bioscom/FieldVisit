using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ActivityType
/// </summary>

public class ActivityType
{
    public int m_iID_ACTIVITY_TYPE { get; set; }
    public string m_sACTIVITY_TYPE { get; set; }

	public ActivityType()
	{
		
	}

    public ActivityType(DataRow dr)
    {
        m_iID_ACTIVITY_TYPE = int.Parse(dr["ID_ACTIVITY_TYPE"].ToString());
        m_sACTIVITY_TYPE = dr["ACTIVITY_TYPE"].ToString();
    }

    public static DataTable dtGetActivityType()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityType();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetActivityTypeById(int ActivityTypeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityTypeById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITY_TYPE";
        param.Value = ActivityTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static ActivityType objGetActivityTypeById(int ActivityTypeId)
    {
        DataTable dt = dtGetActivityTypeById(ActivityTypeId);

        ActivityType xRows = new ActivityType();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new ActivityType(dr);
        }
        return xRows;
    }

    public static List<ActivityType> lstGetActivityType()
    {
        DataTable dt = dtGetActivityType();

        List<ActivityType> xRows = new List<ActivityType>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new ActivityType(dr));
        }
        return xRows;
    }

    public static bool createActivityType(string sACTIVITY_TYPE)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.createActivityType();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITY_TYPE";
        param.Value = sACTIVITY_TYPE;
        param.DbType = DbType.String;
        param.Size = 1000;
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

    public static bool updateActivityType(int iACTIVITY_TYPE, string sACTIVITY_TYPE)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateActivityType();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITY_TYPE";
        param.Value = iACTIVITY_TYPE;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITY_TYPE";
        param.Value = sACTIVITY_TYPE;
        param.DbType = DbType.String;
        param.Size = 1000;
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
