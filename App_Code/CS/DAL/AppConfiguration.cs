using System.Configuration;

public static class AppConfiguration
{
    // Caches the connection string
    public static string dbConnectionString { get; set; }
    public static string dbECConnectionString { get; set; }
    public static string dbProviderName { get; set; }

    // Store the name of application
    public static string smtpHost { get; set; }
    public static string bpPlanYear { get; set; }
    public static string appNameId { get; set; }

    public static string adminName { get; set; }
    public static string adminEmail { get; set; }
    public static string adminUserName { get; set; }
    public static string adminExt { get; set; }

    public static string prodAdminName { get; set; }
    public static string prodAdminEmail { get; set; }
    public static string prodAdminUserName { get; set; }
    public static string prodAdminExt { get; set; }

    public static string productionBIFunctionalAccount { get; set; }

    public static string prodSupportName { get; set; }
    public static string prodSupportEmail { get; set; }
    public static string prodSupportUserName { get; set; }
    public static string prodSupportExt { get; set; }

    public static string siteName { get; set; }
    public static string siteNameFieldVisit { get; set; }
    public static string siteNameManHour { get; set; }
    public static string siteNameBI500 { get; set; }
    public static string siteNameCRP { get; set; }
    public static string siteNameFlareWaiver { get; set; }
    public static string siteNameProductionDailyReport { get; set; }
    public static string siteNamePdcc { get; set; }

    public static string siteHostName { get; set; }
    public static string copyRight { get; set; }
    public static string footerInfo { get; set; }
    public static bool bccAdmin { get; set; }

    public static string informationWareHouse { get; set; }
    //private readonly static string informationWareHouse;

    //------------------- CBI Dashboad ------------//
    public static string CBIDashBoardMenu { get; set; }
    public static string CBISiteName { get; set; }

    //---------- Field Visit---------------//
    public static string adminMenuFieldVisit { get; set; }
    public static string userMenuFieldVisit { get; set; }

    //---------- Man Hour ----------------//
    public static string adminMenuManHour { get; set; }
    public static string userMenuManHour { get; set; }

    //---------- Flare Waiver -----------//
    public static string AdminMenuFlareWaiver { get; set; }
    public static string InitiatorMenuFlareWaiver { get; set; }
    public static string ApproverMenuFlareWaiver { get; set; }

    //---------- Lean Projects ---------------//
    public static string LeanSiteName { get; set; }
    public static string LeanFooterInfo { get; set; }
    public static string LeanCopyRight { get; set; }

    //---------- BI500 ----------------//
    public static string adminMenuBI500 { get; set; }
    public static string corporateMenuBI500 { get; set; }
    public static string userMenuBI500 { get; set; }

    //---------- Cost Reduction ----------------//
    public static string adminMenuCostReduction { get; set; }
    public static string corporateMenuCostReduction { get; set; }
    public static string userMenuCostReduction { get; set; }

    //---------- 14 Day Contract ----------------//
    public static string siteName14DayContract { get; set; }
    public static string adminMenu14DayContract { get; set; }
    public static string userMenu14DayContract { get; set; }

    public static string adminMenuPdcc { get; set; }
    public static string userMenuPdcc { get; set; }

    //---------- Fron Line Barrier Management ---------------//
    public static string adminMenuFLBM { get; set; }
    public static string userMenuFLBM { get; set; }

    //---------- Red Flag ---------------//
    public static string adminMenuRedFlag { get; set; }
    public static string userMenuRedFlag { get; set; }

    public static string dbLink { get; set; }

