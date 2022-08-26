using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for AssessmentQuestions
/// </summary>
public class Assessment
{
    public long lAssesstmentId { get; set; }
    public int iSustainId { get; set; }
    public int iValue { get; set; }
    public long lProjectId { get; set; }

	public Assessment()
	{
		//
		// 
		//
	}

    public Assessment(DataRow dr)
    {
        lAssesstmentId = long.Parse(dr["IDASSESSMENT"].ToString());
        iSustainId = int.Parse(dr["IDSUSTAIN"].ToString());
        iValue = int.Parse(dr["IVALUE"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
    }
}

public class CustomerAssessment
{
    public int iCustomerId { get; set; }
    public long lProjectId { get; set; }
    public string sKeyCustomers { get; set; }
    public string sReviewers { get; set; }
    public string sPositiveFindings { get; set; }
    public string sNegativeFindings { get; set; }
    public DateTime dtAssessed { get; set; }

    public CustomerAssessment()
    {
        //
        // 
        //
    }

    public CustomerAssessment(DataRow dr)
    {
        iCustomerId = int.Parse(dr["IDASSCUSTOMER"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        sKeyCustomers = dr["KEYCUSTOMERS"].ToString();
        sReviewers = dr["REVIEWERS"].ToString();
        sPositiveFindings = dr["POSITIVEFINDINGS"].ToString();
        sNegativeFindings = dr["NEGATIVEFINDINGS"].ToString();
        dtAssessed = DateTime.Parse(dr["DATE_ASSESSED"].ToString());
    }
}

public class AssessmentHelper
{
    public AssessmentHelper()
    {
        //
        // 
        //
    }

    public DataTable dtGetCategories()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getCategories();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetQuestionsByCategoryId(int iCategoryId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getQuestionsByCategoryId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iCategoryId";
        param.Value = iCategoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public bool InsertAssessmentAnswer(Assessment oAssessment)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertLeanAssessmentAnswer();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oAssessment.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSustainId";
        param.Value = oAssessment.iSustainId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iValue";
        param.Value = oAssessment.iValue;
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

    public bool UpdateAssessmentAnswer(Assessment oAssessment)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateLeanAssessmentAnswer();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oAssessment.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSustainId";
        param.Value = oAssessment.iSustainId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iValue";
        param.Value = oAssessment.iValue;
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

    public bool ProjectExistsForAssessment(long lProjectId)
    {
        bool bRet = false;
        if (dtGetAssessmentAnswersByProjectId(lProjectId).Rows.Count > 0)
        {
            bRet = true;
        }

        return bRet;
    }

    public DataTable dtGetAssessmentAnswersByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanAssessmentAnswersByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDashBoardAssessmentByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectAssessmentYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public DataTable dtGetCustomerAssessmentByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanCustomerAssessmentByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<Assessment> lstAssessmentAsnwers(long lProjectId)
    {
        DataTable dt = dtGetAssessmentAnswersByProjectId(lProjectId);

        List<Assessment> oAssessment = new List<Assessment>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oAssessment.Add(new Assessment(dr));
        }
        return oAssessment;
    }

    public CustomerAssessment objGetCustomerAssessment(long lProjectId)
    {
        DataTable dt = dtGetCustomerAssessmentByProjectId(lProjectId);

        CustomerAssessment oAssessment = new CustomerAssessment();
        foreach (DataRow dr in dt.Rows)
        {
            oAssessment= new CustomerAssessment(dr);
        }
        return oAssessment;
    }

    public bool InsertAssessmentReviewers(CustomerAssessment oCustomerAssessment)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertLeanAssessmentReviewers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oCustomerAssessment.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sKeyCustomers";
        param.Value = oCustomerAssessment.sKeyCustomers;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":sReviewers";
        param.Value = oCustomerAssessment.sReviewers;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNegativeFindings";
        param.Value = oCustomerAssessment.sNegativeFindings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPositiveFindings";
        param.Value = oCustomerAssessment.sPositiveFindings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtAssessed";
        param.Value = oCustomerAssessment.dtAssessed;
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
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);

    }

    public bool UpdateAssessmentReviewers(CustomerAssessment oCustomerAssessment)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateLeanAssessmentAnswer();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oCustomerAssessment.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sKeyCustomers";
        param.Value = oCustomerAssessment.sKeyCustomers;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sReviewers";
        param.Value = oCustomerAssessment.sReviewers;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNegativeFindings";
        param.Value = oCustomerAssessment.sNegativeFindings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPositiveFindings";
        param.Value = oCustomerAssessment.sPositiveFindings;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtAssessed";
        param.Value = oCustomerAssessment.dtAssessed;
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
            //MessageBox.Show(ex.Message.ToString());
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);

    }
}