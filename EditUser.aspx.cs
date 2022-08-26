using System;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class Forms_EditUser : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFieldVisit);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");



        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null)
                {
                    int iUserId = int.Parse(Encoder.HtmlEncode(Request.QueryString["UserId"].ToString()));

                    var oAppUser = appUsersHelper.objGetOnlineUserByUserId(iUserId);

                    if (oAppUser.m_iCostSavingAbsVal == 1)
                    {
                        ckbAbsoluteRight.Checked = true;
                        ckbAbsoluteRight.Font.Underline = true;
                        ckbAbsoluteRight.ForeColor = System.Drawing.Color.Green;
                    }
                    else ckbAbsoluteRight.Checked = false;

                    //lblFullname.Text = oAppUser.m_sFullName;

                    grdView.DataSource = appUsersHelper.dtGetOnlineUserByUserId(iUserId);
                    grdView.DataBind();


                    foreach (GridViewRow grdRow in grdView.Rows)
                    {
                        DropDownList ddlUserRoleFieldVisit = ((DropDownList)(grdRow.FindControl("ddlUserRoleFieldVisit")));
                        appUsersRoles.getUserRoles(ddlUserRoleFieldVisit);
                        ddlUserRoleFieldVisit.SelectedValue = oAppUser.m_iRoleIdFieldVisit.ToString();

                        DropDownList ddlUserRoleLean = ((DropDownList)(grdRow.FindControl("ddlUserRoleLean")));
                        appUsersLeanRoles.getUserRoles(ddlUserRoleLean);
                        ddlUserRoleLean.SelectedValue = oAppUser.m_iRoleIdLean.ToString();

                        DropDownList ddlUserRoleInitMgt = ((DropDownList)(grdRow.FindControl("ddlUserRoleInitMgt")));
                        appUsersRoles.getUserRoles(ddlUserRoleInitMgt);
                        ddlUserRoleInitMgt.SelectedValue = oAppUser.m_iRoleIdManHr.ToString();

                        DropDownList ddlUserRoleFlare = ((DropDownList)(grdRow.FindControl("ddlUserRoleFlare")));
                        appUserRolesFlrWaiver.getUserRoles(ddlUserRoleFlare);
                        ddlUserRoleFlare.SelectedValue = oAppUser.m_iRoleIdFlr.ToString();

                        DropDownList ddlUserRoleBI = ((DropDownList)(grdRow.FindControl("ddlUserRoleBI")));
                        appUsersRolesBI500.getUserRoles(ddlUserRoleBI);
                        ddlUserRoleBI.SelectedValue = oAppUser.m_iRoleIdBI.ToString();

                        DropDownList ddlUserRoleCostTrans = ((DropDownList)(grdRow.FindControl("ddlUserRoleCostTrans")));
                        AppUsersPdccRoles.GetUserRoles(ddlUserRoleCostTrans);
                        ddlUserRoleCostTrans.SelectedValue = oAppUser.m_iRolePdcc.ToString();
                    }


                    //if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.FourteenDayContract)
                    //{
                    //    //appUserRolesFlrWaiver.getUserRoles(ddlUserRole);
                    //    ddlUserRole.SelectedValue = appUsersHelper.objGetOnlineUserByUserId(iUserId).m_iRoleIdContract.ToString();
                    //}

                   
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }

    //private void addRoleToDropDown(appUsersRoles.userRole eRole)
    //{
    //    try
    //    {
    //        ListItem oItem = new ListItem();
    //        oItem.Text = appUsersRoles.userRoleDesc(eRole);
    //        oItem.Value = ((int)eRole).ToString();
    //        ddlUserRole.Items.Add(oItem);
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}
    protected void closeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserManagement.aspx");
    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["UserId"] != null)
            {
                int iUserId = int.Parse(Request.QueryString["UserId"].ToString());

                bool bRet = false;

                foreach (GridViewRow grdRow in grdView.Rows)
                {
                    DropDownList ddlUserRoleFieldVisit = ((DropDownList)(grdRow.FindControl("ddlUserRoleFieldVisit")));
                    DropDownList ddlUserRoleLean = ((DropDownList)(grdRow.FindControl("ddlUserRoleLean")));
                    DropDownList ddlUserRoleInitMgt = ((DropDownList)(grdRow.FindControl("ddlUserRoleInitMgt")));
                    DropDownList ddlUserRoleFlare = ((DropDownList)(grdRow.FindControl("ddlUserRoleFlare")));
                    DropDownList ddlUserRoleBI = ((DropDownList)(grdRow.FindControl("ddlUserRoleBI")));
                    DropDownList ddlUserRoleCostTrans = ((DropDownList)(grdRow.FindControl("ddlUserRoleCostTrans")));

                    int? iFieldVisit = (ddlUserRoleFieldVisit.SelectedValue == "-1") ?  0 : int.Parse(ddlUserRoleFieldVisit.SelectedValue);
                    int? iLean = (ddlUserRoleLean.SelectedValue == "-1") ? 0 : int.Parse(ddlUserRoleLean.SelectedValue);
                    int? iBI = (ddlUserRoleBI.SelectedValue == "-1") ? 0 : int.Parse(ddlUserRoleBI.SelectedValue);
                    int? iInitiative = (ddlUserRoleInitMgt.SelectedValue == "-1") ? 0 : int.Parse(ddlUserRoleInitMgt.SelectedValue);
                    int? iFlare = (ddlUserRoleFlare.SelectedValue == "-1") ? 0 : int.Parse(ddlUserRoleFlare.SelectedValue);
                    int? iCostTrans = (ddlUserRoleCostTrans.SelectedValue == "-1") ? 0 : int.Parse(ddlUserRoleCostTrans.SelectedValue);

                    bRet = appUsersHelper.editUserAccount4AllApps(iUserId, iFieldVisit, iLean, iBI, iInitiative, iFlare, iCostTrans);
                }

                if (bRet)
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "User profile successfully updated.");
                }

                //if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.BI500)
                //{
                //    bRet = appUsersHelper.editBIUserAccount(iUserId, int.Parse(ddlUserRole.SelectedValue));
                //}
                //else if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.pec)
                //{
                //    bRet = appUsersHelper.editUserAccount(iUserId, int.Parse(ddlUserRole.SelectedValue));
                //}
                //else if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.FlareWaiver)
                //{
                //    bRet = appUsersHelper.editFlrWaierUserAccount(iUserId, int.Parse(ddlUserRole.SelectedValue));
                //}
                //else if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.FourteenDayContract)
                //{
                //    bRet = appUsersHelper.edit14DayContractUserAccount(iUserId, int.Parse(ddlUserRole.SelectedValue));
                //}
                //else if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.initiativeMgt)
                //{
                //    bRet = appUsersHelper.editManHrUserAccount(iUserId, int.Parse(ddlUserRole.SelectedValue));
                //}
                //else if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.lean)
                //{
                //    bRet = appUsersHelper.editLeanUserAccount(iUserId, int.Parse(ddlUserRole.SelectedValue));
                //}
                //else if (int.Parse(Request.QueryString["App"].ToString()) == (int)AppTokens.appTokens.lean)
                //{
                //    bRet = appUsersHelper.editPdccUserAccount(iUserId, int.Parse(ddlUserRole.SelectedValue));
                //}
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "User not successfully updated, please try again later.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void ckbAbsoluteRight_CheckedChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["UserId"] != null)
        {
            int iUserId = int.Parse(Request.QueryString["UserId"]);
            int iCostSavingRight = (ckbAbsoluteRight.Checked) ? 1 : 0;
            bool bRet = appUsersHelper.DisableEnableCostSavingAbsoluteValuesRight(iUserId, iCostSavingRight);
            ajaxWebExtension.showJscriptAlert(Page, this,
                bRet
                    ? "Right to view Cost Ambition Deep Dive absolute values has been given."
                    : "Right to view Cost Ambition Deep Dive absolute values has been Removed.");
        }
    }
}