using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for _14DayContractOwnership
/// </summary>
public class _14DayContractOwnership
{
    public int m_iOwnershipId { get; set; }
    public int m_iForteenId { get; set; }
    public int m_iYear { get; set; }
    public string m_sTripStart { get; set; }
    public string m_sDateRaised { get; set; }
    public int m_iUserId { get; set; }
    public int m_iUserOpsSup { get; set; }
    public int m_iUserOpsMgr { get; set; }
    public int m_iStatus { get; set; }

    public _14DayContractOwnership()
    {
        //
        // 
        //
    }

    public _14DayContractOwnership(DataRow dr)
    {
        m_iForteenId = int.Parse(dr["IDFOURTEEN"].ToString());
        m_iYear = int.Parse(dr["YYEAR"].ToString());
        m_sTripStart = dr["TRIP_START"].ToString();
        m_sDateRaised = dr["DATE_RAISED"].ToString();
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_iUserOpsSup = int.Parse(dr["USERIDOPSSUP"].ToString());
        m_iUserOpsMgr = int.Parse(dr["USERIDOPSMGR"].ToString());
        m_iStatus = int.Parse(dr["STATUS"].ToString());
    }

    //    SELECT IDOWNERSHIP, IDFOURTEEN, TRIP_START, USERIDOPSSUP, USERIDOPSMGR, USERID, DATE_RAISED
    //FROM CONTRACT_FOURTEENDAY_OWNERSHIP;
}

public class _14DayContractOwnershipHelper
{
    public _14DayContractOwnershipHelper(DataRow dr)
    {

    }
}