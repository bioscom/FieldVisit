using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;
using System.Data;
using System.Linq;

public partial class App_BONGACCP_UserControl_oInputUpdateTele : aspnetUserControl
{
    CommitmentsMgt oMgt = new CommitmentsMgt();
    ActivityDetailsMgt dtlMgt = new ActivityDetailsMgt();
    Department oD = new Department();
    ApprovalDecisionMgt oApproval = new ApprovalDecisionMgt();
    ContractProcurementVehicleMgt oVehicle = new ContractProcurementVehicleMgt();
    RequestStatusMgt oStatus = new RequestStatusMgt();
    PlannedEmmergencyMgt oPlanned = new PlannedEmmergencyMgt();
    PurchasingGroupMgt oPurchasing = new PurchasingGroupMgt();
    TeamMgt oTeam = new TeamMgt();
    appUsersHelper oUser = new appUsersHelper();

    OUMgt oU = new OUMgt();
    Assets oAsset = new Assets();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Validate();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadControls();

                if (!string.IsNullOrEmpty(Request.QueryString["lCommitmentId"]))
                {
                    long lCommitmentId = long.Parse(Request.QueryString["lCommitmentId"]);
                    Retrieve(lCommitmentId);
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void LoadControls()
    {
        //Load all dropdownlist controls
        List<ContractProcurementVehicle> olstVhcl = oVehicle.lstGetContractProcurementVehicle();
        foreach (var o in olstVhcl.Select(r => new RadComboBoxItem(r.m_sName, r.m_iVehicleId.ToString())))
        {
            ddlVehicle.Items.Add(o);
            ddlVehicle.DataBind();
        }

        List<RequestStatus> olstStatus = oStatus.lstGetRequestStatus();
        foreach (var o in olstStatus.Select(r => new RadComboBoxItem(r.m_sStatus, r.m_iStatusId.ToString())))
        {
            ddlStatus.Items.Add(o);
            ddlStatus.DataBind();
        }

        List<PlannedEmmergency> olstPlanned = oPlanned.lstGetPlannedEmmergency();
        foreach (var listItem in olstPlanned.Select(r => new RadComboBoxItem(r.m_sType, r.m_iTypeId.ToString())))
        {
            ddlPlannedEmmergency.Items.Add(listItem);
            ddlPlannedEmmergency.DataBind();
        }

        List<OU> olstOU = oU.lstGetOUS();
        foreach (var listItem in olstOU.Select(r => new RadComboBoxItem(r.m_sOUS, r.m_iOUId.ToString())))
        {
            ddlOU.Items.Add(listItem);
            ddlOU.DataBind();
        }

        ddlAsset.Items.Add(new RadComboBoxItem("N/A", "-1"));
        ddlAsset.DataBind();
        List<Assets> olstAssets = Assets.lstGetAssets();
        foreach (var listItem in olstAssets.Select(r => new RadComboBoxItem(r.sAsset, r.iAssetId.ToString())))
        {
            ddlAsset.Items.Add(listItem);
            ddlAsset.DataBind();
        }

        ddlFacility.Items.Add(new RadComboBoxItem("N/A", "-1"));
        ddlFacility.DataBind();
        List<facility> olstFacility = facility.lstGetFacility();
        foreach (var listItem in olstFacility.Select(r => new RadComboBoxItem(r.m_sFacility, r.m_iFacilityId.ToString())))
        {
            ddlFacility.Items.Add(listItem);
            ddlFacility.DataBind();
        }

        ddlPurchaseGroup.Items.Add(new RadComboBoxItem("N/A", "-1"));
        ddlPurchaseGroup.DataBind();
        List<PurchasingGroup> olstGroup = oPurchasing.lstGetPurchasingGroup();
        foreach (var listItem in olstGroup.Select(r => new RadComboBoxItem(r.m_sName, r.m_iGroupId.ToString())))
        {
            ddlPurchaseGroup.Items.Add(listItem);
            ddlPurchaseGroup.DataBind();
        }




        List<Department> olstTeam = oD.lstGetDeparments();
        foreach (var listItem in olstTeam.Select(r => new RadComboBoxItem(r.m_sDepartment, r.m_iDepartmentId.ToString())))
        {
            ddlteam.Items.Add(listItem);
            ddlteam.DataBind();
        }

        //Capex Opex.
        ddlCapexOpex.Items.Add(new RadComboBoxItem(CapexOpex.CapexOpexDesc(CapexOpex.CapexOpexx.Capex), ((int)CapexOpex.CapexOpexx.Capex).ToString()));
        ddlCapexOpex.Items.Add(new RadComboBoxItem(CapexOpex.CapexOpexDesc(CapexOpex.CapexOpexx.Opex), ((int)CapexOpex.CapexOpexx.Opex).ToString()));

        //Hotdesk Support
        ddlHotDeskSupport.Items.Add(new RadComboBoxItem("N/A", "-1"));
        ddlHotDeskSupport.Items.Add(new RadComboBoxItem(commonEnums.yesNoDesc(commonEnums.YesNo.Yes), ((int)commonEnums.YesNo.Yes).ToString()));
        ddlHotDeskSupport.Items.Add(new RadComboBoxItem(commonEnums.yesNoDesc(commonEnums.YesNo.No), ((int)commonEnums.YesNo.No).ToString()));
        ddlHotDeskSupport.Items.Add(new RadComboBoxItem(commonEnums.yesNoDesc(commonEnums.YesNo.notApplicatble), ((int)commonEnums.YesNo.notApplicatble).ToString()));
        ddlHotDeskSupport.DataBind();
        
        //GM Approval
        //ddlGMApproval.Items.Add(new RadComboBoxItem(commonEnums.yesNoDesc(commonEnums.YesNo.Yes), ((int)commonEnums.YesNo.Yes).ToString()));
        //ddlGMApproval.Items.Add(new RadComboBoxItem(commonEnums.yesNoDesc(commonEnums.YesNo.No), ((int)commonEnums.YesNo.No).ToString()));
        //ddlGMApproval.Items.Add(new RadComboBoxItem(commonEnums.yesNoDesc(commonEnums.YesNo.notApplicatble), ((int)commonEnums.YesNo.notApplicatble).ToString()));

        InputUpdateCommitmentDetails1.Visible = false;
        btnClose.Visible = false;
        btnSubmit.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (oSessnx.getOnlineUser.m_iUserId != 0)
        {
            Commitments o = new Commitments();

            o.IDOU = (int)commonEnums.OU.SPDC;
            o.ASSETID = int.Parse(ddlAsset.SelectedValue);
            o.FACILITYID = int.Parse(ddlFacility.SelectedValue);
            o.IDDEPARTMENT = int.Parse(ddlteam.SelectedValue);
            o.TEAMINDICATOR = txtTeamIndicator.Text;

            o.COSTOBJECT = txtCostObject.Text;
            o.COSTOBJECTDESC = txtCostObjDesc.Text;
            o.CAPEXOPEX = int.Parse(ddlCapexOpex.SelectedValue);

            o.PRNUMBER = txtPRNumber.Text;
            o.PRVALUE = decimal.Parse(txtPRValue.Text);
            o.PONUMBER = txtPONumber.Text;
            o.POVALUE = decimal.Parse(txtPOValue.Text);
            o.COMITMNTNO = txtAgreementNo.Text;
            o.COMMITMENT = decimal.Parse(txtCommitment.Text);

            o.TITLE = txtTitle.Text; //Note: this is activity detailed descrition on the webform.
            o.JUSTIFICATION = txtJustification.Text;
            o.THREAT = txtThreat.Text;

            o.CONTRACTNOVENDOR = txtContractNo.Text;
            o.GROUPID = int.Parse(ddlPurchaseGroup.SelectedValue);
            o.TYPEID = int.Parse(ddlPlannedEmmergency.SelectedValue);
            o.STATUSID = int.Parse(ddlStatus.SelectedValue);
            o.VEHICLEID = int.Parse(ddlVehicle.SelectedValue);

            o.PERIODTO = DateTo.SelectedDate;
            o.PERIODFROM = DateFrom.SelectedDate;
            o.PREVIOUS = DatePrevious.SelectedDate;

            o.NAPPIMSNAIRA = decimal.Parse(txtNappimsNaira.Text);
            o.NAPPIMSDOLLAR = decimal.Parse(txtNappimsDollar.Text);
            o.NAPPIMSFUNCDOLLAR = decimal.Parse(txtNappimsFuncDollar.Text);
            o.REQUESTNAIRA = decimal.Parse(txtRequestNaira.Text);
            o.REQUESTDOLLAR = decimal.Parse(txtRequestDollar.Text);
            o.REQUESTFUNCDOLLAR = decimal.Parse(txtRequestFuncDollar.Text);

            //WorkFlow
            o.SPONSORID = int.Parse(ddlSponsor.SelectedValue);
            o.CHECKEDBYID = int.Parse(ddlCheckedBy.SelectedValue);
            //o.m_iFocalPointId = int.Parse(ddlFocalPoint.SelectedValue);
            //o.m_iApproverId = int.Parse(ddlApprover.SelectedValue);
            o.INITIATORID = oSessnx.getOnlineUser.m_iUserId;

            //o.m_sApprovalComments = txtDecisionComments.Text;
            //o.m_dSavings = decimal.Parse(txtSavings.Text);
            //o.m_iApprovalId = int.Parse(ddlApprovalDecision.SelectedValue);

            //ddlHotDeskSupport
            //ddlGMApproval

            if (string.IsNullOrEmpty(CommitmentHF.Value)) Save(o); else Update(o);
        }
        else
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Please, close the web page and re login again.");
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long lCommitmentId = long.Parse(CommitmentHF.Value);
        Commitments o = oMgt.objGetCommitmentById(lCommitmentId);

        //Send Mail to the Sponsor
        var oHlp = new appUsersHelper();
        var oSendMail = new SendMailBonga(oSessnx.getOnlineUser.structUserIdx);
        var sponsor = oHlp.objGetUserByUserID(o.SPONSORID);
        oSendMail.ForwardCommitmentToSponsor(o, sponsor.structUserIdx, oMgt.CommitmentReviewers(o));

        ajaxWebExtension.showJscriptAlertCx(Page, this, "An email has been sent to your Sponsor for support.");
    }

    private void Save(Commitments o)
    {
        long lCommitmentId = 0; string sCommitmentNumber = "";
        bool bRet = oMgt.Insert(o, ref lCommitmentId, ref sCommitmentNumber);
        if (bRet)
        {
            CommitmentHF.Value = lCommitmentId.ToString();

            //Update Bonga_Auto table to the latest value
            oMgt.UpdateBongaAutoNumberGenerator(lCommitmentId);

            //Set to Update Mode
            btnClose.Visible = true;
            btnSubmit.Visible = true;
            InputUpdateCommitmentDetails1.Visible = true;
            InputUpdateCommitmentDetails1.LoadDetails(lCommitmentId);

            ajaxWebExtension.showJscriptAlertCx(Page, this, "Transaction successul. Enter your Activity Breakdown below.");
        }
        else
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Transaction not successul, try again later.");
        }
    }

