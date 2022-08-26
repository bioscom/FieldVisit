using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Category
/// </summary>


namespace EIdd
{
    public class CategoryMgt
    {
        public CategoryMgt()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool AssignCategoryLeadToCategory(int iUserId, int iCategoryId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.AssignCategoryLead();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
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

        public DataTable GetServices()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getServices();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetServiceByServiceId(int iServiceId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getServiceByServiceId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iServiceId";
            param.Value = iServiceId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public Category objGetServiceByServiceId(int iServiceId)
        {
            DataTable dt = GetServiceByServiceId(iServiceId);

            var o = new Category();
            foreach (DataRow dr in dt.Rows)
            {
                o = new Category(dr);
            }

            return o;
        }

        public List<Category> lstGetServiceByServiceId(int iServiceId)
        {
            DataTable dt = GetServiceByServiceId(iServiceId);

            var o = new List<Category>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new Category(dr));
            }

            return o;
        }

        public DataTable GetServicesByLocation(int iLocationId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getServicesByLocation();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iLocationId";
            param.Value = iLocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<Category> LstGetServicesByLocation(int iLocationId)
        {
            DataTable dt = GetServicesByLocation(iLocationId);

            var o = new List<Category>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new Category(dr));
            }
            return o;
        }

        public List<Category> LstGetServices()
        {
            DataTable dt = GetServices();

            var o = new List<Category>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new Category(dr));
            }
            return o;
        }

        public DataTable GetServicesByLocationDepartment(int iLocationId, int iDept)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getServicesByLocationDepartment();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iLocationId";
            param.Value = iLocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iDept";
            param.Value = iDept;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetServicesByDepartment(int iDept)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getServicesByDepartment();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iDept";
            param.Value = iDept;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<Category> LstGetServicesByLocationDepartment(int iLocationId, int iDept)
        {
            DataTable dt = GetServicesByLocationDepartment(iLocationId, iDept);

            var o = new List<Category>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new Category(dr));
            }
            return o;
        }


        public DataTable GetChildNodes(string iCategoryId)
        {
            string sql = "SELECT IDD_CATEGORY.CATEGORYID, IDD_CATEGORY.CATEGORY, IDD_REQUEST.REQUESTID, IDD_REQUEST.VENDOURCODE, IDD_REQUEST.REGISTEREDNAME ";
            sql += "FROM IDD_CATEGORY INNER JOIN IDD_REQUEST ON IDD_CATEGORY.CATEGORYID = IDD_REQUEST.CATEGORYID WHERE IDD_CATEGORY.CATEGORYID = :iCategoryId ";

            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sql;

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
    }
}