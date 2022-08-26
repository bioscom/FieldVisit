using System;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for KnowledgeSkill
/// </summary>

public class KnowledgeSkillManager
{
    public int lAssessmentId { get; set; }
    public long lSheetId { get; set; }
    public long lAssessId { get; set; }
    public int iAchieved { get; set; }
    public DateTime dDateAchieved { get; set; }
    public int iProficiencyId { get; set; }
    public string sLevel { get; set; }
    public string sCriteria { get; set; }
    public string sEvidence { get; set; }
    public string sComments { get; set; }

    public KnowledgeSkillManager()
    {
        
    }

    public KnowledgeSkillManager(DataRow dr)
    {
        lAssessmentId = int.Parse(dr["ASSESSMENTID"].ToString());
        lSheetId = long.Parse(dr["SHEETID"].ToString());
        lAssessId = long.Parse(dr["ASSESSID"].ToString());
        iAchieved = int.Parse(dr["ACHIEVED"].ToString());
        dDateAchieved = DateTime.Parse(dr["DATE_ACHIEVED"].ToString());
        iProficiencyId = int.Parse(dr["PROFICIENCYID"].ToString());
        sLevel = dr["SLEVEL"].ToString();
        sCriteria = dr["CRITERIA"].ToString();
        sEvidence = dr["EVIDENCE"].ToString();
        sComments = dr["COMMENTS"].ToString();
    }

