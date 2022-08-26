using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Benefit
/// </summary>
public class Benefits
{
    public int m_iBenefitId { get; set; }
    public string m_sBenefit { get; set; }

	public Benefits()
	{
		//
        //
		//
	}

    public Benefits(DataRow dr)
    {
        m_iBenefitId = int.Parse(dr["IDBENEFIT"].ToString());
        m_sBenefit = dr["BENEFIT"].ToString();
    }
}

public class BenefitsMgt
{
    public BenefitsMgt()
    {
        
    }

    public DataTable dtGetBenefits()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBenefits();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetBenefitById(int iBenefitId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBenefitById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iBenefitId";
        param.Value = iBenefitId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Benefits objGetBenefitById(int iDeptId)
    {
        DataTable dt = dtGetBenefitById(iDeptId);

        Benefits oBenefit = new Benefits();
        foreach (DataRow dr in dt.Rows)
        {
            oBenefit = new Benefits(dr);
        }
        return oBenefit;
    }

    public List<Benefits> lstBenefits()
    {
        DataTable dt = dtGetBenefits();

        List<Benefits> oBenefit = new List<Benefits>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oBenefit.Add(new Benefits(dr));
        }
        return oBenefit;
    }
}


public class PotentialBenefit
{
    public int m_iReplicationId { get; set; }
    public string m_sPotential { get; set; }

    public PotentialBenefit()
    {
        //
        //
        //
    }

    public PotentialBenefit(DataRow dr)
    {
        m_iReplicationId = int.Parse(dr["IDREPLICATION"].ToString());
        m_sPotential = dr["REP_POTENTIAL"].ToString();
    }
}

public class PotentialBenefitMgt
{
    public PotentialBenefitMgt()
    {

    }

    public DataTable dtGetPotentialBenefits()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getPotentialBenefits();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtPotentialBenefitById(int iBenefitId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getPotentialBenefitById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iBenefitId";
        param.Value = iBenefitId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PotentialBenefit objPotentialBenefitById(int iDeptId)
    {
        DataTable dt = dtPotentialBenefitById(iDeptId);

        PotentialBenefit oBenefit = new PotentialBenefit();
        foreach (DataRow dr in dt.Rows)
        {
            oBenefit = new PotentialBenefit(dr);
        }
        return oBenefit;
    }

    public List<PotentialBenefit> lstPotentialBenefit()
    {
        DataTable dt = dtGetPotentialBenefits();

        List<PotentialBenefit> oBenefit = new List<PotentialBenefit>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oBenefit.Add(new PotentialBenefit(dr));
        }
        return oBenefit;
    }
}