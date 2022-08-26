using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using System.IO;

/// <summary>
/// Summary description for WeeklyHighlights
/// </summary>
public class WeeklyHighlights
{
    public long lHighlightId { get; set; }
    public int iWeek { get; set; }
    public DateTime dDateFrom { get; set; }
    public DateTime dDateTo { get; set; }
    public DateTime dDateSubmit { get; set; }
    public string sFileName { get; set; }
    public int iUserId { get; set; }
    public byte[] bBlob { get; set; }
    public int iYear { get; set; }

	public WeeklyHighlights()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public WeeklyHighlights(DataRow dr)
    {
        lHighlightId = long.Parse(dr["HIGHLIGHTID"].ToString());
        iWeek = int.Parse(dr["IWEEK"].ToString());
        dDateFrom = DateTime.Parse(dr["DATEFROM"].ToString());
        dDateTo = DateTime.Parse(dr["DATETO"].ToString());
        dDateSubmit = DateTime.Parse(dr["DATESUBMIT"].ToString());
        sFileName = dr["SFILENAME"].ToString();
        iUserId = int.Parse(dr["USERID"].ToString());
        bBlob = (byte[])dr["BLOBFILE"];
        iYear = int.Parse(dr["YYEAR"].ToString());
    }
}

public class WeeklyHighlightsHelper
{
    public WeeklyHighlightsHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable DtGetWeeklyHighlights()
    {
        string sql = "SELECT HIGHLIGHTID, IWEEK, TO_CHAR(DATEFROM, 'DD-MON-YYYY') AS DATEFROM, TO_CHAR(DATETO,  'DD-MON-YYYY') AS DATETO, ";
        sql += "TO_CHAR(DATESUBMIT, 'DD-MON-YYYY') AS DATESUBMIT, SFILENAME, USERID, YYEAR FROM PROD_CBI_WEEKLYHIGHLIGHT";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable DtGetWeeklyHighlightById(long lHighlightId)
    {
        string sql = "SELECT HIGHLIGHTID, IWEEK, DATEFROM, DATETO, DATESUBMIT, SFILENAME, BLOBFILE, USERID, YYEAR FROM PROD_CBI_WEEKLYHIGHLIGHT WHERE HIGHLIGHTID = :lHighlightId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lHighlightId";
        param.Value = lHighlightId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static WeeklyHighlights objGetWeeklyHighlightById(long lHighlightId)
    {
        DataTable dt = DtGetWeeklyHighlightById(lHighlightId);

        WeeklyHighlights o = new WeeklyHighlights();
        foreach (DataRow dr in dt.Rows)
        {
            o = new WeeklyHighlights(dr);
        }
        return o;
    }

    public static DataTable DtGetWeeklyHighlightByWeekYear(int iWeek, int iYear)
    {
        string sql = "SELECT HIGHLIGHTID, IWEEK, DATEFROM, DATETO, DATESUBMIT, SFILENAME, USERID, YYEAR FROM PROD_CBI_WEEKLYHIGHLIGHT ";
        sql += "WHERE IWEEK = :iWeek AND YYEAR = :iYear";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iWeek";
        param.Value = iWeek;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool Insert(WeeklyHighlights oWeeklyHighlights)
    {
        string sql = "INSERT INTO PROD_CBI_WEEKLYHIGHLIGHT (IWEEK, DATEFROM, DATETO, DATESUBMIT, SFILENAME, BLOBFILE, USERID, YYEAR) ";
        sql += "VALUES (:iWeek, :dDateFrom, :dDateTo, :dDateSubmit, :sFileName, :bBlobFile, :iUserId, :iYear)";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":bBlobFile";
        param.Value = oWeeklyHighlights.bBlob;
        param.OracleDbType = OracleDbType.Blob;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iWeek";
        param.Value = oWeeklyHighlights.iWeek;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oWeeklyHighlights.iYear;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateFrom";
        param.Value = oWeeklyHighlights.dDateFrom;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateTo";
        param.Value = oWeeklyHighlights.dDateTo;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateSubmit";
        param.Value = oWeeklyHighlights.dDateSubmit;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileName";
        param.Value = oWeeklyHighlights.sFileName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oWeeklyHighlights.iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);

            //comm.ExecuteNonQuery(); 
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public static bool Update(WeeklyHighlights oWeeklyHighlights, int iYear)
    {
        string sql = "UPDATE PROD_CBI_WEEKLYHIGHLIGHT SET DATEFROM = :dDateFrom, DATETO = :dDateTo, DATESUBMIT = :dDateSubmit, SFILENAME = :sFileName, BLOBFILE = :bBlobFile, USERID = :iUserId ";
        sql += "WHERE IWEEK = :iWeek AND YYEAR = :iYear";   //WHERE HIGHLIGHTID = :lHighlightId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":bBlobFile";
        param.Value = oWeeklyHighlights.bBlob;
        param.OracleDbType = OracleDbType.Blob;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iWeek";
        param.Value = oWeeklyHighlights.iWeek;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateFrom";
        param.Value = oWeeklyHighlights.dDateFrom;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateTo";
        param.Value = oWeeklyHighlights.dDateTo;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateSubmit";
        param.Value = oWeeklyHighlights.dDateSubmit;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileName";
        param.Value = oWeeklyHighlights.sFileName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oWeeklyHighlights.iUserId;
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
}