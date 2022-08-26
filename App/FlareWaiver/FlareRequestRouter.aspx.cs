using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class FlareRequestRouter : aspnetPage
{
    FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();
    FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
    appUsersHelper oAppUsersHelper = new appUsersHelper();
    FacilityAssetGM oFacilityAssetGM = new FacilityAssetGM();
    FacilityAssetGMHelper oFacilityAssetGMHelper = new FacilityAssetGMHelper();
    appUsers oAppUser = new appUsers();
    RequestFacilityHelper oRequestFacilityHelper = new RequestFacilityHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["RequestId"] != null)
            {
                long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                oRequestDetails1.Init_Control(oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId));

                LoadDetails(lRequestId);
            }
        }
    }

    private void LoadDetails(long lRequestId)
    {
        GetUsersByRoleId(ddlLineMgr, appUserRolesFlrWaiver.userRole.LineManager);

        List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(lRequestId);

        foreach (RequestFacility oRequestFacility in lstRequestFacilities)
        {
            oFacilityAssetGM = oFacilityAssetGMHelper.objGetFacilityAssetGMByFacilityId(oRequestFacility.m_iFacilityId);
            oAppUser = oAppUsersHelper.objGetUserByUserID(oFacilityAssetGM.m_iUserId);

            if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
            {
                GetUsersByRoleId(ddlAssetGM, appUserRolesFlrWaiver.userRole.AssuranceOffshore);
                break;
            }
            else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
            {
                GetUsersByRoleId(ddlAssetGM, appUserRolesFlrWaiver.userRole.AssuranceOnshore);
                break;
            }
        }   

        GetUsersByRoleId(ddlProdServMgr, appUserRolesFlrWaiver.userRole.AssurancePSMgr);
        GetUsersByRoleId(ddlGMProd, appUserRolesFlrWaiver.userRole.Approval);

        List<FlareApproval> oFlareApprovals = oFlareApprovalHelper.lstGetFlareApprovalbyRequestId(lRequestId);
        foreach (FlareApproval oFlareApproval in oFlareApprovals)
        {
            if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
            {
                lblLineMgr.Text = oAppUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                Stand(oFlareApproval.m_iStand, lblLineMgrStand, ddlLineMgr, lineMgrBtn);
            }
            else if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
            {
                lblAssetGM.Text = oAppUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                Stand(oFlareApproval.m_iStand, lblAssetGMgrStand, ddlAssetGM, assetGMBtn);
            }
            else if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
            {
                lblAssetGM.Text = oAppUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                Stand(oFlareApproval.m_iStand, lblAssetGMgrStand, ddlAssetGM, assetGMBtn);
            }
            else if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
            {
                lblProdServMgr.Text = oAppUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                Stand(oFlareApproval.m_iStand, lblProdServStand, ddlProdServMgr, prodServMgrBtn);
            }
            else if (oFlareApproval.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval)
            {
                lblGMProd.Text = oAppUsersHelper.objGetUserByUserID(oFlareApproval.m_iUserId).m_sFullName;
                Stand(oFlareApproval.m_iStand, lblGMProdStand, ddlGMProd, GMprodBtn);
            }
        }
    }

    private void GetUsersByRoleId(DropDownList ddlRole, appUserRolesFlrWaiver.userRole eRole)
    {
        List<appUsers> oUsers = oAppUsersHelper.lstGetFlareWaiverUserByRole((int)eRole);
        foreach (appUsers oUser in oUsers)
        {
            ddlRole.Items.Add(new ListItem(oUser.m_sFullName, oUser.m_iUserId.ToString()));
        }
    }

    private void Stand(int iStand, Label lblStand, DropDownList theDDL, Button theButton)
    {
        if (iStand == (int)RequestStatusReporter.RequestStatusRpt.iDefault)
        {
            lblStand.Text = "";
        }
        else if (iStand == (int)RequestStatusReporter.RequestStatusRpt.Approved)
        {
            lblStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)RequestStatusReporter.RequestStatusRpt.Approved);
            lblStand.ForeColor = System.Drawing.Color.Green;
            lblStand.Font.Bold = true;
            theDDL.Enabled = false;
            theButton.Enabled = false;
        }
        else if (iStand == (int)RequestStatusReporter.RequestStatusRpt.NotApproved)
        {
            lblStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)RequestStatusReporter.RequestStatusRpt.NotApproved);
            lblStand.ForeColor = System.Drawing.Color.Red;
            lblStand.Font.Bold = true;
            theDDL.Enabled = true;
            theButton.Enabled = true;
        }
        else if (iStand == (int)RequestStatusReporter.RequestStatusRpt.Supported)
        {
            lblStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)RequestStatusReporter.RequestStatusRpt.Supported);
            lblStand.ForeColor = System.Drawing.Color.Green;
            lblStand.Font.Bold = true;
            theDDL.Enabled = false;
            theButton.Enabled = false;
        }
        else if (iStand == (int)RequestStatusReporter.RequestStatusRpt.NotSupported)
        {
            lblStand.Text = RequestStatusReporter.RequestStatusRptDesc((RequestStatusReporter.RequestStatusRpt)RequestStatusReporter.RequestStatusRpt.NotSupported);
            lblStand.ForeColor = System.Drawing.Color.Red;
            lblStand.Font.Bold = true;
            theDDL.Enabled = true;
            theButton.Enabled = true;
        }
    }
    protected void lineMgrBtn_Click(object sender, EventArgs e)
    {
        router(int.Parse(ddlLineMgr.SelectedValue), (int)appUserRolesFlrWaiver.userRole.LineManager, long.Parse(Request.QueryString["RequestId"].ToString()));
    }
    protected void prodServMgrBtn_Click(object sender, EventArgs e)
    {
        router(int.Parse(ddlProdServMgr.SelectedValue), (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr, long.Parse(Request.QueryString["RequestId"].ToString()));
    }
    protected void GMprodBtn_Click(object sender, EventArgs e)
    {
        router(int.Parse(ddlGMProd.SelectedValue), (int)appUserRolesFlrWaiver.userRole.Approval, long.Parse(Request.QueryString["RequestId"].ToString()));
    }
    protected void assetGMBtn_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
        List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(lRequestId);
        foreach (RequestFacility oRequestFacility in lstRequestFacilities)
        {
            oFacilityAssetGM = oFacilityAssetGMHelper.objGetFacilityAssetGMByFacilityId(oRequestFacility.m_iFacilityId);
            oAppUser = oAppUsersHelper.objGetUserByUserID(oFacilityAssetGM.m_iUserId);

            if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
            {
                router(int.Parse(ddlAssetGM.SelectedValue), (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore, long.Parse(Request.QueryString["RequestId"].ToString()));
                break;
            }
            else if (oAppUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
            {
                router(int.Parse(ddlAssetGM.SelectedValue), (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore, long.Parse(Request.QueryString["RequestId"].ToString()));
                break;
            }
        }   
    }

    private void router(int iUserId, int RoleID, long lRequestId)
    {
        bool bRet = oFlareApprovalHelper.ReRouteRequest(lRequestId, iUserId, RoleID);
        if (bRet)
        {
            LoadDetails(lRequestId);
            FlareWaiver oFlareWaiverRequest = oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId);

            List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
            //Get Initiator
            oCopy.Add(oAppUsersHelper.objGetUserByUserID(oFlareWaiverRequest.m_iUserId).structUserIdx);
            oCopy.Add(oSessnx.getOnlineUser.structUserIdx);

            FlareWaiverSendMail.sendMail oSendMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
            //Send mail
            appUsers oAppUserNxtApprover = oAppUsersHelper.objGetUserByUserID(iUserId);
            oSendMail.ForwardRequestForSupportApproval(oFlareWaiverRequest, oAppUserNxtApprover, oCopy);

            ajaxWebExtension.showJscriptAlert(Page, this, "Flare Waiver Request successfully routed to " + oAppUsersHelper.objGetUserByUserID(iUserId).m_sFullName);
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Flare Waiver Request not successfully routed to " + oAppUsersHelper.objGetUserByUserID(iUserId).m_sFullName + ", please try again later.");
        }
    }
}