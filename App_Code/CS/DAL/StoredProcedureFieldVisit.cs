using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedure
/// </summary>
/// 

public static class StoredProcedure
{
    static StoredProcedure()
    {

    }

    #region ************************ Application Configuration Queries Start ************************************


    #region************************** Assets ****************************************

    public static string getAssets()
    {
        string sql = "SELECT IDASSET, ASSETS, LOCATION FROM PROD_ASSET";
        return sql;
    }

    public static string getAssetById()
    {
        string sql = "SELECT IDASSET, ASSETS, LOCATION FROM PROD_ASSET WHERE IDASSET = :iAssetId";
        return sql;
    }

    public static string getAssetByOuId()
    {
        string sql = "SELECT IDASSET, ASSETS, LOCATION FROM PROD_ASSET WHERE IDOU = :iOuId";
        return sql;
    }

    public static string insertAsset()
    {
        string sql = "INSERT INTO PROD_ASSET (ASSETS, LOCATION) VALUES (:sAsset, :sLocation)";

        return sql;
    }

    public static string updateAsset()
    {
        string sql = "UPDATE PROD_ASSET SET ASSETS = :sAsset, LOCATION = :sLocation WHERE IDASSET = :iAssetId";
        return sql;
    }

    #endregion


    #region************************** Asset Hubs ****************************************

    public static string getAssetHubs()
    {
        string sql = "SELECT IDHUB, HUB FROM ASSET_HUBS";
        return sql;
    }

    //public static string getAssetById()
    //{
    //    string sql = "SELECT IDASSET, ASSETS, LOCATION FROM PROD_ASSET WHERE IDASSET = :iAssetId";
    //    return sql;
    //}

    //public static string getAssetByOuId()
    //{
    //    string sql = "SELECT IDASSET, ASSETS, LOCATION FROM PROD_ASSET WHERE IDOU = :iOuId";
    //    return sql;
    //}

    public static string insertHub()
    {
        string sql = "INSERT INTO ASSET_HUBS (HUB) VALUES (:sHub)";

        return sql;
    }

    public static string updateHub()
    {
        string sql = "UPDATE ASSET_HUBS SET HUB = :sHub WHERE IDHUB = :iHubId";
        return sql;
    }

    #endregion



    #region************************** Superintendents *****************************

    public static string getSuperintendents()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL FROM PROD_SUPERINTENDENT ORDER BY SUPERINTENDENT";

