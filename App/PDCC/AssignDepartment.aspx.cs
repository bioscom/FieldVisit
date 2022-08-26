using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Oracle.ManagedDataAccess.Client;

public partial class App_PDCC_AssignDepartment : aspnetPage
{
    readonly Department _gDepartment = new Department();
    readonly appUsersHelper oAppUsersHelper = new appUsersHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAssignedUsers();

            int x = 1;


            List<AssetPdcc> oAssets = AssetPdcc.lstGetAssets();
            foreach (AssetPdcc oAsset in oAssets)
            {
                ckbDept.Items.Add(new ListItem(x + ". " + Encoder.HtmlEncode(oAsset.sAsset),
                    Encoder.HtmlEncode(oAsset.iAssetId.ToString())));
                x++;
            }

            //List<Department> oDepartments = _gDepartment.lstGetDeparments();
            //foreach (Department oDepartment in oDepartments)
            //{
            //    ckbDept.Items.Add(new ListItem(x + ". " + Encoder.HtmlEncode(oDepartment.m_sDepartment),
            //        Encoder.HtmlEncode(oDepartment.m_iDepartmentId.ToString())));
            //    x++;
            //}

            int y = 1;
            List<appUsers> lstUsers = oAppUsersHelper.lstGetPdccUserByRole((int)AppUsersPdccRoles.UserRole.User);

            foreach (appUsers oUser in lstUsers)
            {
                ddlUsers.Items.Add(new ListItem(y + ". " + oUser.m_sFullName + "{" + AppUsersPdccRoles.UserRoleDesc(AppUsersPdccRoles.UserRole.User) + "}", oUser.m_iUserId.ToString()));
                y++;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        int i = 0;
        foreach (ListItem li in ckbDept.Items)
        {
            if (li.Selected == false)
            {
                i++;
            }
        }
        //int i = ckbDept.Items.Cast<ListItem>().Count(li => li.Selected == false);

        if (i == ckbDept.Items.Count)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Atleast, an asset must be assigned to a User.");
        }
        else
        {
            string sAssets = "";
            bool bRet = false;
            foreach (ListItem li in ckbDept.Items)
            {
                if (li.Selected)
                {
                    //Check if selected Department is found assigned to the user
                    if (!Department.BGetIfAssetHasBeenAssignedToUser(int.Parse(ddlUsers.SelectedValue), int.Parse(li.Value)))
                    {
                        bRet = Department.AssignAssetToPdccUser(int.Parse(ddlUsers.SelectedValue), int.Parse(li.Value));
                        if (bRet) sAssets += li.Text + ", ";
                    }
                    //TODO: if previously selected Asset has been deselected, what should be done?
                }
            }
	    LoadAssignedUsers();
            //ckbDept.ClearSelection();
            string mssg = "The following Assets " + sAssets + " were successully assigned to " + ddlUsers.SelectedItem.Text;
            ajaxWebExtension.showJscriptAlert(Page, this, mssg);

            //if (bRet)
            //{
            //    string mssg = "The following Departments " + sDepartments + " were successully assigned to " + ddlUsers.SelectedItem.Text;
            //    ajaxWebExtension.showJscriptAlert(Page, this, mssg);
            //}
            //else
            //{
            //    string mssg = "Department Assignment not successful!!! Try again later.";
            //    ajaxWebExtension.showJscriptAlert(Page, this, mssg);
            //}
        }
    }
    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TODO: If a user is selected, check to see if the user already has Facilities assigned

        ckbDept.ClearSelection();

        List<AssetPdcc> lstMyAssets = _gDepartment.lstGetAssetsByUser(int.Parse(ddlUsers.SelectedValue));
        foreach (AssetPdcc oAsset in lstMyAssets)
        {
            foreach (ListItem li in ckbDept.Items)
            {
                if (li.Value == oAsset.iAssetId.ToString())
                {
                    li.Selected = true;
                }
            }
        }
    }

    private void LoadAssignedUsers()
    {
        string sql="SELECT PROD_USERMGT.FULLNAME, PDCC_ASSET.ASSET FROM PDCC_USER_DEPT ";
        sql += "INNER JOIN PDCC_ASSET ON PDCC_ASSET.ASSETID = PDCC_USER_DEPT.ASSETID ";
        sql += "INNER JOIN PROD_USERMGT ON PDCC_USER_DEPT.USERID = PROD_USERMGT.USERID ORDER BY PDCC_ASSET.ASSET";

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = sql;

        System.Data.DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);

        grdView.DataSource = dt;
        grdView.DataBind();
    }
}