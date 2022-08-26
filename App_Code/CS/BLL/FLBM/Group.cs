using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Group
/// </summary>
public class Group
{
    public int iGroupId { get; set; }
    public string sGroups { get; set; }
    public Group()
    {

    }

    public Group(DataRow dr)
    {
        iGroupId = int.Parse(dr["GROUPID"].ToString());
        sGroups = dr["GROUPS"].ToString();
    }

    public DataTable DtGetGroups()
    {
        string sql = "SELECT GROUPID, GROUPS FROM ASSESSMENT_GROUPS";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable DtGetGroupById(int iGroupId)
    {
        string sql = "SELECT GROUPID, GROUPS FROM ASSESSMENT_GROUPS WHERE GROUPID = :iGroupId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = iGroupId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static Group ObjGetGroupById(int iGroupId)
    {
        DataTable dt = DtGetGroupById(iGroupId);

        Group o = new Group();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Group(dr);
        }
        return o;
    }

    public List<Group> LstGroups()
    {
        var dt = DtGetGroups();

        var lstGroups = new List<Group>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstGroups.Add(new Group(dr));
        }
        return lstGroups;
    }

    public bool Insert(Group oGroup)
    {
        var sql = "INSERT INTO ASSESSMENT_GROUPS (GROUPS) VALUES (:sGroups)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sGroups";
        param.Value = oGroup.sGroups;
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

    public bool Update(Group oGroup)
    {
        var sql = "UPDATE ASSESSMENT_GROUPS SET GROUPS = :sGroups WHERE GROUPID = :iGroupId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = oGroup.iGroupId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sGroups";
        param.Value = oGroup.sGroups;
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