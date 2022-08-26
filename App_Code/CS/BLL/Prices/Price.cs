using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.IO;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Price
/// </summary>
/// 

public class ReviewStatus
{
    public ReviewStatus()
    {
        //
        // 
        //
    }

    public enum RevStatus
    {
        PendingReview = 0,
        Yes = 1,
        No = 2,
    };

    public static string status(RevStatus eRevStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eRevStatus)
            {
                case RevStatus.PendingReview: sRet = "Not Started"; break;
                case RevStatus.Yes: sRet = "Yes"; break;
                case RevStatus.No: sRet = "No"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}

public class DiscrepancyStatus
{
    public DiscrepancyStatus()
    {

    }

    public enum ReviewStatus
    {
        PendingReview = 0,
        ClosedOut = 1,
        UnderGoingReview = 2,        
    };

    public static string DiscrepancyStatusDesc(ReviewStatus eReview)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eReview)
            {
                case ReviewStatus.PendingReview: sRet = "Pending Review"; break;
                case ReviewStatus.UnderGoingReview: sRet = "Reviewed"; break;
                case ReviewStatus.ClosedOut: sRet = "Closed Out"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}

public class Price
{
    public long lPriceId { get; set; }
    public string sPONumber { get; set; }
    public string sMaterialDescription { get; set; }
    public string sMaterialCode { get; set; }
    public decimal dPrice { get; set; }
    public decimal dShouldBePrice { get; set; }
    public string sPriceSource { get; set; }
    public string sOtherInformation { get; set; }
    public int iUserId { get; set; }
    public DateTime dtDateSubmitted { get; set; }
    public DateTime dtDateReviewed { get; set; }
    public int iStatus { get; set; }
    public int iCloseOutStatus { get; set; }
    public int iReviewerUserId { get; set; }
    public string sComments { get; set; }
    public decimal dAmountSaved { get; set; }
    public string sFileName { get; set; }
    public byte[] bBlob { get; set; }
    public int iHubId { get; set; }

    public Price()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Price(DataRow dr)
    {
        lPriceId = int.Parse(dr["PRICEID"].ToString());
        sPONumber = dr["PONUMBER"].ToString();
        sMaterialDescription = dr["MATERIALDESC"].ToString();
        sMaterialCode = dr["MATERIALCODE"].ToString();
        dPrice = decimal.Parse(dr["PRICE"].ToString());
        dShouldBePrice = decimal.Parse(dr["SHOULDBEPRICE"].ToString());
        sPriceSource = dr["PRICESOURCE"].ToString();
        sOtherInformation = dr["OTHERINFORMATION"].ToString();
        iUserId = int.Parse(dr["USERID"].ToString());
        dtDateSubmitted = DateTime.Parse(dr["DATE_SUBMITTED"].ToString());
        dtDateReviewed = !string.IsNullOrEmpty(dr["DATE_REVIEWED"].ToString()) ? DateTime.Parse(dr["DATE_REVIEWED"].ToString()) : DateTime.Today.Date;

        iStatus = int.Parse(dr["STATUS"].ToString());
        iCloseOutStatus = int.Parse(dr["CLOSEOUTSTATUS"].ToString());
        iReviewerUserId = !string.IsNullOrEmpty(dr["REVIEWERUSERID"].ToString()) ? int.Parse(dr["REVIEWERUSERID"].ToString()) : 0;
        sComments = dr["COMMENTS"].ToString();

        dAmountSaved = !string.IsNullOrEmpty(dr["AMTSAVED"].ToString()) ? decimal.Parse(dr["AMTSAVED"].ToString()) : 0;
        sFileName = dr["SFILENAME"].ToString();
        bBlob = (dr["BLOBFILE"] == DBNull.Value) ? null : (byte[])dr["BLOBFILE"];
        iHubId = int.Parse(dr["IDHUB"].ToString());
    }
}

public static class PriceHelper
{
    static readonly string previewPath = "/App/Prices/RedFlag/";
    static readonly string destinationPath = "../Prices/RedFlag/";

