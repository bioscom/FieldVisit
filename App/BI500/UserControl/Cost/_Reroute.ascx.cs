using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_UserControl_Cost_Reroute : aspnetUserControl
{
    BenefitsMgt oBenefitsMgt = new BenefitsMgt();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    CostReductionRequest o = new CostReductionRequest();
    appUsersHelper oappUsersHelper = new appUsersHelper();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlInformation.Visible = true;
            pnlShow.Visible = false;
        }
    }

    public void Init_Page(long lRequestId)
    {
        try
        {
            if (lRequestId == 0)
            {
                pnlInformation.Visible = true;
                pnlShow.Visible = false;
            }
            else
            {
                pnlInformation.Visible = false;
                pnlShow.Visible = true;

                //Assign the RequestId into an Hidden control, to be used in other actions
                HFRequestId.Value = lRequestId.ToString();

                //Retrieve the Bright Idea or Cost Reduction Idea into object instance (o)
                o = oBI500RequestHelper.objGetBrightIdeaById(lRequestId);

                lblRequestNo.Text = o.sRequestNumber;
                lblProjectTitle.Text = o.sTitle;

                appUsers oFocalPoint = oappUsersHelper.objGetUserByUserID(o.iFocalPointUserId);
                appUsers oInitiativeLead = oappUsersHelper.objGetUserByUserID(o.iInitiativeLeadUserId);
                appUsers oWorkStreamOwner = oappUsersHelper.objGetUserByUserID(o.iProjectChampionUserId);
                appUsers oWorkStreamSponsor = oappUsersHelper.objGetUserByUserID(o.iProjectSponsorUserId);

                HFRequestStatus.Value = o.iStatus.ToString(); HFInitiator.Value = o.iUserId.ToString();

                lblFocalPoint.Text = oFocalPoint.m_sFullName;
                HFFocalPointId.Value = oFocalPoint.m_iUserId.ToString();

                lblInitiativeLead.Text = oInitiativeLead.m_sFullName;
                HFInitLeadId.Value = oInitiativeLead.m_iUserId.ToString();

                lblWorkStreamOwner.Text = oWorkStreamOwner.m_sFullName;
                HFChampionId.Value = oWorkStreamOwner.m_iUserId.ToString();

                lblWorkStreamSponsor.Text = oWorkStreamSponsor.m_sFullName;
                HFSponsorId.Value = oWorkStreamSponsor.m_iUserId.ToString();

                lblStatus.Text = BIRequestStatus.RequestStatusRptDesc((BIRequestStatus.RequestStatusRpt)o.iStatus);

                FocalPoint.editMode();
                FocalPoint.thisDropDownList.Items.Add(new ListItem(oFocalPoint.m_sFullName, oFocalPoint.m_iUserId.ToString()));
                FocalPoint.thisDropDownList.SelectedValue = o.iFocalPointUserId.ToString();

                InitiativeLead.editMode();
                InitiativeLead.thisDropDownList.Items.Add(new ListItem(oInitiativeLead.m_sFullName, oInitiativeLead.m_iUserId.ToString()));
                InitiativeLead.thisDropDownList.SelectedValue = o.iInitiativeLeadUserId.ToString();

                Sponsor.editMode();
                Sponsor.thisDropDownList.Items.Add(new ListItem(oWorkStreamSponsor.m_sFullName, oWorkStreamSponsor.m_iUserId.ToString()));
                Sponsor.thisDropDownList.SelectedValue = o.iProjectSponsorUserId.ToString();

                champion.editMode();
                champion.thisDropDownList.Items.Add(new ListItem(oWorkStreamOwner.m_sFullName, oWorkStreamOwner.m_iUserId.ToString()));
                champion.thisDropDownList.SelectedValue = o.iProjectChampionUserId.ToString();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }


    protected void Reroute_Click(object sender, EventArgs e)
    {
        try
        {
            //Send mail
            List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
            List<structUserMailIdx> oReceivers = new List<structUserMailIdx>();

            bool bRet = false;
            long lRequestId = long.Parse(HFRequestId.Value);

            //Get all actors...
            int iFocalPoint = (FocalPoint._SelectedValue == "-1") ? int.Parse(HFFocalPointId.Value) : int.Parse(FocalPoint._SelectedValue);
            int iInitiativeLead = (InitiativeLead._SelectedValue == "-1") ? int.Parse(HFInitLeadId.Value) : int.Parse(InitiativeLead._SelectedValue);
            int iChampion = (champion._SelectedValue == "-1") ? int.Parse(HFChampionId.Value) : int.Parse(champion._SelectedValue);
            int iSponsor = (Sponsor._SelectedValue == "-1") ? int.Parse(HFSponsorId.Value) : int.Parse(Sponsor._SelectedValue);


            int iStatus = int.Parse(HFRequestStatus.Value); //The current status of the Request...
            bRet = oBI500RequestHelper.AssignFocalPoint(lRequestId, iFocalPoint);
            bRet = oBI500RequestHelper.AssignInitiativeLeadChampionSponsor(lRequestId, iSponsor, iChampion, iInitiativeLead);

            if (iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsFocalPointAction)
            {
                //Assign the request to Functional/Department FocalPoint into the RequestApproval(Workflow) Table
                bRet = oBI500RequestHelper.RouteRequestWithinApprovers(lRequestId, (int)appUsersRolesBI500.userRole.focalPoint, iFocalPoint);
                oReceivers.Add(oappUsersHelper.objGetUserByUserID(iFocalPoint).structUserIdx);  //Work stream Sponsor
            }
            else if (iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectSponsorApproval)
            {
                //Assign the request to Project Sponsor into the RequestApproval(Workflow) Table
                bRet = oBI500RequestHelper.RouteRequestWithinApprovers(lRequestId, (int)appUsersRolesBI500.userRole.sponsor, iSponsor);
                oReceivers.Add(oappUsersHelper.objGetUserByUserID(iSponsor).structUserIdx);  //Work stream Sponsor
            }
            else if (iStatus == (int)BIRequestStatus.RequestStatusRpt.AwaitsProjectChampionSupport)
            {
                //Assign the request to Project Champion into the RequestApproval(Workflow) Table
                bRet = oBI500RequestHelper.RouteRequestWithinApprovers(lRequestId, (int)appUsersRolesBI500.userRole.champion, iChampion);
                oReceivers.Add(oappUsersHelper.objGetUserByUserID(iChampion).structUserIdx);  //Work stream Owner
            }

            //oCopy = oBI500RequestHelper.BIReviewersEmail();
            oCopy.Add(oappUsersHelper.objGetUserByUserID(int.Parse(HFInitiator.Value)).structUserIdx); //Copy Initiator

            sendMailBI500 oSendMail = new sendMailBI500(oSessnx.getOnlineUser.structUserIdx);
            oSendMail.ForwardImprovementIdeaForSupportApproval(o, oReceivers, oCopy);
            if (bRet)
            {
                Init_Page(lRequestId);
                ajaxWebExtension.showJscriptAlertCx(Page, this, "Successfully Rerouted!!!");
            }

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/BI500/CostReductionForMyAction.aspx");
    }
}