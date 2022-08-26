using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Activity
/// </summary>
public class KPIS
{
    PriorityHelper oPriorityHelper = new PriorityHelper();

    public long m_lKpiId { get; set; }
    public int m_iPriorityId { get; set; }
    public int iOrder { get; set; }
    public string m_sActivity { get; set; }
    public string m_sMeasures { get; set; }

    public Priority ePriority { get; set; }

    public KPIS()
    {
        //
        // 
        //
    }

    public KPIS(DataRow dr)
    {
        m_lKpiId = long.Parse(dr["IDKPIS"].ToString());
        m_iPriorityId = int.Parse(dr["IDPRIORITY"].ToString());
        iOrder = int.Parse(dr["IORDER"].ToString());
        m_sActivity = dr["KPIS"].ToString();
        m_sMeasures = dr["MEASURES"].ToString();

        ePriority = oPriorityHelper.objGetPriorityById(m_iPriorityId);
    }
}


public class KPISHelper
{
    public KPISHelper()
    {
        //
        // 
        //
    }

    
}