    static PriceHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool Insert(Price oPrice)
    {
        string sql = "INSERT INTO PRICE_REPORT (PRICE, SHOULDBEPRICE, DATE_SUBMITTED, USERID, MATERIALCODE, MATERIALDESC, OTHERINFORMATION, PONUMBER, PRICESOURCE, STATUS, SFILENAME, BLOBFILE, IDHUB) ";
        sql += "VALUES (:dPrice, :dShouldBePrice, :dtDateSubmitted, :iUserId, :sMaterialCode, :sMaterialDescription, :sOtherInformation, :sPONumber, :sPriceSource, :iStatus, :sFileName, :bBlobFile, :iHubId)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":bBlobFile";
        param.Value = oPrice.bBlob;
        param.OracleDbType = OracleDbType.Blob;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPrice";
        param.Value = oPrice.dPrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dShouldBePrice";
        param.Value = oPrice.dShouldBePrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtDateSubmitted";
        param.Value = oPrice.dtDateSubmitted;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oPrice.iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialCode";
        param.Value = oPrice.sMaterialCode;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialDescription";
        param.Value = oPrice.sMaterialDescription;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOtherInformation";
        param.Value = oPrice.sOtherInformation;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = oPrice.sPONumber;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPriceSource";
        param.Value = oPrice.sPriceSource;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = oPrice.iStatus;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileName";
        param.Value = oPrice.sFileName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iHubId";
        param.Value = oPrice.iHubId;
        param.OracleDbType = OracleDbType.Int32;
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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public static bool InsertWtOutFile(Price oPrice)
    {
        string sql = "INSERT INTO PRICE_REPORT (PRICE, SHOULDBEPRICE, DATE_SUBMITTED, USERID, MATERIALCODE, MATERIALDESC, OTHERINFORMATION, PONUMBER, PRICESOURCE, STATUS, SFILENAME, IDHUB) ";
        sql += "VALUES (:dPrice, :dShouldBePrice, :dtDateSubmitted, :iUserId, :sMaterialCode, :sMaterialDescription, :sOtherInformation, :sPONumber, :sPriceSource, :iStatus, :sFileName, :iHubId)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":dPrice";
        param.Value = oPrice.dPrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dShouldBePrice";
        param.Value = oPrice.dShouldBePrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtDateSubmitted";
        param.Value = oPrice.dtDateSubmitted;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oPrice.iUserId;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialCode";
        param.Value = oPrice.sMaterialCode;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialDescription";
        param.Value = oPrice.sMaterialDescription;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOtherInformation";
        param.Value = oPrice.sOtherInformation;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = oPrice.sPONumber;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPriceSource";
        param.Value = oPrice.sPriceSource;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = oPrice.iStatus;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileName";
        param.Value = oPrice.sFileName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iHubId";
        param.Value = oPrice.iHubId;
        param.OracleDbType = OracleDbType.Int32;
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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public static bool Update(Price oPrice)
    {
        string sql = "UPDATE PRICE_REPORT SET PRICE = :dPrice, SHOULDBEPRICE = :dShouldBePrice, USERID = :iUserId, MATERIALCODE = :sMaterialCode, ";
        sql += "MATERIALDESC = :sMaterialDescription, OTHERINFORMATION = :sOtherInformation, PONUMBER = :sPONumber, PRICESOURCE = :sPriceSource, IDHUB = :iHubId ";
        sql += "WHERE PRICEID = :lPriceId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lPriceId";
        param.Value = oPrice.lPriceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPrice";
        param.Value = oPrice.dPrice;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dShouldBePrice";
        param.Value = oPrice.dShouldBePrice;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oPrice.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialCode";
        param.Value = oPrice.sMaterialCode;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialDescription";
        param.Value = oPrice.sMaterialDescription;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sOtherInformation";
        param.Value = oPrice.sOtherInformation;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = oPrice.sPONumber;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPriceSource";
        param.Value = oPrice.sPriceSource;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iHubId";
        param.Value = oPrice.iHubId;
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

    public static bool UpdateReviewComment(Price oPrice)
    {
        string sql = "UPDATE PRICE_REPORT SET COMMENTS = :sComments, REVIEWERUSERID = :iUserId, AMTSAVED = :dAmtSaved, STATUS = :iStatus, CLOSEOUTSTATUS = :iCloseOut, DATE_REVIEWED = :dtReviewed WHERE PRICEID = :lPriceId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lPriceId";
        param.Value = oPrice.lPriceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oPrice.sComments;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oPrice.iReviewerUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = oPrice.iStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCloseOut";
        param.Value = oPrice.iCloseOutStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dAmtSaved";
        param.Value = oPrice.dAmountSaved;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtReviewed";
        param.Value = oPrice.dtDateReviewed;
        param.DbType = DbType.Date;
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

    public static bool ReviewedClosedOut(Price oPrice)
    {
        string sql = "UPDATE PRICE_REPORT SET STATUS = :iStatus, REVIEWERUSERID = iUserId, COMMENTS = :sComments WHERE PRICEID = :lPriceId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lPriceId";
        param.Value = oPrice.lPriceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = oPrice.iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = oPrice.sMaterialCode;
        param.DbType = DbType.String;
        param.Size = 2000;
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

    private static string getMasterQuery()
    {
        //string sql = "SELECT PRICE_REPORT.PRICEID, PRICE_REPORT.PRICE, PRICE_REPORT.SHOULDBEPRICE, (PRICE_REPORT.PRICE-PRICE_REPORT.SHOULDBEPRICE) AS XVARIANCE, PRICE_REPORT.DATE_SUBMITTED, ";
        //sql += "PRICE_REPORT.USERID, PRICE_REPORT.MATERIALCODE, PRICE_REPORT.MATERIALDESC, PRICE_REPORT.OTHERINFORMATION, PRICE_REPORT.REVIEWERUSERID, PRICE_REPORT.COMMENTS, PRICE_REPORT.IDHUB, ";
        //sql += "PRICE_REPORT.PONUMBER, PRICE_REPORT.PRICESOURCE, PRICE_REPORT.STATUS, PRICE_REPORT.CLOSEOUTSTATUS, PRICE_REPORT.SFILENAME, PRICE_REPORT.BLOBFILE, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PRICE_REPORT.AMTSAVED, PRICE_REPORT.DATE_REVIEWED ";
        //sql += "FROM PRICE_REPORT INNER JOIN PROD_USERMGT ON PRICE_REPORT.USERID = PROD_USERMGT.USERID ";

        string sql = "SELECT PRICE_REPORT.PRICEID, PRICE_REPORT.PRICE, PRICE_REPORT.SHOULDBEPRICE, (PRICE_REPORT.PRICE - PRICE_REPORT.SHOULDBEPRICE) AS XVARIANCE, ";
        sql += "PRICE_REPORT.DATE_SUBMITTED, PRICE_REPORT.USERID, PRICE_REPORT.MATERIALCODE, PRICE_REPORT.MATERIALDESC, PRICE_REPORT.OTHERINFORMATION, ";
        sql += "PRICE_REPORT.REVIEWERUSERID, PRICE_REPORT.COMMENTS, PRICE_REPORT.PONUMBER, PRICE_REPORT.PRICESOURCE, PRICE_REPORT.STATUS, ";
        sql += "PRICE_REPORT.CLOSEOUTSTATUS, PRICE_REPORT.SFILENAME, PRICE_REPORT.BLOBFILE, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PRICE_REPORT.AMTSAVED, ";
        sql += "PRICE_REPORT.DATE_REVIEWED, ASSET_HUBS.IDHUB, ASSET_HUBS.HUB ";
        sql += "FROM PRICE_REPORT ";
        sql += "INNER JOIN PROD_USERMGT ON PRICE_REPORT.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN ASSET_HUBS ON PRICE_REPORT.IDHUB = ASSET_HUBS.IDHUB ";

        return sql;
    }

    public static DataTable dtGetPendingPrices()
    {
        string sql = getMasterQuery();
        sql += "WHERE PRICE_REPORT.CLOSEOUTSTATUS <> :iStatus";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int) ReviewStatus.RevStatus.Yes;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetClosedOutPrices()
    {
        string sql = getMasterQuery();
        sql += "WHERE PRICE_REPORT.CLOSEOUTSTATUS = :iStatus";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int) ReviewStatus.RevStatus.Yes;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetMyPendingPrices(int iUserId)
    {
        //string sql = "SELECT PRICEID, PRICE, SHOULDBEPRICE, DATE_SUBMITTED, USERID, MATERIALCODE, MATERIALDESC, OTHERINFORMATION, PONUMBER, PRICESOURCE, STATUS FROM PRICE_REPORT WHERE USERID = :iUserId AND STATUS <> :iStatus";

        string sql = getMasterQuery();
        sql += "WHERE PROD_USERMGT.USERID = :iUserId AND PRICE_REPORT.CLOSEOUTSTATUS <> :iStatus";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int) ReviewStatus.RevStatus.Yes;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetMyApprovedPrices(int iUserId)
    {
        //string sql = "SELECT PRICEID, PRICE, SHOULDBEPRICE, DATE_SUBMITTED, USERID, MATERIALCODE, MATERIALDESC, OTHERINFORMATION, PONUMBER, PRICESOURCE, STATUS FROM PRICE_REPORT WHERE USERID = :iUserId AND STATUS <> :iStatus";

        string sql = getMasterQuery();
        sql += "WHERE PROD_USERMGT.USERID = :iUserId AND PRICE_REPORT.CLOSEOUTSTATUS = :iStatus";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int) ReviewStatus.RevStatus.Yes;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetPriceById(long lPriceId)
    {
        string sql = getMasterQuery();
        sql += "WHERE PRICE_REPORT.PRICEID = :lPriceId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lPriceId";
        param.Value = lPriceId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static Price objGetPriceById(long lPriceId)
    {
        DataTable dt = dtGetPriceById(lPriceId);

        Price o = new Price();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Price(dr);
        }
        return o;
    }

    public static DataTable GetPrices()
    {
        string sql = getMasterQuery();

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable GetPricesByHub(int iHubId)
    {
        string sql = getMasterQuery();
        sql += "WHERE ASSET_HUBS.IDHUB = :iHubId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iHubId";
        param.Value = iHubId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<Price> LstGetPrices()
    {
        DataTable dt = GetPrices();

        var o = new List<Price>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new Price(dr));
        }
        return o;
    }

    public static List<Price> LstGetPricesByHub(int iHubId)
    {
        DataTable dt = GetPricesByHub(iHubId);

        var o = new List<Price>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new Price(dr));
        }
        return o;
    }

    public static void PreviewLoadedFile(Price o, HtmlGenericControl fileLoader)
    {
        if (o != null)
        {
            string sFinalPath = HttpContext.Current.Server.MapPath(destinationPath + o.sFileName);

            if (o.bBlob != null)
            {
                File.WriteAllBytes(sFinalPath, o.bBlob);
                fileLoader.Attributes["src"] = previewPath + o.sFileName;
            }
        }
        else
        {
            fileLoader.Attributes["src"] = "";
        }
    }

    public static DataTable GetPricesPendingReview()
    {
        string sql = getMasterQuery();
        sql += "WHERE PRICE_REPORT.STATUS = :iStatus";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iStatus";
        param.Value = (int) DiscrepancyStatus.ReviewStatus.PendingReview;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<Price> LstGetPricesPendingReview()
    {
        DataTable dt = GetPricesPendingReview();

        var o = new List<Price>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new Price(dr));
        }
        return o;
    }

    //public static void PreviewLoadedFile(Price o, string DestinationPath, FileUpload fileLoader)
    //{
    //    if (o != null)
    //    {
    //        string sFinalPath = HttpContext.Current.Server.MapPath(DestinationPath + o.sFileName);
    //        File.WriteAllBytes(sFinalPath, o.bBlob);
    //        fileLoader.Attributes["src"] = sFinalPath;

    //        //OpenPDFHyperLink.NavigateUrl = sFinalPath;
    //    }
    //    else
    //    {
    //        fileLoader.Attributes["src"] = "";
    //    }
    //}

    //public static List<AssetPdcc> lstGetAssets()
    //{
    //    DataTable dt = dtGetAssets();

    //    List<AssetPdcc> asset = new List<AssetPdcc>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        asset.Add(new AssetPdcc(dr));
    //    }
    //    return asset;
    //}
}

public class PriceReviewers
{
    public int iUserId { get; set; }
    public PriceReviewers()
    {

    }

    public PriceReviewers(DataRow dr)
    {
        iUserId = int.Parse(dr["USERID"].ToString());
    }
}

public static class PriceReviewerHelper
{
    static PriceReviewerHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool Insert(int iUserId)
    {
        string sql = "INSERT INTO PRICE_REVIEWERS (USERID) VALUES (:iUserId)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
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

    public static bool RemoveFromReviewers(int iUserId)
    {
        string sql = "DELETE FROM PRICE_REVIEWERS WHERE USERID = :iUserId";
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return (result != -1);
    }

    public static DataTable dtGetPriceReviewers()
    {
        //string sql = "SELECT USERID FROM PRICE_REVIEWERS";
        string sql = "SELECT PRICE_REVIEWERS.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL ";
        sql += "FROM PRICE_REVIEWERS INNER JOIN PROD_USERMGT ON PRICE_REVIEWERS.USERID = PROD_USERMGT.USERID";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static List<PriceReviewers> lstGetPriceReviewers()
    {
        DataTable dt = dtGetPriceReviewers();

        List<PriceReviewers> o = new List<PriceReviewers>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new PriceReviewers(dr));
        }
        return o;
    }

    public static List<structUserMailIdx> Reviewers()
    {

        List<structUserMailIdx> Reviewers = new List<structUserMailIdx>();
        List<PriceReviewers> lstReviewers = lstGetPriceReviewers();
        foreach (PriceReviewers o in lstReviewers)
        {
            Reviewers.Add(appUsersHelper.objGetUserByUserId(o.iUserId).structUserIdx);
        }

        return Reviewers;
    }

    public static void Reporter(GridViewRow grdRow)
    {
        Label lblStatus = (Label)grdRow.FindControl("lblStatus");
        lblStatus.Font.Bold = true;
        int iStatus = int.Parse(lblStatus.Text);

        if (iStatus == (int)DiscrepancyStatus.ReviewStatus.PendingReview)
        {
            lblStatus.Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.PendingReview);
            lblStatus.ForeColor = System.Drawing.Color.Red;
        }
        else if (iStatus == (int)DiscrepancyStatus.ReviewStatus.UnderGoingReview)
        {
            lblStatus.Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.UnderGoingReview);
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }
        else if (iStatus == (int)DiscrepancyStatus.ReviewStatus.ClosedOut)
        {
            lblStatus.Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.ClosedOut);
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }
    }

