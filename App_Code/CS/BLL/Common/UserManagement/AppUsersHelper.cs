using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Security.Application;
using System.Web;
using CS.DAL;

/// <summary>
/// Summary description for UserMgt
/// This class contains all methods that are used on appUsers class
/// </summary>
/// 
public class appUsersHelper
{
	public appUsersHelper()
	{
		
	}

    public static string activeDirUser()
    {
        string sRet = "";
        try
        {
            sRet = HttpContext.Current.User.Identity.Name;
            int xPos = sRet.LastIndexOf("\\");
            sRet = sRet.Substring(xPos + 1);
            if (sRet.ToLower() == "bioscom")
            {
                sRet = "isaac.bejide-b";
            }
            sRet = sRet + emailClient.c_sShellMailExt;
            sRet = sRet.ToLower();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        return sRet;
    }

    public static string LoginIDNoDomain(string loginID)
    {
        if (loginID.IndexOf("\\") >= 0)
        {
            loginID = loginID.Substring(loginID.IndexOf("\\") + 1);
        }
        return loginID;
    }

    public void selectUsers(GridView grdView, DataTable dt, string SortExpression)
    {
        LoadGridViews LoadMe = new LoadGridViews();
        LoadMe.LoadMyGridView(grdView, dt, SortExpression);
    }

    public static void SearchUser(GridView grdView, string SortExpression, string SearchCriteria)
    {
        LoadGridViews LoadMe = new LoadGridViews();
        LoadMe.LoadMyGridView(grdView, dtGetUser(), SortExpression);
    }

    public static DataTable dtGetUser()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.searchUser();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":sKEY";
        //param.Value = "%" + Encoder.HtmlEncode(SearchCriteria) + "%";
        //param.OracleDbType = OracleDbType.NVarchar2;
        //param.Size = 500;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iStatus";
        //param.Value = (int)appUsersRoles.userStatus.activeUser;
        //param.OracleDbType = OracleDbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetLeanUserBySearch(string SearchCriteria)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.searchLeanUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":SEARCHKEY";
        param.Value = "%" + Encoder.HtmlEncode(SearchCriteria) + "%";
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetUsers4AllApps()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUsers4AllApps();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetAllGetUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getAllUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetLeanUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getLeanUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetBIUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getBIUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetManHrUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getManHrUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGet14DayContractUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.get14DayContractUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFlareWaiverUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getFlareWaiverUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable DtGetPdccUsers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.GetPdccUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetUserByUserID(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetUserByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        param.Direction = ParameterDirection.InputOutput;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        param.Direction = ParameterDirection.InputOutput;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetUserByUserId(int iUserId)
    {
        DataTable dt = dtGetUserByUserId(iUserId);

        appUsers dpmisUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            dpmisUser = new appUsers(dr);
        }
        return dpmisUser;
    }

    public appUsers objGetUserByUserID(int UserID)
    {
        DataTable dt = dtGetUserByUserID(UserID);

        appUsers thisUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            thisUser = new appUsers(dr);
        }
        return thisUser;
    }

    public DataTable dtGetUserByUserName(string sUserName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByUserName();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sUserName";
        param.Value = sUserName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 500;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iStatus";
        //param.Value = (int)appUsersRoles.userStatus.activeUser;
        //param.OracleDbType = OracleDbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetSupportContact(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getSupportContact();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DELIGATED";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetLeanUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getLeanUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetBIUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getBIUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetManHrUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getManHrUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGet14dayContractUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getContractUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareWaiverUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getFlareWaiverUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGet14DayContractUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.get14DayContractUsersByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDCONTRACT";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetPdccUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.GetPdccUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDeligatedUserByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getDeligatedUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDeligated";
        param.Value = (int)appUsersRoles.eDeligation.Deligated;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);
        
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDeligatedUserByRole2(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getDeligatedUserByRoleId2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUserRolesFlrWaiver.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public bool MakeDeligate(int iDeligated, int iUserId)
    {
        DataTable dt = new DataTable();

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.MakeDeligate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDeligated";
        param.Value = iDeligated;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
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

    public bool bRoutePendingRequestToNewDeligate(int iStatus, int iUserId, int iRoleId)
    {
        DataTable dt = new DataTable();

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.RouteRequestToNewDeligate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = iStatus;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
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

    public appUsers objGetUserByRole(int RoleId)
    {
        DataTable dt = dtGetUserByRole(RoleId);

        appUsers thisUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            thisUser = new appUsers(dr);
        }
        return thisUser;
    }

    public appUsers objGetDeligatedUserByRole(int RoleId)
    {
        DataTable dt = dtGetDeligatedUserByRole(RoleId);

        appUsers thisUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            thisUser = new appUsers(dr);
        }
        return thisUser;
    }

    public List<appUsers> lstGetUserByRole(int RoleId)
    {
        DataTable dt = dtGetUserByRole(RoleId);

        List<appUsers> thisUser = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            thisUser.Add(new appUsers(dr));
        }
        return thisUser;
    }

