using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


/// <summary>
/// Summary description for Eliminate
/// </summary>
public class Eliminate
{
    public long lProjectId { get; set; }
    public long lEliminateId { get; set; }
    public string sKaizenID { get; set; }
    public string sPIP { get; set; }
    public int iPIPV { get; set; }
    public int iHoldKaizenEventV { get; set; }
    public int iRecommendationSignedoffV { get; set; }
    public int iImplementV { get; set; }
    public string sHoldKaizenEvent { get; set; }
    public string sSponsorApproveRec { get; set; }
    public string sImplement { get; set; }
    public string sEliminateWorkDone { get; set; }

	public Eliminate()
	{
		//
		// 
		//
	}

    public Eliminate(DataRow dr)
    {
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        lEliminateId = long.Parse(dr["IDELIMINATE"].ToString());
        sKaizenID = dr["KAIZENID"].ToString();
        sPIP = dr["PIP"].ToString();
        iPIPV = int.Parse(dr["PIP_V"].ToString());
        iHoldKaizenEventV = int.Parse(dr["HOLD_KAIZEN_EVENT_V"].ToString());
        iRecommendationSignedoffV = int.Parse(dr["SPONSOR_APPROVE_REC_V"].ToString());
        iImplementV = int.Parse(dr["IMPLEMENT_V"].ToString());
        sHoldKaizenEvent = dr["HOLD_KAIZEN_EVENT"].ToString();
        sSponsorApproveRec = dr["SPONSOR_APPROVE_REC"].ToString();
        sImplement = dr["IMPLEMENT"].ToString();
        sEliminateWorkDone = dr["ELIMINATE_WORK_DONE"].ToString();
    }
}

public class EliminateHelper
{
    public EliminateHelper()
    {
        //
        // 
        //
    }

    public DataTable dtGetEliminateyByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectEliminateByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Eliminate objGetEliminateByProjectId(long lProjectId)
    {
        DataTable dt = dtGetEliminateyByProjectId(lProjectId);

        Eliminate oIdentify = new Eliminate();
        foreach (DataRow dr in dt.Rows)
        {
            oIdentify = new Eliminate(dr);
        }
        return oIdentify;
    }

    public bool InsertEliminate(Eliminate oEliminate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertEliminate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oEliminate.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sHoldKaizenEventV";
        param.Value = oEliminate.iHoldKaizenEventV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sImplementV";
        param.Value = oEliminate.iImplementV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPIPV";
        param.Value = oEliminate.iPIPV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSponsorApproveRecV";
        param.Value = oEliminate.iRecommendationSignedoffV;
        param.DbType = DbType.Int32;
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

    public bool UpdateEliminate(Eliminate oEliminate)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateEliminate();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oEliminate.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sHoldKaizenEventV";
        param.Value = oEliminate.iHoldKaizenEventV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sImplementV";
        param.Value = oEliminate.iImplementV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPIPV";
        param.Value = oEliminate.iPIPV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSponsorApproveRecV";
        param.Value = oEliminate.iRecommendationSignedoffV;
        param.DbType = DbType.Int32;
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

    public DataTable dtGetEliminateWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getEliminateWorkDoneByFunctionYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<Eliminate> lstGetEliminateWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        DataTable dt = dtGetEliminateWorkDoneByFunctionYear(iFunctionId, iYear);

        List<Eliminate> oEliminate = new List<Eliminate>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oEliminate.Add(new Eliminate(dr));
        }
        return oEliminate;
    }

    public int EliminateWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        int iEliminateWorkdone = 0;
        EliminateHelper oEliminateHelper = new EliminateHelper();
        List<Eliminate> lstEliminate = oEliminateHelper.lstGetEliminateWorkDoneByFunctionYear(iFunctionId, iYear);
        foreach (Eliminate oEliminate in lstEliminate)
        {
            int intSum = (oEliminate.iHoldKaizenEventV + oEliminate.iImplementV + oEliminate.iPIPV + oEliminate.iRecommendationSignedoffV);
            if ((intSum >= 80) && (intSum <= 100))
            {
                iEliminateWorkdone += 1;
            }
        }

        return iEliminateWorkdone;
    }

    public int EliminateWorkDoneByProject(long iProjectId)
    {
        EliminateHelper oEliminateHelper = new EliminateHelper();
        Eliminate oEliminate = oEliminateHelper.objGetEliminateByProjectId(iProjectId);

        int intSum = (oEliminate.iHoldKaizenEventV + oEliminate.iImplementV + oEliminate.iPIPV + oEliminate.iRecommendationSignedoffV);
        return intSum;
    }

    public DataTable dtGetEliminateWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getEliminateWorkDoneByProjectYear();

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

    public Eliminate objGetEliminateWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        DataTable dt = dtGetEliminateWorkDoneByProjectYear(lProjectId, iYear);

        Eliminate oEliminate = new Eliminate();
        foreach (DataRow dr in dt.Rows)
        {
            oEliminate = new Eliminate(dr);
        }
        return oEliminate;
    }

    public int EliminateWorkDoneByProjectYear(long lProjectId, int iYear, System.Web.UI.WebControls.Image imgEliminate, System.Web.UI.WebControls.Label lblEliminate)
    {
        EliminateHelper oEliminateHelper = new EliminateHelper();
        Eliminate oEliminate = oEliminateHelper.objGetEliminateWorkDoneByProjectYear(lProjectId, iYear);

        int intSum = (oEliminate.iHoldKaizenEventV + oEliminate.iImplementV + oEliminate.iPIPV + oEliminate.iRecommendationSignedoffV);
        if ((intSum >= 80) && (intSum <= 100))
        {
            imgEliminate.ImageUrl = "~/Images/i_Green.GIF";
        }
        else if ((intSum < 80) && (intSum >= 50))
        {
            imgEliminate.ImageUrl = "~/Images/i_Amber.GIF";
        }
        else
        {
            imgEliminate.ImageUrl = "~/Images/i_Red.GIF";
        }

        lblEliminate.Text = intSum.ToString() + "%";
        return intSum;
    }
    public int EliminateWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        EliminateHelper oEliminateHelper = new EliminateHelper();
        Eliminate oEliminate = oEliminateHelper.objGetEliminateWorkDoneByProjectYear(lProjectId, iYear);

        int intSum = (oEliminate.iHoldKaizenEventV + oEliminate.iImplementV + oEliminate.iPIPV + oEliminate.iRecommendationSignedoffV);
        return intSum;
    }
}