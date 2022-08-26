using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedure
/// </summary>
public class StoredProcedureCommon
{
    public StoredProcedureCommon()
	{
		//
		// 
		//
	}

    public static string getDepartments()
    {
        string sql = "SELECT IDDEPARTMENT, DEPARTMENT FROM COMMON_DEPARTMENT";
        return sql;
    }
    


    public static string getDepartmentById()
    {
        string sql = "SELECT IDDEPARTMENT, DEPARTMENT FROM COMMON_DEPARTMENT WHERE IDDEPARTMENT = :iDeptId";
        return sql;
    }

    
}