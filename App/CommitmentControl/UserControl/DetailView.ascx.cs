using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_BONGACCP_UserControl_DetailView : aspnetUserControl
{
    ApprovalDecisionMgt oApproval = new ApprovalDecisionMgt();
    CommitmentsMgt oMgt = new CommitmentsMgt();

    ContractProcurementVehicleMgt oVehicle = new ContractProcurementVehicleMgt();
    RequestStatusMgt oStatus = new RequestStatusMgt();
    PlannedEmmergencyMgt oPlanned = new PlannedEmmergencyMgt();
    PurchasingGroupMgt oPurchasing = new PurchasingGroupMgt();
    TeamMgt oTeam = new TeamMgt();
    Department oD = new Department();
    appUsersHelper oUser = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //Load all dropdownlist controls

        List<ApprovalDecision> oLst = oApproval.lstGetApprovalDecisions();
        foreach (var listItem in oLst.Select(r => new ListItem(r.m_sDecision, r.m_iApprovalId.ToString())))
            ddlApprovalDecision.Items.Add(listItem);

        //List<Commitments> olstCommitments = oMgt.lstCommitments();
        //foreach (var listItem in olstCommitments.Select(r => new ListItem(r.TITLE, r.COMMITMENTID.ToString())))
        //    ddlCommitments.Items.Add(listItem);

        long lCommitmentId = long.Parse(Request.QueryString["lCommitmentId"]);

        Retrieve(lCommitmentId);
    }

    private void LoadControls()
    {
        
    }

    public void Retrieve(long lCommitmentId)
    {
        CommitmentHF.Value = lCommitmentId.ToString();
        Commitments o = oMgt.objGetCommitmentById(lCommitmentId);

        //if (!IsPostBack) LoadControls();

        lblInitiator.Text = oUser.objGetUserByUserID(o.INITIATORID).m_sFullName;
        lblSponsor.Text = oUser.objGetUserByUserID(o.SPONSORID).m_sFullName;
        lblFocalPoint.Text = oUser.objGetUserByUserID(o.FOCALPOINTID).m_sFullName;
        lblCheckedBy.Text = oUser.objGetUserByUserID(o.CHECKEDBYID).m_sFullName;
        lblApprover.Text = oUser.objGetUserByUserID(o.APPROVERID).m_sFullName;

        lblGroup.Text = oPurchasing.objGetPurchasingGroupById(o.GROUPID).m_sName;
        lblTeam.Text = oD.objGetDeparmentById(o.IDDEPARTMENT).m_sDepartment;  //oTeam.objGetTeamById(o.IDDEPARTMENT).m_sTeam;
        lblPlannedEmmergency.Text = oPlanned.objGetPlannedEmmergencyById(o.TYPEID).m_sType;
        lblNewRepresented.Text = oStatus.objGetRequestStatusById(o.STATUSID).m_sStatus;
        lblVehicle.Text = oVehicle.objGetContractProcurementVehicleById(o.VEHICLEID).m_sName;

        ddlApprovalDecision.SelectedValue = o.APPROVALID.ToString();
        txtDecisionComments.Text = o.APPROVALCOMMENT;
        txtSavings.Text = o.SAVINGS.ToString();

        lblTitle.Text = o.TITLE;
        lblCostObject.Text = o.COSTOBJECT;
        lblPeriodFrom.Text = string.Format("{0:dd-MMM-yyyy}", o.PERIODFROM);
        lblPeriodTo.Text = string.Format("{0:dd-MMM-yyyy}", o.PERIODTO);
        
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

        EIdd.Utilities.RadComboGetUser(o.eApprover.m_sFullName, o.eApprover.m_iUserId, ddlApprover);
        ddlApprover.SelectedValue = o.eApprover.m_iUserId.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            long lCommitmentId = long.Parse(CommitmentHF.Value);
            Commitments o = oMgt.objGetCommitmentById(lCommitmentId);

            o.APPROVALID = int.Parse(ddlApprovalDecision.SelectedValue);
            o.APPROVALCOMMENT = txtDecisionComments.Text;
            o.SAVINGS = decimal.Parse(txtSavings.Text);
            o.APPROVERID = int.Parse(ddlApprover.SelectedValue);

            bool bRet = oMgt.Update2(o);
            if (bRet)
            {
                var oSendMail = new SendMailBonga(oSessnx.getOnlineUser.structUserIdx);
                oSendMail.RequestReviewed(o, oSessnx.getOnlineUser, oMgt.CommitmentReviewers(o), ddlApprovalDecision.SelectedItem.Text, txtDecisionComments.Text);

                ajaxWebExtension.showJscriptAlertCx(Page, this, "Update successful!!!");
            }
            else
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Update not successful. Try again later.");
            }
        }
        catch(Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    //protected void ddlCommitments_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Retrieve(long.Parse(ddlCommitments.SelectedValue));
    //}

    protected void ddlApprover_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text))
            EIdd.Utilities.Search(e.Text, ddlApprover);
    }

    protected void ckbCompare_CheckedChanged(object sender, EventArgs e)
    {
        var pnl = (Panel) Parent.FindControl("Isaac");
        if (ckbCompare.Checked)
        {
            pnl.Visible = true;
            ckbCompare.Text = "Uncompare";
        }
        else
        {
            pnl.Visible = false;
            ckbCompare.Text = "Compare";
            ckbCompare.Checked = false;
        }
    }

    public HiddenField CommitmentIdHF
    {
        get
        {
            return CommitmentHF;
        }
    }

    public CheckBox CompareCkb
    {
        get
        {
            return ckbCompare;
        }
    }

    protected void ddlCommitment_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlCommitment.SelectedValue))
        {
            long Id = long.Parse(ddlCommitment.SelectedValue);
            Retrieve(Id);

            //var result = oMgt.lstCommitments().Where(t => t.COMMITMENTID == long.Parse(ddlCommitment.SelectedValue));
            //if (result.Count() > 0)
            //{
            //    grdView.DataSource = o.ToDataTable(result);
            //    grdView.Rebind();
            //}
        }
        //else
        //{
        //    LoadDataForgrdView();
        //}
    }

    protected void ddlCommitment_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        var result = oMgt.lstCommitments().Where(t => t.TITLE.Contains(e.Text)).ToList();
        RadComboControlLoader(result, ddlCommitment);
    }

    private static void RadComboControlLoader(List<Commitments> lst, RadComboBox RadDdl)
    {
        foreach (Commitments o in lst)
        {
            var item = new RadComboBoxItem();
            item.Text = o.TITLE;
            item.Value = o.COMMITMENTID.ToString();

            string commitmntNo = o.COMITMNTNO;
            string dateSubmitted = string.Format("{0:dd-MMM-yyy}", o.DATE_SUBMITTED);

            item.Attributes.Add("COMITMNTNO", commitmntNo);
            item.Attributes.Add("DATE_SUBMITTED", dateSubmitted);

            RadDdl.Items.Add(item);
            item.DataBind();
        }
    }

}