    public static void Reporter(DetailsView dtViw)
    {
        Label lblStatus = (Label)dtViw.FindControl("lblStatus");
        lblStatus.Font.Bold = true;
        int iStatus = int.Parse(lblStatus.Text);

        if (iStatus == (int)DiscrepancyStatus.ReviewStatus.PendingReview)
        {
            lblStatus.Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.PendingReview);
            lblStatus.ForeColor = System.Drawing.Color.Red;
        }
        else if (iStatus == (int)DiscrepancyStatus.ReviewStatus.UnderGoingReview)
        {
            lblStatus.Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.UnderGoingReview);
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }
        else if (iStatus == (int)DiscrepancyStatus.ReviewStatus.ClosedOut)
        {
            lblStatus.Text = DiscrepancyStatus.DiscrepancyStatusDesc(DiscrepancyStatus.ReviewStatus.ClosedOut);
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }
    }

    public static void FormatReport(DetailsView dtViw)
    {
        //foreach (DetailsViewRow dtlRow in dtlView.Rows)
        //{
        Label lblPrice = ((Label)(dtViw.FindControl("lblPrice")));
        Label lblShouldBePrice = ((Label)(dtViw.FindControl("lblShouldBePrice")));
        Label lblPriceVariance = ((Label)(dtViw.FindControl("lblPriceVariance")));

        Reporter(dtViw);
        //Label lblStatus = ((Label)(dtlRow.FindControl("lblStatus")));

        decimal Price = !string.IsNullOrEmpty(lblPrice.Text) ? decimal.Parse(lblPrice.Text) : 0;
        decimal ShouldBePrice = !string.IsNullOrEmpty(lblShouldBePrice.Text) ? decimal.Parse(lblShouldBePrice.Text) : 0;
        decimal PriceVariance = !string.IsNullOrEmpty(lblPriceVariance.Text) ? decimal.Parse(lblPriceVariance.Text) : 0;

        lblPrice.Text = !string.IsNullOrEmpty(lblPrice.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblPrice.Text)) : "0";
        lblShouldBePrice.Text = !string.IsNullOrEmpty(lblShouldBePrice.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblShouldBePrice.Text)) : "0";
        lblPriceVariance.Text = !string.IsNullOrEmpty(lblPriceVariance.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblPriceVariance.Text)) : "0";
        //}
    }

    public static void FormatReport(GridView grdView)
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblPrice = ((Label)(grdRow.FindControl("lblPrice")));
            Label lblShouldBePrice = ((Label)(grdRow.FindControl("lblShouldBePrice")));
            Label lblPriceVariance = ((Label)(grdRow.FindControl("lblPriceVariance")));

            decimal Price = !string.IsNullOrEmpty(lblPrice.Text) ? decimal.Parse(lblPrice.Text) : 0;
            decimal ShouldBePrice = !string.IsNullOrEmpty(lblShouldBePrice.Text) ? decimal.Parse(lblShouldBePrice.Text) : 0;
            decimal PriceVariance = !string.IsNullOrEmpty(lblPriceVariance.Text) ? decimal.Parse(lblPriceVariance.Text) : 0;

            lblPrice.Text = !string.IsNullOrEmpty(lblPrice.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblPrice.Text)) : "0";
            lblShouldBePrice.Text = !string.IsNullOrEmpty(lblShouldBePrice.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblShouldBePrice.Text)) : "0";
            lblPriceVariance.Text = !string.IsNullOrEmpty(lblPriceVariance.Text) ? stringRoutine.formatAsBankMoney(decimal.Parse(lblPriceVariance.Text)) : "0";
        }
    }

    public static bool GetReviewer(int iUserId)
    {
        bool bRet = false;
        List<PriceReviewers> lstReviewers = PriceReviewerHelper.lstGetPriceReviewers();
        foreach (PriceReviewers o in lstReviewers)
        {
            if (o.iUserId == iUserId)
            {
                bRet = true;
                break;
            }
        }

        return bRet;
    }
}


