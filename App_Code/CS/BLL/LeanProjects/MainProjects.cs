using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;

/// <summary>
/// Summary description for MainProjects
/// </summary>
public class MainProjects
{
    public long lProjectId { get; set; }
    public string sProjectCode { get; set; }
    public string sTitle { get; set; }
    public int iYear { get; set; }
    public int iType { get; set; }
    public int iDept { get; set; }
    public int iFunction { get; set; }
    public int iChampion { get; set; }
    public int iFocalPointId { get; set; }
    public int iSponsor { get; set; }
    public int iManager { get; set; }
    //public int iCoach { get; set; }
    public string sOpportunity { get; set; }
    public string sBusinessCase { get; set; }
    public string sGoals { get; set; }
    public string sInScope { get; set; }
    public string sOutScope { get; set; }
    public string sPotentialBlokers { get; set; }
    public string sComments { get; set; }

    public string sCTReduction { get; set; }
    public string sCostReduction { get; set; }
    public string sProductionBarrel { get; set; }
    public string sNumber { get; set; }
    public string sBenefits { get; set; }
    public string sPotentialBenftComments { get; set; }

    public DateTime dtIdentifySD { get; set; }
    public DateTime dtIdentifyED { get; set; }
    public DateTime dtEliminateSD { get; set; }
    public DateTime dtEliminateED { get; set; }
    public DateTime dtSustainSD { get; set; }
    public DateTime dtSustainED { get; set; }


    public MainProjects()
    {
        //
        // 
        //
    }

    public MainProjects(DataRow dr)
    {
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        sProjectCode = dr["PROJECTCODE"].ToString();
        sTitle = dr["TITLE"].ToString();
        iYear = int.Parse(dr["YYEAR"].ToString());
        iType = int.Parse(dr["IDTYPE"].ToString());
        iDept = int.Parse(dr["IDDEPARTMENT"].ToString());
        iFunction = int.Parse(dr["FUNCTIONID"].ToString());
        iSponsor = int.Parse(dr["USERID"].ToString());
        iChampion = int.Parse(dr["CHAMPIONUSERID"].ToString());
        iFocalPointId = int.Parse(dr["FOCALPOINTID"].ToString());
        iManager = int.Parse(dr["MANAGERUSERID"].ToString());
        //iCoach = int.Parse(dr["COACHUSERID"].ToString());
        sOpportunity = dr["OPPORTUNITY"].ToString();
        sGoals = dr["GOALS"].ToString();
        sInScope = dr["INSCOPE"].ToString();
        sOutScope = dr["OUTSCOPE"].ToString();
        sPotentialBlokers = dr["POTENTIALBLOCKERS"].ToString();
        sComments = dr["COMMENTS"].ToString();
        sBusinessCase = dr["BUZCASE"].ToString();

        sCTReduction = dr["CTREDUCTION"].ToString();
        sCostReduction = dr["COSTREDUCTION"].ToString();
        sProductionBarrel = dr["PRODUCTIONBARREL"].ToString();
        sNumber = dr["NUMBERRS"].ToString();
        sBenefits = dr["BENEFITS"].ToString();
        sPotentialBenftComments = dr["POTENTIALBENFTCOMMENTS"].ToString();

        DateTime sTest = DateTime.Today.Date;

        //dtIdentifySD = DateTime.TryParse(dr["IDENTIFYSD"].ToString(), out sTest) ? sTest : DateTime.Parse(dr["IDENTIFYSD"].ToString());
        dtIdentifySD = DateTime.Parse(dr["IDENTIFYSD"].ToString());
        dtIdentifyED = DateTime.Parse(dr["IDENTIFYED"].ToString());
        dtEliminateSD =  DateTime.Parse(dr["ELIMINATESD"].ToString());
        dtEliminateED = DateTime.Parse(dr["ELIMINATEED"].ToString());
        dtSustainSD = DateTime.Parse(dr["SUSTAINSD"].ToString());
        dtSustainED = DateTime.Parse(dr["SUSTAINED"].ToString());
    }
}

public class ProjectTeamMembers
{
    public long lTeamId { get; set; }
    public int iUserId { get; set; }
    public long lProjectId { get; set; }

    public ProjectTeamMembers()
    {
        //
        // 
        //
    }

    public ProjectTeamMembers(DataRow dr)
    {
        lTeamId = long.Parse(dr["IDTEAM"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        iUserId = int.Parse(dr["IDUSERS"].ToString());
    }
}

public class ProjectDrbMembers
{
    public long lDrbId { get; set; }
    public int iUserId { get; set; }
    public long lProjectId { get; set; }

    public ProjectDrbMembers()
    {
        //
        // 
        //
    }

    public ProjectDrbMembers(DataRow dr)
    {
        lDrbId = long.Parse(dr["IDDRB"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}

public class ProjectCoaches
{
    public long lCoachId { get; set; }
    public int iUserId { get; set; }
    public long lProjectId { get; set; }

    public ProjectCoaches()
    {
        //
        // 
        //
    }

    public ProjectCoaches(DataRow dr)
    {
        lCoachId = long.Parse(dr["IDCOACH"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}
