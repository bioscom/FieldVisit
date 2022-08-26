using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_UserControl_BrightIdeasOnBehalf : aspnetUserControl
{
    FunctionMgt oFunctionMgt = new FunctionMgt();
    BenefitsMgt oBenefitsMgt = new BenefitsMgt();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    BuzLeanFocalPointHelper oBuzLeanFocalPointHelper = new BuzLeanFocalPointHelper();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    CostReductionRequest oBI500Request = new CostReductionRequest();

    BI500RequestOnBehalf o = new BI500RequestOnBehalf();
    BI500RequestOnBehalfHelper oL = new BI500RequestOnBehalfHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Page_Init()
    {
        btnSubmit.Enabled = false;
        Sponsor.ErrorMssg("Project Sponsor is required. Please, select N/A if Sponsor not found, can be updated later.");
        champion.ErrorMssg("Project Champion is required. Please, select N/A if Champion not found, can be updated later.");

        Sponsor.resetUserInfo();
        champion.resetUserInfo();

        List<Benefits> oBenefits = oBenefitsMgt.lstBenefits();
        foreach (Benefits oBenefit in oBenefits)
        {
            drpBenefit.Items.Add(new ListItem(oBenefit.m_sBenefit, oBenefit.m_iBenefitId.ToString()));
        }
    }

    protected void btnDraft_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(HFRequestId.Value) || (long.Parse(HFRequestId.Value) == 0))
            {
                if (Sponsor.thisDropDownList.SelectedValue == champion.thisDropDownList.SelectedValue)
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, " + Sponsor.thisDropDownList.SelectedItem.Text + ", cannot play dual role. Please select different actors. Thank you.");
                }
                else
                {
                    if (string.IsNullOrEmpty(HFRequestId.Value) || (long.Parse(HFRequestId.Value) == 0))
                    {
                        if (Sponsor.thisDropDownList.SelectedValue == champion.thisDropDownList.SelectedValue)
                            ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, " + Sponsor.thisDropDownList.SelectedItem.Text + ", cannot play dual role. Please select different actors. Thank you.");
                        else if (champion._SelectedValue == "-1")
                            ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Champion.");
                        else if (Sponsor._SelectedValue == "-1")
                            ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Sponsor.");
                        else
                        {
                            long lRequestId = 0;

                            BIUserTeam L = new BIUserTeam();
                            BIUserTeam oUT = L.objGetTeamByUserId(oSessnx.getOnlineUser.m_iUserId);
                            BITeams oT = new BITeams();
                            BITeams oT1 = oT.objGetTeamById(oUT.m_iTeamId);
                            BIDepartments oDept = new BIDepartments();

                            oBI500Request.dCompletionDate = dtCompletion.dtSelectedDate;
                            oBI500Request.iBenefitId = int.Parse(drpBenefit.SelectedValue);

                            oBI500Request.iFunctionId = oDept.objGetDepartmentById(oT1.m_iDepartmentId).m_iFunctionId;
                            oBI500Request.iDeptId = oT1.m_iDepartmentId;
                            oBI500Request.iTeamId = oUT.m_iTeamId;

                            oBI500Request.iProjectChampionUserId = int.Parse(champion._SelectedValue);
                            oBI500Request.iProjectSponsorUserId = int.Parse(Sponsor._SelectedValue);
                            oBI500Request.iUserId = oSessnx.getOnlineUser.m_iUserId;
                            oBI500Request.sBusinessCase = txtBizCase.Text;
                            oBI500Request.sOpportunityStmt = txtOpportunityStmt.Text;
                            oBI500Request.sRequestNumber = AutoNumberBI500.GenerateAutoNumber();
                            oBI500Request.sTitle = txtProjectTitle.Text;
                            //oBI500Request.dAmountSaved = !string.IsNullOrEmpty(txtAmountSaved.Text) ? decimal.Parse(txtAmountSaved.Text) : 0;

                            bool bRet = oBI500RequestHelper.CreateBI500Request(oBI500Request, ref lRequestId);
                            if (bRet)
                            {
                                // ------  Begin Insert Onbehalf of someone  --------

                                o.lRequestId = lRequestId;
                                o.sFullName = txtFullname.Text;
                                o.sEmailAddress = txtEmailAddress.Text;

                                oL.InsertOnBehalf(o);

                                // ------  End Insert Onbehalf  --------

                                HFRequestId.Value = lRequestId.ToString();
                                btnSubmit.Enabled = true;
                                ajaxWebExtension.showJscriptAlert(Page, this, "Bright Idea saved as draft.");
                            }
                            else
                            {
                                ajaxWebExtension.showJscriptAlert(Page, this, "Bright Idea Draft not saved. Try again later.");
                            }

                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(HFRequestId.Value) && (long.Parse(HFRequestId.Value) != 0))
            {
                if (string.IsNullOrEmpty(HFRequestId.Value) || (long.Parse(HFRequestId.Value) == 0))
                {
                    if (Sponsor.thisDropDownList.SelectedValue == champion.thisDropDownList.SelectedValue)
                        ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, " + Sponsor.thisDropDownList.SelectedItem.Text + ", cannot play dual role. Please select different actors. Thank you.");
                    else if (champion._SelectedValue == "-1")
                        ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Champion.");
                    else if (Sponsor._SelectedValue == "-1")
                        ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Sponsor.");
                    else
                    {
                        //Call update function
                        long lRequestId = long.Parse(HFRequestId.Value);

                        oBI500Request.lRequestId = lRequestId;
                        oBI500Request.dCompletionDate = dtCompletion.dtSelectedDate;
                        oBI500Request.iBenefitId = int.Parse(drpBenefit.SelectedValue);

                        BIUserTeam L = new BIUserTeam();
                        BIUserTeam oUT = L.objGetTeamByUserId(oSessnx.getOnlineUser.m_iUserId);
                        BITeams oT = new BITeams();
                        BITeams oT1 = oT.objGetTeamById(oUT.m_iTeamId);
                        BIDepartments oDept = new BIDepartments();


                        oBI500Request.iFunctionId = oDept.objGetDepartmentById(oT1.m_iDepartmentId).m_iFunctionId;
                        oBI500Request.iDeptId = oT1.m_iDepartmentId;
                        oBI500Request.iTeamId = oUT.m_iTeamId;

                        oBI500Request.iProjectChampionUserId = int.Parse(champion._SelectedValue);
                        oBI500Request.iProjectSponsorUserId = int.Parse(Sponsor._SelectedValue);
                        oBI500Request.iUserId = oSessnx.getOnlineUser.m_iUserId;
                        oBI500Request.sBusinessCase = txtBizCase.Text;
                        oBI500Request.sOpportunityStmt = txtOpportunityStmt.Text;
                        oBI500Request.sTitle = txtProjectTitle.Text;
                        //oBI500Request.dAmountSaved = !string.IsNullOrEmpty(txtAmountSaved.Text) ? decimal.Parse(txtAmountSaved.Text) : 0;

                        bool bRet = oBI500RequestHelper.UpdateBI500Request(oBI500Request);

                        if (bRet)
                        {
                            // ------  Begin Update Onbehalf of someone  --------

                            o.lRequestId = lRequestId;
                            o.sFullName = txtFullname.Text;
                            o.sEmailAddress = txtEmailAddress.Text;

                            oL.UpdateOnBehalf(o);

                            // ------  End Update Onbehalf  --------


                            ajaxWebExtension.showJscriptAlert(Page, this, "Bright Idea saved as draft.");
                        }
                        else
                        {
                            ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful, try again later.");
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(HFRequestId.Value) && (long.Parse(HFRequestId.Value) != 0))
            {
                if (string.IsNullOrEmpty(HFRequestId.Value) || (long.Parse(HFRequestId.Value) == 0))
                {
                    if (Sponsor.thisDropDownList.SelectedValue == champion.thisDropDownList.SelectedValue)
                        ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, " + Sponsor.thisDropDownList.SelectedItem.Text + ", cannot play dual role. Please select different actors. Thank you.");
                    else if (champion._SelectedValue == "-1")
                        ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Champion.");
                    else if (Sponsor._SelectedValue == "-1")
                        ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Sponsor.");
                    else
                    {
                        long lRequestId = long.Parse(HFRequestId.Value);

                        BIUserTeam L = new BIUserTeam();
                        BIUserTeam oUT = L.objGetTeamByUserId(oSessnx.getOnlineUser.m_iUserId);
                        BITeams oT = new BITeams();
                        BITeams oT1 = oT.objGetTeamById(oUT.m_iTeamId);
                        BIDepartments oDept = new BIDepartments();

                        oBI500Request.lRequestId = lRequestId;
                        oBI500Request.dCompletionDate = dtCompletion.dtSelectedDate;
                        oBI500Request.iBenefitId = int.Parse(drpBenefit.SelectedValue);

                        oBI500Request.iFunctionId = oDept.objGetDepartmentById(oT1.m_iDepartmentId).m_iFunctionId;
                        oBI500Request.iDeptId = oT1.m_iDepartmentId;
                        oBI500Request.iTeamId = oUT.m_iTeamId;

                        oBI500Request.iProjectChampionUserId = int.Parse(champion._SelectedValue);
                        oBI500Request.iProjectSponsorUserId = int.Parse(Sponsor._SelectedValue);
                        oBI500Request.iUserId = oSessnx.getOnlineUser.m_iUserId;
                        oBI500Request.sBusinessCase = txtBizCase.Text;
                        oBI500Request.sOpportunityStmt = txtOpportunityStmt.Text;
                        oBI500Request.sTitle = txtProjectTitle.Text;
                        //oBI500Request.dAmountSaved = !string.IsNullOrEmpty(txtAmountSaved.Text) ? decimal.Parse(txtAmountSaved.Text) : 0;

                        bool bt = oBI500RequestHelper.UpdateBI500Request(oBI500Request);
                        if (bt)
                        {
                            // ------  Begin Update Onbehalf of someone  --------

                            o.lRequestId = lRequestId;
                            o.sFullName = txtFullname.Text;
                            o.sEmailAddress = txtEmailAddress.Text;

                            oL.UpdateOnBehalf(o);

                            // ------  End Update Onbehalf  --------
                        }

                        //Assign the request to the Project Champion(Staff Supervisor) into the RequestApproval(Workflow) Table
                        bool bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.champion, int.Parse(champion._SelectedValue));

                        //Assign the request to the BI Team into the RequestApproval(Workflow) Table
                        bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam);
                        if (bRet)
                        {
                            oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementOrProjectChampionApproval);

                            List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
                            oReceivers.Add(oappUsersHelper.objGetUserByUserID(int.Parse(champion._SelectedValue)).structUserIdx);
                            oReceivers.Add(new structUserMailIdx("", AppConfiguration.productionBIFunctionalAccount, ""));
                            oReceivers.Add(new structUserMailIdx("", o.sEmailAddress, "")); //Copy the person onbehal of who the Bright Idea was raised.

                            //Send email to the selected Project Champion (who is the supervisor of the requestor), 
                            //that he/she has a pending Bright Idea for review/approval and copy the Initiator
                            oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

                            sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
                            oSendMail.ForwardRequestForSupportApproval(oBI500Request, oReceivers, oSessnx.getOnlineUser.structUserIdx);

                            Clear();
                            //Response.Redirect("~/App/BI500/Default.aspx");
                            ajaxWebExtension.showJscriptAlert(Page, this, "Bright Idea successfully submitted.");
                        }
                    }
                }
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful, try again later.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/App/BI500/Default.aspx");
        Response.Redirect("~/App/BI500/MyBrightIdeas.aspx");
    }

    private void ValidateUser(ASP.usercontrols_userfinder_search4user_ascx oUser, int iRoleId)
    {
        try
        {
            //1. if the selected user is not found in the Native user table(i.e. the application user table), 
            //then call the class for creating user in the application to register the user and return the database generated UserId.
            //The returned UserId will be used to register the request against the user in the Approval Table
            if (!string.IsNullOrEmpty(oUser.selectedUserDetails.m_sUserName))
            {
                appUsers oAppUser = appUsersHelper.objGetAppUserByUserName(oUser.selectedUserDetails.m_sUserName);
                if (String.IsNullOrEmpty(oAppUser.m_sFullName))
                {
                    //Define the User in the PRO_USERMGT table and return the UserID as a ref int value
                    int iUserId = 0;

                    oAppUser.m_iRoleIdFieldVisit = null;
                    oAppUser.m_iRoleIdBI = iRoleId;
                    oAppUser.m_iRoleIdContract = null;
                    oAppUser.m_iRoleIdFlr = null;
                    oAppUser.m_iRoleIdLean = null;
                    oAppUser.m_iRoleIdManHr = null;
                    oAppUser.m_sFullName = oUser.selectedUserDetails.m_sFullName;
                    oAppUser.m_sRefInd = oUser.selectedUserDetails.m_sRefInd;
                    oAppUser.m_sUserMail = oUser.selectedUserDetails.m_sUserMail;
                    oAppUser.m_sUserName = oUser.selectedUserDetails.m_sUserName;

                    bool bRet = appUsersHelper.CreateUserAccount(oAppUser, ref iUserId);
                    if (bRet)
                    {
                        sendMailFieldVisit oMail = new sendMailFieldVisit(sendMailFieldVisit.eManager());
                        oMail.UserDefinition(oAppUser);

                        RaiseRequest(iRoleId, oAppUser);
                    }
                }
                else if (!String.IsNullOrEmpty(oAppUser.m_sFullName))
                {
                    //It means the User, Project Champion, was found in the Native table
                    RaiseRequest(iRoleId, oAppUser);
                }
            }
            else
            {
                string sMessage = "";
                if (iRoleId == (int)appUsersRolesBI500.userRole.initiator)
                {
                    sMessage = "Please select Project Manager. (By Default, this should be yourself)";
                }
                else
                {
                    sMessage = "Please select " + appUsersRolesBI500.userRoleDesc((appUsersRolesBI500.userRole)iRoleId);
                }
                ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void RaiseRequest(int iRoleId, appUsers oNextApprover)
    {
        //Then Raise the request, if the user is Project Champion
        //if (iRoleId == (int)appUsersRoles.userRole.champion)
        //{

        //}
    }
    private void Clear()
    {
        drpBenefit.ClearSelection();
        champion.thisDropDownList.ClearSelection();
        Sponsor.thisDropDownList.ClearSelection();
        txtBizCase.Text = "";
        txtOpportunityStmt.Text = "";
        txtProjectTitle.Text = "";
    }
}