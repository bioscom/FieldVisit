using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ContractProcurementVehicle
/// </summary>
public class ContractProcurementVehicle
{
    public int m_iVehicleId { get; set; }
    public string m_sName { get; set; }

    public ContractProcurementVehicle()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ContractProcurementVehicle(DataRow dr)
    {
        m_iVehicleId = int.Parse(dr["VEHICLEID"].ToString());
        m_sName = dr["NAME"].ToString();
    }
}

public class ContractProcurementVehicleMgt
{

    public DataTable dtGetContractProcurementVehicle()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getVehicles(); 

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetContractProcurementVehicleById(int iVehicleId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getVehicleById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iVehicleId";
        param.Value = iVehicleId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public ContractProcurementVehicle objGetContractProcurementVehicleById(int iVehicleId)
    {
        DataTable dt = dtGetContractProcurementVehicleById(iVehicleId);

        var o = new ContractProcurementVehicle();
        foreach (DataRow dr in dt.Rows)
        {
            o = new ContractProcurementVehicle(dr);
        }
        return o;
    }

    public List<ContractProcurementVehicle> lstGetContractProcurementVehicle()
    {
        DataTable dt = dtGetContractProcurementVehicle();

        List<ContractProcurementVehicle> o = new List<ContractProcurementVehicle>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new ContractProcurementVehicle(dr));
        }
        return o;
    }

}