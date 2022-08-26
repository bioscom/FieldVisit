using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for RecommendationActuals
/// </summary>
/// 
public class BenefitActuals
{
    public long lProjectId { get; set; }
    public long lActualId { get; set; }
    public int iYear { get; set; }
    public decimal sCTSavings { get; set; }
    public decimal sCostSavings { get; set; }
    public decimal sProductionBarrel { get; set; }
    public decimal sNumber { get; set; }
    public string sOtherBenefits { get; set; }
    public string sComments { get; set; }

    public BenefitActuals()
    {
        //
        // 
        //
    }

    public BenefitActuals(DataRow dr)
    {
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        lActualId = long.Parse(dr["ACTUALID"].ToString());
        iYear = int.Parse(dr["YYEAR"].ToString());
        sCTSavings = (dr["CT_SAINGS"] == DBNull.Value) ? 0 : decimal.Parse(dr["CT_SAINGS"].ToString());
        sCostSavings = (dr["COST_SAVINGS"] == DBNull.Value) ? 0 : decimal.Parse(dr["COST_SAVINGS"].ToString());
        sProductionBarrel = (dr["PRODUCTION_BARREL"] == DBNull.Value) ? 0 : decimal.Parse(dr["PRODUCTION_BARREL"].ToString());
        sNumber = (dr["NUMBERR"] == DBNull.Value) ? 0 : decimal.Parse(dr["NUMBERR"].ToString());
        sOtherBenefits = dr["OTHER_BENEFITS"].ToString();
        sComments = dr["COMMENTS"].ToString();
    }
}


public class BenefitActualsHelper
{
    public BenefitActualsHelper()
    {
        //
        // 
        //
    }

    public bool InsertBenefitActual(BenefitActuals oBenefitActuals)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertProjectBenefitActual();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oBenefitActuals.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oBenefitActuals.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostSavings";
        param.Value = oBenefitActuals.sCostSavings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCTSavings";
        param.Value = oBenefitActuals.sCTSavings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProductionBarrel";
        param.Value = oBenefitActuals.sProductionBarrel;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOtherBenefits";
        param.Value = oBenefitActuals.sOtherBenefits;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNumber";
        param.Value = oBenefitActuals.sNumber;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oBenefitActuals.sComments; ;
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

    public bool UpdateBenefitActual(BenefitActuals oBenefitActuals)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateProjectBenefitActual();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oBenefitActuals.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oBenefitActuals.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostSavings";
        param.Value = oBenefitActuals.sCostSavings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCTSavings";
        param.Value = oBenefitActuals.sCTSavings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProductionBarrel";
        param.Value = oBenefitActuals.sProductionBarrel;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOtherBenefits";
        param.Value = oBenefitActuals.sOtherBenefits;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNumber";
        param.Value = oBenefitActuals.sNumber;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oBenefitActuals.sComments; ;
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

    public bool DeleteBenefitActual(BenefitActuals oBenefitActuals)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteProjectBenefitActual();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lActualId";
        param.Value = oBenefitActuals.lActualId;
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
    public DataTable dtProjectBenefitsByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectBenefitsByYear2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public List<BenefitActuals> lstGetProjectBenefitsByYear(int iYear)
    {
        DataTable dt = dtProjectBenefitsByYear(iYear);

        List<BenefitActuals> oBenefitActuals = new List<BenefitActuals>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oBenefitActuals.Add(new BenefitActuals(dr));
        }
        return oBenefitActuals;
    }
    public DataTable dtProjectBenefits(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectBenefits();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetProjectBenefitsByYear(long lProjectId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectBenefitsByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public BenefitActuals objGetProjectBenefitsByYear(long lProjectId, int iYear)
    {
        DataTable dt = dtGetProjectBenefitsByYear(lProjectId, iYear);

        BenefitActuals oBenefitActuals = new BenefitActuals();
        foreach (DataRow dr in dt.Rows)
        {
            oBenefitActuals = new BenefitActuals(dr);
        }
        return oBenefitActuals;
    }

    //public void LoadProjectBenefitsByYear(int iYear, System.Web.UI.WebControls.GridView grdView)
    //{
        

    //    DataTable dt = dtProjectBenefitsByYear(iYear);
    //    grdView.DataSource = dt;
    //    grdView.DataBind();
    //}
}