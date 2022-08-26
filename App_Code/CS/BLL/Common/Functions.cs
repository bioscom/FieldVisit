using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Functions
/// </summary>
public class Functions
{
    public int m_iFunctionId { get; set; }
    public string m_sFunction { get; set; }

	public Functions()
	{
		//
		// 
		//
	}

    public Functions(DataRow dr)
    {
        m_iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());
        m_sFunction = dr["FUNCTION"].ToString();
    }
}

public class FunctionMgt
{
    public FunctionMgt()
    {
        
    }

    public DataTable dtGetFunctions()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getFunctions();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFunctionById(int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getFunctionById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":FUNCTIONID";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Functions objGetFunctionById(int iDeptId)
    {
        DataTable dt = dtGetFunctionById(iDeptId);

        Functions Depts = new Functions();
        foreach (DataRow dr in dt.Rows)
        {
            Depts = new Functions(dr);
        }
        return Depts;
    }

    public List<Functions> lstGetFunctions()
    {
        DataTable dt = dtGetFunctions();

        List<Functions> Depts = new List<Functions>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            Depts.Add(new Functions(dr));
        }
        return Depts;
    }
}