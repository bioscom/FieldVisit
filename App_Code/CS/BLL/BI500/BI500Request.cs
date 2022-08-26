using System;
using System.Data;

/// <summary>
/// Summary description for Initiative
/// </summary>

public class CostReductionRequest
{
    public long lRequestId { get; set; }
    public string sRequestNumber { get; set; }
    public int iUserId { get; set; }
    public int iFunctionId { get; set; }
    public int iDeptId { get; set; }
    public int iTeamId { get; set; }
    public string sTitle { get; set; }
    public int iInitiativeLeadUserId { get; set; }
    public int iProjectChampionUserId { get; set; }
    public int iProjectSponsorUserId { get; set; }
    public string sBusinessCase { get; set; }
    public int iBenefitId { get; set; }
    public int iFocalPointUserId { get; set; }
    public DateTime dCompletionDate { get; set; }
    public DateTime dDateSubmitted { get; set; }
    public string sOpportunityStmt { get; set; }
    public string sTeamMembers { get; set; }    
    public int iStatus { get; set; }
    public int iPhase { get; set; }

    public int iImprovement { get; set; }
    public string sImprovement { get; set; }
    public int iReplication { get; set; }
    public string sReplication { get; set; }
    public string sQtyBenefit { get; set; }
    public DateTime dActualDate { get; set; }

    //Request Type is to differentiate between Bright Idea(BI) and Cost Reduction(CR) requests (BI=1, CR=2)
    public int iRequestType { get; set; }
    public string sRetained { get; set; }
    public decimal dActualSavings { get; set; }
    public decimal dTargetSavings { get; set; }
    public int iGate { get; set; }

    public CostReductionRequest()
    {
        //
        // 
        //
    }

    public CostReductionRequest(DataRow dr)
    {
        lRequestId = long.Parse(dr["IDREQUEST"].ToString());
        sRequestNumber = dr["REQUESTNO"].ToString();
        iUserId = int.Parse(dr["USERID"].ToString());
        iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());
        iDeptId = int.Parse(dr["DEPTID"].ToString());
        iTeamId = int.Parse(dr["TEAMID"].ToString());
        sTitle = dr["TITLE"].ToString();
        iInitiativeLeadUserId = (string.IsNullOrEmpty(dr["INITIATIVELEADUSERID"].ToString())) ? 0 : int.Parse(dr["INITIATIVELEADUSERID"].ToString());
        iProjectChampionUserId = (string.IsNullOrEmpty(dr["CHAMPIONUSERID"].ToString())) ? 0 : int.Parse(dr["CHAMPIONUSERID"].ToString());
        iProjectSponsorUserId = (string.IsNullOrEmpty(dr["SPONSORUSERID"].ToString())) ? 0 : int.Parse(dr["SPONSORUSERID"].ToString());
        sBusinessCase = dr["BUS_CASE"].ToString();
        iBenefitId = int.Parse(dr["IDBENEFIT"].ToString());
        iFocalPointUserId = (string.IsNullOrEmpty(dr["FOCALPOINTUSERID"].ToString())) ? 0 : int.Parse(dr["FOCALPOINTUSERID"].ToString());
        dCompletionDate = (string.IsNullOrEmpty(dr["DATE_COMPLETION"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["DATE_COMPLETION"].ToString());
        dDateSubmitted = (string.IsNullOrEmpty(dr["DATE_SUBMITTED"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["DATE_SUBMITTED"].ToString()); //dr["DATE_SUBMITTED"].ToString();
        sOpportunityStmt = dr["OPPORTUNITYSTMT"].ToString();
        sTeamMembers = dr["TEAM_MEMBER"].ToString();
        iStatus = int.Parse(dr["STATUS"].ToString());
        iPhase = int.Parse(dr["PHASE"].ToString());

        sImprovement = dr["IMPROVEMENT"].ToString();
        iImprovement = int.Parse(dr["IDIMPROVEMENT"].ToString());
        sReplication = dr["REP_POTENTIAL"].ToString();
        iReplication = int.Parse(dr["IDREPLICATION"].ToString());

        sQtyBenefit = dr["QTYBENEFIT"].ToString();
        dActualDate = (string.IsNullOrEmpty(dr["ACTUAL_DATE"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["ACTUAL_DATE"].ToString()); //dr["ACTUAL_DATE"].ToString();
        iRequestType = (string.IsNullOrEmpty(dr["REQUESTTYPE"].ToString())) ? 0 : int.Parse(dr["REQUESTTYPE"].ToString());
        sRetained = dr["RETAINED"].ToString();
        dActualSavings = !string.IsNullOrEmpty(dr["AMOUNTSAVED"].ToString()) ? decimal.Parse(dr["AMOUNTSAVED"].ToString()) : 0;
        dTargetSavings = !string.IsNullOrEmpty(dr["TARGETSAVINGS"].ToString()) ? decimal.Parse(dr["TARGETSAVINGS"].ToString()) : 0;
        iGate = int.Parse(dr["GATE"].ToString());
    }
}

public class CostReductionMileStone
{
    public long lMilestoneId { get; set; }
    public long lRequestId { get; set; }
    public string sActivityDescription { get; set; }
    public DateTime dStartDate { get; set; }
    public DateTime dFinishDate { get; set; }
    public decimal dAmountSaved { get; set; }

    public CostReductionMileStone()
    {

    }

    public CostReductionMileStone(DataRow dr)
    {
        lMilestoneId = long.Parse(dr["MILESTONEID"].ToString());
        sActivityDescription = dr["ACTIVITY_DESCRIPTION"].ToString();
        dStartDate = (string.IsNullOrEmpty(dr["START_DATE"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["START_DATE"].ToString());
        dFinishDate = (string.IsNullOrEmpty(dr["FINISH_DATE"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["FINISH_DATE"].ToString());
        lRequestId = long.Parse(dr["IDREQUEST"].ToString());
        dAmountSaved = !string.IsNullOrEmpty(dr["AMOUNTSAVED"].ToString()) ? decimal.Parse(dr["AMOUNTSAVED"].ToString()) : 0;
    }
}

public class CostReductionCadence
{
    public long lCadenceId { get; set; }
    public long lRequestId { get; set; }
    public string sAction { get; set; }
    public string sActionParty { get; set; }
    public string sThreat { get; set; }
    public DateTime dFinishDate { get; set; }
    public int iStatus { get; set; }

    public CostReductionCadence()
    {

    }

    public CostReductionCadence(DataRow dr)
    {
        lCadenceId = long.Parse(dr["CADENCEID"].ToString());
        lRequestId = long.Parse(dr["IDREQUEST"].ToString());
        sAction = dr["ACTION"].ToString();
        sActionParty = dr["ACTIONPARTY"].ToString();
        sThreat = dr["THREAT"].ToString();
        dFinishDate = (string.IsNullOrEmpty(dr["DUEDATE"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["DUEDATE"].ToString());
        iStatus = int.Parse(dr["STATUS"].ToString());
    }
}
