using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for FlareViolationMailList
/// </summary>
public class FlareViolationMailList
{
    public int iViolationId { get; set; }
    public int iUserId { get; set; }

	public FlareViolationMailList()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public FlareViolationMailList(DataRow dr)
    {
        iViolationId = int.Parse(dr["VIOLATIONID"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }

    public DataTable dtGetViolationMailList()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getViolationMailList();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetViolationMailListByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getViolationMailListByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public FlareViolationMailList objGetViolationMailListByUserId(int iUserId)
    {
        DataTable dt = dtGetViolationMailListByUserId(iUserId);
        FlareViolationMailList o = new FlareViolationMailList();

        foreach (DataRow dr in dt.Rows)
        {
            o = new FlareViolationMailList(dr);
        }
        return o;
    }

    public bool InsertViolationMailList(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.InsertViolationMailList();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return (result != -1);
    }

    public bool UpdateViolationMailList(int iViolationId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateViolationMailList();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iViolationId";
        param.Value = iViolationId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return (result != -1);
    }

    public bool DeleteViolationMailList(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.DeleteViolationMailList();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return (result != -1);
    }


    public List<FlareViolationMailList> lstViolationMailList()
    {
        DataTable dt = dtGetViolationMailList();
        List<FlareViolationMailList> o = new List<FlareViolationMailList>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new FlareViolationMailList(dr));
        }

        return o;
    }

    public List<structUserMailIdx> lstViolationMailReceivers()
    {
        appUsersHelper oK = new appUsersHelper();

        List<structUserMailIdx> o = new List<structUserMailIdx>();
        foreach(FlareViolationMailList oT in lstViolationMailList())
        {
            o.Add(oK.objGetUserByUserID(oT.iUserId).structUserIdx);
        }

        return o;
        //var x = o.Where(p => p.iUserId == 1);
    }
}