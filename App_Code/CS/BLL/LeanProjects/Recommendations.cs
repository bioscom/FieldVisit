using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Recommendations
/// </summary>
public class Recommendations
{
    public long lRecommendationId { get; set; }
    public long lProjectId { get; set; }
    public string sRecommendations { get; set; }
    public int iActionParty { get; set; }
    public int iSeqId { get; set; }
    public int iActionFunction { get; set; }
    public DateTime dtTargetDate { get; set; }
    public string sSponsorComment { get; set; }
    public string sChampionComment { get; set; }
    public int iStatus { get; set; }
    public int iFunctionId { get; set; }
    //public int iTeamId { get; set; }
    public Nullable<Single> dCTReduction { get; set; }
    public Nullable<Single> dCostReduction { get; set; }
    public Nullable<Single> dProductionBarrel { get; set; }
    public Nullable<Single> dNumber { get; set; }
    public string sOtherBenefits { get; set; }
    public string sComments { get; set; }
    

	public Recommendations()
	{
		//
		// 
		//
	}

    public Recommendations(DataRow dr)
    {
        lRecommendationId = long.Parse(dr["RECOMMENDATIONID"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        iSeqId = int.Parse(dr["SEQID"].ToString());
        sRecommendations = dr["RECOMMENDATION"].ToString();
        iActionParty = (dr["CTREDUCTION"] == DBNull.Value) ? -1 : int.Parse(dr["ACTIONPARTYFUNCTIONID"].ToString());
        iActionFunction = (dr["CTREDUCTION"] == DBNull.Value) ? -1 : int.Parse(dr["ACTIONFUNTIONFUNCTIONID"].ToString());
        dtTargetDate = DateTime.Parse(dr["TARGETDATE"].ToString());
        sSponsorComment = dr["SPONSOR_COMMENT"].ToString();
        sChampionComment = dr["CHAMPION_COMMENT"].ToString();
        iStatus = int.Parse(dr["STATUS"].ToString());
        iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());

        dCTReduction = (dr["CTREDUCTION"] == DBNull.Value) ? 0 : Convert.ToSingle(dr["CTREDUCTION"].ToString());
        dCostReduction = (dr["COSTREDUCTION"] == DBNull.Value) ? 0 : Convert.ToSingle(dr["COSTREDUCTION"].ToString());
        dProductionBarrel = (dr["PRODUCTIONBARREL"] == DBNull.Value) ? 0 : Convert.ToSingle(dr["PRODUCTIONBARREL"].ToString());
        dNumber = (dr["NUMBERRS"] == DBNull.Value) ? 0 : Convert.ToSingle(dr["NUMBERRS"].ToString());

        sOtherBenefits = dr["OTHERBENEFITS"].ToString();
        sComments = dr["COMMENTS"].ToString();

        //ACTIONPARTY.FUNCTIONID AS ACTIONPARTYFUNCTIONID, ACTIONPARTY.FUNCTION AS ACTIONPARTYFUNCTION, ACTIONFUNTION.FUNCTIONID AS ACTIONFUNTIONFUNCTIONID, ";
        //sql += "ACTIONFUNTION.FUNCTION AS ACTIONFUNTIONFUNCTION
    }
}


public class RecommendationsHelper
{
    public RecommendationsHelper()
    {
        //
        // 
        //
    }

    public DataTable dtGetLeanProjectRecommendationsByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectRecommendationsByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetLeanProjectRecommendationById(long lRecommendationId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectRecommendationById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRecommendationId";
        param.Value = lRecommendationId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public Recommendations objGetLeanProjectRecommendationById(long lRecommendationId)
    {
        DataTable dt = dtGetLeanProjectRecommendationById(lRecommendationId);

        Recommendations oRecommendations = new Recommendations();
        foreach (DataRow dr in dt.Rows)
        {
            oRecommendations = new Recommendations(dr);
        }
        return oRecommendations;
    }

    public bool InsertRecommendation(Recommendations oRecommendations)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertRecommendation();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oRecommendations.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActionParty";
        param.Value = oRecommendations.iActionParty;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActionFunction";
        param.Value = oRecommendations.iActionFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = oRecommendations.iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = oRecommendations.iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sChampionComment";
        param.Value = oRecommendations.sChampionComment;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":iSeqId";
        param.Value = oRecommendations.iSeqId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRecommendations";
        param.Value = oRecommendations.sRecommendations;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSponsorComment";
        param.Value = oRecommendations.sSponsorComment;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":sTargetDate";
        param.Value = oRecommendations.dtTargetDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostReduction";
        param.Value = oRecommendations.dCostReduction;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCTReduction";
        param.Value = oRecommendations.dCTReduction;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProductionBarrel";
        param.Value = oRecommendations.dProductionBarrel;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNumber";
        param.Value = oRecommendations.dNumber;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOtherBenefits";
        param.Value = oRecommendations.sOtherBenefits;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oRecommendations.sComments; ;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);

    }

    public bool UpdateRecommendation(Recommendations oRecommendations)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateRecommendation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iActionParty";
        param.Value = oRecommendations.iActionParty;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iActionFunction";
        param.Value = oRecommendations.iActionFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = oRecommendations.iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = oRecommendations.iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lRecommendationId";
        param.Value = oRecommendations.lRecommendationId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sChampionComment";
        param.Value = oRecommendations.sChampionComment;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRecommendations";
        param.Value = oRecommendations.sRecommendations;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSponsorComment";
        param.Value = oRecommendations.sSponsorComment;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTargetDate";
        param.Value = oRecommendations.dtTargetDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostReduction";
        param.Value = oRecommendations.dCostReduction;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCTReduction";
        param.Value = oRecommendations.dCTReduction;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProductionBarrel";
        param.Value = oRecommendations.dProductionBarrel;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNumber";
        param.Value = oRecommendations.dNumber;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOtherBenefits";
        param.Value = oRecommendations.sOtherBenefits;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oRecommendations.sComments; ;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool DeleteRecommendation(long lRecommendationId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteRecommendation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRecommendationId";
        param.Value = lRecommendationId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }
}