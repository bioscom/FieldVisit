using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for PurchasingGroup
/// </summary>
public class RequestStatus
{
    public int m_iStatusId { get; set; }
    public string m_sStatus { get; set; }

    public RequestStatus()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public RequestStatus(DataRow dr)
    {
        m_iStatusId = int.Parse(dr["STATUSID"].ToString());
        m_sStatus = dr["STATUS"].ToString();
    }
}

public class RequestStatusMgt
{

    public DataTable dtGetRequestStatus()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getRequestStatus();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetRequestStatusById(int iStatusId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getRequestStatusById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatusId";
        param.Value = iStatusId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public RequestStatus objGetRequestStatusById(int iStatusId)
    {
        DataTable dt = dtGetRequestStatusById(iStatusId);

        var o = new RequestStatus();
        foreach (DataRow dr in dt.Rows)
        {
            o = new RequestStatus(dr);
        }
        return o;
    }

    public List<RequestStatus> lstGetRequestStatus()
    {
        DataTable dt = dtGetRequestStatus();

        List<RequestStatus> o = new List<RequestStatus>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new RequestStatus(dr));
        }
        return o;
    }

}