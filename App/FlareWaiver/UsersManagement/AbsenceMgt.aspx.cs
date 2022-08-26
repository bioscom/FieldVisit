using System;
using System.Web.UI.WebControls;

public partial class UsersManagement_AbsenceMgt : System.Web.UI.Page
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addRoleToDropDown(appUserRolesFlrWaiver.userRole.AssurancePSMgr);
            addRoleToDropDown(appUserRolesFlrWaiver.userRole.AssuranceOffshore);
            addRoleToDropDown(appUserRolesFlrWaiver.userRole.AssuranceOnshore);
            addRoleToDropDown(appUserRolesFlrWaiver.userRole.Approval);
            //addRoleToDropDown(appUserRolesFlrWaiver.userRole.GMDeepWater);
        }
    }

    private void addRoleToDropDown(appUserRolesFlrWaiver.userRole eRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUserRolesFlrWaiver.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            ddlRoles.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (int.Parse(ddlRoles.SelectedValue) == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
            {
                LoadDelegates(oappUsersHelper.dtGetDeligatedUserByRole2((int)appUserRolesFlrWaiver.userRole.AssurancePSMgr));
            }
            else if (int.Parse(ddlRoles.SelectedValue) == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
            {
                LoadDelegates(oappUsersHelper.dtGetDeligatedUserByRole2((int)appUserRolesFlrWaiver.userRole.AssuranceOffshore));
            }
            else if (int.Parse(ddlRoles.SelectedValue) == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
            {
                LoadDelegates(oappUsersHelper.dtGetDeligatedUserByRole2((int)appUserRolesFlrWaiver.userRole.AssuranceOnshore));
            }
            else if (int.Parse(ddlRoles.SelectedValue) == (int)appUserRolesFlrWaiver.userRole.Approval)
            {
                LoadDelegates(oappUsersHelper.dtGetDeligatedUserByRole2((int)appUserRolesFlrWaiver.userRole.Approval));
            }
            //else if (int.Parse(ddlRoles.SelectedValue) == (int)appUserRolesFlrWaiver.userRole.GMDeepWater)
            //{
            //    LoadDelegates(oappUsersHelper.dtGetDeligatedUserByRole2((int)appUserRolesFlrWaiver.userRole.GMDeepWater));
            //}
           
            lblRole.Text = "Current " + ddlRoles.SelectedItem.Text;
            lblRoleDesc.Text = ddlRoles.SelectedItem.Text;
            //lblRoleDesc2.Text = ddlRoles.SelectedItem.Text;
            lblRoleDesc3.Text = ddlRoles.SelectedItem.Text;
            lblRoleDesc4.Text = ddlRoles.SelectedItem.Text;
            lblRoleDesc5.Text = ddlRoles.SelectedItem.Text;
            lblRoleDesc6.Text = ddlRoles.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    private void LoadDelegates(System.Data.DataTable dt)
    {
        try
        {
            if ((dt.Rows.Count > 0))
            {
                grdView.DataSource = dt;
                grdView.DataBind();

                foreach (GridViewRow grd in grdView.Rows)
                {
                    Label status = (Label)grdView.Rows[grd.RowIndex].FindControl("statusLabel");
                    CheckBox deligateCkb = (CheckBox)grdView.Rows[grd.RowIndex].FindControl("deligateCkb");
                    int iFlagColor = Convert.ToInt32(deligateCkb.Attributes["DELIGATED"]);
                    if (iFlagColor == (int)appUserRolesFlrWaiver.eDeligation.Deligated)
                    {
                        status.Text = "Default " + ddlRoles.SelectedItem.Text;
                        deligateCkb.Checked = true;
                    }
                    else if (iFlagColor == 0)
                    {
                        status.Text = "";
                    }
                }
            }
            else
            {
                grdView.DataSource = dt;
                grdView.DataBind();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            if (DefaultDelegateSelected() > 1)
            {
                string oMessage = "You can only select one " + ddlRoles.SelectedItem.Text + " as Default. Select a default deligate and unselect the others. Thank you.";
                ajaxWebExtension.showJscriptAlert(Page, this, oMessage);
            }
            else
            {
                foreach (GridViewRow grd in grdView.Rows)
                {
                    CheckBox deligateCkb = (CheckBox)grdView.Rows[grd.RowIndex].FindControl("deligateCkb");
                    int iUserId = int.Parse(deligateCkb.Attributes["IDUSER"].ToString());
                    if (deligateCkb.Checked)
                    {
                        bRet = oappUsersHelper.MakeDeligate((int)appUserRolesFlrWaiver.eDeligation.Deligated, iUserId);
                        bRet = oappUsersHelper.bRoutePendingRequestToNewDeligate((int)RequestStatusReporter.RequestStatusRpt.Approved, iUserId, int.Parse(ddlRoles.SelectedValue));
                    }
                    else if (!deligateCkb.Checked)
                    {
                        bRet = oappUsersHelper.MakeDeligate((int)appUserRolesFlrWaiver.eDeligation.Undeligated, iUserId);
                    }
                }
            }
            ddlRoles_SelectedIndexChanged(this, e);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private int DefaultDelegateSelected()
    {
        int selectedDeligate = 0;
        try
        {
            foreach (GridViewRow grd in grdView.Rows)
            {
                CheckBox deligateCkb = (CheckBox)grdView.Rows[grd.RowIndex].FindControl("deligateCkb");
                if (deligateCkb.Checked == true)
                {
                    selectedDeligate += 1;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return selectedDeligate;
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/FlareWaiver/UsersManagement/ViewUsers.aspx");
    }
}