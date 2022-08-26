using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;

using System.Text;

    /// <summary>
    /// Summary description for DynamicGridViewMethods
    /// Program Designed by Bejide Isaac O.
    /// </summary>
public class DynamicGridViewMethods
{
    ArrayList ParameterArray = new ArrayList();

    public DynamicGridViewMethods()
    {
        //
        // 
        //
    }


    public DataTable PopulateDataTable(DropDownList EPPriorityDropDownList)  //this method is called by CreateTemplatedGridView() 'see below
    {
        DataTable Table = new DataTable();
        //TableGridView.Columns.Clear();
        //string sql = "";
        //
        //if (DateTime.Today.Month == 1) { sql = Queries.DECsql(EPPriorityDropDownList, (DateTime.Today.Year - 1), CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 2) { sql = Queries.JANsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 3) { sql = Queries.FEBsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 4) { sql = Queries.MARsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 5) { sql = Queries.APRsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 6) { sql = Queries.MAYsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 7) { sql = Queries.JUNsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 8) { sql = Queries.JULsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 9) { sql = Queries.AUGsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 10) { sql = Queries.SEPsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 11) { sql = Queries.OCTsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }
        //else if (DateTime.Today.Month == 12) { sql = Queries.NOVsql(EPPriorityDropDownList, DateTime.Today.Year, CurrentUser.sUserId); }

        //OracleConnection Connection = new OracleConnection(AppConfiguration.DbConnectionString);
        //OracleDataAdapter adapter = new OracleDataAdapter(sql, Connection);

        //try
        //{
        //    adapter.Fill(Table);
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}
        //finally
        //{
        //    Connection.Close();
        //}
        return Table;
    }


    public DataTable PopulateDataTable2(DropDownList EPPriorityDropDownList, DropDownList theMonth, DropDownList YYear)  //this method is called by CreateTemplatedGridView() 'see below
    {
        DataTable Table = new DataTable();
        //TableGridView.Columns.Clear();
        //string sql = "";
        //

        //if (theMonth.SelectedValue == "1") { sql = Queries.JANsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "2") { sql = Queries.FEBsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "3") { sql = Queries.MARsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "4") { sql = Queries.APRsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "5") { sql = Queries.MAYsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "6") { sql = Queries.JUNsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "7") { sql = Queries.JULsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "8") { sql = Queries.AUGsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "9") { sql = Queries.SEPsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "10") { sql = Queries.OCTsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "11") { sql = Queries.NOVsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }
        //else if (theMonth.SelectedValue == "12") { sql = Queries.DECsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue)); }

        //OracleConnection Connection = new OracleConnection(AppConfiguration.DbConnectionString);
        //OracleDataAdapter adapter = new OracleDataAdapter(sql, Connection);

        //try
        //{
        //    adapter.Fill(Table);
        //}

        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //    Connection.Close();
        //}
        return Table;
    }

    public DataTable PopulateDataTable3(DropDownList ddlCorporatePriority, DropDownList YYear)  //this method is called by CreateTemplatedGridView() 'see below
    {
        DataTable Table = new DataTable();

        //string sql = Queries.ALLsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue));

        //OracleConnection Connection = new OracleConnection(AppConfiguration.DbConnectionString);
        //OracleDataAdapter adapter = new OracleDataAdapter(sql, Connection);

        //try
        //{
        //    adapter.Fill(Table);
        //}

        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //    Connection.Close();
        //}
        return Table;
    }


    public DataTable PopulateDataTableBackLogUpdate(DropDownList EPPriorityDropDownList, DropDownList theMonth, DropDownList YYear)  //this method is called by CreateTemplatedGridView() 'see below
    {
        DataTable Table = new DataTable();
        //TableGridView.Columns.Clear();
        //string sql = "";
        //

        //if (theMonth.SelectedValue == "1") { sql = Queries.JANsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "2") { sql = Queries.FEBsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "3") { sql = Queries.MARsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "4") { sql = Queries.APRsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "5") { sql = Queries.MAYsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "6") { sql = Queries.JUNsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "7") { sql = Queries.JULsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "8") { sql = Queries.AUGsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "9") { sql = Queries.SEPsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "10") { sql = Queries.OCTsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "11") { sql = Queries.NOVsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }
        //else if (theMonth.SelectedValue == "12") { sql = Queries.DECsql(EPPriorityDropDownList, Convert.ToInt32(YYear.SelectedValue), CurrentUser.sUserId); }

        //OracleConnection Connection = new OracleConnection(AppConfiguration.DbConnectionString);
        //OracleDataAdapter adapter = new OracleDataAdapter(sql, Connection);

        //try
        //{
        //    adapter.Fill(Table);
        //}

        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //    Connection.Close();
        //}
        return Table;
    }

    public string GenerateUpdateQuery(DataTable Table)
    {
        int i = 0;
        string tempstr = "";
        int temp_index = -1;

        //string TableName = (string)Session["TableSelected"];
        string Query = "";
        //Query = "Update  " + TableName + " set ";
        Query = "Update  PMIS_KPI SET ";

        for (i = 0; i < Table.Columns.Count; i++)
        {
            switch (Table.Columns[i].DataType.Name)
            {

                case "Boolean":
                case "Int32":
                case "Byte":
                case "Decimal":
                    if ((string)ParameterArray[i] == "True")
                        ParameterArray[i] = "1";
                    else if ((string)ParameterArray[i] == "False")
                        ParameterArray[i] = "0";

                    if (i == Table.Columns.Count - 1)
                        Query = Query + Table.Columns[i].ColumnName + "=" + ParameterArray[i];
                    else
                        Query = Query + Table.Columns[i].ColumnName + "=" + ParameterArray[i] + ", ";

                    break;
                case "String":
                case "DateTime":
                    if (((string)ParameterArray[i]).Contains("'"))
                    {
                        tempstr = ((string)ParameterArray[i]);
                        ParameterArray[i] = ((string)ParameterArray[i]).Replace("'", "''");
                        temp_index = i;
                    }

                    if (i == Table.Columns.Count - 1)
                        Query = Query + Table.Columns[i].ColumnName + "='" + ParameterArray[i] + "' ";
                    else
                        Query = Query + Table.Columns[i].ColumnName + "='" + ParameterArray[i] + "', ";
                    break;

            }
        }
        if (temp_index > -1)
            ParameterArray[temp_index] = tempstr;
        if (Table.Columns[0].DataType.Name == "String" || Table.Columns[0].DataType.Name == "DateTime")
            Query = Query + " where " + Table.Columns[0].ColumnName + " = '" + ParameterArray[0] + "'";
        else
            Query = Query + " where " + Table.Columns[0].ColumnName + " = " + ParameterArray[0];

        return Query;
    }

    public string GenerateInsertQuery(DataTable Table)
    {
        int i = 0;
        string tempstr = "";
        int temp_index = -1;

        //string TableName = (string)Session["TableSelected"];
        string Query = "";
        Query = "Insert into  PMIS_KPI (";

        for (i = 0; i < Table.Columns.Count; i++)
        {
            if (i == Table.Columns.Count - 1)
                Query = Query + Table.Columns[i].ColumnName;
            else
                Query = Query + Table.Columns[i].ColumnName + ", ";

        }
        Query = Query + ")" + "Values (";
        for (i = 0; i < Table.Columns.Count; i++)
        {
            switch (Table.Columns[i].DataType.Name)
            {

                case "Boolean":
                case "Int32":
                case "Byte":
                case "Decimal":
                    if ((string)ParameterArray[i] == "True")
                        ParameterArray[i] = "1";
                    else if ((string)ParameterArray[i] == "False")
                        ParameterArray[i] = "0";

                    if (i == Table.Columns.Count - 1)
                        Query = Query + ParameterArray[i];
                    else
                        Query = Query + ParameterArray[i] + ", ";

                    break;
                case "String":
                case "DateTime":
                    if (((string)ParameterArray[i]).Contains("'"))
                    {
                        tempstr = ((string)ParameterArray[i]);
                        ParameterArray[i] = ((string)ParameterArray[i]).Replace("'", "''");
                        temp_index = i;
                    }
                    if (i == Table.Columns.Count - 1)
                        Query = Query + "'" + ParameterArray[i] + "' ";
                    else
                        Query = Query + "'" + ParameterArray[i] + "', ";
                    break;
            }
        }
        Query = Query + ")";

        return Query;
    }

    public string GenerateDeleteQuery(int index, DataTable Table)
    {
        //string TableName = (string)Session["TableSelected"];
        string query = "";
        if (Table.Columns[0].DataType.Name == "String" || Table.Columns[0].DataType.Name == "DateTime")
            query = "Delete from PMIS_KPI where " + Table.Columns[0].ColumnName + "='" + Table.Rows[index][0].ToString() + "'";
        else
            query = "Delete from PMIS_KPI where " + Table.Columns[0].ColumnName + "=" + Table.Rows[index][0].ToString();

        return query;
    }
}
