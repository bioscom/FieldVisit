using System;
using System.Data;
using System.Globalization;

/// <summary>
/// Summary description for BI500Approval
/// </summary>

public class BI500Approval
{
    //Fields
    public long m_lApprovalId { get; set; }
    public long m_lRequestId { get; set; }
    public int m_iUserId { get; set; }
    public int m_iRoleIdBI { get; set; }
    public int m_iStand { get; set; }
    public DateTime m_dDateReceived { get; set; }
    public DateTime m_dDateReviewed { get; set; }
    public string m_sComments { get; set; }

    public BI500Approval()
    {

    }

    public BI500Approval(DataRow dr)
    {
        m_lApprovalId = long.Parse(dr["IDAPPROVAL"].ToString());
        m_lRequestId = long.Parse(dr["IDREQUEST"].ToString());

        if (string.IsNullOrEmpty(dr["USERID"].ToString())) { m_iUserId = 0; }
        else m_iUserId = int.Parse(dr["USERID"].ToString());

        m_iRoleIdBI = int.Parse(dr["IDROLE"].ToString());
        m_iStand = int.Parse(dr["STAND"].ToString());
        m_dDateReceived = (dr["DATE_RECEIVED"] == DBNull.Value) ? DateTime.Today.Date : DateTime.Parse(dr["DATE_RECEIVED"].ToString(), CultureInfo.CurrentCulture);
        m_dDateReviewed = (dr["DATE_REVIEWED"] == DBNull.Value) ? DateTime.Today.Date : DateTime.Parse(dr["DATE_REVIEWED"].ToString(), CultureInfo.CurrentCulture); 
        //m_dDateReceived = (string.IsNullOrEmpty(dr["DATE_RECEIVED"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["DATE_RECEIVED"].ToString(), CultureInfo.CurrentCulture);
        //m_dDateReviewed = (string.IsNullOrEmpty(dr["DATE_REVIEWED"].ToString())) ? DateTime.Today.Date : DateTime.Parse(dr["DATE_REVIEWED"].ToString(), CultureInfo.CurrentCulture); 
        m_sComments = dr["COMMENTS"].ToString();
    }
}