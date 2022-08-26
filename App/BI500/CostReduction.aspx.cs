using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_CostReduction : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
        if (!IsPostBack)
        {
           
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
        WizardStepBase Approved = (WizardStepBase)Wizard1.FindControl("Approved");
        WizardStepBase Rejected = (WizardStepBase)Wizard1.FindControl("Rejected");
        WizardStepBase RequestDetails = (WizardStepBase)Wizard1.FindControl("RequestDetails");

        if (btnStep.CssClass == "prevStep" || btnStep.CssClass == "nextStep" || btnStep.CssClass == "currentStep")
        {
            switch (id)
            {
                case "Pending Improvement Ideas": Wizard1.MoveTo(Pending); break;
                case "Approved Improvement Ideas": Wizard1.MoveTo(Approved); break;
                case "Rejected Improvement Ideas": Wizard1.MoveTo(Rejected); break;
                case "Project Progress": ajaxWebExtension.showJscriptAlert(Page, this, "Go to Improvement Ideas tab, Click on View Progress... against any of the items you want to view Progress Report."); break;
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

    //Business codes start here...

    //protected void btnDraft_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (string.IsNullOrEmpty(HFRequestId.Value) || (long.Parse(HFRequestId.Value) == 0))
    //        {
    //            long lRequestId = 0;
    //            o.iBenefitId = int.Parse(drpBenefit.SelectedValue);

    //            o.iTeamId = int.Parse(ddlTeam.SelectedValue);
    //            o.iDeptId = oT.objGetTeamById(o.iTeamId).m_iDepartmentId;
    //            o.iFunctionId = oD.objGetDepartmentById(o.iDeptId).m_iFunctionId;

    //            o.iUserId = oSessnx.getOnlineUser.m_iUserId;
    //            o.sBusinessCase = txtBizCase.Text;
    //            o.sOpportunityStmt = txtOpportunityStmt.Text;
    //            o.sRequestNumber = AutoNumberBI500.GenerateAutoNumber().Replace("BI", "CR"); //BI for Bright Idea, CR for Cost Reduction
    //            o.sTitle = txtProjectTitle.Text;

    //            bool bRet = oBI500RequestHelper.CreateCostReductionIdea(o, ref lRequestId);
    //            if (bRet)
    //            {
    //                HFRequestId.Value = lRequestId.ToString();
    //                btnSubmit.Enabled = true;
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea saved as draft.");
    //            }
    //            else
    //            {
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea Draft not saved. Try again later.");
    //            }
    //        }
    //        else if (!string.IsNullOrEmpty(HFRequestId.Value) && (long.Parse(HFRequestId.Value) != 0))
    //        {

    //            //Call update function
    //            long lRequestId = long.Parse(HFRequestId.Value);

    //            o.lRequestId = lRequestId;
    //            o.iBenefitId = int.Parse(drpBenefit.SelectedValue);

    //            o.iTeamId = int.Parse(ddlTeam.SelectedValue);
    //            o.iDeptId = oT.objGetTeamById(o.iTeamId).m_iDepartmentId;
    //            o.iFunctionId = oD.objGetDepartmentById(o.iDeptId).m_iFunctionId;

    //            o.iUserId = oSessnx.getOnlineUser.m_iUserId;
    //            o.sBusinessCase = txtBizCase.Text;
    //            o.sOpportunityStmt = txtOpportunityStmt.Text;
    //            o.sTitle = txtProjectTitle.Text;

    //            bool bRet = oBI500RequestHelper.UpdateCostReductionIdea(o);

    //            if (bRet)
    //            {
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea saved as draft.");
    //            }
    //            else
    //            {
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful, try again later.");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(HFRequestId.Value) && (long.Parse(HFRequestId.Value) != 0))
    //        {
    //            long lRequestId = long.Parse(HFRequestId.Value);

    //            o.lRequestId = lRequestId;
    //            o.iBenefitId = int.Parse(drpBenefit.SelectedValue);

    //            o.iTeamId = int.Parse(ddlTeam.SelectedValue);
    //            o.iDeptId = oT.objGetTeamById(o.iTeamId).m_iDepartmentId;
    //            o.iFunctionId = oD.objGetDepartmentById(o.iDeptId).m_iFunctionId;

    //            o.iUserId = oSessnx.getOnlineUser.m_iUserId;
    //            o.sBusinessCase = txtBizCase.Text;
    //            o.sOpportunityStmt = txtOpportunityStmt.Text;
    //            o.sTitle = txtProjectTitle.Text;

    //            bool bt = oBI500RequestHelper.UpdateCostReductionIdea(o);
    //            Clear();

    //            //Assign the request to the Project Champion(Staff Supervisor) into the RequestApproval(Workflow) Table
    //            ///bool bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.champion, int.Parse(champion._SelectedValue));

    //            //Assign the request to the BI Team into the RequestApproval(Workflow) Table
    //            bool bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam);
    //            if (bRet)
    //            {
    //                oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport);

    //                List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();
    //                List<BIReviewers> lstBIReviewers = BuzBILeanReviewers.lstGetBILeanReviewers();
    //                foreach (BIReviewers oR in lstBIReviewers)
    //                {
    //                    oReceivers.Add(oappUsersHelper.objGetUserByUserID(oR.m_iUserId).structUserIdx);
    //                }
    //                // We might obtain a functional account later in the future for this process.
    //                //oReceivers.Add(new structUserMailIdx("", AppConfiguration.productionBIFunctionalAccount, ""));

    //                o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
    //                sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
    //                oSendMail.ForwardRequestForSupportApproval(o, oReceivers, oSessnx.getOnlineUser.structUserIdx);
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea successfully submitted.");
    //                oMyPendingRequests1.Page_Init();
    //                Wizard1.ActiveStepIndex = 1;
    //            }
    //        }
    //        else
    //        {
    //            ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful, try again later.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    //protected void Assign_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (Sponsor.thisDropDownList.SelectedValue == champion.thisDropDownList.SelectedValue)
    //            ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, " + Sponsor.thisDropDownList.SelectedItem.Text + ", cannot play dual role. Please select different actors. Thank you.");
    //        else if (champion._SelectedValue == "-1") ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Champion.");
    //        else if (Sponsor._SelectedValue == "-1") ajaxWebExtension.showJscriptAlert(Page, this, "Please select the Project Sponsor.");
    //        else
    //        {
    //            long lRequestId = long.Parse(HFRequestId2.Value);
    //            int iChampion = int.Parse(champion._SelectedValue);
    //            int iSponsor = int.Parse(Sponsor._SelectedValue);

    //            bool bRet = oBI500RequestHelper.AssignChampionSponsor(lRequestId, iSponsor, iChampion);
    //            if (bRet)
    //            {
    //                //TODO: which email goes to these people to notify them of the project assigned to them?????

    //                oRequestDetails2.Init_Control(lRequestId); //Refresh the control
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Project Champion and Sponsor successfully assigned to Improvement Idea.");
    //            }
    //            else
    //            {
    //                ajaxWebExtension.showJscriptAlert(Page, this, "Not successful. Try again later.");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

    

    //protected void AssignFocalPoint_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        long lRequestId = long.Parse(HFRequestIdFP.Value);
    //        int iFocalPoint = int.Parse(FocalPoint._SelectedValue);

    //        bool bRet = oBI500RequestHelper.AssignFocalPoint(lRequestId, iFocalPoint);
    //        if (bRet)
    //        {
    //            //TODO: which email goes to Focal Point to notify him/her of the project

    //            oRequestDetails3.Init_Control(lRequestId); //Refresh the control
    //            ajaxWebExtension.showJscriptAlert(Page, this, "Focal Point successfully assigned to Improvement Idea.");
    //        }
    //        else
    //        {
    //            ajaxWebExtension.showJscriptAlert(Page, this, "Not successful. Try again later.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}
}