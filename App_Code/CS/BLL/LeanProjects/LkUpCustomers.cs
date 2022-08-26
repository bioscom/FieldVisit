using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for LkUpCustomers
/// </summary>

public class LkUpCustomers
{
    public int iCustomerId { get; set; }
    public string sCustomer { get; set; }

    public LkUpCustomers()
    {
        //
        // 
        //
    }

    public LkUpCustomers(DataRow dr)
    {
        iCustomerId = int.Parse(dr["CUSTOMERID"].ToString());
        sCustomer = dr["CUSTOMER"].ToString();
    }
}

public class LkUpCustomersHelper
{
    public LkUpCustomersHelper()
    {

    }

    public DataTable dtGetCustomers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getCustomers();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<LkUpCustomers> lstGetCustomers()
    {
        DataTable dt = dtGetCustomers();

        List<LkUpCustomers> oCustomers = new List<LkUpCustomers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oCustomers.Add(new LkUpCustomers(dr));
        }
        return oCustomers;
    }
}