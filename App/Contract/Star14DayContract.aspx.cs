using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;

public partial class App_Contract_Star14DayContract : aspnetPage
{
    readonly PriorityHelper oPriorityHelper = new PriorityHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDailyDataInputForm();
            if (oSessnx.getOnlineUser.m_iRoleIdContract == (int) AppUsers14DaysContract.UserRole.OperationsManager)
            {
                actionLnk.Visible = true;
                DailyDataInputForm1.ForwardForApproval.Enabled = false;
            }
            else
            {
                actionLnk.Visible = false;
            }
        }
    }

    private void LoadDailyDataInputForm()
    {
        try
        {
            if (Request.QueryString["bRet"] != null)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Successfully submitted.");
                DailyDataInputForm1.DtDateTripStarts.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
                DailyDataInputForm1.DtDateTripStarts.ImageBtn.Enabled = false;
                DailyDataInputForm1.DtDateTripStarts.txtDateTextBox.Enabled = false;

                dtTripStart2.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
                dtTripStart2.ImageBtn.Enabled = false;
                dtTripStart2.txtDateTextBox.Enabled = false;

                DailyDataInputForm1.Init_Page();
                LoadDataWhatWhyConsequences();
            }
            else
            {
                DailyDataInputForm1.DtDateTripStarts.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
                DailyDataInputForm1.DtDateTripStarts.ImageBtn.Enabled = false;
                DailyDataInputForm1.DtDateTripStarts.txtDateTextBox.Enabled = false;

                dtTripStart2.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
                dtTripStart2.ImageBtn.Enabled = false;
                dtTripStart2.txtDateTextBox.Enabled = false;

                if (oSessnx.getOnlineUser.m_iRoleIdContract == (int)AppUsers14DaysContract.UserRole.Administrator)
                {
                    DailyDataInputForm1.Init_Page();
                    LoadDataWhatWhyConsequences();
                }
                else
                {
                    SuperintendentFunctionalAcctUser oSuperintendents = SuperintendentFunctionalAcctUser.objGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
                    if (oSuperintendents.superintendentId == 0)
                    {
                        ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, You do not have right to enter data for " + District.objGetDistrictById(int.Parse(Request.QueryString["dstrt"].ToString())).m_sDistrict + " District. Contact the System Administrator.");
                    }
                    else
                    {
                        DailyDataInputForm1.Init_Page();
                        LoadDataWhatWhyConsequences();
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

    private void LoadDataWhatWhyConsequences()
    {
        List<Priority> lstPriority = oPriorityHelper.lstGetPriorityBySection();
        int i = lstPriority.Count;
        foreach (Priority oPriority in lstPriority)
        {
            if (oPriority.iPriorityId == 6) //TODO: Please to review this code,, this is hard coding. You may need to split the table, what you are running from.
            {
                ActivityChange1.Init_Page(oPriority.iPriorityId, oPriority.sPriority, int.Parse(Request.QueryString["dstrt"].ToString()), DailyDataInputForm1.DtDateTripStarts.dtSelectedDate);
            }
            else if (oPriority.iPriorityId == 7)
            {
                BusinessImprovement1.Init_Page(oPriority.iPriorityId, oPriority.sPriority, int.Parse(Request.QueryString["dstrt"].ToString()), DailyDataInputForm1.DtDateTripStarts.dtSelectedDate);
            }
            else if (oPriority.iPriorityId == 8)
            {
                LessonLearnt1.Init_Page(oPriority.iPriorityId, oPriority.sPriority, int.Parse(Request.QueryString["dstrt"].ToString()), DailyDataInputForm1.DtDateTripStarts.dtSelectedDate);
            }
        }
    }

    protected void txtApprove_Click(object sender, EventArgs e)
    {
        structUserMailIdx eSender = new structUserMailIdx(oSessnx.getOnlineUser.m_sUserName, oSessnx.getOnlineUser.m_sUserMail, oSessnx.getOnlineUser.m_iUserId.ToString());
        SendMail14DaysContract emailSender = new SendMail14DaysContract(eSender);

        //Update the CONTRACT_APPROVAL Table.

        ContractApproval oContractApproval = new ContractApproval
        {
            iUserId = oSessnx.getOnlineUser.m_iUserId,
            iDistrictId = int.Parse(Request.QueryString["dstrt"]),
            dtTripStartDate = DailyDataInputForm1.DtDateTripStarts.dtSelectedDate,
            iStatus = int.Parse(ddlStand.SelectedValue),
            sComments = txtComments.Text,
        };

        bool bRet = ContractApprovalHelper.Approved(oContractApproval);
        if (bRet)
        {
            //Get superintendent that submitted the 
            //List<OpsMgrFunctionalAcctUserDetails> lstOpsMgrFunctionalAcctUser = Superintendent.lstGetSuperintendent(); //OpsMgrFunctionalAcctUser.lstGetSuperintendentFunctionalAcctUsers();
            //eOpsMgr.AddRange(lstOpsMgrFunctionalAcctUser.Select(opsMgr => appUsersHelper.objGetUserByUserId(opsMgr.iUserId).structUserIdx));


            //Send an email to all involved
            //bRet = emailSender.RequestApproved(oSessnx.getOnlineUser, District.objGetDistrictById(oContractApproval.iDistrictId).m_sDistrict, sStartDate, sEndDate, eOpsMgr);
            //if (bRet)
            //{
            //    ajaxWebExtension.showJscriptAlert(Page, this, "Your 14 days contract has been sucessfully approved.");
            //}
        }
    }
}