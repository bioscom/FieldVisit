using System;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for appUserRolesPDR
/// </summary>

namespace PDR
{
    public class appUserRolesPDR
    {
        public enum userRole
        {
            admin = 1,
            planner = 2,
            superintendent = 3,
            CorporateViewer = 4,
        };

        public static string userRoleDesc(userRole eUserRole)
        {
            string sRet = "UnKnown Account";
            try
            {
                switch (eUserRole)
                {
                    case userRole.admin: sRet = "Administrator"; break;
                    case userRole.planner: sRet = "Planner"; break;
                    case userRole.superintendent: sRet = "Superintendent"; break;
                    case userRole.CorporateViewer: sRet = "Corporate Overview"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }

        public enum userStatus
        {
            activeUser = 1,
            lockedUser = 2,
            disabledMe = 3,
            unKnownMe = 4
        };

        public enum eDeligation
        {
            Deligated = 1,
            Undeligated = 0
        };

        public static string userStatusDesc(userStatus eUserStatus)
        {
            string sRet = "UnKnown Account";
            try
            {
                switch (eUserStatus)
                {
                    case userStatus.activeUser: sRet = "Active Account"; break;
                    case userStatus.disabledMe: sRet = "Deleted Account"; break;
                    case userStatus.lockedUser: sRet = "Locked Account"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }

        public static void getUserRoles(DropDownList ddlUserRole)
        {
            ddlUserRole.Items.Clear();
            ddlUserRole.Items.Add(new ListItem("Please Select Role...", "-1"));
            addRoleToDropDown(appUserRolesPDR.userRole.admin, ddlUserRole);
            addRoleToDropDown(appUserRolesPDR.userRole.planner, ddlUserRole);
            addRoleToDropDown(appUserRolesPDR.userRole.superintendent, ddlUserRole);
        }

        public bool grantPageAccess(string[] sAccountRole, userRole eMyRole)
        {
            bool bRet = false;
            try
            {
                foreach (string sId in sAccountRole)
                {
                    if (eMyRole.ToString() == sId)
                    {
                        bRet = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
            }

            return bRet;
        }

        public bool grantPageAccessAdminInit(string[] sAccountRole, userRole eMyRole)
        {
            bool bRet = false;
            try
            {
                if ((eMyRole == userRole.admin) || (eMyRole == userRole.planner))
                {
                    bRet = true;
                }
                else
                {
                    foreach (string sId in sAccountRole)
                    {
                        if (eMyRole.ToString() == sId)
                        {
                            bRet = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
            }

            return bRet;
        }

        public bool grantPageAccess(string sAccountRole, userRole eMyRole)
        {
            bool bRet = false;
            try
            {
                if (eMyRole.ToString() == sAccountRole)
                {
                    bRet = true;
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
            }

            return bRet;
        }

        private static void addRoleToDropDown(appUserRolesPDR.userRole eRole, DropDownList ddlUserRole)
        {
            try
            {
                ListItem oItem = new ListItem();
                oItem.Text = appUserRolesPDR.userRoleDesc(eRole);
                oItem.Value = ((int)eRole).ToString();
                ddlUserRole.Items.Add(oItem);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }
}