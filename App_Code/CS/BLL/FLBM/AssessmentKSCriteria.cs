using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssessmentKSCriteria
/// </summary>
public class AssessmentKSCriteria
{
    public long lAssessmentId { get; set; }
    public int iCompetencyId { get; set; }
    public int iProficiencyId { get; set; }
    public string sLevel { get; set; }
    public string sCriteria { get; set; }
    public string sEvidence { get; set; }
    
	public AssessmentKSCriteria()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public AssessmentKSCriteria(DataRow dr)
    {
        lAssessmentId = long.Parse(dr["ASSESSMENTID"].ToString());
        iCompetencyId = int.Parse(dr["COMPETENCEID"].ToString());
        iProficiencyId = int.Parse(dr["PROFICIENCYID"].ToString());
        sLevel = dr["SLEVEL"].ToString();
        sCriteria = dr["CRITERIA"].ToString();
        sEvidence = dr["EVIDENCE"].ToString();
    }

    public bool CreateCriteria(AssessmentKSCriteria oAssessmentKSCriteria)
    {
        return true;
    }

    public bool GetCriteria(AssessmentKSCriteria oAssessmentKSCriteria)
    {
        return true;
    }

    public bool UpdateCriteria(AssessmentKSCriteria oAssessmentKSCriteria)
    {
        return true;
    }

    public bool DeleteCriteria(AssessmentKSCriteria oAssessmentKSCriteria)
    {
        return true;
    }
}