using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for iapWindows
/// </summary>
public class iapWindows
{
    public int m_iIDWindow { get; set; }
    public string m_sWindow { get; set; }
    

	public iapWindows()
	{
		//
		// 
		//
	}

    public iapWindows(DataRow dr)
    {
        m_iIDWindow = int.Parse(dr["ID_WINDOW"].ToString());
        m_sWindow = dr["WINDOW"].ToString();
    }

    public static bool createWindow(iapWindows me)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.CreateIAPWindow();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":WINDOW";
        param.Value = me.m_sWindow;
        param.DbType = DbType.String;
        param.Size = 2000;
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

    public static bool UpdateIAPWindow(iapWindows me)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.UpdateIAPWindow();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_WINDOW";
        param.Value = me.m_iIDWindow;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":WINDOW";
        param.Value = me.m_sWindow;
        param.DbType = DbType.String;
        param.Size = 2000;
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

    public static DataTable dtGetIAPWindows()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getIAPWindows();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetIAPWindowsById(int iIAPWindow)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getIAPWindowsById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_WINDOW";
        param.Value = iIAPWindow;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static iapWindows objGetIAPWindows()
    {
        DataTable dt = dtGetIAPWindows();

        iapWindows iapWins = new iapWindows();
        foreach (DataRow dr in dt.Rows)
        {
            iapWins = new iapWindows(dr);
        }
        return iapWins;
    }

    public static iapWindows objGetIAPWindowById(int iIAPWindow)
    {
        DataTable dt = dtGetIAPWindowsById(iIAPWindow);

        iapWindows iapWins = new iapWindows();
        foreach (DataRow dr in dt.Rows)
        {
            iapWins = new iapWindows(dr);
        }
        return iapWins;
    }

    public static List<iapWindows> lstGetIAPWindows()
    {
        DataTable dt = dtGetIAPWindows();

        List<iapWindows> xRows = new List<iapWindows>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new iapWindows(dr));
        }
        return xRows;
    }
}