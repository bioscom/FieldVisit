using System;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class App_CommitmentControl_UserControl_Snepco : aspnetUserControl
{
    CommitmentsMgt oMgt = new CommitmentsMgt();
    Department oD = new Department();
    ContractProcurementVehicleMgt oVehicle = new ContractProcurementVehicleMgt();
    RequestStatusMgt oStatus = new RequestStatusMgt();
    PlannedEmmergencyMgt oPlanned = new PlannedEmmergencyMgt();
    PurchasingGroupMgt oPurchasing = new PurchasingGroupMgt();
    OUMgt oU = new OUMgt();

    public delegate void ChildControlDelegate(long lCommitmentId);

    /// <summary>
    /// Event to which the Parent page will subscribe
    /// </summary>
    public event ChildControlDelegate GetDataFromChild;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) Page.Validate();
    }

    private void LoadControls()
    {
        //Load all dropdownlist controls
        List<ContractProcurementVehicle> olstVhcl = oVehicle.lstGetContractProcurementVehicle();
        foreach (var o in olstVhcl)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sName;
            item.Value = o.m_iVehicleId.ToString();

            ddlVehicle.Items.Add(item);
            item.DataBind();
        }

        List<RequestStatus> olstStatus = oStatus.lstGetRequestStatus();
        foreach (var o in olstStatus)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sStatus;
            item.Value = o.m_iStatusId.ToString();

            ddlStatus.Items.Add(item);
            item.DataBind();
        }

        List<PlannedEmmergency> olstPlanned = oPlanned.lstGetPlannedEmmergency();
        foreach (var o in olstPlanned)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sType;
            item.Value = o.m_iTypeId.ToString();

            ddlPlannedEmmergency.Items.Add(item);
            item.DataBind();
        }

        List<PurchasingGroup> olstGroup = oPurchasing.lstGetPurchasingGroup();
        foreach (var o in olstGroup)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sName;
            item.Value = o.m_iGroupId.ToString();

            ddlPurchaseGroup.Items.Add(item);
            item.DataBind();
        }

        List<Department> olstTeam = oD.lstGetDeparments();
        foreach (var o in olstTeam)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sDepartment;
            item.Value = o.m_iDepartmentId.ToString();

            ddlteam.Items.Add(item);
            item.DataBind();
        }

        List<OU> olstOU = oU.lstGetOUS();
        foreach (var o in olstOU)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sOUS;
            item.Value = o.m_iOUId.ToString();
            item.DataBind();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            LoadControls();

            if (!string.IsNullOrEmpty(Request.QueryString["lCommitmentId"]))
            {
                long lCommitmentId = long.Parse(Request.QueryString["lCommitmentId"]);
                Retrieve(lCommitmentId);
            }
            else
            {
                //InputUpdateCommitmentDetails1.LoadDetails(-1); //Initialis the Details Control
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void Save(Commitments o)
    {
        var oHlp = new appUsersHelper();
        long lCommitmentId = 0; string sCommitmentNumber = "";
        bool bRet = oMgt.InsertSnepco(o, ref lCommitmentId, ref sCommitmentNumber);
        if (bRet)
        {
            CommitmentHF.Value = lCommitmentId.ToString();

            //Update Bonga_Auto table to the latest value
            oMgt.UpdateBongaAutoNumberGenerator(lCommitmentId);
            btnSubmit.Text = "Update";
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Transaction successful.");

            //var HF = (HiddenField)Page.Parent.FindControl("CommitmentHF");
            //HF.Value = lCommitmentId.ToString();
            long Id = long.Parse(CommitmentHF.Value);

            if (GetDataFromChild != null)
            {
                GetDataFromChild(Id);
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Transaction not successul, try again later.");
        }
    }

    private void Update(Commitments o)
    {
        o.COMMITMENTID = long.Parse(CommitmentHF.Value);

        bool bRet = oMgt.UpdateSnepco(o);
        if (bRet) { ajaxWebExtension.showJscriptAlertCx(Page, this, "Transaction successul."); }
        else { ajaxWebExtension.showJscriptAlertCx(Page, this, "Transaction not successul, try again later."); }
    }

    public void Retrieve(long lCommitmentId)
    {
        try
        {
            CommitmentHF.Value = lCommitmentId.ToString();
            Commitments o = oMgt.objGetCommitmentById(lCommitmentId);

            ddlPurchaseGroup.SelectedValue = o.GROUPID.ToString();
            ddlteam.SelectedValue = o.IDDEPARTMENT.ToString();
            ddlPlannedEmmergency.SelectedValue = o.TYPEID.ToString();
            ddlStatus.SelectedValue = o.STATUSID.ToString();
            ddlVehicle.SelectedValue = o.VEHICLEID.ToString();

            EIdd.Utilities.RadComboGetUser(o.eSponsor.m_sFullName, o.eSponsor.m_iUserId, ddlSponsor);
            ddlSponsor.SelectedValue = o.eSponsor.m_iUserId.ToString();

            EIdd.Utilities.RadComboGetUser(o.eCheckedBy.m_sFullName, o.eCheckedBy.m_iUserId, ddlCheckedBy);
            ddlCheckedBy.SelectedValue = o.eCheckedBy.m_iUserId.ToString();

            EIdd.Utilities.RadComboGetUser(o.eFocalPoint.m_sFullName, o.eFocalPoint.m_iUserId, ddlFocalPoint);
            ddlFocalPoint.SelectedValue = o.eFocalPoint.m_iUserId.ToString();

            txtTitle.Text = o.TITLE;
            txtCostObject.Text = o.COSTOBJECT;
            DateFrom.SelectedDate = o.PERIODFROM;
            DateTo.SelectedDate = o.PERIODTO;
            txtJustification.Text = o.JUSTIFICATION;
            txtThreat.Text = o.THREAT;
            txtContractNo.Text = o.CONTRACTNOVENDOR;
            txtPRNumber.Text = o.PRNUMBER;
            txtPRValue.Text = o.PRVALUE.ToString();
            txtPONumber.Text = o.PONUMBER;
            txtPOValue.Text = o.POVALUE.ToString();
            txtCommitment.Text = o.COMMITMENT.ToString();
            lblPOPRVariance.Text = o.dVariance;

            btnSubmit.Text = "Update";
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Commitments o = new Commitments();

            o.IDOU = (int)commonEnums.OU.SNEPCO;
            o.COSTOBJECT = txtCostObject.Text;
            o.TITLE = txtTitle.Text;

            o.PERIODFROM = DateFrom.SelectedDate;
            o.PERIODTO = DateTo.SelectedDate;
            o.JUSTIFICATION = txtJustification.Text;
            o.THREAT = txtThreat.Text;
            o.CONTRACTNOVENDOR = txtContractNo.Text;

            o.PRNUMBER = txtPRNumber.Text;
            o.PRVALUE = decimal.Parse(txtPRValue.Text);

            o.PONUMBER = txtPONumber.Text;
            o.POVALUE = !string.IsNullOrEmpty(txtPOValue.Text) ? decimal.Parse(txtPOValue.Text) : 0;
            o.COMMITMENT = !string.IsNullOrEmpty(txtPOValue.Text) ? decimal.Parse(txtPOValue.Text) : decimal.Parse(txtPRValue.Text);

            o.SPONSORID = int.Parse(ddlSponsor.SelectedValue);
            o.CHECKEDBYID = int.Parse(ddlCheckedBy.SelectedValue);
            o.FOCALPOINTID = int.Parse(ddlFocalPoint.SelectedValue);
            o.INITIATORID = oSessnx.getOnlineUser.m_iUserId;

            o.GROUPID = int.Parse(ddlPurchaseGroup.SelectedValue);
            o.IDDEPARTMENT = int.Parse(ddlteam.SelectedValue);
            o.TYPEID = int.Parse(ddlPlannedEmmergency.SelectedValue);
            o.STATUSID = int.Parse(ddlStatus.SelectedValue);
            o.VEHICLEID = int.Parse(ddlVehicle.SelectedValue);

            if (string.IsNullOrEmpty(CommitmentHF.Value)) Save(o); else Update(o);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void ddlSponsor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text))
            EIdd.Utilities.Search(e.Text, ddlSponsor);
    }

    protected void ddlRequestor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        
    }

    protected void ddlCheckedBy_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text))
            EIdd.Utilities.Search(e.Text, ddlCheckedBy);
    }

    protected void ddlFocalPoint_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text))
            EIdd.Utilities.Search(e.Text, ddlFocalPoint);
    }

    protected void txtPRValue_TextChanged(object sender, EventArgs e)
    {
        txtCommitment.Text = !string.IsNullOrEmpty(txtPOValue.Text) ? txtPOValue.Text : txtPRValue.Text;
        lblPOPRVariance.Text = string.IsNullOrEmpty(txtPOValue.Text) ? 0.ToString() + " %" : (Math.Round(((decimal.Parse(txtPRValue.Text) / decimal.Parse(txtPOValue.Text)) * 100), 2)).ToString() + " %";
    }

    protected void txtPOValue_TextChanged(object sender, EventArgs e)
    {
        txtCommitment.Text = !string.IsNullOrEmpty(txtPOValue.Text) ? txtPOValue.Text : txtPRValue.Text;
        lblPOPRVariance.Text = string.IsNullOrEmpty(txtPOValue.Text) ? 0.ToString() + " %" : (Math.Round(((decimal.Parse(txtPRValue.Text) / decimal.Parse(txtPOValue.Text)) * 100), 2)).ToString() + " %";
    }
}