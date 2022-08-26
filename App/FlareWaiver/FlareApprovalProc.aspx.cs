using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class FlareApprovalProc : aspnetPage
{
    FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();
    FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
    appUsersHelper oAppUsersHelper = new appUsersHelper();
    FacilityAssetGMHelper oFacilityAssetGMHelper = new FacilityAssetGMHelper();
    FacilityAssetGM oFacilityAssetGM = new FacilityAssetGM();
    appUsers oAppUser = new appUsers();
    RequestFacilityHelper oRequestFacilityHelper = new RequestFacilityHelper();
    Facility oF = new Facility();

    bool bRet = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        string sToken = "";
        try
        {
            string[] sPageAccess = { appUserRolesFlrWaiver.userRole.LineManager.ToString(), appUserRolesFlrWaiver.userRole.AssurancePSMgr.ToString(),
                                     appUserRolesFlrWaiver.userRole.AssuranceOnshore.ToString(), appUserRolesFlrWaiver.userRole.AssuranceOffshore.ToString(),
                                     appUserRolesFlrWaiver.userRole.Approval.ToString(), appUserRolesFlrWaiver.userRole.Administrator.ToString() };
            appUserRolesFlrWaiver oAccess = new appUserRolesFlrWaiver();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUserRolesFlrWaiver.userRole)this.oSessnx.getOnlineUser.m_iRoleIdFlr);

            if (oSessnx.getOnlineUser.m_iRoleIdFlr != (int)appUserRolesFlrWaiver.userRole.Initiator) sToken = "tCntAppr";
            if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx?Msg=" + sToken);

            if (!IsPostBack)
            {
                if (Request.QueryString["RequestId"] != null)
                {
                    long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                    FlareWaiver oFlareWaiver = oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId);
                    FlareApproval oFlareApproval = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, (int)oSessnx.getOnlineUser.m_iRoleIdFlr);

                    oRequestDetails1.Init_Control(oFlareWaiver);

                    approverLabel.Text = appUserRolesFlrWaiver.userRoleDesc((appUserRolesFlrWaiver.userRole)oSessnx.getOnlineUser.m_iRoleIdFlr);
                    if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval)
                    {
                        rdbSupport.Items.Add(new ListItem(RequestStatusReporter.RequestStatusRptDesc(RequestStatusReporter.RequestStatusRpt.Approved), ((int)RequestStatusReporter.RequestStatusRpt.Approved).ToString()));
                        rdbSupport.Items.Add(new ListItem(RequestStatusReporter.RequestStatusRptDesc(RequestStatusReporter.RequestStatusRpt.NotApproved), ((int)RequestStatusReporter.RequestStatusRpt.NotApproved).ToString()));
                    }
                    else
                    {
                        rdbSupport.Items.Add(new ListItem(RequestStatusReporter.RequestStatusRptDesc(RequestStatusReporter.RequestStatusRpt.Supported), ((int)RequestStatusReporter.RequestStatusRpt.Supported).ToString()));
                        rdbSupport.Items.Add(new ListItem(RequestStatusReporter.RequestStatusRptDesc(RequestStatusReporter.RequestStatusRpt.NotSupported), ((int)RequestStatusReporter.RequestStatusRpt.NotSupported).ToString()));
                    }

                    txtComment.Text = oFlareApproval.m_sComments;
                    foreach (ListItem li in rdbSupport.Items)
                    {
                        if (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Approved)
                        {
                            if (int.Parse(li.Value) == (int)RequestStatusReporter.RequestStatusRpt.Approved)
                            {
                                li.Selected = true;
                            }
                        }
                        else if (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.NotApproved)
                        {
                            if (int.Parse(li.Value) == (int)RequestStatusReporter.RequestStatusRpt.NotApproved)
                            {
                                li.Selected = true;
                            }
                        }
                        else if (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Supported)
                        {
                            if (int.Parse(li.Value) == (int)RequestStatusReporter.RequestStatusRpt.Supported)
                            {
                                li.Selected = true;
                            }
                        }
                        else if (oFlareApproval.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.NotSupported)
                        {
                            if (int.Parse(li.Value) == (int)RequestStatusReporter.RequestStatusRpt.NotSupported)
                            {
                                li.Selected = true;
                            }
                        }
                    }

                    if (oFlareWaiver.m_sWorkOrder != "No Work Order attached!!!")
                    {
                        WorkOrder1.LoadFileFromWorkOrder(oFlareWaiver.m_sWorkOrder);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void closeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
            AssuranceApprovalWorkflow(lRequestId);
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void AssuranceApprovalWorkflow(long lRequestId)
    {
        int iStand = int.Parse(rdbSupport.SelectedValue);
        FlareWaiver o = oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId);
        List<structUserMailIdx> oCopy = new List<structUserMailIdx>();

        //Get all that have received the request for support/or approval
        List<FlareApproval> lstFlareApprovers = oFlareApprovalHelper.lstGetFlareApprovalbyRequestId(lRequestId);
        foreach (FlareApproval oApprover in lstFlareApprovers) oCopy.Add(oAppUsersHelper.objGetUserByUserID(oApprover.m_iUserId).structUserIdx);
           
        //Also get all the administrators and copy them.
        List<appUsers> lstFlrWaiverAdmins = oAppUsersHelper.lstGetFlareWaiverUserByRole((int)appUserRolesFlrWaiver.userRole.Administrator);
        foreach (appUsers oAppUser in lstFlrWaiverAdmins) oCopy.Add(oAppUser.structUserIdx);

        LineManagerSupport(lRequestId, iStand, o, oCopy);
        AssuranceReviewPSMgr(lRequestId, iStand, o, oCopy);
        AssuranceReview(lRequestId, iStand, o, oCopy);
        FinalApproval(lRequestId, iStand, o, oCopy);
    }
	
    private void LineManagerSupport(long lRequestId, int iStand, FlareWaiver oFlareWaiverRequest, List<structUserMailIdx> oCopy)
    {
        if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
        {
            //Note: The movement of the request from here to either GM Offshore or GM Onshore depends on the facility where the Gas Flare is going to take place.
            //check through the flare request to know which facility(ies) was/were selected

            List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(lRequestId);
            foreach (RequestFacility oRequestFacility in lstRequestFacilities)
            {
                if (Facility.objGetFacilityById(oRequestFacility.m_iFacilityId).m_iLocation == (int)commonEnums.OU.SPDC)
                {
                    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AssuranceReviewSupport, (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore, oFlareWaiverRequest, oCopy);
                    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AssuranceReviewSupport, (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr, oFlareWaiverRequest, oCopy);
                    break;
                }
                else if (Facility.objGetFacilityById(oRequestFacility.m_iFacilityId).m_iLocation == (int)commonEnums.OU.SNEPCO)
                {
                    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AssuranceReviewSupport, (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore, oFlareWaiverRequest, oCopy);
                    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AssuranceReviewSupport, (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr, oFlareWaiverRequest, oCopy);
                    break;
                }
            }
        }
    }

    private void AssuranceReview(long lRequestId, int iStand, FlareWaiver oFlareWaiverRequest, List<structUserMailIdx> oCopy)
    {
        if ((oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore) || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore))
        {
            if(oFlareWaiverRequest.m_iInOutBusinessPlan == (int)commonEnums.BusinessPlan.Scheduled)
            {
                Approved(lRequestId, iStand, oFlareWaiverRequest, oCopy);
            }
            else if (oFlareWaiverRequest.m_iInOutBusinessPlan == (int)commonEnums.BusinessPlan.Unscheduled)
            {
                Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AwaitsFinalApproval, (int)appUserRolesFlrWaiver.userRole.Approval, oFlareWaiverRequest, oCopy);
            }

            ////Check if PS manager has supported
            //FlareApproval o = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr);
            //if (o.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Supported)
            //{
            //    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AwaitsFinalApproval, (int)appUserRolesFlrWaiver.userRole.Approval, oFlareWaiverRequest, oCopy);
            //}
            //else
            //{
            //    Supported(lRequestId, iStand, oFlareWaiverRequest, oCopy);
            //}
        }
    }

    private void AssuranceReviewPSMgr(long lRequestId, int iStand, FlareWaiver oFlareWaiverRequest, List<structUserMailIdx> oCopy)
    {
        if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
        {
            //Determine the source of the Flare Request            
            var oRequestFacilityHelper = new RequestFacilityHelper();
            List<RequestFacility> olst = oRequestFacilityHelper.lstGetFacilitiesByRequestId(lRequestId);
            foreach (RequestFacility r in olst)
            {
                if (Facility.objGetFacilityById(r.m_iFacilityId).m_iLocation == (int)commonEnums.OU.SNEPCO)
                {
                    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AssuranceReviewSupport, (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore, oFlareWaiverRequest, oCopy);
                    break;
                }
                else if (Facility.objGetFacilityById(r.m_iFacilityId).m_iLocation == (int)commonEnums.OU.SPDC)
                {
                    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AssuranceReviewSupport, (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore, oFlareWaiverRequest, oCopy);
                    break;
                }
            }

            //Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AwaitsFinalApproval, (int)appUserRolesFlrWaiver.userRole.Approval, oFlareWaiverRequest, oCopy);

            ////Check if GMP SPDC or SNEPCo has supported
            //FlareApproval o = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore);
            //if (o.m_lRequestId == 0) o = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore);

            //if (o.m_iStand == (int)RequestStatusReporter.RequestStatusRpt.Supported)
            //{
            //    Supported(lRequestId, iStand, (int)RequestStatusReporter.RequestStatusRpt.AwaitsFinalApproval, (int)appUserRolesFlrWaiver.userRole.Approval, oFlareWaiverRequest, oCopy);
            //}
            //else
            //{
            //    Supported(lRequestId, iStand, oFlareWaiverRequest, oCopy);
            //}
        }
    }

    private void FinalApproval(long lRequestId, int iStand, FlareWaiver oFlareWaiverRequest, List<structUserMailIdx> oCopy)
    {
        if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval)
        {
            Approved(lRequestId, iStand, oFlareWaiverRequest, oCopy);
        }
    }

    private void Supported(long lRequestId, int iStand, int iStatus, int iNxtRoleId, FlareWaiver oFlareWaiverRequest, List<structUserMailIdx> oCopy)
    {
        try
        {
            FlareWaiverSendMail.sendMail oSendMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
            if (int.Parse(rdbSupport.SelectedValue) == (int)RequestStatusReporter.RequestStatusRpt.Supported)
            {
                appUsers oAppUserNxtApprover = oAppUsersHelper.objGetDeligatedUserByRole(iNxtRoleId);
                if (!String.IsNullOrEmpty(oAppUserNxtApprover.m_sFullName))
                {
                    bRet = oFlareApprovalHelper.ActionFlareWaiverRequest(lRequestId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text); //If a deligated person is found then action request
                    bRet = oFlareWaiverRequestHelper.AssignRequestToNextApprover(lRequestId, iNxtRoleId, oAppUserNxtApprover.m_iUserId); //Assign Request to next approval
                    oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text); //Create an Audit Trail
                    oFlareWaiverRequestHelper.UpdateRequestStatus(lRequestId, iStatus);  //Update Request Status
                    oSendMail.ForwardRequestForSupportApproval(oFlareWaiverRequest, oAppUserNxtApprover, oCopy); //Send mail

                    Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");
                }
                else
                {
                    string sDeligate = appUserRolesFlrWaiver.userRoleDesc((appUserRolesFlrWaiver.userRole)iNxtRoleId);
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, " + sDeligate + " not found to forward this request for support/approval. Please contact the Administrators to define a deligate " + sDeligate);
                }
            }
            else if (int.Parse(rdbSupport.SelectedValue) == (int)RequestStatusReporter.RequestStatusRpt.NotSupported)
            {
                if (string.IsNullOrEmpty(txtComment.Text))
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Please enter reason why not supported");
                }
                else
                {
                    //Action Request
                    bRet = oFlareApprovalHelper.ActionFlareWaiverRequest(lRequestId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);

                    if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByLineManager; }
                    else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOffShore; }
                    else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOnShore; }
                    else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByProductionServiceManager; }

                    oFlareWaiverRequestHelper.UpdateRequestStatus(lRequestId, iStatus); //Update Request Status
                    //oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text);
                    oSendMail.RequestNotSupportedApproved(oFlareWaiverRequest, oSessnx.getOnlineUser, txtComment.Text, oCopy);
                    Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    //private void Supported(long lRequestId, int iStand, FlareWaiver oFlareWaiverRequest, List<structUserMailIdx> oCopy)
    //{
    //    try
    //    {
    //        FlareWaiverSendMail.sendMail oSendMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
    //        if (int.Parse(rdbSupport.SelectedValue) == (int)RequestStatusReporter.RequestStatusRpt.Supported)
    //        {
    //            bRet = oFlareApprovalHelper.ActionFlareWaiverRequest(lRequestId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text); //If a deligated person is found then action request
    //            oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text); //Create an Audit Trail
    //            oSendMail.RequestSupported(oFlareWaiverRequest, oSessnx.getOnlineUser, oCopy); //Send mail

    //            Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");
    //        }
    //        else if (int.Parse(rdbSupport.SelectedValue) == (int)RequestStatusReporter.RequestStatusRpt.NotSupported)
    //        {
    //            if (string.IsNullOrEmpty(txtComment.Text))
    //            {
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Please enter reason why not supported");
    //            }
    //            else
    //            {
    //                //Action Request
    //                bRet = oFlareApprovalHelper.ActionFlareWaiverRequest(lRequestId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);

    //                int iStatus = 0;
    //                if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByLineManager; }
    //                else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOffShore; }
    //                else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByGMOnShore; }
    //                else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr) { iStatus = (int)RequestStatusReporter.RequestStatusRpt.NotSupportedByProductionServiceManager; }

    //                oFlareWaiverRequestHelper.UpdateRequestStatus(lRequestId, iStatus); //Update Request Status
    //                //oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text);
    //                oSendMail.RequestNotSupportedApproved(oFlareWaiverRequest, oSessnx.getOnlineUser, txtComment.Text, oCopy);
    //                Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        appMonitor.logAppExceptions(ex);
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    private void Approved(long lRequestId, int iStand, FlareWaiver oFlareWaiverRequest, List<structUserMailIdx> oCopy)
    {
        try
        {
            FlareWaiverSendMail.sendMail oSendMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
            if (int.Parse(rdbSupport.SelectedValue) == (int)RequestStatusReporter.RequestStatusRpt.Approved)
            {
                bRet = oFlareApprovalHelper.ActionFlareWaiverRequest(lRequestId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);
                //oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text);
                //Update Request Status and flarewaiver effective startdate
                oFlareWaiverRequestHelper.UpdateRequestStatus(lRequestId, (int)RequestStatusReporter.RequestStatusRpt.Approved);
                oFlareWaiverRequestHelper.UpdateRequestApprovedByGMProduction(lRequestId, oSessnx.getOnlineUser.m_iUserId, oFlareWaiverRequest);
                //Send mail
                oSendMail.RequestApproved(oFlareWaiverRequest, oSessnx.getOnlineUser, oCopy);
                Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");
            }
            else if (int.Parse(rdbSupport.SelectedValue) == (int)RequestStatusReporter.RequestStatusRpt.NotApproved)
            {
                if (string.IsNullOrEmpty(txtComment.Text))
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Please enter reason why not approved.");
                }
                else
                {
                    //Action Request
                    bRet = oFlareApprovalHelper.ActionFlareWaiverRequest(lRequestId, oSessnx.getOnlineUser.m_iUserId, iStand, txtComment.Text);
                    oFlareWaiverRequestHelper.UpdateRequestStatus(lRequestId, (int)RequestStatusReporter.RequestStatusRpt.NotApprovedByGMProduction);

                    //oFlareApprovalHelper.ActionFlareWaiverRequestAuditTrail(lRequestId, iStand, txtComment.Text);
                    oSendMail.RequestNotSupportedApproved(oFlareWaiverRequest, oSessnx.getOnlineUser, txtComment.Text, oCopy);
                    Response.Redirect("~/App/FlareWaiver/GasFlarePending.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}