    private void Update(Commitments o)
    {
        o.COMMITMENTID = long.Parse(CommitmentHF.Value);
        bool bRet = oMgt.Update(o);
    }

    public void Retrieve(long lCommitmentId)
    {
        try
        {
            appUsers u = new appUsers();

            CommitmentHF.Value = lCommitmentId.ToString();
            Commitments o = oMgt.objGetCommitmentById(lCommitmentId);

            ddlAsset.SelectedValue = o.ASSETID.ToString();
            ddlFacility.SelectedValue = o.FACILITYID.ToString();
            ddlteam.SelectedValue = o.IDDEPARTMENT.ToString();
            txtTeamIndicator.Text = o.TEAMINDICATOR;

            txtCostObject.Text = o.COSTOBJECT;
            txtCostObjDesc.Text = o.COSTOBJECTDESC;
            ddlCapexOpex.SelectedValue = o.CAPEXOPEX.ToString();

            txtPRNumber.Text = o.PRNUMBER;
            txtPRValue.Text = o.PRVALUE.ToString();
            txtPONumber.Text = o.PONUMBER;
            txtPOValue.Text = o.POVALUE.ToString();
            txtCommitment.Text = o.COMMITMENT.ToString();
            txtAgreementNo.Text = o.COMITMNTNO;
            lblPOPRVariance.Text = o.dVariance;

            txtTitle.Text = o.TITLE;
            txtJustification.Text = o.JUSTIFICATION;
            txtThreat.Text = o.THREAT;

            txtContractNo.Text = o.CONTRACTNOVENDOR;
            ddlPurchaseGroup.SelectedValue = o.GROUPID.ToString();
            ddlPlannedEmmergency.SelectedValue = o.TYPEID.ToString();
            ddlStatus.SelectedValue = o.STATUSID.ToString();
            ddlVehicle.SelectedValue = o.VEHICLEID.ToString();
            DateFrom.SelectedDate = o.PERIODFROM;
            DateTo.SelectedDate = o.PERIODTO;
            DatePrevious.SelectedDate = o.PREVIOUS;

            txtNappimsDollar.Text = o.NAPPIMSDOLLAR.ToString();
            txtNappimsFuncDollar.Text = o.NAPPIMSFUNCDOLLAR.ToString();
            txtNappimsNaira.Text = o.NAPPIMSNAIRA.ToString();
            txtRequestDollar.Text = o.REQUESTDOLLAR.ToString();
            txtRequestFuncDollar.Text = o.REQUESTFUNCDOLLAR.ToString();
            txtRequestNaira.Text = o.REQUESTNAIRA.ToString();

            //WorkFlow
            var item = new RadComboBoxItem();
            item.Text = appUsersHelper.objGetUserByUserId(o.SPONSORID).m_sFullName;
            item.Value = o.SPONSORID.ToString();
            ddlSponsor.Items.Add(item);
            item.DataBind();

            var item1 = new RadComboBoxItem();
            item1.Text = appUsersHelper.objGetUserByUserId(o.CHECKEDBYID).m_sFullName;
            item1.Value = o.CHECKEDBYID.ToString();
            ddlCheckedBy.Items.Add(item1);
            item1.DataBind();

            //Set to Update Mode
            //InputUpdateCommitmentDetails1.Visible = true;
            //InputUpdateCommitmentDetails1.LoadDetails(lCommitmentId);

            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void ddlSponsor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        LoadUsersBySearch(e.Text, ddlSponsor);
    }

    protected void ddlCheckedBy_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        LoadUsersBySearch(e.Text, ddlCheckedBy);
    }

    private void LoadUsersBySearch(string search, RadComboBox ddl)
    {
        EIdd.Utilities.Search(search, ddl);
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
    }
}