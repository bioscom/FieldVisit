using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ResourceUtilisation
/// </summary>
public class ResourceUtilisation
{
    public long m_lResourceId { get; set; }
    public int m_iDisciplineId { get; set; }
    public int m_iNoOfStaff { get; set; }
    public int m_iStaffUtilisation { get; set; }
    public int m_iMaxWorkHr { get; set; }
    public long m_lInitiativeId { get; set; }

	public ResourceUtilisation()
	{
		//
		// 
		//
	}

    public ResourceUtilisation(DataRow dr)
    {
        m_lResourceId = long.Parse(dr["IDRESOURCE"].ToString());
        m_iDisciplineId = int.Parse(dr["IDDISCIPLINE"].ToString());
        m_iNoOfStaff = int.Parse(dr["NOOFSTAFF"].ToString());
        m_iStaffUtilisation = int.Parse(dr["STAFFHRUTIL"].ToString());
        m_iMaxWorkHr = int.Parse(dr["MAXWRHR"].ToString());
        m_lInitiativeId = long.Parse(dr["IDINITIATIVE"].ToString());
    }

    public bool CreateResourceUtilisation(long lInitiativeId, int iDisciplineId, int iNoOfStaff, int iStaffUtilisation, int iMaxWorkHr)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.CreateResourceUtilisation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDDISCIPLINE";
        param.Value = iDisciplineId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NOOFSTAFF";
        param.Value = iNoOfStaff;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAFFHRUTIL";
        param.Value = iStaffUtilisation;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":MAXWRHR";
        param.Value = iMaxWorkHr;
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

    public bool UpdateResourceUtilisation(long lResourceId, int iDisciplineId, int iNoOfStaff, int iStaffUtilisation, int iMaxWorkHr)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateResourceUtilisation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDRESOURCE";
        param.Value = lResourceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDDISCIPLINE";
        param.Value = iDisciplineId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NOOFSTAFF";
        param.Value = iNoOfStaff;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAFFHRUTIL";
        param.Value = iStaffUtilisation;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":MAXWRHR";
        param.Value = iMaxWorkHr;
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

    public bool deleteInitiative(long lResourceId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.DeleteInitiativeDetail();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDRESOURCE";
        param.Value = lResourceId;
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

    public bool deleteInitiativeDetailsByInitiativeId(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.DeleteInitiativeDetailsByMasterId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
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

    public DataTable dtGetResourceUtilisationByInitiative(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getResourceUtilisationByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetResourceRequirementsByInitiative(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getResourceRequirementByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetResourceRequirementsByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getResourceRequirementByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetResourceUtilisationByResource(long lResourceId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getResourceUtilisationByResourceId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDRESOURCE";
        param.Value = lResourceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public ResourceUtilisation objGetResourceUtilisationByInitiative(long lInitiativeId)
    {
        DataTable dt = dtGetResourceUtilisationByInitiative(lInitiativeId);

        ResourceUtilisation xRows = new ResourceUtilisation();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new ResourceUtilisation(dr);
        }
        return xRows;
    }

    public ResourceUtilisation objGetResourceUtilisationByResourceId(long lResourceId)
    {
        DataTable dt = dtGetResourceUtilisationByResource(lResourceId);

        ResourceUtilisation xRows = new ResourceUtilisation();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new ResourceUtilisation(dr);
        }
        return xRows;
    }
}