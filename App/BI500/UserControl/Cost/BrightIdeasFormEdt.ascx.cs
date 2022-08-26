using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class App_BI500_UserControl_Cost_BrightIdeasFormEdt : aspnetUserControl
{
    BenefitsMgt oBenefitsMgt = new BenefitsMgt();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    CostReductionRequest o = new CostReductionRequest();
    BITeams oT = new BITeams();
    BIDepartments oD = new BIDepartments();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(long lRequestId)
    {
        ValidateNumeric();
        HFRequestId.Value = lRequestId.ToString();

        List<Benefits> oBenefits = oBenefitsMgt.lstBenefits();
        foreach (Benefits oBenefit in oBenefits)
        {
            drpBenefit.Items.Add(new ListItem(oBenefit.m_sBenefit, oBenefit.m_iBenefitId.ToString()));
        }

        List<BITeams> oTs = BITeams.lstGetTeams();
        foreach (BITeams oT in oTs)
        {
            ddlTeam.Items.Add(new ListItem(oT.m_sTeam, oT.m_iTeamId.ToString()));
        }

        o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

        txtBizCase.Text = Encoder.HtmlEncode(o.sBusinessCase);
        txtProjectTitle.Text = Encoder.HtmlEncode(o.sTitle);
        txtOpportunityStmt.Text = Encoder.HtmlEncode(o.sOpportunityStmt);
        drpBenefit.SelectedValue = Encoder.HtmlEncode(o.iBenefitId.ToString());
        ddlTeam.SelectedValue = Encoder.HtmlEncode(o.iTeamId.ToString());

        txtActualSavings.Text = o.dActualSavings.ToString();
        txtTargetSavings.Text = o.dTargetSavings.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(HFRequestId.Value))
        {
            long lRequestId = FuncUpdate();

            bool bRet = (lRequestId != 0);
            if (bRet)
            {
                //Check if request exists in the approval table. if it exists, don't send any mail to the BI review team again.
                System.Data.DataTable dt = BI500ApprovalHelper.dtGetBIApprovalbyRequestId(lRequestId);
                if (dt.Rows.Count == 0)
                {
                    //Assign the request to the BI Team into the RequestApproval(Workflow) Table
                    bRet = oBI500RequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUsersRolesBI500.userRole.BusinessImprovementTeam);
                    if (bRet)
                    {
                        oBI500RequestHelper.UpdateRequestStatus(lRequestId, (int)BIRequestStatus.RequestStatusRpt.AwaitsBusinessImprovementSupport);

                        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
                        oSendMail.ForwardImprovementIdeaForSupportApproval(oBI500RequestHelper.objGetBrightIdeaById(lRequestId), oBI500RequestHelper.BIReviewersEmail(), oSessnx.getOnlineUser.structUserIdx);

                        ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea successfully submitted.");
                    }
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea successfully submitted.");
                }
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful, try again later.");
            }
        }
    }

    private void Clear()
    {
        drpBenefit.ClearSelection();
        txtBizCase.Text = "";
        txtOpportunityStmt.Text = "";
        txtProjectTitle.Text = "";
        ddlTeam.ClearSelection();
    }

    protected void btnDraft_Click(object sender, EventArgs e)
    {
        //Call update function
        if (!string.IsNullOrEmpty(HFRequestId.Value))
        {
            long lRequestId = FuncUpdate();
            if (lRequestId != 0) ajaxWebExtension.showJscriptAlert(Page, this, "Improvement Idea saved as draft.");
            else ajaxWebExtension.showJscriptAlert(Page, this, "Not Successful, try again later.");
        }
    }

    private void ValidateNumeric()
    {
        txtActualSavings.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtActualSavings.ClientID + "');");
        txtTargetSavings.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + txtTargetSavings.ClientID + "');");
    }

    private long FuncUpdate()
    {
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

        return lRequestId;
    }
}