    public List<appUsers> lstGetFlareWaiverUserByRole(int RoleId)
    {
        DataTable dt = dtGetFlareWaiverUserByRole(RoleId);

        List<appUsers> thisUser = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            thisUser.Add(new appUsers(dr));
        }
        return thisUser;
    }

    public List<appUsers> lstGet14DaysContractUserByRole(int RoleId)
    {
        DataTable dt = dtGet14DayContractUserByRole(RoleId);

        List<appUsers> thisUser = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            thisUser.Add(new appUsers(dr));
        }
        return thisUser;
    }

    public List<appUsers> lstGetPdccUserByRole(int RoleId)
    {
        DataTable dt = DtGetPdccUserByRole(RoleId);

        List<appUsers> thisUser = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            thisUser.Add(new appUsers(dr));
        }
        return thisUser;
    }

    public appUsers objGetFlareWaiverUserByRole(int RoleId)
    {
        DataTable dt = dtGetFlareWaiverUserByRole(RoleId);

        appUsers thisUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            thisUser = new appUsers(dr);
        }
        return thisUser;
    }

    public List<appUsers> lstGetBI500UserByRole(int RoleId)
    {
        DataTable dt = dtGetBIUserByRole(RoleId);

        List<appUsers> thisUser = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            thisUser.Add(new appUsers(dr));
        }
        return thisUser;
    }

    public List<appUsers> lstGetSupportContact(int RoleId)
    {
        DataTable dt = dtGetSupportContact(RoleId);

        List<appUsers> thisUser = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            thisUser.Add(new appUsers(dr));
        }
        return thisUser;
    }

    public static DataTable dtGetAppUser(string gidUserName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getOnlineUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":UserName";
        param.Value = gidUserName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetAppUser(string gidUserName)
    {
        DataTable dt = dtGetAppUser(gidUserName);

        appUsers currentUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            currentUser = new appUsers(dr);
        }
        return currentUser;
    }

    public static DataTable dtGetAppUserByName(string sName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByName();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sName";
        param.Value = "%" + sName + "%";
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetAppUserByName(string sName)
    {
        DataTable dt = dtGetAppUserByName(sName);

        appUsers currentUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            currentUser = new appUsers(dr);
        }
        return currentUser;
    }

    public static List<appUsers> lstGetUsersByName(string sName)
    {
        DataTable dt = dtGetAppUserByName(sName);
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            result.Add(new appUsers(dr));
        }

        return result;
    }

    public static bool CreateUserAccount(appUsers oAppUser, ref int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.CreateUserAccount();

        iUserId = GetUserID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDUSER";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERNAME";
        param.Value = oAppUser.m_sUserName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FULLNAME";
        param.Value = oAppUser.m_sFullName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":EMAIL";
        param.Value = oAppUser.m_sUserMail;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = (oAppUser.m_iRoleIdFieldVisit == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdFieldVisit;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDLEAN";
        param.Value = (oAppUser.m_iRoleIdLean == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdLean;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDBI";
        param.Value = (oAppUser.m_iRoleIdBI == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdBI;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDMANHR";
        param.Value = (oAppUser.m_iRoleIdManHr == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdManHr;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDCONTRACT";
        param.Value = (oAppUser.m_iRoleIdContract == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdContract;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDFLR";
        param.Value = (oAppUser.m_iRoleIdFlr == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdFlr;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDPDCC";
        param.Value = (oAppUser.m_iRolePdcc == null) ? DBNull.Value : (object)oAppUser.m_iRolePdcc;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":REFIND";
        param.Value = oAppUser.m_sRefInd;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
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

    public static bool CreateUserAccountEx(appUsers oAppUser)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.CreateUserAccountEx();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERNAME";
        param.Value = oAppUser.m_sUserName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FULLNAME";
        param.Value = oAppUser.m_sFullName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":EMAIL";
        param.Value = oAppUser.m_sUserMail;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":REFIND";
        param.Value = oAppUser.m_sRefInd;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = (oAppUser.m_iRoleIdFieldVisit == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdFieldVisit;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":PASSWORD";
        param.Value = oAppUser.m_sPassword;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDLEAN";
        param.Value = (oAppUser.m_iRoleIdLean == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdLean;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDBI";
        param.Value = (oAppUser.m_iRoleIdBI == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdBI;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDMANHR";
        param.Value = (oAppUser.m_iRoleIdManHr == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdManHr;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDCONTRACT";
        param.Value = (oAppUser.m_iRoleIdContract == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdContract;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDFLR";
        param.Value = (oAppUser.m_iRoleIdFlr == null) ? DBNull.Value : (object)oAppUser.m_iRoleIdFlr;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDPDCC";
        param.Value = (oAppUser.m_iRolePdcc == null) ? DBNull.Value : (object)oAppUser.m_iRolePdcc;
        param.OracleDbType = OracleDbType.Int32;
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

    private static int GetUserID()
    {
        int iUserId = 0;
        try
        {
            DataTable dt = dtGetUserId();
            iUserId = int.Parse(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return iUserId;
    }

    private static DataTable dtGetUserId()
    {
        string sql = "SELECT PROD_USERMGT_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public void GetUsersByRoleId(DropDownList ddlRole, appUserRolesFlrWaiver.userRole eRole)
    {
        ddlRole.Items.Add(new ListItem("Select " + appUserRolesFlrWaiver.userRoleDesc(eRole) + " to hand over requests", "-1"));
        List<appUsers> oUsers = lstGetFlareWaiverUserByRole((int)eRole);
        foreach (appUsers oUser in oUsers)
        {
            ddlRole.Items.Add(new ListItem(oUser.m_sFullName, oUser.m_iUserId.ToString()));
        }
    }

    public static List<appUsers> lstGetUsers()
    {
        DataTable dt = dtGetUsers();
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            result.Add(new appUsers(dr));
        }

        return result;
    }

    public static List<appUsers> lstGetAllUsers()
    {
        DataTable dt = dtGetAllGetUsers();

        List<appUsers> thisUser = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            thisUser.Add(new appUsers(dr));
        }
        return thisUser;
    }

    public static bool editUserAccount4AllApps(int iUserId, int? iRoleFieldVisit, int? iRoleLean, int? iRoleBI, int? iRoleInitMgt, int? iRoleFlr, int? iRoleCostTrans)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.UpdateUser4AllApps();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleFieldVisit;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDLEAN";
        param.Value = iRoleLean;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDBI";
        param.Value = iRoleBI;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDMANHR";
        param.Value = iRoleInitMgt;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDFLR";
        param.Value = iRoleFlr;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEIDPDCC";
        param.Value = iRoleCostTrans;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool editUserAccount(int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.UpdateUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool editLeanUserAccount(int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.updateLeanUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool editBIUserAccount(int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.updateBIUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool editFlrWaierUserAccount(int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.updateFlrWaiverUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool edit14DayContractUserAccount(int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.update14DayContractUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool editManHrUserAccount(int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.updateManHrUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool editPdccUserAccount(int iUserId, int iRole)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.UpdatePdccUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRole;
        param.OracleDbType = OracleDbType.Int32;
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


    public static bool DisableEnableCostSavingAbsoluteValuesRight(int iUserId, int iCostSavingRight)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.EnableCostSavingAbsoluteValuesRight();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":COSTSAVINGABSVAL";
        param.Value = iCostSavingRight;
        param.OracleDbType = OracleDbType.Int32;
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

    public static bool disableUserAccount(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.disableUserAccount();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.disabledMe;
        param.OracleDbType = OracleDbType.Int32;
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

    public static DataTable dtGetUsersByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUsersByRole();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetBIUsersByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getBIUsersByRole();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetLeanUsersByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getLeanUsersByRole();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetFlrWaiverUsersByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getFlrWaiverUsersByRole();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetUsersByName(string sName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUsersByName();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sName";
        param.Value = sName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<appUsers> lstGetOnlineUserByRole(int iRoleId)
    {
        DataTable dt = dtGetUsersByRole(iRoleId);
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            result.Add(new appUsers(dr));
        }

        return result;
    }

    public static List<appUsers> lstGetOnlineBIUserByRole(int iRoleId)
    {
        DataTable dt = dtGetBIUsersByRole(iRoleId);
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            result.Add(new appUsers(dr));
        }

        return result;
    }

    public static List<appUsers> lstGetLeanUsersByRole(int iRoleId)
    {
        DataTable dt = dtGetLeanUsersByRole(iRoleId);
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            result.Add(new appUsers(dr));
        }

        return result;
    }

    public static List<appUsers> lstGetOnlineUsers()
    {
        DataTable dt = dtGetUsers();
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            result.Add(new appUsers(dr));
        }

        return result;
    }

    public static DataTable dtGetOnlineUserByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetOnlineUserByUserId(int iUserId)
    {
        DataTable dt = dtGetOnlineUserByUserId(iUserId);

        appUsers currentUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            currentUser = new appUsers(dr);
        }
        return currentUser;
    }

    public static DataTable dtGetOnlineUserByRoleId(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByRoleId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ROLEID";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetOnlineUserByRoleId(int iRoleId)
    {
        DataTable dt = dtGetOnlineUserByRoleId(iRoleId);

        appUsers currentUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            currentUser = new appUsers(dr);
        }
        return currentUser;
    }

    public static DataTable dtGetOnlineUserByUserName(string sUserName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByUserName();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":UserName";
        param.Value = sUserName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":STATUS";
        //param.Value = (int)appUsersRoles.userStatus.activeUser;
        //param.OracleDbType = OracleDbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetOnlineUserByUserName(string sUserName)
    {
        DataTable dt = dtGetOnlineUserByUserName(sUserName);

        appUsers currentUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            currentUser = new appUsers(dr);
        }
        return currentUser;
    }

    public static appUsers objGetAppUserByUserName(string UserName)
    {
        DataTable dt = dtGetAppUserByUserName(UserName);

        appUsers currentUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            currentUser = new appUsers(dr);
        }
        return currentUser;
    }

    public static DataTable dtGetAppUserByUserName(string UserName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByUserName();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":UserName";
        param.Value = UserName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable DtGetIntMgtApproversByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.GetInitMgtApproversByRole();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetApproversByRole(int iRoleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getApproversByRole();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iRoleId";
        param.Value = iRoleId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<appUsers> lstGetApproversByRole(int iRoleId)
    {
        DataTable dt = dtGetApproversByRole(iRoleId);
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            result.Add(new appUsers(dr));
        }

        return result;
    }

    public static List<appUsers> LstGetInitMgtApproversByRole(int iRoleId)
    {
        DataTable dt = DtGetIntMgtApproversByRole(iRoleId);
        List<appUsers> result = new List<appUsers>(dt.Rows.Count);
        result.AddRange(from DataRow dr in dt.Rows select new appUsers(dr));

        return result;
    }

    public static appUsers UpdateUserAccountPswEx(string sEmail)
    {
        appUsers me = new appUsers();
        string NewPsw = Guid.NewGuid().ToString();

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.updateUserAccountPswEx();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":EMAIL";
        param.Value = sEmail;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":PASSWORD";
        param.Value = NewPsw;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
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
        if (result != -1)
        {
            me = objGetUserByEmailAddress(sEmail);
        }
        return me;
    }

    public static appUsers objGetUserByEmailAddress(string sEmailAddress)
    {
        DataTable dt = dtGetUserByEmailAddress(sEmailAddress);

        appUsers result = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            result = new appUsers(dr);
        }
        return result;
    }

    public static DataTable dtGetUserByEmailAddress(string sEmailAddress)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserByEmailAddress();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":EMAIL";
        param.Value = sEmailAddress;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetUserByGuidPswEx(string sPassword)
    {
        DataTable dt = dtGetUserByGuidPswEx(sPassword);

        appUsers dpmisUser = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            dpmisUser = new appUsers(dr);
        }
        return dpmisUser;
    }

    public static DataTable dtGetUserByGuidPswEx(string sPassword)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getUserAccountByGuidPswEx();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":PASSWORD";
        param.Value = sPassword;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool ResetUserGuidAccountPswEx(string sPassword, string sEmail)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.updateUserAccountPswEx();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":EMAIL";
        param.Value = sEmail;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":PASSWORD";
        param.Value = sPassword;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
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

    public static bool LoginToUserAccountEx(string sUserName, string sPassword)
    {
        bool found = false;

        DataTable dt = dtGetUserByUserIdEx(sUserName, sPassword);
        if (dt.Rows.Count > 0)
        {
            found = true;
        }

        return found;
    }

    public static DataTable dtGetUserByUserIdEx(string sUserName, string sPassword)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.getLoginUserAccountEx();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERNAME";
        param.Value = sUserName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)appUsersRoles.userStatus.activeUser;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":PASSWORD";
        param.Value = sPassword;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static appUsers objGetUserByUserIdEx(string sUserName, string sPassword)
    {
        DataTable dt = dtGetUserByUserIdEx(sUserName, sPassword);

        appUsers oappUsers = new appUsers();
        foreach (DataRow dr in dt.Rows)
        {
            oappUsers = new appUsers(dr);
        }
        return oappUsers;
    }

    public static bool deleteUserProfile(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.DeleteUserProfile();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserid";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)appUsersRoles.userStatus.lockedUser;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 200;
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


    public static void BindUserDataByName(string SortExpression, GridView grdView, TextBox userTextBox)
    {
        DataTable dt = dtGetUser();

        if (dt.Rows.Count > 0)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = SortExpression;
            grdView.DataSource = dv;
            grdView.DataBind();
        }
    }

    //New update: Added on 23, May 2016
    public static bool UpdateUserLastLogOn(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureUserMgt.UpdateLastLogin();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtLastVisit";
        param.Value = DateTime.Now;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
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

    public static DataTable dtGetLastLoggedOn(DateTime o)
    {
        string sql = "SELECT * FROM PROD_USERMGT WHERE TO_CHAR(LASTVISIT, 'DD-MON-YYYY') = :dtLastVisit";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtLastVisit";
        param.Value = o.ToShortDateString();
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetCurrentlyLoggedOn(DateTime o, int t)
    {
        string sql = "SELECT * FROM PROD_USERMGT WHERE TO_CHAR(LASTVISIT, 'DD-MON-YYYY') = :dtLastVisit AND TO_CHAR(LASTVISIT, 'MI') BETWEEN :t1 AND :t2";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtLastVisit";
        param.Value = o.ToShortDateString();
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":t1";
        param.Value = (t - 15); //ie, the numbers of users that logged on in the last 15 minutes.
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":t2";
        param.Value = t;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetTotalVisited()
    {
        string sql = "SELECT * FROM PROD_USERMGT WHERE LASTVISIT IS NOT NULL AND STATUS = '" + (int)appUsersRoles.userStatus.activeUser + "'";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static int iGetNoOfUsersLastLoggedOn(DateTime o)
    {
        DataTable dt = dtGetLastLoggedOn(o);
        return dt.Rows.Count;
    }

    public static int iGetNoOfUsersCurrentlyLoggedOn(DateTime o, int t)
    {
        DataTable dt = dtGetCurrentlyLoggedOn(o, t);
        return dt.Rows.Count;
    }

    public static int iGetNoVisitedSite()
    {
        DataTable dt = dtGetTotalVisited();
        return dt.Rows.Count;
    }
}

//public static appUsers UpdateUserAccountPswEx(string sEmail)
//{
//    appUsers oappUsers = new appUsers();
//    //appUsersHelper oappUsersHelper = new appUsersHelper();

//    string NewPsw = Guid.NewGuid().ToString();

//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.updateUserAccountPswEx();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":EMAIL";
//    param.Value = sEmail;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 500;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":STATUS";
//    param.Value = (int)appUsersRoles.userStatus.activeUser;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":PASSWORD";
//    param.Value = NewPsw;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 1000;
//    comm.Parameters.Add(param);

//    int result = -1;
//    try
//    {
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    if (result != -1)
//    {
//        oappUsers = objGetUserByEmailAddress(sEmail);
//    }
//    return oappUsers;
//}

//public static DataTable dtGetUserByUserIdEx(string sUserName, string sPassword)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.getLoginUserAccountEx();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":USERNAME";
//    param.Value = sUserName;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 200;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":STATUS";
//    param.Value = (int)appUsersRoles.userStatus.activeUser;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":PASSWORD";
//    param.Value = sPassword;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 1000;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public static appUsers objGetUserByUserIdEx(string sUserName, string sPassword)
//{
//    DataTable dt = dtGetUserByUserIdEx(sUserName, sPassword);

//    appUsers dpmisUser = new appUsers();
//    foreach (DataRow dr in dt.Rows)
//    {
//        dpmisUser = new appUsers(dr);
//    }
//    return dpmisUser;
//}

//public static DataTable dtGetUserByGuidPswEx(string sPassword)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.getUserAccountByGuidPswEx();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":STATUS";
//    param.Value = (int)appUsersRoles.userStatus.activeUser;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":PASSWORD";
//    param.Value = sPassword;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 1000;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public static appUsers objGetUserByGuidPswEx(string sPassword)
//{
//    DataTable dt = dtGetUserByGuidPswEx(sPassword);

//    appUsers oappUsers = new appUsers();
//    foreach (DataRow dr in dt.Rows)
//    {
//        oappUsers = new appUsers(dr);
//    }
//    return oappUsers;
//}

//public static bool ResetUserGuidAccountPswEx(string sPassword, string sEmail)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.updateUserAccountPswEx();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":EMAIL";
//    param.Value = sEmail;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 1000;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":STATUS";
//    param.Value = (int)appUsersRoles.userStatus.activeUser;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":PASSWORD";
//    param.Value = sPassword;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 1000;
//    comm.Parameters.Add(param);

//    int result = -1;
//    try
//    {
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    return (result != -1);
//}

//public static DataTable dtGetUserByEmailAddress(string sEmailAddress)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.getUserByEmailAddress();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iStatus";
//    param.Value = (int)appUsersRoles.userStatus.activeUser;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":sEmail";
//    param.Value = sEmailAddress;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 1000;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public static bool UpdateUser(int iUserId, int iRoleId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.UpdateUserAccount();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iUserId";
//    param.Value = iUserId;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iRoleId";
//    param.Value = iRoleId;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    int result = -1;
//    try
//    {
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }

//    return (result != -1);
//}

//public static bool DeleteUser(int iUserId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.DeleteUserAccount();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iUserId";
//    param.Value = iUserId;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iStatus";
//    param.Value = (int)appUsersRoles.userStatus.disabledMe;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    int result = -1;
//    try
//    {
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }

//    return (result != -1);
//}

//===============================================================================

//public static bool LoginToUserAccountEx(string sUserName, string sPassword)
//{
//    bool found = false;

//    DataTable dt = dtGetUserByUserIdEx(sUserName, sPassword);
//    if (dt.Rows.Count > 0)
//    {
//        found = true;
//    }

//    return found;
//}

//public static appUsers objGetAppUser(string gidUserName)
//{
//    DataTable dt = dtGetAppUser(gidUserName);

//    appUsers currentUser = new appUsers();
//    foreach (DataRow dr in dt.Rows)
//    {
//        currentUser = new appUsers(dr);
//    }
//    return currentUser;
//}

//public static appUsers objGetUserByEmailAddress(string sEmailAddress)
//{
//    DataTable dt = dtGetUserByEmailAddress(sEmailAddress);

//    appUsers result = new appUsers();
//    foreach (DataRow dr in dt.Rows)
//    {
//        result = new appUsers(dr);
//    }
//    return result;
//}

//public static appUsers objGetUserByRole(int iRoleId)
//{
//    DataTable dt = dtGetUsersByRole(iRoleId);

//    appUsers result = new appUsers();
//    foreach (DataRow dr in dt.Rows)
//    {
//        result = new appUsers(dr);
//    }
//    return result;
//}

//public static DataTable GetStaffFromCompleteStaffDetails(string lfName)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureFlareWaiver.getUserFromIWH();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":FIRST_NAME";
//    param.Value = lfName;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 500;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":SURNAME";
//    param.Value = lfName;
//    param.OracleDbType = OracleDbType.NVarchar2;
//    param.Size = 500;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public static DataTable dtGetUsers()
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureUserMgt.getUsers();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iStatus";
//    param.Value = (int)appUsersRoles.userStatus.activeUser;
//    param.OracleDbType = OracleDbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}