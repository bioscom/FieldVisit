using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


/// <summary>
/// Summary description for Identify
/// </summary>
public class Identify
{
    public long lProjectId { get; set; }
    public long lIdentifyId { get; set; }
    public string sVSMID { get; set; }
    public string sKickOffMeeting { get; set; }
    public int iKickOffMeetingV { get; set; }
    public string sCharterSignOff { get; set; }
    public int iCharterSignOffV { get; set; }
    public string sProcessWalk { get; set; }
    public int iProcessWalkV { get; set; }
    public string sVSM { get; set; }
    public int iVSMV { get; set; }
    public string sIdentifyWorkDone { get; set; }

	public Identify()
	{
		//
		// 
		//
	}

    public Identify(DataRow dr)
    {
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        lIdentifyId = long.Parse(dr["IDIDENTIFY"].ToString());
        iKickOffMeetingV = int.Parse(dr["KICK_OFF_MEET_V"].ToString());
        iCharterSignOffV = int.Parse(dr["SIGNOFF_CHARTER_V"].ToString());
        iProcessWalkV = int.Parse(dr["PROCESS_WALK_V"].ToString());
        iVSMV = int.Parse(dr["VSM_V"].ToString());
        sProcessWalk = dr["PROCESS_WALK"].ToString();
        sCharterSignOff = dr["SIGNOFF_CHARTERS"].ToString();
        sVSM = dr["VSM"].ToString();
        sVSMID = dr["VSMID"].ToString();
        sKickOffMeeting = dr["KICKOFF_MEET"].ToString();
        sIdentifyWorkDone = dr["IDENTIFY_WORKDONE"].ToString();
    }
}

public class IdentifyHelper
{
    public IdentifyHelper()
	{
		//
		// 
		//
	}

    public DataTable dtGetIdentifyByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectIdentifyByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetIdentifyWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getIdentifyWorkDoneByFunctionYear();

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

    public Identify objGetIdentifyWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        DataTable dt = dtGetIdentifyWorkDoneByFunctionYear(iFunctionId, iYear);

        Identify oIdentify = new Identify();
        foreach (DataRow dr in dt.Rows)
        {
            oIdentify = new Identify(dr);
        }
        return oIdentify;
    }

    public List<Identify> lstGetIdentifyWorkDoneByFunctionYear(int iFunctionId, int iYear) 
    {
        DataTable dt = dtGetIdentifyWorkDoneByFunctionYear(iFunctionId, iYear);

        List<Identify> oIdentify = new List<Identify>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oIdentify.Add(new Identify(dr));
        }
        return oIdentify;
    }

    public Identify objGetIdentifyByProjectId(long lProjectId)
    {
        DataTable dt = dtGetIdentifyByProjectId(lProjectId);

        Identify oIdentify = new Identify();
        foreach (DataRow dr in dt.Rows)
        {
            oIdentify = new Identify(dr);
        }
        return oIdentify;
    }

    public bool InsertIdentify(Identify oIdentify)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertIdentify();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oIdentify.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCharterSignOffV";
        param.Value = oIdentify.iCharterSignOffV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sKickOffMeetingV";
        param.Value = oIdentify.iKickOffMeetingV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProcessWalkV";
        param.Value = oIdentify.iProcessWalkV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sVSMV";
        param.Value = oIdentify.iVSMV;
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

    public bool UpdateIdentify(Identify oIdentify)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateIdentify();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oIdentify.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCharterSignOffV";
        param.Value = oIdentify.iCharterSignOffV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sKickOffMeetingV";
        param.Value = oIdentify.iKickOffMeetingV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProcessWalkV";
        param.Value = oIdentify.iProcessWalkV;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sVSMV";
        param.Value = oIdentify.iVSMV;
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

    public int IdentifyWorkDoneByFunctionYear(int iFunctionId, int iYear)
    {
        int iIdentifyWorkdone = 0;
        IdentifyHelper oIdentifyHelper = new IdentifyHelper();
        List<Identify> lstIdentify = oIdentifyHelper.lstGetIdentifyWorkDoneByFunctionYear(iFunctionId, iYear);
        foreach (Identify oIdentify in lstIdentify)
        {
            int intSum = (oIdentify.iCharterSignOffV + oIdentify.iKickOffMeetingV + oIdentify.iProcessWalkV + oIdentify.iVSMV);
            if ((intSum >= 80) && (intSum <= 100))
            {
                iIdentifyWorkdone += 1;
            }
        }

        return iIdentifyWorkdone;
    }

    public int IdentifyWorkDoneByProject(long lProjectId)
    {
        IdentifyHelper oIdentifyHelper = new IdentifyHelper();
        Identify oIdentify = oIdentifyHelper.objGetIdentifyByProjectId(lProjectId);

        int intSum = (oIdentify.iCharterSignOffV + oIdentify.iKickOffMeetingV + oIdentify.iProcessWalkV + oIdentify.iVSMV);
        return intSum;
    }

    public DataTable dtGetIdentifyWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getIdentifyWorkDoneByProjectYear();

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

    public Identify objGetIdentifyWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        DataTable dt = dtGetIdentifyWorkDoneByProjectYear(lProjectId, iYear);

        Identify oIdentify = new Identify();
        foreach (DataRow dr in dt.Rows)
        {
            oIdentify = new Identify(dr);
        }
        return oIdentify;
    }

    public int IdentifyWorkDoneByProjectYear(long lProjectId, int iYear, System.Web.UI.WebControls.Image imgIdentify, System.Web.UI.WebControls.Label lblIdentify)
    {
        //int iIdentifyWorkdone = 0;

        IdentifyHelper oIdentifyHelper = new IdentifyHelper();
        Identify oIdentify = oIdentifyHelper.objGetIdentifyWorkDoneByProjectYear(lProjectId, iYear);

        int intSum = (oIdentify.iCharterSignOffV + oIdentify.iKickOffMeetingV + oIdentify.iProcessWalkV + oIdentify.iVSMV);
        if ((intSum >= 80) && (intSum <= 100))
        {
            imgIdentify.ImageUrl = "~/Images/i_Green.GIF";
        }
        else if ((intSum < 80) && (intSum >= 50))
        {
            imgIdentify.ImageUrl = "~/Images/i_Amber.GIF";
        }
        else
        {
            imgIdentify.ImageUrl = "~/Images/i_Red.GIF";
        }
        lblIdentify.Text = intSum.ToString() + "%";

        return intSum;
    }

    public int IdentifyWorkDoneByProjectYear(long lProjectId, int iYear)
    {
        //int iIdentifyWorkdone = 0;

        IdentifyHelper oIdentifyHelper = new IdentifyHelper();
        Identify oIdentify = oIdentifyHelper.objGetIdentifyWorkDoneByProjectYear(lProjectId, iYear);

        int intSum = (oIdentify.iCharterSignOffV + oIdentify.iKickOffMeetingV + oIdentify.iProcessWalkV + oIdentify.iVSMV);
        return intSum;
    }
}