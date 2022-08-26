using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_FieldVisit_UserControl_frmSuperintendent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        grdView.DataSource = Superintendent.dtGetSuperintendent();
        grdView.Rebind();
    }

    protected void grdView_ItemCommand(object source, GridCommandEventArgs e)
    {
        //Session["RowIndex"] = e.Item.ItemIndex.ToString();

        //if (e.CommandName == RadGrid.ExpandCollapseCommandName)
        //{
        //    var details = (ASP.app_fieldvisit_usercontrol_frmdistricts_ascx) ((GridDataItem) e.Item).ChildItem.FindControl("frmDistricts");
        //    if (!e.Item.Expanded)
        //    {
        //        int iSuperintendentId = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID_SUPERINTENDENT"].ToString());
        //        details.GetDisctrictBySuperintendent(iSuperintendentId);
        //    }
        //}

        if (e.CommandName == "ViewMembers")
        {
            int iSuperintendentId = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID_SUPERINTENDENT"].ToString());
 
            viwFunctionalAcctMembers1.LoadSuperintendentAcctUserBySuperintendent(iSuperintendentId, Superintendent.objGetSuperintendentById(iSuperintendentId).m_sSuperintendent);

            //LinkButton lbAddMember = (LinkButton) grdView.Rows[index].FindControl("addMemberLinkButton");

            addUserPanel.Visible = true;

            superintendentIdHF.Value = iSuperintendentId.ToString();

            drpSuperintendentUsers.Items.Clear();
            drpSuperintendentUsers.Items.Add(new ListItem("--Select Superintendent User--", "-1"));
            List<appUsers> SuperintendentUsers = appUsersHelper.lstGetOnlineUserByRole((int) appUsersRoles.userRole.superintendent);
            foreach (appUsers SuperintendentUser in SuperintendentUsers)
            {
                drpSuperintendentUsers.Items.Add(new ListItem(SuperintendentUser.m_sFullName, SuperintendentUser.m_iUserId.ToString()));
            }
        }
    }

    protected void grdView_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var lbl = e.Item.FindControl("numberLabel") as Label;
            if (lbl != null)
                lbl.Text = (e.Item.ItemIndex + 1).ToString();
        }
    }

    protected void grdView_ItemDeleted(object sender, Telerik.Web.UI.GridDeletedEventArgs e)
    {

    }

    protected void grdView_ItemInserted(object sender, Telerik.Web.UI.GridInsertedEventArgs e)
    {

    }

    protected void grdView_ItemUpdated(object sender, Telerik.Web.UI.GridUpdatedEventArgs e)
    {

    }

    protected void grdView_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            (sender as RadGrid).DataSource = Superintendent.dtGetSuperintendent();
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            grdView.MasterTableView.SortExpressions.Clear();
            grdView.MasterTableView.GroupByExpressions.Clear();
            grdView.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            grdView.MasterTableView.SortExpressions.Clear();
            grdView.MasterTableView.GroupByExpressions.Clear();
            grdView.MasterTableView.CurrentPageIndex = grdView.MasterTableView.PageCount - 1;
            grdView.Rebind();
        }
    }

    protected void grdView_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
    {
        GridDataItem dataItem = (GridDataItem) e.DetailTableView.ParentItem;

        switch (e.DetailTableView.Name)
        {
            case "Districts":
                {
                    int iSuperintendentId = int.Parse(dataItem.GetDataKeyValue("ID_SUPERINTENDENT").ToString());
                    e.DetailTableView.DataSource = District.dtGetDistrictBySuperintendent(iSuperintendentId);
                    break;
                }

            case "facilities":
                {
                    int iDistrictId = int.Parse(dataItem.GetDataKeyValue("ID_DISTRICT").ToString());
                    e.DetailTableView.DataSource = facility.dtGetFacilityByDistrict(iDistrictId);
                    break;
                }
        }
    }


    protected void submitButton_Click(object sender, EventArgs e)
    {
        //if ((idSuperintendentHF.Value == null) || (idSuperintendentHF.Value == ""))
        //{
        //    bool bRet = Superintendent.createSuperintendent(superintendentTextBox.Text, functionalEmailTextBox.Text);
        //    if (bRet == true)
        //    {
        //        loadData();

        //        string message = superintendentTextBox.Text + " successfully submitted.";
        //        ajaxWebExtension.showJscriptAlert(Page, this, message);
        //    }
        //}
        //else
        //{
        //    bool bRet = Superintendent.updateSuperintendent(int.Parse(idSuperintendentHF.Value), superintendentTextBox.Text, functionalEmailTextBox.Text);
        //    if (bRet == true)
        //    {
        //        loadData();

        //        string updateMessage = superintendentTextBox.Text + " successfully updated.";
        //        ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);

        //        Response.Redirect("~/Setup/Superintendent.aspx");
        //    }
        //}
        //Clear();
    }

    private void loadData()
    {
        //grdView.DataSource = Superintendent.dtGetSuperintendent();
        //grdView.DataBind();
    }

    private void Clear()
    {
        //superintendentTextBox.Text = "";
        //functionalEmailTextBox.Text = "";
        //idSuperintendentHF.Value = "";
    }

    protected void resetButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Setup/Superintendent.aspx");
    }
    protected void addNewUserButton_Click(object sender, EventArgs e)
    {
        System.Data.DataTable dt = SuperintendentFunctionalAcctUser.CheckIfSelectedUserExistsForTheSelectedSuperintendent(int.Parse(superintendentIdHF.Value), int.Parse(drpSuperintendentUsers.SelectedValue));
        if (dt.Rows.Count > 0)
        {
            string message = drpSuperintendentUsers.SelectedItem.Text + " is an existing member of " + superintendentLabel.Text + " functional account, duplicate not allowed.";
            ajaxWebExtension.showJscriptAlert(Page, this, message);
        }
        else
        {
            bool bRet = SuperintendentFunctionalAcctUser.insertSuperintendentFunctionalAcctUser(int.Parse(superintendentIdHF.Value), int.Parse(drpSuperintendentUsers.SelectedValue));
            viwFunctionalAcctMembers1.LoadSuperintendentAcctUserBySuperintendent(int.Parse(superintendentIdHF.Value), superintendentLabel.Text);
        }
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {
        addUserPanel.Visible = false;
    }
}