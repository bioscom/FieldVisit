using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for accountToCharge
/// </summary>

public class accountToCharge
{
    public string m_sAccount { get; set; }
    public string m_sAccountDescription { get; set; }

    public accountToCharge()
    {
        
    }

    public accountToCharge(DataRow dr)
    {
        m_sAccount = dr["ACCOUNT"].ToString();
        m_sAccountDescription = dr["ACCOUNT_DESCRIPTION"].ToString();
    }

    //public static DataTable dtGetAccountsToCharge()
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getAccountToCharge();

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public static List<accountToCharge> lstGetAccountsToCharge()
    //{
    //    DataTable dt = dtGetAccountsToCharge();

    //    List<accountToCharge> asset = new List<accountToCharge>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset.Add(new accountToCharge(dr));
    //    }
    //    return asset;
    //}

    public static DataTable dtGetAccountsToChargeByPrefixText(string PrefixText)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getAccountToChargeByPrefixText();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":TACCOUNT";
        param.Value = PrefixText + "%";
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<accountToCharge> lstGetAccountsToChargeByPrefixText(string PrefixText)
    {
        DataTable dt = dtGetAccountsToChargeByPrefixText(PrefixText);

        List<accountToCharge> asset = new List<accountToCharge>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new accountToCharge(dr));
        }
        return asset;
    }
}