using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for RequiredEvidence
/// </summary>

public class RequiredEvidence
{
    public int iAssessmentId { get; set; }
    public int iEvidenceId { get; set; }
    public string sEvidence { get; set; }

    public RequiredEvidence()
    {

    }

    public RequiredEvidence(DataRow dr)
    {
        iAssessmentId = int.Parse(dr["ASSESSMENTID"].ToString());
        iEvidenceId = int.Parse(dr["EVIDENCEID"].ToString());
        sEvidence = dr["EVIDENCE"].ToString();
    }

    public DataTable DtGetRequiredEvidence()
    {
        string sql = "SELECT ASSESSMENTID, EVIDENCEID, EVIDENCE FROM ASSESSMENT_EVIDENCE";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable DtGetRequiredEvidenceByAssessmentId(int iAssessmentId)
    {
        string sql = "SELECT ASSESSMENTID, EVIDENCEID, EVIDENCE FROM ASSESSMENT_EVIDENCE WHERE ASSESSMENTID = :iAssessmentId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iAssessmentId";
        param.Value = iAssessmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public bool CreateRequiredEvidence(RequiredEvidence oRequiredEvidence)
    {

        return true;
    }

    public bool UpdateRequiredEvidence(RequiredEvidence oRequiredEvidence)
    {

        return true;
    }

    public bool DeleteRequiredEvidence(RequiredEvidence oRequiredEvidence)
    {

        return true;
    }

    public List<RequiredEvidence> LstRequiredEvidenceByAssessment(int iAssessmentId)
    {
        var dt = DtGetRequiredEvidenceByAssessmentId(iAssessmentId);

        var lstRequiredEvidence = new List<RequiredEvidence>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstRequiredEvidence.Add(new RequiredEvidence(dr));
        }
        return lstRequiredEvidence;
    }
}