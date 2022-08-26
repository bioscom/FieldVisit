using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Reflection.Emit;
using CS.DAL;

/// <summary>
/// Summary description for Category
/// </summary>


namespace CS.BLL.PPMS
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string SCategory { get; set; }
        public Category()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Category(DataRow dr)
        {
            CategoryId = int.Parse(dr["CATEGORYID"].ToString());
            SCategory = dr["CATEGORY"].ToString();
        }
    }


    public class CategoryHelper
    {
        public static bool InsertCategory(string sCategory, ref int iCategoryId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.InsertCategory();

            iCategoryId = GetCategoryId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sCategory";
            param.Value = sCategory;
            param.DbType = DbType.String;
            param.Size = 1000;
            comm.Parameters.Add(param);

            var result = -1;

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

        private static int GetCategoryId()
        {
            string sql = "SELECT PPMS_CATEGORY_SEQ.NEXTVAL FROM DUAL";
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sql;

            int iCategoryId = 0;
            try
            {
                DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
                iCategoryId = Convert.ToInt32(dt.Rows[0]["NEXTVAL"].ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

            return iCategoryId;
        }


        public static DataTable DtGetCategories()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetCategories();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static DataTable DtGetCategoryById(int iCategoryId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetCategoryById();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static Category ObjGetCategoryById(int iThemeId)
        {
            DataTable dt = DtGetCategoryById(iThemeId);

            Category oCategory = new Category();
            foreach (DataRow dr in dt.Rows)
            {
                oCategory = new Category(dr);
            }
            return oCategory;
        }

        public static List<Category> LstGetCategoryCategories()
        {
            DataTable dt = DtGetCategories();

            List<Category> lstCategories = new List<Category>(dt.Rows.Count);
            lstCategories.AddRange(from DataRow dr in dt.Rows select new Category(dr));
            return lstCategories;
        }
    }
}