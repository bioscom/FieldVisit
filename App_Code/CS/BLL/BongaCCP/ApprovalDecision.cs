using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ApprovalDecision
/// </summary>
public class ApprovalDecision
{
    public int m_iApprovalId { get; set; }
    public string m_sDecision { get; set; }
    public string m_ColorCode { get; set; }

    public ApprovalDecision()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ApprovalDecision(DataRow dr)
    {
        m_iApprovalId = int.Parse(dr["APPROVALID"].ToString());
        m_sDecision = dr["DECISION"].ToString();
        m_ColorCode = dr["COLORCODE"].ToString();
    }
}


public class ApprovalDecisionMgt
{
    public DataTable dtGetApprovalDecisions()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getApprovalDecisions();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public ApprovalDecision objGetApprovalDecisionById(int iApprovalId)
    {
        DataTable dt = dtGetApprovalDecisions().AsEnumerable().Where(t => t.Field<decimal>("APPROVALID") == iApprovalId).CopyToDataTable();
        var o = new ApprovalDecision();
        foreach (DataRow dr in dt.Rows)
        {
            o = new ApprovalDecision(dr);
        }
        return o;
    }
    public List<ApprovalDecision> lstGetApprovalDecisions()
    {
        DataTable dt = dtGetApprovalDecisions();

        List<ApprovalDecision> o = new List<ApprovalDecision>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new ApprovalDecision(dr));
        }
        return o;
    }

}