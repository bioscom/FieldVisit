using System;
using System.Data;

/// <summary>
/// Summary description for appUsers
/// </summary>
public class appUsers
{
    public int m_iUserId { get; set; }
    public string m_sUserName { get; set; }
    public string m_sUserMail { get; set; }
    public string m_sFullName { get; set; }
    public string m_sRefInd { get; set; }
    public int m_sStatus { get; set; }
    public DateTime m_dLoginTime = DateTime.Now;
    public bool m_bIsGuestAcct = true;
    public string m_sPassword { get; set; }
    public int m_iCostSavingAbsVal { get; set; }

    public int m_iStatus { get; set; }
    public int m_iDeligate { get; set; }

    public int? m_iRoleIdFieldVisit { get; set; }
    public int? m_iRoleIdLean { get; set; }
    public int? m_iRoleIdBI { get; set; }
    public int? m_iRoleIdManHr { get; set; }
    public int? m_iRoleIdContract { get; set; }
    public int? m_iRoleIdFlr { get; set; }
    public int? m_iRolePdcc { get; set; }
    public DateTime m_dtLastVisit { get; set; }

    public appUsers()
    {

    }

    public appUsers(DataRow dr)
    {
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_sUserName = dr["USERNAME"].ToString();
        m_sUserMail = dr["EMAIL"].ToString();
        m_sFullName = dr["FULLNAME"].ToString();
        m_sRefInd = dr["REFIND"].ToString();

        m_sStatus = int.Parse(dr["STATUS"].ToString());
        m_sPassword = dr["PASSWORD"].ToString();
        m_iStatus = int.Parse(dr["STATUS"].ToString());
        m_iDeligate = int.Parse(dr["DELIGATED"].ToString());

        m_iRoleIdFieldVisit = (dr["ROLEID"] == DBNull.Value) ? 0 : int.Parse(dr["ROLEID"].ToString());
        m_iRoleIdLean = (dr["ROLEIDLEAN"] == DBNull.Value) ? 0 : int.Parse(dr["ROLEIDLEAN"].ToString());
        m_iRoleIdBI = (dr["ROLEIDBI"] == DBNull.Value) ? 0 : int.Parse(dr["ROLEIDBI"].ToString());
        m_iRoleIdManHr = (dr["ROLEIDMANHR"] == DBNull.Value) ? 0 : int.Parse(dr["ROLEIDMANHR"].ToString());
        m_iRoleIdContract = (dr["ROLEIDCONTRACT"] == DBNull.Value) ? 0 : int.Parse(dr["ROLEIDCONTRACT"].ToString());
        m_iRoleIdFlr = (dr["ROLEIDFLR"] == DBNull.Value) ? 0 : int.Parse(dr["ROLEIDFLR"].ToString());
        m_iRolePdcc = (dr["ROLEIDPDCC"] == DBNull.Value) ? 0 : int.Parse(dr["ROLEIDPDCC"].ToString());
        m_iCostSavingAbsVal = int.Parse(dr["COSTSAVINGABSVAL"].ToString());
        m_dtLastVisit = (dr["LASTVISIT"] == DBNull.Value) ? DateTime.Now.Date : DateTime.Parse(dr["LASTVISIT"].ToString());
    }

    public structUserMailIdx structUserIdx
    {
        get
        {
            return new structUserMailIdx(m_sFullName, m_sUserMail, m_sUserName);
        }
    }
}
