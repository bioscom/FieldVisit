using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web.UI.WebControls;
using CS.DAL;
using Microsoft.Security.Application;

namespace CS.BLL.PPMS
{
    /// <summary>
    /// Summary description for ActionTrackerRegister
    /// </summary>
    public class ActionTrackerRegister
    {
        //Fields
        public long lActionId { get; set; }
        public string sAction { get; set; }
        //public int iCategory { get; set; }
        public int Importance { get; set; }
        public int Urgency { get; set; }
        public DateTime DateClosedOut { get; set; }
        public int ProjectStatus { get; set; }
        public string Comments { get; set; }
        public string Activities { get; set; }
        public string NextSteps { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateLastActioned { get; set; }

        //NAVIGATORS
        public Themes Theme { get; set; }
        public FunctionAsset TfunctionAsset { get; set; }
        public appUsers ActionParty { get; set; }
        public appUsers FocalPoint { get; set; }
        public CS.BLL.PPMS.Category Tcategory { get; set; }

        public ActionTrackerRegister()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ActionTrackerRegister(DataRow dr)
        {
            lActionId = long.Parse(dr["ACTIONID"].ToString());
            ActionParty = appUsersHelper.objGetUserByUserId(int.Parse(dr["ACTIONPARTYUSERID"].ToString()));
            Activities = dr["ACTIVITIES"].ToString();
            Comments = dr["COMMENTS"].ToString();
            DateClosedOut = DateTime.Parse(dr["DATECLOSEDOUT"].ToString());
            DateSubmitted = DateTime.Parse(dr["DATESUBMITTED"].ToString());
            DateLastActioned = DateTime.Parse(dr["DATELASTACTIONED"].ToString());
            FocalPoint = appUsersHelper.objGetUserByUserId(int.Parse(dr["USERID"].ToString()));
            Importance = int.Parse(dr["IMPORTANCE"].ToString());
            NextSteps = dr["NEXTSTEPS"].ToString();
            ProjectStatus = int.Parse(dr["STATUS"].ToString());
            sAction = dr["ACTION"].ToString();
            Tcategory = CategoryHelper.ObjGetCategoryById(int.Parse(dr["CATEGORYID"].ToString()));
            Theme = ThemesHelper.ObjGetThemeById(int.Parse(dr["THEMEID"].ToString()));
            TfunctionAsset = FunctionAssetHelper.ObjGetAssetById(int.Parse(dr["ASSETID"].ToString()));
            Urgency = int.Parse(dr["URGENCY"].ToString());
        }
    }

    public class ActionTrackerRegisterHelper
    {
        //Insert
        public static bool InsertActionTracker(ActionTrackerRegister oActionTracker)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.InsertProject();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iActionPartyId";
            param.Value = oActionTracker.ActionParty.m_iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":Activities";
            param.Value = oActionTracker.Activities;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":Comments";
            param.Value = oActionTracker.Comments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":DateClosedOut";
            param.Value = oActionTracker.DateClosedOut;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":DateLastActioned";
            param.Value = oActionTracker.DateLastActioned;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":DateSubmitted";
            param.Value = oActionTracker.DateSubmitted;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":FocalPoint";
            param.Value = oActionTracker.FocalPoint.m_iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iImportance";
            param.Value = oActionTracker.Importance;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":NextSteps";
            param.Value = oActionTracker.NextSteps;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":ProjectStatus";
            param.Value = oActionTracker.ProjectStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = oActionTracker.Tcategory.CategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":AssetId";
            param.Value = oActionTracker.TfunctionAsset.AssetId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iThemeId";
            param.Value = oActionTracker.Theme.ThemeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUrgency";
            param.Value = oActionTracker.Urgency;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAction";
            param.Value = oActionTracker.sAction;
            param.DbType = DbType.String;
            param.Size = 2000;
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

