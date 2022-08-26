using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_Default : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((oSessnx.getOnlineUser.m_iRolePdcc == null) || (oSessnx.getOnlineUser.m_iRolePdcc == 0))
        {
            //adminMenu1.Visible = false; //.InitMenu();
            //Response.Redirect("~/Support/pageDenied.aspx?Msg=");
            ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, you do not have any sufficient account to use Production Cost Agenda. Please contact the Administrator.");
        }
        else
        {
            Response.Redirect("~/App/PDCC/OpportunityCostsChallenges.aspx");
        }


        
        //if(oSessnx.getOnlineUser.m_iRolePdcc == (int)AppUsersPdccRoles.UserRole.User)
        //{
        //    Response.Redirect("~/App/PDCC/OpportunityCostsChallenges.aspx");
        //}
        //else
        //{
        //    Response.Redirect("~/App/PDCC/cReport.aspx");
        //}
    }
}