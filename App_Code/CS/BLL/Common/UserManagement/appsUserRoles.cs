using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for appsUser
/// </summary>

public class appUsersRoles
{
    public enum userRole
    {
        admin = 1,
        planner = 2,
        sponsor = 3,
        superintendent = 4,
        initiator = 5,
        FunctionalLead = 6,
        AssetOperationsManager = 7,
        CorporateViewer = 8,
        focalPoint = 9,
        champion = 10,

        LineManager = 11,
        ProductionServicesManager = 12,
        GMProduction = 13,
        BusinessImprovementTeam = 14,
        LeanFocalPoint = 15,
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
                case userRole.sponsor: sRet = "Activity Sponsor"; break;
                case userRole.superintendent: sRet = "Superintendent"; break;
                case userRole.initiator: sRet = "Initiator"; break;
                case userRole.FunctionalLead: sRet = "Functional Lead"; break;
                case userRole.AssetOperationsManager: sRet = "Asset/Operations Manager"; break;

                case userRole.CorporateViewer: sRet = "Corporate Overview"; break;
                case userRole.focalPoint: sRet = "Lean Focal Point"; break;
                case userRole.champion: sRet = "Project Champion"; break;

                case userRole.LineManager: sRet = "Line Manager"; break;
                case userRole.ProductionServicesManager: sRet = "Production Services Manager"; break;
                case userRole.GMProduction: sRet = "GM Production"; break;
                case userRole.BusinessImprovementTeam: sRet = "Business Improvement Review Team"; break;
                case userRole.LeanFocalPoint: sRet = "Lean Team Focal Point"; break;
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
        addRoleToDropDown(appUsersRoles.userRole.admin, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.planner, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.sponsor, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.superintendent, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.initiator, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.FunctionalLead, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.AssetOperationsManager, ddlUserRole);
    }

    //public bool grantPageAccess(string[] sAccountRole, userRole eMyRole)
    //{
    //    bool bRet = false;
    //    try
    //    {
    //        if (eMyRole == userRole.admin)
    //        {
    //            bRet = true;
    //        }
    //        else
    //        {
    //            foreach (string sId in sAccountRole)
    //            {
    //                if (eMyRole.ToString() == sId)
    //                {
    //                    bRet = true;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //    }

    //    return bRet;
    //}

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
            if ((eMyRole == userRole.admin) || (eMyRole == userRole.initiator))
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

    private static void addRoleToDropDown(appUsersRoles.userRole eRole, DropDownList ddlUserRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUsersRoles.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}

public class appUsersLeanRoles
{
    public enum userRole
    {
        Administrator = 1,
        LeanCoach = 2,
        CorporateManager = 3,
        User = 4,
    };

    public static string userRoleDesc(userRole eUserRole)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eUserRole)
            {
                case userRole.Administrator: sRet = "Administrator"; break;
                case userRole.LeanCoach: sRet = "Lean Coach"; break;
                case userRole.CorporateManager: sRet = "Lean Manager"; break;
                case userRole.User: sRet = "User"; break;
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
        addRoleToDropDown(appUsersLeanRoles.userRole.Administrator, ddlUserRole);
        addRoleToDropDown(appUsersLeanRoles.userRole.LeanCoach, ddlUserRole);
        addRoleToDropDown(appUsersLeanRoles.userRole.CorporateManager, ddlUserRole);
        addRoleToDropDown(appUsersLeanRoles.userRole.User, ddlUserRole);
    }

    private static void addRoleToDropDown(appUsersLeanRoles.userRole eRole, DropDownList ddlUserRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUsersLeanRoles.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
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

}

public class appUserRolesFlrWaiver
{
    public enum userRole
    {
        Administrator = 1,
        Initiator = 2,
        LineManager = 3,
        AssurancePSMgr = 4,
        AssuranceOnshore = 5,
        AssuranceOffshore = 6,
        Approval = 9

        //GMProduction = 5,
        //GMOffshore = 6,
        //GMOnshore = 7,
        //GMDeepWater = 8,
    };

