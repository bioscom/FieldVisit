using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Search
/// </summary>
public class Search
{
	public Search()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet SearchRecord(string _query)
    {
        string _sql = "Select * From Tbl_Search Where FreeText([Desc],'" + _query + "') or FreeText(Title,'" + _query + "')";
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection("Data Source=server2;User Id=sa;Password=123;DataBase=Local_Search");
        SqlCommand cmd = new SqlCommand(_sql, cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        return ds;
    }
    public DataSet GetRecord()
    {
        string _sql = "Select * From Tbl_Search";
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection("Data Source=server2;User Id=sa;Password=123;DataBase=Local_Search");
        SqlCommand cmd = new SqlCommand(_sql, cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        return ds;
    }
}