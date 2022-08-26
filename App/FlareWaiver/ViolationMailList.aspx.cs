using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;


public partial class App_FlareWaiver_ViolationMailList : System.Web.UI.Page
{
    string sortArgument = "FULLNAME";
    FlareViolationMailList v = new FlareViolationMailList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            RetrieveUsers();
        }
    }

    private void RetrieveUsers()
    {
        DataView dv = new DataView();

        dv = appUsersHelper.dtGetFlareWaiverUsers().DefaultView;
        dv.Sort = sortArgument;
        grdView.DataSource = dv;
        grdView.DataBind();

        changeValuesFlrWaiver();
        Checkers();

    }

    private void Checkers()
    {
        List<FlareViolationMailList> oM = v.lstViolationMailList();

        foreach (GridViewRow grd in grdView.Rows)
        {
            CheckBox chkUser = (CheckBox)grd.FindControl("chkUser");
            int iUserId = Convert.ToInt32(chkUser.Attributes["USERID"]);

            foreach (FlareViolationMailList ok in oM)
            {
                if (ok.iUserId == iUserId) chkUser.Checked = true;
                else chkUser.Checked = false;
            }
        }
    }

    private void changeValuesFlrWaiver()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label userRole = ((Label)(grdRow.FindControl("labelRole")));

            if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Administrator)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Administrator);
            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOnshore);
            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.Initiator)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.Initiator);
            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.LineManager)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.LineManager);
            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssurancePSMgr);
            else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
                userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.AssuranceOffshore);
            //else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.GMOnshore)
            //    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.GMOnshore);
            //else if (int.Parse(userRole.Text) == (int)appUserRolesFlrWaiver.userRole.GMDeepWater)
            //    userRole.Text = appUserRolesFlrWaiver.userRoleDesc(appUserRolesFlrWaiver.userRole.GMDeepWater);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            CheckBox chkUser = (CheckBox)grdRow.FindControl("chkUser");
            if (chkUser.Checked)
            {
                int iUserId = int.Parse(chkUser.Attributes["USERID"].ToString());
                bRet = v.InsertViolationMailList(iUserId);
            }
            else if (!chkUser.Checked)
            {
                int iUserId = int.Parse(chkUser.Attributes["USERID"].ToString());
                FlareViolationMailList oM = v.objGetViolationMailListByUserId(iUserId);
                if (oM.iUserId != 0)
                {
                    bRet = v.DeleteViolationMailList(iUserId);
                }
            }
        }

        Checkers();

        if (bRet) { ajaxWebExtension.showJscriptAlert(Page, this, "Successful!!!"); }
    }

    protected void grdView_PageIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        RetrieveUsers();
    }

    protected void grdView_Sorted(object sender, EventArgs e)
    {

    }

    protected void grdView_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}