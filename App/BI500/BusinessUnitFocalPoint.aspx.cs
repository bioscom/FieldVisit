using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class App_BI500_BusinessUnitFocalPoint : aspnetPage
{
    FunctionMgt oFunctionMgt = new FunctionMgt();
    BuzLeanFocalPointHelper oBuzLeanFocalPointHelper = new BuzLeanFocalPointHelper();
    appUsers oAppUser = new appUsers();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRolesBI500.userRole.admin.ToString() };
            appUsersRolesBI500 oAccess = new appUsersRolesBI500();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRolesBI500.userRole)this.oSessnx.getOnlineUser.m_iRoleIdBI);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            List<appUsers> oappUsers = appUsersHelper.lstGetOnlineBIUserByRole((int)appUsersRolesBI500.userRole.focalPoint);
            foreach (appUsers oAppUser in oappUsers)
            {
                ddlFocalPoints.Items.Add(new ListItem(oAppUser.m_sFullName, oAppUser.m_iUserId.ToString()));
            }

            List<Functions> lstFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in lstFunctions)
            {
                rdoBusinessUnit.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
            }

            FocalPoints();
        }
    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool bRet = false;
            if (string.IsNullOrEmpty(functionIdHF.Value))
            {
                bRet = oBuzLeanFocalPointHelper.AssignFocalPointToBizUnit(int.Parse(ddlFocalPoints.SelectedValue), int.Parse(rdoBusinessUnit.SelectedValue));
            }
            else
            {
                bRet = oBuzLeanFocalPointHelper.UpdateFocalPointToBizUnit(int.Parse(functionIdHF.Value), int.Parse(ddlFocalPoints.SelectedValue), int.Parse(rdoBusinessUnit.SelectedValue));
            }

            FocalPoints();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {

    }
    protected void ddlFocalPoints_SelectedIndexChanged(object sender, EventArgs e)
    {
        functionIdHF.Value = "";
        rdoBusinessUnit.ClearSelection();

        try
        {
            BusinessLeanFocalPoints oBusinessLeanFocalPoints = oBuzLeanFocalPointHelper.objGetBusinessUnitAssignedByUserId(int.Parse(ddlFocalPoints.SelectedValue));
            if (oBusinessLeanFocalPoints.m_iFocalPointId != 0)
            {
                functionIdHF.Value = oBusinessLeanFocalPoints.m_iFunctionId.ToString();
            }

            if (!string.IsNullOrEmpty(functionIdHF.Value))
            {
                foreach (ListItem li in rdoBusinessUnit.Items)
                {
                    if (li.Value == functionIdHF.Value)
                    {
                        li.Selected = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }

    private void FocalPoints()
    {
        //bLstFocalPointBizUnit.ClearSelection();
        bLstFocalPointBizUnit.Items.Clear();
        List<BusinessLeanFocalPoints> lstBusinessLeanFocalPoints = oBuzLeanFocalPointHelper.lstGetBusinessUnitFocalPoints((int)appUsersRolesBI500.userRole.focalPoint);
        foreach (BusinessLeanFocalPoints oBusinessLeanFocalPoints in lstBusinessLeanFocalPoints)
        {
            bLstFocalPointBizUnit.Items.Add(new ListItem(oappUsersHelper.objGetUserByUserID(oBusinessLeanFocalPoints.m_iUserId).m_sFullName) + " assigned to " + oFunctionMgt.objGetFunctionById(oBusinessLeanFocalPoints.m_iFunctionId).m_sFunction);
        }
    }
}