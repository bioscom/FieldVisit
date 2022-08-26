using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for ActivityInfo
/// </summary>
public class ActivityInfo
{
    public long m_lActivityId { get; set; }
    public int m_iActivityTypeId { get; set; }
    public int m_iFacilityId { get; set; }
    public string m_sActivityDescription { get; set; }
    public string m_sJustification { get; set; }
    public int m_iUserId { get; set; }
    public string m_sActivityId { get; set; }
    public DateTime m_sDateSubmitted { get; set; }
    public string m_sLocation { get; set; }
    public int m_iNoOfBeds { get; set; }
    public DateTime m_sFirstNight { get; set; }
    public DateTime m_sLastNight { get; set; }
    public string m_sACTIVITY_CAUSE_OIL_DEFRMNT { get; set; }
    public string m_sVolume { get; set; }
    public int m_iUnit { get; set; }
    public int m_iStatus { get; set; }
    public int m_iComplete { get; set; } //This is used to keep the last status of any activity before deleted. and it is used to undelete any activity

    public appUsers eInitiator
    {
        get
        {
            return appUsersHelper.objGetOnlineUserByUserId(m_iUserId);
        }
    }

    public facility eFacility
    {
        get
        {
            return facility.objGetFacilityById(m_iFacilityId);
        }
    }

    public Units eUnit
    {
        get
        {
            return Units.objGetUnitsById(m_iUnit);
        }
    }

    public ActivityType eActivityType
    {
        get
        {
            return ActivityType.objGetActivityTypeById(m_iActivityTypeId);
        }
    }

    public List<ActivityTimeLine> eActivityTimeLine
    {
        get
        {
            return ActivityTimeLine.lstGetActivityTimeLineByActivityId(m_lActivityId);
        }
    }

    public VendorCallOut eVendorCallOut
    {
        get
        {
            return VendorCallOut.objGetPersonnelInfoByActivityId(m_lActivityId);
        }
    }

    public List<VendorCallOut> eVendorsCallOut
    {
        get
        {
            return VendorCallOut.lstGetVendorCallOutByActivityId(m_lActivityId);
        }
    }

    public List<PersonnelInfo> ePersonnelInfo
    {
        get
        {
            return PersonnelInfo.lstGetPersonnelInfoByActivityId(m_lActivityId);
        }
    }

    public List<LocationFieldActivityInfo> eLocationFieldActivityInfo
    {
        get
        {
            return LocationFieldActivityInfo.lstGetLocationFieldByActivityId(m_lActivityId);
        }
    }

    public List<PECApprover> lstApprovers
    {
        get
        {
            return PECApprover.lstGetPECApproversByActivityId(m_lActivityId);
        }
    }

    public ActivityInfo()
    {

    }

    public ActivityInfo(DataRow dr)
    {
        m_lActivityId = int.Parse(dr["ID_ACTIVITYINFO"].ToString());
        m_iActivityTypeId = int.Parse(dr["ID_ACTIVITY_TYPE"].ToString());
        m_iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
        m_sActivityDescription = dr["ACTIVITYDESCRIPTION"].ToString();
        m_sJustification = dr["JUSTIFICATION"].ToString();
        m_iUserId = int.Parse(dr["USERID"].ToString());
        m_sActivityId = dr["ACTIVITYID"].ToString();
        m_sDateSubmitted = DateTime.Parse(dr["DATE_SUMBITTED"].ToString());
        m_sLocation = dr["FUNCTION_LOCATION"].ToString();
        m_iNoOfBeds = int.Parse(dr["NO_BEDS"].ToString());
        m_sFirstNight = DateTime.Parse(dr["FIRST_NIGHT"].ToString());
        m_sLastNight = DateTime.Parse(dr["LAST_NIGHT"].ToString());
        m_sACTIVITY_CAUSE_OIL_DEFRMNT = dr["ACTIVITY_CAUSE_OIL_DEFRMNT"].ToString();
        m_sVolume = dr["VOLUME"].ToString();
        m_iUnit = int.Parse(dr["ID_UNIT"].ToString());
        m_iStatus = int.Parse(dr["STATUS"].ToString());
        m_iComplete = int.Parse(dr["COMPLETE"].ToString());
    }

