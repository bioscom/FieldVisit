using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for _14DayContract
/// </summary>
public class _14DayContract
{
    KPISHelper oKPISHelper = new KPISHelper();

    public int m_iForteenId { get; set; }
    public int m_iKpiId { get; set; }
    public decimal m_dTarget { get; set; }
    public decimal m_dActual { get; set; }

    public KPIS eKPIS { get; set; }


    public _14DayContract()
    {
        
    }

    public _14DayContract(DataRow dr)
    {
        m_iForteenId = int.Parse(dr["IDFOURTEEN"].ToString());
        m_iKpiId = int.Parse(dr["IDKPIS"].ToString());
        m_dTarget = decimal.Parse(dr["TARGET"].ToString());
        m_dActual = decimal.Parse(dr["ACTUAL"].ToString());

        //eKPIS = oKPISHelper.objGetPriorityById(m_iPriorityId);
    }
}

public class _14DayContractHelper
{

    public _14DayContractHelper()
    {

    }


    public DataTable dtGet14DayContractByActivityId(long lActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.get14DayContractByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iActivityId";
        param.Value = lActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public _14DayContract objGet14DayContractByActivityId(long lActivityId)
    {
        DataTable dt = dtGet14DayContractByActivityId(lActivityId);

        _14DayContract o14DayContract = new _14DayContract();
        foreach (DataRow dr in dt.Rows)
        {
            o14DayContract = new _14DayContract(dr);
        }
        return o14DayContract;
    }

    public bool Insert14DayContract(decimal dTarget, decimal dActual)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.insertPriority();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":sPriority";
        //param.Value = sPriority;
        //param.DbType = DbType.String;
        //param.Size = 200;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iOrder";
        //param.Value = iOrder;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

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