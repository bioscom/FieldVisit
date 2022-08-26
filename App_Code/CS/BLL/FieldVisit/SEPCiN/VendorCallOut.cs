using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for VendorCallOut
/// </summary>
public class VendorCallOut
{
    public int m_iID_VENDOR { get; set; }
    public long m_iID_ACTIVITYINFO { get; set; }
    public string m_sVENDOR_NAME { get; set; }
    public string m_sCONTACT_PERSON { get; set; }
    public string m_sTELEPHONE { get; set; }
    public string m_sEMAIL_ADDRESS { get; set; }
    public int m_iID_TRADE_TYPE { get; set; }
    public string m_sVENDOR_ADDRESS { get; set; }
    public string m_sTOOLS_MATERIALS { get; set; }

    public TradeType eTradeType
    {
        get
        {
            return TradeType.objGetTradeTypeById(m_iID_TRADE_TYPE);
        }
    }

	public VendorCallOut()
	{
		
	}

    public VendorCallOut(DataRow dr)
    {
        m_iID_VENDOR = int.Parse(dr["ID_VENDOR"].ToString());
        m_iID_ACTIVITYINFO = int.Parse(dr["ID_ACTIVITYINFO"].ToString());
        m_sVENDOR_NAME = dr["VENDOR_NAME"].ToString();
        m_sCONTACT_PERSON = dr["CONTACT_PERSON"].ToString();
        m_sTELEPHONE = dr["TELEPHONE"].ToString();
        m_sEMAIL_ADDRESS = dr["EMAIL_ADDRESS"].ToString();
        m_iID_TRADE_TYPE = int.Parse(dr["ID_TRADE_TYPE"].ToString());
        m_sVENDOR_ADDRESS = dr["VENDOR_ADDRESS"].ToString();
        m_sTOOLS_MATERIALS = dr["TOOLS_MATERIALS"].ToString();
    }

    public static DataTable dtGetVendorCallOut()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVendorCallOut();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetVendorCallOutById(int VendorCallOutId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVendorCallOutById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_VENDOR";
        param.Value = VendorCallOutId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static VendorCallOut objGetPersonnelInfoById(int VendorCallOutId)
    {
        DataTable dt = dtGetVendorCallOutById(VendorCallOutId);

        VendorCallOut xRows = new VendorCallOut();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new VendorCallOut(dr);
        }
        return xRows;
    }

    public static List<VendorCallOut> lstGetVendorCallOut()
    {
        DataTable dt = dtGetVendorCallOut();

        List<VendorCallOut> xRows = new List<VendorCallOut>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new VendorCallOut(dr));
        }
        return xRows;
    }

    public static DataTable dtGetVendorCallOutByActivityId(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVendorCallOutByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static VendorCallOut objGetPersonnelInfoByActivityId(long lActivityId)
    {
        DataTable dt = dtGetVendorCallOutByActivityId(lActivityId);

        VendorCallOut xRows = new VendorCallOut();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new VendorCallOut(dr);
        }
        return xRows;
    }

    public static List<VendorCallOut> lstGetVendorCallOutByActivityId(long iActivityId)
    {
        DataTable dt = dtGetVendorCallOutByActivityId(iActivityId);

        List<VendorCallOut> xRows = new List<VendorCallOut>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new VendorCallOut(dr));
        }
        return xRows;
    }

    // int iID_ACTIVITYINFO, string sVENDOR_NAME, string sCONTACT_PERSON, //string sTELEPHONE, string sEMAIL_ADDRESS, int iTRADE_TYPE, string sVENDOR_ADDRESS, string sTOOLS_MATERIALS)       
    public static bool createVendorCallOut(VendorCallOut eVendor)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.createVendorCallOut();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = eVendor.m_iID_ACTIVITYINFO;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":VENDOR_NAME";
        param.Value = eVendor.m_sVENDOR_NAME;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":CONTACT_PERSON";
        param.Value = eVendor.m_sCONTACT_PERSON;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TELEPHONE";
        param.Value = eVendor.m_sTELEPHONE;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":EMAIL_ADDRESS";
        param.Value = eVendor.m_sEMAIL_ADDRESS;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_TRADE_TYPE";
        param.Value = eVendor.m_iID_TRADE_TYPE;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":VENDOR_ADDRESS";
        param.Value = eVendor.m_sVENDOR_ADDRESS;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TOOLS_MATERIALS";
        param.Value = eVendor.m_sTOOLS_MATERIALS;
        param.DbType = DbType.String;
        param.Size = 2000;
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

    public static bool updateVendorCallOut(int iID_VENDOR, long iID_ACTIVITYINFO, string sVENDOR_NAME, string sCONTACT_PERSON, 
        string sTELEPHONE, string sEMAIL_ADDRESS, int iTRADE_TYPE, string sVENDOR_ADDRESS, string sTOOLS_MATERIALS)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateVendorCallOut();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_VENDOR";
        param.Value = iID_VENDOR;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iID_ACTIVITYINFO;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":VENDOR_NAME";
        param.Value = sVENDOR_NAME;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":CONTACT_PERSON";
        param.Value = sCONTACT_PERSON;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_TRADE_TYPE";
        param.Value = iTRADE_TYPE;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TELEPHONE";
        param.Value = sTELEPHONE;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":EMAIL_ADDRESS";
        param.Value = sEMAIL_ADDRESS;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":VENDOR_ADDRESS";
        param.Value = sVENDOR_ADDRESS;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TOOLS_MATERIALS";
        param.Value = sTOOLS_MATERIALS;
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
