using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for OpportunityCostHelper
/// </summary>
/// 

public class OpexFectoImprovementActualPotential
{
    public decimal dOpex { get; set; }
    public decimal dFecto { get; set; }
    public decimal dImprovement { get; set; }
    public decimal dActSavings { get; set; }
    public decimal dPotSavings { get; set; }

    public OpexFectoImprovementActualPotential()
    {

    }

    public OpexFectoImprovementActualPotential(DataRow dr)
    {
        dOpex = !string.IsNullOrEmpty(dr["OPEX"].ToString()) ? decimal.Parse(dr["OPEX"].ToString()) : 0; //decimal.Parse(dr["OPEX"].ToString());
        dFecto = !string.IsNullOrEmpty(dr["FECTO"].ToString()) ? decimal.Parse(dr["FECTO"].ToString()) : 0; //decimal.Parse(dr["FECTO"].ToString());
        dImprovement = !string.IsNullOrEmpty(dr["IMPROVEMENT"].ToString()) ? decimal.Parse(dr["IMPROVEMENT"].ToString()) : 0; //decimal.Parse(dr["IMPROVEMENT"].ToString());

        dActSavings = !string.IsNullOrEmpty(dr["ACTSAVINGS"].ToString()) ? decimal.Parse(dr["ACTSAVINGS"].ToString()) : 0; //decimal.Parse(dr["ACTSAVINGS"].ToString());
        dPotSavings = !string.IsNullOrEmpty(dr["POTSAVINGS"].ToString()) ? decimal.Parse(dr["POTSAVINGS"].ToString()) : 0; //decimal.Parse(dr["POTSAVINGS"].ToString());
    }
}

public class TransactionYear
{
    public int iYear { get; set; }

    public TransactionYear()
    {

    }

    public TransactionYear(DataRow dr)
    {
        iYear = int.Parse(dr["IYEAR"].ToString());
    }

    public DataTable dtGetYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getTransactionYear();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public TransactionYear ObjGetTransactionYear()
    {
        DataTable dt = dtGetYear();

        TransactionYear oRows = new TransactionYear();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new TransactionYear(dr);
        }
        return oRows;
    }

    public TransactionYear tYear()
    {
        return ObjGetTransactionYear();
    }

    public bool UpdateTransactionYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateTransactionYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }
}

public class SummaryReport
{
    public decimal dBO { get; set; }
    public decimal dReduction { get; set; }
    public decimal dCurrentGap { get; set; }
    public decimal dPercentageBanked { get; set; }
}

public class OpportunityCostHelper
{
    //Note: this year will be used to determine which year data we want to see. 
    //We can eventually put this in a database where we can select the year at will.

    //public static int iYear = DateTime.Today.Year;
    //public static int iYear = DateTime.Today.Year - 1;

    TransactionYear oTrans = new TransactionYear();


	public OpportunityCostHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private static DataTable dtGetOpportunityCostId()
    {
        string sql = "SELECT PDCC_OPPORTINITYCOST_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getYears();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<int> lstYears()
    {
        DataTable dt = dtGetYear();
        List<int> oYears = new List<int>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oYears.Add(int.Parse(dr["YYEAR"].ToString()));
        }

        return oYears;
    }

