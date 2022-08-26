using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AppGatePass : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sAppToken = "";

        if (!string.IsNullOrEmpty(Request.QueryString["sAppToken"]))
        {
            sAppToken = Request.QueryString["sAppToken"].ToString();
        }

        if (oSessnx.getOnlineUser.m_iUserId != 0)
        {
            if (AppTokens.AppDesc(AppTokens.appTokens.pec) == sAppToken)
            {
                if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit != null) && (oSessnx.getOnlineUser.m_iRoleIdFieldVisit != 0)) Response.Redirect("~/App/FieldVisit/taskPage.aspx");
                else Response.Redirect("~/Default.aspx?PecRes");
            }
            else if (AppTokens.AppDesc(AppTokens.appTokens.pdcc) == sAppToken) 
            {
                if ((oSessnx.getOnlineUser.m_iRolePdcc != null) || (oSessnx.getOnlineUser.m_iRolePdcc != 0)) Response.Redirect("~/App/PDCC/Default.aspx");
                else Response.Redirect("~/Default.aspx?PdccRes");
            }
            else if (AppTokens.AppDesc(AppTokens.appTokens.FlareWaiver) == sAppToken)
            {
                if ((oSessnx.getOnlineUser.m_iRoleIdFlr != null) || (oSessnx.getOnlineUser.m_iRoleIdFlr != 0)) Response.Redirect("~/App/FlareWaiver/taskPage.aspx");
                else Response.Redirect("~/Default.aspx?FlrRes");
            }

            else if (AppTokens.AppDesc(AppTokens.appTokens.FourteenDayContract) == sAppToken) Response.Redirect("~/App/Contract/Default.aspx");
            else if (AppTokens.AppDesc(AppTokens.appTokens.PDR) == sAppToken) Response.Redirect("~/App/PDR/MainForm.aspx");
            else if (AppTokens.AppDesc(AppTokens.appTokens.initiativeMgt) == sAppToken) Response.Redirect("~/App/ManHour/taskPage.aspx");

            else if (AppTokens.AppDesc(AppTokens.appTokens.BI500) == sAppToken) Response.Redirect("~/App/BI500/Default.aspx");
            else if (AppTokens.AppDesc(AppTokens.appTokens.lean) == sAppToken) Response.Redirect("~/App/Lean/Default.aspx");
            else if (AppTokens.AppDesc(AppTokens.appTokens.prices) == sAppToken) Response.Redirect("~/App/Prices/Default.aspx");
        }
        else
        {
            //C4C Users
            Response.Redirect("~/Login.aspx");
            //if (AppTokens.AppDesc(AppTokens.appTokens.pec) == sAppToken)
            //{
            //    //C4C Users
            //    Response.Redirect("~/Login.aspx");
            //    //if ((oSessnx.getOnlineUser.m_iRoleIdFieldVisit != null) && (oSessnx.getOnlineUser.m_iRoleIdFieldVisit != 0)) Response.Redirect("~/App/FieldVisit/taskPage.aspx");
            //    //else Response.Redirect("~/Default.aspx?PecRes");
            //}
            //else if (AppTokens.AppDesc(AppTokens.appTokens.BI500) == sAppToken) Response.Redirect("~/App/BI500/Default.aspx");
        }
    }
}