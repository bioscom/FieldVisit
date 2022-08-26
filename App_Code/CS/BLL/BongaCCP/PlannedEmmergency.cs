using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for PlannedEmmergency
/// </summary>
public class PlannedEmmergency
{
    public int m_iTypeId { get; set; }
    public string m_sType { get; set; }

    public PlannedEmmergency()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public PlannedEmmergency(DataRow dr)
    {
        m_iTypeId = int.Parse(dr["TYPEID"].ToString());
        m_sType = dr["TYPE"].ToString();
    }
}

public class PlannedEmmergencyMgt
{

    public DataTable dtGetPlannedEmmergency()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getPlanningEmmergency();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPlannedEmmergencyById(int iTypeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getPlanningEmmergencyById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTypeId";
        param.Value = iTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PlannedEmmergency objGetPlannedEmmergencyById(int iTypeId)
    {
        DataTable dt = dtGetPlannedEmmergencyById(iTypeId);

        var o = new PlannedEmmergency();
        foreach (DataRow dr in dt.Rows)
        {
            o = new PlannedEmmergency(dr);
        }
        return o;
    }

    public List<PlannedEmmergency> lstGetPlannedEmmergency()
    {
        DataTable dt = dtGetPlannedEmmergency();

        List<PlannedEmmergency> o = new List<PlannedEmmergency>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new PlannedEmmergency(dr));
        }
        return o;
    }

}