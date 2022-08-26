using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_IDD_UserControl_oVMIDDApproval : aspnetUserControl
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.IDDAnalystAuditTrail oT = new EIdd.IDDAnalystAuditTrail();
    appUsersHelper hlp = new appUsersHelper();


    protected void Page_Init(object sender, EventArgs e)
    {
        LoadStageOptions();
        LoadStatusOptions();
        LoadAprovalOptions();
        Hider.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["lAuditId"]))
                {
                    long lAuditId = long.Parse(Request.QueryString["lAuditId"]);

                    InitialiseControls(lAuditId);
                }
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    public void InitialiseControls(long lAuditId)
    {
        EIdd.AnalystAuditTrail oA = oT.objGetAnalystAuditTrailById(lAuditId);
        ddlRemarks.SelectedValue = oA.m_iStage.ToString();
        btnLstStatus.SelectedValue = oA.m_iStatus.ToString();
        ColorCode();
        txtComment.Text = oA.m_sComments;
        //rdbApproved.SelectedValue = o.
        txtApproverComments.Text = oA.m_sApproverComments;

        if ((int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Purple))
        {
            Hider.Visible = true;
            ValidityPeriod.SelectedDate = o.objGetRequestById(oA.m_lRequestId).m_dValidityPeriod;
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
            long lRequestId = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["lAuditId"]))
            {
                long lAuditId = long.Parse(Request.QueryString["lAuditId"]);

                lRequestId = oT.objGetAnalystAuditTrailById(lAuditId).m_lRequestId;
                
                if (rdbApproved.SelectedValue == null)
                {
                    ajaxWebExtension.showJscriptAlertCx(Page, this, "Please, select Move status to VSR?");
                }
                else
                {
                    //Update Audit Trail Table
                    bRet = oT.UpdateActionAuditTrail(lAuditId, oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlRemarks.SelectedValue), int.Parse(btnLstStatus.SelectedValue), int.Parse(rdbApproved.SelectedValue), txtComment.Text, txtApproverComments.Text);
                    MailDecision(bRet, lRequestId);

                    //if approved, change the status in the VSR
                    if (int.Parse(rdbApproved.SelectedValue) == (int) EIdd.CompletedEnums.CompletedStatus.Yes)
                    {
                        bRet = o.VMIDDActionRequest(lRequestId, int.Parse(ddlRemarks.SelectedValue), int.Parse(btnLstStatus.SelectedValue), int.Parse(rdbApproved.SelectedValue), txtApproverComments.Text);
                        //Send mail to Request initiator (i.e. Initiator), copy IDD Analyst that the IDD request has been approved.
                    }

                    if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                    else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
                }
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

    private void LoadAprovalOptions()
    {
        var item = new ButtonListItem();
        item.Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.Yes);
        item.Value = ((int) EIdd.CompletedEnums.CompletedStatus.Yes).ToString();
        rdbApproved.Items.Add(item);

        item = new ButtonListItem();
        item.Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.No);
        item.Value = ((int) EIdd.CompletedEnums.CompletedStatus.No).ToString();
        rdbApproved.Items.Add(item);
    }

    protected void btnlstCompleted_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Purple))
            Hider.Visible = true;
        else
            Hider.Visible = false;

        ColorCode();
    }

    private void ColorCode()
    {
        if ((int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Green)) pnlColour.BackColor = System.Drawing.Color.Green;
        else if ((int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Amber)) pnlColour.BackColor = System.Drawing.Color.DarkOrange;
        else if ((int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Gray)) pnlColour.BackColor = System.Drawing.Color.Gray;
        else if ((int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Purple)) pnlColour.BackColor = System.Drawing.Color.Purple;
        else if ((int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Red)) pnlColour.BackColor = System.Drawing.Color.Red;
    }
}