        return sql;
    }

    public static string getSuperintendentById()
    {
        string sql = "SELECT ID_SUPERINTENDENT, SUPERINTENDENT, SUPERINTENDENT_EMAIL FROM PROD_SUPERINTENDENT WHERE ID_SUPERINTENDENT = :ID_SUPERINTENDENT";

        return sql;
    }

    public static string insertSuperintendent()
    {
        string sql = "INSERT INTO PROD_SUPERINTENDENT (SUPERINTENDENT, SUPERINTENDENT_EMAIL) VALUES (:SUPERINTENDENT, :SUPERINTENDENT_EMAIL)";

        return sql;
    }

    public static string updateSuperintendent()
    {
        string sql = "UPDATE PROD_SUPERINTENDENT SET SUPERINTENDENT = :SUPERINTENDENT, SUPERINTENDENT_EMAIL = :SUPERINTENDENT_EMAIL WHERE ID_SUPERINTENDENT = :ID_SUPERINTENDENT";
        return sql;
    }

    #endregion

    #region************************** Operations Manager Functional AcctUser *************************

    public static string getOpsMgrByUserIdSuperintendentId()
    {
        string sql = "SELECT * FROM PROD_OPSMANAGERS_USER WHERE USERID = :USERID AND ID_SUPERINTENDENT = :ID_SUPERINTENDENT";
        return sql;
    }

    public static string insertOpsMgrFunctionalAcctUser()
    {
        string sql = "INSERT INTO PROD_OPSMANAGERS_USER (ID_SUPERINTENDENT, USERID) VALUES (:ID_SUPERINTENDENT, :USERID)";
        return sql;
    }

    public static string updateOpsMgrFunctionalAcctUser()
    {
        string sql = "UPDATE PROD_OPSMANAGERS_USER SET ID_SUPERINTENDENT = :ID_SUPERINTENDENT, USERID = :USERID WHERE ID_OPSMGR = :ID_OPSMGR";
        return sql;
    }

    //public static string getSuperintendentFunctionalAcctUsers()
    //{
    //    string sql = "SELECT PROD_SUPERINTENDENT_ACCTUSER.ID_ACCTUSER, PROD_SUPERINTENDENT_ACCTUSER.USERNAME, PROD_SUPERINTENDENT.ID_SUPERINTENDENT, ";
    //    sql += "PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL FROM PROD_SUPERINTENDENT ";
    //    sql += "INNER JOIN PROD_SUPERINTENDENT_ACCTUSER ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT_ACCTUSER.ID_SUPERINTENDENT ";

    //    return sql;
    //}

    public static string getOpsMgrFunctionalAcctUserById()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_SUPERINTENDENT_USER.ID_ACCTUSER, PROD_SUPERINTENDENT_USER.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.STATUS ";
        sql += "FROM PROD_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT_USER ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT_USER.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SUPERINTENDENT_USER.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_USERMGT.USERID = :USERID";

        return sql;
    }

    public static string getOpsMgrFunctionalAcctByUserId()
    {
        string sql = "SELECT PROD_SUPERINTENDENT_USER.ID_ACCTUSER, PROD_SUPERINTENDENT_USER.USERID, PROD_SUPERINTENDENT.ID_SUPERINTENDENT, ";
        sql += "PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, PROD_USERMGT.FULLNAME, ";
        sql += "PROD_USERMGT.USERNAME FROM PROD_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT_USER ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT_USER.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SUPERINTENDENT_USER.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_USERMGT.USERID = :USERID";

        return sql;
    }

    public static string getOpsMgrFunctionalAcctUsersBySuperintendent()
    {
        string sql = "SELECT PROD_OPSMANAGERS_USER.ID_OPSMGR, PROD_OPSMANAGERS_USER.USERID, PROD_OPSMANAGERS_USER.ID_SUPERINTENDENT, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_USERMGT.REFIND, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME ";
        sql += "FROM PROD_OPSMANAGERS_USER ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_OPSMANAGERS_USER.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_OPSMANAGERS_USER.ID_SUPERINTENDENT = :ID_SUPERINTENDENT)";

        return sql;
    }

    public static string getOpsMgrFunctionalAcctUsersByDistrict()
    {
        string sql = "SELECT PROD_OPSMANAGERS_USER.ID_OPSMGR, PROD_OPSMANAGERS_USER.USERID, PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_DISTRICT.ID_DISTRICT ";
        sql += "FROM PROD_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_DISTRICT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_OPSMANAGERS_USER ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_OPSMANAGERS_USER.ID_SUPERINTENDENT ";
        sql += "WHERE (PROD_DISTRICT.ID_DISTRICT = :iDistrict)";

        return sql;
    }

    public static string RemoveFromOpsMgr()
    {
        string sql = "DELETE FROM PROD_OPSMANAGERS_USER WHERE USERID = :USERID";
        return sql;

    }

    #endregion



    #region************************** SuperintendentFunctionalAcctUser *************************

    public static string getSuperintendentByUserIdSuperintendentId()
    {
        string sql = "SELECT * FROM PROD_SUPERINTENDENT_USER WHERE USERID = :USERID AND ID_SUPERINTENDENT = :ID_SUPERINTENDENT";
        return sql;
    }

    public static string insertSuperintendentFunctionalAcctUser()
    {
        string sql = "INSERT INTO PROD_SUPERINTENDENT_USER (ID_SUPERINTENDENT, USERID) VALUES (:ID_SUPERINTENDENT, :USERID)";
        return sql;
    }

    public static string updateSuperintendentFunctionalAcctUser()
    {
        string sql = "UPDATE PROD_SUPERINTENDENT_USER SET ID_SUPERINTENDENT = :ID_SUPERINTENDENT, USERID = :USERID WHERE ID_ACCTUSER = :ID_ACCTUSER";
        return sql;
    }

    public static string getSuperintendentFunctionalAcctUsers()
    {
        string sql = "SELECT PROD_SUPERINTENDENT_ACCTUSER.ID_ACCTUSER, PROD_SUPERINTENDENT_ACCTUSER.USERNAME, PROD_SUPERINTENDENT.ID_SUPERINTENDENT, ";
        sql += "PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL FROM PROD_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT_ACCTUSER ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT_ACCTUSER.ID_SUPERINTENDENT ";

        return sql;
    }

    public static string getSuperintendentFunctionalAcctUserById()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_SUPERINTENDENT_USER.ID_ACCTUSER, PROD_SUPERINTENDENT_USER.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.STATUS ";
        sql += "FROM PROD_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT_USER ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT_USER.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SUPERINTENDENT_USER.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_USERMGT.USERID = :USERID";

        return sql;
    }

    public static string getSuperintendentFunctionalAcctByUserId()
    {
        string sql = "SELECT PROD_SUPERINTENDENT_USER.ID_ACCTUSER, PROD_SUPERINTENDENT_USER.USERID, PROD_SUPERINTENDENT.ID_SUPERINTENDENT, ";
        sql += "PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, PROD_USERMGT.FULLNAME, ";
        sql += "PROD_USERMGT.USERNAME FROM PROD_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT_USER ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT_USER.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SUPERINTENDENT_USER.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_USERMGT.USERID = :USERID";

        return sql;
    }

    public static string getSuperintendentFunctionalAcctUsersBySuperintendent()
    {
        string sql = "SELECT PROD_SUPERINTENDENT_USER.ID_ACCTUSER, PROD_SUPERINTENDENT_USER.ID_SUPERINTENDENT, PROD_SUPERINTENDENT_USER.USERID, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_USERMGT.REFIND, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME ";
        sql += "FROM PROD_SUPERINTENDENT_USER ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SUPERINTENDENT_USER.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_SUPERINTENDENT_USER.ID_SUPERINTENDENT = :ID_SUPERINTENDENT) ORDER BY PROD_USERMGT.FULLNAME";


        return sql;
    }

    public static string RemoveFromSuperintendent()
    {
        string sql = "DELETE FROM PROD_SUPERINTENDENT_USER WHERE USERID = :USERID";
        return sql;

    }

    #endregion

    #region************************** District ****************************************

    public static string getDistricts()
    {
        string sql = "SELECT ID_DISTRICT, ID_SUPERINTENDENT, DISTRICT FROM PROD_DISTRICT";
        return sql;
    }

    public static string getDistrictsExt()
    {
        string sql = "SELECT PROD_ASSET.IDASSET, PROD_ASSET.ASSETS, PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT ";
        sql += "FROM PROD_DISTRICT INNER JOIN PROD_ASSET ON PROD_ASSET.IDASSET = PROD_DISTRICT.IDASSET";

        return sql;
    }

    public static string getDistrictDetails()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT ";
        sql += "FROM PROD_DISTRICT INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT";

        return sql;
    }

    public static string getDistrictByAssetId()
    {
        string sql = "SELECT PROD_ASSET.IDASSET, ";
        sql += "PROD_ASSET.ASSETS, ";
        sql += "PROD_ASSET.LOCATION, ";
        sql += "PROD_DISTRICT.ID_DISTRICT, ";
        sql += "PROD_DISTRICT.ID_SUPERINTENDENT, ";
        sql += "PROD_DISTRICT.DISTRICT FROM PROD_ASSET ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_ASSET.IDASSET = PROD_DISTRICT.IDASSET ";
        sql += "WHERE PROD_ASSET.IDASSET = :iAssetId";

        return sql;
    }
    public static string getAssetByDistrictId()
    {
        string sql = "SELECT PROD_ASSET.IDASSET, ";
        sql += "PROD_ASSET.ASSETS, ";
        sql += "PROD_ASSET.LOCATION, ";
        sql += "PROD_DISTRICT.ID_DISTRICT, ";
        sql += "PROD_DISTRICT.DISTRICT FROM PROD_ASSET ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_ASSET.IDASSET = PROD_DISTRICT.IDASSET ";
        sql += "WHERE PROD_DISTRICT.ID_DISTRICT = :iDistrictId";

        return sql;
    }

    public static string getDistrictById()
    {
        string sql = "SELECT ID_DISTRICT, ID_SUPERINTENDENT, DISTRICT FROM PROD_DISTRICT WHERE ID_DISTRICT = :ID_DISTRICT";
        return sql;
    }
    public static string getDistrictByName()
    {
        string sql = "SELECT ID_DISTRICT, ID_SUPERINTENDENT, DISTRICT FROM PROD_DISTRICT WHERE DISTRICT = :sDistrict";
        return sql;
    }
    public static string getDistrictDetailsById()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT ";
        sql += "FROM PROD_DISTRICT INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "WHERE PROD_DISTRICT.ID_DISTRICT = :ID_DISTRICT";

        return sql;
    }

    public static string getDistrictBySuperintendent()
    {
        string sql = "SELECT ID_DISTRICT, ID_SUPERINTENDENT, DISTRICT FROM PROD_DISTRICT WHERE ID_SUPERINTENDENT = :ID_SUPERINTENDENT";
        return sql;
    }

    public static string insertDistrict()
    {
        string sql = "INSERT INTO PROD_DISTRICT (ID_SUPERINTENDENT, DISTRICT) VALUES (:ID_SUPERINTENDENT, :DISTRICT)";

        return sql;
    }

    public static string updateDistrict()
    {
        string sql = "UPDATE PROD_DISTRICT SET ID_SUPERINTENDENT = :ID_SUPERINTENDENT, DISTRICT = :DISTRICT WHERE ID_DISTRICT = :ID_DISTRICT";
        return sql;
    }

    public static string getDistrictAssignedToSuperintendent()
    {
        //TODO: Please create this table "PROD_DISTRICT_SUPERINTENDENT"
        string sql = "SELECT * FROM PROD_DISTRICT_SUPERINTENDENT WHERE PROD_DISTRICT_SUPERINTENDENT.ID_DISTRICT = :iDistrictId AND PROD_DISTRICT_SUPERINTENDENT.USERID = :iUserId";
        return sql;
    }

    public static string InsertDistrictSuperintendent()
    {
        string sql = "INSERT INTO PROD_DISTRICT_SUPERINTENDENT (USERID, ID_DISTRICT) VALUES (:iUserId, :iDistrictId)";
        return sql;
    }

    #endregion

    #region************************** Facility **********************************************

    public static string getFacilities()
    {
        string sql = "SELECT ID_FACILITIES, ID_DISTRICT, FACILITIES, DIVESTED FROM PROD_FACILITIES WHERE DIVESTED = '" + (int) DivestmentEnum.Divestment.Active + "' ORDER BY FACILITIES";
        return sql;
    }

    public static string getFacilityDetails()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_FACILITIES.DIVESTED, PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT, ";
        sql += "PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL ";
        sql += "FROM PROD_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT";

        return sql;
    }

    public static string getFacilityById()
    {
        string sql = "SELECT ID_FACILITIES, ID_DISTRICT, FACILITIES, DIVESTED FROM PROD_FACILITIES ";
        sql += "WHERE ID_FACILITIES = :ID_FACILITIES";
        return sql;
    }

    public static string getFacilitiesByPlannerId()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.ID_DISTRICT, PROD_FACILITIES.FACILITIES, PROD_FACILITIES.DIVESTED, PROD_FACILITIES_PLANNER.ID_PLANNER, PROD_FACILITIES_PLANNER.ID_FACILITY_PLANNER ";
        sql += "FROM PROD_FACILITIES INNER JOIN PROD_FACILITIES_PLANNER ON PROD_FACILITIES.ID_FACILITIES = PROD_FACILITIES_PLANNER.ID_FACILITIES ";
        sql += "WHERE ID_PLANNER = :ID_PLANNER";

        return sql;
    }

    public static string getFacilityPlannerByFacilityId()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, ";
        sql += "PROD_USERMGT.ROLEID, PROD_FACILITIES_PLANNER.ID_FACILITY_PLANNER, PROD_FACILITIES_PLANNER.ID_PLANNER FROM PROD_FACILITIES ";
        sql += "INNER JOIN PROD_FACILITIES_PLANNER ON PROD_FACILITIES.ID_FACILITIES = PROD_FACILITIES_PLANNER.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_FACILITIES_PLANNER.ID_PLANNER = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_FACILITIES.ID_FACILITIES = :ID_FACILITIES)";

        return sql;
    }

    public static string getFacilityPlannerByPlannerId()
    {
        string sql = "SELECT PROD_USERMGT.USERID, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME, ";
        sql += "PROD_FACILITIES_PLANNER.ID_FACILITY_PLANNER, PROD_FACILITIES_PLANNER.ID_FACILITIES, PROD_FACILITIES_PLANNER.ID_PLANNER ";
        sql += "FROM PROD_FACILITIES_PLANNER INNER JOIN PROD_USERMGT ON PROD_FACILITIES_PLANNER.ID_PLANNER = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_USERMGT.USERID = :ID_PLANNER)";

        return sql;
    }

    public static string getFacilityByDistrict()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT, PROD_FACILITIES.DIVESTED, ";
        sql += "PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT FROM PROD_DISTRICT ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "WHERE PROD_DISTRICT.ID_DISTRICT = :ID_DISTRICT";

        return sql;
    }

    public static string getFacilityByDistrictId()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_DISTRICT.ID_DISTRICT, PROD_DISTRICT.DISTRICT, PROD_FACILITIES.DIVESTED, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_USERMGT.USERID FROM PROD_DISTRICT ";
        sql += "LEFT OUTER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "INNER JOIN PROD_FACILITIES_PLANNER ON PROD_FACILITIES.ID_FACILITIES = PROD_FACILITIES_PLANNER.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_FACILITIES_PLANNER.ID_PLANNER = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_DISTRICT.ID_DISTRICT = :ID_DISTRICT) ORDER BY PROD_FACILITIES.FACILITIES";

        return sql;
    }

    public static string RemovePlannerFromFacility()
    {
        string sql = "DELETE FROM PROD_FACILITIES_PLANNER WHERE ID_PLANNER = :iUserId AND ID_FACILITIES = :iFacilityId";
        return sql;
            
    }

    public static string getFacilitiesByDistrictId()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_DISTRICT.ID_DISTRICT, PROD_FACILITIES.DIVESTED, PROD_DISTRICT.DISTRICT ";
        sql += "FROM PROD_DISTRICT ";
        sql += "LEFT OUTER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "WHERE (PROD_DISTRICT.ID_DISTRICT = :ID_DISTRICT) ORDER BY PROD_FACILITIES.FACILITIES";

        return sql;
    }

    public static string getSuperintendentByFacilityId()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_FACILITIES.ID_FACILITIES FROM PROD_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "WHERE (PROD_FACILITIES.ID_FACILITIES = :ID_FACILITIES)";

        return sql;
    }

    public static string insertFacility()
    {
        string sql = "INSERT INTO PROD_FACILITIES (ID_DISTRICT, FACILITIES) VALUES (:ID_DISTRICT, :FACILITIES)";
        return sql;
    }

    public static string insertPlannerFacility()
    {
        string sql = "INSERT INTO PROD_FACILITIES_PLANNER (ID_FACILITIES, ID_PLANNER) VALUES (:ID_FACILITIES, :ID_PLANNER)";
        return sql;
    }

    public static string updateFacility()
    {
        string sql = "UPDATE PROD_FACILITIES SET ID_DISTRICT = :ID_DISTRICT, FACILITIES = :FACILITIES WHERE ID_FACILITIES = :ID_FACILITIES";
        return sql;
    }

    public static string Divested()
    {
        string sql = "UPDATE PROD_FACILITIES SET DIVESTED = :DIVESTED WHERE ID_FACILITIES = :ID_FACILITIES";
        return sql;
    }

    public static string getFacilitiesAssignedToPlanner()
    {
        string sql = "SELECT PROD_USERMGT.FULLNAME, PROD_USERMGT.USERID, PROD_FACILITIES_PLANNER.ID_FACILITIES ";
        sql += "FROM PROD_USERMGT INNER JOIN PROD_FACILITIES_PLANNER ON PROD_USERMGT.USERID = PROD_FACILITIES_PLANNER.ID_PLANNER ";
        sql += "WHERE PROD_USERMGT.USERID = :USERID";

        return sql;
    }

    public static string getFacilityForUser()
    {
        string sql = "SELECT ID_FACILITIES, ID_PLANNER FROM PROD_FACILITIES_PLANNER WHERE ID_FACILITIES = :ID_FACILITIES AND ID_PLANNER = :ID_PLANNER";
        return sql;
    }

    #endregion

    #region ************************** Activity Type **********************

    public static string getActivityType()
    {
        string sql = "SELECT ID_ACTIVITY_TYPE, ACTIVITY_TYPE FROM PROD_SEPCIN_ACTIVITY_TYPE";
        return sql;
    }

    public static string getActivityTypeById()
    {
        string sql = "SELECT ID_ACTIVITY_TYPE, ACTIVITY_TYPE FROM PROD_SEPCIN_ACTIVITY_TYPE WHERE ID_ACTIVITY_TYPE = :ID_ACTIVITY_TYPE";
        return sql;
    }

    public static string createActivityType()
    {
        string sql = "INSERT INTO PROD_SEPCIN_ACTIVITY_TYPE (ACTIVITY_TYPE) VALUES (:ACTIVITY_TYPE)";
        return sql;
    }

    public static string updateActivityType()
    {
        string sql = "UPDATE PROD_SEPCIN_ACTIVITY_TYPE SET ACTIVITY_TYPE = :ACTIVITY_TYPE WHERE ID_ACTIVITY_TYPE = :ID_ACTIVITY_TYPE";

        return sql;
    }

    #endregion

    #region ************************** Units **********************

    public static string getUnits()
    {
        string sql = "SELECT ID_UNIT, UNITS FROM PROD_SEPCIN_UNIT";
        return sql;
    }

    public static string getUnitsById()
    {
        string sql = "SELECT ID_UNIT, UNITS FROM PROD_SEPCIN_UNIT WHERE ID_UNIT = :ID_UNIT";
        return sql;
    }

    public static string createUnits()
    {
        string sql = "INSERT INTO PROD_SEPCIN_UNIT (UNITS) VALUES (:UNITS)";
        return sql;
    }

    public static string updateUnits()
    {
        string sql = "UPDATE PROD_SEPCIN_UNIT SET UNITS = :UNITS WHERE ID_UNIT = :ID_UNIT";

        return sql;
    }

    #endregion

    #region ************************** Trade Types **********************

    public static string getTradeType()
    {
        string sql = "SELECT ID_TRADE_TYPE, TRADE_TYPE FROM PROD_SEPCIN_TRADE_TYPE";
        return sql;
    }

    public static string getTradeTypeById()
    {
        string sql = "SELECT ID_TRADE_TYPE, TRADE_TYPE FROM PROD_SEPCIN_TRADE_TYPE WHERE ID_TRADE_TYPE = :ID_TRADE_TYPE";
        return sql;
    }

    public static string createTradeType()
    {
        string sql = "INSERT INTO PROD_SEPCIN_TRADE_TYPE (TRADE_TYPE) VALUES (:TRADE_TYPE)";
        return sql;
    }

    public static string updateTradeType()
    {
        string sql = "UPDATE PROD_SEPCIN_TRADE_TYPE SET TRADE_TYPE = :TRADE_TYPE WHERE ID_TRADE_TYPE = :ID_TRADE_TYPE";

        return sql;
    }

    #endregion

    #region ************************** Baggages **********************

    public static string getBaggage()
    {
        string sql = "SELECT ID_BAG, BAGGAGE FROM PROD_SEPCIN_FIELD_BAGGAGE";
        return sql;
    }

    public static string getBaggageById()
    {
        string sql = "SELECT ID_BAG, BAGGAGE FROM PROD_SEPCIN_FIELD_BAGGAGE WHERE ID_BAG = :ID_BAG";
        return sql;
    }

    public static string createBaggage()
    {
        string sql = "INSERT INTO PROD_SEPCIN_FIELD_BAGGAGE (BAGGAGE) VALUES (:BAGGAGE)";
        return sql;
    }

    public static string updateBaggage()
    {
        string sql = "UPDATE PROD_SEPCIN_FIELD_BAGGAGE SET BAGGAGE = :BAGGAGE WHERE ID_BAG = :ID_BAG";

        return sql;
    }

    #endregion

    #region ************************** Contact Person **********************

    public static string getContactPerson()
    {
        string sql = "SELECT ID_CONTACT, CONTACT_PERSON FROM PROD_SEPCIN_FIELD_CONTACT";
        return sql;
    }

    public static string getContactPersonById()
    {
        string sql = "SELECT ID_CONTACT, CONTACT_PERSON FROM PROD_SEPCIN_FIELD_CONTACT WHERE ID_CONTACT = :ID_CONTACT";
        return sql;
    }

    public static string createContactPerson()
    {
        string sql = "INSERT INTO PROD_SEPCIN_FIELD_CONTACT (CONTACT_PERSON) VALUES (:CONTACT_PERSON)";
        return sql;
    }

    public static string updateContactPerson()
    {
        string sql = "UPDATE PROD_SEPCIN_FIELD_CONTACT SET CONTACT_PERSON = :CONTACT_PERSON WHERE ID_CONTACT = :ID_CONTACT";
        return sql;
    }

    #endregion

    #region ************************** Last Visit **********************

    public static string getLastVisit()
    {
        string sql = "SELECT ID_LAST_VISIT, LAST_VISIT FROM PROD_SEPCIN_FIELD_LAST_VISIT";
        return sql;
    }

    public static string getLastVisitById()
    {
        string sql = "SELECT ID_LAST_VISIT, LAST_VISIT FROM PROD_SEPCIN_FIELD_LAST_VISIT WHERE ID_LAST_VISIT = :ID_LAST_VISIT";
        return sql;
    }

    public static string createLastVisit()
    {
        string sql = "INSERT INTO PROD_SEPCIN_FIELD_LAST_VISIT (LAST_VISIT) VALUES (:LAST_VISIT)";
        return sql;
    }

    public static string updateLastVisit()
    {
        string sql = "UPDATE PROD_SEPCIN_FIELD_LAST_VISIT SET LAST_VISIT = :LAST_VISIT WHERE ID_LAST_VISIT = :ID_LAST_VISIT";
        return sql;
    }

    #endregion

    #region ************************** Visa Type **********************

    public static string getVisaType()
    {
        string sql = "SELECT ID_VISA, VISA_TYPE FROM PROD_SEPCIN_FIELD_VISA_TYPE";
        return sql;
    }

    public static string getVisaTypeById()
    {
        string sql = "SELECT ID_VISA, VISA_TYPE FROM PROD_SEPCIN_FIELD_VISA_TYPE WHERE ID_VISA = :ID_VISA";
        return sql;
    }

    public static string createVisaType()
    {
        string sql = "INSERT INTO PROD_SEPCIN_FIELD_VISA_TYPE (VISA_TYPE) VALUES (:VISA_TYPE)";
        return sql;
    }

    public static string updateVisaType()
    {
        string sql = "UPDATE PROD_SEPCIN_FIELD_VISA_TYPE SET VISA_TYPE = :VISA_TYPE WHERE ID_VISA = :ID_VISA";
        return sql;
    }

    #endregion

    #endregion ************************ Application Configuration Queries End ************************************


    #region ************************ Field Visit Request Form Queries Start ************************************

    #region ******************************Questionaire*******************************

    public static string getQuestionaire()
    {
        string sql = "SELECT PROD_QUESTIONAIRE.ID_QUESTION, PROD_QUESTIONAIRE.SEQUENCIAL, PROD_QUESTIONAIRE.QUESTION, PROD_QUESTIONAIRE.DESCRIPTION FROM PROD_QUESTIONAIRE ORDER BY SEQUENCIAL";

        return sql;
    }

    public static string getQuestionaireById()
    {
        string sql = "SELECT PROD_QUESTIONAIRE.ID_QUESTION, PROD_QUESTIONAIRE.SEQUENCIAL, PROD_QUESTIONAIRE.QUESTION, PROD_QUESTIONAIRE.DESCRIPTION FROM PROD_QUESTIONAIRE WHERE PROD_QUESTIONAIRE.ID_QUESTION = :ID_QUESTION";

        return sql;
    }

    public static string insertQuestion()
    {
        string sql = "INSERT INTO PROD_QUESTIONAIRE (SEQUENCIAL, QUESTION, DESCRIPTION) VALUES (:SEQUENCIAL, :QUESTION, :DESCRIPTION)";
        return sql;
    }

    public static string updateQuestion()
    {
        string sql = "UPDATE PROD_QUESTIONAIRE SET QUESTION = :QUESTION, DESCRIPTION = :DESCRIPTION WHERE ID_QUESTION = :ID_QUESTION";
        return sql;
    }

    public static string CreateNewSiteVisitCheckList()
    {
        string sql = "INSERT INTO PROD_ACTIVITIES_QUESTIONAIRE (ID_ACTIVITIES, ID_QUESTION, CHECKLIST) VALUES (:ID_ACTIVITIES, :ID_QUESTION, :CHECKLIST)";
        return sql;
    }

    public static string UpdateSiteVisitCheckList()
    {
        string sql = "UPDATE PROD_ACTIVITIES_QUESTIONAIRE SET CHECKLIST = :CHECKLIST WHERE (ID_ACTIVITIES = :ID_ACTIVITIES) AND (ID_QUESTION = :ID_QUESTION)";
        return sql;
    }

    #endregion

    #region************************** Field Visit Queries ***********************************

    public static string UpdateFieldVisitRequestPreStatus()
    {
        string sql = "UPDATE PROD_ACTIVITIES SET PRESTATUS = :iStatus WHERE ID_ACTIVITIES = :lActivityId";
        return sql;
    }
    public static string DeleteFieldVisitRequest()
    {
        string sql = "UPDATE PROD_ACTIVITIES SET STATUS = :iStatus WHERE ID_ACTIVITIES = :lActivityId";
        return sql;
    }


    public static string CreateNewSiteVisit()
    {
        string sql = "INSERT INTO PROD_ACTIVITIES (ID_ACTIVITIES, ID_FACILITIES, TASK_DESCRIPTION, USERID, STATUS, ACTIVITYID, ";
        sql += "DATE_FROM, DATE_TO, ACCOUNT, GENERAL_COMMENT, NO_OF_PERSONNEL, NO_OF_NIGHTS) ";
        sql += "VALUES (:ID_ACTIVITIES, :ID_FACILITIES, :TASK_DESCRIPTION, :USERID, :STATUS, :ACTIVITYID, :DATE_FROM, :DATE_TO, ";
        sql += ":ACCOUNT, :GENERAL_COMMENT, :NO_OF_PERSONNEL, :NO_OF_NIGHTS)";

        return sql;
    }

    public static string UpdateSiteVisit()
    {
        string sql = "UPDATE PROD_ACTIVITIES SET ID_FACILITIES = :ID_FACILITIES, TASK_DESCRIPTION = :TASK_DESCRIPTION, DATE_FROM = :DATE_FROM, DATE_TO = :DATE_TO, USERID = :USERID, ";
        sql += "ACCOUNT = :ACCOUNT, GENERAL_COMMENT = :GENERAL_COMMENT, NO_OF_PERSONNEL = :NO_OF_PERSONNEL, NO_OF_NIGHTS = :NO_OF_NIGHTS WHERE ID_ACTIVITIES = :ID_ACTIVITIES";

        return sql;
    }

    public static string fieldVisitDetails()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, ";
        sql += "PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, PROD_ACTIVITIES_APPROVAL.COMMENTS, ";
        sql += "PROD_ACTIVITIES_APPROVAL.STAND, PROD_ACTIVITIES_APPROVAL.ROLES ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string fieldVisitRequestsPendingApproval()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "WHERE (PROD_ACTIVITIES.STATUS <> :STATUS) AND (PROD_ACTIVITIES_APPROVAL.STAND <> :STAND) AND (PROD_ACTIVITIES.STATUS <> :delSTATUS) ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string fieldVisitRequestRejected()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, PROD_ACTIVITIES_APPROVAL.STAND ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "WHERE (PROD_ACTIVITIES_APPROVAL.STAND = :STAND) AND (PROD_ACTIVITIES.STATUS <> :delSTATUS) ";
        sql += "ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC"; //--(PROD_ACTIVITIES.STATUS = :STATUS) OR 

        return sql;
    }

    public static string fieldVisitRequestRejectedByFacility()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, PROD_ACTIVITIES_APPROVAL.STAND ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "WHERE (PROD_ACTIVITIES_APPROVAL.STAND = :STAND) AND (PROD_ACTIVITIES.STATUS <> :delSTATUS) AND (PROD_FACILITIES.ID_FACILITIES = :iFacilityId) ";
        sql += "ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC"; //--(PROD_ACTIVITIES.STATUS = :STATUS) OR 

        return sql;
    }

    public static string fieldVisitRequestsApproved()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, PROD_DISTRICT.DISTRICT, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_ACTIVITIES.STATUS = :STATUS ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string fieldVisitDetailsByActivityId()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES,  ";
        sql += "PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, ";
        sql += "PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, PROD_ACTIVITIES_APPROVAL.COMMENTS, PROD_ACTIVITIES_APPROVAL.STAND, ";
        sql += "PROD_ACTIVITIES_APPROVAL.ROLES, PROD_ACTIVITIES.NO_OF_PERSONNEL, PROD_ACTIVITIES.NO_OF_NIGHTS ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_ACTIVITIES.ID_ACTIVITIES = :ID_ACTIVITIES ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC"; //ID_ACTIVITIES

        return sql;
    }

    public static string fieldVisitDetailsReportByActivityId()
    {
        string sql = "SELECT ID_QUESTION, SEQUENCIAL, QUESTION, DESCRIPTION, CHECKLIST, ID_ACTIVITIES, TASK_DESCRIPTION, ";
        sql += "TO_CHAR(DATE_FROM, 'DD-MON-YYYY') AS DATE_FROM, TO_CHAR(DATE_TO, 'DD-MON-YYYY') AS DATE_TO, ";
        sql += "ACCOUNT, GENERAL_COMMENT, FULLNAME, NO_OF_PERSONNEL, USERID, STATUS, ACTIVITYID, ";
        sql += "NO_OF_NIGHTS, ID_FACILITIES, FACILITIES, ID_DISTRICT, DISTRICT, ID_SUPERINTENDENT, SUPERINTENDENT, SUPERINTENDENT_EMAIL ";
        sql += "FROM PROD_VIW_RPT WHERE ID_ACTIVITIES = :ID_ACTIVITIES ORDER BY SEQUENCIAL";

        return sql;
    }

    public static string fieldVisitDetailsQuestionaireByActivityId()
    {
        string sql = "SELECT ID, ID_ACTIVITIES, ID_QUESTION, CHECKLIST FROM PROD_ACTIVITIES_QUESTIONAIRE WHERE ID_ACTIVITIES = :ID_ACTIVITIES ORDER BY ID";
        return sql;
    }

    public static string PendingFieldVisitDetailsByInitiator()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, PROD_USERMGT.FULLNAME ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_ACTIVITIES.USERID = :USERID) AND (PROD_ACTIVITIES.STATUS <> :STATUS) AND (PROD_ACTIVITIES.STATUS <> :delSTATUS) ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string ApprovedFieldVisitDetailsByInitiator()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, PROD_USERMGT.FULLNAME ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_ACTIVITIES.USERID = :USERID) AND (PROD_ACTIVITIES.STATUS = :STATUS) ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string FieldVisitDetailsByRequestNumber()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, ";
        sql += "PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, PROD_USERMGT.FULLNAME ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_ACTIVITIES.ACTIVITYID = :sRequestNumber)";

        return sql;
    }

    public static string PendingFieldVisitDetailsByApprover()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, PROD_ACTIVITIES.TASK_DESCRIPTION, ";
        sql += "INITIATOR.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, ";
        sql += "INITIATOR.FULLNAME, TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO,  ";
        sql += "PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, ";
        sql += "PROD_ACTIVITIES_APPROVAL.COMMENTS, PROD_ACTIVITIES_APPROVAL.STAND, PROD_ACTIVITIES_APPROVAL.ROLES ";
        sql += "FROM PROD_ACTIVITIES INNER JOIN ";
        sql += "PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "INNER JOIN PROD_USERMGT APPROVERS ON PROD_ACTIVITIES_APPROVAL.USERID = APPROVERS.USERID ";
        sql += "INNER JOIN PROD_USERMGT INITIATOR ON PROD_ACTIVITIES.USERID = INITIATOR.USERID ";
        sql += "WHERE (APPROVERS.USERID = :USERID) AND (PROD_ACTIVITIES_APPROVAL.ROLES = :ROLEID) AND (PROD_ACTIVITIES_APPROVAL.STAND = :STAND) AND (PROD_ACTIVITIES.STATUS <> :delSTATUS) ";
        sql += "ORDER BY PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string RejectedFieldVisiRequestsByApprover()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, PROD_ACTIVITIES.TASK_DESCRIPTION, ";
        sql += "INITIATOR.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, ";
        sql += "INITIATOR.FULLNAME, TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO,  ";
        sql += "PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, ";
        sql += "PROD_ACTIVITIES_APPROVAL.COMMENTS, PROD_ACTIVITIES_APPROVAL.STAND, PROD_ACTIVITIES_APPROVAL.ROLES ";
        sql += "FROM PROD_ACTIVITIES INNER JOIN ";
        sql += "PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "INNER JOIN PROD_USERMGT APPROVERS ON PROD_ACTIVITIES_APPROVAL.USERID = APPROVERS.USERID ";
        sql += "INNER JOIN PROD_USERMGT INITIATOR ON PROD_ACTIVITIES.USERID = INITIATOR.USERID ";
        sql += "WHERE (APPROVERS.USERID = :USERID) AND (PROD_ACTIVITIES_APPROVAL.ROLES = :ROLEID) AND (PROD_ACTIVITIES_APPROVAL.STAND <> :apprdSTAND) ";
        sql += "AND (PROD_ACTIVITIES_APPROVAL.STAND <> :noCmtSTAND) AND (PROD_ACTIVITIES.STATUS <> :delSTATUS) ";
        sql += "ORDER BY PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string ApprovedFieldVisitDetailsByApprover()
    {
        string sql = "SELECT PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, PROD_ACTIVITIES.TASK_DESCRIPTION, ";
        sql += "INITIATOR.USERID, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT, ";
        sql += "INITIATOR.FULLNAME, TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO,  ";
        sql += "PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, ";
        sql += "PROD_ACTIVITIES_APPROVAL.COMMENTS, PROD_ACTIVITIES_APPROVAL.STAND, PROD_ACTIVITIES_APPROVAL.ROLES ";
        sql += "FROM PROD_ACTIVITIES INNER JOIN ";
        sql += "PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "INNER JOIN PROD_USERMGT APPROVERS ON PROD_ACTIVITIES_APPROVAL.USERID = APPROVERS.USERID ";
        sql += "INNER JOIN PROD_USERMGT INITIATOR ON PROD_ACTIVITIES.USERID = INITIATOR.USERID ";
        sql += "WHERE (APPROVERS.USERID = :USERID) AND (PROD_ACTIVITIES_APPROVAL.ROLES = :ROLEID) AND (PROD_ACTIVITIES_APPROVAL.STAND = :STAND) ";
        sql += "ORDER BY PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES DESC";

        return sql;
    }

    public static string getApprovalDetailsBySuperintendent()
    {
        string sql = "SELECT ID_APPROVAL, ID_ACTIVITIES, USERID, COMMENTS, STAND, ROLES, ID_FACILITIES, ";
        sql += "TO_CHAR(DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, TO_CHAR(DATE_COMMENT, 'DD/MM/YYYY') AS DATE_COMMENT ";
        sql += "FROM PROD_ACTIVITIES_APPROVAL WHERE (ROLES = :ROLES) AND (ID_ACTIVITIES = :ID_ACTIVITIES)";

        return sql;
    }

    public static string PendingFieldVisitDetailsBySuperintendent()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_DISTRICT.DISTRICT, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.GENERAL_COMMENT, ";
        sql += "PROD_ACTIVITIES.NO_OF_PERSONNEL, PROD_ACTIVITIES.NO_OF_NIGHTS, PROD_ACTIVITIES.ACCOUNT, PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, ";
        sql += "PROD_ACTIVITIES_APPROVAL.USERID, PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, ";
        sql += "PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, PROD_ACTIVITIES_APPROVAL.COMMENTS, PROD_ACTIVITIES_APPROVAL.STAND, ";
        sql += "PROD_ACTIVITIES_APPROVAL.ROLES ";
        sql += "FROM PROD_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_DISTRICT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "INNER JOIN PROD_ACTIVITIES ON PROD_FACILITIES.ID_FACILITIES = PROD_ACTIVITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_ACTIVITIES_APPROVAL.STAND <> :STAND) AND (PROD_SUPERINTENDENT.ID_SUPERINTENDENT = :ID_SUPERINTENDENT) ";
        sql += "AND (PROD_ACTIVITIES_APPROVAL.ROLES = :ROLES) AND (PROD_ACTIVITIES.STATUS = :STATUS)";

        return sql;
    }

    public static string ApprovedFieldVisitDetailsBySuperintendent()
    {
        string sql = "SELECT PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_DISTRICT.DISTRICT, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.GENERAL_COMMENT, ";
        sql += "PROD_ACTIVITIES.NO_OF_PERSONNEL, PROD_ACTIVITIES.NO_OF_NIGHTS, PROD_ACTIVITIES.ACCOUNT, PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, ";
        sql += "PROD_ACTIVITIES_APPROVAL.USERID, PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, ";
        sql += "PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, PROD_ACTIVITIES_APPROVAL.COMMENTS, PROD_ACTIVITIES_APPROVAL.STAND, ";
        sql += "PROD_ACTIVITIES_APPROVAL.ROLES ";
        sql += "FROM PROD_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_SUPERINTENDENT.ID_SUPERINTENDENT = PROD_DISTRICT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "INNER JOIN PROD_ACTIVITIES ON PROD_FACILITIES.ID_FACILITIES = PROD_ACTIVITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_ACTIVITIES_APPROVAL ON PROD_ACTIVITIES.ID_ACTIVITIES = PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_ACTIVITIES_APPROVAL.STAND = :STAND) AND (PROD_SUPERINTENDENT.ID_SUPERINTENDENT = :ID_SUPERINTENDENT) ";
        sql += "AND (PROD_ACTIVITIES_APPROVAL.ROLES = :ROLES)";

        return sql;
    }

    public static string assignSiteVisitActivityToActivitySponsorPlanner()
    {
        string sql = "INSERT INTO PROD_ACTIVITIES_APPROVAL (ID_ACTIVITIES, USERID, DATE_RECEIVED, ROLES) VALUES (:ID_ACTIVITIES, :USERID, :DATE_RECEIVED, :ROLES)";
        return sql;
    }

    public static string assignSiteVisitActivityToSuperintendent()
    {
        string sql = "INSERT INTO PROD_ACTIVITIES_APPROVAL (ID_ACTIVITIES, DATE_RECEIVED, ROLES) VALUES (:ID_ACTIVITIES, :DATE_RECEIVED, :ROLES)";
        return sql;
    }

    public static string updateAssignSiteVisitActivityToApprover()
    {
        string sql = "UPDATE PROD_ACTIVITIES_APPROVAL SET USERID = :USERID WHERE (ROLES = :ROLES AND ID_ACTIVITIES = :ID_ACTIVITIES)";
        return sql;
    }

    public static string superintendentActionFieldVisitRequest()
    {
        string sql = "UPDATE PROD_ACTIVITIES_APPROVAL SET DATE_COMMENT = :DATE_COMMENT, COMMENTS = :COMMENTS, USERID = :USERID, STAND = :STAND WHERE (ID_APPROVAL = :ID_APPROVAL)";
        return sql;
    }

    public static string actionFieldVisitRequest()
    {
        string sql = "UPDATE PROD_ACTIVITIES_APPROVAL SET DATE_COMMENT = :DATE_COMMENT, COMMENTS = :COMMENTS, STAND = :STAND WHERE (ID_APPROVAL = :ID_APPROVAL) AND (USERID = :USERID)";
        return sql;
    }

    public static string fieldVisitApprovalByApprovalId()
    {
        string sql = "SELECT ID_APPROVAL, ID_ACTIVITIES, USERID, TO_CHAR(DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, STAND, ROLES, ";
        sql += "TO_CHAR(DATE_COMMENT, 'DD/MM/YYYY') AS DATE_COMMENT, COMMENTS FROM PROD_ACTIVITIES_APPROVAL WHERE ID_APPROVAL = :ID_APPROVAL";
        return sql;
    }

    public static string fieldVisitApprovalByActivityId()
    {
        string sql = "SELECT ID_APPROVAL, ID_ACTIVITIES, USERID, TO_CHAR(DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, STAND, ROLES, ";
        sql += "TO_CHAR(DATE_COMMENT, 'DD/MM/YYYY') AS DATE_COMMENT, COMMENTS FROM PROD_ACTIVITIES_APPROVAL WHERE ID_ACTIVITIES = :ID_ACTIVITIES";
        return sql;
    }

    public static string fieldVisitApprovalByActivityIdApprovalId()
    {
        string sql = "SELECT ID_APPROVAL, ID_ACTIVITIES, USERID, TO_CHAR(DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, ";
        sql += "STAND, ROLES, TO_CHAR(DATE_COMMENT, 'DD/MM/YYYY') AS DATE_COMMENT, COMMENTS FROM PROD_ACTIVITIES_APPROVAL ";
        sql += "WHERE (ID_ACTIVITIES = :ID_ACTIVITIES) AND (ID_APPROVAL = :ID_APPROVAL)";
        return sql;
    }

    public static string fieldVisitApprovalByActivityIdApprovalIdPlanner()
    {
        string sql = "SELECT ID_APPROVAL, ID_ACTIVITIES, USERID, TO_CHAR(DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, ";
        sql += "STAND, ROLES, TO_CHAR(DATE_COMMENT, 'DD/MM/YYYY') AS DATE_COMMENT, COMMENTS FROM PROD_ACTIVITIES_APPROVAL ";
        sql += "WHERE (ID_ACTIVITIES = :ID_ACTIVITIES) AND (ID_APPROVAL = :ID_APPROVAL) AND (USERID = :USERID)";
        return sql;
    }

    #endregion

    #region************************** Field Visit Status Queries ***********************************

    public static string fieldVisitApprovalStatus()
    {
        string sql = "SELECT PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES, PROD_ACTIVITIES_APPROVAL.USERID, ";
        sql += "PROD_ACTIVITIES_APPROVAL.COMMENTS, TO_CHAR(PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, ";
        sql += "TO_CHAR(PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, 'DD/MM/YYYY') AS DATE_COMMENT, PROD_ACTIVITIES_APPROVAL.STAND, ";
        sql += "PROD_ACTIVITIES_APPROVAL.ROLES, PROD_USERMGT.FULLNAME, PROD_ACTIVITIES_APPROVAL.ID_FACILITIES ";
        sql += "FROM PROD_ACTIVITIES_APPROVAL LEFT OUTER JOIN PROD_USERMGT ON PROD_ACTIVITIES_APPROVAL.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES = :ID_ACTIVITIES ";

        return sql;
    }

    //public static string fieldVisitApprovalStatusActivityPlanner()
    //{
    //    string sql = "SELECT PROD_ACTIVITIES_APPROVAL.ID_APPROVAL, PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES, PROD_ACTIVITIES_APPROVAL.USERID, PROD_ACTIVITIES_APPROVAL.COMMENTS, ";
    //    sql += "TO_CHAR(PROD_ACTIVITIES_APPROVAL.DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, TO_CHAR(PROD_ACTIVITIES_APPROVAL.DATE_COMMENT, 'DD/MM/YYYY') AS DATE_COMMENT, ";
    //    sql += "PROD_ACTIVITIES_APPROVAL.STAND, PROD_ACTIVITIES_APPROVAL.ROLES, PROD_PLANNERS.FULL_NAME FROM PROD_ACTIVITIES_APPROVAL ";
    //    sql += "INNER JOIN PROD_PLANNERS ON PROD_ACTIVITIES_APPROVAL.USERID = PROD_PLANNERS.USERNAME ";
    //    sql += "WHERE PROD_ACTIVITIES_APPROVAL.ID_ACTIVITIES = :ID_ACTIVITIES ";

    //    return sql;
    //}

    public static string updateFieldVisitRequestStatus()
    {
        string sql = "UPDATE PROD_ACTIVITIES SET STATUS = :STATUS WHERE ID_ACTIVITIES = :ID_ACTIVITIES";
        return sql;
    }

    public static string updatePECRequestStatus()
    {
        string sql = "UPDATE PROD_SEPCIN_ACTIVITYINFO SET STATUS = :STATUS WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    #endregion

    #region************************** Account To Charge **********************************

    //public static string getAccountToCharge()
    //{
    //    //TODO: Possible SQL Injection attack. While going to test/live server, change the AppConfiguration.DbLink to the right link in the config file
    //    string sql = "SELECT VIW_SAP_COST_OBJECT.SAP_COST_OBJECTS_DESC AS ACCOUNT_DESCRIPTION, VIW_SAP_COST_OBJECT.SAP_COST_OBJECTS_NAME AS ACCOUNT ";
    //    sql += "FROM VIW_SAP_COST_OBJECT ORDER BY ACCOUNT";
    //    //sql += "FROM VIW_SAP_COST_OBJECT" + AppConfiguration.DbLink + " ORDER BY ACCOUNT";

    //    return sql;
    //}

    public static string getAccountToChargeByPrefixText()
    {
        //TODO: Possible SQL Injection attack. While going to test/live server, change the AppConfiguration.DbLink to the right link in the config file
        string sql = "SELECT VIW_SAP_COST_OBJECT.SAP_COST_OBJECTS_DESC AS ACCOUNT_DESCRIPTION, VIW_SAP_COST_OBJECT.SAP_COST_OBJECTS_NAME AS ACCOUNT ";
        sql += "FROM VIW_SAP_COST_OBJECT WHERE VIW_SAP_COST_OBJECT.SAP_COST_OBJECTS_NAME LIKE :TACCOUNT ORDER BY ACCOUNT";
        //sql += "FROM VIW_SAP_COST_OBJECT" + AppConfiguration.DbLink + " WHERE VIW_SAP_COST_OBJECT.SAP_COST_OBJECTS_NAME LIKE :TACCOUNT ORDER BY ACCOUNT";

        return sql;
    }

    #endregion

    #endregion********************* Field Visit Request Form Queries End ********************************


    #region ************************ PEC Request Form Queries Start ************************************

    #region ************************** SEPCiN Activity Information ******************************

    public static string getPECReportByActivityID()
    {
        string sql = "SELECT ID_FIELD_LOC, FIELD_LOCATION, ID_FIELD, ID_ACTIVITYINFO, STATUS ";
        sql += "FROM PROD_VIW_PEC WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string getActivityInformationReportByActivityID()
    {
        string sql = "SELECT ID_ACTIVITYINFO, ACTIVITYDESCRIPTION, JUSTIFICATION, USERID, ";
        sql += "ID_ACTIVITYINFO, TO_CHAR(DATE_SUMBITTED, 'DD-MON-YYYY') AS DATE_SUMBITTED, FUNCTION_LOCATION, NO_BEDS, ";
        sql += "TO_CHAR(FIRST_NIGHT, 'DD/MM/YYYY') AS FIRST_NIGHT, TO_CHAR(LAST_NIGHT, 'DD/MM/YYYY') AS LAST_NIGHT, ";
        sql += "ACTIVITY_CAUSE_OIL_DEFRMNT, VOLUME, STATUS, FULLNAME, ID_UNIT, ";
        sql += "UNITS, ID_ACTIVITY_TYPE, ACTIVITY_TYPE, ID_FACILITIES, FACILITIES, ";
        sql += "ID_DISTRICT, DISTRICT, ID_SUPERINTENDENT, SUPERINTENDENT, SUPERINTENDENT_EMAIL ";
        sql += "FROM PROD_VIW_ACTIVITY WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string getAllActivityInformation()
    {
        string sql = "SELECT ID_ACTIVITYINFO, ID_ACTIVITY_TYPE, ID_FACILITIES, ACTIVITYDESCRIPTION, JUSTIFICATION, USERID, STATUS, ";
        sql += "ACTIVITYID, DATE_SUMBITTED, FUNCTION_LOCATION, NO_BEDS, FIRST_NIGHT, LAST_NIGHT, ";
        sql += "ACTIVITY_CAUSE_OIL_DEFRMNT, VOLUME, ID_UNIT, COMPLETE FROM PROD_SEPCIN_ACTIVITYINFO";

        //TO_CHAR(DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, TO_CHAR(DATE_SUMBITTED, 'DD/MM/YYYY') AS 

        return sql;
    }

    public static string getActivityInformationByOriginator()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, ";
        sql += "TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, PROD_SEPCIN_UNIT.ID_UNIT, PROD_SEPCIN_UNIT.UNITS, PROD_FACILITIES.ID_FACILITIES, ";
        sql += "PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, PROD_USERMGT.USERID, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_SEPCIN_ACTIVITYINFO.COMPLETE FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_SEPCIN_UNIT ON PROD_SEPCIN_ACTIVITYINFO.ID_UNIT = PROD_SEPCIN_UNIT.ID_UNIT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_USERMGT.USERID = :USERID AND PROD_SEPCIN_ACTIVITYINFO.STATUS <> :STATUS ORDER BY ID_ACTIVITYINFO DESC";

        return sql;
    }

    public static string getActivityInformationByStatus()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, ";
        sql += "TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, PROD_SEPCIN_UNIT.ID_UNIT, PROD_SEPCIN_UNIT.UNITS, PROD_FACILITIES.ID_FACILITIES, ";
        sql += "PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, PROD_USERMGT.USERID, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_SEPCIN_ACTIVITYINFO.COMPLETE FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_SEPCIN_UNIT ON PROD_SEPCIN_ACTIVITYINFO.ID_UNIT = PROD_SEPCIN_UNIT.ID_UNIT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_USERMGT.USERID = :USERID AND PROD_SEPCIN_ACTIVITYINFO.STATUS = :STATUS ORDER BY ID_ACTIVITYINFO DESC";

        return sql;
    }

    public static string getAllActivityInformationById()
    {
        string sql = "SELECT ID_ACTIVITY_TYPE, ID_FACILITIES, ACTIVITYDESCRIPTION, JUSTIFICATION, USERID, STATUS, ACTIVITYID, DATE_SUMBITTED, ";
        sql += "FUNCTION_LOCATION, NO_BEDS, FIRST_NIGHT, LAST_NIGHT, ACTIVITY_CAUSE_OIL_DEFRMNT, VOLUME, ID_UNIT, COMPLETE ";
        sql += "FROM PROD_SEPCIN_ACTIVITYINFO WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;

        //TO_CHAR(DATE_SUMBITTED, 'DD/MM/YYYY') AS TO_CHAR(FIRST_NIGHT, 'DD/MM/YYYY') AS TO_CHAR(LAST_NIGHT, 'DD/MM/YYYY') AS 
    }

    public static string getActivityByActivityId()
    {
        string sql = "SELECT ID_ACTIVITYINFO, ID_ACTIVITY_TYPE, ID_FACILITIES, ACTIVITYDESCRIPTION, JUSTIFICATION, USERID, STATUS, ";
        sql += "ACTIVITYID, DATE_SUMBITTED, FUNCTION_LOCATION, NO_BEDS, FIRST_NIGHT, LAST_NIGHT, ";
        sql += "ACTIVITY_CAUSE_OIL_DEFRMNT, VOLUME, ID_UNIT, COMPLETE FROM PROD_SEPCIN_ACTIVITYINFO WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;

        //TO_CHAR(DATE_SUMBITTED, 'DD/MM/YYYY') AS TO_CHAR(FIRST_NIGHT, 'DD/MM/YYYY') AS TO_CHAR(LAST_NIGHT, 'DD/MM/YYYY') AS 
    }

    public static string createActivityInformation()
    {
        string sql = "INSERT INTO PROD_SEPCIN_ACTIVITYINFO (ID_ACTIVITYINFO, ID_ACTIVITY_TYPE, ID_FACILITIES, ACTIVITYDESCRIPTION, JUSTIFICATION, USERID, ";
        sql += "ACTIVITYID, DATE_SUMBITTED, FUNCTION_LOCATION, NO_BEDS, FIRST_NIGHT, LAST_NIGHT, ACTIVITY_CAUSE_OIL_DEFRMNT, VOLUME, ID_UNIT) ";
        sql += "VALUES (:ID_ACTIVITYINFO, :ID_ACTIVITY_TYPE, :ID_FACILITIES, :ACTIVITYDESCRIPTION, :JUSTIFICATION, :USERID, ";
        sql += ":ACTIVITYID, :DATE_SUMBITTED, :FUNCTION_LOCATION, :NO_BEDS, :FIRST_NIGHT, :LAST_NIGHT, :ACTIVITY_CAUSE_OIL_DEFRMNT, :VOLUME, :ID_UNIT) ";

        return sql;
    }

    public static string updateActivityInformation()
    {
        string sql = "UPDATE PROD_SEPCIN_ACTIVITYINFO SET ID_ACTIVITY_TYPE = :ID_ACTIVITY_TYPE, ID_FACILITIES = :ID_FACILITIES, ACTIVITYDESCRIPTION = :ACTIVITYDESCRIPTION, ";
        sql += "JUSTIFICATION = :JUSTIFICATION, USERID = :USERID, FUNCTION_LOCATION = :FUNCTION_LOCATION, NO_BEDS = :NO_BEDS, FIRST_NIGHT = :FIRST_NIGHT, ";
        sql += "LAST_NIGHT = :LAST_NIGHT, ACTIVITY_CAUSE_OIL_DEFRMNT = :ACTIVITY_CAUSE_OIL_DEFRMNT, VOLUME = :VOLUME, ID_UNIT = :ID_UNIT WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string deleteActivityInformation()
    {
        string sql = "UPDATE PROD_SEPCIN_ACTIVITYINFO SET STATUS = :STATUS, COMPLETE = :LSTATUSB4DLT WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    public static string UnDeleteActivityInformation()
    {
        string sql = "UPDATE PROD_SEPCIN_ACTIVITYINFO SET STATUS = :STATUS WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    public static string purgeActivityInformation()
    {
        string sql = "DELETE FROM PROD_SEPCIN_ACTIVITYINFO WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }


    #endregion

    #region ************************** PEC Approval ***************************************

    public static string getApprovalReportByActivityID()
    {
        string sql = "SELECT FULLNAME, REFIND, USERNAME, ID_APPROVAL, ACTIVITYID, COMMENTS, ROLEID, ID_ACTIVITYINFO, ";
        sql += "TO_CHAR(DATE_RECEIVED, 'DD-MON-YYYY') AS DATE_RECEIVED, TO_CHAR(DATE_REVIEWED, 'DD-MON-YYYY') AS DATE_REVIEWED ";
        sql += "FROM PROD_VIW_APPROVAL WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string pecApprovalByActivityId()
    {
        string sql = "SELECT PROD_SEPCIN_APPROVAL.ID_APPROVAL, PROD_SEPCIN_APPROVAL.ID_ACTIVITYINFO, PROD_SEPCIN_APPROVAL.USERID, ";
        sql += "TO_CHAR(PROD_SEPCIN_APPROVAL.DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, PROD_SEPCIN_APPROVAL.STAND, ";
        sql += "PROD_SEPCIN_APPROVAL.ROLEID, TO_CHAR(PROD_SEPCIN_APPROVAL.DATE_REVIEWED, 'DD/MM/YYYY') AS DATE_REVIEWED, ";
        sql += "PROD_SEPCIN_APPROVAL.COMMENTS, PROD_USERMGT.FULLNAME, PROD_USERMGT.EMAIL, PROD_USERMGT.USERNAME ";
        sql += "FROM PROD_SEPCIN_APPROVAL INNER JOIN PROD_USERMGT ON PROD_SEPCIN_APPROVAL.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string getPecApprovalByApprovalId()
    {
        string sql = "SELECT ID_APPROVAL, ID_ACTIVITYINFO, USERID, TO_CHAR(DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, STAND, ROLEID, ";
        sql += "TO_CHAR(DATE_REVIEWED, 'DD/MM/YYYY') AS DATE_REVIEWED, COMMENTS FROM PROD_SEPCIN_APPROVAL WHERE ID_APPROVAL = :ID_APPROVAL";
        return sql;
    }

    public static string assignPECRequestToApprover()
    {
        string sql = "INSERT INTO PROD_SEPCIN_APPROVAL (ID_ACTIVITYINFO, USERID, DATE_RECEIVED, ROLEID) VALUES (:ID_ACTIVITYINFO, :USERID, :DATE_RECEIVED, :ROLEID)";
        return sql;
    }

    public static string UpdateAssignedPECRequestToApprover()
    {
        string sql = "UPDATE PROD_SEPCIN_APPROVAL SET USERID = :USERID WHERE (ROLEID = :ROLEID) AND (ID_ACTIVITYINFO = :ID_ACTIVITYINFO)";
        return sql;
    }

    public static string actionPECRequest()
    {
        string sql = "UPDATE PROD_SEPCIN_APPROVAL SET DATE_REVIEWED = :DATE_REVIEWED, COMMENTS = :COMMENTS, STAND = :STAND WHERE (ID_APPROVAL = :ID_APPROVAL)";
        return sql;
    }

    public static string DeletePECApprovalByActivity()
    {
        string sql = "DELETE FROM PROD_SEPCIN_APPROVAL WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    #endregion

    #region ************************** SEPCiN Personnel Information *****************************

    public static string getPersonnelInformationReportByActivityID()
    {
        string sql = "SELECT ID_PERSONNEL, ID_ACTIVITYINFO, EMPLOYEE_NAME, GENDER, COMPANY, BOSIET_VALID, HUET_VALID, MEDICAL, PPE, ";
        sql += "ID_VISA, VISA_TYPE, ID_LAST_VISIT, LAST_VISIT, ID_BAG, BAGGAGE, ID_CONTACT, CONTACT_PERSON ";
        sql += "FROM PROD_VIW_PERSONNEL WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string getAllPersonnelInformation()
    {
        string sql = "SELECT ID_PERSONNEL, ID_ACTIVITYINFO, EMPLOYEE_NAME, GENDER, COMPANY, ID_CONTACT, ID_LAST_VISIT, ";
        sql += "BOSIET_VALID, HUET_VALID, MEDICAL, ID_VISA, PPE, ID_BAG FROM PROD_SEPCIN_PERSONNEL_INFO";

        return sql;
    }

    public static string getPersonnelInformationById()
    {
        string sql = "SELECT ID_PERSONNEL, ID_ACTIVITYINFO, EMPLOYEE_NAME, GENDER, COMPANY, ID_CONTACT, ID_LAST_VISIT, ";
        sql += "BOSIET_VALID, HUET_VALID, MEDICAL, ID_VISA, PPE, ID_BAG FROM PROD_SEPCIN_PERSONNEL_INFO ";
        sql += "WHERE ID_PERSONNEL = :ID_PERSONNEL";

        return sql;
    }

    public static string getPersonnelInformationByActivityId()
    {
        string sql = "SELECT PROD_SEPCIN_PERSONNEL_INFO.ID_PERSONNEL, PROD_SEPCIN_PERSONNEL_INFO.ID_ACTIVITYINFO, PROD_SEPCIN_PERSONNEL_INFO.EMPLOYEE_NAME, ";
        sql += "PROD_SEPCIN_PERSONNEL_INFO.GENDER, PROD_SEPCIN_PERSONNEL_INFO.COMPANY, PROD_SEPCIN_FIELD_CONTACT.ID_CONTACT, ";
        sql += "PROD_SEPCIN_FIELD_LAST_VISIT.ID_LAST_VISIT, PROD_SEPCIN_FIELD_LAST_VISIT.LAST_VISIT, PROD_SEPCIN_PERSONNEL_INFO.BOSIET_VALID, ";
        sql += "PROD_SEPCIN_PERSONNEL_INFO.HUET_VALID, PROD_SEPCIN_PERSONNEL_INFO.MEDICAL, PROD_SEPCIN_FIELD_VISA_TYPE.ID_VISA, ";
        sql += "PROD_SEPCIN_FIELD_VISA_TYPE.VISA_TYPE, PROD_SEPCIN_PERSONNEL_INFO.PPE, PROD_SEPCIN_FIELD_BAGGAGE.ID_BAG, ";
        sql += "PROD_SEPCIN_FIELD_BAGGAGE.BAGGAGE, PROD_SEPCIN_FIELD_CONTACT.CONTACT_PERSON ";
        sql += "FROM PROD_SEPCIN_PERSONNEL_INFO ";
        sql += "INNER JOIN PROD_SEPCIN_FIELD_LAST_VISIT ON PROD_SEPCIN_PERSONNEL_INFO.ID_LAST_VISIT = PROD_SEPCIN_FIELD_LAST_VISIT.ID_LAST_VISIT ";
        sql += "INNER JOIN PROD_SEPCIN_FIELD_VISA_TYPE ON PROD_SEPCIN_PERSONNEL_INFO.ID_VISA = PROD_SEPCIN_FIELD_VISA_TYPE.ID_VISA ";
        sql += "INNER JOIN PROD_SEPCIN_FIELD_BAGGAGE ON PROD_SEPCIN_PERSONNEL_INFO.ID_BAG = PROD_SEPCIN_FIELD_BAGGAGE.ID_BAG ";
        sql += "INNER JOIN PROD_SEPCIN_FIELD_CONTACT ON PROD_SEPCIN_PERSONNEL_INFO.ID_CONTACT = PROD_SEPCIN_FIELD_CONTACT.ID_CONTACT ";
        sql += "WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string createPersonnelInformation()
    {
        string sql = "INSERT INTO PROD_SEPCIN_PERSONNEL_INFO (ID_ACTIVITYINFO, EMPLOYEE_NAME, GENDER, COMPANY, ";
        sql += "ID_CONTACT, ID_LAST_VISIT, BOSIET_VALID, HUET_VALID, MEDICAL, ID_VISA, PPE, ID_BAG) ";
        sql += "VALUES (:ID_ACTIVITYINFO, :EMPLOYEE_NAME, :GENDER, :COMPANY, :ID_CONTACT, :ID_LAST_VISIT, ";
        sql += ":BOSIET_VALID, :HUET_VALID, :MEDICAL, :ID_VISA, :PPE, :ID_BAG) ";

        return sql;
    }

    public static string updatePersonnelInformation()
    {
        string sql = "UPDATE PROD_SEPCIN_PERSONNEL_INFO SET EMPLOYEE_NAME = :EMPLOYEE_NAME, GENDER = :GENDER, ";
        sql += "COMPANY = :COMPANY, ID_CONTACT = :ID_CONTACT, ID_LAST_VISIT = :ID_LAST_VISIT, BOSIET_VALID = :BOSIET_VALID, ";
        sql += "HUET_VALID = :HUET_VALID, MEDICAL = :MEDICAL, ID_VISA = :ID_VISA, PPE = :PPE, ID_BAG = :ID_BAG WHERE ID_PERSONNEL = :ID_PERSONNEL";

        return sql;
    }

    public static string deletePersonnel()
    {
        string sql = "DELETE FROM PROD_SEPCIN_PERSONNEL_INFO WHERE ID_PERSONNEL = :ID_PERSONNEL";
        return sql;
    }

    public static string DeletePersonnelByActivity()
    {
        string sql = "DELETE FROM PROD_SEPCIN_PERSONNEL_INFO WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }


    #endregion

    #region ************************** SEPCiN Vendor Call Out ***********************************

    public static string getVendorCallOutReportByActivityID()
    {
        string sql = "SELECT ID_VENDOR, ID_ACTIVITYINFO, VENDOR_NAME, CONTACT_PERSON, TELEPHONE, EMAIL_ADDRESS, VENDOR_ADDRESS, ";
        sql += "TOOLS_MATERIALS, TRADE_TYPE FROM PROD_VIW_VENDOR WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string getVendorCallOut()
    {
        string sql = "SELECT ID_VENDOR, ID_ACTIVITYINFO, VENDOR_NAME, CONTACT_PERSON, TELEPHONE, EMAIL_ADDRESS, ";
        sql += "ID_TRADE_TYPE, VENDOR_ADDRESS, TOOLS_MATERIALS FROM PROD_SEPCIN_VENDOR_CALLOUT";

        return sql;
    }

    public static string getVendorCallOutById()
    {
        string sql = "SELECT ID_VENDOR, ID_ACTIVITYINFO, VENDOR_NAME, CONTACT_PERSON, TELEPHONE, EMAIL_ADDRESS, ";
        sql += "ID_TRADE_TYPE, VENDOR_ADDRESS, TOOLS_MATERIALS FROM PROD_SEPCIN_VENDOR_CALLOUT ";
        sql += "WHERE ID_VENDOR = :ID_VENDOR";

        return sql;
    }

    public static string getVendorCallOutByActivityId()
    {
        string sql = "SELECT ID_VENDOR, ID_ACTIVITYINFO, VENDOR_NAME, CONTACT_PERSON, TELEPHONE, EMAIL_ADDRESS, ";
        sql += "ID_TRADE_TYPE, VENDOR_ADDRESS, TOOLS_MATERIALS FROM PROD_SEPCIN_VENDOR_CALLOUT ";
        sql += "WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string createVendorCallOut()
    {
        string sql = "INSERT INTO PROD_SEPCIN_VENDOR_CALLOUT (ID_ACTIVITYINFO, VENDOR_NAME, CONTACT_PERSON, TELEPHONE, EMAIL_ADDRESS, ID_TRADE_TYPE, VENDOR_ADDRESS, TOOLS_MATERIALS) ";
        sql += "VALUES (:ID_ACTIVITYINFO, :VENDOR_NAME, :CONTACT_PERSON, :TELEPHONE, :EMAIL_ADDRESS, :ID_TRADE_TYPE, :VENDOR_ADDRESS, :TOOLS_MATERIALS)";

        return sql;
    }

    public static string updateVendorCallOut()
    {
        string sql = "UPDATE PROD_SEPCIN_VENDOR_CALLOUT SET ID_ACTIVITYINFO = :ID_ACTIVITYINFO, VENDOR_NAME = :VENDOR_NAME, ";
        sql += "CONTACT_PERSON = :CONTACT_PERSON, TELEPHONE = :TELEPHONE, EMAIL_ADDRESS = :EMAIL_ADDRESS, ID_TRADE_TYPE = :ID_TRADE_TYPE, ";
        sql += "VENDOR_ADDRESS = :VENDOR_ADDRESS, TOOLS_MATERIALS = :TOOLS_MATERIALS WHERE ID_VENDOR = :ID_VENDOR";

        return sql;
    }

    public static string DeleteVendorCallOutByActivity()
    {
        string sql = "DELETE FROM PROD_SEPCIN_VENDOR_CALLOUT WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    #endregion

    #region ************************** SEPCiN Activity Time Line ********************************

    public static string getActivityTimeLineReportByActivityID()
    {
        string sql = "SELECT ID_TIMELINE, ID_ACTIVITYINFO, ACTIVITY_DESCRIPTION, TO_CHAR(START_DATE, 'DD-MON-YYYY') AS START_DATE, ";
        sql += "TO_CHAR(FINISH_DATE, 'DD-MON-YYYY') AS FINISH_DATE ";
        sql += "FROM PROD_SEPCIN_ACTIVITY_TIMELINE WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";

        return sql;
    }

    public static string getActivityTimeLine()
    {
        string sql = "SELECT ID_TIMELINE, ID_ACTIVITYINFO, ACTIVITY_DESCRIPTION, TO_CHAR(START_DATE, 'DD/MM/YYYY') AS START_DATE, TO_CHAR(FINISH_DATE, 'DD/MM/YYYY') AS FINISH_DATE FROM PROD_SEPCIN_ACTIVITY_TIMELINE";

        return sql;
    }

    public static string getActivityTimeLineById()
    {
        string sql = "SELECT ID_TIMELINE, ID_ACTIVITYINFO, ACTIVITY_DESCRIPTION, TO_CHAR(START_DATE, 'DD/MM/YYYY') AS START_DATE, TO_CHAR(FINISH_DATE, 'DD/MM/YYYY') AS FINISH_DATE FROM PROD_SEPCIN_ACTIVITY_TIMELINE ";
        sql += "WHERE ID_TIMELINE = :ID_TIMELINE";

        return sql;
    }

    public static string getActivityTimeLineByActivityId()
    {
        string sql = "SELECT ID_TIMELINE, ID_ACTIVITYINFO, ACTIVITY_DESCRIPTION, TO_CHAR(START_DATE, 'DD/MM/YYYY') AS START_DATE, TO_CHAR(FINISH_DATE, 'DD/MM/YYYY') AS FINISH_DATE FROM PROD_SEPCIN_ACTIVITY_TIMELINE ";
        sql += "WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO ORDER BY ID_TIMELINE";

        return sql;
    }

    public static string createActivityTimeLine()
    {
        string sql = "INSERT INTO PROD_SEPCIN_ACTIVITY_TIMELINE (ID_ACTIVITYINFO, ACTIVITY_DESCRIPTION, START_DATE, FINISH_DATE) ";
        sql += "VALUES (:ID_ACTIVITYINFO, :ACTIVITY_DESCRIPTION, :START_DATE, :FINISH_DATE)";

        return sql;
    }

    public static string updateActivityTimeLine()
    {
        string sql = "UPDATE PROD_SEPCIN_ACTIVITY_TIMELINE SET ACTIVITY_DESCRIPTION = :ACTIVITY_DESCRIPTION, ";
        sql += "START_DATE = :START_DATE, FINISH_DATE = :FINISH_DATE WHERE ID_TIMELINE = :ID_TIMELINE";

        return sql;
    }

    public static string deleteActivityTimeLine()
    {
        string sql = "DELETE FROM PROD_SEPCIN_ACTIVITY_TIMELINE WHERE ID_TIMELINE = :ID_TIMELINE";
        return sql;
    }

    public static string DeleteActivityTimeLineByActivity()
    {
        string sql = "DELETE FROM PROD_SEPCIN_ACTIVITY_TIMELINE WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    #endregion

    #region ************************** Field Location/Activity Information **********************

    public static string getLocationField()
    {
        string sql = "SELECT ID_FIELD_LOC, FIELD_LOCATION, ID_WINDOW FROM PROD_SEPCIN_LOC_FIELD ORDER BY ID_WINDOW";
        return sql;
    }

    public static string getLocationFieldById()
    {
        string sql = "SELECT ID_FIELD_LOC, FIELD_LOCATION, ID_WINDOW FROM PROD_SEPCIN_LOC_FIELD WHERE ID_FIELD_LOC = :ID_FIELD_LOC ORDER BY FIELD_LOCATION";
        return sql;
    }

    public static string getLocationFieldByWindowId()
    {
        string sql = "SELECT ID_FIELD_LOC, FIELD_LOCATION, ID_WINDOW FROM PROD_SEPCIN_LOC_FIELD WHERE ID_WINDOW = :ID_WINDOW ORDER BY FIELD_LOCATION";
        return sql;
    }

    public static string createLocationField()
    {
        string sql = "INSERT INTO PROD_SEPCIN_LOC_FIELD (FIELD_LOCATION, ID_WINDOW) VALUES (:FIELD_LOCATION, :ID_WINDOW)";
        return sql;
    }

    public static string updateLocationField()
    {
        string sql = "UPDATE PROD_SEPCIN_LOC_FIELD SET FIELD_LOCATION = :FIELD_LOCATION, ID_WINDOW = :ID_WINDOW WHERE ID_FIELD_LOC = :ID_FIELD_LOC";

        return sql;
    }

    //**************** Field Activity Information ************************

    public static string getLocationFieldActivityInfo()
    {
        string sql = "SELECT ID_FIELD, ID_FIELD_LOC, ID_ACTIVITYINFO, STATUS FROM PROD_SEPCIN_LOC_F_ACTIVITYINFO";
        return sql;
    }

    public static string getLocationFieldActivityInfoById()
    {
        string sql = "SELECT ID_FIELD, ID_FIELD_LOC, ID_ACTIVITYINFO, STATUS FROM PROD_SEPCIN_LOC_F_ACTIVITYINFO WHERE ID_FIELD = :ID_FIELD";
        return sql;
    }

    public static string getLocationFieldActivityInfoByActivityID()
    {
        string sql = "SELECT ID_FIELD, ID_FIELD_LOC, ID_ACTIVITYINFO, STATUS FROM PROD_SEPCIN_LOC_F_ACTIVITYINFO WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    public static string createLocationFieldActivityInfo()
    {
        string sql = "INSERT INTO PROD_SEPCIN_LOC_F_ACTIVITYINFO (ID_FIELD_LOC, ID_ACTIVITYINFO, STATUS) ";
        sql += "VALUES (:ID_FIELD_LOC, :ID_ACTIVITYINFO, :STATUS)";

        return sql;
    }

    public static string updateLocationFieldActivityInfo()
    {
        string sql = "UPDATE PROD_SEPCIN_LOC_F_ACTIVITYINFO SET STATUS = :STATUS WHERE (ID_FIELD_LOC = :ID_FIELD_LOC AND ID_ACTIVITYINFO = :ID_ACTIVITYINFO)";
        return sql;
    }

    public static string DeleteLocationFieldByActivity()
    {
        string sql = "DELETE FROM PROD_SEPCIN_LOC_F_ACTIVITYINFO WHERE ID_ACTIVITYINFO = :ID_ACTIVITYINFO";
        return sql;
    }

    //IAP Window

    public static string CreateIAPWindow()
    {
        string sql = "INSERT INTO PROD_SEPCIN_IAPWINDOW (WINDOW) VALUES (:WINDOW)";
        return sql;
    }

    public static string UpdateIAPWindow()
    {
        string sql = "UPDATE PROD_SEPCIN_IAPWINDOW SET WINDOW = :WINDOW WHERE ID_WINDOW = :ID_WINDOW";
        return sql;
    }

    public static string getIAPWindows()
    {
        string sql = "SELECT ID_WINDOW, WINDOW FROM PROD_SEPCIN_IAPWINDOW";
        return sql;
    }

    public static string getIAPWindowsById()
    {
        string sql = "SELECT ID_WINDOW, WINDOW FROM PROD_SEPCIN_IAPWINDOW WHERE ID_WINDOW = :ID_WINDOW";
        return sql;
    }

    #endregion

    public static string PECRequestPendingApproval()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, PROD_SEPCIN_ACTIVITYINFO.USERID, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, PROD_USERMGT.FULLNAME, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.COMPLETE FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_SEPCIN_ACTIVITYINFO.STATUS <> :STATUS ORDER BY ID_ACTIVITYINFO DESC";

        return sql;
    }

    public static string PECPendingApproval()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, PROD_SEPCIN_ACTIVITYINFO.USERID, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, PROD_SEPCIN_APPROVAL.ROLEID, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_SEPCIN_APPROVAL.ID_APPROVAL, PROD_USERMGT.FULLNAME, PROD_SEPCIN_APPROVAL.DATE_RECEIVED, ";
        sql += "PROD_SEPCIN_APPROVAL.DATE_REVIEWED, PROD_SEPCIN_APPROVAL.STAND, PROD_SEPCIN_APPROVAL.COMMENTS, PROD_SEPCIN_ACTIVITYINFO.COMPLETE ";
        sql += "FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_SEPCIN_APPROVAL ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO = PROD_SEPCIN_APPROVAL.ID_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_SEPCIN_APPROVAL.STAND = :STAND) AND (PROD_SEPCIN_ACTIVITYINFO.STATUS = :STATUS) AND (PROD_SEPCIN_APPROVAL.USERID = :USERID) ORDER BY ID_ACTIVITYINFO DESC";

        return sql;
    }

    public static string MyPECRequestPendingApproval()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, PROD_SEPCIN_ACTIVITYINFO.USERID, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, PROD_SEPCIN_APPROVAL.ROLEID, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_SEPCIN_APPROVAL.ID_APPROVAL, PROD_USERMGT.FULLNAME, PROD_SEPCIN_APPROVAL.DATE_RECEIVED, ";
        sql += "PROD_SEPCIN_APPROVAL.DATE_REVIEWED, PROD_SEPCIN_APPROVAL.STAND, PROD_SEPCIN_APPROVAL.COMMENTS, PROD_SEPCIN_ACTIVITYINFO.COMPLETE ";
        sql += "FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_SEPCIN_APPROVAL ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO = PROD_SEPCIN_APPROVAL.ID_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (PROD_SEPCIN_APPROVAL.STAND = :STAND) AND (PROD_SEPCIN_ACTIVITYINFO.STATUS = :STATUS) AND (PROD_SEPCIN_APPROVAL.USERID = :USERID) ORDER BY ID_ACTIVITYINFO DESC";

        return sql;
    }

    public static string getMyApprovedPECs()
    {
        //string sql = "SELECT * FROM PROD_SEPCIN_ACTIVITYINFO WHERE STATUS = :iStatus AND USERID = :iUserId";

        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, PROD_SEPCIN_ACTIVITYINFO.USERID, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_SEPCIN_ACTIVITYINFO.COMPLETE ";
        sql += "FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_SEPCIN_ACTIVITYINFO.STATUS = :iStatus AND PROD_USERMGT.USERID = :iUserId";


        return sql;
    }

    public static string ApprovedPECRequests()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, PROD_SEPCIN_ACTIVITYINFO.USERID, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_SEPCIN_ACTIVITYINFO.COMPLETE ";
        sql += "FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_SEPCIN_ACTIVITYINFO.STATUS = :STATUS";

        return sql;
    }

    public static string ApprovedPECRequestByRequestNumber()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, PROD_SEPCIN_ACTIVITYINFO.USERID, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_SEPCIN_ACTIVITYINFO.COMPLETE ";
        sql += "FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE (UPPER(PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID) = UPPER(:sRequestNumber))";

        return sql;
    }


    public static string PECApproved()
    {
        string sql = "SELECT PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO, PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE, PROD_SEPCIN_ACTIVITY_TYPE.ACTIVITY_TYPE, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYDESCRIPTION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.JUSTIFICATION, PROD_SEPCIN_ACTIVITYINFO.USERID, PROD_SEPCIN_ACTIVITYINFO.ACTIVITYID, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.STATUS, TO_CHAR(PROD_SEPCIN_ACTIVITYINFO.DATE_SUMBITTED, 'DD/MM/YYYY') AS DATE_SUMBITTED, PROD_SEPCIN_ACTIVITYINFO.FUNCTION_LOCATION, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.NO_BEDS, PROD_SEPCIN_APPROVAL.ROLEID, PROD_SEPCIN_ACTIVITYINFO.FIRST_NIGHT, ";
        sql += "PROD_SEPCIN_ACTIVITYINFO.LAST_NIGHT, PROD_SEPCIN_ACTIVITYINFO.ACTIVITY_CAUSE_OIL_DEFRMNT, PROD_SEPCIN_ACTIVITYINFO.VOLUME, ";
        sql += "PROD_SEPCIN_APPROVAL.ID_APPROVAL, PROD_USERMGT.FULLNAME, PROD_SEPCIN_APPROVAL.DATE_RECEIVED, ";
        sql += "PROD_SEPCIN_APPROVAL.DATE_REVIEWED, PROD_SEPCIN_APPROVAL.STAND, PROD_SEPCIN_APPROVAL.COMMENTS, PROD_SEPCIN_ACTIVITYINFO.COMPLETE ";
        sql += "FROM PROD_SEPCIN_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_SEPCIN_ACTIVITY_TYPE ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITY_TYPE = PROD_SEPCIN_ACTIVITY_TYPE.ID_ACTIVITY_TYPE ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_SEPCIN_ACTIVITYINFO.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_SEPCIN_APPROVAL ON PROD_SEPCIN_ACTIVITYINFO.ID_ACTIVITYINFO = PROD_SEPCIN_APPROVAL.ID_ACTIVITYINFO ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_SEPCIN_ACTIVITYINFO.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_SEPCIN_APPROVAL.STAND = :STAND AND PROD_SEPCIN_APPROVAL.USERID = :USERID";
        //sql += "WHERE PROD_SEPCIN_APPROVAL.STAND = :STAND AND PROD_SEPCIN_APPROVAL.USERID = :USERID AND PROD_SEPCIN_APPROVAL.ROLEID = :ROLEID";

        return sql;
    }

    public static string getPECApprovalByApprover()
    {
        string sql = "SELECT ID_APPROVAL, ID_ACTIVITYINFO, USERID, TO_CHAR(DATE_RECEIVED, 'DD/MM/YYYY') AS DATE_RECEIVED, ";
        sql += "STAND, ROLEID, TO_CHAR(DATE_REVIEWED, 'DD/MM/YYYY') AS DATE_REVIEWED, COMMENTS FROM PROD_SEPCIN_APPROVAL ";
        sql += "WHERE (ID_ACTIVITYINFO = :ID_ACTIVITYINFO) AND (ID_APPROVAL = :ID_APPROVAL) AND (USERID = :USERID)";
        return sql;
    }

    #endregion    ************************ PEC Request Form Queries Start ************************************

    public static string fieldVisitRequestsApprovedByFacility()
    {
        string sql = "SELECT DISTINCT PROD_SUPERINTENDENT.ID_SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT, PROD_SUPERINTENDENT.SUPERINTENDENT_EMAIL, PROD_DISTRICT.DISTRICT, ";
        sql += "PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, PROD_ACTIVITIES.ID_ACTIVITIES, PROD_ACTIVITIES.TASK_DESCRIPTION, PROD_ACTIVITIES.USERID, ";
        sql += "PROD_USERMGT.FULLNAME, PROD_ACTIVITIES.STATUS, PROD_ACTIVITIES.ACTIVITYID, ";
        sql += "TO_CHAR(PROD_ACTIVITIES.DATE_FROM, 'DD/MM/YYYY') AS DATE_FROM, TO_CHAR(PROD_ACTIVITIES.DATE_TO, 'DD/MM/YYYY') AS DATE_TO, ";
        sql += "PROD_ACTIVITIES.GENERAL_COMMENT, PROD_ACTIVITIES.ACCOUNT ";
        sql += "FROM PROD_ACTIVITIES ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_ACTIVITIES.ID_FACILITIES = PROD_FACILITIES.ID_FACILITIES ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_FACILITIES.ID_DISTRICT = PROD_DISTRICT.ID_DISTRICT ";
        sql += "INNER JOIN PROD_SUPERINTENDENT ON PROD_DISTRICT.ID_SUPERINTENDENT = PROD_SUPERINTENDENT.ID_SUPERINTENDENT ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_ACTIVITIES.USERID = PROD_USERMGT.USERID ";
        sql += "WHERE PROD_ACTIVITIES.STATUS = :STATUS AND PROD_FACILITIES.ID_FACILITIES = :ID_FACILITIES ORDER BY PROD_ACTIVITIES.ID_ACTIVITIES DESC";

        return sql;
    }

    #region ************************ RPI Verification Heat Map ************************************

    public static string getYearVerificationHeatMap()
    {
        //string sql = "SELECT DISTINCT TO_CHAR(TO_DATE(DATESUBMITTED, 'DD-MON-YY'), 'YYYY') AS YYEAR FROM PROD_VERIFICATION";
        string sql = "SELECT DISTINCT IYEAR FROM PROD_VERIFICATION";
        return sql;
    }

    public static string getVerification()
    {
        string sql = "SELECT DISTINCT IYEAR, IMONTH FROM PROD_VERIFICATION ORDER BY IYEAR DESC";
        return sql;
    }

    public static string getVerificationHeatMapByMonthYear()
    {
        string sql = "SELECT PROD_ASSET.IDASSET, PROD_ASSET.ASSETS, PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, ";
        sql += "PROD_VERIFICATION.IDVERIFICATION, PROD_VERIFICATION.STANDARDIZED_WORK, PROD_VERIFICATION.GO_SEE, PROD_VERIFICATION.STRUCTURED_DAY, ";
        sql += "PROD_VERIFICATION.MTCE_CONSUMABLES, PROD_VERIFICATION.IMONTH, PROD_VERIFICATION.IYEAR, PROD_VERIFICATION.DATESUBMITTED, PROD_USERMGT.USERID, ";
        sql += "PROD_USERMGT.FULLNAME FROM PROD_ASSET ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_DISTRICT.IDASSET = PROD_ASSET.IDASSET ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "INNER JOIN PROD_VERIFICATION ON PROD_FACILITIES.ID_FACILITIES = PROD_VERIFICATION.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = PROD_VERIFICATION.USERID WHERE (PROD_VERIFICATION.IMONTH = :iMonth) AND (PROD_VERIFICATION.IYEAR = :iYear) ORDER BY PROD_DISTRICT.DISTRICT";

        return sql;
    }

    public static string getVerificationHeatMapByMonthYearAsset()
    {
        string sql = "SELECT PROD_ASSET.IDASSET, PROD_ASSET.ASSETS, PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, ";
        sql += "PROD_VERIFICATION.IDVERIFICATION, PROD_VERIFICATION.STANDARDIZED_WORK, PROD_VERIFICATION.GO_SEE, PROD_VERIFICATION.STRUCTURED_DAY, ";
        sql += "PROD_VERIFICATION.MTCE_CONSUMABLES, PROD_VERIFICATION.IMONTH, PROD_VERIFICATION.IYEAR, PROD_VERIFICATION.DATESUBMITTED, PROD_USERMGT.USERID, ";
        sql += "PROD_USERMGT.FULLNAME FROM PROD_ASSET ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_DISTRICT.IDASSET = PROD_ASSET.IDASSET ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "INNER JOIN PROD_VERIFICATION ON PROD_FACILITIES.ID_FACILITIES = PROD_VERIFICATION.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = PROD_VERIFICATION.USERID WHERE (PROD_VERIFICATION.IMONTH = :iMonth) ";
        sql += "AND (PROD_VERIFICATION.IYEAR = :iYear) AND (PROD_ASSET.IDASSET = :iAssetId) ORDER BY PROD_DISTRICT.DISTRICT";

        return sql;
    }

    public static string getVerificationHeatMapByFacilityMonthYear()
    {
        string sql = "SELECT PROD_ASSET.IDASSET, PROD_ASSET.ASSETS, PROD_DISTRICT.DISTRICT, PROD_FACILITIES.ID_FACILITIES, PROD_FACILITIES.FACILITIES, ";
        sql += "PROD_VERIFICATION.IDVERIFICATION, PROD_VERIFICATION.STANDARDIZED_WORK, PROD_VERIFICATION.GO_SEE, PROD_VERIFICATION.STRUCTURED_DAY, ";
        sql += "PROD_VERIFICATION.MTCE_CONSUMABLES, PROD_VERIFICATION.IMONTH, PROD_VERIFICATION.IYEAR, PROD_VERIFICATION.DATESUBMITTED, PROD_USERMGT.USERID, ";
        sql += "PROD_USERMGT.FULLNAME FROM PROD_ASSET ";
        sql += "INNER JOIN PROD_DISTRICT ON PROD_DISTRICT.IDASSET = PROD_ASSET.IDASSET ";
        sql += "INNER JOIN PROD_FACILITIES ON PROD_DISTRICT.ID_DISTRICT = PROD_FACILITIES.ID_DISTRICT ";
        sql += "INNER JOIN PROD_VERIFICATION ON PROD_FACILITIES.ID_FACILITIES = PROD_VERIFICATION.ID_FACILITIES ";
        sql += "INNER JOIN PROD_USERMGT ON PROD_USERMGT.USERID = PROD_VERIFICATION.USERID ";
        sql += "WHERE (PROD_VERIFICATION.IMONTH = :iMonth) AND (PROD_VERIFICATION.IYEAR = :iYear) AND (PROD_VERIFICATION.ID_FACILITIES = :iFacility)";

        return sql;
    }

    public static string insertVerification()
    {
        string sql = "INSERT INTO PROD_VERIFICATION (ID_FACILITIES, STANDARDIZED_WORK, GO_SEE, STRUCTURED_DAY, MTCE_CONSUMABLES, IMONTH, IYEAR, USERID, DATESUBMITTED) ";
        sql += "VALUES (:iFacilityId, :iStandardisedWork, :iGoSee, :iStructuredDay, :iMtceConsumables, :iMonth, :iYear, :iUserId, :sDateSubmitted)";
        return sql;
    }

    public static string UpdateVerification()
    {
        string sql = "UPDATE PROD_VERIFICATION SET ID_FACILITIES = :iFacilityId, STANDARDIZED_WORK = :iStandardisedWork, GO_SEE = :iGoSee, ";
        sql += "STRUCTURED_DAY = :iStructuredDay, MTCE_CONSUMABLES = :iMtceConsumables, IMONTH = :iMonth, IYEAR = :iYear, USERID = :iUserId, ";
        sql += "DATESUBMITTED = :sDateSubmitted WHERE IDVERIFICATION = :lIdVerification";
        return sql;
    }

    #endregion


    #region 

    public static string getMediaTypes()
    {
        string sql = "SELECT MEDIAID, MEDIA, EXTENSION FROM MIMETYPES";

        return sql;
    }

    public static string getMediaTypeByMedia()
    {
        string sql = "SELECT MEDIAID, MEDIA, EXTENSION FROM MIMETYPES WHERE MEDIA = :sMedia";

        return sql;
    }

    #endregion
}   