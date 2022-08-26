using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ContractLessonsLearnt
/// </summary>
public class ContractLessonsLearnt
{
    public long lLessonId { get; set; }
    public int iPriorityId { get; set; }
    public int iDistrictId { get; set; }
    public string sWhat { get; set; }
    public string sWhy { get; set; }
    public string sConsequences { get; set; }
    public DateTime dtTripStartDate { get; set; }
    public int iUserId { get; set; }

    public ContractLessonsLearnt()
    {
        //
        // 
        //
    }

    public ContractLessonsLearnt(DataRow dr)
    {
        lLessonId = long.Parse(dr["IDLESSONS"].ToString());
        iPriorityId = int.Parse(dr["IDPRIORITY"].ToString());
        iDistrictId = int.Parse(dr["ID_DISTRICT"].ToString());
        sWhat = dr["WHAT"].ToString();
        sWhy = dr["WHY"].ToString();
        sConsequences = dr["CONSEQUENCES"].ToString();
        dtTripStartDate = DateTime.Parse(dr["START_DATE"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}


public class ContractLessonsLearntHelper
{

    public ContractLessonsLearntHelper()
    {

    }

    //Get by Priority, StartDate, District

    //Insert Lessons Learnt
    public bool InsertLessonsLearnt(ContractLessonsLearnt oLessonsLearnt)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.InsertLessonsLearnt();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oLessonsLearnt.dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oLessonsLearnt.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = oLessonsLearnt.iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oLessonsLearnt.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sConsequences";
        param.Value = oLessonsLearnt.sConsequences;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWhat";
        param.Value = oLessonsLearnt.sWhat;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWhy";
        param.Value = oLessonsLearnt.sWhy;
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

        return (result != -1);
    }

    //Update Lessons Learnt
    public bool UpdateLessonsLearnt(ContractLessonsLearnt oLessonsLearnt)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.UpdateLessonsLearnt();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oLessonsLearnt.dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oLessonsLearnt.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = oLessonsLearnt.iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oLessonsLearnt.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sConsequences";
        param.Value = oLessonsLearnt.sConsequences;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWhat";
        param.Value = oLessonsLearnt.sWhat;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWhy";
        param.Value = oLessonsLearnt.sWhy;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lLessonId";
        param.Value = oLessonsLearnt.lLessonId;
        param.DbType = DbType.Int64;
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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return (result != -1);
    }

    //Update Lessons Learnt
    public bool DeleteLessonsLearnt(ContractLessonsLearnt oLessonsLearnt)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.DeleteLessonsLearnt();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lLessonId";
        param.Value = oLessonsLearnt.lLessonId;
        param.DbType = DbType.Int64;
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


    public DataTable dtGetLessonsLearntByPriorityDistrictTripStartDate(int iPriorityId, int iDistrictId, DateTime dtTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.GetLessonsLearntByDistrictPriorityTripStartDate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public DataTable dtGetLeadershipActivityByDistrictTripStartDate(int iDistrictId, DateTime dtTripStartDate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.GetLeadershipActivityByDistrictTripStartDate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<ContractLessonsLearnt> lstLessonsLearnt(int iPriorityId, int iDistrictId, DateTime dtTripStartDate)
    {
        DataTable dt = dtGetLessonsLearntByPriorityDistrictTripStartDate(iPriorityId, iDistrictId, dtTripStartDate);

        List<ContractLessonsLearnt> oLessonsLearnt = new List<ContractLessonsLearnt>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oLessonsLearnt.Add(new ContractLessonsLearnt(dr));
        }

        return oLessonsLearnt;
    }
}