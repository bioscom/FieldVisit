using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


public partial class App_IDD_UserControl_oAnalystAction : aspnetUserControl
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    appUsersHelper hlp = new appUsersHelper();
    EIdd.IDDAnalystAuditTrail oT = new EIdd.IDDAnalystAuditTrail();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        LoadStageOptions();
        LoadStatusOptions();
        //LoadCompletedOptions();
        Hider.Visible = false;
        Retrieve();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
            {
                lRequestId = long.Parse(Request.QueryString["lRequestId"]);
                //Update the IDD_Request Table

                if (string.IsNullOrEmpty(ddlAction.SelectedValue))
                {
                    ajaxWebExtension.showJscriptAlertCx(Page, this, sMessage: "Please, select your decision.");
                }
                else
                {
                    bool bRet = false;
                    if ((int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Purple))
                    {
                        if (ValidityPeriod.SelectedDate != null)
                        {
                            bRet = o.AnalystActionRequest(lRequestId, int.Parse(btnLstStatus.SelectedValue), int.Parse(ddlAction.SelectedValue), txtComment.Text, ValidityPeriod.SelectedDate);

                            //Update Audit Trail Table
                            bRet = oT.RequestActionAuditTrail(lRequestId, oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlAction.SelectedValue), int.Parse(btnLstStatus.SelectedValue), txtComment.Text);
                            MailDecision(bRet, lRequestId);
                            if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                        }
                        else
                        {
                            ajaxWebExtension.showJscriptAlertCx(Page, this, "Please, select Effective Date");
                        }
                    }
                    else
                    {
                        bRet = o.AnalystActionRequest2(lRequestId, int.Parse(btnLstStatus.SelectedValue), txtComment.Text);
                        if (bRet)
                        {
                            //Update Audit Trail Table
                            bRet = oT.RequestActionAuditTrail(lRequestId, oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlAction.SelectedValue), int.Parse(btnLstStatus.SelectedValue), txtComment.Text);
                            MailDecision(bRet, lRequestId);
                            if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

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

            //if ((int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int) EIdd.ReportStatusEnums.VendorStatus.Purple))
            //{
            //    // Send mail to VM/IDD lead for approval into VSR
            //    List<structUserMailIdx> eTos = o.LstGetIddFocalPoints(); //To CP IDD Focal Points
            //    oSend.AnalystActionsCompleted(r, eTos);
            //}

            ajaxWebExtension.showJscriptAlertCx(Page, this, sMessage: "Successful!!!");
        }
    }

    private void LoadStageOptions()
    {
        var item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.ContactVMIDDLead);
        item.Value = ((int) EIdd.StageEnums.IddStage.ContactVMIDDLead).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Deadlocked);
        item.Value = ((int) EIdd.StageEnums.IddStage.Deadlocked).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Expired);
        item.Value = ((int) EIdd.StageEnums.IddStage.Expired).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.FinalBlacklisted);
        item.Value = ((int) EIdd.StageEnums.IddStage.FinalBlacklisted).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.GIscreened);
        item.Value = ((int) EIdd.StageEnums.IddStage.GIscreened).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Interim);
        item.Value = ((int) EIdd.StageEnums.IddStage.Interim).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.MitigationOngoing);
        item.Value = ((int) EIdd.StageEnums.IddStage.MitigationOngoing).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments);
        item.Value = ((int) EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Processinitiated);
        item.Value = ((int) EIdd.StageEnums.IddStage.Processinitiated).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.RequestRejected);
        item.Value = ((int) EIdd.StageEnums.IddStage.RequestRejected).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.SiteVisitOngoing);
        item.Value = ((int) EIdd.StageEnums.IddStage.SiteVisitOngoing).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.UndergoingGSSscreening);
        item.Value = ((int) EIdd.StageEnums.IddStage.UndergoingGSSscreening).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.others);
        item.Value = ((int) EIdd.StageEnums.IddStage.others).ToString();
        ddlAction.Items.Add(item);
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

    private void Retrieve()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
        {
            long lRequestId = 0;
            lRequestId = long.Parse(Request.QueryString["lRequestId"]);

            EIdd.RequestForIDD t = o.objGetNewRequestById(lRequestId);

            ddlAction.SelectedValue = t.m_iStage.ToString();
            btnLstStatus.SelectedValue = t.m_iStatus.ToString();
            if ((int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Green) || (int.Parse(btnLstStatus.SelectedValue) == (int)EIdd.ReportStatusEnums.VendorStatus.Purple))
                Hider.Visible = true;
            else
                Hider.Visible = false;
            ValidityPeriod.SelectedDate = t.m_dValidityPeriod;
            txtComment.Text = t.m_sComments; //t.m_sApproverComment;

            ColorCode();
        }
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