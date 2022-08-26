using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ContractActivitiesRecordedHelper
/// </summary>
public class ContractActivitiesRecordedHelper
{
	public ContractActivitiesRecordedHelper()
	{
		//
		// 
		//
	}


    public DataTable dtGet14DayContract()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.get14DayContract();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGet14DayContracts()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.get14DayContracts();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGet14DayContractByDistrict(int iDistrictId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.get14DayContractByDistrict();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGet14DayContractByDistrictStartDate(int iDistrictId, DateTime dTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.get14DayContractByDistrictStartDate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGet14DayContractByDistrictStartDate2(int iDistrictId, DateTime dTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.get14DayContractByDistrictStartDate2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGet14DayContractByTripStartDateActivityId(int iActivityId, DateTime dTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.get14DayContractByTripStartDateActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetGetContractActivitiesRecordedByID(long lFourteenId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getGetContractActivitiesRecordedByID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lFourteenId";
        param.Value = lFourteenId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public bool Insert14DayContract(ContractActivitiesRecorded oContractActivitiesRecorded)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.Insert14DayContract();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oContractActivitiesRecorded.dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oContractActivitiesRecorded.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = oContractActivitiesRecorded.iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oContractActivitiesRecorded.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dTarget";
        param.Value = (oContractActivitiesRecorded.dTarget == null) ? DBNull.Value : (object)oContractActivitiesRecorded.dTarget;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay1";
        param.Value = (oContractActivitiesRecorded.dDay1 == null) ? DBNull.Value : (object)oContractActivitiesRecorded.dDay1;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay2";
        param.Value = oContractActivitiesRecorded.dDay2 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay2;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay3";
        param.Value = oContractActivitiesRecorded.dDay3 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay3;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay4";
        param.Value = oContractActivitiesRecorded.dDay4 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay4;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay5";
        param.Value = oContractActivitiesRecorded.dDay5 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay5;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay6";
        param.Value = oContractActivitiesRecorded.dDay6 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay6;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay7";
        param.Value = oContractActivitiesRecorded.dDay7 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay7;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay8";
        param.Value = oContractActivitiesRecorded.dDay8 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay8;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay9";
        param.Value = oContractActivitiesRecorded.dDay9 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay9;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay10";
        param.Value = oContractActivitiesRecorded.dDay10 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay10;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay11";
        param.Value = oContractActivitiesRecorded.dDay11 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay11;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay12";
        param.Value = oContractActivitiesRecorded.dDay12 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay12;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay13";
        param.Value = oContractActivitiesRecorded.dDay13 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay13;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay14";
        param.Value = oContractActivitiesRecorded.dDay14 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay14;
        param.DbType = DbType.Decimal;
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

    public bool Insert14DayContract2(ContractActivitiesRecorded oContractActivitiesRecorded)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.Insert14DayContract2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oContractActivitiesRecorded.dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oContractActivitiesRecorded.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = oContractActivitiesRecorded.iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oContractActivitiesRecorded.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dTarget";
        param.Value = (oContractActivitiesRecorded.dTarget == null) ? DBNull.Value : (object)oContractActivitiesRecorded.dTarget;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActual";
        param.Value = (oContractActivitiesRecorded.dActual == null) ? DBNull.Value : (object)oContractActivitiesRecorded.dActual;
        param.DbType = DbType.Decimal;
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


    public bool Update14DayContract(ContractActivitiesRecorded oContractActivitiesRecorded)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.Update14DayContract();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lFourteenDayId";
        param.Value = oContractActivitiesRecorded.lFourteenDayId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dTarget";
        param.Value = (oContractActivitiesRecorded.dTarget == null) ? DBNull.Value : (object)oContractActivitiesRecorded.dTarget;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oContractActivitiesRecorded.dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oContractActivitiesRecorded.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = oContractActivitiesRecorded.iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oContractActivitiesRecorded.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay1";
        param.Value = oContractActivitiesRecorded.dDay1 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay1;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay2";
        param.Value = oContractActivitiesRecorded.dDay2 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay2;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay3";
        param.Value = oContractActivitiesRecorded.dDay3 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay3;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay4";
        param.Value = oContractActivitiesRecorded.dDay4 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay4;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay5";
        param.Value = oContractActivitiesRecorded.dDay5 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay5;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay6";
        param.Value = oContractActivitiesRecorded.dDay6 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay6;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay7";
        param.Value = oContractActivitiesRecorded.dDay7 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay7;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay8";
        param.Value = oContractActivitiesRecorded.dDay8 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay8;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay9";
        param.Value = oContractActivitiesRecorded.dDay9 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay9;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay10";
        param.Value = oContractActivitiesRecorded.dDay10 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay10;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay11";
        param.Value = oContractActivitiesRecorded.dDay11 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay11;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay12";
        param.Value = oContractActivitiesRecorded.dDay12 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay12;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay13";
        param.Value = oContractActivitiesRecorded.dDay13 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay13;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDay14";
        param.Value = oContractActivitiesRecorded.dDay14 == null ? DBNull.Value : (object)oContractActivitiesRecorded.dDay14;
        param.DbType = DbType.Decimal;
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

    public bool Update14DayContract2(ContractActivitiesRecorded oContractActivitiesRecorded)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.Update14DayContract2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dTarget";
        param.Value = (oContractActivitiesRecorded.dTarget == null) ? DBNull.Value : (object)oContractActivitiesRecorded.dTarget;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActual";
        param.Value = (oContractActivitiesRecorded.dActual == null) ? DBNull.Value : (object)oContractActivitiesRecorded.dActual;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oContractActivitiesRecorded.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = oContractActivitiesRecorded.iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oContractActivitiesRecorded.dtTripStartDate;
        param.DbType = DbType.Date;
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

    public List<ContractActivitiesRecorded> lstGet14DayContractByTripStartDateActivityId(int iActivityId, DateTime dtTripStartDate)
    {
        DataTable dt = dtGet14DayContractByTripStartDateActivityId(iActivityId, dtTripStartDate);

        List<ContractActivitiesRecorded> oRow = new List<ContractActivitiesRecorded>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oRow.Add(new ContractActivitiesRecorded(dr));
        }
        return oRow;
    }

    public ContractActivitiesRecorded objGetContractActivitiesRecordedById(long lFourteenId)
    {
        DataTable dt = dtGetGetContractActivitiesRecordedByID(lFourteenId);

        ContractActivitiesRecorded oContractActivitiesRecorded = new ContractActivitiesRecorded();
        foreach (DataRow dr in dt.Rows)
        {
            oContractActivitiesRecorded = new ContractActivitiesRecorded(dr);
        }
        return oContractActivitiesRecorded;
    }

}