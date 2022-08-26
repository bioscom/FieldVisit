using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
///  Wizard Step 4: Assign Project to Function/Department Focal Point
///                 This step is used by Business Improvement Team to push the Improvement Idea to 
///                 Functional Focal Point, after review and acceptance
///                 
///  Wizard Step 5: Assign Project Champion and Sponsor
///                 This step is used by the Project Focal point, after the project has been agreed upon by the cadence review meeting, 
///                 the project Sponsor and Champion have been identified
///                 
///  Wizard Step 6: Project Sponsor's/Champion's Commitment Form
///                 This form is used by the Project Sponsor and Champion to show that they are committed to the project
///                 The project champion then continue to work the project to close out.
/// </summary>

public partial class App_BI500_CostReductionForMyAction : aspnetPage
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
        if (!IsPostBack)
        {
            PnlYes.Visible = false;
            PnlNo.Visible = false;

            PnlCadenceNo.Visible = false;
            PnlCadenceYes.Visible = false;

            PnlSponsorCommitNo.Visible = false;
            PnlSponsorCommitYes.Visible = false;

            rblPushYesNo.Items.Add(new ListItem(commonEnums.yesNoDesc(commonEnums.YesNo.Yes), ((int)commonEnums.YesNo.Yes).ToString()));
            rblPushYesNo.Items.Add(new ListItem(commonEnums.yesNoDesc(commonEnums.YesNo.No), ((int)commonEnums.YesNo.No).ToString()));

            rblApprovedYesNo.Items.Add(new ListItem(commonEnums.yesNoDesc(commonEnums.YesNo.Yes), ((int)commonEnums.YesNo.Yes).ToString()));
            rblApprovedYesNo.Items.Add(new ListItem(commonEnums.yesNoDesc(commonEnums.YesNo.No), ((int)commonEnums.YesNo.No).ToString()));

            rblToProjectChampionYesNo.Items.Add(new ListItem(commonEnums.yesNoDesc(commonEnums.YesNo.Yes), ((int)commonEnums.YesNo.Yes).ToString()));
            rblToProjectChampionYesNo.Items.Add(new ListItem(commonEnums.yesNoDesc(commonEnums.YesNo.No), ((int)commonEnums.YesNo.No).ToString()));
        }
    }
    protected void Wizard1_PreRender(object sender, EventArgs e)
    {
        Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
        SideBarList.DataSource = Wizard1.WizardSteps;
        SideBarList.DataBind();
    }
    protected string GetClassForWizardStep(object wizardStep)
    {
        WizardStep step = wizardStep as WizardStep;

        if (step == null)
        {
            return "";
        }
        int stepIndex = Wizard1.WizardSteps.IndexOf(step);

        if (stepIndex < Wizard1.ActiveStepIndex)
        {
            return "prevStep";
        }
        else if (stepIndex > Wizard1.ActiveStepIndex)
        {
            return "nextStep";
        }
        else
        {
            return "currentStep";
        }
    }

    protected void Step_Click(object sender, EventArgs e)
    {
        LinkButton btnStep = (LinkButton)sender;
        string id = btnStep.Text;

        WizardStepBase Pending = (WizardStepBase)Wizard1.FindControl("Pending");
        WizardStepBase Supported = (WizardStepBase)Wizard1.FindControl("Supported");
        WizardStepBase Rejected = (WizardStepBase)Wizard1.FindControl("Rejected");

        WizardStepBase AssignApprovers = (WizardStepBase)Wizard1.FindControl("AssignApprovers");
        WizardStepBase WizFocalPoint = (WizardStepBase)Wizard1.FindControl("WizFocalPoint");
        WizardStepBase RequestDetails = (WizardStepBase)Wizard1.FindControl("RequestDetails");
        WizardStepBase ProjMgrsCommitment = (WizardStepBase)Wizard1.FindControl("ProjMgrsCommitment");
       

        if (btnStep.CssClass == "prevStep" || btnStep.CssClass == "nextStep" || btnStep.CssClass == "currentStep")
        {
            switch (id)
            {
                case "Pending My Action": Wizard1.MoveTo(Pending); break;
                case "Supported": Wizard1.MoveTo(Supported); break;
                case "Rejected": Wizard1.MoveTo(Rejected); break;

                case "Assign Focal Point": ajaxWebExtension.showJscriptAlert(Page, this, "Click Pending My Action tab, Click on Assign Focal Point against any of the items you want to assign Focal Point."); break;
                case "Assign Approvers": ajaxWebExtension.showJscriptAlert(Page, this, "Click Pending My Action tab, Click on Assign Managers against any of the items you want to assing work stream managers."); break;
                case "Commitment Form": ajaxWebExtension.showJscriptAlert(Page, this, "Go to Improvement Ideas tab, Click on View Progress... against any of the items you want to view Progress Report."); break;
                case "Project Progress": ajaxWebExtension.showJscriptAlert(Page, this, "Click any of the previous tabs, Click on View Progress... against any of the items you want to view Progress Report."); break;
                default: Wizard1.MoveTo(Pending); break;
            }
        }
    }

    protected void OnFinish(object sender, WizardNavigationEventArgs e)
    {
        WizardStepType t = Wizard1.WizardSteps[e.NextStepIndex].StepType;
        if (t == WizardStepType.Finish)
        {
            //Wizard1.Visible = false;
            //btnstart.Visible = true;
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/BI500/CostReductionForMyAction.aspx");
    }

    #region <<==================================== Business Improvement Team Push to Focal Point (Wizard Step 4) ===========================================>>
    protected void rblPushYesNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblPushYesNo.SelectedValue == ((int)commonEnums.YesNo.Yes).ToString())
        {
            PnlYes.Visible = true;
            PnlNo.Visible = false;
        }
        else if (rblPushYesNo.SelectedValue == ((int)commonEnums.YesNo.No).ToString())
        {
            PnlYes.Visible = false;
            PnlNo.Visible = true;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(HFRequestIdFP.Value);
            
            bool bRet = oBI500RequestHelper.MaintainInDatabase(lRequestId, txtMaintainInDatabase.Text);
            if (bRet)
            {
                MainTainInDatabaseMail(lRequestId);

                oRequestDetails3.Init_Control(lRequestId); //Refresh the control
                ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea successfully maintained in the database and the Initiator has been notified.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void AssignFocalPoint_Click(object sender, EventArgs e)
    {
        //Note: in this work flow, it is the sole responsiblity of the Business Improvement team(BIM OFFSHORE and ONSHORE) to assign Focal Point
        try
        {
            bool bRet = false;
            long lRequestId = long.Parse(HFRequestIdFP.Value);
            int iFocalPoint = int.Parse(FocalPoint._SelectedValue);

            BI500ApprovalHelper ok = new BI500ApprovalHelper();
            bRet = ok.ActionBIRequest(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam, oSessnx.getOnlineUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Supported, txtCommentFP.Text);
            if (bRet)
            {
                bRet = oBI500RequestHelper.AssignFocalPoint(lRequestId, iFocalPoint);
                if (bRet)
                {
                    //Assign the request to Functional/Department FocalPoint into the RequestApproval(Workflow) Table
                    oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.focalPoint, iFocalPoint);

                    //Update Improvement Idea Status
                    oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction);

                    //Business Improvement Team moves project to Focal Point
                    oBI500RequestHelper.UpdateStageGate(lRequestId, (int)BIRequestStatus.StageGates.StageGate2);

                    //Send mail to Focal Point to notify him/her of the project
                    List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
                    List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
                    oReceivers.Add(oappUsersHelper.objGetUserByUserID(iFocalPoint).structUserIdx); //Focal Point

                    oCopy = oBI500RequestHelper.BIReviewersEmail();
                    CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
                    oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iUserId).structUserIdx); //Copy Initiator

                    sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
                    oSendMail.ForwardImprovementIdeaForSupportApproval(o, oReceivers, oCopy);

                    oRequestDetails3.Init_Control(lRequestId); //Refresh the control
                    ajaxWebExtension.showJscriptAlert(Page, this, "Focal Point successfully assigned to Improvement Idea.");
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Not successful. Try again later.");
                }
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Not successful. Try again later.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    #endregion



    #region <<==================================== Focal Point (Weekly Cadence Review meeting) (Wizard Step 5) ===========================================>>
    protected void rblApprovedYesNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblApprovedYesNo.SelectedValue == ((int)commonEnums.YesNo.Yes).ToString())
        {
            PnlCadenceYes.Visible = true;
            PnlCadenceNo.Visible = false;
        }
        else if (rblApprovedYesNo.SelectedValue == ((int)commonEnums.YesNo.No).ToString())
        {
            PnlCadenceYes.Visible = false;
            PnlCadenceNo.Visible = true;
        }
    }
    protected void btnCadence_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(HFRequestId2.Value);

            bool bRet = oBI500RequestHelper.MaintainInDatabase(lRequestId, txtCadenceComment.Text);
            if (bRet)
            {
                MainTainInDatabaseMail(lRequestId);

                oRequestDetails2.Init_Control(lRequestId); //Refresh the control
                ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea successfully maintained in the database and the Initiator and Business Improvement team have been notified.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void Assign_Click(object sender, EventArgs e)
    {
        ///============================================================================
        ///======== Focal Point uses this module to assign project to =================
        ///======== Initiative Lead, Work Stream Owner and Work Stream Sponsor ========
        ///============================================================================

        try
        {
            if ((Sponsor.thisDropDownList.SelectedValue == champion.thisDropDownList.SelectedValue) || (Sponsor.thisDropDownList.SelectedValue == InitiativeLead.thisDropDownList.SelectedValue) || (InitiativeLead.thisDropDownList.SelectedValue == champion.thisDropDownList.SelectedValue))
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, " + Sponsor.thisDropDownList.SelectedItem.Text + ", cannot play multiple role in a project. Please select different actors. Thank you.");
            }
            else if ((oSessnx.getOnlineUser.m_iUserId.ToString() == champion._SelectedValue) || (oSessnx.getOnlineUser.m_iUserId.ToString() == Sponsor._SelectedValue) || (oSessnx.getOnlineUser.m_iUserId.ToString() == InitiativeLead._SelectedValue))
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Sorry as a Focal Point, you cannot assign yourself as Initiative Lead, Work Stream Owner or Work Stream Sponsor.");
            }
            else if (champion._SelectedValue == "-1") ajaxWebExtension.showJscriptAlert(Page, this, "Please select Work Stream owner.");
            else if (Sponsor._SelectedValue == "-1") ajaxWebExtension.showJscriptAlert(Page, this, "Please select Work Stream Sponsor.");
            else if (InitiativeLead._SelectedValue == "-1") ajaxWebExtension.showJscriptAlert(Page, this, "Please select Initiative Lead.");
            else
            {
                long lRequestId = long.Parse(HFRequestId2.Value);
                int iChampion = int.Parse(champion._SelectedValue);
                int iSponsor = int.Parse(Sponsor._SelectedValue);
                int iInitiativeLead = int.Parse(InitiativeLead._SelectedValue);

                BI500ApprovalHelper ok = new BI500ApprovalHelper();
                bool bRet = ok.ActionBIRequest(lRequestId, (int)appUsersRolesBI500.userRole.focalPoint, oSessnx.getOnlineUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Supported, txtComments.Text);
                if (bRet)
                {
                    bRet = oBI500RequestHelper.AssignInitiativeLeadChampionSponsor(lRequestId, iSponsor, iChampion, iInitiativeLead);
                    if (bRet)
                    {
                        //Assign the request to Project Sponsor into the RequestApproval(Workflow) Table
                        oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.sponsor, iSponsor);

                        //Focal Point moves project to Initiative Lead, work stream owner and work strem sponsor
                        oBI500RequestHelper.UpdateStageGate(lRequestId, (int)BIRequestStatus.StageGates.StageGate3);

                        //Update Improvement Idea Status
                        oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval);

                        //Send mail to Work Stream Sponsor to notify him/her of the project
                        List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
                        List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
                        oReceivers.Add(oappUsersHelper.objGetUserByUserID(iSponsor).structUserIdx);  //Work stream Sponsor

                        oCopy = oBI500RequestHelper.BIReviewersEmail();

                        CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
                        oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iUserId).structUserIdx); //Copy Initiator
                        oCopy.Add(oSessnx.getOnlineUser.structUserIdx); //Copy Functional Focal Point

                        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
                        oSendMail.ForwardImprovementIdeaForSupportApproval(o, oReceivers, oCopy);
                        oRequestDetails2.Init_Control(lRequestId); //Refresh the control
                        ajaxWebExtension.showJscriptAlert(Page, this, "Initiative Lead, Work Stream Owner and Work Stream Sponsor were successfully assigned to this Improvement Idea.");
                    }
                    else
                    {
                        ajaxWebExtension.showJscriptAlert(Page, this, "Not successful. Try again later.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    #endregion



    #region  <<==================================== Project Sponsor/Champion (Wizard Step 6) ===========================================>>
    protected void rblToProjectChampion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblToProjectChampionYesNo.SelectedValue == ((int)commonEnums.YesNo.Yes).ToString())
        {
            PnlSponsorCommitYes.Visible = true;
            PnlSponsorCommitNo.Visible = false;
        }
        else if (rblToProjectChampionYesNo.SelectedValue == ((int)commonEnums.YesNo.No).ToString())
        {
            PnlSponsorCommitYes.Visible = false;
            PnlSponsorCommitNo.Visible = true;
        }
    }
    
    protected void btnSponsorMaintain_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(HFRequestIdProjCommitment.Value);

            bool bRet = oBI500RequestHelper.MaintainInDatabase(lRequestId, txtSponsorMaintain.Text);
            if (bRet)
            {
                MainTainInDatabaseMail(lRequestId);
                oRequestDetailsProjCommit.Init_Control(lRequestId); //Refresh the control
                ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea successfully maintained in the database and the Initiator has been notified.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnSendToChampion_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(HFRequestIdProjCommitment.Value);
            CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
            BI500ApprovalHelper ok = new BI500ApprovalHelper();

            if (oSessnx.getOnlineUser.m_iUserId == o.iProjectSponsorUserId)
            {
                bool bRet = ok.ActionBIRequest(lRequestId, (int)appUsersRolesBI500.userRole.sponsor, oSessnx.getOnlineUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Supported, txtSponsorComments.Text);

                //Assign the request to Project Champion into the RequestApproval(Workflow) Table
                oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.champion, o.iProjectChampionUserId);

                //Update Improvement Idea Status
                oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport);

                //Send mail to Focal Point to notify him/her of the project
                List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
                List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
                oReceivers.Add(oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId).structUserIdx); //Project Champion
                //oReceivers.Add(oappUsersHelper.objGetUserByUserID(iSponsor).structUserIdx);  //Project Sponsor

                oCopy = oBI500RequestHelper.BIReviewersEmail();
                oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iUserId).structUserIdx); //Copy Initiator
                oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId).structUserIdx); //Copy Functional Focal Point

                sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
                oSendMail.ForwardImprovementIdeaForSupportApproval(o, oReceivers, oCopy);
                oRequestDetailsProjCommit.Init_Control(lRequestId); //Refresh the control
                ajaxWebExtension.showJscriptAlert(Page, this, "Work Stream Owner has been notified of the Improvement Idea.");
            }
            else if (oSessnx.getOnlineUser.m_iUserId == o.iProjectChampionUserId)
            {
                //This will serve as the final approval for now. At this stage the project goes to the Project Champion Commitment intray and goes to work.
                bool bRet = ok.ActionBIRequest(lRequestId, (int)appUsersRolesBI500.userRole.champion, oSessnx.getOnlineUser.m_iUserId, (int)BIRequestStatus.RequestStatusRpt.Approved, txtSponsorComments.Text);

                //Update Improvement Idea Status
                oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.InitiativeLead);

                //Send mail to all Involved in the approval process, that it has been committed to.
                List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
                List<structUserMailIdx> oCopy = new List<structUserMailIdx>();          
                oReceivers.Add(oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId).structUserIdx); //Project Sponsor
                oReceivers.Add(oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId).structUserIdx);  //Function Focal Point
                oReceivers.Add(oappUsersHelper.objGetUserByUserID(o.iInitiativeLeadUserId).structUserIdx);  //Initiative lead to start working the project

                oCopy = oBI500RequestHelper.BIReviewersEmail();
                oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iUserId).structUserIdx); //Copy Initiator

                sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
                oSendMail.ForwardImprovementIdeaForSupportApproval(o, oReceivers, oCopy);
                oRequestDetailsProjCommit.Init_Control(lRequestId); //Refresh the control
                ajaxWebExtension.showJscriptAlert(Page, this, "Project sucessfully committed to and Initiative Lead (IL) has been notified.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    
    #endregion

    private void MainTainInDatabaseMail(long lRequestId)
    {
        CostReductionRequest o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        //Send mail to the Initiator and copy all members of Business Improvement.
        List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
        oReceivers.Add(oappUsersHelper.objGetUserByUserID(o.iUserId).structUserIdx); //Send to Initiator

        List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
        oCopy = oBI500RequestHelper.BIReviewersEmail();

        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.MaintainedInDatabase(o, oReceivers, oCopy);
    }
}