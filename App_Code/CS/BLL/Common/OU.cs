using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for OU
/// </summary>
public class OU
{
    public int m_iOUId { get; set; }
    public string m_sOUS { get; set; }

	public OU()
	{
		//
		// 
		//
	}

    public OU(DataRow dr)
    {
        m_iOUId = int.Parse(dr["IDOU"].ToString());
        m_sOUS = dr["OU"].ToString();
    }
}

public class OUMgt
{
    public OUMgt()
    {
        
    }

    public DataTable dtGetOus()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getOUs();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetOuById(int iOuId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getOUById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDOU";
        param.Value = iOuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public OU objGetOuById(int iOuId)
    {
        DataTable dt = dtGetOuById(iOuId);

        OU result = new OU();
        foreach (DataRow dr in dt.Rows)
        {
            result = new OU(dr);
        }
        return result;
    }

    public List<OU> lstGetOUS()
    {
        DataTable dt = dtGetOus();

        List<OU> Ous = new List<OU>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            Ous.Add(new OU(dr));
        }
        return Ous;
    }
}