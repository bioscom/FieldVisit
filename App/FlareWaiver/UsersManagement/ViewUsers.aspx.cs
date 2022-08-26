using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UsersManagement_ViewUsers : aspnetPage
{
    //string CurrentSortExpression = "";
    //appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        string sToken = "";
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUserRolesFlrWaiver.userRole.Administrator.ToString() };
            appUserRolesFlrWaiver oAccess = new appUserRolesFlrWaiver();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUserRolesFlrWaiver.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFlr);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }

        //if (oSessnx.getOnlineUser.m_iRoleIdFlr != (int)appUserRolesFlrWaiver.userRole.Initiator) sToken = "tAdmin";
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx?Msg=" + sToken);

        if (!IsPostBack)
        {
            ViewUsers1.InitPage((int)AppTokens.appTokens.FlareWaiver);
        }
    }


    private void UserRole()
    {
        try
        {
            //foreach (GridViewRow grdRow in UsersGridView.Rows)
            //{
            //    Label lblRole = (Label)grdRow.FindControl("labelUserRole");

            //    if (int.Parse(lblRole.Text) == (int)appUserRolesFlrWaiver.userRole.Administrator)
            //    {
            //        lblRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Administrator);
            //    }
            //    else if (int.Parse(lblRole.Text) == (int)appUserRolesFlrWaiver.userRole.GMProduction)
            //    {
            //        lblRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.GMProduction);
            //    }
            //    else if (int.Parse(lblRole.Text) == (int)appUserRolesFlrWaiver.userRole.Initiator)
            //    {
            //        lblRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Initiator);
            //    }
            //    else if (int.Parse(lblRole.Text) == (int)appUserRolesFlrWaiver.userRole.LineManager)
            //    {
            //        lblRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.LineManager);
            //    }
            //    else if (int.Parse(lblRole.Text) == (int)appUserRolesFlrWaiver.userRole.ProductionServicesManager)
            //    {
            //        lblRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.ProductionServicesManager);
            //    }
            //}
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void UsersGridView_Sorted(object sender, EventArgs e)
    {
        // Display the sort expression and sort direction.
        //SortInformationLabel.Text = "Sorted by " + HttpContext.Current.Session["SortExpression"] + " in " + UsersGridView.SortDirection.ToString() + " order.";
    }
    
    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
        UserRole();
    }
}
