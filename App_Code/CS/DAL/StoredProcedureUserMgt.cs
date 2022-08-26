namespace CS.DAL
{
    /// <summary>
    /// Summary description for StoredProcedureUserMgt
    /// </summary>
    public class StoredProcedureUserMgt
    {
        public StoredProcedureUserMgt()
        {
            
        }

        #region ********************* USER Management *********************

        private static string getUserT()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, ROLEIDPDCC, LASTVISIT ";
            return sql;
        }
        public static string getUserByEmailAddress()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND upper(EMAIL) = upper(:EMAIL)";
            return sql;
        }
        public static string searchUser()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT "; //WHERE ((upper(FULLNAME) LIKE upper(:sKEY)) OR (upper(USERNAME) LIKE upper(:sKEY))) AND (STATUS = :iStatus)";
            return sql;      
        }
        public static string getApproversByRole()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEID = :iRoleId ORDER BY FULLNAME";
            return sql;
        }

        public static string GetInitMgtApproversByRole()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDMANHR = :iRoleId ORDER BY FULLNAME";
            return sql;
        }

        public static string getUsersByRole()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEID = :iRoleId ORDER BY FULLNAME";
            return sql;
        }
        public static string getBIUsersByRole()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDBI = :iRoleId ORDER BY FULLNAME";
            return sql;
        }
        public static string getUserAccountByGuidPswEx()
        {
            ///Summary
            ///Note: Please do not set the password here (PASSWORD = UPPER(:PASSWORD)) to UPPER,the password to be reset is case sensitive. Thanks.
            /// October 15, 2014 code review
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE (PASSWORD = :PASSWORD) AND (STATUS = :STATUS)";
            return sql;
        }
        public static string getAllUsers()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus ORDER BY FULLNAME";
            return sql;
        }
        public static string getUsers()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus ORDER BY FULLNAME";
            //sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEID IS NOT NULL  ORDER BY FULLNAME";
            return sql;
        }

        public static string getUsers4AllApps()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus ORDER BY FULLNAME";
            return sql;
        }

        public static string getLoginUserAccountEx()
        {
            ///Summary
            ///Note: Please do not set the password here (PASSWORD = UPPER(:PASSWORD)) to UPPER,the password to be reset is case sensitive. Thanks.
            /// October 15, 2014 code review
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE (PASSWORD = :PASSWORD) AND (USERNAME = UPPER(:USERNAME)) AND (STATUS = :STATUS)";
            return sql;
        }
        public static string getSupportContact()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEID = :ROLEID AND DELIGATED = :DELIGATED";
            return sql;
        }
        public static string getManHrUserByRoleId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEIDMANHR = :ROLEID AND ROLEIDMANHR IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }
        public static string getContractUserByRoleId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEIDCONTRACT = :ROLEID AND ROLEIDCONTRACT IS NOT NULL";
            return sql;
        }
        public static string getFlareWaiverUserByRoleId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEIDFLR = :ROLEID AND ROLEIDFLR IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }
        public static string GetPdccUserByRoleId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEIDPDCC = :ROLEID AND ROLEIDPDCC IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }
        public static string getOnlineUser()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE lower(substr(EMAIL,1,instr(EMAIL,'@')-1)) = lower(:UserName)";
            return sql;
        }
        public static string getUserByUserId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND USERID = :iUserId";
            return sql;
        }
        public static string getUserByUserName()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE USERNAME = :UserName";
            return sql;
        }
        public static string getUserByName()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND upper(FULLNAME) LIKE(:sName) ORDER BY FULLNAME";
            return sql;
        }
        public static string getUsersByName()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :sStatus AND UPPER(USERNAME) = upper(:sName)";
            return sql;
        }
        public static string getUserByRoleId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEID = :ROLEID AND ROLEID IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }
        public static string getBIUserByRoleId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEIDBI = :ROLEID AND ROLEIDBI IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }


        public static string getLeanUserByRoleId()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDLEAN AS ROLEID, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEIDLEAN = :ROLEID AND ROLEIDLEAN IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }
        public static string getDeligatedUserByRoleId()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEIDFLR AS ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, ROLEIDPDCC, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE (ROLEIDFLR = :iRoleId) AND (STATUS = :iStatus) AND (DELIGATED = :iDeligated)";
            return sql;
        }

        public static string getDeligatedUserByRoleId2()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEIDFLR AS ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, ROLEIDPDCC, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE (ROLEIDFLR = :iRoleId) AND (STATUS = :iStatus)";
            return sql;
        }
        public static string getLeanUsers()
        {
            //string sql = "SELECT USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDLEAN IS NOT NULL ORDER BY FULLNAME";
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDLEAN AS ROLEID, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDLEAN IS NOT NULL ORDER BY FULLNAME";

            return sql;
        }

        public static string getBIUsers()
        {
            //string sql = "SELECT USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDBI IS NOT NULL ORDER BY FULLNAME";
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDBI AS ROLEID, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDBI IS NOT NULL ORDER BY FULLNAME";

            return sql;
        }

        public static string getManHrUsers()
        {
            //string sql = "SELECT USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDMANHR IS NOT NULL ORDER BY FULLNAME";
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDMANHR AS ROLEID, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDMANHR IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }

        public static string get14DayContractUsers()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDCONTRACT IS NOT NULL ORDER BY FULLNAME";
            return sql;

            //string sql = "SELECT USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDCONTRACT IS NOT NULL ORDER BY FULLNAME";
            //string sql = "SELECT USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDCONTRACT AS ROLEID ";
            //sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDCONTRACT IS NOT NULL ORDER BY FULLNAME";
            //return sql;
        }

        public static string get14DayContractUsersByRoleId()
        {
            string sql = getUserT();
            sql += "FROM PROD_USERMGT WHERE STATUS = :STATUS AND ROLEIDCONTRACT = :ROLEID AND ROLEIDCONTRACT IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }

        public static string getFlareWaiverUsers()
        {
            //string sql = "SELECT USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDFLR IS NOT NULL ORDER BY FULLNAME";
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDFLR AS ROLEID, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDFLR IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }
        public static string GetPdccUsers()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDPDCC AS ROLEID, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDPDCC IS NOT NULL ORDER BY FULLNAME";
            return sql;
        }

       

        public static string getFlrWaiverUsersByRole()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDFLR AS ROLEID, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDFLR = :iRoleId ORDER BY FULLNAME";
            return sql;
        }

        public static string getLeanUsersByRole()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDLEAN AS ROLEID, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDLEAN  = :iRoleId ORDER BY FULLNAME";
            //string sql = "SELECT USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDLEAN AS ROLEID FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEIDLEAN  = :iRoleId ORDER BY FULLNAME";
            return sql;
        }

        public static string getFocalPointUsers()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, DELIGATED, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, LASTVISIT ";
            sql += "FROM PROD_USERMGT WHERE STATUS = :iStatus AND ROLEID = :iRoleId ORDER BY FULLNAME";
            return sql;
        }


        public static string searchLeanUser()
        {
            string sql = "SELECT USERID, COSTSAVINGABSVAL, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, PASSWORD, DELIGATED, ROLEIDLEAN AS ROLEID, LASTVISIT FROM PROD_USERMGT ";
            sql += "WHERE (upper(FULLNAME) LIKE upper(:SEARCHKEY) OR upper(USERNAME) LIKE upper(:SEARCHKEY)) AND STATUS = :sStatus";

            return sql;
        }

       

        public static string RouteRequestToNewDeligate()
        {
            string sql = "UPDATE FLARE_APPROVAL SET FLARE_APPROVAL.IDUSER = :iUserId WHERE (FLARE_APPROVAL.IDROLE = :iRoleId) ";
            sql += "AND FLARE_APPROVAL.IDREQUEST IN (SELECT FLARE_REQUEST.IDREQUEST FROM FLARE_REQUEST WHERE FLARE_REQUEST.STATUS <> :iStatus)";
            return sql;
        }

        public static string DeleteUserProfile()
        {
            string sql = "UPDATE PROD_USERMGT SET STATUS = :iStatus WHERE USERID = :iUserid";

            return sql;
        }

        public static string CreateUserAccount()
        {
            string sql = "INSERT INTO PROD_USERMGT (USERID, USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, ROLEIDPDCC) ";
            sql += "VALUES (:IDUSER, :USERNAME, :STATUS, :FULLNAME, :EMAIL, :REFIND, :ROLEID, :ROLEIDLEAN, :ROLEIDBI, :ROLEIDMANHR, :ROLEIDCONTRACT, :ROLEIDFLR, :ROLEIDPDCC)";
            return sql;
        }

        public static string CreateUserAccountEx()
        {
            string sql = "INSERT INTO PROD_USERMGT (USERNAME, STATUS, FULLNAME, EMAIL, REFIND, ROLEID, PASSWORD, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, ROLEIDPDCC) ";
            sql += "VALUES (:USERNAME, :STATUS, :FULLNAME, :EMAIL, :REFIND, :ROLEID, :PASSWORD, :ROLEIDLEAN, :ROLEIDBI, :ROLEIDMANHR, :ROLEIDCONTRACT, :ROLEIDFLR, :ROLEIDPDCC)";
            return sql;
        }

        public static string updateUserAccountPswEx()
        {
            string sql = "UPDATE PROD_USERMGT SET PASSWORD = :PASSWORD WHERE (UPPER(EMAIL) = UPPER(:EMAIL)) AND (STATUS = :STATUS)";
            //string sql = "UPDATE PROD_USERMGT SET PASSWORD = :PASSWORD WHERE (EMAIL = UPPER(:EMAIL)) AND (STATUS = :STATUS)";
            return sql;
        }


        #region Update individual User account role in each application
        //Update 

        //ROLEID, ROLEIDLEAN, ROLEIDBI, ROLEIDMANHR, ROLEIDCONTRACT, ROLEIDFLR, ROLEIDPDCC

        public static string UpdateUser4AllApps()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEID = :ROLEID, ROLEIDLEAN = :ROLEIDLEAN, ROLEIDBI = :ROLEIDBI, ";
            sql += "ROLEIDMANHR = :ROLEIDMANHR, ROLEIDFLR = :ROLEIDFLR, ROLEIDPDCC = :ROLEIDPDCC WHERE USERID = :USERID";
            return sql;
        }

        public static string UpdateUser()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEID = :ROLEID WHERE USERID = :USERID";
            return sql;
        }

        public static string updateLeanUser()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEIDLEAN = :ROLEID WHERE USERID = :USERID";
            return sql;
        }

        public static string updateBIUser()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEIDBI = :ROLEID WHERE USERID = :USERID";
            return sql;
        }

        public static string updateFlrWaiverUser()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEIDFLR = :ROLEID WHERE USERID = :USERID";
            return sql;
        }

        public static string update14DayContractUser()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEIDCONTRACT = :ROLEID WHERE USERID = :USERID";
            return sql;
        }

        public static string updateManHrUser()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEIDMANHR = :ROLEID WHERE USERID = :USERID";
            return sql;
        }
        public static string UpdatePdccUser()
        {
            string sql = "UPDATE PROD_USERMGT SET ROLEIDPDCC = :ROLEID WHERE USERID = :USERID";
            return sql;
        }

        #endregion

        public static string disableUserAccount()
        {
            string sql = "UPDATE PROD_USERMGT SET STATUS = :STATUS WHERE USERID = :USERID";
            return sql;
        }

        public static string EnableCostSavingAbsoluteValuesRight()
        {
            string sql = "UPDATE PROD_USERMGT SET COSTSAVINGABSVAL = :COSTSAVINGABSVAL WHERE USERID = :USERID";
            return sql;
        }

        public static string MakeDeligate()
        {
            //TODO: note there is need to ensure which application's deligate is refered to. This is important, bcos it means ones a user is made a deligate, he can function as deligate for other applications
            //There is a need to separate this in the future. I recommend individual column for deligate field for each application, just like each application has roleid.
            //(October 15, 2014 code review)

            string sql = "UPDATE PROD_USERMGT SET DELIGATED = :iDeligated WHERE USERID = :iUserId";
            return sql;
        }

        //New update: Added on 23, May 2016
        public static string UpdateLastLogin()
        {
            string sql = "UPDATE PROD_USERMGT SET LASTVISIT = :dtLastVisit WHERE USERID = :iUserId";
            return sql;
        }

        #endregion

        #region************************** Staff Details from Information Ware House *******************

        public static string getUserByDomainLoginID()
        {
            //TODO: Possible SQL Injection attack. 
            string sql = "SELECT SURNAME, FIRST_NAME, FULL_NAME, REF_IND, JOB_POSITION, JOB_TITLE, USERNAME, EMAIL FROM " + AppConfiguration.informationWareHouse;
            sql += " WHERE lower(substr(EMAIL,1,instr(EMAIL,'@')-1)) = lower(:sEmail)";

            return sql;
        }

        public static string CompleteStafDetailsByName()
        {
            //TODO: Possible SQL Injection attack. 
            string sql = "SELECT SURNAME, FIRST_NAME, FULL_NAME, REF_IND, JOB_POSITION, JOB_TITLE, USERNAME, EMAIL FROM " + AppConfiguration.informationWareHouse;
            sql += " WHERE (upper(SURNAME) LIKE :SURNAME) OR (upper(FIRST_NAME) LIKE :SURNAME) AND USERNAME IS NOT NULL";

            return sql;
        }

        public static string getUserFromCompleteStaffDetailsByUserName()
        {
            //TODO: Possible SQL Injection attack. 
            string sql = "SELECT SURNAME, FIRST_NAME, FULL_NAME, REF_IND, JOB_POSITION, JOB_TITLE, USERNAME, EMAIL FROM " + AppConfiguration.informationWareHouse;
            sql += " WHERE upper(USERNAME) = :USERNAME";
            return sql;
        }

        public static string CompleteStafDetailsByStaffNumber()
        {
            //TODO: Possible SQL Injection attack. 
            string sql = "SELECT SURNAME, FIRST_NAME, FULL_NAME, REF_IND, JOB_POSITION, JOB_TITLE, USERNAME, EMAIL FROM " + AppConfiguration.informationWareHouse;
            sql += " WHERE upper(STAFF_NUMBER) = :STAFF_NUMBER";
            return sql;
        }

        #endregion

    }
}