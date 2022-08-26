using System;
using System.Data;

/// <summary>
///
/// </summary>

public class FlareWaiver
{
    public long m_lRequestId { get; set; }
    public int m_iUserId { get; set; }
    public int m_iStatus { get; set; }
    public int m_iCategoryId { get; set; }
    //public int m_iFacilityId { get; set; }
    public string m_sRequestNumber { get; set; }
    public DateTime? m_sDateCreated { get; set; }
    public DateTime? m_sStartDate { get; set; }
    public String m_sStartTime { get; set; }
    public DateTime? m_sEndDate { get; set; }
    public String m_sEndTime { get; set; }
    public decimal m_sFlareVol { get; set; }
    public decimal m_sOilProduced { get; set; }
    public string m_sReason { get; set; }
    public string m_sJustification { get; set; }
    public string m_sPostEvent { get; set; }
    public string m_sWorkOrder { get; set; }
    public int m_iInOutBusinessPlan { get; set; }

    //New Updates
    public int m_iGMApprovalUserId { get; set; }
    public string m_sDateApproved { get; set; }
    public string m_sNewEndDate { get; set; }

    public FlareWaiver()
    {

    }

    public FlareWaiver(DataRow dr)
    {
        m_lRequestId = long.Parse(dr["IDREQUEST"].ToString());
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_iStatus = int.Parse(dr["STATUS"].ToString());
        m_iCategoryId = int.Parse(dr["IDCATEGORY"].ToString());
        //m_iFacilityId = int.Parse(dr["IDFACILITY"].ToString());
        m_sRequestNumber = dr["REQUESTNO"].ToString();
        m_sDateCreated = DateTime.Parse(dr["DATE_CREATED"].ToString());
        m_sStartDate = DateTime.Parse(dr["START_DATE"].ToString());
        m_sStartTime = dr["START_TIME"].ToString();
        m_sEndTime = dr["END_TIME"].ToString();
        m_sFlareVol = decimal.Parse(dr["FLAREVOL"].ToString());
        m_sOilProduced = decimal.Parse(dr["OILPROD"].ToString());
        m_sReason = dr["REASON"].ToString();
        m_sJustification = dr["JUSTIFICATION"].ToString();
        m_sPostEvent = dr["POSTEVENT"].ToString();
        m_sWorkOrder = dr["WORKORDER"].ToString();
        m_iInOutBusinessPlan = !string.IsNullOrEmpty(dr["BPSTATUS"].ToString()) ? int.Parse(dr["BPSTATUS"].ToString()) : 0;

        //New Update
        m_iGMApprovalUserId = !string.IsNullOrEmpty(dr["IDGMAPPROVAL"].ToString()) ? int.Parse(dr["IDGMAPPROVAL"].ToString()) : 0;
        m_sDateApproved = dr["DATE_APPROVED"].ToString();
        m_sNewEndDate = dr["NEW_END_DATE"].ToString();
        m_sEndDate = DateTime.Parse(dr["END_DATE"].ToString());
    }
}