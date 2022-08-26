using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BusinessLeanFocalPoints
/// </summary>
public class BusinessLeanFocalPoints
{
    public int m_iUserId { get; set; }
    public int m_iFunctionId { get; set; }
    public int m_iFocalPointId { get; set; }

	public BusinessLeanFocalPoints()
	{
		//
		// 
		//
	}

    public BusinessLeanFocalPoints(DataRow dr)
    {
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());
        m_iFocalPointId = int.Parse(dr["IDFOCALPOINT"].ToString());
    }
}