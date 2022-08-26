using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for VSMASIS
/// </summary>

public class VSMASIS
{
    public long lProjectId { get; set; }
    public long lVsmAsIsId { get; set; }
    public int iSeqId { get; set; }
    //public string sVSMID { get; set; }
    public string sActivityDesc { get; set; }
    public decimal dProcessLt { get; set; }
    public int iProcessLtUnit { get; set; }
    public decimal dProcessVat { get; set; }
    public int iProcessVatUnit { get; set; }
    //public decimal dProcessLtMin { get; set; }
    //public decimal dProcessVatMin { get; set; }
    public int iWasteCat { get; set; }
    public string sSupplier { get; set; }
    public string sInput { get; set; }
    public string sOutPut { get; set; }
    public string sCustomer { get; set; }
    public string sImprovement { get; set; }
    public string sWasteCode { get; set; }
    public int iFunctionId { get; set; }

    public VSMASIS()
    {

    }

    public VSMASIS(DataRow dr)
    {
        lVsmAsIsId = long.Parse(dr["IDVSMASIS"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        //sVSMID = dr["VSMID"].ToString();
        iSeqId = int.Parse(dr["SEQID"].ToString());
        sActivityDesc = dr["ACTIVITYDESC"].ToString();
        dProcessLt = decimal.Parse(dr["PROCESSLT"].ToString());
        iProcessLtUnit = int.Parse(dr["PROCESSLTUNIT"].ToString());
        dProcessVat = decimal.Parse(dr["PROCESSVAT"].ToString());
        iProcessVatUnit = int.Parse(dr["PROCESSVATUNIT"].ToString());
        //dProcessLtMin = decimal.Parse(dr["PLTMINUTE"].ToString());
        //dProcessVatMin = decimal.Parse(dr["PVATMINUTE"].ToString());
        iWasteCat = int.Parse(dr["WASTEID"].ToString());
        sSupplier = dr["SUPPLIER"].ToString();
        sInput = dr["INPUT"].ToString();
        sOutPut = dr["OUTPUT"].ToString();
        sCustomer = dr["CUSTOMER"].ToString();
        sImprovement = dr["IMPROVEMENT"].ToString();
        sWasteCode = dr["WASTECODE"].ToString();
        iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());
    }
}

public class VSMASISHelper
{
    public VSMASISHelper()
    {

    }

    public DataTable dtGetVSMASISByProjectId(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getProjectVSMASISByProjectId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    //public DataTable dtGetVSMASISByProjectIdentifyId(long lIdentifyId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedureLean.getProjectVSMASISByProjectIdentifyId();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":lIdentifyId";
    //    param.Value = lIdentifyId;
    //    param.DbType = DbType.Int64;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public VSMASIS objGetASISByProjectIdentifyId(long lIdentifyId)
    //{
    //    DataTable dt = dtGetVSMASISByProjectIdentifyId(lIdentifyId);

    //    VSMASIS oIdenfifyASISVsm = new VSMASIS();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        oIdenfifyASISVsm = new VSMASIS(dr);
    //    }
    //    return oIdenfifyASISVsm;
    //}

    public DataTable dtGetVSMASISByVsmAsIsId(long lVsmAsIsId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getVSMASISByVsmAsIsId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lVsmAsIsId";
        param.Value = lVsmAsIsId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public VSMASIS objGetVSMASISByVsmAsIsId(long lVsmAsIsId)
    {
        DataTable dt = dtGetVSMASISByVsmAsIsId(lVsmAsIsId);

        VSMASIS oIdenfifyASISVsm = new VSMASIS();
        foreach (DataRow dr in dt.Rows)
        {
            oIdenfifyASISVsm = new VSMASIS(dr);
        }
        return oIdenfifyASISVsm;
    }

    public bool InsertVsmAsIs(VSMASIS oVsmAsIs)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.InsertVsmAsIs();
        
        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sCustomer";
        param.Value = oVsmAsIs.sCustomer;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = oVsmAsIs.iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iProcessLtUnit";
        param.Value = oVsmAsIs.iProcessLtUnit;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iProcessVatUnit";
        param.Value = oVsmAsIs.iProcessVatUnit;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSeqId";
        param.Value = oVsmAsIs.iSeqId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSupplier";
        param.Value = oVsmAsIs.sSupplier;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iWasteCat";
        param.Value = oVsmAsIs.iWasteCat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = oVsmAsIs.lProjectId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);       

        param = comm.CreateParameter();
        param.ParameterName = ":sActivityDesc";
        param.Value = oVsmAsIs.sActivityDesc;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sImprovement";
        param.Value = oVsmAsIs.sImprovement;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sInput";
        param.Value = oVsmAsIs.sInput;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOutPut";
        param.Value = oVsmAsIs.sOutPut;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = ":sProcessLt";
        param.Value = oVsmAsIs.dProcessLt;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sProcessLtMin";
        //param.Value = oVsmAsIs.dProcessLtMin;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProcessVat";
        param.Value = oVsmAsIs.dProcessVat;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sProcessVatMin";
        //param.Value = oVsmAsIs.dProcessVatMin;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWasteCode";
        param.Value = oVsmAsIs.sWasteCode;
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
            // any errors are logged in GenericDataAccess, we ignore them here
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);

    }
    public bool UpdateVsmAsIs(VSMASIS oVsmAsIs)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateVsmAsIs();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sCustomer";
        param.Value = oVsmAsIs.sCustomer;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFunctionId";
        param.Value = oVsmAsIs.iFunctionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iProcessLtUnit";
        param.Value = oVsmAsIs.iProcessLtUnit;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iProcessVatUnit";
        param.Value = oVsmAsIs.iProcessVatUnit;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSeqId";
        param.Value = oVsmAsIs.iSeqId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sSupplier";
        param.Value = oVsmAsIs.sSupplier;
        param.DbType = DbType.String;
        param.Size = 500;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iWasteCat";
        param.Value = oVsmAsIs.iWasteCat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lVsmAsIsId";
        param.Value = oVsmAsIs.lVsmAsIsId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sActivityDesc";
        param.Value = oVsmAsIs.sActivityDesc;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sImprovement";
        param.Value = oVsmAsIs.sImprovement;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sInput";
        param.Value = oVsmAsIs.sInput;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOutPut";
        param.Value = oVsmAsIs.sOutPut;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProcessLt";
        param.Value = oVsmAsIs.dProcessLt;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sProcessLtMin";
        //param.Value = oVsmAsIs.dProcessLtMin;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sProcessVat";
        param.Value = oVsmAsIs.dProcessVat;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sProcessVatMin";
        //param.Value = oVsmAsIs.dProcessVatMin;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sWasteCode";
        param.Value = oVsmAsIs.sWasteCode;
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
    public bool DeleteVsmAsIs(long lVsmAsIsId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteVsmAsIs2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lVsmAsIsId";
        param.Value = lVsmAsIsId;
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
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);

    }

}