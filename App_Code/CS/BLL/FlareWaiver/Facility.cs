using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Area and Facility
/// </summary>
/// 

public class Area
{
    public int m_iIDAREA { get; set; }
    public string m_sAREA { get; set; }

    public Area()
    {

    }
    public Area(DataRow dr)
    {
        m_iIDAREA = int.Parse(dr["IDAREA"].ToString());
        m_sAREA = dr["AREA"].ToString();
    }

    public static DataTable dtGetAreas()
    {
        string sql = "SELECT IDAREA, AREA FROM FLARE_AREA ORDER BY AREA";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<Area> lstGetAreas()
    {
        DataTable dt = dtGetAreas();

        List<Area> lstAreas = new List<Area>();
        foreach (DataRow dr in dt.Rows)
        {
            lstAreas.Add(new Area(dr));
        }
        return lstAreas;
    }
}

public class Facility
{
    public int m_iFacilityId { get; set; }
    public int m_iAreaId { get; set; }
    public string m_sFacility { get; set; }
    public string m_sCode { get; set; }
    public int m_iAgg { get; set; }
    public int m_iLocation { get; set; }

	public Facility()
	{
		
	}

    public Facility(DataRow dr)
    {
        m_iFacilityId = int.Parse(dr["IDFACILITY"].ToString());
        m_iAreaId = int.Parse(dr["IDAREA"].ToString());
        m_sFacility = dr["FACILITY"].ToString();
        m_sCode = dr["CODE"].ToString();
        m_iAgg = int.Parse(dr["AGG"].ToString());
        m_iLocation = int.Parse(dr["LOCATION"].ToString());
    }

    public static Facility objGetFacilityById(int iFacilityId)
    {
        DataTable dt = dtGetFacilityById(iFacilityId);

        Facility oFacility = new Facility();
        foreach (DataRow dr in dt.Rows)
        {
            oFacility = new Facility(dr);
        }
        return oFacility;
    }

    public static DataTable dtGetFacilityById(int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilityById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilities()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilities();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilitiesByArea(int iAreaId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilitiesByArea();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAreaId";
        param.Value = iAreaId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetAGGFacilitiesByArea(int iAreaId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getAGGFacilitiesByArea();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAreaId";
        param.Value = iAreaId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<Facility> lstGetFacilities()
    {
        DataTable dt = dtGetFacilities();

        List<Facility> oFacilities = new List<Facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oFacilities.Add(new Facility(dr));
        }
        return oFacilities;
    }

    public static List<Facility> lstGetFacilitiesByArea(int iAreaId)
    {
        DataTable dt = dtGetFacilitiesByArea(iAreaId);

        List<Facility> oFacilities = new List<Facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oFacilities.Add(new Facility(dr));
        }
        return oFacilities;
    }

    public static List<Facility> lstGetAGGFacilitiesByArea(int iAreaId)
    {
        DataTable dt = dtGetAGGFacilitiesByArea(iAreaId);

        List<Facility> oFacilities = new List<Facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oFacilities.Add(new Facility(dr));
        }
        return oFacilities;
    }

    public static bool AddFacility(Facility o)
    {
        //int iAreaId, string sFacility, string sCode
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.InsertFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDAREA";
        param.Value = o.m_iAreaId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FACILITY";
        param.Value = o.m_sFacility;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":CODE";
        param.Value = o.m_sCode;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":AGG";
        param.Value = o.m_iAgg;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":LOCATION";
        param.Value = o.m_iLocation;
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

    public static bool UpdateFacility(Facility o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDAREA";
        param.Value = o.m_iAreaId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FACILITY";
        param.Value = o.m_sFacility;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":CODE";
        param.Value = o.m_sCode;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDFACILITY";
        param.Value = o.m_iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":AGG";
        param.Value = o.m_iAgg;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":LOCATION";
        param.Value = o.m_iLocation;
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
}