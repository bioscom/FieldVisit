using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
	public int m_iCategoryId { get; set; }
    public string m_sCategory { get; set; }

	public Category()
	{
		
	}

    public Category(DataRow dr)
    {
        m_iCategoryId = int.Parse(dr["IDCATEGORY"].ToString());
        m_sCategory =dr["CATEGORY"].ToString();
    }

    public static Category objGetCategoryByCatId(int iCategoryId)
    {
        DataTable dt = dtGetCategoryByCatId(iCategoryId);

        Category oCategory = new Category();
        foreach (DataRow dr in dt.Rows)
        {
            oCategory = new Category(dr);
        }
        return oCategory;
    }

    public static DataTable dtGetCategoryByCatId(int iCategoryId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getCategoryByCatId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iCategoryId";
        param.Value = iCategoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetCategories()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getCategories();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<Category> lstGetCategories()
    {
        DataTable dt = dtGetCategories();

        List<Category> oCategories = new List<Category>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oCategories.Add(new Category(dr));
        }
        return oCategories;
    }
}