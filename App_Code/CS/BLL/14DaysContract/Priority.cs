using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

public class Priority
{
    public int iPriorityId { get; set; }
    //public int iOrder { get; set; }
    public string sPriority { get; set; }

    public Priority()
    {

    }

    public Priority(DataRow dr)
    {
        iPriorityId = int.Parse(dr["IDPRIORITY"].ToString());
        sPriority = dr["PRIORITY"].ToString();
        //iOrder = int.Parse(dr["IORDER"].ToString());
    }
}

public class PriorityHelper
{
    //Returns all the available data as datatable
    public DataTable dtGetPriorities()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getPriority();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPrioritys()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getPrioritys();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPrioritiesBySection()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getPriorityBySection();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPriorityById(int iPriorityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getPriorityById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = iPriorityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPrioritiesByPriority(string Priority)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.getPriorityByPriority();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sName";
        param.Value = Priority;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public DataTable dtGetUserAssignedCorporatePriorities(int iUserId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureContract.getUserAssignedCorporatePriority();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iUserId";
    //    param.Value = iUserId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //Returns a datarow

    public Priority objGetPriority()
    {
        DataTable dt = dtGetPriorities();

        Priority priority = new Priority();
        foreach (DataRow dr in dt.Rows)
        {
            priority = new Priority(dr);
        }
        return priority;
    }

    public Priority objGetPriorityById(int iPriorityId)
    {
        DataTable dt = dtGetPriorityById(iPriorityId);

        Priority priority = new Priority();
        foreach (DataRow dr in dt.Rows)
        {
            priority = new Priority(dr);
        }
        return priority;
    }

    //Returns all the data as a collection of corporatePriority list
    public List<Priority> lstGetPriority()
    {
        DataTable dt = dtGetPrioritys();

        List<Priority> priorities = new List<Priority>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            priorities.Add(new Priority(dr));
        }

        return priorities;
    }

    public List<Priority> lstGetPriorityBySection()
    {
        DataTable dt = dtGetPrioritiesBySection();

        List<Priority> priorities = new List<Priority>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            priorities.Add(new Priority(dr));
        }

        return priorities;
    }

    //public List<corporatePriority> lstGetUserAssignedCorporatePriorities(int iUserId)
    //{
    //    DataTable dt = dtGetUserAssignedCorporatePriorities(iUserId);

    //    List<corporatePriority> priorities = new List<corporatePriority>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        priorities.Add(new corporatePriority(dr));
    //    }

    //    return priorities;
    //}

    public bool createPriority(string sPriority, int iOrder)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.insertPriority();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sPriority";
        param.Value = sPriority;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOrder";
        param.Value = iOrder;
        param.DbType = DbType.Int32;
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

    public bool updatePriority(string sPriority, int iOrder, int PriorityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.updatePriority();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sPriority";
        param.Value = sPriority;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOrder";
        param.Value = iOrder;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPriorityId";
        param.Value = PriorityId;
        param.DbType = DbType.Int32;
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
