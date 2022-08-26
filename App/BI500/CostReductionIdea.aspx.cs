using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_CostReductionIdea : aspnetPage
{
    BenefitsMgt oBnft = new BenefitsMgt();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    CostReductionRequest o = new CostReductionRequest();
    BITeams oT = new BITeams();
    BIDepartments oD = new BIDepartments();
    appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ValidateNumeric();

            btnSubmit.Enabled = false;
            List<Benefits> oBenefits = oBnft.lstBenefits();
            foreach (Benefits oBenefit in oBenefits)
            {
                drpBenefit.Items.Add(new ListItem(oBenefit.m_sBenefit, oBenefit.m_iBenefitId.ToString()));
            }

            List<BITeams> oTs = BITeams.lstGetTeams();
            foreach (BITeams oT in oTs)
            {
                ddlTeam.Items.Add(new ListItem(oT.m_sTeam, oT.m_iTeamId.ToString()));
            }
        }
    }

    protected void btnDraft_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(HFRequestId.Value) || (long.Parse(HFRequestId.Value) == 0))
            {
                long lRequestId = 0;
                o.iBenefitId = int.Parse(drpBenefit.SelectedValue);

                o.iTeamId = int.Parse(ddlTeam.SelectedValue);
                o.iDeptId = oT.objGetTeamById(o.iTeamId).m_iDepartmentId;
                o.iFunctionId = oD.objGetDepartmentById(o.iDeptId).m_iFunctionId;

                o.iUserId = oSessnx.getOnlineUser.m_iUserId;
                o.sBusinessCase = txtBizCase.Text;
                o.sOpportunityStmt = txtOpportunityStmt.Text;
                o.sRequestNumber = AutoNumberBI500.GenerateAutoNumber().Replace("BI", "CR"); //BI for Bright Idea, CR for Cost Reduction
                o.sTitle = txtProjectTitle.Text;

                o.dTargetSavings = !string.IsNullOrEmpty(txtTargetSavings.Text) ? decimal.Parse(txtTargetSavings.Text) : 0;
                o.dActualSavings = !string.IsNullOrEmpty(txtActualSavings.Text) ? decimal.Parse(txtActualSavings.Text) : 0;

                bool bRet = oBI500RequestHelper.CreateCostReductionIdea(o, ref lRequestId);
                if (bRet)
                {
                    HFRequestId.Value = lRequestId.ToString();
                    btnSubmit.Enabled = true;
                    ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea saved as draft.");
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea Draft not saved. Try again later.");
                }
            }
            else if (!string.IsNullOrEmpty(HFRequestId.Value) && (long.Parse(HFRequestId.Value) != 0))
            {
                FuncUpdate();
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
                long lRequestId = FuncUpdate();
                Clear();

                //Assign the request to the BI Team into the RequestApproval(Workflow) Table
                bool bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam);
                if (bRet)
                {
                    oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport);
                    oBI500RequestHelper.UpdateStageGate(lRequestId, (int)BIRequestStatus.StageGates.StageGate1); // Stage Gate 1, when submitted to the Business Improvement team

                    sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
                    oSendMail.ForwardImprovementIdeaForSupportApproval(oBI500RequestHelper.objGetBrightIdeaById(lRequestId), oBI500RequestHelper.BIReviewersEmail(), oSessnx.getOnlineUser.structUserIdx);
                    ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea successfully submitted.");

                    Response.Redirect("~/App/BI500/CostReductionMyIdeas.aspx");
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

    private void ValidateNumeric()
    {
        txtActualSavings.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtActualSavings.ClientID + "');");
        txtTargetSavings.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtTargetSavings.ClientID + "');");
    }

    private void Clear()
    {
        txtBizCase.Text = "";
        txtOpportunityStmt.Text = "";
        txtProjectTitle.Text = "";
        ddlTeam.ClearSelection();
        drpBenefit.ClearSelection();
    }

    private long FuncUpdate()
    {
        //Call update function
        long lRequestId = long.Parse(HFRequestId.Value);

        o.lRequestId = lRequestId;
        o.iBenefitId = int.Parse(drpBenefit.SelectedValue);

        o.iTeamId = int.Parse(ddlTeam.SelectedValue);
        o.iDeptId = oT.objGetTeamById(o.iTeamId).m_iDepartmentId;
        o.iFunctionId = oD.objGetDepartmentById(o.iDeptId).m_iFunctionId;

        o.iUserId = oSessnx.getOnlineUser.m_iUserId;
        o.sBusinessCase = txtBizCase.Text;
        o.sOpportunityStmt = txtOpportunityStmt.Text;
        o.sTitle = txtProjectTitle.Text;

        o.dTargetSavings = !string.IsNullOrEmpty(txtTargetSavings.Text) ? decimal.Parse(txtTargetSavings.Text) : 0;
        o.dActualSavings = !string.IsNullOrEmpty(txtActualSavings.Text) ? decimal.Parse(txtActualSavings.Text) : 0;

        bool bRet = oBI500RequestHelper.UpdateCostReductionIdea(o);

        if (bRet) ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea saved as draft.");
        else ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful, try again later.");

        return lRequestId;
    }

}