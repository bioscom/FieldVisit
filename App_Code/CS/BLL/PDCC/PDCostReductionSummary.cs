using System;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;

/// <summary>
/// Summary description for PDCostReductionSummary
/// </summary>
/// 


public class PDInitialEstimatedSavings
{
    public long lEstimateId { get; set; }
    public int iAssetId { get; set; }
    public decimal dDD { get; set; }
    public decimal dDDO { get; set; }
    public decimal dEIO { get; set; }
    public int iYear { get; set; }
    public int iMonth { get; set; }
    public int iUserId { get; set; }


    public PDInitialEstimatedSavings()
    {

    }

    public PDInitialEstimatedSavings(DataRow dr)
    {
        lEstimateId = long.Parse(dr["IDESTSAVINGS"].ToString());
        iAssetId = int.Parse(dr["ASSETID"].ToString());
        dDD = !string.IsNullOrEmpty(dr["DD"].ToString()) ? decimal.Parse(dr["DD"].ToString()) : 0;
        dDDO = !string.IsNullOrEmpty(dr["DDO"].ToString()) ? decimal.Parse(dr["DDO"].ToString()) : 0;
        dEIO = !string.IsNullOrEmpty(dr["EIO"].ToString()) ? decimal.Parse(dr["EIO"].ToString()) : 0;
        iYear = int.Parse(dr["IYEAR"].ToString());
        iMonth = int.Parse(dr["IMONTH"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());

    }
}

public class PDEstimatedSavings
{
    public long lEstimateId { get; set; }
    public int iAssetId { get; set; }
    public decimal dDD { get; set; }
    public decimal dDDO { get; set; }
    public decimal dEIO { get; set; }
    public int iYear { get; set; }
    public int iMonth { get; set; }
    public int iUserId { get; set; }


    public PDEstimatedSavings()
    {

    }

    public PDEstimatedSavings(DataRow dr)
    {
        lEstimateId = long.Parse(dr["IDESTIMATE"].ToString());
        iAssetId = int.Parse(dr["ASSETID"].ToString());
        dDD = !string.IsNullOrEmpty(dr["DD"].ToString()) ? decimal.Parse(dr["DD"].ToString()) : 0;
        dDDO = !string.IsNullOrEmpty(dr["DDO"].ToString()) ? decimal.Parse(dr["DDO"].ToString()) : 0;
        dEIO = !string.IsNullOrEmpty(dr["EIO"].ToString()) ? decimal.Parse(dr["EIO"].ToString()) : 0;
        iYear = int.Parse(dr["IYEAR"].ToString());
        iMonth = int.Parse(dr["IMONTH"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());

    }
}

public class PDEstimatedActualSavings
{
    public decimal dDD { get; set; }
    public decimal dDDO { get; set; }
    public decimal dEIO { get; set; }

    public PDEstimatedActualSavings()
    {

    }

    public PDEstimatedActualSavings(DataRow dr)
    {
        dDD = !string.IsNullOrEmpty(dr["DD"].ToString()) ? decimal.Parse(dr["DD"].ToString()) : 0;
        dDDO = !string.IsNullOrEmpty(dr["DDO"].ToString()) ? decimal.Parse(dr["DDO"].ToString()) : 0;
        dEIO = !string.IsNullOrEmpty(dr["EIO"].ToString()) ? decimal.Parse(dr["EIO"].ToString()) : 0;
    }
}

public class PDActualSavings
{
    public long lActualId { get; set; }
    public int iAssetId { get; set; }
    public decimal dDD { get; set; }
    public decimal dDDO { get; set; }
    public decimal dEIO { get; set; }
    public int iYear { get; set; }
    public int iMonth { get; set; }
    public int iUserId { get; set; }


    public PDActualSavings()
    {

    }

