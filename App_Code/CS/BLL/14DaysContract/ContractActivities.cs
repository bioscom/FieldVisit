using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Activities
/// </summary>
public class ContractActivities
{
    public int iActivitiesId { get; set; }
    public int iSubActivitiesId { get; set; }
    public int iPriorityId { get; set; }
    public string sActivity { get; set; }
    public int iSequence { get; set; }
    public int iBit { get; set; }
    public int iBitCalc { get; set; }
    public string sMeasures { get; set; }
    public decimal dTripTarget { get; set; }

    public ContractActivities()
    {
        //
        // 
        //
    }

    public ContractActivities(DataRow dr)
    {
        iActivitiesId = int.Parse(dr["IDACTIVITIES"].ToString());
        iSubActivitiesId = string.IsNullOrEmpty(dr["IDSUBACTIVITIES"].ToString()) ? 0 : int.Parse(dr["IDSUBACTIVITIES"].ToString());
        iPriorityId = int.Parse(dr["IDPRIORITY"].ToString());
        sActivity = dr["ACTIVITY"].ToString();
        iSequence = int.Parse(dr["ISEQUENCE"].ToString());
        iBit = int.Parse(dr["IBIT"].ToString());
        iBitCalc = int.Parse(dr["IBITCALC"].ToString());
        sMeasures = dr["MEASURES"].ToString();
        dTripTarget = string.IsNullOrEmpty(dr["TARGET"].ToString()) ? 0 : decimal.Parse(dr["TARGET"].ToString());
    }
}