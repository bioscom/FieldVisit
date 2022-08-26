using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


/// <summary>
/// Summary description for facility
/// </summary>
public class facility
{
    public int m_iFacilityId { get; set; }
    public int m_iDistrictId { get; set; }
    public string m_sFacility { get; set; }
    public int m_iDivested { get; set; }
    public District eDistrict
    {
        get
        {
            return District.objGetDistrictById(m_iDistrictId);
        }
    }
    public Superintendent eSuperintendent
    {
        get
        {
            return Superintendent.objGetSuperintendentById(eDistrict.m_iSuperintendentId);
        }
    }

    public facility()
    {
        //
        //
    }

    public facility(DataRow dr)
    {
        m_iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
        m_iDistrictId = int.Parse(dr["ID_DISTRICT"].ToString());
        m_sFacility = dr["FACILITIES"].ToString();
        m_iDivested = int.Parse(dr["DIVESTED"].ToString());
    }

    public static DataTable dtGetFacility()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilities();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilityDetails()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilityDetails();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilityById(int FacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilityById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = FacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilitiesByPlannerId(int iPlannerId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilitiesByPlannerId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_PLANNER";
        param.Value = iPlannerId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilityByDistrict(int DistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilityByDistrict();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = DistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilityByDistrictId(int DistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilityByDistrictId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = DistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool RemovePlannerFromFacility(int iFacilityId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.RemovePlannerFromFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
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


    public static facility objGetFacilityById(int FacilityId)
    {
        DataTable dt = dtGetFacilityById(FacilityId);

        facility asset = new facility();
        foreach (DataRow dr in dt.Rows)
        {
            asset = new facility(dr);
        }
        return asset;
    }

    public static List<facility> lstGetFacility()
    {
        DataTable dt = dtGetFacility();

        List<facility> asset = new List<facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new facility(dr));
        }
        return asset;
    }

    public static List<facility> lstGetFacilitiesByPlanner(int iUserId)
    {
        DataTable dt = dtGetFacilitiesByPlannerId(iUserId);

        List<facility> asset = new List<facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new facility(dr));
        }
        return asset;
    }

    public static List<facility> lstGetFacilityByDistrict(int DistrictId)
    {
        DataTable dt = dtGetFacilityByDistrict(DistrictId);

        List<facility> asset = new List<facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new facility(dr));
        }
        return asset;
    }

    public static List<facility> lstGetFacilityByPlanner(int iPlannerId)
    {
        DataTable dt = dtGetFacilitiesByPlannerId(iPlannerId);

        List<facility> asset = new List<facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new facility(dr));
        }
        return asset;
    }

    public static DataTable dtGetFacilityPlannersByFacilityId(int FacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilityPlannerByFacilityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = FacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFacilityPlannersByPlannerId(int PlannerId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilityPlannerByPlannerId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_PLANNER";
        param.Value = PlannerId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static FacilityPlanners objGetFacilityPlannerByPlanneryId(int PlannerId)
    {
        DataTable dt = dtGetFacilityPlannersByPlannerId(PlannerId);

        FacilityPlanners planner = new FacilityPlanners();
        foreach (DataRow dr in dt.Rows)
        {
            planner = new FacilityPlanners(dr);
        }
        return planner;
    }

    public static FacilityPlanners objGetFacilityPlannerByFacilityId(int FacilityId)
    {
        DataTable dt = dtGetFacilityPlannersByFacilityId(FacilityId);

        FacilityPlanners planner = new FacilityPlanners();
        foreach (DataRow dr in dt.Rows)
        {
            planner = new FacilityPlanners(dr);
        }
        return planner;
    }

    public static List<FacilityPlanners> lstGetFacilityPlannersByFacility(int FacilityId)
    {
        DataTable dt = dtGetFacilityPlannersByFacilityId(FacilityId);

        List<FacilityPlanners> planners = new List<FacilityPlanners>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            planners.Add(new FacilityPlanners(dr));
        }
        return planners;
    }


    public static DataTable dtGetSuperintendentByFacilityId(int FacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendentByFacilityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = FacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static Superintendent objGetSuperintendentByFacilityId(int FacilityId)
    {
        DataTable dt = dtGetSuperintendentByFacilityId(FacilityId);

        Superintendent superIntend = new Superintendent();
        foreach (DataRow dr in dt.Rows)
        {
            superIntend = new Superintendent(dr);
        }
        return superIntend;
    }


    public static bool createFacility(int iDistrictId, string sFacility)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FACILITIES";
        param.Value = sFacility;
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

    public static bool updateFacility(int iFacilityId, int iDistrictId, string sFacility)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FACILITIES";
        param.Value = sFacility;
        param.DbType = DbType.String;
        param.Size = 500;
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

    public static bool Divested(int iFacilityId, int iDivested)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.Divested();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DIVESTED";
        param.Value = iDivested;
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


    public static bool AssignFacilityToPlanner(int iPlannerId, int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertPlannerFacility();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_PLANNER";
        param.Value = iPlannerId;
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

    public static int GetPlannerID()
    {
        string sql = "SELECT PROD_PLANNERS_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
        return int.Parse(dt.Rows[0]["NEXTVAL"].ToString());
    }


    ///////#########################################################################

    //public static DataTable dtGetFacilityDetails()
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getFacilityDetails();

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    public static DataTable dtGetFacilitiesByInitiativeId(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getFacilitiesByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public static DataTable dtGetFacilityByDistrictId(int DistrictId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getFacilityByDistrictId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_DISTRICT";
    //    param.Value = DistrictId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static facility objGetFacilityById(int FacilityId)
    //{
    //    DataTable dt = dtGetFacilityById(FacilityId);

    //    facility asset = new facility();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset = new facility(dr);
    //    }
    //    return asset;
    //}

    //public static List<facility> lstGetFacility()
    //{
    //    DataTable dt = dtGetFacility();

    //    List<facility> asset = new List<facility>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset.Add(new facility(dr));
    //    }
    //    return asset;
    //}

    public static List<facility> lstGetFacilityByInitiative(long lInitiativeId)
    {
        DataTable dt = dtGetFacilitiesByInitiativeId(lInitiativeId);

        List<facility> asset = new List<facility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new facility(dr));
        }
        return asset;
    }

    //public static DataTable dtGetFacilityPlannersByFacilityId(int FacilityId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getFacilityPlannerByFacilityId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_FACILITIES";
    //    param.Value = FacilityId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetFacilityPlannersByPlannerId(int PlannerId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getFacilityPlannerByPlannerId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_PLANNER";
    //    param.Value = PlannerId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static DataTable dtGetSuperintendentByFacilityId(int FacilityId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getSuperintendentByFacilityId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":ID_FACILITIES";
    //    param.Value = FacilityId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}


}

public class FacilityPlanners
{
    public int m_iPlannerId { get; set; }
    public int m_iFacilities { get; set; }
    public int m_iFacilitiesPlanner { get; set; }
    public appUsers eFacilityPlanner
    {
        get
        {
            return appUsersHelper.objGetUserByUserId(m_iPlannerId);
        }
    }
    public List<facility> lstPlannerFacilities
    {
        get
        {
            return facility.lstGetFacilityByPlanner(m_iPlannerId);
        }
    }

    public FacilityPlanners()
    {
        //
        //
    }

    public FacilityPlanners(DataRow dr)
    {
        m_iFacilitiesPlanner = int.Parse(dr["ID_FACILITY_PLANNER"].ToString());
        m_iFacilities = int.Parse(dr["ID_FACILITIES"].ToString());
        m_iPlannerId = int.Parse(dr["ID_PLANNER"].ToString());
    }
}

public class PlannersAssignedFacilities
{
    public int m_iFacilityId { get; set; }
    public int m_iUserId { get; set; }
    public string m_sFullName { get; set; }

    public PlannersAssignedFacilities()
    {

    }

    public PlannersAssignedFacilities(DataRow dr)
    {
        m_iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_sFullName = dr["FULLNAME"].ToString();
    }

    public static DataTable dtGetFacilitiesAssignedToPlanner(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilitiesAssignedToPlanner();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<PlannersAssignedFacilities> lstGetFacilitiesAssignedToPlanner(int iUserId)
    {
        DataTable dt = dtGetFacilitiesAssignedToPlanner(iUserId);

        List<PlannersAssignedFacilities> FacilitiesAssignedToPlanner = new List<PlannersAssignedFacilities>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            FacilitiesAssignedToPlanner.Add(new PlannersAssignedFacilities(dr));
        }
        return FacilitiesAssignedToPlanner;
    }

    public static bool bGetIfFacilityHasBeenAssignedToUser(int iUserId, int iFacilityId)
    {
        bool Found = false;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getFacilityForUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_PLANNER";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        if (GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count > 0)
        {
            Found = true;
        }

        return Found;
    }
}