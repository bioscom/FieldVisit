using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ContractApproval
/// </summary>

public class ContractApproval
{
    public int iDistrictId { get; set; }
    public int iApprovalId { get; set; }
    public int iUserId { get; set; }
    public string sComments { get; set; }
    public int iStatus { get; set; }
    public DateTime dtTripStartDate { get; set; }
    public DateTime dtDateReceived { get; set; }
    public DateTime dtDateReviewed { get; set; }
    //public int iBit { get; set; }
    //public int iBitCalc { get; set; }
    //public string sMeasures { get; set; }
    //public decimal dTripTarget { get; set; }

    public ContractApproval()
    {
        //
        // 
        //
    }

    public ContractApproval(DataRow dr)
    {
        iDistrictId = int.Parse(dr["ID_DISTRICT"].ToString());
        iApprovalId = int.Parse(dr["IDAPPROVAL"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
        iStatus = int.Parse(dr["STATUS"].ToString());
        sComments = dr["COMMENTS"].ToString();
        dtTripStartDate = DateTime.Parse(dr["START_DATE"].ToString());
        dtDateReceived = DateTime.Parse(dr["DATE_RECEIVED"].ToString());
        dtDateReviewed = DateTime.Parse(dr["DATE_REVIEWED"].ToString());
    }
}

public class ContractApprovalHelper
{
    public ContractApprovalHelper()
    {
        
    }

    public static bool SendForApproval(ContractApproval oContractApproval)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.SendForApproval();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oContractApproval.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
                
        param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oContractApproval.dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dDateReceived";
        param.Value = oContractApproval.dtDateReceived;
        param.DbType = DbType.Date;
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

    public static bool Approved(ContractApproval oContractApproval)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureContract.Approved();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iDistrictId";
        param.Value = oContractApproval.iDistrictId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtTripStartDate";
        param.Value = oContractApproval.dtTripStartDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtDateReviewed";
        param.Value = DateTime.Now.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = oContractApproval.iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oContractApproval.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oContractApproval.sComments;
        param.DbType = DbType.String;
        param.Size = 2000;
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

}