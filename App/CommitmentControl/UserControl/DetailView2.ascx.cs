using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BONGACCP_UserControl_DetailView2 : System.Web.UI.UserControl
{
    ApprovalDecisionMgt oApproval = new ApprovalDecisionMgt();
    CommitmentsMgt oMgt = new CommitmentsMgt();

    ContractProcurementVehicleMgt oVehicle = new ContractProcurementVehicleMgt();
    RequestStatusMgt oStatus = new RequestStatusMgt();
    PlannedEmmergencyMgt oPlanned = new PlannedEmmergencyMgt();
    PurchasingGroupMgt oPurchasing = new PurchasingGroupMgt();
    TeamMgt oTeam = new TeamMgt();
    appUsersHelper oUser = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        long lCommitmentId = long.Parse(Request.QueryString["lCommitmentId"]);

        Retrieve(lCommitmentId);
    }

    public void Retrieve(long lCommitmentId)
    {
        CommitmentHF.Value = lCommitmentId.ToString();
        Commitments o = oMgt.objGetCommitmentById(lCommitmentId);

        lblDecision.Text = o.eDecision.m_sDecision;
        lblDecisionComments.Text = o.APPROVALCOMMENT;

        lblInitiator.Text = oUser.objGetUserByUserID(o.INITIATORID).m_sFullName;
        lblSponsor.Text = oUser.objGetUserByUserID(o.SPONSORID).m_sFullName;
        //lblRequestor.Text = oUser.objGetUserByUserID(o.m_iRequestorId).m_sFullName;
        lblCheckedBy.Text = oUser.objGetUserByUserID(o.CHECKEDBYID).m_sFullName;
        lblApprover.Text = oUser.objGetUserByUserID(o.APPROVERID).m_sFullName;

        lblGroup.Text = oPurchasing.objGetPurchasingGroupById(o.GROUPID).m_sName;
        lblTeam.Text = oTeam.objGetTeamById(o.IDDEPARTMENT).m_sTeam;
        lblPlannedEmmergency.Text = oPlanned.objGetPlannedEmmergencyById(o.TYPEID).m_sType;
        lblNewRepresented.Text = oStatus.objGetRequestStatusById(o.STATUSID).m_sStatus;
        lblVehicle.Text = oVehicle.objGetContractProcurementVehicleById(o.VEHICLEID).m_sName;

        lblTitle.Text = o.TITLE;
        lblCostObject.Text = o.COSTOBJECT;
        //datePeriod.setDate(o.m_tActivityPeriod.ToString());
        lblBuzJustification.Text = o.JUSTIFICATION;
        lblThreat.Text = o.THREAT;
        lblContractNo.Text = o.CONTRACTNOVENDOR;
        lblPRNo.Text = o.PRNUMBER;
        lblPRValue.Text = stringRoutine.formatAsBankMoney(o.PRVALUE);
        lblPONo.Text = o.PONUMBER;
        lblPOValue.Text = stringRoutine.formatAsBankMoney(o.POVALUE);
        lblCommitment.Text = stringRoutine.formatAsBankMoney(o.COMMITMENT);

        //lblDecisionComments.Text = o.m_sApprovalComments;
        lblSavings.Text = stringRoutine.formatAsBankMoney(o.SAVINGS);

        activityDescription1.LoadDetails(lCommitmentId);
        oDocsUploaded1.LoadDocuments(lCommitmentId);
        //InputUpdateCommitmentDetailsUpdt1.LoadDetails();

        lblPOPRVariance.Text = o.dVariance.ToString();
        lblApprovedBy.Text = oUser.objGetUserByUserID(o.APPROVERID).m_sFullName;
    }
}