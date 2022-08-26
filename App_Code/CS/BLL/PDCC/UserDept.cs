using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDept
/// </summary>
public class UserDept
{
    Department oDepartment = new Department();
    public int iDept { get; set; }
    public int iUserId { get; set; }

    public UserDept()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public UserDept(DataRow dr)
    {
        iDept = int.Parse(dr["IDDEPARTMENT"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}