using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for FacilityAssetGM
/// </summary>
public class FacilityAssetGM
{
    public int m_iFacilityGMId { get; set; }
    public int m_iFacilityId { get; set; }
    public int m_iUserId { get; set; }
	public FacilityAssetGM()
	{
		//
		// 
		//
	}
    public FacilityAssetGM(DataRow dr)
    {
        m_iFacilityGMId = int.Parse(dr["IDFACILITYGM"].ToString());
        m_iFacilityId = int.Parse(dr["IDFACILITY"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
    }
}

public class FacilityAssetGMHelper
{
    public FacilityAssetGMHelper()
    {
        //
        // 
        //
    }

    public DataTable dtGetFacilityAssetGM(int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilitAssetGMByFacilityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public FacilityAssetGM objGetFacilityAssetGMByFacilityId(int iFacilityId)
    {
        DataTable dt = dtGetFacilityAssetGM(iFacilityId);

        FacilityAssetGM oFacilityAssetGM = new FacilityAssetGM();
        foreach (DataRow dr in dt.Rows)
        {
            oFacilityAssetGM = new FacilityAssetGM(dr);
        }
        return oFacilityAssetGM;
    }
    public bool AssignFacilityToAssetGM(int iUserId, int iFacilityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.InsertFacilityAssetGM();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
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
    public bool UpdateFacilityAssetGM(int iUserId, int iFacilityId, int iFacilityGMId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateFacilityAssetGM();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityGMId";
        param.Value = iFacilityGMId;
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

    public static DataTable dtGetFacilitiesAssignedToGM(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilitiesAssignedToGMr();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<FacilityAssetGM> lstGetFacilitiesAssignedToGM(int iUserId)
    {
        DataTable dt = dtGetFacilitiesAssignedToGM(iUserId);

        List<FacilityAssetGM> FacilitiesAssignedToGM = new List<FacilityAssetGM>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            FacilitiesAssignedToGM.Add(new FacilityAssetGM(dr));
        }
        return FacilitiesAssignedToGM;
    }

    public static bool bGetIfFacilityHasBeenAssignedToGM(int iUserId, int iFacilityId)
    {
        bool Found = false;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFacilitiesAssignedToGM();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        if (GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count > 0)
        {
            Found = true;
        }

        return Found;
    }

    //public DataTable dtGetFacilityByRequestId(long lRequestId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureFlareWaiver.getFacilitiesByRequestId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":lRequestId";
    //    param.Value = lRequestId;
    //    param.DbType = DbType.Int64;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public List<RequestFacility> lstGetFacilitiesByRequestId(long lRequestId)
    //{
    //    DataTable dt = dtGetFacilityByRequestId(lRequestId);

    //    List<RequestFacility> oFacilities = new List<RequestFacility>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        oFacilities.Add(new RequestFacility(dr));
    //    }
    //    return oFacilities;
    //}

}
