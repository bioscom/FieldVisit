using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for VerificationHeatMap
/// </summary>
/// 


public class mVerificationEnuem
{
    public enum mVerification
    {
        NV = 1, Red = 2, Bronze = 3, Silver = 4, Gold = 5, NA = 6,
    };


    public static string VerificationDesc(mVerification eVerification)
    {
        string sRet = "NILL";
        try
        {
            switch (eVerification)
            {
                case mVerification.NV: sRet = "NV"; break;
                case mVerification.Red: sRet = "Red"; break;
                case mVerification.Bronze: sRet = "Bronze"; break;
                case mVerification.Silver: sRet = "Silver"; break;
                case mVerification.Gold: sRet = "Gold"; break;
                case mVerification.NA: sRet = "N/A"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}

public class VerificationYearMonth
{
    public int iYear { get; set; }
    public int iMonth { get; set; }

    public VerificationYearMonth()
    {

    }

    public VerificationYearMonth(DataRow dr)
    {
        iYear = int.Parse(dr["IYEAR"].ToString());
        iMonth = int.Parse(dr["IMONTH"].ToString());
    }
}


public class cVerificationHeatMap
{
    public long lIdVerification { get; set; }
    public int iFacilityId { get; set; }
    public int iStandardisedWork { get; set; }
    public int iGoSee { get; set; }
    public int iStructuredDay { get; set; }
    public int iMtceConsumables { get; set; }
    public int iMonth { get; set; }
    public int iYear { get; set; }
    public int iUserId { get; set; }
    public DateTime DateSubmitted { get; set; }

    public string sAssets { get; set; }
    public string sDistricts { get; set; }
    public string sFacilities { get; set; }

	public cVerificationHeatMap()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public cVerificationHeatMap(DataRow dr)
    {
        sAssets = dr["ASSETS"].ToString();
        sDistricts = dr["DISTRICT"].ToString();
        sFacilities = dr["FACILITIES"].ToString();

        lIdVerification = long.Parse(dr["IDVERIFICATION"].ToString());
        iFacilityId = int.Parse(dr["ID_FACILITIES"].ToString());
        iStandardisedWork = int.Parse(dr["STANDARDIZED_WORK"].ToString());
        iGoSee = int.Parse(dr["GO_SEE"].ToString());
        iStructuredDay = int.Parse(dr["STRUCTURED_DAY"].ToString());
        iMtceConsumables = int.Parse(dr["MTCE_CONSUMABLES"].ToString());
        iMonth = int.Parse(dr["IMONTH"].ToString());
        iYear = int.Parse(dr["IYEAR"].ToString());
        iUserId = int.Parse(dr["USERID"].ToString());
        DateSubmitted = DateTime.Parse(dr["DATESUBMITTED"].ToString());
    }
}

public class cVerificationHeatMapHelper
{
    public cVerificationHeatMapHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable dtGetYear()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getYearVerificationHeatMap();

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

    public static void getMonths(DropDownList ddlMonth)
    {
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.jan), ((int)mMonthEnuem.mMonth.jan).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.feb), ((int)mMonthEnuem.mMonth.feb).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.mar), ((int)mMonthEnuem.mMonth.mar).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.apr), ((int)mMonthEnuem.mMonth.apr).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.may), ((int)mMonthEnuem.mMonth.may).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.jun), ((int)mMonthEnuem.mMonth.jun).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.jul), ((int)mMonthEnuem.mMonth.jul).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.aug), ((int)mMonthEnuem.mMonth.aug).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.sep), ((int)mMonthEnuem.mMonth.sep).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.oct), ((int)mMonthEnuem.mMonth.oct).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.nov), ((int)mMonthEnuem.mMonth.nov).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthDesc(mMonthEnuem.mMonth.dec), ((int)mMonthEnuem.mMonth.dec).ToString()));
    }

    public static void getMonths2(DropDownList ddlMonth)
    {
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.jan), ((int)mMonthEnuem.mMonth.jan).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.feb), ((int)mMonthEnuem.mMonth.feb).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.mar), ((int)mMonthEnuem.mMonth.mar).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.apr), ((int)mMonthEnuem.mMonth.apr).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.may), ((int)mMonthEnuem.mMonth.may).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.jun), ((int)mMonthEnuem.mMonth.jun).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.jul), ((int)mMonthEnuem.mMonth.jul).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.aug), ((int)mMonthEnuem.mMonth.aug).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.sep), ((int)mMonthEnuem.mMonth.sep).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.oct), ((int)mMonthEnuem.mMonth.oct).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.nov), ((int)mMonthEnuem.mMonth.nov).ToString()));
        ddlMonth.Items.Add(new ListItem(mMonthEnuem.monthOtherDesc(mMonthEnuem.mMonth.dec), ((int)mMonthEnuem.mMonth.dec).ToString()));
    }

    //;

    public static DataTable dtGetVerification()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVerification();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<VerificationYearMonth> lstGetVerification()
    {
        DataTable dt = dtGetVerification();

        List<VerificationYearMonth> lstVerifications = new List<VerificationYearMonth>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstVerifications.Add(new VerificationYearMonth(dr));
        }
        return lstVerifications;
    }

    public static DataTable dtGetVerificationByMonthYear(int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVerificationHeatMapByMonthYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetVerificationByMonthYearAsset(int iMonth, int iYear, int iAssetId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVerificationHeatMapByMonthYearAsset();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = iAssetId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetVerificationByMonthYear(int iFacility, int iMonth, int iYear)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getVerificationHeatMapByFacilityMonthYear();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = iYear;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacility";
        param.Value = iFacility;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<cVerificationHeatMap> lstGetVerificationByMonthYear(int iMonth, int iYear)
    {
        DataTable dt = dtGetVerificationByMonthYear(iMonth, iYear);

        List<cVerificationHeatMap> lstVerifications = new List<cVerificationHeatMap>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstVerifications.Add(new cVerificationHeatMap(dr));
        }
        return lstVerifications;
    }

    public static List<cVerificationHeatMap> lstGetVerificationByMonthYearAsset(int iMonth, int iYear, int iAssetId)
    {
        DataTable dt = dtGetVerificationByMonthYearAsset(iMonth, iYear, iAssetId);

        List<cVerificationHeatMap> lstVerifications = new List<cVerificationHeatMap>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lstVerifications.Add(new cVerificationHeatMap(dr));
        }
        return lstVerifications;
    }

    public static cVerificationHeatMap objGetVerificationByMonthYear(int iFacility, int iMonth, int iYear)
    {
        DataTable dt = dtGetVerificationByMonthYear(iFacility, iMonth, iYear);

        cVerificationHeatMap oVerification = new cVerificationHeatMap();
        foreach (DataRow dr in dt.Rows)
        {
            oVerification = new cVerificationHeatMap(dr);
        }
        return oVerification;
    }

    public static bool Insert(cVerificationHeatMap oVerification)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.insertVerification();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sDateSubmitted";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oVerification.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = oVerification.iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStandardisedWork";
        param.Value = oVerification.iStandardisedWork;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iGoSee";
        param.Value = oVerification.iGoSee;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
         
        param = comm.CreateParameter();
        param.ParameterName = ":iStructuredDay";
        param.Value = oVerification.iStructuredDay;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMtceConsumables";
        param.Value = oVerification.iMtceConsumables;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oVerification.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oVerification.iYear;
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

    public static bool Update(cVerificationHeatMap oVerification)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.UpdateVerification();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sDateSubmitted";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lIdVerification";
        param.Value = oVerification.lIdVerification ;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oVerification.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = oVerification.iFacilityId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStandardisedWork";
        param.Value = oVerification.iStandardisedWork;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iGoSee";
        param.Value = oVerification.iGoSee;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStructuredDay";
        param.Value = oVerification.iStructuredDay;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMtceConsumables";
        param.Value = oVerification.iMtceConsumables;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iMonth";
        param.Value = oVerification.iMonth;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iYear";
        param.Value = oVerification.iYear;
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

}