using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Sustain
/// </summary>
public class Sustain
{
    public long lProjectId { get; set; }
    public long lSustainId { get; set; }
    public string sSPOP { get; set; }
    public string sVisual_Measures { get; set; }
    public string sHandOver { get; set; }
    public int iSPOP_V { get; set; }
    public int iVisual_MeasuresV { get; set; }
    public int iHandOverV { get; set; }
    public string sSustainWorkDone { get; set; }

	public Sustain()
	{
		//
		// 
		//
	}

    public Sustain(DataRow dr)
    {
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        lSustainId = long.Parse(dr["IDSUSTAIN"].ToString());
        sSPOP = dr["SOPS"].ToString();
        iSPOP_V = int.Parse(dr["SOPS_V"].ToString());
        sVisual_Measures = dr["VISUAL_MEASURES"].ToString();
        iVisual_MeasuresV = int.Parse(dr["VISUAL_MEASURES_V"].ToString());
        sHandOver = dr["HANDOVER"].ToString();
        iHandOverV = int.Parse(dr["HANDOVER_V"].ToString());
        sSustainWorkDone = dr["SUSTAIN_WORKDONE"].ToString();
    }
}

public class SustainHelper
{
    public SustainHelper()
    {
        //
        // 
        //
    }

    public DataTable dtGetSustainByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectSustainByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Sustain objGetSustainByProjectId(long lProjectId)
    {
        DataTable dt = dtGetSustainByProjectId(lProjectId);

        Sustain oSustain = new Sustain();
        foreach (DataRow dr in dt.Rows)
        {
            oSustain = new Sustain(dr);
        }
        return oSustain;
    }

    public bool InsertSustain(Sustain oSustain)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertSustain();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oSustain.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sHandOverV";
        param.Value = oSustain.iHandOverV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSPOP_V";
        param.Value = oSustain.iSPOP_V;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sVisual_MeasuresV";
        param.Value = oSustain.iVisual_MeasuresV;
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

    public bool UpdateSustain(Sustain oSustain)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateSustain();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oSustain.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sHandOverV";
        param.Value = oSustain.iHandOverV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSPOP_V";
        param.Value = oSustain.iSPOP_V;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sVisual_MeasuresV";
        param.Value = oSustain.iVisual_MeasuresV;
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

    public DataTable dtGetSustainWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getSustainWorkDoneByFunctionYear();

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

    public List<Sustain> lstGetSustainWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        DataTable dt = dtGetSustainWorkDoneByFunctionYear(iFunctionId, iYear);

        List<Sustain> oSustain = new List<Sustain>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oSustain.Add(new Sustain(dr));
        }
        return oSustain;
    }

    public int SustainWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        int iSustainWorkdone = 0;
        SustainHelper oSustainHelper = new SustainHelper();
        List<Sustain> lstSustain = oSustainHelper.lstGetSustainWorkDoneByFunctionYear(iFunctionId, iYear);
        foreach (Sustain oSustain in lstSustain)
        {
            int intSum = (oSustain.iHandOverV + oSustain.iSPOP_V + oSustain.iVisual_MeasuresV);
            if ((intSum >= 80) && (intSum <= 100))
            {
                iSustainWorkdone += 1;
            }
        }

        return iSustainWorkdone;
    }

    public int SustainWorkDoneByProject(long lProjectId)
    {
        SustainHelper oSustainHelper = new SustainHelper();
        Sustain oSustain = oSustainHelper.objGetSustainByProjectId(lProjectId);

        int intSum = (oSustain.iHandOverV + oSustain.iSPOP_V + oSustain.iVisual_MeasuresV);
        return intSum;
    }

    public DataTable dtGetSustainWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getSustainWorkDoneByProjectYear();

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

    public Sustain objGetSustainWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        DataTable dt = dtGetSustainWorkDoneByProjectYear(lProjectId, iYear);

        Sustain oSustain = new Sustain();
        foreach (DataRow dr in dt.Rows)
        {
            oSustain = new Sustain(dr);
        }
        return oSustain;
    }

    public int SustainWorkDoneByProjectYear(int iProjectId, int iYear, System.Web.UI.WebControls.Image imgSustain, System.Web.UI.WebControls.Label lblSustain)
    {
        SustainHelper oSustainHelper = new SustainHelper();
        Sustain oSustain = oSustainHelper.objGetSustainWorkDoneByProjectYear(iProjectId, iYear);

        int intSum = (oSustain.iHandOverV + oSustain.iSPOP_V + oSustain.iVisual_MeasuresV);

        if ((intSum >= 80) && (intSum <= 100))
        {
            imgSustain.ImageUrl = "~/Images/i_Green.GIF";
        }
        else if ((intSum < 80) && (intSum >= 50))
        {
            imgSustain.ImageUrl = "~/Images/i_Amber.GIF";
        }
        else
        {
            imgSustain.ImageUrl = "~/Images/i_Red.GIF";
        }
        lblSustain.Text = intSum.ToString() + "%";

        return intSum;
    }

    public int SustainWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        SustainHelper oSustainHelper = new SustainHelper();
        Sustain oSustain = oSustainHelper.objGetSustainWorkDoneByProjectYear(lProjectId, iYear);

        int intSum = (oSustain.iHandOverV + oSustain.iSPOP_V + oSustain.iVisual_MeasuresV);
        return intSum;
    }
}