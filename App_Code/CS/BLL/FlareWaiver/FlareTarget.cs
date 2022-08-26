using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for FlareTarget
/// </summary>
/// 


public class MidDay
{
    public int iMonitorId { get; set; }
    public DateTime dMidDay { get; set; }

    public MidDay()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public MidDay(DataRow dr)
    {
        iMonitorId = int.Parse(dr["MONITORID"].ToString());
        dMidDay = DateTime.Parse(dr["MID_DAY"].ToString());
    }

    public static bool Update(MidDay o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateMidDay();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dDate";
        param.Value = DateTime.Now;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public static DataTable dtGetMidDay()
    {
        OracleCommand comm = GenericDataAccess.ECCreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getMidDay();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static MidDay objGetMidDay()
    {
        DataTable dt = dtGetMidDay();

        MidDay o = new MidDay();
        foreach (DataRow dr in dt.Rows)
        {
            o = new MidDay(dr);
        }
        return o;
    }

}

public class mFlareTarget
{
    public long lTargetId { get; set; }
    public int iFacilityId { get; set; }
    public int iYear { get; set; }
    public decimal iMonth { get; set; }


    public mFlareTarget()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public mFlareTarget(DataRow dr, string mMonth)
    {
        lTargetId = long.Parse(dr["TARGETID"].ToString());
        iFacilityId = int.Parse(dr["IDFACILITY"].ToString());
        iYear = int.Parse(dr["IYEAR"].ToString());
        iMonth = decimal.Parse(dr[mMonth].ToString());
    }
}


public class FlareTarget
{
    public long lTargetId { get; set; }
    public int iFacilityId { get; set; }
    public int iYear { get; set; }
    public decimal iJan { get; set; }
    public decimal iFeb { get; set; }
    public decimal iMar { get; set; }
    public decimal iApr { get; set; }
    public decimal iMay { get; set; }
    public decimal iJun { get; set; }
    public decimal iJul { get; set; }
    public decimal iAug { get; set; }
    public decimal iSep { get; set; }
    public decimal iOct { get; set; }
    public decimal iNov { get; set; }
    public decimal iDec { get; set; }
    public decimal iYTD { get; set; }


    public FlareTarget()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public FlareTarget(DataRow dr)
    {
        lTargetId = long.Parse(dr["TARGETID"].ToString());
        iFacilityId = int.Parse(dr["IDFACILITY"].ToString());
        iYear = int.Parse(dr["IYEAR"].ToString());
        iJan = decimal.Parse(dr["JAN"].ToString());
        iFeb = decimal.Parse(dr["FEB"].ToString());
        iMar = decimal.Parse(dr["MAR"].ToString());
        iApr = decimal.Parse(dr["APR"].ToString());
        iMay = decimal.Parse(dr["MAY"].ToString());
        iJun = decimal.Parse(dr["JUN"].ToString());
        iJul = decimal.Parse(dr["JUL"].ToString());
        iAug = decimal.Parse(dr["AUG"].ToString());
        iSep = decimal.Parse(dr["SEP"].ToString());
        iOct = decimal.Parse(dr["OCT"].ToString());
        iNov = decimal.Parse(dr["NOV"].ToString());
        iDec = decimal.Parse(dr["DECB"].ToString());
        iYTD = decimal.Parse(dr["YTD"].ToString());
    }
}



public class EnergyComponent
{
    public string FacilityKey { get; set; }
    public DateTime ProductionDay { get; set; }
    public string Code { get; set; }
    public string StreamCategory { get; set; }
    public decimal SI { get; set; }
    public decimal API { get; set; }
    public string MQI { get; set; }

    public EnergyComponent()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public EnergyComponent(DataRow dr)
    {
        FacilityKey = dr["FacilityKey"].ToString();
        ProductionDay = string.IsNullOrEmpty(dr["PRODUCTION_DAY"].ToString()) ? DateTime.Now.Date : DateTime.Parse(dr["PRODUCTION_DAY"].ToString());
        Code = dr["CODE"].ToString();
        StreamCategory = dr["STREAM_CATEGORY"].ToString();
        SI = string.IsNullOrEmpty(dr["SI"].ToString()) ? 0: decimal.Parse(dr["SI"].ToString());
        API = string.IsNullOrEmpty(dr["API"].ToString()) ? 0: decimal.Parse(dr["API"].ToString());
        MQI = dr["MQI"].ToString();
    }
}

public class FlareTargetHelper
{
    public static DataTable dtGetYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getYearFlareTarget();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<int> lstYears()
    {
        DataTable dt = dtGetYear();
        List<int> oYears = new List<int>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            oYears.Add(int.Parse(dr["IYEAR"].ToString()));
        }

        return oYears;
    }



    public bool Insert(FlareTarget o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.InsertFlareTarget();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = o.iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = o.iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iJan";
        param.Value = o.iJan;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFeb";
        param.Value = o.iFeb;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMar";
        param.Value = o.iMar;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iApr";
        param.Value = o.iApr;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMay";
        param.Value = o.iMay;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iJun";
        param.Value = o.iJun;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iJul";
        param.Value = o.iJul;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAug";
        param.Value = o.iAug;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSep";
        param.Value = o.iSep;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOct";
        param.Value = o.iOct;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iNov";
        param.Value = o.iNov;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDec";
        param.Value = o.iDec;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYtd";
        param.Value = o.iYTD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool Update(FlareTarget o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.UpdateFlareTarget();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lTargetId";
        param.Value = o.lTargetId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = o.iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iJan";
        param.Value = o.iJan;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFeb";
        param.Value = o.iFeb;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMar";
        param.Value = o.iMar;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iApr";
        param.Value = o.iApr;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMay";
        param.Value = o.iMay;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iJun";
        param.Value = o.iJun;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iJul";
        param.Value = o.iJul;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAug";
        param.Value = o.iAug;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSep";
        param.Value = o.iSep;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOct";
        param.Value = o.iOct;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iNov";
        param.Value = o.iNov;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iDec";
        param.Value = o.iDec;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYtd";
        param.Value = o.iYTD;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public DataTable dtGetFlareTarget(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.GetFlareTargetByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareTargetByYear(int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareTargetByYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareTargetByMonthYear(string sMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareTargetByMonthYear(sMonth);

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear2";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iStatus";
        //param.Value = (int)RequestStatusReporter.RequestStatusRpt.Approved;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);

        return dt;
    }

    public DataTable dtGetFlareTargetByTargetId(long lTargetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareTargetByTargetId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lTargetId";
        param.Value = lTargetId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetFlareTargetByFacilityId(int iFacilityId, string sMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareTargetByFacilityId(sMonth);

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);

        return dt;
    }

    public DataTable dtGetFlareAnnualTargetByFacilityId(int iFacilityId, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureFlareWaiver.getFlareAnnualTargetByFacilityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);

        return dt;
    }

    public FlareTarget objGetFlareAnnualTargetByFacilityId(int iFacilityId, int iYear)
    {
        DataTable dt = dtGetFlareAnnualTargetByFacilityId(iFacilityId, iYear);

        FlareTarget o = new FlareTarget();
        foreach (DataRow dr in dt.Rows)
        {
            o = new FlareTarget(dr);
        }
        return o;
    }

    public FlareTarget objGetFlareTargetByTargetId(long lTargetId)
    {
        DataTable dt = dtGetFlareTargetByTargetId(lTargetId);

        FlareTarget o = new FlareTarget();
        foreach (DataRow dr in dt.Rows)
        {
            o = new FlareTarget(dr);
        }
        return o;
    }

    public mFlareTarget objGetFlareTargetByFacilityId(int iFacilityId, string sMonth, int iYear)
    {
        DataTable dt = dtGetFlareTargetByFacilityId(iFacilityId, sMonth, iYear);

        mFlareTarget o = new mFlareTarget();
        foreach (DataRow dr in dt.Rows)
        {
            o = new mFlareTarget(dr, sMonth);
        }
        return o;
    }


    public void GasFlareViolationAlert(int iYear, string sMonth, int iMonth, int iDay)
    {
        FlareTargetHelper oFt = new FlareTargetHelper();
        FlareWaiverRequestHelper oReq = new FlareWaiverRequestHelper();

        try
        {
            List<Facility> lstFacilities = Facility.lstGetFacilities();
            foreach (Facility o in lstFacilities)
            {
                if (!string.IsNullOrEmpty(o.m_sCode))
                {
                    mFlareTarget oT = oFt.objGetFlareTargetByFacilityId(o.m_iFacilityId, sMonth, iYear);
                    EnergyComponent oE = oReq.objGetDailyFlaredGasFromEC(iDay, iMonth, iYear, o.m_sCode);

                    if (oE.SI > oT.iMonth)
                    {
                        //Send Mail to selected people, about Gas flaring violation
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }


    public void SendAlert()
    {
        MidDay m = MidDay.objGetMidDay();
        TimeSpan start = TimeSpan.Parse(m.dMidDay.ToString());
        TimeSpan end = new TimeSpan(12, 0, 0);

        if (start == end)
        {
            GasFlareViolationAlert(DateTime.Now.Year, mMonthEnuem.getMonth(DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Day);

            //m.MidDay = 
            //MidDay.Update()
        }
    }
}