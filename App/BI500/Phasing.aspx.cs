using System;
using System.Collections.Generic;
using Microsoft.Security.Application;
using System.Web.UI.WebControls;

public partial class App_BI500_Phasing : aspnetPage
{
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    CostReductionRequest oBI500Request = new CostReductionRequest();
    BenefitsMgt oBenefitsMgt = new BenefitsMgt();
    PotentialBenefitMgt oPotentialBenfit = new PotentialBenefitMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["RequestId"] != null)
            {
                long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["RequestId"].ToString()));
                oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

                oRequestDetails1.Init_Control(oBI500Request);

                rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.Identify), ((int)BIRequestStatus.RequestPhasing.Identify).ToString()));
                rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.Eliminate), ((int)BIRequestStatus.RequestPhasing.Eliminate).ToString()));
                rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.Sustain), ((int)BIRequestStatus.RequestPhasing.Sustain).ToString()));
                rdbPhasing.Items.Add(new ListItem(BIRequestStatus.RequestPhasingDesc(BIRequestStatus.RequestPhasing.HandOver), ((int)BIRequestStatus.RequestPhasing.HandOver).ToString()));

                if (oBI500Request.iPhase != 0)
                    rdbPhasing.SelectedValue = oBI500Request.iPhase.ToString();
                rdbPhasing.Text = "Current Project Phase";

                txtTeamMembers.Text = oBI500Request.sTeamMembers;
                
                btnSubmitSustain.Visible = false;

                if (oBI500Request.iPhase == (int)BIRequestStatus.RequestPhasing.HandOver)
                {
                    btnSubmit.Enabled = false;
                }
            }
            SustainShow(oBI500Request);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["RequestId"].ToString()));
        
        //Update Phasing
        oBI500RequestHelper.UpdateRequestPhase(lRequestId, int.Parse(rdbPhasing.SelectedValue), txtTeamMembers.Text);
        ForwardMail(lRequestId);
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/BI500/MyBrightIdeas.aspx");
    }

    protected void rdbPhasing_SelectedIndexChanged(object sender, EventArgs e)
    {
        long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["RequestId"].ToString()));
        oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

        SequencePhasing(oBI500Request);
        SustainShow(oBI500Request);
    }

    private void SustainShow(CostReductionRequest oBI500Request)
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

                    txtQtyBenefit.Text = oBI500Request.sQtyBenefit;
                    drpImprovement.SelectedValue = oBI500Request.iImprovement.ToString();
                    drpPotential.SelectedValue = oBI500Request.iReplication.ToString();
                    dtFinishDate.dtSetDate(oBI500Request.dCompletionDate);             
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
        long lRequestId = long.Parse(Encoder.HtmlEncode(Request.QueryString["RequestId"].ToString()));

        oBI500RequestHelper.UpdateRequestSustainPhase(lRequestId, int.Parse(rdbPhasing.SelectedValue), int.Parse(drpImprovement.SelectedValue), int.Parse(drpPotential.SelectedValue), txtQtyBenefit.Text, dtFinishDate.dtSelectedDate);

        ForwardMail(lRequestId);
    }

    private void ForwardMail(long lRequestId)
    {
        //A mail should go to Project Champion that the Initiator has updated the Project Phase Status
        //And copy Project Sponsor and Project Lean Team Support Focal Point         

        List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
        oBI500Request = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);
        oCopy.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iUserId).structUserIdx);
        oCopy.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iFocalPointUserId).structUserIdx);
        oCopy.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectChampionUserId).structUserIdx);
        oCopy.Add(oappUsersHelper.objGetUserByUserID(oBI500Request.iProjectSponsorUserId).structUserIdx);
        oCopy.Add(oSessnx.getOnlineUser.structUserIdx);

        sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.BIPhaseUpdated(oBI500Request, oSessnx.getOnlineUser, oCopy);

        Response.Redirect("~/App/BI500/MyBrightIdeas.aspx");
    }
}