    public static int getActivityInfoId()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO_SEQ.NEXTVAL FROM DUAL";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        int activityInfoID = 0;
        try
        {
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
            activityInfoID = Convert.ToInt32(dt.Rows[0]["NEXTVAL"].ToString());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return activityInfoID;
    }

    public static DataTable dtGetActivityInfo()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getAllActivityInformation();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetActivityInfoByOriginator(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityInformationByOriginator();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetDeletedActivityInfoByOriginator(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityInformationByStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Deleted;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetMyApprovedPEC(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getMyApprovedPECs();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetMyApprovedPECRequests(int iUserId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getMyApprovedPECs(); //getActivityInformationByStatus();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int)Approval.apprStatusRpt.Approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":STAND";
        //param.Value = Approval.apprStatusRpt.Approved;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetActivityInfoByActivityId(long iActivityId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool bGetActivityInfoByActivityId(int iActivityId)
    {
        bool found = false;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getActivityByActivityId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        if (GenericDataAccess.ExecuteSelectCommand(comm).Rows.Count > 0)
        {
            found = true;
        }

        return found;
    }

    public static ActivityInfo objGetActivityInfoByActivityId(long iActivityId)
    {
        DataTable dt = dtGetActivityInfoByActivityId(iActivityId);

        ActivityInfo xRows = new ActivityInfo();
        foreach (DataRow dr in dt.Rows)
        {
            xRows = new ActivityInfo(dr);
        }
        return xRows;
    }

    public static List<ActivityInfo> lstGetActivityInfo()
    {
        DataTable dt = dtGetActivityInfo();

        List<ActivityInfo> xRows = new List<ActivityInfo>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new ActivityInfo(dr));
        }
        return xRows;
    }

    public static bool createActivityInfo(ActivityInfo oActivityInfo)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.createActivityInformation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = oActivityInfo.m_lActivityId; //iID_ACTIVITYINFO;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);
         
        param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITY_TYPE";
        param.Value = oActivityInfo.m_iActivityTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = oActivityInfo.eFacility.m_iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITYDESCRIPTION";
        param.Value = oActivityInfo.m_sActivityDescription; //sACTIVITYDESCRIPTION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":JUSTIFICATION";
        param.Value = oActivityInfo.m_sJustification;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = oActivityInfo.m_iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITYID";
        param.Value = oActivityInfo.m_sActivityId;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":DATE_SUMBITTED";
        param.Value = oActivityInfo.m_sDateSubmitted;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FUNCTION_LOCATION";
        param.Value = oActivityInfo.m_sLocation;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NO_BEDS";
        param.Value = oActivityInfo.m_iNoOfBeds;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FIRST_NIGHT";
        param.Value = oActivityInfo.m_sFirstNight;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":LAST_NIGHT";
        param.Value = oActivityInfo.m_sLastNight;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITY_CAUSE_OIL_DEFRMNT";
        param.Value = oActivityInfo.m_sACTIVITY_CAUSE_OIL_DEFRMNT;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":VOLUME";
        param.Value = oActivityInfo.m_sVolume;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_UNIT";
        param.Value = oActivityInfo.eUnit.m_iID_UNIT; //.m_iV_UNIT;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //, long iID_ACTIVITYINFO, int iACTIVITY_TYPE, int iFacility,
        //string sACTIVITYDESCRIPTION, string sJUSTIFICATION, int iUserId, string sACTIVITYID, 
        //string sDATE_SUMBITTED, string sFUNCTION_LOCATION, int iNO_BEDS, DateTime sFIRST_NIGHT, 
        //DateTime sLAST_NIGHT, string sACTIVITY_CAUSE_OIL_DEFRMNT, string sVOLUME, int iV_UNIT)

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

    public static bool updateActivityInfo(long iID_ACTIVITYINFO, int iACTIVITY_TYPE, int iFacility, string sACTIVITYDESCRIPTION, 
        string sJUSTIFICATION, int iUserId, string sFUNCTION_LOCATION, int iNO_BEDS, DateTime sFIRST_NIGHT, DateTime sLAST_NIGHT, 
        string sACTIVITY_CAUSE_OIL_DEFRMNT, string sVOLUME, int iV_UNIT)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.updateActivityInformation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iID_ACTIVITYINFO;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITY_TYPE";
        param.Value = iACTIVITY_TYPE;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_FACILITIES";
        param.Value = iFacility;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITYDESCRIPTION";
        param.Value = sACTIVITYDESCRIPTION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":JUSTIFICATION";
        param.Value = sJUSTIFICATION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":USERID";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FUNCTION_LOCATION";
        param.Value = sFUNCTION_LOCATION;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NO_BEDS";
        param.Value = iNO_BEDS;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":FIRST_NIGHT";
        param.Value = sFIRST_NIGHT;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":LAST_NIGHT";
        param.Value = sLAST_NIGHT;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ACTIVITY_CAUSE_OIL_DEFRMNT";
        param.Value = sACTIVITY_CAUSE_OIL_DEFRMNT;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":VOLUME";
        param.Value = sVOLUME;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":ID_UNIT";
        param.Value = iV_UNIT;
        param.DbType = DbType.Int32;
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

    public static bool deleteActivityInfo(Int64 iActivityInfoId, int iCurrentStatus)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.deleteActivityInformation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":LSTATUSB4DLT";
        param.Value = iCurrentStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = (int)Approval.apprStatusRpt.Deleted;
        param.DbType = DbType.Int32;
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

    public static bool UnDeleteActivityInfo(Int64 iActivityInfoId, int iStatusB4Deleted)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.UnDeleteActivityInformation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":STATUS";
        param.Value = iStatusB4Deleted;
        param.DbType = DbType.Int32;
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

    public static bool PurgeActivityInfo(Int64 iActivityInfoId)
    {
        return DeleteDependencies(iActivityInfoId);
    }

    public static bool purgeActivityInfo(Int64 iActivityInfoId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.purgeActivityInformation();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
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

    public static bool DeleteActivityTimeLineActivityInfo(Int64 iActivityInfoId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.DeleteActivityTimeLineByActivity();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
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

    public static bool DeleteApprovalByActivityInfo(Int64 iActivityInfoId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.DeletePECApprovalByActivity();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
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

    public static bool DeleteLocationFieldByActivityInfo(Int64 iActivityInfoId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.DeleteLocationFieldByActivity();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
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

    public static bool DeletePersonnelInfoByActivityInfo(Int64 iActivityInfoId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.DeletePersonnelByActivity();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
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

    public static bool DeleteVendorCallOutByActivityInfo(Int64 iActivityInfoId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.DeleteVendorCallOutByActivity();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":ID_ACTIVITYINFO";
        param.Value = iActivityInfoId;
        param.DbType = DbType.Int64;
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

    private static bool DeleteDependencies(Int64 iActivityInfo)
    {
        bool success = false;

        success = DeleteActivityTimeLineActivityInfo(iActivityInfo);
        if (success)
        {
            success = DeleteApprovalByActivityInfo(iActivityInfo);
            if (success)
            {
                success = DeleteLocationFieldByActivityInfo(iActivityInfo);
                if (success)
                {
                    success = DeletePersonnelInfoByActivityInfo(iActivityInfo);
                    if (success)
                    {
                        success = DeleteVendorCallOutByActivityInfo(iActivityInfo);
                        if (success)
                        {
                            success = purgeActivityInfo(iActivityInfo);
                            if (success)
                            {
                                success = true;
                            }
                            else
                            {
                                success = false;
                            }
                        }
                        else
                        {
                            success = false;
                        }
                    }
                    else
                    {
                        success = false;
                    }
                }
                else
                {
                    success = false;
                }
            }
            else
            {
                success = false;
            }
        }
        else
        {
            success = false;
        }
        return success;
    }
}
