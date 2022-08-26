using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


/// <summary>
/// Summary description for LkUpProjectType
/// </summary>
public class LkUpProjectType
{
    public int m_iProjectType { get; set; }
    public string m_sProjectType { get; set; }

	public LkUpProjectType()
	{
		//
		// 
		//
	}

    public LkUpProjectType(DataRow dr)
    {
        m_iProjectType = int.Parse(dr["IDTYPE"].ToString());
        m_sProjectType = dr["PROJTYPE"].ToString();
    }

    public DataTable dtGetAllProjectTypes()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectTypes();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetProjectTypeById(int iProjTypeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectTypeById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":TypeId";
        param.Value = iProjTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public LkUpProjectType objGetProjectTypeById(int iProjTypeId)
    {
        DataTable dt = dtGetProjectTypeById(iProjTypeId);

        LkUpProjectType oLkUpProjectType = new LkUpProjectType();
        foreach (DataRow dr in dt.Rows)
        {
            oLkUpProjectType = new LkUpProjectType(dr);
        }
        return oLkUpProjectType;
    }

    public List<LkUpProjectType> lstGetProjectTypes()
    {
        DataTable dt = dtGetAllProjectTypes();

        List<LkUpProjectType> oProjects = new List<LkUpProjectType>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oProjects.Add(new LkUpProjectType(dr));
        }
        return oProjects;
    }

}