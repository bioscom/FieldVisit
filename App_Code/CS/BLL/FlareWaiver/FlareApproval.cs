using System.Data;

/// <summary>
/// Summary description for FlareApproval
/// </summary>
public class FlareApproval
{
    //Fields
    public long m_lApprovalId { get; set; }
    public long m_lRequestId { get; set; }
    public int m_iUserId { get; set; }
    public int m_iRoleIdFlr { get; set; }
    public int m_iStand { get; set; }
    public string m_sDateReceived { get; set; }
    public string m_sDateReviewed { get; set; }
    public string m_sComments { get; set; }

    public FlareApproval()
    {
        
    }

    public FlareApproval(DataRow dr)
    {
        m_lApprovalId = long.Parse(dr["IDAPPROVAL"].ToString());
        m_lRequestId = long.Parse(dr["IDREQUEST"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_iRoleIdFlr = int.Parse(dr["ROLEIDFLR"].ToString());
        m_iStand = int.Parse(dr["STAND"].ToString());
        m_sDateReceived = dr["DATE_RECEIVED"].ToString();
        m_sDateReviewed = dr["DATE_REVIEWED"].ToString();
        m_sComments = dr["COMMENTS"].ToString();
    }
}