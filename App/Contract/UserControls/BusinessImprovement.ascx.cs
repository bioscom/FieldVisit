using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Contract_UserControls_BusinessImprovement : aspnetUserControl
{
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractLessonsLearnt oContractLessonsLearnt = new ContractLessonsLearnt();
    ContractLessonsLearntHelper oContractLessonsLearntHelper = new ContractLessonsLearntHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iPriorityId, string sPriority, int iDistrictId, DateTime dtTripStartDate)
    {
        lblBusinessImprovement.Text = sPriority;
        businessImprovementPriorityHF.Value = iPriorityId.ToString();
        districtBusinessHF.Value = iDistrictId.ToString();
        dtBusinessTripStartDateHF.Value = dtTripStartDate.ToString();
        LoadBusinessImprovement(iPriorityId);
    }


    #region //******************** grdViewBusinessImprovement

    protected void grdViewBusinessImprovement_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdViewBusinessImprovement_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(businessImprovementPriorityHF.Value);
            if (e.CommandName.Equals("Insert"))
            {
                oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtBusinessTripStartDateHF.Value);
                oContractLessonsLearnt.iDistrictId = int.Parse(districtBusinessHF.Value);
                oContractLessonsLearnt.iPriorityId = iPriorityId;
                oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;
                oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)grdViewBusinessImprovement.FooterRow.FindControl("txtWhat")).Text);
                oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)grdViewBusinessImprovement.FooterRow.FindControl("txtValueCost")).Text);
                oContractLessonsLearnt.sConsequences = Convert.ToString(((TextBox)grdViewBusinessImprovement.FooterRow.FindControl("txtEase")).Text);

                oContractLessonsLearntHelper.InsertLessonsLearnt(oContractLessonsLearnt);
                LoadBusinessImprovement(iPriorityId);
            }

            if (e.CommandName.Equals("emptyInsert"))
            {
                GridViewRow emptyRow = grdViewBusinessImprovement.Controls[0].Controls[0] as GridViewRow;

                oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtBusinessTripStartDateHF.Value);
                oContractLessonsLearnt.iDistrictId = int.Parse(districtBusinessHF.Value);
                oContractLessonsLearnt.iPriorityId = iPriorityId;
                oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;
                oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)emptyRow.FindControl("txtWhat")).Text);
                oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)emptyRow.FindControl("txtValueCost")).Text);
                oContractLessonsLearnt.sConsequences = Convert.ToString(((TextBox)emptyRow.FindControl("txtEase")).Text);

                oContractLessonsLearntHelper.InsertLessonsLearnt(oContractLessonsLearnt);
                LoadBusinessImprovement(iPriorityId);
            }
            
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewBusinessImprovement_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int iPriorityId = int.Parse(businessImprovementPriorityHF.Value);
        grdViewBusinessImprovement.EditIndex = -1;
        LoadBusinessImprovement(iPriorityId);
    }
    protected void grdViewBusinessImprovement_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdViewBusinessImprovement_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(businessImprovementPriorityHF.Value);
            grdViewBusinessImprovement.EditIndex = e.NewEditIndex;
            LoadBusinessImprovement(iPriorityId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewBusinessImprovement_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(businessImprovementPriorityHF.Value);
            long lLessonId = Convert.ToInt64(grdViewBusinessImprovement.DataKeys[e.RowIndex].Values[0].ToString());

            oContractLessonsLearnt.lLessonId = lLessonId;
            oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtBusinessTripStartDateHF.Value);
            oContractLessonsLearnt.iDistrictId = int.Parse(districtBusinessHF.Value);
            oContractLessonsLearnt.iPriorityId = iPriorityId;
            oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;
            oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)grdViewBusinessImprovement.Rows[e.RowIndex].FindControl("txtWhat")).Text);
            oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)grdViewBusinessImprovement.Rows[e.RowIndex].FindControl("txtValueCost")).Text);
            oContractLessonsLearnt.sConsequences = Convert.ToString(((TextBox)grdViewBusinessImprovement.Rows[e.RowIndex].FindControl("txtEase")).Text);

            oContractLessonsLearntHelper.UpdateLessonsLearnt(oContractLessonsLearnt);
            grdViewBusinessImprovement.EditIndex = -1;
            LoadBusinessImprovement(iPriorityId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewBusinessImprovement_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int iPriorityId = int.Parse(businessImprovementPriorityHF.Value);
        long lLessonId = long.Parse(grdViewBusinessImprovement.DataKeys[e.RowIndex].Values[0].ToString());

        oContractLessonsLearnt.lLessonId = lLessonId;

        oContractLessonsLearntHelper.DeleteLessonsLearnt(oContractLessonsLearnt);
        ajaxWebExtension.showJscriptAlert(Page, this, "Milestone successfully deleted.");
        LoadBusinessImprovement(iPriorityId);
    }
    private void LoadBusinessImprovement(int iPriorityId)
    {
        try
        {
            System.Data.DataTable dt = oContractLessonsLearntHelper.dtGetLessonsLearntByPriorityDistrictTripStartDate(iPriorityId, int.Parse(districtBusinessHF.Value), DateTime.Parse(dtBusinessTripStartDateHF.Value));
            grdViewBusinessImprovement.DataSource = dt;
            grdViewBusinessImprovement.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    #endregion

}