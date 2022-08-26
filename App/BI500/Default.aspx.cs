using System;

public partial class BI500_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if ((oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.admin) || (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.CorporateViewer))
        //{
        //    Response.Redirect("~/App/BI500/AllBrightIdeas.aspx");
        //}
        //else if (oSessnx.getOnlineUser.m_iRoleIdBI == (int)appUsersRolesBI500.userRole.focalPoint)
        //{
        //    Response.Redirect("~/App/BI500/ApprovalReview.aspx");
        //}
        //else
        //{
        //    Response.Redirect("~/App/BI500/MyBrightIdeas.aspx");
        //}

        Response.Redirect("~/App/BI500/NewBizIntel.aspx");
    }
}