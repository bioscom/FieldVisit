using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BIReviewers
/// </summary>
public class BIReviewers
{
    public int m_iUserId { get; set; }
    public int m_iReviewId { get; set; }
    public int m_iBICR { get; set; }

    public BIReviewers()
    {
        //
        // 
        //
    }

    public BIReviewers(DataRow dr)
    {
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_iReviewId = int.Parse(dr["IDREVIEWER"].ToString());
        m_iBICR = int.Parse(dr["BICR"].ToString());
    }
}