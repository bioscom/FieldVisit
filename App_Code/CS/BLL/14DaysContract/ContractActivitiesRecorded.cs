using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ContractActivitiesRecorded
/// </summary>
public class ContractActivitiesRecorded
{
    public long lFourteenDayId { get; set; }
    public int iDistrictId { get; set; }
    public Nullable<decimal> dTarget { get; set; }
    public Nullable<decimal> dActual { get; set; } 
    public Nullable<decimal> dDay1 { get; set; }
    public Nullable<decimal> dDay2 { get; set; }
    public Nullable<decimal> dDay3 { get; set; }
    public Nullable<decimal> dDay4 { get; set; }
    public Nullable<decimal> dDay5 { get; set; }
    public Nullable<decimal> dDay6 { get; set; }
    public Nullable<decimal> dDay7 { get; set; }
    public Nullable<decimal> dDay8 { get; set; }
    public Nullable<decimal> dDay9 { get; set; }
    public Nullable<decimal> dDay10 { get; set; }
    public Nullable<decimal> dDay11 { get; set; }
    public Nullable<decimal> dDay12 { get; set; }
    public Nullable<decimal> dDay13 { get; set; }
    public Nullable<decimal> dDay14 { get; set; }
    public DateTime dtTripStartDate { get; set; }
    public int iUserId { get; set; }
    public int iActivityId { get; set; }

	public ContractActivitiesRecorded()
	{
		//
		// 
		//
	}

    public ContractActivitiesRecorded(DataRow dr)
    {
        lFourteenDayId = int.Parse(dr["IDFOURTEEN"].ToString());
        iDistrictId = int.Parse(dr["ID_DISTRICT"].ToString());

        dTarget = string.IsNullOrEmpty(dr["TARGET"].ToString()) ? 0 : decimal.Parse(dr["TARGET"].ToString()); //decimal.Parse(dr["TARGET"].ToString());
        dActual = string.IsNullOrEmpty(dr["ACTUAL"].ToString()) ? 0 : decimal.Parse(dr["ACTUAL"].ToString()); //decimal.Parse(dr["ACTUAL"].ToString());
        //iSubActivitiesId = string.IsNullOrEmpty(dr["IDSUBACTIVITIES"].ToString()) ? 0 : int.Parse(dr["IDSUBACTIVITIES"].ToString());
        dDay1 = string.IsNullOrEmpty(dr["DAY1"].ToString()) ? 0 : decimal.Parse(dr["DAY1"].ToString());
        dDay2 = string.IsNullOrEmpty(dr["DAY2"].ToString()) ? 0 : decimal.Parse(dr["DAY2"].ToString());
        dDay3 = string.IsNullOrEmpty(dr["DAY3"].ToString()) ? 0 : decimal.Parse(dr["DAY3"].ToString());
        dDay4 = string.IsNullOrEmpty(dr["DAY4"].ToString()) ? 0 : decimal.Parse(dr["DAY4"].ToString());
        dDay5 = string.IsNullOrEmpty(dr["DAY5"].ToString()) ? 0 : decimal.Parse(dr["DAY5"].ToString());
        dDay6 = string.IsNullOrEmpty(dr["DAY6"].ToString()) ? 0 : decimal.Parse(dr["DAY6"].ToString());
        dDay7 = string.IsNullOrEmpty(dr["DAY7"].ToString()) ? 0 : decimal.Parse(dr["DAY7"].ToString());
        dDay8 = string.IsNullOrEmpty(dr["DAY8"].ToString()) ? 0 : decimal.Parse(dr["DAY8"].ToString());
        dDay9 = string.IsNullOrEmpty(dr["DAY9"].ToString()) ? 0 : decimal.Parse(dr["DAY9"].ToString());
        dDay10 = string.IsNullOrEmpty(dr["DAY10"].ToString()) ? 0 : decimal.Parse(dr["DAY10"].ToString());
        dDay11 = string.IsNullOrEmpty(dr["DAY11"].ToString()) ? 0 : decimal.Parse(dr["DAY11"].ToString());
        dDay12 = string.IsNullOrEmpty(dr["DAY12"].ToString()) ? 0 : decimal.Parse(dr["DAY12"].ToString());
        dDay13 = string.IsNullOrEmpty(dr["DAY13"].ToString()) ? 0 : decimal.Parse(dr["DAY13"].ToString());
        dDay14 = string.IsNullOrEmpty(dr["DAY14"].ToString()) ? 0 : decimal.Parse(dr["DAY14"].ToString());

        dtTripStartDate = DateTime.Parse(dr["START_DATE"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
        iActivityId = int.Parse(dr["IDACTIVITIES"].ToString());
    }
}