    //public DataTable DtGetOpportunityCostByAsset(int iAssetId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.GetOpportunitiesByAsset();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iAssetId";
    //    param.Value = iAssetId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}
    public DataTable DtGetOpportunityCostByAsset(int iAssetId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunitiesByAsset();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<OpportunityCost> lstGetOpportunityCostByAsset(int iAssetId, int iYear)
    {
        DataTable dt = DtGetOpportunityCostByAsset(iAssetId, iYear);

        List<OpportunityCost> asset = new List<OpportunityCost>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new OpportunityCost(dr));
        }
        return asset;
    }

    public DataTable DtGetOpportunityCostByAssetOwner(int iAssetId, int iYear, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunitiesByAssetOwner();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostByDeptRpt(int iAsset)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunitiesByAssetRpt();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAsset";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostByUser(int iUserId, int iRoleId, int iYear)
    {
        string sql = "";
        if (iRoleId == (int)AppUsersPdccRoles.UserRole.ActionParty) sql = StoredProcedurePDCC.GetOpportunityByActionParty();
        else if (iRoleId == (int)AppUsersPdccRoles.UserRole.Sponsor) sql = StoredProcedurePDCC.GetOpportunityBySponsor();

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostByActionParty(int iActionParty)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iActionParty";
        param.Value = iActionParty;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostByPriority(int iPriority)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iPriority";
        param.Value = iPriority;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostByAcceptPark(int iAcceptPark)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAcceptPark";
        param.Value = iAcceptPark;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostByFrontEndCostTakeOut(int iFecto)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFecto";
        param.Value = iFecto;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public DataTable DtGetOpportunityCostByImprovement(int iYear, int iImprovement)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.GetOpportunitiesByYear(iImprovement, iYear);

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iImprovement";
    //    param.Value = iImprovement;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    public DataTable DtGetOpportunityCostByAssetSupportService(int iAsset)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovalByInitiativeId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAsset";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    #region Code for Graph reporting starts here
    public DataTable DtGetOpExFectoImprovementByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPDPerformanceByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public OpexFectoImprovementActualPotential ObjGetPDPerformanceSummaryByYear(int iYear)
    {
        DataTable dt = DtGetOpExFectoImprovementByYear(iYear);

        OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpexFectoImprovementActualPotential(dr);
        }
        return oRows;
    }

    public DataTable DtGetOpExFectoImprovementByYearDepartment(int iYear, int iDept)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getOpExFectoImprovementByYearDepartment();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDept";
        param.Value = iDept;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpExFectoImprovementByYearDepartmentAsset(int iYear, int iDept, int iAsset)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getOpExFectoImprovementByYearDepartmentAsset();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDept";
        param.Value = iDept;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAsset";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public OpexFectoImprovementActualPotential ObjGetOpExFectoImprovementByYearDepartmentAsset(int iYear, int iDept, int iAsset)
    {
        DataTable dt = DtGetOpExFectoImprovementByYearDepartmentAsset(iYear, iDept, iAsset);

        OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpexFectoImprovementActualPotential(dr);
        }
        return oRows;
    }

    public OpexFectoImprovementActualPotential ObjGetOpExFectoImprovementByYearDepartment(int iYear, int iDept)
    {
        DataTable dt = DtGetOpExFectoImprovementByYearDepartment(iYear, iDept);

        OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpexFectoImprovementActualPotential(dr);
        }
        return oRows;
    }

    public DataTable DtGetOpExFectoImprovementByYearOpCost(int iYear, long lOpCost)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getOpExFectoImprovementByYearOpCost();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = lOpCost;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public OpexFectoImprovementActualPotential ObjGetOpExFectoImprovementByYearOpCost(int iYear, long lOpCost)
    {
        DataTable dt = DtGetOpExFectoImprovementByYearOpCost(iYear, lOpCost);

        OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpexFectoImprovementActualPotential(dr);
        }
        return oRows;
    }

    public DataTable DtGetOpExFectoImprovementByAssetYear(int iYear, int iAsset)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getOnshoreOffshorePerformanceByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAsset";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetAssetPerformanceByYear(int iYear, int iAsset)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getAssetPerformanceByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAsset";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public OpexFectoImprovementActualPotential ObjGetOpExFectoImprovementByAssetYear(int iYear, int iAsset)
    {
        DataTable dt = DtGetOpExFectoImprovementByAssetYear(iYear, iAsset);

        OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpexFectoImprovementActualPotential(dr);
        }
        return oRows;
    }

    public OpexFectoImprovementActualPotential ObjGetAssetPerformanceByYear(int iYear, int iAsset)
    {
        DataTable dt = DtGetAssetPerformanceByYear(iYear, iAsset);

        OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpexFectoImprovementActualPotential(dr);
        }
        return oRows;
    }

  
    #endregion

    public DataTable DtGetOpportunityCosts(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunities();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCosts()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunities();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetProjects(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetProjects();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostBySerialNo(string sSerialNo)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunityBySerialNo();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sSerialNo";
        param.Value = sSerialNo;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public OpportunityCost ObjGetProjects(int iYear)
    {
        DataTable dt = DtGetProjects(iYear);

        OpportunityCost oRows = new OpportunityCost();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpportunityCost(dr);
        }
        return oRows;
    }

    public List<OpportunityCost> lstGetProjects(int iYear)
    {
        DataTable dt = DtGetProjects(iYear);

        List<OpportunityCost> asset = new List<OpportunityCost>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new OpportunityCost(dr));
        }
        return asset;
    }

    public OpportunityCost ObjGetOpportunityCostBySerialNo(string sSerialNo)
    {
        DataTable dt = DtGetOpportunityCostBySerialNo(sSerialNo);

        OpportunityCost oRows = new OpportunityCost();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpportunityCost(dr);
        }
        return oRows;
    }

    public DataTable DtGetOpportunityCostById(long lOpCost)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunitiesById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = lOpCost;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable DtGetOpportunityCostByOpportunity(string Opportunity)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetOpportunityByOpportunity();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":Opportunity";
        param.Value = "%" + Opportunity + "%";
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public OpportunityCost ObjGetOpportunityCostByOpportunity(string Opportunity)
    {
        DataTable dt = DtGetOpportunityCostByOpportunity(Opportunity);

        OpportunityCost oRows = new OpportunityCost();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpportunityCost(dr);
        }
        return oRows;
    }

    public OpportunityCost ObjGetOpportunityCostById(long lOpCostId)
    {
        DataTable dt =  DtGetOpportunityCostById(lOpCostId);

        OpportunityCost oRows = new OpportunityCost();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpportunityCost(dr);
        }
        return oRows;
    }
    private long GetOpportunityCostID()
    {
        long lOpCostId = 0;
        try
        {
            DataTable dt = dtGetOpportunityCostId();
            lOpCostId = long.Parse(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return lOpCostId;
    }
    public bool CreateOpportunityCost(OpportunityCost oOpportunityCost, ref long lOpCostId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.CreatePdcc();

        lOpCostId = GetOpportunityCostID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = lOpCostId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oOpportunityCost.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStartedBy";
        param.Value = oOpportunityCost.dtStartedBy;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCompletedBy";
        param.Value = oOpportunityCost.dtCompletedBy;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = oOpportunityCost.iSponsor;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActionParty";
        param.Value = oOpportunityCost.iActionParty;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAcceptPark";
        param.Value = oOpportunityCost.iAcceptPark;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPriority";
        param.Value = oOpportunityCost.iPriority;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dOpexYear";
        param.Value = oOpportunityCost.dOpexYear;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dFecto";
        param.Value = oOpportunityCost.dFecto;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dImprovement";
        param.Value = oOpportunityCost.dImprovement;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAsService";
        param.Value = oOpportunityCost.iAsService;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPotSavings";
        param.Value = oOpportunityCost.dPotSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActSavings";
        param.Value = oOpportunityCost.dActSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oOpportunityCost.sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostCentre";
        param.Value = oOpportunityCost.sCostCentre;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunity";
        param.Value = oOpportunityCost.sOpportunity;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWorkScope";
        param.Value = oOpportunityCost.sWorkScope;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DtDateUpdated";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oTrans.tYear().iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oOpportunityCost.iLastUpdatedBy;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }
    public bool UpdateOpportunityCost(OpportunityCost oOpportunityCost)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdatePdcc();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = oOpportunityCost.lOpCost;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oOpportunityCost.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStartedBy";
        param.Value = oOpportunityCost.dtStartedBy;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCompletedBy";
        param.Value = oOpportunityCost.dtCompletedBy;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = oOpportunityCost.iSponsor;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActionParty";
        param.Value = oOpportunityCost.iActionParty;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAcceptPark";
        param.Value = oOpportunityCost.iAcceptPark;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iPriority";
        param.Value = oOpportunityCost.iPriority;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dOpexYear";
        param.Value = oOpportunityCost.dOpexYear;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dFecto";
        param.Value = oOpportunityCost.dFecto;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dImprovement";
        param.Value = oOpportunityCost.dImprovement;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAsService";
        param.Value = oOpportunityCost.iAsService;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dPotSavings";
        //param.Value = oOpportunityCost.dPotSavings;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dActSavings";
        //param.Value = oOpportunityCost.dActSavings;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPotSavings";
        param.Value = oOpportunityCost.dPotSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActSavings";
        param.Value = oOpportunityCost.dActSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oOpportunityCost.sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostCentre";
        param.Value = oOpportunityCost.sCostCentre;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sComments";
        //param.Value = oOpportunityCost.sComments;
        //param.DbType = DbType.String;
        //param.Size = 4000;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunity";
        param.Value = oOpportunityCost.sOpportunity;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWorkScope";
        param.Value = oOpportunityCost.sWorkScope;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DtDateUpdated";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oOpportunityCost.iLastUpdatedBy;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }
    public bool UpdateOpportunityCost2(OpportunityCost oOpportunityCost)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdatePdcc2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = oOpportunityCost.lOpCost;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPotSavings";
        param.Value = oOpportunityCost.dPotSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActSavings";
        param.Value = oOpportunityCost.dActSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oOpportunityCost.sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DtDateUpdated";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oOpportunityCost.iLastUpdatedBy;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool DeleteOpportunityCost(long lOpCost)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.DeleteProjectMilestone();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = lOpCost;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }


    #region =============== Audit Trail ====================================================
    public bool CreateOpportunityCostLog(OpportunityCost oOpportunityCost, long lOpCost)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.CreatePdccLog();


        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = lOpCost;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dFecto";
        param.Value = oOpportunityCost.dFecto;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dImprovement";
        param.Value = oOpportunityCost.dImprovement;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPotSavings";
        param.Value = oOpportunityCost.dPotSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dActSavings";
        param.Value = oOpportunityCost.dActSavings;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oOpportunityCost.sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWorkScope";
        param.Value = oOpportunityCost.sWorkScope;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DtDateUpdated";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oOpportunityCost.iLastUpdatedBy;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public DataTable DtGetOpportunityCostLogs(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPdccLog();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetOpportunityCostLogsByAsset(int iAssetId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPdccLogByAsset();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public DataTable DtGetOpportunityCostLogByOpportunity(int iYear, long lOpCost)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPdccLogByOpportunity();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lOpCost";
        param.Value = lOpCost;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public List<OpportunityCostLog> lstGetOpportunityCostLogs(int iYear)
    //{
    //    DataTable dt = DtGetOpportunityCostLogs(iYear);

    //    List<OpportunityCostLog> oRows = new List<OpportunityCostLog>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        oRows.Add(new OpportunityCostLog(dr));
    //    }

    //    return oRows;
    //}
    //public List<OpportunityCostLog> lstGetOpportunityCostLogByOpportunityId(int iYear, long lOpCostId)
    //{
    //    DataTable dt = DtGetOpportunityCostLogByOpportunity(iYear, lOpCostId);

    //    List<OpportunityCostLog> oRows = new List<OpportunityCostLog>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        oRows.Add(new OpportunityCostLog(dr));
    //    }

    //    return oRows;
    //}

    #endregion

    public void FillMenu(XmlDataSource XmlMenuDataSource, TreeView mnuTreeView)
    {
        try
        {
            getChartMenu(XmlMenuDataSource);
            mnuTreeView.DataBind();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private static void getChartMenu(XmlDataSource XmlDS)
    {
        try
        {
            DataSet ds = GenericDataAccess.ExecuteSelectCommand(StoredProcedurePDCC.getChartMenu());

            DataTable dtMenu = new DataTable("MenuTable");
            dtMenu.Columns.Add(new DataColumn("MENUID", typeof(System.String)));
            dtMenu.Columns.Add(new DataColumn("TITLE", typeof(System.String)));
            dtMenu.Columns.Add(new DataColumn("PARENTID", typeof(System.String)));

            DataSet dsMenu = new DataSet();
            dsMenu.Tables.Add(dtMenu);

            string sNewHeader = "";
            string LastMenuId = "";
            int iUniqueId = 2;
            int iUniqueIdHolder = 1;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (LastMenuId != dr["MENUID"].ToString())
                {
                    sNewHeader = dr["MENUID"].ToString();

                    DataRow anyRow = dsMenu.Tables["MenuTable"].NewRow();

                    DataRow[] oRow = null;
                    oRow = ds.Tables[0].Select("MENUID=" + sNewHeader);
                    if (oRow != null)
                    {
                        anyRow[0] = iUniqueIdHolder;
                        anyRow[1] = oRow[0]["ASSETS"].ToString();
                        anyRow[2] = DBNull.Value;
                        dsMenu.Tables["MenuTable"].Rows.Add(anyRow);

                        foreach (DataRow dr2 in oRow)
                        {
                            anyRow = dsMenu.Tables["MenuTable"].NewRow();
                            anyRow[0] = iUniqueId++;
                            anyRow[1] = dr2["TITLE"].ToString();
                            anyRow[2] = iUniqueIdHolder;
                            dsMenu.Tables["MenuTable"].Rows.Add(anyRow);
                        }
                        iUniqueIdHolder = iUniqueId;
                        iUniqueId++;
                    }

                }
                LastMenuId = sNewHeader;
            }

            dsMenu.DataSetName = "Menus";
            dsMenu.Tables["MenuTable"].TableName = "Menu";

            DataRelation relation = new DataRelation("ParentChild", dsMenu.Tables["Menu"].Columns["MENUID"], dsMenu.Tables["Menu"].Columns["PARENTID"], true);
            relation.Nested = true;
            dsMenu.Relations.Add(relation);

            XmlDS.Data = dsMenu.GetXml(); //Returns the XML representation of the data stored in the System.Data.DataSet

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public static int getCurrentMonth()
    {
        int previousMonth = DateTime.Today.Month - 1;
        int iMonth = 0;
        switch (previousMonth)
        {
            case 1: iMonth = 1;
                break;
            case 2: iMonth = 2;
                break;
            case 3: iMonth = 3;
                break;
            case 4: iMonth = 4;
                break;
            case 5: iMonth = 5;
                break;
            case 6: iMonth = 6;
                break;
            case 7: iMonth = 7;
                break;
            case 8: iMonth = 8;
                break;
            case 9: iMonth = 9;
                break;
            case 10: iMonth = 10;
                break;
            case 11: iMonth = 11;
                break;
            case 0: iMonth = 12;
                break;
        }
        return iMonth;
    }

    public static string getMonth()
    {
        int previousMonth = DateTime.Today.Month - 1;
        string mMonth = "";
        switch (previousMonth)
        {
            case 1: mMonth = "January";
                break;
            case 2: mMonth = "February";
                break;
            case 3: mMonth = "March";
                break;
            case 4: mMonth = "April";
                break;
            case 5: mMonth = "May";
                break;
            case 6: mMonth = "June";
                break;
            case 7: mMonth = "July";
                break;
            case 8: mMonth = "August";
                break;
            case 9: mMonth = "September";
                break;
            case 10: mMonth = "October";
                break;
            case 11: mMonth = "November";
                break;
            case 0: mMonth = "December";
                break;
        }
        return mMonth;
    }

    public static string getMonth(int iMonth)
    {
        //int previousMonth = DateTime.Today.Month - 1;
        int previousMonth = iMonth;
        string mMonth = "";
        switch (previousMonth)
        {
            case 1: mMonth = "January";
                break;
            case 2: mMonth = "February";
                break;
            case 3: mMonth = "March";
                break;
            case 4: mMonth = "April";
                break;
            case 5: mMonth = "May";
                break;
            case 6: mMonth = "June";
                break;
            case 7: mMonth = "July";
                break;
            case 8: mMonth = "August";
                break;
            case 9: mMonth = "September";
                break;
            case 10: mMonth = "October";
                break;
            case 11: mMonth = "November";
                break;
            case 0: mMonth = "December";
                break;
        }
        return mMonth;
    }

    public static void getOpexYear(Label lblOpex)
    {
        TransactionYear o = new TransactionYear();
        lblOpex.Text = "OP" + (o.tYear().iYear - 1).ToString().Remove(0, 2) + " " + o.tYear() + "($mln)"; //'000: 
    }

    public static string getSOpexYear(string sOpexYear)
    {
        TransactionYear o = new TransactionYear();
        sOpexYear = "OP" + (o.tYear().iYear - 1).ToString().Remove(0, 2) + " " + o.tYear().iYear + " ($mln)";// '000

        return sOpexYear;
    }

    #region Charting Data


    public DataTable dtGetFunctionsOrDepartments()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetFunctionsOrDepartments();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetAssetsByOnshoreOffshoreByYear(int iOnshoreOffshore, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetAssetByOnshoreOffshore();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iOnshoreOffshore;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetAssetsByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetAssetsByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<AssetPdcc> lstGetAssetsByOnshoreOffshoreByYear(int iOnshoreOffshore, int iYear)
    {
        DataTable dt = dtGetAssetsByOnshoreOffshoreByYear(iOnshoreOffshore, iYear);

        List<AssetPdcc> asset = new List<AssetPdcc>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new AssetPdcc(dr));
        }
        return asset;
    }

    public DataTable dtGetFunctionsByDepartments(int iDeptId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetFunctionsByDepartments();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDeptId";
        param.Value = iDeptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetSummaryByOnshoreOffshoreAsset(int iAssetId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getOnshoreOffshorePerformanceByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    public DataTable dtGetSummaryByAssetYear(int iAssetId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetDataSummaryByAsset();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    //public DataTable dtGetSummaryByDepartmentYear(int iDeptId, int iYear)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedurePDCC.GetDataSummaryByAsset();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iYear";
    //    param.Value = iYear;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":iAssetId";
    //    param.Value = iAssetId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);

    //}

    public OpexFectoImprovementActualPotential ObjGetSummaryByAssetYear(int iYear, int iAsset)
    {
        DataTable dt = dtGetSummaryByAssetYear(iYear, iAsset);

        OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new OpexFectoImprovementActualPotential(dr);
        }
        return oRows;
    }

    //public OpexFectoImprovementActualPotential ObjGetSummaryByDepartmentYear(int iYear, int iDeptId)
    //{
    //    DataTable dt = dtGetSummaryByDepartmentYear(iYear, iDeptId);

    //    OpexFectoImprovementActualPotential oRows = new OpexFectoImprovementActualPotential();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        oRows = new OpexFectoImprovementActualPotential(dr);
    //    }
    //    return oRows;
    //}

    #endregion



    #region This class is very important to correct performance of the Charting data calculation

    public void GetItemsStringValues(GridView oGrdView, appUsers oAppUser)
    {
        decimal dTotalOpex = 0; decimal dTotalBanked = 0; decimal dTotalBO = 0; decimal dTotalOpportunity = 0; decimal dTotalPerBanked = 0;
        try
        {
            foreach (GridViewRow grdRow in oGrdView.Rows)
            {
                Label lblOpex = (Label)grdRow.FindControl("lblOpex");
                Label lblActualSaving = (Label)grdRow.FindControl("lblActualSaving"); //Deep Dive Savings
                Label lblImprovement = (Label)grdRow.FindControl("lblImprovement"); //Improvement Opportunity
                Label lblBO = (Label)grdRow.FindControl("lblBO");
                Label lblReduction = (Label)grdRow.FindControl("lblReduction");
                Label lblCurrentGap = (Label)grdRow.FindControl("lblCurrentGap");
                Label lblPercentageBanked = (Label)grdRow.FindControl("lblPercentageBanked");

                dTotalOpex += !string.IsNullOrEmpty(lblOpex.Text) ? decimal.Parse(lblOpex.Text) : 0;
                dTotalBanked += !string.IsNullOrEmpty(lblActualSaving.Text) ? decimal.Parse(lblActualSaving.Text) : 0;
                dTotalOpportunity += !string.IsNullOrEmpty(lblImprovement.Text) ? decimal.Parse(lblImprovement.Text) : 0;


                //B&O $mln
                if ((lblActualSaving.Text != "") && (lblImprovement.Text != ""))
                {
                    decimal dBanked = decimal.Parse(lblActualSaving.Text);
                    decimal dOpppr = decimal.Parse(lblImprovement.Text);
                    decimal dBO = dBanked + dOpppr;

                    lblBO.Text = dBO.ToString();
                    dTotalBO += dBO;
                }

                //25% Reduction
                if (lblOpex.Text != "")
                {
                    decimal dOpexReduction = decimal.Parse(lblOpex.Text);
                    lblReduction.Text = (Math.Round((dOpexReduction * 0.25M), 2)).ToString();
                }

                //Currnt Gap: PercentageReduction - Banked
                if ((lblReduction.Text != "") && (lblActualSaving.Text != ""))
                {
                    decimal dBanked = decimal.Parse(lblActualSaving.Text);
                    decimal dReduction = decimal.Parse(lblReduction.Text);
                    lblCurrentGap.Text = (dReduction - dBanked).ToString();
                }

                //%tage Banked
                if ((lblOpex.Text != "") && (lblActualSaving.Text != ""))
                {
                    decimal dBanked = decimal.Parse(lblActualSaving.Text);
                    decimal dOpex = decimal.Parse(lblOpex.Text);
                    lblPercentageBanked.Text = (dOpex != 0) ? Math.Round(((dBanked / dOpex) * 100), 2).ToString() : "0"; //To avoid divisible by zero
                }

                //lblOpex.Text == "" ? (lblOpex.Text = "") : (lblOpex.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblOpex.Text)));

                if (lblOpex.Text != "") lblOpex.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblOpex.Text));
                if (lblActualSaving.Text != "") lblActualSaving.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblActualSaving.Text));
                if (lblImprovement.Text != "") lblImprovement.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblImprovement.Text));
                if (lblBO.Text != "") lblBO.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblBO.Text));
                if (lblReduction.Text != "") lblReduction.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblReduction.Text));
                if (lblCurrentGap.Text != "") lblCurrentGap.Text = stringRoutine.formatAsBankMoney(decimal.Parse(lblCurrentGap.Text));
            }

            oGrdView.FooterStyle.BackColor = System.Drawing.Color.Silver;
            oGrdView.FooterStyle.ForeColor = System.Drawing.Color.Red;
            oGrdView.FooterStyle.Font.Bold = true;

            oGrdView.FooterStyle.HorizontalAlign = HorizontalAlign.Left;
            oGrdView.FooterRow.Cells[1].Text = "Total";
            oGrdView.FooterRow.Cells[2].Text = stringRoutine.formatAsBankMoney(dTotalOpex);
            oGrdView.FooterRow.Cells[3].Text = stringRoutine.formatAsBankMoney(dTotalBanked);
            oGrdView.FooterRow.Cells[4].Text = stringRoutine.formatAsBankMoney(dTotalPerBanked);
            oGrdView.FooterRow.Cells[5].Text = stringRoutine.formatAsBankMoney(dTotalOpportunity);
            oGrdView.FooterRow.Cells[6].Text = stringRoutine.formatAsBankMoney(dTotalBO);

            //oGrdView.FooterRow.Cells[7].Text = stringRoutine.formatAsBankMoney(dTotalOpex);
            //oGrdView.FooterRow.Cells[8].Text = stringRoutine.formatAsBankMoney(dTotalOpex);

            if (oAppUser.m_iCostSavingAbsVal != 1)
            {
                foreach (GridViewRow grdRow in oGrdView.Rows)
                {
                    Label lblOpex = (Label) grdRow.FindControl("lblOpex");
                    Label lblActualSaving = (Label) grdRow.FindControl("lblActualSaving"); //Deep Dive Savings
                    Label lblImprovement = (Label) grdRow.FindControl("lblImprovement"); //Improvement Opportunity
                    Label lblBO = (Label) grdRow.FindControl("lblBO");
                    Label lblReduction = (Label) grdRow.FindControl("lblReduction");
                    Label lblCurrentGap = (Label) grdRow.FindControl("lblCurrentGap");
                    Label lblPercentageBanked = (Label) grdRow.FindControl("lblPercentageBanked");

                    //lblActualSaving.Text = "#,###,###.##";
                    //lblImprovement.Text = "#,###,###.##";
                    //lblBO.Text = "#,###,###.##";

                    lblActualSaving.Text = "0,000,000.00";
                    lblImprovement.Text = "0,000,000.00";
                    lblBO.Text = "0,000,000.00";

                    //25% Reduction
                    if (!String.IsNullOrEmpty(lblOpex.Text))
                    {
                        decimal dOpexReduction = decimal.Parse(lblOpex.Text);
                        lblReduction.Text = dOpexReduction != 0
                            ? (((Math.Round((dOpexReduction * 0.25M), 2)) / dOpexReduction)*100).ToString()
                            : "";
                    }

                    lblOpex.Text = "0,000,000.00"; //Note: this line must come below the lines at the top, or else there will be error.

                    //lblReduction.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public SummaryReport GetItemsStringValues2(decimal dOpex, decimal dActualSavings, decimal dImprovement)
    {
        SummaryReport oSummaryReport = new SummaryReport();
        try
        {
            oSummaryReport.dBO = dActualSavings + dImprovement;             //B&O $mln          
            oSummaryReport.dReduction = Math.Round((dOpex * 0.25M), 2);     //25% Reduction
           
            decimal dBanked = dActualSavings;
            decimal dReduction = Math.Round((dOpex * 0.25M), 2);
            oSummaryReport.dCurrentGap = dReduction - dBanked;               //Currnt Gap: PercentageReduction - Banked

            oSummaryReport.dPercentageBanked = (dOpex != 0) ? Math.Round(((dBanked / dOpex) * 100), 2) : 0;  //%tage Banked //To avoid divisible by zero
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return oSummaryReport;
    }

    #endregion

    #region Insert Stories



    public DataTable dtGetStories()
    {
        //getStories
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getStories();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetStoryById(long lStoryId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getStoryById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lStoryId";
        param.Value = lStoryId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public int iGetNumberOfMembers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getNoOfMembers();

        int iNoOfMembers = GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count;
        return iNoOfMembers;
    }
    public int iGetNumberOfTopics()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getNoOfTopics();

        int iNoOfTopics = GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count;
        return iNoOfTopics;
    }

    public int iGetMyTopics(string sUserName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getNoOfMyTopics();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sUserName";
        param.Value = sUserName;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        int iMyTopics = GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count;
        return iMyTopics;
    }

    public DataTable dtGetStoryByUserName(string sUserName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getStoryByUserName();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sUserName";
        param.Value = sUserName;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetStoryBySearch(string sSearch)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getStoryBySearch();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sSearch";
        param.Value = "%" + sSearch + "%";
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public TellYourStories objGetStoryById(long lStoryId)
    {
        DataTable dt = dtGetStoryById(lStoryId);

        TellYourStories oTellUrStory = new TellYourStories();
        foreach (DataRow dr in dt.Rows)
        {
            oTellUrStory = new TellYourStories(dr);
        }
        return oTellUrStory;
    }

    public bool InsertStory(TellYourStories oTellUrStories)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.InsertStory();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sStory";
        param.Value = oTellUrStories.m_sStory;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sUserName";
        param.Value = oTellUrStories.m_sUserName;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = oTellUrStories.m_sTitle;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtDateTold";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTime";
        param.Value = DateTime.Now.ToShortTimeString();
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dAmtSaved";
        param.Value = oTellUrStories.m_dAmtSaved;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile1";
        param.Value = oTellUrStories.m_sFileName1;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile2";
        param.Value = oTellUrStories.m_sFileName2;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile3";
        param.Value = oTellUrStories.m_sFileName3;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile4";
        param.Value = oTellUrStories.m_sFileName4;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateStory(TellYourStories oTellUrStories)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateStory();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lStoryId";
        param.Value = oTellUrStories.m_lStoryId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStory";
        param.Value = oTellUrStories.m_sStory;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = oTellUrStories.m_sTitle;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dAmtSaved";
        param.Value = oTellUrStories.m_dAmtSaved;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile1";
        param.Value = oTellUrStories.m_sFileName1;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile2";
        param.Value = oTellUrStories.m_sFileName2;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile3";
        param.Value = oTellUrStories.m_sFileName3;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile4";
        param.Value = oTellUrStories.m_sFileName4;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateStoryWtFileUpload(TellYourStories oTellUrStories)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateStoryWtFileUpload();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lStoryId";
        param.Value = oTellUrStories.m_lStoryId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sStory";
        param.Value = oTellUrStories.m_sStory;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = oTellUrStories.m_sTitle;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dAmtSaved";
        param.Value = oTellUrStories.m_dAmtSaved;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile1";
        param.Value = oTellUrStories.m_sFileName1;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile2";
        param.Value = oTellUrStories.m_sFileName2;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile3";
        param.Value = oTellUrStories.m_sFileName3;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFile4";
        param.Value = oTellUrStories.m_sFileName4;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }


    public void SiteVisitors()
    {
        AppsVisitorsHelper oAppsVisitorsHelper = new AppsVisitorsHelper();
        AppsVisitors oAppVisitor = oAppsVisitorsHelper.ObjGetLogonUsersToday();

        if (!string.IsNullOrEmpty(oAppVisitor.UsersNames))
        {
            if (!oAppVisitor.UsersNames.Contains(Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name)))
            {
                oAppVisitor.UsersNames += Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name) + ",";
            }

            oAppsVisitorsHelper.Update(oAppVisitor);
        }
        else
        {
            oAppVisitor.UsersNames = Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name) + ",";
            oAppsVisitorsHelper.Insert(oAppVisitor);
        }

        int iTotalCurrentlyLogonUsers = oAppVisitor.UsersNames.Split(',').Length;
        string[] UsersNames = oAppVisitor.UsersNames.Split(',');

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (string s in UsersNames)
        {
            sb.Append(s + ", ");
        }

        string sLogonUsers = sb.ToString();
    }

    #endregion
}