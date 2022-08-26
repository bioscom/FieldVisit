using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for InitiativeOUDistrictFacilities
/// </summary>
public class InitiativeOUDistrictFacilities
{
	public InitiativeOUDistrictFacilities()
	{
		//
		// 
		//
	}

    public bool AssignFacilitiesToInitiative(long lInitiativeId, int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.AssignFacilitiesToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
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

    public bool AssignOUToInitiative(long lInitiativeId, int iOuId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.AssignOUToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDOU";
        param.Value = iOuId;
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

    public bool AssignAssetToInitiative(long lInitiativeId, int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.AssignAssetToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDASSET";
        param.Value = iAssetId;
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

    public bool AssignDistrictToInitiative(long lInitiativeId, int iDistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.AssignDistrictToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = iDistrictId;
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


    public bool UpdateFacilitiesToInitiative(long lInitiativeId, int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateFacilitiesToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
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

    public bool UpdateOUToInitiative(long lInitiativeId, int iOuId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateOUToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDOU";
        param.Value = iOuId;
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

    public bool UpdateAssetToInitiative(long lInitiativeId, int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateAssetToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDASSET";
        param.Value = iAssetId;
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

    public bool UpdateDistrictToInitiative(long lInitiativeId, int iDistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateDistrictToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = iDistrictId;
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


    public bool findFacilitiesToInitiative(long lInitiativeId, int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.findFacilitiesToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacilityId;
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

    public bool findOUToInitiative(long lInitiativeId, int iOuId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.findOUToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDOU";
        param.Value = iOuId;
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

    public bool findeAssetToInitiative(long lInitiativeId, int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.findAssetToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDASSET";
        param.Value = iAssetId;
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

    public bool findDistrictToInitiative(long lInitiativeId, int iDistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.findDistrictToInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_DISTRICT";
        param.Value = iDistrictId;
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
    public DataTable dtGetOuByInitiative(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getOuByInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<Initiative_OU> lstGetOuByInitiative(long lInitiativeId)
    {
        DataTable dt = dtGetOuByInitiative(lInitiativeId);

        List<Initiative_OU> xRow = new List<Initiative_OU>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRow.Add(new Initiative_OU(dr));
        }
        return xRow;
    }

    public DataTable dtGetDistrictFacilitiesByInitiative(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getDistrictFacilitiesByInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<Initiative_Dist_Facilities> lstGetDistrictFacilitiesByInitiative(long lInitiativeId)
    {
        DataTable dt = dtGetDistrictFacilitiesByInitiative(lInitiativeId);

        List<Initiative_Dist_Facilities> xRow = new List<Initiative_Dist_Facilities>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRow.Add(new Initiative_Dist_Facilities(dr));
        }
        return xRow;
    }

}


public class Initiative_OU
{
    public long m_lIdOuInit { get; set; }
    public int m_iIdOU { get; set; }
    public long m_lIdInitiative { get; set; }

    public Initiative_OU()
    {

    }

    public Initiative_OU(DataRow dr)
    {
        m_lIdOuInit = long.Parse(dr["IDOUINIT"].ToString());
        m_iIdOU = int.Parse(dr["IDOU"].ToString());
        m_lIdInitiative = long.Parse(dr["IDINITIATIVE"].ToString());
    }
}

public class Initiative_Dist_Facilities
{
    public int m_iIdDistFacility { get; set; }
    public int m_iIdDistrict { get; set; }
    public int m_iIdFacility { get; set; }
    public long m_lIdInitiative { get; set; }

    public Initiative_Dist_Facilities()
    {

    }

    public Initiative_Dist_Facilities(DataRow dr)
    {
        m_iIdDistFacility = int.Parse(dr["IDDISTFAC"].ToString());
        m_iIdDistrict = int.Parse(dr["ID_DISTRICT"].ToString());
        m_iIdFacility = int.Parse(dr["ID_FACILITIES"].ToString());
        m_lIdInitiative = long.Parse(dr["IDINITIATIVE"].ToString());
    }
}