    public static string userRoleDesc(userRole eUserRole)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eUserRole)
            {
                case userRole.Administrator: sRet = "Administrator"; break;
                case userRole.Initiator: sRet = "Request Owner"; break;
                case userRole.LineManager: sRet = "Line Manager"; break;
                case userRole.AssurancePSMgr: sRet = "Assurance Review/Support (PS Mgr)"; break;
                case userRole.AssuranceOnshore: sRet = "Assurance Review/Support (SPDC)"; break;
                case userRole.AssuranceOffshore: sRet = "Assurance Review/Support (SNEPCO)"; break;
                case userRole.Approval: sRet = "Approval"; break;
                //case userRole.GMProduction: sRet = "GM Production"; break;
                //case userRole.GMOffshore: sRet = "GM Offshore"; break;
                //case userRole.GMOnshore: sRet = "GM Onshore"; break;
                //case userRole.GMDeepWater: sRet = "GM DeepWater"; break;
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
        disableMe = 3,
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
                case userStatus.disableMe: sRet = "Deleted Account"; break;
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
        addRoleToDropDown(userRole.Administrator, ddlUserRole);
        addRoleToDropDown(userRole.Initiator, ddlUserRole);
        addRoleToDropDown(userRole.LineManager, ddlUserRole);
        addRoleToDropDown(userRole.AssurancePSMgr, ddlUserRole);
        addRoleToDropDown(userRole.AssuranceOnshore, ddlUserRole);
        addRoleToDropDown(userRole.AssuranceOffshore, ddlUserRole);
        addRoleToDropDown(userRole.Approval, ddlUserRole);
        //addRoleToDropDown(appUserRolesFlrWaiver.userRole.GMDeepWater, ddlUserRole);
        //addRoleToDropDown(appUserRolesFlrWaiver.userRole.GMOffshore, ddlUserRole);
        //addRoleToDropDown(appUserRolesFlrWaiver.userRole.GMOnshore, ddlUserRole);
    }

