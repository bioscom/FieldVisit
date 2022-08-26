using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for MainProjectHelper
/// </summary>
public class MainProjectHelper
{
    MainProjects oMainProject = new MainProjects();
    IdentifyHelper oIdentifyHelper = new IdentifyHelper();
    EliminateHelper oEliminateHelper = new EliminateHelper();
    SustainHelper oSustainHelper = new SustainHelper();

	public MainProjectHelper()
	{
		//
		// 
		//
	}
    public bool DeleteProject(long lProjectId, string sql)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
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


    //Selecting all projects
    public DataTable dtGetLeanProjects()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanProjects();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetLeanProjectsByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanProjectsByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetLeanProjectsByFunction(int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanProjectsByFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetLeanProjectsByFunctionYear(int iFunctionId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanProjectsByFunctionYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    //Selecting Projects that belong to a particular user or he/she is assigned to play a role
    public DataTable dtGetMyProjects(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getMyLeanProjects();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iChampionId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCoachId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPointId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMyProjectsByYear(int iUserId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getMyLeanProjectByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iChampionId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCoachId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPointId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMyProjectsByFunction(int iUserId, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getMyLeanProjectByFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iChampionId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCoachId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPointId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMyProjectsByYearFunction(int iUserId, int iYear, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getMyLeanProjectByYearFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iChampionId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCoachId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPointId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    //Selecting Projects for Dashboard Display
    public DataTable dtGetAllLeanProjectDashBoard()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getDashBoardData();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetLeanProjectDashBoardByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getDashBoardDataByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetLeanProjectDashBoardByFunction(int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getDashBoardDataByFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetLeanProjectDashBoardByYearFunction(int iYear, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getDashBoardDataByYearFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    //Insert, Update and Delete Projects
    public bool AddLeanProject(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertLeanProject();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = oMainProject.sTitle;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oMainProject.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iType";
        param.Value = oMainProject.iType;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDept";
        param.Value = oMainProject.iDept;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunction";
        param.Value = oMainProject.iFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = oMainProject.iSponsor;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iChampion";
        param.Value = oMainProject.iChampion;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPoint";
        param.Value = oMainProject.iFocalPointId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iManager";
        param.Value = oMainProject.iManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iCoach";
        //param.Value = oMainProject.iCoach;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunity";
        param.Value = oMainProject.sOpportunity;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBusinessCase";
        param.Value = oMainProject.sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sGoals";
        param.Value = oMainProject.sGoals;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sInScope";
        param.Value = oMainProject.sInScope;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOutScope";
        param.Value = oMainProject.sOutScope;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPotentialBlokers";
        param.Value = oMainProject.sPotentialBlokers;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oMainProject.sComments;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostReduction";
        param.Value = oMainProject.sCostReduction;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCTReduction";
        param.Value = oMainProject.sCTReduction;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProductionBarrel";
        param.Value = oMainProject.sProductionBarrel;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNumber";
        param.Value = oMainProject.sNumber;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBenefits";
        param.Value = oMainProject.sBenefits;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPotentialBenftComments";
        param.Value = oMainProject.sPotentialBenftComments;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sIdentifySD";
        param.Value = oMainProject.dtIdentifySD;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sIdentifyED";
        param.Value = oMainProject.dtIdentifyED;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEliminateSD";
        param.Value = oMainProject.dtEliminateSD;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEliminateED";
        param.Value = oMainProject.dtEliminateED;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSustainSD";
        param.Value = oMainProject.dtSustainSD;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSustainED";
        param.Value = oMainProject.dtSustainED;
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

    public bool UpdateLeanProject(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateLeanProject();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = oMainProject.sTitle;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oMainProject.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iType";
        param.Value = oMainProject.iType;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDept";
        param.Value = oMainProject.iDept;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunction";
        param.Value = oMainProject.iFunction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsor";
        param.Value = oMainProject.iSponsor;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iChampion";
        param.Value = oMainProject.iChampion;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iManager";
        param.Value = oMainProject.iManager;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iCoach";
        //param.Value = oMainProject.iCoach;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOpportunity";
        param.Value = oMainProject.sOpportunity;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBusinessCase";
        param.Value = oMainProject.sBusinessCase;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sGoals";
        param.Value = oMainProject.sGoals;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sInScope";
        param.Value = oMainProject.sInScope;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOutScope";
        param.Value = oMainProject.sOutScope;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPotentialBlokers";
        param.Value = oMainProject.sPotentialBlokers;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oMainProject.sComments;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        //Potential Benefits

        param = comm.CreateParameter();
        param.ParameterName = ":sCostReduction";
        param.Value = oMainProject.sCostReduction;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCTReduction";
        param.Value = oMainProject.sCTReduction;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProductionBarrel";
        param.Value = oMainProject.sProductionBarrel;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sNumber";
        param.Value = oMainProject.sNumber;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sBenefits";
        param.Value = oMainProject.sBenefits;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPotentialBenftComments";
        param.Value = oMainProject.sPotentialBenftComments;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sIdentifySD";
        param.Value = oMainProject.dtIdentifySD;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sIdentifyED";
        param.Value = oMainProject.dtIdentifyED;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEliminateSD";
        param.Value = oMainProject.dtEliminateSD;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sEliminateED";
        param.Value = oMainProject.dtEliminateED;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSustainSD";
        param.Value = oMainProject.dtSustainSD;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSustainED";
        param.Value = oMainProject.dtSustainED;
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



    #region //*****************************  To delete a project

    public bool DeleteProjectBenefit(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteBenefits;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
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

    public bool DeleteProjectEliminate(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteEliminate;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
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

    public bool DeleteProjectIdentify(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteIdentify;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
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

    public bool DeleteProjectImprovementRecommendation(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteImprvRec;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
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

    public bool DeleteProjectSustain(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteSustain;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
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

    public bool DeleteProjectVSM(MainProjects oMainProject)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteVsmAsIs;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
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

    public bool DeleteProject(MainProjects oMainProject)
    {
        //To Delete a Project, you must Delete the followings:
        //All ASIS entries.
        //All Identify, Eliminate and Sustain entries.
        //All Project Recommendations.
        //All Project Benefits

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteLeanProject();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oMainProject.lProjectId;
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

    #endregion


    public DataTable dtGetYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanProjectsYear();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<int> lstYears()
    {
        DataTable dt = dtGetYear();
        List<int> oYears = new List<int>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oYears.Add(int.Parse(dr["YYEAR"].ToString()));
        }

        return oYears;
    }

    public List<int> lstYearsExt()
    {
        int iYear = 0;
        DataTable dt = dtGetYear();
        List<int> oYears = new List<int>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            iYear = int.Parse(dr["YYEAR"].ToString());
            oYears.Add(iYear);
        }

        oYears.Add(iYear += 1);
        oYears.Add(iYear += 1);
        oYears.Add(iYear += 1);
        oYears.Add(iYear += 1);

        return oYears;
    }

    public List<MainProjects> lstGetLeanProjectsByYear(int iYear)
    {
        DataTable dt = dtGetLeanProjectsByYear(iYear);

        List<MainProjects> oProjects = new List<MainProjects>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oProjects.Add(new MainProjects(dr));
        }
        return oProjects;
    }

    public DataTable dtGetLeanProjectByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getLeanProjectByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public MainProjects objGetLeanProjectsByProjectId(long lProjectId)
    {
        DataTable dt = dtGetLeanProjectByProjectId(lProjectId);

        MainProjects oMainProjects = new MainProjects();
        foreach (DataRow dr in dt.Rows)
        {
            oMainProjects = new MainProjects(dr);
        }
        return oMainProjects;
    }

    public void LoadProjectsByYear(DropDownList ddlProjects, DropDownList ddlYear)
    {
        ddlProjects.Items.Clear();
        ddlProjects.Items.Add(new ListItem("Select Project", "-1"));

        List<MainProjects> lstMainProjects = lstGetLeanProjectsByYear(int.Parse(ddlYear.SelectedValue));
        foreach (MainProjects oMainProject in lstMainProjects)
        {
            ddlProjects.Items.Add(new ListItem(oMainProject.sTitle, oMainProject.lProjectId.ToString()));
        }
    }

    public int iTotalProjectsByFunctionYear(int iFunctionId, int iYear)
    {
        int iTotalProjects = 0;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getTotalProjectsByFunctionYear();

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

        iTotalProjects = GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count;

        return iTotalProjects;
    }

    public int iTotalProjectsByYear(int iYear)
    {
        int iTotalProjects = 0;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getTotalProjectsByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        iTotalProjects = GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count;

        return iTotalProjects;
    }

    public decimal iTotalCostReductionPerYear(int iYear)
    {
        decimal iTotalCostReduction = 0;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getTotalCostReductionPerYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        iTotalCostReduction = decimal.TryParse(GenericDataAccess.ExecuteSelectCommand(comm).Rows[0]["COSTSAVINGS"].ToString(), out iTotalCostReduction) == false ? iTotalCostReduction : iTotalCostReduction;

        return iTotalCostReduction;
    }

    public decimal iTotalCycleTimeReductionPerYear(int iYear)
    {
        decimal iTotalCycleTimeReduction = 0;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getTotalCycleTimeReductionPerYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        iTotalCycleTimeReduction = decimal.TryParse(GenericDataAccess.ExecuteSelectCommand(comm).Rows[0]["CT_SAINGS"].ToString(), out iTotalCycleTimeReduction) == false ? iTotalCycleTimeReduction : iTotalCycleTimeReduction;

        return iTotalCycleTimeReduction;
    }

    public decimal iNumberofProductionBarrelPerYear(int iYear)
    {
        decimal iNumberofProductionBarrel = 0;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getTotalNoOfProductionBarrelPerYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        iNumberofProductionBarrel = decimal.TryParse(GenericDataAccess.ExecuteSelectCommand(comm).Rows[0]["PRODUCTIONBARREL"].ToString(), out iNumberofProductionBarrel) == false ? iNumberofProductionBarrel : iNumberofProductionBarrel;

        return iNumberofProductionBarrel;
    }

    public DataTable dtGetProjectFunctions(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectFunctions();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFunctionWorkDoneByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.WorkDone();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetWorkDoneByFunction(int iYear)
    {
        int iTotalProjects = 0;
        int iFunctionProjects = 0;
        int iFunctionId = 0;
        DataTable dt = dtGetProjectFunctions(iYear);

        //Chart Work Done.
        //dt.Columns.Add("FUNCTION");
        dt.Columns.Add("IDENTIFY");
        dt.Columns.Add("ELIMINATE");
        dt.Columns.Add("SUSTAIN");
        dt.Columns.Add("TOTALPROJINHOPPER");

        foreach (DataRow dr in dt.Rows)
        {
            iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());

            //dr["FUNCTION"] = oFunctionMgt.objGetFunctionById(iFunctionId).m_sFunction;
            dr["IDENTIFY"] = oIdentifyHelper.IdentifyWorkDoneByFunctionYear(iFunctionId, iYear).ToString();
            dr["ELIMINATE"] = oEliminateHelper.EliminateWorkDoneByFunctionYear(iFunctionId, iYear).ToString();
            dr["SUSTAIN"] = oSustainHelper.SustainWorkDoneByFunctionYear(iFunctionId, iYear).ToString();
            iFunctionProjects = iTotalProjectsByFunctionYear(iFunctionId, iYear);
            dr["TOTALPROJINHOPPER"] = iFunctionProjects;
            iTotalProjects += iFunctionProjects;
        }

        return dt;
    }

    public List<WorkDone> lstWorkDone(int iYear)
    {
        DataTable dt = dtGetWorkDoneByFunction(iYear);

        List<WorkDone> oWorkDone = new List<WorkDone>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oWorkDone.Add(new WorkDone(dr));
        }

        return oWorkDone;
    }

    public List<ProjectMaturationPhase> lstProjectMaturationPhase(int iYear)
    {
        DataTable dt = dtGetFunctionWorkDoneByYear(iYear);

        List<ProjectMaturationPhase> oProjectMaturationPhase = new List<ProjectMaturationPhase>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oProjectMaturationPhase.Add(new ProjectMaturationPhase(dr));
        }

        return oProjectMaturationPhase;
    }

    public DataTable dtGetCompletedAndOngoingProjectsByFunction(int iYear, int iFunctionId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.CompletedAndOngoingProjectsByFunction();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCompleted";
        param.Value = ((int)ProjectStatus.ProjStatus.Yes20 - 1);
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOngoing";
        param.Value = (int)ProjectStatus.ProjStatus.Ongoing10;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public struct CompletedOngoingProjects
    {
        public int iCompleted;
        public decimal dActualBenefitCR;
        public decimal dActualBenefitCT;
        public decimal dActualBenefitBRRL;

        public int iOngoingStalled;
        public decimal dPotentialBenefitCR;
        public decimal dPotentialBenefitCT;
        public decimal dPotentialBenefitBRRL;

        public int iTotalProjects;
    }

    public CompletedOngoingProjects objGetCompletedAndOngoingProjects(int iYear, int iFunctionId)
    {
        DataTable dt = dtGetCompletedAndOngoingProjectsByFunction(iYear, iFunctionId);
        
        CompletedOngoingProjects oCompletedOngoingProjects = new CompletedOngoingProjects();
         //= dt.Rows.Count;

        foreach (DataRow dr in dt.Rows)
        {
            //TODO: find a way to change the "IMPLEMENT_V" table field to a typed value. Later.... I can't remember what I mean here but I think the code is okay (15, October 2014 code review)
            if (dr["IMPLEMENT_V"].ToString() == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString())
            {
                oCompletedOngoingProjects.iCompleted += 1;

                if (dr["PRODUCTION_BARREL"] != DBNull.Value) oCompletedOngoingProjects.dActualBenefitBRRL += decimal.Parse(dr["PRODUCTION_BARREL"].ToString());
                if (dr["COST_SAVINGS"] != DBNull.Value) oCompletedOngoingProjects.dActualBenefitCR += decimal.Parse(dr["COST_SAVINGS"].ToString());
                if (dr["CT_SAINGS"] != DBNull.Value) oCompletedOngoingProjects.dActualBenefitCT += decimal.Parse(dr["CT_SAINGS"].ToString());

                if (dr["PRODUCTIONBARREL"] != DBNull.Value) oCompletedOngoingProjects.dPotentialBenefitBRRL += decimal.Parse(dr["PRODUCTIONBARREL"].ToString());
                if (dr["COSTREDUCTION"] != DBNull.Value) oCompletedOngoingProjects.dPotentialBenefitCR += decimal.Parse(dr["COSTREDUCTION"].ToString());
                if (dr["CTREDUCTION"] != DBNull.Value) oCompletedOngoingProjects.dPotentialBenefitCT += decimal.Parse(dr["CTREDUCTION"].ToString());
            }
            else if ((dr["IMPLEMENT_V"].ToString() == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) || (dr["IMPLEMENT_V"].ToString() == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) || (dr["IMPLEMENT_V"] == DBNull.Value))
            {
                oCompletedOngoingProjects.iOngoingStalled += 1;

                if (dr["PRODUCTION_BARREL"] != DBNull.Value) oCompletedOngoingProjects.dActualBenefitBRRL += decimal.Parse(dr["PRODUCTION_BARREL"].ToString());
                if (dr["COST_SAVINGS"] != DBNull.Value) oCompletedOngoingProjects.dActualBenefitCR += decimal.Parse(dr["COST_SAVINGS"].ToString());
                if (dr["CT_SAINGS"] != DBNull.Value) oCompletedOngoingProjects.dActualBenefitCT += decimal.Parse(dr["CT_SAINGS"].ToString());

                if (dr["PRODUCTIONBARREL"] != DBNull.Value) oCompletedOngoingProjects.dPotentialBenefitBRRL += decimal.Parse(dr["PRODUCTIONBARREL"].ToString());
                if (dr["COSTREDUCTION"] != DBNull.Value) oCompletedOngoingProjects.dPotentialBenefitCR += decimal.Parse(dr["COSTREDUCTION"].ToString());
                if (dr["CTREDUCTION"] != DBNull.Value) oCompletedOngoingProjects.dPotentialBenefitCT += decimal.Parse(dr["CTREDUCTION"].ToString());
            }

            oCompletedOngoingProjects.iTotalProjects += 1;
        }
        return oCompletedOngoingProjects;
    }

    #region  //******************** Loading Projects By Who logs in and by criteria *****************************

    public void LoadProjects(Nullable<int> iRoleId, int iUserId, GridView grdGridView)
    {
        if ((iRoleId == (int)appUsersLeanRoles.userRole.Administrator) || (iRoleId == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = dtGetLeanProjects();
        }
        else
        {
            grdGridView.DataSource = dtGetMyProjects(iUserId);
        }

        grdGridView.DataBind();
    }

    public void LoadProjectsByYear(int iRoleId, int iUserId, int iYear, GridView grdGridView)
    {
        if ((iRoleId == (int)appUsersLeanRoles.userRole.Administrator) || (iRoleId == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = dtGetLeanProjectsByYear(iYear);
        }
        else
        {
            grdGridView.DataSource = dtGetMyProjectsByYear(iUserId, iYear);
        }
       
        grdGridView.DataBind();
    }

    public void LoadProjectsByFunction(Nullable<int> iRoleId, int iUserId, int iFunctionId, GridView grdGridView)
    {
        if ((iRoleId == (int)appUsersLeanRoles.userRole.Administrator) || (iRoleId == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = dtGetLeanProjectsByFunction(iFunctionId);
        }
        else
        {
            grdGridView.DataSource = dtGetMyProjectsByFunction(iUserId, iFunctionId);
        }

        grdGridView.DataBind();
    }

    public void LoadProjectsByFunctionYear(Nullable<int> iRoleId, int iUserId, int iYear, int iFunctionId, GridView grdGridView)
    {
        if ((iRoleId == (int)appUsersLeanRoles.userRole.Administrator) || (iRoleId == (int)appUsersLeanRoles.userRole.CorporateManager))
        {
            grdGridView.DataSource = dtGetLeanProjectsByFunctionYear(iYear, iFunctionId);
        }
        else
        {
            grdGridView.DataSource = dtGetMyProjectsByYearFunction(iUserId, iYear, iFunctionId);
        }
       
        grdGridView.DataBind();
    }

    #endregion


    #region //***********************  Project Team Members *****************************

    public DataTable dtGetProjectTeamMembers(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectTeamMembers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<ProjectTeamMembers> lstProjectTeamMembers(long lProjectId)
    {
        DataTable dt = dtGetProjectTeamMembers(lProjectId);

        List<ProjectTeamMembers> oProjectTeamMembers = new List<ProjectTeamMembers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oProjectTeamMembers.Add(new ProjectTeamMembers(dr));
        }

        return oProjectTeamMembers;
    }

    public bool deleteProjectTeamMember(long lTeamId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.deleteProjectTeamMember();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lTeamId";
        param.Value = lTeamId;
        param.DbType = DbType.Int64;
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

    public bool AddProjectTeamMember(ProjectTeamMembers oProjectTeamMembers)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.AddProjectTeamMember();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oProjectTeamMembers.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oProjectTeamMembers.iUserId;
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


    #endregion


    #region //***********************  Project DRB Members *****************************
    public DataTable dtGetProjectDRBMembers(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectDrbMembers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public List<ProjectDrbMembers> lstProjectDrbMembers(long lProjectId)
    {
        DataTable dt = dtGetProjectDRBMembers(lProjectId);

        List<ProjectDrbMembers> oProjectDrbMembers = new List<ProjectDrbMembers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oProjectDrbMembers.Add(new ProjectDrbMembers(dr));
        }

        return oProjectDrbMembers;
    }
    public bool deleteProjectDRBMember(long lDrbId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.deleteProjectDrbMember();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDrbId";
        param.Value = lDrbId;
        param.DbType = DbType.Int64;
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
    public bool AddProjectDrbMember(ProjectDrbMembers oProjectDrbMembers)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.AddProjectDrbMember();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oProjectDrbMembers.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oProjectDrbMembers.iUserId;
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

    #endregion

    #region //***********************  Project Coaches *****************************
    public DataTable dtGetProjectProjectCoach(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectCoach();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<ProjectCoaches> lstProjectCoaches(long lProjectId)
    {
        DataTable dt = dtGetProjectProjectCoach(lProjectId);

        List<ProjectCoaches> oProjectCoaches = new List<ProjectCoaches>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oProjectCoaches.Add(new ProjectCoaches(dr));
        }

        return oProjectCoaches;
    }

    public bool deleteProjectCoach(long lCoachId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.deleteProjectCoach();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCoachId";
        param.Value = lCoachId;
        param.DbType = DbType.Int64;
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
    public bool AddProjectCoach(ProjectCoaches oProjectCoaches)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.AddProjectCoach();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oProjectCoaches.lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oProjectCoaches.iUserId;
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

    #endregion
}

//// Update Project Ownership

//public bool UpdateSponsor(MainProjects oMainProject)
//{
//    string sql = "UPDATE LEAN_PROJECTS SET SPONSORID = :iSponsor WHERE IDPROJECT = :lProjectId";

//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = sql;

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":lProjectId";
//    param.Value = oMainProject.lProjectId;
//    param.DbType = DbType.Int64;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iSponsor";
//    param.Value = oMainProject.iSponsor;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    int result = -1;

//    try
//    {
//        // execute the stored procedure
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        //MessageBox.Show(ex.Message.ToString());
//        // any errors are logged in GenericDataAccess, we ignore them here
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    // result will be 1 in case of success
//    return (result != -1);

//}

//public bool UpdateChampion(MainProjects oMainProject)
//{
//    string sql = "UPDATE LEAN_PROJECTS SET CHAMPIONID = :iChampion WHERE IDPROJECT = :lProjectId";

//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = sql;

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":lProjectId";
//    param.Value = oMainProject.lProjectId;
//    param.DbType = DbType.Int64;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iChampion";
//    param.Value = oMainProject.iChampion;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    int result = -1;

//    try
//    {
//        // execute the stored procedure
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        //MessageBox.Show(ex.Message.ToString());
//        // any errors are logged in GenericDataAccess, we ignore them here
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    // result will be 1 in case of success
//    return (result != -1);

//}

//public bool UpdateManager(MainProjects oMainProject)
//{
//    string sql = "UPDATE LEAN_PROJECTS SET MANAGERID = :iManager WHERE IDPROJECT = :lProjectId";

//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = sql;

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":lProjectId";
//    param.Value = oMainProject.lProjectId;
//    param.DbType = DbType.Int64;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iManager";
//    param.Value = oMainProject.iManager;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    int result = -1;

//    try
//    {
//        // execute the stored procedure
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        //MessageBox.Show(ex.Message.ToString());
//        // any errors are logged in GenericDataAccess, we ignore them here
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    // result will be 1 in case of success
//    return (result != -1);

//}

//public bool UpdateCoach(MainProjects oMainProject)
//{
//    string sql = "UPDATE LEAN_PROJECTS SET COACHID = :iCoach WHERE IDPROJECT = :lProjectId";

//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = sql;

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":lProjectId";
//    param.Value = oMainProject.lProjectId;
//    param.DbType = DbType.Int64;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iCoach";
//    param.Value = oMainProject.iCoach;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    int result = -1;

//    try
//    {
//        // execute the stored procedure
//        result = GenericDataAccess.ExecuteNonQuery(comm);
//    }
//    catch (Exception ex)
//    {
//        //MessageBox.Show(ex.Message.ToString());
//        // any errors are logged in GenericDataAccess, we ignore them here
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//    // result will be 1 in case of success
//    return (result != -1);

//}

//public DataTable dtGetMyProjectsLeanCoach(int iCoachId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectLeanCoach();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iCoachId";
//    param.Value = iCoachId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsLeanCoachByYear(int iCoachId, int iYear)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectLeanCoachByYear();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iCoachId";
//    param.Value = iCoachId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iYear";
//    param.Value = iYear;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsLeanCoachByFunction(int iCoachId, int iFunctionId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectLeanCoachByFunction();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iCoachId";
//    param.Value = iCoachId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iFunctionId";
//    param.Value = iFunctionId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsLeanCoachByYearFunction(int iCoachId, int iYear, int iFunctionId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectLeanCoachByYearFunction();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iCoachId";
//    param.Value = iCoachId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iYear";
//    param.Value = iYear;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iFunctionId";
//    param.Value = iFunctionId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}
//public DataTable dtGetMyProjectsSponsor(int iSponsorId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectsSponsor();

//DbParameter 

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsSponsorByYear(int iSponsorId, int iYear)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectSponsorByYear();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iSponsorId";
//    param.Value = iSponsorId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iYear";
//    param.Value = iYear;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsSponsorByFunction(int iSponsorId, int iFunctionId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectSponsorByFunction();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iSponsorId";
//    param.Value = iSponsorId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iFunctionId";
//    param.Value = iFunctionId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsSponsorByYearFunction(int iSponsorId, int iYear, int iFunctionId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectSponsorByYearFunction();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iSponsorId";
//    param.Value = iSponsorId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iYear";
//    param.Value = iYear;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iFunctionId";
//    param.Value = iFunctionId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}


//public DataTable dtGetMyProjectsManager(int iFocalPointId)
//{
//    //Note: The Project Manager is the Project Focal Point
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectsManager();

//    

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsManagerByYear(int iFocalPointId, int iYear)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectManagerByYear();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iFocalPointId";
//    param.Value = iFocalPointId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iYear";
//    param.Value = iYear;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsManagerByFunction(int iFocalPointId, int iFunctionId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectManagerByFunction();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iFocalPointId";
//    param.Value = iFocalPointId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iFunctionId";
//    param.Value = iFunctionId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}

//public DataTable dtGetMyProjectsManagerByYearFunction(int iFocalPointId, int iYear, int iFunctionId)
//{
//    OracleCommand comm = GenericDataAccess.CreateCommand();
//    comm.CommandText = StoredProcedureLean.getMyLeanProjectManagerByYearFunction();

//    OracleParameter param = comm.CreateParameter();
//    param.ParameterName = ":iFocalPointId";
//    param.Value = iFocalPointId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iYear";
//    param.Value = iYear;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    param = comm.CreateParameter();
//    param.ParameterName = ":iFunctionId";
//    param.Value = iFunctionId;
//    param.DbType = DbType.Int32;
//    comm.Parameters.Add(param);

//    return GenericDataAccess.ExecuteSelectCommand(comm);
//}
