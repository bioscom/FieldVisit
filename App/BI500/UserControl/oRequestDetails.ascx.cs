using System;
using Microsoft.Security.Application;

public partial class UserControl_oRequestDetails : System.Web.UI.UserControl
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    BenefitsMgt oBenefitsMgt = new BenefitsMgt();
    FunctionMgt oFunctionMgt = new FunctionMgt();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control(CostReductionRequest oBI500Request)
    {
        lblRequestNumber.Text = Encoder.HtmlEncode(oBI500Request.sRequestNumber);
        lblTitle.Text = Encoder.HtmlEncode(oBI500Request.sTitle);
        lblDateInit.Text = Encoder.HtmlEncode(oBI500Request.dDateSubmitted.ToString());
        lblBusinessArea.Text = Encoder.HtmlEncode(oFunctionMgt.objGetFunctionById(oBI500Request.iFunctionId).m_sFunction);
        lblImpactArea.Text = Encoder.HtmlEncode(oBenefitsMgt.objGetBenefitById(oBI500Request.iBenefitId).m_sBenefit);
        lblPlanCompletionDate.Text = Encoder.HtmlEncode(oBI500Request.dCompletionDate.ToString());
        lblInitiator.Text = Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).m_sFullName);
        lblProjectChampion.Text = Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectChampionUserId).m_sFullName);
        lblProjectSponsor.Text = Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectSponsorUserId).m_sFullName);
        //lblFocalPoint.Text = Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(oBI500Request.iFocalPointUserId).m_sFullName);
        lblBuzCase.Text = Encoder.HtmlEncode(oBI500Request.sBusinessCase);
        lblOpportunityStmt.Text = Encoder.HtmlEncode(oBI500Request.sOpportunityStmt);
        lblTeamMembers.Text = Encoder.HtmlEncode(oBI500Request.sTeamMembers);

        lblStatus.Text = Encoder.HtmlEncode(oBI500Request.iStatus.ToString());
        lnkPhase.Text = Encoder.HtmlEncode(oBI500Request.iPhase.ToString());
        BIRequestStatus.reportMyStatus(lblStatus);
        BIRequestStatus.reportBrightIdeaPhase(lnkPhase);

        lblImprovementBenefit.Text = (Encoder.HtmlEncode(oBI500Request.sImprovement) == "None") ? "?" : Encoder.HtmlEncode(oBI500Request.sImprovement);
        lblFinishedDate.Text = string.IsNullOrEmpty(Encoder.HtmlEncode(oBI500Request.dActualDate.ToString())) ? "?" : Encoder.HtmlEncode(oBI500Request.dActualDate.ToString());
        lblQtyBenefit.Text = Encoder.HtmlEncode(oBI500Request.sQtyBenefit.ToString());
        lblReplicationPotential.Text = (Encoder.HtmlEncode(oBI500Request.sReplication) == "None") ? "?" : Encoder.HtmlEncode(oBI500Request.sReplication);

        BI500RequestOnBehalfHelper o = new BI500RequestOnBehalfHelper();
        BI500RequestOnBehalf oBhlf = o.objGetBrightIdeaOnbehalfById(oBI500Request.lRequestId);
        lblFullName.Text = oBhlf.sFullName;
        lblEmailAddress.Text = oBhlf.sEmailAddress;
    }
}