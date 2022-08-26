using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Training
/// </summary>

public class Training
{
    public long lTrainingId { get; set; }
    public int iYear { get; set; }
    public int iTrainingType { get; set; }
    public int iDept { get; set; }
    public int iFunction { get; set; }
    public int iUserId { get; set; }
    public string sTrainers { get; set; }

    public Training()
    {
        //
        // 
        //
    }

    public Training(DataRow dr)
    {
        lTrainingId = long.Parse(dr["IDTRAINING"].ToString());
        iYear = int.Parse(dr["YYEAR"].ToString());
        iTrainingType = int.Parse(dr["IDTRAINTYPE"].ToString());
        iDept = int.Parse(dr["IDDEPARTMENT"].ToString());
        iFunction = int.Parse(dr["FUNCTIONID"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
        sTrainers = dr["TRAINERS"].ToString();
    }
}

public class TrainingHelper
{
    public TrainingHelper()
    {
        //
        // 
        //
    }

    public bool InsertPersonTrained(Training oTraining)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.AddPersonTrained();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oTraining.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDept";
        param.Value = oTraining.iDept;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunction";
        param.Value = oTraining.iFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTrainingType";
        param.Value = oTraining.iTrainingType;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oTraining.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTrainers";
        param.Value = oTraining.sTrainers;
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

    public bool UpdatePersonTrained(Training oTraining)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdatePersonTrained();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lTrainingId";
        param.Value = oTraining.lTrainingId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oTraining.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDept";
        param.Value = oTraining.iDept;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunction";
        param.Value = oTraining.iFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTrainingType";
        param.Value = oTraining.iTrainingType;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oTraining.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTrainers";
        param.Value = oTraining.sTrainers;
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

    public DataTable dtGetPersonsTrainedByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getPersonsTrainedByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPersonsTrainedById(long lTrainingId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getPersonsTrainedById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lTrainingId";
        param.Value = lTrainingId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetPersonsTrainedByTrainTypeIdYear(int iTrainTypeId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getPersonsTrainedByTrainingTypeIdYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iTrainTypeId";
        param.Value = iTrainTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public bool DeletePersonTrained(long lTrainingId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeletePersonsTrainedById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lTrainingId";
        param.Value = lTrainingId;
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

    public Training objGetPersonTrainedById(long lTrainingId)
    {
        DataTable dt = dtGetPersonsTrainedById(lTrainingId);

        Training xRows = new Training();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new Training(dr);
        }
        return xRows;
    }

    public int NoOfPeopleTrainedByTrainingTypeYear(int iTrainTypeId, int iYear)
    {
        DataTable dt = dtGetPersonsTrainedByTrainTypeIdYear(iTrainTypeId, iYear);
        int iNoOfPeopleTrained = int.Parse(dt.Rows[0]["TRAINED"].ToString());

        return iNoOfPeopleTrained;
    }

}


public class TrainingType
{
    public int iTypeId { get; set; }
    public string sType { get; set; }

    public TrainingType()
    {
        //
        // 
        //
    }

    public TrainingType(DataRow dr)
    {
        iTypeId = int.Parse(dr["IDTYPE"].ToString());
        sType = dr["TYPE"].ToString();
    }
}

public class TrainingTypeHelper
{
    public TrainingTypeHelper()
    {
        //
        // 
        //
    }

    public bool InsertTrainingType(TrainingType oTrainingType)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.AddPersonTrained();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":iUserId";
        //param.Value = oTraining.iUserId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iDept";
        //param.Value = oTraining.iDept;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iFunction";
        //param.Value = oTraining.iFunction;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iTrainingType";
        //param.Value = oTraining.iTrainingType;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iYear";
        //param.Value = oTraining.iYear;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sTrainers";
        //param.Value = oTraining.sTrainers;
        //param.DbType = DbType.String;
        //param.Size = 2000;
        //comm.Parameters.Add(param);

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

    public bool UpdateTrainingType(TrainingType oTrainingType)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdatePersonTrained();

        //OracleParameter param = comm.CreateParameter();
        //param.ParameterName = ":lTrainingId";
        //param.Value = oTraining.lTrainingId;
        //param.DbType = DbType.Int64;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iUserId";
        //param.Value = oTraining.iUserId;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iDept";
        //param.Value = oTraining.iDept;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iFunction";
        //param.Value = oTraining.iFunction;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iTrainingType";
        //param.Value = oTraining.iTrainingType;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iYear";
        //param.Value = oTraining.iYear;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sTrainers";
        //param.Value = oTraining.sTrainers;
        //param.DbType = DbType.String;
        //param.Size = 2000;
        //comm.Parameters.Add(param);

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

    public DataTable dtGetTrainingType()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getTrainingType();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<TrainingType> lstTrainingTypes()
    {
        DataTable dt = dtGetTrainingType();

        List<TrainingType> oTrainingType = new List<TrainingType>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oTrainingType.Add(new TrainingType(dr));
        }
        return oTrainingType;

    }
}

