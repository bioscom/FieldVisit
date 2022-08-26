using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for RecommendationPotential
/// </summary>
public class BenefitPotential
{
    public long m_lRecommendationId { get; set; }
    public long m_lPotentialId { get; set; }
    public string m_sCTReduction { get; set; }
    public string m_sCostReduction { get; set; }
    public string m_sProductionBarrel { get; set; }
    public string m_sOtherBenefits { get; set; }
    public string m_sComments { get; set; }

    public BenefitPotential()
    {
        //
        // 
        //
    }

    public BenefitPotential(DataRow dr)
    {
        m_lRecommendationId = long.Parse(dr["RECOMMENDATIONID"].ToString());
        m_lPotentialId = long.Parse(dr["POTENTIALID"].ToString());
        m_sCTReduction = dr["CTREDUCTION"].ToString();
        m_sCostReduction = dr["COSTREDUCTION"].ToString();
        m_sProductionBarrel = dr["PRODUCTIONBARREL"].ToString();
        m_sOtherBenefits = dr["OTHERBENEFITS"].ToString();
        m_sComments = dr["COMMENTS"].ToString();
    }
}


public class BenefitPotentialHelper
{
    public BenefitPotentialHelper()
    {
        //
        // 
        //
    }
}