public class FindingsRecomendations
{
    public long lRecommendId { get; set; }  
    public string sPONumber { get; set; }
    public string sMaterialDescription { get; set; }
    public string sMaterialCode { get; set; }
    public decimal dOldPrice { get; set; }
    public decimal dNewPrice { get; set; }
    public decimal dValDiffPrice { get; set; }
    public int iQty { get; set; }
    public decimal dValLossPrice { get; set; }
    public string sIssueDesc { get; set; }
    public string sRecommendation { get; set; }
    public string sComments { get; set; }
    public int iUserId { get; set; }
    public DateTime dtDateSubmitted { get; set; }


    public FindingsRecomendations()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public FindingsRecomendations(DataRow dr)
    {
        lRecommendId = long.Parse(dr["RECOMENDID"].ToString());
        sPONumber = dr["PONUMBER"].ToString();
        sMaterialDescription = dr["MATERIALDESCRIPTION"].ToString();
        sMaterialCode = dr["MATERIALNUM"].ToString();
        sIssueDesc = dr["ISSUEDESCRIPTION"].ToString();
        sRecommendation = dr["RECOMMENDATION"].ToString();
        sComments = dr["COMMENTS"].ToString();
        iUserId = int.Parse(dr["USERID"].ToString());
        dtDateSubmitted = DateTime.Parse(dr["DATE_SUBMITTED"].ToString());
        dOldPrice = !string.IsNullOrEmpty(dr["OLDPRICE"].ToString()) ? decimal.Parse(dr["OLDPRICE"].ToString()) : 0;
        dNewPrice = !string.IsNullOrEmpty(dr["NEWPRICE"].ToString()) ? decimal.Parse(dr["NEWPRICE"].ToString()) : 0;
        dValDiffPrice = !string.IsNullOrEmpty(dr["VALDIFF"].ToString()) ? decimal.Parse(dr["VALDIFF"].ToString()) : 0;
        iQty = !string.IsNullOrEmpty(dr["STOCKQTY"].ToString()) ? int.Parse(dr["STOCKQTY"].ToString()) : 0;
        dValLossPrice = !string.IsNullOrEmpty(dr["VALLOSS"].ToString()) ? decimal.Parse(dr["VALLOSS"].ToString()) : 0;
    }
}

