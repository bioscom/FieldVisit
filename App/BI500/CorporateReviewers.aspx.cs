using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_CorporateReviewers : aspnetPage
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
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRolesBI500.userRole)oSessnx.getOnlineUser.m_iRoleIdBI);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            List<appUsers> oappUsers = appUsersHelper.lstGetOnlineBIUserByRole((int)appUsersRolesBI500.userRole.CorporateViewer);
            foreach (appUsers oAppUser in oappUsers)
            {
               ddlCorporate.Items.Add(new ListItem(oAppUser.m_sFullName, oAppUser.m_iUserId.ToString()));
            }

            List<Functions> lstFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in lstFunctions)
            {
                rdoBusinessUnit.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
            }

            CorporateOverviewers();
        }
    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool bRet = false;
            if (string.IsNullOrEmpty(functionIdHF.Value))
            {
                bRet = oBuzLeanFocalPointHelper.AssignFocalPointToBizUnit(int.Parse(ddlCorporate.SelectedValue), int.Parse(rdoBusinessUnit.SelectedValue));
            }
            else
            {
                bRet = oBuzLeanFocalPointHelper.UpdateFocalPointToBizUnit(int.Parse(functionIdHF.Value), int.Parse(ddlCorporate.SelectedValue), int.Parse(rdoBusinessUnit.SelectedValue));
            }

            CorporateOverviewers();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {

    }
    protected void ddlCorporate_SelectedIndexChanged(object sender, EventArgs e)
    {
        functionIdHF.Value = "";
        rdoBusinessUnit.ClearSelection();

        try
        {
            BusinessLeanFocalPoints oBusinessLeanFocalPoints = oBuzLeanFocalPointHelper.objGetBusinessUnitAssignedByUserId(int.Parse(ddlCorporate.SelectedValue));
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

    private void CorporateOverviewers()
    {
        //bLstFocalPointBizUnit.ClearSelection();
        bLstFocalPointBizUnit.Items.Clear();
        List<BusinessLeanFocalPoints> lstCorporateOverviewers = oBuzLeanFocalPointHelper.lstGetBusinessUnitFocalPoints((int)appUsersRolesBI500.userRole.CorporateViewer);
        foreach (BusinessLeanFocalPoints oCorporateOverviewers in lstCorporateOverviewers)
        {
            bLstFocalPointBizUnit.Items.Add(new ListItem(oappUsersHelper.objGetUserByUserID(oCorporateOverviewers.m_iUserId).m_sFullName) + " assigned to " + oFunctionMgt.objGetFunctionById(oCorporateOverviewers.m_iFunctionId).m_sFunction);
        }
    }
}