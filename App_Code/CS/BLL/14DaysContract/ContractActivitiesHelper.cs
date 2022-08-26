using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ContractActivitiesHelper
/// </summary>
public class ContractActivitiesHelper
{
	public ContractActivitiesHelper()
	{
		//
		// 
		//
	}

    public void LoadDistrict(DropDownList ddlDistrict)
    {
        ddlDistrict.Items.Clear();
        ddlDistrict.Items.Add(new ListItem("Select District...", "-1"));
        List<DistrictExt> districts = District.lstGetDistrictExt();
        foreach (DistrictExt district in districts)
        {
            ddlDistrict.Items.Add(new ListItem(district.m_sAsset + " - " + district.m_sDistrict, district.m_iDistrictId.ToString()));
        }
    }

    public DataTable dtGetActivitiesByPriority(int iPriorityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getActitiesByPriority();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetActivitiesByPriority2(int iPriorityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getActitiesByPriority2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iBit";
        param.Value = 1; //TODO: You need to ensure this is typed. This may still be for the main time. (15-October, 2014 code review)
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetActivitiesByPriority2TripStartDate(int iPriorityId, int iDistrict, DateTime dtTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getActitiesByPriority2TripStartDate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrict";
        param.Value = iDistrict;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iBit";
        param.Value = 1; //TODO: You need to ensure this is typed. This may still be for the main time. (15-October, 2014 code review)
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public DataTable dtGetActivitiesByActivity(int iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getActitiesByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public ContractActivities objGetActivitiesByActivity(int iActivityId)
    {
        DataTable dt = dtGetActivitiesByActivity(iActivityId);

        ContractActivities oContractActivities = new ContractActivities();
        foreach (DataRow dr in dt.Rows)
        {
            oContractActivities = new ContractActivities(dr);
        }
        return oContractActivities;
    }

    public DataTable dtGetActivitiesByPriorityTripStartDate(int iPriorityId, int iDistrict, DateTime dtTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getActitiesByPriorityTripStartDate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrict";
        param.Value = iDistrict;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iBit";
        param.Value = 1; //TODO: You need to ensure this is typed. This may still be for the main time. (15-October, 2014 code review)
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetOpsSuperintendentByTripStartDate(DateTime dtTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getOpsSuperintendentByTripStartDate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public int objGetOpsSuperintendentByTripStartDated(DateTime dtTripStartDate)
    {
        DataTable dt = dtGetOpsSuperintendentByTripStartDate(dtTripStartDate);

        int iUser = 0;
        foreach (DataRow dr in dt.Rows)
        {
            iUser = int.Parse(dr[0].ToString());
        }
        return iUser;
    }

    public List<ContractActivities> lstActivitiesByPriority(int iPriorityId)
    {
        DataTable dt = dtGetActivitiesByPriority(iPriorityId);

        List<ContractActivities> oActivities = new List<ContractActivities>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oActivities.Add(new ContractActivities(dr));
        }

        return oActivities;
    }

    public bool updateActivityBit(int iBit, int iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.UpdateBit();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iBit";
        param.Value = iBit;
        param.DbType = DbType.Int16;
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

        return (result != -1);
    }

    public bool updateActivityBitCalc(int iBitCalc, int iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.UpdateBitCalc();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iBitCalc";
        param.Value = iBitCalc;
        param.DbType = DbType.Int16;
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

        return (result != -1);
    }


}