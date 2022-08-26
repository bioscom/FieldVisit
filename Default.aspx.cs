using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Web;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sRedirect = "";

        if (!IsPostBack)
        {
            string sMsg = "";
            string sRet = "";
            switch (sMsg)
            {
                case "sLO":
                    sRedirect = "~/Support/logout.aspx?Msg=sLO";
                    break;

                case "PecRes":
                    //ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have sufficient profile to access Field Visit/PEC. Contact the Administrator.");
                    Response.Redirect("~/Login.aspx");
                    break;

                case "PdccRes":
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have sufficient profile to access Production Cost Opportunity. Contact the Administrator.");
                    //Response.Redirect("~/Login.aspx");
                    break;

                case "FlrRes":
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have sufficient profile to access Flare Waiver. Contact the Administrator.");
                    break;

                case "sTl":
                    sRet = UseWindowsAuth();
                    if (sRet != "")
                    {
                        sRedirect = "~/Support/pageDenied.aspx?Msg=" + sRet;
                    }
                    break;

                default:
                    sRet = UseWindowsAuth();

                    if (sRet == "Relogin")
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    //else if (!string.IsNullOrEmpty(sRet))
                    //{
                    //    sRedirect = "~/Support/pageDenied.aspx?Msg=" + sRet;
                    //}

                    else if (Request.QueryString["xMod"] != null) //Initiative Management Framework
                    {
                        if (Request.QueryString["xMod"].ToString() == "Viw")
                        {
                            long lInitiativeId = long.Parse(Request.QueryString["IntiativeId"].ToString());
                            sRedirect = "~/App/ManHour/taskPage.aspx?xMod=Viw&IntiativeId=" + lInitiativeId;
                        }
                    }

                    else if (Request.QueryString["xApproveBI"] != null) //Bright Ideas Rgistration Portal
                    {
                        if (Request.QueryString["xApproveBI"].ToString() == "Yes")
                        {
                            sRedirect = "~/App/BI500/ApprovalReview.aspx";
                        }
                    }
                    else if (Request.QueryString["BI"] != null) //BI approval process
                    {
                        if (int.Parse(Request.QueryString["BI"].ToString()) == (int)AppTokens.appTokens.BI500)
                        {
                            if (!string.IsNullOrEmpty(Request.QueryString["RequestId"]))
                            {
                                long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                                sRedirect = "~/App/BI500/BIApprovalProc.aspx?RequestId=" + lRequestId;
                            }
                            else
                            {
                                sRedirect = "~/App/BI500/NewBizIntel.aspx";
                            }
                        }
                    }
                    else if (Request.QueryString["CR"] != null) //Cost Reduction approval process
                    {
                        if (int.Parse(Request.QueryString["CR"].ToString()) == (int)AppTokens.appTokens.BI500)
                        {
                            if (!string.IsNullOrEmpty(Request.QueryString["RequestId"]))
                            {
                                long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                                sRedirect = "~/App/BI500/CostReductionForMyAction.aspx?RequestId=" + lRequestId;
                            }
                            else
                            {
                                sRedirect = "~/App/BI500/CostReductionIdea.aspx";
                            }
                        }
                    }

                    else if (Request.QueryString["App"] != null) //Lean Project Portal
                    {
                        string see = Request.QueryString["App"].ToString();
                        //if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.lean)
                        if (Request.QueryString["App"].ToString() == AppTokens.AppDesc((AppTokens.appTokens)AppTokens.appTokens.lean))
                        {
                            if (sRet == "NotFound") sRedirect = "~/App/Lean/CIDashBoard.aspx";//Lean Project Portal CI Dashboard
                            else sRedirect = "~/App/Lean/Default.aspx";
                        }
                    }

                    else if (Request.QueryString["flr"] != null) //Flare Waiver approval
                    {
                        if (int.Parse(Request.QueryString["flr"].ToString()) == (int)AppTokens.appTokens.FlareWaiver)
                        {
                            long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                            sRedirect = "~/App/FlareWaiver/FlareApprovalProc.aspx?RequestId=" + lRequestId;
                        }
                    }

                    else if (Request.QueryString["pec"] != null) //PEC approval
                    {
                        if (int.Parse(Request.QueryString["pec"].ToString()) == (int)AppTokens.appTokens.pec)
                        {
                            long lActivityId = long.Parse(Request.QueryString["lActivityId"].ToString());
                            sRedirect = "~/App/FieldVisit/Forms/PEC/Approval/Pending.aspx?lActivityId=" + lActivityId;
                        }
                    }
                    else if (Request.QueryString["pdcc"] != null) //PEC approval
                    {
                        if (int.Parse(Request.QueryString["pdcc"]) == (int)AppTokens.appTokens.pdcc)
                        {
                            int iDeptId = int.Parse(Request.QueryString["iDeptId"].ToString());
                            sRedirect = "~/App/PDCC/OpportunityCostsChallenges.aspx?iDeptId=" + iDeptId;
                        }
                    }
                    else if (Request.QueryString["pr"] != null) //Price Red Flag
                    {
                        if (int.Parse(Request.QueryString["pr"].ToString()) == (int)AppTokens.appTokens.prices)
                        {
                            sRedirect = "~/App/Prices/Default.aspx";
                        }
                    }
                    else if(Request.QueryString["Id"] == "Analyst")
                    {
                        sRedirect = "~/App/IDD/Analyst.aspx";
                    }
                    else if (Request.QueryString["Id"] == "Idd")
                    {
                        sRedirect = "~/App/IDD/Default.aspx";
                    }
                    else if (sRet == "NotFound")
                    {
                        Response.Redirect("~/Index.aspx?iFnd=NotFound");
                        //Response.Redirect("~/taskPage.aspx");
                        //Response.Redirect("~/Login.aspx"); //Old
                    }
                    else
                    {
                        Response.Redirect("~/Index.aspx");
                    }

                    break;
            }
        }

        if (sRedirect != "")
        {
            Response.Redirect(sRedirect);
        }
    }

    private string UseWindowsAuth()
    {
        //Note: User Authentication, in this portal, is based on the application the user wants to log into.
        //Tokenes are used from the URL of the application to know where the user wants to go.
        //Where string sToken determines where the user is going
        //"Lean" for Lean Projects Management application

        string sRet = "Err";
        try
        {
            loginUser oLogin = new loginUser();
            loginUser.loginRet o = oLogin.verifyAppUser();

            //Note: loginRet, a member of the loginUser Class, returns three objects; statusx, eAppUserInfo and eIWHUserInfo
            //User to be authenticated could be found on eAppUserInfo or eIWHUserInfo object, 
            //therefore test eAppUserInfo and eIWHUserInfo to see where login user is found.

            if (o.eStatus == loginUser.statusx.idIsNotFound)
            {
                //if status is not found, the user does not exist any where. Then present the login page to the user.
                sRet = "NotFound";
            }
            else
            {
                if (o.eAppUserInfo != null)
                {
                    sRet = LogMeIn(o, sRet);
                }
                else if (o.eAppUserInfo == null)
                {
                    if (o.eIWHUserInfo != null)
                    {
                        //If the above condition is true, automatically register this user in the corresponding user's table based on the application Login Token
                        //Call the funtion or method that registers user from the add user page
                        int iUserId = 0;
                        bool bRet = false;

                        appUsers oAppUser = new appUsers
                        {
                            m_iRoleIdFieldVisit = (int) appUsersRoles.userRole.initiator,
                            m_iRoleIdBI = (int) appUsersRolesBI500.userRole.initiator,
                            m_iRoleIdFlr = (int) appUserRolesFlrWaiver.userRole.Initiator,
                            m_iRoleIdLean = (int) appUsersLeanRoles.userRole.User,
                            m_iRoleIdManHr = (int) appUsersRoles.userRole.initiator,
                            m_iRolePdcc = (int) AppUsersPdccRoles.UserRole.User,
                            m_iRoleIdContract = null,
                            m_sFullName = o.eIWHUserInfo.m_sFullName,
                            m_sRefInd = o.eIWHUserInfo.m_sRefInd,
                            m_sUserMail = o.eIWHUserInfo.m_sUserMail,
                            m_sUserName = o.eIWHUserInfo.m_sUserName
                        };

                        bRet = appUsersHelper.CreateUserAccount(oAppUser, ref iUserId);
                        if (bRet)
                        {
                            ajaxWebExtension.showJscriptAlert(Page, this, "Welcome, in case you need to change your profile, please call support.");

                            //TODO:    Revisit this place
                            //Relogin to recreate session
                            sRet = LogMeIn(o, sRet);
                        }
                    }
                    else if (o.eIWHUserInfo == null)
                    {
                        sRet = "NotFound";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    private string LogMeIn(loginUser.loginRet me, string sRet)
    {
        switch (me.eStatus)
        {
            case loginUser.statusx.loginSucceed:

                if (me.eAppUserInfo == null)
                {
                    FormsAuthentication.RedirectFromLoginPage(me.eIWHUserInfo.m_sUserName, true);
                    sRet = "Relogin";
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(me.eAppUserInfo.m_sUserName, true);
                    sRet = "";
                }

                break;
            case loginUser.statusx.idIsNotFound:
                sRet = "eId";
                break;
            case loginUser.statusx.loginFailed:
                sRet = "Err";
                break;
            case loginUser.statusx.statusDisabld:
                sRet = "nId";
                break;
            case loginUser.statusx.statusUnKnown:
                sRet = "nId";
                break;
            case loginUser.statusx.statusLocked:
                sRet = "lId";
                break;
        }
        return sRet;
    }
}