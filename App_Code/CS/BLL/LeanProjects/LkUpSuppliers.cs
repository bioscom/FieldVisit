using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for LkUpSuppliers
/// </summary>
public class LkUpSuppliers
{
    public int iSupplierId { get; set; }
    public string sSupplier { get; set; }

	public LkUpSuppliers()
	{
		//
		// 
		//
	}

    public LkUpSuppliers(DataRow dr)
    {
        iSupplierId = int.Parse(dr["SUPPLIERID"].ToString());
        sSupplier = dr["SUPPLIER"].ToString();
    }
}

public class LkUpSuppliersHelper
{
    public LkUpSuppliersHelper()
    {

    }

    public DataTable dtGetSuppliers()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getSuppliers();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<LkUpSuppliers> lstGetSuppliers()
    {
        DataTable dt = dtGetSuppliers();

        List<LkUpSuppliers> oSuppliers = new List<LkUpSuppliers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oSuppliers.Add(new LkUpSuppliers(dr));
        }
        return oSuppliers;
    }
}