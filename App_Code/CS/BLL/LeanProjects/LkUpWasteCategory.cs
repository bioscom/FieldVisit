using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for LkUpWasteCategory
/// </summary>
public class LkUpWasteCategory
{
    public int iWasteId { get; set; }
    public string sWaste { get; set; }
    public string sCode { get; set; }

	public LkUpWasteCategory()
	{
		//
		// 
		//
	}

    public LkUpWasteCategory(DataRow dr)
    {
        iWasteId = int.Parse(dr["WASTEID"].ToString());
        sWaste = dr["WASTE"].ToString();
        sCode = dr["CODE"].ToString();
    }
}

public class LkUpWasteCategoryHelper
{
    public LkUpWasteCategoryHelper()
    {

    }

    public DataTable dtGetWasteCategory()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getWasteCategory();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public List<LkUpWasteCategory> lstGetWasteCategory()
    {
        DataTable dt = dtGetWasteCategory();

        List<LkUpWasteCategory> oWasteCategory = new List<LkUpWasteCategory>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oWasteCategory.Add(new LkUpWasteCategory(dr));
        }
        return oWasteCategory;
    }
}