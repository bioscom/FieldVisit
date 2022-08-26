using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_ManHour_UserControl_ViewComments : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Init_Page(long lInitiativeId)
    {
        lInitiativeHF.Value = lInitiativeId.ToString();
        InitValues();
        RetrieveData(lInitiativeId);
    }
    private void RetrieveData(long lInitiativeId)
    {
        InitiativeApproval oInitiativeApproval = new InitiativeApproval();
        grdView.DataSource = oInitiativeApproval.dtApproverByInitiative(lInitiativeId);
        grdView.DataBind();

        ApprovalStatus(grdView);
        //if (Request.QueryString["ProposalId"].ToString() != "")
        //{
        //    long lProposalId = long.Parse(Request.QueryString["ProposalId"].ToString());
        //    ProposalDetailedInfo1.Page_Init(lProposalId);

        //    ProposalApprovalMgt oProposalApprovalMgt = new ProposalApprovalMgt();
        //    ProposalApproval oProposalApproval = oProposalApprovalMgt.objGetApprovalDetailsByProposalId(lProposalId);

        //    grdView.DataSource = oProposalApprovalMgt.dtGetApprovalDetailsByProposalId(lProposalId);
        //    grdView.DataBind();
        //    oStatus.ProposalStatusReporter(grdView);
        //}
    }
    public void InitValues()
    {
        //lInitiativeHF.Value = lInitiativeId.ToString();
        try
        {
            ////Load Activity Sponsors
            //drpSponsor.Items.Clear();
            //drpSponsor.Items.Add(new ListItem("--Select Activity Sponsor", "-1"));
            ////List<appUsers> ActivitySponsors = appUsersHelper.lstGetApproversByRole((int)appUsersRoles.userRole.sponsor);
            //List<appUsers> ActivitySponsors = appUsersHelper.lstGetUsers();
            //foreach (appUsers ActivitySponsor in ActivitySponsors)
            //{
            //    drpSponsor.Items.Add(new ListItem(ActivitySponsor.m_sFullName, ActivitySponsor.m_iUserId.ToString()));
            //}

            //ddlSponsor.initUserInfo("To locate user quickly, click on search botton.", 250);

            //List<appUsers> AssetManagers = appUsersHelper.lstGetApproversByRole((int)appUsersRoles.userRole.AssetOperationsManager);
            //foreach (appUsers AssetManager in AssetManagers)
            //{
            //    assetMgrCkbLst.Items.Add(new ListItem(AssetManager.m_sFullName, AssetManager.m_iUserId.ToString()));
            //}

            //List<appUsers> FunctionalLeads = appUsersHelper.lstGetApproversByRole((int)appUsersRoles.userRole.FunctionalLead);
            //foreach (appUsers FunctionalLead in FunctionalLeads)
            //{
            //    funcMgrCkbLst.Items.Add(new ListItem(FunctionalLead.m_sFullName, FunctionalLead.m_iUserId.ToString()));
            //}

            //Retrieve_Data(lInitiativeId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void reminderButton_Click(object sender, EventArgs e)
    {
        //UserAccountMgt oUserAccountMgt = new UserAccountMgt();
        //Users oUser = new Users();
        //List<structUserMailIdx> oReceiver = new List<structUserMailIdx>();
        //foreach (GridViewRow grdRows in grdView.Rows)
        //{
        //    CheckBox ckb = (CheckBox)grdRows.FindControl("reminderCheckBox");
        //    if (ckb.Checked)
        //    {
        //        oReceiver.Add(new structUserMailIdx(oUserAccountMgt.objGetUserByUserId(int.Parse(ckb.Attributes["IDUSER"].ToString())).structUserIdx));
        //    }
        //}

        //long lProposalId = long.Parse(Request.QueryString["ProposalId"].ToString());
        //ProposalMgt oProposalMgt = new ProposalMgt();
        //Proposal oProposal = oProposalMgt.objGetProposalByProposalId(lProposalId);
        //sendMail emailSystem = new sendMail(oSessnx.getOnlineUser.structUserIdx);
        //bool sent = emailSystem.SendMailToNextSupportApprover(oReceiver, oProposal);
        //if (sent)
        //{
        //    string mssg = "Proposal reminder sent to selected support/approver.";
        //    ajaxWebExtension.showJscriptAlert(Page, this, mssg);
        //}
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grdView.PageIndex = e.NewPageIndex;
        //RetrieveData();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdView_Load(object sender, EventArgs e)
    {

    }

    private void ApprovalStatus(GridView grd)
    {
        foreach (GridViewRow grdRow in grd.Rows)
        {
            Label lblStand = (Label)grdRow.FindControl("labelStand");
            Label lblRole = (Label)grdRow.FindControl("labelRole");

            if (lblStand != null)
            {
                if (int.Parse(lblStand.Text) == (int)Approval.apprStatusRpt.NoComment)
                {
                    lblStand.ForeColor = System.Drawing.Color.OrangeRed;
                    lblStand.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NoComment);
                }
                else if (int.Parse(lblStand.Text) == (int)Approval.apprStatusRpt.NotApproved)
                {
                    lblStand.ForeColor = System.Drawing.Color.Red;
                    lblStand.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.NotApproved);
                }
                else if (int.Parse(lblStand.Text) == (int)Approval.apprStatusRpt.Approved)
                {
                    lblStand.ForeColor = System.Drawing.Color.Green;
                    lblStand.Text = Approval.StatusRptDesc(Approval.apprStatusRpt.Approved);
                }
            }

            if (lblRole != null)
            {
                if (int.Parse(lblRole.Text) == (int)appUsersRoles.userRole.sponsor)
                {
                    lblRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.sponsor);
                }
                else if (int.Parse(lblRole.Text) == (int)appUsersRoles.userRole.FunctionalLead)
                {
                    lblRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.FunctionalLead);
                }
                else if (int.Parse(lblRole.Text) == (int)appUsersRoles.userRole.AssetOperationsManager)
                {
                    lblRole.Text = appUsersRoles.userRoleDesc(appUsersRoles.userRole.AssetOperationsManager);
                }
            }
        }
    }
}