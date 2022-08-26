using System;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for CTRAutoNumber
/// </summary>
public static class AutoNumber
{
    static AutoNumber()
    {
        
    }

    public static string GenerateAutoNumber()
    {
        string YY = DateTime.Now.Year.ToString().Remove(0, 2);// YY = year of origin
        string ZZZZ; //project sequencial numbering

        DataTable dt = dtGetAutoNumber();
        string xy = dt.Rows[0]["NEXTVAL"].ToString();

        if (xy.Length == 1) ZZZZ = "000" + xy;
        else if (xy.Length == 2) ZZZZ = "00" + xy;
        else if (xy.Length == 3) ZZZZ = "0" + xy;
        else ZZZZ = xy;

        return "FLRW" + YY + ZZZZ;
    }

    private static DataTable dtGetAutoNumber()
    {
        string sql = "SELECT FLARE_AUTONUMBER_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}

public static class AutoNumberBI500
{
    static AutoNumberBI500()
    {

    }

    public static string GenerateAutoNumber()
    {
        string YY = DateTime.Now.Year.ToString().Remove(0, 2);// YY = year of origin
        string ZZZZ; //project sequencial numbering

        DataTable dt = dtGetAutoNumber();
        string xy = dt.Rows[0]["NEXTVAL"].ToString();

        if (xy.Length == 1) ZZZZ = "000" + xy;
        else if (xy.Length == 2) ZZZZ = "00" + xy;
        else if (xy.Length == 3) ZZZZ = "0" + xy;
        else ZZZZ = xy;

        return "BI" + YY + ZZZZ;
    }

    private static DataTable dtGetAutoNumber()
    {
        string sql = "SELECT BI500_AUTONUMBER_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}