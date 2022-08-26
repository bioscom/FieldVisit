using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using Microsoft.Security.Application;

/// <summary>
/// Summary description for Initiative
/// </summary>
public class Initiative
{
    public long m_lInitiativeId { get; set; }
    public int m_iUserId { get; set; }
    public string m_sBusinessCase { get; set; }
    public string m_sScope { get; set; }
    public string m_sSuccessFactor { get; set; }
    public string m_sObjectives { get; set; }
    public string m_sDeliverables { get; set; }
    public string m_sTeamMembers { get; set; }
    public string m_sBenefits { get; set; }
    public string m_sMeasures { get; set; }
    public string m_sKeyActivities { get; set; }
    public DateTime m_dDateSubmitted { get; set; }

    public string m_sTitle { get; set; }

    public int m_iOuId { get; set; }
    //public int m_iFacilityId { get; set; }
    public int m_iFunctionId { get; set; }
    public int m_iStatus { get; set; }
    public string m_sPixName { get; set; }


    public Initiative()
    {
        //
        // 
        //
    }

    public Initiative(DataRow dr)
    {
        m_lInitiativeId = long.Parse(dr["IDINITIATIVE"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_sBusinessCase = dr["BUS_CASE"].ToString();
        m_sScope = dr["SCOPE"].ToString();
        m_sSuccessFactor = dr["SUCCESS_FACTOR"].ToString();
        m_sObjectives = dr["OBJECTIVES"].ToString();
        m_sDeliverables = dr["DELIVERABLES"].ToString();
        m_sTeamMembers = dr["TEAM_MEMBER"].ToString();
        m_sBenefits = dr["BENEFITS"].ToString();
        m_sMeasures = dr["INITMEASURES"].ToString();
        m_sKeyActivities = dr["KEYACTIVITIES"].ToString();
        m_dDateSubmitted = DateTime.Parse(dr["DATE_SUBMITTED"].ToString());

        m_sTitle = dr["TITLE"].ToString();
        m_iOuId = int.Parse(dr["IDOU"].ToString());
        //m_iFacilityId = int.Parse(dr["IDFACILITIES"].ToString());
        m_iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());

        m_iStatus = int.Parse(dr["STATUS"].ToString());
        m_sPixName = dr["PIXNAME"].ToString();
    }

    public static long getInitiativeId()
    {
        string sql = "SELECT MANHR_INITIATIVE_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        long lInitiativeId = 0;
        try
        {
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
            lInitiativeId = Convert.ToInt64(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return lInitiativeId;
    }

    public bool CreateInitiative(long lInitiativeId, int UserId, string sBusinessCase, string sScope, string sSuccessFactor, string sObjectives, string sDeliverables, 
        string sTeamMembers, string sBenefits, string sMeasures, string sTitle, int OuId, int FunctionId, string sKeyActivities, string sPixName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.CreateInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = UserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":BUS_CASE";
        param.Value = sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":SCOPE";
        param.Value = sScope;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":SUCCESS_FACTOR";
        param.Value = sSuccessFactor;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":OBJECTIVES";
        param.Value = sObjectives;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DELIVERABLES";
        param.Value = sDeliverables;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TEAM_MEMBER";
        param.Value = sTeamMembers;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":BENEFITS";
        param.Value = sBenefits;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":MEASURES";
        param.Value = sMeasures;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_SUBMITTED";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TITLE";
        param.Value = sTitle;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDOU";
        param.Value = OuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FUNCTIONID";
        param.Value = FunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":KEYACTIVITIES";
        param.Value = sKeyActivities;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":PIXNAME";
        param.Value = sPixName;
        param.DbType = DbType.String;
        param.Size = 1000;
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

    public bool UpdateInitiative(long lInitiativeId, int UserId, string sBusinessCase, string sScope, string sSuccessFactor, string sObjectives, string sDeliverables, 
        string sTeamMembers, string sBenefits, string sMeasures, string sTitle, int OuId, int FunctionId, string sKeyActivities, string sPixName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = UserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":BUS_CASE";
        param.Value = sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":SCOPE";
        param.Value = sScope;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":SUCCESS_FACTOR";
        param.Value = sSuccessFactor;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":OBJECTIVES";
        param.Value = sObjectives;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DELIVERABLES";
        param.Value = sDeliverables;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TEAM_MEMBER";
        param.Value = sTeamMembers;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":BENEFITS";
        param.Value = sBenefits;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":MEASURES";
        param.Value = sMeasures;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":TITLE";
        param.Value = sTitle;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDOU";
        param.Value = OuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FUNCTIONID";
        param.Value = FunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":KEYACTIVITIES";
        param.Value = sKeyActivities;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":PIXNAME";
        param.Value = sPixName;
        param.DbType = DbType.String;
        param.Size = 1000;
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

    public static DataTable dtGetInitiativeById(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiativeById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetReportByInitiativeId(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.Reporter();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDINITIATIVE";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetImpactOnAssetTwo(int iYear1, int iYear3)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.ImpactOnAssetViewTwo();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":YYEARONE";
        param.Value = iYear1;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":YYEARTHREE";
        param.Value = iYear3;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetImpactOnAssetThree(int iYear1, int iYear3)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.ImpactOnAssetViewThree();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":YYEARONE";
        param.Value = iYear1;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":YYEARTHREE";
        param.Value = iYear3;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetInitiativeStaffTimeUtilisation(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.InitiativeStaffTimeUtilisation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetBusinessInitiativeReportByInitiativeId(long lInitiativeId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.xReport();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lInitiativeId";
        param.Value = lInitiativeId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Initiative objGetBusinessInitiativeReportByInitiativeId(long lInitiativeId)
    {
        DataTable dt = dtGetBusinessInitiativeReportByInitiativeId(lInitiativeId);
        Initiative rptInitiative = new Initiative();
        foreach (DataRow dr in dt.Rows)
        {
            rptInitiative = new Initiative(dr);
        }
        return rptInitiative;
    }



    //*******************************                               *********************************//

    public DataTable dtGetInitiativeByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiativeByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetInitiativePendingMyApproval(int iUserId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiativePendingMyApproval();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetInitiativeIApproved(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiativeIApproved();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetInitiativeApprovedInMyFunction(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiativeApprovedInMyFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetMyApprovedNotApprovedInitiative(int iUserId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.GetMyApprovedNotApprovedInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetMyPendingInitiative(int iUserId, int iStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.GetMyPendingInitiative();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataSet dsGetInitiativeByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiativeByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.dsExecuteSelectCommand(comm);
    }

    public DataTable dtGetInitiatives()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiatives();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetAllApprovedInitiatives()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getAllApprovedInitiatives();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetAllNotApprovedInitiatives()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getAllApprovedInitiatives();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.NotApproved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetAllPendingInitiatives()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getAllPendingInitiatives();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetApprovedInitiative()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getApprovedInitiatives();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public DataTable dtGetNotApprovedInitiative()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getNotApprovedInitiatives();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":STAND";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<Initiative> lstGetInitiatives()
    {
        DataTable dt = dtGetInitiatives();

        List<Initiative> MyInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            MyInitiatives.Add(new Initiative(dr));
        }
        return MyInitiatives;
    }

    public List<Initiative> lstGetAllApprovedInitiatives()
    {
        DataTable dt = dtGetAllApprovedInitiatives();

        List<Initiative> MyInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            MyInitiatives.Add(new Initiative(dr));
        }
        return MyInitiatives;
    }

    public List<Initiative> lstGetAllPendingInitiatives()
    {
        DataTable dt = dtGetAllPendingInitiatives();

        List<Initiative> MyInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            MyInitiatives.Add(new Initiative(dr));
        }
        return MyInitiatives;
    }
    public List<Initiative> lstGetAllNotApprovedInitiatives()
    {
        DataTable dt = dtGetAllNotApprovedInitiatives();

        List<Initiative> MyInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            MyInitiatives.Add(new Initiative(dr));
        }
        return MyInitiatives;
    }

    public List<Initiative> lstGetApprovedInitiatives()
    {
        DataTable dt = dtGetApprovedInitiative();

        List<Initiative> ApprovedInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            ApprovedInitiatives.Add(new Initiative(dr));
        }
        return ApprovedInitiatives;
    }

    public List<Initiative> lstGetNotApprovedInitiatives()
    {
        DataTable dt = dtGetApprovedInitiative();

        List<Initiative> NotApprovedInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            NotApprovedInitiatives.Add(new Initiative(dr));
        }
        return NotApprovedInitiatives;
    }

    public List<Initiative> lstGetInitiativesByUserId(int iUserId)
    {
        DataTable dt = dtGetInitiativeByUserId(iUserId);

        List<Initiative> MyInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            MyInitiatives.Add(new Initiative(dr));
        }
        return MyInitiatives;
    }

    public List<Initiative> lstGetInitiativesPendingMyApproval(int iUserId, int iStatus)
    {
        DataTable dt = dtGetInitiativePendingMyApproval(iUserId, iStatus);
        List<Initiative> InitiativesPendingMyApproval = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            InitiativesPendingMyApproval.Add(new Initiative(dr));
        }
        return InitiativesPendingMyApproval;
    }

    public List<Initiative> lstGetInitiativesIApproved(int iUserId)
    {
        DataTable dt = dtGetInitiativeIApproved(iUserId);
        List<Initiative> InitiativesIApproved = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            InitiativesIApproved.Add(new Initiative(dr));
        }
        return InitiativesIApproved;
    }

    public List<Initiative> lstGetInitiativesApprovedInMyFunction(int iUserId)
    {
        DataTable dt = dtGetInitiativeApprovedInMyFunction(iUserId);
        List<Initiative> InitiativesIApproved = new List<Initiative>(dt.Rows.Count);
        InitiativesIApproved.AddRange(from DataRow dr in dt.Rows select new Initiative(dr));
        return InitiativesIApproved;
    }

    public List<Initiative> LstGetPendingInitiativesByUserId(int iUserId, int iStatus)
    {
        DataTable dt = DtGetMyPendingInitiative(iUserId, iStatus);

        List<Initiative> MyInitiatives = new List<Initiative>(dt.Rows.Count);
        MyInitiatives.AddRange(from DataRow dr in dt.Rows select new Initiative(dr));
        return MyInitiatives;
    }

    public List<Initiative> LstGetApprovedNotApprovedInitiativesByUserId(int iUserId, int iStatus)
    {
        DataTable dt = DtGetMyApprovedNotApprovedInitiative(iUserId, iStatus);

        List<Initiative> MyInitiatives = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            MyInitiatives.Add(new Initiative(dr));
        }
        return MyInitiatives;
    }

    public static Initiative objGetInitiativeById(long lInitiativeId)
    {
        DataTable dt = dtGetInitiativeById(lInitiativeId);

        Initiative xRows = new Initiative();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new Initiative(dr);
        }
        return xRows;
    }

    public DataTable dtGetBusinessInitiativeByPrefixText(string PrefixText)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getInitiativeByPrefix();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":TITLE";
        param.Value = PrefixText + "%";
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<Initiative> lstGetBusinessInitiativeByPrefixText(string PrefixText)
    {
        DataTable dt = dtGetBusinessInitiativeByPrefixText(PrefixText);

        List<Initiative> asset = new List<Initiative>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            asset.Add(new Initiative(dr));
        }
        return asset;
    }

    //public Int64 bGetMyInput(string sEmail)
    //{
    //    Int64 iManHrId = 0;

    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getMyInput();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":EMAIL";
    //    param.Value = sEmail;
    //    param.DbType = DbType.String;
    //    param.Size = 200;
    //    comm.Parameters.Add(param);

    //    DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);


    //    if (dt.Rows.Count > 0)
    //    {
    //        iManHrId = Int64.Parse(dt.Rows[0]["ID_MANH"].ToString());
    //    }

    //    return iManHrId;
    //}
}