using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ActivityDetails
/// </summary>
public class ActivityDetails
{
    public long m_lDetailsId { get; set; }
    public string m_sDescription { get; set; }
    //public decimal m_dAmount { get; set; }
    public decimal m_dQuantity { get; set; }
    public decimal m_dRate { get; set; }
    public long m_lCommitmentId { get; set; }

    public ActivityDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ActivityDetails(DataRow dr)
    {
        m_lDetailsId = long.Parse(dr["DETAILSID"].ToString());
        m_sDescription = dr["DESCRIPTION"].ToString();
        m_dQuantity = string.IsNullOrEmpty(dr["QUANTITY"].ToString()) ? 0 : decimal.Parse(dr["QUANTITY"].ToString());
        m_dRate = string.IsNullOrEmpty(dr["RATE"].ToString()) ? 0 : decimal.Parse(dr["RATE"].ToString());
        m_lCommitmentId = long.Parse(dr["COMMITMENTID"].ToString());
    }
}

public class ActivityDetailsMgt
{
    public ActivityDetailsMgt()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Insert(ActivityDetails o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.InsertCommitmentDetails();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = o.m_lCommitmentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":sDescription";
        param.Value = o.m_sDescription;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dQuantity";
        param.Value = o.m_dQuantity;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRate";
        param.Value = o.m_dRate;
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

    public bool Update(ActivityDetails o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.UpdateCommitmentDetails();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDetailsId";
        param.Value = o.m_lDetailsId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDescription";
        param.Value = o.m_sDescription;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dQuantity";
        param.Value = o.m_dQuantity;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRate";
        param.Value = o.m_dRate;
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

    public bool Delete(long lDetailId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.DeleteCommitmentDetails();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDetailId";
        param.Value = lDetailId;
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
        // result will be 1 in case of success
        return (result != -1);
    }

    public DataTable dtGetCommitmentDetailsByCommitmentId(long lCommitmentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getCommitmentMasterDetails();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = lCommitmentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetCommitmentDetailsById(long lDetailId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getCommitmentDetailsById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDetailId";
        param.Value = lDetailId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public ActivityDetails objGetActivityDetailsById(long lDetailId)
    {
        DataTable dt = dtGetCommitmentDetailsById(lDetailId);

        var o = new ActivityDetails();
        foreach (DataRow dr in dt.Rows)
        {
            o = new ActivityDetails(dr);
        }
        return o;
    }

    public List<ActivityDetails> lstGetActivityDetailsById(long lCommitmentId)
    {
        DataTable dt = dtGetCommitmentDetailsByCommitmentId(lCommitmentId);

        List<ActivityDetails> o = new List<ActivityDetails>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new ActivityDetails(dr));
        }
        return o;

    }
}