using System;
using System.Data;

/// <summary>
/// Summary description for OpportunityCost
/// </summary>
public class OpportunityCost
{
    public long lOpCost { get; set; }
    public string sOpportunity { get; set; }
    public int iAssetId { get; set; }
    public DateTime dtStartedBy { get; set; }
    public DateTime dtCompletedBy { get; set; }
    public int iSponsor { get; set; }
    public int iActionParty { get; set; }
    public int iAcceptPark { get; set; }
    public int iPriority { get; set; }
    public decimal dOpexYear { get; set; }
    public decimal dFecto { get; set; } //Front End Cost Take Out
    public decimal dImprovement { get; set; }
    public decimal dPotSavings { get; set; }
    public decimal dActSavings { get; set; }
    public int iAsService { get; set; }
    public string sCostCentre { get; set; }
    public string sComments { get; set; }
    public DateTime DtDateUpdated { get; set; }
    public int iYear { get; set; }
    public int iLastUpdatedBy { get; set; }

    public string sAsset { get; set; }
    public string sWorkScope { get; set; }
    public string sSerialNo { get; set; }
    public string sDepartment { get; set; }
    public int iUserId { get; set; }

    public OpportunityCost()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public OpportunityCost(DataRow dr)
    {
        try
        {
            lOpCost = long.Parse(dr["IDOPCOST"].ToString());
            sOpportunity = dr["OPPORTUNITY"].ToString();
            iAssetId = int.Parse(dr["ASSETID"].ToString());

            if (!string.IsNullOrEmpty(dr["SPONSOR"].ToString())) iSponsor = int.Parse(dr["SPONSOR"].ToString());
            if (!string.IsNullOrEmpty(dr["ACTIONPARTY"].ToString())) iActionParty = int.Parse(dr["ACTIONPARTY"].ToString());
            if (!string.IsNullOrEmpty(dr["USERID"].ToString())) iLastUpdatedBy = int.Parse(dr["USERID"].ToString());

            if (!string.IsNullOrEmpty(dr["ACCEPTPARK"].ToString())) iAcceptPark = int.Parse(dr["ACCEPTPARK"].ToString());
            if (!string.IsNullOrEmpty(dr["PRIORITY"].ToString())) iPriority = int.Parse(dr["PRIORITY"].ToString());
            if (!string.IsNullOrEmpty(dr["ASSERV"].ToString())) iAsService = int.Parse(dr["ASSERV"].ToString());
            
            sCostCentre = dr["COSTCENTRE"].ToString();
            sComments = dr["COMMENTS"].ToString();
            
            iYear = int.Parse(dr["YYEAR"].ToString());
            //iLastUpdatedBy = int.Parse(dr["USERID"].ToString());

            dOpexYear = !string.IsNullOrEmpty(dr["OPEX"].ToString()) ? decimal.Parse(dr["OPEX"].ToString()) : 0;

            dFecto = !string.IsNullOrEmpty(dr["FECTO"].ToString()) ? decimal.Parse(dr["FECTO"].ToString()) : 0; //Front End Cost Take Out
            dImprovement = !string.IsNullOrEmpty(dr["IMPROVEMENT"].ToString()) ? decimal.Parse(dr["IMPROVEMENT"].ToString()) : 0;

            dPotSavings = !string.IsNullOrEmpty(dr["POTSAVINGS"].ToString()) ? decimal.Parse(dr["POTSAVINGS"].ToString()) : 0;
            dActSavings = !string.IsNullOrEmpty(dr["ACTSAVINGS"].ToString()) ? decimal.Parse(dr["ACTSAVINGS"].ToString()) : 0;

            DtDateUpdated = !string.IsNullOrEmpty(dr["DATEUPDATED"].ToString()) ? DateTime.Parse(dr["DATEUPDATED"].ToString()) : DateTime.Today.Date;
            dtStartedBy = !string.IsNullOrEmpty(dr["STARTEDBY"].ToString()) ? DateTime.Parse(dr["STARTEDBY"].ToString()) : DateTime.Today.Date;
            dtCompletedBy = !string.IsNullOrEmpty(dr["COMPLETEDBY"].ToString()) ? DateTime.Parse(dr["COMPLETEDBY"].ToString()) : DateTime.Today.Date;

            sAsset = dr["ASSET"].ToString();
            sWorkScope = dr["WORKSCOPE"].ToString();
            sSerialNo = dr["SERIALNO"].ToString();
            sDepartment = dr["DEPARTMENT"].ToString();
            iUserId = !string.IsNullOrEmpty(dr["USERID"].ToString()) ? int.Parse(dr["USERID"].ToString()) : 0;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}

public class OpportunityCostLog
{
    public long lOpCost { get; set; }
    public decimal dOpexYear { get; set; }
    public decimal dFecto { get; set; } //Front End Cost Take Out
    public decimal dImprovement { get; set; }
    public decimal dPotSavings { get; set; }
    public decimal dActSavings { get; set; }
    public DateTime DtDateUpdated { get; set; }
    public string sComments { get; set; }
    public string sWorkScope { get; set; }
    public int iUserId { get; set; }

    public OpportunityCostLog()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public OpportunityCostLog(DataRow dr)
    {
        try
        {
            lOpCost = long.Parse(dr["IDOPCOST"].ToString());
            sComments = dr["COMMENTS"].ToString();

            //iLastUpdatedBy = int.Parse(dr["USERID"].ToString());

            dOpexYear = !string.IsNullOrEmpty(dr["OPEX"].ToString()) ? decimal.Parse(dr["OPEX"].ToString()) : 0;

            dFecto = !string.IsNullOrEmpty(dr["FECTO"].ToString()) ? decimal.Parse(dr["FECTO"].ToString()) : 0; //Front End Cost Take Out
            dImprovement = !string.IsNullOrEmpty(dr["IMPROVEMENT"].ToString()) ? decimal.Parse(dr["IMPROVEMENT"].ToString()) : 0;

            dPotSavings = !string.IsNullOrEmpty(dr["POTSAVINGS"].ToString()) ? decimal.Parse(dr["POTSAVINGS"].ToString()) : 0;
            dActSavings = !string.IsNullOrEmpty(dr["ACTSAVINGS"].ToString()) ? decimal.Parse(dr["ACTSAVINGS"].ToString()) : 0;

            DtDateUpdated = !string.IsNullOrEmpty(dr["DATEUPDATED"].ToString()) ? DateTime.Parse(dr["DATEUPDATED"].ToString()) : DateTime.Today.Date;
            sWorkScope = dr["WORKSCOPE"].ToString();
            iUserId = !string.IsNullOrEmpty(dr["USERID"].ToString()) ? int.Parse(dr["USERID"].ToString()) : 0;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}