    private static void addRoleToDropDown(appUserRolesFlrWaiver.userRole eRole, DropDownList ddlUserRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUserRolesFlrWaiver.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public static bool FlareWaiverDeletePrivilege(int iRoleId)
    {
        //CTRRegisterDeletePrivilege searches the Roles assigned to a user, if the System Administrator or BPO is found,
        //the user should be able to delete CTRs.
        //Also, if the user is an CTR Initiator, and the status of the CTR shows that it has not been forwarded, he/she should be able to delete the CTR.

        bool DeletePrivilege = false;

        if ((iRoleId == (int)appUserRolesFlrWaiver.userRole.Administrator) || (iRoleId == (int)appUserRolesFlrWaiver.userRole.Initiator))
        {
            DeletePrivilege = true;
        }

        return DeletePrivilege;
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
}

public class appUsersRolesBI500
{
    public enum userRole
    {
        admin = 1,
        sponsor = 2,
        initiator = 3,
        BusinessImprovementTeam = 4,
        AssetOperationsManager = 5,
        CorporateViewer = 6,
        focalPoint = 7,
        champion = 8,
    };

    public static string userRoleDesc(userRole eUserRole)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eUserRole)
            {
                case userRole.admin: sRet = "Administrator"; break;
                case userRole.sponsor: sRet = "Work Stream Sponsor"; break;
                case userRole.initiator: sRet = "Initiator"; break;
                case userRole.BusinessImprovementTeam: sRet = "Business Improvement Review Team"; break;
                case userRole.AssetOperationsManager: sRet = "Asset/Operations Manager"; break;
                case userRole.CorporateViewer: sRet = "Corporate Overview"; break;
                case userRole.focalPoint: sRet = "Lean Focal Point"; break;
                case userRole.champion: sRet = "Work Stream Owner"; break;                
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
        addRoleToDropDown(appUsersRolesBI500.userRole.admin, ddlUserRole);
        addRoleToDropDown(appUsersRolesBI500.userRole.sponsor, ddlUserRole);
        addRoleToDropDown(appUsersRolesBI500.userRole.initiator, ddlUserRole);
        addRoleToDropDown(appUsersRolesBI500.userRole.AssetOperationsManager, ddlUserRole);
        addRoleToDropDown(appUsersRolesBI500.userRole.CorporateViewer, ddlUserRole);
        addRoleToDropDown(appUsersRolesBI500.userRole.BusinessImprovementTeam, ddlUserRole);
        addRoleToDropDown(appUsersRolesBI500.userRole.focalPoint, ddlUserRole);
    }

    //public bool grantPageAccess(string[] sAccountRole, userRole eMyRole)
    //{
    //    bool bRet = false;
    //    try
    //    {
    //        if (eMyRole == userRole.admin)
    //        {
    //            bRet = true;
    //        }
    //        else
    //        {
    //            foreach (string sId in sAccountRole)
    //            {
    //                if (eMyRole.ToString() == sId)
    //                {
    //                    bRet = true;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //    }

    //    return bRet;
    //}

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
            if ((eMyRole == userRole.admin) || (eMyRole == userRole.initiator))
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

    private static void addRoleToDropDown(appUsersRolesBI500.userRole eRole, DropDownList ddlUserRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUsersRolesBI500.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}

public class AppUsersPdccRoles
{
    public enum UserRole
    {
        Administrator = 1,
        Sponsor = 2,
        ActionParty = 3,
        User = 4,
    };

    public static string UserRoleDesc(UserRole eUserRole)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eUserRole)
            {
                case UserRole.Administrator: sRet = "Administrator"; break;
                case UserRole.Sponsor: sRet = "Sponsor"; break;
                case UserRole.ActionParty: sRet = "Action Party"; break;
                case UserRole.User: sRet = "User"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public static void GetUserRoles(DropDownList ddlUserRole)
    {
        ddlUserRole.Items.Clear();
        ddlUserRole.Items.Add(new ListItem("Please Select Role...", "-1"));
        AddRoleToDropDown(UserRole.Administrator, ddlUserRole);
        AddRoleToDropDown(UserRole.Sponsor, ddlUserRole);
        AddRoleToDropDown(UserRole.ActionParty, ddlUserRole);
        AddRoleToDropDown(UserRole.User, ddlUserRole);
    }

    private static void AddRoleToDropDown(UserRole eRole, DropDownList ddlUserRole)
    {
        try
        {
            ListItem oItem = new ListItem {Text = UserRoleDesc(eRole), Value = ((int) eRole).ToString()};
            ddlUserRole.Items.Add(oItem);

            //ListItem oItem = new ListItem();
            //oItem.Text = UserRoleDesc(eRole);
            //oItem.Value = ((int)eRole).ToString();
            //ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public bool GrantPageAccess(string[] sAccountRole, UserRole eMyRole)
    {
        bool bRet = false;
        try
        {
            //if (sAccountRole.Any(sId => eMyRole.ToString() == sId))
            //{
            //    bRet = true;
            //}
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

    public bool GrantPageAccess(string sAccountRole, UserRole eMyRole)
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

}

public class AppUsers14DaysContract
{
    public enum UserRole
    {
        Administrator = 1,
        Superintendent = 2,
        CorporateViewer = 3,
        OperationsManager = 4,
    };

    public static string UserRoleDesc(UserRole eUserRole)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eUserRole)
            {
                case UserRole.Administrator: sRet = "Administrator"; break;
                case UserRole.Superintendent: sRet = "Superintendent"; break;
                case UserRole.CorporateViewer: sRet = "Corporate Viewer"; break;
                case UserRole.OperationsManager: sRet = "Operations Manager"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public static void GetUserRoles(DropDownList ddlUserRole)
    {
        ddlUserRole.Items.Clear();
        ddlUserRole.Items.Add(new ListItem("Please Select Role...", "-1"));
        AddRoleToDropDown(UserRole.Administrator, ddlUserRole);
        AddRoleToDropDown(UserRole.Superintendent, ddlUserRole);
        AddRoleToDropDown(UserRole.CorporateViewer, ddlUserRole);
        AddRoleToDropDown(UserRole.OperationsManager, ddlUserRole);
    }

    private static void AddRoleToDropDown(UserRole eRole, DropDownList ddlUserRole)
    {
        try
        {
            ListItem oItem = new ListItem { Text = UserRoleDesc(eRole), Value = ((int)eRole).ToString() };
            ddlUserRole.Items.Add(oItem);

            //ListItem oItem = new ListItem();
            //oItem.Text = UserRoleDesc(eRole);
            //oItem.Value = ((int)eRole).ToString();
            //ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public bool GrantPageAccess(string[] sAccountRole, UserRole eMyRole)
    {
        bool bRet = false;
        try
        {
            //if (sAccountRole.Any(sId => eMyRole.ToString() == sId))
            //{
            //    bRet = true;
            //}
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

    public bool GrantPageAccess(string sAccountRole, UserRole eMyRole)
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

}

public class AppUsersRolesInitMgt
{
    public enum UserRole
    {
        Admin = 1,
        Planner = 2,
        Sponsor = 3,
        Superintendent = 4,
        Initiator = 5,
        FunctionalLead = 6,
        AssetOperationsManager = 7,
        CorporateViewer = 8,
        FocalPoint = 9,
        Champion = 10,

        LineManager = 11,
        ProductionServicesManager = 12,
        GmProduction = 13,
        BusinessImprovementTeam = 14,
    };

    public static string UserRoleDesc(UserRole eUserRole)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eUserRole)
            {
                case UserRole.Admin: sRet = "Administrator"; break;
                case UserRole.Planner: sRet = "Planner"; break;
                case UserRole.Sponsor: sRet = "Activity Sponsor"; break;
                case UserRole.Superintendent: sRet = "Superintendent"; break;
                case UserRole.Initiator: sRet = "Initiator"; break;
                case UserRole.FunctionalLead: sRet = "Functional Lead"; break;
                case UserRole.AssetOperationsManager: sRet = "Asset/Operations Manager"; break;

                case UserRole.CorporateViewer: sRet = "Corporate Overview"; break;
                case UserRole.FocalPoint: sRet = "Lean Focal Point"; break;
                case UserRole.Champion: sRet = "Project Champion"; break;

                case UserRole.LineManager: sRet = "Line Manager"; break;
                case UserRole.ProductionServicesManager: sRet = "Production Services Manager"; break;
                case UserRole.GmProduction: sRet = "GM Production"; break;
                case UserRole.BusinessImprovementTeam: sRet = "Business Improvement Review Team"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public enum UserStatus
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

    public static string userStatusDesc(UserStatus eUserStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eUserStatus)
            {
                case UserStatus.activeUser: sRet = "Active Account"; break;
                case UserStatus.disabledMe: sRet = "Deleted Account"; break;
                case UserStatus.lockedUser: sRet = "Locked Account"; break;
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
        addRoleToDropDown(appUsersRoles.userRole.admin, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.planner, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.sponsor, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.superintendent, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.initiator, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.FunctionalLead, ddlUserRole);
        addRoleToDropDown(appUsersRoles.userRole.AssetOperationsManager, ddlUserRole);
    }

    //public bool grantPageAccess(string[] sAccountRole, userRole eMyRole)
    //{
    //    bool bRet = false;
    //    try
    //    {
    //        if (eMyRole == userRole.admin)
    //        {
    //            bRet = true;
    //        }
    //        else
    //        {
    //            foreach (string sId in sAccountRole)
    //            {
    //                if (eMyRole.ToString() == sId)
    //                {
    //                    bRet = true;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //    }

    //    return bRet;
    //}

    public bool grantPageAccess(string[] sAccountRole, UserStatus eMyRole)
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

    public bool grantPageAccessAdminInit(string[] sAccountRole, UserRole eMyRole)
    {
        bool bRet = false;
        try
        {
            if ((eMyRole == UserRole.Admin) || (eMyRole == UserRole.Initiator))
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

    public bool grantPageAccess(string sAccountRole, UserRole eMyRole)
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

    private static void addRoleToDropDown(appUsersRoles.userRole eRole, DropDownList ddlUserRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUsersRoles.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            ddlUserRole.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}
