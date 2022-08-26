using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for AppsVisitors
/// </summary>
public class AppsVisitors
{
    public long lIdLogon { get; set; }
    public DateTime DateLogon { get; set; }
    public string TimeLogon { get; set; }
    public string UsersNames { get; set; }


    public AppsVisitors()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public AppsVisitors(DataRow dr)
    {
        lIdLogon = long.Parse(dr["IDLOGON"].ToString());
        DateLogon = DateTime.Parse(dr["DATELOGON"].ToString());
        TimeLogon = dr["TIMELOGON"].ToString();
        UsersNames = dr["USERSNAMES"].ToString();
    }
}


public class AppsVisitorsHelper
{
    public AppsVisitorsHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable DtGetLogonUserToday()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetTodayLogonUsers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDateLogon";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public AppsVisitors ObjGetLogonUsersToday()
    {
        DataTable dt = DtGetLogonUserToday();

        AppsVisitors oRows = new AppsVisitors();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new AppsVisitors(dr);
        }
        return oRows;
    }

    public bool Insert(AppsVisitors oAppsVisitors)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.insertLogonUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sTimeLogon";
        param.Value = DateTime.Now.ToShortTimeString();
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDateLogon";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sUsersNames";
        param.Value = oAppsVisitors.UsersNames;
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

    public bool Update(AppsVisitors oAppsVisitors)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateLogonUser();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lIdLogon";
        param.Value = oAppsVisitors.lIdLogon;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sUsersNames";
        param.Value = oAppsVisitors.UsersNames;
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

