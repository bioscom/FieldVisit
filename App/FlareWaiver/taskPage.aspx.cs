using System;

public partial class taskPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO: This application is open to everybody.
        //When a new person logs in, it should check the Local (Native) user's table,
        //If not found and the user is a GID user, look up to the IWH to fetch User information and 
        //call the class for creating user in the application to register the user as an Initator.

        //The Administrator can later re define the role.

        //TODO: if the user is a C4C user, give him the page to logon, if never logon click here to register.


        Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");

        //if ((oSessnx.getOnlineUser.m_iRoleIdFlr == (int)UserRoles.userRole.Administrator) || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)UserRoles.userRole.Business_Process_Owner))
        //{
        //    Response.Redirect("~/FlarePendingRequest.aspx");
        //}
        //else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)UserRoles.userRole.Initiator)
        //{
        //    Response.Redirect("~/CTRInitiator/MyCTRs.aspx");
        //}
        //else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)UserRoles.userRole.ContractAnalyst)
        //{
        //    Response.Redirect("~/xSapLnk.aspx");
        //}
        //else 
        //{
        //    Response.Redirect("~/Common/Approval.aspx");
        //}
    }
}
