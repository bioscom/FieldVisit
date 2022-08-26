using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Contract_UserControls_LessonLearnt : aspnetUserControl
{
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractLessonsLearnt oContractLessonsLearnt = new ContractLessonsLearnt();
    ContractLessonsLearntHelper oContractLessonsLearntHelper = new ContractLessonsLearntHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(int iPriorityId, string sPriority, int iDistrictId, DateTime dtTripStartDate)
    {
        lblLessonLearnt.Text = sPriority;
        lessonLearntPriorityHF.Value = iPriorityId.ToString();
        districtLessonHF.Value = iDistrictId.ToString();
        dtLessonTripStartDateHF.Value = dtTripStartDate.ToString();
        LoadLessonLearnt(iPriorityId);
    }

    #region //******************* grdViewLessonsLearnt

    protected void grdViewLessonsLearnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdViewLessonsLearnt_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(lessonLearntPriorityHF.Value);
            if (e.CommandName.Equals("Insert"))
            {
                oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtLessonTripStartDateHF.Value);
                oContractLessonsLearnt.iDistrictId = int.Parse(districtLessonHF.Value);
                oContractLessonsLearnt.iPriorityId = iPriorityId;
                oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;
                oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)grdViewLessonsLearnt.FooterRow.FindControl("txtWhat")).Text);
                oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)grdViewLessonsLearnt.FooterRow.FindControl("txtAction")).Text);
                oContractLessonsLearnt.sConsequences = "";

                oContractLessonsLearntHelper.InsertLessonsLearnt(oContractLessonsLearnt);
                LoadLessonLearnt(iPriorityId);
            }

            if (e.CommandName.Equals("emptyInsert"))
            {
                GridViewRow emptyRow = grdViewLessonsLearnt.Controls[0].Controls[0] as GridViewRow;

                oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtLessonTripStartDateHF.Value);
                oContractLessonsLearnt.iDistrictId = int.Parse(districtLessonHF.Value);
                oContractLessonsLearnt.iPriorityId = iPriorityId;
                oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;
                oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)emptyRow.FindControl("txtWhat")).Text);
                oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)emptyRow.FindControl("txtAction")).Text);
                oContractLessonsLearnt.sConsequences = "";

                oContractLessonsLearntHelper.InsertLessonsLearnt(oContractLessonsLearnt);
                LoadLessonLearnt(iPriorityId);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewLessonsLearnt_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int iPriorityId = int.Parse(lessonLearntPriorityHF.Value);
        grdViewLessonsLearnt.EditIndex = -1;
        LoadLessonLearnt(iPriorityId);
    }
    protected void grdViewLessonsLearnt_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdViewLessonsLearnt_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(lessonLearntPriorityHF.Value);
            grdViewLessonsLearnt.EditIndex = e.NewEditIndex;
            LoadLessonLearnt(iPriorityId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewLessonsLearnt_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int iPriorityId = int.Parse(lessonLearntPriorityHF.Value);
            long lLessonId = Convert.ToInt64(grdViewLessonsLearnt.DataKeys[e.RowIndex].Values[0].ToString());

            oContractLessonsLearnt.lLessonId = lLessonId;
            oContractLessonsLearnt.dtTripStartDate = DateTime.Parse(dtLessonTripStartDateHF.Value);
            oContractLessonsLearnt.iDistrictId = int.Parse(districtLessonHF.Value);
            oContractLessonsLearnt.iPriorityId = iPriorityId;
            oContractLessonsLearnt.iUserId = oSessnx.getOnlineUser.m_iUserId;
            oContractLessonsLearnt.sWhat = Convert.ToString(((TextBox)grdViewLessonsLearnt.Rows[e.RowIndex].FindControl("txtWhat")).Text);
            oContractLessonsLearnt.sWhy = Convert.ToString(((TextBox)grdViewLessonsLearnt.Rows[e.RowIndex].FindControl("txtAction")).Text);
            oContractLessonsLearnt.sConsequences = "";

            oContractLessonsLearntHelper.UpdateLessonsLearnt(oContractLessonsLearnt);
            grdViewLessonsLearnt.EditIndex = -1;
            LoadLessonLearnt(iPriorityId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdViewLessonsLearnt_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int iPriorityId = int.Parse(lessonLearntPriorityHF.Value);
        long lLessonId = long.Parse(grdViewLessonsLearnt.DataKeys[e.RowIndex].Values[0].ToString());

        oContractLessonsLearnt.lLessonId = lLessonId;

        oContractLessonsLearntHelper.DeleteLessonsLearnt(oContractLessonsLearnt);
        ajaxWebExtension.showJscriptAlert(Page, this, "Delete Successful.");
        LoadLessonLearnt(iPriorityId);
    }

    private void LoadLessonLearnt(int iPriorityId)
    {
        try
        {
            System.Data.DataTable dt = oContractLessonsLearntHelper.dtGetLessonsLearntByPriorityDistrictTripStartDate(iPriorityId, int.Parse(districtLessonHF.Value), DateTime.Parse(dtLessonTripStartDateHF.Value));
            grdViewLessonsLearnt.DataSource = dt;
            grdViewLessonsLearnt.DataBind();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    #endregion
}