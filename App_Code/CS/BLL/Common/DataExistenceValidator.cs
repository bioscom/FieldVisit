﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for DataExistenceValidator
/// </summary>
public class DataExistenceValidator
{
	public DataExistenceValidator()
	{

    }

    public bool bValidateDataEntry(string paraMeter, string fieldName, string tableName)
    {

        bool DataExists = false;
        try
        {
            string sql = "SELECT * FROM @TABLENAME WHERE UPPER(@FIELDNAME) = " + "'@PARAMETER'";
            sql = sql.Replace("@TABLENAME", tableName);
            sql = sql.Replace("@FIELDNAME", fieldName);
            sql = sql.Replace("@PARAMETER", paraMeter.ToUpper().Trim());

            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sql;

            DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);

            if (dt.Rows.Count > 0)
            {
                DataExists = true;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return DataExists;
    }
}
