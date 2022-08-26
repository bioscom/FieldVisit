using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Questionaire
/// </summary>
public class Questionaire
{
    public int questionId { get; set; }
    public int sequencial { get; set; }
    public string question { get; set; }
    public string description { get; set; }

	public Questionaire()
	{
		
	}

    public Questionaire(DataRow dr)
    {
        questionId = int.Parse(dr["ID_QUESTION"].ToString());
        sequencial = int.Parse(dr["SEQUENCIAL"].ToString()); ;
        question = dr["QUESTION"].ToString();
        description = dr["DESCRIPTION"].ToString();
    }

    public static bool insertQuestion(int iSequence, string sQuestion, string sDescription)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertQuestion();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":SEQUENCIAL";
        param.Value = iSequence;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":QUESTION";
        param.Value = sQuestion;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DESCRIPTION";
        param.Value = sDescription;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return (result != -1);
    }

    public static bool updateQuestion(int iQuestionId, string sQuestion, string sDescription)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateQuestion();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_QUESTION";
        param.Value = iQuestionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":QUESTION";
        param.Value = sQuestion;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DESCRIPTION";
        param.Value = sDescription;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return (result != -1);
    }

    public static DataTable dtGetQuestionaire()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getQuestionaire();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetQuestionaireById(int iQuestionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getQuestionaireById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_QUESTION";
        param.Value = iQuestionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static Questionaire objGetQuestionaireById(int iQuestionId)
    {
        DataTable dt = dtGetQuestionaireById(iQuestionId);

        Questionaire question = new Questionaire();
        foreach (DataRow dr in dt.Rows)
        {
            question = new Questionaire(dr);
        }
        return question;
    }

    public static List<Questionaire> lstGetQuestionaire()
    {
        DataTable dt = dtGetQuestionaire();

        List<Questionaire> questions = new List<Questionaire>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            questions.Add(new Questionaire(dr));
        }
        return questions;
    }
}