        //Update
        public static bool UpdateActionTracker(ActionTrackerRegister oActionTracker)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.UpdateProject();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lActionId";
            param.Value = oActionTracker.lActionId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iActionPartyId";
            param.Value = oActionTracker.ActionParty.m_iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":Activities";
            param.Value = oActionTracker.Activities;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":Comments";
            param.Value = oActionTracker.Comments;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":DateClosedOut";
            param.Value = oActionTracker.DateClosedOut;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":DateLastActioned";
            param.Value = oActionTracker.DateLastActioned;
            param.DbType = DbType.Date;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":FocalPoint";
            param.Value = oActionTracker.FocalPoint.m_iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iImportance";
            param.Value = oActionTracker.Importance;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":NextSteps";
            param.Value = oActionTracker.NextSteps;
            param.DbType = DbType.String;
            param.Size = 2000;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":ProjectStatus";
            param.Value = oActionTracker.ProjectStatus;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = oActionTracker.Tcategory.CategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":AssetId";
            param.Value = oActionTracker.TfunctionAsset.AssetId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iThemeId";
            param.Value = oActionTracker.Theme.ThemeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iUrgency";
            param.Value = oActionTracker.Urgency;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":sAction";
            param.Value = oActionTracker.sAction;
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

        //Delete

        //Get All Actions
        public static DataTable DtGetActions()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackers();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static DataTable DtGetMyProjects(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetMyProjects();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iFocalPoint";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iActionParty";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static DataTable DtGetProjectByActionTitle(string sAction)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetProjectByActionTitle();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":SEARCHKEY";
            param.Value = "%" + Encoder.HtmlEncode(sAction) + "%";
            param.DbType = DbType.String;
            param.Size = 500;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static DataTable DtGetActionById(long lActionId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByActionId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":lActionId";
            param.Value = lActionId;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static ActionTrackerRegister ObjGetActionById(long lActionId)
        {
            var dt = DtGetActionById(lActionId);

            var oActionTracker = new ActionTrackerRegister();
            foreach (DataRow dr in dt.Rows)
            {
                oActionTracker = new ActionTrackerRegister(dr);
            }
            return oActionTracker;
        }

        //Get Actions by Asset
        public static DataTable DtGetActionByAssetId(int iAssetId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByAssetId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iAssetId";
            param.Value = iAssetId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static List<ActionTrackerRegister> LstGetActions()
        {
            var dt = DtGetActions();

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }
        public static List<ActionTrackerRegister> LstGetActionsByAssetId(int iAssetId)
        {
            var dt = DtGetActionByAssetId(iAssetId);

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }


        //Get Actions by Category
        public static DataTable DtGetActionByCategoryId(int iCategoryId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByCategoryId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static List<ActionTrackerRegister> LstGetActionsByCategoryId(int iCategoryId)
        {
            DataTable dt = DtGetActionByCategoryId(iCategoryId);

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }

        //Get Actions By Focal Point
        public static DataTable DtGetActionByFocalPoint(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByFocalPoint();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static List<ActionTrackerRegister> LstGetActionsByFocalPoint(int iUserId)
        {
            DataTable dt = DtGetActionByFocalPoint(iUserId);

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }

        //Get Actions by Action Party.
        public static DataTable DtGetActionByActionParty(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByActionParty();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static List<ActionTrackerRegister> LstGetActionsByActionParty(int iUserId)
        {
            DataTable dt = DtGetActionByActionParty(iUserId);

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }

        //Get Actions By Themes
        public static DataTable DtGetActionByTheme(int iThemeId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByTheme();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iThemeId";
            param.Value = iThemeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static List<ActionTrackerRegister> LstGetActionsByTheme(int iThemeId)
        {
            DataTable dt = DtGetActionByTheme(iThemeId);

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }

        //Get Actions by Urgency
        public static DataTable DtGetActionByUrgency(int iUrgency)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByUrgency();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUrgency";
            param.Value = iUrgency;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static List<ActionTrackerRegister> LstGetActionsByUrgency(int iUrgency)
        {
            DataTable dt = DtGetActionByUrgency(iUrgency);

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }

        //Get Actions by Importance
        public static DataTable DtGetActionByImportance(int iImportance)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureActionTracker.GetActionTrackerByImportance();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iImportance";
            param.Value = iImportance;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static List<ActionTrackerRegister> LstGetActionsByImportance(int iImportance)
        {
            DataTable dt = DtGetActionByImportance(iImportance);

            var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
            lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
            return lstActionTracker;
        }


        public static void ManageReport(GridView oGridView)
        {
            foreach (GridViewRow grdRow in oGridView.Rows)
            {
                Label lbImportance = (Label)grdRow.FindControl("lblImportance");
                Label lbUrgency = (Label)grdRow.FindControl("lblUrgency");
                Label lbStatus = (Label)grdRow.FindControl("lblStatus");

                if (lbImportance.Text == ((int)appEnumList.mImportance.H).ToString())
                {
                    lbImportance.Text = appEnumList.ImportanceDesc(appEnumList.mImportance.H);
                    grdRow.Cells[6].BackColor = System.Drawing.Color.Red;
                }
                else if (lbImportance.Text == ((int)appEnumList.mImportance.M).ToString())
                {
                    lbImportance.Text = appEnumList.ImportanceDesc(appEnumList.mImportance.M);
                    grdRow.Cells[6].BackColor = System.Drawing.Color.DarkOrange;
                }
                else if (lbImportance.Text == ((int)appEnumList.mImportance.L).ToString())
                {
                    lbImportance.Text = appEnumList.ImportanceDesc(appEnumList.mImportance.L);
                    grdRow.Cells[6].BackColor = System.Drawing.Color.Cyan;
                }


                if (lbUrgency.Text == ((int)appEnumList.mUrgency.Ok).ToString())
                {
                    lbUrgency.Text = appEnumList.UrgencyDesc(appEnumList.mUrgency.Ok);
                    grdRow.Cells[7].BackColor = System.Drawing.Color.Green;
                }
                else if (lbUrgency.Text == ((int)appEnumList.mUrgency.OverDue).ToString())
                {
                    lbUrgency.Text = appEnumList.UrgencyDesc(appEnumList.mUrgency.OverDue);
                    grdRow.Cells[7].BackColor = System.Drawing.Color.Red;
                }
                else if (lbUrgency.Text == ((int)appEnumList.mUrgency.Na).ToString())
                {
                    lbUrgency.Text = appEnumList.UrgencyDesc(appEnumList.mUrgency.Na);
                    grdRow.Cells[7].BackColor = System.Drawing.Color.White;
                }


                if (lbStatus.Text == ((int)appEnumList.mProjectStatus.InProgress).ToString())
                {
                    lbStatus.Text = appEnumList.ProjectStatusDesc(appEnumList.mProjectStatus.InProgress);
                    grdRow.Cells[8].BackColor = System.Drawing.Color.DarkOrange;
                }
                else if (lbStatus.Text == ((int)appEnumList.mProjectStatus.Completed).ToString())
                {
                    lbStatus.Text = appEnumList.ProjectStatusDesc(appEnumList.mProjectStatus.Completed);
                    grdRow.Cells[8].BackColor = System.Drawing.Color.Green;
                }
                else if (lbStatus.Text == ((int)appEnumList.mProjectStatus.NotStated).ToString())
                {
                    lbStatus.Text = appEnumList.ProjectStatusDesc(appEnumList.mProjectStatus.NotStated);
                    grdRow.Cells[8].BackColor = System.Drawing.Color.Red;
                }
            }
        }


        //Get Actions By Date Submitted
        //public static DataTable DtGetActionByDateSubmitted(DateTime dDateSubmitted)
        //{
        //    OracleCommand comm = GenericDataAccess.CreateCommand();
        //    comm.CommandText = StoredProcedureActionTracker.getAlarmRateFacilitiesByDistrict();

        //    OracleParameter param = comm.CreateParameter();
        //    param.ParameterName = ":dDateSubmitted";
        //    param.Value = dDateSubmitted;
        //    param.DbType = DbType.Date;
        //    comm.Parameters.Add(param);

        //    return GenericDataAccess.ExecuteSelectCommand(comm);
        //}

        //public static List<ActionTrackerRegister> LstGetActionsByDateSubmitted(DateTime dDateSubmitted)
        //{
        //    DataTable dt = DtGetActionByDateSubmitted(dDateSubmitted);

        //    var lstActionTracker = new List<ActionTrackerRegister>(dt.Rows.Count);
        //    lstActionTracker.AddRange(from DataRow dr in dt.Rows select new ActionTrackerRegister(dr));
        //    return lstActionTracker;
        //}

        //
    }
}