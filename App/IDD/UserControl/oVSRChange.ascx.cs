using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_IDD_UserControl_oVSRChange : aspnetUserControl
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.IDDAnalystAuditTrail oT = new EIdd.IDDAnalystAuditTrail();
    appUsersHelper hlp = new appUsersHelper();
    EIdd.VendorReportMgt v = new EIdd.VendorReportMgt();

    protected void Page_Init(object sender, EventArgs e)
    {
        LoadStageOptions();
        LoadStatusOptions();
        LoadServices();
        //LoadAprovalOptions();
        Hider.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["lVendorId"] != null)
                {
                    //VENDORID
                    long lVendorId = long.Parse(Request.QueryString["lVendorId"]);
                    long lRequestId = long.Parse(Request.QueryString["lRequestId"]);

                    InitialiseControls(lVendorId, lRequestId);
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    private void LoadServices()
    {
        ddlServices.Items.Clear();
        var l = new EIdd.CategoryMgt();

        foreach (var o in l.LstGetServices())
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sCategory;
            item.Value = o.m_iCategoryId.ToString();

            ddlServices.Items.Add(item);
            item.DataBind();
        }
    }

    private void LoadGOGI()
    {
        btnLstGI.Items.Clear();
        btnLstGO.Items.Clear();

        var item = new ButtonListItem();
        item.Text = "Yes";
        item.Value = "1";
        btnLstGI.Items.Add(item);
        btnLstGO.Items.Add(item);

        item = new ButtonListItem();
        item.Text = "No";
        item.Value = "2";
        btnLstGI.Items.Add(item);
        btnLstGO.Items.Add(item);
    }

    public void InitialiseControls(long lVendorId, long lRequestId)
    {
        LoadGOGI();

        EIdd.Vendours oV = v.objGetVendorById(lVendorId);
        EIdd.RequestForIDD oT = o.objGetRequestById(lRequestId);

        ddlServices.SelectedValue = oV.m_iCategoryId.ToString();
        txtVendorAddress.Text = oV.m_sAddress;
        txtEmailAddress.Text = oV.m_sEmailAddress;
        txtVendorName.Text = oV.m_sRegisteredName;
        txtRepresentative.Text = oV.m_sRepresentative;
        txtMskPhoneNo.Text = oV.m_sTelephoneNumber;
        txtVendorCode.Text = oV.m_sCodes;
        txtContractValue.Text = oV.m_dAmount.ToString();
        btnLstGI.SelectedValue = oV.m_iGI.ToString();
        btnLstGO.SelectedValue = oV.m_iGO.ToString();

        //EIdd.AnalystAuditTrail oA = oT.objGetAnalystAuditTrailById(lAuditId);
        ddlRemarks.SelectedValue = oT.m_iStage.ToString();
        btnLstStatus.SelectedValue = oT.m_iStatus.ToString();

        txtComment.Text = oT.m_sComments;
        //TODO: get the approvers comments into the request table
        txtApproverComments.Text = oT.m_sApproverComment;

        if ((int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Purple))
        {
            Hider.Visible = true;
            ValidityPeriod.SelectedDate = oT.m_dValidityPeriod;
        }

        else
            Hider.Visible = false;

        //RequestIdHF.Value = lRequestId.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bool bRet = false;
            if (Request.QueryString["lVendorId"] != null)
            {
                long lVendorId = long.Parse(Request.QueryString["lVendorId"]);
                long lRequestId = long.Parse(Request.QueryString["lRequestId"]);

                //var oR = new EIdd.RequestForIDD();
                //oR.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
                var oK = new EIdd.Vendours();
                oK.m_lVendorId = lVendorId;
                oK.m_iCategoryId = int.Parse(ddlServices.SelectedValue);
                oK.m_sAddress = txtVendorAddress.Text;
                oK.m_sEmailAddress = txtEmailAddress.Text;
                oK.m_sRegisteredName = txtVendorName.Text;
                oK.m_sRepresentative = txtRepresentative.Text;
                oK.m_sTelephoneNumber = txtMskPhoneNo.Text;
                oK.m_sCodes = txtVendorCode.Text;
                oK.m_dAmount = !string.IsNullOrEmpty(txtContractValue.Text) ? decimal.Parse(txtContractValue.Text) : 0;

                foreach (ButtonListItem li in btnLstGI.Items) if (li.Selected) oK.m_iGI = int.Parse(li.Value);
                foreach (ButtonListItem li in btnLstGO.Items) if (li.Selected) oK.m_iGO = int.Parse(li.Value);

                bRet = o.UpdateVendor(oK);

                if ((int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Purple))
                {
                    bRet = o.VMIDDLeadVsrMgtWtDate(lRequestId, int.Parse(ddlRemarks.SelectedValue), int.Parse(btnLstStatus.SelectedValue), txtApproverComments.Text, ValidityPeriod.SelectedDate);
                }
                else
                {
                    bRet = o.VMIDDLeadVsrMgt(lRequestId, int.Parse(ddlRemarks.SelectedValue), int.Parse(btnLstStatus.SelectedValue), txtApproverComments.Text);
                }

                if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }


    ///From ID Analyst side
    ///

    private void MailDecision(bool bRet, long lRequestId)
    {
        if (bRet)
        {
            EIdd.RequestForIDD r = o.objGetRequestById(lRequestId);

            //Get the Request Request initiator
            structUserMailIdx contractHolder = hlp.objGetUserByUserID(r.m_iUserId).structUserIdx;
            //Copy Category Lead and Request initiator.
            List<structUserMailIdx> categoryLeads = o.LstGetCategoryLeads(r);
            List<structUserMailIdx> cCopy = (categoryLeads.Count != 0) ? categoryLeads : new List<structUserMailIdx>();
            cCopy.Add(contractHolder);

            //Get the CP IDD Focal Point
            structUserMailIdx cpIddFocalPoint = hlp.objGetUserByUserID(r.m_iFocalPointId).structUserIdx;

            //Send Mail
            var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
            oSend.AnalystActionsRequest(r, cpIddFocalPoint, cCopy);

            if ((int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Purple))
            {
                // Send mail to VM/IDD lead for approval into VSR
                List<structUserMailIdx> eTos = o.LstGetIddFocalPoints(); //To CP IDD Focal Points
                oSend.AnalystActionsCompleted(r, eTos);
            }

            ajaxWebExtension.showJscriptAlertCx(Page, this, sMessage: "Successful!!!");
        }
    }

    private void LoadStageOptions()
    {
        var item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.ContactVMIDDLead);
        item.Value = ((int) EIdd.StageEnums.IddStage.ContactVMIDDLead).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Deadlocked);
        item.Value = ((int) EIdd.StageEnums.IddStage.Deadlocked).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Expired);
        item.Value = ((int) EIdd.StageEnums.IddStage.Expired).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.FinalBlacklisted);
        item.Value = ((int) EIdd.StageEnums.IddStage.FinalBlacklisted).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.GIscreened);
        item.Value = ((int) EIdd.StageEnums.IddStage.GIscreened).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Interim);
        item.Value = ((int) EIdd.StageEnums.IddStage.Interim).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.MitigationOngoing);
        item.Value = ((int) EIdd.StageEnums.IddStage.MitigationOngoing).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments);
        item.Value = ((int) EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Processinitiated);
        item.Value = ((int) EIdd.StageEnums.IddStage.Processinitiated).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.RequestRejected);
        item.Value = ((int) EIdd.StageEnums.IddStage.RequestRejected).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.SiteVisitOngoing);
        item.Value = ((int) EIdd.StageEnums.IddStage.SiteVisitOngoing).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.UndergoingGSSscreening);
        item.Value = ((int) EIdd.StageEnums.IddStage.UndergoingGSSscreening).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.others);
        item.Value = ((int) EIdd.StageEnums.IddStage.others).ToString();
        ddlRemarks.Items.Add(item);
        item.DataBind();
    }

    private void LoadStatusOptions()
    {
        var item = new ButtonListItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Amber);
        item.Value = ((int) EIdd.ReportStatusEnums.VendorStatus.Amber).ToString();
        btnLstStatus.Items.Add(item);

        item = new ButtonListItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Gray);
        item.Value = ((int) EIdd.ReportStatusEnums.VendorStatus.Gray).ToString();
        btnLstStatus.Items.Add(item);

        item = new ButtonListItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Green);
        item.Value = ((int) EIdd.ReportStatusEnums.VendorStatus.Green).ToString();
        btnLstStatus.Items.Add(item);

        item = new ButtonListItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Purple);
        item.Value = ((int) EIdd.ReportStatusEnums.VendorStatus.Purple).ToString();
        btnLstStatus.Items.Add(item);

        item = new ButtonListItem();
        item.Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Red);
        item.Value = ((int) EIdd.ReportStatusEnums.VendorStatus.Red).ToString();
        btnLstStatus.Items.Add(item);
    }

    //private void LoadAprovalOptions()
    //{
    //    var item = new ButtonListItem();
    //    item.Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.Yes);
    //    item.Value = ((int) EIdd.CompletedEnums.CompletedStatus.Yes).ToString();
    //    rdbApproved.Items.Add(item);

    //    item = new ButtonListItem();
    //    item.Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.No);
    //    item.Value = ((int) EIdd.CompletedEnums.CompletedStatus.No).ToString();
    //    rdbApproved.Items.Add(item);
    //}

    protected void btnlstCompleted_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Purple))
            Hider.Visible = true;
        else
            Hider.Visible = false;
    }
}