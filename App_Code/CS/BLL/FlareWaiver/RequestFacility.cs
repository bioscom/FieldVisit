using System;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;

/// <summary>
/// Summary description for RequestFacility
/// </summary>
public class RequestFacility
{
    public long m_lReqFacId { get; set; }
    public long m_lRequestId { get; set; }
    public int m_iFacilityId { get; set; }

	public RequestFacility()
	{
		//
		// 
		//
	}

    public RequestFacility(DataRow dr)
    {
        m_lReqFacId = long.Parse(dr["ID"].ToString());
        m_lRequestId = long.Parse(dr["IDREQUEST"].ToString());
        m_iFacilityId = int.Parse(dr["IDFACILITY"].ToString());
    }
}

public class RequestFacilityHelper
{
    public RequestFacilityHelper()
	{
       
	}

    public bool InsertFacilityForRequest(long lRequestId, int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.InsertFacilityForRequest();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
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
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public DataTable dtGetFacilityByRequestId(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilitiesByRequestId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<RequestFacility> lstGetFacilitiesByRequestId(long lRequestId)
    {
        DataTable dt = dtGetFacilityByRequestId(lRequestId);

        List<RequestFacility> oFacilities = new List<RequestFacility>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oFacilities.Add(new RequestFacility(dr));
        }
        return oFacilities;
    }

    //public static Facility objGetFacilityById(int iFacilityId)
    //{
    //    DataTable dt = dtGetFacilityById(iFacilityId);

    //    Facility oFacility = new Facility();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        oFacility = new Facility(dr);
    //    }
    //    return oFacility;
    //}
}