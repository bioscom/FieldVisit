using System;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;

public class DocumentDetails
{
    public long lDocumentId { get; set; }
    public long lProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FileName { get; set; }

    public DocumentDetails()
    {

    }

    public DocumentDetails(DataRow dr)
    {
        lDocumentId = long.Parse(dr["IDDOC"].ToString());
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        Title = dr["DOC_TITLE"].ToString();
        FileName = dr["FILE_NAME"].ToString();
        Description = dr["DESCRIPTION"].ToString();
    }
}

/// <summary>
/// Product catalog business tier component
/// </summary>
public static class CatalogAccess
{
    static CatalogAccess()
    {
        //
        // 
        //
    }

    public static DataTable dtDocumentDetails(long lDocumentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getDocumentDetails(); //"CatalogGetProductDetails";

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDocumentId";
        param.Value = lDocumentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DocumentDetails objGetDocumentDetails(long lDocumentId)
    {
        DataTable dt = dtDocumentDetails(lDocumentId);

        DocumentDetails oDocumentDetails = new DocumentDetails();
        foreach (DataRow dr in dt.Rows)
        {
            oDocumentDetails = new DocumentDetails(dr);
        }
        return oDocumentDetails;
    }
    public static DataTable GetAllDocumentsInProject(long lProjectId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.getAllDocuments();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // Create a new product
    public static bool CreateDocument(long lProjectId, string sTitle, string sDescription, string sFileName)
    {
        // get a configured DbCommand object
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.CreateDocument();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lProjectId";
        param.Value = lProjectId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = sTitle;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDescription";
        param.Value = sDescription;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileName";
        param.Value = sFileName;
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
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result >= 1);
    }

    // Update an existing document
    public static bool UpdateDocument(long lDocumentId, string sTitle, string sDescription)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.UpdateDocument();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDocumentId";
        param.Value = lDocumentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = sTitle;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sDescription";
        param.Value = sDescription;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sFileName";
        //param.Value = sFileName;
        //param.DbType = DbType.String;
        //param.Size = 2000;
        //comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // deletes a document from the document catalog
    public static bool DeleteDocument(long lDocumentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureLean.DeleteDocument();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDocumentId";
        param.Value = lDocumentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }

        return (result != -1);
    }

    // retrieve the list of products featured for a department
    //public static DataTable GetProductsOnDeptPromo
    //(string departmentId, string pageNumber, out int howManyPages)
    //{
    //  // get a configured DbCommand object
    //  OracleCommand comm = GenericDataAccess.CreateCommand();
    //  // set the stored procedure name
    //  comm.CommandText = "CatalogGetProductsOnDeptPromo";
    //  // create a new parameter
    //  OracleParameter param = comm.CreateParameter();
    //  param.ParameterName = "@DepartmentID";
    //  param.Value = departmentId;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@DescriptionLength";
    //  param.Value = BalloonShopConfiguration.ProductDescriptionLength;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@PageNumber";
    //  param.Value = pageNumber;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@ProductsPerPage";
    //  param.Value = BalloonShopConfiguration.ProductsPerPage;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@HowManyProducts";
    //  param.Direction = ParameterDirection.Output;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // execute the stored procedure and save the results in a DataTable
    //  DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    //  // calculate how many pages of products and set the out parameter
    //  int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
    //  howManyPages = (int)Math.Ceiling((double)howManyProducts /
    //                 (double)BalloonShopConfiguration.ProductsPerPage);
    //  // return the page of products
    //  return table;
    //}

    // retrieve the list of products in a category
    //public static DataTable GetProductsInCategory
    //(string categoryId, string pageNumber, out int howManyPages)
    //{
    //  // get a configured DbCommand object
    //  OracleCommand comm = GenericDataAccess.CreateCommand();
    //  // set the stored procedure name
    //  comm.CommandText = "CatalogGetProductsInCategory";
    //  // create a new parameter
    //  OracleParameter param = comm.CreateParameter();
    //  param.ParameterName = "@CategoryID";
    //  param.Value = categoryId;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@DescriptionLength";
    //  param.Value = BalloonShopConfiguration.ProductDescriptionLength;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@PageNumber";

    //  param.Value = pageNumber;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@ProductsPerPage";
    //  param.Value = BalloonShopConfiguration.ProductsPerPage;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@HowManyProducts";
    //  param.Direction = ParameterDirection.Output;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // execute the stored procedure and save the results in a DataTable
    //  DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    //  // calculate how many pages of products and set the out parameter
    //  int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
    //  howManyPages = (int)Math.Ceiling((double)howManyProducts /
    //                 (double)BalloonShopConfiguration.ProductsPerPage);
    //  // return the page of products
    //  return table;
    //}

    // Retrieve the list of product attributes 
    //public static DataTable GetProductAttributes(string productId)
    //{
    //  // get a configured DbCommand object
    //  OracleCommand comm = GenericDataAccess.CreateCommand();
    //  // set the stored procedure name
    //  comm.CommandText = "CatalogGetProductAttributeValues";
    //  // create a new parameter
    //  OracleParameter param = comm.CreateParameter();
    //  param.ParameterName = "@ProductID";
    //  param.Value = productId;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // execute the stored procedure and return the results
    //  return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    // Search the product catalog
    //public static DataTable Search(string searchString, string allWords,
    //string pageNumber, out int howManyPages)
    //{
    //  // get a configured DbCommand object
    //  OracleCommand comm = GenericDataAccess.CreateCommand();
    //  // set the stored procedure name
    //  comm.CommandText = "SearchCatalog";
    //  // create a new parameter
    //  OracleParameter param = comm.CreateParameter();
    //  param.ParameterName = "@DescriptionLength";
    //  param.Value = BalloonShopConfiguration.ProductDescriptionLength;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@AllWords";
    //  param.Value = allWords.ToUpper() == "TRUE" ? "1" : "0";
    //  param.DbType = DbType.Byte;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@PageNumber";
    //  param.Value = pageNumber;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@ProductsPerPage";
    //  param.Value = BalloonShopConfiguration.ProductsPerPage;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);
    //  // create a new parameter
    //  param = comm.CreateParameter();
    //  param.ParameterName = "@HowManyResults";
    //  param.Direction = ParameterDirection.Output;
    //  param.DbType = DbType.Int32;
    //  comm.Parameters.Add(param);

    //  // define the maximum number of words
    //  int howManyWords = 5;
    //  // transform search string into array of words
    //  string[] words = Regex.Split(searchString, "[^a-zA-Z0-9]+");

    //  // add the words as stored procedure parameters
    //  int index = 1;
    //  for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
    //    // ignore short words
    //    if (words[i].Length > 2)
    //    {
    //      // create the @Word parameters
    //      param = comm.CreateParameter();
    //      param.ParameterName = "@Word" + index.ToString();
    //      param.Value = words[i];
    //      param.DbType = DbType.String;
    //      comm.Parameters.Add(param);
    //      index++;
    //    }

    //  // execute the stored procedure and save the results in a DataTable
    //  DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    //  // calculate how many pages of products and set the out parameter
    //  int howManyProducts =
    //Int32.Parse(comm.Parameters["@HowManyResults"].Value.ToString());
    //  howManyPages = (int)Math.Ceiling((double)howManyProducts /
    //                 (double)BalloonShopConfiguration.ProductsPerPage);
    //  // return the page of products
    //  return table;
    //}
}