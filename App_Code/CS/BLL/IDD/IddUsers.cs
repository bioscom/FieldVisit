using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using Telerik.Web.UI;

/// <summary>
/// Summary description for Admins
/// </summary>
/// 
namespace EIdd
{
    public class eIddUsers
    {
        public int m_iUserId { get; set; }
        public string m_sUserName { get; set; }
        public string m_sUserMail { get; set; }
        public string m_sFullName { get; set; }
        public string m_sRefInd { get; set; }

        public eIddUsers()
        {

        }

        public eIddUsers(DataRow dr)
        {
            m_iUserId = int.Parse(dr["USERID"].ToString());
            m_sUserName = dr["USERNAME"].ToString();
            m_sUserMail = dr["EMAIL"].ToString();
            m_sFullName = dr["FULLNAME"].ToString();
            m_sRefInd = dr["REFIND"].ToString();
        }

        public structUserMailIdx structUserIdx
        {
            get
            {
                return new structUserMailIdx(m_sFullName, m_sUserMail, m_sUserName);
            }
        }
    }

    public class Admins
    {
        public Admins()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetAdmins()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getAdministators();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetAdminByUserId(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getAdministatorByUserId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public eIddUsers objGetAdminByUserId(int iUserId)
        {
            DataTable dt = GetAdminByUserId(iUserId);

            var o = new eIddUsers();
            foreach (DataRow dr in dt.Rows)
            {
                o = new eIddUsers(dr);
            }

            return o;
        }

        public bool AddAdministrator(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.addAdministrator();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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

        public bool RemoveAdmin(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.RemoveAdministrator();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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

    }

    public class Corporate
    {
        public Corporate()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCorporates()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getCorporateUsers();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetCorporateUserByUserId(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getCorporateUserByUserId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public eIddUsers objGetCorporateUserByUserId(int iUserId)
        {
            DataTable dt = GetCorporateUserByUserId(iUserId);

            var o = new eIddUsers();
            foreach (DataRow dr in dt.Rows)
            {
                o = new eIddUsers(dr);
            }

            return o;
        }

        public bool AddCorporateUser(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.addCorporateUser();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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

        public bool RemoveCorporateUser(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.RemoveCorporateUser();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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

    }




    public class Analysts
    {
        public Analysts()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetAnalysts()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getOrderedAnalysts();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<eIddUsers> lstGetAnalysts()
        {
            DataTable dt = GetAnalysts();
            var o = new List<eIddUsers>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new eIddUsers(dr));
            }

            return o;
        }

        public DataTable GetAnalystByUserId(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getAnalystByUserId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public eIddUsers objGetAnalystByUserId(int iUserId)
        {
            DataTable dt = GetAnalystByUserId(iUserId);

            var o = new eIddUsers();
            foreach (DataRow dr in dt.Rows)
            {
                o = new eIddUsers(dr);
            }

            return o;
        }

        public bool AddAnalyst(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.addAnalyst();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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

        public bool RemoveAnalyst(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.RemoveAnalyst();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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
                appMonitor.logAppExceptions(ex);
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }
    }

    public class LeadFocalPoint
    {
        public LeadFocalPoint()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetLeadFocalPoints()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getLeadFocalPoints();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }


        public List<eIddUsers> lstGetCPIDDFocalPoints()
        {
            DataTable dt = GetLeadFocalPoints();
            var o = new List<eIddUsers>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new eIddUsers(dr));
            }

            return o;
        }

        public DataTable GetLeadFocalPointByUserId(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getLeadFocalPointByUserId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public eIddUsers objGetLeadFocalPointByUserId(int iUserId)
        {
            DataTable dt = GetLeadFocalPointByUserId(iUserId);

            var o = new eIddUsers();
            foreach (DataRow dr in dt.Rows)
            {
                o = new eIddUsers(dr);
            }

            return o;
        }

        public bool AddLeadFocalPoint(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.addLeadFocalPoint();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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

        public bool RemoveLeadFocalPoint(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.RemoveLeadFocalPoint();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
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

    }

    public static class Utilities
    {
        static Utilities()
        {

        }

        public static void Search(string criteria, RadComboBox ddl)
        {
            try
            {
                List<appUsers> olst = appUsersHelper.lstGetAllUsers().Where(t => t.m_iStatus == (int)appUsersRoles.userStatus.activeUser && t.m_sFullName.ToUpper().Contains(criteria.ToUpper())).ToList();
                RadComboControlLoader(olst, ddl);
            }
            catch(Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }

        private static void RadComboControlLoader(List<appUsers> lst, RadComboBox RadDdl)
        {
            foreach (appUsers o in lst)
            {
                var item = new RadComboBoxItem();
                item.Text = o.m_sFullName;
                item.Value = o.m_iUserId.ToString();

                string email = o.m_sUserMail;
                string refInd = o.m_sRefInd;

                item.Attributes.Add("EMAIL", email);
                item.Attributes.Add("REFIND", refInd);

                RadDdl.Items.Add(item);
                item.DataBind();
            }
        }

        public static void RadComboControlLoader2(DataTable dt, RadComboBox RadDdl)
        {
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = new RadComboBoxItem();
                    item.Text = (string)dr["REGISTEREDNAME"];
                    item.Value = dr["VENDORID"].ToString();

                    string email = dr["EMAILADDRESS"].ToString();
                    string refInd = dr["TELEPHONENO"].ToString();

                    item.Attributes.Add("EMAILADDRESS", email);
                    item.Attributes.Add("TELEPHONENO", refInd);

                    RadDdl.Items.Add(item);
                    item.DataBind();
                }
            }

            //if (dt != null)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        var item = new RadComboBoxItem();
            //        item.Text = (string)dr["FULLNAME"];
            //        item.Value = dr["USERID"].ToString();

            //        string email = dr["EMAIL"].ToString();
            //        string refInd = dr["REFIND"].ToString();

            //        item.Attributes.Add("EMAIL", email);
            //        item.Attributes.Add("REFIND", refInd);
            //        //item.Value += ":" + refInd;

            //        RadDdl.Items.Add(item);
            //        item.DataBind();
            //    }
            //}
        }

        public static void RadComboGetUser(string sText, int iValue, RadComboBox RadDdl)
        {
            var item = new RadComboBoxItem();
            item.Text = sText;
            item.Value = iValue.ToString();

            RadDdl.Items.Add(item);
            item.DataBind();
        }
    }

}