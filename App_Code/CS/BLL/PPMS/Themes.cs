using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using CS.DAL;

/// <summary>
/// Summary description for Themes
/// </summary>
/// 
/// 

namespace CS.BLL.PPMS
{
    public class Themes
    {
        public int ThemeId { get; set; }
        public string STheme { get; set; }
        public Themes()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Themes(DataRow dr)
        {
            ThemeId = int.Parse(dr["THEMEID"].ToString());
            STheme = dr["THEMES"].ToString();
        }

        
    }


    public class ThemesHelper
    {
        public static bool InsertTheme(string sTheme, ref int iThemeId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.InsertTheme();

            iThemeId = GetThemeId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iThemeId";
            param.Value = iThemeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sTheme";
            param.Value = sTheme;
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

        private static int GetThemeId()
        {
            string sql = "SELECT PPMS_THEME_SEQ.NEXTVAL FROM DUAL";
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = sql;

            int iAssetId = 0;
            try
            {
                DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
                iAssetId = Convert.ToInt32(dt.Rows[0]["NEXTVAL"].ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }

            return iAssetId;
        }


        public static DataTable DtGetThemes()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetThemes();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static DataTable DtGetThemeById(int iThemeId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetThemeById();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iThemeId";
            param.Value = iThemeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static Themes ObjGetThemeById(int iThemeId)
        {
            DataTable dt = DtGetThemeById(iThemeId);

            Themes oThemes = new Themes();
            foreach (DataRow dr in dt.Rows)
            {
                oThemes = new Themes(dr);
            }
            return oThemes;
        }

        public static List<Themes> LstGeThemeses()
        {
            DataTable dt = DtGetThemes();

            List<Themes> lstThemes = new List<Themes>(dt.Rows.Count);
            lstThemes.AddRange(from DataRow dr in dt.Rows select new Themes(dr));
            return lstThemes;
        }
    }

}
