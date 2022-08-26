using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using Microsoft.Security.Application;
using System.Drawing;
using Telerik.Web.UI;

namespace EIdd
{
    /// <summary>
    /// Summary description for IDDRequestMgtt
    /// </summary>

    public class IDDRequestMgt
    {
        readonly CategoryMgt c = new CategoryMgt();
        readonly appUsersHelper H = new appUsersHelper();

        public IDDRequestMgt()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private static DataTable dtGetIDDId()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getIDDAutoNumber();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        private static DataTable dtGetRequestId()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestIdAutoNumber();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        private struct IDDIdentity
        {
            public long lRequestID;
            public string sVendorNumber;
        }

        private IDDIdentity IDDIdentifier()
        {
            IDDIdentity e = new IDDIdentity();
            try
            {
                string sNo = "";
                DataTable dt = dtGetIDDId();
                e.lRequestID = long.Parse(dt.Rows[0]["AUTO"].ToString()) + 1;

                if (e.lRequestID.ToString().Length == 1) sNo = "000" + e.lRequestID.ToString();
                else if (e.lRequestID.ToString().Length == 2) sNo = "00" + e.lRequestID.ToString();
                else if (e.lRequestID.ToString().Length == 3) sNo = "0" + e.lRequestID.ToString();
                else if (e.lRequestID.ToString().Length >= 4) sNo = e.lRequestID.ToString();

                e.sVendorNumber = "IDD" + DateTime.Now.Year.ToString().Remove(0, 2) + sNo;
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

            return e;
        }

        private IDDIdentity RequestIdGenerator()
        {
            IDDIdentity e = new IDDIdentity();
            try
            {
                string sNo = "";
                DataTable dt = dtGetRequestId();
                e.lRequestID = long.Parse(dt.Rows[0]["AUTO"].ToString()) + 1;

                if (e.lRequestID.ToString().Length == 1) sNo = "000" + e.lRequestID.ToString();
                else if (e.lRequestID.ToString().Length == 2) sNo = "00" + e.lRequestID.ToString();
                else if (e.lRequestID.ToString().Length == 3) sNo = "0" + e.lRequestID.ToString();
                else if (e.lRequestID.ToString().Length >= 4) sNo = e.lRequestID.ToString();

                //e.sVendorNumber = "IDD" + DateTime.Now.Year.ToString().Remove(0, 2) + sNo;
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

            return e;
        }

        public eIddUsers CheckIfLogInUserIsCpFocalPoint(int iUserId)
        {
            var cppFP = new LeadFocalPoint();
            eIddUsers o = cppFP.objGetLeadFocalPointByUserId(iUserId);
            return o;
        }


        public bool MakeNewRequest(RequestForIDD o, ref long lRequestId)
        {
            IDDIdentity c = RequestIdGenerator();
            lRequestId = c.lRequestID;
            o.m_lRequestId = c.lRequestID;

            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.MakeIddRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVendorId";
            param.Value = o.m_lVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = o.m_iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = o.m_iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = o.m_iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dDateSubmitted";
            param.Value = DateTime.Now.Date;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iNor";
            param.Value = o.m_iNoR;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool UpdateNewRequest(RequestForIDD o)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.UpdateRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = o.m_lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVendorId";
            param.Value = o.m_lVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = o.m_iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = o.m_iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = o.m_iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //param = comm.CreateParameter();
            //param.ParameterName = ":dDateSubmitted";
            //param.Value = DateTime.Now.Date;
            //param.DbType = DbType.Date;
            //comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iNor";
            param.Value = o.m_iNoR;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }


        //DeleteDuplicateRequest

        public bool DeleteDuplicateRequest(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.DeleteDuplicateRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }


        public bool DeleteRequestAuditTrail(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.DeleteRequestAuditTrails();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool DeleteRequestDocuments(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.DeleteRequestDocuments();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool DeleteRequest(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.DeleteRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool AddVendor(Vendours o, ref long lVendorId, ref string sIDDNumber)
        {
            IDDIdentity c = IDDIdentifier();
            lVendorId = c.lRequestID;
            o.m_lVendorId = c.lRequestID;
            o.m_sIDDNo = c.sVendorNumber;
            sIDDNumber = c.sVendorNumber;

            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.AddVendor();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lVendorId";
            param.Value = lVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sIDDNo";
            param.Value = o.m_sIDDNo;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = o.m_iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCodes";
            param.Value = o.m_sCodes;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sRegisteredName";
            param.Value = o.m_sRegisteredName;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAddress";
            param.Value = o.m_sAddress;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sRepresentative";
            param.Value = o.m_sRepresentative;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sEmailAddress";
            param.Value = o.m_sEmailAddress;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sTelephoneNo";
            param.Value = o.m_sTelephoneNumber;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dAmount";
            param.Value = o.m_dAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iGo";
            param.Value = o.m_iGO;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iGi";
            param.Value = o.m_iGI;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool UpdateVendor(Vendours o)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.UpdateVendor();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lVendorId";
            param.Value = o.m_lVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = o.m_iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCodes";
            param.Value = o.m_sCodes;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sRegisteredName";
            param.Value = o.m_sRegisteredName;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAddress";
            param.Value = o.m_sAddress;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sRepresentative";
            param.Value = o.m_sRepresentative;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sEmailAddress";
            param.Value = o.m_sEmailAddress;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sTelephoneNo";
            param.Value = o.m_sTelephoneNumber;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dAmount";
            param.Value = o.m_dAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iGo";
            param.Value = o.m_iGO;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iGi";
            param.Value = o.m_iGI;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool AssignAnalyst(long lRequestId, int iFocalPointId, int iAnalystId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.AssignIDDAnalyst();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFocalPointId";
            param.Value = iFocalPointId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iAnalystId";
            param.Value = iAnalystId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dDateAssigned";
            param.Value = DateTime.Now.Date;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int) StageEnums.IddStage.IddAnalystProgression;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool RequestRejected(long lRequestId, int iFocalPointId, string sReasonForRejection)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.RequestRejected();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iFocalPointId";
            param.Value = iFocalPointId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sReasonForRejection;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int) StageEnums.IddStage.RequestRejected;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool AnalystActionRequest(long lRequestId, int iStatus, int iStage, string sComments, DateTime? dValidityPeriod)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.AnalystActionRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dValidityPeriod";
            param.Value = dValidityPeriod;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool AnalystActionRequest2(long lRequestId, int iStatus, string sComments)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.AnalystActionRequest2();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            //param = comm.CreateParameter();
            //param.ParameterName = ":iStage";
            //param.Value = iStage;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool VMIDDActionRequest(long lRequestId, int iStage, int iStatus, int iVsr, string sComments)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.VMIDDActionRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVsr";
            param.Value = iVsr;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool IDDExpired(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.IddExpired();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = (int)ReportStatusEnums.VendorStatus.Amber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int)StageEnums.IddStage.Expired;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool VMIDDActionRequest2(long lRequestId, int iStage, int iStatus, string sComments)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.VMIDDActionRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool VMIDDLeadVsrMgt(long lRequestId, int iStage, int iStatus, string sComments)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.VMIDDLeadApproveRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool VMIDDLeadVsrMgtWtDate(long lRequestId, int iStage, int iStatus, string sComments, DateTime? dtScreened)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.VMIDDLeadApproveRequestWtDate();

            //TODO: THERE IS AN UNRESOLVED ISSUES HERE
            //string sql = "UPDATE IDD_REQUEST SET STATUS = :iStatus, STAGE = :iStage, DATESCREENED = :dtScreened, APPROVERCOMMENT = :sComments  WHERE REQUESTID = :lRequestId";
            //TODO: Changing to Grey or Red from any color is not working

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dtScreened";
            param.Value = dtScreened;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool UpdateIDDAutoNumberGenerator(long lVendorId)
        {
            //Update Bonga_Auto table to the latest value
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.UpdateIDDAuto();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lVendorId";
            param.Value = lVendorId;
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

        public bool UpdateRequestNumberAutoGenerated(long lRequestId)
        {
            //Update Bonga_Auto table to the latest value
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.UpdateReqNumAuto();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
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

        public DataTable GetRequests()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequests();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<RequestForIDD> lstRequests()
        {
            DataTable dt = GetRequests();

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }
            return o;
        }


        public DataTable GetRequestsAssignedToMeAnalyst(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestAssignedToMeAnalyst();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVsr";
            param.Value = (int)CompletedEnums.CompletedStatus.No;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetPendingRequests()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getPendingRequests();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int)StageEnums.IddStage.AwaitingFocalPoint;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetVSRReport()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVSRReport();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = (int)ReportStatusEnums.VendorStatus.Amber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVsr";
            param.Value = (int)CompletedEnums.CompletedStatus.Yes;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetVSRReportByVendorId(long lVendorId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVSRReportByVendorId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = (int)ReportStatusEnums.VendorStatus.Amber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVsr";
            param.Value = (int)CompletedEnums.CompletedStatus.Yes;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":lVendorId";
            param.Value = lVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetVSRReportByRequestId(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVSRReportByRequestId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetCompletedRequestByStatus(int iStatus)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getCompletedRequestByStatus();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVsr";
            param.Value = (int)CompletedEnums.CompletedStatus.Yes;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetMyPendingRequests(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getMyPendingRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int)StageEnums.IddStage.AwaitingFocalPoint;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetMyRequestsAssignedToAnalyst(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getMyRequestAssignedToAnalyst();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int)StageEnums.IddStage.RequestRejected;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestsAssignedToMeAnalystInVSR(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestAssignedToMeAnalystInVsr();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVsr";
            param.Value = (int)CompletedEnums.CompletedStatus.Yes;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestsAssignedToAnalyst()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestAssignedToAnalyst();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestsRejected()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRejectedRequests();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int)StageEnums.IddStage.RequestRejected;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetMyRequestsRejected(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getMyRejectedRequest();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = (int)StageEnums.IddStage.RequestRejected;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetMyCompletedRequests(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getMyCompletedRequests();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestById(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestById();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetNewRequestById(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestById();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetNewRequestByVendorId(long lVendorId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestByVendorId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lVendorId";
            param.Value = lVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public RequestForIDD objGetRequestByVendorId(long lVendorId)
        {
            DataTable dt = GetNewRequestByVendorId(lVendorId);

            var o = new RequestForIDD();
            foreach (DataRow dr in dt.Rows)
            {
                o = new RequestForIDD(dr);
            }

            return o;
        }

        public List<RequestForIDD> LstGetRequestByVendorId(long lVendorId)
        {
            DataTable dt = GetNewRequestByVendorId(lVendorId);

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }
            return o;
        }

        public DataTable GetRequestByPriority(int iPriority)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestByPriority();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iPriority";
            param.Value = iPriority;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestByLocation(int iLocationId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestByLocation();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iLocationId";
            param.Value = iLocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestByLocationCategory(int iLocationId, int iCategoryId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestByLocationCategory();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iLocationId";
            param.Value = iLocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestByVendourCode(string sVendourCode)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestByVendourCode();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":sVendourCode";
            param.Value = sVendourCode;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetRequestByRegisteredName(string sRegisteredName)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestByRegisteredName();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":sRegisteredName";
            param.Value = "%" + Encoder.HtmlEncode(sRegisteredName.ToUpper()) + "%";
            //param.Value = sRegisteredName;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<RequestForIDD> LstGetRequests()
        {
            DataTable dt = GetRequests();

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }
            return o;
        }

        public RequestForIDD objGetRequestById(long lRequestId)
        {
            DataTable dt = GetRequestById(lRequestId);

            var o = new RequestForIDD();
            foreach (DataRow dr in dt.Rows)
            {
                o = new RequestForIDD(dr);
            }

            return o;
        }

        public RequestForIDD objGetNewRequestById(long lRequestId)
        {
            DataTable dt = GetNewRequestById(lRequestId);

            var o = new RequestForIDD();
            foreach (DataRow dr in dt.Rows)
            {
                o = new RequestForIDD(dr);
            }

            return o;
        }

        public RequestForIDD objGetRequestByVendourCode(string sVendourCode)
        {
            DataTable dt = GetRequestByVendourCode(sVendourCode);

            var o = new RequestForIDD();
            foreach (DataRow dr in dt.Rows)
            {
                o = new RequestForIDD(dr);
            }

            return o;
        }

        public List<RequestForIDD> LstGetRequestByPriority(int priority)
        {
            DataTable dt = GetRequestByPriority(priority);

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }

            return o;
        }

        public List<RequestForIDD> LstGetRequestByLocation(int iLocationId)
        {
            DataTable dt = GetRequestByLocation(iLocationId);

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }

            return o;
        }

        public List<RequestForIDD> LstGetRequestByLocationCategory(int iLocationId, int iCategoryId)
        {
            DataTable dt = GetRequestByLocationCategory(iLocationId, iCategoryId);

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }

            return o;
        }

        public List<RequestForIDD> LstGetRequestByVendourCode(string sVendourCode)
        {
            DataTable dt = GetRequestByVendourCode(sVendourCode);

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }

            return o;
        }

        public RequestForIDD objGetRequestByRegisteredName(string sRegisteredName)
        {
            DataTable dt = GetRequestByRegisteredName(sRegisteredName);

            var o = new RequestForIDD();
            foreach (DataRow dr in dt.Rows)
            {
                o = new RequestForIDD(dr);
            }

            return o;
        }

        public List<RequestForIDD> LstGetRequestByRegisteredName(string sRegisteredName)
        {
            DataTable dt = GetRequestByRegisteredName(sRegisteredName);

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }

            return o;
        }

        public DataTable dtGetRequestBySearch(string search)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestBySearch();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":Search";
            param.Value = "%" + Encoder.HtmlEncode(search.ToUpper()) + "%";
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iVsr";
            param.Value = (int)CompletedEnums.CompletedStatus.Yes;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable dtGetExpiredIDDs()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getExpiredIdds();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":Status";
            param.Value = (int)ReportStatusEnums.VendorStatus.Amber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<ExpiredIdds> LstGetExpiredIDDs()
        {
            DataTable dt = dtGetExpiredIDDs();

            var o = new List<ExpiredIdds>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new ExpiredIdds(dr));
            }

            return o;
        }

        public IEnumerable<RequestForIDD> LstGetRequestBySearch(string search)
        {
            DataTable dt = dtGetRequestBySearch(search);

            var o = new List<RequestForIDD>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new RequestForIDD(dr));
            }
            return o;
        }

        public List<structUserMailIdx> LstGetCategoryLeads(RequestForIDD o)
        {
            //Get the Category Leads for the selected Category/Service
            List<Category> cat = c.lstGetServiceByServiceId(o.m_iCategoryId);
            var oCopy = new List<structUserMailIdx>();
            foreach (Category ct in cat)
            {
                oCopy.Add(H.objGetUserByUserID(ct.m_iUserId).structUserIdx);
            }

            return oCopy;
        }

        public List<structUserMailIdx> LstGetCategoryLeads(Vendours o)
        {
            //Get the Category Leads for the selected Category/Service
            List<Category> cat = c.lstGetServiceByServiceId(o.m_iCategoryId);
            var oCopy = new List<structUserMailIdx>();
            foreach (Category ct in cat)
            {
                oCopy.Add(H.objGetUserByUserID(ct.m_iUserId).structUserIdx);
            }

            return oCopy;
        }

        public List<structUserMailIdx> LstGetIddFocalPoints()
        {
            var oF = new LeadFocalPoint();
            List<eIddUsers> tos = oF.lstGetCPIDDFocalPoints();
            var eTos = new List<structUserMailIdx>();
            foreach (eIddUsers ct in tos)
            {
                eTos.Add(ct.structUserIdx);
                //eTos.Add(H.objGetUserByUserID(ct.m_iUserId).structUserIdx);
            }

            return eTos;
        }

        public DataTable GetAuditTrailByRequestId(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getAuditTrailByRequestId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable ExpiredIDDs()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getExpiredIDDs();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        //public object ExpiredIDDBetween(DateTime? selectedDate1, DateTime? selectedDate2)
        //{
        //    throw new NotImplementedException();
        //}

        public DataTable ExpiredIDDBetween(string From, string To)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getExpiredIDDBtween();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":dFrom";
            param.Value = From;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dTo";
            param.Value = To;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetExpiredRequestByRequestId(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getExpiredIDDByRequestId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public void DueDiligenceAuditTrailStatusManager(GridDataItem item, string Remarks, int iStatus)
        {
            if (item[Remarks].Text == ((int) StageEnums.IddStage.AwaitingFocalPoint).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.AwaitingFocalPoint);
                item[Remarks].ForeColor = Color.Red;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.IddAnalystProgression).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.IddAnalystProgression);
                item[Remarks].ForeColor = Color.Red;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.ContactVMIDDLead).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.ContactVMIDDLead);
                item[Remarks].ForeColor = Color.Navy;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.Deadlocked).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.Deadlocked);
                item[Remarks].ForeColor = Color.Red;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.Expired).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.Expired);
                item[Remarks].ForeColor = Color.Red;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.FinalBlacklisted).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.FinalBlacklisted);
                item[Remarks].ForeColor = Color.Black;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.GIscreened).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.GIscreened);
                item[Remarks].ForeColor = Color.Green;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.Interim).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.Interim);
                item[Remarks].ForeColor = Color.Blue;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.MitigationOngoing).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.MitigationOngoing);
                item[Remarks].ForeColor = Color.Brown;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.OutstandingStatutoryDocuments).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.OutstandingStatutoryDocuments);
                item[Remarks].ForeColor = Color.Red;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.Processinitiated).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.Processinitiated);
                item[Remarks].ForeColor = Color.Chocolate;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.SiteVisitOngoing).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.SiteVisitOngoing);
                item[Remarks].ForeColor = Color.Green;
            }
            else if (item[Remarks].Text == ((int) StageEnums.IddStage.UndergoingGSSscreening).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.UndergoingGSSscreening);
                item[Remarks].ForeColor = Color.DarkGoldenrod;
            }
            else if (item[Remarks].Text == ((int)StageEnums.IddStage.RequestRejected).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.RequestRejected);
                item[Remarks].ForeColor = Color.Red;
            }
            else if (item[Remarks].Text == ((int)StageEnums.IddStage.others).ToString())
            {
                item[Remarks].Text = StageEnums.IddStageDesc(StageEnums.IddStage.others);
                item[Remarks].ForeColor = Color.Sienna;
            }


            if (item.Cells[iStatus].Text == ((int) ReportStatusEnums.VendorStatus.Amber).ToString())
            {
                item.Cells[iStatus].Text = ReportStatusEnums.VendorStatusDesc(ReportStatusEnums.VendorStatus.Amber);
                item.Cells[iStatus].BackColor = Color.Gold;
            }
            else if (item.Cells[iStatus].Text == ((int) ReportStatusEnums.VendorStatus.Gray).ToString())
            {
                item.Cells[iStatus].Text = ReportStatusEnums.VendorStatusDesc(ReportStatusEnums.VendorStatus.Gray);
                item.Cells[iStatus].BackColor = Color.Gray;
            }
            if (item.Cells[iStatus].Text == ((int) ReportStatusEnums.VendorStatus.Green).ToString())
            {
                item.Cells[iStatus].Text = ReportStatusEnums.VendorStatusDesc(ReportStatusEnums.VendorStatus.Green);
                item.Cells[iStatus].BackColor = Color.Green;
            }
            if (item.Cells[iStatus].Text == ((int) ReportStatusEnums.VendorStatus.Purple).ToString())
            {
                item.Cells[iStatus].Text = ReportStatusEnums.VendorStatusDesc(ReportStatusEnums.VendorStatus.Purple);
                item.Cells[iStatus].BackColor = Color.Purple;
            }
            if (item.Cells[iStatus].Text == ((int) ReportStatusEnums.VendorStatus.Red).ToString())
            {
                item.Cells[iStatus].Text = ReportStatusEnums.VendorStatusDesc(ReportStatusEnums.VendorStatus.Red);
                item.Cells[iStatus].BackColor = Color.Red;
            }
        }
    }

    public class IDDRequestDocsMgt
    {
        public IDDRequestDocsMgt()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool CreateRequestDocs(long lRequestId, byte[] bBlob, string sFileName, string sFileType)
        {
           OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.InsertRequestDocuments();

           OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":bBlobFile";
            param.Value = bBlob;
            param.OracleDbType = OracleDbType.Blob;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFileName";
            param.Value = sFileName;
            param.OracleDbType = OracleDbType.NVarchar2;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFileType";
            param.Value = sFileType;
            param.OracleDbType = OracleDbType.NVarchar2;
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
                //appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool UpdateRequestDocs(long lDocId, long lRequestId, byte[] bBlob, string sFileName)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.InsertRequestDocuments();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":bBlobFile";
            param.Value = bBlob;
            param.OracleDbType = OracleDbType.Blob;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFileName";
            param.Value = sFileName;
            param.OracleDbType = OracleDbType.NVarchar2;
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
                //appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool deleteDocById(long lDocId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.DeleteRequestDocuments();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lDocId";
            param.Value = lDocId;
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
                //appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public DataTable dtGetDocsByRequestId(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestDocumentsByRequestId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);

        }

        public DataTable dtGetRequestDocByDocId(long lDocId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getRequestDocumentByDocId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lDocId";
            param.Value = lDocId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public RequestDocs objGetRequestDocByDocId(long lDocsId)
        {
            DataTable dt = dtGetRequestDocByDocId(lDocsId);

            var o = new RequestDocs();
            foreach (DataRow dr in dt.Rows)
            {
                o = new RequestDocs(dr);
            }

            return o;
        }

        public List<RequestDocs> RetrieveRequestDocsById(long lRequestId)
        {
            var o = new List<RequestDocs>();

            return o;
        }
    }

    public class IDDRequestProgressReport
    {
        public IDDRequestProgressReport()
        {

        }

        public bool AddComment(RequestProgressReport o)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.addComment();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = o.m_iRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = o.m_iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = o.m_sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dDate";
            param.Value = o.m_dDateComment;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iAnalyst";
            param.Value = o.m_iAnalystId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool UpdateComment(RequestProgressReport o)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.updateComment();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = o.m_iRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":lReportId";
            param.Value = o.m_lReportId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = o.m_iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = o.m_sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dDate";
            param.Value = o.m_dDateComment;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iAnalyst";
            param.Value = o.m_iAnalystId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public DataTable dtGetReportProgressByRequestId(long lRequestId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getProgressReportByRequestId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }

    public class VendorReportMgt
    {
        public VendorReportMgt()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool AddNewVendor(long lRequestId, byte[] bBlob, string sFileName, string sFileType)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.InsertRequestDocuments();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":bBlobFile";
            param.Value = bBlob;
            param.OracleDbType = OracleDbType.Blob;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFileName";
            param.Value = sFileName;
            param.OracleDbType = OracleDbType.NVarchar2;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sFileType";
            param.Value = sFileType;
            param.OracleDbType = OracleDbType.NVarchar2;
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
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public DataTable GetVendors()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVendors();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetVendorById(long lVendorId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVendorsTById();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lVendorId";
            param.Value = lVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable dtGetVendorBySearch(string search)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVendorBySearch();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":Search";
            param.Value = "%" + Encoder.HtmlEncode(search.ToUpper()) + "%";
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public IEnumerable<Vendours> LstGetVendorsBySearch(string search)
        {
            DataTable dt = dtGetVendorBySearch(search);

            var o = new List<Vendours>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new Vendours(dr));
            }
            return o;
        }

        public DataTable dtGetVendorById(long iVendorId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVendorById();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iVendorId";
            param.Value = iVendorId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public Vendours objGetVendorById(long lVendorId)
        {
            DataTable dt = dtGetVendorById(lVendorId);

            var o = new Vendours();
            foreach (DataRow dr in dt.Rows)
            {
                o = new Vendours(dr);
            }

            return o;
        }

        public DataTable GetVendorByRegisteredName(string sRegisteredName)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVendorByRegisteredName();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":sRegisteredName";
            param.Value = "%" + Encoder.HtmlEncode(sRegisteredName.ToUpper()) + "%";
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public Vendours objGetVendorByRegisteredName(string sRegisteredName)
        {
            DataTable dt = GetVendorByRegisteredName(sRegisteredName);

            var o = new Vendours();
            foreach (DataRow dr in dt.Rows)
            {
                o = new Vendours(dr);
            }

            return o;
        }

        public DataTable GetVendorByVendourCode(string sVendourCode)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getVendorByVendourCode();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":sVendourCode";
            param.Value = sVendourCode;
            param.DbType = DbType.String;
            param.Size = 200;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public Vendours objGetVendorByVendourCode(string sVendourCode)
        {
            DataTable dt = GetVendorByVendourCode(sVendourCode);

            var o = new Vendours();
            foreach (DataRow dr in dt.Rows)
            {
                o = new Vendours(dr);
            }

            return o;
        }
    }

    public class StageEnums
    {
        public StageEnums()
        {

        }

        public enum IddStage
        {
            AwaitingFocalPoint = 1,
            IddAnalystProgression = 2,
            RequestRejected = 3,
            Processinitiated = 4,
            UndergoingGSSscreening = 5,
            SiteVisitOngoing = 6,
            GIscreened = 7,
            ContactVMIDDLead = 8,
            MitigationOngoing = 9,
            Deadlocked = 10,
            OutstandingStatutoryDocuments = 11,
            Expired = 12,
            Interim = 13,
            FinalBlacklisted = 14,
            others = 15

        };

        public static string IddStageDesc(IddStage eStatus)
        {
            string sRet = "UnKnown Account";
            try
            {
                switch (eStatus)
                {
                    case IddStage.AwaitingFocalPoint: sRet = "Awaiting CP IDD Focal Point's Action"; break;
                    case IddStage.IddAnalystProgression: sRet = "Awaiting IDD Analyst Action"; break;
                    case IddStage.RequestRejected: sRet = "Rejected"; break;
                    case IddStage.Processinitiated: sRet = "Process Initiated"; break;
                    case IddStage.UndergoingGSSscreening: sRet = "Undergoing GSS screening"; break;
                    case IddStage.SiteVisitOngoing: sRet = "Site Visit Ongoing"; break;
                    case IddStage.GIscreened: sRet = "GI screened"; break;
                    case IddStage.ContactVMIDDLead: sRet = "Contact VM/IDD Lead"; break;
                    case IddStage.MitigationOngoing: sRet = "Mitigation Ongoing"; break;
                    case IddStage.Deadlocked: sRet = "Deadlocked"; break;
                    case IddStage.OutstandingStatutoryDocuments: sRet = "Outstanding Statutory Documents"; break;
                    case IddStage.Expired: sRet = "Expired"; break;
                    case IddStage.Interim: sRet = "Interim"; break;
                    case IddStage.FinalBlacklisted: sRet = "Final (Blacklisted)"; break;
                    case IddStage.others: sRet = "Others"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }
    }

    public class ReportStatusEnums
    {
        public ReportStatusEnums()
        {

        }

        public enum VendorStatus
        {
            Amber = 3,
            Green = 4,
            Gray = 5,
            Purple = 6,
            Red = 7,
        };

        public static string VendorStatusDesc(VendorStatus eStatus)
        {
            string sRet = "UnKnown Account";
            try
            {
                switch (eStatus)
                {
                    case VendorStatus.Amber: sRet = "Amber"; break;
                    case VendorStatus.Green: sRet = "Green"; break;
                    case VendorStatus.Gray: sRet = "Gray"; break;
                    case VendorStatus.Purple: sRet = "Purple"; break;
                    case VendorStatus.Red: sRet = "Red"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }
    }

    public class CompletedEnums
    {
        public CompletedEnums()
        {

        }

        public enum CompletedStatus
        {
            Yes = 1,
            No = 0,
        };

        public static string CompletedStatusDesc(CompletedStatus eStatus)
        {
            string sRet = "UnKnown Account";
            try
            {
                switch (eStatus)
                {
                    case CompletedStatus.Yes: sRet = "Move Status to VSR"; break;
                    case CompletedStatus.No: sRet = "Do Not Move Status to VSR"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }
    }

    public class NatureOfRequest
    {
        public NatureOfRequest()
        {

        }

        public enum NatureOfRequestStatus
        {
            New = 1,
            Renewal = 2,
        };

        public static string NatureOfRequestStatusDesc(NatureOfRequestStatus eStatus)
        {
            string sRet = "UnKnown Account";
            try
            {
                switch (eStatus)
                {
                    case NatureOfRequestStatus.New: sRet = "New"; break;
                    case NatureOfRequestStatus.Renewal: sRet = "Renewal"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }
    }

    public class IDDAnalystAuditTrail
    {
        public IDDAnalystAuditTrail()
        {

        }

        public bool RequestActionAuditTrail(long lRequestId, int iUserId, int iStage, int iStatus, string sComments)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.RequestActionAuditTrail();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lRequestId";
            param.Value = lRequestId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dDateComment";
            param.Value = DateTime.Today.Date;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);


            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool UpdateActionAuditTrail(long lAuditId, int iUserId, int iStage, int iStatus, int iYesNo, string sComments, string sApproverComments)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.UpdateActionAuditTrail();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lAuditId";
            param.Value = lAuditId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStage";
            param.Value = iStage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iStatus";
            param.Value = iStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sComments";
            param.Value = sComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sApproverComments";
            param.Value = sApproverComments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iYesNo";
            param.Value = iYesNo;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":dDateComment";
            param.Value = DateTime.Today.Date;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }


        public DataTable dtGetAnalystAuditTrailById(long lAuditId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getAuditTraiByRequestId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lAuditId";
            param.Value = lAuditId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public AnalystAuditTrail objGetAnalystAuditTrailById(long lAuditId)
        {
            DataTable dt = dtGetAnalystAuditTrailById(lAuditId);

            var o = new AnalystAuditTrail();
            foreach (DataRow dr in dt.Rows)
            {
                o = new AnalystAuditTrail(dr);
            }
            return o;
        }


        #region ========================  GOING OUT OF FASHION ================================

       

        //public bool UpdateVendor(long lDocId, long lRequestId, byte[] bBlob, string sFileName)
        //{
        //    OracleCommand comm = GenericDataAccess.CreateCommand();
        //    comm.CommandText = StoredProcedureIDD.InsertRequestDocuments();

        //    OracleParameter param = comm.CreateParameter();
        //    param.ParameterName = ":lRequestId";
        //    param.Value = lRequestId;
        //    param.DbType = DbType.Int64;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":bBlobFile";
        //    param.Value = bBlob;
        //    param.OracleDbType = OracleDbType.Binary;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sFileName";
        //    param.Value = sFileName;
        //    param.OracleDbType = OracleDbType.NVarChar;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    // result will represent the number of changed rows
        //    int result = -1;
        //    try
        //    {
        //        // execute the stored procedure
        //        result = GenericDataAccess.ExecuteNonQuery(comm);
        //    }
        //    catch (Exception ex)
        //    {
        //        appMonitor.logAppExceptions(ex);
        //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //    }
        //    // result will be 1 in case of success
        //    return (result != -1);
        //}


        //public bool CreateRequest(RequestForIDD o, ref long lRequestId, ref string sIDDNumber)
        //{
        //    IDDIdentity c = IDDIdentifier();
        //    lRequestId = c.lRequestID;
        //    o.m_lRequestId = c.lRequestID;
        //    o.m_sIDDNo = c.sRequestNumber;
        //    sIDDNumber = c.sRequestNumber;

        //    OracleCommand comm = GenericDataAccess.CreateCommand();
        //    comm.CommandText = StoredProcedureIDD.CreateIDD();

        //    OracleParameter param = comm.CreateParameter();
        //    param.ParameterName = ":lRequestId";
        //    param.Value = lRequestId;
        //    param.DbType = DbType.Int64;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sIDDNo";
        //    param.Value = o.m_sIDDNo;
        //    param.DbType = DbType.String;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":iUserId";
        //    param.Value = o.m_iUserId;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":iCategoryId";
        //    param.Value = o.m_iCategoryId;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sVendourCode";
        //    param.Value = o.m_sVendourCode;
        //    param.DbType = DbType.String;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sRegisteredName";
        //    param.Value = o.m_sRegisteredName;
        //    param.DbType = DbType.String;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sAddress";
        //    param.Value = o.m_sAddress;
        //    param.DbType = DbType.String;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sRepresentative";
        //    param.Value = o.m_sRepresentative;
        //    param.DbType = DbType.String;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sEmailAddress";
        //    param.Value = o.m_sEmailAddress;
        //    param.DbType = DbType.String;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":sTelephoneNo";
        //    param.Value = o.m_sTelephoneNumber;
        //    param.DbType = DbType.String;
        //    param.Size = 2000;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":iStage";
        //    param.Value = o.m_iStatus;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":dDateSubmitted";
        //    param.Value = DateTime.Now.Date;
        //    param.DbType = DbType.Date;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":iNor";
        //    param.Value = o.m_iNoR;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":dAmount";
        //    param.Value = o.m_dAmount;
        //    param.DbType = DbType.Decimal;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":iGo";
        //    param.Value = o.m_iGO;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = ":iGi";
        //    param.Value = o.m_iGI;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    int result = -1;

        //    try
        //    {
        //        // execute the stored procedure
        //        result = GenericDataAccess.ExecuteNonQuery(comm);
        //    }
        //    catch (Exception ex)
        //    {
        //        // any errors are logged in GenericDataAccess, we ignore them here
        //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //    }
        //    // result will be 1 in case of success
        //    return (result != -1);
        //}


        #endregion
    }
}