public class FindingsRecomendationsHelper
{
    public FindingsRecomendationsHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private static string getRecommendation()
    {
        string sql = "SELECT RECOMENDID, MATERIALNUM, MATERIALDESCRIPTION, PONUMBER, OLDPRICE, NEWPRICE, ";
        sql += "(OLDPRICE - NEWPRICE) VALDIFF, STOCKQTY, ((OLDPRICE - NEWPRICE)*STOCKQTY) VALLOSS, ";
        sql += "ISSUEDESCRIPTION, COMMENTS, RECOMMENDATION, DATE_SUBMITTED, USERID, STATUS FROM PRICE_RECOMMENDATION ";

        return sql;
    }

    public static DataTable dtGetRecommendation()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = getRecommendation();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable dtGetRecommendationById(long lRecommendId)
    {
        string sql = getRecommendation();
        sql += "WHERE RECOMENDID = :lRecommendId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRecommendId";
        param.Value = lRecommendId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static FindingsRecomendations objGetRecommendationById(long lRecommendId)
    {
        DataTable dt = dtGetRecommendationById(lRecommendId);

        var o = new FindingsRecomendations();
        foreach (DataRow dr in dt.Rows)
        {
            o = new FindingsRecomendations(dr);
        }
        return o;
    }

    public static bool InsertRecommentdation(string sMaterialCode, string sMaterialDescription, string sPONumber, decimal dOldPrice, decimal dNewPrice, int iQty, string sIssue, string sComments, string sRecommendation, int iUserId)
    {
        string sql = "INSERT INTO PRICE_RECOMMENDATION (MATERIALNUM, MATERIALDESCRIPTION, PONUMBER, OLDPRICE, NEWPRICE, STOCKQTY, ISSUEDESCRIPTION, COMMENTS, RECOMMENDATION, USERID, DATE_SUBMITTED) ";
        sql += "VALUES (:sMaterialCode, :sMaterialDescription, :sPONumber, :dOldPrice, :dNewPrice, :iQty, :sIssue, :sComments, :sRecommendation, :iUserId, :dtDateSubmitted)";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sMaterialCode";
        param.Value = sMaterialCode;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialDescription";
        param.Value = sMaterialDescription;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = sPONumber;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dOldPrice";
        param.Value = dOldPrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNewPrice";
        param.Value = dNewPrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iQty";
        param.Value = iQty;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sIssue";
        param.Value = sIssue;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = sComments;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRecommendation";
        param.Value = sRecommendation;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtDateSubmitted";
        param.Value = DateTime.Today.Date;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public static bool UpdateRecommentdation(long lRecommendId, string sMaterialCode, string sMaterialDescription, string sPONumber, decimal dOldPrice, decimal dNewPrice, int iQty, string sIssue, string sComments, string sRecommendation, int iUserId)
    {
        string sql = "UPDATE PRICE_RECOMMENDATION SET MATERIALNUM = :sMaterialCode, MATERIALDESCRIPTION = :sMaterialDescription, PONUMBER = :sPONumber, OLDPRICE = :dOldPrice, NEWPRICE = :dNewPrice, STOCKQTY = :iQty, ";
        sql += "ISSUEDESCRIPTION = :sIssue, COMMENTS = :sComments, RECOMMENDATION = :sRecommendation, USERID = :iUserId, DATE_SUBMITTED = :dtDateSubmitted WHERE RECOMENDID = :lRecommendId";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lRecommendId";
        param.Value = lRecommendId;
        param.OracleDbType = OracleDbType.Int32;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialCode";
        param.Value = sMaterialCode;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sMaterialDescription";
        param.Value = sMaterialDescription;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = sPONumber;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 1000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dOldPrice";
        param.Value = dOldPrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNewPrice";
        param.Value = dNewPrice;
        param.OracleDbType = OracleDbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iQty";
        param.Value = iQty;
        param.OracleDbType = OracleDbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sIssue";
        param.Value = sIssue;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sComments";
        param.Value = sComments;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sRecommendation";
        param.Value = sRecommendation;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dtDateSubmitted";
        param.Value = DateTime.Today.Date;
        param.OracleDbType = OracleDbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iUserId";
        param.Value = iUserId;
        param.OracleDbType = OracleDbType.Int32;
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
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }
}