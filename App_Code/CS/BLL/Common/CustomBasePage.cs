using System;
using System.Collections.Generic;
using System.Web;

public class CustomBasePage : aspnetPage
{
    public CustomBasePage()
    {

    }

    public void SessionExpires()
    {
        if (string.IsNullOrEmpty(oSessnx.getOnlineUser.m_iUserId.ToString()))
        {
            Response.Redirect("~/Index.aspx");
        }

        //
        //CurrentUser = new eipUsers(Apps.LoginIDNoDomain(User.Identity.Name));

        //CurrentUser = new eipUsers(Session["UserID"].ToString());

    }
}
