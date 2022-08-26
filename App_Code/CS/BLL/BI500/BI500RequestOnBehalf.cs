using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for BI500RequestOnBehalf
/// </summary>
public class BI500RequestOnBehalf
{
    public long lOnBehalfId { get; set; }
    public long lRequestId { get; set; }
    public string sFullName { get; set; }
    public string sEmailAddress { get; set; }
	public BI500RequestOnBehalf()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public BI500RequestOnBehalf(DataRow dr)
    {
        lOnBehalfId = long.Parse(dr["ONBEHALFID"].ToString());
        lRequestId = long.Parse(dr["IDREQUEST"].ToString());
        sFullName = dr["FULLNAME"].ToString();
        sEmailAddress = dr["EMAILADDRESS"].ToString();
    }
}

public class BI500RequestOnBehalfHelper
{
    public bool InsertOnBehalf(BI500RequestOnBehalf o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.InsertOnbehalf();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = o.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFullName";
        param.Value = o.sFullName;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEmailAddress";
        param.Value = o.sEmailAddress;
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
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateOnBehalf(BI500RequestOnBehalf o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateOnbehalf();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = o.lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFullName";
        param.Value = o.sFullName;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEmailAddress";
        param.Value = o.sEmailAddress;
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
        // result will be 1 in case of success
        return (result != -1);
    }


    public DataTable dtGetRequestOnBehalByRequestId(long lRequestId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getRequestOnbehalf();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRequestId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public BI500RequestOnBehalf objGetBrightIdeaOnbehalfById(long lRequestId)
    {
        DataTable dt = dtGetRequestOnBehalByRequestId(lRequestId);
        BI500RequestOnBehalf o = new BI500RequestOnBehalf();
        foreach (DataRow dr in dt.Rows)
        {
            o = new BI500RequestOnBehalf(dr);
        }
        return o;
    }
}