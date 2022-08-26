using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FinanceDirecor
/// </summary>


public class CommitmentControlUsers
{
    public int m_iUserId { get; set; }
    public string m_sUserName { get; set; }
    public string m_sUserMail { get; set; }
    public string m_sFullName { get; set; }
    public string m_sRefInd { get; set; }

    public CommitmentControlUsers()
    {

    }

    public CommitmentControlUsers(DataRow dr)
    {
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_sUserName = dr["USERNAME"].ToString();
        m_sUserMail = dr["EMAIL"].ToString();
        m_sFullName = dr["FULLNAME"].ToString();
        m_sRefInd = dr["REFIND"].ToString();
    }

    public structUserMailIdx structUserIdx
    {
        get
        {
            return new structUserMailIdx(m_sFullName, m_sUserMail, m_sUserName);
        }
    }
}

public class FinanceDirecor
{
    public FinanceDirecor()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetFinanceDirectors()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getFinanceDirectors();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public CommitmentControlUsers objGetAdminByUserId(int iUserId)
    {
        var fd = GetFinanceDirectors().AsEnumerable().Where(t => t.Field<decimal>("USERID") == iUserId);
        DataTable dt = fd.CopyToDataTable();

        var o = new CommitmentControlUsers();
        foreach (DataRow dr in dt.Rows)
        {
            o = new CommitmentControlUsers(dr);
        }
        return o;
    }

    public bool AddFianceDirector(int iUserId, int iOuId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.addFinanceDirector();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOuId";
        param.Value = iOuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool RemoveFinanceDirector(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.RemoveFinanceDirector();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

}