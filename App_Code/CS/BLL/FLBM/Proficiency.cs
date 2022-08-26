using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Proficiency
/// </summary>
public class Proficiency
{
    public int iProficiencyId { get; set; }
    public string sProficiency { get; set; }
    public Proficiency()
    {

    }

    public Proficiency(DataRow dr)
    {
        iProficiencyId = int.Parse(dr["PROFICIENCYID"].ToString());
        sProficiency = dr["PROFICIENCY"].ToString();
    }

    public DataTable DtGetProficiencies()
    {
        string sql = "SELECT PROFICIENCYID, PROFICIENCY FROM ASSESSMENT_PROFICIENCY";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable DtGetProficiencyById(int iProficiencyId)
    {
        string sql = "SELECT PROFICIENCYID, PROFICIENCY FROM ASSESSMENT_PROFICIENCY WHERE PROFICIENCYID = :iProficiencyId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iProficiencyId";
        param.Value = iProficiencyId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static Proficiency ObjGetProficiencyById(int iProficiencyId)
    {
        DataTable dt = DtGetProficiencyById(iProficiencyId);

        Proficiency o = new Proficiency();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Proficiency(dr);
        }
        return o;
    }

    public List<Proficiency> LstProficiency()
    {
        var dt = DtGetProficiencies();

        var lstLevels = new List<Proficiency>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstLevels.Add(new Proficiency(dr));
        }
        return lstLevels;
    }

    public bool Insert(Proficiency oProficiency)
    {
        var sql = "INSERT INTO ASSESSMENT_PROFICIENCY (PROFICIENCY) VALUES (:sProficiency)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sProficiency";
        param.Value = oProficiency.sProficiency;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool Update(Proficiency oProficiency)
    {
        var sql = "UPDATE ASSESSMENT_PROFICIENCY SET PROFICIENCY = :sProficiency WHERE PROFICIENCYID = :iProficiencyId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iProficiencyId";
        param.Value = oProficiency.iProficiencyId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProficiency";
        param.Value = oProficiency.sProficiency;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }
}