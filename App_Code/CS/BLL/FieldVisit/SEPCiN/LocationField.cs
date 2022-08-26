using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for LocationField
/// </summary>
public class LocationField
{
    public int iID_FIELD_LOC { get; set; }
    public string sFIELD_LOCATION { get; set; }
    public int m_iIAPWindowId { get; set; }

    public enum PEC { VST = 1, ST = 2, MT = 3 };

    public static string PECDesc(PEC eWindow)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eWindow)
            {
                case PEC.MT: sRet = "MT 2 Years"; break;
                case PEC.ST: sRet = "ST 90 Days"; break;
                case PEC.VST: sRet = "VST 14/28"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public iapWindows eWindows
    { 
        get
        {
            return iapWindows.objGetIAPWindowById(m_iIAPWindowId);
        }
    }

	public LocationField()
	{
		
	}

    public LocationField(DataRow dr)
    {
        iID_FIELD_LOC = int.Parse(dr["ID_FIELD_LOC"].ToString());
        sFIELD_LOCATION = dr["FIELD_LOCATION"].ToString();
        m_iIAPWindowId = int.Parse(dr["ID_WINDOW"].ToString());
    }

    public static DataTable dtGetLocationField()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getLocationField();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetLocationFieldById(int LocationFieldId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getLocationFieldById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FIELD_LOC";
        param.Value = LocationFieldId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetLocationFieldByWindowId(int iWindowId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getLocationFieldByWindowId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_WINDOW";
        param.Value = iWindowId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static LocationField objGetLocationFieldById(int LocationFieldId)
    {
        DataTable dt = dtGetLocationFieldById(LocationFieldId);

        LocationField xRows = new LocationField();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new LocationField(dr);
        }
        return xRows;
    }

    public static List<LocationField> lstGetLocationField()
    {
        DataTable dt = dtGetLocationField();

        List<LocationField> xRows = new List<LocationField>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new LocationField(dr));
        }
        return xRows;
    }

    public static bool createLocationField(string sFIELD_LOCATION, int iIapWindow)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.createLocationField();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":FIELD_LOCATION";
        param.Value = sFIELD_LOCATION;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_WINDOW";
        param.Value = iIapWindow;
        param.DbType = DbType.Int32;
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

    public static bool updateLocationField(int iID_FIELD_LOC, string sFIELD_LOCATION, int iIapWindow)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateLocationField();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FIELD_LOC";
        param.Value = iID_FIELD_LOC;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FIELD_LOCATION";
        param.Value = sFIELD_LOCATION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_WINDOW";
        param.Value = iIapWindow;
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
}


public class LocationFieldActivityInfo
{
    public int m_iID_FIELD { get; set; }
    public int m_iID_FIELD_LOC { get; set; }
    public int m_iACTIVITYID { get; set; }
    public int m_iSTATUS { get; set; }

    public LocationField eLocationField
    {
        get
        {
            return LocationField.objGetLocationFieldById(m_iID_FIELD_LOC);
        }
    }

    public LocationFieldActivityInfo()
    {

    }

    public LocationFieldActivityInfo(DataRow dr)
    {
        m_iID_FIELD = int.Parse(dr["ID_FIELD"].ToString());
        m_iID_FIELD_LOC = int.Parse(dr["ID_FIELD_LOC"].ToString());
        m_iACTIVITYID = int.Parse(dr["ID_ACTIVITYINFO"].ToString());
        m_iSTATUS = int.Parse(dr["STATUS"].ToString());
    }

    public static DataTable dtGetLocationFieldInfo()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getLocationFieldActivityInfo();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetLocationFieldById(int LocationFieldId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getLocationFieldActivityInfoById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FIELD";
        param.Value = LocationFieldId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static LocationFieldActivityInfo objGetLocationFieldById(int LocationFieldId)
    {
        DataTable dt = dtGetLocationFieldById(LocationFieldId);

        LocationFieldActivityInfo xRows = new LocationFieldActivityInfo();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new LocationFieldActivityInfo(dr);
        }
        return xRows;
    }

    public static List<LocationFieldActivityInfo> lstGetLocationField()
    {
        DataTable dt = dtGetLocationFieldInfo();

        List<LocationFieldActivityInfo> xRows = new List<LocationFieldActivityInfo>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new LocationFieldActivityInfo(dr));
        }
        return xRows;
    }


    public static DataTable dtGetLocationFieldByActivityId(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getLocationFieldActivityInfoByActivityID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static LocationFieldActivityInfo objGetLocationFieldByActivityId(long iActivityId)
    {
        DataTable dt = dtGetLocationFieldByActivityId(iActivityId);

        LocationFieldActivityInfo xRows = new LocationFieldActivityInfo();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new LocationFieldActivityInfo(dr);
        }
        return xRows;
    }

    public static List<LocationFieldActivityInfo> lstGetLocationFieldByActivityId(long iActivityId)
    {
        DataTable dt = dtGetLocationFieldByActivityId(iActivityId);

        List<LocationFieldActivityInfo> xRows = new List<LocationFieldActivityInfo>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new LocationFieldActivityInfo(dr));
        }
        return xRows;
    }

    public static bool createLocationFieldActivityInfo(int iID_FIELD_LOC, long iActivityId, int iSTATUS)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.createLocationFieldActivityInfo();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FIELD_LOC";
        param.Value = iID_FIELD_LOC;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = iSTATUS;
        param.DbType = DbType.Int32;
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

    public static bool updateLocationFieldActivityInfo(int iID_FIELD_LOC, long iActivityId, int iSTATUS)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateLocationFieldActivityInfo();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FIELD_LOC";
        param.Value = iID_FIELD_LOC;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = iSTATUS;
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
}