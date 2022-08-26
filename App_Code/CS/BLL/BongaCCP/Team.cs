using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for PurchasingGroup
/// </summary>
public class Team
{
    public int m_iTeamId { get; set; }
    public string m_sTeam { get; set; }

    public Team()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Team(DataRow dr)
    {
        m_iTeamId = int.Parse(dr["TEAMID"].ToString());
        m_sTeam = dr["NAME"].ToString();
    }
}

public class TeamMgt
{
    Department oD = new Department();

    public DataTable dtGetTeams()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getTeams();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetTeamById(int iTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getTeamById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDepartmentById(int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureCommon.getDepartmentById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public Team objGetTeamById(int iTeamID)
    {
        DataTable dt = dtGetTeamById(iTeamID);

        var o = new Team();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Team(dr);
        }
        return o;
    }

    public List<Team> lstGetTeam()
    {
        DataTable dt = dtGetTeams();

        List<Team> o = new List<Team>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new Team(dr));
        }
        return o;
    }

    public List<Department> lstGetDepartments()
    {
        return oD.lstGetDeparments();
    }

}