    static AppConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["productionConnectionString"].ConnectionString;
        dbECConnectionString = ConfigurationManager.ConnectionStrings["ECConnectionString"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["productionConnectionString"].ProviderName;
        //smtpHost = ConfigurationManager.AppSettings["cpdms.smtpHost"]; 
        smtpHost = ConfigurationManager.AppSettings["MailServer"];
        bpPlanYear = ConfigurationManager.AppSettings["opex.bpPlanYear"];
        appNameId = ConfigurationManager.AppSettings["appNameId"];

        adminName = ConfigurationManager.AppSettings["cpdms.adminName"];
        adminEmail = ConfigurationManager.AppSettings["cpdms.AdminMail"];
        adminUserName = ConfigurationManager.AppSettings["cpdms.AdminUserName"];
        adminExt = ConfigurationManager.AppSettings["cpdms.AdminExt"];
        bccAdmin = bool.Parse(ConfigurationManager.AppSettings["cpdms.BccAdmin"]);

        prodAdminName = ConfigurationManager.AppSettings["production.adminName"];
        prodAdminEmail = ConfigurationManager.AppSettings["production.AdminMail"];
        prodAdminUserName = ConfigurationManager.AppSettings["production.AdminUserName"];
        prodAdminExt = ConfigurationManager.AppSettings["production.AdminExt"];
        productionBIFunctionalAccount = ConfigurationManager.AppSettings["production.BIFunctionalAccount"];

        prodSupportName = ConfigurationManager.AppSettings["production.SupportName"];
        prodSupportEmail = ConfigurationManager.AppSettings["production.SupportMail"];
        prodSupportUserName = ConfigurationManager.AppSettings["production.SupportUserName"];
        prodSupportExt = ConfigurationManager.AppSettings["production.SupportExt"];

        siteName = ConfigurationManager.AppSettings["SiteName"];
        siteNameFieldVisit = ConfigurationManager.AppSettings["SiteName.FieldVisit"];
        siteNameManHour = ConfigurationManager.AppSettings["SiteName.ManHour"];
        siteNameBI500 = ConfigurationManager.AppSettings["SiteName.BI500"];
        siteNameCRP = ConfigurationManager.AppSettings["SiteName.CRP"];
        siteName14DayContract = ConfigurationManager.AppSettings["SiteName.14DayContract"];
        siteNameFlareWaiver = ConfigurationManager.AppSettings["SiteName.FlareWaiver"];
        LeanSiteName = ConfigurationManager.AppSettings["SiteName.Lean"];
        siteNameProductionDailyReport = ConfigurationManager.AppSettings["SiteName.PDR"];
        siteNamePdcc = ConfigurationManager.AppSettings["SiteName.PDCC"];
        CBISiteName = ConfigurationManager.AppSettings["SiteName"];

        siteHostName = ConfigurationManager.AppSettings["siteHostName"];

        copyRight = ConfigurationManager.AppSettings["CopyRight"];
        footerInfo = ConfigurationManager.AppSettings["footerInfo"];

        LeanFooterInfo = ConfigurationManager.AppSettings["LeanfooterInfo"];
        LeanCopyRight = ConfigurationManager.AppSettings["LeanCopyRight"];

        informationWareHouse = ConfigurationManager.AppSettings["IWH"];

        CBIDashBoardMenu = ConfigurationManager.AppSettings["CBIMenu"];

        adminMenuFieldVisit = ConfigurationManager.AppSettings["AdminMenu.FieldVisit"];
        userMenuFieldVisit = ConfigurationManager.AppSettings["UserMenu.FieldVisit"];

        adminMenuManHour = ConfigurationManager.AppSettings["AdminMenu.ManHour"];
        userMenuManHour = ConfigurationManager.AppSettings["UserMenu.ManHour"];

        AdminMenuFlareWaiver = ConfigurationManager.AppSettings["AdminMenu.FlareWaiver"];
        InitiatorMenuFlareWaiver = ConfigurationManager.AppSettings["InitiatorMenu.FlareWaiver"];
        ApproverMenuFlareWaiver = ConfigurationManager.AppSettings["ApproverMenu.FlareWaiver"];


        adminMenuBI500 = ConfigurationManager.AppSettings["AdminMenu.BI500"];
        corporateMenuBI500 = ConfigurationManager.AppSettings["CorporateMenu.BI500"];
        userMenuBI500 = ConfigurationManager.AppSettings["UserMenu.BI500"];

        adminMenuCostReduction = ConfigurationManager.AppSettings["AdminMenu.CostReduction"];
        corporateMenuCostReduction = ConfigurationManager.AppSettings["CorporateMenu.CostReduction"];
        userMenuCostReduction = ConfigurationManager.AppSettings["UserMenu.CostReduction"];

        adminMenu14DayContract = ConfigurationManager.AppSettings["AdminMenu.14DayContract"];
        userMenu14DayContract = ConfigurationManager.AppSettings["UserMenu.14DayContract"];

        adminMenuPdcc = ConfigurationManager.AppSettings["AdminMenu.Pdcc"];
        userMenuPdcc = ConfigurationManager.AppSettings["UserMenu.Pdcc"];

        adminMenuFLBM = ConfigurationManager.AppSettings["AdminMenu.FLBM"];
        userMenuFLBM = ConfigurationManager.AppSettings["UserMenu.FLBM"];

        adminMenuRedFlag = ConfigurationManager.AppSettings["AdminMenu.RedFlag"];
        userMenuRedFlag = ConfigurationManager.AppSettings["UserMenu.RedFlag"];

        dbLink = ConfigurationManager.AppSettings["DBLINK"];
    }
    // Returns the connection string for the CPDMS database
    
    
    // Returns the address of the mail server
    public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    // Send error log emails?
    public static bool EnableErrorLogEmail
    {
        get
        {
            return bool.Parse(ConfigurationManager.AppSettings["EnableErrorLogEmail"]);
        }
    }

    // Returns the email address where to send error reports
    public static string ErrorLogEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ErrorLogEmail"];
        }
    }
}