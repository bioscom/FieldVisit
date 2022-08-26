using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Superintendent
/// </summary>
public class Superintendent
{
    public int m_iSuperintendentId { get; set; }
    public string m_sSuperintendent { get; set; }
    public string m_sSuperintendentEmail { get; set; }

    public Superintendent()
    {

    }

    public Superintendent(DataRow dr)
    {
        m_iSuperintendentId = int.Parse(dr["ID_SUPERINTENDENT"].ToString());
        m_sSuperintendent = dr["SUPERINTENDENT"].ToString();
        m_sSuperintendentEmail = dr["SUPERINTENDENT_EMAIL"].ToString();
    }

    public static DataTable dtGetSuperintendent()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendents();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetSuperintendentById(int superintendentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendentById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = superintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static Superintendent objGetSuperintendentById(int superintendentId)
    {
        DataTable dt = dtGetSuperintendentById(superintendentId);

        Superintendent asset = new Superintendent();
        foreach (DataRow dr in dt.Rows)
        {
            asset = new Superintendent(dr);
        }
        return asset;
    }

    public static List<Superintendent> lstGetSuperintendent()
    {
        DataTable dt = dtGetSuperintendent();

        List<Superintendent> asset = new List<Superintendent>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new Superintendent(dr));
        }
        return asset;
    }

    public static bool createSuperintendent(string sSuperintendent, string sSuperintendent_Email)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertSuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":SUPERINTENDENT";
        param.Value = sSuperintendent;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":SUPERINTENDENT_EMAIL";
        param.Value = sSuperintendent_Email;
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

    public static bool updateSuperintendent(int iSuperintendentId, string sSuperintendent, string sSuperintendent_Email)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateSuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":SUPERINTENDENT";
        param.Value = sSuperintendent;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":SUPERINTENDENT_EMAIL";
        param.Value = sSuperintendent_Email;
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

/// <summary>
/// Summary description for SuperintendentFunctionalAcctUser
/// </summary>

public class SuperintendentFunctionalAcctUser
{
    public int acctUserId { get; set; }
    public int superintendentId { get; set; }
    public int iUserId { get; set; }
    public appUsers eSuperintendentUser
    {
        get
        {
            return appUsersHelper.objGetUserByUserId(iUserId);
        }       
    }

    public SuperintendentFunctionalAcctUser()
    {

    }

    public SuperintendentFunctionalAcctUser(DataRow dr)
    {
        acctUserId = int.Parse(dr["ID_ACCTUSER"].ToString());
        superintendentId = int.Parse(dr["ID_SUPERINTENDENT"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }

    public static DataTable CheckIfSelectedUserExistsForTheSelectedSuperintendent(int iSuperintendent, int iUserId)
    {
        //SuperintendentFunctionalAcctUser MySuperintendent = SuperintendentFunctionalAcctUser.objGetSuperintendentFunctionalAcctByUserName(sUserName);

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendentByUserIdSuperintendentId(); 

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendent;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool insertSuperintendentFunctionalAcctUser(int iSuperintendent, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertSuperintendentFunctionalAcctUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendent;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
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

    public static bool updateSuperintendentFunctionalAcctUser(int iAcctUserId, int iSuperintendent, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateSuperintendentFunctionalAcctUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACCTUSER";
        param.Value = iAcctUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendent;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
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

    public static DataTable dtGetSuperintendentFunctionalAcctUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendentFunctionalAcctUsers();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    
    public static DataTable dtGetSuperintendentFunctionalAcctUsersBySuperintendent(int iSuperintendentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendentFunctionalAcctUsersBySuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool RemoveFromSuperintendent(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.RemoveFromSuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
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

    public static DataTable dtGetSuperintendentFunctionalAcctUserById(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendentFunctionalAcctUserById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetSuperintendentFunctionalAcctByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getSuperintendentFunctionalAcctByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static SuperintendentFunctionalAcctUser objGetSuperintendentFunctionalAcctUserById(int iAcctUserId)
    {
        DataTable dt = dtGetSuperintendentFunctionalAcctUserById(iAcctUserId);

        SuperintendentFunctionalAcctUser superintendentFunctionalAcctUser = new SuperintendentFunctionalAcctUser();
        foreach (DataRow dr in dt.Rows)
        {
            superintendentFunctionalAcctUser = new SuperintendentFunctionalAcctUser(dr);
        }
        return superintendentFunctionalAcctUser;
    }

    public static SuperintendentFunctionalAcctUser objGetSuperintendentFunctionalAcctByUserId(int iUserId)
    {
        DataTable dt = dtGetSuperintendentFunctionalAcctByUserId(iUserId);

        SuperintendentFunctionalAcctUser superintendentFunctionalAcctUser = new SuperintendentFunctionalAcctUser();
        foreach (DataRow dr in dt.Rows)
        {
            superintendentFunctionalAcctUser = new SuperintendentFunctionalAcctUser(dr);
        }
        return superintendentFunctionalAcctUser;
    }

    public static List<SuperintendentFunctionalAcctUser> lstGetSuperintendentFunctionalAcctByUserId(int iUserId)
    {
        DataTable dt = dtGetSuperintendentFunctionalAcctByUserId(iUserId);

        List<SuperintendentFunctionalAcctUser> superintendentFunctionalAcctUser = new List<SuperintendentFunctionalAcctUser>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            superintendentFunctionalAcctUser.Add(new SuperintendentFunctionalAcctUser(dr));
        }
        return superintendentFunctionalAcctUser;
    }

    public static List<SuperintendentFunctionalAcctUser> lstGetSuperintendentFunctionalAcctUsers()
    {
        DataTable dt = dtGetSuperintendentFunctionalAcctUsers();

        List<SuperintendentFunctionalAcctUser> superintendentFunctionalAcctUsers = new List<SuperintendentFunctionalAcctUser>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            superintendentFunctionalAcctUsers.Add(new SuperintendentFunctionalAcctUser(dr));
        }
        return superintendentFunctionalAcctUsers;
    }

    public static List<SuperintendentFunctionalAcctUserDetails> lstGetSuperintendentFunctionalAcctUsersBySuperintendent(int iSuperintendentId)
    {
        DataTable dt = dtGetSuperintendentFunctionalAcctUsersBySuperintendent(iSuperintendentId);

        List<SuperintendentFunctionalAcctUserDetails> superintendentFunctionalAcctUsers = new List<SuperintendentFunctionalAcctUserDetails>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            superintendentFunctionalAcctUsers.Add(new SuperintendentFunctionalAcctUserDetails(dr));
        }
        return superintendentFunctionalAcctUsers;
    }
}

public class SuperintendentFunctionalAcctUserDetails
{
    public int acctUserId { get; set; }
    public int superintendetId { get; set; }
    public string userName { get; set; }
    public string fullName { get; set; }
    public string refind { get; set; }
    public string email { get; set; }

    public SuperintendentFunctionalAcctUserDetails()
    {

    }

    public SuperintendentFunctionalAcctUserDetails(DataRow dr)
    {
        acctUserId = int.Parse(dr["ID_ACCTUSER"].ToString());
        superintendetId = int.Parse(dr["ID_SUPERINTENDENT"].ToString());
        userName = dr["USERNAME"].ToString();
        fullName = dr["FULLNAME"].ToString();
        refind = dr["REFIND"].ToString();
        email = dr["EMAIL"].ToString();
    }
}