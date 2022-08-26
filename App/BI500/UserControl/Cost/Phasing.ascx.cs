using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class App_BI500_UserControl_Cost_Phasing : aspnetUserControl
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    CostReductionRequest o = new CostReductionRequest();
    BenefitsMgt oBenefitsMgt = new BenefitsMgt();
    PotentialBenefitMgt oPotentialBenfit = new PotentialBenefitMgt();

    public void Init_Page(long lRequestId)
    {
        rdbPhasing.Items.Clear();

        o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        HFRequestId3.Value = lRequestId.ToString();

        lblRequestNumber.Text = o.sRequestNumber;
        lblTitle.Text = o.sTitle;
        lblDateInit.Text = o.dDateSubmitted.ToLongDateString();

        rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.Identify), ((int)BIRequestStatus.RequestPhasing.Identify).ToString()));
        rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.Eliminate), ((int)BIRequestStatus.RequestPhasing.Eliminate).ToString()));
        rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.Sustain), ((int)BIRequestStatus.RequestPhasing.Sustain).ToString()));
        rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.HandOver), ((int)BIRequestStatus.RequestPhasing.HandOver).ToString()));

        if (o.iPhase != 0) rdbPhasing.SelectedValue = o.iPhase.ToString();

        //rdbPhasing.Text = "Current Project Phase";

        txtTeamMembers.Text = o.sTeamMembers;

        btnSubmitSustain.Visible = false;

        if (o.iPhase == (int)BIRequestStatus.RequestPhasing.HandOver)
        {
            btnSubmit.Enabled = false;
        }
        SustainShow(o);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(HFRequestId3.Value);

        //Update Phasing
        oBI500RequestHelper.UpdateRequestPhase(lRequestId, int.Parse(rdbPhasing.SelectedValue), txtTeamMembers.Text);
        ajaxWebExtension.showJscriptAlertCx(Page, this, "Successful!!!");
        ForwardMail(lRequestId);
    }

    protected void rdbPhasing_SelectedIndexChanged(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(HFRequestId3.Value);
        o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

        SequencePhasing(o);
        SustainShow(o);
    }

    private void SustainShow(CostReductionRequest o)
    {
        try
        {
            if (!string.IsNullOrEmpty(rdbPhasing.SelectedValue))
            {
                if (int.Parse(rdbPhasing.SelectedValue) == (int)BIRequestStatus.RequestPhasing.Sustain)
                {
                    pnlSustain.Visible = true;
                    btnSubmit.Visible = false;
                    btnSubmitSustain.Visible = true;

                    List<Benefits> oBenefits = oBenefitsMgt.lstBenefits();
                    foreach (Benefits oBenefit in oBenefits)
                    {
                        drpImprovement.Items.Add(new ListItem(oBenefit.m_sBenefit, oBenefit.m_iBenefitId.ToString()));
                    }

                    List<PotentialBenefit> oPotentials = oPotentialBenfit.lstPotentialBenefit();
                    foreach (PotentialBenefit oBenefit in oPotentials)
                    {
                        drpPotential.Items.Add(new ListItem(oBenefit.m_sPotential, oBenefit.m_iReplicationId.ToString()));
                    }

                    txtQtyBenefit.Text = o.sQtyBenefit;
                    drpImprovement.SelectedValue = o.iImprovement.ToString();
                    drpPotential.SelectedValue = o.iReplication.ToString();
                    dtFinishDate.dtSetDate(o.dCompletionDate);
                }
                else if (int.Parse(rdbPhasing.SelectedValue) == (int)BIRequestStatus.RequestPhasing.HandOver)
                {
                    pnlSustain.Visible = true;
                    btnSubmit.Visible = false;
                    btnSubmitSustain.Visible = false;
                }
                else
                {
                    pnlSustain.Visible = false;
                    btnSubmit.Visible = true;
                }
            }
            else
            {
                pnlSustain.Visible = false;
                btnSubmit.Visible = true;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void SequencePhasing(CostReductionRequest oBI500Request)
    {
        try
        {
            if (oBI500Request.iPhase == (int)BIRequestStatus.RequestPhasing.iDefault)
            {
                if (int.Parse(rdbPhasing.SelectedValue) != (int)BIRequestStatus.RequestPhasing.Identify)
                {
                    rdbPhasing.SelectedValue = oBI500Request.iPhase.ToString();
                    ajaxWebExtension.showJscriptAlert(Page, this, "Identify Phase expected to be selected.");
                }
            }
            else if (oBI500Request.iPhase == (int)BIRequestStatus.RequestPhasing.Identify)
            {
                if (int.Parse(rdbPhasing.SelectedValue) != (int)BIRequestStatus.RequestPhasing.Eliminate)
                {
                    rdbPhasing.SelectedValue = oBI500Request.iPhase.ToString();
                    ajaxWebExtension.showJscriptAlert(Page, this, "Eliminate Phase expected to be selected.");
                }
            }
            else if (oBI500Request.iPhase == (int)BIRequestStatus.RequestPhasing.Eliminate)
            {
                if (int.Parse(rdbPhasing.SelectedValue) != (int)BIRequestStatus.RequestPhasing.Sustain)
                {
                    rdbPhasing.SelectedValue = oBI500Request.iPhase.ToString();
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sustain Phase expected to be selected.");
                }
            }
            else if (oBI500Request.iPhase == (int)BIRequestStatus.RequestPhasing.Sustain)
            {
                if (int.Parse(rdbPhasing.SelectedValue) != (int)BIRequestStatus.RequestPhasing.HandOver)
                {
                    rdbPhasing.SelectedValue = oBI500Request.iPhase.ToString();
                    ajaxWebExtension.showJscriptAlert(Page, this, "HandOver Phase expected to be selected.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnSubmitSustain_Click(object sender, EventArgs e)
    {
        //Update Phasing
        long lRequestId = long.Parse(HFRequestId3.Value);

        oBI500RequestHelper.UpdateRequestSustainPhase(lRequestId, int.Parse(rdbPhasing.SelectedValue), int.Parse(drpImprovement.SelectedValue), int.Parse(drpPotential.SelectedValue), txtQtyBenefit.Text, dtFinishDate.dtSelectedDate);

        ForwardMail(lRequestId);
    }

    private void ForwardMail(long lRequestId)
    {
        //A mail should go to Project Champion that the Initiator has updated the Project Phase Status
        //And copy Project Sponsor and Project Lean Team Support Focal Point         

        List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
        o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iUserId).structUserIdx);
        //oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId).structUserIdx);
        oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId).structUserIdx);
        oCopy.Add(oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId).structUserIdx);
        oCopy.Add(oSessnx.getOnlineUser.structUserIdx);

        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.BIPhaseUpdated(o, oSessnx.getOnlineUser, oCopy);

        //Response.Redirect("~/App/BI500/MyBrightIdeas.aspx");
    }
}