    //public DataTable DtGetNewAssessmentSheetByProficiency(int iProficiency)
    //{
    //    var sql = "SELECT ASSESSMENT_KS.ASSESSMENTID,  ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ";
    //    sql += "ASSESSMENT_PROFICIENCY.PROFICIENCYID FROM ASSESSMENT_KS ";
    //    sql += "INNER JOIN ASSESSMENT_PROFICIENCY ON ASSESSMENT_KS.PROFICIENCYID = ASSESSMENT_PROFICIENCY.PROFICIENCYID ";
    //    sql += "WHERE ASSESSMENT_PROFICIENCY.PROFICIENCYID = :iProficiency ORDER BY ASSESSMENT_KS.SLEVEL";

    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = sql;

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iProficiency";
    //    param.Value = iProficiency;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    public DataTable DtGetAssessmentSheetByProficiencyCompetence(int iProficiency, int iCompetenceId)
    {
        var sql = "SELECT ASSESSMENT_KS.ASSESSMENTID, ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ASSESSMENT_PROFICIENCY.PROFICIENCYID, ";
        sql += "ASSESSMENT_PROFICIENCY.PROFICIENCY, ASSESSMENT_COMPETENCE.COMPETENCE FROM ASSESSMENT_KS ";
        sql += "INNER JOIN ASSESSMENT_PROFICIENCY ON ASSESSMENT_KS.PROFICIENCYID = ASSESSMENT_PROFICIENCY.PROFICIENCYID ";
        sql += "INNER JOIN ASSESSMENT_COMPETENCE ON ASSESSMENT_KS.COMPETENCEID = ASSESSMENT_COMPETENCE.COMPETENCEID ";
        sql += "WHERE ASSESSMENT_PROFICIENCY.PROFICIENCYID = :iProficiency AND ASSESSMENT_COMPETENCE.COMPETENCEID = :iCompetenceId ";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iProficiency";
        param.Value = iProficiency;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCompetenceId";
        param.Value = iCompetenceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetAssessmentSheetByProficiencyCompetenceEdt(int iProficiency, int iAssesseId)
    {
        var sql = "SELECT ASSESSMENT_KS.ASSESSMENTID, ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ASSESMENT_SHEET.SHEETID, ";
        sql += "ASSESMENT_SHEET.ASSESSID, ASSESMENT_SHEET.COMMENTS, ASSESMENT_SHEET.ACHIEVED, ASSESMENT_SHEET.DATE_ACHIEVED, ";
        sql += "ASSESSMENT_PROFICIENCY.PROFICIENCYID FROM ASSESMENT_SHEET ";
        sql += "LEFT OUTER JOIN ASSESSMENT_HEADER ON ASSESSMENT_HEADER.ASSESSID = ASSESMENT_SHEET.ASSESSID ";
        sql += "RIGHT OUTER JOIN ASSESSMENT_KS ON ASSESSMENT_KS.ASSESSMENTID = ASSESMENT_SHEET.ASSESSMENTID ";
        sql += "INNER JOIN ASSESSMENT_PROFICIENCY ON ASSESSMENT_KS.PROFICIENCYID = ASSESSMENT_PROFICIENCY.PROFICIENCYID ";
        sql += "WHERE ASSESSMENT_PROFICIENCY.PROFICIENCYID = :iProficiency AND ASSESSMENT_HEADER.ASSESSEEID = :iAssesseId";  //ORDER BY ASSESSMENT_KS.SLEVEL

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iProficiency";
        param.Value = iProficiency;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssesseId";
        param.Value = iAssesseId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetAssessmentSheetByProficiency(int iProficiency)
    {
        var sql = "SELECT ASSESSMENT_KS.ASSESSMENTID, ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ASSESMENT_SHEET.SHEETID, ";
        sql += "ASSESMENT_SHEET.ASSESSID, ASSESMENT_SHEET.COMMENTS, ASSESMENT_SHEET.ACHIEVED, ASSESMENT_SHEET.DATE_ACHIEVED, ";
        sql += "ASSESSMENT_PROFICIENCY.PROFICIENCYID FROM ASSESMENT_SHEET ";
        sql += "INNER JOIN ASSESSMENT_HEADER ON ASSESSMENT_HEADER.ASSESSID = ASSESMENT_SHEET.ASSESSID ";
        sql += "INNER JOIN ASSESSMENT_KS ON ASSESSMENT_KS.ASSESSMENTID = ASSESMENT_SHEET.ASSESSMENTID ";
        sql += "INNER JOIN ASSESSMENT_PROFICIENCY ON ASSESSMENT_KS.PROFICIENCYID = ASSESSMENT_PROFICIENCY.PROFICIENCYID ";
        sql += "WHERE ASSESSMENT_PROFICIENCY.PROFICIENCYID = :iProficiency"; //AND ASSESSMENT_HEADER.ASSESSEEID = :iAssesseId"; ORDER BY ASSESSMENT_KS.SLEVEL

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iProficiency";
        param.Value = iProficiency;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iAssesseId";
        //param.Value = iAssesseId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<KnowledgeSkillManager> LstGetAssessmentSheetByProficiency(int iProficiency)
    {
        var dt = DtGetAssessmentSheetByProficiency(iProficiency);

        var o = new List<KnowledgeSkillManager>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new KnowledgeSkillManager(dr));
        }
        return o;
    }

    public DataTable DtLoadAssessmentRegister()
    {
        var sql = "SELECT ASSESSMENT_GROUPS.GROUPS, ASSESSMENT_COMPETENCE.COMPETENCE, ASSESSMENT_PROFICIENCY.PROFICIENCY, ASSESSMENT_HEADER.ASSESSID, ";
        sql += "ASSESSMENT_HEADER.DATE_ASSESSED, ASSESSMENT_HEADER.STATUS, ASSESSEE.FULLNAME AS ASSESSEENAME, ASSESSOR.FULLNAME AS ASSESSORNAME ";
        sql += "FROM ASSESSMENT_HEADER ";
        sql += "INNER JOIN ASSESSMENT_COMPETENCE ON ASSESSMENT_COMPETENCE.COMPETENCEID = ASSESSMENT_HEADER.COMPETENCEID ";
        sql += "INNER JOIN ASSESSMENT_PROFICIENCY ON ASSESSMENT_PROFICIENCY.PROFICIENCYID = ASSESSMENT_HEADER.PROFICIENCYID ";
        sql += "INNER JOIN ASSESSMENT_GROUPS ON ASSESSMENT_GROUPS.GROUPID = ASSESSMENT_COMPETENCE.GROUPID ";
        sql += "INNER JOIN PROD_USERMGT ASSESSEE ON ASSESSEE.USERID = ASSESSMENT_HEADER.ASSESSEEID ";
        sql += "INNER JOIN PROD_USERMGT ASSESSOR ON ASSESSOR.USERID = ASSESSMENT_HEADER.ASSESSORID ";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtLoadMyAssessments(int iUserId)
    {
        var sql = "SELECT ASSESSMENT_GROUPS.GROUPS, ASSESSMENT_COMPETENCE.COMPETENCE, ASSESSMENT_PROFICIENCY.PROFICIENCY, ASSESSMENT_HEADER.ASSESSID, ";
        sql += "ASSESSMENT_HEADER.DATE_ASSESSED, ASSESSMENT_HEADER.STATUS, ASSESSEE.FULLNAME AS ASSESSEENAME, ASSESSOR.FULLNAME AS ASSESSORNAME ";
        sql += "FROM ASSESSMENT_HEADER ";
        sql += "INNER JOIN ASSESSMENT_COMPETENCE ON ASSESSMENT_COMPETENCE.COMPETENCEID = ASSESSMENT_HEADER.COMPETENCEID ";
        sql += "INNER JOIN ASSESSMENT_PROFICIENCY ON ASSESSMENT_PROFICIENCY.PROFICIENCYID = ASSESSMENT_HEADER.PROFICIENCYID ";
        sql += "INNER JOIN ASSESSMENT_GROUPS ON ASSESSMENT_GROUPS.GROUPID = ASSESSMENT_COMPETENCE.GROUPID ";
        sql += "INNER JOIN PROD_USERMGT ASSESSEE ON ASSESSEE.USERID = ASSESSMENT_HEADER.ASSESSEEID ";
        sql += "INNER JOIN PROD_USERMGT ASSESSOR ON ASSESSOR.USERID = ASSESSMENT_HEADER.ASSESSORID ";
        sql += "WHERE ASSESSOR.USERID = :iUserId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetKnowledgeSkillByCompetenceProficiency(int iCompetencyId, int iProficiencyId)
    {
        var sql = "SELECT ASSESSMENT_KS.ASSESSMENTID, ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ";
        sql += "ASSESSMENT_KS.COMPETENCEID, ASSESSMENT_KS.PROFICIENCYID FROM ASSESSMENT_PROFICIENCY ";
        sql += "INNER JOIN ASSESSMENT_KS ON ASSESSMENT_PROFICIENCY.PROFICIENCYID = ASSESSMENT_KS.PROFICIENCYID ";
        sql += "WHERE ASSESSMENT_KS.COMPETENCEID = :iCompetencyId AND ASSESSMENT_KS.PROFICIENCYID = :iProficiencyId ";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iCompetencyId";
        param.Value = iCompetencyId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iProficiencyId";
        param.Value = iProficiencyId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    #region ================================= Assessor Matrix ============================

    public DataTable DtGetCompetenceGroup()
    {
        var sql = "SELECT ASSESSMENT_GROUPS.GROUPID, ASSESSMENT_GROUPS.GROUPS, ASSESSMENT_COMPETENCE.COMPETENCEID, ";
        sql += "ASSESSMENT_COMPETENCE.COMPETENCE, ASSESSMENT_COMPETENCE.LOCATION ";
        sql += "FROM ASSESSMENT_GROUPS ";
        sql += "INNER JOIN ASSESSMENT_COMPETENCE ON ASSESSMENT_GROUPS.GROUPID = ASSESSMENT_COMPETENCE.GROUPID ORDER BY ASSESSMENT_GROUPS.GROUPS";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    #endregion
}

public class KnowledgeSkillAssessorAssesseInfo
{
    public long lAssessId { get; set; }
    public int iAssesseeId { get; set; }
    public int iAssessorId { get; set; }
    public DateTime dDateAssessed { get; set; }
    public int iStatus { get; set; }
    public int iCompetenceId { get; set; }
    public int iProficiencyId { get; set; }

    //public Competencies oCompetencies { get; set; }
    //public Proficiency oProficiency { get; set; }


    public KnowledgeSkillAssessorAssesseInfo()
    {

    }

    public KnowledgeSkillAssessorAssesseInfo(DataRow dr)
    {
        lAssessId = long.Parse(dr["ASSESSID"].ToString());
        iAssesseeId = int.Parse(dr["ASSESSEEID"].ToString());
        iAssessorId = int.Parse(dr["ASSESSORID"].ToString());
        dDateAssessed = DateTime.Parse(dr["DATE_ASSESSED"].ToString());
        iStatus = int.Parse(dr["STATUS"].ToString());
        iCompetenceId = int.Parse(dr["COMPETENCEID"].ToString());
        iProficiencyId = int.Parse(dr["PROFICIENCYID"].ToString());
    }

    public bool AddAssessorAssesseInfo(KnowledgeSkillAssessorAssesseInfo oKnowledgeSkillAssessorAssesseInfo, ref long lAssessId)
    {
        var sql = "INSERT INTO ASSESSMENT_HEADER (ASSESSID, ASSESSEEID, ASSESSORID, DATE_ASSESSED, STATUS, COMPETENCEID, PROFICIENCYID) ";
        sql += "VALUES (:lAssessId, :iAssesseeId, :iAssessorId, :dDateAssessed, :iStatus, :iCompetenceId, :iProficiencyId)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        lAssessId = GetAssessID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lAssessId";
        param.Value = lAssessId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssesseeId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iAssesseeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssessorId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iAssessorId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateAssessed";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.dDateAssessed;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCompetenceId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iCompetenceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iProficiencyId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iProficiencyId;
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
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateAssessorAssesseInfo(KnowledgeSkillAssessorAssesseInfo oKnowledgeSkillAssessorAssesseInfo)
    {
        var sql = "UPDATE ASSESSMENT_HEADER SET ASSESSEEID = :iAssesseeId, ASSESSORID = :iAssessorId, COMPETENCEID = :iCompetenceId, ";
        sql += "PROFICIENCYID = :iProficiencyId WHERE ASSESSID = :lAssessId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lAssessId";
        param.Value = lAssessId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssesseeId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iAssesseeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssessorId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iAssessorId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCompetenceId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iCompetenceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iProficiencyId";
        param.Value = oKnowledgeSkillAssessorAssesseInfo.iProficiencyId;
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
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    private long GetAssessID()
    {
        long lRequestId = 0;
        try
        {
            DataTable dt = DtGetAssessId();
            lRequestId = long.Parse(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return lRequestId;
    }

    private static DataTable DtGetAssessId()
    {
        string sql = "SELECT ASSESSMENT_HEADER_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable DtGetAssessmentHeaderByAssessId(long lAssessId)
    {
        var sql = "SELECT ASSESSMENT_HEADER.ASSESSID, ASSESSMENT_HEADER.ASSESSEEID, ASSESSMENT_HEADER.ASSESSORID, ";
        sql += "ASSESSMENT_HEADER.DATE_ASSESSED, ASSESSMENT_HEADER.STATUS, ASSESSMENT_HEADER.COMPETENCEID, ASSESSMENT_HEADER.PROFICIENCYID ";
        sql += "FROM ASSESSMENT_HEADER WHERE ASSESSMENT_HEADER.ASSESSID = :lAssessId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lAssessId";
        param.Value = lAssessId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public KnowledgeSkillAssessorAssesseInfo ObjGetAssessmentHeaderByAssessId(long lAssessId)
    {
        DataTable dt = DtGetAssessmentHeaderByAssessId(lAssessId);

        KnowledgeSkillAssessorAssesseInfo oSkillAssessor = new KnowledgeSkillAssessorAssesseInfo();
        foreach (DataRow dr in dt.Rows)
        {
            oSkillAssessor = new KnowledgeSkillAssessorAssesseInfo(dr);
        }
        return oSkillAssessor;
    }


    //public Initiative objGetBusinessInitiativeReportByInitiativeId(long lInitiativeId)
    //{
    //    DataTable dt = dtGetBusinessInitiativeReportByInitiativeId(lInitiativeId);
    //    Initiative rptInitiative = new Initiative();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        rptInitiative = new Initiative(dr);
    //    }
    //    return rptInitiative;
    //}

}

public class KnowledgeSkillSheet
{
    public long lSheetId { get; set; }
    public long lAssessId { get; set; }
    public long lAssessmentId { get; set; }
    public string sComments { get; set; }
    public int iAchieved { get; set; }
    public DateTime dDateAchieved { get; set; }

    public KnowledgeSkillSheet()
    {

    }

    public KnowledgeSkillSheet(DataRow dr)
    {
        lSheetId = long.Parse(dr["SHEETID"].ToString());
        lAssessId = long.Parse(dr["ASSESSID"].ToString());
        lAssessmentId = long.Parse(dr["ASSESSMENTID"].ToString());
        sComments = dr["COMMENTS"].ToString();
        iAchieved = int.Parse(dr["ACHIEVED"].ToString());
        dDateAchieved = DateTime.Parse(dr["DATE_ACHIEVED"].ToString());
    }

    public bool AddAssessmentScore(KnowledgeSkillSheet oKnowledgeSkillSheet, ref long lSheetId)
    {
        var sql = "INSERT INTO ASSESMENT_SHEET (SHEETID, ASSESSID, ASSESSMENTID, COMMENTS, ACHIEVED, DATE_ACHIEVED) ";
        sql += "VALUES (:lSheetId, :lAssessId, :lAssessmentId, :sComments, :iAchieved, :dDateAchieved)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        lSheetId = GetSheetID();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lSheetId";
        param.Value = lSheetId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lAssessId";
        param.Value = oKnowledgeSkillSheet.lAssessId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lAssessmentId";
        param.Value = oKnowledgeSkillSheet.lAssessmentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oKnowledgeSkillSheet.sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAchieved";
        param.Value = oKnowledgeSkillSheet.iAchieved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateAchieved";
        param.Value = oKnowledgeSkillSheet.dDateAchieved;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateAssessmentScore(KnowledgeSkillSheet oKnowledgeSkillSheet)
    {
        var sql = "UPDATE ASSESMENT_SHEET SET ASSESSID = :lAssessId, ASSESSMENTID = :lAssessmentId, COMMENTS = :sComments, ";
        sql += "ACHIEVED = :iAchieved, DATE_ACHIEVED = :dDateAchieved WHERE SHEETID = :lSheetId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lSheetId";
        param.Value = oKnowledgeSkillSheet.lSheetId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lAssessId";
        param.Value = oKnowledgeSkillSheet.lAssessId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lAssessmentId";
        param.Value = oKnowledgeSkillSheet.lAssessmentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oKnowledgeSkillSheet.sComments;
        param.DbType = DbType.String;
        param.Size = 4000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAchieved";
        param.Value = oKnowledgeSkillSheet.iAchieved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateAchieved";
        param.Value = oKnowledgeSkillSheet.dDateAchieved;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        int result = -1;

        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    private long GetSheetID()
    {
        long lRequestId = 0;
        try
        {
            DataTable dt = DtGetSheetId();
            lRequestId = long.Parse(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return lRequestId;
    }

    private static DataTable DtGetSheetId()
    {
        string sql = "SELECT ASSESMENT_SHEET_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}

public class KnowledgeSkillScores
{
    public long iScoreId { get; set; }
    public long iEvidenceId { get; set; }
    public long iSheetId { get; set; }
    public int iScore { get; set; }

    public KnowledgeSkillScores()
    {

    }

    public KnowledgeSkillScores(DataRow dr)
    {
        iScoreId = long.Parse(dr["SCOREID"].ToString());
        iEvidenceId = long.Parse(dr["EVIDENCEID"].ToString());
        iSheetId = long.Parse(dr["SHEETID"].ToString());
        iScore = int.Parse(dr["SCORE"].ToString());
    }

    public bool AddScore(KnowledgeSkillScores oKnowledgeSkillScores)
    {
        var sql = "INSERT INTO ASSESSMENT_EVIDENCE_SCORE (EVIDENCEID, SHEETID, SCORE) VALUES (:lEvidenceId, :lSheetId, :iScore)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lEvidenceId";
        param.Value = oKnowledgeSkillScores.iEvidenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lSheetId";
        param.Value = oKnowledgeSkillScores.iSheetId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iScore";
        param.Value = oKnowledgeSkillScores.iScore;
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
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateScore(KnowledgeSkillScores oKnowledgeSkillScores)
    {
        var sql = "UPDATE ASSESSMENT_EVIDENCE_SCORE SET SCORE = :iScore WHERE EVIDENCEID = :lEvidenceId AND SHEETID = :lSheetId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lEvidenceId";
        param.Value = oKnowledgeSkillScores.iEvidenceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lSheetId";
        param.Value = oKnowledgeSkillScores.iSheetId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iScore";
        param.Value = oKnowledgeSkillScores.iScore;
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
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }


    public static DataTable DtGetKnowledgeSkillScoresBySheetId(long lSheetId)
    {
        var sql = "SELECT ASSESSMENT_EVIDENCE_SCORE.SCOREID, ASSESSMENT_EVIDENCE_SCORE.SHEETID, ASSESSMENT_EVIDENCE_SCORE.EVIDENCEID, ";
        sql += "ASSESSMENT_EVIDENCE_SCORE.SCORE FROM ASSESSMENT_EVIDENCE_SCORE WHERE ASSESSMENT_EVIDENCE_SCORE.SHEETID = :lSheetId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lSheetId";
        param.Value = lSheetId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public KnowledgeSkillScores ObjGetKnowledgeSkillScoresBySheetId(long lSheetId)
    {
        DataTable dt = DtGetKnowledgeSkillScoresBySheetId(lSheetId);

        KnowledgeSkillScores oSkillScore = new KnowledgeSkillScores();
        foreach (DataRow dr in dt.Rows)
        {
            oSkillScore = new KnowledgeSkillScores(dr);
        }
        return oSkillScore;
    }

    public List<KnowledgeSkillScores> LstGetKnowledgeSkillScoresBySheetId(long lSheetId)
    {
        var dt = DtGetKnowledgeSkillScoresBySheetId(lSheetId);

        var o = new List<KnowledgeSkillScores>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new KnowledgeSkillScores(dr));
        }
        return o;
    }

    //public DataTable DtGetKnowledgeSkillByCompetenceProficiency(int iCompetencyId, int iProficiencyId)
    //{
    //    var sql = "SELECT ASSESSMENT_KS.ASSESSMENTID, ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ";
    //    sql += "ASSESSMENT_KS.COMPETENCEID, ASSESSMENT_KS.PROFICIENCYID FROM ASSESSMENT_PROFICIENCY ";
    //    sql += "INNER JOIN ASSESSMENT_KS ON ASSESSMENT_PROFICIENCY.PROFICIENCYID = ASSESSMENT_KS.PROFICIENCYID ";
    //    sql += "WHERE ASSESSMENT_KS.COMPETENCEID = :iCompetencyId AND ASSESSMENT_KS.PROFICIENCYID = :iProficiencyId ";

    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = sql;

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iCompetencyId";
    //    param.Value = iCompetencyId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    param = comm.CreateParameter();
    //    param.ParameterName = ":iProficiencyId";
    //    param.Value = iProficiencyId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}


}

public class AssessmentReport
{
    public AssessmentReport()
    {

    }

    public static string ReportMasterQuery()
    {
        var sql = "SELECT ASSESSMENT_KS.ASSESSMENTID, ASSESSMENT_KS.SLEVEL, ASSESSMENT_KS.CRITERIA, ASSESSMENT_KS.EVIDENCE, ASSESMENT_SHEET.SHEETID, ";
        sql += "ASSESMENT_SHEET.ASSESSID, ASSESMENT_SHEET.COMMENTS, ASSESMENT_SHEET.ACHIEVED, ASSESMENT_SHEET.DATE_ACHIEVED, ASSESSMENT_COMPETENCE.COMPETENCE, ";
        sql += "ASSESSMENT_PROFICIENCY.PROFICIENCY, ASSESSOR.FULLNAME AS ASSESSORNAME, ASSESSOR.EMAIL AS ASSESSOREMAIL, ASSESSMENT_HEADER.ASSESSORID, ";
        sql += "ASSESSMENT_HEADER.ASSESSEEID, ASSESSEE.FULLNAME AS ASSESSEENAME, ASSESSEE.EMAIL AS ASSESSEEEMAIL, ASSESSMENT_HEADER.DATE_ASSESSED, ";
        sql += "ASSESSMENT_HEADER.STATUS ";
        sql += "FROM ASSESMENT_SHEET ";
        sql += "LEFT OUTER JOIN ASSESSMENT_HEADER ON ASSESSMENT_HEADER.ASSESSID = ASSESMENT_SHEET.ASSESSID ";
        sql += "RIGHT OUTER JOIN ASSESSMENT_KS ON ASSESSMENT_KS.ASSESSMENTID = ASSESMENT_SHEET.ASSESSMENTID ";
        sql += "INNER JOIN ASSESSMENT_COMPETENCE ON ASSESSMENT_HEADER.COMPETENCEID = ASSESSMENT_COMPETENCE.COMPETENCEID ";
        sql += "INNER JOIN ASSESSMENT_PROFICIENCY ON ASSESSMENT_HEADER.PROFICIENCYID = ASSESSMENT_PROFICIENCY.PROFICIENCYID ";
        sql += "INNER JOIN PROD_USERMGT ASSESSOR ON ASSESSMENT_HEADER.ASSESSORID = ASSESSOR.USERID ";
        sql += "INNER JOIN PROD_USERMGT ASSESSEE ON ASSESSMENT_HEADER.ASSESSEEID = ASSESSEE.USERID ";

        return sql;
    }
}