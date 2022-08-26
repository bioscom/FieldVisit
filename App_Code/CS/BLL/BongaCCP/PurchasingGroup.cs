using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for PurchasingGroup
/// </summary>
public class PurchasingGroup
{
    public int m_iGroupId { get; set; }
    public string m_sName { get; set; }

    public PurchasingGroup()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public PurchasingGroup(DataRow dr)
    {
        m_iGroupId = int.Parse(dr["GROUPID"].ToString());
        m_sName = dr["NAME"].ToString();
    }
}

public class PurchasingGroupMgt
{

    public DataTable dtGetPurchasingGroups()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getPurchasingGroups();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPurchasingGroupById(int iGroupId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getPurchasingGroupById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = iGroupId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PurchasingGroup objGetPurchasingGroupById(int iGroupId)
    {
        DataTable dt = dtGetPurchasingGroupById(iGroupId);

        var o = new PurchasingGroup();
        foreach (DataRow dr in dt.Rows)
        {
            o = new PurchasingGroup(dr);
        }
        return o;
    }

    public List<PurchasingGroup> lstGetPurchasingGroup()
    {
        DataTable dt = dtGetPurchasingGroups();

        List<PurchasingGroup> o = new List<PurchasingGroup>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new PurchasingGroup(dr));
        }
        return o;
    }

}