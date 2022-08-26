using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for LkUpLeanTime
/// </summary>
public class LkUpLeanTime
{
    public int iTimeId { get; set; }
    public string sUnit { get; set; }
    public string sDescription { get; set; }
    public string sMinConvertion { get; set; }

	public LkUpLeanTime()
	{
		//
		// 
		//
	}

    public LkUpLeanTime(DataRow dr)
    {
        iTimeId = int.Parse(dr["TIMEID"].ToString());
        sUnit = dr["UNIT"].ToString();
        sDescription = dr["DESCRIPTION"].ToString();
        sMinConvertion = dr["MINCONVERT"].ToString();
    }
}

public class LkUpLeanTimeHelper
{
    public LkUpLeanTimeHelper()
    {

    }

    public DataTable dtGetLkUpTime()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanTime();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<LkUpLeanTime> lstGetLkUpLeanTime()
    {
        DataTable dt = dtGetLkUpTime();

        List<LkUpLeanTime> oLeanTime = new List<LkUpLeanTime>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oLeanTime.Add(new LkUpLeanTime(dr));
        }
        return oLeanTime;
    }
}