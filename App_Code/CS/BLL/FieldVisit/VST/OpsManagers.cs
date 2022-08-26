using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for OpsMgrFunctionalAcctUserDetails
/// </summary>

public class OpsMgrFunctionalAcctUser
{
    public int acctUserId { get; set; }
    public int superintendentId { get; set; }
    public int iUserId { get; set; }
    public appUsers eOpsMgrUser
    {
        get
        {
            return appUsersHelper.objGetUserByUserId(iUserId);
        }       
    }

    public OpsMgrFunctionalAcctUser()
    {

    }

    public OpsMgrFunctionalAcctUser(DataRow dr)
    {
        acctUserId = int.Parse(dr["ID_OPSMGR"].ToString());
        superintendentId = int.Parse(dr["ID_SUPERINTENDENT"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }

    public static DataTable CheckIfSelectedUserExistsForTheSelectedSuperintendent(int iSuperintendent, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getOpsMgrByUserIdSuperintendentId(); 

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

    public static bool insertOpsMgrFunctionalAcctUser(int iSuperintendent, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertOpsMgrFunctionalAcctUser();

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
        comm.CommandText = StoredProcedure.updateOpsMgrFunctionalAcctUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_OPSMGR";
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

    public static DataTable dtGetOpsMgrFunctionalAcctUsersBySuperintendent(int iSuperintendentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getOpsMgrFunctionalAcctUsersBySuperintendent();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_SUPERINTENDENT";
        param.Value = iSuperintendentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetOpsMgrFunctionalAcctUsersByDistrict(int iDistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getOpsMgrFunctionalAcctUsersByDistrict();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDistrict";
        param.Value = iDistrictId;
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

    public static List<OpsMgrFunctionalAcctUserDetails> lstGetOpsMgrAcctDetailsByDistrict(int iDistrictId)
    {
        DataTable dt = dtGetOpsMgrFunctionalAcctUsersByDistrict(iDistrictId);

        List<OpsMgrFunctionalAcctUserDetails> superintendentFunctionalAcctUsers = new List<OpsMgrFunctionalAcctUserDetails>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            superintendentFunctionalAcctUsers.Add(new OpsMgrFunctionalAcctUserDetails(dr));
        }
        return superintendentFunctionalAcctUsers;
    }
}

public class OpsMgrFunctionalAcctUserDetails
{
    public int acctUserId { get; set; }
    public int superintendetId { get; set; }
    public int iDistrict { get; set; }
    public int iUserId { get; set; }

    //public string userName { get; set; }
    //public string fullName { get; set; }
    //public string refind { get; set; }
    //public string email { get; set; }

    public OpsMgrFunctionalAcctUserDetails()
    {

    }

    public OpsMgrFunctionalAcctUserDetails(DataRow dr)
    {
        acctUserId = int.Parse(dr["ID_OPSMGR"].ToString());
        superintendetId = int.Parse(dr["ID_SUPERINTENDENT"].ToString());
        iDistrict = int.Parse(dr["ID_DISTRICT"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}