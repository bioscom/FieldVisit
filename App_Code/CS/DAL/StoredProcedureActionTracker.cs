namespace CS.DAL
{
    /// <summary>
    /// Summary description for StoredProcedureActionTracker
    /// </summary>
    public class StoredProcedureActionTracker
    {
        public StoredProcedureActionTracker()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string GetActionTrackers()
        {
            var sql = "SELECT PPMS_ACTIONTRACKER.ACTIONID, PPMS_ACTIONTRACKER.ACTIONPARTY AS ACTIONPARTYUSERID, FOCALPOINT.USERID, ACTIONPARTY.FULLNAME AS ACTIONPARTYFULLNAME, FOCALPOINT.FULLNAME AS FOCALPOINTFULLNAME, ";
            sql += "PPMS_ACTIONTRACKER.ACTIVITIES, PPMS_ACTIONTRACKER.COMMENTS, PPMS_ACTIONTRACKER.DATECLOSEDOUT, PPMS_ACTIONTRACKER.DATESUBMITTED, ";
            sql += "PPMS_ACTIONTRACKER.DATELASTACTIONED, PPMS_ACTIONTRACKER.IMPORTANCE, PPMS_ACTIONTRACKER.NEXTSTEPS, PPMS_ACTIONTRACKER.STATUS, ";
            sql += "PPMS_ACTIONTRACKER.ACTION, PPMS_CATEGORY.CATEGORYID, PPMS_CATEGORY.CATEGORY, PPMS_THEME.THEMEID, PPMS_THEME.THEMES, PPMS_ASSET.ASSETID, ";
            sql += "PPMS_ASSET.ASSET, PPMS_ACTIONTRACKER.URGENCY FROM PPMS_ACTIONTRACKER ";
            sql += "INNER JOIN PPMS_ASSET ON PPMS_ASSET.ASSETID = PPMS_ACTIONTRACKER.ASSETID ";
            sql += "INNER JOIN PPMS_CATEGORY ON PPMS_CATEGORY.CATEGORYID = PPMS_ACTIONTRACKER.CATEGORYID ";
            sql += "INNER JOIN PPMS_THEME ON PPMS_THEME.THEMEID = PPMS_ACTIONTRACKER.THEMEID ";
            sql += "INNER JOIN PROD_USERMGT ACTIONPARTY ON ACTIONPARTY.USERID = PPMS_ACTIONTRACKER.ACTIONPARTY ";
            sql += "INNER JOIN PROD_USERMGT FOCALPOINT ON FOCALPOINT.USERID = PPMS_ACTIONTRACKER.USERID ";

            return sql;
        }

        public static string GetMyProjects()
        {
            var sql = GetActionTrackers();
            sql += " WHERE (ACTIONPARTYUSERID = :iActionParty) OR (FOCALPOINT.USERID = :iFocalPoint)";
            return sql;
        }
        public static string GetProjectByActionTitle()
        {
            string sql = GetActionTrackers();
            sql += " WHERE (UPPER(PPMS_ACTIONTRACKER.ACTION) LIKE UPPER(:SEARCHKEY))";
            return sql;
        }

        public static string GetActionTrackerByActionId()
        {
            var sql = GetActionTrackers();
            sql += " WHERE PPMS_ACTIONTRACKER.ACTIONID = :lActionId";
            return sql;
        }

        public static string GetActionTrackerByAssetId()
        {
            string sql = GetActionTrackers();
            sql += " WHERE PPMS_ASSET.ASSETID = :iAssetId";
            return sql;
        }

        public static string GetActionTrackerByCategoryId()
        {
            string sql = GetActionTrackers();
            sql += " WHERE PPMS_CATEGORY.CATEGORYID = :iCategoryId";
            return sql;
        }

        public static string GetActionTrackerByFocalPoint()
        {
            string sql = GetActionTrackers();
            sql += " WHERE FOCALPOINT.USERID = :iUserId";
            return sql;
        }

        public static string GetActionTrackerByActionParty()
        {
            string sql = GetActionTrackers();
            sql += " WHERE ACTIONPARTY.USERID = :iUserId";
            return sql;
        }

        public static string GetActionTrackerByTheme()
        {
            string sql = GetActionTrackers();
            sql += " WHERE PPMS_THEME.THEMEID = :iThemeId";
            return sql;
        }
        public static string GetActionTrackerByUrgency()
        {
            string sql = GetActionTrackers();
            sql += " WHERE PPMS_ACTIONTRACKER.URGENCY = :iUrgency";
            return sql;
        }

        public static string GetActionTrackerByImportance()
        {
            string sql = GetActionTrackers();
            sql += " WHERE PPMS_ACTIONTRACKER.IMPORTANCE = :iImportance";
            return sql;
        }

        public static string InsertProject()
        {
            var sql = "INSERT INTO PPMS_ACTIONTRACKER (ACTIONPARTY, USERID, ACTIVITIES, COMMENTS, DATECLOSEDOUT, DATESUBMITTED, DATELASTACTIONED, ";
            sql += "IMPORTANCE, NEXTSTEPS, STATUS, ACTION, CATEGORYID, THEMEID, ASSETID, URGENCY) ";
            sql += "VALUES (:iActionPartyId, :FocalPoint, :Activities, :Comments, :DateClosedOut, :DateSubmitted, :DateLastActioned, :iImportance, ";
            sql += ":NextSteps, :ProjectStatus, :sAction, :iCategoryId, :iThemeId, :AssetId, :iUrgency) ";

            return sql;
        }

        public static string UpdateProject()
        {
            var sql = "UPDATE PPMS_ACTIONTRACKER SET ACTIONPARTY = :iActionPartyId, USERID = :FocalPoint, ACTIVITIES = :Activities, ";
            sql += "COMMENTS = :Comments, DATECLOSEDOUT = :DateClosedOut, DATELASTACTIONED = :DateLastActioned, ";
            sql += "IMPORTANCE = :iImportance, NEXTSTEPS = :NextSteps, STATUS = :ProjectStatus, ACTION = :sAction, ";
            sql += "CATEGORYID = :iCategoryId, THEMEID = :iThemeId, ASSETID = :AssetId, URGENCY = :iUrgency WHERE ACTIONID = :lActionId ";

            return sql;
        }

        public static string GetCategories()
        {
            var sql = "SELECT CATEGORY, CATEGORYID FROM PPMS_CATEGORY ";
            return sql; 
        }

        public static string GetThemes()
        {
            var sql = "SELECT THEMES, THEMEID FROM PPMS_THEME ";
            return sql;
        }

        public static string GetAssets()
        {
            var sql = "SELECT ASSET, ASSETID FROM PPMS_ASSET ";
            return sql;
        }

        public static string GetCategoryById()
        {
            var sql = GetCategories();
            sql += " WHERE CATEGORYID = :iCategoryId";
            return sql;
        }

        public static string InsertCategory()
        {
            var sql = "INSERT INTO PPMS_CATEGORY (CATEGORYID, CATEGORY) VALUES (:iCategoryId, :sCategory)";

            return sql;
        }

        public static string InsertAsset()
        {
            var sql = "INSERT INTO PPMS_ASSET (ASSETID, ASSET) VALUES (:iAssetId, :sAsset)";

            return sql;
        }

        public static string InsertTheme()
        {
            var sql = "INSERT INTO PPMS_THEME (THEMEID, THEMES) VALUES (:iThemeId, :sTheme)";

            return sql;
        }

        public static string GetThemeById()
        {
            var sql = GetThemes();
            sql += " WHERE THEMEID = :iThemeId";
            return sql;
        }

        public static string GetAssetById()
        {
            var sql = GetAssets();
            sql += " WHERE ASSETID = :iAssetId";
            return sql;
        }
    }
}