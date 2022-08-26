using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for aMainReport
/// </summary>
/// 
namespace PDR
{
    public class MainReport
    {
        public long lReportId { get; set; }
        public string sSnapShot1 { get; set; }
        public string sSnapShot2 { get; set; }
        public string sSnapShot3 { get; set; }
        public string sSnapShot4 { get; set; }
        public string sSnapShot5 { get; set; }
        public string sHighLight { get; set; }
        public string sLowLight { get; set; }
        public string sLookAhead { get; set; }
        public int iDistrict { get; set; }
        public int iUserId { get; set; }
        public DateTime dtDateReported { get; set; }

        public MainReport()
        {

        }
        public MainReport(DataRow dr)
        {
            lReportId = long.Parse(dr["IDREPORT"].ToString());
            sSnapShot1 = dr["SNAPSHOT1"].ToString();
            sSnapShot2 = dr["SNAPSHOT2"].ToString();
            sSnapShot3 = dr["SNAPSHOT3"].ToString();
            sSnapShot4 = dr["SNAPSHOT4"].ToString();
            sSnapShot5 = dr["SNAPSHOT5"].ToString();
            sHighLight = dr["HIGHLIGHT"].ToString();
            sLowLight = dr["LOWLIGHT"].ToString();
            sLookAhead = dr["LOOKAHEAD"].ToString();
            iDistrict = int.Parse(dr["ID_DISTRICT"].ToString());
            iUserId = int.Parse(dr["USERID"].ToString());
            dtDateReported = DateTime.Parse(dr["DATERPTD"].ToString());
        }
    }

    public class MainReportHelper
    {
        public MainReportHelper()
        {

        }
        public bool InsertMainReport2(MainReport oMainReport)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport2();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oMainReport.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = oMainReport.iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iDistrict";
            param.Value = oMainReport.iDistrict;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sHighLight";
            param.Value = oMainReport.sHighLight;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLookAhead";
            param.Value = oMainReport.sLookAhead;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLowLight";
            param.Value = oMainReport.sLowLight;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot1";
            param.Value = oMainReport.sSnapShot1;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot2";
            param.Value = oMainReport.sSnapShot2;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot3";
            param.Value = oMainReport.sSnapShot3;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot4";
            param.Value = oMainReport.sSnapShot4;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot5";
            param.Value = oMainReport.sSnapShot5;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dtDateReported";
            param.Value = oMainReport.dtDateReported;
            param.DbType = DbType.Date;
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

        public bool InsertMainReport(MainReport oMainReport, ref long lReportId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.InsertMainReport();

            lReportId = getReportId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = oMainReport.iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iDistrict";
            param.Value = oMainReport.iDistrict;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dtDateReported";
            param.Value = DateTime.Today.Date;
            param.DbType = DbType.Date;
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
        public bool UpdateMainReport(MainReport oMainReport)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.UpdateMainReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = oMainReport.lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = oMainReport.iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sHighLight";
            param.Value = oMainReport.sHighLight;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLookAhead";
            param.Value = oMainReport.sLookAhead;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sLowLight";
            param.Value = oMainReport.sLowLight;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot1";
            param.Value = oMainReport.sSnapShot1;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot2";
            param.Value = oMainReport.sSnapShot2;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot3";
            param.Value = oMainReport.sSnapShot3;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot4";
            param.Value = oMainReport.sSnapShot4;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sSnapShot5";
            param.Value = oMainReport.sSnapShot5;
            param.DbType = DbType.String;
            param.Size = 2000;
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

        public DataTable dtGetMaiReportByDistrictDate(int iDistrictId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getMaiReportByDistrictDate();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDistrictId";
            param.Value = iDistrictId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dTodaysDate";
            param.Value = DateTime.Today.Date;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable dtGetMaiReportByDistrictNameDate(string sDistrict)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getMaiReportByDistrictNameDate();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":sDistrict";
            param.Value = sDistrict;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dTodaysDate";
            param.Value = DateTime.Today.Date;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable dtGetMaiReportByReportId(long lReportId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = PDR.StoredProcedure.getMaiReportByReportId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public MainReport objGetMaiReportByDistrictDate(int iDistrict)
        {
            DataTable dt = dtGetMaiReportByDistrictDate(iDistrict);

            MainReport oMainReport = new MainReport();
            foreach (DataRow dr in dt.Rows)
            {
                oMainReport = new MainReport(dr);
            }
            return oMainReport;
        }

        public MainReport objGetMaiReportByReportId(long lReportId)
        {
            DataTable dt = dtGetMaiReportByReportId(lReportId);

            MainReport oMainReport = new MainReport();
            foreach (DataRow dr in dt.Rows)
            {
                oMainReport = new MainReport(dr);
            }
            return oMainReport;
        }

        public MainReport objGetMaiReportByDistrictNameDate(string sDistrict)
        {
            DataTable dt = dtGetMaiReportByDistrictNameDate(sDistrict);

            MainReport oMainReport = new MainReport();
            foreach (DataRow dr in dt.Rows)
            {
                oMainReport = new MainReport(dr);
            }
            return oMainReport;
        }
        public static long getReportId()
        {
            string sql = "SELECT PDR_MAINREPORT_SEQ.NEXTVAL FROM DUAL";
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sql;

            long ReportId = 0;
            try
            {
                DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
                ReportId = Convert.ToInt32(dt.Rows[0]["NEXTVAL"].ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

            return ReportId;
        }

        public void FillMenu(XmlDataSource XmlMenuDataSource, TreeView mnuTreeView)
        {
            try
            {
                Menu.getChartMenu(XmlMenuDataSource);
                mnuTreeView.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }

        public void FillMenuVerificationHeatMap(XmlDataSource XmlMenuDataSource, TreeView mnuTreeView)
        {
            try
            {
                Menu.getChartMenuVerificationHeatMap(XmlMenuDataSource);
                mnuTreeView.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }

        //public MainProjectHelper(DataRow dr)
        //{
        //    string sql ="SELECT PDR_MAINREPORT.IDREPORT, PDR_MAINREPORT.SNAPSHOT1, PDR_MAINREPORT.SNAPSHOT2, PDR_MAINREPORT.SNAPSHOT3, PDR_MAINREPORT.SNAPSHOT4, ";
        //    sql +="PDR_MAINREPORT.SNAPSHOT5, PDR_MAINREPORT.HIGHLIGHT, PDR_MAINREPORT.LOWLIGHT, PDR_MAINREPORT.LOOKAHEAD, PDR_MAINREPORT.ID_DISTRICT, PDR_MAINREPORT.USERID, ";
        //    sql +="PDR_MAINREPORT.DATERPTD FROM PDR_MAINREPORT";


        //}

    }
}