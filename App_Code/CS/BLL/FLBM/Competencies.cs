using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Competencies
/// </summary>

public class Competencies
{
    public int iCompetenceId { get; set; }
    public int iGroupId { get; set; }
    public string sCompetence { get; set; }
    public string sCompetenceDescription { get; set; }
    public string sUrl { get; set; }
    public Competencies()
    {

    }

    public Competencies(DataRow dr)
    {
        iGroupId = int.Parse(dr["GROUPID"].ToString());
        iCompetenceId = int.Parse(dr["COMPETENCEID"].ToString());
        sCompetence = dr["COMPETENCE"].ToString();
        sCompetenceDescription = dr["DESCRIPTIONS"].ToString();
        sUrl = dr["LOCATION"].ToString();
    }

    public DataTable DtGetCompetenciesByGroup(int iGroupId)
    {
        string sql = "SELECT GROUPID, COMPETENCEID, COMPETENCE, LOCATION, DESCRIPTIONS FROM ASSESSMENT_COMPETENCE WHERE GROUPID = :iGroupId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = iGroupId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetCompetenceById(int iCompetenceId)
    {
        string sql = "SELECT GROUPID, COMPETENCEID, COMPETENCE, LOCATION, DESCRIPTIONS FROM ASSESSMENT_COMPETENCE WHERE COMPETENCEID = :iCompetenceId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iCompetenceId";
        param.Value = iCompetenceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Competencies ObjGetCompetenceById(int iCompetenceId)
    {
        DataTable dt = DtGetCompetenceById(iCompetenceId);

        Competencies o = new Competencies();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Competencies(dr);
        }
        return o;
    }

    public Competencies ObjGetCompetenciesByGroup(int iGroupId)
    {
        DataTable dt = DtGetCompetenciesByGroup(iGroupId);

        Competencies o = new Competencies();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Competencies(dr);
        }
        return o;
    }

    public List<Competencies> LstCompetenciesByGroup(int iGroupId)
    {
        var dt = DtGetCompetenciesByGroup(iGroupId);

        var lstCompetencies = new List<Competencies>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstCompetencies.Add(new Competencies(dr));
        }
        return lstCompetencies;
    }

    public bool CreateCompetence(Competencies oCompetencies)
    {
        var sql = "INSERT INTO ASSESSMENT_COMPETENCE (GROUPID, COMPETENCE, LOCATION, DESCRIPTIONS) VALUES (:iGroupId, :sCompetence, :sLocation, :sDescriptions)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = oCompetencies.iGroupId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCompetence";
        param.Value = oCompetencies.sCompetence;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sLocation";
        param.Value = oCompetencies.sUrl;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDescriptions";
        param.Value = oCompetencies.sCompetenceDescription;
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


    public bool UpdateCompetence(Competencies oCompetencies)
    {
        var sql = "UPDATE ASSESSMENT_COMPETENCE SET GROUPID = :iGroupId, COMPETENCE = :sCompetence, LOCATION = :sLocation, DESCRIPTIONS = :sDescriptions WHERE COMPETENCEID = :iCompetenceId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iCompetenceId";
        param.Value = oCompetencies.iCompetenceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = oCompetencies.iGroupId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCompetence";
        param.Value = oCompetencies.sCompetence;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sLocation";
        param.Value = oCompetencies.sUrl;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDescriptions";
        param.Value = oCompetencies.sCompetenceDescription;
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

    public bool DeleteCompetence(Competencies oCompetencies)
    {
        return true;
    }
}