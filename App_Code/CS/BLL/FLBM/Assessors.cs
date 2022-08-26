using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Assessors
/// </summary>
public class Assessors
{
    public int iAssessor { get; set; }
    public int iUserId { get; set; }
    public string sFullName { get; set; }

    public Assessors()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Assessors(DataRow dr)
    {
        iAssessor = int.Parse(dr["IDASSESSOR"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
        sFullName = dr["FULLNAME"].ToString();
    }


    public bool Insert(int iUserId)
    {
        var sql = "INSERT INTO ASSESSMENT_ASSESSORS (USERID) VALUES (:iUserId)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
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

    public bool RemoveFromAssessorList(int iUserId)
    {
        var sql = "DELETE FROM ASSESSMENT_ASSESSORS WHERE USERID = :iUserId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
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


    public DataTable DtGetAssessors()
    {
        var sql = "SELECT ASSESSMENT_ASSESSORS.IDASSESSOR, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL ";
        sql += "FROM ASSESSMENT_ASSESSORS ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = ASSESSMENT_ASSESSORS.USERID ";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetAssessorByUserId(int iUserId)
    {
        var sql = "SELECT ASSESSMENT_ASSESSORS.IDASSESSOR, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL ";
        sql += "FROM ASSESSMENT_ASSESSORS ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = ASSESSMENT_ASSESSORS.USERID WHERE PROD_USERMGT.USERID = :iUserId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Assessors objGetAssessorsByUserId(int iUserId)
    {
        var dt = DtGetAssessorByUserId(iUserId);

        var o = new Assessors();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Assessors(dr);
        }
        return o;
    }

    public List<Assessors> LstAssessors()
    {
        var dt = DtGetAssessors();

        var lstAssessors = new List<Assessors>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstAssessors.Add(new Assessors(dr));
        }
        return lstAssessors;
    }
}

public class AssessorsRights
{
    public long lAccessId { get; set; }
    public int iUserId { get; set; }
    public int iRight { get; set; }
    public long lCompetenceId { get; set; }

    public string sFullName { get; set; }

    public AssessorsRights()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public AssessorsRights(DataRow dr)
    {
        lAccessId = long.Parse(dr["ACCESSID"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
        iRight = int.Parse(dr["IRIGHT"].ToString());
        lCompetenceId = long.Parse(dr["COMPETENCEID"].ToString());
    }

    public DataTable DtGetAssessorsRightByCompetence(long lCompetenceId, int iUserId)
    {
        var sql = "SELECT * FROM ASSESSMENT_ASSESSORS_ACCESS WHERE USERID = :iUserId AND COMPETENCEID = :lCompetenceId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lCompetenceId";
        param.Value = lCompetenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetAssessorsRight(int iUserId)
    {
        var sql = "SELECT ACCESSID, USERID, IRIGHT, COMPETENCEID FROM ASSESSMENT_ASSESSORS_ACCESS WHERE USERID = :iUserId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public bool InsertAssessorRight(int iUserId, long lCompetenceId, int iRight)
    {
        var sql = "INSERT INTO ASSESSMENT_ASSESSORS_ACCESS (USERID, COMPETENCEID, IRIGHT) VALUES (:iUserId, :lCompetenceId, :iRight)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lCompetenceId";
        param.Value = lCompetenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRight";
        param.Value = iRight;
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

    public bool UpdateAssessorRight(int iUserId, long lCompetenceId, int iRight)
    {
        var sql = "UPDATE ASSESSMENT_ASSESSORS_ACCESS SET IRIGHT = :iRight WHERE (USERID = :iUserId AND COMPETENCEID = :lCompetenceId)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lCompetenceId";
        param.Value = lCompetenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRight";
        param.Value = iRight;
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

    public List<AssessorsRights> LstAssessorsRights(int iUserId)
    {
        var dt = DtGetAssessorsRight(iUserId);

        var lstAssessorsRights = new List<AssessorsRights>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstAssessorsRights.Add(new AssessorsRights(dr));
        }
        return lstAssessorsRights;
    }

    public AssessorsRights objGetAssessorsRightsByCompetence(int iUserId, long lCompetenceId)
    {
        var dt = DtGetAssessorsRightByCompetence(lCompetenceId, iUserId);

        var o = new AssessorsRights();
        foreach (DataRow dr in dt.Rows)
        {
            o = new AssessorsRights(dr);
        }
        return o;
    }
}