    public PDActualSavings(DataRow dr)
    {
        lActualId = long.Parse(dr["IDACTUAL"].ToString());
        iAssetId = int.Parse(dr["ASSETID"].ToString());
        dDD = !string.IsNullOrEmpty(dr["DD"].ToString()) ? decimal.Parse(dr["DD"].ToString()) : 0;
        dDDO = !string.IsNullOrEmpty(dr["DDO"].ToString()) ? decimal.Parse(dr["DDO"].ToString()) : 0;
        dEIO = !string.IsNullOrEmpty(dr["EIO"].ToString()) ? decimal.Parse(dr["EIO"].ToString()) : 0;
        iYear = int.Parse(dr["IYEAR"].ToString());
        iMonth = int.Parse(dr["IMONTH"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}

public class PDLESavings
{
    public long lLEId { get; set; }
    public int iAssetId { get; set; }
    public decimal dDD { get; set; }
    public decimal dDDO { get; set; }
    public decimal dEIO { get; set; }
    public int iYear { get; set; }
    public int iMonth { get; set; }
    public int iUserId { get; set; }


    public PDLESavings()
    {

    }

    public PDLESavings(DataRow dr)
    {
        lLEId = long.Parse(dr["IDLE"].ToString());
        iAssetId = int.Parse(dr["ASSETID"].ToString());
        dDD = !string.IsNullOrEmpty(dr["DD"].ToString()) ? decimal.Parse(dr["DD"].ToString()) : 0;
        dDDO = !string.IsNullOrEmpty(dr["DDO"].ToString()) ? decimal.Parse(dr["DDO"].ToString()) : 0;
        dEIO = !string.IsNullOrEmpty(dr["EIO"].ToString()) ? decimal.Parse(dr["EIO"].ToString()) : 0;
        iYear = int.Parse(dr["IYEAR"].ToString());
        iMonth = int.Parse(dr["IMONTH"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}


public class PDPerformanceSumm
{
    public decimal dOpex { get; set; }
    public decimal dDDBanked { get; set; }
    public decimal dDDOppor { get; set; }
    public decimal dDDOpporBanked { get; set; }
    public decimal dEIO { get; set; }
    public decimal dEIOBanked { get; set; }

    public PDPerformanceSumm()
    {
        
    }

    public PDPerformanceSumm(DataRow dr)
    {
        dOpex = !string.IsNullOrEmpty(dr["OPEX"].ToString()) ? decimal.Parse(dr["OPEX"].ToString()) : 0;
        dDDBanked = !string.IsNullOrEmpty(dr["DDBANKED"].ToString()) ? decimal.Parse(dr["DDBANKED"].ToString()) : 0;
        dDDOppor = !string.IsNullOrEmpty(dr["DDOPPOR"].ToString()) ? decimal.Parse(dr["DDOPPOR"].ToString()) : 0;
        dDDOpporBanked = !string.IsNullOrEmpty(dr["DDOPPORBANKED"].ToString()) ? decimal.Parse(dr["DDOPPORBANKED"].ToString()) : 0;
        dEIO = !string.IsNullOrEmpty(dr["EIO"].ToString()) ? decimal.Parse(dr["EIO"].ToString()) : 0;
        dEIOBanked = !string.IsNullOrEmpty(dr["EIOBANKED"].ToString()) ? decimal.Parse(dr["EIOBANKED"].ToString()) : 0;
    }
}


public class AssetServices
{
    public int iServiceId { get; set; }
    public string sService { get; set; }
    public AssetServices()
    {

    }

    public AssetServices(DataRow dr)
    {
        try
        {
            iServiceId = int.Parse(dr["IDSERVICE"].ToString());
            sService = dr["SERVICE"].ToString();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public static DataTable DtGetServices()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getAssetServices();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}

public class PDCostReductionSummary
{
    public long lCost { get; set; }
    public int iAssetId { get; set; }

    public decimal dOpex { get; set; }
    public decimal dDeepDiveBanked { get; set; }
    public decimal dDeepDiveBankable { get; set; }
    public decimal dDeepDiveExpected { get; set; }

    public decimal dDeepDiveOppor { get; set; }
    public decimal dDeepDiveOpporBanked { get; set; }
    public decimal dDeepDiveOpporExpected { get; set; }

    public decimal dEIO { get; set; }
    public decimal dEIOBanked { get; set; }
    public decimal dEIOActual { get; set; }
    public decimal dEIOCostAvoidance { get; set; }

    public DateTime DtDateUpdated { get; set; }
    public int iYear { get; set; }
    public int iUserId { get; set; }

    public string sPerformanceDescription { get; set; }

    public PDCostReductionSummary()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public PDCostReductionSummary(DataRow dr)
    {
        try
        {
            lCost = long.Parse(dr["IDCOST"].ToString());
            iAssetId = int.Parse(dr["ASSETID"].ToString());

            dOpex = !string.IsNullOrEmpty(dr["OPEX"].ToString()) ? decimal.Parse(dr["OPEX"].ToString()) : 0;
            dDeepDiveBanked = !string.IsNullOrEmpty(dr["DDBANKED"].ToString()) ? decimal.Parse(dr["DDBANKED"].ToString()) : 0; //Front End Cost Take Out
            dDeepDiveBankable = !string.IsNullOrEmpty(dr["DDBANKABLE"].ToString()) ? decimal.Parse(dr["DDBANKABLE"].ToString()) : 0;
            dDeepDiveExpected = !string.IsNullOrEmpty(dr["DDEXPECTED"].ToString()) ? decimal.Parse(dr["DDEXPECTED"].ToString()) : 0;

            dDeepDiveOppor = !string.IsNullOrEmpty(dr["DDOPPOR"].ToString()) ? decimal.Parse(dr["DDOPPOR"].ToString()) : 0;
            dDeepDiveOpporBanked = !string.IsNullOrEmpty(dr["DDOPPORBANKED"].ToString()) ? decimal.Parse(dr["DDOPPORBANKED"].ToString()) : 0;
            dDeepDiveOpporExpected = !string.IsNullOrEmpty(dr["DDOPPOREXPECTED"].ToString()) ? decimal.Parse(dr["DDOPPOREXPECTED"].ToString()) : 0;

            dEIO = !string.IsNullOrEmpty(dr["EIO"].ToString()) ? decimal.Parse(dr["EIO"].ToString()) : 0;
            dEIOBanked = !string.IsNullOrEmpty(dr["EIOBANKED"].ToString()) ? decimal.Parse(dr["EIOBANKED"].ToString()) : 0;
            dEIOActual = !string.IsNullOrEmpty(dr["EIOACTUAL"].ToString()) ? decimal.Parse(dr["EIOACTUAL"].ToString()) : 0;
            dEIOCostAvoidance = !string.IsNullOrEmpty(dr["EIOCOSTAVOID"].ToString()) ? decimal.Parse(dr["EIOCOSTAVOID"].ToString()) : 0;

            DtDateUpdated = !string.IsNullOrEmpty(dr["DATEUPDATED"].ToString()) ? DateTime.Parse(dr["DATEUPDATED"].ToString()) : DateTime.Today.Date;
            iUserId = !string.IsNullOrEmpty(dr["USERID"].ToString()) ? int.Parse(dr["USERID"].ToString()) : 0;
            iYear = int.Parse(dr["YYEAR"].ToString());
            sPerformanceDescription = dr["PERFDESCRIPTION"].ToString();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}

public class PDCostReductionSummaryHelper
{
    TransactionYear oTrans = new TransactionYear();
    public PDCostReductionSummaryHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public decimal OverrallPercentageSavings()
    {
        decimal dSumOpex = 0; decimal dSumDeepDiveBanked = 0; decimal dSumDeepDiveOpporBanked = 0; decimal dSumEIOBanked = 0;

        List<PDCostReductionSummary> lstPDCostReduction = lstGetCostReductionByYear(oTrans.tYear().iYear);
        foreach (PDCostReductionSummary oCostReduction in lstPDCostReduction)
        {
            dSumOpex += oCostReduction.dOpex;

            dSumDeepDiveBanked += oCostReduction.dDeepDiveBankable;//dDeepDiveBanked
            dSumDeepDiveOpporBanked += oCostReduction.dDeepDiveOpporBanked;
            dSumEIOBanked += oCostReduction.dEIOBanked;
        }

        decimal oResult = (dSumOpex != 0) ? Math.Round((((dSumDeepDiveBanked + dSumDeepDiveOpporBanked + dSumEIOBanked) / dSumOpex) * 100), 1) : 0;

        return oResult;
    }


    public DataTable dtGetYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getYears2();

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

    public DataTable DtGetCostReductionByAssetService(int iServiceId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetCostReductionByAssetService();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iServiceId";
        param.Value = iServiceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetCostReductionByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetCostReductionByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetPDCostReductionPerformance(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetPDCostReductionPerformance();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<PDCostReductionSummary> lstGetCostReductionByAssetService(int iServiceId, int iYear)
    {
        DataTable dt = DtGetCostReductionByAssetService(iServiceId, iYear);

        List<PDCostReductionSummary> lstCostReduction = new List<PDCostReductionSummary>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstCostReduction.Add(new PDCostReductionSummary(dr));
        }
        return lstCostReduction;
    }

    public List<PDCostReductionSummary> lstGetCostReductionByYear(int iYear)
    {
        DataTable dt = DtGetCostReductionByYear(iYear);

        List<PDCostReductionSummary> lstCostReduction = new List<PDCostReductionSummary>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstCostReduction.Add(new PDCostReductionSummary(dr));
        }
        return lstCostReduction;
    }

    public DataTable DtGetCostReductionSummaryByAssetId(int iAssetId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.GetCostReductionSummaryByAsset();

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

    public PDCostReductionSummary ObjGetCostReductionSummaryByAssetId(int iAssetId, int iYear)
    {
        DataTable dt = DtGetCostReductionSummaryByAssetId(iAssetId, iYear);

        PDCostReductionSummary oRows = new PDCostReductionSummary();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDCostReductionSummary(dr);
        }
        return oRows;
    }

    public bool CreatePDCostReductionSummary(PDCostReductionSummary oCostSummary)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.CreatePDCostReduction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oCostSummary.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveBanked";
        param.Value = oCostSummary.dDeepDiveBanked;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveBankable";
        param.Value = oCostSummary.dDeepDiveBankable;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveExpected";
        param.Value = oCostSummary.dDeepDiveExpected;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveOppor";
        param.Value = oCostSummary.dDeepDiveOppor;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveOpporBanked";
        param.Value = oCostSummary.dDeepDiveOpporBanked;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveOpporExpected";
        param.Value = oCostSummary.dDeepDiveOpporExpected;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oCostSummary.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIOBanked";
        param.Value = oCostSummary.dEIOBanked;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIOActual";
        param.Value = oCostSummary.dEIOActual;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIOCostAvoidance";
        param.Value = oCostSummary.dEIOCostAvoidance;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dOpex";
        param.Value = oCostSummary.dOpex;
        param.DbType = DbType.Decimal;
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
        param.Value = oCostSummary.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPerDescription";
        param.Value = oCostSummary.sPerformanceDescription;
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
    public bool UpdatePDCostReductionSummary(PDCostReductionSummary oCostSummary)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdatePDCostReduction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCost";
        param.Value = oCostSummary.lCost;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oCostSummary.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveBanked";
        param.Value = oCostSummary.dDeepDiveBanked;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveBankable";
        param.Value = oCostSummary.dDeepDiveBankable;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveExpected";
        param.Value = oCostSummary.dDeepDiveExpected;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveOppor";
        param.Value = oCostSummary.dDeepDiveOppor;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveOpporBanked";
        param.Value = oCostSummary.dDeepDiveOpporBanked;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDeepDiveOpporExpected";
        param.Value = oCostSummary.dDeepDiveOpporExpected;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oCostSummary.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIOBanked";
        param.Value = oCostSummary.dEIOBanked;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIOActual";
        param.Value = oCostSummary.dEIOActual;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIOCostAvoidance";
        param.Value = oCostSummary.dEIOCostAvoidance;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dOpex";
        param.Value = oCostSummary.dOpex;
        param.DbType = DbType.Decimal;
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
        param.Value = oCostSummary.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPerDescription";
        param.Value = oCostSummary.sPerformanceDescription;
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
    public bool DeletePDCostReductionSummary(long lOpCost)
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

    public decimal TotalDDBanked(decimal dDDBanked, decimal DDOpporBanked)
    {
        //decimal DDBanked = !string.IsNullOrEmpty(txtDDBanked.Text) ? decimal.Parse(txtDDBanked.Text) : 0;
        //decimal DDOpporBanked = !string.IsNullOrEmpty(txtDDOpporBanked.Text) ? decimal.Parse(txtDDOpporBanked.Text) : 0;
        decimal totDDBanked = dDDBanked + DDOpporBanked;
        return totDDBanked;
    }

    public decimal PercentageDDBanked(decimal dOpex, decimal dDDBanked, decimal DDOpporBanked)
    {
        //decimal Opex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
        decimal PerDDBanked = (dOpex == 0) ? 0 : (TotalDDBanked(dDDBanked, DDOpporBanked) / dOpex) * 100;
        return Math.Round(PerDDBanked, 1);
    }

    public decimal PercentageEioBanked(decimal dEffImprBanked, decimal dEffImprOppor)
    {
        //decimal dEioBanked = !string.IsNullOrEmpty(txtEffImprovementBanked.Text) ? decimal.Parse(txtEffImprovementBanked.Text) : 0;
        //decimal dEio = !string.IsNullOrEmpty(txtEffImprovement.Text) ? decimal.Parse(txtEffImprovement.Text) : 0;
        decimal PerEioBanked = (dEffImprOppor == 0) ? 0 : (dEffImprBanked / dEffImprOppor) * 100;
        return Math.Round(PerEioBanked, 1);
    }

    public decimal AllSavingsBanked(decimal dEffImprOpporBanked, decimal dDDBanked, decimal DDOpporBanked)
    {
        //decimal dEioBanked = !string.IsNullOrEmpty(txtEffImprovementBanked.Text) ? decimal.Parse(txtEffImprovementBanked.Text) : 0;
        decimal dAllSavingsbanked = TotalDDBanked(dDDBanked, DDOpporBanked) + dEffImprOpporBanked;
        return dAllSavingsbanked;
    }

    public decimal PercentageSavingsBanked(decimal dOpex, decimal dEffImprOpporBanked, decimal dDDBanked, decimal DDOpporBanked)
    {
        //decimal Opex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
        decimal PercBanked = (dOpex == 0) ? 0 : (AllSavingsBanked(dEffImprOpporBanked, dDDBanked, DDOpporBanked) / dOpex) * 100;
        return Math.Round(PercBanked, 1);
    }

    public decimal TargetReduction(decimal dOpex)
    {
        //decimal Opex = !string.IsNullOrEmpty(txtOpexYear.Text) ? decimal.Parse(txtOpexYear.Text) : 0;
        decimal PercTargetRedtn = dOpex * 0.25M;
        return PercTargetRedtn;
    }

    public DataTable DtGetPDCostReductionPerformanceByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPDCostReductionPerformanceByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PDPerformanceSumm ObjGetPDPerformanceSummaryByYear(int iYear)
    {
        DataTable dt = DtGetPDCostReductionPerformanceByYear(iYear);

        PDPerformanceSumm oRows = new PDPerformanceSumm();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDPerformanceSumm(dr);
        }
        return oRows;
    }
    public DataTable DtGetPDCostReductionPerformanceByYearAssetService(int iYear, int iServiceId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPDCostReductionPerformanceByYearAssetService();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iServiceId";
        param.Value = iServiceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PDPerformanceSumm ObjGetPDPerformanceSummaryByYearAssetService(int iYear, int iServiceId)
    {
        DataTable dt = DtGetPDCostReductionPerformanceByYearAssetService(iYear, iServiceId);

        PDPerformanceSumm oRows = new PDPerformanceSumm();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDPerformanceSumm(dr);
        }
        return oRows;
    }
    public DataTable DtGetPDCostReductionPerformanceByYearOU(int iYear, int iOuId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getPDCostReductionPerformanceByYearOU();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOuId";
        param.Value = iOuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public PDPerformanceSumm ObjGetPDPerformanceSummaryByYearOU(int iYear, int iOuId)
    {
        DataTable dt = DtGetPDCostReductionPerformanceByYearOU(iYear, iOuId);

        PDPerformanceSumm oRows = new PDPerformanceSumm();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDPerformanceSumm(dr);
        }
        return oRows;
    }


    public bool InsertInitialEstimatedSavings(PDInitialEstimatedSavings oEstimated)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.InsertInitialEstimatedSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oEstimated.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oEstimated.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oEstimated.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oEstimated.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oEstimated.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oEstimated.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oEstimated.iUserId;
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

    public bool UpdateInitialEstimatedSavings(PDInitialEstimatedSavings oEstimated)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateInitialEstimatedSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oEstimated.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oEstimated.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oEstimated.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oEstimated.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oEstimated.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oEstimated.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oEstimated.iUserId;
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

    public bool InsertEstimatedSavings(PDEstimatedSavings oEstimated)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.InsertEstimatedSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oEstimated.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oEstimated.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oEstimated.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oEstimated.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oEstimated.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oEstimated.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oEstimated.iUserId;
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
    public bool UpdateEstimatedSavings(PDEstimatedSavings oEstimated)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateEstimatedSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lEstimateId";
        param.Value = oEstimated.lEstimateId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oEstimated.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oEstimated.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oEstimated.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oEstimated.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oEstimated.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oEstimated.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oEstimated.iUserId;
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

    public bool UpdateEstimatedSavings2(PDEstimatedSavings oEstimated)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateEstimatedSavings2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oEstimated.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oEstimated.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oEstimated.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oEstimated.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oEstimated.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oEstimated.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oEstimated.iUserId;
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


    public bool InsertActualSavings(PDActualSavings oActual)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.InsertActualSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oActual.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oActual.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oActual.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oActual.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oActual.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oActual.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oActual.iUserId;
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
    public bool UpdateActualSavings(PDActualSavings oActual)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateActualSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lActualId";
        param.Value = oActual.lActualId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oActual.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oActual.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oActual.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oActual.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oActual.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oActual.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oActual.iUserId;
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

    public bool UpdateActualSavings2(PDActualSavings oActual)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateActualSavings2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oActual.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oActual.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oActual.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oActual.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oActual.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oActual.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oActual.iUserId;
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

    public bool InsertLESavings(PDLESavings oLE)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.InsertLESavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oLE.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oLE.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oLE.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oLE.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oLE.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oLE.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oLE.iUserId;
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
    public bool UpdateLESavings(PDLESavings oLE)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateLESavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lLEId";
        param.Value = oLE.lLEId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oLE.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oLE.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oLE.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oLE.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oLE.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oLE.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oLE.iUserId;
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

    public bool UpdateLESavings2(PDLESavings oLE)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.UpdateLESavings2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = oLE.iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDD";
        param.Value = oLE.dDD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDDO";
        param.Value = oLE.dDDO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dEIO";
        param.Value = oLE.dEIO;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":DtDateUpdated";
        //param.Value = DateTime.Today.Date;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oLE.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oLE.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oLE.iUserId;
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


    public DataTable DtGetAssetEstimatedSavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getEstimatedSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public PDEstimatedSavings ObjGetAssetEstimatedSavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        DataTable dt = DtGetAssetEstimatedSavingByMonthYear(iAsset, iMonth, iYear);

        PDEstimatedSavings oRows = new PDEstimatedSavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDEstimatedSavings(dr);
        }
        return oRows;
    }

    public DataTable DtGetAssetInitialEstimatedSavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getInitialEstimatedSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public PDInitialEstimatedSavings ObjGetAssetInitialEstimatedSavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        DataTable dt = DtGetAssetInitialEstimatedSavingByMonthYear(iAsset, iMonth, iYear);

        PDInitialEstimatedSavings oRows = new PDInitialEstimatedSavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDInitialEstimatedSavings(dr);
        }
        return oRows;
    }

    public DataTable DtGetAssetActualSavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getActualSavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable DtGetAssetLESavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getLESavings();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAsset;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public PDActualSavings ObjGetAssetActualSavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        DataTable dt = DtGetAssetActualSavingByMonthYear(iAsset, iMonth, iYear);

        PDActualSavings oRows = new PDActualSavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDActualSavings(dr);
        }
        return oRows;
    }

    public PDLESavings ObjGetAssetLESavingByMonthYear(int iAsset, int iMonth, int iYear)
    {
        DataTable dt = DtGetAssetLESavingByMonthYear(iAsset, iMonth, iYear);

        PDLESavings oRows = new PDLESavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDLESavings(dr);
        }
        return oRows;
    }


    public DataTable DtGetEstimatedSavingByMonthYear(int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getEstimatedSavingsSum();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PDEstimatedActualSavings ObjGetEstimatedSavingByMonthYear(int iMonth, int iYear)
    {
        DataTable dt = DtGetEstimatedSavingByMonthYear(iMonth, iYear);

        PDEstimatedActualSavings oRows = new PDEstimatedActualSavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDEstimatedActualSavings(dr);
        }
        return oRows;
    }

    public DataTable DtGetInitialEstimatedSavingByMonthYear(int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getInitialEstimatedSavingsSum();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PDEstimatedActualSavings ObjGetInitialEstimatedSavingByMonthYear(int iMonth, int iYear)
    {
        DataTable dt = DtGetInitialEstimatedSavingByMonthYear(iMonth, iYear);

        PDEstimatedActualSavings oRows = new PDEstimatedActualSavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDEstimatedActualSavings(dr);
        }
        return oRows;
    }

    public DataTable DtGetActualSavingByMonthYear(int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getActualSavingsSum();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PDEstimatedActualSavings ObjGetActualSavingByMonthYear(int iMonth, int iYear)
    {
        DataTable dt = DtGetActualSavingByMonthYear(iMonth, iYear);

        PDEstimatedActualSavings oRows = new PDEstimatedActualSavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDEstimatedActualSavings(dr);
        }
        return oRows;
    }

    public DataTable DtGetLESavingByMonthYear(int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedurePDCC.getLESavingsSum();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public PDEstimatedActualSavings ObjGetLESavingByMonthYear(int iMonth, int iYear)
    {
        DataTable dt = DtGetLESavingByMonthYear(iMonth, iYear);

        PDEstimatedActualSavings oRows = new PDEstimatedActualSavings();
        foreach (DataRow dr in dt.Rows)
        {
            oRows = new PDEstimatedActualSavings(dr);
        }
        return oRows;
    }

}