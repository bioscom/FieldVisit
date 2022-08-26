using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class App_Contract_AssignAssetsToOpsManager : aspnetPage
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

        if (!IsPostBack)
        {
            loadData();
            addUserPanel.Visible = false;
        }
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        loadData();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "editThis")
        {
            LinkButton lbEdit = (LinkButton)grdView.Rows[index].FindControl("editLinkButton");
            idSuperintendentHF.Value = lbEdit.Attributes["ID_SUPERINTENDENT"].ToString();

            if ((idSuperintendentHF.Value != null) || (idSuperintendentHF.Value != ""))
            {
                Superintendent mySuperintendent = Superintendent.objGetSuperintendentById(int.Parse(idSuperintendentHF.Value));
                superintendentTextBox.Text = mySuperintendent.m_sSuperintendent;
                functionalEmailTextBox.Text = mySuperintendent.m_sSuperintendentEmail;
            }
        }
        else if (ButtonClicked == "viwMember")
        {
            LinkButton lbViewMember = (LinkButton)grdView.Rows[index].FindControl("viwMemberLinkButton");
            int superintendentId = int.Parse(lbViewMember.Attributes["ID_SUPERINTENDENT"].ToString());
            Label lbSuperintendent = (Label)grdView.Rows[index].FindControl("labelSuperintendent");

            viwFunctionalAcctMembers1.LoadOpsMgrAcctUserBySuperintendent(superintendentId, lbSuperintendent.Text);

            LinkButton lbAddMember = (LinkButton)grdView.Rows[index].FindControl("addMemberLinkButton");

            addUserPanel.Visible = true;

            opsMgrIdHF.Value = superintendentId.ToString();

            drpOpsMgrUsers.Items.Clear();
            drpOpsMgrUsers.Items.Add(new ListItem("--Select Operations Manager--", "-1"));
            List<appUsers> lstOpsMgr = appUsersHelper.lstGetOnlineUserByRole((int)AppUsers14DaysContract.UserRole.OperationsManager);
            foreach (appUsers OpsMgr in lstOpsMgr)
            {
                drpOpsMgrUsers.Items.Add(new ListItem(OpsMgr.m_sFullName, OpsMgr.m_iUserId.ToString()));
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idSuperintendentHF.Value == null) || (idSuperintendentHF.Value == ""))
        {
            bool bRet = Superintendent.createSuperintendent(superintendentTextBox.Text, functionalEmailTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string message = superintendentTextBox.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = Superintendent.updateSuperintendent(int.Parse(idSuperintendentHF.Value), superintendentTextBox.Text, functionalEmailTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = superintendentTextBox.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);

                Response.Redirect("~/Setup/Superintendent.aspx");
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = Superintendent.dtGetSuperintendent();
        grdView.DataBind();
    }

    private void Clear()
    {
        superintendentTextBox.Text = "";
        functionalEmailTextBox.Text = "";
        idSuperintendentHF.Value = "";
    }

    protected void resetButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Setup/Superintendent.aspx");
    }
    protected void addNewUserButton_Click(object sender, EventArgs e)
    {
        System.Data.DataTable dt = OpsMgrFunctionalAcctUser.CheckIfSelectedUserExistsForTheSelectedSuperintendent(int.Parse(opsMgrIdHF.Value), int.Parse(drpOpsMgrUsers.SelectedValue));
        if (dt.Rows.Count > 0)
        {
            string message = drpOpsMgrUsers.SelectedItem.Text + " is an existing member of " + superintendentLabel.Text + " functional account, duplicate not allowed.";
            ajaxWebExtension.showJscriptAlert(Page, this, message);
        }
        else
        {
            bool bRet = OpsMgrFunctionalAcctUser.insertOpsMgrFunctionalAcctUser(int.Parse(opsMgrIdHF.Value), int.Parse(drpOpsMgrUsers.SelectedValue));
            viwFunctionalAcctMembers1.LoadOpsMgrAcctUserBySuperintendent(int.Parse(opsMgrIdHF.Value), superintendentLabel.Text);
        }
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {
        addUserPanel.Visible = false;
    }
    //protected void addNewUserImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    //{
    //    addUserPanel.Visible = true;
    //}
}