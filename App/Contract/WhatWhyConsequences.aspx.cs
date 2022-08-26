using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Contract_WhatWhyConsequences : aspnetPage
{
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractLessonsLearnt oContractLessonsLearnt = new ContractLessonsLearnt();
    ContractLessonsLearntHelper oContractLessonsLearntHelper = new ContractLessonsLearntHelper();
    PriorityHelper oPriorityHelper = new PriorityHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtTripStart.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
            dtTripStart.ImageBtn.Enabled = false;
            dtTripStart.txtDateTextBox.Enabled = false;

            if (oSessnx.getOnlineUser.m_iRoleIdContract == (int)appUsersRoles.userRole.admin)
            {
                LoadData();
            }
            else
            {
                SuperintendentFunctionalAcctUser MySuperintendents = SuperintendentFunctionalAcctUser.objGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
                if (MySuperintendents.superintendentId == 0)
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, You do not have right to enter data for " + District.objGetDistrictById(int.Parse(Request.QueryString["dstrt"].ToString())).m_sDistrict + " District. Contact the System Administrator.");
                }
                else LoadData();
            }
        }
    }

    private void LoadData()
    {
        List<Priority> lstPriority = oPriorityHelper.lstGetPriorityBySection();
        int i = lstPriority.Count;
        foreach (Priority oPriority in lstPriority)
        {
            if (oPriority.iPriorityId == 6) //TODO: Please to review this code,, this is hard coding. You may need to split the table, what you are running from.
            {
                ActivityChange1.Init_Page(oPriority.iPriorityId, oPriority.sPriority, int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStart.dtSelectedDate);
                //lblActivityChanges.Text = oPriority.sPriority;
                //activityChangePriorityHF.Value = oPriority.iPriorityId.ToString();
                //LoadActivityChange(oPriority.iPriorityId);
            }
            else if (oPriority.iPriorityId == 7)
            {
                BusinessImprovement1.Init_Page(oPriority.iPriorityId, oPriority.sPriority, int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStart.dtSelectedDate);

                //lblBusinessImprovement.Text = oPriority.sPriority;
                //businessImprovementPriorityHF.Value = oPriority.iPriorityId.ToString();
                //LoadBusinessImprovement(oPriority.iPriorityId);
            }
            else if (oPriority.iPriorityId == 8)
            {
                LessonLearnt1.Init_Page(oPriority.iPriorityId, oPriority.sPriority, int.Parse(Request.QueryString["dstrt"].ToString()), dtTripStart.dtSelectedDate);
                //lblLessonLearnt.Text = oPriority.sPriority;
                //lessonLearntPriorityHF.Value = oPriority.iPriorityId.ToString();
                //LoadLessonLearnt(oPriority.iPriorityId);
            }
        }
    }
}