using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Contract_UserControls_ActivityChange : aspnetUserControl
{
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractLessonsLearnt oContractLessonsLearnt = new ContractLessonsLearnt();
    ContractLessonsLearntHelper oContractLessonsLearntHelper = new ContractLessonsLearntHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iPriorityId, string sPriority, int iDistrictId, DateTime dtTripStartDate)
    {
        lblActivityChanges.Text = sPriority;
        activityChangePriorityHF.Value = iPriorityId.ToString();
        districtActivityHF.Value = iDistrictId.ToString();
        dtActivityTripStartDateHF.Value = dtTripStartDate.ToString();
        LoadActivityChange(iPriorityId);
    }

    #region   //***************** grdViewActivityChanges

    protected void grdViewActivityChanges_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdViewActivityChanges_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(activityChangePriorityHF.Value);
            if (e.CommandName.Equals("Insert"))
            {
                oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtActivityTripStartDateHF.Value);
                oContractLessonsLearnt.iDistrictId = int.Parse(districtActivityHF.Value);
                oContractLessonsLearnt.iPriorityId = iPriorityId;
                oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;

                oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)grdViewActivityChanges.FooterRow.FindControl("txtWhat")).Text);
                oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)grdViewActivityChanges.FooterRow.FindControl("txtWhy")).Text);
                oContractLessonsLearnt.sConsequences = Convert.ToString(((TextBox)grdViewActivityChanges.FooterRow.FindControl("txtConsequences")).Text);

                oContractLessonsLearntHelper.InsertLessonsLearnt(oContractLessonsLearnt);
                LoadActivityChange(iPriorityId);
            }

            if (e.CommandName.Equals("emptyInsert"))
            {
                GridViewRow emptyRow = grdViewActivityChanges.Controls[0].Controls[0] as GridViewRow;

                oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtActivityTripStartDateHF.Value);
                oContractLessonsLearnt.iDistrictId = int.Parse(districtActivityHF.Value);
                oContractLessonsLearnt.iPriorityId = iPriorityId;
                oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;

                oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)emptyRow.FindControl("txtWhat")).Text);
                oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)emptyRow.FindControl("txtWhy")).Text);
                oContractLessonsLearnt.sConsequences = Convert.ToString(((TextBox)emptyRow.FindControl("txtConsequences")).Text);

                oContractLessonsLearntHelper.InsertLessonsLearnt(oContractLessonsLearnt);
                LoadActivityChange(iPriorityId);
            }
            
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewActivityChanges_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int iPriorityId = int.Parse(activityChangePriorityHF.Value);
        grdViewActivityChanges.EditIndex = -1;
        LoadActivityChange(iPriorityId);
    }
    protected void grdViewActivityChanges_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdViewActivityChanges_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(activityChangePriorityHF.Value);
            grdViewActivityChanges.EditIndex = e.NewEditIndex;
            LoadActivityChange(iPriorityId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewActivityChanges_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(activityChangePriorityHF.Value);
            long lLessonId = Convert.ToInt64(grdViewActivityChanges.DataKeys[e.RowIndex].Values[0].ToString());

            oContractLessonsLearnt.lLessonId = lLessonId;
            oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtActivityTripStartDateHF.Value);
            oContractLessonsLearnt.iDistrictId = int.Parse(districtActivityHF.Value);
            oContractLessonsLearnt.iPriorityId = iPriorityId;
            oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;

            oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)grdViewActivityChanges.Rows[e.RowIndex].FindControl("txtWhat")).Text);
            oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)grdViewActivityChanges.Rows[e.RowIndex].FindControl("txtWhy")).Text);
            oContractLessonsLearnt.sConsequences = Convert.ToString(((TextBox)grdViewActivityChanges.Rows[e.RowIndex].FindControl("txtConsequences")).Text);

            oContractLessonsLearntHelper.UpdateLessonsLearnt(oContractLessonsLearnt);
            grdViewActivityChanges.EditIndex = -1;
            LoadActivityChange(iPriorityId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewActivityChanges_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int iPriorityId = int.Parse(activityChangePriorityHF.Value);
        long lLessonId = long.Parse(grdViewActivityChanges.DataKeys[e.RowIndex].Values[0].ToString());

        oContractLessonsLearnt.lLessonId = lLessonId;

        oContractLessonsLearntHelper.DeleteLessonsLearnt(oContractLessonsLearnt);
        ajaxWebExtension.showJscriptAlert(Page, this, "Milestone successfully deleted.");
        LoadActivityChange(iPriorityId);
    }

    private void LoadActivityChange(int iPriorityId)
    {
        try
        {
            System.Data.DataTable dt = oContractLessonsLearntHelper.dtGetLessonsLearntByPriorityDistrictTripStartDate(iPriorityId, int.Parse(districtActivityHF.Value), DateTime.Parse(dtActivityTripStartDateHF.Value));
            grdViewActivityChanges.DataSource = dt;
            grdViewActivityChanges.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    #endregion

}