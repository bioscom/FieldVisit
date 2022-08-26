using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class Setup_Superintendent : aspnetPage
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

        
    }
    //protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdView.PageIndex = e.NewPageIndex;
    //    loadData();
    //}
    //protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
    //    int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

    //    if (ButtonClicked == "editThis")
    //    {
    //        LinkButton lbEdit = (LinkButton)grdView.Rows[index].FindControl("editLinkButton");
    //        idSuperintendentHF.Value = lbEdit.Attributes["ID_SUPERINTENDENT"].ToString();

    //        if ((idSuperintendentHF.Value != null)||(idSuperintendentHF.Value != ""))
    //        {
    //            Superintendent mySuperintendent = Superintendent.objGetSuperintendentById(int.Parse(idSuperintendentHF.Value));
    //            superintendentTextBox.Text = mySuperintendent.m_sSuperintendent;
    //            functionalEmailTextBox.Text = mySuperintendent.m_sSuperintendentEmail;
    //        }
    //    }
    //    else if (ButtonClicked == "viwMember")
    //    {
    //        LinkButton lbViewMember = (LinkButton)grdView.Rows[index].FindControl("viwMemberLinkButton");
    //        int superintendentId = int.Parse(lbViewMember.Attributes["ID_SUPERINTENDENT"].ToString());
    //        Label lbSuperintendent = (Label)grdView.Rows[index].FindControl("labelSuperintendent");

    //        viwFunctionalAcctMembers1.LoadSuperintendentAcctUserBySuperintendent(superintendentId, lbSuperintendent.Text);

    //        LinkButton lbAddMember = (LinkButton)grdView.Rows[index].FindControl("addMemberLinkButton");

    //        addUserPanel.Visible = true;

    //        superintendentIdHF.Value = superintendentId.ToString();

    //        drpSuperintendentUsers.Items.Clear();
    //        drpSuperintendentUsers.Items.Add(new ListItem("--Select Superintendent User--", "-1"));
    //        List<appUsers> SuperintendentUsers = appUsersHelper.lstGetOnlineUserByRole((int)appUsersRoles.userRole.superintendent);
    //        foreach (appUsers SuperintendentUser in SuperintendentUsers)
    //        {
    //            drpSuperintendentUsers.Items.Add(new ListItem(SuperintendentUser.m_sFullName, SuperintendentUser.m_iUserId.ToString()));
    //        }
    //    }
    //    //else if (ButtonClicked == "addMember")
    //    //{
            
    //    //}
    //}

   
    //protected void addNewUserImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    //{
    //    addUserPanel.Visible = true;
    //}
}
