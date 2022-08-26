using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for BuzBILeanReviewers
/// </summary>

public class BuzBILeanReviewers
{
    public BuzBILeanReviewers()
    {
        //
        // 
        //
    }
    public static bool Insert(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.InsertReviewer();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
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

    public static bool InsertCRStageGater(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.InsertStageGater();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iValue";
        param.Value = 2;
        param.DbType = DbType.Int32;
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

    public static bool Update(int iReviewId, int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.UpdateReviewer();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iReviewId";
        param.Value = iReviewId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
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

    public static DataTable dtGetBILeanReviewers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBILeanReviewers();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetCRStageGaters()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getCRStageGaters();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetBILeanReviewerByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getBILeanReviewerByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetCRStageGaterByUserId(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.getCRStageGaterByUserId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool RemoveFromReviewers(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.RemoveFromReviewers();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
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

    public static bool RemoveFromStageGaters(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBI500.RemoveFromStageGaters();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
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

    public static List<BIReviewers> lstGetBILeanReviewers()
    {
        DataTable dt = dtGetBILeanReviewers();

        List<BIReviewers> BILeanReviewers = new List<BIReviewers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            BILeanReviewers.Add(new BIReviewers(dr));
        }
        return BILeanReviewers;
    }

    public static List<BIReviewers> lstGetCRStageGaters()
    {
        DataTable dt = dtGetCRStageGaters();

        List<BIReviewers> o = new List<BIReviewers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new BIReviewers(dr));
        }
        return o;
    }

    public static BIReviewers objGetBILeanReviewerByUserId(int iUserId)
    {
        DataTable dt = dtGetBILeanReviewerByUserId(iUserId);
        BIReviewers oBIReviewers = new BIReviewers();
        foreach (DataRow dr in dt.Rows)
        {
            oBIReviewers = new BIReviewers(dr);
        }
        return oBIReviewers;
    }

    

    //public DataTable dtGetBusinessUnitAssignedByUserId(int iUserId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureBI500.getBusinessUnitFocalPoint();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iUserId";
    //    param.Value = iUserId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public BusinessLeanFocalPoints objGetBusinessUnitAssignedByUserId(int iUserId)
    //{
    //    DataTable dt = dtGetBusinessUnitAssignedByUserId(iUserId);
    //    BusinessLeanFocalPoints oBusinessLeanFocalPoints = new BusinessLeanFocalPoints();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        oBusinessLeanFocalPoints = new BusinessLeanFocalPoints(dr);
    //    }
    //    return oBusinessLeanFocalPoints;
    //}

    //public DataTable dtGetBusinessUnitFocalPointsByFunction(int iFunctionId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureBI500.getBusinessUnitFocalPointsByFunction();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":iFunctionId";
    //    param.Value = iFunctionId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public List<BusinessLeanFocalPoints> lstGetBusinessUnitFocalPointsByFunction(int iFunctionId)
    //{
    //    DataTable dt = dtGetBusinessUnitFocalPointsByFunction(iFunctionId);

    //    List<BusinessLeanFocalPoints> BusinessUnitFocalPoints = new List<BusinessLeanFocalPoints>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        BusinessUnitFocalPoints.Add(new BusinessLeanFocalPoints(dr));
    //    }
    //    return BusinessUnitFocalPoints;
    //}
}