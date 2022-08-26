using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for LkUpLeanTeam
/// </summary>

public class LkUpLeanTeam
{
    public int iTeamId { get; set; }
    public string sTeam { get; set; }

    public LkUpLeanTeam()
    {
        //
        // 
        //
    }

    public LkUpLeanTeam(DataRow dr)
    {
        iTeamId = int.Parse(dr["TEAMID"].ToString());
        sTeam = dr["TEAM"].ToString();
    }
}

public class LkUpLeanTeamHelper
{
    public LkUpLeanTeamHelper()
    {

    }

    public DataTable dtGetLeanTeam()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanTeam();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetLeanTeamById(int iTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanTeamById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = iTeamId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public LkUpLeanTeam objGetLeanTeamById(int iTeamId)
    {
        DataTable dt = dtGetLeanTeamById(iTeamId);

        LkUpLeanTeam oLkUpLeanTeam = new LkUpLeanTeam();
        foreach (DataRow dr in dt.Rows)
        {
            oLkUpLeanTeam = new LkUpLeanTeam(dr);
        }
        return oLkUpLeanTeam;
    }

    public List<LkUpLeanTeam> lstGetLeanTeam()
    {
        DataTable dt = dtGetLeanTeam();

        List<LkUpLeanTeam> oLeanTime = new List<LkUpLeanTeam>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oLeanTime.Add(new LkUpLeanTeam(dr));
        }
        return oLeanTime;
    }
}